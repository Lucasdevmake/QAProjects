namespace QABuscaCepCorreio.Helper;

public class LogWriter
{
    private readonly string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

    public LogWriter()
    {
        // LogWrite(logMessage);
    }

    public void LogWrite(string logMessage)
    {
        try
        {
            using StreamWriter w = File.AppendText(path + "\\" + "log_test.txt");
            Log(logMessage, w);
        }
        catch
        {
        }
    }

    public void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.Write("\r\nLog Entry : ");
            txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            txtWriter.WriteLine(" ");
            txtWriter.WriteLine("  *{0}", logMessage);
            txtWriter.WriteLine("------------------------------------------------------------------------------------");
        }
        catch
        {
        }
    }
}
