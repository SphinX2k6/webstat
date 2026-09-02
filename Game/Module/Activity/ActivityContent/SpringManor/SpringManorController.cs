using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062FB RID: 25339
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SpringManorController : ActivityControllerBase<SpringManorController>
	{
		// Token: 0x0603FB11 RID: 260881 RVA: 0x01053AB3 File Offset: 0x01051CB3
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603FB12 RID: 260882 RVA: 0x01053AB5 File Offset: 0x01051CB5
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_Spring26ActivityEntry";
		}

		// Token: 0x0603FB13 RID: 260883 RVA: 0x01053ABC File Offset: 0x01051CBC
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new SpringManorSubView();
		}

		// Token: 0x0603FB14 RID: 260884 RVA: 0x01053AC3 File Offset: 0x01051CC3
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new SpringManorData();
		}

		// Token: 0x0603FB15 RID: 260885 RVA: 0x01053ACA File Offset: 0x01051CCA
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603FB16 RID: 260886 RVA: 0x01053AD0 File Offset: 0x01051CD0
		public void RequestExhibitionSave(List<EntityItemBundleInfo> bundleInfos)
		{
			ExhibitionItemSaveRequest exhibitionItemSaveRequest = ExhibitionItemSaveRequest.Create();
			exhibitionItemSaveRequest.EntityItemBundleInfos.AddRange(bundleInfos);
			Singleton<Net>.Instance.Call<ExhibitionItemSaveResponse>(ERequestMessageId.ExhibitionItemSaveRequest, exhibitionItemSaveRequest, delegate(ExhibitionItemSaveResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.ExhibitionItemSaveResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603FB17 RID: 260887 RVA: 0x01053B20 File Offset: 0x01051D20
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<SpringFestivalUpdateNotify>(ENotifyMessageId.SpringFestivalUpdateNotify, new Action<SpringFestivalUpdateNotify, Net.CallbackStatus>(this.OnSpringFestivalUpdateNotify));
			Singleton<Net>.Instance.Register<SpringFestivalAtmosphereUpdateNotify>(ENotifyMessageId.SpringFestivalAtmosphereUpdateNotify, new Action<SpringFestivalAtmosphereUpdateNotify, Net.CallbackStatus>(this.OnAtmosphereUpdateNotify));
			Singleton<Net>.Instance.Register<BookItemUpdateNotify>(ENotifyMessageId.BookItemUpdateNotify, new Action<BookItemUpdateNotify, Net.CallbackStatus>(this.OnBookItemUpdateNotify));
		}

		// Token: 0x0603FB18 RID: 260888 RVA: 0x01053B81 File Offset: 0x01051D81
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SpringFestivalUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SpringFestivalAtmosphereUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BookItemUpdateNotify);
		}

		// Token: 0x0603FB19 RID: 260889 RVA: 0x01053BB4 File Offset: 0x01051DB4
		private void OnAtmosphereUpdateNotify(SpringFestivalAtmosphereUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			SpringManorData activityData = instance.ActivityData;
			int atmosphere = activityData.GetAtmosphere();
			int atmosphere2 = notify.Atmosphere;
			int atmosphereLevel = activityData.GetAtmosphereLevel();
			int atmosphereLevel2 = notify.AtmosphereLevel;
			int id = instance.IsMaxLevel(atmosphereLevel2) ? atmosphereLevel2 : (atmosphereLevel2 + 1);
			int atmosphereNeed = ConfigBase<SpringManorConfig>.Instance.GetLevelConfigById(id).Value.AtmosphereNeed;
			bool flag = instance.CheckInInstance();
			if (atmosphere < atmosphere2 && flag)
			{
				SpringManorAtmosphereLevelUpViewData param = new SpringManorAtmosphereLevelUpViewData
				{
					OldLevel = atmosphereLevel,
					NewLevel = atmosphereLevel2,
					OldAtmosphere = atmosphere,
					NewAtmosphere = atmosphere2,
					MaxAtmosphere = atmosphereNeed
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelUpView, param, null);
				bool flag2 = ConfigBase<SpringManorConfig>.Instance.GetLevelConfigById(atmosphereLevel2).Value.UnlockFunctionLength > 0;
				if (atmosphereLevel2 > atmosphereLevel && flag2)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorUnlockView, null, null);
				}
				int atmosphereLevelStage = instance.GetAtmosphereLevelStage(atmosphereLevel);
				int atmosphereLevelStage2 = instance.GetAtmosphereLevelStage(atmosphereLevel2);
				if (atmosphereLevelStage2 > atmosphereLevelStage)
				{
					AtmosphereStageUpParam atmosphereStageUpParam = new AtmosphereStageUpParam
					{
						OldAtmosphere = atmosphere,
						NewAtmosphere = atmosphere2,
						OldLevel = atmosphereLevel,
						NewLevel = atmosphereLevel2,
						Stage = atmosphereLevelStage2
					};
					instance.SetAtmosphereStageUpParam(atmosphereStageUpParam);
				}
			}
			SpringManorModel instance2 = ModelBase<SpringManorModel>.Instance;
			if (instance2 != null)
			{
				instance2.ActivityData.OnAtmosphereUpdateNotify(atmosphere2, atmosphereLevel2);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.SpringManorAtmosphereUpdate);
		}

		// Token: 0x0603FB1A RID: 260890 RVA: 0x01053D24 File Offset: 0x01051F24
		private void OnSpringFestivalUpdateNotify(SpringFestivalUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify.FunctionId != 0)
			{
				this.OnFunctionOpenNotify(notify.FunctionId);
				return;
			}
			if (notify.Task != null)
			{
				this.OnTaskUpdateNotify(notify.Task);
				return;
			}
			if (notify.SkipEntry != null)
			{
				this.OnSkipEntryUpdateNotify(notify.SkipEntry);
				return;
			}
			if (notify.JokerLevelInfos != null)
			{
				this.OnJokerLevelUpdateNotify(notify.JokerLevelInfos);
			}
		}

		// Token: 0x0603FB1B RID: 260891 RVA: 0x01053D84 File Offset: 0x01051F84
		private void OnSkipEntryUpdateNotify(SpringSkipEntry skipEntry)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ActivityData.OnSkipEntryUpdateNotify(skipEntry);
		}

		// Token: 0x0603FB1C RID: 260892 RVA: 0x01053D9B File Offset: 0x01051F9B
		private void OnJokerLevelUpdateNotify(GuessJokerLevelInfoArray jokerLevelInfos)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ActivityData.UpdateGuessJokerGameData(jokerLevelInfos.GuessJokerLevelInfos);
		}

		// Token: 0x0603FB1D RID: 260893 RVA: 0x01053DB8 File Offset: 0x01051FB8
		private void OnFunctionOpenNotify(int functionId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance != null)
			{
				instance.ActivityData.OnFunctionUpdateNotify(functionId);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.SpringManorFunctionOpenNotify);
			if (SpringManorDefine.furnitureFunctionTypeList.Contains((ESpringFunctionType)functionId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.FurnitureFunctionOpenNotify, functionId);
			}
		}

		// Token: 0x0603FB1E RID: 260894 RVA: 0x01053E09 File Offset: 0x01052009
		private void OnTaskUpdateNotify(ConditionTask task)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance != null)
			{
				instance.ActivityData.OnTaskUpdateNotify(task);
			}
			this.UpdateRewardTrack();
			Singleton<EventSystem>.Instance.Emit(EEventName.SpringManorTaskUpdateNotify);
		}

		// Token: 0x0603FB1F RID: 260895 RVA: 0x01053E38 File Offset: 0x01052038
		[NullableContext(2)]
		public void RequestTaskRewardReceive(int tabId, Action finishCallback = null)
		{
			SpringFestivalTaskRewardRequest springFestivalTaskRewardRequest = SpringFestivalTaskRewardRequest.Create();
			springFestivalTaskRewardRequest.ActivityId = ModelBase<SpringManorModel>.Instance.ActivityData.Id;
			List<int> canClaimedTaskIdList = ModelBase<SpringManorModel>.Instance.ActivityData.GetTabCanClaimableTaskId(tabId);
			springFestivalTaskRewardRequest.TaskIds.AddRange(canClaimedTaskIdList);
			Singleton<Net>.Instance.Call<SpringFestivalTaskRewardResponse>(ERequestMessageId.SpringFestivalTaskRewardRequest, springFestivalTaskRewardRequest, delegate(SpringFestivalTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.SpringFestivalTaskRewardResponse, null, true, true);
					return;
				}
				SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
				if (instance != null)
				{
					instance.ActivityData.OnRewardTaskClaimed(canClaimedTaskIdList);
				}
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			}, 0);
		}

		// Token: 0x0603FB20 RID: 260896 RVA: 0x01053EB4 File Offset: 0x010520B4
		[NullableContext(2)]
		public void RequestScoreRewardReceive(Action finishCallback = null)
		{
			SpringFestivalScoreRewardRequest springFestivalScoreRewardRequest = SpringFestivalScoreRewardRequest.Create();
			springFestivalScoreRewardRequest.ActivityId = ModelBase<SpringManorModel>.Instance.ActivityData.Id;
			List<int> canClaimedScoreIdList = ModelBase<SpringManorModel>.Instance.ActivityData.GetCanClaimedScoreRewardList();
			springFestivalScoreRewardRequest.ScoreIds.AddRange(canClaimedScoreIdList);
			Singleton<Net>.Instance.Call<SpringFestivalScoreRewardResponse>(ERequestMessageId.SpringFestivalScoreRewardRequest, springFestivalScoreRewardRequest, delegate(SpringFestivalScoreRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.SpringFestivalScoreRewardResponse, null, true, true);
					return;
				}
				SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
				if (instance != null)
				{
					instance.ActivityData.OnScoreRewardClaimed(canClaimedScoreIdList);
				}
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			}, 0);
		}

		// Token: 0x0603FB21 RID: 260897 RVA: 0x01053F2C File Offset: 0x0105212C
		[NullableContext(2)]
		public void RequestAtmosphereRewardReceive(Action finishCallback = null)
		{
			SpringFestivalAtmosphereRewardRequest springFestivalAtmosphereRewardRequest = SpringFestivalAtmosphereRewardRequest.Create();
			springFestivalAtmosphereRewardRequest.ActivityId = ModelBase<SpringManorModel>.Instance.ActivityData.Id;
			List<int> levelIdList = ModelBase<SpringManorModel>.Instance.GetCanClaimedLevelIdList();
			springFestivalAtmosphereRewardRequest.LevelIds.AddRange(levelIdList);
			Singleton<Net>.Instance.Call<SpringFestivalAtmosphereRewardResponse>(ERequestMessageId.SpringFestivalAtmosphereRewardRequest, springFestivalAtmosphereRewardRequest, delegate(SpringFestivalAtmosphereRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.SpringFestivalAtmosphereRewardResponse, null, true, true);
					return;
				}
				SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
				if (instance != null)
				{
					instance.ActivityData.OnAtmosphereLevelRewardUpdateNotify(levelIdList);
				}
				Action finishCallback2 = finishCallback;
				if (finishCallback2 == null)
				{
					return;
				}
				finishCallback2();
			}, 0);
		}

		// Token: 0x0603FB22 RID: 260898 RVA: 0x01053F9F File Offset: 0x0105219F
		public void RequestTrackQuest(int questId, bool isTrack)
		{
			if (ModelBase<SpringManorModel>.Instance.IsMainQuest(questId))
			{
				ControllerBase<QuestNewController>.Instance.RequestTrackQuest(questId, isTrack, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
				return;
			}
			if (isTrack)
			{
				this.TrackSubQuest(questId);
				return;
			}
			this.StopTrackSubQuest(questId);
		}

		// Token: 0x0603FB23 RID: 260899 RVA: 0x01053FD1 File Offset: 0x010521D1
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603FB24 RID: 260900 RVA: 0x0105400B File Offset: 0x0105220B
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x0603FB25 RID: 260901 RVA: 0x01054045 File Offset: 0x01052245
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorActivityOpenView, null, null);
		}

		// Token: 0x0603FB26 RID: 260902 RVA: 0x01054058 File Offset: 0x01052258
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			if (state != QuestState.Finish && state != QuestState.Delete)
			{
				return;
			}
			this.StopTrackSubQuest(questId);
		}

		// Token: 0x0603FB27 RID: 260903 RVA: 0x0105406A File Offset: 0x0105226A
		private void OnWorldDone()
		{
			if (ModelBase<SpringManorModel>.Instance.CheckInInstance())
			{
				this.SetLimitTag(true);
			}
		}

		// Token: 0x0603FB28 RID: 260904 RVA: 0x0105407F File Offset: 0x0105227F
		public void LeaveInstanceDungeonRequest()
		{
			this.SetLimitTag(false);
			this.ClearCustomTrack();
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
		}

		// Token: 0x0603FB29 RID: 260905 RVA: 0x0105409C File Offset: 0x0105229C
		private void SetLimitTag(bool enable)
		{
			this.SetPlayerTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止"], enable);
			this.SetPlayerTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.滑翔禁止"], enable);
			this.SetPlayerTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止上墙"], enable);
			this.SetPlayerTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.禁用探索工具轮盘"], enable);
		}

		// Token: 0x0603FB2A RID: 260906 RVA: 0x01054104 File Offset: 0x01052304
		private unsafe void SetPlayerTag(int tagId, bool enable)
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (!ControllerBase<FormationDataController>.Instance.IsPlayerExist(playerId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LJ;
				string message = "找不到当前玩家";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerId", playerId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TagName", GameplayTagUtils.GetNameByTagId(tagId));
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (enable)
			{
				if (!ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, tagId, true))
				{
					ControllerBase<FormationDataController>.Instance.AddPlayerTag(playerId, new int?(tagId));
					return;
				}
			}
			else if (ControllerBase<FormationDataController>.Instance.HasPlayerTag(playerId, tagId, true))
			{
				ControllerBase<FormationDataController>.Instance.RemovePlayerTag(playerId, new int?(tagId));
			}
		}

		// Token: 0x0603FB2B RID: 260907 RVA: 0x010541CC File Offset: 0x010523CC
		public void EnterBigWorldInstRequestAndUnTrackQuest()
		{
			global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
			if (curTrackedQuest != null && !ModelBase<SpringManorModel>.Instance.IsMainQuest(curTrackedQuest.Id))
			{
				ControllerBase<QuestNewController>.Instance.RequestTrackQuest(curTrackedQuest.Id, false, ERequestTrackOperate.Auto, ESetTrackReason.None, new Action(this.EnterBigWorldInstRequest));
				return;
			}
			this.EnterBigWorldInstRequest();
		}

		// Token: 0x0603FB2C RID: 260908 RVA: 0x01054220 File Offset: 0x01052420
		public void EnterBigWorldInstRequest()
		{
			EnterBigWorldInstRequest enterBigWorldInstRequest = Aki.Protocol.EnterBigWorldInstRequest.Create();
			EnterBigWorldInstContext enterBigWorldInstContext = EnterBigWorldInstContext.Create();
			enterBigWorldInstContext.SpringFestivalCtx = SpringFestivalCtx.Create();
			enterBigWorldInstContext.SpringFestivalCtx.ActivityId = ModelBase<SpringManorModel>.Instance.ActivityData.Id;
			enterBigWorldInstRequest.EnterBigWorldInstContext = enterBigWorldInstContext;
			Singleton<Net>.Instance.Call<EnterBigWorldInstResponse>(ERequestMessageId.EnterBigWorldInstRequest, enterBigWorldInstRequest, delegate(EnterBigWorldInstResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.EnterBigWorldInstResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603FB2D RID: 260909 RVA: 0x01054298 File Offset: 0x01052498
		public void SpringManorInputHandler(string actionName)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			SpringManorData springManorData = (instance != null) ? instance.ActivityData : null;
			if (springManorData == null)
			{
				return;
			}
			if (!(actionName == "切换角色1"))
			{
				if (!(actionName == "切换角色2"))
				{
					if (!(actionName == "切换角色3"))
					{
						return;
					}
					Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorRewardView, null, null);
					return;
				}
				else
				{
					if (!springManorData.IsFunctionUnlocked(ESpringFunctionType.DIY))
					{
						return;
					}
					ControllerBase<FurnitureController>.Instance.OpenFurnitureAreaSelectView();
					return;
				}
			}
			else
			{
				if (!springManorData.IsFunctionUnlocked(ESpringFunctionType.Gameplay))
				{
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorGameplayEntryView, null, null);
				return;
			}
		}

		// Token: 0x0603FB2E RID: 260910 RVA: 0x01054328 File Offset: 0x01052528
		private void OnBookItemUpdateNotify(BookItemUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			int num = 0;
			foreach (BookItemInfo bookItemInfo in response.BookItems)
			{
				int bookItemId = bookItemInfo.BookItemId;
				EBrochureState bookItemStateById = activityData.GetBookItemStateById(bookItemId);
				if (activityData != null)
				{
					activityData.SetBookItemDataById(bookItemId, bookItemInfo);
				}
				if (bookItemStateById == EBrochureState.Lock && bookItemInfo.BookItemState == BookItemState.BookItemUnlock)
				{
					num = bookItemId;
				}
			}
			if (num > 0)
			{
				this.OpenPropView(response.ActivityId, response.BrochureId, num);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBrochureBookItemStateUpdate);
		}

		// Token: 0x0603FB2F RID: 260911 RVA: 0x010543D8 File Offset: 0x010525D8
		private void OpenPropView(int activityId, int brochureId, int configId)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureById(brochureId) : null;
			if (brochure == null)
			{
				return;
			}
			if (!this.IsUnlockBrochureType((EBrochureType)brochure.Value.Type))
			{
				return;
			}
			EBrochureType type = (EBrochureType)brochure.Value.Type;
			if (type > EBrochureType.EasterEggBook)
			{
				if (type != EBrochureType.Brochure)
				{
					return;
				}
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SpringManorBrochureCompletedView))
				{
					return;
				}
				SpringManorBrochureCompletedViewOpenParam param = new SpringManorBrochureCompletedViewOpenParam
				{
					ConfigId = configId
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorBrochureCompletedView, param, null);
				return;
			}
			else
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SpringManorAlbumPropView))
				{
					return;
				}
				this.LatestUnlockBookItemId = configId;
				this.LatestUnlockBrochureId = brochureId;
				SpringManorAlbumPropViewOpenParam param2 = new SpringManorAlbumPropViewOpenParam
				{
					ActivityId = activityId,
					ConfigId = configId,
					BrochureId = brochureId
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAlbumPropView, param2, null);
				return;
			}
		}

		// Token: 0x0603FB30 RID: 260912 RVA: 0x010544BC File Offset: 0x010526BC
		private bool IsUnlockBrochureType(EBrochureType type)
		{
			if (type > EBrochureType.EasterEggBook)
			{
				return type == EBrochureType.Brochure && ModelBase<SpringManorModel>.Instance.ActivityData.IsFunctionUnlocked(ESpringFunctionType.Publicity);
			}
			return ModelBase<SpringManorModel>.Instance.ActivityData.IsFunctionUnlocked(ESpringFunctionType.Draw);
		}

		// Token: 0x0603FB31 RID: 260913 RVA: 0x010544EC File Offset: 0x010526EC
		public void RequestBrochureReward(int activityId, EBrochureType brochureType, int bookItemId, bool isAllReward = false)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureByActivityAndType(activityId, brochureType) : null;
			if (brochure == null)
			{
				return;
			}
			SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			BrochureRewardRequest brochureRewardRequest = BrochureRewardRequest.Create();
			brochureRewardRequest.ActivityId = activityId;
			brochureRewardRequest.BrochureId = brochure.Value.Id;
			List<int> bookItemIds = new List<int>();
			if (isAllReward)
			{
				for (int i = 0; i < brochure.Value.BookItemIdsLength; i++)
				{
					int num = brochure.Value.BookItemIds(i);
					SpringManorData activityData3 = activityData;
					BookItemInfo bookItemInfo = (activityData3 != null) ? activityData3.GetBookItemDataById(num) : null;
					if (bookItemInfo != null && bookItemInfo.BookItemState == BookItemState.BookItemUnlock)
					{
						bookItemIds.Add(num);
					}
				}
			}
			else
			{
				bookItemIds.Add(bookItemId);
			}
			brochureRewardRequest.BookItems.AddRange(bookItemIds);
			Singleton<Net>.Instance.Call<BrochureRewardResponse>(ERequestMessageId.BrochureRewardRequest, brochureRewardRequest, delegate(BrochureRewardResponse response, Net.CallbackStatus _)
			{
				if (response != null)
				{
					if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
					{
						foreach (int num2 in bookItemIds)
						{
							SpringManorData activityData2 = activityData;
							if (activityData2 != null)
							{
								activityData2.SetTargetBookItemState(num2, BookItemState.BookItemRewarded);
							}
							if (ControllerBase<SpringManorController>.Instance.LatestUnlockBookItemId == num2)
							{
								ControllerBase<SpringManorController>.Instance.LatestUnlockBookItemId = 0;
								ControllerBase<SpringManorController>.Instance.LatestUnlockBrochureId = 0;
							}
						}
						Singleton<EventSystem>.Instance.Emit(EEventName.OnBrochureBookItemStateUpdate);
						return;
					}
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.ArtemisNodeUpdateResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x0603FB32 RID: 260914 RVA: 0x01054610 File Offset: 0x01052810
		public void ClearCustomTrack()
		{
			this.StopTrackRewardTask();
			this.StopTrackSkipEntry();
			this.StopCurrentTrackSubQuest();
			if (this.TrackCheckTimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TrackCheckTimerHandle);
			}
		}

		// Token: 0x0603FB33 RID: 260915 RVA: 0x01054640 File Offset: 0x01052840
		public void TryStartTrackCheckTimer()
		{
			if (this.TrackCheckTimerHandle != null)
			{
				return;
			}
			SpringManorModel model = ModelBase<SpringManorModel>.Instance;
			if (!model.HasAnyCanAutoEndTrack())
			{
				return;
			}
			this.TrackCheckTimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				if (!model.HasAnyCanAutoEndTrack())
				{
					if (this.TrackCheckTimerHandle != null)
					{
						TimerSystem.GameplayTimeInstance.Remove(this.TrackCheckTimerHandle);
					}
					this.TrackCheckTimerHandle = null;
					return;
				}
				global::Vector currentTrackRewardPosition = model.GetCurrentTrackRewardPosition();
				if (currentTrackRewardPosition != null && model.CheckPositionIsInAutoEndRange(currentTrackRewardPosition))
				{
					this.StopTrackRewardTask();
				}
				global::Vector currentTrackGetWayPosition = model.GetCurrentTrackGetWayPosition();
				if (currentTrackGetWayPosition != null && model.CheckPositionIsInAutoEndRange(currentTrackGetWayPosition))
				{
					this.StopTrackSkipEntry();
				}
			}, 500f, 1f, null, null, true);
		}

		// Token: 0x0603FB34 RID: 260916 RVA: 0x010546A8 File Offset: 0x010528A8
		[NullableContext(2)]
		public void ExecuteSkipEntry(int skipEntryId, Action onTrackPositionCallback = null)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			SpringFestivalSkipEntry? springFestivalSkipEntry = (instance != null) ? instance.GetSkipEntryConfigById(skipEntryId) : null;
			if (springFestivalSkipEntry == null)
			{
				return;
			}
			if (springFestivalSkipEntry.Value.JumpId > 0)
			{
				SkipTaskManager.RunByConfigId(springFestivalSkipEntry.Value.JumpId, null);
				return;
			}
			if (!springFestivalSkipEntry.Value.IsTeleport)
			{
				SpringManorController instance2 = ControllerBase<SpringManorController>.Instance;
				if (instance2 != null)
				{
					instance2.TrackSkipEntry(skipEntryId);
				}
				if (onTrackPositionCallback != null)
				{
					onTrackPositionCallback();
				}
				return;
			}
			global::Vector vector = global::Vector.Create((double)springFestivalSkipEntry.Value.TrackPosition(0), (double)springFestivalSkipEntry.Value.TrackPosition(1), (double)springFestivalSkipEntry.Value.TrackPosition(2));
			global::Rotator rotator = global::Rotator.Create((float)springFestivalSkipEntry.Value.TrackPosition(3), (float)springFestivalSkipEntry.Value.TrackPosition(4), (float)springFestivalSkipEntry.Value.TrackPosition(5));
			ControllerBase<TeleportController>.Instance.TeleportPlayer(new ITeleportContextParam
			{
				ClientReason = "SpringManorSkipEntry",
				TargetPosition = vector.ToUeVector(false),
				TargetRotation = rotator.ToUeRotator(),
				TeleportMode = new ETeleportMode?(ETeleportMode.NoLoading)
			});
			if (onTrackPositionCallback != null)
			{
				onTrackPositionCallback();
			}
		}

		// Token: 0x0603FB35 RID: 260917 RVA: 0x010547F8 File Offset: 0x010529F8
		public void TrackSkipEntry(int skipEntryId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int currentTrackGetWayId = instance.GetCurrentTrackGetWayId();
			if (currentTrackGetWayId == skipEntryId)
			{
				return;
			}
			SpringFestivalSkipEntry? skipEntryConfigById = ConfigBase<SpringManorConfig>.Instance.GetSkipEntryConfigById(skipEntryId);
			if (skipEntryConfigById == null || skipEntryConfigById.Value.TrackPositionLength < 3)
			{
				return;
			}
			if (currentTrackGetWayId > 0)
			{
				this.StopTrackSkipEntry();
			}
			global::Vector vector = global::Vector.Create((double)skipEntryConfigById.Value.TrackPosition(0), (double)skipEntryConfigById.Value.TrackPosition(1), (double)skipEntryConfigById.Value.TrackPosition(2));
			ControllerBase<TrackController>.Instance.StartTrack(new TrackData
			{
				TrackSource = ETrackSource.None,
				Id = skipEntryId,
				TrackTarget = vector,
				IconPath = skipEntryConfigById.Value.TrackIconPath
			}, true);
			instance.SetCurrentTrackGetWayId(skipEntryId, vector);
			this.TryStartTrackCheckTimer();
		}

		// Token: 0x0603FB36 RID: 260918 RVA: 0x010548D8 File Offset: 0x01052AD8
		public void StopTrackSkipEntry()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int currentTrackGetWayId = instance.GetCurrentTrackGetWayId();
			if (currentTrackGetWayId == 0)
			{
				return;
			}
			instance.ClearCurrentTrackGetWayId();
			ControllerBase<TrackController>.Instance.EndTrack(ETrackSource.None, currentTrackGetWayId);
		}

		// Token: 0x0603FB37 RID: 260919 RVA: 0x0105490C File Offset: 0x01052B0C
		public void TrackRewardTask(int rewardTaskId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int currentTrackRewardId = instance.GetCurrentTrackRewardId();
			if (currentTrackRewardId == rewardTaskId)
			{
				return;
			}
			SpringFestivalReward? rewardTaskConfigById = ConfigBase<SpringManorConfig>.Instance.GetRewardTaskConfigById(rewardTaskId);
			if (rewardTaskConfigById == null || rewardTaskConfigById.Value.SkipType != 2)
			{
				return;
			}
			if (currentTrackRewardId > 0)
			{
				this.StopTrackRewardTask();
			}
			global::Vector vector = global::Vector.Create((double)float.Parse(rewardTaskConfigById.Value.SkipParam(0)), (double)float.Parse(rewardTaskConfigById.Value.SkipParam(1)), (double)float.Parse(rewardTaskConfigById.Value.SkipParam(2)));
			SpringFestival activityConfig = instance.GetActivityConfig();
			ControllerBase<TrackController>.Instance.StartTrack(new TrackData
			{
				TrackSource = ETrackSource.None,
				Id = rewardTaskId,
				TrackTarget = vector,
				IconPath = activityConfig.TrackRewardIconPath
			}, true);
			instance.SetCurrentTrackRewardId(rewardTaskId, vector);
			this.TryStartTrackCheckTimer();
		}

		// Token: 0x0603FB38 RID: 260920 RVA: 0x010549F8 File Offset: 0x01052BF8
		public void StopTrackRewardTask()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int currentTrackRewardId = instance.GetCurrentTrackRewardId();
			if (currentTrackRewardId == 0)
			{
				return;
			}
			instance.ClearCurrentTrackRewardId();
			ControllerBase<TrackController>.Instance.EndTrack(ETrackSource.None, currentTrackRewardId);
		}

		// Token: 0x0603FB39 RID: 260921 RVA: 0x01054A2C File Offset: 0x01052C2C
		public void UpdateRewardTrack()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int currentTrackRewardId = instance.GetCurrentTrackRewardId();
			if (currentTrackRewardId <= 0)
			{
				return;
			}
			SpringManorData activityData = instance.ActivityData;
			EActivityTaskState? eactivityTaskState;
			if (activityData == null)
			{
				eactivityTaskState = null;
			}
			else
			{
				ActivitySpringManorTaskData rewardTaskData = activityData.GetRewardTaskData(currentTrackRewardId);
				eactivityTaskState = ((rewardTaskData != null) ? new EActivityTaskState?(rewardTaskData.Status) : null);
			}
			EActivityTaskState? eactivityTaskState2 = eactivityTaskState;
			if (eactivityTaskState2.GetValueOrDefault() != EActivityTaskState.Active)
			{
				this.StopTrackRewardTask();
			}
		}

		// Token: 0x0603FB3A RID: 260922 RVA: 0x01054A90 File Offset: 0x01052C90
		public void TrackSubQuest(int questId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int trackingSubQuestId = instance.GetTrackingSubQuestId();
			if (trackingSubQuestId == questId)
			{
				return;
			}
			if (ModelBase<QuestNewModel>.Instance.GetQuest(questId) == null)
			{
				return;
			}
			if (instance.CheckTrackingSubQuest())
			{
				this.StopTrackSubQuest(trackingSubQuestId);
			}
			this.StartShowTrackText(questId);
			this.StartShowSubQuestTrackIcon(questId);
			instance.SetTrackingSubQuestId(questId);
		}

		// Token: 0x0603FB3B RID: 260923 RVA: 0x01054AE4 File Offset: 0x01052CE4
		public void StopCurrentTrackSubQuest()
		{
			int trackingSubQuestId = ModelBase<SpringManorModel>.Instance.GetTrackingSubQuestId();
			this.StopTrackSubQuest(trackingSubQuestId);
		}

		// Token: 0x0603FB3C RID: 260924 RVA: 0x01054B04 File Offset: 0x01052D04
		public void StopTrackSubQuest(int questId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (!instance.IsTrackingSubQuest(questId))
			{
				return;
			}
			this.EndShowSubQuestTrackIcon();
			this.EndShowTrackText();
			instance.ClearTrackingSubQuest();
		}

		// Token: 0x0603FB3D RID: 260925 RVA: 0x01054B34 File Offset: 0x01052D34
		private void StartShowSubQuestTrackIcon(int questId)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance.CheckTrackingSubQuest())
			{
				this.EndShowSubQuestTrackIcon();
			}
			global::Vector questTrackPosition = instance.GetQuestTrackPosition(questId);
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
			string questTypeMark = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeMark(quest.QuestMarkId);
			ControllerBase<TrackController>.Instance.StartTrack(new TrackData
			{
				TrackSource = ETrackSource.Quest,
				Id = questId,
				TrackTarget = questTrackPosition,
				IconPath = questTypeMark
			}, true);
		}

		// Token: 0x0603FB3E RID: 260926 RVA: 0x01054BAC File Offset: 0x01052DAC
		private void EndShowSubQuestTrackIcon()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (!instance.CheckTrackingSubQuest())
			{
				return;
			}
			ControllerBase<TrackController>.Instance.EndTrack(ETrackSource.Quest, instance.GetTrackingSubQuestId());
		}

		// Token: 0x0603FB3F RID: 260927 RVA: 0x01054BDC File Offset: 0x01052DDC
		private void StartShowTrackText(int questId)
		{
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
			if (quest == null || !quest.HasBehaviorTree())
			{
				return;
			}
			BaseBehaviorTree tree = quest.Tree;
			BehaviorTreeViewShowData behaviorTreeViewShowData;
			if (tree == null)
			{
				behaviorTreeViewShowData = null;
			}
			else
			{
				Blackboard blackBoard = tree.GetBlackBoard();
				behaviorTreeViewShowData = ((blackBoard != null) ? blackBoard.CreateShowData(false) : null);
			}
			BehaviorTreeViewShowData behaviorTreeViewShowData2 = behaviorTreeViewShowData;
			if (behaviorTreeViewShowData2 == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<BehaviorTreeViewShowData, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeStartShowTrackText, behaviorTreeViewShowData2, ETreeTextExpressReason.None, false);
		}

		// Token: 0x0603FB40 RID: 260928 RVA: 0x01054C38 File Offset: 0x01052E38
		private void EndShowTrackText()
		{
			int trackingSubQuestId = ModelBase<SpringManorModel>.Instance.GetTrackingSubQuestId();
			global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(trackingSubQuestId);
			if (quest == null || !quest.HasBehaviorTree())
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<long, ETreeTextExpressReason, bool>(EEventName.GeneralLogicTreeEndShowTrackText, quest.TreeId.Value, ETreeTextExpressReason.None, false);
		}

		// Token: 0x0603FB41 RID: 260929 RVA: 0x01054C88 File Offset: 0x01052E88
		public UniTask ChangeRoleRequest(int targetRoleId)
		{
			SpringManorController.<ChangeRoleRequest>d__51 <ChangeRoleRequest>d__;
			<ChangeRoleRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeRoleRequest>d__.targetRoleId = targetRoleId;
			<ChangeRoleRequest>d__.<>1__state = -1;
			<ChangeRoleRequest>d__.<>t__builder.Start<SpringManorController.<ChangeRoleRequest>d__51>(ref <ChangeRoleRequest>d__);
			return <ChangeRoleRequest>d__.<>t__builder.Task;
		}

		// Token: 0x04023C09 RID: 146441
		public int LatestUnlockBookItemId;

		// Token: 0x04023C0A RID: 146442
		public int LatestUnlockBrochureId;

		// Token: 0x04023C0B RID: 146443
		[Nullable(2)]
		private TimerHandle TrackCheckTimerHandle;

		// Token: 0x04023C0C RID: 146444
		private const int AUTO_CHECK_TRACK_RANGE_INTERVAL = 500;

		// Token: 0x04023C0D RID: 146445
		private const int VECTOR_DIMENSION = 3;
	}
}
