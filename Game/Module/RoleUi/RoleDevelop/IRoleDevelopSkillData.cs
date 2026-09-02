using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200509E RID: 20638
	public interface IRoleDevelopSkillData
	{
		// Token: 0x17008BF7 RID: 35831
		// (get) Token: 0x060352E8 RID: 217832
		// (set) Token: 0x060352E9 RID: 217833
		int RoleId { get; set; }

		// Token: 0x17008BF8 RID: 35832
		// (get) Token: 0x060352EA RID: 217834
		// (set) Token: 0x060352EB RID: 217835
		int SkillNodeId { get; set; }

		// Token: 0x17008BF9 RID: 35833
		// (get) Token: 0x060352EC RID: 217836
		// (set) Token: 0x060352ED RID: 217837
		int CurrentLevel { get; set; }

		// Token: 0x17008BFA RID: 35834
		// (get) Token: 0x060352EE RID: 217838
		// (set) Token: 0x060352EF RID: 217839
		int TargetLevel { get; set; }

		// Token: 0x17008BFB RID: 35835
		// (get) Token: 0x060352F0 RID: 217840
		// (set) Token: 0x060352F1 RID: 217841
		int Index { get; set; }
	}
}
