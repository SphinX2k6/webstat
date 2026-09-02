using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D10 RID: 19728
	[NullableContext(1)]
	[Nullable(0)]
	public class InteractComponent : HotKeyComponent
	{
		// Token: 0x06033489 RID: 210057 RVA: 0x00CD61A7 File Offset: 0x00CD43A7
		public InteractComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603348A RID: 210058 RVA: 0x00CD61B0 File Offset: 0x00CD43B0
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.InteractClick();
		}

		// Token: 0x0603348B RID: 210059 RVA: 0x00CD61BC File Offset: 0x00CD43BC
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, focusListener != null, false);
		}

		// Token: 0x0603348C RID: 210060 RVA: 0x00CD61DC File Offset: 0x00CD43DC
		protected override void OnRefreshHotKeyText(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			TsUiNavigationTextChangeListener tsUiNavigationTextChangeListener = (focusListener != null) ? focusListener.GetTextChangeComponent() : null;
			if (tsUiNavigationTextChangeListener != null)
			{
				base.SetHotKeyDescTextForce(tsUiNavigationTextChangeListener.Text.GetText());
				return;
			}
			base.ResetHotKeyDescTextForce();
		}

		// Token: 0x0603348D RID: 210061 RVA: 0x00CD6218 File Offset: 0x00CD4418
		protected override void OnRefreshHotKeyTextId(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				return;
			}
			string tipsTextIdByState = focusListener.GetTipsTextIdByState();
			base.SetHotKeyTextId(tipsTextIdByState);
			base.RefreshHotKeyNameText();
		}
	}
}
