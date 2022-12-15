namespace ProBT
{
    public interface IDataBase
    {
        void SaveData();
        void LoadData();
    }

    public interface IQuote
    {
        List<DateTime> Date {get; }
        List<double> Open {get; }
        List<double> High {get; }
        List<double> Low {get; }
        List<double> Close {get; }

        IQuoteInfo Info { get; }
    }

    public interface IQuoteInfo
    {
        string Symbol {get; }
        string Category {get; }
        string Sector {get; }
        double TickSize {get; }
        decimal BigPointValue {get; }
    }



    public interface IOrder
    {
        string Name { get; }
        ORDER_TYPE Type { get; }
        ORDER_PRICE PriceS { get; }
        double PriceD { get; }
        double StopLoss { get; }
        double TakeProfit { get; }

        void SetStopLoss(double point);
        void SetTakeProfit(double point);        
    }

    public interface IOrders
   {
        List<IOrder> Orders { get; }

        void Append(IOrder order);
        void Remove(IOrder order);
        IOrders Reset();
   }

    public interface IPosition
    {
        string Name { get; }
        ORDER_TYPE Type { get; }
        DateTime EntryDate { get; }
        double EntryPrice { get; }
        double StopLoss { get; }
        double TakeProfit { get; }

        decimal MAE { get; set; }
        decimal MFE { get; set; }
        decimal Profit { get; set; }
    }

    public interface ITrade: IPosition
    {
        DateTime ExitDate { get; }
        double ExitPrice { get; }
        string ExitReason { get; }
    }

    public interface ITrades
    {
        List<ITrade> Trades{get;}

        void Append(ITrade trade);
    }

    public interface IStrategy
    {
        IQuote Quote { get; }
        IOrders Orders { get; }
        IPosition Position { get; }
        ITrades Trades { get; }
        IEquity Equity { get; }

        void INIT();
        void ONBAR();
        void DEINIT();

        void UpdateQuote();
        void OrderExecute();
    }


    public interface IPoint
    {
        int ID { get; }
        ORDER_TYPE Type { get; }
        DateTime Date { get; }
        decimal Peak { get; }
        decimal Valley { get; }
        decimal Close { get; }
    }

    public interface IEquity
    {
        decimal InitialBalance { get; }
        List<IPoint> Point { get; }
    }

    public interface IPerformanceReport: ISummary, ITradeAnalysis, IPeriodicalAnalysis
    {
        ITrades Trades { get; }
        IEquity Equity { get; }

        IPerformanceReport Generate();
    }

    public interface ISummary
    {
        Dictionary<string, object> Summary {get;}
    }

    public interface ITradeAnalysis
    {
        Dictionary<string, object> TradeAnalisys {get;}
    }

    public interface IPeriodicalAnalysis
    {
        Dictionary<string, object> PeriodicalAnalysis {get;}
    }

    
    public interface IBacktest
    {
        int MaxBarsBack { get; set; }
        decimal InitialBalance { get; set; }
        IQuote Quote { get; }
        IStrategy Strategy { get; }
        IOrders Orders { get; }
        IPosition Position { get; }
        ITrades Trades { get; }
        IPerformanceReport PerformanceReport { get; }

        IPerformanceReport Run();
    }

    public interface IPermutation
    {
        List<IPerformanceReport> backtestList { get; }

        void Run(IQuote _quote, IStrategy _strategy, int iter_number);
    }
}