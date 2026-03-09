using System;

// Enum to store weight units
public enum WeightUnit
{
    KILOGRAM,
    GRAM,
    POUND
}

// Helper class to handle unit conversion
public static class WeightUnitHelper
{
    // Convert any unit to the base unit (kilogram)
    public static double ToKilogram(double value, WeightUnit unit)
    {
        // If unit is already kilogram
        if (unit == WeightUnit.KILOGRAM)
            return value;

        // Convert gram to kilogram
        // 1000 g = 1 kg
        if (unit == WeightUnit.GRAM)
            return value * 0.001;

        // Convert pound to kilogram
        // 1 lb ≈ 0.453592 kg
        if (unit == WeightUnit.POUND)
            return value * 0.453592;

        return value;
    }

    // Convert kilogram to another unit
    public static double FromKilogram(double kgValue, WeightUnit targetUnit)
    {
        // If target is kilogram
        if (targetUnit == WeightUnit.KILOGRAM)
            return kgValue;

        // Convert kg to gram
        if (targetUnit == WeightUnit.GRAM)
            return kgValue * 1000;

        // Convert kg to pound
        if (targetUnit == WeightUnit.POUND)
            return kgValue / 0.453592;

        return kgValue;
    }
}