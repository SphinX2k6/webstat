using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

// Token: 0x02000E1E RID: 3614
internal class GazeParams
{
	// Token: 0x06005569 RID: 21865 RVA: 0x000DC5B8 File Offset: 0x000DA7B8
	[NullableContext(1)]
	public GazeParams(GrapplingHookPointComponent grapplingPoint, bool useGaze2 = false)
	{
		if (useGaze2)
		{
			IGazeNextPointAfterInteract gazeNextPointAfterInteract = grapplingPoint.GazeNextPointAfterInteract;
			this.LockCamera = ((gazeNextPointAfterInteract != null) ? gazeNextPointAfterInteract.GazePerformance.LockCamera : null).GetValueOrDefault();
			IGazeNextPointAfterInteract gazeNextPointAfterInteract2 = grapplingPoint.GazeNextPointAfterInteract;
			this.FadeInTime = ((gazeNextPointAfterInteract2 != null) ? gazeNextPointAfterInteract2.GazePerformance.FadeInTime : 0f);
			IGazeNextPointAfterInteract gazeNextPointAfterInteract3 = grapplingPoint.GazeNextPointAfterInteract;
			this.FadeOutTime = new float?(((gazeNextPointAfterInteract3 != null) ? gazeNextPointAfterInteract3.GazePerformance.FadeOutTime : null).GetValueOrDefault());
			IGazeNextPointAfterInteract gazeNextPointAfterInteract4 = grapplingPoint.GazeNextPointAfterInteract;
			this.StayTime = ((gazeNextPointAfterInteract4 != null) ? gazeNextPointAfterInteract4.GazePerformance.StayTime : 0f);
			return;
		}
		ICameraGaze cameraGaze = grapplingPoint.CameraGaze;
		this.LockCamera = ((cameraGaze != null) ? cameraGaze.LockCamera : null).GetValueOrDefault();
		ICameraGaze cameraGaze2 = grapplingPoint.CameraGaze;
		this.FadeInTime = ((cameraGaze2 != null) ? cameraGaze2.FadeInTime : 0f);
		ICameraGaze cameraGaze3 = grapplingPoint.CameraGaze;
		this.FadeOutTime = ((cameraGaze3 != null) ? cameraGaze3.FadeOutTime : null);
		ICameraGaze cameraGaze4 = grapplingPoint.CameraGaze;
		this.StayTime = ((cameraGaze4 != null) ? cameraGaze4.StayTime : 0f);
	}

	// Token: 0x04001A87 RID: 6791
	public bool LockCamera;

	// Token: 0x04001A88 RID: 6792
	public float FadeInTime;

	// Token: 0x04001A89 RID: 6793
	public float? FadeOutTime;

	// Token: 0x04001A8A RID: 6794
	public float StayTime;
}
