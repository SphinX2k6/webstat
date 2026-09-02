using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005047 RID: 20551
	public class SkillSlotExtendData : ISkillSlotExtendData
	{
		// Token: 0x17008B2F RID: 35631
		// (get) Token: 0x06034EA3 RID: 216739 RVA: 0x00D468EC File Offset: 0x00D44AEC
		// (set) Token: 0x06034EA4 RID: 216740 RVA: 0x00D468F4 File Offset: 0x00D44AF4
		public int RoleId { get; set; }

		// Token: 0x17008B30 RID: 35632
		// (get) Token: 0x06034EA5 RID: 216741 RVA: 0x00D468FD File Offset: 0x00D44AFD
		// (set) Token: 0x06034EA6 RID: 216742 RVA: 0x00D46905 File Offset: 0x00D44B05
		public int SkillNodeId { get; set; }

		// Token: 0x17008B31 RID: 35633
		// (get) Token: 0x06034EA7 RID: 216743 RVA: 0x00D4690E File Offset: 0x00D44B0E
		// (set) Token: 0x06034EA8 RID: 216744 RVA: 0x00D46916 File Offset: 0x00D44B16
		public int IconId { get; set; }

		// Token: 0x17008B32 RID: 35634
		// (get) Token: 0x06034EA9 RID: 216745 RVA: 0x00D4691F File Offset: 0x00D44B1F
		// (set) Token: 0x06034EAA RID: 216746 RVA: 0x00D46927 File Offset: 0x00D44B27
		public int CurrentLevel { get; set; }

		// Token: 0x17008B33 RID: 35635
		// (get) Token: 0x06034EAB RID: 216747 RVA: 0x00D46930 File Offset: 0x00D44B30
		// (set) Token: 0x06034EAC RID: 216748 RVA: 0x00D46938 File Offset: 0x00D44B38
		public int NormalTargetLevel { get; set; }

		// Token: 0x17008B34 RID: 35636
		// (get) Token: 0x06034EAD RID: 216749 RVA: 0x00D46941 File Offset: 0x00D44B41
		// (set) Token: 0x06034EAE RID: 216750 RVA: 0x00D46949 File Offset: 0x00D44B49
		public int PerfectTargetLevel { get; set; }

		// Token: 0x17008B35 RID: 35637
		// (get) Token: 0x06034EAF RID: 216751 RVA: 0x00D46952 File Offset: 0x00D44B52
		// (set) Token: 0x06034EB0 RID: 216752 RVA: 0x00D4695A File Offset: 0x00D44B5A
		public ESkillType SkillType { get; set; }

		// Token: 0x17008B36 RID: 35638
		// (get) Token: 0x06034EB1 RID: 216753 RVA: 0x00D46963 File Offset: 0x00D44B63
		// (set) Token: 0x06034EB2 RID: 216754 RVA: 0x00D4696B File Offset: 0x00D44B6B
		public int NodeIndex { get; set; }
	}
}
