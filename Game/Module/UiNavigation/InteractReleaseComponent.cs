using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D11 RID: 19729
	[NullableContext(1)]
	[Nullable(0)]
	public class InteractReleaseComponent : HotKeyComponent
	{
		// Token: 0x0603348E RID: 210062 RVA: 0x00CD6244 File Offset: 0x00CD4444
		public InteractReleaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603348F RID: 210063 RVA: 0x00CD624D File Offset: 0x00CD444D
		protected override void OnPress(HotKeyMap config)
		{
			this.PressListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			ControllerBase<UiNavigationNewController>.Instance.Interact(true, config.Id);
		}

		// Token: 0x06033490 RID: 210064 RVA: 0x00CD6272 File Offset: 0x00CD4472
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.InteractRelease(config.Id, this.PressListener);
			this.PressListener = null;
		}

		// Token: 0x06033491 RID: 210065 RVA: 0x00CD6294 File Offset: 0x00CD4494
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, focusListener != null, false);
		}

		// Token: 0x06033492 RID: 210066 RVA: 0x00CD62B4 File Offset: 0x00CD44B4
		protected override void HandleLogicAfterRefresh(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (this.PressListener != null && this.PressListener != focusListener)
			{
				this.OnRelease(base.GetHotKeyConfig().GetValueOrDefault());
			}
		}

		// Token: 0x06033493 RID: 210067 RVA: 0x00CD62F0 File Offset: 0x00CD44F0
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

		// Token: 0x06033494 RID: 210068 RVA: 0x00CD632C File Offset: 0x00CD452C
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

		// Token: 0x0401DC46 RID: 121926
		[Nullable(2)]
		private TsUiNavigationBehaviorListener PressListener;
	}
}
