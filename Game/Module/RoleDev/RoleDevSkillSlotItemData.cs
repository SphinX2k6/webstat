using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200504D RID: 20557
	public class RoleDevSkillSlotItemData : IRoleDevSkillSlotItemData
	{
		// Token: 0x17008B46 RID: 35654
		// (get) Token: 0x06034ED4 RID: 216788 RVA: 0x00D469E1 File Offset: 0x00D44BE1
		// (set) Token: 0x06034ED5 RID: 216789 RVA: 0x00D469E9 File Offset: 0x00D44BE9
		public int RoleId { get; set; }

		// Token: 0x17008B47 RID: 35655
		// (get) Token: 0x06034ED6 RID: 216790 RVA: 0x00D469F2 File Offset: 0x00D44BF2
		// (set) Token: 0x06034ED7 RID: 216791 RVA: 0x00D469FA File Offset: 0x00D44BFA
		public int SkillNodeId { get; set; }

		// Token: 0x17008B48 RID: 35656
		// (get) Token: 0x06034ED8 RID: 216792 RVA: 0x00D46A03 File Offset: 0x00D44C03
		// (set) Token: 0x06034ED9 RID: 216793 RVA: 0x00D46A0B File Offset: 0x00D44C0B
		public int CurrentLevel { get; set; }

		// Token: 0x17008B49 RID: 35657
		// (get) Token: 0x06034EDA RID: 216794 RVA: 0x00D46A14 File Offset: 0x00D44C14
		// (set) Token: 0x06034EDB RID: 216795 RVA: 0x00D46A1C File Offset: 0x00D44C1C
		public int NormalTargetLevel { get; set; }

		// Token: 0x17008B4A RID: 35658
		// (get) Token: 0x06034EDC RID: 216796 RVA: 0x00D46A25 File Offset: 0x00D44C25
		// (set) Token: 0x06034EDD RID: 216797 RVA: 0x00D46A2D File Offset: 0x00D44C2D
		public int PerfectTargetLevel { get; set; }
	}
}
