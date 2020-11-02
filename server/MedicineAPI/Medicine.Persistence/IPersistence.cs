using System;
using System.Collections.Generic;

namespace MedicineAPI.Persistence
{
    public interface IPersistence
    {
        IEnumerable<MedicineModel.Medicine> GetAll();
        MedicineModel.Medicine Get(Guid id);
        IEnumerable<MedicineModel.Medicine> Search(string name);
        void Add(MedicineModel.Medicine medicine);
        void Update(MedicineModel.Medicine medicine);
    }
}
