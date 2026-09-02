using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TraceExploreEntityPanel
{
	// Token: 0x02004B84 RID: 19332
	public class TraceExploreEntityPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060327E0 RID: 206816 RVA: 0x00CA1C6F File Offset: 0x00C9FE6F
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060327E1 RID: 206817 RVA: 0x00CA1C76 File Offset: 0x00C9FE76
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.SetPanelItemLayoutActive(false);
		}

		// Token: 0x060327E2 RID: 206818 RVA: 0x00CA1CAC File Offset: 0x00C9FEAC
		private void SetPanelItemLayoutActive(bool active)
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout == null)
			{
				return;
			}
			verticalLayout.RootUIComp.Get().SetUIActive(active);
		}

		// Token: 0x060327E3 RID: 206819 RVA: 0x00CA1CD8 File Offset: 0x00C9FED8
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TraceExploreEntityMarkItem traceExploreEntityMarkItem = param[0] as TraceExploreEntityMarkItem;
				if (traceExploreEntityMarkItem != null)
				{
					this.LayoutContext.MarkItem = traceExploreEntityMarkItem;
					this.UpdateEnableFastMoveLayout();
					base.UpdateMultiMap();
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByServerMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDownStateIcon(this.LayoutContext);
					base.UpdateTopRightIconActive();
				}
			}
		}

		// Token: 0x0200AC54 RID: 44116
		public static class EComponents
		{
			// Token: 0x0403595F RID: 219487
			public const int TraceExploreEntityPanel = 0;
		}
	}
}
