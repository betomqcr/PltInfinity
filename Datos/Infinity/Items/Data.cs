namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public partial struct Data
    {
        public List<Datum> AnythingArray;
        public string String;

        public static implicit operator Data(List<Datum> AnythingArray) => new Data { AnythingArray = AnythingArray };
        public static implicit operator Data(string String) => new Data { String = String };


    }
}
