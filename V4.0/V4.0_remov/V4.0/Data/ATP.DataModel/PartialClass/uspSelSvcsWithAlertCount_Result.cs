using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public partial class uspSelVehSvcsForARCH_Result : INotifyPropertyChanged
    {
        //[DataMember]
        //public string PersonBorderBrush { get; set; }
        [DataMember]
        public string VehicleYMMT { get; set; }
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public Nullable<System.Guid> UpdatedBy { get; set; }

        [DataMember]
        public Nullable<System.Guid> EnteredBy { get; set; }
        [DataMember]
        public int? MsgCount { get; set; }

        [DataMember]
        public string RONumber { get; set; }

        [DataMember]
        public string TotalROAmount { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string Address1 { get; set; }
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public string State { get; set; }
        [DataMember]
        public short vehYear { get; set; }

        private bool _IsSelected = false;
        [DataMember]
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; OnChanged("IsSelected"); } }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

    }
}