using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.HonamiPanel
{
	// Token: 0x02004BB2 RID: 19378
	public class HonamiScanItemPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032988 RID: 207240 RVA: 0x00CAC124 File Offset: 0x00CAA324
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032989 RID: 207241 RVA: 0x00CAC12C File Offset: 0x00CAA32C
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(16);
			if (verticalLayout != null)
			{
				verticalLayout.SetActive(false, false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(7);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout3 = base.GetVerticalLayout(5);
			if (verticalLayout3 != null)
			{
				verticalLayout3.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			base.OnStart();
		}

		// Token: 0x0603298A RID: 207242 RVA: 0x00CAC1BC File Offset: 0x00CAA3BC
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				HonamiScanItemMarkItem honamiScanItemMarkItem = param[0] as HonamiScanItemMarkItem;
				if (honamiScanItemMarkItem != null)
				{
					this.LayoutContext.MarkItem = honamiScanItemMarkItem;
					this.UpdateEnableFastMoveLayout();
					base.UpdateMultiMap();
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateIconByServerMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByServerMarkItem(this.LayoutContext);
					this.UpdateTitle();
					this.UpdateDescription();
					base.UpdateTopRightIconActive();
				}
			}
		}

		// Token: 0x0603298B RID: 207243 RVA: 0x00CAC22F File Offset: 0x00CAA42F
		protected override void UpdateEnableFastMoveLayout()
		{
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				layoutContext.SetConfirmBtnActive(false);
			}
			WorldMapSecondaryUiContext layoutContext2 = this.LayoutContext;
			if (layoutContext2 != null)
			{
				layoutContext2.SetConfirmBtnEnableClick(false);
			}
			base.UpdateQuickGotoActive(true);
		}

		// Token: 0x0603298C RID: 207244 RVA: 0x00CAC25C File Offset: 0x00CAA45C
		private void UpdateDescription()
		{
			HonamiScanItemMarkItem honamiScanItemMarkItem = this.LayoutContext.MarkItem as HonamiScanItemMarkItem;
			if (honamiScanItemMarkItem != null)
			{
				UUIText descriptionText = this.LayoutContext.DescriptionText;
				if (descriptionText == null)
				{
					return;
				}
				descriptionText.ShowTextNew(honamiScanItemMarkItem.GetDescriptionText());
			}
		}

		// Token: 0x0603298D RID: 207245 RVA: 0x00CAC298 File Offset: 0x00CAA498
		private void UpdateTitle()
		{
			HonamiScanItemMarkItem honamiScanItemMarkItem = this.LayoutContext.MarkItem as HonamiScanItemMarkItem;
			if (honamiScanItemMarkItem != null)
			{
				UUIText title = this.LayoutContext.Title;
				if (title == null)
				{
					return;
				}
				title.SetText(honamiScanItemMarkItem.GetTitleText(), true);
			}
		}

		// Token: 0x0200AC96 RID: 44182
		public static class EComponents
		{
			// Token: 0x04035A1F RID: 219679
			public const int HonamiScanItemPanel = 0;
		}
	}
}
