using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Linq;

static class LogLine
{
    /* [Define] Declare and Initialise variables */
    // (Define-sub) Class-level Constants
    const string template = "[<LEVEL>]: <MESSAGE>";
    enum LOGLEVELS {
        INFO,
        WARNING,
        ERROR
        }

    private static int ReturnIndexOfFirstCharacterInLogLine(string logLine, string character)
    {
        int indexOfFirstCharacterInLogLine = logLine.IndexOf(character);
        return indexOfFirstCharacterInLogLine;
    }
    public static string Message(string logLine)
    {
        /* [Define] Declare and Initialise variables or logic */
        // (SUB) Output Variable
        string output = default;
        // (SUB) Process Variables
        // (SUB) Process Logic
        void ActionSurroundingLeadingWhitespaces (ref string logLine) { 
            logLine = logLine.Trim();
        };
        void ActionClipLogLevelPart(ref string logLine) {
            int indexOfMessageStart = ReturnIndexOfFirstCharacterInLogLine(logLine, ":") + 1;
            logLine = logLine.Substring(indexOfMessageStart);
            Console.WriteLine(logLine);
        };
        
        string ExtractMessageFromLogLine(string logLine)
        {
            ActionClipLogLevelPart(ref logLine);
            Console.WriteLine(logLine);
            ActionSurroundingLeadingWhitespaces(ref logLine);
            return logLine;
        };

        /* [Process] Perform logic on earlier-defined members */
        output = ExtractMessageFromLogLine(logLine);

        /* [Conclude] Conclude the Method's intent */
        return output;
    }

    public static string LogLevel(string logLine)
    {
        /* [Define] Declare and Initialise variables or logic */
        // (SUB) Output Variable
        string output = default;
        // (SUB) Process Variables
        string errorMessage = "no log level was recognised of: " + string.Join(" ", Enum.GetNames(typeof(LOGLEVELS)).Select(name => name.ToUpper()));
        (string, string) logLineData = (LogLine: logLine, ErrorMessage: errorMessage);
        // (SUB) Process Logic
        string ExtractLogLevel((string LogLine, string ErrorMessage) logLineData)
        {
            int indexOfFirstLeftSquareBracketInLogLine = ReturnIndexOfFirstCharacterInLogLine(logLine, "]");
            int indexOfFirstRightSquareBracketInLogLine = ReturnIndexOfFirstCharacterInLogLine(logLine, "[");
            string extractedLogLevel = logLineData.LogLine.Substring(indexOfFirstRightSquareBracketInLogLine+1, indexOfFirstLeftSquareBracketInLogLine-1);
            return extractedLogLevel.ToLower();
        };

        /* [Process] Perform logic on earlier-defined members */
        output = ExtractLogLevel(logLineData);

        /* [Conclude] Conclude the Method's intent */
        return output;
    }

    public static string Reformat(string logLine)
    {
        /* [Define] Declare and Initialise variables or logic */
        // (SUB) Output Variable
        string output = default;
        // (SUB) Process Variables
        string message = Message(logLine);
        string logLevel = LogLevel(logLine);
        var messageData = (Message: message, LogLevel: logLevel);
        // (SUB) Process Logic
        void ExtractMessageParts((string Message, string LogLevel) messageData)
        {
            messageData.Message = Message(logLine);
            messageData.LogLevel = LogLevel(logLine);
        };
        string ReformatMessage((string Message, string LogLevel) messageData)
        {
            string formattedMessage = $"{messageData.Message} ({messageData.LogLevel})";
            return formattedMessage;
        };

        /* [Process] Perform logic on earlier-defined members */
        ExtractMessageParts(messageData);
        output = ReformatMessage(messageData);

        /* [Conclude] Conclude the Method's intent */
        return output;
    }
}

class Template
{
    public int TemplateMethod(int amountOfLayersInLasagna)
    {
        /* [Define] Declare and Initialise variables or logic */
        // (SUB) Output Variable
        int output = default;
        // (SUB) Process Variables
        const int lasagnaCookingTime = 40;
        const int preparationTimePerLayerInMinutes = 2;
        var lasagnaCookingData = (AmountOfLayers: amountOfLayersInLasagna, PreparationTimePerLayerInMinutes: preparationTimePerLayerInMinutes);
        // (SUB) Process Logic
        void ActionPerformsSoDoesNotReturns()
        {
            Console.WriteLine("everything is going great");
        };
        int CalculateTotalTimeSpent((int AmountOfLayersInLasagna, int PreparationTimePerLayerInMinutes) lasagnaCookingData)
        {
            return lasagnaCookingData.AmountOfLayersInLasagna * lasagnaCookingData.PreparationTimePerLayerInMinutes + lasagnaCookingTime;
        };

        /* [Process] Perform logic on earlier-defined members */
        ActionPerformsSoDoesNotReturns();
        output = CalculateTotalTimeSpent(lasagnaCookingData);

        /* [Conclude] Conclude the Method's intent */
        return output;
    }
}