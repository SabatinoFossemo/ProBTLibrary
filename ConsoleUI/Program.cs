using ProBT;
using System;

namespace TestCL;

class Program 
{
    static void Main(string[] args) 
    {
        string file_path = "/Users/sabatinofossemo/VSC_Project/CSHARP/ClassLibraryProjects/ShowCase/@CL.csv";

        Quote mydata = new Quote(file_path, "CL", "Futures", "Energy", 1000, 0.01);
        mydata.PrintInfo();
        mydata.AdjValueBelow0();
        // mydata.Statistics();

        MyStrategy mystrategy = new MyStrategy();

        ProBT.Backtest myBT = new ProBT.Backtest();
        myBT.MaxBarsBack = 200;
        myBT.InitialBalance = 100000;

        var report = myBT.Run(mydata, mystrategy);

        Console.WriteLine(report.Summary.ToString());

        //ProBT.Permutation myRand = new ProBT.Permutation();
        //myRand.Run(mydata, mystrategy, 1000);

    }
}

public class MyStrategy : ProBT.Strategy
{
    public override void Iniialize()
    {
    }

    public override void OnBarUpdate()
    {

        bool condition1 = C[0] < C[1];

        if(!condition1)
            Buy("close", "CL_DC");

        if(condition1)
            SellShort("close", "CL_DC");

    }

    public override void Deinitialize()
    {
    }

}