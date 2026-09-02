using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6E RID: 19822
	public class SettingSliderReduceReverseInsideComponent : SliderReduceInsideComponent
	{
		// Token: 0x060335D0 RID: 210384 RVA: 0x00CD8BD1 File Offset: 0x00CD6DD1
		public SettingSliderReduceReverseInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335D1 RID: 210385 RVA: 0x00CD8BDA File Offset: 0x00CD6DDA
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.073f)
			{
				return;
			}
			this.SetValue(-value * 0.01f);
		}
	}
}
