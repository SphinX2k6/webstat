using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.TowerDefence;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BE6 RID: 23526
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDungeonInfoItem : UiPanelBase
	{
		// Token: 0x0603B8D7 RID: 243927 RVA: 0x00F18674 File Offset: 0x00F16874
		protected unsafe override void OnRegisterComponent()
		{
			InstanceDungeonViewModelBase instanceDungeonViewModelBase = this.OpenParam as InstanceDungeonViewModelBase;
			if (instanceDungeonViewModelBase == null)
			{
				throw new ArgumentNullException("OpenParam");
			}
			this.ParentModel = instanceDungeonViewModelBase;
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B8D8 RID: 243928 RVA: 0x00F18760 File Offset: 0x00F16960
		protected override UniTask OnBeforeStartAsync()
		{
			InstanceDungeonInfoItem.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InstanceDungeonInfoItem.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B8D9 RID: 243929 RVA: 0x00F187A3 File Offset: 0x00F169A3
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshInstancedRecommendLevel, new Action(this.OnRefreshInstancedRecommendLevel));
		}

		// Token: 0x0603B8DA RID: 243930 RVA: 0x00F187C1 File Offset: 0x00F169C1
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshInstancedRecommendLevel, new Action(this.OnRefreshInstancedRecommendLevel));
		}

		// Token: 0x0603B8DB RID: 243931 RVA: 0x00F187DF File Offset: 0x00F169DF
		[NullableContext(1)]
		public void InitButton(Action onClickBtnSoloCallBack, Action onClickBtnMultipleCallBack, Action onClickBtnTeamCallBack)
		{
			this.InstanceDungeonStartButtonItem.OnClickBtnSoloCallBack = onClickBtnSoloCallBack;
			this.InstanceDungeonStartButtonItem.OnClickBtnMultipleCallBack = onClickBtnMultipleCallBack;
			this.InstanceDungeonStartButtonItem.OnClickBtnTeamCallBack = onClickBtnTeamCallBack;
		}

		// Token: 0x0603B8DC RID: 243932 RVA: 0x00F18808 File Offset: 0x00F16A08
		public UniTask RefreshItem(int instanceId)
		{
			InstanceDungeonInfoItem.<RefreshItem>d__29 <RefreshItem>d__;
			<RefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshItem>d__.<>4__this = this;
			<RefreshItem>d__.instanceId = instanceId;
			<RefreshItem>d__.<>1__state = -1;
			<RefreshItem>d__.<>t__builder.Start<InstanceDungeonInfoItem.<RefreshItem>d__29>(ref <RefreshItem>d__);
			return <RefreshItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B8DD RID: 243933 RVA: 0x00F18854 File Offset: 0x00F16A54
		[NullableContext(1)]
		private void UpdateInstanceDungeonBuffItem(InstanceDungeon config, string monsterTips, bool showMonsterPreview)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass30_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass30_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.monsterTips = monsterTips;
			CS$<>8__locals1.showMonsterPreview = showMonsterPreview;
			if (string.IsNullOrEmpty(CS$<>8__locals1.monsterTips) && !CS$<>8__locals1.showMonsterPreview)
			{
				InstanceDungeonBuffItem instanceDungeonBuffItem = this.InstanceDungeonBuffItem;
				if (instanceDungeonBuffItem == null)
				{
					return;
				}
				instanceDungeonBuffItem.SetActive(false);
				return;
			}
			else
			{
				bool flag = config.InstSubType == 4;
				CS$<>8__locals1.showType = (flag ? InstanceDungeonBuffItem.EBuffInfoType.Resistance : InstanceDungeonBuffItem.EBuffInfoType.Buff);
				if (this.InstanceDungeonBuffItem == null)
				{
					this.InstanceDungeonBuffItem = new InstanceDungeonBuffItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass30_0.<<UpdateInstanceDungeonBuffItem>b__0>d <<UpdateInstanceDungeonBuffItem>b__0>d;
						<<UpdateInstanceDungeonBuffItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateInstanceDungeonBuffItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateInstanceDungeonBuffItem>b__0>d.<>1__state = -1;
						<<UpdateInstanceDungeonBuffItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass30_0.<<UpdateInstanceDungeonBuffItem>b__0>d>(ref <<UpdateInstanceDungeonBuffItem>b__0>d);
						return <<UpdateInstanceDungeonBuffItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				InstanceDungeonBuffItem instanceDungeonBuffItem2 = this.InstanceDungeonBuffItem;
				if (instanceDungeonBuffItem2 != null)
				{
					instanceDungeonBuffItem2.SetActive(true);
				}
				InstanceDungeonBuffItem instanceDungeonBuffItem3 = this.InstanceDungeonBuffItem;
				if (instanceDungeonBuffItem3 == null)
				{
					return;
				}
				instanceDungeonBuffItem3.RefreshItem(CS$<>8__locals1.monsterTips, CS$<>8__locals1.showMonsterPreview, CS$<>8__locals1.showType);
				return;
			}
		}

		// Token: 0x0603B8DE RID: 243934 RVA: 0x00F1891C File Offset: 0x00F16B1C
		private void UpdateInstanceDungeonEntranceTowerDefenceItem(EDungeonSubType subType)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass31_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass31_0();
			CS$<>8__locals1.<>4__this = this;
			if (subType != EDungeonSubType.TowerDefense)
			{
				InstanceDungeonEntranceTowerDefenceItem instanceDungeonEntranceTowerDefenceItem = this.InstanceDungeonEntranceTowerDefenceItem;
				if (instanceDungeonEntranceTowerDefenceItem == null)
				{
					return;
				}
				instanceDungeonEntranceTowerDefenceItem.SetActive(false);
				return;
			}
			else
			{
				CS$<>8__locals1.data = ControllerBase<TowerDefenseController>.Instance.BuildPhantomForInstanceDungeonEntranceData(this.InstanceId);
				if (this.InstanceDungeonEntranceTowerDefenceItem == null)
				{
					this.InstanceDungeonEntranceTowerDefenceItem = new InstanceDungeonEntranceTowerDefenceItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass31_0.<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d <<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d;
						<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d.<>1__state = -1;
						<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass31_0.<<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d>(ref <<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d);
						return <<UpdateInstanceDungeonEntranceTowerDefenceItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonEntranceTowerDefenceItem.SetActive(true);
				this.InstanceDungeonEntranceTowerDefenceItem.RefreshItem(CS$<>8__locals1.data);
				return;
			}
		}

		// Token: 0x0603B8DF RID: 243935 RVA: 0x00F189B0 File Offset: 0x00F16BB0
		private void UpdateLineItem(EDungeonSubType subType)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass32_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass32_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.isNeedLineItem = (subType == EDungeonSubType.MowingRisk);
			if (!CS$<>8__locals1.isNeedLineItem && this.LineItem != null)
			{
				this.LineItem.SetUIActive(false);
				return;
			}
			if (this.LineItem == null)
			{
				this.LoadList.Add(delegate
				{
					InstanceDungeonInfoItem.<>c__DisplayClass32_0.<<UpdateLineItem>b__0>d <<UpdateLineItem>b__0>d;
					<<UpdateLineItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
					<<UpdateLineItem>b__0>d.<>4__this = CS$<>8__locals1;
					<<UpdateLineItem>b__0>d.<>1__state = -1;
					<<UpdateLineItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass32_0.<<UpdateLineItem>b__0>d>(ref <<UpdateLineItem>b__0>d);
					return <<UpdateLineItem>b__0>d.<>t__builder.Task;
				});
				return;
			}
			this.LineItem.SetUIActive(true);
		}

		// Token: 0x0603B8E0 RID: 243936 RVA: 0x00F18A20 File Offset: 0x00F16C20
		private void UpdateInstanceDungeonRecommendLevelItem(EDungeonSubType subType)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass33_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass33_0();
			CS$<>8__locals1.<>4__this = this;
			if (subType != EDungeonSubType.TowerDefense && subType != EDungeonSubType.Mowing && subType != EDungeonSubType.MowingRisk)
			{
				InstanceDungeonRecommendLevelItem instanceDungeonRecommendLevelItem = this.InstanceDungeonRecommendLevelItem;
				if (instanceDungeonRecommendLevelItem == null)
				{
					return;
				}
				instanceDungeonRecommendLevelItem.SetActive(false);
				return;
			}
			else
			{
				CS$<>8__locals1.level = new TowerDefenseRecommendLevel
				{
					TextId = "RecommendLevel",
					Level = 0
				};
				if (subType == EDungeonSubType.TowerDefense)
				{
					CS$<>8__locals1.level = ControllerBase<TowerDefenseController>.Instance.BuildRecommendLevelForInstanceDungeonEntranceData(this.InstanceId);
				}
				else if (subType == EDungeonSubType.MowingRisk)
				{
					IMowingRiskInstanceRecommendData mowingRiskInstanceRecommendData = ModelBase<MowingRiskModel>.Instance.BuildInstanceRecommendDataByInstanceId(this.InstanceId);
					CS$<>8__locals1.level.TextId = mowingRiskInstanceRecommendData.TextId;
					CS$<>8__locals1.level.Level = mowingRiskInstanceRecommendData.RecommendLevel;
				}
				else
				{
					ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
					int? num = (mowingActivityData != null) ? new int?(mowingActivityData.GetLevelDiffRecommendLevel(this.InstanceId)) : null;
					CS$<>8__locals1.level.Level = num.GetValueOrDefault();
				}
				if (this.InstanceDungeonRecommendLevelItem == null)
				{
					this.InstanceDungeonRecommendLevelItem = new InstanceDungeonRecommendLevelItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass33_0.<<UpdateInstanceDungeonRecommendLevelItem>b__0>d <<UpdateInstanceDungeonRecommendLevelItem>b__0>d;
						<<UpdateInstanceDungeonRecommendLevelItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateInstanceDungeonRecommendLevelItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateInstanceDungeonRecommendLevelItem>b__0>d.<>1__state = -1;
						<<UpdateInstanceDungeonRecommendLevelItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass33_0.<<UpdateInstanceDungeonRecommendLevelItem>b__0>d>(ref <<UpdateInstanceDungeonRecommendLevelItem>b__0>d);
						return <<UpdateInstanceDungeonRecommendLevelItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonRecommendLevelItem.SetActive(true);
				this.InstanceDungeonRecommendLevelItem.RefreshItem(CS$<>8__locals1.level);
				return;
			}
		}

		// Token: 0x0603B8E1 RID: 243937 RVA: 0x00F18B58 File Offset: 0x00F16D58
		private void UpdateInstanceDungeonTimeCountCostItem()
		{
			InstanceDungeonInfoItem.<>c__DisplayClass34_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass34_0();
			CS$<>8__locals1.<>4__this = this;
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			if (config == null)
			{
				return;
			}
			bool flag = config.Value.InstSubType == 4;
			int? instancePowerCost = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(this.InstanceId);
			if (instancePowerCost != null)
			{
				int? num = instancePowerCost;
				int num2 = 0;
				if (!(num.GetValueOrDefault() <= num2 & num != null))
				{
					CS$<>8__locals1.costItem = ModelBase<ExchangeRewardModel>.Instance.GetExchangeNormalConsume(this.InstanceId);
					if (flag)
					{
						if (this.InstanceDungeonTimeCountAndCostItem == null)
						{
							this.InstanceDungeonTimeCountAndCostItem = new InstanceDungeonTimeCountAndCostItem();
							this.LoadList.Add(delegate
							{
								InstanceDungeonInfoItem.<>c__DisplayClass34_0.<<UpdateInstanceDungeonTimeCountCostItem>b__0>d <<UpdateInstanceDungeonTimeCountCostItem>b__0>d;
								<<UpdateInstanceDungeonTimeCountCostItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
								<<UpdateInstanceDungeonTimeCountCostItem>b__0>d.<>4__this = CS$<>8__locals1;
								<<UpdateInstanceDungeonTimeCountCostItem>b__0>d.<>1__state = -1;
								<<UpdateInstanceDungeonTimeCountCostItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass34_0.<<UpdateInstanceDungeonTimeCountCostItem>b__0>d>(ref <<UpdateInstanceDungeonTimeCountCostItem>b__0>d);
								return <<UpdateInstanceDungeonTimeCountCostItem>b__0>d.<>t__builder.Task;
							});
							return;
						}
						this.InstanceDungeonTimeCountAndCostItem.SetActive(true);
						this.InstanceDungeonTimeCountAndCostItem.RefreshItem(CS$<>8__locals1.costItem[0], this.InstanceId);
						return;
					}
					else
					{
						if (this.InstanceDungeonCostItem == null)
						{
							this.InstanceDungeonCostItem = new InstanceDungeonCostItem();
							this.LoadList.Add(delegate
							{
								InstanceDungeonInfoItem.<>c__DisplayClass34_0.<<UpdateInstanceDungeonTimeCountCostItem>b__1>d <<UpdateInstanceDungeonTimeCountCostItem>b__1>d;
								<<UpdateInstanceDungeonTimeCountCostItem>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
								<<UpdateInstanceDungeonTimeCountCostItem>b__1>d.<>4__this = CS$<>8__locals1;
								<<UpdateInstanceDungeonTimeCountCostItem>b__1>d.<>1__state = -1;
								<<UpdateInstanceDungeonTimeCountCostItem>b__1>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass34_0.<<UpdateInstanceDungeonTimeCountCostItem>b__1>d>(ref <<UpdateInstanceDungeonTimeCountCostItem>b__1>d);
								return <<UpdateInstanceDungeonTimeCountCostItem>b__1>d.<>t__builder.Task;
							});
							return;
						}
						this.InstanceDungeonCostItem.SetActive(true);
						this.InstanceDungeonCostItem.RefreshItem(CS$<>8__locals1.costItem[0]);
						return;
					}
				}
			}
		}

		// Token: 0x0603B8E2 RID: 243938 RVA: 0x00F18C98 File Offset: 0x00F16E98
		private void UpdateRewardItem()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstanceDungeonReward(this.InstanceId).Item1.Count <= 0)
			{
				InstanceDungeonEntranceRewardItem instanceDungeonEntranceRewardItem = this.InstanceDungeonEntranceRewardItem;
				if (instanceDungeonEntranceRewardItem == null)
				{
					return;
				}
				instanceDungeonEntranceRewardItem.SetActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonEntranceRewardItem == null)
				{
					this.InstanceDungeonEntranceRewardItem = new InstanceDungeonEntranceRewardItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<<UpdateRewardItem>b__35_0>d <<UpdateRewardItem>b__35_0>d;
						<<UpdateRewardItem>b__35_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateRewardItem>b__35_0>d.<>4__this = this;
						<<UpdateRewardItem>b__35_0>d.<>1__state = -1;
						<<UpdateRewardItem>b__35_0>d.<>t__builder.Start<InstanceDungeonInfoItem.<<UpdateRewardItem>b__35_0>d>(ref <<UpdateRewardItem>b__35_0>d);
						return <<UpdateRewardItem>b__35_0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonEntranceRewardItem.SetActive(true);
				this.InstanceDungeonEntranceRewardItem.RefreshItem(this.InstanceId);
				return;
			}
		}

		// Token: 0x0603B8E3 RID: 243939 RVA: 0x00F18D1C File Offset: 0x00F16F1C
		private void UpdateBottomTips(EDungeonSubType subType)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass36_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass36_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dataList = null;
			if (subType == EDungeonSubType.MowingRisk)
			{
				CS$<>8__locals1.dataList = new List<InstanceDungeonBottomTipItemData>();
				MowingRiskModel instance = ModelBase<MowingRiskModel>.Instance;
				RiskHarvestInst riskHarvestInstConfigByInstanceId = instance.GetRiskHarvestInstConfigByInstanceId(this.InstanceId);
				int maxScoreByInstanceId = instance.GetMaxScoreByInstanceId(this.InstanceId);
				InstanceDungeonBottomTipItemData item = new InstanceDungeonBottomTipItemData
				{
					TextId = "riskofrain_total_num",
					TextArgs = new string[]
					{
						maxScoreByInstanceId.ToString()
					}
				};
				CS$<>8__locals1.dataList.Add(item);
				if (!riskHarvestInstConfigByInstanceId.Accumulate)
				{
					int monsterRatioByInstanceId = instance.GetMonsterRatioByInstanceId(this.InstanceId);
					InstanceDungeonBottomTipItemData item2 = new InstanceDungeonBottomTipItemData
					{
						TextId = "riskofrain_ratio_num",
						TextArgs = new string[]
						{
							monsterRatioByInstanceId.ToString()
						}
					};
					CS$<>8__locals1.dataList.Add(item2);
				}
			}
			if (CS$<>8__locals1.dataList == null || CS$<>8__locals1.dataList.Count == 0)
			{
				base.GetVerticalLayout(4).RootUIComp.Get().SetUIActive(false);
				return;
			}
			base.GetVerticalLayout(4).RootUIComp.Get().SetUIActive(true);
			this.LoadList.Add(delegate
			{
				InstanceDungeonInfoItem.<>c__DisplayClass36_0.<<UpdateBottomTips>b__0>d <<UpdateBottomTips>b__0>d;
				<<UpdateBottomTips>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<UpdateBottomTips>b__0>d.<>4__this = CS$<>8__locals1;
				<<UpdateBottomTips>b__0>d.<>1__state = -1;
				<<UpdateBottomTips>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass36_0.<<UpdateBottomTips>b__0>d>(ref <<UpdateBottomTips>b__0>d);
				return <<UpdateBottomTips>b__0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0603B8E4 RID: 243940 RVA: 0x00F18E60 File Offset: 0x00F17060
		private UniTask LoadInstanceDungeonBottomTipTemplateItem()
		{
			InstanceDungeonInfoItem.<LoadInstanceDungeonBottomTipTemplateItem>d__37 <LoadInstanceDungeonBottomTipTemplateItem>d__;
			<LoadInstanceDungeonBottomTipTemplateItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadInstanceDungeonBottomTipTemplateItem>d__.<>4__this = this;
			<LoadInstanceDungeonBottomTipTemplateItem>d__.<>1__state = -1;
			<LoadInstanceDungeonBottomTipTemplateItem>d__.<>t__builder.Start<InstanceDungeonInfoItem.<LoadInstanceDungeonBottomTipTemplateItem>d__37>(ref <LoadInstanceDungeonBottomTipTemplateItem>d__);
			return <LoadInstanceDungeonBottomTipTemplateItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B8E5 RID: 243941 RVA: 0x00F18EA4 File Offset: 0x00F170A4
		private void InitInstanceDungeonBottomTipLayout()
		{
			if (this.InstanceDungeonBottomTipLayout != null)
			{
				return;
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(4);
			this.InstanceDungeonBottomTipLayout = new GenericLayout<InstanceDungeonBottomTipItem, InstanceDungeonBottomTipItemData>(verticalLayout, new Func<InstanceDungeonBottomTipItem>(this.CreateInstanceDungeonBottomTipItem), null, false, true);
		}

		// Token: 0x0603B8E6 RID: 243942 RVA: 0x00F18EDD File Offset: 0x00F170DD
		[NullableContext(1)]
		private InstanceDungeonBottomTipItem CreateInstanceDungeonBottomTipItem()
		{
			return new InstanceDungeonBottomTipItem();
		}

		// Token: 0x0603B8E7 RID: 243943 RVA: 0x00F18EE4 File Offset: 0x00F170E4
		private void UpdateInstanceDungeonMowingDropDownItem(EDungeonSubType subType)
		{
			bool flag = subType == EDungeonSubType.Mowing;
			bool flag2 = ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(this.InstanceId);
			if (!flag || !flag2)
			{
				InstanceDungeonMowingDropDownItem instanceDungeonMowingDropDownItem = this.InstanceDungeonMowingDropDownItem;
				if (instanceDungeonMowingDropDownItem == null)
				{
					return;
				}
				instanceDungeonMowingDropDownItem.SetActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonMowingDropDownItem == null)
				{
					this.InstanceDungeonMowingDropDownItem = new InstanceDungeonMowingDropDownItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d <<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d;
						<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d.<>4__this = this;
						<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d.<>1__state = -1;
						<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d.<>t__builder.Start<InstanceDungeonInfoItem.<<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d>(ref <<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d);
						return <<UpdateInstanceDungeonMowingDropDownItem>b__40_0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonMowingDropDownItem.SetActive(true);
				this.InstanceDungeonMowingDropDownItem.RefreshItem(this.InstanceId);
				return;
			}
		}

		// Token: 0x0603B8E8 RID: 243944 RVA: 0x00F18F68 File Offset: 0x00F17168
		public void SetMatchingItemActive(bool isShow)
		{
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(this.InstanceId);
			InstanceDungeonStartButtonItem instanceDungeonStartButtonItem = this.InstanceDungeonStartButtonItem;
			if (instanceDungeonStartButtonItem != null)
			{
				instanceDungeonStartButtonItem.SetActive(!isShow && flag);
			}
			InstanceDungeonMatchingItem instanceDungeonMatchingItem = this.InstanceDungeonMatchingItem;
			if (instanceDungeonMatchingItem == null)
			{
				return;
			}
			instanceDungeonMatchingItem.SetActive(isShow);
		}

		// Token: 0x0603B8E9 RID: 243945 RVA: 0x00F18FB0 File Offset: 0x00F171B0
		public void UpdateInstanceDungeonLockItemAndCostItem()
		{
			bool flag = ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching;
			InstanceDungeonTimeCountAndCostItem instanceDungeonTimeCountAndCostItem = this.InstanceDungeonTimeCountAndCostItem;
			if (instanceDungeonTimeCountAndCostItem != null)
			{
				instanceDungeonTimeCountAndCostItem.SetActive(false);
			}
			if (this.ParentModel.CheckInstanceUnlock(this.InstanceId))
			{
				this.UpdateInstanceDungeonTimeCountCostItem();
				this.InstanceDungeonStartButtonItem.SetActive(!flag);
				this.InstanceDungeonLockItem.SetActive(false);
				InstanceDungeonMatchingItem instanceDungeonMatchingItem = this.InstanceDungeonMatchingItem;
				if (instanceDungeonMatchingItem == null)
				{
					return;
				}
				instanceDungeonMatchingItem.SetActive(flag);
				return;
			}
			else
			{
				TableTextArgNew unlockConditionTextId = this.ParentModel.GetUnlockConditionTextId(this.InstanceId);
				if (unlockConditionTextId != null)
				{
					this.InstanceDungeonLockItem.RefreshItem(unlockConditionTextId);
				}
				this.InstanceDungeonStartButtonItem.SetActive(false);
				this.InstanceDungeonLockItem.SetActive(true);
				InstanceDungeonMatchingItem instanceDungeonMatchingItem2 = this.InstanceDungeonMatchingItem;
				if (instanceDungeonMatchingItem2 == null)
				{
					return;
				}
				instanceDungeonMatchingItem2.SetActive(false);
				return;
			}
		}

		// Token: 0x0603B8EA RID: 243946 RVA: 0x00F19070 File Offset: 0x00F17270
		private void UpdateRogueBlackFlowerItem(InstanceDungeon dungeonConfig)
		{
			bool flag = dungeonConfig.InstSubType == 15;
			bool flag2 = ModelBase<RoguelikeModel>.Instance.HasBlackFlowerExchanged(this.InstanceId);
			if (!flag || !flag2)
			{
				RoguelikeBlackFlowerInstanceItem rogueBlackFlowerItem = this.RogueBlackFlowerItem;
				if (rogueBlackFlowerItem == null)
				{
					return;
				}
				rogueBlackFlowerItem.SetActive(false);
				return;
			}
			else
			{
				if (this.RogueBlackFlowerItem == null)
				{
					this.RogueBlackFlowerItem = new RoguelikeBlackFlowerInstanceItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<<UpdateRogueBlackFlowerItem>b__43_0>d <<UpdateRogueBlackFlowerItem>b__43_0>d;
						<<UpdateRogueBlackFlowerItem>b__43_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateRogueBlackFlowerItem>b__43_0>d.<>4__this = this;
						<<UpdateRogueBlackFlowerItem>b__43_0>d.<>1__state = -1;
						<<UpdateRogueBlackFlowerItem>b__43_0>d.<>t__builder.Start<InstanceDungeonInfoItem.<<UpdateRogueBlackFlowerItem>b__43_0>d>(ref <<UpdateRogueBlackFlowerItem>b__43_0>d);
						return <<UpdateRogueBlackFlowerItem>b__43_0>d.<>t__builder.Task;
					});
					return;
				}
				this.RogueBlackFlowerItem.SetActive(true);
				return;
			}
		}

		// Token: 0x0603B8EB RID: 243947 RVA: 0x00F190E8 File Offset: 0x00F172E8
		private void UpdatePictureItem(int uid)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass44_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass44_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dataGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetPictureItemDataGetter(uid);
			if (CS$<>8__locals1.dataGetter == null)
			{
				InstanceDungeonPicItem instanceDungeonPicItem = this.InstanceDungeonPicItem;
				if (instanceDungeonPicItem == null)
				{
					return;
				}
				instanceDungeonPicItem.SetUiActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonPicItem == null)
				{
					this.InstanceDungeonPicItem = new InstanceDungeonPicItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass44_0.<<UpdatePictureItem>b__0>d <<UpdatePictureItem>b__0>d;
						<<UpdatePictureItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdatePictureItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdatePictureItem>b__0>d.<>1__state = -1;
						<<UpdatePictureItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass44_0.<<UpdatePictureItem>b__0>d>(ref <<UpdatePictureItem>b__0>d);
						return <<UpdatePictureItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonPicItem.SetUiActive(true);
				this.InstanceDungeonPicItem.RefreshItem(CS$<>8__locals1.dataGetter());
				return;
			}
		}

		// Token: 0x0603B8EC RID: 243948 RVA: 0x00F1917C File Offset: 0x00F1737C
		private void UpdateDescWidelyItem(int uid)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass45_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass45_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dataGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetDescWidelyItemDataGetter(uid);
			if (CS$<>8__locals1.dataGetter == null)
			{
				InstanceDungeonDescWidelyItem instanceDungeonDescWidelyItem = this.InstanceDungeonDescWidelyItem;
				if (instanceDungeonDescWidelyItem == null)
				{
					return;
				}
				instanceDungeonDescWidelyItem.SetUiActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonDescWidelyItem == null)
				{
					this.InstanceDungeonDescWidelyItem = new InstanceDungeonDescWidelyItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass45_0.<<UpdateDescWidelyItem>b__0>d <<UpdateDescWidelyItem>b__0>d;
						<<UpdateDescWidelyItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateDescWidelyItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateDescWidelyItem>b__0>d.<>1__state = -1;
						<<UpdateDescWidelyItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass45_0.<<UpdateDescWidelyItem>b__0>d>(ref <<UpdateDescWidelyItem>b__0>d);
						return <<UpdateDescWidelyItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonDescWidelyItem.SetUiActive(true);
				this.InstanceDungeonDescWidelyItem.RefreshItem(CS$<>8__locals1.dataGetter());
				return;
			}
		}

		// Token: 0x0603B8ED RID: 243949 RVA: 0x00F19210 File Offset: 0x00F17410
		private void UpdateTitleWidelyItem(int uid)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass46_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass46_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dataGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetTitleWidelyItemDataGetter(uid);
			if (CS$<>8__locals1.dataGetter == null)
			{
				InstanceDungeonTitleWidelyItem instanceDungeonTitleWidelyItem = this.InstanceDungeonTitleWidelyItem;
				if (instanceDungeonTitleWidelyItem == null)
				{
					return;
				}
				instanceDungeonTitleWidelyItem.SetUiActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonTitleWidelyItem == null)
				{
					this.InstanceDungeonTitleWidelyItem = new InstanceDungeonTitleWidelyItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass46_0.<<UpdateTitleWidelyItem>b__0>d <<UpdateTitleWidelyItem>b__0>d;
						<<UpdateTitleWidelyItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateTitleWidelyItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateTitleWidelyItem>b__0>d.<>1__state = -1;
						<<UpdateTitleWidelyItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass46_0.<<UpdateTitleWidelyItem>b__0>d>(ref <<UpdateTitleWidelyItem>b__0>d);
						return <<UpdateTitleWidelyItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonTitleWidelyItem.SetUiActive(true);
				this.InstanceDungeonTitleWidelyItem.RefreshItem(CS$<>8__locals1.dataGetter());
				return;
			}
		}

		// Token: 0x0603B8EE RID: 243950 RVA: 0x00F192A4 File Offset: 0x00F174A4
		private void UpdateScoreListItem(int uid)
		{
			InstanceDungeonInfoItem.<>c__DisplayClass47_0 CS$<>8__locals1 = new InstanceDungeonInfoItem.<>c__DisplayClass47_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.dataGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetScoreListItemDataGetter(uid);
			if (CS$<>8__locals1.dataGetter == null)
			{
				InstanceDungeonScoreListItem instanceDungeonScoreListItem = this.InstanceDungeonScoreListItem;
				if (instanceDungeonScoreListItem == null)
				{
					return;
				}
				instanceDungeonScoreListItem.SetUiActive(false);
				return;
			}
			else
			{
				if (this.InstanceDungeonScoreListItem == null)
				{
					this.InstanceDungeonScoreListItem = new InstanceDungeonScoreListItem();
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<>c__DisplayClass47_0.<<UpdateScoreListItem>b__0>d <<UpdateScoreListItem>b__0>d;
						<<UpdateScoreListItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateScoreListItem>b__0>d.<>4__this = CS$<>8__locals1;
						<<UpdateScoreListItem>b__0>d.<>1__state = -1;
						<<UpdateScoreListItem>b__0>d.<>t__builder.Start<InstanceDungeonInfoItem.<>c__DisplayClass47_0.<<UpdateScoreListItem>b__0>d>(ref <<UpdateScoreListItem>b__0>d);
						return <<UpdateScoreListItem>b__0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonScoreListItem.SetUiActive(true);
				this.InstanceDungeonScoreListItem.RefreshItem(CS$<>8__locals1.dataGetter());
				return;
			}
		}

		// Token: 0x0603B8EF RID: 243951 RVA: 0x00F19338 File Offset: 0x00F17538
		private void UpdateRankTimeItem(int instanceId)
		{
			if (this.ParentModel.RankItemModel == null)
			{
				InstanceDungeonRankTimeItem instanceDungeonRankTimeItem = this.InstanceDungeonRankTimeItem;
				if (instanceDungeonRankTimeItem == null)
				{
					return;
				}
				instanceDungeonRankTimeItem.SetUiActive(false);
				return;
			}
			else
			{
				this.ParentModel.RankItemModel.RefreshInstance(instanceId);
				if (this.InstanceDungeonRankTimeItem == null)
				{
					this.InstanceDungeonRankTimeItem = new InstanceDungeonRankTimeItem();
					this.InstanceDungeonRankTimeItem.OpenParam = this.ParentModel.RankItemModel;
					this.LoadList.Add(delegate
					{
						InstanceDungeonInfoItem.<<UpdateRankTimeItem>b__48_0>d <<UpdateRankTimeItem>b__48_0>d;
						<<UpdateRankTimeItem>b__48_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
						<<UpdateRankTimeItem>b__48_0>d.<>4__this = this;
						<<UpdateRankTimeItem>b__48_0>d.<>1__state = -1;
						<<UpdateRankTimeItem>b__48_0>d.<>t__builder.Start<InstanceDungeonInfoItem.<<UpdateRankTimeItem>b__48_0>d>(ref <<UpdateRankTimeItem>b__48_0>d);
						return <<UpdateRankTimeItem>b__48_0>d.<>t__builder.Task;
					});
					return;
				}
				this.InstanceDungeonRankTimeItem.SetUiActive(true);
				this.InstanceDungeonRankTimeItem.Refresh();
				return;
			}
		}

		// Token: 0x0603B8F0 RID: 243952 RVA: 0x00F193CD File Offset: 0x00F175CD
		[NullableContext(1)]
		public void SetLockText(string lockText)
		{
			this.InstanceDungeonLockItem.SetActive(true);
			this.InstanceDungeonLockItem.SetLockText(lockText);
		}

		// Token: 0x0603B8F1 RID: 243953 RVA: 0x00F193E8 File Offset: 0x00F175E8
		private void OnRefreshInstancedRecommendLevel()
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			if (config == null)
			{
				return;
			}
			this.UpdateInstanceDungeonRecommendLevelItem((EDungeonSubType)config.Value.InstSubType);
		}

		// Token: 0x0402186D RID: 137325
		private int InstanceId;

		// Token: 0x0402186E RID: 137326
		private InstanceDungeonRightTitleItem InstanceDungeonRightTitleItem;

		// Token: 0x0402186F RID: 137327
		private InstanceDungeonBuffItem InstanceDungeonBuffItem;

		// Token: 0x04021870 RID: 137328
		private InstanceDungeonEntranceTowerDefenceItem InstanceDungeonEntranceTowerDefenceItem;

		// Token: 0x04021871 RID: 137329
		private InstanceDungeonRecommendLevelItem InstanceDungeonRecommendLevelItem;

		// Token: 0x04021872 RID: 137330
		private InstanceDungeonCostItem InstanceDungeonCostItem;

		// Token: 0x04021873 RID: 137331
		private InstanceDungeonTimeCountAndCostItem InstanceDungeonTimeCountAndCostItem;

		// Token: 0x04021874 RID: 137332
		private InstanceDungeonEntranceRewardItem InstanceDungeonEntranceRewardItem;

		// Token: 0x04021875 RID: 137333
		private InstanceDungeonMowingDropDownItem InstanceDungeonMowingDropDownItem;

		// Token: 0x04021876 RID: 137334
		private InstanceDungeonStartButtonItem InstanceDungeonStartButtonItem;

		// Token: 0x04021877 RID: 137335
		private InstanceDungeonMatchingItem InstanceDungeonMatchingItem;

		// Token: 0x04021878 RID: 137336
		private InstanceDungeonLockItem InstanceDungeonLockItem;

		// Token: 0x04021879 RID: 137337
		private RoguelikeBlackFlowerInstanceItem RogueBlackFlowerItem;

		// Token: 0x0402187A RID: 137338
		private UUIItem LineItem;

		// Token: 0x0402187B RID: 137339
		private InstanceDungeonBottomTipItem InstanceDungeonBottomTipTemplateItem;

		// Token: 0x0402187C RID: 137340
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<InstanceDungeonBottomTipItem, InstanceDungeonBottomTipItemData> InstanceDungeonBottomTipLayout;

		// Token: 0x0402187D RID: 137341
		private InstanceDungeonPicItem InstanceDungeonPicItem;

		// Token: 0x0402187E RID: 137342
		private InstanceDungeonDescWidelyItem InstanceDungeonDescWidelyItem;

		// Token: 0x0402187F RID: 137343
		private InstanceDungeonTitleWidelyItem InstanceDungeonTitleWidelyItem;

		// Token: 0x04021880 RID: 137344
		private InstanceDungeonScoreListItem InstanceDungeonScoreListItem;

		// Token: 0x04021881 RID: 137345
		private InstanceDungeonRankTimeItem InstanceDungeonRankTimeItem;

		// Token: 0x04021882 RID: 137346
		[Nullable(1)]
		private List<Func<UniTask>> LoadList = new List<Func<UniTask>>();

		// Token: 0x04021883 RID: 137347
		[Nullable(1)]
		private InstanceDungeonViewModelBase ParentModel;

		// Token: 0x0200BC4E RID: 48206
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403A12F RID: 237871
			TopItem,
			// Token: 0x0403A130 RID: 237872
			BottomItem,
			// Token: 0x0403A131 RID: 237873
			ButtonItem,
			// Token: 0x0403A132 RID: 237874
			RewardItem,
			// Token: 0x0403A133 RID: 237875
			BottomTipLayout
		}
	}
}
