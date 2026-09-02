using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.MingSu;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews.Common;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.GeneralPanel
{
	// Token: 0x02004BB8 RID: 19384
	[NullableContext(1)]
	[Nullable(0)]
	public class GeneralPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329A8 RID: 207272 RVA: 0x00CACA27 File Offset: 0x00CAAC27
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329A9 RID: 207273 RVA: 0x00CACA30 File Offset: 0x00CAAC30
		protected override UniTask OnBeforeStartAsync()
		{
			GeneralPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GeneralPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060329AA RID: 207274 RVA: 0x00CACA73 File Offset: 0x00CAAC73
		protected override void OnStart()
		{
			this.DifficultyView = new GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData>(base.GetVerticalLayout(16), new Func<DifficultyItem>(this.OnCreateDifficultyItem), null, false, true);
			GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData> difficultyView = this.DifficultyView;
			if (difficultyView != null)
			{
				difficultyView.SetActive(false);
			}
			base.OnStart();
		}

		// Token: 0x060329AB RID: 207275 RVA: 0x00CACAB0 File Offset: 0x00CAACB0
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			PopupListItemPanel popupListItemPanel = this.PopupListItemPanel;
			if (popupListItemPanel != null)
			{
				popupListItemPanel.SetUiActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(36);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(25);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x060329AC RID: 207276 RVA: 0x00CACB50 File Offset: 0x00CAAD50
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				MarkItem markItem = param[0] as MarkItem;
				if (markItem != null)
				{
					this.SelectedMarkItem = markItem;
					this.LayoutContext.MarkItem = markItem;
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaAndIconByConfigOrDynamicConfigMarkItem(this.LayoutContext);
					base.UpdateTopRightIconActive();
					PopupListItemPanel popupListItemPanel = this.PopupListItemPanel;
					if (popupListItemPanel != null)
					{
						popupListItemPanel.SetTxtRTxtColor("#ac8839");
					}
					this.UpdateEnableFastMoveLayout();
					this.UpdateSubTypeView();
				}
			}
		}

		// Token: 0x060329AD RID: 207277 RVA: 0x00CACBDF File Offset: 0x00CAADDF
		protected DifficultyItem OnCreateDifficultyItem()
		{
			return new DifficultyItem();
		}

		// Token: 0x060329AE RID: 207278 RVA: 0x00CACBE6 File Offset: 0x00CAADE6
		protected override void OnConfirmBtnClick(int index)
		{
			this.HandleFastMoveAndTrack();
		}

		// Token: 0x060329AF RID: 207279 RVA: 0x00CACBF0 File Offset: 0x00CAADF0
		private void UpdateSubTypeView()
		{
			ConfigMarkItem configMarkItem = this.SelectedMarkItem as ConfigMarkItem;
			int relativeType;
			int relativeSubType;
			if (configMarkItem != null && configMarkItem.MarkConfig != null)
			{
				relativeType = configMarkItem.MarkConfig.Value.RelativeType;
				relativeSubType = configMarkItem.MarkConfig.Value.RelativeSubType;
			}
			else
			{
				DynamicConfigMarkItem dynamicConfigMarkItem = this.SelectedMarkItem as DynamicConfigMarkItem;
				if (dynamicConfigMarkItem == null || dynamicConfigMarkItem.MarkConfig == null)
				{
					return;
				}
				relativeType = dynamicConfigMarkItem.MarkConfig.Value.RelativeType;
				relativeSubType = dynamicConfigMarkItem.MarkConfig.Value.RelativeSubType;
			}
			if (relativeType == 1 && relativeSubType == 5)
			{
				this.SetupToDarkCoastLayoutAndRefresh();
			}
			TTrackTarget_Int ttrackTarget_Int = this.SelectedMarkItem.TrackTarget as TTrackTarget_Int;
			if (ttrackTarget_Int != null && ttrackTarget_Int.Value == 109002516)
			{
				this.SetupToExploreLayoutAndRefresh();
			}
		}

		// Token: 0x060329B0 RID: 207280 RVA: 0x00CACCC8 File Offset: 0x00CAAEC8
		private void SetupToDarkCoastLayoutAndRefresh()
		{
			ConfigMarkItem configMarkItem = this.SelectedMarkItem as ConfigMarkItem;
			MapMark? mapMark = (configMarkItem != null) ? configMarkItem.MarkConfig : null;
			if (mapMark == null)
			{
				return;
			}
			int relativeId = mapMark.Value.RelativeId;
			DarkCoastDeliveryLevelData darkCoastDeliveryDataByLevelPlayId = ModelBase<MingSuModel>.Instance.GetDarkCoastDeliveryDataByLevelPlayId(relativeId);
			if (darkCoastDeliveryDataByLevelPlayId == null)
			{
				return;
			}
			MingSuDefine.EDarkCoastDeliveryLevelDataState darkCoastDeliveryGuardState = darkCoastDeliveryDataByLevelPlayId.GetDarkCoastDeliveryGuardState();
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData> difficultyView = this.DifficultyView;
			if (difficultyView != null)
			{
				difficultyView.SetActive(true);
			}
			GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData> difficultyView2 = this.DifficultyView;
			if (difficultyView2 != null)
			{
				difficultyView2.RefreshByData(new <>z__ReadOnlySingleElementList<DarkCoastDeliveryLevelData>(darkCoastDeliveryDataByLevelPlayId), null, false);
			}
			bool flag = darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Passed;
			bool flag2 = darkCoastDeliveryGuardState == MingSuDefine.EDarkCoastDeliveryLevelDataState.Received;
			UUIItem item2 = base.GetItem(25);
			if (item2 != null)
			{
				item2.SetUIActive(flag || flag2);
			}
			UUIText text = base.GetText(36);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(30), "DarkShoreBossRewardNotGet", Array.Empty<object>());
				UUIText text2 = base.GetText(30);
				if (text2 != null)
				{
					text2.SetColor(FColor.FromHex("#51340CFF"));
				}
				UUISprite sprite = base.GetSprite(34);
				if (sprite != null)
				{
					sprite.SetColor(FColor.FromHex("#FFC9367F"));
				}
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ComIconSign");
				if (!string.IsNullOrEmpty(resourcePath))
				{
					this.SetSpriteByPath(resourcePath, base.GetSprite(35), false, null, null);
				}
			}
			if (flag2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(30), "DarkShoreBossRewardGet", Array.Empty<object>());
				UUIText text3 = base.GetText(30);
				if (text3 != null)
				{
					text3.SetColor(FColor.FromHex("#00000099"));
				}
				UUISprite sprite2 = base.GetSprite(34);
				if (sprite2 != null)
				{
					sprite2.SetColor(FColor.FromHex("#3EC79C7F"));
				}
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_AgreeFriend");
				if (!string.IsNullOrEmpty(resourcePath2))
				{
					this.SetSpriteByPath(resourcePath2, base.GetSprite(35), false, null, null);
				}
			}
		}

		// Token: 0x060329B1 RID: 207281 RVA: 0x00CACEC0 File Offset: 0x00CAB0C0
		private void SetupToExploreLayoutAndRefresh()
		{
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			PopupListItemPanel popupListItemPanel = this.PopupListItemPanel;
			if (popupListItemPanel != null)
			{
				popupListItemPanel.SetUiActive(true);
			}
			PopupListItemPanel popupListItemPanel2 = this.PopupListItemPanel;
			if (popupListItemPanel2 != null)
			{
				popupListItemPanel2.SetBtnHelpA2Active(false);
			}
			PopupListItemPanel popupListItemPanel3 = this.PopupListItemPanel;
			if (popupListItemPanel3 != null)
			{
				popupListItemPanel3.SetIconActive(false);
			}
			CountryExploreLevelData countryExploreLevelData = ModelBase<ExploreLevelModel>.Instance.GetCountryExploreLevelData(1);
			bool uiactive = countryExploreLevelData != null && countryExploreLevelData.CanLevelUp();
			UUIItem item2 = base.GetItem(25);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive);
			}
			if (countryExploreLevelData != null)
			{
				CountryExploreLevelRewardData currentExploreLevelRewardData = countryExploreLevelData.GetCurrentExploreLevelRewardData();
				PopupListItemPanel popupListItemPanel4 = this.PopupListItemPanel;
				if (popupListItemPanel4 != null)
				{
					popupListItemPanel4.SetTxtLActive(true);
				}
				PopupListItemPanel popupListItemPanel5 = this.PopupListItemPanel;
				if (popupListItemPanel5 != null)
				{
					popupListItemPanel5.SetTxtLNewTxt("ExploreLv_Text");
				}
				PopupListItemPanel popupListItemPanel6 = this.PopupListItemPanel;
				if (popupListItemPanel6 != null)
				{
					popupListItemPanel6.SetTexIconActive(false);
				}
				PopupListItemPanel popupListItemPanel7 = this.PopupListItemPanel;
				if (popupListItemPanel7 != null)
				{
					popupListItemPanel7.SetIconActive(true);
				}
				PopupListItemPanel popupListItemPanel8 = this.PopupListItemPanel;
				if (popupListItemPanel8 != null)
				{
					popupListItemPanel8.SetIconSprite("SP_ComRoleMapLevel");
				}
				PopupListItemPanel popupListItemPanel9 = this.PopupListItemPanel;
				if (popupListItemPanel9 != null)
				{
					popupListItemPanel9.SetTxtRActive(true);
				}
				PopupListItemPanel popupListItemPanel10 = this.PopupListItemPanel;
				if (popupListItemPanel10 != null)
				{
					popupListItemPanel10.SetTxtRNewTxt("ExploreLv_Value", new object[]
					{
						((currentExploreLevelRewardData != null) ? currentExploreLevelRewardData.GetExploreLevel().ToString() : null) ?? "0"
					});
				}
				PopupListItemPanel popupListItemPanel11 = this.PopupListItemPanel;
				if (popupListItemPanel11 != null)
				{
					popupListItemPanel11.SetTxtRTxtColor("#ac8839");
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(30), "ExploreRewardGet_Text", Array.Empty<object>());
				this.RefreshExploreRewardScrollView();
			}
		}

		// Token: 0x060329B2 RID: 207282 RVA: 0x00CAD05C File Offset: 0x00CAB25C
		private void RefreshExploreRewardScrollView()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			CountryExploreLevelData countryExploreLevelData = ModelBase<ExploreLevelModel>.Instance.GetCountryExploreLevelData(1);
			if (countryExploreLevelData == null)
			{
				return;
			}
			CountryExploreLevelRewardData currentExploreLevelRewardData = countryExploreLevelData.GetCurrentExploreLevelRewardData();
			if (currentExploreLevelRewardData == null)
			{
				return;
			}
			CountryExploreLevelRewardData exploreLevelRewardData = countryExploreLevelData.GetExploreLevelRewardData(currentExploreLevelRewardData.GetExploreLevel() + 1);
			if (exploreLevelRewardData == null)
			{
				RewardItemBar rewardsView = this.RewardsView;
				if (rewardsView != null)
				{
					rewardsView.RebuildRewardsByData(new List<TItem>());
				}
				RewardItemBar rewardsView2 = this.RewardsView;
				if (rewardsView2 == null)
				{
					return;
				}
				rewardsView2.SetTitleNewTxt("ExploreLvFull_Text");
				return;
			}
			else
			{
				Dictionary<int, int> dropItemNumMap = exploreLevelRewardData.GetDropItemNumMap();
				List<TItem> list = new List<TItem>();
				if (dropItemNumMap != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dropItemNumMap)
					{
						TItem item2 = new TItem
						{
							ItemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0),
							Count = keyValuePair.Value
						};
						list.Add(item2);
					}
				}
				RewardItemBar rewardsView3 = this.RewardsView;
				if (rewardsView3 != null)
				{
					rewardsView3.RebuildRewardsByData(list);
				}
				RewardItemBar rewardsView4 = this.RewardsView;
				if (rewardsView4 == null)
				{
					return;
				}
				rewardsView4.SetTitleNewTxt("ExploreNextLv_Text");
				return;
			}
		}

		// Token: 0x060329B3 RID: 207283 RVA: 0x00CAD1A4 File Offset: 0x00CAB3A4
		protected override void OnBeforeDestroy()
		{
			GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData> difficultyView = this.DifficultyView;
			if (difficultyView != null)
			{
				difficultyView.ClearChildren();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0401D7DF RID: 120799
		[Nullable(2)]
		private MarkItem SelectedMarkItem;

		// Token: 0x0401D7E0 RID: 120800
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DifficultyItem, DarkCoastDeliveryLevelData> DifficultyView;

		// Token: 0x0401D7E1 RID: 120801
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x0401D7E2 RID: 120802
		[Nullable(2)]
		private PopupListItemPanel PopupListItemPanel;

		// Token: 0x0200AC9B RID: 44187
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A2A RID: 219690
			public const int GeneralPanel = 0;
		}
	}
}
