using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BF4 RID: 27636
	public class LevelEventSettlementDungeon : LevelEventBase
	{
		// Token: 0x06044108 RID: 278792 RVA: 0x011AB472 File Offset: 0x011A9672
		public LevelEventSettlementDungeon(int id) : base(id)
		{
		}

		// Token: 0x06044109 RID: 278793 RVA: 0x011AB47C File Offset: 0x011A967C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (ModelBase<InstanceDungeonModel>.Instance.InstanceFinishSuccess != EInstanceFinishState.Success)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.LJQ, "副本结算行为触发时，副本未成功", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			int? costPower = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(instanceId);
			bool flag = costPower == null || costPower.GetValueOrDefault() == 0;
			if (flag)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			if (ModelBase<InstanceDungeonModel>.Instance.InstanceRewardHaveTake)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("HaveReceiveRewrad", Array.Empty<object>());
				base.FinishExecute(true, false, true);
				return;
			}
			if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
			{
				base.FinishExecute(true, false, true);
				return;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceCanReward(instanceId))
			{
				this.OpenInstanceRewardTimesNotEnoughConfirmBox();
				base.FinishExecute(true, false, true);
				return;
			}
			if (!ModelBase<ExchangeRewardModel>.Instance.GetInstanceDungeonIfCanExchange(instanceId))
			{
				this.OpenInstanceRewardTimesNotEnoughConfirmBox();
				base.FinishExecute(true, false, true);
				return;
			}
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			bool flag2 = ConfigBase<InstanceDungeonConfig>.Instance.GetInstanceFirstRewardId(instanceId) != 0;
			bool? currentInstanceIsFinish = ModelBase<InstanceDungeonModel>.Instance.CurrentInstanceIsFinish;
			if (flag2 && !currentInstanceIsFinish.GetValueOrDefault() && config.Value.InstSubType != 49)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			ActivityDoubleRewardData dungeonUpActivity = ControllerBase<ActivityDoubleRewardController>.Instance.GetDungeonUpActivity(config.Value.CustomTypes(), true);
			ValueTuple<bool, int, int, string, string> regressDoubleDropTuple = ModelBase<ActivityRegressModel>.Instance.GetRegressDoubleDropTuple(instanceId);
			bool item = regressDoubleDropTuple.Item1;
			int item2 = regressDoubleDropTuple.Item2;
			int item3 = regressDoubleDropTuple.Item3;
			string item4 = regressDoubleDropTuple.Item4;
			string item5 = regressDoubleDropTuple.Item5;
			bool flag3 = dungeonUpActivity != null && dungeonUpActivity.LeftUpCount > 0;
			if (!item && ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.PowerMagnificationReward))
			{
				IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("MultiExchangeInstType");
				if (intArrayConfig != null && intArrayConfig.Contains(config.Value.InstSubType))
				{
					PowerMagnificationRewardPopViewData powerMagnificationRewardPopViewData = new PowerMagnificationRewardPopViewData();
					powerMagnificationRewardPopViewData.SinglePowerCost = costPower.Value;
					powerMagnificationRewardPopViewData.RewardCallBack = delegate(int count)
					{
						ControllerBase<InstanceDungeonController>.Instance.GetInstExchangeRewardRequest(count);
					};
					PowerMagnificationRewardPopViewData powerMagnificationRewardPopViewData2 = powerMagnificationRewardPopViewData;
					if (flag3)
					{
						powerMagnificationRewardPopViewData2.Tip = dungeonUpActivity.GetFullTip();
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.PowerMagnificationRewardPopView, powerMagnificationRewardPopViewData2, null);
					base.FinishExecute(true, false, true);
					return;
				}
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ReceiveLevelPlayReward);
			confirmBoxDataNew.ShowPowerItem = true;
			confirmBoxDataNew.CanExecuteCloseFunc = ((int selectedIndex) => selectedIndex != 2 || ModelBase<PowerModel>.Instance.IsPowerEnough(costPower));
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				costPower.ToString()
			});
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (!ModelBase<PowerModel>.Instance.IsPowerEnough(costPower))
				{
					string textById = ConfigBase<TextConfig>.Instance.GetTextById("ReceiveLevelPlayPowerNotEnough");
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textById);
					ControllerBase<PowerController>.Instance.OpenPowerView(EPowerMenuType.Supply, ModelBase<PowerModel>.Instance.GetCurrentNeedPower(costPower));
					return;
				}
				ControllerBase<InstanceDungeonController>.Instance.GetInstExchangeRewardRequest(1);
			};
			if (flag3)
			{
				confirmBoxDataNew.Tip = dungeonUpActivity.GetFullTip();
			}
			if (item)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(item5, null);
				string str = StringUtils.FormatStaticBuilder(ConfigMultiTextLang.GetLocalTextNew(item4, null), new object[]
				{
					item2,
					item3
				});
				confirmBoxDataNew.Tip = localTextNew + str;
			}
			base.FinishExecute(true, false, true);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0604410A RID: 278794 RVA: 0x011AB7C8 File Offset: 0x011A99C8
		public void OpenInstanceRewardTimesNotEnoughConfirmBox()
		{
			LevelEventSettlementDungeon.<>c__DisplayClass2_0 CS$<>8__locals1 = new LevelEventSettlementDungeon.<>c__DisplayClass2_0();
			LevelEventSettlementDungeon.<>c__DisplayClass2_0 CS$<>8__locals2 = CS$<>8__locals1;
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			CS$<>8__locals2.isMulti = ((instance != null) ? new bool?(instance.IsMulti) : null);
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(CS$<>8__locals1.isMulti.GetValueOrDefault() ? EConfirmBoxConfigId.InstanceRewardTimesNotEnoughMulti : EConfirmBoxConfigId.InstanceRewardTimesNotEnoughSingle);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				if (!CS$<>8__locals1.isMulti.GetValueOrDefault())
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				}
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (!CS$<>8__locals1.isMulti.GetValueOrDefault())
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon();
					return;
				}
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}
}
