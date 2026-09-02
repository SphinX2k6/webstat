using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.BoxPanel
{
	// Token: 0x02004BDC RID: 19420
	public class BoxPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032ACB RID: 207563 RVA: 0x00CB0EEF File Offset: 0x00CAF0EF
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032ACC RID: 207564 RVA: 0x00CB0EF8 File Offset: 0x00CAF0F8
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				layoutContext.SetConfirmBtnActive(false);
			}
			UUIItem item3 = base.GetItem(32);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
		}

		// Token: 0x06032ACD RID: 207565 RVA: 0x00CB0F98 File Offset: 0x00CAF198
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			if (parameters.Length != 0)
			{
				MarkItem markItem = parameters[0] as MarkItem;
				if (markItem != null)
				{
					this.LayoutContext.MarkItem = markItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateBoxDesc(this.LayoutContext);
				}
			}
		}

		// Token: 0x0200ACC5 RID: 44229
		public static class EComponents
		{
			// Token: 0x04035AAA RID: 219818
			public const int BoxPanel = 0;
		}
	}
}
