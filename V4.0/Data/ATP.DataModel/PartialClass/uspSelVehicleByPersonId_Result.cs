using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
namespace ATP.DataModel
{
    public partial class uspSelVehicleByPersonId_Result : ObservableObject
    {
        [DataMember]
        public int EnteredMiles { get; set; }
        [DataMember]
        public string CorrectedHtmlColor { get; set; }
        [DataMember]
        public string ServiceNotes { get; set; }
        [DataMember]
        public string NextServiceDate { get; set; }

        [DataMember]
        public decimal PackageCost { get; set; }
        [DataMember]
        public decimal ServiceCost { get; set; }

    }

    [Serializable]
    [DataContract(IsReference = true)]
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}