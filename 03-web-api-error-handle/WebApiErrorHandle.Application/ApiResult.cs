namespace WebApiErrorHandle.Application
{
    public class ApiResult
    {
        public Info Info { get; set; }
        public IList<Character> Results { get; set; }
    }

    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string? Next { get; set; }
        public string? Prev { get; set; }
    }
}
