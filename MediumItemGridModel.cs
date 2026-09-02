using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020019F6 RID: 6646
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MediumItemGridModel : ModelBase<MediumItemGridModel>
{
	// Token: 0x0600BE45 RID: 48709 RVA: 0x003262A0 File Offset: 0x003244A0
	protected override bool OnInit()
	{
		this.ItemGridCoolDownSecond = ConfigCommonParamById.GetIntConfig("ItemGridCoolDownSecond").Value;
		this.AttackBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemIconAttack");
		this.DefenseBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemIconShield");
		this.RestoreHealthBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemIconHeart");
		this.RechargeBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemIconPhysical");
		this.ResurrectionBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ItemIconRecover");
		this.ExploreBuffSpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_Iconpropertyabsorbup_UI");
		return true;
	}

	// Token: 0x0600BE46 RID: 48710 RVA: 0x00326344 File Offset: 0x00324544
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0400597B RID: 22907
	public int ItemGridCoolDownSecond;

	// Token: 0x0400597C RID: 22908
	public string AttackBuffSpritePath;

	// Token: 0x0400597D RID: 22909
	public string DefenseBuffSpritePath;

	// Token: 0x0400597E RID: 22910
	public string RestoreHealthBuffSpritePath;

	// Token: 0x0400597F RID: 22911
	public string RechargeBuffSpritePath;

	// Token: 0x04005980 RID: 22912
	public string ResurrectionBuffSpritePath;

	// Token: 0x04005981 RID: 22913
	public string ExploreBuffSpritePath;
}
