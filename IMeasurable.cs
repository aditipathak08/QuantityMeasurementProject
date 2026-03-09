// Interface for all measurement units
public interface IMeasurable
{
    // Convert value to base unit
    double convertToBaseUnit(double value);

    // Convert base unit value to this unit
    double convertFromBaseUnit(double value);
}