namespace HavlinTasks
{
    //public string FTPPath1 = "";


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string FTPPath1 = "123";
            //Task<string> car1 = new Task<string>(fun);
            //car1.Start();
            //var numCar1 = car1.Result;
            //Task<string> car1 = new Task<string>(loadNumCar1(FTPPath1));

            //Task car1 = new Task(fun);
            //car1.Start();

            #region אופציה 1 לעשות את זה ואז לחסום אותו בפונקציות עצמם עם ברייק כשלשני יש תוצאה
            string carNum1 = "0";
            string carNum2 = "0";

            while (carNum1 == "0" && carNum2 == "0")
            {
                Task<string> numCar1 = Task<string>.Factory.StartNew(() =>
                   fun1());

                Task<string> numCar2 = Task<string>.Factory.StartNew(() =>
                fun2());
                //loadNumCar2(FTPPath2));

                carNum1 = numCar1.Result;
                carNum2 = numCar2.Result;

                //numCar1 = "";
                //numCar2 = "";
                GetWeight();


                //Console.WriteLine(carNum1);
                //Console.WriteLine(carNum2);
            }
            GetWeight();
            #endregion


            #region
            Task<string> numCar11 = Task<string>.Factory.StartNew(() => fun1());
            Task<string> numCar22 = Task<string>.Factory.StartNew(() => fun2());

            Task<string> completedTask = Task.WhenAny(numCar11, numCar22).Result; // Wait for the first completed task

            if (completedTask == numCar11)
            {
                carNum1 = completedTask.Result;
                // Process carNum1
            }
            else if (completedTask == numCar22)
            {
                carNum2 = completedTask.Result;
                // Process carNum2
            }

            // Now, you can continue with the rest of your code and call GetWeight()
            GetWeight();



            #endregion
        }




        void GetWeight()
        {
            //Console.WriteLine("get weight");
            string s = "weight";
        }

        public string fun1()
        {
            //Console.WriteLine("in fun1");
            return "0";
        }

        public string fun2()
        {
            //Console.WriteLine("in fun2");
            return "0";
        }
        public string loadNumCar1(string FTPPath)
        {
            string numCar = "0";
            while (numCar == "0")
            {
                Thread.Sleep(1000);
                numCar = getLisenceFTP1(FTPPath);
            }
            return numCar;
        }



        public string loadNumCar2(string FTPPath)
        {
            string numCar = "0";
            while (numCar == "0")
            {
                Thread.Sleep(1000);
                numCar = getLisenceFTP2(FTPPath);
            }
            return numCar;
        }


        public string getLisenceFTP1(string FTPPath1)//getLisenceFTP1
        {
            DirectoryInfo dir = new DirectoryInfo(FTPPath1);

            // Get only files (exclude directories) from the main folder
            FileSystemInfo[] files = dir.GetFileSystemInfos()
                .Where(f => f is FileInfo)
                .ToArray();

            // Sort the files by creation time
            Array.Sort(files, delegate (FileSystemInfo a, FileSystemInfo b)
            {
                return a.LastWriteTime.CompareTo(b.LastWriteTime);
            });

            int lenFile = files.Length;
            if (lenFile == 0)
            {
                return "0";
            }
            else
            {
                string fileName = files[lenFile - 1].FullName;
                string[] license = fileName.Split('_');
                license = license[0].Split('\\');
                return license[3];
            }
        }



        public string getLisenceFTP2(string FTPPath1)//getLisenceFTP1
        {
            DirectoryInfo dir = new DirectoryInfo(FTPPath1);

            // Get only files (exclude directories) from the main folder
            FileSystemInfo[] files = dir.GetFileSystemInfos()
                .Where(f => f is FileInfo)
                .ToArray();

            // Sort the files by creation time
            Array.Sort(files, delegate (FileSystemInfo a, FileSystemInfo b)
            {
                return a.LastWriteTime.CompareTo(b.LastWriteTime);
            });

            int lenFile = files.Length;
            if (lenFile == 0)
            {
                return "0";
            }
            else
            {
                string fileName = files[lenFile - 1].FullName;
                string[] license = fileName.Split('_');
                license = license[0].Split('\\');
                return license[4];
            }
        }
    }
}