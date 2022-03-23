using AdvancedSqlServerDependencies.Properties;
using System;
using System.Drawing;

namespace AdvancedSqlServerDependencies.CustomOutput
{
    class MyOutputMessage
    {
        public EOutputMessageType OutputMessageType;
        public DateTime OutputMessageTimestamp;
        public string OutputMessageDescription;
        public double DurationSec;

        public string DurationSecString
        {
            get
            {
                if(DurationSec != -1)
                    return string.Format("{0:00}:{1:00}:{2:00}.{3:000}", (int) DurationSec / 60 / 60, (int)DurationSec / 60 % 60, (int)DurationSec % 60, (DurationSec - Math.Truncate(DurationSec)) * 1000);
                return string.Empty;
            }
        }

        public Image Image
        {
            get
            {
                switch (OutputMessageType)
                {
                    case EOutputMessageType.INFORMATION: return Resources.StatusAnnotations_Information_16xLG_color;
                    case EOutputMessageType.WARNING: return Resources.StatusAnnotations_Warning_16xLG_color;
                    case EOutputMessageType.ERROR: return Resources.StatusAnnotations_Critical_16xLG_color;
                    case EOutputMessageType.PROGRESS: return Resources.wait_16x16;
                    default: return Resources._1508_QuestionMarkRed;
                };
            }
        }
    }

    public enum EOutputMessageType
    {
        INFORMATION,
        WARNING,
        ERROR,
        PROGRESS
    }
}
