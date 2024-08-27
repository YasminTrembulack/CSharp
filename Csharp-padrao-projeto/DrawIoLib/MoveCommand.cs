using System.Drawing;
namespace DrawIo.Commands;
public class MoveCommand : ICommand
{
    public ClassBox Object { get; set; }
    public PointF Old { get; set; }
    public PointF New { get; set; }
    public void Execute(Project app)
    {
        this.Old = Object.Rectangle.Location;
        Object.Rectangle = new RectangleF(New, this.Object.Rectangle.Size);
    }
    public void Undo(Project app)
    {
        Object.Rectangle = new RectangleF(Old, this.Object.Rectangle.Size);
    }
}