using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions
{
	// Token: 0x02006E75 RID: 28277
	public class GuaranteeActionExitOrbitalCamera : GuaranteeActionBase
	{
		// Token: 0x0604498F RID: 280975 RVA: 0x011D538B File Offset: 0x011D358B
		[NullableContext(2)]
		protected override void OnExecute(ActionParams @params)
		{
			ControllerBase<CameraController>.Instance.MainModel.OrbitalCamera.PlayerComponent.StopCameraOrbital();
		}
	}
}
