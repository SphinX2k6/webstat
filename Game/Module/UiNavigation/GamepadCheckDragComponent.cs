using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFD RID: 19709
	public class GamepadCheckDragComponent : GamepadInteractComponentBase
	{
		// Token: 0x06033411 RID: 209937 RVA: 0x00CD4E06 File Offset: 0x00CD3006
		public GamepadCheckDragComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033412 RID: 209938 RVA: 0x00CD4E10 File Offset: 0x00CD3010
		protected override void OnPress(HotKeyMap config)
		{
			if (this.IsUseDrag)
			{
				this.IsUseDrag = false;
				return;
			}
			this.IsUseDrag = ControllerBase<UiNavigationNewController>.Instance.IsGamepadHitListenerUseDrag();
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = currentViewHandle.GetGuideUiListener();
			if (tsUiNavigationBehaviorListener == null)
			{
				tsUiNavigationBehaviorListener = currentViewHandle.GetHitComponentListener();
			}
			ControllerBase<UiNavigationNewController>.Instance.GamepadInteractSimulationPointer((tsUiNavigationBehaviorListener != null) ? tsUiNavigationBehaviorListener.GetBehaviorComponent() : null, true);
			if (!ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging() && this.IsUseDrag)
			{
				this.IsUseDrag = false;
			}
		}

		// Token: 0x06033413 RID: 209939 RVA: 0x00CD4E8C File Offset: 0x00CD308C
		protected override void OnRelease(HotKeyMap config)
		{
			if (this.IsUseDrag)
			{
				return;
			}
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			if (currentViewHandle.GetGuideUiListener() == null)
			{
				currentViewHandle.GetHitComponentListener();
			}
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
		}

		// Token: 0x06033414 RID: 209940 RVA: 0x00CD4EC7 File Offset: 0x00CD30C7
		protected override void OnRefreshByControllerChange()
		{
			if (this.IsUseDrag)
			{
				this.IsUseDrag = false;
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
			}
		}

		// Token: 0x0401DC37 RID: 121911
		private bool IsUseDrag;
	}
}
