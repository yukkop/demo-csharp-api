namespace Logic.Model.Result.Shared;

public interface IPagination { }

public class Pagination<T>: IPagination
{
    public Pagination(
        List<T>? data,
        int taken,
        int skipped,
        int total
    )
    {
        Data = data;
        Taken = taken;
        Skipped = skipped;
        Total = total;
    }
    
    public List<T>? Data { get; set; }
    public int Taken { get; set; }
    public int Skipped { get; set; }
    public int Total { get; set; }
}