using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005046 RID: 20550
	public interface ISkillSlotExtendData
	{
		// Token: 0x17008B27 RID: 35623
		// (get) Token: 0x06034E93 RID: 216723
		// (set) Token: 0x06034E94 RID: 216724
		int RoleId { get; set; }

		// Token: 0x17008B28 RID: 35624
		// (get) Token: 0x06034E95 RID: 216725
		// (set) Token: 0x06034E96 RID: 216726
		int SkillNodeId { get; set; }

		// Token: 0x17008B29 RID: 35625
		// (get) Token: 0x06034E97 RID: 216727
		// (set) Token: 0x06034E98 RID: 216728
		int IconId { get; set; }

		// Token: 0x17008B2A RID: 35626
		// (get) Token: 0x06034E99 RID: 216729
		// (set) Token: 0x06034E9A RID: 216730
		int CurrentLevel { get; set; }

		// Token: 0x17008B2B RID: 35627
		// (get) Token: 0x06034E9B RID: 216731
		// (set) Token: 0x06034E9C RID: 216732
		int NormalTargetLevel { get; set; }

		// Token: 0x17008B2C RID: 35628
		// (get) Token: 0x06034E9D RID: 216733
		// (set) Token: 0x06034E9E RID: 216734
		int PerfectTargetLevel { get; set; }

		// Token: 0x17008B2D RID: 35629
		// (get) Token: 0x06034E9F RID: 216735
		// (set) Token: 0x06034EA0 RID: 216736
		ESkillType SkillType { get; set; }

		// Token: 0x17008B2E RID: 35630
		// (get) Token: 0x06034EA1 RID: 216737
		// (set) Token: 0x06034EA2 RID: 216738
		int NodeIndex { get; set; }
	}
}
