using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509F RID: 20639
	public class RoleDevelopSkillData : IRoleDevelopSkillData
	{
		// Token: 0x17008BFC RID: 35836
		// (get) Token: 0x060352F2 RID: 217842 RVA: 0x00D5313A File Offset: 0x00D5133A
		// (set) Token: 0x060352F3 RID: 217843 RVA: 0x00D53142 File Offset: 0x00D51342
		public int RoleId { get; set; }

		// Token: 0x17008BFD RID: 35837
		// (get) Token: 0x060352F4 RID: 217844 RVA: 0x00D5314B File Offset: 0x00D5134B
		// (set) Token: 0x060352F5 RID: 217845 RVA: 0x00D53153 File Offset: 0x00D51353
		public int SkillNodeId { get; set; }

		// Token: 0x17008BFE RID: 35838
		// (get) Token: 0x060352F6 RID: 217846 RVA: 0x00D5315C File Offset: 0x00D5135C
		// (set) Token: 0x060352F7 RID: 217847 RVA: 0x00D53164 File Offset: 0x00D51364
		public int CurrentLevel { get; set; }

		// Token: 0x17008BFF RID: 35839
		// (get) Token: 0x060352F8 RID: 217848 RVA: 0x00D5316D File Offset: 0x00D5136D
		// (set) Token: 0x060352F9 RID: 217849 RVA: 0x00D53175 File Offset: 0x00D51375
		public int TargetLevel { get; set; }

		// Token: 0x17008C00 RID: 35840
		// (get) Token: 0x060352FA RID: 217850 RVA: 0x00D5317E File Offset: 0x00D5137E
		// (set) Token: 0x060352FB RID: 217851 RVA: 0x00D53186 File Offset: 0x00D51386
		public int Index { get; set; }
	}
}
