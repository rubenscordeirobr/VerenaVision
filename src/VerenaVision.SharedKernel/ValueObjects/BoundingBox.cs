namespace VerenaVision.Shared.ValueObjects;

/// <summary>
/// Represents the bounding box of a detection.
/// </summary>
/// <param name="X">The X coordinate of the top-left corner.</param>
/// <param name="Y">The Y coordinate of the top-left corner.</param>
/// <param name="Width">The width of the bounding box.</param>
/// <param name="Height">The height of the bounding box.</param>
public record BoundingBox : ValueObjectBase
{
    public double X { get; init; }
    public double Y { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }

    public sealed override string ToString()
       => $"X: {X}, Y:{Y}, Width:{Width}, Height:{Height}";

    public string ToJson()
      => JsonUtils.Serialize(this);

    public static Result<BoundingBox> Create(double x, double y, double width, double height)
    {
        if (x is < 0 or > 1)
        {
            return Result.ValidationFailure<BoundingBox>(
                "BoundingBox.InvalidX",
                "X must be between 0 and 1.");
        }
        if (y is < 0 or > 1)
        {
            return Result.ValidationFailure<BoundingBox>(
                "BoundingBox.InvalidY",
                "Y must be between 0 and 1.");
        }

        if(width is < 0 or > 1)
        {
            return Result.ValidationFailure<BoundingBox>(
                "BoundingBox.InvalidWidth",
                "Width must be between 0 and 1.");
        }

        if(height is < 0 or > 1)
        {
            return Result.ValidationFailure<BoundingBox>(
                "BoundingBox.InvalidHeight",
                "Height must be between 0 and 1.");
        }

        return Result.Success(new BoundingBox
        {
            X = x,
            Y = y,
            Width = width,
            Height = height
        });
    }

    public static BoundingBox Empty
        => new BoundingBox();

    public static BoundingBox Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Empty;
        
        var boundingBox = JsonUtils.Deserialize<BoundingBox>(value);
        return boundingBox ?? Empty;    
    }
}
