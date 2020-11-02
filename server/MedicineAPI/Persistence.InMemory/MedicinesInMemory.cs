using Medicine.Persistence;
using System;
using System.Collections.Generic;

namespace Persistence.InMemory
{
    public class MedicinesInMemory : IPersistence
    {
        public MedicineModel.Medicine Add(MedicineModel.Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public MedicineModel.Medicine Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicineModel.Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicineModel.Medicine> Search(string name)
        {
            throw new NotImplementedException();
        }

        public MedicineModel.Medicine Update(MedicineModel.Medicine medicine)
        {
            throw new NotImplementedException();
        }
    }
}
