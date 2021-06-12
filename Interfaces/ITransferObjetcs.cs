using System.Collections.Generic;

namespace tecnovision_backend.Interfaces
{
    interface ITransferObjetcs<T>
    {

        public void Save(T o);
        
        public T FindById(long id);

        public List<T> FindAll();

    }
}
