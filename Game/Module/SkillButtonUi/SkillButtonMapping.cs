using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F86 RID: 20358
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonMapping<[Nullable(2)] T>
	{
		// Token: 0x060348CC RID: 215244 RVA: 0x00D2BFA8 File Offset: 0x00D2A1A8
		public void Add(IEnumerable<T> keys, SkillButtonData skillButtonData)
		{
			foreach (T key in keys)
			{
				HashSet<SkillButtonData> hashSet;
				if (this.SkillButtonMap.TryGetValue(key, out hashSet))
				{
					hashSet.Add(skillButtonData);
				}
				else
				{
					hashSet = new HashSet<SkillButtonData>();
					hashSet.Add(skillButtonData);
					this.SkillButtonMap[key] = hashSet;
				}
			}
		}

		// Token: 0x060348CD RID: 215245 RVA: 0x00D2C020 File Offset: 0x00D2A220
		public void AddSingle(T key, SkillButtonData skillButtonData)
		{
			HashSet<SkillButtonData> hashSet;
			if (this.SkillButtonMap.TryGetValue(key, out hashSet))
			{
				hashSet.Add(skillButtonData);
				return;
			}
			hashSet = new HashSet<SkillButtonData>();
			hashSet.Add(skillButtonData);
			this.SkillButtonMap[key] = hashSet;
		}

		// Token: 0x060348CE RID: 215246 RVA: 0x00D2C064 File Offset: 0x00D2A264
		public void RemoveSingle(T key, SkillButtonData skillButtonData)
		{
			HashSet<SkillButtonData> hashSet;
			if (this.SkillButtonMap.TryGetValue(key, out hashSet))
			{
				hashSet.Remove(skillButtonData);
			}
		}

		// Token: 0x060348CF RID: 215247 RVA: 0x00D2C08C File Offset: 0x00D2A28C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public HashSet<SkillButtonData> Get(T key)
		{
			HashSet<SkillButtonData> result;
			if (!this.SkillButtonMap.TryGetValue(key, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x060348D0 RID: 215248 RVA: 0x00D2C0AC File Offset: 0x00D2A2AC
		public void Clear()
		{
			this.SkillButtonMap.Clear();
		}

		// Token: 0x0401E483 RID: 124035
		private readonly Dictionary<T, HashSet<SkillButtonData>> SkillButtonMap = new Dictionary<T, HashSet<SkillButtonData>>();
	}
}
