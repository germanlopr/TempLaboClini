namespace TempLaboClini.Domain.ValueObjects
{
    public class Dinero
    {
        public decimal Cantidad { get; private set; }
        public string Moneda { get; private set; }

        public Dinero(decimal cantidad, string moneda)
        {
            if (cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            Cantidad = cantidad;
            Moneda = moneda;
        }

        public Dinero Sumar(Dinero otro)
        {
            if (otro.Moneda != Moneda)
                throw new ArgumentException("No se pueden sumar cantidades en diferentes monedas.");

            return new Dinero(Cantidad + otro.Cantidad, Moneda);
        }

        public override string ToString()
        {
            return $"{Cantidad} {Moneda}";
        }
    }

}
