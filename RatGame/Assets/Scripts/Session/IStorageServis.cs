using System;

namespace Session
{
    public interface IStorageServis
    {
        void Save(string key, object data);
        T Load<T>(string key);
    }
}
