using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A57 RID: 27223
	[NullableContext(1)]
	[Nullable(0)]
	public class CustomContext : GeneralContext
	{
		// Token: 0x0604352D RID: 275757 RVA: 0x0114DEFE File Offset: 0x0114C0FE
		public CustomContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Custom);
			this.CustomProperty = new Dictionary<string, object>();
		}

		// Token: 0x0604352E RID: 275758 RVA: 0x0114DF1E File Offset: 0x0114C11E
		public void SetValueRestricted<[Nullable(2)] T>(string key, T value)
		{
			this.CustomProperty[key] = value;
		}

		// Token: 0x0604352F RID: 275759 RVA: 0x0114DF34 File Offset: 0x0114C134
		[NullableContext(2)]
		public T GetValueRestricted<T>([Nullable(1)] string key)
		{
			if (this.CustomProperty == null || !this.CustomProperty.ContainsKey(key))
			{
				return default(T);
			}
			object obj = this.CustomProperty[key];
			if (obj is T)
			{
				return (T)((object)obj);
			}
			return default(T);
		}

		// Token: 0x06043530 RID: 275760 RVA: 0x0114DF88 File Offset: 0x0114C188
		public static CustomContext Create()
		{
			return GeneralContext.GetObj(EGeneralContextType.Custom, null, () => new CustomContext()) as CustomContext;
		}

		// Token: 0x040258AD RID: 153773
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly Dictionary<string, object> CustomProperty;
	}
}
