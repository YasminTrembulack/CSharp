



public abstract class Function
{
    protected abstract float Compute(float x);

    public float this[float x] => Compute(x);
    public abstract Function Derive();

    public static implicit operator Function(float value) 
        => new ConstantFunction(value);
    public static implicit operator Function(double value) 
    => new ConstantFunction((float)value);
}

public class ConstantFunction(float value) : Function
{
    protected override float Compute(float x) => x;
    public override Function Derive() 
        => new ConstantFunction(0);
}

public class LinearFunction : Function
{
    public override Function Derive()
        => 1f;

    protected override float Compute(float x)
    
}