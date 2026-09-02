using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x02004826 RID: 18470
	[NullableContext(1)]
	[Nullable(0)]
	public class ProjectedDragModeStrategy : BaseDragModeStrategy
	{
		// Token: 0x1700823B RID: 33339
		// (get) Token: 0x0603010D RID: 196877 RVA: 0x00BA6780 File Offset: 0x00BA4980
		public override EKuroSplineConstrainedDragMode Mode { get; } = 1;

		// Token: 0x0603010E RID: 196878 RVA: 0x00BA6788 File Offset: 0x00BA4988
		public override void BeginDrag()
		{
			base.BeginDrag();
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return;
			}
			host.SnapToSpline();
		}

		// Token: 0x0603010F RID: 196879 RVA: 0x00BA67AD File Offset: 0x00BA49AD
		public override void SetCurrentScreenPosition(Vector screenPosition)
		{
		}

		// Token: 0x06030110 RID: 196880 RVA: 0x00BA67B0 File Offset: 0x00BA49B0
		public override void ApplyScreenDelta(Vector screenDelta)
		{
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return;
			}
			float currentDistanceAlongSpline = host.GetCurrentDistanceAlongSpline();
			float num = this.ComputeDistanceDeltaByProjectedTangent(screenDelta, currentDistanceAlongSpline);
			if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null))
			{
				host.SetDistanceAlongSpline(currentDistanceAlongSpline + num, true);
			}
		}

		// Token: 0x06030111 RID: 196881 RVA: 0x00BA67FC File Offset: 0x00BA49FC
		private float ComputeDistanceDeltaByProjectedTangent(Vector screenDelta, float anchorDistance)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null || !characterController.IsValid())
			{
				return 0f;
			}
			IKuroSplineConstrainedDrag host = this.Host;
			if (host == null)
			{
				return 0f;
			}
			USplineComponent constraintSpline = host.GetConstraintSpline();
			if (constraintSpline == null || !constraintSpline.IsValid())
			{
				return 0f;
			}
			float splineLength = constraintSpline.GetSplineLength();
			float num = Math.Max(1f, this.ProjectionScreenSpaceSampleDistance);
			float num2 = Singleton<MathUtils>.Instance.Clamp(anchorDistance - num, 0f, splineLength);
			float num3 = Singleton<MathUtils>.Instance.Clamp(anchorDistance + num, 0f, splineLength);
			float num4 = num3 - num2;
			if (num4 < 0.0001f)
			{
				return 0f;
			}
			FVectorDouble fvectorDouble = constraintSpline.D_GetLocationAtDistanceAlongSpline(num2, ESplineCoordinateSpace.World);
			FVectorDouble fvectorDouble2 = constraintSpline.D_GetLocationAtDistanceAlongSpline(num3, ESplineCoordinateSpace.World);
			FVector2D projectionStartScreenPos2D = this.ProjectionStartScreenPos2D;
			FVector2D projectionEndScreenPos2D = this.ProjectionEndScreenPos2D;
			if (!UGameplayStatics.D_ProjectWorldToScreen(Global.CharacterController, fvectorDouble, ref projectionStartScreenPos2D, false))
			{
				return 0f;
			}
			if (!UGameplayStatics.D_ProjectWorldToScreen(Global.CharacterController, fvectorDouble2, ref projectionEndScreenPos2D, false))
			{
				return 0f;
			}
			this.ProjectionStartScreenPos2D = projectionStartScreenPos2D;
			this.ProjectionEndScreenPos2D = projectionEndScreenPos2D;
			FVector2D fvector2D = this.ProjectionEndScreenPos2D - this.ProjectionStartScreenPos2D;
			float num5 = fvector2D.Size();
			if (num5 < this.ProjectionMinScreenTangentPixels)
			{
				return 0f;
			}
			this.ProjectionScreenDelta2D.Set((float)screenDelta.X, (float)screenDelta.Y);
			float num6 = this.ProjectionScreenDelta2D.Size();
			if (num6 < 0.0001f)
			{
				return 0f;
			}
			FVector2D fvector2D2 = fvector2D / num5;
			float num7 = FVector2D.DotProduct(this.ProjectionScreenDelta2D, fvector2D2);
			if (Math.Abs(num7) / num6 < this.ProjectionTangentAlignmentThreshold)
			{
				return 0f;
			}
			float num8 = num4 / num5;
			return num7 * num8 * this.ProjectionScreenSpaceDragScale;
		}

		// Token: 0x0401B986 RID: 113030
		private readonly float ProjectionScreenSpaceSampleDistance = 20f;

		// Token: 0x0401B987 RID: 113031
		private readonly float ProjectionMinScreenTangentPixels = 0.1f;

		// Token: 0x0401B988 RID: 113032
		private readonly float ProjectionScreenSpaceDragScale = 1f;

		// Token: 0x0401B989 RID: 113033
		private readonly float ProjectionTangentAlignmentThreshold = 0.2f;

		// Token: 0x0401B98A RID: 113034
		private FVector2D ProjectionStartScreenPos2D = new FVector2D();

		// Token: 0x0401B98B RID: 113035
		private FVector2D ProjectionEndScreenPos2D = new FVector2D();

		// Token: 0x0401B98C RID: 113036
		private FVector2D ProjectionScreenDelta2D = new FVector2D();
	}
}
