using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F77 RID: 20343
	[NullableContext(1)]
	[Nullable(0)]
	public class BehaviorButtonMapping<T>
	{
		// Token: 0x0603478A RID: 214922 RVA: 0x00D21840 File Offset: 0x00D1FA40
		public void Add(IEnumerable<T> keys, BehaviorButtonData skillButtonData)
		{
			foreach (T key in keys)
			{
				HashSet<BehaviorButtonData> hashSet;
				if (this.BehaviorButtonMap.TryGetValue(key, out hashSet))
				{
					hashSet.Add(skillButtonData);
				}
				else
				{
					hashSet = new HashSet<BehaviorButtonData>();
					hashSet.Add(skillButtonData);
					this.BehaviorButtonMap[key] = hashSet;
				}
			}
		}

		// Token: 0x0603478B RID: 214923 RVA: 0x00D218B8 File Offset: 0x00D1FAB8
		public void AddSingle(T key, BehaviorButtonData skillButtonData)
		{
			HashSet<BehaviorButtonData> hashSet;
			if (this.BehaviorButtonMap.TryGetValue(key, out hashSet))
			{
				hashSet.Add(skillButtonData);
				return;
			}
			hashSet = new HashSet<BehaviorButtonData>();
			hashSet.Add(skillButtonData);
			this.BehaviorButtonMap[key] = hashSet;
		}

		// Token: 0x0603478C RID: 214924 RVA: 0x00D218FC File Offset: 0x00D1FAFC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<BehaviorButtonData> Get(T key)
		{
			HashSet<BehaviorButtonData> result;
			if (!this.BehaviorButtonMap.TryGetValue(key, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0603478D RID: 214925 RVA: 0x00D2191C File Offset: 0x00D1FB1C
		public IEnumerable<T> GetAllKey()
		{
			return this.BehaviorButtonMap.Keys;
		}

		// Token: 0x0603478E RID: 214926 RVA: 0x00D21929 File Offset: 0x00D1FB29
		public void Clear()
		{
			this.BehaviorButtonMap.Clear();
		}

		// Token: 0x0401E397 RID: 123799
		private readonly Dictionary<T, HashSet<BehaviorButtonData>> BehaviorButtonMap = new Dictionary<T, HashSet<BehaviorButtonData>>();
	}
}
