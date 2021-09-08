namespace Gallery.Models
{
    public interface IResult
    {
        string Error { get; set; }
        string Response { get; set; }
    }
}