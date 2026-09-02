using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6C RID: 19820
	public class SettingSliderReduceInsideComponent : SliderReduceInsideComponent
	{
		// Token: 0x060335CC RID: 210380 RVA: 0x00CD8B8E File Offset: 0x00CD6D8E
		public SettingSliderReduceInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335CD RID: 210381 RVA: 0x00CD8B97 File Offset: 0x00CD6D97
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.073f)
			{
				return;
			}
			this.SetValue(value * 0.01f);
		}
	}
}
