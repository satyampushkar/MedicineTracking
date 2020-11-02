using MedicineModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineService
{
    public interface IMedicineService
    {
        IEnumerable<Medicine> GetAll();
        Medicine Get(Guid id);
        IEnumerable<Medicine> Search(string name);
        Medicine Add(Medicine medicine);
        Medicine Update(Medicine medicine);
    }
}
