using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAF RID: 20143
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomSkillItemInBattleData : ITowerDefensePhantomSkillItemInBattleData
	{
		// Token: 0x17008949 RID: 35145
		// (get) Token: 0x0603409A RID: 213146 RVA: 0x00D04727 File Offset: 0x00D02927
		// (set) Token: 0x0603409B RID: 213147 RVA: 0x00D0472F File Offset: 0x00D0292F
		public string Skill { get; set; }

		// Token: 0x1700894A RID: 35146
		// (get) Token: 0x0603409C RID: 213148 RVA: 0x00D04738 File Offset: 0x00D02938
		// (set) Token: 0x0603409D RID: 213149 RVA: 0x00D04740 File Offset: 0x00D02940
		public string Description { get; set; }

		// Token: 0x1700894B RID: 35147
		// (get) Token: 0x0603409E RID: 213150 RVA: 0x00D04749 File Offset: 0x00D02949
		// (set) Token: 0x0603409F RID: 213151 RVA: 0x00D04751 File Offset: 0x00D02951
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

		// Token: 0x1700894C RID: 35148
		// (get) Token: 0x060340A0 RID: 213152 RVA: 0x00D0475A File Offset: 0x00D0295A
		// (set) Token: 0x060340A1 RID: 213153 RVA: 0x00D04762 File Offset: 0x00D02962
		public bool IsUnlock { get; set; }

		// Token: 0x1700894D RID: 35149
		// (get) Token: 0x060340A2 RID: 213154 RVA: 0x00D0476B File Offset: 0x00D0296B
		// (set) Token: 0x060340A3 RID: 213155 RVA: 0x00D04773 File Offset: 0x00D02973
		public bool IsCurrent { get; set; }
	}
}
