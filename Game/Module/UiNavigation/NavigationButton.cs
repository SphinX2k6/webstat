using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CAF RID: 19631
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationButton : NavigationSelectableBase
	{
		// Token: 0x0603321C RID: 209436 RVA: 0x00CCDE77 File Offset: 0x00CCC077
		public NavigationButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603321D RID: 209437 RVA: 0x00CCDE82 File Offset: 0x00CCC082
		protected override void OnInit()
		{
			this.RegisterButtonClick();
		}

		// Token: 0x0603321E RID: 209438 RVA: 0x00CCDE8A File Offset: 0x00CCC08A
		protected override void OnClear()
		{
			this.UnRegisterButtonClick();
		}

		// Token: 0x0603321F RID: 209439 RVA: 0x00CCDE94 File Offset: 0x00CCC094
		private void RegisterButtonClick()
		{
			if (this.NeedAddButtonClick())
			{
				UUIButtonComponent uuibuttonComponent = this.Selectable as UUIButtonComponent;
				FLGUIButtonDynamicDelegate flguibuttonDynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIButtonDynamicDelegate>(new Action(this.ButtonClick));
				this.HandleWrapper = ((uuibuttonComponent != null) ? uuibuttonComponent.RegisterClickEvent(flguibuttonDynamicDelegate) : null);
			}
		}

		// Token: 0x06033220 RID: 209440 RVA: 0x00CCDEDC File Offset: 0x00CCC0DC
		private void UnRegisterButtonClick()
		{
			if (this.HandleWrapper != null)
			{
				UUIButtonComponent uuibuttonComponent = this.Selectable as UUIButtonComponent;
				if (uuibuttonComponent != null)
				{
					uuibuttonComponent.UnregisterClickEvent(this.HandleWrapper);
				}
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.ButtonClick));
				this.HandleWrapper = null;
			}
		}

		// Token: 0x06033221 RID: 209441 RVA: 0x00CCDF2B File Offset: 0x00CCC12B
		private void ButtonClick()
		{
			this.OnButtonClick();
		}

		// Token: 0x06033222 RID: 209442 RVA: 0x00CCDF33 File Offset: 0x00CCC133
		protected virtual void OnButtonClick()
		{
		}

		// Token: 0x06033223 RID: 209443 RVA: 0x00CCDF35 File Offset: 0x00CCC135
		protected virtual bool NeedAddButtonClick()
		{
			return base.GetType() != ENavigationSelectableDefine.Button;
		}

		// Token: 0x06033224 RID: 209444 RVA: 0x00CCDF44 File Offset: 0x00CCC144
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			TsUiNavigationBehaviorListener listener = this.Listener;
			bool flag;
			if (listener == null)
			{
				flag = (null != null);
			}
			else
			{
				UiNavigationScrollProxy scrollProxy = listener.ScrollProxy;
				flag = (((scrollProxy != null) ? scrollProxy.ScrollView : null) != null);
			}
			if (flag)
			{
				this.Listener.ScrollProxy.ScrollView.ScrollToSelectableComponent(this.Selectable as UUIButtonComponent);
			}
			TsUiNavigationBehaviorListener listener2 = this.Listener;
			NavigationGroup navigationGroup = (listener2 != null) ? listener2.GetNavigationGroup() : null;
			if (((navigationGroup != null) ? navigationGroup.InsideGroupNameSet : new HashSet<string>()).Count > 0)
			{
				TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
				return ControllerBase<UiNavigationNewController>.Instance.IsInFocusInsideListenerList(this.Listener, currentNavigationFocusListener);
			}
			return false;
		}

		// Token: 0x0401DB80 RID: 121728
		[Nullable(2)]
		private FLGUIDelegateHandleWrapper HandleWrapper;
	}
}
