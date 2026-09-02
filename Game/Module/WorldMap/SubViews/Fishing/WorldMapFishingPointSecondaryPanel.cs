using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BBF RID: 19391
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapFishingPointSecondaryPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329DD RID: 207325 RVA: 0x00CAD971 File Offset: 0x00CABB71
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329DE RID: 207326 RVA: 0x00CAD978 File Offset: 0x00CABB78
		protected override UniTask OnBeforeStartAsync()
		{
			WorldMapFishingPointSecondaryPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WorldMapFishingPointSecondaryPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060329DF RID: 207327 RVA: 0x00CAD9BC File Offset: 0x00CABBBC
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

		// Token: 0x060329E0 RID: 207328 RVA: 0x00CAD9F8 File Offset: 0x00CABBF8
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				FishingPointMarkItem fishingPointMarkItem = param[0] as FishingPointMarkItem;
				if (fishingPointMarkItem != null)
				{
					this.LayoutContext.MarkItem = fishingPointMarkItem;
					int entityId = 0;
					TTrackTarget_Int ttrackTarget_Int = fishingPointMarkItem.TrackTarget as TTrackTarget_Int;
					if (ttrackTarget_Int != null)
					{
						entityId = ttrackTarget_Int.Value;
					}
					string fishingPointNameLocalKey = ModelBase<FishingModel>.Instance.GetFishingPointNameLocalKey(entityId);
					string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointNameLocalKey, Array.Empty<string>());
					string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointMarkItem.MarkConfig.MarkTitle, new string[]
					{
						multiText
					});
					UUIText title = this.LayoutContext.Title;
					if (title != null)
					{
						title.SetText(multiText2, true);
					}
					WorldMapSecondaryUiLayoutHelper.UpdateIcon(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByServerMarkItem(this.LayoutContext);
					string multiText3 = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointMarkItem.MarkConfig.MarkDesc, new string[]
					{
						multiText
					});
					UUIText descriptionText = this.LayoutContext.DescriptionText;
					if (descriptionText != null)
					{
						descriptionText.SetText(multiText3, true);
					}
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithStopDetectionStyle(this.LayoutContext);
					this.RefreshTipList();
					base.UpdateQuickGotoActive(false);
				}
			}
		}

		// Token: 0x060329E1 RID: 207329 RVA: 0x00CADB0C File Offset: 0x00CABD0C
		private void RefreshTipList()
		{
			List<IWorldMapSecondaryTipItemParam> data = new List<IWorldMapSecondaryTipItemParam>
			{
				this.GetCapacityTipItemData(),
				this.GetNeedTechTipItemData(),
				this.GetAppearTimeTipItemData()
			};
			this.WorldMapSecondaryTipList.RefreshByData(data);
		}

		// Token: 0x060329E2 RID: 207330 RVA: 0x00CADB50 File Offset: 0x00CABD50
		private IWorldMapSecondaryTipItemParam GetCapacityTipItemData()
		{
			FishingPointMarkItem fishingPointMarkItem = this.LayoutContext.MarkItem as FishingPointMarkItem;
			int entityId = 0;
			TTrackTarget_Int ttrackTarget_Int = ((fishingPointMarkItem != null) ? fishingPointMarkItem.TrackTarget : null) as TTrackTarget_Int;
			if (ttrackTarget_Int != null)
			{
				entityId = ttrackTarget_Int.Value;
			}
			int item = ModelBase<FishingModel>.Instance.GetFishingPointCapacityInfoTuple(entityId).Item1;
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText4", Array.Empty<string>());
			string desc = item.ToString();
			return new WorldMapSecondaryTipItemParam
			{
				Name = multiText,
				Desc = desc
			};
		}

		// Token: 0x060329E3 RID: 207331 RVA: 0x00CADBD0 File Offset: 0x00CABDD0
		private IWorldMapSecondaryTipItemParam GetNeedTechTipItemData()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			int entityId = 0;
			TTrackTarget_Int ttrackTarget_Int = ((markItem != null) ? markItem.TrackTarget : null) as TTrackTarget_Int;
			if (ttrackTarget_Int != null)
			{
				entityId = ttrackTarget_Int.Value;
			}
			string fishingPointTechNameLocalKey = ModelBase<FishingModel>.Instance.GetFishingPointTechNameLocalKey(entityId);
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText2", Array.Empty<string>());
			string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointTechNameLocalKey, Array.Empty<string>());
			return new WorldMapSecondaryTipItemParam
			{
				Name = multiText,
				Desc = multiText2
			};
		}

		// Token: 0x060329E4 RID: 207332 RVA: 0x00CADC50 File Offset: 0x00CABE50
		private IWorldMapSecondaryTipItemParam GetAppearTimeTipItemData()
		{
			MarkItem markItem = this.LayoutContext.MarkItem;
			int entityId = 0;
			TTrackTarget_Int ttrackTarget_Int = ((markItem != null) ? markItem.TrackTarget : null) as TTrackTarget_Int;
			if (ttrackTarget_Int != null)
			{
				entityId = ttrackTarget_Int.Value;
			}
			string fishingPointAppearTimeLocalKey = ModelBase<FishingModel>.Instance.GetFishingPointAppearTimeLocalKey(entityId);
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("Fishing_MarkText3", Array.Empty<string>());
			string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText(fishingPointAppearTimeLocalKey, Array.Empty<string>());
			return new WorldMapSecondaryTipItemParam
			{
				Name = multiText,
				Desc = multiText2
			};
		}

		// Token: 0x060329E5 RID: 207333 RVA: 0x00CADCCD File Offset: 0x00CABECD
		protected override void OnConfirmBtnClick(int index)
		{
			ControllerBase<FishingController>.Instance.RequestFishingEntrustTrace(0);
			ModelBase<FishingQuestModel>.Instance.TraceItem(0);
			base.Close();
		}

		// Token: 0x0401D7ED RID: 120813
		private WorldMapSecondaryTipListPanel WorldMapSecondaryTipList;

		// Token: 0x0200ACA1 RID: 44193
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A37 RID: 219703
			public const int FishingPoint = 0;
		}
	}
}
