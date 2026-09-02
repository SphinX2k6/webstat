using System;
using System.Runtime.CompilerServices;

// Token: 0x020032AD RID: 12973
public class EntityMainAssetRecord
{
	// Token: 0x0400DD92 RID: 56722
	public int ModelId;

	// Token: 0x0400DD93 RID: 56723
	[Nullable(2)]
	public string ActorClassPath;

	// Token: 0x0400DD94 RID: 56724
	[Nullable(1)]
	public AssetRecord AssetRecord = new AssetRecord();
}
