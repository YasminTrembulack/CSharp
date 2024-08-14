using Csharp_padrao_projeto.src.Process;
using Csharp_padrao_projeto.src.Process.Dismissal;
using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.County.Brazil
{
    public class BrazilProcessFactory : IProcessFactory
    {
        public DismissalProcess CreateDismissalProcess()
            => new BrazilDismissalProcess();
    
        public WagePaymentProcess CreateWagePaymentProcess()
            => new BrazilWagePaymentProcess();
    }
}