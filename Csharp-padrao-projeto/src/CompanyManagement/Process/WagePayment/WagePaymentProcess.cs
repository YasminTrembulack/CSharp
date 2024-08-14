
using Csharp_padrao_projeto.src.Process;
using Csharp_padrao_projeto.src.Process.WagePayment;

namespace Csharp_padrao_projeto.src.Process.WagePayment
{
    public abstract class WagePaymentProcess : Process
    {
        public abstract void Apply(WagePaymentArgs args);
    }
}