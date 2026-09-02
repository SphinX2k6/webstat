using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAC RID: 20140
	[NullableContext(1)]
	public interface ITowerDefensePhantomSkillItemData
	{
		// Token: 0x1700893C RID: 35132
		// (get) Token: 0x0603407F RID: 213119
		// (set) Token: 0x06034080 RID: 213120
		string SkillTextId { get; set; }

		// Token: 0x1700893D RID: 35133
		// (get) Token: 0x06034081 RID: 213121
		// (set) Token: 0x06034082 RID: 213122
		string Level { get; set; }

		// Token: 0x1700893E RID: 35134
		// (get) Token: 0x06034083 RID: 213123
		// (set) Token: 0x06034084 RID: 213124
		string DescriptionTextId { get; set; }

		// Token: 0x1700893F RID: 35135
		// (get) Token: 0x06034085 RID: 213125
		// (set) Token: 0x06034086 RID: 213126
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
	}
}
