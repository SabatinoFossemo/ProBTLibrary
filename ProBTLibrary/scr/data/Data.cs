namespace ProBT
{
    public class DataModel
    {
        static int count = 0;
        List<Quote> Data { get; set;}

        public DataModel()
        {
            Data = new List<Quote>();
        }

        public void Add(Quote data)
        {
            if(count >= 10 ){
                return;
            }

            this.Data.Add(data);
            DataModel.count++;
        }   

        public Quote Data1 { get => this.Data[0]; } 
        public Quote Data2 { get => this.Data[1]; } 
        public Quote Data3 { get => this.Data[2]; } 
        public Quote Data4 { get => this.Data[3]; } 
        public Quote Data5 { get => this.Data[4]; } 
        public Quote Data6 { get => this.Data[5]; } 
        public Quote Data7 { get => this.Data[6]; } 
        public Quote Data8 { get => this.Data[7]; } 
        public Quote Data9 { get => this.Data[8]; } 
        public Quote Data10 { get => this.Data[9]; } 
    }


}