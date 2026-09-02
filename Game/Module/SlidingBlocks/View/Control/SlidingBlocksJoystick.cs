using System;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Control
{
	// Token: 0x02004F1E RID: 20254
	public class SlidingBlocksJoystick : Joystick
	{
		// Token: 0x06034579 RID: 214393 RVA: 0x00D195A3 File Offset: 0x00D177A3
		public override void SetVisible(EBattleUiVisibleReason visibleReason, bool bVisible)
		{
			this.JoystickVisible = bVisible;
		}

		// Token: 0x0603457A RID: 214394 RVA: 0x00D195AC File Offset: 0x00D177AC
		protected override void UpdateJoystickVisible()
		{
		}
	}
}
