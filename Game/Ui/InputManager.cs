using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A29 RID: 18985
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InputManager : Singleton<InputManager>
	{
		// Token: 0x0603199E RID: 203166 RVA: 0x00C5B63F File Offset: 0x00C5983F
		public void Init()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UiManagerInit, new Action(this.Start));
			Singleton<EventSystem>.Instance.Add(EEventName.UiManagerDestroy, new Action(this.Clear));
		}

		// Token: 0x0603199F RID: 203167 RVA: 0x00C5B674 File Offset: 0x00C59874
		private void Start()
		{
			if (!this.IsInit)
			{
				this.RegisterHandle();
				this.IsInit = true;
				this.ShowMouseViewRecord.Clear();
				this.DisableShortcutKeyViewRecord.Clear();
				this.DisableCloseViewByShortcutKeyViewRecord.Clear();
				this.IsAltPress = false;
				this.ImmersiveMouseModule = new ImmersiveMouseModule();
				this.ImmersiveMouseModule.Initialize();
			}
			UKuroInputFunctionLibrary.ClearInputModeReply();
		}

		// Token: 0x060319A0 RID: 203168 RVA: 0x00C5B6DC File Offset: 0x00C598DC
		private void Clear()
		{
			if (this.IsInit)
			{
				this.RemoveHandle();
				this.ShowMouseViewRecord.Clear();
				this.DisableShortcutKeyViewRecord.Clear();
				this.DisableCloseViewByShortcutKeyViewRecord.Clear();
				ViewHotKeyHandleContainer viewHotKeyHandleContainer = this.ViewHotKeyHandleContainer;
				if (viewHotKeyHandleContainer != null)
				{
					viewHotKeyHandleContainer.Clear();
				}
				this.IsInit = false;
				this.IsAltPress = false;
			}
		}

		// Token: 0x060319A1 RID: 203169 RVA: 0x00C5B738 File Offset: 0x00C59938
		private void AddViewHotKeyHandle(OpenAndCloseViewHotKey config)
		{
			if (this.ViewHotKeyHandleContainer.IsDataExist(config.Id))
			{
				return;
			}
			string[] array = new string[config.ViewParamLength];
			for (int i = 0; i < config.ViewParamLength; i++)
			{
				array[i] = config.ViewParam(i);
			}
			ViewHotKeyHandle viewHotKeyHandle = ViewHotKeyHandleFactory.CreateViewHotKeyHandle(new OpenAndCloseViewHotKey
			{
				ConfigId = config.Id,
				ActionName = config.ActionName,
				InputControllerType = (EOpenAndCloseViewInputControllerType)config.InputControllerType,
				ViewName = (EUiViewName)config.ViewName,
				ViewParam = array,
				IsPressTrigger = config.IsPressTrigger,
				PressStartTime = config.PressStartTime,
				PressTriggerTime = config.PressTriggerTime,
				IsReleaseTrigger = config.IsReleaseTrigger,
				ReleaseInvalidTime = config.ReleaseInvalidTime,
				IsPressClose = config.IsPressClose,
				IsReleaseClose = config.IsReleaseClose,
				IsAllowOpenViewByShortcutKey = new Func<bool>(this.IsAllowOpenViewByShortcutKey),
				IsAllowCloseViewByShortcutKey = new Func<bool>(this.IsAllowCloseViewByShortcutKey),
				IsLockShortcutKey = delegate(string actionName, InputDistributeDefine.EActionType actionType)
				{
					using (Dictionary<string, TLockShortcutKeyDelegate>.ValueCollection.Enumerator enumerator = this.LockShortcutKeyDelegateMap.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current(actionName, actionType))
							{
								return true;
							}
						}
					}
					return false;
				}
			}, config.HandleType);
			viewHotKeyHandle.Bind();
			this.ViewHotKeyHandleContainer.Add(viewHotKeyHandle);
		}

		// Token: 0x060319A2 RID: 203170 RVA: 0x00C5B87C File Offset: 0x00C59A7C
		private void RemoveViewHotKeyHandle(OpenAndCloseViewHotKey config)
		{
			ViewHotKeyHandle[] array = this.ViewHotKeyHandleContainer.Get((EUiViewName)config.ViewName);
			if (array == null)
			{
				return;
			}
			foreach (ViewHotKeyHandle viewHotKeyHandle in array)
			{
				this.ViewHotKeyHandleContainer.Remove(viewHotKeyHandle);
			}
		}

		// Token: 0x060319A3 RID: 203171 RVA: 0x00C5B8C5 File Offset: 0x00C59AC5
		private bool DefaultLockShortcutKeyDelegate(string actionName, InputDistributeDefine.EActionType actionType)
		{
			return true;
		}

		// Token: 0x060319A4 RID: 203172 RVA: 0x00C5B8C8 File Offset: 0x00C59AC8
		public void AddViewHotKeyActionByType(EInputDataType type)
		{
			IReadOnlyList<OpenAndCloseViewHotKey> allOpenAndCloseViewHotKeyConfig = ConfigBase<ViewHotKeyConfig>.Instance.GetAllOpenAndCloseViewHotKeyConfig();
			if (allOpenAndCloseViewHotKeyConfig == null)
			{
				return;
			}
			foreach (OpenAndCloseViewHotKey config in allOpenAndCloseViewHotKeyConfig)
			{
				if (config.GetEffectiveTypeListBytes().Contains((int)type))
				{
					this.AddViewHotKeyHandle(config);
				}
			}
		}

		// Token: 0x060319A5 RID: 203173 RVA: 0x00C5B930 File Offset: 0x00C59B30
		public void RemoveViewHotKeyActionByType(EInputDataType type)
		{
			IReadOnlyList<OpenAndCloseViewHotKey> allOpenAndCloseViewHotKeyConfig = ConfigBase<ViewHotKeyConfig>.Instance.GetAllOpenAndCloseViewHotKeyConfig();
			if (allOpenAndCloseViewHotKeyConfig == null)
			{
				return;
			}
			foreach (OpenAndCloseViewHotKey config in allOpenAndCloseViewHotKeyConfig)
			{
				if (config.GetEffectiveTypeListBytes().Contains((int)type))
				{
					this.RemoveViewHotKeyHandle(config);
				}
			}
		}

		// Token: 0x060319A6 RID: 203174 RVA: 0x00C5B998 File Offset: 0x00C59B98
		public void RegisterLockShortcutKeyReason(string reason, TLockShortcutKeyDelegate delegateItem = null)
		{
			if (delegateItem == null)
			{
				delegateItem = new TLockShortcutKeyDelegate(this.DefaultLockShortcutKeyDelegate);
			}
			this.LockShortcutKeyDelegateMap[reason] = delegateItem;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputManager;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "锁定快捷键输入的原因";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060319A7 RID: 203175 RVA: 0x00C5B9EC File Offset: 0x00C59BEC
		public void RemoveLockShortcutKeyReason(string reason)
		{
			this.LockShortcutKeyDelegateMap.Remove(reason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputManager;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "解锁快捷键输入的原因";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x060319A8 RID: 203176 RVA: 0x00C5BA30 File Offset: 0x00C59C30
		public void RegisterOpenViewFunc(EUiViewName name, Action delegateItem)
		{
			this.ViewHotKeyHandleContainer.RegisterOpenViewFunc(name, delegateItem);
			ViewHotKeyHandle[] array = this.ViewHotKeyHandleContainer.Get(name);
			if (array == null)
			{
				return;
			}
			ViewHotKeyHandle[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].BindOpenViewCallback(delegateItem);
			}
		}

		// Token: 0x060319A9 RID: 203177 RVA: 0x00C5BA74 File Offset: 0x00C59C74
		public void RegisterCloseViewFunc(EUiViewName name, Action delegateItem)
		{
			this.ViewHotKeyHandleContainer.RegisterCloseViewFunc(name, delegateItem);
			ViewHotKeyHandle[] array = this.ViewHotKeyHandleContainer.Get(name);
			if (array == null)
			{
				return;
			}
			ViewHotKeyHandle[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].BindCloseViewCallback(delegateItem);
			}
		}

		// Token: 0x060319AA RID: 203178 RVA: 0x00C5BAB8 File Offset: 0x00C59CB8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public ViewHotKeyHandle[] GetViewHotKeyHandle(EUiViewName viewName)
		{
			return this.ViewHotKeyHandleContainer.Get(viewName);
		}

		// Token: 0x060319AB RID: 203179 RVA: 0x00C5BAC6 File Offset: 0x00C59CC6
		public ViewHotKeyHandle[] GetAllViewHotKeyHandle()
		{
			return this.ViewHotKeyHandleContainer.GetAll();
		}

		// Token: 0x060319AC RID: 203180 RVA: 0x00C5BAD4 File Offset: 0x00C59CD4
		private void RegisterHandle()
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("GM指令", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputGmShortcutKey));
			ControllerBase<InputDistributeController>.Instance.BindAction("显示鼠标", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputMouseShortcutKey));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetModuleByResetToBattleView, new Action(this.OnPlayerDead));
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshCursor, new Action(this.RefreshCursor));
			Singleton<EventSystem>.Instance.Add(EEventName.MoveCursorToRightDown, new Action(this.MoveCursorToRightDown));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.RefreshStateOnPlatformChanged));
		}

		// Token: 0x060319AD RID: 203181 RVA: 0x00C5BBD4 File Offset: 0x00C59DD4
		private void RemoveHandle()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("GM指令", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputGmShortcutKey));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("显示鼠标", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputMouseShortcutKey));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetModuleByResetToBattleView, new Action(this.OnPlayerDead));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCursor, new Action(this.RefreshCursor));
			Singleton<EventSystem>.Instance.Remove(EEventName.MoveCursorToRightDown, new Action(this.MoveCursorToRightDown));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.RefreshStateOnPlatformChanged));
		}

		// Token: 0x060319AE RID: 203182 RVA: 0x00C5BCD4 File Offset: 0x00C59ED4
		private void OnInputGmShortcutKey(string name, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			if (!ModelBase<SundryModel>.Instance.GmBlueprintGmIsOpen)
			{
				return;
			}
			if (ModelBase<SundryModel>.Instance.CanOpenGmView)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GmView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.GmView, null);
					return;
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GmView, null, null);
			}
		}

		// Token: 0x060319AF RID: 203183 RVA: 0x00C5BD34 File Offset: 0x00C59F34
		private void OnInputMouseShortcutKey(string name, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			bool flag = actionType == InputDistributeDefine.EActionType.Press;
			if (flag != this.IsAltPress)
			{
				this.IsAltPress = flag;
				ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			}
			if (this.MouseCursorVisibleType == EMouseCursorVisibleType.AlwaysVisible)
			{
				return;
			}
			bool flag2 = actionType == InputDistributeDefine.EActionType.Press;
			if (this.IsAlwaysShowMouseCursor)
			{
				if (flag2)
				{
					this.SetShowCursor(true, true);
					return;
				}
			}
			else
			{
				this.MoveCursorToCenter();
				this.SetShowCursor(flag2, true);
			}
		}

		// Token: 0x060319B0 RID: 203184 RVA: 0x00C5BD91 File Offset: 0x00C59F91
		private void OnOpenView(EUiViewName viewName, int viewId)
		{
			this.AddViewHandle(viewName, viewId);
		}

		// Token: 0x060319B1 RID: 203185 RVA: 0x00C5BD9B File Offset: 0x00C59F9B
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			this.RemoveViewHandle(viewName, viewId);
		}

		// Token: 0x060319B2 RID: 203186 RVA: 0x00C5BDA5 File Offset: 0x00C59FA5
		private void AddViewHandle(EUiViewName viewName, int viewId)
		{
			ImmersiveMouseModule immersiveMouseModule = this.ImmersiveMouseModule;
			if (immersiveMouseModule != null)
			{
				immersiveMouseModule.RefreshMouseImmersiveMode();
			}
			this.CursorOpenViewHandle(viewName, viewId);
			this.TryAddDisableCloseView(viewName, viewId);
			this.TryAddDisableShortcutKeyView(viewName, viewId);
		}

		// Token: 0x060319B3 RID: 203187 RVA: 0x00C5BDD0 File Offset: 0x00C59FD0
		private void RemoveViewHandle(EUiViewName viewName, int viewId)
		{
			ImmersiveMouseModule immersiveMouseModule = this.ImmersiveMouseModule;
			if (immersiveMouseModule != null)
			{
				immersiveMouseModule.RefreshMouseImmersiveMode();
			}
			this.TryCloseViewHiddenCursor(viewName, viewId);
			this.TryRemoveDisableShortcutKeyView(viewName, viewId);
			this.TryRemoveDisableCloseView(viewName, viewId);
		}

		// Token: 0x060319B4 RID: 203188 RVA: 0x00C5BDFB File Offset: 0x00C59FFB
		private void OnPlayerDead()
		{
			this.ClearAlwaysCursorViewList();
			this.DisableShortcutKeyViewRecord.Clear();
			this.DisableCloseViewByShortcutKeyViewRecord.Clear();
		}

		// Token: 0x060319B5 RID: 203189 RVA: 0x00C5BE19 File Offset: 0x00C5A019
		private void RefreshCursor()
		{
			this.RefreshAlwaysCursorVisible();
		}

		// Token: 0x060319B6 RID: 203190 RVA: 0x00C5BE24 File Offset: 0x00C5A024
		private void MoveCursorToRightDown()
		{
			ValueTuple<int, int>? cursorRightDown = this.GetCursorRightDown();
			if (cursorRightDown != null)
			{
				this.SetMouseLocation(cursorRightDown.Value);
			}
		}

		// Token: 0x060319B7 RID: 203191 RVA: 0x00C5BE4E File Offset: 0x00C5A04E
		private void OnWorldDone()
		{
			this.ClearAlwaysCursorViewList();
		}

		// Token: 0x060319B8 RID: 203192 RVA: 0x00C5BE58 File Offset: 0x00C5A058
		private unsafe void TryAddDisableShortcutKeyView(EUiViewName viewName, int viewId)
		{
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null)
			{
				return;
			}
			if (uiViewInfo.CanOpenViewByShortcutKey)
			{
				return;
			}
			int num = this.DisableShortcutKeyViewRecord.Add(viewName);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputManager;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加不允许打开界面快捷键的界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewName", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("length", this.DisableShortcutKeyViewRecord.Size());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("count", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x060319B9 RID: 203193 RVA: 0x00C5BF10 File Offset: 0x00C5A110
		private unsafe void TryRemoveDisableShortcutKeyView(EUiViewName viewName, int viewId)
		{
			if (!this.DisableShortcutKeyViewRecord.Has(viewName))
			{
				return;
			}
			int num = this.DisableShortcutKeyViewRecord.Remove(viewName);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InputManager;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "删除不允许打开界面快捷键的界面";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewName", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("length", this.DisableShortcutKeyViewRecord.Size());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("count", num);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}

		// Token: 0x060319BA RID: 203194 RVA: 0x00C5BFBD File Offset: 0x00C5A1BD
		public bool IsAllowOpenViewByShortcutKey()
		{
			return !this.DisableShortcutKeyViewRecord.HasAny();
		}

		// Token: 0x060319BB RID: 203195 RVA: 0x00C5BFCD File Offset: 0x00C5A1CD
		public bool IsAllowCloseViewByShortcutKey()
		{
			return !this.DisableCloseViewByShortcutKeyViewRecord.HasAny();
		}

		// Token: 0x060319BC RID: 203196 RVA: 0x00C5BFDD File Offset: 0x00C5A1DD
		public void SetMouseCursorVisibleType(EMouseCursorVisibleType cursorVisibleType)
		{
			this.MouseCursorVisibleType = cursorVisibleType;
			if (cursorVisibleType == EMouseCursorVisibleType.AlwaysVisible)
			{
				this.SetShowCursor(true, true);
				return;
			}
			if (cursorVisibleType != EMouseCursorVisibleType.AlwaysHide)
			{
				this.RefreshAlwaysCursorVisible();
				return;
			}
			this.SetShowCursor(false, true);
		}

		// Token: 0x060319BD RID: 203197 RVA: 0x00C5C00C File Offset: 0x00C5A20C
		private void CursorOpenViewHandle(EUiViewName viewName, int viewId)
		{
			if (viewName == Singleton<UiModel>.Instance.MainViewName)
			{
				this.ClearAlwaysCursorViewList();
				return;
			}
			if (!this.IsPlayerControllerIsValid())
			{
				return;
			}
			bool flag = this.IsShowMouseCursor();
			if (!this.TryOpenViewShowCursor(viewName, viewId))
			{
				return;
			}
			if (!flag)
			{
				this.MoveCursorToCenter();
			}
		}

		// Token: 0x060319BE RID: 203198 RVA: 0x00C5C058 File Offset: 0x00C5A258
		private void TryAddDisableCloseView(EUiViewName viewName, int viewId)
		{
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null)
			{
				return;
			}
			if (uiViewInfo.IsShortKeysExitView && uiViewInfo.Type != ELayerType.Normal)
			{
				this.DisableCloseViewByShortcutKeyViewRecord.Add(viewName);
			}
		}

		// Token: 0x060319BF RID: 203199 RVA: 0x00C5C093 File Offset: 0x00C5A293
		private void TryRemoveDisableCloseView(EUiViewName viewName, int viewId)
		{
			this.DisableCloseViewByShortcutKeyViewRecord.Remove(viewName);
		}

		// Token: 0x060319C0 RID: 203200 RVA: 0x00C5C0A4 File Offset: 0x00C5A2A4
		private unsafe bool TryOpenViewShowCursor(EUiViewName viewName, int viewId)
		{
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null)
			{
				return false;
			}
			if (uiViewInfo.ShowCursorType == EShowCursorType.NotSet)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputManager;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "打开界面时显示鼠标 失败，原因是因为此界面的显示鼠标类型为：不影响鼠标显隐";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (uiViewInfo.ShowCursorType == EShowCursorType.Hidden)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputManager;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "打开界面时显示鼠标 失败，原因是因为此界面的显示鼠标类型为：隐藏鼠标";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("viewName", viewName);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.RefreshAlwaysCursorVisibleViewName(viewName);
				return false;
			}
			int num = this.ShowMouseViewRecord.Add(viewName);
			if (this.MouseCursorVisibleType != EMouseCursorVisibleType.None)
			{
				return false;
			}
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.InputManager;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "打开界面时尝试显示鼠标成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ViewName", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowCursorType", uiViewInfo.ShowCursorType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("count", num);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			this.RefreshAlwaysCursorVisibleViewName(viewName);
			return true;
		}

		// Token: 0x060319C1 RID: 203201 RVA: 0x00C5C1D4 File Offset: 0x00C5A3D4
		private unsafe void TryCloseViewHiddenCursor(EUiViewName viewName, int viewId)
		{
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo(viewName);
			if (uiViewInfo == null)
			{
				return;
			}
			if (uiViewInfo.ShowCursorType == EShowCursorType.NotSet)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputManager;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "关闭界面时尝试隐藏失败，原因是因为UI表中，此界面的显示鼠标类型为：不影响鼠标显隐藏";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", viewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.MouseCursorVisibleType != EMouseCursorVisibleType.None)
			{
				Singleton<Log>.Instance.Info(ELogModule.InputManager, ELogAuthor.XXJ, "关闭界面时尝试隐藏失败，原因是因为运行了总是显示鼠标的GM指令", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!this.ShowMouseViewRecord.Has(viewName))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.InputManager;
				ELogAuthor author2 = ELogAuthor.XXJ;
				string message2 = "关闭界面时尝试隐藏失败，原因是因为此界面没有再显示鼠标界面列表中";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewName", viewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowMouseViewList", this.ShowMouseViewRecord);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.ShowMouseViewRecord.Remove(viewName);
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.InputManager;
			ELogAuthor author3 = ELogAuthor.XXJ;
			string message3 = "关闭界面时尝试隐藏鼠标成功";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("viewName", viewName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ShowCursorType", uiViewInfo.ShowCursorType);
			instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.RefreshAlwaysCursorVisibleViewName(viewName);
		}

		// Token: 0x060319C2 RID: 203202 RVA: 0x00C5C330 File Offset: 0x00C5A530
		private void RefreshAlwaysCursorVisibleViewName(EUiViewName viewName)
		{
			bool flag = this.RefreshAlwaysCursorVisible();
			if (viewName != EUiViewName.NetWorkMaskView)
			{
				if (flag && !this.IsCursorFrameGenDisabled)
				{
					this.IsCursorFrameGenDisabled = true;
					Singleton<GameSettingsDeviceRender>.Instance.TemporaryDisableFrameGeneration("CursorVisialbe");
					return;
				}
				if (!flag && this.IsCursorFrameGenDisabled)
				{
					this.IsCursorFrameGenDisabled = false;
					Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("CursorVisialbe");
				}
			}
		}

		// Token: 0x060319C3 RID: 203203 RVA: 0x00C5C394 File Offset: 0x00C5A594
		private bool RefreshAlwaysCursorVisible()
		{
			bool flag = this.IsImmersiveMouseModeEnabled() && !this.IsImmersiveInputPaused();
			bool flag2 = this.ShowMouseViewRecord.HasAny() && !flag;
			this.SetAlwaysShowCursor(flag2);
			return flag2;
		}

		// Token: 0x060319C4 RID: 203204 RVA: 0x00C5C3D3 File Offset: 0x00C5A5D3
		private void ClearAlwaysCursorViewList()
		{
			this.ShowMouseViewRecord.Clear();
			this.SetAlwaysShowCursor(false);
			if (this.IsCursorFrameGenDisabled)
			{
				this.IsCursorFrameGenDisabled = false;
				Singleton<GameSettingsDeviceRender>.Instance.CancelTemporaryDisableFrameGeneration("CursorVisialbe");
			}
		}

		// Token: 0x060319C5 RID: 203205 RVA: 0x00C5C408 File Offset: 0x00C5A608
		public void SetAlwaysShowCursor(bool bAlwaysShowMouseCursor)
		{
			if (Singleton<InputExtraShowCursorCenter>.Instance.HasExtraShowCursorData())
			{
				bool isAlwaysShowMouseCursor = Singleton<InputExtraShowCursorCenter>.Instance.CheckShowCursorData();
				this.IsAlwaysShowMouseCursor = isAlwaysShowMouseCursor;
			}
			else
			{
				this.IsAlwaysShowMouseCursor = bAlwaysShowMouseCursor;
			}
			if (this.IsAlwaysShowMouseCursor == this.ManagerMouseStatus)
			{
				return;
			}
			this.SetShowCursor(this.IsAlwaysShowMouseCursor, true);
		}

		// Token: 0x060319C6 RID: 203206 RVA: 0x00C5C458 File Offset: 0x00C5A658
		public unsafe void SetShowCursor(bool value, bool fireEvent = true)
		{
			if (!this.IsPlayerControllerIsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InputManager;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "设置鼠标可见性失败，因为PlayerController不可用";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ManagerMouseStatus = value;
			bool flag = this.ManagerMouseStatus && !Singleton<Info>.Instance.IsInGamepad();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.InputManager;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "实际设置鼠标可见性";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("realSetValue", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			APlayerController playerController = Global.PlayerController;
			if (flag)
			{
				playerController.bShowMouseCursor = true;
				this.ApplyGameAndUiInputMode();
			}
			else
			{
				playerController.bShowMouseCursor = false;
				this.ReplyGameAndUiInputMode();
			}
			if (fireEvent)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnShowMouseCursor, value);
			}
		}

		// Token: 0x060319C7 RID: 203207 RVA: 0x00C5C550 File Offset: 0x00C5A750
		private void ApplyGameAndUiInputMode()
		{
			APlayerController playerController = Global.PlayerController;
			if (this.InputModeReply == null || !UKuroInputFunctionLibrary.HasInputModeReply(this.InputModeReply))
			{
				this.InputModeReply = UKuroInputFunctionLibrary.SetGameAndUIInputMode(playerController, "InputManager设置输入模式", false, false);
			}
		}

		// Token: 0x060319C8 RID: 203208 RVA: 0x00C5C591 File Offset: 0x00C5A791
		private void ReplyGameAndUiInputMode()
		{
			if (this.InputModeReply != null)
			{
				UKuroInputFunctionLibrary.ReplyInputMode(Global.PlayerController, this.InputModeReply);
				this.InputModeReply = null;
			}
		}

		// Token: 0x060319C9 RID: 203209 RVA: 0x00C5C5B8 File Offset: 0x00C5A7B8
		public void RefreshStateOnPlatformChanged(EInputControllerType eInputControllerType, EInputControllerType inputControllerType)
		{
			this.SetShowCursor(this.ManagerMouseStatus, true);
		}

		// Token: 0x060319CA RID: 203210 RVA: 0x00C5C5C8 File Offset: 0x00C5A7C8
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"X",
			"Y"
		})]
		private ValueTuple<int, int>? GetCursorCenter()
		{
			if (!this.IsPlayerControllerIsValid())
			{
				return null;
			}
			APlayerController playerController = Global.PlayerController;
			int num = 0;
			int num2 = 0;
			playerController.GetViewportSize(ref num, ref num2);
			int item = num / 2;
			int item2 = num2 / 2;
			return new ValueTuple<int, int>?(new ValueTuple<int, int>(item, item2));
		}

		// Token: 0x060319CB RID: 203211 RVA: 0x00C5C60C File Offset: 0x00C5A80C
		public void MoveCursorToCenter()
		{
			if (!this.IsAutoMoveCursorToCenter)
			{
				return;
			}
			ValueTuple<int, int>? cursorCenter = this.GetCursorCenter();
			if (cursorCenter != null)
			{
				this.SetMouseLocation(cursorCenter.Value);
			}
		}

		// Token: 0x060319CC RID: 203212 RVA: 0x00C5C640 File Offset: 0x00C5A840
		[NullableContext(0)]
		[return: TupleElementNames(new string[]
		{
			"X",
			"Y"
		})]
		private ValueTuple<int, int>? GetCursorRightDown()
		{
			if (!this.IsPlayerControllerIsValid())
			{
				return null;
			}
			APlayerController playerController = Global.PlayerController;
			int num = 0;
			int num2 = 0;
			playerController.GetViewportSize(ref num, ref num2);
			int item = num;
			int item2 = num2;
			return new ValueTuple<int, int>?(new ValueTuple<int, int>(item, item2));
		}

		// Token: 0x060319CD RID: 203213 RVA: 0x00C5C67F File Offset: 0x00C5A87F
		[NullableContext(0)]
		public void SetEventDataPrevPosition([TupleElementNames(new string[]
		{
			"X",
			"Y"
		})] ValueTuple<float, float>? cursorData)
		{
			if (cursorData != null)
			{
				Singleton<LguiEventSystemManager>.Instance.SetEventDataPrevPosition(cursorData.Value.Item1, cursorData.Value.Item2);
			}
		}

		// Token: 0x060319CE RID: 203214 RVA: 0x00C5C6AC File Offset: 0x00C5A8AC
		public bool IsShowMouseCursor()
		{
			return this.IsPlayerControllerIsValid() && Global.PlayerController.bShowMouseCursor;
		}

		// Token: 0x060319CF RID: 203215 RVA: 0x00C5C6C4 File Offset: 0x00C5A8C4
		private bool IsPlayerControllerIsValid()
		{
			APlayerController playerController = Global.PlayerController;
			return playerController != null && playerController.IsValid();
		}

		// Token: 0x060319D0 RID: 203216 RVA: 0x00C5C6E8 File Offset: 0x00C5A8E8
		[NullableContext(0)]
		private void SetMouseLocation([TupleElementNames(new string[]
		{
			"X",
			"Y"
		})] ValueTuple<int, int> cursorData)
		{
			Global.PlayerController.SetMouseLocation(cursorData.Item1, cursorData.Item2);
			this.SetEventDataPrevPosition(new ValueTuple<float, float>?(new ValueTuple<float, float>((float)cursorData.Item1, (float)cursorData.Item2)));
		}

		// Token: 0x060319D1 RID: 203217 RVA: 0x00C5C72B File Offset: 0x00C5A92B
		public void SetInputRespondToKey(string keyboardShortcut)
		{
			if (keyboardShortcut != "")
			{
				Singleton<Input>.Instance.OnlyRespondToKey = keyboardShortcut;
			}
		}

		// Token: 0x060319D2 RID: 203218 RVA: 0x00C5C745 File Offset: 0x00C5A945
		public void ResetInputRespondToKey(string keyboardShortcut)
		{
			if (keyboardShortcut == Singleton<Input>.Instance.OnlyRespondToKey)
			{
				Singleton<Input>.Instance.OnlyRespondToKey = "";
			}
		}

		// Token: 0x060319D3 RID: 203219 RVA: 0x00C5C768 File Offset: 0x00C5A968
		public void PauseImmersiveMouseMode(EImmersiveMouseModeReason reason, bool bReset = true, bool bShowCursor = true, bool bWakeInputState = false)
		{
			if (this.ImmersiveMouseModule != null)
			{
				this.ImmersiveMouseModule.PauseImmersiveMode(reason, bReset, bShowCursor);
			}
			if (bWakeInputState)
			{
				this.SetImmersiveInputWakeState(Singleton<Info>.Instance.InputControllerMainType, true);
			}
		}

		// Token: 0x060319D4 RID: 203220 RVA: 0x00C5C795 File Offset: 0x00C5A995
		public void ResumeImmersiveMouseMode(EImmersiveMouseModeReason reason)
		{
			if (this.ImmersiveMouseModule != null)
			{
				this.ImmersiveMouseModule.ResumeImmersiveMode(reason);
			}
		}

		// Token: 0x060319D5 RID: 203221 RVA: 0x00C5C7AB File Offset: 0x00C5A9AB
		public bool IsImmersiveMouseModeEnabled()
		{
			return this.ImmersiveMouseModule != null && this.ImmersiveMouseModule.IsImmersiveModeEnabled();
		}

		// Token: 0x060319D6 RID: 203222 RVA: 0x00C5C7C2 File Offset: 0x00C5A9C2
		public bool IsImmersiveInputPaused()
		{
			return this.ImmersiveMouseModule != null && this.ImmersiveMouseModule.IsImmersiveInputPaused();
		}

		// Token: 0x060319D7 RID: 203223 RVA: 0x00C5C7D9 File Offset: 0x00C5A9D9
		public bool GetImmersiveInputWakeState()
		{
			return this.ImmersiveInputWakeState;
		}

		// Token: 0x060319D8 RID: 203224 RVA: 0x00C5C7E1 File Offset: 0x00C5A9E1
		public void SetImmersiveInputWakeState(EInputControllerMainType inputMainType, bool isWake)
		{
			if (this.ImmersiveInputWakeState == isWake)
			{
				return;
			}
			this.ImmersiveInputWakeState = isWake;
			Singleton<EventSystem>.Instance.Emit<EInputControllerMainType, bool>(EEventName.OnImmersiveInputStateChange, inputMainType, isWake);
		}

		// Token: 0x0401CE11 RID: 118289
		private EMouseCursorVisibleType MouseCursorVisibleType;

		// Token: 0x0401CE12 RID: 118290
		private bool IsAlwaysShowMouseCursor;

		// Token: 0x0401CE13 RID: 118291
		private bool ManagerMouseStatus;

		// Token: 0x0401CE14 RID: 118292
		private bool IsInit;

		// Token: 0x0401CE15 RID: 118293
		private readonly InputViewRecord ShowMouseViewRecord = new InputViewRecord();

		// Token: 0x0401CE16 RID: 118294
		private bool IsCursorFrameGenDisabled;

		// Token: 0x0401CE17 RID: 118295
		public readonly InputViewRecord DisableShortcutKeyViewRecord = new InputViewRecord();

		// Token: 0x0401CE18 RID: 118296
		public readonly InputViewRecord DisableCloseViewByShortcutKeyViewRecord = new InputViewRecord();

		// Token: 0x0401CE19 RID: 118297
		[Nullable(2)]
		private FInputModeReply InputModeReply;

		// Token: 0x0401CE1A RID: 118298
		private readonly ViewHotKeyHandleContainer ViewHotKeyHandleContainer = new ViewHotKeyHandleContainer();

		// Token: 0x0401CE1B RID: 118299
		public bool IsAutoMoveCursorToCenter = true;

		// Token: 0x0401CE1C RID: 118300
		public bool IsAltPress;

		// Token: 0x0401CE1D RID: 118301
		[Nullable(2)]
		public ImmersiveMouseModule ImmersiveMouseModule;

		// Token: 0x0401CE1E RID: 118302
		private readonly Dictionary<string, TLockShortcutKeyDelegate> LockShortcutKeyDelegateMap = new Dictionary<string, TLockShortcutKeyDelegate>();

		// Token: 0x0401CE1F RID: 118303
		private bool ImmersiveInputWakeState;
	}
}
