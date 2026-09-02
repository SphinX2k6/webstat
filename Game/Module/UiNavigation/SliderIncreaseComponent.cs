using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D60 RID: 19808
	public class SliderIncreaseComponent : SliderComponent
	{
		// Token: 0x060335AD RID: 210349 RVA: 0x00CD8942 File Offset: 0x00CD6B42
		public SliderIncreaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335AE RID: 210350 RVA: 0x00CD894B File Offset: 0x00CD6B4B
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(0.05f);
		}

		// Token: 0x060335AF RID: 210351 RVA: 0x00CD8958 File Offset: 0x00CD6B58
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
