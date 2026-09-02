using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D51 RID: 19793
	public class HorizontalScrollBarComponent : ScrollBarComponentBase
	{
		// Token: 0x0603357E RID: 210302 RVA: 0x00CD8418 File Offset: 0x00CD6618
		public HorizontalScrollBarComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603357F RID: 210303 RVA: 0x00CD8421 File Offset: 0x00CD6621
		protected override void HandleScrollBarChange(float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.HorizontalScrollBarChangeSchedule(-value * 4.5f);
		}

		// Token: 0x0401DC65 RID: 121957
		private const float SCROLL_COEFFICIENT = 4.5f;
	}
}
