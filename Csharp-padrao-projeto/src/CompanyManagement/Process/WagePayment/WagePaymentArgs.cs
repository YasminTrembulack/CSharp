namespace Csharp_padrao_projeto.src.Process.WagePayment
{
    public class WagePaymentArgs : ProcessArgs
    {
        public Company Company { get; set; }
        public Employee Employe { get; set; }
    }
}