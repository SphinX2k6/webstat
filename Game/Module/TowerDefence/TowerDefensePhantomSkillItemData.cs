using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAD RID: 20141
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomSkillItemData : ITowerDefensePhantomSkillItemData
	{
		// Token: 0x17008940 RID: 35136
		// (get) Token: 0x06034087 RID: 213127 RVA: 0x00D046DB File Offset: 0x00D028DB
		// (set) Token: 0x06034088 RID: 213128 RVA: 0x00D046E3 File Offset: 0x00D028E3
		public string SkillTextId { get; set; }

		// Token: 0x17008941 RID: 35137
		// (get) Token: 0x06034089 RID: 213129 RVA: 0x00D046EC File Offset: 0x00D028EC
		// (set) Token: 0x0603408A RID: 213130 RVA: 0x00D046F4 File Offset: 0x00D028F4
		public string Level { get; set; }

		// Token: 0x17008942 RID: 35138
		// (get) Token: 0x0603408B RID: 213131 RVA: 0x00D046FD File Offset: 0x00D028FD
		// (set) Token: 0x0603408C RID: 213132 RVA: 0x00D04705 File Offset: 0x00D02905
		public string DescriptionTextId { get; set; }

		// Token: 0x17008943 RID: 35139
		// (get) Token: 0x0603408D RID: 213133 RVA: 0x00D0470E File Offset: 0x00D0290E
		// (set) Token: 0x0603408E RID: 213134 RVA: 0x00D04716 File Offset: 0x00D02916
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<string> DescriptionArgs { [return: Nullable(new byte[]
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
