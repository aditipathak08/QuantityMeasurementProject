using NUnit.Framework;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
public class QuantityAllUseCasesTests
{
private const double EPSILON = 1e-6;

    // UC1–UC4 : Length Equality

    [Test]
    public void UC1_SameUnit_ShouldBeEqual()
    {
        var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);

        Assert.That(q1.Equals(q2), Is.True);
    }

    [Test]
    public void UC3_CrossUnit_ShouldBeEqual()
    {
        var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

        Assert.That(q1.Equals(q2), Is.True);
    }

    [Test]
    public void UC4_YardToFeet_ShouldBeEqual()
    {
        var yard = new Quantity<LengthUnit>(1.0, LengthUnit.Yards);
        var feet = new Quantity<LengthUnit>(3.0, LengthUnit.Feet);

        Assert.That(yard.Equals(feet), Is.True);
    }

    // UC5 : Conversion

    [Test]
    public void UC5_Convert_FeetToInches()
    {
        var result = new Quantity<LengthUnit>(1.0, LengthUnit.Feet)
            .ConvertTo(LengthUnit.Inch);

        Assert.That(result.Value, Is.EqualTo(12.0).Within(EPSILON));
    }

    [Test]
    public void UC5_RoundTrip_ShouldPreserveValue()
    {
        var q = new Quantity<LengthUnit>(10.0, LengthUnit.Feet);

        var inches = q.ConvertTo(LengthUnit.Inch);
        var back = inches.ConvertTo(LengthUnit.Feet);

        Assert.That(back.Value, Is.EqualTo(10.0).Within(EPSILON));
    }

    // UC6 : Addition (Implicit)

    [Test]
    public void UC6_Add_SameUnit()
    {
        var result = new Quantity<LengthUnit>(1.0, LengthUnit.Feet)
            .Add(new Quantity<LengthUnit>(2.0, LengthUnit.Feet));

        Assert.That(result.Value, Is.EqualTo(3.0).Within(EPSILON));
    }

    [Test]
    public void UC6_Add_CrossUnit()
    {
        var result = new Quantity<LengthUnit>(1.0, LengthUnit.Feet)
            .Add(new Quantity<LengthUnit>(12.0, LengthUnit.Inch));

        Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
    }

    // UC7 : Addition (Explicit)

    [Test]
    public void UC7_Add_Explicit_Yards()
    {
        var result = new Quantity<LengthUnit>(1.0, LengthUnit.Feet)
            .Add(new Quantity<LengthUnit>(12.0, LengthUnit.Inch), LengthUnit.Yards);

        Assert.That(result.Value, Is.EqualTo(0.666666).Within(1e-4));
        Assert.That(result.Unit, Is.EqualTo(LengthUnit.Yards));
    }

    // UC8 : Enum Responsibility

    [Test]
    public void UC8_LengthUnit_BaseConversion()
    {
        double feet = LengthUnit.Inch.ConvertToBaseUnit(12.0);

        Assert.That(feet, Is.EqualTo(1.0).Within(EPSILON));
    }

    // UC10 : Generic Commutativity

    [Test]
    public void UC10_Addition_Commutativity()
    {
        var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.Inch);

        var r1 = q1.Add(q2);
        var r2 = q2.Add(q1);

        Assert.That(
            r1.ConvertTo(LengthUnit.Feet).Value,
            Is.EqualTo(r2.ConvertTo(LengthUnit.Feet).Value).Within(EPSILON)
        );
    }

    // UC12 : Subtraction

    [Test]
    public void UC12_Subtraction_FeetMinusInches()
    {
        var q1 = new Quantity<LengthUnit>(10, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(6, LengthUnit.Inch);

        var result = q1.Subtract(q2);

        Assert.That(result.Value, Is.EqualTo(9.5).Within(0.01));
    }

    // UC12 : Division

    [Test]
    public void UC12_Division_FeetByFeet()
    {
        var q1 = new Quantity<LengthUnit>(10, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(2, LengthUnit.Feet);

        double result = q1.Divide(q2);

        Assert.That(result, Is.EqualTo(5.0));
    }
}

}
