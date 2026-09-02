using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Enum;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB6 RID: 19638
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationToggle : NavigationSelectableBase
	{
		// Token: 0x0603325E RID: 209502 RVA: 0x00CCE85F File Offset: 0x00CCCA5F
		public NavigationToggle(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x0603325F RID: 209503 RVA: 0x00CCE86A File Offset: 0x00CCCA6A
		protected override void OnInit()
		{
			this.RegisterHotKeyTips();
			this.RegisterToggleClick();
		}

		// Token: 0x06033260 RID: 209504 RVA: 0x00CCE878 File Offset: 0x00CCCA78
		protected override void OnClear()
		{
			this.UnRegisterHotKeyTips();
			this.UnRegisterToggleClick();
		}

		// Token: 0x06033261 RID: 209505 RVA: 0x00CCE888 File Offset: 0x00CCCA88
		private void RegisterHotKeyTips()
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (this.Listener.HotKeyTipsTextIdMap.Num() > 0)
			{
				uuiextendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnStateChangeEvent));
			}
		}

		// Token: 0x06033262 RID: 209506 RVA: 0x00CCE8CC File Offset: 0x00CCCACC
		private void UnRegisterHotKeyTips()
		{
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (this.Listener.HotKeyTipsTextIdMap.Num() > 0)
			{
				uuiextendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnStateChangeEvent));
			}
		}

		// Token: 0x06033263 RID: 209507 RVA: 0x00CCE90F File Offset: 0x00CCCB0F
		private void OnStateChangeEvent(EToggleState state)
		{
			Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKeyTextId();
		}

		// Token: 0x06033264 RID: 209508 RVA: 0x00CCE91B File Offset: 0x00CCCB1B
		private void RegisterToggleClick()
		{
			if (this.NeedAddToggleClick())
			{
				(this.Selectable as UUIExtendToggle).OnStateChange.Add(new Action<EToggleState>(this.ToggleClick));
			}
		}

		// Token: 0x06033265 RID: 209509 RVA: 0x00CCE946 File Offset: 0x00CCCB46
		private void UnRegisterToggleClick()
		{
			if (this.NeedAddToggleClick())
			{
				(this.Selectable as UUIExtendToggle).OnStateChange.Remove(new Action<EToggleState>(this.ToggleClick));
			}
		}

		// Token: 0x06033266 RID: 209510 RVA: 0x00CCE971 File Offset: 0x00CCCB71
		private void ToggleClick(EToggleState state)
		{
			this.OnToggleClick(state);
		}

		// Token: 0x06033267 RID: 209511 RVA: 0x00CCE97A File Offset: 0x00CCCB7A
		protected virtual void OnToggleClick(EToggleState state)
		{
		}

		// Token: 0x06033268 RID: 209512 RVA: 0x00CCE97C File Offset: 0x00CCCB7C
		protected void ScrollToSelectableComponent(UUIExtendToggle selectable)
		{
			if (this.Listener.HasDynamicScrollView() || this.Listener.HasMultiTemplateScrollView())
			{
				return;
			}
			UiNavigationScrollProxy scrollProxy = this.Listener.ScrollProxy;
			if (((scrollProxy != null) ? scrollProxy.ScrollView : null) != null)
			{
				this.Listener.ScrollProxy.ScrollView.ScrollToSelectableComponent(selectable);
			}
		}

		// Token: 0x06033269 RID: 209513 RVA: 0x00CCE9D3 File Offset: 0x00CCCBD3
		protected virtual bool NeedAddToggleClick()
		{
			return base.GetType() != ENavigationSelectableDefine.Toggle;
		}

		// Token: 0x0603326A RID: 209514 RVA: 0x00CCE9E4 File Offset: 0x00CCCBE4
		protected override bool OnCanFocusInScrollOrLayout()
		{
			if (!this.IsInteractive)
			{
				return false;
			}
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			return (uuiextendToggle.ToggleState == EToggleState.ETT_Checked || !uuiextendToggle.bCheckToggleSelected) && this.Selectable.RootUIComp.Get().IsUIActiveInHierarchy();
		}

		// Token: 0x0603326B RID: 209515 RVA: 0x00CCEA38 File Offset: 0x00CCCC38
		protected override string OnGetTipsTextId()
		{
			if ((this.Selectable as UUIExtendToggle).ToggleState == EToggleState.ETT_Checked)
			{
				return this.Listener.HotKeyTipsTextIdMap.GetValueOrDefault(EHotKeyNameStateType.ToggleSelected, string.Empty);
			}
			return this.Listener.HotKeyTipsTextIdMap.GetValueOrDefault(EHotKeyNameStateType.Normal, string.Empty);
		}

		// Token: 0x0603326C RID: 209516 RVA: 0x00CCEA85 File Offset: 0x00CCCC85
		protected override bool OnHandlePointerEnter(ULGUIPointerEventData eventData)
		{
			return !(this.Selectable as UUIExtendToggle).bToggleOnSelect;
		}

		// Token: 0x0603326D RID: 209517 RVA: 0x00CCEA9C File Offset: 0x00CCCC9C
		protected override bool OnHandlePointerSelect(ULGUIPointerEventData eventData)
		{
			if (!this.OnHandlePointerSelectInheritance(eventData))
			{
				return false;
			}
			UUIExtendToggle uuiextendToggle = this.Selectable as UUIExtendToggle;
			if (uuiextendToggle.ToggleState == EToggleState.ETT_UnChecked)
			{
				if (eventData != null && eventData.inputType == ELGUIPointerInputType.Navigation && uuiextendToggle.bToggleOnSelect)
				{
					uuiextendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
				}
				this.ScrollToSelectableComponent(uuiextendToggle);
			}
			else if (uuiextendToggle.ToggleState == EToggleState.ETT_UnDetermined)
			{
				this.ScrollToSelectableComponent(uuiextendToggle);
				if (eventData != null && eventData.inputType == ELGUIPointerInputType.Navigation && uuiextendToggle.bToggleOnSelect)
				{
					ControllerBase<UiNavigationNewController>.Instance.SimulateClickItem(uuiextendToggle.RootUIComp, null);
				}
			}
			else
			{
				this.ScrollToSelectableComponent(uuiextendToggle);
			}
			return base.IsAllowNavigationByGroup();
		}

		// Token: 0x0603326E RID: 209518 RVA: 0x00CCEB47 File Offset: 0x00CCCD47
		protected virtual bool OnHandlePointerSelectInheritance(ULGUIPointerEventData eventData)
		{
			return true;
		}
	}
}
