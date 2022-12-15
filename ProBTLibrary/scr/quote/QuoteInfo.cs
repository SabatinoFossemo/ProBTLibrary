namespace ProBT
{
    public class QuoteInfo
    {
        public string Symbol {get; }
        public string Category {get; }
        public string Sector {get; }
        public double TickSize {get; }
        public decimal BigPointValue {get; }

        public QuoteInfo(string symbol="NONE", string category="NONE", string sector="NONE", decimal bigpointvalue=1, double ticksize=1)
        {
            this.Symbol = symbol;
            this.Category = category;
            this.Sector = sector;
            this.BigPointValue = bigpointvalue;
            this.TickSize = ticksize;
        }
    }
}