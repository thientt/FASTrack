
namespace FASTrack.Model.DTO
{
    public class MSTCustomerDto : BaseDto
    {
        public string CustomerName { get; set; }
        public bool EndCustomer { get; set; }
        public string Location { get; set; }
        public bool Strategic { get; set; }
    }
}
