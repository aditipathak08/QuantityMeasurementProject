namespace QuantityMeasurementApp.API.DTO
{
    public class LoginRequest//it takes data from fronend to backend and checks if data is valid or not
    {
        public string? Email { get; set; }// ? nullable value is possible
        public string? Password { get; set; }
    }
}
