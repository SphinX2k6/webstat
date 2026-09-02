using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200666E RID: 26222
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskSortedMap<[Nullable(2)] T>
	{
		// Token: 0x06041823 RID: 268323 RVA: 0x010D0819 File Offset: 0x010CEA19
		public MowingRiskSortedMap(Func<T, object> getUniqueKey)
		{
			if (getUniqueKey == null)
			{
				throw new ArgumentNullException("getUniqueKey");
			}
			this.GetUniqueKey = getUniqueKey;
			this.ListCache = new List<T>();
			this.MapCache = new Dictionary<object, T>();
		}

		// Token: 0x06041824 RID: 268324 RVA: 0x010D0858 File Offset: 0x010CEA58
		private void Add(T value)
		{
			object key = this.GetUniqueKey(value);
			this.ListCache.Add(value);
			this.MapCache[key] = value;
		}

		// Token: 0x06041825 RID: 268325 RVA: 0x010D088C File Offset: 0x010CEA8C
		public void DeleteByKey(object key)
		{
			if (key == null)
			{
				return;
			}
			this.ListCache.RemoveAll((T item) => this.GetUniqueKey(item).Equals(key));
			this.MapCache.Remove(key);
		}

		// Token: 0x06041826 RID: 268326 RVA: 0x010D08E0 File Offset: 0x010CEAE0
		public void Set(T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			object key = this.GetUniqueKey(value);
			if (this.MapCache.ContainsKey(key))
			{
				int num = this.ListCache.FindIndex((T item) => this.GetUniqueKey(item).Equals(key));
				if (num >= 0)
				{
					this.ListCache[num] = value;
				}
				this.MapCache[key] = value;
				return;
			}
			this.Add(value);
		}

		// Token: 0x06041827 RID: 268327 RVA: 0x010D0978 File Offset: 0x010CEB78
		public T Get(object key)
		{
			if (key == null)
			{
				return default(T);
			}
			T result;
			this.MapCache.TryGetValue(key, out result);
			return result;
		}

		// Token: 0x06041828 RID: 268328 RVA: 0x010D09A2 File Offset: 0x010CEBA2
		public IEnumerable<T> GetAll()
		{
			return this.ListCache.AsReadOnly();
		}

		// Token: 0x040249B3 RID: 149939
		private readonly Func<T, object> GetUniqueKey;

		// Token: 0x040249B4 RID: 149940
		private readonly List<T> ListCache = new List<T>();

		// Token: 0x040249B5 RID: 149941
		private readonly Dictionary<object, T> MapCache;
	}
}
