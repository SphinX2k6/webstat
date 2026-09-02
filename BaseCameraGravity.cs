using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E13 RID: 3603
[NullableContext(1)]
[Nullable(0)]
public class BaseCameraGravity
{
	// Token: 0x0600551E RID: 21790 RVA: 0x000D7F83 File Offset: 0x000D6183
	public void Init(CameraGravityController owner, CameraGravityDirectionConfig config)
	{
		this.Owner = owner;
		this.CameraGravityConfig = config;
		this.StartLerpGravityVector.DeepCopy(this.Owner.GetCurrentCameraGravityDirect());
		this.SetCameraGravityMode();
	}

	// Token: 0x0600551F RID: 21791 RVA: 0x000D7FAF File Offset: 0x000D61AF
	protected void InternalSetCameraGravityMode(ECameraGravityMode cameraGravityMode)
	{
		this.Owner.SetCurrentCameraGravityMode(cameraGravityMode);
	}

	// Token: 0x06005520 RID: 21792 RVA: 0x000D7FBD File Offset: 0x000D61BD
	protected virtual void SetCameraGravityMode()
	{
	}

	// Token: 0x06005521 RID: 21793 RVA: 0x000D7FBF File Offset: 0x000D61BF
	public Vector GravityStartLerpVector()
	{
		return this.StartLerpGravityVector;
	}

	// Token: 0x06005522 RID: 21794 RVA: 0x000D7FC7 File Offset: 0x000D61C7
	public virtual Vector GravityEndLerpVector()
	{
		return this.EndLerpGravityVector;
	}

	// Token: 0x04001A28 RID: 6696
	[Nullable(2)]
	public CameraGravityController Owner;

	// Token: 0x04001A29 RID: 6697
	[Nullable(2)]
	public CameraGravityDirectionConfig CameraGravityConfig;

	// Token: 0x04001A2A RID: 6698
	protected readonly Vector StartLerpGravityVector = Vector.Create();

	// Token: 0x04001A2B RID: 6699
	protected readonly Vector EndLerpGravityVector = Vector.Create();
}
