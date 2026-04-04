namespace Unibet.ValueObjects
{
    public class Amount
    {
        public decimal Value { get; set; }

        public Amount(decimal value)
        {
            if (value <= 0)
            {
                throw new Exception("Valor nao pode ser negativo");
            }

            this.Value = value;
        }
    }
}
