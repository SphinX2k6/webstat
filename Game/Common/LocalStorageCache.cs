using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Common
{
	// Token: 0x02007061 RID: 28769
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalStorageCache
	{
		// Token: 0x06045A93 RID: 285331 RVA: 0x012347E8 File Offset: 0x012329E8
		public void Set(string key, string encodedValue)
		{
			CacheObj cacheObj = this.Lru.Get(key);
			if (cacheObj != null)
			{
				cacheObj.EncodeValue = encodedValue;
				return;
			}
			this.Lru.Put(key, new CacheObj
			{
				EncodeValue = encodedValue
			}, 1);
		}

		// Token: 0x06045A94 RID: 285332 RVA: 0x01234827 File Offset: 0x01232A27
		[return: Nullable(2)]
		public string Get(string key)
		{
			CacheObj cacheObj = this.Lru.Get(key);
			if (cacheObj == null)
			{
				return null;
			}
			return cacheObj.EncodeValue;
		}

		// Token: 0x06045A95 RID: 285333 RVA: 0x01234840 File Offset: 0x01232A40
		public void Clear()
		{
			this.Lru.Clear();
		}

		// Token: 0x04026E3A RID: 159290
		private const int CACHE_CAPACITY = 50;

		// Token: 0x04026E3B RID: 159291
		private readonly TrimLru<string, CacheObj> Lru = new TrimLru<string, CacheObj>(50, false);
	}
}
