using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6B RID: 19819
	public class SettingSliderIncreaseInsideComponent : SliderIncreaseInsideComponent
	{
		// Token: 0x060335CA RID: 210378 RVA: 0x00CD8B6D File Offset: 0x00CD6D6D
		public SettingSliderIncreaseInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335CB RID: 210379 RVA: 0x00CD8B76 File Offset: 0x00CD6D76
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.073f)
			{
				return;
			}
			this.SetValue(value * 0.01f);
		}
	}
}
