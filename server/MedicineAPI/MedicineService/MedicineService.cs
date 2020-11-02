using MedicineAPI.Persistence;
using MedicineModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineService
{
    public class MedicineService : IMedicineService
    {
        private readonly IPersistence _persistence;
        public MedicineService(IPersistence persistence)
        {
            _persistence = persistence;
        }
        public Medicine Add(Medicine medicine)
        {
            _persistence.Add(medicine);
            return medicine;
        }

        public Medicine Get(Guid id)
        {
            return _persistence.Get(id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _persistence.GetAll();
        }

        public IEnumerable<Medicine> Search(string name)
        {
            return _persistence.Search(name);
        }

        public Medicine Update(Medicine medicine)
        {
            _persistence.Update(medicine);
            return medicine;
        }
    }
}
