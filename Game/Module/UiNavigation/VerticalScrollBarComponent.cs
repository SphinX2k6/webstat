using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D52 RID: 19794
	public class VerticalScrollBarComponent : ScrollBarComponentBase
	{
		// Token: 0x06033580 RID: 210304 RVA: 0x00CD8435 File Offset: 0x00CD6635
		public VerticalScrollBarComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033581 RID: 210305 RVA: 0x00CD843E File Offset: 0x00CD663E
		protected override void HandleScrollBarChange(float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.VerticalScrollBarChangeSchedule(value * 4.5f);
		}

		// Token: 0x0401DC66 RID: 121958
		private const float SCROLL_COEFFICIENT = 4.5f;
	}
}
