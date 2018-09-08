using System;
using System.Collections.Generic;
using System.Text;

namespace MyFullStackWebApp.DataStore.Operations
{
    public class AzureTableStoreOperations<T> : IStoreOperations<T> where T : class
    {
        public bool DeleteFromStore(T obj)
        {
            throw new NotImplementedException();
        }

        public bool InsertInStore(T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadFromStore()
        {
            throw new NotImplementedException();
        }

        public bool UpdateInStore(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
