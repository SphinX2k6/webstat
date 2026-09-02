using System;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFC RID: 19708
	public class GamepadCheckComponent : GamepadInteractComponentBase
	{
		// Token: 0x0603340D RID: 209933 RVA: 0x00CD4D4C File Offset: 0x00CD2F4C
		public GamepadCheckComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603340E RID: 209934 RVA: 0x00CD4D58 File Offset: 0x00CD2F58
		protected override void OnPress(HotKeyMap config)
		{
			if (!ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging() && this.IsUseDrag)
			{
				this.IsUseDrag = false;
			}
			if (this.IsUseDrag)
			{
				this.IsUseDrag = false;
				return;
			}
			this.IsUseDrag = ControllerBase<UiNavigationNewController>.Instance.IsGamepadHitListenerUseDrag();
			if (this.IsUseDrag)
			{
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(true);
			}
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(true);
		}

		// Token: 0x0603340F RID: 209935 RVA: 0x00CD4DBE File Offset: 0x00CD2FBE
		protected override void OnRelease(HotKeyMap config)
		{
			if (this.IsUseDrag)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
			ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
		}

		// Token: 0x06033410 RID: 209936 RVA: 0x00CD4DDF File Offset: 0x00CD2FDF
		protected override void OnRefreshByControllerChange()
		{
			if (this.IsUseDrag)
			{
				this.IsUseDrag = false;
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
			}
		}

		// Token: 0x0401DC36 RID: 121910
		private bool IsUseDrag;
	}
}
