using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Atm atm = new Atm();
            atm.Run();
        }
    }

    public class Record
    {
        public string Name { get; set; }
        public int PinCode { get; set; }
        public double Balance { get; set; }

        public Record()
        {
            this.Name = String.Empty;
            this.PinCode = 0;
            this.Balance = 0.0;
        }

        public Record(string n, int pCode, double b)
        {
            this.Name = n;
            this.PinCode = pCode;
            this.Balance = b;
        }

        public override string ToString()
        {
            return string.Format(
                "The Name Is: {0}, PinCode Is: {0}, Balance Is: {2}",
                this.Name,
                this.PinCode,
                this.Balance
                );
        }
    }

    public class Atm
    {
        private const string DataFile = "data.txt";
        private List<Record> recordList = new List<Record>();

        public void AddNewRecord()
        {
            this.recordList.Add(new Record("jasper", 1122, 30000));
            this.recordList.Add(new Record("tom", 2211, 20000));
            this.recordList.Add(new Record("tanel", 1234, 80000));
            this.recordList.Add(new Record("andris", 4321, 10000));
            using (TextWriter tw = File.CreateText(DataFile))
            {
                foreach (Record record in this.recordList)
                {
                    tw.WriteLine(record.Name + "," + record.PinCode + "," + record.Balance);
                }

                tw.Close();
            }
        }

        public void LoadRecords()
        {
            this.recordList.Clear();
            if (File.Exists(DataFile))
            {
                using (TextReader tr = File.OpenText(DataFile))
                {
                    string[] data = null;
                    string line = tr.ReadLine();
                    while (line != null)
                    {
                        data = line.Split(',');
                        recordList.Add(new Record(data[0], int.Parse(data[1]), double.Parse(data[2])));
                        line = tr.ReadLine();
                    }

                    tr.Close();
                }
            }
            else
            {
                this.AddNewRecord();
            }
        }

        public void SaveRecords()
        {
            using (TextWriter tw = File.CreateText(DataFile))
            {
                foreach (Record record in this.recordList)
                {
                    tw.WriteLine(record.Name + "," + record.PinCode + "," + record.Balance);
                }

                tw.Close();
            }
        }

        private static void DisplayTransactionMenu(Record record)
        {
            Console.WriteLine("Welcome , " + record.Name.ToUpper());
            Console.WriteLine("Press 1 to withdraw money");
            Console.WriteLine("Press 2 to deposit money");
            Console.WriteLine("Press 3 to print balance");
        }

        private static void DisplayTopLevelMenu()
        {
            Console.WriteLine("Welcome.");
            Console.WriteLine("Enter your PIN or 'exit' to quit:");
        }

        private static bool TryGetPin(string input, out int pin)
        {
            pin = -1;
            return int.TryParse(input, out pin);
        }

        private bool TryGetRecord(int pin, out Record record)
        {
            record = this.recordList.Where(r => r.PinCode == pin).FirstOrDefault();
            return record != null;
        }

        private static bool TryGetOperation(string input, out int operation)
        {
            operation = -1;
            return int.TryParse(input, out operation);
        }

        internal void Run()
        {
            bool exit = false;
            do
            {
                DisplayTopLevelMenu();
                string input = Console.ReadLine();
                int pin;
                if (TryGetPin(input, out pin))
                {
                    Record record;
                    this.LoadRecords();
                    if (TryGetRecord(pin, out record))
                    {
                        DisplayTransactionMenu(record);
                        input = Console.ReadLine();
                        int operation;
                        if (TryGetOperation(input, out operation))
                        {
                            if (operation == 1)
                            {
                                this.Withdraw(record);
                            }

                            if (operation == 2)
                            {
                                this.Deposit(record);
                            }

                            if (operation == 3)
                            {
                                Print(record);
                            }
                        }
                    }
                }

                exit = input.Equals("exit");
            }
            while (!exit);
        }

        private void Withdraw(Record record)
        {
            throw new NotImplementedException();
        }

        private void Deposit(Record record)
        {
            throw new NotImplementedException();
        }

        private static void Print(Record record)
        {
            Console.WriteLine(record.ToString());
        }
    }
}
