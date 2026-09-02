using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D54 RID: 19796
	[NullableContext(1)]
	[Nullable(0)]
	public class ScrollSwitchComponent : HotKeyComponent
	{
		// Token: 0x06033585 RID: 210309 RVA: 0x00CD852D File Offset: 0x00CD672D
		public ScrollSwitchComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033586 RID: 210310 RVA: 0x00CD8536 File Offset: 0x00CD6736
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.FindScrollbar(true);
		}

		// Token: 0x06033587 RID: 210311 RVA: 0x00CD8544 File Offset: 0x00CD6744
		protected override void OnInputAxis(string axisName, float value)
		{
			if (this.IsTrigger)
			{
				if (value == 0f)
				{
					this.IsTrigger = false;
				}
				return;
			}
			if (Math.Abs(value) <= 0.6f)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.FindScrollbar(value < 0f);
			this.IsTrigger = true;
		}

		// Token: 0x06033588 RID: 210312 RVA: 0x00CD8590 File Offset: 0x00CD6790
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			NavigationScrollbarData scrollbarData = viewHandle.GetScrollbarData();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, scrollbarData.HasActiveScrollbarList(), false);
		}

		// Token: 0x0401DC69 RID: 121961
		private const float THRESHOLD = 0.6f;

		// Token: 0x0401DC6A RID: 121962
		private bool IsTrigger;
	}
}
