using System;

namespace ATP.Kiosk.Common
{
    [Serializable()]
    public class ComboFill
    {
        public ComboFill()
        {
        }

        public ComboFill(int id, string desc, string des1 = null, string des2 = null)
        {
            Id = id; Desc = desc; Desc1 = des1; Desc2 = des2;
        }

        public int Id { get; set; }

        public string Desc { get; set; }

        public string Desc1 { get; set; } // extra field

        public string Desc2 { get; set; } // extra field
    }
}