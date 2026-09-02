using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A73 RID: 6771
[NullableContext(1)]
[Nullable(0)]
public class CommonTipsBaseData
{
	// Token: 0x04005AB3 RID: 23219
	public int? IncId = new int?(0);

	// Token: 0x04005AB4 RID: 23220
	public int ConfigId;

	// Token: 0x04005AB5 RID: 23221
	public string Name = "";

	// Token: 0x04005AB6 RID: 23222
	public int QualityId;

	// Token: 0x04005AB7 RID: 23223
	public CommonComponentDefine.ECommonTipsType ItemType = CommonComponentDefine.ECommonTipsType.Weapon;

	// Token: 0x04005AB8 RID: 23224
	public string BgDescription = "";

	// Token: 0x04005AB9 RID: 23225
	public string LevelText = "";

	// Token: 0x04005ABA RID: 23226
	public string MaxLevelText = "";

	// Token: 0x04005ABB RID: 23227
	public string Type = "";

	// Token: 0x04005ABC RID: 23228
	public int EquippedId;

	// Token: 0x04005ABD RID: 23229
	public string EquippedIcon = "";

	// Token: 0x04005ABE RID: 23230
	public string EquippedName = "";
}
