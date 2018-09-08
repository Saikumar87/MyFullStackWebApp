using System;
using System.Collections.Generic;

namespace MyFullStackWebApp.DataStore.Operations
{
    public interface IStoreOperations<T> where T: class
    {
        bool InsertInStore(T obj);

        bool UpdateInStore(T obj);

        bool DeleteFromStore(T obj);

        IEnumerable<T> ReadFromStore();

    }

 

  


    


}
