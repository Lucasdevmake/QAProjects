namespace QABuscaCepCorreio.Helper
{
    public class LogWriter
    {
        private string path = string.Empty;

        public LogWriter()
        {
            // LogWrite(logMessage);
        }

        public void LogWrite(string logMessage)
        {
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            try
            {
                using StreamWriter w = File.AppendText(path + "\\" + "log_test.txt");
                Log(logMessage, w);
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
            }
        }
    }
}
