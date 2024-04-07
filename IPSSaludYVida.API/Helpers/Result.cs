namespace IPSSaludYVida.API
{
    public class Result<T>
    {
        public Result()
        {
            Message = "Petición exitosa.";
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public T? Data { get; set; }
    }
}
