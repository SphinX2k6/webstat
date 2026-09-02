using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D69 RID: 19817
	public class SliderIncreaseInsideComponent : SliderInsideComponent
	{
		// Token: 0x060335C4 RID: 210372 RVA: 0x00CD8B11 File Offset: 0x00CD6D11
		public SliderIncreaseInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335C5 RID: 210373 RVA: 0x00CD8B1A File Offset: 0x00CD6D1A
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(0.05f);
		}

		// Token: 0x060335C6 RID: 210374 RVA: 0x00CD8B27 File Offset: 0x00CD6D27
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.4f)
			{
				return;
			}
			this.SetValue(value * 0.05f);
		}
	}
}
