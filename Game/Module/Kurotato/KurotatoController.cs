using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A29 RID: 23081
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class KurotatoController : UiControllerBase<KurotatoController>
	{
		// Token: 0x0603A73E RID: 239422 RVA: 0x00ED1D14 File Offset: 0x00ECFF14
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603A73F RID: 239423 RVA: 0x00ED1D18 File Offset: 0x00ECFF18
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<KurotatoStepUpdateNotify>(ENotifyMessageId.KurotatoStepUpdateNotify, new Action<KurotatoStepUpdateNotify, Net.CallbackStatus>(this.OnKurotatoStepUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoChestRewardNotify>(ENotifyMessageId.KurotatoChestRewardNotify, new Action<KurotatoChestRewardNotify, Net.CallbackStatus>(this.OnKurotatoChestRewardNotify));
			Singleton<Net>.Instance.Register<KurotatoUpgradeRewardNotify>(ENotifyMessageId.KurotatoUpgradeRewardNotify, new Action<KurotatoUpgradeRewardNotify, Net.CallbackStatus>(this.OnKurotatoUpgradeRewardNotify));
			Singleton<Net>.Instance.Register<KurotatoSystemInfoNotify>(ENotifyMessageId.KurotatoSystemInfoNotify, new Action<KurotatoSystemInfoNotify, Net.CallbackStatus>(this.OnKurotatoSystemInfoNotify));
			Singleton<Net>.Instance.Register<KurotatoShopRewardNotify>(ENotifyMessageId.KurotatoShopRewardNotify, new Action<KurotatoShopRewardNotify, Net.CallbackStatus>(this.OnKurotatoShopRewardNotify));
			Singleton<Net>.Instance.Register<KurotatoItemUpdateNotify>(ENotifyMessageId.KurotatoItemUpdateNotify, new Action<KurotatoItemUpdateNotify, Net.CallbackStatus>(this.OnKurotatoItemUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoAllItemUpdateNotify>(ENotifyMessageId.KurotatoAllItemUpdateNotify, new Action<KurotatoAllItemUpdateNotify, Net.CallbackStatus>(this.OnKurotatoAllItemUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoWeaponUpdateNotify>(ENotifyMessageId.KurotatoWeaponUpdateNotify, new Action<KurotatoWeaponUpdateNotify, Net.CallbackStatus>(this.OnKurotatoWeaponUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoSettlementNotify>(ENotifyMessageId.KurotatoSettlementNotify, new Action<KurotatoSettlementNotify, Net.CallbackStatus>(this.OnKurotatoSettlementNotify));
			Singleton<Net>.Instance.Register<KurotatoRoleRecordNotify>(ENotifyMessageId.KurotatoRoleRecordNotify, new Action<KurotatoRoleRecordNotify, Net.CallbackStatus>(this.OnKurotatoRoleRecordNotify));
			Singleton<Net>.Instance.Register<KurotatoPropertyUpdateNotify>(ENotifyMessageId.KurotatoPropertyUpdateNotify, new Action<KurotatoPropertyUpdateNotify, Net.CallbackStatus>(this.OnKurotatoPropertyUpdateNotify));
			Singleton<Net>.Instance.Register<KurotatoRefineWeaponNotify>(ENotifyMessageId.KurotatoRefineWeaponNotify, new Action<KurotatoRefineWeaponNotify, Net.CallbackStatus>(this.OnKurotatoRefineWeaponNotify));
			Singleton<Net>.Instance.Register<KurotatoDieNotify>(ENotifyMessageId.KurotatoDieNotify, new Action<KurotatoDieNotify, Net.CallbackStatus>(this.OnKurotatoDieNotify));
			Singleton<Net>.Instance.Register<KurotatoReChallengeCountNotify>(ENotifyMessageId.KurotatoReChallengeCountNotify, new Action<KurotatoReChallengeCountNotify, Net.CallbackStatus>(this.OnKurotatoReChallengeCountNotify));
			Singleton<Net>.Instance.Register<KurotatoNextWaveTypeNotify>(ENotifyMessageId.KurotatoNextWaveTypeNotify, new Action<KurotatoNextWaveTypeNotify, Net.CallbackStatus>(this.OnKurotatoNextWaveTypeNotify));
		}

		// Token: 0x0603A740 RID: 239424 RVA: 0x00ED1ECC File Offset: 0x00ED00CC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoStepUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoChestRewardNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoUpgradeRewardNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoSystemInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoShopRewardNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoItemUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoAllItemUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoWeaponUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoSettlementNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoRoleRecordNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoPropertyUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoRefineWeaponNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoDieNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoReChallengeCountNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.KurotatoNextWaveTypeNotify);
		}

		// Token: 0x0603A741 RID: 239425 RVA: 0x00ED1FCC File Offset: 0x00ED01CC
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603A742 RID: 239426 RVA: 0x00ED202C File Offset: 0x00ED022C
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603A743 RID: 239427 RVA: 0x00ED208A File Offset: 0x00ED028A
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName == EUiViewName.KurotatoPauseView)
			{
				this.ReconcileStepView();
			}
		}

		// Token: 0x0603A744 RID: 239428 RVA: 0x00ED209F File Offset: 0x00ED029F
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.LevelUpView, new Func<EUiViewName, object, bool>(this.CheckCanOpenLevelUpView), "KurotatoController.CheckCanOpenLevelUpView");
		}

		// Token: 0x0603A745 RID: 239429 RVA: 0x00ED20C1 File Offset: 0x00ED02C1
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.LevelUpView, new Func<EUiViewName, object, bool>(this.CheckCanOpenLevelUpView));
		}

		// Token: 0x0603A746 RID: 239430 RVA: 0x00ED20E0 File Offset: 0x00ED02E0
		public void RequestEnterInst(int levelId, int roleId, bool isContinue)
		{
			KurotatoCtx kurotatoCtx = new KurotatoCtx
			{
				Continue = isContinue,
				RoleId = roleId,
				LevelId = levelId
			};
			int kurotatoRoleId = roleId;
			if (roleId == 0)
			{
				KurotatoInstInfo archivedData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetKurotatoLevelData(levelId).ArchivedData;
				kurotatoRoleId = ((archivedData != null) ? archivedData.RoleId : 0);
			}
			int dataId = ModelBase<KurotatoModel>.Instance.GetRoleDataByKurotatoRoleId(kurotatoRoleId).GetDataId();
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.KurotatoCtx = kurotatoCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(0, new List<int>
			{
				dataId
			}, 0, 0, null, null).Forget<bool>();
		}

		// Token: 0x0603A747 RID: 239431 RVA: 0x00ED2170 File Offset: 0x00ED0370
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoLevelRecordDelete(int levelId)
		{
			KurotatoController.<RequestKurotatoLevelRecordDelete>d__12 <RequestKurotatoLevelRecordDelete>d__;
			<RequestKurotatoLevelRecordDelete>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoLevelRecordDelete>d__.levelId = levelId;
			<RequestKurotatoLevelRecordDelete>d__.<>1__state = -1;
			<RequestKurotatoLevelRecordDelete>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoLevelRecordDelete>d__12>(ref <RequestKurotatoLevelRecordDelete>d__);
			return <RequestKurotatoLevelRecordDelete>d__.<>t__builder.Task;
		}

		// Token: 0x0603A748 RID: 239432 RVA: 0x00ED21B4 File Offset: 0x00ED03B4
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoChestRewardSelect(bool willSold)
		{
			KurotatoController.<RequestKurotatoChestRewardSelect>d__13 <RequestKurotatoChestRewardSelect>d__;
			<RequestKurotatoChestRewardSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoChestRewardSelect>d__.willSold = willSold;
			<RequestKurotatoChestRewardSelect>d__.<>1__state = -1;
			<RequestKurotatoChestRewardSelect>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoChestRewardSelect>d__13>(ref <RequestKurotatoChestRewardSelect>d__);
			return <RequestKurotatoChestRewardSelect>d__.<>t__builder.Task;
		}

		// Token: 0x0603A749 RID: 239433 RVA: 0x00ED21F8 File Offset: 0x00ED03F8
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoUpgradeRewardSelect(int selectionId)
		{
			KurotatoController.<RequestKurotatoUpgradeRewardSelect>d__14 <RequestKurotatoUpgradeRewardSelect>d__;
			<RequestKurotatoUpgradeRewardSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoUpgradeRewardSelect>d__.selectionId = selectionId;
			<RequestKurotatoUpgradeRewardSelect>d__.<>1__state = -1;
			<RequestKurotatoUpgradeRewardSelect>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoUpgradeRewardSelect>d__14>(ref <RequestKurotatoUpgradeRewardSelect>d__);
			return <RequestKurotatoUpgradeRewardSelect>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74A RID: 239434 RVA: 0x00ED223C File Offset: 0x00ED043C
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoUpgradeRewardRefresh()
		{
			KurotatoController.<RequestKurotatoUpgradeRewardRefresh>d__15 <RequestKurotatoUpgradeRewardRefresh>d__;
			<RequestKurotatoUpgradeRewardRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoUpgradeRewardRefresh>d__.<>1__state = -1;
			<RequestKurotatoUpgradeRewardRefresh>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoUpgradeRewardRefresh>d__15>(ref <RequestKurotatoUpgradeRewardRefresh>d__);
			return <RequestKurotatoUpgradeRewardRefresh>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74B RID: 239435 RVA: 0x00ED2278 File Offset: 0x00ED0478
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoShopProductSelect(int selectionId)
		{
			KurotatoController.<RequestKurotatoShopProductSelect>d__16 <RequestKurotatoShopProductSelect>d__;
			<RequestKurotatoShopProductSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoShopProductSelect>d__.selectionId = selectionId;
			<RequestKurotatoShopProductSelect>d__.<>1__state = -1;
			<RequestKurotatoShopProductSelect>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoShopProductSelect>d__16>(ref <RequestKurotatoShopProductSelect>d__);
			return <RequestKurotatoShopProductSelect>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74C RID: 239436 RVA: 0x00ED22BC File Offset: 0x00ED04BC
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoShopRewardLock(int selectionId)
		{
			KurotatoController.<RequestKurotatoShopRewardLock>d__17 <RequestKurotatoShopRewardLock>d__;
			<RequestKurotatoShopRewardLock>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoShopRewardLock>d__.selectionId = selectionId;
			<RequestKurotatoShopRewardLock>d__.<>1__state = -1;
			<RequestKurotatoShopRewardLock>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoShopRewardLock>d__17>(ref <RequestKurotatoShopRewardLock>d__);
			return <RequestKurotatoShopRewardLock>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74D RID: 239437 RVA: 0x00ED2300 File Offset: 0x00ED0500
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoShopRewardRefresh()
		{
			KurotatoController.<RequestKurotatoShopRewardRefresh>d__18 <RequestKurotatoShopRewardRefresh>d__;
			<RequestKurotatoShopRewardRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoShopRewardRefresh>d__.<>1__state = -1;
			<RequestKurotatoShopRewardRefresh>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoShopRewardRefresh>d__18>(ref <RequestKurotatoShopRewardRefresh>d__);
			return <RequestKurotatoShopRewardRefresh>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74E RID: 239438 RVA: 0x00ED233C File Offset: 0x00ED053C
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoEndShopStep(bool isEndLess)
		{
			KurotatoController.<RequestKurotatoEndShopStep>d__19 <RequestKurotatoEndShopStep>d__;
			<RequestKurotatoEndShopStep>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoEndShopStep>d__.isEndLess = isEndLess;
			<RequestKurotatoEndShopStep>d__.<>1__state = -1;
			<RequestKurotatoEndShopStep>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoEndShopStep>d__19>(ref <RequestKurotatoEndShopStep>d__);
			return <RequestKurotatoEndShopStep>d__.<>t__builder.Task;
		}

		// Token: 0x0603A74F RID: 239439 RVA: 0x00ED2380 File Offset: 0x00ED0580
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoStepAdvance()
		{
			KurotatoController.<RequestKurotatoStepAdvance>d__20 <RequestKurotatoStepAdvance>d__;
			<RequestKurotatoStepAdvance>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoStepAdvance>d__.<>1__state = -1;
			<RequestKurotatoStepAdvance>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoStepAdvance>d__20>(ref <RequestKurotatoStepAdvance>d__);
			return <RequestKurotatoStepAdvance>d__.<>t__builder.Task;
		}

		// Token: 0x0603A750 RID: 239440 RVA: 0x00ED23BC File Offset: 0x00ED05BC
		public bool CheckInKurotatoInstance()
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.Value.InstSubType == 51;
		}

		// Token: 0x0603A751 RID: 239441 RVA: 0x00ED240D File Offset: 0x00ED060D
		private bool CheckCanOpenLevelUpView(EUiViewName viewName, object param)
		{
			return !this.CheckInKurotatoInstance();
		}

		// Token: 0x0603A752 RID: 239442 RVA: 0x00ED2418 File Offset: 0x00ED0618
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoRefineWeapon(int weaponIncId)
		{
			KurotatoController.<RequestKurotatoRefineWeapon>d__23 <RequestKurotatoRefineWeapon>d__;
			<RequestKurotatoRefineWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoRefineWeapon>d__.weaponIncId = weaponIncId;
			<RequestKurotatoRefineWeapon>d__.<>1__state = -1;
			<RequestKurotatoRefineWeapon>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoRefineWeapon>d__23>(ref <RequestKurotatoRefineWeapon>d__);
			return <RequestKurotatoRefineWeapon>d__.<>t__builder.Task;
		}

		// Token: 0x0603A753 RID: 239443 RVA: 0x00ED245C File Offset: 0x00ED065C
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoRoleRecord()
		{
			KurotatoController.<RequestKurotatoRoleRecord>d__24 <RequestKurotatoRoleRecord>d__;
			<RequestKurotatoRoleRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoRoleRecord>d__.<>1__state = -1;
			<RequestKurotatoRoleRecord>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoRoleRecord>d__24>(ref <RequestKurotatoRoleRecord>d__);
			return <RequestKurotatoRoleRecord>d__.<>t__builder.Task;
		}

		// Token: 0x0603A754 RID: 239444 RVA: 0x00ED2498 File Offset: 0x00ED0698
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoSettlement()
		{
			KurotatoController.<RequestKurotatoSettlement>d__25 <RequestKurotatoSettlement>d__;
			<RequestKurotatoSettlement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoSettlement>d__.<>1__state = -1;
			<RequestKurotatoSettlement>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoSettlement>d__25>(ref <RequestKurotatoSettlement>d__);
			return <RequestKurotatoSettlement>d__.<>t__builder.Task;
		}

		// Token: 0x0603A755 RID: 239445 RVA: 0x00ED24D4 File Offset: 0x00ED06D4
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoEndSpecialWaveCombat()
		{
			KurotatoController.<RequestKurotatoEndSpecialWaveCombat>d__26 <RequestKurotatoEndSpecialWaveCombat>d__;
			<RequestKurotatoEndSpecialWaveCombat>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoEndSpecialWaveCombat>d__.<>1__state = -1;
			<RequestKurotatoEndSpecialWaveCombat>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoEndSpecialWaveCombat>d__26>(ref <RequestKurotatoEndSpecialWaveCombat>d__);
			return <RequestKurotatoEndSpecialWaveCombat>d__.<>t__builder.Task;
		}

		// Token: 0x0603A756 RID: 239446 RVA: 0x00ED2510 File Offset: 0x00ED0710
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoReChallenge(bool isFromCurWave)
		{
			KurotatoController.<RequestKurotatoReChallenge>d__27 <RequestKurotatoReChallenge>d__;
			<RequestKurotatoReChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoReChallenge>d__.isFromCurWave = isFromCurWave;
			<RequestKurotatoReChallenge>d__.<>1__state = -1;
			<RequestKurotatoReChallenge>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoReChallenge>d__27>(ref <RequestKurotatoReChallenge>d__);
			return <RequestKurotatoReChallenge>d__.<>t__builder.Task;
		}

		// Token: 0x0603A757 RID: 239447 RVA: 0x00ED2554 File Offset: 0x00ED0754
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoGoldAdd(int goldCount)
		{
			KurotatoController.<RequestKurotatoGoldAdd>d__28 <RequestKurotatoGoldAdd>d__;
			<RequestKurotatoGoldAdd>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoGoldAdd>d__.goldCount = goldCount;
			<RequestKurotatoGoldAdd>d__.<>1__state = -1;
			<RequestKurotatoGoldAdd>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoGoldAdd>d__28>(ref <RequestKurotatoGoldAdd>d__);
			return <RequestKurotatoGoldAdd>d__.<>t__builder.Task;
		}

		// Token: 0x0603A758 RID: 239448 RVA: 0x00ED2598 File Offset: 0x00ED0798
		[NullableContext(0)]
		public UniTask<bool> RequestKurotatoSellWeapon(int weaponIncId)
		{
			KurotatoController.<RequestKurotatoSellWeapon>d__29 <RequestKurotatoSellWeapon>d__;
			<RequestKurotatoSellWeapon>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestKurotatoSellWeapon>d__.weaponIncId = weaponIncId;
			<RequestKurotatoSellWeapon>d__.<>1__state = -1;
			<RequestKurotatoSellWeapon>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoSellWeapon>d__29>(ref <RequestKurotatoSellWeapon>d__);
			return <RequestKurotatoSellWeapon>d__.<>t__builder.Task;
		}

		// Token: 0x0603A759 RID: 239449 RVA: 0x00ED25DC File Offset: 0x00ED07DC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<HashSet<int>> RequestKurotatoConditionGroupState(int conditionGroupId)
		{
			KurotatoController.<RequestKurotatoConditionGroupState>d__30 <RequestKurotatoConditionGroupState>d__;
			<RequestKurotatoConditionGroupState>d__.<>t__builder = AsyncUniTaskMethodBuilder<HashSet<int>>.Create();
			<RequestKurotatoConditionGroupState>d__.conditionGroupId = conditionGroupId;
			<RequestKurotatoConditionGroupState>d__.<>1__state = -1;
			<RequestKurotatoConditionGroupState>d__.<>t__builder.Start<KurotatoController.<RequestKurotatoConditionGroupState>d__30>(ref <RequestKurotatoConditionGroupState>d__);
			return <RequestKurotatoConditionGroupState>d__.<>t__builder.Task;
		}

		// Token: 0x0603A75A RID: 239450 RVA: 0x00ED2620 File Offset: 0x00ED0820
		private void OnKurotatoStepUpdateNotify(KurotatoStepUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetStepData(notify);
			EKurotatoStep step = ModelBase<KurotatoModel>.Instance.GetStep();
			if (step == EKurotatoStep.Combat && !ModelBase<KurotatoModel>.Instance.GetBattleMusicStarted())
			{
				ModelBase<KurotatoModel>.Instance.SetBattleMusicStarted(true);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_music_3_5_wuyinweiji");
			}
			EKurotatoStep prevStep = ModelBase<KurotatoModel>.Instance.GetPrevStep();
			if (step != EKurotatoStep.End && prevStep == EKurotatoStep.End && ModelBase<KurotatoModel>.Instance.GetIsStepStart())
			{
				if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.KurotatoContentView))
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoContentView, null, null);
				}
			}
			else if (step == EKurotatoStep.Combat && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.KurotatoContentView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.KurotatoContentView, null);
			}
			this.ReconcileStepView();
		}

		// Token: 0x0603A75B RID: 239451 RVA: 0x00ED26DC File Offset: 0x00ED08DC
		private void ReconcileStepView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.KurotatoPauseView))
			{
				return;
			}
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			EKurotatoStep step = instance.GetStep();
			EUiViewName? euiViewName = null;
			bool isStepStart = instance.GetIsStepStart();
			if (isStepStart && step == EKurotatoStep.ChestReward && instance.GetChestItemId() > 0)
			{
				euiViewName = new EUiViewName?(EUiViewName.KurotatoBoxDropMainView);
			}
			else if (isStepStart && step == EKurotatoStep.UpgradeReward && instance.GetUpgradeRewardData().Count > 0)
			{
				euiViewName = new EUiViewName?(EUiViewName.KurotatoAttrSelectMainView);
			}
			else if (isStepStart && step == EKurotatoStep.Shop)
			{
				euiViewName = new EUiViewName?(EUiViewName.KurotatoShopMainView);
			}
			foreach (EUiViewName euiViewName2 in new EUiViewName[]
			{
				EUiViewName.KurotatoBoxDropMainView,
				EUiViewName.KurotatoAttrSelectMainView,
				EUiViewName.KurotatoShopMainView
			})
			{
				if (euiViewName2 != euiViewName && Singleton<UiManager>.Instance.IsViewOpen(euiViewName2))
				{
					Singleton<UiManager>.Instance.CloseView(euiViewName2, null);
				}
			}
			if (euiViewName != null && !Singleton<UiManager>.Instance.IsViewOpen(euiViewName.Value))
			{
				Singleton<UiManager>.Instance.OpenView(euiViewName.Value, null, null);
			}
		}

		// Token: 0x0603A75C RID: 239452 RVA: 0x00ED2822 File Offset: 0x00ED0A22
		private void OnKurotatoChestRewardNotify(KurotatoChestRewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetChestRewardData(notify.ItemId, notify.SoldPrice, notify.RewardIndex, notify.TotalRewardCount);
			this.ReconcileStepView();
		}

		// Token: 0x0603A75D RID: 239453 RVA: 0x00ED284C File Offset: 0x00ED0A4C
		private void OnKurotatoUpgradeRewardNotify(KurotatoUpgradeRewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetUpgradeRewardData(notify.PanelPbData);
			this.ReconcileStepView();
		}

		// Token: 0x0603A75E RID: 239454 RVA: 0x00ED2864 File Offset: 0x00ED0A64
		private void OnKurotatoSystemInfoNotify(KurotatoSystemInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetCurLevelId(notify.LevelId);
			ModelBase<KurotatoModel>.Instance.SetRoleId(notify.CharacterId);
			ModelBase<KurotatoModel>.Instance.SetSystemPropertyValues(notify.PropertyValues, notify.LockedPropertyValues);
			ModelBase<KurotatoModel>.Instance.UpdateItemPanel(notify.ItemPanelPbData);
			ModelBase<KurotatoModel>.Instance.UpdateWeapon(notify.WeaponPanelPbData);
			ModelBase<KurotatoModel>.Instance.BattleData.SetBehaviorTreeVar(notify.VariableKeyNames);
			KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
			if (curSubController != null)
			{
				curSubController.OnSystemInfoNotify();
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnSystemInfoUpdate);
		}

		// Token: 0x0603A75F RID: 239455 RVA: 0x00ED2901 File Offset: 0x00ED0B01
		private void OnKurotatoShopRewardNotify(KurotatoShopRewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetShopData(notify.PanelPbData);
		}

		// Token: 0x0603A760 RID: 239456 RVA: 0x00ED2913 File Offset: 0x00ED0B13
		private void OnKurotatoItemUpdateNotify(KurotatoItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.UpdateItem(new KurotatoItemData
			{
				ItemId = notify.ItemPbData.ItemId,
				Count = notify.ItemPbData.Count
			}, notify.IsAdd);
		}

		// Token: 0x0603A761 RID: 239457 RVA: 0x00ED294C File Offset: 0x00ED0B4C
		private void OnKurotatoAllItemUpdateNotify(KurotatoAllItemUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.UpdateItemPanel(notify.PanelPbData);
		}

		// Token: 0x0603A762 RID: 239458 RVA: 0x00ED295E File Offset: 0x00ED0B5E
		private void OnKurotatoWeaponUpdateNotify(KurotatoWeaponUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.UpdateWeapon(notify.PanelPbData);
		}

		// Token: 0x0603A763 RID: 239459 RVA: 0x00ED2970 File Offset: 0x00ED0B70
		private void OnKurotatoSettlementNotify(KurotatoSettlementNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			this.StopBattleMusic();
			ModelBase<KurotatoModel>.Instance.SetSettlementData(notify);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoSettleView, null, null);
		}

		// Token: 0x0603A764 RID: 239460 RVA: 0x00ED2994 File Offset: 0x00ED0B94
		private void OnKurotatoRoleRecordNotify(KurotatoRoleRecordNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetRoleSaveState(notify.KurotatoRoleSaveState);
			ModelBase<KurotatoModel>.Instance.SetRoleSaveIsPopView(notify.IsPopView);
			ModelBase<KurotatoModel>.Instance.SetRoleSaveInstInfos(new List<KurotatoInstInfo>(notify.InstInfos));
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnRoleSaveStateUpdate);
			if (notify.IsPopView)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoSaveNotifyConfirm);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}

		// Token: 0x0603A765 RID: 239461 RVA: 0x00ED2A05 File Offset: 0x00ED0C05
		private void OnWorldDone()
		{
			if (this.IsNeedShowMainViewInternal)
			{
				this.IsNeedShowMainViewInternal = false;
				this.AddMainViewSplashTask();
			}
		}

		// Token: 0x0603A766 RID: 239462 RVA: 0x00ED2A1C File Offset: 0x00ED0C1C
		private void AddMainViewSplashTask()
		{
			KurotatoController.<>c__DisplayClass43_0 CS$<>8__locals1 = new KurotatoController.<>c__DisplayClass43_0();
			KurotatoController.<>c__DisplayClass43_0 CS$<>8__locals2 = CS$<>8__locals1;
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			CS$<>8__locals2.activityData = ((instance != null) ? instance.GetActivityData() : null);
			if (CS$<>8__locals1.activityData == null)
			{
				return;
			}
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoMainView, CS$<>8__locals1.activityData, null);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
		}

		// Token: 0x0603A767 RID: 239463 RVA: 0x00ED2A70 File Offset: 0x00ED0C70
		private void OnInstanceChange(int lastInstanceId, int newInstanceId)
		{
			InstanceDungeon? instanceDungeon = (lastInstanceId > 0) ? ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(lastInstanceId) : null;
			InstanceDungeon? instanceDungeon2 = (newInstanceId > 0) ? ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(newInstanceId) : null;
			bool flag = instanceDungeon2 != null && instanceDungeon2.GetValueOrDefault().InstSubType == 51;
			if (flag)
			{
				ControllerBase<SkillButtonUiController>.Instance.AddEventInterface(ModelBase<KurotatoModel>.Instance.BattleData);
			}
			else
			{
				ControllerBase<SkillButtonUiController>.Instance.RemoveEventInterface(ModelBase<KurotatoModel>.Instance.BattleData);
			}
			bool flag2 = instanceDungeon != null && instanceDungeon.GetValueOrDefault().InstSubType == 51;
			if (flag2 && !flag)
			{
				this.StopBattleMusic();
			}
			if (flag2)
			{
				ModelBase<KurotatoModel>.Instance.ClearInGameData();
			}
		}

		// Token: 0x0603A768 RID: 239464 RVA: 0x00ED2B39 File Offset: 0x00ED0D39
		private void OnKurotatoPropertyUpdateNotify(KurotatoPropertyUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			Singleton<EventSystem>.Instance.Emit<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, notify.PropertyValues);
			ModelBase<KurotatoModel>.Instance.UpdateSystemPropertyValues(notify.PropertyValues, notify.LockedPropertyValues);
		}

		// Token: 0x0603A769 RID: 239465 RVA: 0x00ED2B67 File Offset: 0x00ED0D67
		private void OnKurotatoRefineWeaponNotify(KurotatoRefineWeaponNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("kurotato_weaponcombinsucceed", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.KurotatoOnWeaponRefined, notify.NewWeaponIncId);
		}

		// Token: 0x0603A76A RID: 239466 RVA: 0x00ED2B93 File Offset: 0x00ED0D93
		private void OnKurotatoDieNotify(KurotatoDieNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			this.StopBattleMusic();
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnPlayerDie);
		}

		// Token: 0x0603A76B RID: 239467 RVA: 0x00ED2BAC File Offset: 0x00ED0DAC
		private void StopBattleMusic()
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			if (!instance.GetBattleMusicStarted())
			{
				return;
			}
			instance.SetBattleMusicStarted(false);
			Singleton<AudioSystem>.Instance.PostEvent("stop_ui_music_3_5_wuyinweiji");
		}

		// Token: 0x0603A76C RID: 239468 RVA: 0x00ED2BDF File Offset: 0x00ED0DDF
		private void OnKurotatoReChallengeCountNotify(KurotatoReChallengeCountNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetReChallengeCount(notify.MaxReChallengeCount, notify.UsedReChallengeCount);
		}

		// Token: 0x0603A76D RID: 239469 RVA: 0x00ED2BF7 File Offset: 0x00ED0DF7
		private void OnKurotatoNextWaveTypeNotify(KurotatoNextWaveTypeNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<KurotatoModel>.Instance.SetNextWaveType(notify.NextWaveType, notify.NextWaveId);
			Singleton<EventSystem>.Instance.Emit(EEventName.KurotatoOnNextWaveTypeUpdate);
		}

		// Token: 0x0603A76E RID: 239470 RVA: 0x00ED2C20 File Offset: 0x00ED0E20
		public void LeaveInstanceDungeon()
		{
			this.StopBattleMusic();
			KurotatoActivityController instance = ControllerBase<KurotatoActivityController>.Instance;
			CSharpScript.Game.Module.Kurotato.Data.KurotatoActivityData kurotatoActivityData = (instance != null) ? instance.GetActivityData() : null;
			if (kurotatoActivityData != null && !kurotatoActivityData.CheckIfClose())
			{
				this.IsNeedShowMainViewInternal = true;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		}

		// Token: 0x04021176 RID: 135542
		private bool IsNeedShowMainViewInternal;

		// Token: 0x04021177 RID: 135543
		private const string KUROTATO_BATTLE_MUSIC_PLAY = "play_ui_music_3_5_wuyinweiji";

		// Token: 0x04021178 RID: 135544
		private const string KUROTATO_BATTLE_MUSIC_STOP = "stop_ui_music_3_5_wuyinweiji";
	}
}
