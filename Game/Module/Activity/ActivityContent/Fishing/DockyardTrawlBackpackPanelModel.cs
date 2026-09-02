using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D5 RID: 26581
	public class DockyardTrawlBackpackPanelModel : DockyardBackpackPanelModelBase
	{
		// Token: 0x060424E9 RID: 271593 RVA: 0x01102263 File Offset: 0x01100463
		public override bool GetIsTrawlOpen()
		{
			return ModelBase<FishingModel>.Instance.IsInDock && ModelBase<DockyardModel>.Instance.IsTrawlOpen;
		}

		// Token: 0x060424EA RID: 271594 RVA: 0x0110227D File Offset: 0x0110047D
		public override bool GetIsBackToWareHouseOpen()
		{
			IDockyardBackpackInterface viewModel = this.ViewModel;
			return viewModel != null && viewModel.IsTrawlInteractive();
		}
	}
}
