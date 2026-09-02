using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006417 RID: 25623
	public interface IRoverlikeGameShopGridData
	{
		// Token: 0x17009DDA RID: 40410
		// (get) Token: 0x06040530 RID: 263472
		// (set) Token: 0x06040531 RID: 263473
		int IncId { get; set; }

		// Token: 0x17009DDB RID: 40411
		// (get) Token: 0x06040532 RID: 263474
		// (set) Token: 0x06040533 RID: 263475
		int ShowItemId { get; set; }

		// Token: 0x17009DDC RID: 40412
		// (get) Token: 0x06040534 RID: 263476
		// (set) Token: 0x06040535 RID: 263477
		ERoverlikeGameShopItemType Type { get; set; }

		// Token: 0x17009DDD RID: 40413
		// (get) Token: 0x06040536 RID: 263478
		// (set) Token: 0x06040537 RID: 263479
		int FinalPrice { get; set; }

		// Token: 0x17009DDE RID: 40414
		// (get) Token: 0x06040538 RID: 263480
		// (set) Token: 0x06040539 RID: 263481
		int OriginalPrice { get; set; }

		// Token: 0x17009DDF RID: 40415
		// (get) Token: 0x0604053A RID: 263482
		// (set) Token: 0x0604053B RID: 263483
		bool IsBought { get; set; }

		// Token: 0x17009DE0 RID: 40416
		// (get) Token: 0x0604053C RID: 263484
		// (set) Token: 0x0604053D RID: 263485
		bool IsSelected { get; set; }
	}
}
