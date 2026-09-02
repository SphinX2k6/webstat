using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BBB RID: 19387
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapFishingCageSecondaryPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329C3 RID: 207299 RVA: 0x00CAD3AE File Offset: 0x00CAB5AE
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329C4 RID: 207300 RVA: 0x00CAD3B8 File Offset: 0x00CAB5B8
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapFishingCageSecondaryPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapFishingCageSecondaryPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060329C5 RID: 207301 RVA: 0x00CAD3FC File Offset: 0x00CAB5FC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			UUIVerticalLayout panelListLayout = layoutContext.PanelListLayout;
			if (panelListLayout == null)
			{
				return;
			}
			panelListLayout.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x060329C6 RID: 207302 RVA: 0x00CAD438 File Offset: 0x00CAB638
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				ConfigMarkItem configMarkItem = param[0] as ConfigMarkItem;
				if (configMarkItem != null)
				{
					this.LayoutContext.MarkItem = configMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithTrackStyle(this.LayoutContext);
					this.RefreshTipList();
					base.UpdateQuickGotoActive(false);
				}
			}
		}

		// Token: 0x060329C7 RID: 207303 RVA: 0x00CAD49C File Offset: 0x00CAB69C
		private void RefreshTipList()
		{
			List<IWorldMapSecondaryTipItemParam> data = new List<IWorldMapSecondaryTipItemParam>
			{
				this.GetNextHarvestTimeTipItemData(),
				this.GetCapacityTipItemData()
			};
			this.WorldMapSecondaryTipList.RefreshByData(data);
		}

		// Token: 0x060329C8 RID: 207304 RVA: 0x00CAD4D4 File Offset: 0x00CAB6D4
		private IWorldMapFishingCageSecondaryTipItemParam GetNextHarvestTimeTipItemData()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			MarkConfigComponent markConfigComponent = (markItem != null) ? markItem.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			int valueOrDefault = ((markConfigComponent != null) ? markConfigComponent.RelativeId : null).GetValueOrDefault();
			return new WorldMapFishingCageSecondaryTipItemParam
			{
				Name = "",
				Desc = "",
				RelativeId = valueOrDefault,
				TipItemType = EFishingCageSecondaryTipItemType.NextHarvestTimeStamp
			};
		}

		// Token: 0x060329C9 RID: 207305 RVA: 0x00CAD548 File Offset: 0x00CAB748
		private IWorldMapFishingCageSecondaryTipItemParam GetCapacityTipItemData()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			MarkConfigComponent markConfigComponent = (markItem != null) ? markItem.MarkItemEntity.GetComponent<MarkConfigComponent>(EMapComponent.MarkConfig) : null;
			int valueOrDefault = ((markConfigComponent != null) ? markConfigComponent.RelativeId : null).GetValueOrDefault();
			return new WorldMapFishingCageSecondaryTipItemParam
			{
				Name = "",
				Desc = "",
				RelativeId = valueOrDefault,
				TipItemType = EFishingCageSecondaryTipItemType.Capacity
			};
		}

		// Token: 0x0401D7EA RID: 120810
		private WorldMapFishingCageTipListPanel WorldMapSecondaryTipList;

		// Token: 0x0200AC9D RID: 44189
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A2F RID: 219695
			public const int FishingCage = 0;
		}
	}
}
