using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AA RID: 26538
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractBackpackPanelModel : DockyardBackpackPanelModelBase
	{
		// Token: 0x060422DA RID: 271066 RVA: 0x010F9CCD File Offset: 0x010F7ECD
		public void RegisterInteractPanel(DockyardInteractPanelModel interactPanel)
		{
			this.InteractPanelModel = interactPanel;
		}

		// Token: 0x060422DB RID: 271067 RVA: 0x010F9CD6 File Offset: 0x010F7ED6
		public override bool IsQuickSellOpen()
		{
			return false;
		}

		// Token: 0x060422DC RID: 271068 RVA: 0x010F9CD9 File Offset: 0x010F7ED9
		public override bool GetIsBackToWareHouseOpen()
		{
			return false;
		}

		// Token: 0x060422DD RID: 271069 RVA: 0x010F9CDC File Offset: 0x010F7EDC
		public void ShowScrollingTips()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_CantPutDown", Array.Empty<object>());
		}

		// Token: 0x04024DDC RID: 151004
		protected DockyardInteractPanelModel InteractPanelModel;

		// Token: 0x04024DDD RID: 151005
		public int ConfigId;
	}
}
