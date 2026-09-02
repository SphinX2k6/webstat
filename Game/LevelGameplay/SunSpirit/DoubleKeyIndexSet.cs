using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit
{
	// Token: 0x02006A9F RID: 27295
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1,
		1
	})]
	public class DoubleKeyIndexSet<[Nullable(2)] TK1, [Nullable(2)] TK2, [Nullable(2)] TV> : Dictionary<TK1, Dictionary<TK2, HashSet<TV>>>
	{
		// Token: 0x06043802 RID: 276482 RVA: 0x011654B8 File Offset: 0x011636B8
		public void AddValToSet(TK1 key1, TK2 key2, TV val)
		{
			Dictionary<TK2, HashSet<TV>> dictionary;
			if (!base.TryGetValue(key1, out dictionary))
			{
				dictionary = new Dictionary<TK2, HashSet<TV>>();
				base[key1] = dictionary;
			}
			HashSet<TV> hashSet;
			if (!dictionary.TryGetValue(key2, out hashSet))
			{
				hashSet = new HashSet<TV>();
				dictionary[key2] = hashSet;
			}
			hashSet.Add(val);
		}

		// Token: 0x06043803 RID: 276483 RVA: 0x01165500 File Offset: 0x01163700
		public void DeleteValFromSet(TK1 key1, TK2 key2, TV val)
		{
			Dictionary<TK2, HashSet<TV>> dictionary;
			if (!base.TryGetValue(key1, out dictionary))
			{
				return;
			}
			HashSet<TV> hashSet;
			if (!dictionary.TryGetValue(key2, out hashSet))
			{
				return;
			}
			hashSet.Remove(val);
			if (hashSet.Count == 0)
			{
				dictionary.Remove(key2);
			}
			if (dictionary.Count == 0)
			{
				base.Remove(key1);
			}
		}

		// Token: 0x06043804 RID: 276484 RVA: 0x01165550 File Offset: 0x01163750
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<TV> GetSet(TK1 key1, TK2 key2)
		{
			Dictionary<TK2, HashSet<TV>> dictionary;
			HashSet<TV> result;
			if (base.TryGetValue(key1, out dictionary) && dictionary.TryGetValue(key2, out result))
			{
				return result;
			}
			return null;
		}
	}
}
