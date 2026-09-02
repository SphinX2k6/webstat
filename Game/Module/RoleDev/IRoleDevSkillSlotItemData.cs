using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200504C RID: 20556
	public interface IRoleDevSkillSlotItemData
	{
		// Token: 0x17008B41 RID: 35649
		// (get) Token: 0x06034ECA RID: 216778
		// (set) Token: 0x06034ECB RID: 216779
		int RoleId { get; set; }

		// Token: 0x17008B42 RID: 35650
		// (get) Token: 0x06034ECC RID: 216780
		// (set) Token: 0x06034ECD RID: 216781
		int SkillNodeId { get; set; }

		// Token: 0x17008B43 RID: 35651
		// (get) Token: 0x06034ECE RID: 216782
		// (set) Token: 0x06034ECF RID: 216783
		int CurrentLevel { get; set; }

		// Token: 0x17008B44 RID: 35652
		// (get) Token: 0x06034ED0 RID: 216784
		// (set) Token: 0x06034ED1 RID: 216785
		int NormalTargetLevel { get; set; }

		// Token: 0x17008B45 RID: 35653
		// (get) Token: 0x06034ED2 RID: 216786
		// (set) Token: 0x06034ED3 RID: 216787
		int PerfectTargetLevel { get; set; }
	}
}
