using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D8 RID: 26584
	public class DockyardWareHouseListPanelModel : DockyardItemListPanelModel
	{
		// Token: 0x060424F1 RID: 271601 RVA: 0x0110232E File Offset: 0x0110052E
		protected override void OnInit()
		{
			base.ComponentData.TitleText = "Fishing_CageText1";
		}

		// Token: 0x060424F2 RID: 271602 RVA: 0x01102340 File Offset: 0x01100540
		[NullableContext(1)]
		public override List<DockyardItemBlockOriginalData> GetShowItemList()
		{
			return ModelBase<DockyardModel>.Instance.GetWareHouseDataList();
		}
	}
}
