using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D50 RID: 19792
	public class ScrollBarComponent : ScrollBarComponentBase
	{
		// Token: 0x0603357C RID: 210300 RVA: 0x00CD8402 File Offset: 0x00CD6602
		public ScrollBarComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603357D RID: 210301 RVA: 0x00CD840B File Offset: 0x00CD660B
		protected override void HandleScrollBarChange(float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.ScrollBarChangeSchedule(value);
		}
	}
}
