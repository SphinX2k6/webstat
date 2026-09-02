using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BBE RID: 19390
	public class WorldMapFishingDockSecondaryPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329D7 RID: 207319 RVA: 0x00CAD83B File Offset: 0x00CABA3B
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329D8 RID: 207320 RVA: 0x00CAD844 File Offset: 0x00CABA44
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

		// Token: 0x060329D9 RID: 207321 RVA: 0x00CAD8C0 File Offset: 0x00CABAC0
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				ConfigMarkItem configMarkItem = param[0] as ConfigMarkItem;
				if (configMarkItem != null)
				{
					this.LayoutContext.MarkItem = configMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonEnableClickByTeleportState(this.LayoutContext);
					this.UpdateConfirmButton();
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					base.UpdateMultiMap();
					base.UpdateQuickGotoActive(false);
				}
			}
		}

		// Token: 0x060329DA RID: 207322 RVA: 0x00CAD928 File Offset: 0x00CABB28
		private void UpdateConfirmButton()
		{
			if (ModelBase<FishingModel>.Instance.IsOnShipVehicle())
			{
				WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithTrackStyle(this.LayoutContext);
				return;
			}
			WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
		}

		// Token: 0x060329DB RID: 207323 RVA: 0x00CAD94D File Offset: 0x00CABB4D
		protected override void OnConfirmBtnClick(int index)
		{
			if (ModelBase<FishingModel>.Instance.IsOnShipVehicle())
			{
				this.HandleTrack();
				return;
			}
			this.HandleTeleport();
		}

		// Token: 0x0200ACA0 RID: 44192
		public static class EComponents
		{
			// Token: 0x04035A36 RID: 219702
			public const int FishingDock = 0;
		}
	}
}
