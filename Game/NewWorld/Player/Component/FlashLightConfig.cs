using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Player.Component
{
	// Token: 0x0200489E RID: 18590
	[NullableContext(1)]
	[Nullable(0)]
	public class FlashLightConfig
	{
		// Token: 0x06030709 RID: 198409 RVA: 0x00BDF97C File Offset: 0x00BDDB7C
		public void Init(BP_FlashLightConfig_C asset)
		{
			Transform relativeTrans = this.RelativeTrans;
			FTransform relativeTrans2 = asset.RelativeTrans;
			relativeTrans.FromUeTransform(relativeTrans2);
			this.Intensity = asset.Intensity;
			this.AttenuationRadius = asset.AttenuationRadius;
			this.InnerConeAngle = asset.InnerConeAngle;
			this.OuterConeAngle = asset.OuterConeAngle;
			this.SpecularScale = asset.SpecularScale;
			this.LightFalloffExponent = asset.LightFalloffExponent;
			this.VolumetricScatteringIntensity = asset.VolumetricScatteringIntensity;
			this.LightColor = asset.LightColor;
			this.ToonRealTimeShadowIntensity = asset.ToonRealTimeShadowIntensity;
			this.ToonPointLightFallOff = asset.ToonPointLightFallOff;
			this.ToonDistanceBlendIntensity = asset.ToonDistanceBlendIntensity;
			this.ToonIntensity = asset.ToonIntensity;
			this.ToonLightingPriority = asset.ToonLightingPriority;
			this.ToonShadowColorIntensity = asset.ToonShadowColorIntensity;
			this.LightToonColor = asset.LightToonColor;
			this.IESTexture = asset.IESTexture;
			this.IsUseCameraPitch = asset.UseCameraPitch;
			this.IsUsePitchLerp = asset.UsePitchLerp;
			this.MinTurnSpeed = asset.MinTurnSpeed;
			this.MaxTurnSpeed = asset.MaxTurnSpeed;
			this.LerpBeginDeg = asset.LerpBeginDeg;
			this.LerpPow = asset.LerpPow;
			this.LerpCurve = asset.LerpCurve;
		}

		// Token: 0x0603070A RID: 198410 RVA: 0x00BDFAB4 File Offset: 0x00BDDCB4
		public bool IsValid()
		{
			return this.Intensity >= 0f && this.AttenuationRadius >= 0f && this.MaxTurnSpeed >= this.MinTurnSpeed && this.MinTurnSpeed > 0f && this.OuterConeAngle >= this.InnerConeAngle && this.InnerConeAngle > 0f && (!this.IsUsePitchLerp || this.LerpCurve != null || this.LerpPow != 0f);
		}

		// Token: 0x0603070B RID: 198411 RVA: 0x00BDFB38 File Offset: 0x00BDDD38
		public float GetLerpDegAlpha(float inAlpha)
		{
			float num = Singleton<MathUtils>.Instance.Clamp(inAlpha, 0f, 1f);
			UCurveFloat lerpCurve = this.LerpCurve;
			if (lerpCurve != null && lerpCurve.IsValid())
			{
				return Singleton<MathUtils>.Instance.Clamp(this.LerpCurve.GetFloatValue(num), 0f, 1f);
			}
			return (float)Math.Pow((double)num, (double)this.LerpPow);
		}

		// Token: 0x0401BD1A RID: 113946
		public Transform RelativeTrans = Transform.Create();

		// Token: 0x0401BD1B RID: 113947
		public float Intensity;

		// Token: 0x0401BD1C RID: 113948
		public float AttenuationRadius;

		// Token: 0x0401BD1D RID: 113949
		public float InnerConeAngle;

		// Token: 0x0401BD1E RID: 113950
		public float OuterConeAngle;

		// Token: 0x0401BD1F RID: 113951
		public float SpecularScale;

		// Token: 0x0401BD20 RID: 113952
		public float LightFalloffExponent;

		// Token: 0x0401BD21 RID: 113953
		public float VolumetricScatteringIntensity;

		// Token: 0x0401BD22 RID: 113954
		public FLinearColor LightColor = new FLinearColor();

		// Token: 0x0401BD23 RID: 113955
		public float ToonPointLightFallOff;

		// Token: 0x0401BD24 RID: 113956
		public float ToonDistanceBlendIntensity;

		// Token: 0x0401BD25 RID: 113957
		public float ToonIntensity;

		// Token: 0x0401BD26 RID: 113958
		public int ToonLightingPriority;

		// Token: 0x0401BD27 RID: 113959
		public float ToonShadowColorIntensity;

		// Token: 0x0401BD28 RID: 113960
		public float ToonRealTimeShadowIntensity;

		// Token: 0x0401BD29 RID: 113961
		public FLinearColor LightToonColor = new FLinearColor();

		// Token: 0x0401BD2A RID: 113962
		[Nullable(2)]
		public UTextureLightProfile IESTexture;

		// Token: 0x0401BD2B RID: 113963
		public bool IsUseCameraPitch;

		// Token: 0x0401BD2C RID: 113964
		public bool IsUsePitchLerp;

		// Token: 0x0401BD2D RID: 113965
		public float MinTurnSpeed;

		// Token: 0x0401BD2E RID: 113966
		public float MaxTurnSpeed;

		// Token: 0x0401BD2F RID: 113967
		public float LerpBeginDeg;

		// Token: 0x0401BD30 RID: 113968
		public float LerpPow;

		// Token: 0x0401BD31 RID: 113969
		[Nullable(2)]
		public UCurveFloat LerpCurve;
	}
}
