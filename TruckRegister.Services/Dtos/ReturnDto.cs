namespace TruckRegister.Services.Dtos
{
    public class ReturnDto
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public bool Success { get; set; }

        public ReturnDto AddSuccess(string message)
        {
            Error = false;
            Success = true;
            Message = message;
            return this;
        }

        public ReturnDto AddError(string message)
        {
            Error = true;
            Success = false;
            Message = message;
            return this;
        }
    }
}
