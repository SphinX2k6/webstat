using System;
using CSharpScript.Game.Module.SkillButtonUi;

namespace CSharpScript.Game.Module.RoleMorph.Handle
{
	// Token: 0x020050E8 RID: 20712
	public class RoleMorphPaoTaiHandle : RoleMorphHandleBase
	{
		// Token: 0x06035632 RID: 218674 RVA: 0x00D644A8 File Offset: 0x00D626A8
		public override void BeginMorph()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.ControlCameraByMoveAxis = true;
			}
		}

		// Token: 0x06035633 RID: 218675 RVA: 0x00D644CC File Offset: 0x00D626CC
		public override void EndMorph()
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null)
			{
				gamepadData.ControlCameraByMoveAxis = false;
			}
		}
	}
}
