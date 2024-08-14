using Csharp_padrao_projeto.src.Process.Dismissal;
using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.Process
{
    public interface IProcessFactory
    {
        public WagePaymentProcess CreateWagePaymentProcess();
        public DismissalProcess CreateDismissalProcess();
    }
}