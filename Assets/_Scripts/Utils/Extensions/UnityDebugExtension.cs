namespace KatanaRed.Utils
{
    public static class UnityDebug
    {
        public static void LogFormatted(params object[] args)
        {
            string debugString = "";
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0)
                    debugString += args[i];
                else
                    debugString += " | " + args[i];
            }
            UnityEngine.Debug.Log(debugString);
        }
    }
}