using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFE RID: 19710
	public class GamepadWheelComponent : GamepadInteractComponentBase
	{
		// Token: 0x06033415 RID: 209941 RVA: 0x00CD4EEE File Offset: 0x00CD30EE
		public GamepadWheelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033416 RID: 209942 RVA: 0x00CD4EF8 File Offset: 0x00CD30F8
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			float num = -value * 0.4f;
			if (this.CacheValue == num && num == 0f)
			{
				return;
			}
			this.CacheValue = num;
			Singleton<LguiEventSystemManager>.Instance.InputWheelAxisByGamepad(num);
		}

		// Token: 0x0401DC38 RID: 121912
		private const float WHEEL_SPEED_SCALE = 0.4f;

		// Token: 0x0401DC39 RID: 121913
		private float CacheValue;
	}
}
