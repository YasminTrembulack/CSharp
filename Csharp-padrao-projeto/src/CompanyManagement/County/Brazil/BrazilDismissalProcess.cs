using Csharp_padrao_projeto.src.Process.Dismissal;

namespace Csharp_padrao_projeto.src.County.Brazil
{
    public class BrazilDismissalProcess : DismissalProcess
    {
        public override string Title => "Demissão de Funcionário";

        public override void Apply(DismissalArgs args)
        {
            args.Company.Money -= 2 * args.Employe.Wage;
        }
    }
}