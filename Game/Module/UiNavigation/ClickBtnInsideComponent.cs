using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE8 RID: 19688
	[NullableContext(1)]
	[Nullable(0)]
	public class ClickBtnInsideComponent : HotKeyComponent
	{
		// Token: 0x060333C0 RID: 209856 RVA: 0x00CD42FA File Offset: 0x00CD24FA
		public ClickBtnInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333C1 RID: 209857 RVA: 0x00CD4304 File Offset: 0x00CD2504
		private void ClickButtonInside(ENavigationDirectionType direction)
		{
			if (base.IsAxisAllDirection())
			{
				ControllerBase<UiNavigationNewController>.Instance.ClickButtonInside(base.GetBindButtonTag());
				return;
			}
			if (direction == ENavigationDirectionType.Left && base.IsAxisReverse())
			{
				ControllerBase<UiNavigationNewController>.Instance.ClickButtonInside(base.GetBindButtonTag());
				return;
			}
			if (direction == ENavigationDirectionType.Right && base.IsAxisPositive())
			{
				ControllerBase<UiNavigationNewController>.Instance.ClickButtonInside(base.GetBindButtonTag());
			}
		}

		// Token: 0x060333C2 RID: 209858 RVA: 0x00CD4363 File Offset: 0x00CD2563
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ClickButtonInside(config.BindButtonTag);
		}

		// Token: 0x060333C3 RID: 209859 RVA: 0x00CD4376 File Offset: 0x00CD2576
		protected override void OnStartInputAxis(string axisName)
		{
			UiNavigationJoystickInput.RegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.ClickButtonInside));
		}

		// Token: 0x060333C4 RID: 209860 RVA: 0x00CD4389 File Offset: 0x00CD2589
		protected override void OnFinishInputAxis(string axisName)
		{
			UiNavigationJoystickInput.UnRegisterLeftJoystickFunction(new Action<ENavigationDirectionType>(this.ClickButtonInside));
		}

		// Token: 0x060333C5 RID: 209861 RVA: 0x00CD439C File Offset: 0x00CD259C
		protected override void OnRefreshHotKeyText(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = focusListener.GetChildListenerByTag(bindButtonTag);
			}
			TsUiNavigationTextChangeListener tsUiNavigationTextChangeListener = (tsUiNavigationBehaviorListener != null) ? tsUiNavigationBehaviorListener.GetTextChangeComponent() : null;
			if (tsUiNavigationTextChangeListener != null)
			{
				base.SetHotKeyDescTextForce(tsUiNavigationTextChangeListener.Text.GetText());
				return;
			}
			base.ResetHotKeyDescTextForce();
		}

		// Token: 0x060333C6 RID: 209862 RVA: 0x00CD4404 File Offset: 0x00CD2604
		protected override void OnRefreshHotKeyTextId(UiNavigationViewHandle viewHandle)
		{
			if (this.CurComponent.GetIsForceSetText())
			{
				return;
			}
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = focusListener.GetChildListenerByTag(bindButtonTag);
			}
			string hotKeyTextId = (tsUiNavigationBehaviorListener != null) ? tsUiNavigationBehaviorListener.GetTipsTextIdByState() : null;
			base.SetHotKeyTextId(hotKeyTextId);
			base.RefreshHotKeyNameText();
		}

		// Token: 0x060333C7 RID: 209863 RVA: 0x00CD446C File Offset: 0x00CD266C
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.IsLinkListener(focusListener.GetOwner()))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = focusListener.GetChildListenerByTag(bindButtonTag);
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, tsUiNavigationBehaviorListener != null && tsUiNavigationBehaviorListener.IsListenerActive(), false);
		}
	}
}
