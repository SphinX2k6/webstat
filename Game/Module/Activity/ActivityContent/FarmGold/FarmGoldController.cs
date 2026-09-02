using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.View.InstanceEntrance;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FarmGold
{
	// Token: 0x02006850 RID: 26704
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FarmGoldController : ActivityControllerBase<FarmGoldController>
	{
		// Token: 0x060428CE RID: 272590 RVA: 0x011152CA File Offset: 0x011134CA
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x060428CF RID: 272591 RVA: 0x011152CC File Offset: 0x011134CC
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_FarmGoldMain";
		}

		// Token: 0x060428D0 RID: 272592 RVA: 0x011152D3 File Offset: 0x011134D3
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new FarmGoldSubView();
		}

		// Token: 0x060428D1 RID: 272593 RVA: 0x011152DA File Offset: 0x011134DA
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new FarmGoldData();
		}

		// Token: 0x060428D2 RID: 272594 RVA: 0x011152E1 File Offset: 0x011134E1
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x060428D3 RID: 272595 RVA: 0x011152E4 File Offset: 0x011134E4
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		}

		// Token: 0x060428D4 RID: 272596 RVA: 0x01115302 File Offset: 0x01113502
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		}

		// Token: 0x060428D5 RID: 272597 RVA: 0x01115320 File Offset: 0x01113520
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<FarmGoldLevelNotify>(ENotifyMessageId.FarmGoldLevelNotify, new Action<FarmGoldLevelNotify, Net.CallbackStatus>(this.FarmGoldLevelNotify));
			Singleton<Net>.Instance.Register<FarmGoldResultNotify>(ENotifyMessageId.FarmGoldResultNotify, new Action<FarmGoldResultNotify, Net.CallbackStatus>(this.OnFarmGoldResultNotify));
		}

		// Token: 0x060428D6 RID: 272598 RVA: 0x0111535A File Offset: 0x0111355A
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FarmGoldLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FarmGoldResultNotify);
		}

		// Token: 0x060428D7 RID: 272599 RVA: 0x0111537C File Offset: 0x0111357C
		private void OnLeaveInstanceDungeonConfirm()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsFarmGoldInstanceDungeon())
			{
				this.RequestExitDungeon();
			}
		}

		// Token: 0x060428D8 RID: 272600 RVA: 0x01115390 File Offset: 0x01113590
		public void RequestExitDungeon()
		{
			FarmGoldResultRequest message = new FarmGoldResultRequest();
			Singleton<Net>.Instance.Call<FarmGoldResultResponse>(ERequestMessageId.FarmGoldResultRequest, message, delegate(FarmGoldResultResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
				}
			}, 0);
		}

		// Token: 0x060428D9 RID: 272601 RVA: 0x011153D4 File Offset: 0x011135D4
		public void RequestSetDifficulty(int activityId, int insId, int diff)
		{
			FarmGoldLevelDiffRequest farmGoldLevelDiffRequest = FarmGoldLevelDiffRequest.Create();
			farmGoldLevelDiffRequest.ActivityId = activityId;
			farmGoldLevelDiffRequest.InstId = insId;
			farmGoldLevelDiffRequest.Diff = diff;
			Singleton<Net>.Instance.Call<FarmGoldLevelDiffResponse>(ERequestMessageId.FarmGoldLevelDiffRequest, farmGoldLevelDiffRequest, delegate(FarmGoldLevelDiffResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27303, null, true, true);
				}
				FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as FarmGoldData;
				if (farmGoldData != null)
				{
					farmGoldData.SetInsDifficult(insId, diff);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRefreshInstancedRecommendLevel);
			}, 0);
		}

		// Token: 0x060428DA RID: 272602 RVA: 0x01115444 File Offset: 0x01113644
		private void FarmGoldLevelNotify(FarmGoldLevelNotify notify, [Nullable(2)] Net.CallbackStatus status = null)
		{
			FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as FarmGoldData;
			if (farmGoldData == null)
			{
				return;
			}
			if (notify.LevelPlayTasks != null)
			{
				farmGoldData.RefreshLevelData(notify.LevelPlayTasks);
			}
			farmGoldData.PhraseRewardInfo();
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
			{
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, farmGoldData.GetRewardViewData());
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.FarmGoldRefreshRewardRedDot, notify.ActivityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, notify.ActivityId);
		}

		// Token: 0x060428DB RID: 272603 RVA: 0x011154D8 File Offset: 0x011136D8
		public void RequestFarmGoldPoint(int activityId, List<int> ids)
		{
			if (ids == null || ids.Count <= 0)
			{
				return;
			}
			FarmGoldPointRepeatedRequest farmGoldPointRepeatedRequest = FarmGoldPointRepeatedRequest.Create();
			farmGoldPointRepeatedRequest.ActivityId = activityId;
			farmGoldPointRepeatedRequest.Ids.AddRange(ids);
			Singleton<Net>.Instance.Call<FarmGoldPointRepeatedResponse>(ERequestMessageId.FarmGoldPointRepeatedRequest, farmGoldPointRepeatedRequest, delegate(FarmGoldPointRepeatedResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28751, null, true, true);
					return;
				}
				if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as FarmGoldData;
					if (farmGoldData != null)
					{
						farmGoldData.AddFinishPointId(ids);
					}
					if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
					{
						Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, farmGoldData.GetRewardPopUpViewData());
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.FarmGoldRefreshRewardRedDot, activityId);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
				}
			}, 0);
		}

		// Token: 0x060428DC RID: 272604 RVA: 0x01115550 File Offset: 0x01113750
		public void RequestFarmGoldLevelPlay(int activityId, List<int> instIds)
		{
			if (instIds == null || instIds.Count <= 0)
			{
				return;
			}
			FarmGoldLevelPlayRepeatedRequest farmGoldLevelPlayRepeatedRequest = FarmGoldLevelPlayRepeatedRequest.Create();
			farmGoldLevelPlayRepeatedRequest.ActivityId = activityId;
			farmGoldLevelPlayRepeatedRequest.InstIdList.AddRange(instIds);
			Singleton<Net>.Instance.Call<FarmGoldLevelPlayRepeatedResponse>(ERequestMessageId.FarmGoldLevelPlayRepeatedRequest, farmGoldLevelPlayRepeatedRequest, delegate(FarmGoldLevelPlayRepeatedResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21675, null, true, true);
					return;
				}
				if (response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as FarmGoldData;
					if (farmGoldData != null)
					{
						farmGoldData.FinishLevelReward(instIds);
					}
					if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
					{
						Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, farmGoldData.GetRewardPopUpViewData());
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.FarmGoldRefreshRewardRedDot, activityId);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
				}
			}, 0);
		}

		// Token: 0x060428DD RID: 272605 RVA: 0x011155C8 File Offset: 0x011137C8
		private void OnFarmGoldResultNotify(FarmGoldResultNotify notify, [Nullable(2)] Net.CallbackStatus status = null)
		{
			bool flag = notify.ErrorCode > Aki.Protocol.ErrorCode.Success;
			if (flag)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(notify.ErrorCode, 16808, null, true, true);
			}
			Action onClickQuit = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
			};
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_217_ButtonText_0",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					onClickQuit();
				}
			};
			Action onClickFight = delegate()
			{
				ControllerBase<InstanceDungeonController>.Instance.SingleInstReChallengeRequest();
			};
			RewardExploreConfirmButtonData item2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_217_ButtonText_1",
				DescriptionTextId = "FarmGoldHighestPoint",
				DescriptionArgs = new List<object>
				{
					notify.HisPoint.ToString()
				},
				IsTimeDownCloseView = false,
				IsClickedCloseView = false,
				OnClickedCallback = delegate(int _)
				{
					onClickFight();
				}
			};
			RewardExploreRecordData rewardExploreRecordData = new RewardExploreRecordData
			{
				TitleTextId = "FarmGoldCurrentPoint",
				Record = notify.CurPoint.ToString(),
				IsNewRecord = (notify.CurPoint >= notify.HisPoint)
			};
			ItemRewardController instance = ControllerBase<ItemRewardController>.Instance;
			int configId = flag ? 3021 : 3022;
			bool isSuccess = !flag && notify.Succ;
			List<RewardItemData> rewardItemDataList = null;
			IRewardExploreRecord exploreRecordInfo = flag ? null : rewardExploreRecordData;
			List<IRewardExploreBar> exploreBarDataList = null;
			List<IRewardExploreConfirmButton> buttonInfoList;
			if (!flag)
			{
				List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
				list.Add(item);
				buttonInfoList = list;
				list.Add(item2);
			}
			else
			{
				(buttonInfoList = new List<IRewardExploreConfirmButton>()).Add(item);
			}
			instance.OpenExploreRewardView(configId, isSuccess, rewardItemDataList, exploreRecordInfo, exploreBarDataList, buttonInfoList, null, null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x060428DE RID: 272606 RVA: 0x01115790 File Offset: 0x01113990
		[NullableContext(0)]
		public UniTask<bool> OpenDefaultFarmGoldView()
		{
			FarmGoldController.<OpenDefaultFarmGoldView>d__16 <OpenDefaultFarmGoldView>d__;
			<OpenDefaultFarmGoldView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenDefaultFarmGoldView>d__.<>4__this = this;
			<OpenDefaultFarmGoldView>d__.<>1__state = -1;
			<OpenDefaultFarmGoldView>d__.<>t__builder.Start<FarmGoldController.<OpenDefaultFarmGoldView>d__16>(ref <OpenDefaultFarmGoldView>d__);
			return <OpenDefaultFarmGoldView>d__.<>t__builder.Task;
		}

		// Token: 0x060428DF RID: 272607 RVA: 0x011157D4 File Offset: 0x011139D4
		[NullableContext(0)]
		public UniTask<bool> OpenFarmGoldEntranceView(int activityId)
		{
			FarmGoldController.<OpenFarmGoldEntranceView>d__17 <OpenFarmGoldEntranceView>d__;
			<OpenFarmGoldEntranceView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenFarmGoldEntranceView>d__.<>4__this = this;
			<OpenFarmGoldEntranceView>d__.activityId = activityId;
			<OpenFarmGoldEntranceView>d__.<>1__state = -1;
			<OpenFarmGoldEntranceView>d__.<>t__builder.Start<FarmGoldController.<OpenFarmGoldEntranceView>d__17>(ref <OpenFarmGoldEntranceView>d__);
			return <OpenFarmGoldEntranceView>d__.<>t__builder.Task;
		}

		// Token: 0x060428E0 RID: 272608 RVA: 0x01115820 File Offset: 0x01113A20
		public void OpenTempFarmGoldEntranceView()
		{
			FarmGoldData activityData = this.CreateTempActivityData();
			ActivityInstanceEntranceData param = this.CreateViewData(activityData);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityInstanceEntranceView, param, null);
		}

		// Token: 0x060428E1 RID: 272609 RVA: 0x01115850 File Offset: 0x01113A50
		private FarmGoldData CreateTempActivityData()
		{
			FarmGoldData farmGoldData = new FarmGoldData();
			ActivityData activityData = new ActivityData
			{
				Id = 100805001,
				Type = ActivityType.FarmGold
			};
			activityData.FarmGoldInfo = new FarmGoldInfo();
			foreach (FarmGoldActivity farmGoldActivity in ConfigBase<FarmGoldConfig>.Instance.GetAllFarmGoldActivity())
			{
				FarmGoldLevelPlayInfo item = new FarmGoldLevelPlayInfo
				{
					InstId = farmGoldActivity.InstId,
					Point = 0,
					StartTime = 0,
					IsOpen = true,
					LevelRewardGet = false,
					Difficulty = 1
				};
				activityData.FarmGoldInfo.LevelPlayTasks.Add(item);
			}
			farmGoldData.Init(activityData);
			farmGoldData.Phrase(activityData);
			return farmGoldData;
		}

		// Token: 0x060428E2 RID: 272610 RVA: 0x0111591C File Offset: 0x01113B1C
		private ActivityInstanceEntranceData CreateViewData(FarmGoldData activityData)
		{
			ActivityEntrancePointData activityEntrancePointData = ActivityEntrancePointData.Create(activityData.GetCurrentFullScore(), 0, new ERedDotName?(ERedDotName.FarmGoldReward), activityData.Id, activityData.GetRewardViewData(), new Func<string>(activityData.GetScoreDesc), delegate
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, activityData.GetRewardPopUpViewData(), delegate(bool success, int viewId)
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.ActivityInstanceEntranceView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				});
			});
			ActivityEntranceDescInfoData activityEntranceDescInfoData = ActivityEntranceDescInfoData.Create(new Func<int, string>(activityData.GetLevelNameTextByIndex), new Func<int, string>(activityData.GetLevelDescTextByIndex), new Func<int, List<int>>(activityData.GetLevelRecommendElementByIndex));
			string farmGoldEntranceName = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldEntranceName();
			string farmGoldEntranceSpritePath = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldEntranceSpritePath();
			int farmGoldEntranceHelpId = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldEntranceHelpId();
			ActivityEntranceCaptionItemData activityEntranceCaptionItemData = ActivityEntranceCaptionItemData.Create(farmGoldEntranceName, farmGoldEntranceSpritePath, farmGoldEntranceHelpId);
			List<ActivityEntranceSelectItemBaseData> list = new List<ActivityEntranceSelectItemBaseData>();
			List<FarmGoldLevelData> allLevelData = activityData.GetAllLevelData();
			Action<int> <>9__7;
			for (int i = 0; i < allLevelData.Count; i++)
			{
				int num = i;
				ActivityEntranceSelectItemSubData[] subData = null;
				Func<int, string> getNameFunc = new Func<int, string>(activityData.GetLevelNameTextByIndex);
				Func<int, string> getDescFunc = new Func<int, string>(activityData.GetLevelDescTextByIndex);
				Func<int, string> getSubTitleFunc = new Func<int, string>(activityData.GetLevelSubTitleTextByIndex);
				Func<int, bool> getLockStateFunc = new Func<int, bool>(activityData.GetLevelLockStateByIndex);
				Func<int, int> getInstanceDungeonIdFunc = new Func<int, int>(activityData.GetLevelInstanceDungeonIdByIndex);
				Func<int, string> getUnlockDescFunc = new Func<int, string>(activityData.GetLevelUnlockTextByIndex);
				Func<int, bool> getFinishStateFunc = new Func<int, bool>(activityData.GetLevelFinishStateByIndex);
				Func<int, int> getRecommendLevelFunc = new Func<int, int>(activityData.GetLevelRecommendLevelByIndex);
				Func<int, int> getDefaultDifficultIndex = new Func<int, int>(activityData.GetLevelDifficultIndexByIndex);
				Func<int, string> getBgPathFunc = new Func<int, string>(activityData.GetLevelBgByIndex);
				Action<int> clickCallBack;
				if ((clickCallBack = <>9__7) == null)
				{
					clickCallBack = (<>9__7 = delegate(int dataIndex)
					{
						FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(dataIndex);
						if (levelDataByIndex == null)
						{
							return;
						}
						levelDataByIndex.SaveOpenState();
					});
				}
				ActivityEntranceSelectItemBaseData item = ActivityEntranceSelectItemBaseData.Create(num, num, subData, getNameFunc, getDescFunc, getSubTitleFunc, getLockStateFunc, getInstanceDungeonIdFunc, getUnlockDescFunc, getFinishStateFunc, getRecommendLevelFunc, getDefaultDifficultIndex, getBgPathFunc, clickCallBack, new Func<int, bool>(activityData.GetLevelRedDotStateByIndex));
				list.Add(item);
			}
			ActivityEntranceSelectItemData selectData = ActivityEntranceSelectItemData.Create(list);
			IReadOnlyList<FarmGoldDifficulty> allDifficultData = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldAllDifficult();
			List<ActivityEntranceDropDownContentData> list2 = new List<ActivityEntranceDropDownContentData>();
			Func<int, string> <>9__8;
			Func<int, string> <>9__9;
			Func<int, int> <>9__10;
			Action<ActivityInstanceEntranceData, int> <>9__11;
			for (int j = 0; j < allDifficultData.Count; j++)
			{
				int dataIndex2 = j;
				Func<int, string> getTogOptionTextFunc;
				if ((getTogOptionTextFunc = <>9__8) == null)
				{
					getTogOptionTextFunc = (<>9__8 = delegate(int dataIndex)
					{
						int id = allDifficultData[dataIndex].Id;
						return activityData.GetDifficultTogText(id);
					});
				}
				Func<int, string> getDropDownTextFunc;
				if ((getDropDownTextFunc = <>9__9) == null)
				{
					getDropDownTextFunc = (<>9__9 = delegate(int dataIndex)
					{
						int id = allDifficultData[dataIndex].Id;
						return activityData.GetDifficultTitle(id);
					});
				}
				Func<int, int> getRecommendLevelFunc2;
				if ((getRecommendLevelFunc2 = <>9__10) == null)
				{
					getRecommendLevelFunc2 = (<>9__10 = delegate(int dataIndex)
					{
						int id = allDifficultData[dataIndex].Id;
						return activityData.GetDifficultRecommendLevel(id);
					});
				}
				Action<ActivityInstanceEntranceData, int> getOnSelectCallBack;
				if ((getOnSelectCallBack = <>9__11) == null)
				{
					getOnSelectCallBack = (<>9__11 = delegate(ActivityInstanceEntranceData entranceData, int dataIndex)
					{
						int id = allDifficultData[dataIndex].Id;
						ActivityEntranceSelectItemData activityEntranceSelectItemData = entranceData.GetActivityEntranceSelectItemData();
						int? num2;
						if (activityEntranceSelectItemData == null)
						{
							num2 = null;
						}
						else
						{
							ActivityEntranceItemData currentSelectData2 = activityEntranceSelectItemData.GetCurrentSelectData();
							num2 = ((currentSelectData2 != null) ? new int?(currentSelectData2.GetInstanceDungeonId()) : null);
						}
						int? num3 = num2;
						int valueOrDefault = num3.GetValueOrDefault();
						this.RequestSetDifficulty(activityData.Id, valueOrDefault, id);
					});
				}
				ActivityEntranceDropDownContentData item2 = ActivityEntranceDropDownContentData.Create(dataIndex2, getTogOptionTextFunc, getDropDownTextFunc, getRecommendLevelFunc2, getOnSelectCallBack);
				list2.Add(item2);
			}
			ActivityEntranceItemData currentSelectData = selectData.GetCurrentSelectData();
			int instId = (currentSelectData != null) ? currentSelectData.GetInstanceDungeonId() : 0;
			FarmGoldLevelData levelInfoByInstId = activityData.GetLevelInfoByInstId(instId);
			ActivityEntranceDropDownData activityEntranceDropDownData = ActivityEntranceDropDownData.Create(list2.ToArray(), (levelInfoByInstId != null) ? levelInfoByInstId.GetSelectDifficultIndex() : 0);
			ActivityEntranceMonsterPreviewData activityEntranceMonsterPreviewData = ActivityEntranceMonsterPreviewData.Create(delegate(int dataIndex)
			{
				FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(dataIndex);
				return ((levelDataByIndex != null) ? levelDataByIndex.GetMonsterTips() : null) ?? "";
			}, delegate(int dataIndex)
			{
				FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(dataIndex);
				return levelDataByIndex != null && levelDataByIndex.GetMonsterPreviewState();
			}, delegate(int dataIndex)
			{
				FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(dataIndex);
				if (levelDataByIndex == null)
				{
					return 0;
				}
				return levelDataByIndex.GetInstId();
			}, delegate(int dataIndex)
			{
				UiManager instance = Singleton<UiManager>.Instance;
				EUiViewName instanceDungeonMonsterPreView = EUiViewName.InstanceDungeonMonsterPreView;
				FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(dataIndex);
				instance.OpenView(instanceDungeonMonsterPreView, (levelDataByIndex != null) ? new int?(levelDataByIndex.GetInstId()) : null, null);
			});
			return ActivityInstanceEntranceData.Create(activityEntrancePointData, activityEntranceDescInfoData, selectData, activityEntranceCaptionItemData, activityEntranceDropDownData, activityEntranceMonsterPreviewData, delegate
			{
				ActivityEntranceItemData currentSelectData2 = selectData.GetCurrentSelectData();
				if (currentSelectData2 != null)
				{
					FarmGoldLevelData levelDataByIndex = activityData.GetLevelDataByIndex(currentSelectData2.GetSelectDataIndex());
					if (levelDataByIndex != null)
					{
						this.HandleDoubleConfirmSoloEnterDungeon(levelDataByIndex);
					}
				}
			});
		}

		// Token: 0x060428E3 RID: 272611 RVA: 0x01115C84 File Offset: 0x01113E84
		private void HandleDoubleConfirmSoloEnterDungeon(FarmGoldLevelData levelData)
		{
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = false;
			int instId = levelData.GetInstId();
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.IsDungeonArchiveActivate(instId) && ModelBase<InstanceDungeonEntranceModel>.Instance.HasDungeonArchive(instId))
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DungeonContinuePlayConfirm);
				Action value = delegate()
				{
					ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = true;
					this.HandleSoloEnterDungeon(levelData);
				};
				Action value2 = delegate()
				{
					this.HandleSoloEnterDungeon(levelData);
				};
				Action value3 = delegate()
				{
					ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
				};
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[2] = value;
				confirmBoxDataNew.FunctionMap[1] = value2;
				confirmBoxDataNew.FunctionMap[-1] = value3;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			this.HandleSoloEnterDungeon(levelData);
		}

		// Token: 0x060428E4 RID: 272612 RVA: 0x01115D6C File Offset: 0x01113F6C
		private void HandleSoloEnterDungeon(FarmGoldLevelData levelData)
		{
			int instId = levelData.GetInstId();
			ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId = instId;
			FarmGoldData.CurrentSelectEntranceId = levelData.GetInstanceEntranceId();
			ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId = levelData.GetInstanceEntranceId();
			ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
		}

		// Token: 0x060428E5 RID: 272613 RVA: 0x01115DB0 File Offset: 0x01113FB0
		public bool CheckInFarmGold()
		{
			InstanceDungeon? config = ConfigInstanceDungeonById.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId(), true);
			return config != null && config.Value.InstSubType == 25 && ControllerBase<GameModeController>.Instance.IsInInstance();
		}
	}
}
