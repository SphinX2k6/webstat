using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C2 RID: 26562
	public class DockyardShopBackpackPanelModel : DockyardBackpackPanelModelBase
	{
		// Token: 0x0604244A RID: 271434 RVA: 0x010FFB9F File Offset: 0x010FDD9F
		public override bool GetIsTrawlOpen()
		{
			return ModelBase<FishingModel>.Instance.IsInDock && ModelBase<DockyardModel>.Instance.IsTrawlOpen;
		}

		// Token: 0x1700A111 RID: 41233
		// (get) Token: 0x0604244B RID: 271435 RVA: 0x010FFBB9 File Offset: 0x010FDDB9
		// (set) Token: 0x0604244C RID: 271436 RVA: 0x010FFBC1 File Offset: 0x010FDDC1
		public override bool IsAllSellOpen { get; set; } = true;

		// Token: 0x1700A112 RID: 41234
		// (get) Token: 0x0604244D RID: 271437 RVA: 0x010FFBCA File Offset: 0x010FDDCA
		// (set) Token: 0x0604244E RID: 271438 RVA: 0x010FFBD2 File Offset: 0x010FDDD2
		public override bool IsDeleteOpen { get; set; }

		// Token: 0x0604244F RID: 271439 RVA: 0x010FFBDB File Offset: 0x010FDDDB
		public override bool GetIsBackToWareHouseOpen()
		{
			return false;
		}
	}
}
