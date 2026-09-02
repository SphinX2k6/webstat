using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D64 RID: 19812
	public class SettingSliderIncreaseComponent : SliderIncreaseComponent
	{
		// Token: 0x060335B9 RID: 210361 RVA: 0x00CD89FC File Offset: 0x00CD6BFC
		public SettingSliderIncreaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335BA RID: 210362 RVA: 0x00CD8A05 File Offset: 0x00CD6C05
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.073f)
			{
				return;
			}
			this.SetValue(value * 0.01f);
		}

		// Token: 0x0401DC6E RID: 121966
		private const float SETTING_DEAD_AREA = 0.073f;

		// Token: 0x0401DC6F RID: 121967
		private const float SETTING_INTERVAL = 0.01f;
	}
}
