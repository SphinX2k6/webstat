using System;
using System.Runtime.CompilerServices;

// Token: 0x020032A7 RID: 12967
[NullableContext(1)]
[Nullable(0)]
public class SkillAssetRecord
{
	// Token: 0x0400DD80 RID: 56704
	public int SkillId;

	// Token: 0x0400DD81 RID: 56705
	public string ActorBlueprint = "";

	// Token: 0x0400DD82 RID: 56706
	public int LoadType;

	// Token: 0x0400DD83 RID: 56707
	public bool IsCommon;

	// Token: 0x0400DD84 RID: 56708
	public bool HasMontagePath;

	// Token: 0x0400DD85 RID: 56709
	public AssetRecord AssetRecord = new AssetRecord();
}
