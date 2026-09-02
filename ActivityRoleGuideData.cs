using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02001576 RID: 5494
[NullableContext(1)]
[Nullable(0)]
public class ActivityRoleGuideData : ActivityBaseData
{
	// Token: 0x17000D2A RID: 3370
	// (get) Token: 0x06009A38 RID: 39480 RVA: 0x002863FD File Offset: 0x002845FD
	// (set) Token: 0x06009A39 RID: 39481 RVA: 0x00286405 File Offset: 0x00284605
	public RoleGuideActivity? RoleGuideConfig { get; set; }

	// Token: 0x06009A3A RID: 39482 RVA: 0x00286410 File Offset: 0x00284610
	protected override void PhraseEx(ActivityData data)
	{
		this.RoleGuideConfig = ConfigBase<ActivityRoleGuideConfig>.Instance.GetRoleTrialActivityConfig(base.Id);
		if (this.RoleGuideConfig == null)
		{
			return;
		}
		this.RoleId = this.RoleGuideConfig.Value.RoleId;
		this.RoleQuestId = this.RoleGuideConfig.Value.RoleQuestId;
		this.RoleTrialId = this.RoleGuideConfig.Value.RoleTrialId;
		this.ShowQuestId = this.RoleGuideConfig.Value.ShowQuestId;
	}

	// Token: 0x06009A3B RID: 39483 RVA: 0x002864B4 File Offset: 0x002846B4
	public string GetRoleResourcePath()
	{
		string roleUi = this.RoleGuideConfig.Value.RoleUi;
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(roleUi) ?? "";
	}

	// Token: 0x06009A3C RID: 39484 RVA: 0x002864EC File Offset: 0x002846EC
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06009A3D RID: 39485 RVA: 0x002864EF File Offset: 0x002846EF
	public override bool GetExDataRedPointShowState()
	{
		return false;
	}

	// Token: 0x0400471C RID: 18204
	public int RoleId;

	// Token: 0x0400471D RID: 18205
	public int RoleQuestId;

	// Token: 0x0400471E RID: 18206
	public int RoleTrialId;

	// Token: 0x0400471F RID: 18207
	public int ShowQuestId;
}
