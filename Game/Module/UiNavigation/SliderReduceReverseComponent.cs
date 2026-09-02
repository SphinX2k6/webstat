using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D63 RID: 19811
	public class SliderReduceReverseComponent : SliderComponent
	{
		// Token: 0x060335B6 RID: 210358 RVA: 0x00CD89CD File Offset: 0x00CD6BCD
		public SliderReduceReverseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335B7 RID: 210359 RVA: 0x00CD89D6 File Offset: 0x00CD6BD6
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(-0.05f);
		}

		// Token: 0x060335B8 RID: 210360 RVA: 0x00CD89E3 File Offset: 0x00CD6BE3
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value <= 0.4f)
			{
				return;
			}
			this.SetValue(-value * 0.05f);
		}
	}
}
