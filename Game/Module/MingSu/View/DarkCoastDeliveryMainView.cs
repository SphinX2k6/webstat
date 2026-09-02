using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573F RID: 22335
	[NullableContext(1)]
	[Nullable(0)]
	public class DarkCoastDeliveryMainView : UiViewBase
	{
		// Token: 0x06038D88 RID: 232840 RVA: 0x00E6620B File Offset: 0x00E6440B
		public DarkCoastDeliveryMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038D89 RID: 232841 RVA: 0x00E66238 File Offset: 0x00E64438
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(20, typeof(UUIText)),
				new ValueTuple<int, Type>(21, typeof(UUIText)),
				new ValueTuple<int, Type>(22, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(25, typeof(UUIItem)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUIItem)),
				new ValueTuple<int, Type>(28, typeof(UUIItem)),
				new ValueTuple<int, Type>(29, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(19, new Action(this.OnClickRewardBtn)),
				new ValueTuple<int, Delegate>(22, new Action(this.OnClickSubmitBtn)),
				new ValueTuple<int, Delegate>(24, new Action(this.OnClickSubmitIconBtn))
			};
		}

		// Token: 0x06038D8A RID: 232842 RVA: 0x00E66550 File Offset: 0x00E64750
		protected override UniTask OnBeforeStartAsync()
		{
			DarkCoastDeliveryMainView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DarkCoastDeliveryMainView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038D8B RID: 232843 RVA: 0x00E66594 File Offset: 0x00E64794
		private void InitLineItemList()
		{
			this.GrayLineItemList = new List<UUIItem>();
			this.LightLineItemList = new List<UUIItem>();
			for (int i = 1; i < 13; i++)
			{
				if (i % 2 != 0)
				{
					this.GrayLineItemList.Add(base.GetItem(i));
				}
				else
				{
					this.LightLineItemList.Add(base.GetItem(i));
				}
			}
		}

		// Token: 0x06038D8C RID: 232844 RVA: 0x00E665F0 File Offset: 0x00E647F0
		private UniTask InitLevelItemList()
		{
			DarkCoastDeliveryMainView.<InitLevelItemList>d__19 <InitLevelItemList>d__;
			<InitLevelItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLevelItemList>d__.<>4__this = this;
			<InitLevelItemList>d__.<>1__state = -1;
			<InitLevelItemList>d__.<>t__builder.Start<DarkCoastDeliveryMainView.<InitLevelItemList>d__19>(ref <InitLevelItemList>d__);
			return <InitLevelItemList>d__.<>t__builder.Task;
		}

		// Token: 0x06038D8D RID: 232845 RVA: 0x00E66634 File Offset: 0x00E64834
		private UniTask InitLevelItem(DarkCoastDeliveryLevelItem levelItem, UUIItem item)
		{
			DarkCoastDeliveryMainView.<InitLevelItem>d__20 <InitLevelItem>d__;
			<InitLevelItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLevelItem>d__.levelItem = levelItem;
			<InitLevelItem>d__.item = item;
			<InitLevelItem>d__.<>1__state = -1;
			<InitLevelItem>d__.<>t__builder.Start<DarkCoastDeliveryMainView.<InitLevelItem>d__20>(ref <InitLevelItem>d__);
			return <InitLevelItem>d__.<>t__builder.Task;
		}

		// Token: 0x06038D8E RID: 232846 RVA: 0x00E66680 File Offset: 0x00E64880
		protected override void OnBeforeShow()
		{
			ModelBase<MingSuModel>.Instance.CurrentInteractCreatureDataLongId = ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId;
			this.RefreshUi();
			this.RefreshLineItemList();
			if (this.CurSelectLevelData != null)
			{
				this.TipPanel.RefreshUi(this.CurSelectLevelData);
			}
			this.RefreshLevelUpItemList();
		}

		// Token: 0x06038D8F RID: 232847 RVA: 0x00E666CC File Offset: 0x00E648CC
		private void RefreshUi()
		{
			string curLevelTexturePath = this.Data.GetCurLevelTexturePath();
			base.SetTextureShowUntilLoaded(curLevelTexturePath, base.GetTexture(0), null);
			base.SetTextureShowUntilLoaded(curLevelTexturePath, base.GetTexture(29), null);
			int targetDragonPoolLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelById(this.Data.DragonPoolId);
			int targetDragonPoolMaxLevelById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolMaxLevelById(this.Data.DragonPoolId);
			if (targetDragonPoolLevelById >= targetDragonPoolMaxLevelById)
			{
				int targetDragonPoolLevelNeedCoreById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelNeedCoreById(this.Data.DragonPoolId, targetDragonPoolLevelById - 1);
				base.GetText(20).SetText(targetDragonPoolLevelNeedCoreById.ToString() + "/" + targetDragonPoolLevelNeedCoreById.ToString(), true);
				base.GetItem(27).SetUIActive(false);
				base.GetItem(28).SetUIActive(true);
			}
			else
			{
				int targetDragonPoolCoreCountById = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolCoreCountById(this.Data.DragonPoolId);
				int targetDragonPoolLevelNeedCoreById2 = ModelBase<MingSuModel>.Instance.GetTargetDragonPoolLevelNeedCoreById(this.Data.DragonPoolId, targetDragonPoolLevelById);
				base.GetText(20).SetText(targetDragonPoolCoreCountById.ToString() + "/" + targetDragonPoolLevelNeedCoreById2.ToString(), true);
				base.GetItem(27).SetUIActive(true);
				base.GetItem(28).SetUIActive(false);
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.Data.GetCoreId(), 0);
			UUIText text = base.GetText(21);
			text.SetText(itemCountByConfigId.ToString(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = itemCountByConfigId <= 0 && targetDragonPoolLevelById < targetDragonPoolMaxLevelById;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			bool uiactive = ModelBase<MingSuModel>.Instance.CheckUp(this.Data.DragonPoolId);
			base.GetItem(25).SetUIActive(uiactive);
			bool rewardRedDotState = this.Data.GetRewardRedDotState();
			UUIItem item = base.GetItem(26);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(rewardRedDotState);
		}

		// Token: 0x06038D90 RID: 232848 RVA: 0x00E6689C File Offset: 0x00E64A9C
		private void RefreshLevelUpItemList()
		{
			int dragonPoolLevel = this.Data.GetDragonPoolLevel();
			if (this.PreLevel >= dragonPoolLevel)
			{
				return;
			}
			int level = this.PreLevel + 1;
			int num = dragonPoolLevel - level + 1;
			if (num <= 0)
			{
				return;
			}
			if (num == 1)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					this.RefreshLevelItem(level);
				}, 300f, null, null, true, 1f);
			}
			else
			{
				TimerSystem.Instance.Loop(delegate(float _)
				{
					int level;
					this.RefreshLevelItem(level);
					level = level;
					level++;
				}, 300f, num, 1f, null, null, true);
			}
			this.PreLevel = dragonPoolLevel;
		}

		// Token: 0x06038D91 RID: 232849 RVA: 0x00E66940 File Offset: 0x00E64B40
		private void RefreshLevelItem(int level)
		{
			DarkCoastDeliveryLevelItem selectItemByLevel = this.GetSelectItemByLevel(level);
			if (selectItemByLevel == null)
			{
				return;
			}
			selectItemByLevel.RefreshUi();
			selectItemByLevel.PlaySequence(false);
		}

		// Token: 0x06038D92 RID: 232850 RVA: 0x00E66968 File Offset: 0x00E64B68
		[NullableContext(2)]
		private DarkCoastDeliveryLevelItem GetSelectItemByLevel(int level)
		{
			for (int i = 0; i < this.LevelItemList.Count; i++)
			{
				DarkCoastDeliveryLevelItem darkCoastDeliveryLevelItem = this.LevelItemList[i];
				if (darkCoastDeliveryLevelItem.LevelData.Id == level)
				{
					return darkCoastDeliveryLevelItem;
				}
			}
			return null;
		}

		// Token: 0x06038D93 RID: 232851 RVA: 0x00E669AC File Offset: 0x00E64BAC
		private void RefreshLineItemList()
		{
			int dragonPoolLevel = this.Data.GetDragonPoolLevel();
			for (int i = 0; i < this.LightLineItemList.Count; i++)
			{
				this.LightLineItemList[i].SetUIActive(dragonPoolLevel >= i);
				this.GrayLineItemList[i].SetUIActive(dragonPoolLevel < i);
			}
		}

		// Token: 0x06038D94 RID: 232852 RVA: 0x00E66A08 File Offset: 0x00E64C08
		private void SelectLevelItem(DarkCoastDeliveryLevelData data, DarkCoastDeliveryLevelItem item)
		{
			if (this.CurSelectLevelData == data)
			{
				return;
			}
			if (this.CurSelectLevelItem != null)
			{
				this.CurSelectLevelItem.SetSelect(false);
			}
			this.CurSelectLevelData = data;
			this.CurSelectLevelItem = item;
			this.CurSelectLevelItem.SetSelect(true);
			this.TipPanel.RefreshUi(data);
			this.TipPanel.SetUiActive(true);
			this.UiViewSequence.StopPrevSequence(false, false);
			this.UiViewSequence.PlaySequence("Switch", false, null);
		}

		// Token: 0x06038D95 RID: 232853 RVA: 0x00E66A8C File Offset: 0x00E64C8C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateDragonPoolView, new Action(this.OnRefreshDragonPoolData));
			Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshReward));
		}

		// Token: 0x06038D96 RID: 232854 RVA: 0x00E66AC6 File Offset: 0x00E64CC6
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateDragonPoolView, new Action(this.OnRefreshDragonPoolData));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshReward));
		}

		// Token: 0x06038D97 RID: 232855 RVA: 0x00E66B00 File Offset: 0x00E64D00
		private void OnClickCloseBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06038D98 RID: 232856 RVA: 0x00E66B09 File Offset: 0x00E64D09
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(113);
		}

		// Token: 0x06038D99 RID: 232857 RVA: 0x00E66B17 File Offset: 0x00E64D17
		private void OnClickLevelItem(DarkCoastDeliveryLevelData data, DarkCoastDeliveryLevelItem item)
		{
			this.SelectLevelItem(data, item);
		}

		// Token: 0x06038D9A RID: 232858 RVA: 0x00E66B24 File Offset: 0x00E64D24
		private void OnClickRewardBtn()
		{
			IActivityRewardViewData activityRewardViewData = this.Data.GetActivityRewardViewData();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, activityRewardViewData, delegate(bool success, int viewId)
			{
				if (!success)
				{
					return;
				}
				base.AddChildViewById(viewId);
			});
		}

		// Token: 0x06038D9B RID: 232859 RVA: 0x00E66B5C File Offset: 0x00E64D5C
		private void OnClickSubmitBtn()
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.Data.GetCoreId(), 0) <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DarkCoastDelivery_Item_0", Array.Empty<object>());
				return;
			}
			this.PreLevel = this.Data.GetDragonPoolLevel();
			MingSuController.SendHandInMingSuRequest(this.Data.DragonPoolId);
		}

		// Token: 0x06038D9C RID: 232860 RVA: 0x00E66BB8 File Offset: 0x00E64DB8
		private void OnClickSubmitIconBtn()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.Data.GetCoreId(), true, null);
		}

		// Token: 0x06038D9D RID: 232861 RVA: 0x00E66BD4 File Offset: 0x00E64DD4
		private void OnRefreshDragonPoolData()
		{
			int curLevel = this.Data.GetDragonPoolLevel();
			if (curLevel > this.PreLevel)
			{
				DarkCoastDeliveryLevelUpViewData param = new DarkCoastDeliveryLevelUpViewData(this.PreLevel, curLevel);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DarkCoastDeliveryLevelUpView, param, delegate(bool _, int __)
				{
					DarkCoastDeliveryLevelItem selectItemByLevel = this.GetSelectItemByLevel(curLevel);
					if (selectItemByLevel == null)
					{
						return;
					}
					this.SelectLevelItem(selectItemByLevel.LevelData, selectItemByLevel);
				});
				return;
			}
			this.UiViewSequence.PlaySequence("Sweep", false, null);
			this.RefreshUi();
		}

		// Token: 0x06038D9E RID: 232862 RVA: 0x00E66C5C File Offset: 0x00E64E5C
		private void OnRefreshReward(IActivityRewardViewData data)
		{
			this.RefreshUi();
		}

		// Token: 0x040205FB RID: 132603
		private const int LINE_START_INDEX = 1;

		// Token: 0x040205FC RID: 132604
		private const int LINE_COUNT = 6;

		// Token: 0x040205FD RID: 132605
		private const int ITEM_START_INDEX = 13;

		// Token: 0x040205FE RID: 132606
		private const int ITEM_COUNT = 5;

		// Token: 0x040205FF RID: 132607
		private const int LEVEL_ITEM_SHOW_DELAY = 300;

		// Token: 0x04020600 RID: 132608
		[Nullable(2)]
		private DarkCoastDeliveryData Data;

		// Token: 0x04020601 RID: 132609
		[Nullable(2)]
		private DarkCoastDeliveryLevelData CurSelectLevelData;

		// Token: 0x04020602 RID: 132610
		[Nullable(2)]
		private DarkCoastDeliveryLevelItem CurSelectLevelItem;

		// Token: 0x04020603 RID: 132611
		private List<UUIItem> GrayLineItemList = new List<UUIItem>();

		// Token: 0x04020604 RID: 132612
		private List<UUIItem> LightLineItemList = new List<UUIItem>();

		// Token: 0x04020605 RID: 132613
		private readonly List<DarkCoastDeliveryLevelItem> LevelItemList = new List<DarkCoastDeliveryLevelItem>();

		// Token: 0x04020606 RID: 132614
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04020607 RID: 132615
		[Nullable(2)]
		private DarkCoastDeliveryTipPanel TipPanel;

		// Token: 0x04020608 RID: 132616
		private int PreLevel;

		// Token: 0x0200B7EC RID: 47084
		[NullableContext(0)]
		private static class EComponent
		{
			// Token: 0x04038E21 RID: 232993
			public const int LevelTexture = 0;

			// Token: 0x04038E22 RID: 232994
			public const int GrayLine1 = 1;

			// Token: 0x04038E23 RID: 232995
			public const int LightLine1 = 2;

			// Token: 0x04038E24 RID: 232996
			public const int GrayLine2 = 3;

			// Token: 0x04038E25 RID: 232997
			public const int LightLine2 = 4;

			// Token: 0x04038E26 RID: 232998
			public const int GrayLine3 = 5;

			// Token: 0x04038E27 RID: 232999
			public const int LightLine3 = 6;

			// Token: 0x04038E28 RID: 233000
			public const int GrayLine4 = 7;

			// Token: 0x04038E29 RID: 233001
			public const int LightLine4 = 8;

			// Token: 0x04038E2A RID: 233002
			public const int GrayLine5 = 9;

			// Token: 0x04038E2B RID: 233003
			public const int LightLine5 = 10;

			// Token: 0x04038E2C RID: 233004
			public const int GrayLine6 = 11;

			// Token: 0x04038E2D RID: 233005
			public const int LightLine6 = 12;

			// Token: 0x04038E2E RID: 233006
			public const int DarkCoastDeliveryItem1 = 13;

			// Token: 0x04038E2F RID: 233007
			public const int DarkCoastDeliveryItem2 = 14;

			// Token: 0x04038E30 RID: 233008
			public const int DarkCoastDeliveryItem3 = 15;

			// Token: 0x04038E31 RID: 233009
			public const int DarkCoastDeliveryItem4 = 16;

			// Token: 0x04038E32 RID: 233010
			public const int DarkCoastDeliveryItem5 = 17;

			// Token: 0x04038E33 RID: 233011
			public const int TipPanelItem = 18;

			// Token: 0x04038E34 RID: 233012
			public const int RewardBtn = 19;

			// Token: 0x04038E35 RID: 233013
			public const int RewardProgressText = 20;

			// Token: 0x04038E36 RID: 233014
			public const int OwnCountText = 21;

			// Token: 0x04038E37 RID: 233015
			public const int SubmitBtn = 22;

			// Token: 0x04038E38 RID: 233016
			public const int CaptionItem = 23;

			// Token: 0x04038E39 RID: 233017
			public const int SubmitIconBtn = 24;

			// Token: 0x04038E3A RID: 233018
			public const int LevelUpRedDot = 25;

			// Token: 0x04038E3B RID: 233019
			public const int RewardRedDot = 26;

			// Token: 0x04038E3C RID: 233020
			public const int SubmitRootItem = 27;

			// Token: 0x04038E3D RID: 233021
			public const int SubmitDoneItem = 28;

			// Token: 0x04038E3E RID: 233022
			public const int SubLevelTexture = 29;
		}
	}
}
