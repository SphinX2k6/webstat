using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0E RID: 19726
	[NullableContext(1)]
	[Nullable(0)]
	public class HotKeyComponent : UiPanelBase
	{
		// Token: 0x06033441 RID: 209985 RVA: 0x00CD55A6 File Offset: 0x00CD37A6
		public HotKeyComponent(int hotKeyMapIndex)
		{
			this.HotKeyMapIndex = hotKeyMapIndex;
			this.HotKeyConfig = ConfigBase<UiNavigationConfig>.Instance.GetHotKeyMapConfig(this.HotKeyMapIndex);
		}

		// Token: 0x06033442 RID: 209986 RVA: 0x00CD55CB File Offset: 0x00CD37CB
		protected override void OnBeforeCreateImplement()
		{
			this.OnInit();
		}

		// Token: 0x06033443 RID: 209987 RVA: 0x00CD55D4 File Offset: 0x00CD37D4
		protected override UniTask OnBeforeStartAsync()
		{
			HotKeyComponent.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HotKeyComponent.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033444 RID: 209988 RVA: 0x00CD5617 File Offset: 0x00CD3817
		private bool GetLogic()
		{
			return this.LogicMode == HotKeyViewDefine.ELogicMode.Min;
		}

		// Token: 0x06033445 RID: 209989 RVA: 0x00CD5622 File Offset: 0x00CD3822
		private void OnSetVisible(bool bVisible)
		{
			if (bVisible)
			{
				this.OnRefreshMode();
			}
			else if (this.IsPress)
			{
				this.ReleaseWithoutCheck();
			}
			this.CurComponent.SetVisible(bVisible);
		}

		// Token: 0x06033446 RID: 209990 RVA: 0x00CD5649 File Offset: 0x00CD3849
		protected virtual void OnRefreshMode()
		{
			this.RefreshKeyIcon();
			this.RefreshHotKeyNameText();
		}

		// Token: 0x06033447 RID: 209991 RVA: 0x00CD5657 File Offset: 0x00CD3857
		private void RefreshKeyIcon()
		{
			this.CurComponent.RefreshKeyIcon();
		}

		// Token: 0x06033448 RID: 209992 RVA: 0x00CD5664 File Offset: 0x00CD3864
		private void RefreshKeyIconWithoutActive()
		{
			this.CurComponent.RefreshKeyIconWithoutActive();
		}

		// Token: 0x06033449 RID: 209993 RVA: 0x00CD5671 File Offset: 0x00CD3871
		protected HotKeyMap? GetHotKeyConfig()
		{
			return new HotKeyMap?(this.HotKeyConfig.Value);
		}

		// Token: 0x0603344A RID: 209994 RVA: 0x00CD5684 File Offset: 0x00CD3884
		private unsafe void SetLogicMode(HotKeyViewDefine.ELogicMode logicMode, bool isActive)
		{
			if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigationHotKey;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[LogicMode]模式设置";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置id", this.HotKeyMapIndex);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", this.GetBindButtonTag());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("模式", HotKeyViewDefine.LogicModeLogString[logicMode]);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("值", isActive);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			if (isActive)
			{
				if ((this.LogicMode & logicMode) != HotKeyViewDefine.ELogicMode.Min)
				{
					this.LogicMode ^= logicMode;
					return;
				}
			}
			else
			{
				this.LogicMode |= logicMode;
			}
		}

		// Token: 0x0603344B RID: 209995 RVA: 0x00CD5770 File Offset: 0x00CD3970
		protected void RefreshHotKeyNameText()
		{
			HotKeyMap? hotKeyMap;
			string textId = this.HotKeyTextId ?? ((this.GetHotKeyConfig() != null) ? hotKeyMap.GetValueOrDefault().TextId : null);
			this.CurComponent.RefreshNameText(textId);
		}

		// Token: 0x0603344C RID: 209996 RVA: 0x00CD57B8 File Offset: 0x00CD39B8
		protected virtual void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = this.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag != null, false);
		}

		// Token: 0x0603344D RID: 209997 RVA: 0x00CD57E9 File Offset: 0x00CD39E9
		protected virtual void OnRefreshHotKeyText(UiNavigationViewHandle viewHandle)
		{
		}

		// Token: 0x0603344E RID: 209998 RVA: 0x00CD57EC File Offset: 0x00CD39EC
		protected virtual void OnRefreshHotKeyTextId(UiNavigationViewHandle viewHandle)
		{
			if (this.CurComponent.GetIsForceSetText())
			{
				return;
			}
			string bindButtonTag = this.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			string hotKeyTextId = (activeListenerByTag != null) ? activeListenerByTag.GetTipsTextIdByState() : null;
			this.SetHotKeyTextId(hotKeyTextId);
			this.RefreshHotKeyNameText();
		}

		// Token: 0x0603344F RID: 209999 RVA: 0x00CD5838 File Offset: 0x00CD3A38
		protected virtual void OnRefreshHotKeyShield(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerNotifyShield, focusListener == null || !focusListener.ShieldHotKeyIndexArray.Contains(this.HotKeyMapIndex), false);
		}

		// Token: 0x06033450 RID: 210000 RVA: 0x00CD5870 File Offset: 0x00CD3A70
		private unsafe void RefreshConfigShield(bool isForce = false)
		{
			if (this.RootItem == null || !this.RootItem.IsValid())
			{
				return;
			}
			HotKeyViewDefine.EHotKeyApplicableType applicableType = (HotKeyViewDefine.EHotKeyApplicableType)this.HotKeyConfig.Value.ApplicableType;
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.KeyboardAndHandle)
			{
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, true, true);
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.OnlyKeyboard)
			{
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, Singleton<Info>.Instance.IsInKeyBoard(), isForce);
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.OnlyHandle)
			{
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, Singleton<Info>.Instance.IsInGamepad(), isForce);
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.OnlyKeyboardTransparent)
			{
				bool flag = Singleton<Info>.Instance.IsInKeyBoard();
				this.RootItem.SetAlpha(!flag);
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, true, isForce);
				if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiNavigationHotKey;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "仅键鼠透明";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("配置id", this.HotKeyMapIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", this.GetBindButtonTag());
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.OnlyHandleTransparent)
			{
				bool flag2 = Singleton<Info>.Instance.IsInGamepad();
				this.RootItem.SetAlpha(!flag2);
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, true, isForce);
				if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.UiNavigationHotKey;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "仅手柄透明";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("配置id", this.HotKeyMapIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Tag", this.GetBindButtonTag());
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.KeyboardAndHandleTransparent)
			{
				bool flag3 = Singleton<Info>.Instance.IsInKeyBoard();
				bool flag4 = Singleton<Info>.Instance.IsInGamepad();
				this.RootItem.SetAlpha((float)((flag3 || flag4) ? 0 : 1));
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, true, true);
				if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.UiNavigationHotKey;
					ELogAuthor author3 = ELogAuthor.XXJ;
					string message3 = "键盘和手柄透明";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("配置id", this.HotKeyMapIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Tag", this.GetBindButtonTag());
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				}
				return;
			}
			if (applicableType == HotKeyViewDefine.EHotKeyApplicableType.OnlyKeyboardTransparentExceptLongPress)
			{
				bool flag5 = Singleton<Info>.Instance.IsInKeyBoard();
				this.RootItem.SetAlpha(!flag5);
				this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ConfigShield, flag5, isForce);
				if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.UiNavigationHotKey;
					ELogAuthor author4 = ELogAuthor.CB;
					string message4 = "仅键鼠可用且透明,长按时不透明";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("配置id", this.HotKeyMapIndex);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Tag", this.GetBindButtonTag());
					instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
				}
			}
		}

		// Token: 0x06033451 RID: 210001 RVA: 0x00CD5B78 File Offset: 0x00CD3D78
		public void InitHotKeyLogicMode()
		{
			this.SetVisibleMode(HotKeyViewDefine.ELogicMode.LogicByNoController, !Singleton<Info>.Instance.IsInTouch(), false);
			this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, true);
			this.RefreshConfigShield(false);
		}

		// Token: 0x06033452 RID: 210002 RVA: 0x00CD5BA0 File Offset: 0x00CD3DA0
		public void RegisterMe()
		{
			this.AddEventListener();
			this.RefreshConfigShield(true);
			HotKeyCombineComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.RefreshPcAndGamepad();
			}
			this.RefreshKeyIconWithoutActive();
		}

		// Token: 0x06033453 RID: 210003 RVA: 0x00CD5BC6 File Offset: 0x00CD3DC6
		public void UnRegisterMe()
		{
			this.RemoveEventListener();
			this.OnUnRegisterMe();
			this.HandleFinishInputAxis(this.GetAxisName());
		}

		// Token: 0x06033454 RID: 210004 RVA: 0x00CD5BE0 File Offset: 0x00CD3DE0
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			if (this.HotKeyConfig != null && this.HotKeyConfig.GetValueOrDefault().HideInShowMouse)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursorChanged));
				this.OnShowMouseCursorChanged(Singleton<InputManager>.Instance.IsShowMouseCursor());
			}
			this.OnAddEventListener();
		}

		// Token: 0x06033455 RID: 210005 RVA: 0x00CD5C5C File Offset: 0x00CD3E5C
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActionKeyChanged, new Action<string>(this.OnActionKeyChanged));
			if (this.HotKeyConfig != null && this.HotKeyConfig.GetValueOrDefault().HideInShowMouse)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursorChanged));
			}
			this.OnRemoveEventListener();
		}

		// Token: 0x06033456 RID: 210006 RVA: 0x00CD5CC8 File Offset: 0x00CD3EC8
		private void OnShowMouseCursorChanged(bool bShowMouseCursor)
		{
			this.SetVisibleMode(HotKeyViewDefine.ELogicMode.ShowMouseShield, !bShowMouseCursor, false);
		}

		// Token: 0x06033457 RID: 210007 RVA: 0x00CD5CDC File Offset: 0x00CD3EDC
		private void OnActionKeyChanged(string notifyActionName)
		{
			string actionName = this.GetActionName();
			if (!StringUtils.IsEmpty(actionName) && actionName == notifyActionName)
			{
				this.RefreshKeyIconWithoutActive();
			}
		}

		// Token: 0x06033458 RID: 210008 RVA: 0x00CD5D08 File Offset: 0x00CD3F08
		public void SetVisibleMode(HotKeyViewDefine.ELogicMode logicMode, bool isActive, bool isForce = false)
		{
			HotKeyViewDefine.ELogicMode logicMode2 = this.LogicMode;
			this.SetLogicMode(logicMode, isActive);
			if (this.LogicMode != logicMode2 || isForce || this.ForceRefreshVisibleMode)
			{
				this.ForceRefreshVisibleMode = false;
				this.OnSetVisible(this.GetLogic());
			}
		}

		// Token: 0x06033459 RID: 210009 RVA: 0x00CD5D4F File Offset: 0x00CD3F4F
		public void OnlySetVisibleMode(HotKeyViewDefine.ELogicMode logicMode, bool isActive)
		{
			this.ForceRefreshVisibleMode = true;
			this.SetLogicMode(logicMode, isActive);
		}

		// Token: 0x0603345A RID: 210010 RVA: 0x00CD5D60 File Offset: 0x00CD3F60
		public void SetHotKeyDescTextForce(string text)
		{
			this.CurComponent.SetNameTextForce(true);
			this.CurComponent.SetNameText(text);
		}

		// Token: 0x0603345B RID: 210011 RVA: 0x00CD5D7A File Offset: 0x00CD3F7A
		public void ResetHotKeyDescTextForce()
		{
			this.CurComponent.SetNameTextForce(false);
		}

		// Token: 0x0603345C RID: 210012 RVA: 0x00CD5D88 File Offset: 0x00CD3F88
		[NullableContext(2)]
		public void SetHotKeyTextId(string textId)
		{
			if (StringUtils.IsEmpty(textId))
			{
				this.HotKeyTextId = null;
				return;
			}
			this.HotKeyTextId = textId;
		}

		// Token: 0x0603345D RID: 210013 RVA: 0x00CD5DA1 File Offset: 0x00CD3FA1
		public bool IsHotKeyActive()
		{
			return this.LogicMode == HotKeyViewDefine.ELogicMode.Min;
		}

		// Token: 0x0603345E RID: 210014 RVA: 0x00CD5DAC File Offset: 0x00CD3FAC
		public bool IsAllowTickContinue()
		{
			return this.LogicMode == HotKeyViewDefine.ELogicMode.Min || this.IsStartInputAxis;
		}

		// Token: 0x0603345F RID: 210015 RVA: 0x00CD5DC0 File Offset: 0x00CD3FC0
		public void RefreshMode()
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigationHotKey, ELogAuthor.XXJ, "切换了控制器,强制刷新表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshConfigShield(true);
			HotKeyCombineComponent curComponent = this.CurComponent;
			if (curComponent != null)
			{
				curComponent.RefreshPcAndGamepad();
			}
			this.OnRefreshByControllerChange();
		}

		// Token: 0x06033460 RID: 210016 RVA: 0x00CD5E0C File Offset: 0x00CD400C
		public void Press()
		{
			if (!this.GetLogic())
			{
				return;
			}
			this.IsPress = true;
			HotKeyMap? hotKeyConfig = this.GetHotKeyConfig();
			if (hotKeyConfig != null)
			{
				this.OnPress(hotKeyConfig.Value);
			}
		}

		// Token: 0x06033461 RID: 210017 RVA: 0x00CD5E46 File Offset: 0x00CD4046
		public void Release()
		{
			if (!this.GetLogic() || !this.IsPress)
			{
				return;
			}
			this.ReleaseWithoutCheck();
		}

		// Token: 0x06033462 RID: 210018 RVA: 0x00CD5E60 File Offset: 0x00CD4060
		protected void ReleaseWithoutCheck()
		{
			this.IsPress = false;
			HotKeyMap? hotKeyConfig = this.GetHotKeyConfig();
			if (hotKeyConfig != null)
			{
				this.OnRelease(hotKeyConfig.Value);
			}
		}

		// Token: 0x06033463 RID: 210019 RVA: 0x00CD5E91 File Offset: 0x00CD4091
		public void InputAxis(string axisName, float value)
		{
			if (!this.GetLogic())
			{
				this.HandleFinishInputAxis(axisName);
				return;
			}
			this.HandleStartInputAxis(axisName);
			this.OnInputAxis(axisName, value);
		}

		// Token: 0x06033464 RID: 210020 RVA: 0x00CD5EB2 File Offset: 0x00CD40B2
		private void HandleStartInputAxis(string axisName)
		{
			if (!this.IsStartInputAxis)
			{
				this.IsStartInputAxis = true;
				this.OnStartInputAxis(axisName);
			}
		}

		// Token: 0x06033465 RID: 210021 RVA: 0x00CD5ECA File Offset: 0x00CD40CA
		private void HandleFinishInputAxis(string axisName)
		{
			if (this.IsStartInputAxis)
			{
				this.IsStartInputAxis = false;
				this.OnFinishInputAxis(axisName);
			}
		}

		// Token: 0x06033466 RID: 210022 RVA: 0x00CD5EE4 File Offset: 0x00CD40E4
		[NullableContext(2)]
		public string GetBindButtonTag()
		{
			if (this.HotKeyConfig == null)
			{
				return null;
			}
			return this.HotKeyConfig.GetValueOrDefault().BindButtonTag;
		}

		// Token: 0x06033467 RID: 210023 RVA: 0x00CD5F10 File Offset: 0x00CD4110
		[NullableContext(2)]
		public string GetActionName()
		{
			if (this.HotKeyConfig == null)
			{
				return null;
			}
			return this.HotKeyConfig.GetValueOrDefault().ActionName;
		}

		// Token: 0x06033468 RID: 210024 RVA: 0x00CD5F3C File Offset: 0x00CD413C
		[NullableContext(2)]
		public string GetAxisName()
		{
			if (this.HotKeyConfig == null)
			{
				return null;
			}
			return this.HotKeyConfig.GetValueOrDefault().AxisName;
		}

		// Token: 0x06033469 RID: 210025 RVA: 0x00CD5F68 File Offset: 0x00CD4168
		public bool IsAxisAllDirection()
		{
			return ((this.HotKeyConfig != null) ? new int?(this.HotKeyConfig.GetValueOrDefault().AxisDirection) : null).Value == 0;
		}

		// Token: 0x0603346A RID: 210026 RVA: 0x00CD5FAC File Offset: 0x00CD41AC
		public bool IsAxisPositive()
		{
			return ((this.HotKeyConfig != null) ? new int?(this.HotKeyConfig.GetValueOrDefault().AxisDirection) : null).Value != 1;
		}

		// Token: 0x0603346B RID: 210027 RVA: 0x00CD5FF4 File Offset: 0x00CD41F4
		public bool IsAxisReverse()
		{
			return ((this.HotKeyConfig != null) ? new int?(this.HotKeyConfig.GetValueOrDefault().AxisDirection) : null).Value != 2;
		}

		// Token: 0x0603346C RID: 210028 RVA: 0x00CD603B File Offset: 0x00CD423B
		public void SetHotKeyFunctionType(string functionType)
		{
			this.FunctionType = functionType;
		}

		// Token: 0x0603346D RID: 210029 RVA: 0x00CD6044 File Offset: 0x00CD4244
		public string GetHotKeyFunctionType()
		{
			return this.FunctionType;
		}

		// Token: 0x0603346E RID: 210030 RVA: 0x00CD604C File Offset: 0x00CD424C
		public bool IsOccupancyFightInput()
		{
			return this.OnIsOccupancyFightInput();
		}

		// Token: 0x0603346F RID: 210031 RVA: 0x00CD6054 File Offset: 0x00CD4254
		public void RefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			this.OnRefreshHotKeyShield(viewHandle);
			this.OnRefreshSelfHotKeyState(viewHandle);
			this.RefreshConfigShield(false);
			this.HandleLogicAfterRefresh(viewHandle);
		}

		// Token: 0x06033470 RID: 210032 RVA: 0x00CD6072 File Offset: 0x00CD4272
		public void RefreshSelfHotKeyText(UiNavigationViewHandle viewHandle)
		{
			this.OnRefreshHotKeyText(viewHandle);
			this.OnRefreshHotKeyTextId(viewHandle);
		}

		// Token: 0x06033471 RID: 210033 RVA: 0x00CD6082 File Offset: 0x00CD4282
		public void SetHotKeyType(HotKeyTypeBase hotKeyType)
		{
			this.CurComponent.SetHotKeyType(hotKeyType);
		}

		// Token: 0x06033472 RID: 210034 RVA: 0x00CD6090 File Offset: 0x00CD4290
		public void SetLinkComponent(TsUiHotKeyLinkListener linkComponent)
		{
			this.LinkComponent = linkComponent;
		}

		// Token: 0x06033473 RID: 210035 RVA: 0x00CD6099 File Offset: 0x00CD4299
		[NullableContext(2)]
		public bool IsLinkListener(AActor actor)
		{
			if (this.LinkComponent == null)
			{
				return true;
			}
			if (actor == null)
			{
				return false;
			}
			TArray<AActor> actorList = this.LinkComponent.ActorList;
			return actorList != null && actorList.Contains(actor);
		}

		// Token: 0x06033474 RID: 210036 RVA: 0x00CD60C1 File Offset: 0x00CD42C1
		public int GetHotKeyMapIndex()
		{
			return this.HotKeyMapIndex;
		}

		// Token: 0x06033475 RID: 210037 RVA: 0x00CD60C9 File Offset: 0x00CD42C9
		public void Clear()
		{
			this.OnClear();
		}

		// Token: 0x06033476 RID: 210038 RVA: 0x00CD60D1 File Offset: 0x00CD42D1
		protected virtual void OnInit()
		{
		}

		// Token: 0x06033477 RID: 210039 RVA: 0x00CD60D3 File Offset: 0x00CD42D3
		protected virtual void OnRefreshByControllerChange()
		{
		}

		// Token: 0x06033478 RID: 210040 RVA: 0x00CD60D5 File Offset: 0x00CD42D5
		protected virtual void OnAddEventListener()
		{
		}

		// Token: 0x06033479 RID: 210041 RVA: 0x00CD60D7 File Offset: 0x00CD42D7
		protected virtual void OnRemoveEventListener()
		{
		}

		// Token: 0x0603347A RID: 210042 RVA: 0x00CD60D9 File Offset: 0x00CD42D9
		protected virtual void OnUnRegisterMe()
		{
		}

		// Token: 0x0603347B RID: 210043 RVA: 0x00CD60DB File Offset: 0x00CD42DB
		protected virtual void OnClear()
		{
		}

		// Token: 0x0603347C RID: 210044 RVA: 0x00CD60DD File Offset: 0x00CD42DD
		protected virtual void HandleLogicAfterRefresh(UiNavigationViewHandle viewHandle)
		{
		}

		// Token: 0x0603347D RID: 210045 RVA: 0x00CD60E0 File Offset: 0x00CD42E0
		protected virtual bool OnIsOccupancyFightInput()
		{
			return this.HotKeyConfig == null || this.HotKeyConfig.GetValueOrDefault().IsOccupancyFightInput;
		}

		// Token: 0x0603347E RID: 210046 RVA: 0x00CD610B File Offset: 0x00CD430B
		public virtual void SetDataCallback(Func<object> callback)
		{
		}

		// Token: 0x0603347F RID: 210047 RVA: 0x00CD610D File Offset: 0x00CD430D
		protected virtual void OnPress(HotKeyMap config)
		{
		}

		// Token: 0x06033480 RID: 210048 RVA: 0x00CD610F File Offset: 0x00CD430F
		protected virtual void OnRelease(HotKeyMap config)
		{
		}

		// Token: 0x06033481 RID: 210049 RVA: 0x00CD6111 File Offset: 0x00CD4311
		protected virtual void OnInputAxis(string axisName, float value)
		{
		}

		// Token: 0x06033482 RID: 210050 RVA: 0x00CD6113 File Offset: 0x00CD4313
		protected virtual void OnStartInputAxis(string axisName)
		{
		}

		// Token: 0x06033483 RID: 210051 RVA: 0x00CD6115 File Offset: 0x00CD4315
		protected virtual void OnFinishInputAxis(string axisName)
		{
		}

		// Token: 0x06033484 RID: 210052 RVA: 0x00CD6118 File Offset: 0x00CD4318
		protected virtual bool GetIsLongPress()
		{
			return this.HotKeyConfig != null && this.HotKeyConfig.Value.LongPressTime > 0;
		}

		// Token: 0x06033485 RID: 210053 RVA: 0x00CD614A File Offset: 0x00CD434A
		public void ResetPressState()
		{
			if (!this.IsLongPress && this.IsPress)
			{
				this.IsPress = false;
			}
		}

		// Token: 0x0401DC3A RID: 121914
		protected int HotKeyMapIndex;

		// Token: 0x0401DC3B RID: 121915
		[Nullable(2)]
		protected HotKeyCombineComponent CurComponent;

		// Token: 0x0401DC3C RID: 121916
		protected bool IsPress;

		// Token: 0x0401DC3D RID: 121917
		private readonly HotKeyMap? HotKeyConfig;

		// Token: 0x0401DC3E RID: 121918
		private HotKeyViewDefine.ELogicMode LogicMode;

		// Token: 0x0401DC3F RID: 121919
		[Nullable(2)]
		protected string HotKeyTextId;

		// Token: 0x0401DC40 RID: 121920
		[Nullable(2)]
		private string FunctionType;

		// Token: 0x0401DC41 RID: 121921
		[Nullable(2)]
		private string FullPath;

		// Token: 0x0401DC42 RID: 121922
		[Nullable(2)]
		private TsUiHotKeyLinkListener LinkComponent;

		// Token: 0x0401DC43 RID: 121923
		private bool ForceRefreshVisibleMode;

		// Token: 0x0401DC44 RID: 121924
		private bool IsStartInputAxis;

		// Token: 0x0401DC45 RID: 121925
		private bool IsLongPress;
	}
}
