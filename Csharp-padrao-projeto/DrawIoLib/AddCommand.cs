namespace DrawIo.Commands;
public class AddCommand : ICommand
{
    public VisualObject Object { get; set; }
    public void Execute(Project app)
    {
        app.Add(Object);
    }
    public void Undo(Project app)
    {
        app.Remove(Object);
    }
}