public interface IMeasurable
{
    double getConversionFactor();
    double convertToBaseUnit(double value);
    double convertFromBaseUnit(double value);

    // new method
    string getUnitName();
}