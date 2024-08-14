using Csharp_padrao_projeto.src.Process;
using Csharp_padrao_projeto.src.Process.Dismissal;
using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.County.Argentina
{
    public class ArgentinaProcessFactory : IProcessFactory
    {
        public DismissalProcess CreateDismissalProcess()
            => new ArgentinaDismissalProcess();
    
        public WagePaymentProcess CreateWagePaymentProcess()
            => new ArgentinaWagePaymentProcess();
    }
}