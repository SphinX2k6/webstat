using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D62 RID: 19810
	public class SliderIncreaseReverseComponent : SliderComponent
	{
		// Token: 0x060335B3 RID: 210355 RVA: 0x00CD899E File Offset: 0x00CD6B9E
		public SliderIncreaseReverseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335B4 RID: 210356 RVA: 0x00CD89A7 File Offset: 0x00CD6BA7
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(0.05f);
		}

		// Token: 0x060335B5 RID: 210357 RVA: 0x00CD89B4 File Offset: 0x00CD6BB4
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.4f)
			{
				return;
			}
			this.SetValue(-value * 0.05f);
		}
	}
}
