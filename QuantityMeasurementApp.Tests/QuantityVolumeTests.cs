using NUnit.Framework;
using QuantityMeasurementApp.Models;

namespace QuantityMeasurementApp.Tests
{
public class QuantityVolumeTests
{
private const double EPSILON = 1e-6;


    [Test]
    public void UC11_LitreToMillilitre_ShouldBeEqual()
    {
        var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
        var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);

        Assert.That(litre.Equals(ml), Is.True);
    }

    [Test]
    public void UC11_GallonToLitre_ShouldBeEqual()
    {
        var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.Gallon);
        var litre = new Quantity<VolumeUnit>(3.78541, VolumeUnit.Litre);

        Assert.That(gallon.Equals(litre), Is.True);
    }

    [Test]
    public void UC11_Convert_LitreToMillilitre()
    {
        var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);

        var result = litre.ConvertTo(VolumeUnit.Millilitre);

        Assert.That(result.Value, Is.EqualTo(1000.0).Within(EPSILON));
    }

    [Test]
    public void UC11_Convert_GallonToLitre()
    {
        var gallon = new Quantity<VolumeUnit>(1.0, VolumeUnit.Gallon);

        var result = gallon.ConvertTo(VolumeUnit.Litre);

        Assert.That(result.Value, Is.EqualTo(3.78541).Within(1e-4));
    }

    [Test]
    public void UC11_Add_LitreAndMillilitre()
    {
        var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
        var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);

        var result = litre.Add(ml);

        Assert.That(result.Value, Is.EqualTo(2.0).Within(EPSILON));
    }

    [Test]
    public void UC11_Add_WithExplicitTarget()
    {
        var litre = new Quantity<VolumeUnit>(1.0, VolumeUnit.Litre);
        var ml = new Quantity<VolumeUnit>(1000.0, VolumeUnit.Millilitre);

        var result = litre.Add(ml, VolumeUnit.Millilitre);

        Assert.That(result.Value, Is.EqualTo(2000.0).Within(EPSILON));
    }

    // UC12

    [Test]
    public void UC12_Subtraction_FeetMinusInches()
    {
        var q1 = new Quantity<LengthUnit>(10, LengthUnit.Feet);
        var q2 = new Quantity<LengthUnit>(6, LengthUnit.Inch);

        var result = q1.Subtract(q2);

        Assert.That(result.Value, Is.EqualTo(9.5).Within(0.01));
    }

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
