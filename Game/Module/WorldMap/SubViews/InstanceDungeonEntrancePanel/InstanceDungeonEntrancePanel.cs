using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel
{
	// Token: 0x02004BAA RID: 19370
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x170086EF RID: 34543
		// (get) Token: 0x0603290C RID: 207116 RVA: 0x00CA89A8 File Offset: 0x00CA6BA8
		private InstanceDungeonEntrance? EntranceConfig
		{
			get
			{
				if (this.EntranceId == 0)
				{
					return null;
				}
				InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetConfig(this.EntranceId);
			}
		}

		// Token: 0x0603290D RID: 207117 RVA: 0x00CA89E5 File Offset: 0x00CA6BE5
		public override string GetResourceId()
		{
			return "UiView_InstanceEntranceTip_Prefab";
		}

		// Token: 0x0603290E RID: 207118 RVA: 0x00CA89EC File Offset: 0x00CA6BEC
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			this.InstanceCostTipView = new GenericLayoutAdd<InstanceDungeonCostTip>(base.GetVerticalLayout(5), new TLayoutRefresh<InstanceDungeonCostTip>(this.OnInstanceRefresh));
			this.InstanceScrollView = new GenericLayout<InstanceTipGrid, IInstanceTipGridData>(base.GetVerticalLayout(7), new Func<InstanceTipGrid>(this.InitItem), null, false, true);
			base.OnStart();
		}

		// Token: 0x0603290F RID: 207119 RVA: 0x00CA8A5E File Offset: 0x00CA6C5E
		protected override void OnBeforeDestroy()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.ClearChildren();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032910 RID: 207120 RVA: 0x00CA8A78 File Offset: 0x00CA6C78
		private ILayoutItem<InstanceDungeonCostTip> OnInstanceRefresh(object data, UUIItem uiItem, int index, int originalItemIndex)
		{
			InstanceDungeonCostTip instanceDungeonCostTip = new InstanceDungeonCostTip();
			instanceDungeonCostTip.SetRootActor(uiItem.GetOwner(), true);
			return new LayoutItem<InstanceDungeonCostTip>
			{
				Key = data,
				Value = instanceDungeonCostTip
			};
		}

		// Token: 0x06032911 RID: 207121 RVA: 0x00CA8AAB File Offset: 0x00CA6CAB
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(32);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06032912 RID: 207122 RVA: 0x00CA8AC8 File Offset: 0x00CA6CC8
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.SelectedMarkItem = teleportMarkItem;
					this.LayoutContext.MarkItem = teleportMarkItem;
					int num = (teleportMarkItem != null) ? teleportMarkItem.MarkConfig.Value.RelativeId : 0;
					int markConfigId = teleportMarkItem.MarkConfigId;
					int entranceId;
					if (num == 0)
					{
						InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
						entranceId = ((instance != null) ? instance.GetEntranceIdByMarkId(markConfigId) : 0);
					}
					else
					{
						entranceId = num;
					}
					this.EntranceId = entranceId;
					if (this.EntranceId == 0)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.InstanceDungeon;
						ELogAuthor author = ELogAuthor.LYX;
						string message = "副本入口弹窗打开错误，副本入口表中找不到对应的地图标记Id！";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markConfigId);
						instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return;
					}
					this.InitView();
					ControllerBase<InstanceDungeonEntranceController>.Instance.InstEntranceDetailRequest(this.EntranceId).ContinueWith(delegate(bool _)
					{
						this.UpdateInstanceList();
						this.UpdateCost();
					});
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					InstanceDungeonEntrance? instanceDungeonEntrance;
					int num2 = (this.EntranceConfig != null) ? instanceDungeonEntrance.GetValueOrDefault().UnLockCondition : 0;
					if (num2 != 0 && !ModelBase<FunctionModel>.Instance.IsOpen(num2))
					{
						FunctionConfig instance3 = ConfigBase<FunctionConfig>.Instance;
						FunctionCondition? functionCondition = (instance3 != null) ? instance3.GetFunctionCondition(num2) : null;
						ConditionConfig instance4 = ConfigBase<ConditionConfig>.Instance;
						ConditionGroup? conditionGroup = (instance4 != null) ? instance4.GetConditionGroupConfig((functionCondition != null) ? functionCondition.GetValueOrDefault().OpenConditionId : 0) : null;
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), ((conditionGroup != null) ? conditionGroup.GetValueOrDefault().HintText : null) ?? "", Array.Empty<object>());
					}
				}
			}
		}

		// Token: 0x06032913 RID: 207123 RVA: 0x00CA8C80 File Offset: 0x00CA6E80
		public List<int> GetMaxUnlockInstanceList()
		{
			List<int> list = new List<int>();
			if (this.InstanceIdList.Count == 0)
			{
				return list;
			}
			int num = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.InstanceIdList[0], ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
			foreach (int num2 in this.InstanceIdList)
			{
				InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
				if (instance != null && instance.CheckInstanceUnlock(num2))
				{
					InstanceDungeonConfig instance2 = ConfigBase<InstanceDungeonConfig>.Instance;
					int num3 = (instance2 != null) ? instance2.GetRecommendLevel(num2, ModelBase<WorldLevelModel>.Instance.CurWorldLevel) : 0;
					if (num3 >= num)
					{
						if (num3 > num)
						{
							list.Clear();
							num = num3;
						}
						list.Add(num2);
					}
				}
			}
			if (list.Count == 0)
			{
				foreach (int num4 in this.InstanceIdList)
				{
					InstanceDungeonConfig instance3 = ConfigBase<InstanceDungeonConfig>.Instance;
					int num5 = (instance3 != null) ? instance3.GetRecommendLevel(num4, ModelBase<WorldLevelModel>.Instance.CurWorldLevel) : 0;
					if (num5 <= num)
					{
						if (num5 < num)
						{
							list.Clear();
							num = num5;
						}
						list.Add(num4);
					}
				}
			}
			list.Sort(delegate(int a, int b)
			{
				ExchangeRewardModel instance4 = ModelBase<ExchangeRewardModel>.Instance;
				int num6 = (instance4 != null && instance4.GetInstanceDungeonIfCanExchange(a)) ? 1 : 0;
				ExchangeRewardModel instance5 = ModelBase<ExchangeRewardModel>.Instance;
				bool flag = instance5 != null && instance5.GetInstanceDungeonIfCanExchange(b);
				return ((num6 == 0) - !flag) ? 1 : 0;
			});
			return list;
		}

		// Token: 0x06032914 RID: 207124 RVA: 0x00CA8DF4 File Offset: 0x00CA6FF4
		private void InitView()
		{
			InstanceDungeonEntrance? entranceConfig = this.EntranceConfig;
			if (entranceConfig == null)
			{
				return;
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.ShowTextNew(entranceConfig.Value.Description);
			}
			WorldMapSecondaryUiLayoutHelper.UpdateIcon(this.LayoutContext);
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.ShowTextNew(entranceConfig.Value.Name);
			}
			WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				TeleportMarkItem selectedMarkItem = this.SelectedMarkItem;
				item.SetUIActive(selectedMarkItem != null && !selectedMarkItem.IsFogUnlock);
			}
			UUIText text3 = base.GetText(10);
			if (text3 != null)
			{
				text3.ShowTextNew("Instance_Dungeon_Rcommand_Text");
			}
			bool flag = base.UpdateQuickGoto();
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext == null)
			{
				return;
			}
			layoutContext.SetConfirmBtnActive(!flag);
		}

		// Token: 0x06032915 RID: 207125 RVA: 0x00CA8EC8 File Offset: 0x00CA70C8
		private void UpdateInstanceList()
		{
			this.InstanceIdList.Clear();
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			Dictionary<int, int> dictionary = (instance != null) ? instance.GetSortedByTitleEntranceInstanceIdList(this.EntranceId) : null;
			if (dictionary == null)
			{
				return;
			}
			List<KeyValuePair<int, int>> list = dictionary.ToList<KeyValuePair<int, int>>();
			list.Sort((KeyValuePair<int, int> a, KeyValuePair<int, int> b) => a.Value - b.Value);
			foreach (KeyValuePair<int, int> keyValuePair in list)
			{
				this.InstanceIdList.Add(keyValuePair.Key);
			}
			this.InstanceIdList = this.GetMaxUnlockInstanceList();
			if (this.InstanceIdList.Count == 0)
			{
				return;
			}
			InstanceDungeonConfig instance2 = ConfigBase<InstanceDungeonConfig>.Instance;
			InstanceDungeon? instanceDungeon = (instance2 != null) ? instance2.GetConfig(this.InstanceIdList[0]) : null;
			if (instanceDungeon == null)
			{
				return;
			}
			List<int> list2 = new List<int>();
			list2.AddRange(instanceDungeon.Value.GetCustomTypesBytes());
			ActivityDoubleRewardController instance3 = ControllerBase<ActivityDoubleRewardController>.Instance;
			ActivityDoubleRewardData activityDoubleRewardData = (instance3 != null) ? instance3.GetDungeonUpActivity(list2, true) : null;
			UUIItem item = base.GetItem(19);
			if (item != null)
			{
				item.SetUIActive(activityDoubleRewardData != null);
			}
			if (activityDoubleRewardData != null)
			{
				ValueTuple<string, int, int> numTxtAndParam = activityDoubleRewardData.GetNumTxtAndParam();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), numTxtAndParam.Item1, new <>z__ReadOnlyArray<object>(new object[]
				{
					numTxtAndParam.Item2,
					numTxtAndParam.Item3
				}));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(42), "Double_reward_tips_02", Array.Empty<object>());
			}
			ValueTuple<bool, int, int, string, string> doubleRestAndMaxTimes = MapHelper.GetDoubleRestAndMaxTimes(this.SelectedMarkItem);
			bool item2 = doubleRestAndMaxTimes.Item1;
			int item3 = doubleRestAndMaxTimes.Item2;
			int item4 = doubleRestAndMaxTimes.Item3;
			string item5 = doubleRestAndMaxTimes.Item4;
			string item6 = doubleRestAndMaxTimes.Item5;
			if (item2)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), item5, new <>z__ReadOnlyArray<object>(new object[]
				{
					item3.ToString(),
					item4.ToString()
				}));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(42), item6, Array.Empty<object>());
				UUIText text = base.GetText(42);
				if (text != null)
				{
					text.SetUIActive(item2);
				}
			}
			UUIItem item7 = base.GetItem(19);
			if (item7 != null)
			{
				item7.SetUIActive(item2 || activityDoubleRewardData != null);
			}
			List<IInstanceTipGridData> list3 = new List<IInstanceTipGridData>();
			foreach (int instanceId in this.InstanceIdList)
			{
				list3.Add(new InstanceTipGridData
				{
					InstanceId = instanceId,
					IsDouble = item2
				});
			}
			GenericLayout<InstanceTipGrid, IInstanceTipGridData> instanceScrollView = this.InstanceScrollView;
			if (instanceScrollView != null)
			{
				instanceScrollView.RefreshByData(list3, null, false);
			}
			int rewardId = instanceDungeon.Value.RewardId;
			ExchangeRewardConfig instance4 = ConfigBase<ExchangeRewardConfig>.Instance;
			ExchangeReward? exchangeReward;
			int? num = (instance4 != null) ? ((instance4.GetExchangeRewardConfig(new int?(rewardId)) != null) ? new int?(exchangeReward.GetValueOrDefault().SharedId) : null) : null;
			if (num != null && num.Value != 0)
			{
				GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
				if (instanceCostTipView != null)
				{
					instanceCostTipView.AddItemToLayout(new object[]
					{
						"countLimit"
					}, 0);
				}
				GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
				InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("countLimit", 0) : null) as InstanceDungeonCostTip;
				if (instanceDungeonCostTip != null)
				{
					instanceDungeonCostTip.SetIconVisible(false);
					instanceDungeonCostTip.SetStarVisible(false);
					string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_CanReceivedCount_Text", null) ?? "", new string[]
					{
						""
					});
					instanceDungeonCostTip.SetLeftText(leftText);
					ExchangeRewardConfig instance5 = ConfigBase<ExchangeRewardConfig>.Instance;
					ExchangeShared? exchangeShared = (instance5 != null) ? instance5.GetExchangeShareConfig(new int?(num.Value)) : null;
					if (exchangeShared != null)
					{
						ExchangeRewardModel instance6 = ModelBase<ExchangeRewardModel>.Instance;
						int num2 = (instance6 != null) ? instance6.GetExchangeRewardShareCount(num.Value) : 0;
						int maxCount = exchangeShared.Value.MaxCount;
						instanceDungeonCostTip.SetRightText(StringUtils.Format("{0}/{1}", new string[]
						{
							(maxCount - num2).ToString(),
							maxCount.ToString()
						}));
					}
					instanceDungeonCostTip.SetHelpButtonVisible(false);
				}
			}
		}

		// Token: 0x06032916 RID: 207126 RVA: 0x00CA9338 File Offset: 0x00CA7538
		private void UpdateCost()
		{
			if (this.InstanceIdList.Count == 0)
			{
				return;
			}
			ExchangeRewardModel instance = ModelBase<ExchangeRewardModel>.Instance;
			List<TItem> list = (instance != null) ? instance.GetExchangeNormalConsume(this.InstanceIdList[0]) : null;
			if (list == null || list.Count == 0)
			{
				return;
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.AddItemToLayout(new object[]
				{
					"power"
				}, 0);
			}
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView2 = this.InstanceCostTipView;
			InstanceDungeonCostTip instanceDungeonCostTip = ((instanceCostTipView2 != null) ? instanceCostTipView2.GetLayoutItemByKey("power", 0) : null) as InstanceDungeonCostTip;
			if (instanceDungeonCostTip != null)
			{
				instanceDungeonCostTip.SetStarVisible(false);
				int itemId = list[0].ItemData.ItemId;
				instanceDungeonCostTip.SetIconByItemId(itemId);
				instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("CostStamina", null) ?? "");
				instanceDungeonCostTip.SetHelpButtonVisible(true);
				instanceDungeonCostTip.SetRightText(list[0].Count.ToString());
				instanceDungeonCostTip.SetClickHelpFunc(new Action(this.OnClickHelpButton));
			}
		}

		// Token: 0x06032917 RID: 207127 RVA: 0x00CA942B File Offset: 0x00CA762B
		private void OnClickHelpButton()
		{
			HelpController instance = ControllerBase<HelpController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OpenHelpById(89);
		}

		// Token: 0x06032918 RID: 207128 RVA: 0x00CA943E File Offset: 0x00CA763E
		protected override void OnCloseWorldMapSecondaryUi()
		{
			GenericLayoutAdd<InstanceDungeonCostTip> instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView == null)
			{
				return;
			}
			instanceCostTipView.ClearChildren();
		}

		// Token: 0x06032919 RID: 207129 RVA: 0x00CA9450 File Offset: 0x00CA7650
		private InstanceTipGrid InitItem()
		{
			return new InstanceTipGrid();
		}

		// Token: 0x0603291A RID: 207130 RVA: 0x00CA9457 File Offset: 0x00CA7657
		[NullableContext(2)]
		public override UUIItem GetGuideFocusUiItem()
		{
			UUIButtonComponent button = base.GetButton(11);
			object obj;
			if (button == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = button.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
			}
			return obj as UUIItem;
		}

		// Token: 0x0401D7A9 RID: 120745
		private const int HELP_ID = 89;

		// Token: 0x0401D7AA RID: 120746
		private const string POWER_COST_KEY = "power";

		// Token: 0x0401D7AB RID: 120747
		private const string COUNT_LIMMIT_KEY = "countLimit";

		// Token: 0x0401D7AC RID: 120748
		private int EntranceId;

		// Token: 0x0401D7AD RID: 120749
		private List<int> InstanceIdList = new List<int>();

		// Token: 0x0401D7AE RID: 120750
		[Nullable(2)]
		private TeleportMarkItem SelectedMarkItem;

		// Token: 0x0401D7AF RID: 120751
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutAdd<InstanceDungeonCostTip> InstanceCostTipView;

		// Token: 0x0401D7B0 RID: 120752
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<InstanceTipGrid, IInstanceTipGridData> InstanceScrollView;

		// Token: 0x0200AC82 RID: 44162
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x040359F0 RID: 219632
			public const int InstanceDungeonEntrancePanel = 0;
		}
	}
}
