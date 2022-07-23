using FASTrack.Model.DTO;
using System.Collections.Generic;

namespace FASTrack.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class FARReportGeneratorViewModel : FARRequestViewModel
    {

        /// <summary>
        /// 
        /// </summary>public MSTBuDto BU { get; set; }
        public MSTOriginDto Origin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTPriorityDto Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTFailureOriginDto FailureOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTFailureTypeDto FailureType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTStatusDto State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MSTLabSiteDto LabSite { get; set; }

        /// <summary>
        /// 
        /// </summary>

        private List<FARDeviceDetailsDto> deviceDetails;

        /// <summary>
        /// 
        /// </summary>
        public List<FARDeviceDetailsDto> DeviceDetails
        {
            get
            {
                if (deviceDetails == null)
                    deviceDetails = new List<FARDeviceDetailsDto>();

                return deviceDetails;
            }
            set
            {
                deviceDetails = value;
            }
        }
    }
}