using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAE RID: 20142
	[NullableContext(1)]
	public interface ITowerDefensePhantomSkillItemInBattleData
	{
		// Token: 0x17008944 RID: 35140
		// (get) Token: 0x06034090 RID: 213136
		// (set) Token: 0x06034091 RID: 213137
		string Skill { get; set; }

		// Token: 0x17008945 RID: 35141
		// (get) Token: 0x06034092 RID: 213138
		// (set) Token: 0x06034093 RID: 213139
		string Description { get; set; }

		// Token: 0x17008946 RID: 35142
		// (get) Token: 0x06034094 RID: 213140
		// (set) Token: 0x06034095 RID: 213141
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<string> DescriptionArgs { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17008947 RID: 35143
		// (get) Token: 0x06034096 RID: 213142
		// (set) Token: 0x06034097 RID: 213143
		bool IsUnlock { get; set; }

		// Token: 0x17008948 RID: 35144
		// (get) Token: 0x06034098 RID: 213144
		// (set) Token: 0x06034099 RID: 213145
		bool IsCurrent { get; set; }
	}
}
