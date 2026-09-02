using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006411 RID: 25617
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeResultView : UiViewBase
	{
		// Token: 0x06040503 RID: 263427 RVA: 0x0107BE97 File Offset: 0x0107A097
		public RoverlikeResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040504 RID: 263428 RVA: 0x0107BEA0 File Offset: 0x0107A0A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 24;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIInturnAnimController));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickExit));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickDetailClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040505 RID: 263429 RVA: 0x0107C250 File Offset: 0x0107A450
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeResultView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeResultView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040506 RID: 263430 RVA: 0x0107C294 File Offset: 0x0107A494
		protected override void OnStart()
		{
			RoverRogueResultInfo roverRogueResultInfo = this.OpenParam as RoverRogueResultInfo;
			if (roverRogueResultInfo == null)
			{
				return;
			}
			RoverlikeSettleBlessingPanel blessingPanel = this.BlessingPanel;
			if (blessingPanel != null)
			{
				blessingPanel.BindOnItemClick(new Action<int>(this.OpenBlessingDetail));
			}
			RoverlikeSettleReinforcementPanel reinforcementPanel = this.ReinforcementPanel;
			if (reinforcementPanel != null)
			{
				reinforcementPanel.BindOnItemClick(new Action<int, int>(this.OpenReinforcementDetail));
			}
			RoverlikeSettleItemPanel itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.BindOnItemClick(new Action<int, int>(this.OpenItemDetail));
			}
			this.RefreshTitle(roverRogueResultInfo);
			this.RefreshRole(roverRogueResultInfo);
			this.RefreshSummary(roverRogueResultInfo);
			this.RefreshDataGrid(roverRogueResultInfo);
			this.RefreshGainPanels(roverRogueResultInfo);
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(22);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.AddSequenceFinishEvent("TipClose", new Action<string>(this.OnTipCloseEnd), false);
		}

		// Token: 0x06040507 RID: 263431 RVA: 0x0107C384 File Offset: 0x0107A584
		private void RefreshTitle(RoverRogueResultInfo resultInfo)
		{
			bool flag = resultInfo.SettleType != RoverRogueInstState.RoverRogueInstFinished;
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), flag ? "RoverRogue_EndGame_Defeat" : "RoverRogue_EndGame_Victory", Array.Empty<object>());
			this.UiViewSequence.StartSequenceName = (flag ? "Fail" : "Success");
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverRogueActivity? roverRogueActivity;
			if (instance == null)
			{
				roverRogueActivity = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverRogueActivity = ((currentActivityData != null) ? currentActivityData.GetParamConfig() : null);
			}
			RoverRogueActivity? roverRogueActivity2 = roverRogueActivity;
			if (roverRogueActivity2 == null)
			{
				return;
			}
			string text = null;
			int settleLevelIconLength = roverRogueActivity2.Value.SettleLevelIconLength;
			for (int i = 0; i < settleLevelIconLength; i++)
			{
				DicIntString? dicIntString = roverRogueActivity2.Value.SettleLevelIcon(i);
				if (dicIntString != null && dicIntString.Value.Key == (int)resultInfo.Grade)
				{
					text = dicIntString.Value.Value;
					break;
				}
			}
			if (StringUtils.IsEmpty(text))
			{
				return;
			}
			base.SetTextureShowUntilLoaded(text, base.GetTexture(7), null);
		}

		// Token: 0x06040508 RID: 263432 RVA: 0x0107C4C8 File Offset: 0x0107A6C8
		private void RefreshRole(RoverRogueResultInfo resultInfo)
		{
			RoverRogueRoleType? roleTypeConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoleTypeConfig(resultInfo.RoleType);
			int? num = (roleTypeConfig != null) ? new int?(roleTypeConfig.GetValueOrDefault().FemaleRoleId) : null;
			int roverId = resultInfo.RoverId;
			bool flag = num.GetValueOrDefault() == roverId & num != null;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			if (roleTypeConfig != null)
			{
				base.SetTextureByPath(roleTypeConfig.Value.ResultElementIcon, base.GetTexture(4), null, null);
			}
		}

		// Token: 0x06040509 RID: 263433 RVA: 0x0107C588 File Offset: 0x0107A788
		private void RefreshSummary(RoverRogueResultInfo resultInfo)
		{
			RoverRogueIns? insConfig = ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(resultInfo.InstId);
			if (insConfig != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), insConfig.Value.LevelName, Array.Empty<object>());
			}
			long num = Singleton<MathUtils>.Instance.LongToNumber(resultInfo.TotalCostTime) / 1000L;
			base.GetText(12).SetText(Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat6((double)num), true);
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverRogueActivity? roverRogueActivity;
			if (instance == null)
			{
				roverRogueActivity = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverRogueActivity = ((currentActivityData != null) ? currentActivityData.GetParamConfig() : null);
			}
			RoverRogueActivity? roverRogueActivity2 = roverRogueActivity;
			this.RefreshReward(this.RewardItemUp, (roverRogueActivity2 != null) ? new int?(roverRogueActivity2.GetValueOrDefault().TokenItemId) : null, resultInfo.Rewards);
			this.RefreshReward(this.RewardItemDown, (roverRogueActivity2 != null) ? new int?(roverRogueActivity2.GetValueOrDefault().TalentPointItemId) : null, resultInfo.Rewards);
		}

		// Token: 0x0604050A RID: 263434 RVA: 0x0107C6B0 File Offset: 0x0107A8B0
		private void RefreshReward([Nullable(2)] RoverlikeRewardItem rewardItem, int? itemId, IList<RoverRogueSettleReward> rewardList)
		{
			bool flag = (itemId ?? 0) == 0;
			if (flag)
			{
				if (rewardItem != null)
				{
					rewardItem.SetUiActive(false);
				}
				return;
			}
			int num = 0;
			foreach (RoverRogueSettleReward roverRogueSettleReward in rewardList)
			{
				if (roverRogueSettleReward.ItemId == itemId.Value)
				{
					num = roverRogueSettleReward.Num;
					break;
				}
			}
			if (num == 0)
			{
				if (rewardItem != null)
				{
					rewardItem.SetUiActive(false);
				}
				return;
			}
			RoverRogueCurrency? currencyConfig = ConfigBase<RoverlikeConfig>.Instance.GetCurrencyConfig(itemId.Value);
			RoverlikeSettleRewardItemData data = new RoverlikeSettleRewardItemData
			{
				IconPath = (((currencyConfig != null) ? currencyConfig.GetValueOrDefault().IconSmall : null) ?? ""),
				NameTextId = (((currencyConfig != null) ? currencyConfig.GetValueOrDefault().Title : null) ?? ""),
				Num = num
			};
			if (rewardItem != null)
			{
				rewardItem.Refresh(data);
			}
			if (rewardItem != null)
			{
				rewardItem.SetUiActive(true);
			}
		}

		// Token: 0x0604050B RID: 263435 RVA: 0x0107C7D0 File Offset: 0x0107A9D0
		private void RefreshDataGrid(RoverRogueResultInfo resultInfo)
		{
			List<IRoverlikeSettleDataItemData> list = new List<IRoverlikeSettleDataItemData>();
			RoverlikeSettleDataItemData item = new RoverlikeSettleDataItemData
			{
				NameTextId = "RoverRogue_EndGame_RoomClear",
				ValueText = resultInfo.RoomPassedCount.ToString()
			};
			list.Add(item);
			RoverlikeSettleDataItemData item2 = new RoverlikeSettleDataItemData
			{
				NameTextId = "RoverRogue_EndGame_RoomElite",
				ValueText = resultInfo.EliteRoom.ToString()
			};
			list.Add(item2);
			RoverlikeSettleDataItemData item3 = new RoverlikeSettleDataItemData
			{
				NameTextId = "RoverRogue_EndGame_RoomBoss",
				ValueText = resultInfo.BossRoom.ToString()
			};
			list.Add(item3);
			RoverlikeSettleDataItemData item4 = new RoverlikeSettleDataItemData
			{
				NameTextId = "RoverRogue_EndGame_GoldGain",
				ValueText = resultInfo.TotalGold.ToString()
			};
			list.Add(item4);
			this.DataLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0604050C RID: 263436 RVA: 0x0107C8A8 File Offset: 0x0107AAA8
		private void RefreshGainPanels(RoverRogueResultInfo resultInfo)
		{
			RoverlikeSettleBlessingPanel blessingPanel = this.BlessingPanel;
			if (blessingPanel != null)
			{
				blessingPanel.Refresh(RoverlikeInstanceData.SortGainConfigIds(resultInfo.GainBlessConfId.ToList<int>(), RoverRogueGainDataType.RoverRogueGainBless));
			}
			RoverlikeSettleReinforcementPanel reinforcementPanel = this.ReinforcementPanel;
			if (reinforcementPanel != null)
			{
				reinforcementPanel.Refresh(RoverlikeInstanceData.SortGainConfigIds(resultInfo.GainRoleConfId.ToList<int>(), RoverRogueGainDataType.RoverRogueGainRoleEnhance));
			}
			RoverlikeSettleItemPanel itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.Refresh(RoverlikeInstanceData.SortGainConfigIds(resultInfo.GainItemConfId.ToList<int>(), RoverRogueGainDataType.RoverRogueGainItem));
			}
			bool flag = resultInfo.GainLootInfo.Count > 0;
			RoverlikeLootItem lootItem = this.LootItem;
			if (lootItem != null)
			{
				lootItem.SetUiActive(flag);
			}
			if (flag)
			{
				RoverlikeLootGainEntry data = new RoverlikeLootGainEntry(resultInfo.GainLootInfo[0]);
				RoverlikeLootItem lootItem2 = this.LootItem;
				if (lootItem2 == null)
				{
					return;
				}
				lootItem2.Refresh(data);
			}
		}

		// Token: 0x0604050D RID: 263437 RVA: 0x0107C962 File Offset: 0x0107AB62
		private RoverlikeDataItem CreateDataItem()
		{
			return new RoverlikeDataItem();
		}

		// Token: 0x0604050E RID: 263438 RVA: 0x0107C969 File Offset: 0x0107AB69
		private void OnClickExit()
		{
			if (!ControllerBase<RoverlikeController>.Instance.CheckInRoverlike())
			{
				base.CloseMe(null);
			}
			ControllerBase<RoverlikeController>.Instance.RoverRogueExitRequest();
		}

		// Token: 0x0604050F RID: 263439 RVA: 0x0107C988 File Offset: 0x0107AB88
		private void OnTipCloseEnd(string sequenceName)
		{
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(22);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06040510 RID: 263440 RVA: 0x0107C9CC File Offset: 0x0107ABCC
		private void OpenBlessingDetail(int blessId)
		{
			this.SelectPanelItem(this.BlessingPanel, blessId);
			RoverlikeBlessingItemData data = new RoverlikeBlessingItemData
			{
				BlessId = blessId,
				AllowToggleInteract = new bool?(false)
			};
			RoverlikeBlessingCardItem blessingCard = this.BlessingCard;
			if (blessingCard != null)
			{
				blessingCard.Refresh(data, false, 0);
			}
			this.ShowDetail(19);
		}

		// Token: 0x06040511 RID: 263441 RVA: 0x0107CA1C File Offset: 0x0107AC1C
		private void OpenReinforcementDetail(int configId, int key)
		{
			this.SelectPanelItem(this.ReinforcementPanel, key);
			RoverlikeReinforcementItemData data = new RoverlikeReinforcementItemData
			{
				ConfigId = configId,
				AllowToggleInteract = new bool?(false)
			};
			RoverlikeReinforcementCardItem reinforcementCard = this.ReinforcementCard;
			if (reinforcementCard != null)
			{
				reinforcementCard.Refresh(data, false, 0);
			}
			this.ShowDetail(20);
		}

		// Token: 0x06040512 RID: 263442 RVA: 0x0107CA6C File Offset: 0x0107AC6C
		private void OpenItemDetail(int configId, int key)
		{
			this.SelectPanelItem(this.ItemPanel, key);
			RoverlikePropItemData data = new RoverlikePropItemData
			{
				ConfigId = configId,
				IsInGame = false
			};
			RoverlikePropCardItem itemCard = this.ItemCard;
			if (itemCard != null)
			{
				itemCard.Refresh(data, false, 0);
			}
			this.ShowDetail(21);
		}

		// Token: 0x06040513 RID: 263443 RVA: 0x0107CAB8 File Offset: 0x0107ACB8
		private void ShowDetail(int activeCard)
		{
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIButtonComponent button = base.GetButton(22);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(19);
			if (item2 != null)
			{
				item2.SetUIActive(activeCard == 19);
			}
			UUIItem item3 = base.GetItem(20);
			if (item3 != null)
			{
				item3.SetUIActive(activeCard == 20);
			}
			UUIItem item4 = base.GetItem(21);
			if (item4 != null)
			{
				item4.SetUIActive(activeCard == 21);
			}
			if (!this.IsDetailShow)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlayOrReplaySequenceByName("TipStart", true, null);
				}
			}
			this.IsDetailShow = true;
			UUIInturnAnimController uiInturnAnimController = base.GetUiInturnAnimController(23);
			if (uiInturnAnimController == null)
			{
				return;
			}
			uiInturnAnimController.Play("", -1, false);
		}

		// Token: 0x06040514 RID: 263444 RVA: 0x0107CB8A File Offset: 0x0107AD8A
		[NullableContext(2)]
		private void SelectPanelItem(IRoverlikeSettleSelectablePanel targetPanel, int key)
		{
			RoverlikeSettleBlessingPanel blessingPanel = this.BlessingPanel;
			if (blessingPanel != null)
			{
				blessingPanel.ClearSelect();
			}
			RoverlikeSettleReinforcementPanel reinforcementPanel = this.ReinforcementPanel;
			if (reinforcementPanel != null)
			{
				reinforcementPanel.ClearSelect();
			}
			RoverlikeSettleItemPanel itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.ClearSelect();
			}
			if (targetPanel != null)
			{
				targetPanel.SelectByKey(key);
			}
		}

		// Token: 0x06040515 RID: 263445 RVA: 0x0107CBCC File Offset: 0x0107ADCC
		private void OnClickDetailClose()
		{
			RoverlikeSettleBlessingPanel blessingPanel = this.BlessingPanel;
			if (blessingPanel != null)
			{
				blessingPanel.ClearSelect();
			}
			RoverlikeSettleReinforcementPanel reinforcementPanel = this.ReinforcementPanel;
			if (reinforcementPanel != null)
			{
				reinforcementPanel.ClearSelect();
			}
			RoverlikeSettleItemPanel itemPanel = this.ItemPanel;
			if (itemPanel != null)
			{
				itemPanel.ClearSelect();
			}
			this.IsDetailShow = false;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("TipClose", true, null);
		}

		// Token: 0x040240B4 RID: 147636
		[Nullable(2)]
		private RoverlikeRewardItem RewardItemUp;

		// Token: 0x040240B5 RID: 147637
		[Nullable(2)]
		private RoverlikeRewardItem RewardItemDown;

		// Token: 0x040240B6 RID: 147638
		[Nullable(2)]
		private RoverlikeLootItem LootItem;

		// Token: 0x040240B7 RID: 147639
		[Nullable(2)]
		private RoverlikeSettleBlessingPanel BlessingPanel;

		// Token: 0x040240B8 RID: 147640
		[Nullable(2)]
		private RoverlikeSettleReinforcementPanel ReinforcementPanel;

		// Token: 0x040240B9 RID: 147641
		[Nullable(2)]
		private RoverlikeSettleItemPanel ItemPanel;

		// Token: 0x040240BA RID: 147642
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeDataItem, IRoverlikeSettleDataItemData> DataLayout;

		// Token: 0x040240BB RID: 147643
		[Nullable(2)]
		private RoverlikeBlessingCardItem BlessingCard;

		// Token: 0x040240BC RID: 147644
		[Nullable(2)]
		private RoverlikeReinforcementCardItem ReinforcementCard;

		// Token: 0x040240BD RID: 147645
		[Nullable(2)]
		private RoverlikePropCardItem ItemCard;

		// Token: 0x040240BE RID: 147646
		private bool IsDetailShow;

		// Token: 0x0200C47D RID: 50301
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C7A9 RID: 247721
			public const int BtnClose = 0;

			// Token: 0x0403C7AA RID: 247722
			public const int PanelMale = 1;

			// Token: 0x0403C7AB RID: 247723
			public const int PanelFemale = 2;

			// Token: 0x0403C7AC RID: 247724
			public const int ItemLoot = 3;

			// Token: 0x0403C7AD RID: 247725
			public const int TexIconElement = 4;

			// Token: 0x0403C7AE RID: 247726
			public const int RewardItem1 = 5;

			// Token: 0x0403C7AF RID: 247727
			public const int RewardItem2 = 6;

			// Token: 0x0403C7B0 RID: 247728
			public const int TexRankIcon = 7;

			// Token: 0x0403C7B1 RID: 247729
			public const int TxtResultTitle = 8;

			// Token: 0x0403C7B2 RID: 247730
			public const int ItemSuccessBg = 9;

			// Token: 0x0403C7B3 RID: 247731
			public const int ItemFailBg = 10;

			// Token: 0x0403C7B4 RID: 247732
			public const int TxtTitleDifficulty = 11;

			// Token: 0x0403C7B5 RID: 247733
			public const int TxtTime = 12;

			// Token: 0x0403C7B6 RID: 247734
			public const int InfoLayout = 13;

			// Token: 0x0403C7B7 RID: 247735
			public const int InfoItem = 14;

			// Token: 0x0403C7B8 RID: 247736
			public const int PanelBlessing = 15;

			// Token: 0x0403C7B9 RID: 247737
			public const int PanelReinforcement = 16;

			// Token: 0x0403C7BA RID: 247738
			public const int PanelItem = 17;

			// Token: 0x0403C7BB RID: 247739
			public const int PanelDetailInfo = 18;

			// Token: 0x0403C7BC RID: 247740
			public const int CardBlessing = 19;

			// Token: 0x0403C7BD RID: 247741
			public const int CardReinforcement = 20;

			// Token: 0x0403C7BE RID: 247742
			public const int CardItem = 21;

			// Token: 0x0403C7BF RID: 247743
			public const int BtnDetailClose = 22;

			// Token: 0x0403C7C0 RID: 247744
			public const int DetailCardPanel = 23;
		}

		// Token: 0x0200C47E RID: 50302
		[Nullable(0)]
		private class EViewSeqName
		{
			// Token: 0x0403C7C1 RID: 247745
			public const string TipStart = "TipStart";

			// Token: 0x0403C7C2 RID: 247746
			public const string TipClose = "TipClose";
		}
	}
}
