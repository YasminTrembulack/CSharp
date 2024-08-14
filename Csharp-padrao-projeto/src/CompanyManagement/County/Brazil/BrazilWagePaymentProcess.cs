using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.County.Brazil
{
    
    public class BrazilWagePaymentProcess : WagePaymentProcess
    {
        public override string Title => "Pagamento de Salário";
    
        public override void Apply(WagePaymentArgs args)
        {
            args.Company.Money -= 1.45m * args.Employe.Wage + 500;
        }
    }
}