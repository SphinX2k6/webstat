using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFA RID: 19706
	public class GamepadMoveForwardComponent : GamepadInteractComponentBase
	{
		// Token: 0x06033409 RID: 209929 RVA: 0x00CD4D20 File Offset: 0x00CD2F20
		public GamepadMoveForwardComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603340A RID: 209930 RVA: 0x00CD4D29 File Offset: 0x00CD2F29
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.GamepadControlMouseMoveForward(value);
		}
	}
}
