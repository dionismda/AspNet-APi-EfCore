namespace AspNet_Api_EfCore.ViewModels
{
    public class ResultViewModel<TObject> : IResultViewModel<TObject>
    {
        public ResultViewModel(string type, string message, object result)
        {
            Type = type;
            Message = message;
            Result = result;
        }

        public string Type { get; private set; }
        public string Message { get; private set; }
        public object Result { get; private set; }
    }

}
