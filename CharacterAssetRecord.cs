using System;
using System.Runtime.CompilerServices;

// Token: 0x020032AB RID: 12971
public class CharacterAssetRecord
{
	// Token: 0x0400DD8D RID: 56717
	public int RoleId;

	// Token: 0x0400DD8E RID: 56718
	public int AiId;

	// Token: 0x0400DD8F RID: 56719
	[Nullable(1)]
	public AssetRecord AssetRecord = new AssetRecord();
}
