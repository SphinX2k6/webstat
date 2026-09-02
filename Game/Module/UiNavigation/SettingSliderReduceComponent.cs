using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D65 RID: 19813
	public class SettingSliderReduceComponent : SliderReduceComponent
	{
		// Token: 0x060335BB RID: 210363 RVA: 0x00CD8A1D File Offset: 0x00CD6C1D
		public SettingSliderReduceComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335BC RID: 210364 RVA: 0x00CD8A26 File Offset: 0x00CD6C26
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.073f)
			{
				return;
			}
			this.SetValue(value * 0.01f);
		}

		// Token: 0x0401DC70 RID: 121968
		private const float SETTING_DEAD_AREA = 0.073f;

		// Token: 0x0401DC71 RID: 121969
		private const float SETTING_INTERVAL = 0.01f;
	}
}
