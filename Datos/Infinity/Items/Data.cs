namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public partial struct Data
    {
        public string String;
        public List<Guid> UuidArray;

        public static implicit operator Data(string String) => new Data { String = String };
        public static implicit operator Data(List<Guid> UuidArray) => new Data { UuidArray = UuidArray };

    }
}
