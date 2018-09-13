using MyFullStackWebApp.DataStore.Operations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FullStackApp.JsonFileStore
{
    public interface IFileStoreOperations<T>: IStoreOperations<T> where T: class
    {
        Task<bool> InsertInStore(T obj);
    }


    public class FileStoreOperations<T> : IFileStoreOperations<T> where T : class
    {
        private string _FullFilePath = "";
        private static readonly object _locked = new Object();

        public FileStoreOperations(string fullfilePath)
        {
            _FullFilePath = fullfilePath;
        }

        public bool DeleteFromStore(T obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertInStore(T obj)
        {
            
            await Task.Run(() =>
                {
                    lock (_locked)
                    {
                        try
                        {
                            using (FileStream fs = new FileStream(_FullFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                StreamWriter m_streamWriter = new StreamWriter(fs);
                                // Write to the file using StreamWriter class 
                                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);

                                m_streamWriter.WriteLine(JsonConvert.SerializeObject(obj));
                                //m_streamWriter.WriteLine(" First Line : Data is first line \n");
                                //m_streamWriter.WriteLine(" This is next line in the text file. \n ");
                                m_streamWriter.Flush();
                                fs.Close();
                            }

                        }
                        catch(FileNotFoundException e1)
                        {
                            throw e1;
                        }

                        catch (FileLoadException e2)
                        {
                            throw e2;
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    }
                });
               
                return true;
            
        }

        public IEnumerable<T> ReadFromStore()
        {
            throw new NotImplementedException();
        }

        public bool UpdateInStore(T obj)
        {
            throw new NotImplementedException();
        }

        bool IStoreOperations<T>.InsertInStore(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
