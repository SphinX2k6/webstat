using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.BattleViewDynamicUI;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063AB RID: 25515
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RoverlikeController : UiControllerBase<RoverlikeController>
	{
		// Token: 0x0604014E RID: 262478 RVA: 0x0106CC3B File Offset: 0x0106AE3B
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0604014F RID: 262479 RVA: 0x0106CC40 File Offset: 0x0106AE40
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RoverRogueInfoNotify>(ENotifyMessageId.RoverRogueInfoNotify, new Action<RoverRogueInfoNotify, Net.CallbackStatus>(this.OnRoverRogueInfoNotify));
			Singleton<Net>.Instance.Register<RoverRogueRoomInfoNotify>(ENotifyMessageId.RoverRogueRoomInfoNotify, new Action<RoverRogueRoomInfoNotify, Net.CallbackStatus>(this.OnRoverRogueRoomInfoNotify));
			Singleton<Net>.Instance.Register<RoverRogueChooseDataNotify>(ENotifyMessageId.RoverRogueChooseDataNotify, new Action<RoverRogueChooseDataNotify, Net.CallbackStatus>(this.OnRoverRogueChooseDataNotify));
			Singleton<Net>.Instance.Register<RoverRogueSubLevelNotify>(ENotifyMessageId.RoverRogueSubLevelNotify, new Action<RoverRogueSubLevelNotify, Net.CallbackStatus>(this.OnRoverRogueSubLevelNotify));
			Singleton<Net>.Instance.Register<RoverRogueResultNotify>(ENotifyMessageId.RoverRogueResultNotify, new Action<RoverRogueResultNotify, Net.CallbackStatus>(this.OnRoverRogueResultNotify));
			Singleton<Net>.Instance.Register<RoverRogueCurrencyNotify>(ENotifyMessageId.RoverRogueCurrencyNotify, new Action<RoverRogueCurrencyNotify, Net.CallbackStatus>(this.OnRoverRogueCurrencyNotify));
			Singleton<Net>.Instance.Register<RoverRogueGainDataUpdateNotify>(ENotifyMessageId.RoverRogueGainDataUpdateNotify, new Action<RoverRogueGainDataUpdateNotify, Net.CallbackStatus>(this.OnRoverRogueGainDataUpdateNotify));
			Singleton<Net>.Instance.Register<RoverRogueShopUpdateNotify>(ENotifyMessageId.RoverRogueShopUpdateNotify, new Action<RoverRogueShopUpdateNotify, Net.CallbackStatus>(this.OnRoverRogueShopUpdateNotify));
			Singleton<Net>.Instance.Register<RoverRogueShopInfoUpdateNotify>(ENotifyMessageId.RoverRogueShopInfoUpdateNotify, new Action<RoverRogueShopInfoUpdateNotify, Net.CallbackStatus>(this.OnRoverRogueShopInfoUpdateNotify));
			Singleton<Net>.Instance.Register<RoverRogueGainGetOrLoseNotify>(ENotifyMessageId.RoverRogueGainGetOrLoseNotify, new Action<RoverRogueGainGetOrLoseNotify, Net.CallbackStatus>(this.OnRoverRogueGainGetOrLoseNotify));
			Singleton<Net>.Instance.Register<RoverRogueBlessGroupSelectNotify>(ENotifyMessageId.RoverRogueBlessGroupSelectNotify, new Action<RoverRogueBlessGroupSelectNotify, Net.CallbackStatus>(this.OnRoverRogueBlessGroupSelectNotify));
			Singleton<Net>.Instance.Register<RoverRogueEventNotify>(ENotifyMessageId.RoverRogueEventNotify, new Action<RoverRogueEventNotify, Net.CallbackStatus>(this.OnRoverRogueEventNotify));
			Singleton<Net>.Instance.Register<RoverRogueLootChangeNotify>(ENotifyMessageId.RoverRogueLootChangeNotify, new Action<RoverRogueLootChangeNotify, Net.CallbackStatus>(this.OnRoverRogueLootChangeNotify));
			Singleton<Net>.Instance.Register<RoverRogueUpdateReviveTimesNotify>(ENotifyMessageId.RoverRogueUpdateReviveTimesNotify, new Action<RoverRogueUpdateReviveTimesNotify, Net.CallbackStatus>(this.OnRoverRogueUpdateReviveTimesNotify));
			Singleton<Net>.Instance.Register<RoverRogueTalentUnlockNotify>(ENotifyMessageId.RoverRogueTalentUnlockNotify, new Action<RoverRogueTalentUnlockNotify, Net.CallbackStatus>(this.OnRoverRogueTalentUnlockNotify));
			Singleton<Net>.Instance.Register<RoverRogueResourcesUpdateNotify>(ENotifyMessageId.RoverRogueResourcesUpdateNotify, new Action<RoverRogueResourcesUpdateNotify, Net.CallbackStatus>(this.OnRoverRogueResourcesUpdateNotify));
		}

		// Token: 0x06040150 RID: 262480 RVA: 0x0106CE10 File Offset: 0x0106B010
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueRoomInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueChooseDataNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueSubLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueResultNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueCurrencyNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueGainDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueShopUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueShopInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueGainGetOrLoseNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueBlessGroupSelectNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueEventNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueLootChangeNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueUpdateReviveTimesNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueTalentUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoverRogueResourcesUpdateNotify);
		}

		// Token: 0x06040151 RID: 262481 RVA: 0x0106CF1D File Offset: 0x0106B11D
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x06040152 RID: 262482 RVA: 0x0106CF3B File Offset: 0x0106B13B
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x06040153 RID: 262483 RVA: 0x0106CF5C File Offset: 0x0106B15C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		protected override ValueTuple<string, CustomPromise<bool>>? OnPreload()
		{
			if (this.CheckInRoverlike())
			{
				Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnRevive));
			}
			return null;
		}

		// Token: 0x06040154 RID: 262484 RVA: 0x0106CF98 File Offset: 0x0106B198
		protected override bool OnLeaveLevel()
		{
			if (Singleton<EventSystem>.Instance.Has<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnRevive)))
			{
				Singleton<EventSystem>.Instance.Remove<Entity>(EEventName.OnRevive, new Action<Entity>(this.OnRevive));
			}
			this.ClearDeathAnimTimer();
			return true;
		}

		// Token: 0x06040155 RID: 262485 RVA: 0x0106CFE5 File Offset: 0x0106B1E5
		private void OnWorldDone()
		{
			if (ModelBase<RoverlikeModel>.Instance.NeedOpenMainView)
			{
				this.AddMainViewSplashTask();
			}
		}

		// Token: 0x06040156 RID: 262486 RVA: 0x0106CFFC File Offset: 0x0106B1FC
		private void EnqueueRoleUnlockByInstId(int instId)
		{
			IReadOnlyList<RoverRogueBlessRole> blessRoleConfigListByUnlockInsId = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfigListByUnlockInsId(instId);
			if (blessRoleConfigListByUnlockInsId == null)
			{
				return;
			}
			foreach (RoverRogueBlessRole roverRogueBlessRole in blessRoleConfigListByUnlockInsId)
			{
				if (!this.RoleUnlockQueue.Contains(roverRogueBlessRole.Id))
				{
					this.RoleUnlockQueue.Add(roverRogueBlessRole.Id);
				}
			}
		}

		// Token: 0x06040157 RID: 262487 RVA: 0x0106D074 File Offset: 0x0106B274
		public void PlayMainViewUnlockFlow()
		{
			this.IsLootUnlockReady = false;
			UniTask.Create(delegate()
			{
				RoverlikeController.<<PlayMainViewUnlockFlow>b__17_0>d <<PlayMainViewUnlockFlow>b__17_0>d;
				<<PlayMainViewUnlockFlow>b__17_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<PlayMainViewUnlockFlow>b__17_0>d.<>4__this = this;
				<<PlayMainViewUnlockFlow>b__17_0>d.<>1__state = -1;
				<<PlayMainViewUnlockFlow>b__17_0>d.<>t__builder.Start<RoverlikeController.<<PlayMainViewUnlockFlow>b__17_0>d>(ref <<PlayMainViewUnlockFlow>b__17_0>d);
				return <<PlayMainViewUnlockFlow>b__17_0>d.<>t__builder.Task;
			}).Forget();
			this.PlayRoleUnlockQueue();
		}

		// Token: 0x06040158 RID: 262488 RVA: 0x0106D099 File Offset: 0x0106B299
		public void PlayRoleUnlockQueue()
		{
			this.TryShowNextRoleUnlock();
		}

		// Token: 0x06040159 RID: 262489 RVA: 0x0106D0A4 File Offset: 0x0106B2A4
		private void TryShowNextRoleUnlock()
		{
			if (this.IsRoleUnlockShowing)
			{
				return;
			}
			if (this.RoleUnlockQueue.Count == 0)
			{
				if (this.IsLootUnlockReady)
				{
					this.TryShowLootUnlockView();
				}
				return;
			}
			int blessRoleId = this.RoleUnlockQueue[0];
			this.RoleUnlockQueue.RemoveAt(0);
			this.IsRoleUnlockShowing = true;
			RoverlikeRoleUnlockViewParam param = new RoverlikeRoleUnlockViewParam
			{
				BlessRoleId = blessRoleId,
				OnClosed = delegate()
				{
					this.IsRoleUnlockShowing = false;
					this.TryShowNextRoleUnlock();
				}
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeRoleUnlockView, param, null);
		}

		// Token: 0x0604015A RID: 262490 RVA: 0x0106D128 File Offset: 0x0106B328
		private UniTask CacheAndDiffUnlockLoots()
		{
			RoverlikeController.<CacheAndDiffUnlockLoots>d__20 <CacheAndDiffUnlockLoots>d__;
			<CacheAndDiffUnlockLoots>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CacheAndDiffUnlockLoots>d__.<>4__this = this;
			<CacheAndDiffUnlockLoots>d__.<>1__state = -1;
			<CacheAndDiffUnlockLoots>d__.<>t__builder.Start<RoverlikeController.<CacheAndDiffUnlockLoots>d__20>(ref <CacheAndDiffUnlockLoots>d__);
			return <CacheAndDiffUnlockLoots>d__.<>t__builder.Task;
		}

		// Token: 0x0604015B RID: 262491 RVA: 0x0106D16C File Offset: 0x0106B36C
		private void TryShowLootUnlockView()
		{
			List<RoverRogueGainEntry> pendingUnlockLoots = this.PendingUnlockLoots;
			this.PendingUnlockLoots = new List<RoverRogueGainEntry>();
			if (pendingUnlockLoots.Count == 0)
			{
				this.NotifyUnlockFlowEnd();
				return;
			}
			RoverlikeLootUnlockViewOpenParam param = new RoverlikeLootUnlockViewOpenParam
			{
				Loots = pendingUnlockLoots,
				OnClosed = new Action(this.NotifyUnlockFlowEnd)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLootUnlockView, param, null);
		}

		// Token: 0x0604015C RID: 262492 RVA: 0x0106D1CA File Offset: 0x0106B3CA
		private void NotifyUnlockFlowEnd()
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoverlikeUnlockShowEnd");
		}

		// Token: 0x0604015D RID: 262493 RVA: 0x0106D1E4 File Offset: 0x0106B3E4
		private void OnRoverRogueTalentUnlockNotify(RoverRogueTalentUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.TalentTreeData.UpdateUnlockTalentIds(notify.TalentIds, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeTalentUnlockDataUpdate);
		}

		// Token: 0x0604015E RID: 262494 RVA: 0x0106D224 File Offset: 0x0106B424
		private void OnRoverRogueInfoNotify(RoverRogueInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			instance.CreateInstanceData();
			instance.CreateActionData();
			instance.InstanceData.InitFromNotify(notify);
			instance.UpdateCurrency(notify.ItemData);
			ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.RoverlikeMonsterCursor);
			ControllerBase<BattleViewDynamicUIController>.Instance.TryCreateDynamicUI(EBattleViewDynamicUIType.RoverlikeBattleInfo);
			ModelBase<BattleUiModel>.Instance.RegisterTopPanelHook(new RoverlikeTopHudHook());
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					CameraCollision cameraCollision = logicComponent.CameraCollision;
					if (cameraCollision != null)
					{
						cameraCollision.SetCameraCollisionMode(ECameraCollisionMode.InPlaceProbe);
					}
				}
			}
			ControllerBase<InputDistributeController>.Instance.BindAction("大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0604015F RID: 262495 RVA: 0x0106D2CC File Offset: 0x0106B4CC
		private void ClearRoverRogueInstance()
		{
			ModelBase<RoverlikeModel>.Instance.ClearInstanceData();
			RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
			if (currentActivityData != null && currentActivityData.CheckIfInOpenTime())
			{
				ModelBase<RoverlikeModel>.Instance.HasNewSettle = true;
			}
			FightCamera fightCamera = ControllerBase<CameraController>.Instance.MainModel.FightCamera;
			if (fightCamera != null)
			{
				FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
				if (logicComponent != null)
				{
					CameraCollision cameraCollision = logicComponent.CameraCollision;
					if (cameraCollision != null)
					{
						cameraCollision.SetCameraCollisionMode(ECameraCollisionMode.Default);
					}
				}
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAction("大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x06040160 RID: 262496 RVA: 0x0106D350 File Offset: 0x0106B550
		private void OnRoverRogueRoomInfoNotify(RoverRogueRoomInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			if (instanceData != null)
			{
				instanceData.UpdateRoomUpdateInfo(notify);
			}
			RoverRogueRoom? roomConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoomConfig(notify.RoomId);
			RoverRogueRoomType? roomTypeConfig = ConfigBase<RoverlikeConfig>.Instance.GetRoomTypeConfig(notify.RoomTypeId);
			if (!StringUtils.IsEmpty((roomConfig != null) ? roomConfig.GetValueOrDefault().MusicState : null))
			{
				ModelBase<RoverlikeModel>.Instance.CurRoomMusicState = ((roomConfig != null) ? roomConfig.GetValueOrDefault().MusicState : null);
			}
			else
			{
				ModelBase<RoverlikeModel>.Instance.CurRoomMusicState = ((roomTypeConfig != null) ? roomTypeConfig.GetValueOrDefault().MusicState : null);
			}
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLevelTipsView, null, null);
			}, 1000f, null, null, true, 1f);
		}

		// Token: 0x06040161 RID: 262497 RVA: 0x0106D43C File Offset: 0x0106B63C
		private void OnRoverRogueResultNotify(RoverRogueResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverRogueResultInfo resultInfo = notify.ResultInfo;
			if (resultInfo == null)
			{
				return;
			}
			if (this.TryExitRoverRogueWithoutResultView(resultInfo))
			{
				return;
			}
			if (resultInfo.IsDeadTrigger)
			{
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeResultView, resultInfo, null);
				}, 3000f, null, null, true, 1f);
				return;
			}
			ModelBase<RoverlikeModel>.Instance.SaveLastPassRoleTypeId();
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeLevelSelectData roverlikeLevelSelectData;
			if (instance == null)
			{
				roverlikeLevelSelectData = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				roverlikeLevelSelectData = ((currentActivityData != null) ? currentActivityData.LevelSelectData : null);
			}
			RoverlikeLevelSelectData roverlikeLevelSelectData2 = roverlikeLevelSelectData;
			if (roverlikeLevelSelectData2 == null || !roverlikeLevelSelectData2.IsPassed(resultInfo.InstId))
			{
				this.EnqueueRoleUnlockByInstId(resultInfo.InstId);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeResultView, resultInfo, null);
		}

		// Token: 0x06040162 RID: 262498 RVA: 0x0106D50C File Offset: 0x0106B70C
		private void OnRoverRogueCurrencyNotify(RoverRogueCurrencyNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoverlikeModel>.Instance.UpdateCurrency(notify.ItemData);
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			int num = (roverlikeActivityData != null) ? roverlikeActivityData.TalentTreeData.TalentPointItemId : 0;
			if (num <= 0)
			{
				return;
			}
			using (IEnumerator<RoverRogueItemCurrencyData> enumerator = (notify.ItemData ?? new RepeatedField<RoverRogueItemCurrencyData>()).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.ItemId == num)
					{
						Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeTalentUnlockDataUpdate);
					}
				}
			}
		}

		// Token: 0x06040163 RID: 262499 RVA: 0x0106D5AC File Offset: 0x0106B7AC
		private void OnRoverRogueGainDataUpdateNotify(RoverRogueGainDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (ModelBase<RoverlikeModel>.Instance.InstanceData != null)
			{
				ModelBase<RoverlikeModel>.Instance.InstanceData.ApplyGainDataUpdate(notify);
			}
		}

		// Token: 0x06040164 RID: 262500 RVA: 0x0106D5CC File Offset: 0x0106B7CC
		private void OnRoverRogueResourcesUpdateNotify(RoverRogueResourcesUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			List<IRoverlikeFloatTextData> list = this.BuildResourcesFloatTextList(notify);
			if (list.Count == 0)
			{
				return;
			}
			this.ShowResourcesFloatText(list);
		}

		// Token: 0x06040165 RID: 262501 RVA: 0x0106D5F4 File Offset: 0x0106B7F4
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			EInputState state = (actionType == InputDistributeDefine.EActionType.Press) ? EInputState.Press : EInputState.Release;
			ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.幻象2, state);
		}

		// Token: 0x06040166 RID: 262502 RVA: 0x0106D61C File Offset: 0x0106B81C
		private List<IRoverlikeFloatTextData> BuildResourcesFloatTextList(RoverRogueResourcesUpdateNotify notify)
		{
			List<IRoverlikeFloatTextData> list = new List<IRoverlikeFloatTextData>();
			int effectId = notify.EffectId;
			if (effectId > 0)
			{
				RoverRogueEffect? effectConfig = ConfigBase<RoverlikeConfig>.Instance.GetEffectConfig(effectId);
				if (effectConfig == null || !effectConfig.Value.ClientDisplay)
				{
					return list;
				}
			}
			this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.HpMax, (double)notify.HpMax, null);
			this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.Coin, (double)notify.Coin, null);
			this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.TalentPoint, (double)notify.TalentPoint, null);
			this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.GoldEfficiency, (double)notify.GoldEfficiency / 100.0, null);
			foreach (RoverRogueResourcesItem roverRogueResourcesItem in (notify.Item ?? new RepeatedField<RoverRogueResourcesItem>()))
			{
				RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(roverRogueResourcesItem.ConfId);
				if (itemConfig != null)
				{
					string text = ConfigMultiTextLang.GetLocalTextNew(itemConfig.Value.Name, null) ?? string.Empty;
					this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.ItemRound, (double)roverRogueResourcesItem.RoundNum, new string[]
					{
						text,
						roverRogueResourcesItem.RoundNum.ToString()
					});
				}
			}
			foreach (RoverRogueAttChange roverRogueAttChange in (notify.AttChange ?? new RepeatedField<RoverRogueAttChange>()))
			{
				int attId = roverRogueAttChange.AttId;
				PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(attId);
				if (propertyIndexInfo != null)
				{
					RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
					RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
					string priorityAttributeName = this.GetPriorityAttributeName(roverlikeActivityData.GetParamConfig().Value, attId);
					string text2 = string.Empty;
					if (!StringUtils.IsEmpty(priorityAttributeName))
					{
						text2 = (ConfigMultiTextLang.GetLocalTextNew(priorityAttributeName, null) ?? string.Empty);
					}
					else
					{
						text2 = (ConfigMultiTextLang.GetLocalTextNew(propertyIndexInfo.Value.Name, null) ?? string.Empty);
					}
					string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(attId, (double)roverRogueAttChange.ChangeAttValue, propertyIndexInfo.Value.IsPercent);
					this.PushFloatTextIfAny(list, ERoverlikeFloatTextType.Attr, (double)roverRogueAttChange.ChangeAttValue, new string[]
					{
						text2,
						formatAttributeValueString
					});
				}
			}
			return list;
		}

		// Token: 0x06040167 RID: 262503 RVA: 0x0106D888 File Offset: 0x0106BA88
		[NullableContext(2)]
		private string GetPriorityAttributeName(RoverRogueActivity activityConfig, int attrId)
		{
			for (int i = 0; i < activityConfig.AttributeNameLength; i++)
			{
				DicIntString? dicIntString = activityConfig.AttributeName(i);
				if (dicIntString != null && dicIntString.GetValueOrDefault().Key == attrId)
				{
					return dicIntString.Value.Value;
				}
			}
			return null;
		}

		// Token: 0x06040168 RID: 262504 RVA: 0x0106D8E4 File Offset: 0x0106BAE4
		private void PushFloatTextIfAny(List<IRoverlikeFloatTextData> floatTextList, ERoverlikeFloatTextType type, double value, [Nullable(new byte[]
		{
			2,
			1
		})] string[] param = null)
		{
			if (value == 0.0)
			{
				return;
			}
			RoverlikeFloatTextKeyPair roverlikeFloatTextKeyPair = RoverlikeFloatTextKeyMap.Map[type];
			RoverlikeFloatTextData roverlikeFloatTextData = new RoverlikeFloatTextData();
			roverlikeFloatTextData.Type = type;
			roverlikeFloatTextData.TextKey = ((value > 0.0) ? roverlikeFloatTextKeyPair.Increment : roverlikeFloatTextKeyPair.Decrements);
			RoverlikeFloatTextData roverlikeFloatTextData2 = roverlikeFloatTextData;
			string[] textParam = param;
			if (param == null)
			{
				(textParam = new string[1])[0] = value.ToString();
			}
			roverlikeFloatTextData2.TextParam = textParam;
			RoverlikeFloatTextData item = roverlikeFloatTextData;
			floatTextList.Add(item);
		}

		// Token: 0x06040169 RID: 262505 RVA: 0x0106D95C File Offset: 0x0106BB5C
		private void ShowResourcesFloatText(List<IRoverlikeFloatTextData> floatTextList)
		{
			ModelBase<RoverlikeModel>.Instance.EnqueueFloatText(floatTextList);
			this.TryOpenFloatTipsView();
		}

		// Token: 0x0604016A RID: 262506 RVA: 0x0106D96F File Offset: 0x0106BB6F
		private void TryOpenFloatTipsView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoverlikeInfoTipsView))
			{
				return;
			}
			if (ModelBase<RoverlikeModel>.Instance.IsFloatTextEmpty)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeInfoTipsView, null, null);
		}

		// Token: 0x0604016B RID: 262507 RVA: 0x0106D9A4 File Offset: 0x0106BBA4
		private void OnRoverRogueSubLevelNotify(RoverRogueSubLevelNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverlikeController.<>c__DisplayClass37_0 CS$<>8__locals1 = new RoverlikeController.<>c__DisplayClass37_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.notify = notify;
			AsyncTask task = new AsyncTask("RoverlikeSubLevelChangeTask", delegate()
			{
				RoverlikeController.<>c__DisplayClass37_0.<<OnRoverRogueSubLevelNotify>b__0>d <<OnRoverRogueSubLevelNotify>b__0>d;
				<<OnRoverRogueSubLevelNotify>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<OnRoverRogueSubLevelNotify>b__0>d.<>4__this = CS$<>8__locals1;
				<<OnRoverRogueSubLevelNotify>b__0>d.<>1__state = -1;
				<<OnRoverRogueSubLevelNotify>b__0>d.<>t__builder.Start<RoverlikeController.<>c__DisplayClass37_0.<<OnRoverRogueSubLevelNotify>b__0>d>(ref <<OnRoverRogueSubLevelNotify>b__0>d);
				return <<OnRoverRogueSubLevelNotify>b__0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x0604016C RID: 262508 RVA: 0x0106D9F8 File Offset: 0x0106BBF8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		private ValueTuple<string[], string[]> FilterSameSubLevel(RoverRogueSubLevelNotify notify)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (string text in notify.UnLoadSubLevels)
			{
				bool flag = false;
				foreach (string b in notify.LoadSubLevels)
				{
					if (text == b)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(text);
				}
			}
			foreach (string text2 in notify.LoadSubLevels)
			{
				bool flag2 = false;
				foreach (string b2 in notify.UnLoadSubLevels)
				{
					if (text2 == b2)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list2.Add(text2);
				}
			}
			return new ValueTuple<string[], string[]>(list.ToArray(), list2.ToArray());
		}

		// Token: 0x0604016D RID: 262509 RVA: 0x0106DB44 File Offset: 0x0106BD44
		private UniTask RoverRogueGotoNextRoomCommitAsync()
		{
			RoverlikeController.<RoverRogueGotoNextRoomCommitAsync>d__39 <RoverRogueGotoNextRoomCommitAsync>d__;
			<RoverRogueGotoNextRoomCommitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoverRogueGotoNextRoomCommitAsync>d__.<>1__state = -1;
			<RoverRogueGotoNextRoomCommitAsync>d__.<>t__builder.Start<RoverlikeController.<RoverRogueGotoNextRoomCommitAsync>d__39>(ref <RoverRogueGotoNextRoomCommitAsync>d__);
			return <RoverRogueGotoNextRoomCommitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604016E RID: 262510 RVA: 0x0106DB7F File Offset: 0x0106BD7F
		private bool TryExitRoverRogueWithoutResultView(RoverRogueResultInfo resultInfo)
		{
			if (resultInfo.InstId != 0)
			{
				return false;
			}
			if (this.CheckInRoverlike())
			{
				this.RoverRogueExitRequest();
			}
			return true;
		}

		// Token: 0x0604016F RID: 262511 RVA: 0x0106DB9C File Offset: 0x0106BD9C
		public void OpenRoverRogueLootViewRequest()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			bool flag = roverlikeActivityData != null && roverlikeActivityData.HasSaveProgress();
			int num = (roverlikeActivityData != null) ? roverlikeActivityData.GetEquippedLootId() : 0;
			RoverlikeLootViewOpenParam roverlikeLootViewOpenParam = new RoverlikeLootViewOpenParam();
			roverlikeLootViewOpenParam.IsInGame = false;
			roverlikeLootViewOpenParam.Loots = new List<RoverRogueGainEntry>(this.CachedLootInfoList);
			roverlikeLootViewOpenParam.EnableUse = new bool?(!flag);
			List<int> equippedLootIds;
			if (num <= 0)
			{
				equippedLootIds = new List<int>();
			}
			else
			{
				(equippedLootIds = new List<int>()).Add(num);
			}
			roverlikeLootViewOpenParam.EquippedLootIds = equippedLootIds;
			IRoverlikeLootViewOpenParam param = roverlikeLootViewOpenParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLootView, param, null);
		}

		// Token: 0x06040170 RID: 262512 RVA: 0x0106DC30 File Offset: 0x0106BE30
		public void OpenRoverRogueLootSelectView(int defaultLootId, Action<int, int> onConfirm)
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			int num = (roverlikeActivityData != null) ? roverlikeActivityData.GetEquippedLootId() : 0;
			RoverlikeLootViewOpenParam roverlikeLootViewOpenParam = new RoverlikeLootViewOpenParam();
			roverlikeLootViewOpenParam.IsInGame = false;
			roverlikeLootViewOpenParam.Loots = new List<RoverRogueGainEntry>(this.CachedLootInfoList);
			roverlikeLootViewOpenParam.EnableUse = new bool?(true);
			List<int> equippedLootIds;
			if (num <= 0)
			{
				equippedLootIds = new List<int>();
			}
			else
			{
				(equippedLootIds = new List<int>()).Add(num);
			}
			roverlikeLootViewOpenParam.EquippedLootIds = equippedLootIds;
			roverlikeLootViewOpenParam.DefaultSelectedLootId = defaultLootId;
			roverlikeLootViewOpenParam.OnConfirmSelect = onConfirm;
			IRoverlikeLootViewOpenParam param = roverlikeLootViewOpenParam;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLootView, param, null);
		}

		// Token: 0x06040171 RID: 262513 RVA: 0x0106DCC1 File Offset: 0x0106BEC1
		public void OpenGameInfoView(EUiTabViewName? viewName = null)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeDetailView, viewName, null);
		}

		// Token: 0x06040172 RID: 262514 RVA: 0x0106DCDC File Offset: 0x0106BEDC
		private void AddMainViewSplashTask()
		{
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
			{
				RoverlikeActivityData currentActivityData = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData();
				if (currentActivityData == null)
				{
					ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeMainView, currentActivityData, null);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
		}

		// Token: 0x06040173 RID: 262515 RVA: 0x0106DD1C File Offset: 0x0106BF1C
		[NullableContext(2)]
		public void RequestInsList(Action callback = null)
		{
			RoverlikeController.<>c__DisplayClass45_0 CS$<>8__locals1 = new RoverlikeController.<>c__DisplayClass45_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			RoverlikeController.<>c__DisplayClass45_0 CS$<>8__locals2 = CS$<>8__locals1;
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			CS$<>8__locals2.activityData = ((instance != null) ? instance.GetCurrentActivityData() : null);
			if (CS$<>8__locals1.activityData == null)
			{
				return;
			}
			int id = CS$<>8__locals1.activityData.Id;
			RoverRogueInsListRequest roverRogueInsListRequest = RoverRogueInsListRequest.Create();
			roverRogueInsListRequest.ActivityId = id;
			Singleton<Net>.Instance.Call<RoverRogueInsListResponse>(ERequestMessageId.RoverRogueInsListRequest, roverRogueInsListRequest, delegate(RoverRogueInsListResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueInsListResponse, null, true, true);
					return;
				}
				CS$<>8__locals1.<>4__this.HandleInsListResponse(CS$<>8__locals1.activityData, response, CS$<>8__locals1.callback);
			}, 0);
		}

		// Token: 0x06040174 RID: 262516 RVA: 0x0106DD94 File Offset: 0x0106BF94
		private void HandleInsListResponse(RoverlikeActivityData activityData, RoverRogueInsListResponse response, [Nullable(2)] Action callback = null)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueInsListResponse, null, true, true);
				return;
			}
			activityData.LevelSelectData.UpdateEntries(response.List);
			activityData.RefreshNewLevelUnlockRedDot();
			if (callback != null)
			{
				callback();
			}
		}

		// Token: 0x06040175 RID: 262517 RVA: 0x0106DDE4 File Offset: 0x0106BFE4
		[NullableContext(2)]
		public void RequestUnlockTalentNode(int talentHeadId, Action callback = null)
		{
			RoverlikeController.<>c__DisplayClass47_0 CS$<>8__locals1 = new RoverlikeController.<>c__DisplayClass47_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.talentHeadId = talentHeadId;
			CS$<>8__locals1.callback = callback;
			RoverlikeController.<>c__DisplayClass47_0 CS$<>8__locals2 = CS$<>8__locals1;
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			CS$<>8__locals2.activityData = ((instance != null) ? instance.GetCurrentActivityData() : null);
			if (CS$<>8__locals1.activityData == null)
			{
				return;
			}
			RoverlikeTalentNodeData nodeData = CS$<>8__locals1.activityData.TalentTreeData.GetNodeData(CS$<>8__locals1.talentHeadId);
			if (nodeData == null)
			{
				return;
			}
			if (!CS$<>8__locals1.activityData.TalentTreeData.IsTalentCanUnlock(nodeData))
			{
				return;
			}
			int nextLevelId = nodeData.NextLevelId;
			if (nextLevelId <= 0)
			{
				return;
			}
			int id = CS$<>8__locals1.activityData.Id;
			RoverRogueTalentUnlockRequest roverRogueTalentUnlockRequest = RoverRogueTalentUnlockRequest.Create();
			roverRogueTalentUnlockRequest.ActivityId = id;
			roverRogueTalentUnlockRequest.TalentId = nextLevelId;
			Singleton<Net>.Instance.Call<RoverRogueTalentUnlockResponse>(ERequestMessageId.RoverRogueTalentUnlockRequest, roverRogueTalentUnlockRequest, delegate(RoverRogueTalentUnlockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueTalentUnlockResponse, null, true, true);
					return;
				}
				CS$<>8__locals1.<>4__this.HandleTalentUnlockResponse(CS$<>8__locals1.activityData, response, CS$<>8__locals1.talentHeadId, CS$<>8__locals1.callback);
			}, 0);
		}

		// Token: 0x06040176 RID: 262518 RVA: 0x0106DEA8 File Offset: 0x0106C0A8
		private void HandleTalentUnlockResponse(RoverlikeActivityData activityData, RoverRogueTalentUnlockResponse response, int talentHeadId, [Nullable(2)] Action callback = null)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueTalentUnlockResponse, null, true, true);
				return;
			}
			if (!activityData.TalentTreeData.LocalUnlockNextTalentLevel(talentHeadId))
			{
				return;
			}
			if (callback != null)
			{
				callback();
			}
		}

		// Token: 0x06040177 RID: 262519 RVA: 0x0106DEE8 File Offset: 0x0106C0E8
		[NullableContext(2)]
		public void RoverRogueStartRequest(int instId, int roleId, int roleType, bool continueLastProgress, int lootId, Action<bool> callback = null)
		{
			RoverRogueInsCtx roverRogueInsCtx = new RoverRogueInsCtx();
			roverRogueInsCtx.RoverId = roleId;
			roverRogueInsCtx.ContinueLastProgress = continueLastProgress;
			RepeatedField<int> equippedLootIds = roverRogueInsCtx.EquippedLootIds;
			List<int> values;
			if (lootId <= 0)
			{
				values = new List<int>();
			}
			else
			{
				(values = new List<int>()).Add(lootId);
			}
			equippedLootIds.AddRange(values);
			roverRogueInsCtx.RoverRoleType = roleType;
			ModelBase<InstanceDungeonModel>.Instance.InstanceContinue = continueLastProgress;
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RoverRogueInsCtx = roverRogueInsCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instId, new List<int>
			{
				roleId
			}, 0, 0, null, null).ContinueWith(delegate(bool success)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(success);
			}).Forget();
		}

		// Token: 0x06040178 RID: 262520 RVA: 0x0106DF90 File Offset: 0x0106C190
		[NullableContext(2)]
		public void RoverRogueReChallengeRequest(int instId, Action<bool> callback = null)
		{
			int mainRoleId = ModelBase<RoverlikeModel>.Instance.GetMainRoleId();
			this.RoverRogueStartRequest(instId, mainRoleId, 0, true, 0, callback);
		}

		// Token: 0x06040179 RID: 262521 RVA: 0x0106DFB4 File Offset: 0x0106C1B4
		[NullableContext(2)]
		public void RoverRogueQuitRequest(int activityId, Action<bool> callback = null)
		{
			RoverRogueQuitRequest roverRogueQuitRequest = Aki.Protocol.RoverRogueQuitRequest.Create();
			roverRogueQuitRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<RoverRogueQuitResponse>(ERequestMessageId.RoverRogueQuitRequest, roverRogueQuitRequest, delegate(RoverRogueQuitResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueQuitResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					this.ClearRoverRogueInstance();
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x0604017A RID: 262522 RVA: 0x0106E000 File Offset: 0x0106C200
		[NullableContext(2)]
		public void RoverRogueResultRequest(int activityId, int instId, Action<bool> callback = null)
		{
			RoverRogueResultRequest roverRogueResultRequest = Aki.Protocol.RoverRogueResultRequest.Create();
			roverRogueResultRequest.ActivityId = activityId;
			roverRogueResultRequest.InstId = instId;
			Singleton<Net>.Instance.Call<RoverRogueResultResponse>(ERequestMessageId.RoverRogueResultRequest, roverRogueResultRequest, delegate(RoverRogueResultResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueResultResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					RoverRogueResultInfo roverRogueResultInfo = (response != null) ? response.ResultInfo : null;
					if (roverRogueResultInfo != null && !this.TryExitRoverRogueWithoutResultView(roverRogueResultInfo))
					{
						Action<bool> callback3 = callback;
						if (callback3 != null)
						{
							callback3(true);
						}
						Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeResultView, roverRogueResultInfo, null);
						return;
					}
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(false);
					return;
				}
			}, 0);
		}

		// Token: 0x0604017B RID: 262523 RVA: 0x0106E054 File Offset: 0x0106C254
		public void RoverRogueExitRequest()
		{
			if (!this.CheckInRoverlike())
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RoverlikeResultView, null);
				this.ClearRoverRogueInstance();
				return;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
			{
				this.ClearRoverRogueInstance();
			}).Forget();
		}

		// Token: 0x0604017C RID: 262524 RVA: 0x0106E0A0 File Offset: 0x0106C2A0
		private void OnRoverRogueShopUpdateNotify(RoverRogueShopUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverRogueShopSnapshot snapshot = notify.Snapshot;
			if (snapshot == null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoverlikeGameShopView))
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeGameShopView, snapshot, null);
		}

		// Token: 0x0604017D RID: 262525 RVA: 0x0106E0DC File Offset: 0x0106C2DC
		private void OnRoverRogueShopInfoUpdateNotify(RoverRogueShopInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoverRogueShopSnapshot snapshot = notify.Snapshot;
			if (snapshot == null)
			{
				return;
			}
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoverlikeGameShopView))
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<RoverRogueShopSnapshot>(EEventName.RoverlikeShopInfoUpdate, snapshot);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_RefreshSuccess", Array.Empty<object>());
		}

		// Token: 0x0604017E RID: 262526 RVA: 0x0106E12C File Offset: 0x0106C32C
		private void OnRoverRogueGainGetOrLoseNotify(RoverRogueGainGetOrLoseNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			bool flag = false;
			foreach (RoverRogueGetOrLoseData roverRogueGetOrLoseData in notify.Data)
			{
				int effectId = roverRogueGetOrLoseData.EffectId;
				bool flag2 = true;
				if (effectId > 0)
				{
					RoverRogueEffect? effectConfig = ConfigBase<RoverlikeConfig>.Instance.GetEffectConfig(effectId);
					if (effectConfig == null || !effectConfig.Value.ClientDisplay)
					{
						continue;
					}
					string type = effectConfig.Value.Type;
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
					if (roverRogueActivity2 != null)
					{
						flag2 = !roverRogueActivity2.Value.IgnoreLoseEffectType().ToList<string>().Contains(type);
					}
				}
				if (flag2 && this.PushObtainIfAny(roverRogueGetOrLoseData.RoverRogueGainEntryIncIdLose, true))
				{
					flag = true;
				}
				if (this.PushObtainIfAny(roverRogueGetOrLoseData.RoverRogueGainEntryIncIdGet, false))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			this.OpenRoverlikeGeneralObtainViewIfNeeded();
		}

		// Token: 0x0604017F RID: 262527 RVA: 0x0106E258 File Offset: 0x0106C458
		public void OpenRoverlikeGeneralObtainView(IRoverlikeGeneralObtainParam param)
		{
			if (!this.PushObtainParam(param))
			{
				return;
			}
			this.OpenRoverlikeGeneralObtainViewIfNeeded();
		}

		// Token: 0x06040180 RID: 262528 RVA: 0x0106E26A File Offset: 0x0106C46A
		private void OpenRoverlikeGeneralObtainViewIfNeeded()
		{
			if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.RoverlikeGeneralObtainView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeGeneralObtainView, null, null);
			}
		}

		// Token: 0x06040181 RID: 262529 RVA: 0x0106E290 File Offset: 0x0106C490
		private bool PushObtainParam(IRoverlikeGeneralObtainParam param)
		{
			RoverlikeActionData actionData = ModelBase<RoverlikeModel>.Instance.ActionData;
			if (actionData == null)
			{
				return false;
			}
			if (param.Entries.Count == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roverlike, ELogAuthor.YYZ, "[俯视角肉鸽] 打开通用获得界面失败，Entries为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			IRoverlikeGeneralObtainParam param2 = new RoverlikeGeneralObtainParam
			{
				Entries = new List<RoverlikeGainEntry>(param.Entries),
				IsLose = param.IsLose
			};
			actionData.PushObtainParam(param2);
			return true;
		}

		// Token: 0x06040182 RID: 262530 RVA: 0x0106E308 File Offset: 0x0106C508
		private bool PushObtainIfAny(IList<RoverRogueGainEntry> protoEntries, bool isLose)
		{
			if (protoEntries == null || protoEntries.Count == 0)
			{
				return false;
			}
			List<RoverlikeGainEntry> list = new List<RoverlikeGainEntry>();
			foreach (RoverRogueGainEntry proto in protoEntries)
			{
				list.Add(new RoverlikeGainEntry(proto));
			}
			IRoverlikeGeneralObtainParam param = new RoverlikeGeneralObtainParam
			{
				Entries = list,
				IsLose = isLose
			};
			return this.PushObtainParam(param);
		}

		// Token: 0x06040183 RID: 262531 RVA: 0x0106E384 File Offset: 0x0106C584
		private void OnRoverRogueBlessGroupSelectNotify(RoverRogueBlessGroupSelectNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RepeatedField<RoverRogueBlessGroupData> blessGroupData = notify.BlessGroupData;
			List<IRoverlikeBlessingSuitData> list = new List<IRoverlikeBlessingSuitData>();
			if (blessGroupData != null)
			{
				foreach (RoverRogueBlessGroupData roverRogueBlessGroupData in blessGroupData)
				{
					IRoverlikeBlessingSuitData item = new RoverlikeBlessingSuitData
					{
						SuitId = roverRogueBlessGroupData.BlessGroupId,
						BlessingIdList = ((roverRogueBlessGroupData.BlessIdList != null) ? new List<int>(roverRogueBlessGroupData.BlessIdList) : new List<int>())
					};
					list.Add(item);
				}
			}
			this.OpenActionSubView(ERoverActionSubViewType.BlessingSuitPreview, list);
		}

		// Token: 0x06040184 RID: 262532 RVA: 0x0106E41C File Offset: 0x0106C61C
		private void OnRoverRogueChooseDataNotify(RoverRogueChooseDataNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify.ChooseData == null)
			{
				return;
			}
			if (ModelBase<RoverlikeModel>.Instance.ActionData == null)
			{
				return;
			}
			ModelBase<RoverlikeModel>.Instance.ActionData.SetChooseData(notify.ChooseData);
		}

		// Token: 0x06040185 RID: 262533 RVA: 0x0106E44C File Offset: 0x0106C64C
		private void OnRoverRogueEventNotify(RoverRogueEventNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			IRoverlikeEventOpenParam openParam = new RoverlikeEventOpenParam
			{
				EventIncId = notify.EventIncId,
				ChoiceList = ((notify.ChoiceList != null) ? new List<int>(notify.ChoiceList) : new List<int>())
			};
			this.OpenActionSubView(ERoverActionSubViewType.SelectEvent, openParam);
		}

		// Token: 0x06040186 RID: 262534 RVA: 0x0106E494 File Offset: 0x0106C694
		private void OnRoverRogueUpdateReviveTimesNotify(RoverRogueUpdateReviveTimesNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoverlikeModel>.Instance.UpdateReviveTimes(notify.ReviveTimes, notify.ReviveTimesMax);
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.RoverlikeReviveTimesUpdate, notify.ReviveTimes, notify.ReviveTimesMax);
		}

		// Token: 0x06040187 RID: 262535 RVA: 0x0106E4C8 File Offset: 0x0106C6C8
		[NullableContext(2)]
		public void RoverRogueChooseDataResultRequest(int bindId, int incId, Action<bool> callback = null)
		{
			RoverlikeActionData actionData = ModelBase<RoverlikeModel>.Instance.ActionData;
			if (actionData != null)
			{
				RoverRogueChooseDataResultRequest roverRogueChooseDataResultRequest = Aki.Protocol.RoverRogueChooseDataResultRequest.Create();
				roverRogueChooseDataResultRequest.BindId = bindId;
				roverRogueChooseDataResultRequest.IncId = incId;
				Singleton<Net>.Instance.Call<RoverRogueChooseDataResultResponse>(ERequestMessageId.RoverRogueChooseDataResultRequest, roverRogueChooseDataResultRequest, delegate(RoverRogueChooseDataResultResponse response, Net.CallbackStatus _)
				{
					if (response == null)
					{
						return;
					}
					if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueChooseDataResultResponse, null, true, true);
						Action<bool> callback3 = callback;
						if (callback3 == null)
						{
							return;
						}
						callback3(false);
						return;
					}
					else
					{
						actionData.RemoveChooseData(bindId);
						Action<bool> callback4 = callback;
						if (callback4 == null)
						{
							return;
						}
						callback4(true);
						return;
					}
				}, 0);
				return;
			}
			Action<bool> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(false);
		}

		// Token: 0x06040188 RID: 262536 RVA: 0x0106E54C File Offset: 0x0106C74C
		[NullableContext(2)]
		public void RoverRogueRefreshGainRequest(int bindId, Action<bool> callback = null)
		{
			RoverlikeActionData actionData = ModelBase<RoverlikeModel>.Instance.ActionData;
			if (actionData != null)
			{
				RoverRogueRefreshGainRequest roverRogueRefreshGainRequest = Aki.Protocol.RoverRogueRefreshGainRequest.Create();
				roverRogueRefreshGainRequest.BindId = bindId;
				Singleton<Net>.Instance.Call<RoverRogueRefreshGainResponse>(ERequestMessageId.RoverRogueRefreshGainRequest, roverRogueRefreshGainRequest, delegate(RoverRogueRefreshGainResponse response, Net.CallbackStatus _)
				{
					if (response == null)
					{
						return;
					}
					if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
					{
						if (response.ChooseData != null)
						{
							actionData.SetChooseData(response.ChooseData);
						}
						Action<bool> callback3 = callback;
						if (callback3 != null)
						{
							callback3(true);
						}
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_RefreshSuccess", Array.Empty<object>());
						return;
					}
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueRefreshGainResponse, null, true, true);
					Action<bool> callback4 = callback;
					if (callback4 == null)
					{
						return;
					}
					callback4(false);
				}, 0);
				return;
			}
			Action<bool> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(false);
		}

		// Token: 0x06040189 RID: 262537 RVA: 0x0106E5BC File Offset: 0x0106C7BC
		[NullableContext(2)]
		public void RoverRogueGiveUpGainRequest(int bindId, Action<bool> callback = null)
		{
			RoverlikeActionData actionData = ModelBase<RoverlikeModel>.Instance.ActionData;
			if (actionData != null)
			{
				RoverRogueGiveUpGainRequest roverRogueGiveUpGainRequest = Aki.Protocol.RoverRogueGiveUpGainRequest.Create();
				roverRogueGiveUpGainRequest.BindId = bindId;
				Singleton<Net>.Instance.Call<RoverRogueGiveUpGainResponse>(ERequestMessageId.RoverRogueGiveUpGainRequest, roverRogueGiveUpGainRequest, delegate(RoverRogueGiveUpGainResponse response, Net.CallbackStatus _)
				{
					if (response == null)
					{
						return;
					}
					if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueGiveUpGainResponse, null, true, true);
						Action<bool> callback3 = callback;
						if (callback3 == null)
						{
							return;
						}
						callback3(false);
						return;
					}
					else
					{
						actionData.RemoveChooseData(bindId);
						Action<bool> callback4 = callback;
						if (callback4 == null)
						{
							return;
						}
						callback4(true);
						return;
					}
				}, 0);
				return;
			}
			Action<bool> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(false);
		}

		// Token: 0x0604018A RID: 262538 RVA: 0x0106E638 File Offset: 0x0106C838
		[NullableContext(2)]
		public void RoverRogueShopBuyRequest(int activityId, int goodIncId, Action<bool> callback = null)
		{
			RoverRogueShopBuyRequest roverRogueShopBuyRequest = Aki.Protocol.RoverRogueShopBuyRequest.Create();
			roverRogueShopBuyRequest.ActivityId = activityId;
			roverRogueShopBuyRequest.GoodIncId = goodIncId;
			Singleton<Net>.Instance.Call<RoverRogueShopBuyResponse>(ERequestMessageId.RoverRogueShopBuyRequest, roverRogueShopBuyRequest, delegate(RoverRogueShopBuyResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueShopBuyResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x0604018B RID: 262539 RVA: 0x0106E684 File Offset: 0x0106C884
		[NullableContext(2)]
		public void RoverRogueShopRefreshRequest(int activityId, Action<RoverRogueShopSnapshot> callback = null)
		{
			RoverRogueShopRefreshRequest roverRogueShopRefreshRequest = Aki.Protocol.RoverRogueShopRefreshRequest.Create();
			roverRogueShopRefreshRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<RoverRogueShopRefreshResponse>(ERequestMessageId.RoverRogueShopRefreshRequest, roverRogueShopRefreshRequest, delegate(RoverRogueShopRefreshResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					Action<RoverRogueShopSnapshot> callback2 = callback;
					if (callback2 != null)
					{
						callback2(response.Snapshot);
					}
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoverRogue_RefreshSuccess", Array.Empty<object>());
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueShopRefreshResponse, null, true, true);
				Action<RoverRogueShopSnapshot> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(null);
			}, 0);
		}

		// Token: 0x0604018C RID: 262540 RVA: 0x0106E6C8 File Offset: 0x0106C8C8
		[NullableContext(2)]
		public void RoverRogueBlessGroupSelectRequest(int activityId, int blessGroupId, Action<bool> callback = null)
		{
			RoverRogueBlessGroupSelectRequest roverRogueBlessGroupSelectRequest = Aki.Protocol.RoverRogueBlessGroupSelectRequest.Create();
			roverRogueBlessGroupSelectRequest.ActivityId = activityId;
			roverRogueBlessGroupSelectRequest.BlessGroupId = blessGroupId;
			Singleton<Net>.Instance.Call<RoverRogueBlessGroupSelectResponse>(ERequestMessageId.RoverRogueBlessGroupSelectRequest, roverRogueBlessGroupSelectRequest, delegate(RoverRogueBlessGroupSelectResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueBlessGroupSelectResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x0604018D RID: 262541 RVA: 0x0106E714 File Offset: 0x0106C914
		[NullableContext(2)]
		public void RoverRogueEventSelectRequest(int eventIncId, int choiceId, Action<bool> callback = null)
		{
			RoverRogueEventSelectRequest roverRogueEventSelectRequest = Aki.Protocol.RoverRogueEventSelectRequest.Create();
			roverRogueEventSelectRequest.EventIncId = eventIncId;
			roverRogueEventSelectRequest.ChoiceId = choiceId;
			Singleton<Net>.Instance.Call<RoverRogueEventSelectResponse>(ERequestMessageId.RoverRogueEventSelectRequest, roverRogueEventSelectRequest, delegate(RoverRogueEventSelectResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueEventSelectResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x0604018E RID: 262542 RVA: 0x0106E760 File Offset: 0x0106C960
		private void OnRoverRogueLootChangeNotify(RoverRogueLootChangeNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			List<int> list = new List<int>();
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			foreach (RoverlikeLootGainEntry roverlikeLootGainEntry in (((instanceData != null) ? instanceData.GetLootItemList() : null) ?? new List<RoverlikeLootGainEntry>()))
			{
				list.Add(roverlikeLootGainEntry.ConfigId);
			}
			IRoverlikeLootViewOpenParam param = new RoverlikeLootViewOpenParam
			{
				IsInGame = true,
				Loots = new List<RoverRogueGainEntry>(notify.LootData),
				EnableUse = new bool?(notify.EnableUse),
				EquippedLootIds = list,
				DefaultSelectedLootId = ((list.Count > 0) ? list[0] : 0)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeLootView, param, null);
		}

		// Token: 0x0604018F RID: 262543 RVA: 0x0106E838 File Offset: 0x0106CA38
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private UniTask<List<RoverRogueGainEntry>> RefreshLootInfoCacheAsync()
		{
			RoverlikeController.<RefreshLootInfoCacheAsync>d__73 <RefreshLootInfoCacheAsync>d__;
			<RefreshLootInfoCacheAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<RoverRogueGainEntry>>.Create();
			<RefreshLootInfoCacheAsync>d__.<>4__this = this;
			<RefreshLootInfoCacheAsync>d__.<>1__state = -1;
			<RefreshLootInfoCacheAsync>d__.<>t__builder.Start<RoverlikeController.<RefreshLootInfoCacheAsync>d__73>(ref <RefreshLootInfoCacheAsync>d__);
			return <RefreshLootInfoCacheAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040190 RID: 262544 RVA: 0x0106E87C File Offset: 0x0106CA7C
		public int GetEquippedLootLevel()
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
			int equippedLootId = (roverlikeActivityData != null) ? roverlikeActivityData.GetEquippedLootId() : 0;
			if (equippedLootId <= 0)
			{
				return 0;
			}
			RoverRogueGainEntry roverRogueGainEntry = this.CachedLootInfoList.FirstOrDefault((RoverRogueGainEntry loot) => loot.ConfigId == equippedLootId);
			int? num;
			if (roverRogueGainEntry == null)
			{
				num = null;
			}
			else
			{
				RoverRogueLootInfo lootInfo = roverRogueGainEntry.LootInfo;
				num = ((lootInfo != null) ? new int?(lootInfo.LootLv) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x06040191 RID: 262545 RVA: 0x0106E90C File Offset: 0x0106CB0C
		private List<RoverRogueGainEntry> MergeLootWithConfig(IReadOnlyList<RoverRogueGainEntry> serverLoots)
		{
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			int? num;
			if (instance == null)
			{
				num = null;
			}
			else
			{
				RoverlikeActivityData currentActivityData = instance.GetCurrentActivityData();
				num = ((currentActivityData != null) ? new int?(currentActivityData.Id) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			IReadOnlyList<RoverRogueLoot> lootConfigListByActivityId = ConfigBase<RoverlikeConfig>.Instance.GetLootConfigListByActivityId(valueOrDefault);
			if (lootConfigListByActivityId.Count == 0)
			{
				return new List<RoverRogueGainEntry>(serverLoots);
			}
			Dictionary<int, RoverRogueGainEntry> dictionary = new Dictionary<int, RoverRogueGainEntry>();
			foreach (RoverRogueGainEntry roverRogueGainEntry in serverLoots)
			{
				dictionary[roverRogueGainEntry.ConfigId] = roverRogueGainEntry;
			}
			List<RoverRogueGainEntry> list = new List<RoverRogueGainEntry>();
			foreach (RoverRogueLoot roverRogueLoot in lootConfigListByActivityId)
			{
				RoverRogueGainEntry roverRogueGainEntry2;
				list.Add(dictionary.TryGetValue(roverRogueLoot.Id, out roverRogueGainEntry2) ? roverRogueGainEntry2 : this.CreateLockedLootEntry(roverRogueLoot.Id));
			}
			return list;
		}

		// Token: 0x06040192 RID: 262546 RVA: 0x0106EA28 File Offset: 0x0106CC28
		private RoverRogueGainEntry CreateLockedLootEntry(int configId)
		{
			RoverRogueGainEntry roverRogueGainEntry = RoverRogueGainEntry.Create();
			roverRogueGainEntry.Type = RoverRogueGainDataType.RoverRogueGainLootItem;
			roverRogueGainEntry.ConfigId = configId;
			roverRogueGainEntry.LootInfo = RoverRogueLootInfo.Create();
			roverRogueGainEntry.LootInfo.Unlock = false;
			return roverRogueGainEntry;
		}

		// Token: 0x06040193 RID: 262547 RVA: 0x0106EA54 File Offset: 0x0106CC54
		[NullableContext(2)]
		public void RoverRogueLootChangeRequest(int lootId, Action<bool> callback = null)
		{
			RoverRogueLootChangeRequest roverRogueLootChangeRequest = Aki.Protocol.RoverRogueLootChangeRequest.Create();
			roverRogueLootChangeRequest.ActivityId = ControllerBase<RoverlikeActivityController>.Instance.GetCurrentActivityData().Id;
			roverRogueLootChangeRequest.LootId = lootId;
			Singleton<Net>.Instance.Call<RoverRogueLootChangeResponse>(ERequestMessageId.RoverRogueLootChangeRequest, roverRogueLootChangeRequest, delegate(RoverRogueLootChangeResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueLootChangeResponse, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x06040194 RID: 262548 RVA: 0x0106EAB0 File Offset: 0x0106CCB0
		[NullableContext(2)]
		public void RoverRogueOutGameLootChangeRequest(int lootId, int lootLv, Action<bool> callback = null)
		{
			this.RoverRogueLootChangeRequest(lootId, delegate(bool success)
			{
				if (success)
				{
					RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
					RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
					if (roverlikeActivityData != null)
					{
						roverlikeActivityData.SetEquippedLoot(lootId);
					}
					if (((roverlikeActivityData != null) ? roverlikeActivityData.LevelSelectData : null) != null)
					{
						roverlikeActivityData.LevelSelectData.SelectedLootLv = lootLv;
					}
				}
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(success);
			});
		}

		// Token: 0x06040195 RID: 262549 RVA: 0x0106EAF0 File Offset: 0x0106CCF0
		public void UpdateActionSubView(int incId)
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			if (actionSubViewManager == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roverlike, ELogAuthor.YYZ, "[俯视角肉鸽] ActionSubViewManager不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RoverlikeActionSubViewBase subViewByIncId = actionSubViewManager.GetSubViewByIncId(incId);
			if (subViewByIncId == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Roverlike;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[俯视角肉鸽] ActionSubView不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IncId", incId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			subViewByIncId.OnRefreshSubView();
		}

		// Token: 0x06040196 RID: 262550 RVA: 0x0106EB6C File Offset: 0x0106CD6C
		[NullableContext(2)]
		public int OpenActionSubView(ERoverActionSubViewType type, object openParam = null)
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			if (actionSubViewManager == null || actionSubViewManager.IsDisposed)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roverlike, ELogAuthor.YYZ, "[俯视角肉鸽] ActionSubViewManager不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return -1;
			}
			if (!actionSubViewManager.HostReady)
			{
				if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoverlikeGeneralActionView) != null)
				{
					Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.RoverlikeGeneralActionView, EUiViewName.RoverlikeGeneralActionView, null, null, true);
				}
				else
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoverlikeGeneralActionView, null, null);
				}
			}
			return actionSubViewManager.AddSubView(type, openParam);
		}

		// Token: 0x06040197 RID: 262551 RVA: 0x0106EBFB File Offset: 0x0106CDFB
		public void FinishActionSubView(int incId)
		{
			RoverlikeActionSubViewManager actionSubViewManager = ModelBase<RoverlikeModel>.Instance.ActionSubViewManager;
			if (actionSubViewManager == null)
			{
				return;
			}
			actionSubViewManager.FinishSubView(incId);
		}

		// Token: 0x06040198 RID: 262552 RVA: 0x0106EC14 File Offset: 0x0106CE14
		public bool CheckInRoverlike()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
				return config != null && config.Value.InstSubType == 59;
			}
			return false;
		}

		// Token: 0x06040199 RID: 262553 RVA: 0x0106EC64 File Offset: 0x0106CE64
		public void RequestTaskRewardTake(List<int> taskIds, [Nullable(2)] Action<bool> callback = null)
		{
			RoverlikeController.<>c__DisplayClass83_0 CS$<>8__locals1 = new RoverlikeController.<>c__DisplayClass83_0();
			CS$<>8__locals1.callback = callback;
			RoverlikeController.<>c__DisplayClass83_0 CS$<>8__locals2 = CS$<>8__locals1;
			RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
			CS$<>8__locals2.activityData = ((instance != null) ? instance.GetCurrentActivityData() : null);
			if (CS$<>8__locals1.activityData == null)
			{
				Action<bool> callback2 = CS$<>8__locals1.callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else
			{
				if (taskIds.Count != 0)
				{
					RoverRogueTaskRewardTakeRequest roverRogueTaskRewardTakeRequest = RoverRogueTaskRewardTakeRequest.Create();
					roverRogueTaskRewardTakeRequest.ActivityId = CS$<>8__locals1.activityData.Id;
					roverRogueTaskRewardTakeRequest.RewardIds.AddRange(taskIds);
					Singleton<Net>.Instance.Call<RoverRogueTaskRewardTakeResponse>(ERequestMessageId.RoverRogueTaskRewardTakeRequest, roverRogueTaskRewardTakeRequest, delegate(RoverRogueTaskRewardTakeResponse response, Net.CallbackStatus _)
					{
						if (response == null)
						{
							Action<bool> callback4 = CS$<>8__locals1.callback;
							if (callback4 == null)
							{
								return;
							}
							callback4(false);
							return;
						}
						else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
						{
							ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RoverRogueTaskRewardTakeResponse, null, true, true);
							Action<bool> callback5 = CS$<>8__locals1.callback;
							if (callback5 == null)
							{
								return;
							}
							callback5(false);
							return;
						}
						else
						{
							foreach (int taskId in response.SuccessRewardIds)
							{
								CS$<>8__locals1.activityData.QuestData.MarkTaken(taskId);
							}
							Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeQuestTaskUpdate);
							Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, CS$<>8__locals1.activityData.Id);
							Action<bool> callback6 = CS$<>8__locals1.callback;
							if (callback6 == null)
							{
								return;
							}
							callback6(true);
							return;
						}
					}, 0);
					return;
				}
				Action<bool> callback3 = CS$<>8__locals1.callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
		}

		// Token: 0x0604019A RID: 262554 RVA: 0x0106ED0C File Offset: 0x0106CF0C
		public void RoleDeathStart(Entity entity)
		{
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			if (component == null || !component.IsRoleAndCtrlByMe)
			{
				return;
			}
			this.IsRoleDeathEnded = false;
			this.ClearDeathAnimTimer();
			this.DeathAnimTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.ClearDeathAnimTimer();
				ModelBase<DeadReviveModel>.Instance.BlockAllInput = false;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
				if (this.CheckInRoverlike())
				{
					this.RoleDeathEnded(entity);
				}
			}, 3000f, null, null, true, 1f);
		}

		// Token: 0x0604019B RID: 262555 RVA: 0x0106ED80 File Offset: 0x0106CF80
		private void ClearDeathAnimTimer()
		{
			if (this.DeathAnimTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DeathAnimTimer);
				this.DeathAnimTimer = null;
			}
		}

		// Token: 0x0604019C RID: 262556 RVA: 0x0106EDA4 File Offset: 0x0106CFA4
		public void RoleDeathEnded(Entity entity)
		{
			if (this.IsRoleDeathEnded)
			{
				return;
			}
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			if (component == null || !component.IsRoleAndCtrlByMe)
			{
				return;
			}
			this.IsRoleDeathEnded = true;
			this.ClearDeathAnimTimer();
			bool flag = ModelBase<RoverlikeModel>.Instance.ConsumeReviveTimes();
			if (!flag)
			{
				entity.DisableByKey(EEntityDisableKey.RoverlikeDeath, true);
			}
			ControllerBase<DeadReviveController>.Instance.DoDeadFinish(flag);
		}

		// Token: 0x0604019D RID: 262557 RVA: 0x0106EE04 File Offset: 0x0106D004
		private void OnRevive(Entity entity)
		{
			if (!this.CheckInRoverlike())
			{
				return;
			}
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			if (component != null && component.IsRoleAndCtrlByMe)
			{
				this.IsRoleDeathEnded = false;
				if (entity.HasDisableKey(EEntityDisableKey.RoverlikeDeath))
				{
					entity.EnableByKey(EEntityDisableKey.RoverlikeDeath, true);
				}
				BaseBuffComponent component2 = entity.GetComponent<BaseBuffComponent>();
				if (component2 != null)
				{
					component2.AddBuff(1502000501L, new AddBuffParam
					{
						InstigatorId = component2.CreatureDataId,
						Reason = "Roverlike角色复活效果"
					});
				}
			}
		}

		// Token: 0x04023F82 RID: 147330
		private const int REVIVE_EFFECT_BUFF_ID = 1502000501;

		// Token: 0x04023F83 RID: 147331
		private readonly List<int> RoleUnlockQueue = new List<int>();

		// Token: 0x04023F84 RID: 147332
		private bool IsRoleUnlockShowing;

		// Token: 0x04023F85 RID: 147333
		private readonly HashSet<int> KnownUnlockedLootIds = new HashSet<int>();

		// Token: 0x04023F86 RID: 147334
		private bool IsLootCacheInited;

		// Token: 0x04023F87 RID: 147335
		private List<RoverRogueGainEntry> PendingUnlockLoots = new List<RoverRogueGainEntry>();

		// Token: 0x04023F88 RID: 147336
		private bool IsLootUnlockReady;

		// Token: 0x04023F89 RID: 147337
		private List<RoverRogueGainEntry> CachedLootInfoList = new List<RoverRogueGainEntry>();

		// Token: 0x04023F8A RID: 147338
		[Nullable(2)]
		private TimerHandle DeathAnimTimer;

		// Token: 0x04023F8B RID: 147339
		private bool IsRoleDeathEnded;
	}
}
