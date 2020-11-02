using System;

namespace MedicineModel
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime Expiry { get; set; }
        public string Notes { get; set; }
    }
}
