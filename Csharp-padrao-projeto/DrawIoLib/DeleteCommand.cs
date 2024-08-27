namespace DrawIo.Commands;
public class DeleteCommand : ICommand
{
    private VisualObject deleted = null;
    public void Execute(Project app)
    {
        this.deleted = app.Delete();
    }
    public void Undo(Project app)
    {
        if (this.deleted == null)
            return;
        app.Add(this.deleted);
    }
}