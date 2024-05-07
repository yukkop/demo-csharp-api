namespace Logic.Library;

public class Comparator
{
    public static bool Equals<T>(T obj1, T obj2) where T : class
    {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }

        if (obj1 is null || obj2 is null)
        {
            return false;
        }

        if (obj1.GetType() != obj2.GetType())
        {
            return false;
        }

        var properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var value1 = property.GetValue(obj1, null);
            var value2 = property.GetValue(obj2, null);

            if (value1 is null && value2 is null)
            {
                continue;
            }

            if (value1 is null || value2 is null)
            {
                return false;
            }

            if (!value1.Equals(value2))
            {
                return false;
            }
        }

        return true;
    }
}