using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Render;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x0200501A RID: 20506
	[NullableContext(1)]
	[Nullable(0)]
	public class RouletteMainView : UiTickViewBase
	{
		// Token: 0x17008AD0 RID: 35536
		// (get) Token: 0x06034DA3 RID: 216483 RVA: 0x00D458AA File Offset: 0x00D43AAA
		private RouletteComponentMain RouletteComponent
		{
			get
			{
				return this.ViewProxy.GetRouletteComponent();
			}
		}

		// Token: 0x06034DA4 RID: 216484 RVA: 0x00D458B7 File Offset: 0x00D43AB7
		public RouletteMainView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034DA5 RID: 216485 RVA: 0x00D458C0 File Offset: 0x00D43AC0
		protected unsafe override void OnRegisterComponent()
		{
			if (this.OpenParam == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Phantom, ELogAuthor.YYZ, "[Roulette] 轮盘打开时未获取到参数", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			else
			{
				this.ViewProxy = (RouletteMainViewProxyBase)this.OpenParam;
			}
			this.ViewProxy.RegisterView(this);
			EOperationType operationType = Singleton<Info>.Instance.OperationType;
			if (operationType != EOperationType.Pad)
			{
				if (operationType == EOperationType.Desktop)
				{
					int num = 6;
					List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
					CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
					Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
					int num2 = 0;
					*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
					num2++;
					*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
					num2++;
					*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
					num2++;
					*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
					num2++;
					*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
					num2++;
					*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
					this.ComponentRegisterInfos = list;
					num2 = 2;
					List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
					CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
					Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
					num = 0;
					*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnRouletteTypeSwitch));
					num++;
					*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnRouletteTypeSwitch));
					this.BtnBindInfo = list2;
					return;
				}
			}
			else
			{
				int num = 1;
				List<ValueTuple<int, Type>> list3 = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list3, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list3);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
				this.ComponentRegisterInfos = list3;
			}
		}

		// Token: 0x06034DA6 RID: 216486 RVA: 0x00D45ABC File Offset: 0x00D43CBC
		protected override void OnBeforeCreate()
		{
			UiInteractLogReport.RecordRouletteOpen();
		}

		// Token: 0x06034DA7 RID: 216487 RVA: 0x00D45AC4 File Offset: 0x00D43CC4
		protected override UniTask OnBeforeStartAsync()
		{
			RouletteMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RouletteMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034DA8 RID: 216488 RVA: 0x00D45B08 File Offset: 0x00D43D08
		protected override void OnStart()
		{
			this.ViewProxy.Start();
			this.RefreshRouletteType();
			if (Singleton<Info>.Instance.OperationType == EOperationType.Desktop)
			{
				bool panelSwitchOpen = this.ViewProxy.GetPanelSwitchOpen();
				base.GetItem(1).SetUIActive(panelSwitchOpen);
				this.SetTips();
			}
			this.SetRouletteParam();
			float? floatConfig = ConfigCommonParamById.GetFloatConfig("Roulette_Main_Gamepad_DeadLimit");
			Vector2D beginPos = Singleton<Info>.Instance.IsInKeyBoard() ? Vector2D.Create(base.GetRootItem().GetPositionInScreen(true)) : null;
			this.InputManager = RouletteInputManager.CreateInput(Singleton<Info>.Instance.InputControllerMainType, beginPos, null, this.ViewProxy.TouchId, floatConfig);
			this.InputManager.BindEvent();
			this.InputManager.OnInit();
			this.InputManager.RouletteViewType = ERouletteViewType.Main;
			this.InputManager.SetEndInputEvent(delegate
			{
				this.CloseSelf(true);
			});
			this.BlockOperation();
			this.InputManager.ActivateInput(true);
			this.ViewProxy.AddEventListenerByStart();
		}

		// Token: 0x06034DA9 RID: 216489 RVA: 0x00D45C0A File Offset: 0x00D43E0A
		protected override void OnBeforeShow()
		{
			this.ViewProxy.BeforeShow();
			ControllerBase<RenderModuleController>.Instance.GlobalTimeDilation = 0.1f;
		}

		// Token: 0x06034DAA RID: 216490 RVA: 0x00D45C26 File Offset: 0x00D43E26
		private void BlockOperation()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.ExploreRoulette, new EBattleUiChild[]
			{
				EBattleUiChild.InteractionHint
			}, false, true, 0);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRouletteViewVisibleChanged, true);
		}

		// Token: 0x06034DAB RID: 216491 RVA: 0x00D45C58 File Offset: 0x00D43E58
		protected override void OnBeforeDestroy()
		{
			this.ViewProxy.RemoveEventListenerByStart();
			this.RouletteUiItem = null;
			this.ViewProxy.Destroy();
			if (this.InputManager != null)
			{
				this.InputManager.Destroy();
				this.InputManager = null;
			}
		}

		// Token: 0x06034DAC RID: 216492 RVA: 0x00D45C91 File Offset: 0x00D43E91
		protected override void OnAfterDestroy()
		{
			ControllerBase<RenderModuleController>.Instance.GlobalTimeDilation = 1f;
			this.FreeOperation();
			UiInteractLogReport.RecordRouletteClose();
		}

		// Token: 0x06034DAD RID: 216493 RVA: 0x00D45CAD File Offset: 0x00D43EAD
		private void FreeOperation()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.ExploreRoulette, new EBattleUiChild[]
			{
				EBattleUiChild.InteractionHint
			}, true, true, 0);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRouletteViewVisibleChanged, false);
		}

		// Token: 0x06034DAE RID: 216494 RVA: 0x00D45CE0 File Offset: 0x00D43EE0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<InputDistributeTag>>(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnCheckDisableInput));
			Singleton<EventSystem>.Instance.Add(EEventName.OpenRouletteSetView, new Action(this.OnOpenRouletteSetView));
			Singleton<EventSystem>.Instance.Add(EEventName.RouletteSwitchToggleComponentEmit, new Action(this.OnRouletteSwitchToggleComponentEmit));
			string actionName = this.ViewProxy.GetActionName();
			ControllerBase<InputDistributeController>.Instance.BindAction(actionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputRouletteAction));
			this.ViewProxy.AddEventListener();
		}

		// Token: 0x06034DAF RID: 216495 RVA: 0x00D45D8C File Offset: 0x00D43F8C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInputDistributeTagChanged, new Action<IReadOnlyList<InputDistributeTag>>(this.OnCheckDisableInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenRouletteSetView, new Action(this.OnOpenRouletteSetView));
			Singleton<EventSystem>.Instance.Remove(EEventName.RouletteSwitchToggleComponentEmit, new Action(this.OnRouletteSwitchToggleComponentEmit));
			string actionName = this.ViewProxy.GetActionName();
			ControllerBase<InputDistributeController>.Instance.UnBindAction(actionName, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputRouletteAction));
			this.ViewProxy.RemoveEventListener();
		}

		// Token: 0x06034DB0 RID: 216496 RVA: 0x00D45E37 File Offset: 0x00D44037
		public void CloseSelf(bool emitSelectOn = true)
		{
			if (emitSelectOn)
			{
				this.RouletteComponent.TryEmitCurrentGridSelectOn();
			}
			base.CloseMe(null);
		}

		// Token: 0x06034DB1 RID: 216497 RVA: 0x00D45E50 File Offset: 0x00D44050
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			if (base.IsHideOrHiding)
			{
				return;
			}
			ValueTuple<int?, int?> valueTuple = this.InputManager.Tick(delta);
			int? item = valueTuple.Item1;
			int? item2 = valueTuple.Item2;
			this.RouletteComponent.Refresh(item, item2);
		}

		// Token: 0x06034DB2 RID: 216498 RVA: 0x00D45E93 File Offset: 0x00D44093
		private void SetRouletteParam()
		{
			this.SetRouletteInputType();
			this.SetRoulettePlatformType();
			this.SetRouletteType();
			this.RouletteComponent.SetAllGridToggleSelfInteractive(false);
		}

		// Token: 0x06034DB3 RID: 216499 RVA: 0x00D45EB3 File Offset: 0x00D440B3
		private void SetRouletteType()
		{
			this.RouletteComponent.RefreshRouletteType();
		}

		// Token: 0x06034DB4 RID: 216500 RVA: 0x00D45EC0 File Offset: 0x00D440C0
		private void SetRoulettePlatformType()
		{
			this.RouletteComponent.RefreshRoulettePlatformType();
		}

		// Token: 0x06034DB5 RID: 216501 RVA: 0x00D45ECD File Offset: 0x00D440CD
		private void SetRouletteInputType()
		{
			this.RouletteComponent.RefreshRouletteInputType();
		}

		// Token: 0x06034DB6 RID: 216502 RVA: 0x00D45EDC File Offset: 0x00D440DC
		private void RefreshRouletteType()
		{
			if (Singleton<Info>.Instance.OperationType == EOperationType.Desktop)
			{
				bool canOpenAssembly = this.ViewProxy.GetCanOpenAssembly(this.ViewProxy.RouletteType);
				base.GetItem(5).SetUIActive(canOpenAssembly);
				base.GetExtendToggle(2).SetToggleState(this.ViewProxy.GetToggle1State().GetValueOrDefault(), false, false, false);
				base.GetExtendToggle(3).SetToggleState(this.ViewProxy.GetToggle2State().GetValueOrDefault(), false, false, false);
			}
		}

		// Token: 0x06034DB7 RID: 216503 RVA: 0x00D45F60 File Offset: 0x00D44160
		private void OnRouletteTypeSwitch(EToggleState toggleState)
		{
			if (!this.ViewProxy.CanSwitchType)
			{
				return;
			}
			ValueTuple<int, int> currentIndexAndAngle = this.RouletteComponent.GetCurrentIndexAndAngle();
			int item = currentIndexAndAngle.Item1;
			int item2 = currentIndexAndAngle.Item2;
			this.ViewProxy.RouletteTypeSwitch();
			this.RefreshRouletteType();
			this.SetRouletteParam();
			this.RouletteComponent.Refresh(new int?(item), new int?(item2));
		}

		// Token: 0x06034DB8 RID: 216504 RVA: 0x00D45FC4 File Offset: 0x00D441C4
		private void InputControllerMainTypeChange(EInputControllerMainType eInputControllerMainType, EInputControllerMainType inputControllerMainType)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "检测到轮盘输入变化,关闭自身";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("新输入类型", Singleton<Info>.Instance.InputControllerType);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CloseSelf(false);
		}

		// Token: 0x06034DB9 RID: 216505 RVA: 0x00D4600D File Offset: 0x00D4420D
		private void OnCheckDisableInput(IReadOnlyList<InputDistributeTag> inputDistributeTags)
		{
			if (!ModelBase<InputDistributeModel>.Instance.IsTagMatchAnyCurrentInputTag("UiInputRoot.ShortcutKeyTag", false))
			{
				this.CloseSelf(false);
			}
		}

		// Token: 0x06034DBA RID: 216506 RVA: 0x00D46028 File Offset: 0x00D44228
		private void SetTips()
		{
			string actionName = this.ViewProxy.GetActionName();
			UUIText text = base.GetText(4);
			text.SetUIActive(Singleton<Info>.Instance.IsInGamepad());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ToolsClosePC_Text", new <>z__ReadOnlySingleElementList<object>(ModelBase<RouletteModel>.Instance.GetRouletteKeyRichText(actionName)));
		}

		// Token: 0x06034DBB RID: 216507 RVA: 0x00D46079 File Offset: 0x00D44279
		private void OnInputRouletteAction(string name, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType == InputDistributeDefine.EActionType.Release)
			{
				this.CloseSelf(true);
			}
		}

		// Token: 0x06034DBC RID: 216508 RVA: 0x00D46088 File Offset: 0x00D44288
		private void OnOpenRouletteSetView()
		{
			ControllerBase<RouletteController>.Instance.OpenAssemblyView(this.ViewProxy.RouletteType, null, null, null);
			this.CloseSelf(false);
		}

		// Token: 0x06034DBD RID: 216509 RVA: 0x00D460CD File Offset: 0x00D442CD
		private void OnRouletteSwitchToggleComponentEmit()
		{
			this.OnRouletteTypeSwitch(EToggleState.ETT_UnChecked);
		}

		// Token: 0x0401E778 RID: 124792
		[Nullable(2)]
		private RouletteInputBase InputManager;

		// Token: 0x0401E779 RID: 124793
		[Nullable(2)]
		public UUIItem RouletteUiItem;

		// Token: 0x0401E77A RID: 124794
		private RouletteMainViewProxyBase ViewProxy;
	}
}
