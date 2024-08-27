namespace DrawIo.Commands;
public class PasteCommand : ICommand
{
    private VisualObject pasted = null;
    public void Execute(Project app)
    {
        this.pasted = app.Paste();
    }
    public void Undo(Project app)
    {
        if (this.pasted == null)
            return;
        app.Remove(this.pasted);
    }
}