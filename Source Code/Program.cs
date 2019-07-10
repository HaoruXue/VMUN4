using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VMUN_4
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Welcome());
            
        }

        
            }
    public class Lists
    {

        public bool excelUsed;
        public List<string> allCountry;
        public List<string> speakersList;
        public List<int> mcCountryIndex;
        public List<string> mcCountryName;
        public List<string> allCountryUpper;
        public List<paper> papers = new List<paper>();
        public double[,] data;
        public string reminder1 = "";
        public string reminder2 = "";
        public Lists()
        {
            allCountry = new List<string>();
            speakersList = new List<string>();
            excelUsed = false;
            mcCountryIndex = new List<int>();
            mcCountryName = new List<string>();
            allCountryUpper = new List<string>();
        }

        public void readFromTxt(int languageIndex)//读取txt中的国家名到allCountry
        {

            allCountry.Clear();
            string fileLocation = $"{System.Windows.Forms.Application.StartupPath}/Country.txt";
            excelUsed = false;
            StreamReader reader = new StreamReader(fileLocation, Encoding.GetEncoding("GB2312"));
            try
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    allCountry.Add(line);
                    allCountryUpper.Add(line.ToUpper());
                    line = reader.ReadLine();

                }
                reader.Dispose();
            }
            catch (Exception e)
            {
                reader.Dispose();
                MessageBox.Show(e.Message);
                
            }
            /* 测试代码
                 for (int j=0; j<allCountry.Count;j++)
             {
                daisConsole.listEvents.Items.Add(allCountry[j]);
             }  
             */


        }

        public void reloadData()
        {
            data = new double[allCountry.Count, 9];
            string unreadable = "";
            if (File.Exists(Application.StartupPath + "/Data.txt"))
            {
                StreamReader reader;
                reader = new StreamReader(Application.StartupPath + "/Data.txt", Encoding.GetEncoding("GB2312"));
                try
                {
                    string line = reader.ReadLine();
                    while (line == "//")
                    {
                        line = reader.ReadLine();
                        string countryName = line;
                        if (findAMatch(countryName))
                        {
                            int countryIndex = allCountry.IndexOf(countryName);                          
                            data[countryIndex, 0] = countryIndex;
                            int actionIndex = 1;
                            line = reader.ReadLine();
                            while (line != "//" && line != null)
                            {
                                data[countryIndex, actionIndex++] = double.Parse(line);
                                line = reader.ReadLine();
                            }
                        }
                        else
                        {
                            unreadable += countryName + ", ";
                            while (line != "//" && line != null)
                            {
                                line = reader.ReadLine();
                            }

                        }
                        line = reader.ReadLine();
                    }
                    for (int i = 0; i < data.GetLength(0); i++)
                    {
                        data[i, 0] = i;
                        for (int j = 1; j < 9; j++)
                        {
                            if (!(data[i, j] >= 0))
                            {
                                data[i, j] = 0;
                            }
                        }
                    }
                    line = reader.ReadLine();
                    while (line != "/Reminder2/")
                    {
                        reminder1 += line + Environment.NewLine;
                        line = reader.ReadLine();
                    }
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        reminder2 += line + Environment.NewLine;
                        line = reader.ReadLine();
                    }

                    reader.Dispose();
                    if (unreadable != "")
                    {
                        MessageBox.Show("The following countries in Data.txt could not be matched with any country in Country.txt: " + Environment.NewLine + "以下Data.txt中的国家无法在Country.txt中找到对应：" + Environment.NewLine + unreadable);

                    }
                }
                catch (Exception e)
                {
                    reader.Dispose();
                    MessageBox.Show(e.Message + " Data.txt");
                    
                }
            }
        }

        private bool findAMatch(string countryName)
        {
            int countryIndex = allCountry.IndexOf(countryName);
            if (countryIndex ==-1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<string> readEvent(int languageIndex)
        {
            List<string> eventList = new List<string>();
            
            if (File.Exists(Application.StartupPath + "/Event.txt"))
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "/Event.txt", Encoding.GetEncoding("GB2312"));               
                try
                {
                    string line = reader.ReadLine();
                    while (line !=null)
                    {
                        eventList.Add(line);
                        line = reader.ReadLine();
                    }
                    reader.Dispose();
                    return eventList;

                }
                catch (Exception ex)
                {
                    reader.Dispose();
                    MessageBox.Show(ex.Message + " Event.txt");
                    
                    eventList = new List<string>();
                    return eventList;

                }

            }
            else
            {
                return eventList;
            }
        }
        public List<paper> readFile(int languageIndex)
        {
            List<paper> papers = new List<paper>();
            List<string> allRecord = new List<string>();
            int nowLine = 0;
            if (File.Exists(Application.StartupPath + "/File.txt"))
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "/File.txt", Encoding.GetEncoding("GB2312"));
            
                try
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        allRecord.Add(line);
                        line = reader.ReadLine();
                    }
                    reader.Dispose();
                    while (nowLine <allRecord.Count-7)
                    {
                        if (allRecord[nowLine] == "{" && nowLine < allRecord.Count-6)
                        {
                            paper newPaper = new paper();
                            newPaper.paperName = allRecord[++nowLine];
                            newPaper.filePath = allRecord[++nowLine];
                            if (allRecord[++nowLine] == "/%/") 
                            {
                                while (allRecord[++nowLine] != "/%/")
                                {
                                    newPaper.sponsors.Add(allRecord[nowLine]);
                                }
                                while (allRecord[++nowLine] != "/%/")
                                {
                                    newPaper.signatories.Add(allRecord[nowLine]);
                                }
                                if (allRecord[++nowLine] == "}")
                                {
                                    papers.Add(newPaper);
                                    nowLine++;
                                }
                                else
                                {
                                    papers = new List<paper>();
                                    return papers;

                                }
                            }
                            else
                            {
                                papers = new List<paper>();
                                return papers;
                            }

                            
                        }
                        else
                        {
                            papers = new List<paper>();
                            return papers;
                        }
                    }
                    return papers;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " File.txt");
                    reader.Dispose();
                    papers = new List<paper>();
                    return papers;

                }
                finally
                {
                    reader.Dispose();
                }

            }
            else
            {
                return papers;
            }
        }
    }

    public class Motion
    {
        public int motionIndex;
        public int raisedBy;
        public double totalTime;
        public int eachTime;
        public int[] speakerIndex;
        public string topic;
        public bool passed;
        public DateTime submitTime;
        public Motion(int motionIndex, int raisedBy, string totalTime = "", string eachTime = "", string topic = "", bool passed = false )
        {
            this.motionIndex = motionIndex;
            this.raisedBy = raisedBy;
            this.passed = passed;
            switch (motionIndex)
            {
                case 0://MC
                    this.totalTime = double.Parse(totalTime);
                    this.eachTime = int.Parse(eachTime);
                    this.topic = topic;
                    
                    break;
                case 1://UMC
                    this.totalTime = double.Parse(totalTime);
                    break;
                case 2://Free Debate
                    this.totalTime = double.Parse(totalTime);
                    break;
                case 3://Suspend
                    break;
                case 4://Close
                    break;
                case 5://Other
                    this.topic = topic;
                    break;


            }
                     
            this.submitTime = DateTime.Now;
        }
    }

    public class Voting
    {
        public string fileName;
        public int nowIndex;
        public int[] choices;
        public int yes;
        public int no;
        public int yesnoam;
        public int yesnosm;
        public int votesam;
        public int votessm;
        public int allam;
        public int allsm;
        public int pass;
        public int abstain;
        public int favorRate;
        public int allCountry;
        public List<int> presentCountryIndex;
        public Voting(string fileName,Lists lists, double[,] data )
        {
            presentCountryIndex = new List<int>();
            this.fileName = fileName;
            for (int i=0;i<data.GetLength(0);i++)
            {
                if (data[i,8]==1)
                {
                    presentCountryIndex.Add(i);
                }
            }
            nowIndex = 0;
            this.allCountry = lists.allCountry.Count;
            choices = new int[presentCountryIndex.Count];          
            for (int i =0;i< presentCountryIndex.Count;i++)
            {
                choices[i] = 0;
            }
            calculate();
        }

        public void choose(int theIndex, int choice)
        {
            choices[theIndex] = choice;
        }

        public void calculate()
        {
            yes = 0;
            no = 0;
            abstain = 0;
            pass = 0;
            allam = int.Parse(Math.Ceiling(double.Parse(allCountry.ToString()) * 2 / 3).ToString());
            allsm = int.Parse(Math.Ceiling((double.Parse(allCountry.ToString())+1) / 2).ToString());
            for (int i = 0;i<choices.GetLength(0);i ++)
            {
                switch (choices[i])
                {
                    case 0:
                        break;
                    case 1:
                        yes++;
                        break;
                    case 2:
                        no++;
                        break;
                    case 3:
                        abstain++;
                        break;
                    case 4:
                        pass++;
                        break;
                }

            }
            yesnoam = int.Parse(Math.Ceiling((double.Parse(yes.ToString()) + double.Parse(no.ToString())) * 2 / 3).ToString());
            yesnosm = int.Parse(Math.Ceiling((double.Parse(yes.ToString()) + double.Parse(no.ToString())+1)/2).ToString());
            votesam = int.Parse(Math.Ceiling((double.Parse(yes.ToString()) + double.Parse(no.ToString())+double.Parse(pass.ToString())+double.Parse(abstain.ToString())) * 2 / 3).ToString());
            votessm = int.Parse(Math.Ceiling((double.Parse(yes.ToString()) + double.Parse(no.ToString()) + double.Parse(pass.ToString()) + double.Parse(abstain.ToString())+1) /2).ToString());
            if (yes + no > 0)
            {
                favorRate = yes * 100 / (yes + no);
            }
            else
                favorRate = 0;
            
        }
       
        

       public void endVoting()
        {
            calculate();

        }

        public void cancel()
        {
            
        }
    }

    public class paper
    {
        public int paperType;
        public string paperName;
        public List<string> sponsors;
        public List<string> signatories;
        public string filePath;
        public paper()
        {
            paperType = -1;
            paperName = "";
            sponsors = new List<string>();
            signatories = new List<string>();
            filePath = "na";
        }
    }



}
