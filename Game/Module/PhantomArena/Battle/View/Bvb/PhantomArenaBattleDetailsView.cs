using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb.DamageStatistics;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D7 RID: 21975
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsView : UiTickViewBase, IUiProhibitRefreshData, IExtraShowCursor
	{
		// Token: 0x06037FDE RID: 229342 RVA: 0x00E2EF3B File Offset: 0x00E2D13B
		public PhantomArenaBattleDetailsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037FDF RID: 229343 RVA: 0x00E2EF50 File Offset: 0x00E2D150
		protected override void OnRegisterComponent()
		{
			this.Proxy = (this.OpenParam as PhantomArenaBattleDetailsViewProxy);
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(5, typeof(UUINiagara)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUINiagara)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickBackBtn)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickSkipBtn))
			};
		}

		// Token: 0x06037FE0 RID: 229344 RVA: 0x00E2F094 File Offset: 0x00E2D294
		private UniTask InitMobileJoystick()
		{
			PhantomArenaBattleDetailsView.<InitMobileJoystick>d__36 <InitMobileJoystick>d__;
			<InitMobileJoystick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMobileJoystick>d__.<>4__this = this;
			<InitMobileJoystick>d__.<>1__state = -1;
			<InitMobileJoystick>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitMobileJoystick>d__36>(ref <InitMobileJoystick>d__);
			return <InitMobileJoystick>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE1 RID: 229345 RVA: 0x00E2F0D8 File Offset: 0x00E2D2D8
		private UniTask InitOwnArea()
		{
			PhantomArenaBattleDetailsView.<InitOwnArea>d__37 <InitOwnArea>d__;
			<InitOwnArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOwnArea>d__.<>4__this = this;
			<InitOwnArea>d__.<>1__state = -1;
			<InitOwnArea>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitOwnArea>d__37>(ref <InitOwnArea>d__);
			return <InitOwnArea>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE2 RID: 229346 RVA: 0x00E2F11C File Offset: 0x00E2D31C
		private UniTask InitOpponentArea()
		{
			PhantomArenaBattleDetailsView.<InitOpponentArea>d__38 <InitOpponentArea>d__;
			<InitOpponentArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOpponentArea>d__.<>4__this = this;
			<InitOpponentArea>d__.<>1__state = -1;
			<InitOpponentArea>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitOpponentArea>d__38>(ref <InitOpponentArea>d__);
			return <InitOpponentArea>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE3 RID: 229347 RVA: 0x00E2F160 File Offset: 0x00E2D360
		private UniTask InitCurve()
		{
			PhantomArenaBattleDetailsView.<InitCurve>d__39 <InitCurve>d__;
			<InitCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurve>d__.<>4__this = this;
			<InitCurve>d__.<>1__state = -1;
			<InitCurve>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurve>d__39>(ref <InitCurve>d__);
			return <InitCurve>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE4 RID: 229348 RVA: 0x00E2F1A4 File Offset: 0x00E2D3A4
		private UniTask InitCurveZ()
		{
			PhantomArenaBattleDetailsView.<InitCurveZ>d__40 <InitCurveZ>d__;
			<InitCurveZ>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveZ>d__.<>4__this = this;
			<InitCurveZ>d__.<>1__state = -1;
			<InitCurveZ>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveZ>d__40>(ref <InitCurveZ>d__);
			return <InitCurveZ>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE5 RID: 229349 RVA: 0x00E2F1E8 File Offset: 0x00E2D3E8
		private UniTask InitCurveMeX()
		{
			PhantomArenaBattleDetailsView.<InitCurveMeX>d__41 <InitCurveMeX>d__;
			<InitCurveMeX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveMeX>d__.<>4__this = this;
			<InitCurveMeX>d__.<>1__state = -1;
			<InitCurveMeX>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveMeX>d__41>(ref <InitCurveMeX>d__);
			return <InitCurveMeX>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE6 RID: 229350 RVA: 0x00E2F22C File Offset: 0x00E2D42C
		private UniTask InitCurveOppositeX()
		{
			PhantomArenaBattleDetailsView.<InitCurveOppositeX>d__42 <InitCurveOppositeX>d__;
			<InitCurveOppositeX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveOppositeX>d__.<>4__this = this;
			<InitCurveOppositeX>d__.<>1__state = -1;
			<InitCurveOppositeX>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveOppositeX>d__42>(ref <InitCurveOppositeX>d__);
			return <InitCurveOppositeX>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE7 RID: 229351 RVA: 0x00E2F270 File Offset: 0x00E2D470
		private UniTask InitCurveCommon()
		{
			PhantomArenaBattleDetailsView.<InitCurveCommon>d__43 <InitCurveCommon>d__;
			<InitCurveCommon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveCommon>d__.<>4__this = this;
			<InitCurveCommon>d__.<>1__state = -1;
			<InitCurveCommon>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveCommon>d__43>(ref <InitCurveCommon>d__);
			return <InitCurveCommon>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE8 RID: 229352 RVA: 0x00E2F2B4 File Offset: 0x00E2D4B4
		private UniTask InitCurveDamageX()
		{
			PhantomArenaBattleDetailsView.<InitCurveDamageX>d__44 <InitCurveDamageX>d__;
			<InitCurveDamageX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveDamageX>d__.<>4__this = this;
			<InitCurveDamageX>d__.<>1__state = -1;
			<InitCurveDamageX>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveDamageX>d__44>(ref <InitCurveDamageX>d__);
			return <InitCurveDamageX>d__.<>t__builder.Task;
		}

		// Token: 0x06037FE9 RID: 229353 RVA: 0x00E2F2F8 File Offset: 0x00E2D4F8
		private UniTask InitCurveDamageYMe()
		{
			PhantomArenaBattleDetailsView.<InitCurveDamageYMe>d__45 <InitCurveDamageYMe>d__;
			<InitCurveDamageYMe>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveDamageYMe>d__.<>4__this = this;
			<InitCurveDamageYMe>d__.<>1__state = -1;
			<InitCurveDamageYMe>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveDamageYMe>d__45>(ref <InitCurveDamageYMe>d__);
			return <InitCurveDamageYMe>d__.<>t__builder.Task;
		}

		// Token: 0x06037FEA RID: 229354 RVA: 0x00E2F33C File Offset: 0x00E2D53C
		private UniTask InitCurveDamageYNpc()
		{
			PhantomArenaBattleDetailsView.<InitCurveDamageYNpc>d__46 <InitCurveDamageYNpc>d__;
			<InitCurveDamageYNpc>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCurveDamageYNpc>d__.<>4__this = this;
			<InitCurveDamageYNpc>d__.<>1__state = -1;
			<InitCurveDamageYNpc>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitCurveDamageYNpc>d__46>(ref <InitCurveDamageYNpc>d__);
			return <InitCurveDamageYNpc>d__.<>t__builder.Task;
		}

		// Token: 0x06037FEB RID: 229355 RVA: 0x00E2F380 File Offset: 0x00E2D580
		private void InitHeadStatePanel()
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
			BattleViewProxy battleViewProxy = ((viewByName != null) ? viewByName.OpenParam : null) as BattleViewProxy;
			this.HeadStatePanel = ((battleViewProxy != null) ? battleViewProxy.HeadStatePanel : null);
		}

		// Token: 0x06037FEC RID: 229356 RVA: 0x00E2F3C0 File Offset: 0x00E2D5C0
		private UniTask InitDamageStatistics()
		{
			PhantomArenaBattleDetailsView.<InitDamageStatistics>d__48 <InitDamageStatistics>d__;
			<InitDamageStatistics>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDamageStatistics>d__.<>4__this = this;
			<InitDamageStatistics>d__.<>1__state = -1;
			<InitDamageStatistics>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<InitDamageStatistics>d__48>(ref <InitDamageStatistics>d__);
			return <InitDamageStatistics>d__.<>t__builder.Task;
		}

		// Token: 0x06037FED RID: 229357 RVA: 0x00E2F404 File Offset: 0x00E2D604
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleDetailsView.<OnBeforeStartAsync>d__49 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<OnBeforeStartAsync>d__49>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037FEE RID: 229358 RVA: 0x00E2F448 File Offset: 0x00E2D648
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnDamageAnimEnd), false);
			this.TweenerNpcX = new LguiFloatTween();
			this.TweenerNpcX.BindUpdateTween(new Action<float>(this.TweenCallNpcX));
			this.TweenerNpcX.BindCompleteTween(new Action(this.OnTweenerNpcXEnd));
			this.TweenerNpcZ = new LguiFloatTween();
			this.TweenerNpcZ.BindUpdateTween(new Action<float>(this.TweenCallNpcZ));
			this.TweenerMeX = new LguiFloatTween();
			this.TweenerMeX.BindUpdateTween(new Action<float>(this.TweenCallMeX));
			this.TweenerMeX.BindCompleteTween(new Action(this.OnTweenerMeXEnd));
			this.TweenerMeZ = new LguiFloatTween();
			this.TweenerMeZ.BindUpdateTween(new Action<float>(this.TweenCallMeZ));
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(7);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(false);
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.PhantomArena);
			}
			this.InitBattleEntityList();
			this.RegisterExtraShowCursor();
			this.RegisterExtraUiProhibitRefresh();
			this.SetSpeedText();
			EFunctionType functionId = ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb ? EFunctionType.PhantomArenaSkipFuncUnlock : EFunctionType.PermanentPhantomArenaSkipFuncUnlock;
			bool uiactive = ModelBase<FunctionModel>.Instance.IsOpen(functionId);
			UUIButtonComponent button = base.GetButton(3);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			Singleton<EventSystem>.Instance.Add<float>(EEventName.PlotSequencePlay, new Action<float>(this.OnPlotStart));
			Singleton<EventSystem>.Instance.Add(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
		}

		// Token: 0x06037FEF RID: 229359 RVA: 0x00E2F608 File Offset: 0x00E2D808
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomArenaStartTurnResult, new Action<PhantomBattleBvBSettleNotify>(this.OnTurnBattleEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaBattleDamageAccumulateEnd, new Action(this.OnAccumulateAnimEnd));
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x06037FF0 RID: 229360 RVA: 0x00E2F688 File Offset: 0x00E2D888
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomArenaStartTurnResult, new Action<PhantomBattleBvBSettleNotify>(this.OnTurnBattleEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnAnimEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaBattleDamageAccumulateEnd, new Action(this.OnAccumulateAnimEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		}

		// Token: 0x06037FF1 RID: 229361 RVA: 0x00E2F708 File Offset: 0x00E2D908
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequencePlay, new Action<float>(this.OnPlotStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotEnd));
			this.UnRegisterExtraShowCursor();
			this.UnRegisterExtraUiProhibitRefresh();
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.PhantomArena);
			}
			this.Proxy.DialogManager.Clear();
			this.TweenerNpcX.Destroy();
			this.TweenerNpcZ.Destroy();
			this.TweenerMeX.Destroy();
			this.TweenerMeZ.Destroy();
			this.CurveZ = null;
			this.CurveMeX = null;
			this.CurveOppositeX = null;
			this.CurveCommon = null;
			this.CurveDamageX = null;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomArenaBattleFloatTips))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomArenaBattleFloatTips, null);
			}
			this.RemoveTimerHandle();
			ModelBase<PhantomArenaBattleModel>.Instance.SetIsInBattle(false);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomArenaBattleDamageView, null);
		}

		// Token: 0x06037FF2 RID: 229362 RVA: 0x00E2F810 File Offset: 0x00E2DA10
		protected override void OnTick(float deltaTime)
		{
			BattleHeadStatePanel headStatePanel = this.HeadStatePanel;
			if (headStatePanel != null)
			{
				headStatePanel.Tick(deltaTime);
			}
			PhantomArenaBattleDetailsAreaItem ownArea = this.OwnArea;
			if (ownArea != null)
			{
				ownArea.TickMonster(deltaTime);
			}
			PhantomArenaBattleDetailsAreaItem opponentArea = this.OpponentArea;
			if (opponentArea != null)
			{
				opponentArea.TickMonster(deltaTime);
			}
			PhantomArenaJoystick mobileJoystick = this.MobileJoystick;
			if (mobileJoystick != null)
			{
				mobileJoystick.Tick(deltaTime);
			}
			PhantomArenaBattleDamageStatisticsPanel damageStatistics = this.DamageStatistics;
			if (damageStatistics == null)
			{
				return;
			}
			damageStatistics.Tick(deltaTime);
		}

		// Token: 0x06037FF3 RID: 229363 RVA: 0x00E2F876 File Offset: 0x00E2DA76
		private void OnClickBackBtn()
		{
			ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(new Action(ModelBase<PhantomArenaBattleModel>.Instance.OnClickExitButtonConfirm), null, true);
		}

		// Token: 0x06037FF4 RID: 229364 RVA: 0x00E2F894 File Offset: 0x00E2DA94
		private void OnClickSkipBtn()
		{
			ModelBase<PhantomArenaBattleModel>.Instance.SetSpeedUp();
			this.SetSpeedText();
		}

		// Token: 0x06037FF5 RID: 229365 RVA: 0x00E2F8A6 File Offset: 0x00E2DAA6
		private void RegisterExtraShowCursor()
		{
			Singleton<InputExtraShowCursorCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
		}

		// Token: 0x06037FF6 RID: 229366 RVA: 0x00E2F8C3 File Offset: 0x00E2DAC3
		private void UnRegisterExtraShowCursor()
		{
			Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
		}

		// Token: 0x06037FF7 RID: 229367 RVA: 0x00E2F8DF File Offset: 0x00E2DADF
		private void RegisterExtraUiProhibitRefresh()
		{
			Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
		}

		// Token: 0x06037FF8 RID: 229368 RVA: 0x00E2F8FC File Offset: 0x00E2DAFC
		private void UnRegisterExtraUiProhibitRefresh()
		{
			Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
		}

		// Token: 0x06037FF9 RID: 229369 RVA: 0x00E2F918 File Offset: 0x00E2DB18
		private void InitBattleEntityList()
		{
			List<long> allEntityIdList = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetAllEntityIdList();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "场上的实体列表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityIdList", allEntityIdList);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06037FFA RID: 229370 RVA: 0x00E2F960 File Offset: 0x00E2DB60
		private void RefreshOwnLife()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			this.OwnArea.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037FFB RID: 229371 RVA: 0x00E2F9A4 File Offset: 0x00E2DBA4
		private void RefreshOwnShield()
		{
			int battleBattleAttr = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleBattleAttr(PhantomBattleCardAttr.Defence);
			this.OwnArea.RoleItem.RefreshShieldNum(battleBattleAttr);
		}

		// Token: 0x06037FFC RID: 229372 RVA: 0x00E2F9D4 File Offset: 0x00E2DBD4
		private void RefreshOpponentLife()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			this.OpponentArea.RoleItem.RefreshLifeNum(battleStatusValue, battleStatusValue2);
		}

		// Token: 0x06037FFD RID: 229373 RVA: 0x00E2FA18 File Offset: 0x00E2DC18
		private void RefreshOpponentShield()
		{
			int battleBattleAttr = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleBattleAttr(PhantomBattleCardAttr.Defence);
			this.OpponentArea.RoleItem.RefreshShieldNum(battleBattleAttr);
		}

		// Token: 0x06037FFE RID: 229374 RVA: 0x00E2FA48 File Offset: 0x00E2DC48
		private void SetSpeedText()
		{
			float speedUpText = ModelBase<PhantomArenaBattleModel>.Instance.GetSpeedUpText();
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(speedUpText, "F1");
			defaultInterpolatedStringHandler.AppendLiteral("X");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06037FFF RID: 229375 RVA: 0x00E2FA9B File Offset: 0x00E2DC9B
		public void SetOwnAllSettlePoint(int allSettlePoint)
		{
			this.OwnArea.SetSettlePoint(allSettlePoint);
		}

		// Token: 0x06038000 RID: 229376 RVA: 0x00E2FAA9 File Offset: 0x00E2DCA9
		public void SetOpponentSettlePoint(int opponentSettlePoint)
		{
			this.OpponentArea.SetSettlePoint(opponentSettlePoint);
		}

		// Token: 0x06038001 RID: 229377 RVA: 0x00E2FAB8 File Offset: 0x00E2DCB8
		public bool CheckCondition()
		{
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			HashSet<EUiViewName> hashSet = (instance != null) ? instance.GetNotAllowFightInputViewNameSet() : null;
			if (hashSet == null || hashSet.Count == 0)
			{
				return false;
			}
			List<EUiViewName> list = hashSet.ToList<EUiViewName>();
			return !(list[list.Count - 1] != this.ViewInfo.Name);
		}

		// Token: 0x06038002 RID: 229378 RVA: 0x00E2FB0C File Offset: 0x00E2DD0C
		public string[] GetDistributeTags()
		{
			if (this.Proxy.IsInGamepadNavigation)
			{
				return new string[]
				{
					"UiInputRoot.MouseInputTag",
					"UiInputRoot.Navigation"
				};
			}
			if (Singleton<InputManager>.Instance.IsShowMouseCursor() && Singleton<Info>.Instance.IsInKeyBoard())
			{
				return new string[]
				{
					"UiInputRoot.MouseInputTag"
				};
			}
			return new string[]
			{
				"FightInputRoot",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			};
		}

		// Token: 0x06038003 RID: 229379 RVA: 0x00E2FB84 File Offset: 0x00E2DD84
		public bool IsShowCursor()
		{
			InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
			HashSet<EUiViewName> hashSet = (instance != null) ? instance.GetNotAllowFightInputViewNameSet() : null;
			if (hashSet == null || hashSet.Count == 0)
			{
				return true;
			}
			List<EUiViewName> list = hashSet.ToList<EUiViewName>();
			return list[list.Count - 1] != this.ViewInfo.Name;
		}

		// Token: 0x06038004 RID: 229380 RVA: 0x00E2FBD8 File Offset: 0x00E2DDD8
		private unsafe void ShowBattleSettleWinAnim()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "声骸竞技场BvB结算表现开始";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isWin", this.IsWin);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MeDamaged", this.MeDamaged);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NpcDamaged", this.NpcDamaged);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.NpcBeforeDamaged = this.OwnArea.GetBeforeDamage();
			this.MeBeforeDamaged = this.OpponentArea.GetBeforeDamage();
			if (this.NpcBeforeDamaged == 0 && this.MeBeforeDamaged == 0)
			{
				ModelBase<PhantomArenaBattleModel>.Instance.TryPhantomBattleDealCardNotify();
				return;
			}
			PhantomArenaBattleDetailsAreaItem ownArea = this.OwnArea;
			if (ownArea != null)
			{
				ownArea.SetHitNum(this.MeDamaged);
			}
			PhantomArenaBattleDetailsAreaItem opponentArea = this.OpponentArea;
			if (opponentArea != null)
			{
				opponentArea.SetHitNum(this.NpcDamaged);
			}
			if (this.IsWin || this.NpcBeforeDamaged > 0)
			{
				PhantomArenaBattleDetailsAreaItem ownArea2 = this.OwnArea;
				if (ownArea2 != null)
				{
					ownArea2.StartShowWinAnim();
				}
			}
			if (!this.IsWin || this.MeBeforeDamaged > 0)
			{
				PhantomArenaBattleDetailsAreaItem opponentArea2 = this.OpponentArea;
				if (opponentArea2 == null)
				{
					return;
				}
				opponentArea2.StartShowWinAnim();
			}
		}

		// Token: 0x06038005 RID: 229381 RVA: 0x00E2FD20 File Offset: 0x00E2DF20
		private void OnTurnBattleEnd(PhantomBattleBvBSettleNotify resultData)
		{
			this.IsWin = resultData.IsWin;
			this.NpcDamaged = resultData.NpcDeductLife;
			this.NpcOriginalDamage = resultData.NpcOriginalDamage;
			this.MeDamaged = resultData.PlayerDeductLife;
			this.MeOriginalDamage = resultData.PlayerOriginalDamage;
			this.IsFinishSettle = resultData.IsFinalSettle;
			this.ShowBattleSettleWinAnim();
		}

		// Token: 0x06038006 RID: 229382 RVA: 0x00E2FD7C File Offset: 0x00E2DF7C
		private void OnAnimEvent(string param)
		{
			if (param == EPhantomBattleHeadAnim.DamageAccumulate.ToString())
			{
				if (this.AccumulateTween)
				{
					return;
				}
				this.AccumulateTween = true;
				if (this.IsWin || this.NpcBeforeDamaged > 0)
				{
					PhantomArenaBattleDetailsAreaItem ownArea = this.OwnArea;
					if (ownArea != null)
					{
						ownArea.StartAccumulate(this.CurveMeX, this.CurveZ, this.CurveCommon);
					}
				}
				if (!this.IsWin && this.MeBeforeDamaged > 0)
				{
					PhantomArenaBattleDetailsAreaItem opponentArea = this.OpponentArea;
					if (opponentArea == null)
					{
						return;
					}
					opponentArea.StartAccumulate(this.CurveOppositeX, this.CurveZ, this.CurveCommon);
					return;
				}
			}
			else if (param == EPhantomBattleHeadAnim.Damage.ToString())
			{
				if (this.AnimDamageTween)
				{
					return;
				}
				this.AnimDamageTween = true;
				if (this.MeDamaged > 0)
				{
					PhantomArenaBattleDetailsAreaItem ownArea2 = this.OwnArea;
					if (ownArea2 == null)
					{
						return;
					}
					ownArea2.SetDamageTween(this.CurveDamageX, this.MeDamaged);
					return;
				}
			}
			else if (param == EPhantomBattleHeadAnim.DamageNPC.ToString())
			{
				if (this.AnimDamageTween)
				{
					return;
				}
				this.AnimDamageTween = true;
				if (this.NpcDamaged > 0)
				{
					PhantomArenaBattleDetailsAreaItem opponentArea2 = this.OpponentArea;
					if (opponentArea2 == null)
					{
						return;
					}
					opponentArea2.SetDamageTween(this.CurveDamageX, this.NpcDamaged);
				}
			}
		}

		// Token: 0x06038007 RID: 229383 RVA: 0x00E2FEBC File Offset: 0x00E2E0BC
		private string GetDamageNiagaraPath(int damage)
		{
			string resourceId;
			if (damage < 10)
			{
				resourceId = "NS_Fx_LGUI_Trail_0";
			}
			else
			{
				resourceId = "NS_Fx_LGUI_Trail_1";
			}
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		}

		// Token: 0x06038008 RID: 229384 RVA: 0x00E2FEF0 File Offset: 0x00E2E0F0
		private UniTask OnOpponentWinDamage()
		{
			PhantomArenaBattleDetailsView.<OnOpponentWinDamage>d__76 <OnOpponentWinDamage>d__;
			<OnOpponentWinDamage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnOpponentWinDamage>d__.<>4__this = this;
			<OnOpponentWinDamage>d__.<>1__state = -1;
			<OnOpponentWinDamage>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<OnOpponentWinDamage>d__76>(ref <OnOpponentWinDamage>d__);
			return <OnOpponentWinDamage>d__.<>t__builder.Task;
		}

		// Token: 0x06038009 RID: 229385 RVA: 0x00E2FF34 File Offset: 0x00E2E134
		private UniTask OnMeWinDamage()
		{
			PhantomArenaBattleDetailsView.<OnMeWinDamage>d__77 <OnMeWinDamage>d__;
			<OnMeWinDamage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnMeWinDamage>d__.<>4__this = this;
			<OnMeWinDamage>d__.<>1__state = -1;
			<OnMeWinDamage>d__.<>t__builder.Start<PhantomArenaBattleDetailsView.<OnMeWinDamage>d__77>(ref <OnMeWinDamage>d__);
			return <OnMeWinDamage>d__.<>t__builder.Task;
		}

		// Token: 0x0603800A RID: 229386 RVA: 0x00E2FF77 File Offset: 0x00E2E177
		private void RemoveTimerHandle()
		{
			if (this.TimeHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimeHandle);
				this.TimeHandle = null;
			}
		}

		// Token: 0x0603800B RID: 229387 RVA: 0x00E2FF99 File Offset: 0x00E2E199
		protected override string OnGetLoopAudioEvent()
		{
			if (ModelBase<PhantomArenaBattleModel>.Instance.IsOldBvb)
			{
				return this.ViewInfo.LoopAudioEvent;
			}
			return "play_ui_music_3_0_arena_card_battle";
		}

		// Token: 0x0603800C RID: 229388 RVA: 0x00E2FFB8 File Offset: 0x00E2E1B8
		private void TweenCallNpcX(float value)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			FVectorDouble? fvectorDouble = (uiNiagara != null) ? new FVectorDouble?(uiNiagara.D_K2_GetComponentLocation()) : null;
			if (fvectorDouble != null)
			{
				FVectorDouble newLocation = global::Vector.Create((double)value, fvectorDouble.Value.Y, fvectorDouble.Value.Z).ToUeVector(false);
				UUINiagara uiNiagara2 = base.GetUiNiagara(5);
				if (uiNiagara2 == null)
				{
					return;
				}
				uiNiagara2.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x0603800D RID: 229389 RVA: 0x00E30030 File Offset: 0x00E2E230
		private void TweenCallNpcZ(float value)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			FVectorDouble? fvectorDouble = (uiNiagara != null) ? new FVectorDouble?(uiNiagara.D_K2_GetComponentLocation()) : null;
			if (fvectorDouble != null)
			{
				FVectorDouble newLocation = global::Vector.Create(fvectorDouble.Value.X, fvectorDouble.Value.Y, (double)value).ToUeVector(false);
				UUINiagara uiNiagara2 = base.GetUiNiagara(5);
				if (uiNiagara2 == null)
				{
					return;
				}
				uiNiagara2.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x0603800E RID: 229390 RVA: 0x00E300A8 File Offset: 0x00E2E2A8
		private void TweenCallMeX(float value)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(7);
			FVectorDouble? fvectorDouble = (uiNiagara != null) ? new FVectorDouble?(uiNiagara.D_K2_GetComponentLocation()) : null;
			if (fvectorDouble != null)
			{
				FVectorDouble newLocation = global::Vector.Create((double)value, fvectorDouble.Value.Y, fvectorDouble.Value.Z).ToUeVector(false);
				UUINiagara uiNiagara2 = base.GetUiNiagara(7);
				if (uiNiagara2 == null)
				{
					return;
				}
				uiNiagara2.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x0603800F RID: 229391 RVA: 0x00E30120 File Offset: 0x00E2E320
		private void TweenCallMeZ(float value)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(7);
			FVectorDouble? fvectorDouble = (uiNiagara != null) ? new FVectorDouble?(uiNiagara.D_K2_GetComponentLocation()) : null;
			if (fvectorDouble != null)
			{
				FVectorDouble newLocation = global::Vector.Create(fvectorDouble.Value.X, fvectorDouble.Value.Y, (double)value).ToUeVector(false);
				UUINiagara uiNiagara2 = base.GetUiNiagara(7);
				if (uiNiagara2 == null)
				{
					return;
				}
				uiNiagara2.D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
			}
		}

		// Token: 0x06038010 RID: 229392 RVA: 0x00E30198 File Offset: 0x00E2E398
		private void OnTweenerNpcXEnd()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName(EPhantomBattleHeadAnim.Damage.ToString(), false, null, false);
			}
			this.RefreshOwnShield();
		}

		// Token: 0x06038011 RID: 229393 RVA: 0x00E301EC File Offset: 0x00E2E3EC
		private void OnTweenerMeXEnd()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(7);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName(EPhantomBattleHeadAnim.DamageNPC.ToString(), false, null, false);
			}
			this.RefreshOpponentShield();
		}

		// Token: 0x06038012 RID: 229394 RVA: 0x00E30240 File Offset: 0x00E2E440
		private void OnAccumulateAnimEnd()
		{
			if (!this.IsWin || !this.IsFinishSettle)
			{
				if (this.MeBeforeDamaged > 0)
				{
					this.OnOpponentWinDamage().Forget();
				}
				if (this.NpcBeforeDamaged > 0)
				{
					this.OnMeWinDamage().Forget();
				}
				return;
			}
			int instId = ModelBase<PhantomArenaBattleModel>.Instance.InstId;
			PhantomBattleWinSeq? seqConfig = ConfigBase<PhantomArenaConfig>.Instance.GetSeqConfig(instId);
			if (seqConfig == null)
			{
				ModelBase<PhantomArenaBattleModel>.Instance.TryPhantomBattleDealCardNotify();
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "声骸竞技场3D BvB缺少胜利Seq配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instId", instId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.FlowListName = seqConfig.Value.FlowListName;
			ControllerBase<FlowController>.Instance.StartFlow(seqConfig.Value.FlowListName, seqConfig.Value.FlowId, seqConfig.Value.StateId, null, 0L, false, false, false, null);
		}

		// Token: 0x06038013 RID: 229395 RVA: 0x00E3033C File Offset: 0x00E2E53C
		private void OnDamageAnimEnd(string name)
		{
			if (name != EPhantomBattleHeadAnim.Damage.ToString() && name != EPhantomBattleHeadAnim.DamageNPC.ToString())
			{
				return;
			}
			if (this.DamageAnimEnd)
			{
				return;
			}
			this.DamageAnimEnd = true;
			ModelBase<PhantomArenaBattleModel>.Instance.TryPhantomBattleDealCardNotify();
		}

		// Token: 0x06038014 RID: 229396 RVA: 0x00E30394 File Offset: 0x00E2E594
		private void OnPlotStart(float viewBlendDuration)
		{
			if (!this.IsWin || this.FlowListName == "")
			{
				return;
			}
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleLife);
			int battleStatusValue2 = ModelBase<PhantomArenaBattleModel>.Instance.OpponentData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleMaxLife);
			PhantomArenaBattleDetailsAreaItem opponentArea = this.OpponentArea;
			if (opponentArea != null)
			{
				opponentArea.RoleItem.RefreshLifeNum(Math.Max(battleStatusValue, 0), battleStatusValue2);
			}
			BattleHeadStatePanel headStatePanel = this.HeadStatePanel;
			if (headStatePanel != null)
			{
				headStatePanel.RefreshAllHeadState(0f);
			}
			this.TimeHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaBattleDamageView, this.MeOriginalDamage, null);
				this.TimeHandle = null;
			}, 4500f, null, null, true, 1f);
		}

		// Token: 0x06038015 RID: 229397 RVA: 0x00E3043C File Offset: 0x00E2E63C
		private void OnPlotEnd(PlotResultInfo plotInfo)
		{
			if (!this.IsWin || plotInfo.FlowListName != this.FlowListName)
			{
				return;
			}
			if (this.TimeHandle != null)
			{
				this.RemoveTimerHandle();
			}
			else
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomArenaBattleDamageView, null);
			}
			ModelBase<PhantomArenaBattleModel>.Instance.TryPhantomBattleDealCardNotify();
		}

		// Token: 0x06038016 RID: 229398 RVA: 0x00E3048F File Offset: 0x00E2E68F
		private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
		{
			if (last == EInputControllerMainType.Gamepad)
			{
				this.Proxy.SetIsInGamepadNavigation(false);
			}
		}

		// Token: 0x0402003F RID: 131135
		private const int ANIM_DAMAGE_DELAY = 4500;

		// Token: 0x04020040 RID: 131136
		private const int DAMAGE_FIRST = 10;

		// Token: 0x04020041 RID: 131137
		protected PhantomArenaBattleDetailsAreaItem OwnArea;

		// Token: 0x04020042 RID: 131138
		protected PhantomArenaBattleDetailsAreaItem OpponentArea;

		// Token: 0x04020043 RID: 131139
		protected PhantomArenaBattleDetailsViewProxy Proxy;

		// Token: 0x04020044 RID: 131140
		protected BattleHeadStatePanel HeadStatePanel;

		// Token: 0x04020045 RID: 131141
		protected PhantomArenaJoystick MobileJoystick;

		// Token: 0x04020046 RID: 131142
		protected PhantomArenaBattleDamageStatisticsPanel DamageStatistics;

		// Token: 0x04020047 RID: 131143
		protected bool IsWin;

		// Token: 0x04020048 RID: 131144
		protected bool AccumulateTween;

		// Token: 0x04020049 RID: 131145
		protected bool AnimDamageTween;

		// Token: 0x0402004A RID: 131146
		protected UCurveFloat CurveZ;

		// Token: 0x0402004B RID: 131147
		protected UCurveFloat CurveMeX;

		// Token: 0x0402004C RID: 131148
		protected UCurveFloat CurveOppositeX;

		// Token: 0x0402004D RID: 131149
		protected UCurveFloat CurveCommon;

		// Token: 0x0402004E RID: 131150
		protected UCurveFloat CurveDamageX;

		// Token: 0x0402004F RID: 131151
		protected UCurveFloat CurveDamageYMe;

		// Token: 0x04020050 RID: 131152
		protected UCurveFloat CurveDamageYNpc;

		// Token: 0x04020051 RID: 131153
		protected LguiFloatTween TweenerNpcX;

		// Token: 0x04020052 RID: 131154
		protected LguiFloatTween TweenerNpcZ;

		// Token: 0x04020053 RID: 131155
		protected LguiFloatTween TweenerMeX;

		// Token: 0x04020054 RID: 131156
		protected LguiFloatTween TweenerMeZ;

		// Token: 0x04020055 RID: 131157
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x04020056 RID: 131158
		protected int MeDamaged;

		// Token: 0x04020057 RID: 131159
		protected int MeBeforeDamaged;

		// Token: 0x04020058 RID: 131160
		protected int MeOriginalDamage;

		// Token: 0x04020059 RID: 131161
		protected int NpcDamaged;

		// Token: 0x0402005A RID: 131162
		protected int NpcBeforeDamaged;

		// Token: 0x0402005B RID: 131163
		protected int NpcOriginalDamage;

		// Token: 0x0402005C RID: 131164
		protected bool IsFinishSettle;

		// Token: 0x0402005D RID: 131165
		protected string FlowListName = "";

		// Token: 0x0402005E RID: 131166
		protected bool DamageAnimEnd;

		// Token: 0x0402005F RID: 131167
		protected TimerHandle TimeHandle;

		// Token: 0x0200B5D3 RID: 46547
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403842D RID: 230445
			public const int OwnArea = 0;

			// Token: 0x0403842E RID: 230446
			public const int OpponentArea = 1;

			// Token: 0x0403842F RID: 230447
			public const int BackBtn = 2;

			// Token: 0x04038430 RID: 230448
			public const int SkipBtn = 3;

			// Token: 0x04038431 RID: 230449
			public const int DraggableComponent = 4;

			// Token: 0x04038432 RID: 230450
			public const int NiagaraPoint = 5;

			// Token: 0x04038433 RID: 230451
			public const int TxtSpeed = 6;

			// Token: 0x04038434 RID: 230452
			public const int NiagaraPointMe = 7;

			// Token: 0x04038435 RID: 230453
			public const int CameraMoveItem = 8;

			// Token: 0x04038436 RID: 230454
			public const int DamageStatisticsItem = 9;
		}
	}
}
