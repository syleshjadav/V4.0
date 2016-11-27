using System;
using System.Runtime.Serialization;


[Serializable]
[DataContract]
public partial class ATPErrorLog
{
    [DataMember]
    public string Created { get; set; }
   
    [DataMember]
    public string Class { get; set; }
  
   
    [DataMember]
    public string Text { get; set; }
}
