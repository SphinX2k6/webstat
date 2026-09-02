using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6D RID: 19821
	public class SettingSliderIncreaseReverseInsideComponent : SliderIncreaseInsideComponent
	{
		// Token: 0x060335CE RID: 210382 RVA: 0x00CD8BAF File Offset: 0x00CD6DAF
		public SettingSliderIncreaseReverseInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335CF RID: 210383 RVA: 0x00CD8BB8 File Offset: 0x00CD6DB8
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.073f)
			{
				return;
			}
			this.SetValue(-value * 0.01f);
		}
	}
}
