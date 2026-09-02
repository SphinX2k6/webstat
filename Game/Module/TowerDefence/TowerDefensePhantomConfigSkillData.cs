using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EB5 RID: 20149
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefensePhantomConfigSkillData : ITowerDefensePhantomConfigSkillData
	{
		// Token: 0x17008965 RID: 35173
		// (get) Token: 0x060340D5 RID: 213205 RVA: 0x00D0482D File Offset: 0x00D02A2D
		// (set) Token: 0x060340D6 RID: 213206 RVA: 0x00D04835 File Offset: 0x00D02A35
		public string Name { get; set; }

		// Token: 0x17008966 RID: 35174
		// (get) Token: 0x060340D7 RID: 213207 RVA: 0x00D0483E File Offset: 0x00D02A3E
		// (set) Token: 0x060340D8 RID: 213208 RVA: 0x00D04846 File Offset: 0x00D02A46
		public string Description { get; set; }

		// Token: 0x17008967 RID: 35175
		// (get) Token: 0x060340D9 RID: 213209 RVA: 0x00D0484F File Offset: 0x00D02A4F
		// (set) Token: 0x060340DA RID: 213210 RVA: 0x00D04857 File Offset: 0x00D02A57
		public string UnlockDescription { get; set; }

		// Token: 0x17008968 RID: 35176
		// (get) Token: 0x060340DB RID: 213211 RVA: 0x00D04860 File Offset: 0x00D02A60
		// (set) Token: 0x060340DC RID: 213212 RVA: 0x00D04868 File Offset: 0x00D02A68
		public double? ExpThreshold { get; set; }

		// Token: 0x17008969 RID: 35177
		// (get) Token: 0x060340DD RID: 213213 RVA: 0x00D04871 File Offset: 0x00D02A71
		// (set) Token: 0x060340DE RID: 213214 RVA: 0x00D04879 File Offset: 0x00D02A79
		public int PhantomSkill { get; set; }
	}
}
