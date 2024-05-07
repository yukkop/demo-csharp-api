namespace Logic.Externsions;

public static class ExceptionExtension
{
    public static List<string> GetListOfAllMessages(this Exception ex)
    {
        var messages = new List<string>();
        Exception? current = ex;

        while (ex != null)
        {
            messages.Add(ex.Message);
            current = current?.InnerException;
        }

        return messages;
    }

    public static string GetAllMessagesIntoString(this Exception ex)
    {
        var messages = new List<string>();
        Exception? current = ex;

        var counter = 0;
        // if will make more, pizdezz become fast
        while (counter < 10)
        {
            counter ++;
            messages.Add(ex.Message);
            current = current?.InnerException;
        }

        return string.Join("\n", messages);
    }
}