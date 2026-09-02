using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CaveHole
{
	// Token: 0x02004BDB RID: 19419
	public class CaveHoleSecondaryPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032AC6 RID: 207558 RVA: 0x00CB0DD4 File Offset: 0x00CAEFD4
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032AC7 RID: 207559 RVA: 0x00CB0DDC File Offset: 0x00CAEFDC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06032AC8 RID: 207560 RVA: 0x00CB0E58 File Offset: 0x00CAF058
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			if (parameters.Length != 0)
			{
				CaveHoleMarkItem caveHoleMarkItem = parameters[0] as CaveHoleMarkItem;
				if (caveHoleMarkItem != null)
				{
					this.LayoutContext.MarkItem = caveHoleMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					base.UpdateTopRightIconActive();
					base.UpdateRightDownIconActive();
					bool flag = base.UpdateQuickGoto();
					WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
					if (layoutContext == null)
					{
						return;
					}
					layoutContext.SetConfirmBtnActive(!flag);
				}
			}
		}

		// Token: 0x06032AC9 RID: 207561 RVA: 0x00CB0EDF File Offset: 0x00CAF0DF
		protected override void OnConfirmBtnClick(int index)
		{
			this.HandleTrack();
		}

		// Token: 0x0200ACC4 RID: 44228
		public static class EComponents
		{
			// Token: 0x04035AA9 RID: 219817
			public const int CaveHole = 1;
		}
	}
}
