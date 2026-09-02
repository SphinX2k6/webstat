using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001A53 RID: 6739
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SmallItemGridModel : ModelBase<SmallItemGridModel>
{
	// Token: 0x0600C0A9 RID: 49321 RVA: 0x0032D658 File Offset: 0x0032B858
	protected override bool OnInit()
	{
		this.ItemGridNameMaxLength = ConfigCommonParamById.GetIntConfig("ItemGridNameMaxLength").Value;
		this.DefaultQualitySpritePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_QualityVisionB");
		this.ItemGridCoolDownSecond = ConfigCommonParamById.GetIntConfig("ItemGridCoolDownSecond").Value;
		return true;
	}

	// Token: 0x04005A52 RID: 23122
	public int ItemGridCoolDownSecond;

	// Token: 0x04005A53 RID: 23123
	public int ItemGridNameMaxLength;

	// Token: 0x04005A54 RID: 23124
	public string DefaultQualitySpritePath;
}
