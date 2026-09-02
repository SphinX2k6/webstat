using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D67 RID: 19815
	public class SettingSliderReduceReverseComponent : SliderReduceComponent
	{
		// Token: 0x060335BF RID: 210367 RVA: 0x00CD8A60 File Offset: 0x00CD6C60
		public SettingSliderReduceReverseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335C0 RID: 210368 RVA: 0x00CD8A69 File Offset: 0x00CD6C69
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.073f)
			{
				return;
			}
			this.SetValue(-value * 0.01f);
		}

		// Token: 0x0401DC74 RID: 121972
		private const float SETTING_DEAD_AREA = 0.073f;

		// Token: 0x0401DC75 RID: 121973
		private const float SETTING_INTERVAL = 0.01f;
	}
}
