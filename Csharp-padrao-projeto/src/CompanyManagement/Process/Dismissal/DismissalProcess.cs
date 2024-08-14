namespace Csharp_padrao_projeto.src.Process.Dismissal
{
    public abstract class DismissalProcess : Process
    {
        public abstract void Apply(DismissalArgs args);
    }
}