using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace Wap_TheThaoSo.Library
{
    public class DataCaching
    {
        private HttpContext context;
        private static readonly DataCaching Instance = new DataCaching();
        public static DataCaching GetInstance()
        {
            return Instance;
        }
        public DataCaching()
        {
            context = HttpContext.Current;
        }

        public object GetCache(string key)
        {
            return context.Cache.Get(key);
        }
        public object GetKey(string key)
        {
            return context.Cache.Get(key);
        }
        public void InsertCache(string key, object data, double expireTime)
        {
            if (expireTime == 0) InsertCacheNoExpireTime(key, data);
            else context.Cache.Insert(key, data, null, DateTime.Now.AddMinutes(expireTime), Cache.NoSlidingExpiration);
        }

        public void InsertCache(string key, object data, double expireTime, SqlCacheDependency sqlDep)
        {
            if (expireTime == 0) InsertCacheNoExpireTime(key, data);
            else context.Cache.Insert(key, data, sqlDep, DateTime.Now.AddMinutes(expireTime), Cache.NoSlidingExpiration);
        }
        public void InsertCacheNoExpireTime(string key, object data)
        {
            if (data != null) context.Cache.Insert(key, data);
        }
        public void InsertCacheNoExpireTime(string key, object data, SqlCacheDependency sqlDep)
        {
            if (data != null) context.Cache.Insert(key, data, sqlDep);
        }
        public bool RemoveCache(string key)
        {
            if (context.Cache[key] != null)
            {
                context.Cache.Remove(key);
                return true;
            }
            else return false;
        }

        public object GetHashCache(string hashKey, object param)
        {
            Hashtable retVal = (Hashtable)this.GetCache(hashKey);
            if (retVal == null) return null;
            if (retVal[param] == null) return null;
            return retVal[param];
        }

        public void SetHashCache(string hashKey, object param, object data, double expireTime)
        {
            Hashtable retVal = (Hashtable)this.GetCache(hashKey);
            if (retVal == null)
            {
                retVal = new Hashtable();
                retVal[param] = data;
                this.InsertCache(hashKey, retVal, expireTime);
            }
            else if (retVal.ContainsKey(param))
            {
                retVal[param] = data;
            }
            else
            {
                retVal.Add(param, data);
            }
        }
        public void SetHashCache(string hashKey, object param, double expireTime, object data, SqlCacheDependency sqlDep)
        {
            Hashtable retVal = (Hashtable)this.GetCache(hashKey);
            if (retVal == null)
            {
                retVal = new Hashtable();
                retVal[param] = data;
                this.InsertCache(hashKey, retVal, expireTime, sqlDep);
            }
            else if (retVal.ContainsKey(param))
            {
                retVal[param] = data;
            }
            else
            {
                retVal.Add(param, data);
            }
        }
        public void RemoveAll()
        {
            Cache cache = context.Cache;
            IEnumerator ienum = cache.GetEnumerator();
            while (ienum.MoveNext())
            {
                DictionaryEntry dic = (DictionaryEntry)ienum.Current;
                RemoveCache(dic.Key.ToString());
            }
        }
        public ArrayList GetKeys()
        {
            IEnumerator dcEnum = context.Cache.GetEnumerator();
            ArrayList _cacheArray = new ArrayList();
            while (dcEnum.MoveNext())
                if (((DictionaryEntry)dcEnum.Current).Value != null)
                    _cacheArray.Add(((DictionaryEntry)dcEnum.Current).Key.ToString());
            _cacheArray.Sort();
            return _cacheArray;
        }
    }
}