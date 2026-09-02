using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006418 RID: 25624
	public class RoverlikeGameShopGridData : IRoverlikeGameShopGridData
	{
		// Token: 0x17009DE1 RID: 40417
		// (get) Token: 0x0604053E RID: 263486 RVA: 0x0107D2B9 File Offset: 0x0107B4B9
		// (set) Token: 0x0604053F RID: 263487 RVA: 0x0107D2C1 File Offset: 0x0107B4C1
		public int IncId { get; set; }

		// Token: 0x17009DE2 RID: 40418
		// (get) Token: 0x06040540 RID: 263488 RVA: 0x0107D2CA File Offset: 0x0107B4CA
		// (set) Token: 0x06040541 RID: 263489 RVA: 0x0107D2D2 File Offset: 0x0107B4D2
		public int ShowItemId { get; set; }

		// Token: 0x17009DE3 RID: 40419
		// (get) Token: 0x06040542 RID: 263490 RVA: 0x0107D2DB File Offset: 0x0107B4DB
		// (set) Token: 0x06040543 RID: 263491 RVA: 0x0107D2E3 File Offset: 0x0107B4E3
		public ERoverlikeGameShopItemType Type { get; set; }

		// Token: 0x17009DE4 RID: 40420
		// (get) Token: 0x06040544 RID: 263492 RVA: 0x0107D2EC File Offset: 0x0107B4EC
		// (set) Token: 0x06040545 RID: 263493 RVA: 0x0107D2F4 File Offset: 0x0107B4F4
		public int FinalPrice { get; set; }

		// Token: 0x17009DE5 RID: 40421
		// (get) Token: 0x06040546 RID: 263494 RVA: 0x0107D2FD File Offset: 0x0107B4FD
		// (set) Token: 0x06040547 RID: 263495 RVA: 0x0107D305 File Offset: 0x0107B505
		public int OriginalPrice { get; set; }

		// Token: 0x17009DE6 RID: 40422
		// (get) Token: 0x06040548 RID: 263496 RVA: 0x0107D30E File Offset: 0x0107B50E
		// (set) Token: 0x06040549 RID: 263497 RVA: 0x0107D316 File Offset: 0x0107B516
		public bool IsBought { get; set; }

		// Token: 0x17009DE7 RID: 40423
		// (get) Token: 0x0604054A RID: 263498 RVA: 0x0107D31F File Offset: 0x0107B51F
		// (set) Token: 0x0604054B RID: 263499 RVA: 0x0107D327 File Offset: 0x0107B527
		public bool IsSelected { get; set; }
	}
}
