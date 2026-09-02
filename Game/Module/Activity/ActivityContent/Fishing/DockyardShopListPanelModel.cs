using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C4 RID: 26564
	public class DockyardShopListPanelModel : DockyardItemListPanelModel
	{
		// Token: 0x06042455 RID: 271445 RVA: 0x010FFC53 File Offset: 0x010FDE53
		protected override void OnInit()
		{
			base.ComponentData.TitleText = "Fishing_CageText1";
			base.ComponentData.HelpBtnId = 194;
			this.MaxCount = ModelBase<DockyardModel>.Instance.TrawlSize;
		}

		// Token: 0x06042456 RID: 271446 RVA: 0x010FFC85 File Offset: 0x010FDE85
		[NullableContext(1)]
		public override List<DockyardItemBlockOriginalData> GetShowItemList()
		{
			return ModelBase<DockyardModel>.Instance.GetTrawlDataList();
		}

		// Token: 0x06042457 RID: 271447 RVA: 0x010FFC94 File Offset: 0x010FDE94
		protected override bool CheckOtherCanDragCondition(bool fromDragResult)
		{
			if (base.CheckSelectedInList())
			{
				return true;
			}
			bool flag = base.ShowItemList.Count < this.MaxCount;
			if (fromDragResult && !flag)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_DraftFull", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x04024E6F RID: 151151
		protected int MaxCount;
	}
}
