using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D66 RID: 19814
	public class SettingSliderIncreaseReverseComponent : SliderIncreaseComponent
	{
		// Token: 0x060335BD RID: 210365 RVA: 0x00CD8A3E File Offset: 0x00CD6C3E
		public SettingSliderIncreaseReverseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335BE RID: 210366 RVA: 0x00CD8A47 File Offset: 0x00CD6C47
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.073f)
			{
				return;
			}
			this.SetValue(-value * 0.01f);
		}

		// Token: 0x0401DC72 RID: 121970
		private const float SETTING_DEAD_AREA = 0.073f;

		// Token: 0x0401DC73 RID: 121971
		private const float SETTING_INTERVAL = 0.01f;
	}
}
