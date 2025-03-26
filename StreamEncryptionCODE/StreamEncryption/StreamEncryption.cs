using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;


namespace StreamEncryption
{
    public delegate void IndexedWork(int ind);
    public partial class StreamEncryption : Form
    {

        int encryptDegree = 33;
        byte[] input;
        string prepareString = null;
        private string fileNameOutput;
        public const int maxShow = 32767;
        

        public StreamEncryption()
        {
            InitializeComponent();
            tstrbtEncrypt.Click += new EventHandler(btEncodeOrDecode_Click);
            tstrbtDecrypt.Click += new EventHandler(btEncodeOrDecode_Click);
        }

        public static void ShowNotAllAtBeginAndEnd(int countBytes, string res, TextBox text)
        {
            int countBits = countBytes * 8;
            text.Invoke((Action)(() => {
                text.Text += "First:";
                for (int i = 0; i < countBits; i++)
                {
                    text.Text += res[i];
                }
                int endInd = res.Length;
                text.Text += "\n";
                text.Text += "Last:";
                for (int i = countBits; i > 0; i--)
                {
                    text.Text += res[endInd - i];
                }
            }));

        }

        private async void btInputFile_Click(object sender, EventArgs e)
        {
            if (ofdChooseFile.ShowDialog() == DialogResult.OK)
            {
                tbInput.Text = "";
                using (FileStream fileStream = new FileStream(ofdChooseFile.FileName, FileMode.Open))
                {
                    input = new byte[fileStream.Length];
                    fileStream.ReadAsync(input, 0, input.Length).Wait();
                    string result = null;
                    await Task.Run(() => result = WorkWithBinary.GetBinaryString(input, 2));
                    if (result.Length > maxShow)
                    {
                        ShowNotAllAtBeginAndEnd(30, result, tbInput);
                    }
                    else
                        tbInput.Text = result;
                    prepareString = result;
                }

            }
        }


        private void btOutputFile_Click(object sender, EventArgs e)
        {
            if (ofdChooseFile.ShowDialog() == DialogResult.OK)
            {

                fileNameOutput = ofdChooseFile.FileName;
            }
        }

