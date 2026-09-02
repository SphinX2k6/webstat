using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleSkill;
using CSharpScript.Game.Ui;

// Token: 0x020028B5 RID: 10421
public class RoleSkillTreeInfoViewData : UiPopViewData, IRoleSkillTreeInfoItemData
{
	// Token: 0x17001B26 RID: 6950
	// (get) Token: 0x06014AE2 RID: 84706 RVA: 0x005BA232 File Offset: 0x005B8432
	// (set) Token: 0x06014AE3 RID: 84707 RVA: 0x005BA23A File Offset: 0x005B843A
	public int RoleId { get; set; }

	// Token: 0x17001B27 RID: 6951
	// (get) Token: 0x06014AE4 RID: 84708 RVA: 0x005BA243 File Offset: 0x005B8443
	// (set) Token: 0x06014AE5 RID: 84709 RVA: 0x005BA24B File Offset: 0x005B844B
	public int SkillNodeId { get; set; }

	// Token: 0x04009F87 RID: 40839
	[Nullable(2)]
	public RoleViewAgent RoleViewAgent;
}
