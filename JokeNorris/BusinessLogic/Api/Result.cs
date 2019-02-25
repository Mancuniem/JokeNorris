namespace JokeNorris.BusinessLogic.Api
{
    public class Result<TValue>
    {
        public string type { get; set; }
        public TValue value { get; set; }
    }
}
