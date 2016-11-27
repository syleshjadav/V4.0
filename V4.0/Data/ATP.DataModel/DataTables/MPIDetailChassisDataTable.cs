using System;
using System.Runtime.Serialization;

namespace ATP.DataModel
{
    public class MPIDetailChassisDataTable
    {
     
    
        [DataMember]
        public byte MPIItemId { get; set; }
        [DataMember]
        public byte FrontBumperRYGNValue { get; set; }
        [DataMember]
        public byte RearBumperRYGNValue { get; set; }
        [DataMember]
        public byte FrontHoodRYGNValue { get; set; }
        [DataMember]
        public byte RearHoodRYGNValue { get; set; }
        [DataMember]
        public byte RYGNValue { get; set; }
        [DataMember]
        public byte FrontDoorLeftRYGNValue { get; set; }
        [DataMember]
        public byte FrontDoorRightRYGNValue { get; set; }
        [DataMember]
        public byte RearDoorLeftRYGNValue { get; set; }
        [DataMember]
        public byte RearDoorRightRYGNValue { get; set; }
        [DataMember]
        public byte FrontWindShieldRYGNValue { get; set; }
        [DataMember]
        public byte RearWindShieldRYGNValue { get; set; }
        [DataMember]
        public byte LeftHeadLightRYGNValue { get; set; }
        [DataMember]
        public byte RightHeadLightRYGNValue { get; set; }
        [DataMember]
        public byte LeftFenderRYGNValue { get; set; }
        [DataMember]
        public byte RightFenderFrontRYGNValue { get; set; }
        [DataMember]
        public byte LeftFenderRearRYGNValue { get; set; }
        [DataMember]
        public byte RightFenderRearRYGNValue { get; set; }

        [DataMember]
        public byte LFWheelRYGNValue { get; set; }

        [DataMember]
        public byte LRWheelRYGNValue { get; set; }

        [DataMember]
        public byte RFWheelRYGNValue { get; set; }

        [DataMember]
        public byte RRWheelRYGNValue { get; set; }


        [DataMember]
        public string ChassisComments { get; set; }
        [DataMember]
        public string TechComments { get; set; }

        [DataMember]
        public string ServiceWriterComments { get; set; }


    }
}
