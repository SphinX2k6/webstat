using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;

// Token: 0x020030E7 RID: 12519
[NullableContext(1)]
[Nullable(0)]
public class FreeFollowingParams
{
	// Token: 0x06019DF8 RID: 105976 RVA: 0x0078FC30 File Offset: 0x0078DE30
	public FreeFollowingParams()
	{
	}

	// Token: 0x06019DF9 RID: 105977 RVA: 0x0078FCE4 File Offset: 0x0078DEE4
	public FreeFollowingParams(SFreeFollowingConfig data)
	{
		this.Enable = data.Enable;
		this.FollowOnRight = data.FollowOnRight;
		this.AutoChangeSide = data.AutoChangeSide;
		this.EnableLocalMovementHold = data.EnableLocalMovementHold;
		this.MovementIntentSmoothingTime = (double)data.MovementIntentSmoothingTime;
		this.LocalMovementEnterRate = Singleton<MathUtils>.Instance.Clamp((double)data.LocalMovementEnterRate, 0.0, 0.7);
		this.LocalMovementEnterConfirmTime = (double)data.LocalMovementEnterConfirmTime;
		this.RunReferenceDirectionSmoothingTime = (double)data.RunReferenceDirectionSmoothingTime;
		this.SprintReferenceDirectionSmoothingTime = (double)data.SprintReferenceDirectionSmoothingTime;
		this.StopConfirmTime = (double)data.StopConfirmTime;
		this.WalkBehindTargetPauseTime = (double)data.WalkBehindTargetPauseTime;
		this.StartFollowingRadius = (double)data.StartFollowingRadius;
		this.FollowRadius = (double)data.FollowRadius;
		this.MaxForwardOffset = (double)Math.Max(0f, data.MaxForwardOffset);
		this.FullForwardOffsetSpeed = (double)((data.FullForwardOffsetSpeed <= 0f) ? 600f : data.FullForwardOffsetSpeed);
		this.SideAngleTolerance = (double)Singleton<MathUtils>.Instance.Clamp(data.SideAngleTolerance, 0f, 89f);
		this.OffsetAngle = (double)Singleton<MathUtils>.Instance.Clamp(data.OffsetAngle, 0f, 89f);
		this.DebugDraw = data.DebugDraw;
		if (!this.Enable)
		{
			return;
		}
		if (this.FollowRadius <= 0.0)
		{
			this.Enable = false;
			this.InvalidReason = "FollowRadius必须大于0";
			return;
		}
		if (this.StartFollowingRadius < this.FollowRadius)
		{
			this.StartFollowingRadius = this.FollowRadius;
			this.ClampedStartFollowingRadius = true;
		}
		this.WalkFollowRadius = ((data.WalkFollowRadius <= 0f) ? this.FollowRadius : ((double)data.WalkFollowRadius));
		this.WalkStartFollowingRadius = ((data.WalkStartFollowingRadius <= 0f) ? this.StartFollowingRadius : ((double)data.WalkStartFollowingRadius));
		if (this.WalkStartFollowingRadius < this.WalkFollowRadius)
		{
			this.WalkStartFollowingRadius = this.WalkFollowRadius;
			this.ClampedWalkStartFollowingRadius = true;
		}
	}

	// Token: 0x0400CF32 RID: 53042
	public bool Enable;

	// Token: 0x0400CF33 RID: 53043
	public bool FollowOnRight = true;

	// Token: 0x0400CF34 RID: 53044
	public bool AutoChangeSide;

	// Token: 0x0400CF35 RID: 53045
	public bool EnableLocalMovementHold = true;

	// Token: 0x0400CF36 RID: 53046
	public double MovementIntentSmoothingTime = 0.5;

	// Token: 0x0400CF37 RID: 53047
	public double LocalMovementEnterRate = 0.55;

	// Token: 0x0400CF38 RID: 53048
	public double LocalMovementEnterConfirmTime = 0.35;

	// Token: 0x0400CF39 RID: 53049
	public double RunReferenceDirectionSmoothingTime = 0.2;

	// Token: 0x0400CF3A RID: 53050
	public double SprintReferenceDirectionSmoothingTime = 0.12;

	// Token: 0x0400CF3B RID: 53051
	public double StopConfirmTime = 0.2;

	// Token: 0x0400CF3C RID: 53052
	public double WalkBehindTargetPauseTime = 1.0;

	// Token: 0x0400CF3D RID: 53053
	public double StartFollowingRadius;

	// Token: 0x0400CF3E RID: 53054
	public double FollowRadius;

	// Token: 0x0400CF3F RID: 53055
	public double WalkStartFollowingRadius;

	// Token: 0x0400CF40 RID: 53056
	public double WalkFollowRadius;

	// Token: 0x0400CF41 RID: 53057
	public double MaxForwardOffset;

	// Token: 0x0400CF42 RID: 53058
	public double FullForwardOffsetSpeed = 600.0;

	// Token: 0x0400CF43 RID: 53059
	public double SideAngleTolerance = 30.0;

	// Token: 0x0400CF44 RID: 53060
	public double OffsetAngle;

	// Token: 0x0400CF45 RID: 53061
	public string InvalidReason = "";

	// Token: 0x0400CF46 RID: 53062
	public bool ClampedStartFollowingRadius;

	// Token: 0x0400CF47 RID: 53063
	public bool ClampedWalkStartFollowingRadius;

	// Token: 0x0400CF48 RID: 53064
	public bool DebugDraw;
}
