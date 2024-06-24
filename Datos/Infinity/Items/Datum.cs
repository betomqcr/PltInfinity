namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public partial struct Datum
    {
        public long? Integer;
        public Guid? Uuid;

        public static implicit operator Datum(long Integer) => new Datum { Integer = Integer };
        public static implicit operator Datum(Guid Uuid) => new Datum { Uuid = Uuid };
    }
}
