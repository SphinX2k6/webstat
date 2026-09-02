using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x0200259F RID: 9631
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PhotographQuickModel : ModelBase<PhotographQuickModel>
{
	// Token: 0x06012C4D RID: 76877 RVA: 0x0052D8A0 File Offset: 0x0052BAA0
	public PhotoCameraHandler GetHandler()
	{
		return this.CaptureHandler;
	}

	// Token: 0x06012C4E RID: 76878 RVA: 0x0052D8A8 File Offset: 0x0052BAA8
	public void ClearHandler()
	{
		PhotoCameraHandler captureHandler = this.CaptureHandler;
		if (captureHandler != null)
		{
			captureHandler.Clear();
		}
		this.CaptureHandler = null;
	}

	// Token: 0x06012C4F RID: 76879 RVA: 0x0052D8C4 File Offset: 0x0052BAC4
	public void InitHandlerForCaptureCollect()
	{
		ACameraActor acameraActor = ControllerBase<CameraController>.Instance.GetMainPlayerCameraManager().ViewTarget.Target as ACameraActor;
		if (acameraActor == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HWR, "InitHandlerForCaptureCollect 缺少相机Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		FightCameraHandler fightCameraHandler = new FightCameraHandler();
		fightCameraHandler.Init(acameraActor);
		this.CaptureHandler = fightCameraHandler;
	}

	// Token: 0x04009285 RID: 37509
	private PhotoCameraHandler CaptureHandler;
}
