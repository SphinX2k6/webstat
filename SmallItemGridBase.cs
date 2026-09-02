using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A4A RID: 6730
[NullableContext(2)]
[Nullable(0)]
public abstract class SmallItemGridBase : IMediumItemGridBase
{
	// Token: 0x17000FC7 RID: 4039
	// (get) Token: 0x0600C096 RID: 49302
	public abstract ESmallItemGridType Type { get; }

	// Token: 0x04005A0C RID: 23052
	public object Data;

	// Token: 0x04005A0D RID: 23053
	public int? SkinId;

	// Token: 0x04005A0E RID: 23054
	public bool? IsIconHide;

	// Token: 0x04005A0F RID: 23055
	public int? ItemConfigId;

	// Token: 0x04005A10 RID: 23056
	public string BottomTextId;

	// Token: 0x04005A11 RID: 23057
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public object[] BottomTextParameter;

	// Token: 0x04005A12 RID: 23058
	public string BottomText;

	// Token: 0x04005A13 RID: 23059
	public string IconPath;

	// Token: 0x04005A14 RID: 23060
	public bool? IsQualityHidden;

	// Token: 0x04005A15 RID: 23061
	public string QualityIconResourceId;

	// Token: 0x04005A16 RID: 23062
	public string QualityIcon;

	// Token: 0x04005A17 RID: 23063
	public int? QualityId;

	// Token: 0x04005A18 RID: 23064
	public CommonDefine.EQualityIconType? QualityType;

	// Token: 0x04005A19 RID: 23065
	public bool? IsDisable;

	// Token: 0x04005A1A RID: 23066
	public string TopRightTextId;

	// Token: 0x04005A1B RID: 23067
	public object[] TopRightTextParameter;

	// Token: 0x04005A1C RID: 23068
	public string TopRightText;

	// Token: 0x04005A1D RID: 23069
	public string TopRightTextBgColor;

	// Token: 0x04005A1E RID: 23070
	public string TopRightTextColor;

	// Token: 0x04005A1F RID: 23071
	public string RightTopValue;

	// Token: 0x04005A20 RID: 23072
	public bool? IsRedDotVisible;

	// Token: 0x04005A21 RID: 23073
	public bool? IsDoubleRewardVisible;

	// Token: 0x04005A22 RID: 23074
	public string SpriteIconPath;
}
