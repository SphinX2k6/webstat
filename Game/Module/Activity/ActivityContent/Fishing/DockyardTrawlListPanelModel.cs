using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D6 RID: 26582
	public class DockyardTrawlListPanelModel : DockyardItemListPanelModel
	{
		// Token: 0x060424EC RID: 271596 RVA: 0x01102298 File Offset: 0x01100498
		protected override void OnInit()
		{
			base.ComponentData.TitleText = "Fishing_CageText5";
			base.ComponentData.HelpBtnId = 194;
			this.MaxCount = ModelBase<DockyardModel>.Instance.TrawlSize;
		}

		// Token: 0x060424ED RID: 271597 RVA: 0x011022CA File Offset: 0x011004CA
		[NullableContext(1)]
		public override List<DockyardItemBlockOriginalData> GetShowItemList()
		{
			return ModelBase<DockyardModel>.Instance.GetTrawlDataList();
		}

		// Token: 0x060424EE RID: 271598 RVA: 0x011022D8 File Offset: 0x011004D8
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

		// Token: 0x04024E95 RID: 151189
		protected int MaxCount;
	}
}
