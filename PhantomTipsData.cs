using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A76 RID: 6774
[NullableContext(1)]
[Nullable(0)]
public class PhantomTipsData : CommonTipsBaseData
{
	// Token: 0x04005AC3 RID: 23235
	public int PhantomId;

	// Token: 0x04005AC4 RID: 23236
	public int Level;

	// Token: 0x04005AC5 RID: 23237
	public string RarityId = "";

	// Token: 0x04005AC6 RID: 23238
	public string PropertyTexture = "";

	// Token: 0x04005AC7 RID: 23239
	public int PropertyId;

	// Token: 0x04005AC8 RID: 23240
	public bool IsBreak;

	// Token: 0x04005AC9 RID: 23241
	public List<CommonComponentDefine.TipsAttributeData> BreakAttributeList = new List<CommonComponentDefine.TipsAttributeData>();

	// Token: 0x04005ACA RID: 23242
	public bool IsMain;

	// Token: 0x04005ACB RID: 23243
	public List<CommonComponentDefine.TipsAttributeData> MainAttributeList = new List<CommonComponentDefine.TipsAttributeData>();

	// Token: 0x04005ACC RID: 23244
	public string MainSkillText = "";

	// Token: 0x04005ACD RID: 23245
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] MainSkillParameter;

	// Token: 0x04005ACE RID: 23246
	public string SkillIcon = "";

	// Token: 0x04005ACF RID: 23247
	public bool IsSub;

	// Token: 0x04005AD0 RID: 23248
	public List<CommonComponentDefine.TipsAttributeData> SubAttributeList = new List<CommonComponentDefine.TipsAttributeData>();

	// Token: 0x04005AD1 RID: 23249
	public bool IsUnlockSub;

	// Token: 0x04005AD2 RID: 23250
	public string UnlockSubTips = "";
}
