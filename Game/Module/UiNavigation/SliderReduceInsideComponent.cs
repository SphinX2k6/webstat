using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6A RID: 19818
	public class SliderReduceInsideComponent : SliderInsideComponent
	{
		// Token: 0x060335C7 RID: 210375 RVA: 0x00CD8B3F File Offset: 0x00CD6D3F
		public SliderReduceInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335C8 RID: 210376 RVA: 0x00CD8B48 File Offset: 0x00CD6D48
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(-0.05f);
		}

		// Token: 0x060335C9 RID: 210377 RVA: 0x00CD8B55 File Offset: 0x00CD6D55
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			if (value >= -0.4f)
			{
				return;
			}
			this.SetValue(value * 0.05f);
		}
	}
}
