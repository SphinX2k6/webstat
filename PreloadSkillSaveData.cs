using System;
using System.Runtime.CompilerServices;

// Token: 0x020034BA RID: 13498
public class PreloadSkillSaveData : PreloadSaveData
{
	// Token: 0x0400E5A5 RID: 58789
	public int SkillId;

	// Token: 0x0400E5A6 RID: 58790
	[Nullable(1)]
	public string ActorBlueprint = "";

	// Token: 0x0400E5A7 RID: 58791
	public int LoadType;

	// Token: 0x0400E5A8 RID: 58792
	public bool IsCommon;

	// Token: 0x0400E5A9 RID: 58793
	public bool HasMontagePath;
}
