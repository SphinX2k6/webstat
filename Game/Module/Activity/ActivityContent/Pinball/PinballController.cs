using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x0200658C RID: 25996
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class PinballController : ActivityControllerBase<PinballController>
	{
		// Token: 0x06040F19 RID: 266009 RVA: 0x010A9F2E File Offset: 0x010A812E
		private bool IsBlockedEnterPinballMainInMulti()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (instance == null || !instance.IsMulti)
			{
				return false;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PinballMultiTips", Array.Empty<object>());
			return true;
		}

		// Token: 0x06040F1A RID: 266010 RVA: 0x010A9F5D File Offset: 0x010A815D
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<PinballUpdateNotify>(ENotifyMessageId.PinballUpdateNotify, new Action<PinballUpdateNotify, Net.CallbackStatus>(this.OnPinballUpdateNotify));
		}

		// Token: 0x06040F1B RID: 266011 RVA: 0x010A9F7B File Offset: 0x010A817B
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PinballUpdateNotify);
		}

		// Token: 0x06040F1C RID: 266012 RVA: 0x010A9F8D File Offset: 0x010A818D
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(this.OnQuestRedDotStateChange));
		}

		// Token: 0x06040F1D RID: 266013 RVA: 0x010A9FAB File Offset: 0x010A81AB
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestRedDotStateChange, new Action<int>(this.OnQuestRedDotStateChange));
		}

		// Token: 0x06040F1E RID: 266014 RVA: 0x010A9FCC File Offset: 0x010A81CC
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			PinballController.<OnOpenSubView>d__5 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<PinballController.<OnOpenSubView>d__5>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F1F RID: 266015 RVA: 0x010AA018 File Offset: 0x010A8218
		private void OnPinballUpdateNotify(PinballUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			PinballActivityData activityData = ModelBase<PinballModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			ConditionTask conditionTask = notify.ConditionTask;
			if (conditionTask != null)
			{
				activityData.UpdateTaskData(conditionTask);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}
			PinballLevelData levelData = notify.LevelData;
			if (levelData != null)
			{
				activityData.UpdateLevelData(levelData);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityData.Id);
			}
			PinballRoles newRole = notify.NewRole;
			RepeatedField<Aki.Protocol.PinballRoleData> repeatedField = (newRole != null) ? newRole.Roles : null;
			if (repeatedField != null && repeatedField.Count > 0)
			{
				foreach (Aki.Protocol.PinballRoleData data in repeatedField)
				{
					activityData.UpdateRoleByServerData(data);
				}
			}
			PinballWeapons newWeapon = notify.NewWeapon;
			RepeatedField<PinballWeapon> repeatedField2 = (newWeapon != null) ? newWeapon.PinballWeaponList : null;
			if (repeatedField2 != null && repeatedField2.Count > 0)
			{
				foreach (PinballWeapon data2 in repeatedField2)
				{
					activityData.UpdateWeaponData(data2);
				}
			}
			GroupFormation groupFormation = notify.GroupFormation;
			if (groupFormation != null)
			{
				activityData.UpDateLevelFormationData(groupFormation);
			}
			activityData.UpdateRoleWeaponRedDot();
		}

		// Token: 0x06040F20 RID: 266016 RVA: 0x010AA160 File Offset: 0x010A8360
		[NullableContext(0)]
		public UniTask<bool> PinballRoleLevelUpRequestAsync(int activityId, int roleId, int addLevel)
		{
			PinballController.<PinballRoleLevelUpRequestAsync>d__7 <PinballRoleLevelUpRequestAsync>d__;
			<PinballRoleLevelUpRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PinballRoleLevelUpRequestAsync>d__.activityId = activityId;
			<PinballRoleLevelUpRequestAsync>d__.roleId = roleId;
			<PinballRoleLevelUpRequestAsync>d__.addLevel = addLevel;
			<PinballRoleLevelUpRequestAsync>d__.<>1__state = -1;
			<PinballRoleLevelUpRequestAsync>d__.<>t__builder.Start<PinballController.<PinballRoleLevelUpRequestAsync>d__7>(ref <PinballRoleLevelUpRequestAsync>d__);
			return <PinballRoleLevelUpRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040F21 RID: 266017 RVA: 0x010AA1B4 File Offset: 0x010A83B4
		[NullableContext(0)]
		public UniTask<bool> PinballWeaponWearRequestAsync(int activityId, int roleId, int weaponIncId)
		{
			PinballController.<PinballWeaponWearRequestAsync>d__8 <PinballWeaponWearRequestAsync>d__;
			<PinballWeaponWearRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PinballWeaponWearRequestAsync>d__.activityId = activityId;
			<PinballWeaponWearRequestAsync>d__.roleId = roleId;
			<PinballWeaponWearRequestAsync>d__.weaponIncId = weaponIncId;
			<PinballWeaponWearRequestAsync>d__.<>1__state = -1;
			<PinballWeaponWearRequestAsync>d__.<>t__builder.Start<PinballController.<PinballWeaponWearRequestAsync>d__8>(ref <PinballWeaponWearRequestAsync>d__);
			return <PinballWeaponWearRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040F22 RID: 266018 RVA: 0x010AA207 File Offset: 0x010A8407
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06040F23 RID: 266019 RVA: 0x010AA209 File Offset: 0x010A8409
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityCatapultStoryGuide";
		}

		// Token: 0x06040F24 RID: 266020 RVA: 0x010AA210 File Offset: 0x010A8410
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new PinballActivitySubView();
		}

		// Token: 0x06040F25 RID: 266021 RVA: 0x010AA217 File Offset: 0x010A8417
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new PinballActivityData();
		}

		// Token: 0x06040F26 RID: 266022 RVA: 0x010AA21E File Offset: 0x010A841E
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06040F27 RID: 266023 RVA: 0x010AA224 File Offset: 0x010A8424
		[NullableContext(0)]
		public UniTask<bool> OpenLevelViewByType(int levelId, bool isFromInstanceDungeon = false)
		{
			PinballController.<OpenLevelViewByType>d__14 <OpenLevelViewByType>d__;
			<OpenLevelViewByType>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenLevelViewByType>d__.<>4__this = this;
			<OpenLevelViewByType>d__.levelId = levelId;
			<OpenLevelViewByType>d__.isFromInstanceDungeon = isFromInstanceDungeon;
			<OpenLevelViewByType>d__.<>1__state = -1;
			<OpenLevelViewByType>d__.<>t__builder.Start<PinballController.<OpenLevelViewByType>d__14>(ref <OpenLevelViewByType>d__);
			return <OpenLevelViewByType>d__.<>t__builder.Task;
		}

		// Token: 0x06040F28 RID: 266024 RVA: 0x010AA278 File Offset: 0x010A8478
		[NullableContext(0)]
		public UniTask<bool> OpenLevelView(int levelId, bool isFromInstanceDungeon = false)
		{
			PinballController.<OpenLevelView>d__15 <OpenLevelView>d__;
			<OpenLevelView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenLevelView>d__.<>4__this = this;
			<OpenLevelView>d__.levelId = levelId;
			<OpenLevelView>d__.isFromInstanceDungeon = isFromInstanceDungeon;
			<OpenLevelView>d__.<>1__state = -1;
			<OpenLevelView>d__.<>t__builder.Start<PinballController.<OpenLevelView>d__15>(ref <OpenLevelView>d__);
			return <OpenLevelView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F29 RID: 266025 RVA: 0x010AA2CC File Offset: 0x010A84CC
		[NullableContext(0)]
		public UniTask<bool> OpenTowerLevelView(int levelId, bool isFromInstanceDungeon = false)
		{
			PinballController.<OpenTowerLevelView>d__16 <OpenTowerLevelView>d__;
			<OpenTowerLevelView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenTowerLevelView>d__.<>4__this = this;
			<OpenTowerLevelView>d__.levelId = levelId;
			<OpenTowerLevelView>d__.isFromInstanceDungeon = isFromInstanceDungeon;
			<OpenTowerLevelView>d__.<>1__state = -1;
			<OpenTowerLevelView>d__.<>t__builder.Start<PinballController.<OpenTowerLevelView>d__16>(ref <OpenTowerLevelView>d__);
			return <OpenTowerLevelView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2A RID: 266026 RVA: 0x010AA320 File Offset: 0x010A8520
		[NullableContext(0)]
		public UniTask<bool> OpenDailyLevelView(bool isFromInstanceDungeon = false)
		{
			PinballController.<OpenDailyLevelView>d__17 <OpenDailyLevelView>d__;
			<OpenDailyLevelView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenDailyLevelView>d__.<>4__this = this;
			<OpenDailyLevelView>d__.isFromInstanceDungeon = isFromInstanceDungeon;
			<OpenDailyLevelView>d__.<>1__state = -1;
			<OpenDailyLevelView>d__.<>t__builder.Start<PinballController.<OpenDailyLevelView>d__17>(ref <OpenDailyLevelView>d__);
			return <OpenDailyLevelView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2B RID: 266027 RVA: 0x010AA36C File Offset: 0x010A856C
		[NullableContext(0)]
		public UniTask<bool> OpenMainRootView([Nullable(2)] IPinballMainRootViewOpenParam openParam = null)
		{
			PinballController.<OpenMainRootView>d__18 <OpenMainRootView>d__;
			<OpenMainRootView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenMainRootView>d__.<>4__this = this;
			<OpenMainRootView>d__.openParam = openParam;
			<OpenMainRootView>d__.<>1__state = -1;
			<OpenMainRootView>d__.<>t__builder.Start<PinballController.<OpenMainRootView>d__18>(ref <OpenMainRootView>d__);
			return <OpenMainRootView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2C RID: 266028 RVA: 0x010AA3B8 File Offset: 0x010A85B8
		[NullableContext(0)]
		public UniTask<bool> OpenMonsterDetailView(int levelId)
		{
			PinballController.<OpenMonsterDetailView>d__19 <OpenMonsterDetailView>d__;
			<OpenMonsterDetailView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenMonsterDetailView>d__.levelId = levelId;
			<OpenMonsterDetailView>d__.<>1__state = -1;
			<OpenMonsterDetailView>d__.<>t__builder.Start<PinballController.<OpenMonsterDetailView>d__19>(ref <OpenMonsterDetailView>d__);
			return <OpenMonsterDetailView>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2D RID: 266029 RVA: 0x010AA3FC File Offset: 0x010A85FC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<PinballWeaponDegradeResponse> RequestWeaponDecompose(HashSet<int> selection)
		{
			PinballController.<RequestWeaponDecompose>d__20 <RequestWeaponDecompose>d__;
			<RequestWeaponDecompose>d__.<>t__builder = AsyncUniTaskMethodBuilder<PinballWeaponDegradeResponse>.Create();
			<RequestWeaponDecompose>d__.selection = selection;
			<RequestWeaponDecompose>d__.<>1__state = -1;
			<RequestWeaponDecompose>d__.<>t__builder.Start<PinballController.<RequestWeaponDecompose>d__20>(ref <RequestWeaponDecompose>d__);
			return <RequestWeaponDecompose>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2E RID: 266030 RVA: 0x010AA440 File Offset: 0x010A8640
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<PinballWeaponDegradeResponse> RequestWeaponDecompose(IEnumerable<int> weaponIncIdList)
		{
			PinballController.<RequestWeaponDecompose>d__21 <RequestWeaponDecompose>d__;
			<RequestWeaponDecompose>d__.<>t__builder = AsyncUniTaskMethodBuilder<PinballWeaponDegradeResponse>.Create();
			<RequestWeaponDecompose>d__.<>4__this = this;
			<RequestWeaponDecompose>d__.weaponIncIdList = weaponIncIdList;
			<RequestWeaponDecompose>d__.<>1__state = -1;
			<RequestWeaponDecompose>d__.<>t__builder.Start<PinballController.<RequestWeaponDecompose>d__21>(ref <RequestWeaponDecompose>d__);
			return <RequestWeaponDecompose>d__.<>t__builder.Task;
		}

		// Token: 0x06040F2F RID: 266031 RVA: 0x010AA48C File Offset: 0x010A868C
		public void RequestWeaponLock(int incId, bool bLock)
		{
			ItemLockRequest itemLockRequest = ItemLockRequest.Create();
			itemLockRequest.IncrId = incId;
			itemLockRequest.Oper = (bLock ? 1 : 2);
			Singleton<Net>.Instance.Call<ItemLockResponse>(ERequestMessageId.ItemLockRequest, itemLockRequest, delegate(ItemLockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 24035, null, true, true);
					return;
				}
				if (!bLock)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemUnlockSuccess", Array.Empty<object>());
				}
				else
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ItemLockSuccess", Array.Empty<object>());
				}
				PinballWeaponData weaponDataByIncId = ModelBase<PinballModel>.Instance.GetWeaponDataByIncId(incId);
				if (weaponDataByIncId != null)
				{
					weaponDataByIncId.SetIsLock(bLock);
				}
				Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnPinballWeaponLockChanged, incId, bLock);
			}, 0);
		}

		// Token: 0x06040F30 RID: 266032 RVA: 0x010AA4EE File Offset: 0x010A86EE
		public void OpenPinballSmallConfirmBoxView(ConfirmBoxDataNew data)
		{
			data.CustomPopType = new EUiBehaviourPopType?(EUiBehaviourPopType.PinballSmall);
			data.CustomResourceId = "UiItem_ComConfirmPopup";
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(data);
		}

		// Token: 0x06040F31 RID: 266033 RVA: 0x010AA514 File Offset: 0x010A8714
		public void ShowBossTips(int bossTypeId)
		{
			PinballBattleBossComingTipsParam param = new PinballBattleBossComingTipsParam
			{
				BossTypeId = bossTypeId,
				AddMask = new bool?(true),
				CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.BossComing)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballBossComingTipsView, param, null);
		}

		// Token: 0x06040F32 RID: 266034 RVA: 0x010AA558 File Offset: 0x010A8758
		[NullableContext(2)]
		public void ShowFailureTips(Action callBack = null)
		{
			this.OpenGameMainViewMask();
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			PinballWorldConfig? pinballWorldConfig = (pinballBattleSubModel != null) ? pinballBattleSubModel.WorldConfigCache : null;
			int num = (pinballWorldConfig == null) ? 0 : pinballWorldConfig.GetValueOrDefault().SettleDelay;
			TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				PinballBattleTipsParam param = new PinballBattleTipsParam
				{
					CloseCallback = callBack,
					AddMask = new bool?(true),
					CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.Failure)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFailureTipsView, param, null);
			}, (float)num, null, null, true, 1f);
		}

		// Token: 0x06040F33 RID: 266035 RVA: 0x010AA5E4 File Offset: 0x010A87E4
		[NullableContext(2)]
		public void ShowRoleSkillTips(int roleId, Action callBack = null)
		{
			PinballBattleRoleSkillReleaseTips pinballBattleRoleSkillReleaseTips = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PinballRoleSkillReleaseTipsView) as PinballBattleRoleSkillReleaseTips;
			if (pinballBattleRoleSkillReleaseTips != null)
			{
				pinballBattleRoleSkillReleaseTips.AddNewRole(roleId);
				return;
			}
			PinballBattleRoleSkillReleaseTipsControllerParam param = new PinballBattleRoleSkillReleaseTipsControllerParam
			{
				RoleId = roleId,
				CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.RoleSkillRelease),
				CloseCallback = callBack
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleSkillReleaseTipsView, param, null);
		}

		// Token: 0x06040F34 RID: 266036 RVA: 0x010AA644 File Offset: 0x010A8844
		[NullableContext(2)]
		public void ShowSuccessTips(Action callBack = null)
		{
			this.OpenGameMainViewMask();
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			PinballWorldConfig? pinballWorldConfig = (pinballBattleSubModel != null) ? pinballBattleSubModel.WorldConfigCache : null;
			int num = (pinballWorldConfig == null) ? 0 : pinballWorldConfig.GetValueOrDefault().SettleDelay;
			TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				PinballBattleTipsParam param = new PinballBattleTipsParam
				{
					CloseCallback = callBack,
					AddMask = new bool?(true),
					CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.Success)
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballSuccessTipsView, param, null);
			}, (float)num, null, null, true, 1f);
		}

		// Token: 0x06040F35 RID: 266037 RVA: 0x010AA6CF File Offset: 0x010A88CF
		private void OpenGameMainViewMask()
		{
			CommonGameMainView commonGameMainView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonGameMainView) as CommonGameMainView;
			if (commonGameMainView == null)
			{
				return;
			}
			commonGameMainView.SetMaskItemActive(true);
		}

		// Token: 0x06040F36 RID: 266038 RVA: 0x010AA6F0 File Offset: 0x010A88F0
		public void ShowBossSkillTips(string tipsTextId)
		{
			PinballBattleBossSkillTipsControllerParam param = new PinballBattleBossSkillTipsControllerParam
			{
				TextId = tipsTextId,
				CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.BossSkill)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballBossSkillTipsView, param, null);
		}

		// Token: 0x06040F37 RID: 266039 RVA: 0x010AA728 File Offset: 0x010A8928
		public void ShowRoleSkillMaxTips(int roleId)
		{
			PinballBattleRoleSkillMaxTipsControllerParam param = new PinballBattleRoleSkillMaxTipsControllerParam
			{
				RoleId = roleId,
				CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.RoleEnergyMax),
				MoveToBehind = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleSkillMaxTipsView, param, null);
		}

		// Token: 0x06040F38 RID: 266040 RVA: 0x010AA76C File Offset: 0x010A896C
		[NullableContext(2)]
		public void ShowLevelStartTips(int curWave, int maxWave, Action callback = null)
		{
			PinballBattleLevelStartTipsControllerParam param = new PinballBattleLevelStartTipsControllerParam
			{
				CurWave = curWave,
				MaxWave = maxWave,
				CloseCallback = callback,
				AddMask = new bool?(true),
				CloseTime = this.GetTipsCloseTime(EPinballGameTipsType.WaveStart)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballWaveStartTipsView, param, null);
		}

		// Token: 0x06040F39 RID: 266041 RVA: 0x010AA7C0 File Offset: 0x010A89C0
		private int? GetTipsCloseTime(EPinballGameTipsType tipsType)
		{
			PinballBattleSubModel pinballBattleSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as PinballBattleSubModel;
			PinballWorldConfig? pinballWorldConfig = (pinballBattleSubModel != null) ? pinballBattleSubModel.WorldConfigCache : null;
			if (pinballWorldConfig != null)
			{
				PinballWorldConfig valueOrDefault = pinballWorldConfig.GetValueOrDefault();
				for (int i = 0; i < valueOrDefault.TipsTimeLength; i++)
				{
					DicIntInt? dicIntInt = valueOrDefault.TipsTime(i);
					if (dicIntInt != null && dicIntInt.Value.Key == (int)tipsType)
					{
						return new int?(dicIntInt.Value.Value);
					}
				}
				return null;
			}
			return null;
		}

		// Token: 0x06040F3A RID: 266042 RVA: 0x010AA86C File Offset: 0x010A8A6C
		[return: Nullable(2)]
		private PinballActivityData GetPinballActivityData(ActivityBaseData data)
		{
			PinballActivityData pinballActivityData = data as PinballActivityData;
			if (pinballActivityData != null)
			{
				return pinballActivityData;
			}
			return null;
		}

		// Token: 0x06040F3B RID: 266043 RVA: 0x010AA886 File Offset: 0x010A8A86
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipCatapultStoryView, null, null);
		}

		// Token: 0x06040F3C RID: 266044 RVA: 0x010AA89C File Offset: 0x010A8A9C
		private void OnQuestRedDotStateChange(int questId)
		{
			PinballModel instance = ModelBase<PinballModel>.Instance;
			PinballActivityData pinballActivityData = (instance != null) ? instance.ActivityData : null;
			if (pinballActivityData == null)
			{
				return;
			}
			List<int> preGuideQuestIds = pinballActivityData.GetPreGuideQuestIds();
			if (preGuideQuestIds == null || preGuideQuestIds.Count == 0)
			{
				return;
			}
			if (questId != 0 && !preGuideQuestIds.Contains(questId))
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, pinballActivityData.Id);
		}

		// Token: 0x06040F3D RID: 266045 RVA: 0x010AA8F8 File Offset: 0x010A8AF8
		public UniTask RequestTaskReward(PinballActivityData activityData, int taskId, [Nullable(2)] Action finishCallback = null)
		{
			PinballController.<RequestTaskReward>d__36 <RequestTaskReward>d__;
			<RequestTaskReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestTaskReward>d__.<>4__this = this;
			<RequestTaskReward>d__.activityData = activityData;
			<RequestTaskReward>d__.taskId = taskId;
			<RequestTaskReward>d__.finishCallback = finishCallback;
			<RequestTaskReward>d__.<>1__state = -1;
			<RequestTaskReward>d__.<>t__builder.Start<PinballController.<RequestTaskReward>d__36>(ref <RequestTaskReward>d__);
			return <RequestTaskReward>d__.<>t__builder.Task;
		}

		// Token: 0x06040F3E RID: 266046 RVA: 0x010AA954 File Offset: 0x010A8B54
		public UniTask RequestTaskRewardByTaskIds(PinballActivityData activityData, List<int> taskIds, [Nullable(2)] Action finishCallback = null)
		{
			PinballController.<RequestTaskRewardByTaskIds>d__37 <RequestTaskRewardByTaskIds>d__;
			<RequestTaskRewardByTaskIds>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestTaskRewardByTaskIds>d__.activityData = activityData;
			<RequestTaskRewardByTaskIds>d__.taskIds = taskIds;
			<RequestTaskRewardByTaskIds>d__.finishCallback = finishCallback;
			<RequestTaskRewardByTaskIds>d__.<>1__state = -1;
			<RequestTaskRewardByTaskIds>d__.<>t__builder.Start<PinballController.<RequestTaskRewardByTaskIds>d__37>(ref <RequestTaskRewardByTaskIds>d__);
			return <RequestTaskRewardByTaskIds>d__.<>t__builder.Task;
		}

		// Token: 0x06040F3F RID: 266047 RVA: 0x010AA9A8 File Offset: 0x010A8BA8
		public UniTask RequestRankDataList(PinballActivityData activityData)
		{
			PinballController.<RequestRankDataList>d__38 <RequestRankDataList>d__;
			<RequestRankDataList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRankDataList>d__.activityData = activityData;
			<RequestRankDataList>d__.<>1__state = -1;
			<RequestRankDataList>d__.<>t__builder.Start<PinballController.<RequestRankDataList>d__38>(ref <RequestRankDataList>d__);
			return <RequestRankDataList>d__.<>t__builder.Task;
		}

		// Token: 0x06040F40 RID: 266048 RVA: 0x010AA9EC File Offset: 0x010A8BEC
		public UniTask RequestMyRankData(PinballActivityData activityData)
		{
			PinballController.<RequestMyRankData>d__39 <RequestMyRankData>d__;
			<RequestMyRankData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestMyRankData>d__.<>4__this = this;
			<RequestMyRankData>d__.activityData = activityData;
			<RequestMyRankData>d__.<>1__state = -1;
			<RequestMyRankData>d__.<>t__builder.Start<PinballController.<RequestMyRankData>d__39>(ref <RequestMyRankData>d__);
			return <RequestMyRankData>d__.<>t__builder.Task;
		}

		// Token: 0x06040F41 RID: 266049 RVA: 0x010AAA38 File Offset: 0x010A8C38
		public void OpenConfirmBackWorld()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ShipTowerFromViewLeaveInst);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.LeaveBattle();
			};
			this.OpenPinballSmallConfirmBoxView(confirmBoxDataNew);
		}

		// Token: 0x06040F42 RID: 266050 RVA: 0x010AAA6F File Offset: 0x010A8C6F
		private bool LeaveBattle()
		{
			if (!this.CheckInPinballBattleDungeon())
			{
				return false;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			return true;
		}

		// Token: 0x06040F43 RID: 266051 RVA: 0x010AAA8C File Offset: 0x010A8C8C
		public bool CheckInPinballBattleDungeon()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 45;
		}

		// Token: 0x06040F44 RID: 266052 RVA: 0x010AAADD File Offset: 0x010A8CDD
		public bool CheckToSetRoleRedDotAsRead(int activityId, int roleId)
		{
			if (!ModelBase<PinballModel>.Instance.GetRoleRedDot(activityId, roleId))
			{
				return false;
			}
			this.SetRoleRedDotAsRead(activityId, roleId);
			return true;
		}

		// Token: 0x06040F45 RID: 266053 RVA: 0x010AAAF8 File Offset: 0x010A8CF8
		public void SetRoleRedDotAsRead(int activityId, int roleId)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			PinballActivityData activityDataByActivityId = ModelBase<PinballModel>.Instance.GetActivityDataByActivityId(activityId);
			if (activityDataByActivityId == null)
			{
				return;
			}
			global::PinballRoleData roleData = activityDataByActivityId.GetRoleData(roleId);
			if (roleData == null)
			{
				return;
			}
			int subId = roleData.GetConfig().SubId;
			instance.SaveActivityData(activityId, subId, 0, 0, 1);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshPinballRoleRedDot, roleId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}

		// Token: 0x06040F46 RID: 266054 RVA: 0x010AAB65 File Offset: 0x010A8D65
		public void OpenBubbleView(CustomPromise promise)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PinballBubbleView))
			{
				promise.SetResult();
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballBubbleView, promise, null);
		}
	}
}
