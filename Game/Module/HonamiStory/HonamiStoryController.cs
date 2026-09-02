using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C70 RID: 23664
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HonamiStoryController : ActivityControllerBase<HonamiStoryController>
	{
		// Token: 0x0603BCD2 RID: 244946 RVA: 0x00F292B5 File Offset: 0x00F274B5
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryUnlockTipView, null, null);
		}

		// Token: 0x0603BCD3 RID: 244947 RVA: 0x00F292C8 File Offset: 0x00F274C8
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603BCD4 RID: 244948 RVA: 0x00F292CA File Offset: 0x00F274CA
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityHonamiStoryGuide";
		}

		// Token: 0x0603BCD5 RID: 244949 RVA: 0x00F292D1 File Offset: 0x00F274D1
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new HonamiStoryActivityView();
		}

		// Token: 0x0603BCD6 RID: 244950 RVA: 0x00F292D8 File Offset: 0x00F274D8
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			HonamiStoryActivityData honamiStoryActivityData = new HonamiStoryActivityData();
			ModelBase<HonamiStoryModel>.Instance.SetActivityData(honamiStoryActivityData);
			return honamiStoryActivityData;
		}

		// Token: 0x0603BCD7 RID: 244951 RVA: 0x00F292F7 File Offset: 0x00F274F7
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			throw new NotImplementedException();
		}

		// Token: 0x0603BCD8 RID: 244952 RVA: 0x00F29300 File Offset: 0x00F27500
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveDungeon));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnEnterDungeon));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.ActivityInfoRequest));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.ActivityInfoRequest));
		}

		// Token: 0x0603BCD9 RID: 244953 RVA: 0x00F2939C File Offset: 0x00F2759C
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveDungeon));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnEnterDungeon));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.ActivityInfoRequest));
			Singleton<EventSystem>.Instance.Remove<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.ActivityInfoRequest));
		}

		// Token: 0x0603BCDA RID: 244954 RVA: 0x00F29438 File Offset: 0x00F27638
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<HonamiStoryBagInfoUpdateNotify>(ENotifyMessageId.HonamiStoryBagInfoUpdateNotify, new Action<HonamiStoryBagInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryBagInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryInstInfoNotify>(ENotifyMessageId.HonamiStoryInstInfoNotify, new Action<HonamiStoryInstInfoNotify, Net.CallbackStatus>(this.OnHonamiStoryInstInfoNotify));
			Singleton<Net>.Instance.Register<HonamiStorySafeLeaveNotify>(ENotifyMessageId.HonamiStorySafeLeaveNotify, new Action<HonamiStorySafeLeaveNotify, Net.CallbackStatus>(this.OnHonamiStorySafeLeaveNotify));
			Singleton<Net>.Instance.Register<HonamiStoryMascotInfoUpdateNotify>(ENotifyMessageId.HonamiStoryMascotInfoUpdateNotify, new Action<HonamiStoryMascotInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryMascotInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryAreaInfoUpdateNotify>(ENotifyMessageId.HonamiStoryAreaInfoUpdateNotify, new Action<HonamiStoryAreaInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryAreaInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryResidentTaskInfoUpdateNotify>(ENotifyMessageId.HonamiStoryResidentTaskInfoUpdateNotify, new Action<HonamiStoryResidentTaskInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryPermanentTaskInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryLimitTaskInfoUpdateNotify>(ENotifyMessageId.HonamiStoryLimitTaskInfoUpdateNotify, new Action<HonamiStoryLimitTaskInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryLimitTaskInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryScoreRewardInfoUpdateNotify>(ENotifyMessageId.HonamiStoryScoreRewardInfoUpdateNotify, new Action<HonamiStoryScoreRewardInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryScoreRewardInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryItemCollectionInfoUpdateNotify>(ENotifyMessageId.HonamiStoryItemCollectionInfoUpdateNotify, new Action<HonamiStoryItemCollectionInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryItemCollectionInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryAreaTaskInfoRefreshNotify>(ENotifyMessageId.HonamiStoryAreaTaskInfoRefreshNotify, new Action<HonamiStoryAreaTaskInfoRefreshNotify, Net.CallbackStatus>(this.OnHonamiStoryAreaTaskInfoRefreshNotify));
			Singleton<Net>.Instance.Register<HonamiStoryAreaTaskInfoUpdateNotify>(ENotifyMessageId.HonamiStoryAreaTaskInfoUpdateNotify, new Action<HonamiStoryAreaTaskInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryAreaTaskInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryRoleUpdateNotify>(ENotifyMessageId.HonamiStoryRoleUpdateNotify, new Action<HonamiStoryRoleUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryRoleUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryInstSettleNotify>(ENotifyMessageId.HonamiStoryInstSettleNotify, new Action<HonamiStoryInstSettleNotify, Net.CallbackStatus>(this.OnHonamiStoryInstSettleNotify));
			Singleton<Net>.Instance.Register<HonamiStoryPollutionUpdateNotify>(ENotifyMessageId.HonamiStoryPollutionUpdateNotify, new Action<HonamiStoryPollutionUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryPollutionUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryBagSizeUpdateNotify>(ENotifyMessageId.HonamiStoryBagSizeUpdateNotify, new Action<HonamiStoryBagSizeUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryBagSizeUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryAddWeaponNotify>(ENotifyMessageId.HonamiStoryAddWeaponNotify, new Action<HonamiStoryAddWeaponNotify, Net.CallbackStatus>(this.OnHonamiStoryAddWeaponNotify));
			Singleton<Net>.Instance.Register<HonamiStoryInstTopTowerSettleNotify>(ENotifyMessageId.HonamiStoryInstTopTowerSettleNotify, new Action<HonamiStoryInstTopTowerSettleNotify, Net.CallbackStatus>(this.OnHonamiStoryInstTopTowerSettleNotify));
			Singleton<Net>.Instance.Register<HonamiStorySetFormationNotify>(ENotifyMessageId.HonamiStorySetFormationNotify, new Action<HonamiStorySetFormationNotify, Net.CallbackStatus>(this.OnHonamiStorySetFormationNotify));
			Singleton<Net>.Instance.Register<HonamiStoryTalentInfoUpdateNotify>(ENotifyMessageId.HonamiStoryTalentInfoUpdateNotify, new Action<HonamiStoryTalentInfoUpdateNotify, Net.CallbackStatus>(this.OnHonamiStoryTalentInfoUpdateNotify));
			Singleton<Net>.Instance.Register<HonamiStoryTotalRevenueNotify>(ENotifyMessageId.HonamiStoryTotalRevenueNotify, new Action<HonamiStoryTotalRevenueNotify, Net.CallbackStatus>(this.OnHonamiStoryTotalRevenueNotify));
			Singleton<Net>.Instance.Register<HonamiStoryLifeSupportNotify>(ENotifyMessageId.HonamiStoryLifeSupportNotify, new Action<HonamiStoryLifeSupportNotify, Net.CallbackStatus>(this.OnHonamiStoryLifeSupportNotify));
			Singleton<Net>.Instance.Register<HonamiStoryTopInfoNotify>(ENotifyMessageId.HonamiStoryTopInfoNotify, new Action<HonamiStoryTopInfoNotify, Net.CallbackStatus>(this.OnHonamiStoryTopInfoNotify));
		}

		// Token: 0x0603BCDB RID: 244955 RVA: 0x00F296B0 File Offset: 0x00F278B0
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryBagInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryInstInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStorySafeLeaveNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryInstSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryMascotInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryAreaInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryResidentTaskInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryLimitTaskInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryScoreRewardInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryItemCollectionInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryAreaTaskInfoRefreshNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryAreaTaskInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryRoleUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryPollutionUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryBagSizeUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryAddWeaponNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryInstTopTowerSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStorySetFormationNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryTalentInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryTotalRevenueNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.HonamiStoryLifeSupportNotify);
		}

		// Token: 0x0603BCDC RID: 244956 RVA: 0x00F29810 File Offset: 0x00F27A10
		private void ActivityInfoRequest(EFunctionType id, bool isOpen)
		{
			if (id != EFunctionType.HonamiStoryMainQuestFuncId)
			{
				return;
			}
			if (!isOpen)
			{
				return;
			}
			HonamiStoryActivityInfoRequest honamiStoryActivityInfoRequest = HonamiStoryActivityInfoRequest.Create();
			IEnumerable<HonamiStoryActivity> allActivityConfig = ConfigBase<HonamiStoryConfig>.Instance.GetAllActivityConfig();
			int actId = 0;
			foreach (HonamiStoryActivity honamiStoryActivity in allActivityConfig)
			{
				actId = honamiStoryActivity.ActivityId;
			}
			if (actId == 0)
			{
				return;
			}
			honamiStoryActivityInfoRequest.ActivityId = actId;
			Singleton<Net>.Instance.Call<HonamiStoryActivityInfoResponse>(ERequestMessageId.HonamiStoryActivityInfoRequest, honamiStoryActivityInfoRequest, delegate(HonamiStoryActivityInfoResponse response, Net.CallbackStatus _)
			{
				if (response == null || response.HonamiStoryActivityInfo == null)
				{
					return;
				}
				ModelBase<HonamiStoryModel>.Instance.InitActivityInfo(actId, response.HonamiStoryActivityInfo);
			}, 0);
		}

		// Token: 0x0603BCDD RID: 244957 RVA: 0x00F298BC File Offset: 0x00F27ABC
		public void TryHonamiStoryInstLeave(bool showSafeLeaveUpdate = false)
		{
			HonamiStoryLeaveTipParams honamiStoryLeaveTipParams = new HonamiStoryLeaveTipParams();
			honamiStoryLeaveTipParams.LeaveType = (ModelBase<HonamiStoryModel>.Instance.CanSafeLeave ? EHonamiStoryLeaveType.SafeLeave : EHonamiStoryLeaveType.DangerLeave);
			honamiStoryLeaveTipParams.ShowSafeLeaveUpdate = showSafeLeaveUpdate;
			honamiStoryLeaveTipParams.ConfirmCallback = delegate()
			{
				HonamiStoryInstLeaveRequest message = HonamiStoryInstLeaveRequest.Create();
				Singleton<Net>.Instance.Call<HonamiStoryInstLeaveResponse>(ERequestMessageId.HonamiStoryInstLeaveRequest, message, delegate(HonamiStoryInstLeaveResponse _, Net.CallbackStatus __)
				{
				}, 0);
			};
			HonamiStoryLeaveTipParams param = honamiStoryLeaveTipParams;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryLeaveTip, param, null);
		}

		// Token: 0x0603BCDE RID: 244958 RVA: 0x00F29924 File Offset: 0x00F27B24
		[NullableContext(0)]
		public UniTask<bool> OpenHonamiStoryBag()
		{
			HonamiStoryController.<OpenHonamiStoryBag>d__12 <OpenHonamiStoryBag>d__;
			<OpenHonamiStoryBag>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenHonamiStoryBag>d__.<>1__state = -1;
			<OpenHonamiStoryBag>d__.<>t__builder.Start<HonamiStoryController.<OpenHonamiStoryBag>d__12>(ref <OpenHonamiStoryBag>d__);
			return <OpenHonamiStoryBag>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCDF RID: 244959 RVA: 0x00F29960 File Offset: 0x00F27B60
		public void SetHonamiStoryLoadingInfoByResult(bool isSuccess)
		{
			EHonamiStoryLoadingTimingType honamiStoryLoadingInfoByTimingOnly = isSuccess ? EHonamiStoryLoadingTimingType.SuccessLeave : EHonamiStoryLoadingTimingType.FailLeave;
			this.SetHonamiStoryLoadingInfoByTimingOnly(honamiStoryLoadingInfoByTimingOnly);
		}

		// Token: 0x0603BCE0 RID: 244960 RVA: 0x00F2997C File Offset: 0x00F27B7C
		public void SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType timing)
		{
			HonamiStoryLoadingDataImpl gamePlayLoadingData = new HonamiStoryLoadingDataImpl
			{
				Timing = new int?((int)timing)
			};
			ModelBase<HonamiStoryModel>.Instance.SetGamePlayLoadingData(gamePlayLoadingData);
		}

		// Token: 0x0603BCE1 RID: 244961 RVA: 0x00F299A8 File Offset: 0x00F27BA8
		public void SetHonamiStoryLoadingInfoByBtId(int btId)
		{
			HonamiStoryLoadingDataImpl gamePlayLoadingData = new HonamiStoryLoadingDataImpl
			{
				Timing = new int?(2),
				BtId = new int?(btId)
			};
			ModelBase<HonamiStoryModel>.Instance.SetGamePlayLoadingData(gamePlayLoadingData);
		}

		// Token: 0x0603BCE2 RID: 244962 RVA: 0x00F299E0 File Offset: 0x00F27BE0
		public void OnHonamiStoryInstInfoNotify(HonamiStoryInstInfoNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.SetIsLastPickUpViewDirty(false);
			ModelBase<HonamiStoryModel>.Instance.InitBackPackInfoList(message.HonamiStoryBagInfos.ToList<HonamiStoryBagInfo>());
			ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			this.UpdateHonamiStorySafeLeave(message.CanSafeLeave, false);
			int dangerLevelId = message.DangerLevelId;
			if (dangerLevelId > 0)
			{
				HonamiStoryDangerLevel? config = ConfigHonamiStoryDangerLevelById.GetConfig(dangerLevelId, true);
				if (config != null)
				{
					ModelBase<HonamiStoryModel>.Instance.MonsterBaseEnhanceLevel = config.Value.MonsterEnhanceLevel;
					ModelBase<HonamiStoryModel>.Instance.DangerLevel = config.Value.Level;
				}
				ModelBase<HonamiStoryModel>.Instance.PollutionLevel = message.PollutionLevel;
				ModelBase<HonamiStoryModel>.Instance.PollutionStarTime = (float)Singleton<MathUtils>.Instance.LongToNumber(message.PollutionStartTime);
				Dictionary<int, IHonamiStoryPollution> dictionary = ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap;
				if (dictionary != null)
				{
					if (dictionary != null)
					{
						dictionary.Clear();
					}
				}
				else
				{
					dictionary = new Dictionary<int, IHonamiStoryPollution>();
					ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap = dictionary;
				}
				int pollutionGroup = message.PollutionGroup;
				HonamiStoryPollutionStage? config2 = ConfigHonamiStoryPollutionStageById.GetConfig(pollutionGroup, true);
				if (config2 != null)
				{
					ModelBase<HonamiStoryModel>.Instance.PollutionWarningLevel = config2.Value.WarningLevel;
					ModelBase<HonamiStoryModel>.Instance.PollutionDangerLevel = config2.Value.DangerLevel;
				}
				IReadOnlyList<HonamiStoryPollution> configList = ConfigHonamiStoryPollutionByActivityId.GetConfigList(message.ActivityId, true);
				if (configList != null)
				{
					List<IHonamiStoryPollution> list = new List<IHonamiStoryPollution>();
					foreach (HonamiStoryPollution honamiStoryPollution in configList)
					{
						if (honamiStoryPollution.Group == pollutionGroup)
						{
							list.Add(new HonamiStoryPollution
							{
								PollutionLevel = honamiStoryPollution.Level,
								PersistMilliseconds = honamiStoryPollution.PersistSecond * 1000,
								MonsterEnhanceLevel = honamiStoryPollution.MonsterEnhanceLevel
							});
						}
					}
					list.Sort((IHonamiStoryPollution a, IHonamiStoryPollution b) => a.PollutionLevel - b.PollutionLevel);
					IHonamiStoryPollution honamiStoryPollution2 = null;
					foreach (IHonamiStoryPollution honamiStoryPollution3 in list)
					{
						if (honamiStoryPollution2 != null)
						{
							honamiStoryPollution3.MonsterEnhanceLevel += honamiStoryPollution2.MonsterEnhanceLevel;
						}
						dictionary[honamiStoryPollution3.PollutionLevel] = honamiStoryPollution3;
						honamiStoryPollution2 = honamiStoryPollution3;
					}
					ModelBase<HonamiStoryModel>.Instance.PollutionMaxLevel = list[list.Count - 1].PollutionLevel;
				}
			}
			ModelBase<HonamiStoryModel>.Instance.MonsterLevelSafeOffset = ConfigCommonParamById.GetIntConfig("HonamiStorySafeLevelOffset").GetValueOrDefault();
			ModelBase<HonamiStoryModel>.Instance.MonsterLevelDangerOffset = -ConfigCommonParamById.GetIntConfig("HonamiStoryDangerLevelOffset").GetValueOrDefault();
			ModelBase<HonamiStoryModel>.Instance.CurAreaId = message.HonamiStoryAreaId;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryInstInfoUpdate);
		}

		// Token: 0x0603BCE3 RID: 244963 RVA: 0x00F29CBC File Offset: 0x00F27EBC
		private void OnHonamiStorySafeLeaveNotify(HonamiStorySafeLeaveNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			this.UpdateHonamiStorySafeLeave(message.CanSafeLeave, true);
		}

		// Token: 0x0603BCE4 RID: 244964 RVA: 0x00F29CCB File Offset: 0x00F27ECB
		private void UpdateHonamiStorySafeLeave(bool canSafeLeave, bool showLeave)
		{
			if (ModelBase<HonamiStoryModel>.Instance.CanSafeLeave == canSafeLeave)
			{
				if (canSafeLeave && showLeave)
				{
					this.TryHonamiStoryInstLeave(false);
				}
				return;
			}
			ModelBase<HonamiStoryModel>.Instance.CanSafeLeave = canSafeLeave;
			if (!canSafeLeave)
			{
				return;
			}
			if (showLeave)
			{
				this.TryHonamiStoryInstLeave(true);
				return;
			}
			this.ShowSafeLeaveUpdate();
		}

		// Token: 0x0603BCE5 RID: 244965 RVA: 0x00F29D07 File Offset: 0x00F27F07
		public void ShowSafeLeaveUpdate()
		{
			if (ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySafeLeaveUpdateView, null, null);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryLeaveButtonUpdate);
				return;
			}
			ModelBase<HonamiStoryModel>.Instance.CacheShowSafeLeaveUpdate = true;
		}

		// Token: 0x0603BCE6 RID: 244966 RVA: 0x00F29D44 File Offset: 0x00F27F44
		private void OnHonamiStoryPollutionUpdateNotify(HonamiStoryPollutionUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			int pollutionLevel = ModelBase<HonamiStoryModel>.Instance.PollutionLevel;
			int pollutionLevel2 = message.PollutionLevel;
			long num = Singleton<MathUtils>.Instance.LongToNumber(message.PollutionStartTime);
			ModelBase<HonamiStoryModel>.Instance.PollutionLevel = pollutionLevel2;
			ModelBase<HonamiStoryModel>.Instance.PollutionStarTime = (float)num;
			Dictionary<int, IHonamiStoryPollution> pollutionLevelMap = ModelBase<HonamiStoryModel>.Instance.PollutionLevelMap;
			IHonamiStoryPollution honamiStoryPollution;
			int num2 = (pollutionLevelMap != null && pollutionLevelMap.TryGetValue(pollutionLevel2, out honamiStoryPollution)) ? honamiStoryPollution.MonsterEnhanceLevel : 0;
			if (pollutionLevel != 0 && pollutionLevel < pollutionLevel2 && num > 0L)
			{
				IHonamiStoryPollution honamiStoryPollution2;
				int num3 = (pollutionLevelMap != null && pollutionLevelMap.TryGetValue(pollutionLevel, out honamiStoryPollution2)) ? honamiStoryPollution2.MonsterEnhanceLevel : 0;
				HonamiStoryPollutionUpdateParams param = new HonamiStoryPollutionUpdateParams
				{
					PollutionLevel = pollutionLevel2,
					MonsterIncreaseLevel = num2 - num3
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryPollutionLevelUpdateView, param, null);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnHonamiStoryPollutionUpdate, num2);
		}

		// Token: 0x0603BCE7 RID: 244967 RVA: 0x00F29E14 File Offset: 0x00F28014
		private void OnHonamiStoryInstSettleNotify(HonamiStoryInstSettleNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			List<IHonamiStorySettleItemParams> list = new List<IHonamiStorySettleItemParams>();
			list.Add(new HonamiStorySettleItemParams
			{
				Name = "HonamiStory_EvacuationInterface_2",
				Value = Singleton<TimeUtil>.Instance.GetTimeString((double)message.UseTime)
			});
			list.Add(new HonamiStorySettleItemParams
			{
				Name = "HonamiStory_EvacuationInterface_8",
				Value = message.InnerCoin.ToString()
			});
			list.Add(new HonamiStorySettleItemParams
			{
				Name = "HonamiStory_EvacuationInterface_1",
				Value = message.ItemTotalValue.ToString()
			});
			int talentAdd = message.TalentAdd;
			if (talentAdd > 0)
			{
				list.Add(new HonamiStorySettleItemParams
				{
					Name = "HonamiStory_EvacuationInterface_3",
					Value = talentAdd.ToString()
				});
			}
			this.SetHonamiStoryLoadingInfoByResult(message.IsSuccess);
			if (message.IsSuccess)
			{
				HonamiStorySettleSuccessViewParams param = new HonamiStorySettleSuccessViewParams
				{
					DisplayItems = list,
					TotalReward = message.TotalValue,
					IsNewRecord = message.IsUpdateTotalValue
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySettleSuccessView, param, null);
				return;
			}
			HonamiStorySettleFailViewParams failParams = new HonamiStorySettleFailViewParams
			{
				DisplayItems = list,
				TotalReward = message.TotalValue,
				IsNewRecord = message.IsUpdateTotalValue,
				FailAddProportion = (int)Math.Round((double)message.FailAddProportion / 100.0)
			};
			if (!message.IsDeadSettle)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySettleFailView, failParams, null);
				return;
			}
			Singleton<UiManager>.Instance.ResetToBattleView(null);
			Action<bool> <>9__1;
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UiManager instance = Singleton<UiManager>.Instance;
				Action<bool> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate(bool _)
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySettleFailView, failParams, null);
					});
				}
				instance.ResetToBattleView(callback);
			}, 3000f, null, null, true, 1f);
		}

		// Token: 0x0603BCE8 RID: 244968 RVA: 0x00F29FCC File Offset: 0x00F281CC
		private void OnHonamiStoryInstTopTowerSettleNotify(HonamiStoryInstTopTowerSettleNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			int costItemId = 0;
			int costNum = 0;
			int dangerLevel = ModelBase<HonamiStoryModel>.Instance.DangerLevel;
			if (dangerLevel > 0)
			{
				HonamiStoryDangerLevel? config = ConfigHonamiStoryDangerLevelById.GetConfig(dangerLevel, true);
				if (config != null)
				{
					Dictionary<int, int> dictionary = config.Value.ConsumeItems();
					if (dictionary != null && dictionary.Count > 0)
					{
						using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
						{
							if (enumerator.MoveNext())
							{
								KeyValuePair<int, int> keyValuePair = enumerator.Current;
								costItemId = keyValuePair.Key;
								costNum = keyValuePair.Value;
							}
						}
					}
				}
			}
			List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
			list.Add(new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_217_ButtonText_0",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = delegate(int _)
				{
					this.SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType.LeaveTower);
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				}
			});
			bool needCost = costItemId > 0 && costNum > 0;
			List<string> list2 = new List<string>();
			if (needCost)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(costItemId, 0);
				string item = itemCountByConfigId.ToString();
				if (itemCountByConfigId < costNum)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#c25757>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(itemCountByConfigId);
					defaultInterpolatedStringHandler.AppendLiteral("</color>");
					item = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				list2.Add(item);
				string iconSmall = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(costItemId).IconSmall;
				string item2 = "<texture=" + iconSmall + "/>";
				list2.Add(item2);
			}
			Action <>9__2;
			list.Add(new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_133_ButtonText_1",
				DescriptionTextId = (needCost ? "Text_RemainText_Text" : null),
				DescriptionArgs = (needCost ? list2.Cast<object>().ToList<object>() : null),
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = delegate(int _)
				{
					if (needCost)
					{
						ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.HonamiStoryTowerRestart);
						Dictionary<int, Action> functionMap = confirmBoxDataNew.FunctionMap;
						int key = 2;
						Action value;
						if ((value = <>9__2) == null)
						{
							value = (<>9__2 = delegate()
							{
								if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(costItemId, 0) < costNum)
								{
									ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_InsufficientBalance", Array.Empty<object>());
									return;
								}
								this.SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType.Tower);
								ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon();
							});
						}
						functionMap.Add(key, value);
						ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
						return;
					}
					this.SetHonamiStoryLoadingInfoByTimingOnly(EHonamiStoryLoadingTimingType.Tower);
					ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon();
				}
			});
			List<RewardItemData> list3 = new List<RewardItemData>();
			foreach (Aki.Protocol.RewardItem rewardItem in message.RewardItems)
			{
				RewardItemData item3 = new RewardItemData(rewardItem.Id, rewardItem.Count, null, EDropItemType.Normal);
				list3.Add(item3);
			}
			List<IHonamiTowerRecordData> list4 = new List<IHonamiTowerRecordData>();
			list4.Add(new HonamiTowerRecordData
			{
				RecordName = "HonamiStory_EvacuationInterface_5",
				RecordValue = message.DangerLevel.ToString()
			});
			list4.Add(new HonamiTowerRecordData
			{
				RecordName = "HonamiStory_EvacuationInterface_6",
				RecordValue = message.PassFloor.ToString()
			});
			list4.Add(new HonamiTowerRecordData
			{
				RecordName = "HonamiStory_EvacuationInterface_7",
				RecordValue = Singleton<TimeUtil>.Instance.GetTimeString((double)message.UseTime)
			});
			IHonamiTowerRecordData[] array = new IHonamiTowerRecordData[list4.Count];
			for (int i = 0; i < list4.Count; i++)
			{
				array[i] = list4[i];
			}
			RewardItemData[] array2 = new RewardItemData[list3.Count];
			for (int j = 0; j < list3.Count; j++)
			{
				array2[j] = list3[j];
			}
			HonamiTowerSuccessData honamiTowerSuccessData = new HonamiTowerSuccessData
			{
				RecordItemList = array,
				RewardItemList = array2
			};
			ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(new ExploreRewardViewData
			{
				ConfigId = 3031,
				IsSuccess = true,
				ButtonInfoList = list,
				HonamiTowerSuccessData = honamiTowerSuccessData,
				IsBagFull = new bool?(false)
			});
		}

		// Token: 0x0603BCE9 RID: 244969 RVA: 0x00F2A3C0 File Offset: 0x00F285C0
		private void OnLeaveDungeon()
		{
			if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
			{
				HonamiStoryQuestDataBase curTrackTaskData = ModelBase<HonamiStoryModel>.Instance.CurTrackTaskData;
				if (curTrackTaskData != null)
				{
					global::LevelPlayInfo levelPlayInfo = curTrackTaskData.GetLevelPlayInfo();
					if (levelPlayInfo != null)
					{
						levelPlayInfo.ResetTrackPriorityOverride();
					}
				}
				ModelBase<HonamiStoryModel>.Instance.RemoveBackPack(2);
				ModelBase<HonamiStoryModel>.Instance.RemoveBackPack(3);
				ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnHonamiStoryLifeSupportChanged));
			}
		}

		// Token: 0x0603BCEA RID: 244970 RVA: 0x00F2A420 File Offset: 0x00F28620
		private void OnEnterDungeon(int _1, int _2)
		{
			if (HonamiStoryUtil.CheckInHonamiStoryDungeon())
			{
				ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.HonamiStoryLifeSupport, new TValueListener(this.OnHonamiStoryLifeSupportChanged), null);
			}
		}

		// Token: 0x0603BCEB RID: 244971 RVA: 0x00F2A444 File Offset: 0x00F28644
		private void OnWorldDoneAndCloseLoading()
		{
			if (ModelBase<HonamiStoryModel>.Instance.CacheShowSafeLeaveUpdate)
			{
				this.ShowSafeLeaveUpdate();
			}
			if (HonamiStoryUtil.CheckInHonamiStoryAreaDungeon())
			{
				Singleton<Log>.Instance.Info(ELogModule.HonamiStory, ELogAuthor.LRC, "OnWorldDoneAndCloseLoading 自动追踪第一个未完成的支线任务", default(ReadOnlySpan<ValueTuple<string, object>>));
				ModelBase<HonamiStoryModel>.Instance.InitSubQuestTrack();
			}
		}

		// Token: 0x0603BCEC RID: 244972 RVA: 0x00F2A493 File Offset: 0x00F28693
		private void OnHonamiStoryLifeSupportChanged(EFormationAttributeId attributeId, float newValue, float oldValue)
		{
			Singleton<EventSystem>.Instance.Emit<float, float>(EEventName.OnHonamiStoryLifeSupportChanged, oldValue, newValue);
		}

		// Token: 0x0603BCED RID: 244973 RVA: 0x00F2A4A8 File Offset: 0x00F286A8
		private void OnHonamiStoryMascotInfoUpdateNotify(HonamiStoryMascotInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).UpdateHonamiStoryMascotDataList(message.HonamiStoryMascotInfos.ToList<HonamiStoryMascotInfo>());
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMascotUnlockSet, null) ?? new HashSet<int>();
			foreach (HonamiStoryMascotInfo honamiStoryMascotInfo in message.HonamiStoryMascotInfos)
			{
				if (honamiStoryMascotInfo.Status == 1)
				{
					hashSet.Add(honamiStoryMascotInfo.HonamiStoryMascotId);
				}
			}
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryMascotUnlockSet, hashSet);
		}

		// Token: 0x0603BCEE RID: 244974 RVA: 0x00F2A540 File Offset: 0x00F28740
		public void SendHonamiStoryMascotRewardRequest(int mascotId, Action callback)
		{
			HonamiStoryMascotRewardRequest honamiStoryMascotRewardRequest = HonamiStoryMascotRewardRequest.Create();
			honamiStoryMascotRewardRequest.HonamiStoryMascotId = mascotId;
			Singleton<Net>.Instance.Call<HonamiStoryMascotRewardResponse>(ERequestMessageId.HonamiStoryMascotRewardRequest, honamiStoryMascotRewardRequest, delegate(HonamiStoryMascotRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25627, null, true, true);
					return;
				}
				ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).GetHonamiStoryMascotData(mascotId).UpdateState(EHonamiStoryCollectState.GotReward);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnHonamiStoryMascotRewardReceive, mascotId);
				callback();
			}, 0);
		}

		// Token: 0x0603BCEF RID: 244975 RVA: 0x00F2A590 File Offset: 0x00F28790
		private void OnHonamiStoryAreaInfoUpdateNotify(HonamiStoryAreaInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).UpdateHonamiStoryAreaDataList(message.HonamiStoryAreaInfo.ToList<HonamiStoryAreaInfo>());
		}

		// Token: 0x0603BCF0 RID: 244976 RVA: 0x00F2A5B0 File Offset: 0x00F287B0
		public void SendHonamiStoryAreaSecretRewardRequest(int areaSecretId, Action callback)
		{
			HonamiStoryAreaSecretRewardRequest honamiStoryAreaSecretRewardRequest = HonamiStoryAreaSecretRewardRequest.Create();
			honamiStoryAreaSecretRewardRequest.AreaSecretId = areaSecretId;
			Singleton<Net>.Instance.Call<HonamiStoryAreaSecretRewardResponse>(ERequestMessageId.HonamiStoryAreaSecretRewardRequest, honamiStoryAreaSecretRewardRequest, delegate(HonamiStoryAreaSecretRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26109, null, true, true);
					return;
				}
				ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).GetHonamiStoryAreaData(areaSecretId).UpdateCollectMascotState(EHonamiStoryCollectState.GotReward);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnHonamiStoryAreaSecretRewardReceive, areaSecretId);
				callback();
			}, 0);
		}

		// Token: 0x0603BCF1 RID: 244977 RVA: 0x00F2A600 File Offset: 0x00F28800
		[NullableContext(0)]
		public UniTask<bool> LeaveHonamiDungeon()
		{
			HonamiStoryController.<LeaveHonamiDungeon>d__31 <LeaveHonamiDungeon>d__;
			<LeaveHonamiDungeon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LeaveHonamiDungeon>d__.<>1__state = -1;
			<LeaveHonamiDungeon>d__.<>t__builder.Start<HonamiStoryController.<LeaveHonamiDungeon>d__31>(ref <LeaveHonamiDungeon>d__);
			return <LeaveHonamiDungeon>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCF2 RID: 244978 RVA: 0x00F2A63B File Offset: 0x00F2883B
		public bool CanOpenBackpack(EUiViewName viewName, object _)
		{
			return ModelBase<FunctionModel>.Instance.IsOpen(10102);
		}

		// Token: 0x0603BCF3 RID: 244979 RVA: 0x00F2A64C File Offset: 0x00F2884C
		private void OnHonamiStorySetFormationNotify(HonamiStorySetFormationNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			HonamiStoryPlayerBackpackData playerBackpackData = ModelBase<HonamiStoryModel>.Instance.GetPlayerBackpackData();
			playerBackpackData.RefreshEquipInfo(message.HonamiStoryRackInfos.ToList<HonamiStoryRackInfo>());
			if (message.EquipRack != null)
			{
				playerBackpackData.RefreshGridItemInfo(message.EquipRack.HonamiStoryBagItemInfos.ToList<HonamiStoryBagItemInfo>());
			}
			ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
		}

		// Token: 0x0603BCF4 RID: 244980 RVA: 0x00F2A69E File Offset: 0x00F2889E
		private void OnHonamiStoryBagInfoUpdateNotify(HonamiStoryBagInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.UpdateBackpackInfo(message);
			ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
		}

		// Token: 0x0603BCF5 RID: 244981 RVA: 0x00F2A6B8 File Offset: 0x00F288B8
		[NullableContext(0)]
		public UniTask<bool> SendHonamiStoryBagOperateRequest([Nullable(1)] List<HonamiStoryBagUpdateContext> updateContext)
		{
			HonamiStoryController.<SendHonamiStoryBagOperateRequest>d__35 <SendHonamiStoryBagOperateRequest>d__;
			<SendHonamiStoryBagOperateRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SendHonamiStoryBagOperateRequest>d__.updateContext = updateContext;
			<SendHonamiStoryBagOperateRequest>d__.<>1__state = -1;
			<SendHonamiStoryBagOperateRequest>d__.<>t__builder.Start<HonamiStoryController.<SendHonamiStoryBagOperateRequest>d__35>(ref <SendHonamiStoryBagOperateRequest>d__);
			return <SendHonamiStoryBagOperateRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCF6 RID: 244982 RVA: 0x00F2A6FC File Offset: 0x00F288FC
		public void RequestHonamiStoryEquipRole(List<int> roleList)
		{
			HonamiStoryEquipRoleRequest honamiStoryEquipRoleRequest = HonamiStoryEquipRoleRequest.Create();
			honamiStoryEquipRoleRequest.ActivityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
			honamiStoryEquipRoleRequest.RoleId.Add(roleList);
			Singleton<Net>.Instance.Call<HonamiStoryEquipRoleResponse>(ERequestMessageId.HonamiStoryEquipRoleRequest, honamiStoryEquipRoleRequest, delegate(HonamiStoryEquipRoleResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23706, null, true, true);
					return;
				}
				RepeatedField<int> roleId = response.RoleId;
				ModelBase<HonamiStoryModel>.Instance.UpdateRoleList(roleId.ToList<int>());
				Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryRoleEquipChanged);
				ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			}, 0);
		}

		// Token: 0x0603BCF7 RID: 244983 RVA: 0x00F2A75C File Offset: 0x00F2895C
		[NullableContext(0)]
		public UniTask<bool> SendHonamiStoryPickUpItemRequest(int backpackId, [Nullable(1)] HonamiStoryItemDataBase itemData, int position)
		{
			HonamiStoryController.<SendHonamiStoryPickUpItemRequest>d__37 <SendHonamiStoryPickUpItemRequest>d__;
			<SendHonamiStoryPickUpItemRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SendHonamiStoryPickUpItemRequest>d__.backpackId = backpackId;
			<SendHonamiStoryPickUpItemRequest>d__.itemData = itemData;
			<SendHonamiStoryPickUpItemRequest>d__.position = position;
			<SendHonamiStoryPickUpItemRequest>d__.<>1__state = -1;
			<SendHonamiStoryPickUpItemRequest>d__.<>t__builder.Start<HonamiStoryController.<SendHonamiStoryPickUpItemRequest>d__37>(ref <SendHonamiStoryPickUpItemRequest>d__);
			return <SendHonamiStoryPickUpItemRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCF8 RID: 244984 RVA: 0x00F2A7B0 File Offset: 0x00F289B0
		[NullableContext(0)]
		public UniTask<bool> HonamiStoryPickAndEquipRequest([Nullable(1)] HonamiStoryItemDataBase itemData, int pos)
		{
			HonamiStoryController.<HonamiStoryPickAndEquipRequest>d__38 <HonamiStoryPickAndEquipRequest>d__;
			<HonamiStoryPickAndEquipRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<HonamiStoryPickAndEquipRequest>d__.itemData = itemData;
			<HonamiStoryPickAndEquipRequest>d__.pos = pos;
			<HonamiStoryPickAndEquipRequest>d__.<>1__state = -1;
			<HonamiStoryPickAndEquipRequest>d__.<>t__builder.Start<HonamiStoryController.<HonamiStoryPickAndEquipRequest>d__38>(ref <HonamiStoryPickAndEquipRequest>d__);
			return <HonamiStoryPickAndEquipRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCF9 RID: 244985 RVA: 0x00F2A7FC File Offset: 0x00F289FC
		public void SendHonamiStoryDiscardItemRequest(HonamiStoryBagUpdateContext updateContext)
		{
			HonamiStoryDiscardItemRequest request = HonamiStoryDiscardItemRequest.Create();
			request.HonamiStoryBagUpdateContext = updateContext;
			Singleton<Net>.Instance.Call<HonamiStoryDiscardItemResponse>(ERequestMessageId.HonamiStoryDiscardItemRequest, request, delegate(HonamiStoryDiscardItemResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19926, null, true, true);
					return;
				}
				bool flag = updateContext.BackPackConfigId == 4;
				if (!flag && updateContext.BackPackConfigId != 3)
				{
					HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(2, false);
					using (IEnumerator<HonamiStoryBagUpdateInfo> enumerator = updateContext.HonamiStoryBagUpdateInfo.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo = enumerator.Current;
							HonamiStoryItemDataBase honamiStoryItemDataBase = (backPackData != null) ? backPackData.GetItemDataByInstanceId(honamiStoryBagUpdateInfo.ItemIncrId, true) : null;
							if (honamiStoryItemDataBase != null)
							{
								ModelBase<HonamiStoryModel>.Instance.ShowDiscardTips(honamiStoryItemDataBase);
								if (honamiStoryItemDataBase.GetItemType() == EHonamiStoryItemType.Plugin)
								{
									flag = true;
									break;
								}
							}
						}
						goto IL_105;
					}
				}
				foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo2 in updateContext.HonamiStoryBagUpdateInfo)
				{
					HonamiStoryItemDataBase equipItemDataByIncId = ModelBase<HonamiStoryModel>.Instance.GetEquipItemDataByIncId(honamiStoryBagUpdateInfo2.ItemIncrId);
					if (equipItemDataByIncId != null)
					{
						ModelBase<HonamiStoryModel>.Instance.ShowDiscardTips(equipItemDataByIncId);
					}
				}
				IL_105:
				ModelBase<HonamiStoryModel>.Instance.UpdateBackPackContext(new List<HonamiStoryBagUpdateContext>
				{
					request.HonamiStoryBagUpdateContext
				});
				Singleton<EventSystem>.Instance.Emit<HonamiStoryBagUpdateContext>(EEventName.OnHonamiStoryBackpackUpdate, updateContext);
				if (flag)
				{
					ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
				}
			}, 0);
		}

		// Token: 0x0603BCFA RID: 244986 RVA: 0x00F2A854 File Offset: 0x00F28A54
		private void OnHonamiStoryBagSizeUpdateNotify(HonamiStoryBagSizeUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			MapField<int, int> bagSize = message.BagSize;
			ModelBase<HonamiStoryModel>.Instance.UpdateBackpackSize(bagSize.ToDictionary<int, int>());
		}

		// Token: 0x0603BCFB RID: 244987 RVA: 0x00F2A878 File Offset: 0x00F28A78
		[NullableContext(0)]
		public UniTask<bool> RequestHonamiStoryUnlockSlot([Nullable(1)] HonamiStoryRoleEquipSlotData slotData, int rolePos)
		{
			HonamiStoryController.<RequestHonamiStoryUnlockSlot>d__41 <RequestHonamiStoryUnlockSlot>d__;
			<RequestHonamiStoryUnlockSlot>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestHonamiStoryUnlockSlot>d__.slotData = slotData;
			<RequestHonamiStoryUnlockSlot>d__.rolePos = rolePos;
			<RequestHonamiStoryUnlockSlot>d__.<>1__state = -1;
			<RequestHonamiStoryUnlockSlot>d__.<>t__builder.Start<HonamiStoryController.<RequestHonamiStoryUnlockSlot>d__41>(ref <RequestHonamiStoryUnlockSlot>d__);
			return <RequestHonamiStoryUnlockSlot>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCFC RID: 244988 RVA: 0x00F2A8C4 File Offset: 0x00F28AC4
		[return: Nullable(0)]
		public UniTask<bool> RequestHonamiStoryQuickUnloadAll(List<HonamiStoryItemDataBase> itemList, HashSet<int> posList, EHonamiStoryBackpack backpack)
		{
			HonamiStoryController.<RequestHonamiStoryQuickUnloadAll>d__42 <RequestHonamiStoryQuickUnloadAll>d__;
			<RequestHonamiStoryQuickUnloadAll>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestHonamiStoryQuickUnloadAll>d__.itemList = itemList;
			<RequestHonamiStoryQuickUnloadAll>d__.posList = posList;
			<RequestHonamiStoryQuickUnloadAll>d__.backpack = backpack;
			<RequestHonamiStoryQuickUnloadAll>d__.<>1__state = -1;
			<RequestHonamiStoryQuickUnloadAll>d__.<>t__builder.Start<HonamiStoryController.<RequestHonamiStoryQuickUnloadAll>d__42>(ref <RequestHonamiStoryQuickUnloadAll>d__);
			return <RequestHonamiStoryQuickUnloadAll>d__.<>t__builder.Task;
		}

		// Token: 0x0603BCFD RID: 244989 RVA: 0x00F2A918 File Offset: 0x00F28B18
		private void OnHonamiStoryPermanentTaskInfoUpdateNotify(HonamiStoryResidentTaskInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			activityData.UpdatePermanentTaskDataList(message.ConditionTasks.ToList<ConditionTask>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}

		// Token: 0x0603BCFE RID: 244990 RVA: 0x00F2A958 File Offset: 0x00F28B58
		public void SendHonamiStoryPermanentTaskRewardRequest(List<int> taskIds, Action callback)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			HonamiStoryResidentTaskRewardRequest honamiStoryResidentTaskRewardRequest = HonamiStoryResidentTaskRewardRequest.Create();
			honamiStoryResidentTaskRewardRequest.ActivityId = activityData.Id;
			honamiStoryResidentTaskRewardRequest.ResidentTaskIds.Add(taskIds);
			Singleton<Net>.Instance.Call<HonamiStoryResidentTaskRewardResponse>(ERequestMessageId.HonamiStoryResidentTaskRewardRequest, honamiStoryResidentTaskRewardRequest, delegate(HonamiStoryResidentTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29443, null, true, true);
					return;
				}
				foreach (int id in taskIds)
				{
					activityData.GetPermanentTaskData(id).UpdateState(EActivityTaskState.FinishedAndClaimed);
				}
				callback();
			}, 0);
		}

		// Token: 0x0603BCFF RID: 244991 RVA: 0x00F2A9D0 File Offset: 0x00F28BD0
		private void OnHonamiStoryLimitTaskInfoUpdateNotify(HonamiStoryLimitTaskInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			activityData.UpdateLimitTaskDataList(message.ConditionTasks.ToList<ConditionTask>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}

		// Token: 0x0603BD00 RID: 244992 RVA: 0x00F2AA10 File Offset: 0x00F28C10
		public void SendHonamiStoryLimitTaskRewardRequest(List<int> taskIds, Action callback)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			HonamiStoryLimitTaskRewardRequest honamiStoryLimitTaskRewardRequest = HonamiStoryLimitTaskRewardRequest.Create();
			honamiStoryLimitTaskRewardRequest.ActivityId = activityData.Id;
			honamiStoryLimitTaskRewardRequest.LimitTaskIds.Add(taskIds);
			Singleton<Net>.Instance.Call<HonamiStoryLimitTaskRewardResponse>(ERequestMessageId.HonamiStoryLimitTaskRewardRequest, honamiStoryLimitTaskRewardRequest, delegate(HonamiStoryLimitTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27509, null, true, true);
					return;
				}
				foreach (int id in taskIds)
				{
					activityData.GetLimitTaskData(id).UpdateState(EActivityTaskState.FinishedAndClaimed);
				}
				callback();
			}, 0);
		}

		// Token: 0x0603BD01 RID: 244993 RVA: 0x00F2AA88 File Offset: 0x00F28C88
		public void OnHonamiStoryScoreRewardInfoUpdateNotify(HonamiStoryScoreRewardInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			activityData.UpdateScoreRewardDataList(message.HonamiStoryScoreRewardInfos.ToList<HonamiStoryScoreRewardInfo>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
		}

		// Token: 0x0603BD02 RID: 244994 RVA: 0x00F2AAC8 File Offset: 0x00F28CC8
		public void SendHonamiStoryScoreRewardRequest(List<int> scoreRewardIds, Action callback)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			HonamiStoryScoreRewardRequest honamiStoryScoreRewardRequest = HonamiStoryScoreRewardRequest.Create();
			honamiStoryScoreRewardRequest.ActivityId = activityData.Id;
			honamiStoryScoreRewardRequest.ScoreRewardId.Add(scoreRewardIds);
			Singleton<Net>.Instance.Call<HonamiStoryScoreRewardResponse>(ERequestMessageId.HonamiStoryScoreRewardRequest, honamiStoryScoreRewardRequest, delegate(HonamiStoryScoreRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19907, null, true, true);
					return;
				}
				HonamiStoryActivityData activityData2 = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
				foreach (int scoreRewardId in scoreRewardIds)
				{
					activityData2.GetScoreRewardData(scoreRewardId).UpdateState(EHonamiStoryCollectState.GotReward);
				}
				callback();
			}, 0);
		}

		// Token: 0x0603BD03 RID: 244995 RVA: 0x00F2AB38 File Offset: 0x00F28D38
		private void OnHonamiStoryAddWeaponNotify(HonamiStoryAddWeaponNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.UpdateWeaponDataList(message.WeaponIds.ToList<int>());
			List<RewardItemData> list = new List<RewardItemData>();
			foreach (int num in message.WeaponIds)
			{
				HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, null) ?? new HashSet<int>();
				hashSet.Add(num);
				LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, hashSet);
				HonamiStoryWeaponData weaponData = ModelBase<HonamiStoryModel>.Instance.GetWeaponData(num);
				if (weaponData != null && weaponData.IsShowReward)
				{
					RewardItemData item = new RewardItemData(num, 1, null, EDropItemType.Normal);
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				this.OpenHonamiWeaponRewardView(list);
			}
		}

		// Token: 0x0603BD04 RID: 244996 RVA: 0x00F2AC08 File Offset: 0x00F28E08
		public void SendHonamiStoryWeaponDressRequest(int selectWeaponId, int selectPosition, Action callback)
		{
			HonamiStoryWeaponDressRequest honamiStoryWeaponDressRequest = HonamiStoryWeaponDressRequest.Create();
			honamiStoryWeaponDressRequest.WeaponItemId = selectWeaponId;
			honamiStoryWeaponDressRequest.RackIndex = selectPosition;
			honamiStoryWeaponDressRequest.ActivityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
			Singleton<Net>.Instance.Call<HonamiStoryWeaponDressResponse>(ERequestMessageId.HonamiStoryWeaponDressRequest, honamiStoryWeaponDressRequest, delegate(HonamiStoryWeaponDressResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20134, null, true, true);
					return;
				}
				int weaponItemId = response.WeaponItemId;
				int rackIndex = response.RackIndex;
				HonamiStoryRoleEquipData weaponEquipState = ModelBase<HonamiStoryModel>.Instance.GetWeaponEquipState(weaponItemId);
				if (weaponEquipState != null)
				{
					int position = weaponEquipState.GetPosition();
					HonamiStoryRoleEquipData roleEquipDataByPosition = ModelBase<HonamiStoryModel>.Instance.GetRoleEquipDataByPosition(rackIndex);
					int weaponId = (roleEquipDataByPosition != null) ? roleEquipDataByPosition.GetWeaponId() : 0;
					ModelBase<HonamiStoryModel>.Instance.UpdateWeaponByPosition(weaponId, position);
				}
				ModelBase<HonamiStoryModel>.Instance.UpdateWeaponByPosition(weaponItemId, rackIndex);
				callback();
				Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryRoleEquipChanged);
				ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			}, 0);
		}

		// Token: 0x0603BD05 RID: 244997 RVA: 0x00F2AC63 File Offset: 0x00F28E63
		private void OnHonamiStoryItemCollectionInfoUpdateNotify(HonamiStoryItemCollectionInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).UpdateItemCollectionDataList(message.HonamiStoryItemCollectionInfos.ToList<HonamiStoryItemCollectionInfo>());
		}

		// Token: 0x0603BD06 RID: 244998 RVA: 0x00F2AC80 File Offset: 0x00F28E80
		public void SendHonamiStoryItemEnterRequest(bool isTower, int dangerLv, bool isBuy)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			int count = activityData.GetHonamiStoryAreaDataList().Count;
			if (!isTower && dangerLv <= count && !activityData.GetHonamiStoryAreaData(dangerLv).IsAreaCanEnter)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_LevelUnlockedPrompt", Array.Empty<object>());
				return;
			}
			HonamiStoryEnterCtx honamiStoryEnterCtx = new HonamiStoryEnterCtx
			{
				IsUpTower = isTower,
				DangerLevel = dangerLv,
				BuySafeLeave = isBuy,
				ActivityId = activityData.Id
			};
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.HonamiStoryEnterCtx = honamiStoryEnterCtx;
			int[] allRoleIdList = ModelBase<HonamiStoryModel>.Instance.GetAllRoleIdList();
			int areaInstId = activityData.AreaInstId;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(areaInstId, allRoleIdList.ToList<int>(), 0, 0, null, null).ContinueWith(delegate(bool value)
			{
				ModelBase<HonamiStoryModel>.Instance.SetQuickAllDirty(true);
			});
		}

		// Token: 0x0603BD07 RID: 244999 RVA: 0x00F2AD54 File Offset: 0x00F28F54
		public void SendHonamiStoryItemCollectionRequest(List<int> itemCollectionIdList)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			HonamiStoryItemCollectionRequest honamiStoryItemCollectionRequest = HonamiStoryItemCollectionRequest.Create();
			honamiStoryItemCollectionRequest.HonamiStoryItemCollectionId.Add(itemCollectionIdList);
			honamiStoryItemCollectionRequest.ActivityId = activityData.Id;
			Singleton<Net>.Instance.Call<HonamiStoryItemCollectionResponse>(ERequestMessageId.HonamiStoryItemCollectionRequest, honamiStoryItemCollectionRequest, delegate(HonamiStoryItemCollectionResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27301, null, true, true);
					return;
				}
				if (response.HonamiStoryItemCollectionId.Count <= 0)
				{
					return;
				}
				foreach (int id in response.HonamiStoryItemCollectionId)
				{
					activityData.GetItemCollectionData(id).UpdateState(EHonamiStoryCollectState.GotReward);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryItemCollectGetReward);
			}, 0);
		}

		// Token: 0x0603BD08 RID: 245000 RVA: 0x00F2ADB8 File Offset: 0x00F28FB8
		public void SendHonamiStoryActivateTalentRequest(int talentId, Action callback)
		{
			HonamiStoryActivateTalentRequest honamiStoryActivateTalentRequest = HonamiStoryActivateTalentRequest.Create();
			honamiStoryActivateTalentRequest.TalentId = talentId;
			Singleton<Net>.Instance.Call<HonamiStoryActivateTalentResponse>(ERequestMessageId.HonamiStoryActivateTalentRequest, honamiStoryActivateTalentRequest, delegate(HonamiStoryActivateTalentResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27067, null, true, true);
					return;
				}
				callback();
			}, 0);
		}

		// Token: 0x0603BD09 RID: 245001 RVA: 0x00F2ADFC File Offset: 0x00F28FFC
		private void OnHonamiStoryTalentInfoUpdateNotify(HonamiStoryTalentInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.RefreshTalentInfos(message.HonamiStoryTalentInfos);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryTechNodeLevelUpdate);
		}

		// Token: 0x0603BD0A RID: 245002 RVA: 0x00F2AE1E File Offset: 0x00F2901E
		private void OnHonamiStoryTotalRevenueNotify(HonamiStoryTotalRevenueNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.SetTotalRevenueInternal(message.TotalRevenue);
		}

		// Token: 0x0603BD0B RID: 245003 RVA: 0x00F2AE30 File Offset: 0x00F29030
		private void OnHonamiStoryAreaTaskInfoRefreshNotify(HonamiStoryAreaTaskInfoRefreshNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).InitSubQuestTaskDataList(message.ConditionTasks);
		}

		// Token: 0x0603BD0C RID: 245004 RVA: 0x00F2AE48 File Offset: 0x00F29048
		private void OnHonamiStoryAreaTaskInfoUpdateNotify(HonamiStoryAreaTaskInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
			activityData.UpdateSubQuestTaskDataList(message.ConditionTasks.ToList<ConditionTask>());
			foreach (ConditionTask conditionTask in message.ConditionTasks)
			{
				HonamiStorySubQuestData subQuestTaskData = activityData.GetSubQuestTaskData(conditionTask.Id);
				if (subQuestTaskData != null && subQuestTaskData.IsFinished())
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryQuestFinishView, subQuestTaskData, null);
					ModelBase<HonamiStoryModel>.Instance.InitSubQuestTrack();
				}
			}
		}

		// Token: 0x0603BD0D RID: 245005 RVA: 0x00F2AEE0 File Offset: 0x00F290E0
		private void OnHonamiStoryRoleUpdateNotify(HonamiStoryRoleUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetPlayerBackpackData().RefreshRoleInfo(message.RoleId.ToList<int>());
		}

		// Token: 0x0603BD0E RID: 245006 RVA: 0x00F2AEFC File Offset: 0x00F290FC
		private void OnHonamiStoryLifeSupportNotify(HonamiStoryLifeSupportNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetPlayerData().SetLifeSupportLevel(message.LifeSupportLevel);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnHonamiStoryLifeSupportLevelUp);
		}

		// Token: 0x0603BD0F RID: 245007 RVA: 0x00F2AF23 File Offset: 0x00F29123
		private void OnHonamiStoryTopInfoNotify(HonamiStoryTopInfoNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<HonamiStoryModel>.Instance.GetActivityData(true).RefreshTowerData(message.HonamiStoryTopInfos.ToList<HonamiStoryTopInfo>());
		}

		// Token: 0x0603BD10 RID: 245008 RVA: 0x00F2AF40 File Offset: 0x00F29140
		[NullableContext(0)]
		public UniTask<bool> RequestHonamiStoryLifeSupportUp()
		{
			HonamiStoryController.<RequestHonamiStoryLifeSupportUp>d__62 <RequestHonamiStoryLifeSupportUp>d__;
			<RequestHonamiStoryLifeSupportUp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestHonamiStoryLifeSupportUp>d__.<>1__state = -1;
			<RequestHonamiStoryLifeSupportUp>d__.<>t__builder.Start<HonamiStoryController.<RequestHonamiStoryLifeSupportUp>d__62>(ref <RequestHonamiStoryLifeSupportUp>d__);
			return <RequestHonamiStoryLifeSupportUp>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD11 RID: 245009 RVA: 0x00F2AF7C File Offset: 0x00F2917C
		[NullableContext(0)]
		public UniTask<bool> RequestSwitchItem([Nullable(1)] HonamiStoryItemDataBase itemData, [Nullable(2)] HonamiStoryItemDataBase exchangeItemData, int position, int equipPosition, EHonamiStoryBackpack sourceBag, EHonamiStoryBackpack targetBag)
		{
			HonamiStoryController.<RequestSwitchItem>d__63 <RequestSwitchItem>d__;
			<RequestSwitchItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestSwitchItem>d__.itemData = itemData;
			<RequestSwitchItem>d__.exchangeItemData = exchangeItemData;
			<RequestSwitchItem>d__.position = position;
			<RequestSwitchItem>d__.equipPosition = equipPosition;
			<RequestSwitchItem>d__.sourceBag = sourceBag;
			<RequestSwitchItem>d__.targetBag = targetBag;
			<RequestSwitchItem>d__.<>1__state = -1;
			<RequestSwitchItem>d__.<>t__builder.Start<HonamiStoryController.<RequestSwitchItem>d__63>(ref <RequestSwitchItem>d__);
			return <RequestSwitchItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD12 RID: 245010 RVA: 0x00F2AFEC File Offset: 0x00F291EC
		[NullableContext(0)]
		public UniTask<bool> RequestSwitchInSameBag([Nullable(1)] HonamiStoryItemDataBase itemData, int position, EHonamiStoryBackpack bag)
		{
			HonamiStoryController.<RequestSwitchInSameBag>d__64 <RequestSwitchInSameBag>d__;
			<RequestSwitchInSameBag>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestSwitchInSameBag>d__.itemData = itemData;
			<RequestSwitchInSameBag>d__.position = position;
			<RequestSwitchInSameBag>d__.bag = bag;
			<RequestSwitchInSameBag>d__.<>1__state = -1;
			<RequestSwitchInSameBag>d__.<>t__builder.Start<HonamiStoryController.<RequestSwitchInSameBag>d__64>(ref <RequestSwitchInSameBag>d__);
			return <RequestSwitchInSameBag>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD13 RID: 245011 RVA: 0x00F2B040 File Offset: 0x00F29240
		[return: Nullable(0)]
		public UniTask<bool> RequestEquipFromPickUpBox(HonamiStoryItemDataBase itemData, HonamiStoryItemDataBase exchangeItemData, int equipPosition, int bagPosition)
		{
			HonamiStoryController.<RequestEquipFromPickUpBox>d__65 <RequestEquipFromPickUpBox>d__;
			<RequestEquipFromPickUpBox>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestEquipFromPickUpBox>d__.itemData = itemData;
			<RequestEquipFromPickUpBox>d__.exchangeItemData = exchangeItemData;
			<RequestEquipFromPickUpBox>d__.equipPosition = equipPosition;
			<RequestEquipFromPickUpBox>d__.bagPosition = bagPosition;
			<RequestEquipFromPickUpBox>d__.<>1__state = -1;
			<RequestEquipFromPickUpBox>d__.<>t__builder.Start<HonamiStoryController.<RequestEquipFromPickUpBox>d__65>(ref <RequestEquipFromPickUpBox>d__);
			return <RequestEquipFromPickUpBox>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD14 RID: 245012 RVA: 0x00F2B09C File Offset: 0x00F2929C
		public void RequestDiscardItem(HonamiStoryItemDataBase itemData, EHonamiStoryBackpack sourceBag)
		{
			HonamiStoryBagUpdateContext honamiStoryBagUpdateContext = HonamiStoryBagUpdateContext.Create();
			honamiStoryBagUpdateContext.BackPackConfigId = (int)sourceBag;
			HonamiStoryBagUpdateInfo honamiStoryItemRemoveInfo = HonamiStoryUtil.GetHonamiStoryItemRemoveInfo(itemData);
			honamiStoryBagUpdateContext.HonamiStoryBagUpdateInfo.Add(honamiStoryItemRemoveInfo);
			this.SendHonamiStoryDiscardItemRequest(honamiStoryBagUpdateContext);
		}

		// Token: 0x0603BD15 RID: 245013 RVA: 0x00F2B0D0 File Offset: 0x00F292D0
		[NullableContext(0)]
		public UniTask<bool> RequestHonamiStorySellItem([Nullable(1)] List<IHonamiStoryItemSellInfo> itemInfoList)
		{
			HonamiStoryController.<RequestHonamiStorySellItem>d__67 <RequestHonamiStorySellItem>d__;
			<RequestHonamiStorySellItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestHonamiStorySellItem>d__.itemInfoList = itemInfoList;
			<RequestHonamiStorySellItem>d__.<>1__state = -1;
			<RequestHonamiStorySellItem>d__.<>t__builder.Start<HonamiStoryController.<RequestHonamiStorySellItem>d__67>(ref <RequestHonamiStorySellItem>d__);
			return <RequestHonamiStorySellItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD16 RID: 245014 RVA: 0x00F2B114 File Offset: 0x00F29314
		[NullableContext(0)]
		public UniTask<bool> RequestHonamiStoryLockItem(int itemUid, EHonamiStoryBackpack backType, bool isLock)
		{
			HonamiStoryController.<RequestHonamiStoryLockItem>d__68 <RequestHonamiStoryLockItem>d__;
			<RequestHonamiStoryLockItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestHonamiStoryLockItem>d__.itemUid = itemUid;
			<RequestHonamiStoryLockItem>d__.backType = backType;
			<RequestHonamiStoryLockItem>d__.isLock = isLock;
			<RequestHonamiStoryLockItem>d__.<>1__state = -1;
			<RequestHonamiStoryLockItem>d__.<>t__builder.Start<HonamiStoryController.<RequestHonamiStoryLockItem>d__68>(ref <RequestHonamiStoryLockItem>d__);
			return <RequestHonamiStoryLockItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603BD17 RID: 245015 RVA: 0x00F2B168 File Offset: 0x00F29368
		private void OpenHonamiWeaponRewardView(List<RewardItemData> rewardItemDataList)
		{
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(1009, EUiViewName.HonamiWeaponRewardView, rewardItemDataList, null, null, null, null, null, true, false);
			if (rewardData == null)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiWeaponRewardView, rewardData, null);
		}
	}
}
