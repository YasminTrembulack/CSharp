using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.County.Argentina
{
    public class ArgentinaWagePaymentProcess : WagePaymentProcess
    {
        public override string Title => "Pago de salario";
    
        public override void Apply(WagePaymentArgs args)
        {
            args.Company.Money -= 1.65m * args.Employe.Wage + 700;
        }
    }
}