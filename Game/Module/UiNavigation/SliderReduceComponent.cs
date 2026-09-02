using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D61 RID: 19809
	public class SliderReduceComponent : SliderComponent
	{
		// Token: 0x060335B0 RID: 210352 RVA: 0x00CD8970 File Offset: 0x00CD6B70
		public SliderReduceComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335B1 RID: 210353 RVA: 0x00CD8979 File Offset: 0x00CD6B79
		protected override void OnRelease(HotKeyMap config)
		{
			this.SetValue(-0.05f);
		}

		// Token: 0x060335B2 RID: 210354 RVA: 0x00CD8986 File Offset: 0x00CD6B86
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
