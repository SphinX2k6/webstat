using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067F5 RID: 26613
	[NullableContext(1)]
	public interface IRequestCabinPut
	{
		// Token: 0x1700A123 RID: 41251
		// (get) Token: 0x0604258B RID: 271755
		// (set) Token: 0x0604258C RID: 271756
		CabinType Type { get; set; }

		// Token: 0x1700A124 RID: 41252
		// (get) Token: 0x0604258D RID: 271757
		// (set) Token: 0x0604258E RID: 271758
		int? RequestId { get; set; }

		// Token: 0x1700A125 RID: 41253
		// (get) Token: 0x0604258F RID: 271759
		// (set) Token: 0x06042590 RID: 271760
		List<FishingItemInfo> LeftDataList { get; set; }

		// Token: 0x1700A126 RID: 41254
		// (get) Token: 0x06042591 RID: 271761
		// (set) Token: 0x06042592 RID: 271762
		List<FishingItemInfo> RightDataList { get; set; }

		// Token: 0x1700A127 RID: 41255
		// (get) Token: 0x06042593 RID: 271763
		// (set) Token: 0x06042594 RID: 271764
		int? RemoveIncId { get; set; }

		// Token: 0x1700A128 RID: 41256
		// (get) Token: 0x06042595 RID: 271765
		// (set) Token: 0x06042596 RID: 271766
		[Nullable(2)]
		Action<bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
