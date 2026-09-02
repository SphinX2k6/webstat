using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070B2 RID: 28850
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneSubCamera
	{
		// Token: 0x06045EF5 RID: 286453 RVA: 0x0125388C File Offset: 0x01251A8C
		[NullableContext(1)]
		public static int Compare(SceneSubCamera a, SceneSubCamera b)
		{
			int num = a.Type - b.Type;
			if (num == 0)
			{
				num--;
			}
			return num;
		}

		// Token: 0x06045EF6 RID: 286454 RVA: 0x012538AF File Offset: 0x01251AAF
		public void Clear()
		{
			if (this.Camera != null && this.Camera.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("SceneSubCamera.Clear", this.Camera, null);
				this.Camera = null;
			}
		}

		// Token: 0x06045EF7 RID: 286455 RVA: 0x012538E4 File Offset: 0x01251AE4
		[NullableContext(1)]
		public void CopyData(SceneSubCamera camera)
		{
			if (camera.Camera == null || !camera.Camera.IsValid())
			{
				return;
			}
			AActor camera2 = this.Camera;
			FRotator frotator = camera.Camera.K2_GetActorRotation();
			FVectorDouble fvectorDouble = camera.Camera.D_K2_GetActorLocation();
			FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
			FVector fvector = fvectorDouble2;
			FTransformDouble ftransformDouble = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			camera2.D_K2_SetActorTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
			this.FadeIn = camera.FadeIn;
			this.FadeOut = camera.FadeOut;
			this.IsKeepUi = camera.IsKeepUi;
		}

		// Token: 0x040272D7 RID: 160471
		public ESceneSubCameraType Type = ESceneSubCameraType.Default;

		// Token: 0x040272D8 RID: 160472
		public BP_CineCamera_C Camera;

		// Token: 0x040272D9 RID: 160473
		[Nullable(1)]
		public Rotator StartRotation = new Rotator();

		// Token: 0x040272DA RID: 160474
		public float FadeIn;

		// Token: 0x040272DB RID: 160475
		public EViewTargetBlendFunction FadeInFunc;

		// Token: 0x040272DC RID: 160476
		public float FadeInExp;

		// Token: 0x040272DD RID: 160477
		public UCurveFloat FadeInCurve;

		// Token: 0x040272DE RID: 160478
		public float FadeOut;

		// Token: 0x040272DF RID: 160479
		public EViewTargetBlendFunction FadeOutFunc;

		// Token: 0x040272E0 RID: 160480
		public float FadeOutExp;

		// Token: 0x040272E1 RID: 160481
		public UCurveFloat FadeOutCurve;

		// Token: 0x040272E2 RID: 160482
		public bool IsBinding;

		// Token: 0x040272E3 RID: 160483
		public bool IsKeepUi;

		// Token: 0x040272E4 RID: 160484
		public bool IsCameraAberrationEnable;

		// Token: 0x040272E5 RID: 160485
		public CameraAberrationView CameraAberrationView;

		// Token: 0x040272E6 RID: 160486
		public bool CanAcceptInput;

		// Token: 0x040272E7 RID: 160487
		public bool EnableInPlotMode;

		// Token: 0x040272E8 RID: 160488
		public SceneFixInputData FixInputData;

		// Token: 0x040272E9 RID: 160489
		public SceneCameraFollowConfig FollowConfig;
	}
}
