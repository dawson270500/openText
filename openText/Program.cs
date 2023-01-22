namespace OpenText
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        static Window main = null;
        static List<Window> subWindow = new List<Window>();
        static public string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        static public log Logger = new (DefaultPath);
       
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            main = new Window();
            Application.Run(main);
        }

        static public void MakeSubwin()
        {
            subWindow.Add(new Window(true));
            subWindow.Last().FormClosed += new System.Windows.Forms.FormClosedEventHandler(SubWinClose);
            subWindow.Last().Show();
        }

        static void SubWinClose(object sender, EventArgs e)
        {
            Window? closeMe = null;
            foreach (object window in subWindow)
            {
                Window holder = (Window)window;
                if(holder.Equals((Window)sender))
                {
                    closeMe = (Window)window;
                    break;
                }
            }

            if(closeMe != null)
            {
                subWindow.Remove(closeMe);
            }
            else
            {
                Logger.WriteLine($"Failed to close subwindow '{sender.GetType().Name}' '{sender.ToString}'");
                MessageBox.Show($"Failed to close subwindow '{sender.GetType().Name}' '{sender.ToString}'");
            }
        }

        static public bool GetWordWarp() => main.GetWordWarp();
    }
}