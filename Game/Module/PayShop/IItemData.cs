using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B5 RID: 22197
	[NullableContext(1)]
	public interface IItemData
	{
		// Token: 0x170090B0 RID: 37040
		// (get) Token: 0x060387E6 RID: 231398
		// (set) Token: 0x060387E7 RID: 231399
		int Quality { get; set; }

		// Token: 0x170090B1 RID: 37041
		// (get) Token: 0x060387E8 RID: 231400
		// (set) Token: 0x060387E9 RID: 231401
		int ItemId { get; set; }

		// Token: 0x170090B2 RID: 37042
		// (get) Token: 0x060387EA RID: 231402
		// (set) Token: 0x060387EB RID: 231403
		string Name { get; set; }

		// Token: 0x170090B3 RID: 37043
		// (get) Token: 0x060387EC RID: 231404
		// (set) Token: 0x060387ED RID: 231405
		EItemQualityType QualityType { get; set; }
	}
}
