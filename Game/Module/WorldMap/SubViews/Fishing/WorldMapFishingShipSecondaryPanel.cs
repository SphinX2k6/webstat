using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BC0 RID: 19392
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapFishingShipSecondaryPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329E8 RID: 207336 RVA: 0x00CADCFB File Offset: 0x00CABEFB
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329E9 RID: 207337 RVA: 0x00CADD04 File Offset: 0x00CABF04
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapFishingShipSecondaryPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapFishingShipSecondaryPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060329EA RID: 207338 RVA: 0x00CADD48 File Offset: 0x00CABF48
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				UUIText areaText = layoutContext.AreaText;
				if (areaText != null)
				{
					areaText.SetUIActive(false);
				}
			}
			WorldMapSecondaryUiContext layoutContext2 = this.LayoutContext;
			if (layoutContext2 == null)
			{
				return;
			}
			UUIVerticalLayout panelListLayout = layoutContext2.PanelListLayout;
			if (panelListLayout == null)
			{
				return;
			}
			panelListLayout.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x060329EB RID: 207339 RVA: 0x00CADDA0 File Offset: 0x00CABFA0
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				FishingShipMarkItem fishingShipMarkItem = param[0] as FishingShipMarkItem;
				if (fishingShipMarkItem != null)
				{
					this.LayoutContext.MarkItem = fishingShipMarkItem;
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
					if (layoutContext != null)
					{
						layoutContext.SetConfirmBtnText("Fishing_FastOnBoat", Array.Empty<object>());
					}
					this.RefreshTipList();
					base.UpdateQuickGotoActive(false);
				}
			}
		}

		// Token: 0x060329EC RID: 207340 RVA: 0x00CADE08 File Offset: 0x00CAC008
		private void RefreshTipList()
		{
			List<IWorldMapSecondaryTipItemParam> data = new List<IWorldMapSecondaryTipItemParam>
			{
				this.GetCapacityTipItemData()
			};
			this.WorldMapSecondaryTipList.RefreshByData(data);
		}

		// Token: 0x060329ED RID: 207341 RVA: 0x00CADE34 File Offset: 0x00CAC034
		private IWorldMapSecondaryTipItemParam GetCapacityTipItemData()
		{
			int backpackUseSize = ModelBase<DockyardModel>.Instance.BackpackUseSize;
			int backpackSize = ModelBase<DockyardModel>.Instance.BackpackSize;
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText1", Array.Empty<string>());
			string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_QTE_Count", new string[]
			{
				backpackUseSize.ToString(),
				backpackSize.ToString()
			});
			return new WorldMapSecondaryTipItemParam
			{
				Name = multiText,
				Desc = multiText2
			};
		}

		// Token: 0x060329EE RID: 207342 RVA: 0x00CADEA9 File Offset: 0x00CAC0A9
		protected override void OnConfirmBtnClick(int index)
		{
			ControllerBase<FishingController>.Instance.FishingTeleportToBoat();
		}

		// Token: 0x0401D7EE RID: 120814
		private WorldMapSecondaryTipListPanel WorldMapSecondaryTipList;

		// Token: 0x0200ACA3 RID: 44195
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A3C RID: 219708
			public const int FishingShip = 0;
		}
	}
}
