using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CFB RID: 19707
	public class GamepadMoveRightComponent : GamepadInteractComponentBase
	{
		// Token: 0x0603340B RID: 209931 RVA: 0x00CD4D36 File Offset: 0x00CD2F36
		public GamepadMoveRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603340C RID: 209932 RVA: 0x00CD4D3F File Offset: 0x00CD2F3F
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.GamepadControlMouseMoveRight(value);
		}
	}
}
