using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x020023BA RID: 9146
[RequiredMember]
public class PayGiftPreviewBuildResult
{
	// Token: 0x06011A58 RID: 72280 RVA: 0x004D82DC File Offset: 0x004D64DC
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public PayGiftPreviewBuildResult()
	{
	}

	// Token: 0x04008A5E RID: 35422
	[Nullable(1)]
	[RequiredMember]
	public List<RewardItemData> PreviewItems;
}
