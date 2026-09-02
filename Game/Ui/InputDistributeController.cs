using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049EF RID: 18927
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class InputDistributeController : ControllerBase<InputDistributeController>
	{
		// Token: 0x060317EC RID: 202732 RVA: 0x00C55BFC File Offset: 0x00C53DFC
		protected override bool OnInit()
		{
			this.AddEvents();
			return true;
		}

		// Token: 0x060317ED RID: 202733 RVA: 0x00C55C05 File Offset: 0x00C53E05
		protected override bool OnClear()
		{
			this.RemoveEvents();
			return true;
		}

		// Token: 0x060317EE RID: 202734 RVA: 0x00C55C10 File Offset: 0x00C53E10
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnAddNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnClearNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.ShowHUD, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.HideHUD, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.ReConnectBegin, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.ReConnectSuccess, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.LogOut, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnStartLoadingState, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleByResetToBattleView, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.SdkKick, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.CharOnRoleDrown, new Action<bool>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPlotWaitViewDone, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add<EOperationType, EOperationType>(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnCameraSequenceSetUiVisible, new Action<bool, string>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnEnterTransitionMap, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Add(EEventName.OnOnlyAllowFightInputStateChanged, new Action(this.OnOnlyAllowFightInputStateChanged));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OpenViewBegined, new Action<EUiViewName>(this.OnOpenViewBegined));
			Singleton<EventSystem>.Instance.Add<EUiViewName>(EEventName.OpenViewFail, new Action<EUiViewName>(this.OnOpenViewFail));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.FloatQueueCloseView, new Action<EUiViewName, int>(this.OnFloatQueueCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleByResetToBattleView, new Action(this.OnResetModuleByResetToBattleView));
		}

		// Token: 0x060317EF RID: 202735 RVA: 0x00C55F20 File Offset: 0x00C54120
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnClearNotAllowFightInputViewName, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.ShowHUD, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.HideHUD, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.ReConnectBegin, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.ReConnectSuccess, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.LogOut, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStartLoadingState, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFinishLoadingState, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleByResetToBattleView, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.SdkKick, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.CharOnRoleDrown, new Action<bool>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlotWaitViewDone, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove<EOperationType, EOperationType>(EEventName.ShowTypeChange, new Action<EOperationType, EOperationType>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove<bool, string>(EEventName.OnCameraSequenceSetUiVisible, new Action<bool, string>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterTransitionMap, new Action(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove<bool, string>(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.OnRefreshInputDistributeTag));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnOnlyAllowFightInputStateChanged, new Action(this.OnOnlyAllowFightInputStateChanged));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove<EUiViewName>(EEventName.OpenViewBegined, new Action<EUiViewName>(this.OnOpenViewBegined));
			Singleton<EventSystem>.Instance.Remove<EUiViewName>(EEventName.OpenViewFail, new Action<EUiViewName>(this.OnOpenViewFail));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.FloatQueueCloseView, new Action<EUiViewName, int>(this.OnFloatQueueCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleByResetToBattleView, new Action(this.OnResetModuleByResetToBattleView));
		}

		// Token: 0x060317F0 RID: 202736 RVA: 0x00C5622D File Offset: 0x00C5442D
		private void OnRefreshInputDistributeTag(bool _)
		{
			this.RefreshInputTag();
		}

		// Token: 0x060317F1 RID: 202737 RVA: 0x00C56235 File Offset: 0x00C54435
		private void OnRefreshInputDistributeTag(bool _, string _1)
		{
			this.RefreshInputTag();
		}

		// Token: 0x060317F2 RID: 202738 RVA: 0x00C5623D File Offset: 0x00C5443D
		private void OnOnlyAllowFightInputStateChanged()
		{
			this.RefreshInputTag();
		}

		// Token: 0x060317F3 RID: 202739 RVA: 0x00C56245 File Offset: 0x00C54445
		private void OnRefreshInputDistributeTag(EOperationType last, EOperationType now)
		{
			this.RefreshInputTag();
		}

		// Token: 0x060317F4 RID: 202740 RVA: 0x00C5624D File Offset: 0x00C5444D
		private void OnRefreshInputDistributeTag()
		{
			this.RefreshInputTag();
		}

		// Token: 0x060317F5 RID: 202741 RVA: 0x00C56258 File Offset: 0x00C54458
		private void OnWorldDone()
		{
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "当世界加载完成时，清理所有输入分发Tag", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ClearAllNotAllowFightInputViewNames();
		}

		// Token: 0x060317F6 RID: 202742 RVA: 0x00C56288 File Offset: 0x00C54488
		private void OnResetModuleByResetToBattleView()
		{
			Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]当回到主界面时，清理所有输入分发Tag", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ClearAllNotAllowFightInputViewNames();
		}

		// Token: 0x060317F7 RID: 202743 RVA: 0x00C562B8 File Offset: 0x00C544B8
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
			if (!ConfigBase<InputDistributeConfig>.Instance.IsViewAllowFightInput(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]当打开界面时, 记录不允许输入的界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<InputDistributeModel>.Instance.AddNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
		}

		// Token: 0x060317F8 RID: 202744 RVA: 0x00C5631C File Offset: 0x00C5451C
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (!ConfigBase<InputDistributeConfig>.Instance.IsViewAllowFightInput(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]当关闭界面时, 删除不允许输入的界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<InputDistributeModel>.Instance.RemoveNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveNotAllowFightInputViewName);
		}

		// Token: 0x060317F9 RID: 202745 RVA: 0x00C56380 File Offset: 0x00C54580
		private void OnOpenViewBegined(EUiViewName viewName)
		{
			if (!ConfigBase<InputDistributeConfig>.Instance.IsViewAllowFightInput(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]当打开界面开始时, 将界面添加至“不允许战斗输入”Set中";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<InputDistributeModel>.Instance.AddNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnAddNotAllowFightInputViewName);
		}

		// Token: 0x060317FA RID: 202746 RVA: 0x00C563E4 File Offset: 0x00C545E4
		private void OnOpenViewFail(EUiViewName viewName)
		{
			if (!ConfigBase<InputDistributeConfig>.Instance.IsViewAllowFightInput(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]当打开界面结束时, 清理“不允许战斗输入”Set";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<InputDistributeModel>.Instance.RemoveNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveNotAllowFightInputViewName);
		}

		// Token: 0x060317FB RID: 202747 RVA: 0x00C56448 File Offset: 0x00C54648
		private void OnFloatQueueCloseView(EUiViewName viewName, int viewId)
		{
			if (!ConfigBase<InputDistributeConfig>.Instance.IsViewAllowFightInput(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[InputDistribute]当Float队列关闭界面时, 删除不允许输入的界面";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<InputDistributeModel>.Instance.RemoveNotAllowFightInputViewName(viewName);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRemoveNotAllowFightInputViewName);
		}

		// Token: 0x060317FC RID: 202748 RVA: 0x00C564A9 File Offset: 0x00C546A9
		private void ClearAllNotAllowFightInputViewNames()
		{
			ModelBase<InputDistributeModel>.Instance.ClearAllNotAllowFightInputViewNames();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnClearNotAllowFightInputViewName);
		}

		// Token: 0x060317FD RID: 202749 RVA: 0x00C564C5 File Offset: 0x00C546C5
		public void RefreshInputTag()
		{
			ModelBase<InputDistributeModel>.Instance.RefreshInputDistributeTag();
		}

		// Token: 0x060317FE RID: 202750 RVA: 0x00C564D1 File Offset: 0x00C546D1
		public void BindAction(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindAction(actionName, actionCallback);
		}

		// Token: 0x060317FF RID: 202751 RVA: 0x00C564DF File Offset: 0x00C546DF
		public void ExecuteDelayInputAction(string actionName)
		{
			ModelBase<InputDistributeModel>.Instance.ExecuteDelayInputAction(actionName);
		}

		// Token: 0x06031800 RID: 202752 RVA: 0x00C564EC File Offset: 0x00C546EC
		public void BindActions(IReadOnlyList<string> actionNames, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindActions(actionNames, actionCallback);
		}

		// Token: 0x06031801 RID: 202753 RVA: 0x00C564FA File Offset: 0x00C546FA
		public void UnBindAction(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindAction(actionName, actionCallback);
		}

		// Token: 0x06031802 RID: 202754 RVA: 0x00C56508 File Offset: 0x00C54708
		public void UnBindActions(IReadOnlyList<string> actionNames, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindActions(actionNames, actionCallback);
		}

		// Token: 0x06031803 RID: 202755 RVA: 0x00C56516 File Offset: 0x00C54716
		public void BindActionIgnoreLimit(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindActionIgnoreLimit(actionName, actionCallback);
		}

		// Token: 0x06031804 RID: 202756 RVA: 0x00C56524 File Offset: 0x00C54724
		public void UnBindActionIgnoreLimit(string actionName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindActionIgnoreLimit(actionName, actionCallback);
		}

		// Token: 0x06031805 RID: 202757 RVA: 0x00C56532 File Offset: 0x00C54732
		public void BindAxis(string axisName, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindAxis(axisName, axisCallback);
		}

		// Token: 0x06031806 RID: 202758 RVA: 0x00C56540 File Offset: 0x00C54740
		public void BindAxes(IReadOnlyList<string> axisNames, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindAxes(axisNames, axisCallback);
		}

		// Token: 0x06031807 RID: 202759 RVA: 0x00C5654E File Offset: 0x00C5474E
		public void UnBindAxis(string axisName, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindAxis(axisName, axisCallback);
		}

		// Token: 0x06031808 RID: 202760 RVA: 0x00C5655C File Offset: 0x00C5475C
		public void UnBindAxes(IReadOnlyList<string> axisNames, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindAxes(axisNames, axisCallback);
		}

		// Token: 0x06031809 RID: 202761 RVA: 0x00C5656A File Offset: 0x00C5476A
		public bool HasAxisBind(string axisName)
		{
			return ModelBase<InputDistributeModel>.Instance.HasAxisBind(axisName);
		}

		// Token: 0x0603180A RID: 202762 RVA: 0x00C56577 File Offset: 0x00C54777
		public bool HasActionBind(string actionName)
		{
			return ModelBase<InputDistributeModel>.Instance.HasActionBind(actionName);
		}

		// Token: 0x0603180B RID: 202763 RVA: 0x00C56584 File Offset: 0x00C54784
		public bool IsActionRespondable(string actionName)
		{
			return ModelBase<InputDistributeModel>.Instance.IsActionRespondable(actionName);
		}

		// Token: 0x0603180C RID: 202764 RVA: 0x00C56591 File Offset: 0x00C54791
		public void BindAxisIgnoreLimit(string axisName, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindAxisIgnoreLimit(axisName, axisCallback);
		}

		// Token: 0x0603180D RID: 202765 RVA: 0x00C5659F File Offset: 0x00C5479F
		public void UnBindAxisIgnoreLimit(string axisName, TInputHandle<float> axisCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindAxisIgnoreLimit(axisName, axisCallback);
		}

		// Token: 0x0603180E RID: 202766 RVA: 0x00C565AD File Offset: 0x00C547AD
		public void BindTouch(int touchId, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindTouch(touchId, touchCallback);
		}

		// Token: 0x0603180F RID: 202767 RVA: 0x00C565BB File Offset: 0x00C547BB
		public void BindTouches(int[] touchIdList, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindTouches(touchIdList, touchCallback);
		}

		// Token: 0x06031810 RID: 202768 RVA: 0x00C565C9 File Offset: 0x00C547C9
		public void UnBindTouch(int touchId, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindTouch(touchId, touchCallback);
		}

		// Token: 0x06031811 RID: 202769 RVA: 0x00C565D7 File Offset: 0x00C547D7
		public void UnBindTouches(IReadOnlyList<int> touchIdList, TInputHandle<InputDistributeDefine.ITouchData> touchCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindTouches(touchIdList, touchCallback);
		}

		// Token: 0x06031812 RID: 202770 RVA: 0x00C565E5 File Offset: 0x00C547E5
		public void BindKey(string keyName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.BindKey(keyName, actionCallback);
		}

		// Token: 0x06031813 RID: 202771 RVA: 0x00C565F3 File Offset: 0x00C547F3
		public void UnBindKey(string keyName, TInputHandle<InputDistributeDefine.EActionType> actionCallback)
		{
			ModelBase<InputDistributeModel>.Instance.UnBindKey(keyName, actionCallback);
		}

		// Token: 0x06031814 RID: 202772 RVA: 0x00C56601 File Offset: 0x00C54801
		public void InputAxis(string axisName, float value, bool force = false)
		{
			if (Math.Abs(value) <= 0.02f)
			{
				ModelBase<InputDistributeModel>.Instance.InputAxis(axisName, 0f, force);
				return;
			}
			ModelBase<InputDistributeModel>.Instance.InputAxis(axisName, value, force);
		}

		// Token: 0x06031815 RID: 202773 RVA: 0x00C5662F File Offset: 0x00C5482F
		public bool IsAxisRespondable(string axisName)
		{
			return ModelBase<InputDistributeModel>.Instance.IsAxisRespondable(axisName);
		}

		// Token: 0x06031816 RID: 202774 RVA: 0x00C5663C File Offset: 0x00C5483C
		public bool InputAction(string actionName, bool bPress)
		{
			return ModelBase<InputDistributeModel>.Instance.InputAction(actionName, bPress);
		}

		// Token: 0x06031817 RID: 202775 RVA: 0x00C5664A File Offset: 0x00C5484A
		public void InputTouch(int touchId, InputDistributeDefine.ITouchData touchData)
		{
			ModelBase<InputDistributeModel>.Instance.InputTouch(touchId, touchData);
		}

		// Token: 0x06031818 RID: 202776 RVA: 0x00C56658 File Offset: 0x00C54858
		public void InputKey(string keyName, bool bPress)
		{
			ModelBase<InputDistributeModel>.Instance.InputKey(keyName, bPress);
		}

		// Token: 0x06031819 RID: 202777 RVA: 0x00C56666 File Offset: 0x00C54866
		[NullableContext(2)]
		public string GetCurrentActionName()
		{
			return ModelBase<InputDistributeModel>.Instance.GetCurrentActionName();
		}

		// Token: 0x0603181A RID: 202778 RVA: 0x00C56672 File Offset: 0x00C54872
		[NullableContext(2)]
		public string GetCurrentAxisName()
		{
			return ModelBase<InputDistributeModel>.Instance.GetCurrentAxisName();
		}

		// Token: 0x0603181B RID: 202779 RVA: 0x00C5667E File Offset: 0x00C5487E
		public bool IsAllowFightInput()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowFightInput();
		}

		// Token: 0x0603181C RID: 202780 RVA: 0x00C5668A File Offset: 0x00C5488A
		public bool IsAllowFightMoveInput()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowFightMoveInput();
		}

		// Token: 0x0603181D RID: 202781 RVA: 0x00C56696 File Offset: 0x00C54896
		public bool IsAllowFightActionInput()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowFightActionInput();
		}

		// Token: 0x0603181E RID: 202782 RVA: 0x00C566A2 File Offset: 0x00C548A2
		public bool IsAllowFightCameraRotationInput()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowFightCameraRotationInput();
		}

		// Token: 0x0603181F RID: 202783 RVA: 0x00C566AE File Offset: 0x00C548AE
		public bool IsAllowFightCameraZoomInput()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowFightCameraZoomInput();
		}

		// Token: 0x06031820 RID: 202784 RVA: 0x00C566BA File Offset: 0x00C548BA
		public bool IsAllowHeadRotation()
		{
			return ModelBase<InputDistributeModel>.Instance.IsAllowHeadRotation();
		}
	}
}