        private async void btEncodeOrDecode_Click(object sender, EventArgs e) {
            tbOutput.Text = "";
            tbKey.Text = "";
            if (prepareString == null || prepareString.Length <= maxShow)
            {
                if (sender == tstrbtEncrypt)
                    prepareString = tbInput.Text;
                else
                    prepareString = tbOutput.Text;
            }
            string correctInput = await Task.Run(() => LFSR.GetOnlyBinaries(prepareString));
            if (correctInput == null)
            {
                MessageBox.Show("Ваш текст не содержит допустимых двоичных значений: 0 и 1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            input = await Task.Run(() => WorkWithBinary.GetBytesFromBinaryString(correctInput));
            if (input == null)
            {
                MessageBox.Show("Допустимый текст в двоичном виде не содержит целое число байтов.Ваша длина текста не кратна 8", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
           
             
            byte[] result;
            string iniStateRegister = LFSR.GetOnlyBinaries(tbSeanceKey.Text);
           

            if (iniStateRegister == null || iniStateRegister.Length != encryptDegree)
            {
                MessageBox.Show($"Начальное состояние регистра должно быть длиной {encryptDegree} двоичные цифры", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            LFSR register = new LFSR(iniStateRegister, encryptDegree);
            
            if (sender == tstrbtEncrypt)
            {
                result = await Task.Run(()=>register.Encode(input));
            }
            else
                result = await Task.Run(()=>register.Decode(input));

            byte[] bytesKey = register.keyBytes;
            string sRes = WorkWithBinary.GetBinaryString(result, 2);
            string bKey = WorkWithBinary.GetBinaryString(bytesKey, 2);

            if (sRes.Length > maxShow)
            {
                ShowNotAllAtBeginAndEnd(30, bKey, tbKey);
                ShowNotAllAtBeginAndEnd(30, sRes, tbOutput);
            }
            else
            {
                tbOutput.Text = sRes;
                tbKey.Text = bKey;
            }
            if (fileNameOutput != null)
            {
                using (FileStream fileStream = new FileStream(fileNameOutput, FileMode.Create))
                {
                    fileStream.WriteAsync(result, 0, result.Length).Wait();

                }
            }
            
        }

        private void tstrbtClean_Click(object sender, EventArgs e)
        {
            tbInput.Text = "";
            tbOutput.Text = "";
            tbSeanceKey.Text = "";
            tbKey.Text = "";
            input = null;
            fileNameOutput = null;
        }


        private void tbSeanceKey_TextChanged(object sender, EventArgs e)
        {
            int length = 0;
            if (LFSR.GetOnlyBinaries(tbSeanceKey.Text) != null)
                length = LFSR.GetOnlyBinaries(tbSeanceKey.Text).Length;
            lbSymbolsCount.Text = $"Количество двоичных символов регистра:{length}";
        }

    }

    public class TaskControl
    {
        public Task[] Tasks { get; set; }
        public int TasksForAll { get; set; }
        public TaskControl(int taskCount) 
        { 
            Tasks = new Task[taskCount];
        }
        public void distributeTasks(int countWork,IndexedWork work)
        {
            int modWork = countWork % Tasks.Length;
            int potentialWork= countWork / Tasks.Length;
            if (potentialWork == 0)
            {
                Tasks[0] = Task.Run(() => ProcessTask(0, modWork, work));
                Tasks[0].Wait();
            }
            else
            {
                int firstPoint = 0;
                for (int i = 0; i < Tasks.Length; i++)
                {
                    
                    int lastPoint = firstPoint + potentialWork + ((i < modWork) ? 1 : 0);
                    int localFirstPoint = firstPoint;
                   

                    Tasks[i] = Task.Run(() => ProcessTask(localFirstPoint, lastPoint, work));
                    firstPoint = lastPoint;

                }
                Task.WaitAll(Tasks);
            }
            
        }
        public void ProcessTask(int firstPoint,int lastPoint,IndexedWork Work)
        {
            for (int i = firstPoint; i < lastPoint; i++)
            {
                Work.Invoke(i);
            }
        }
    }

    public class WorkWithBinary
    {
        private static byte makeOneByte(string byteString,int pos,int byteLength)
        {
            byte b = 0;
            int code = '1';
            for (int i = 0; i < byteLength; i++)
            {
                b <<= 1;
                b |= (byte)((int)(byteString[pos])/code);
                pos++;
            }
            return b;
        }
        public static byte[] GetBytesFromBinaryString(string binarySting)
        {
            TaskControl taskControl = new TaskControl(33);
            int mod = binarySting.Length % 8;
            if (mod != 0)
                return null;
            int count = binarySting.Length / 8;
            byte[] bytes = new byte[count];
            
            taskControl.distributeTasks(count, (int ind) => { bytes[ind] = makeOneByte(binarySting, ind * 8, 8); });
            return bytes;
        }
        public static string GetBinaryString(byte[] bytes,int bas)
        {
            
            TaskControl taskControl = new TaskControl(33);
            char[] chars = new char[bytes.Length*8];

            
            taskControl.distributeTasks(bytes.Length, (int ind) => { AddByteToChars(chars,ind*8,bytes[ind]);});
            return new string(chars);
            
        }
        public static void AddByteToChars(char[] chars,int ind,byte b)
        {
            
            int curr = ind + 7;
            for (; curr >= ind; curr--)
            {

                chars[curr] = (char)((b & 1) + '0');
                b >>= 1;
            }
        }
    }
    public class LFSR
    {
        //private Int64 polyMask;
        private Int64 highMask;
        private Int64 keyMask;
        private Int64 lastBitMask;
        private const int maxDegree = 40;
        private const int minDegree = 23;
        private int startDegree = minDegree;
        private string iniState;
        public byte[] keyBytes;
        
        public string InitialState { get { return iniState; } set { if (value.Length == Degree) { iniState = GetOnlyBinaries(value); } } }
        private Int64 IntIniState;
        public int Degree { get { return startDegree; } set { if (value >= minDegree && value <= maxDegree) startDegree = value; } }

        /*static private Int64[] PolynomMasks = new Int64[] { 0b10000000000000000010000,0b100000000000000000001101,0b1000000000000000000000100,0b10000000000000000011000001,
            0b100000000000000000011000001,0b1000000000000000000000000100,0b10000000000000000000000000010,0b100000000000001100000000000001,
            0b1000000000000000000000000000100,0b10000000000000000001000000000000,0b100000000000000000110000000000001,0b1000000000000000000000000000000010,
            0b10000000000000000000000010000000000,0b100000000000000000000000101000000010,0b1000000000000000000000000000000110001,0b10000000000000000000000000000000001000,
            0b100000000000000000101000000000000000010};
        */
        
        public byte[] Encode(byte[] plainText)
        {
           
            byte[] encipher =  StreamEncodeOrDecode(plainText);
            return encipher;
        }
        public byte[] Decode(byte[] encodeText)
        {
           
            byte[] decipher = StreamEncodeOrDecode(encodeText);
            return decipher;
        }

        
        private byte[] StreamEncodeOrDecode(byte[] textBytes)
        {
            int textLength = textBytes.Length;
            keyBytes = GenerateKey(textLength);
            byte[] lastBytes = new byte[textLength];
            TaskControl taskControl = new TaskControl(33);
            taskControl.distributeTasks(textLength,(int ind) => { lastBytes[ind] = (byte)(textBytes[ind] ^ keyBytes[ind]); });
            return lastBytes; 
        }
        public LFSR(string initialState, int degree)
        {
            Degree = degree;
            InitialState = initialState;
            IntIniState = Convert.ToInt64(InitialState, 2);
            //polyMask = PolynomMasks[Degree - minDegree];
            keyMask = createKeyMask(Degree);
            highMask = createMask(degree);
            lastBitMask = createMask(1);
            lastBitMask = ~lastBitMask;
        }

        public static string GetOnlyBinaries(string initialState)
        {
          
            string good = new string(initialState.AsParallel().AsOrdered().Where(c => (c == '1' || c == '0') ).ToArray());
            if (good.Length == 0)
                return null;
            return good;
        }

        private void ShiftLeftAndInsert(ref Int64 iniState)
        {
            int insertValue = ((byte)(((iniState >> 32) & 1) ^ ((iniState >> 12) & 1)));
            iniState <<= 1;
            iniState = iniState & highMask;
            iniState = ((iniState & lastBitMask) | (Int64)insertValue);

        }
        
        private byte[] GenerateKey(int byteCount)
        {
            byte [] keyBytes = new byte[byteCount];

            
            Int64 thisState = IntIniState;

            for (int i = 0; i < byteCount; i++)
            {
                byte key = 0;
                for (int j = 0; j < 8; j++)
                {
                    key <<= 1;
                    key |= (byte)((thisState & keyMask)/keyMask);
                    ShiftLeftAndInsert(ref thisState);
                    
                }
                keyBytes[i] = key;
            }
            return keyBytes;
            
        }

        // подпрограмма для создания маски с целью отделения последнего бита ключа
        private Int64 createKeyMask(int length)
        {
            Int64 mask = 1;
            for (int i = 0; i < length-1; i++)
            {
                mask <<= 1;
            }
            return mask;
        }

        // подпрограмма для создания единичной маски 
        private Int64 createMask(int length)
        {
            Int64 mask = 1;
            Int64 temp;
            for (int i = 0; i < length - 1; i++)
            {
                temp = mask;
                mask <<= 1;
                mask |= temp;
            }
            return mask;
        }
    }


}
