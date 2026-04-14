using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities
{
    public class Orders
    {
        [Key]//Key attribute is used to apply the primary key and identity value.
        public int orderid { get; set; }
        public string ordername { get; set; }
        public string orderlocation { get; set; }
    }
}
