using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070BC RID: 28860
	[NullableContext(2)]
	[Nullable(0)]
	public class WidgetCameraBlendComponent : EntityComponent
	{
		// Token: 0x1700A5DC RID: 42460
		// (get) Token: 0x06045F9C RID: 286620 RVA: 0x0125A5BF File Offset: 0x012587BF
		// (set) Token: 0x06045F9D RID: 286621 RVA: 0x0125A5C7 File Offset: 0x012587C7
		private WidgetCameraDisplayComponent DisplayComponent { get; set; }

		// Token: 0x06045F9E RID: 286622 RVA: 0x0125A5D0 File Offset: 0x012587D0
		public void SetBlendParams(float blendTime, EViewTargetBlendFunction blendFunction, byte blendExp, bool blendLocation, bool isRelativeLocation, bool overrideLocation, FVectorDouble newLocation, bool blendRotation, bool isRelativeRotation, bool overrideRotation, FRotator newRotation)
		{
			this.BlendTime = blendTime;
			this.BlendTimeToGo = blendTime;
			this.BlendFunction = blendFunction;
			this.BlendExp = (EEasingFunc)blendExp;
			this.BlendLocation = blendLocation;
			if (this.BlendLocation)
			{
				this.IsRelativeLocation = isRelativeLocation;
				BP_CineCamera_C cineCamera = this.DisplayComponent.CineCamera;
				if (this.IsRelativeLocation)
				{
					FVectorDouble value = UKismetMathLibrary.Conv_VectorToVectorDouble(cineCamera.SceneComponent.RelativeLocation);
					this.PreBlendLocation = new FVectorDouble?(value);
				}
				else
				{
					this.PreBlendLocation = new FVectorDouble?(cineCamera.D_K2_GetActorLocation());
				}
				if (overrideLocation)
				{
					this.TargetLocation.FromUeVector(newLocation);
				}
				else
				{
					Vector targetLocation = this.TargetLocation;
					FVectorDouble value2 = this.PreBlendLocation.Value;
					FVectorDouble fvectorDouble = value2 + newLocation;
					targetLocation.FromUeVector(fvectorDouble);
				}
				this.BlendRotation = blendRotation;
				if (this.BlendRotation)
				{
					this.IsRelativeRotation = isRelativeRotation;
					this.PreBlendRotation = new FRotator?(this.IsRelativeRotation ? cineCamera.SceneComponent.RelativeRotation : cineCamera.K2_GetActorRotation());
					if (overrideRotation)
					{
						this.TargetRotation = new FRotator?(newRotation);
						return;
					}
					FRotator frotator = newRotation;
					FRotator? preBlendRotation = this.PreBlendRotation;
					FRotator? targetRotation;
					if (preBlendRotation == null)
					{
						targetRotation = null;
					}
					else
					{
						FRotator valueOrDefault = preBlendRotation.GetValueOrDefault();
						targetRotation = new FRotator?(frotator + valueOrDefault);
					}
					this.TargetRotation = targetRotation;
				}
			}
		}

		// Token: 0x06045F9F RID: 286623 RVA: 0x0125A71C File Offset: 0x0125891C
		protected override bool OnStart()
		{
			this.DisplayComponent = base.Entity.GetComponent<WidgetCameraDisplayComponent>();
			return this.DisplayComponent.Valid;
		}

		// Token: 0x06045FA0 RID: 286624 RVA: 0x0125A73A File Offset: 0x0125893A
		protected override bool OnEnd()
		{
			this.DisplayComponent = null;
			return true;
		}

		// Token: 0x06045FA1 RID: 286625 RVA: 0x0125A744 File Offset: 0x01258944
		protected override void OnTick(float deltaSeconds)
		{
			float val = this.BlendTimeToGo - deltaSeconds;
			float val2 = 0f;
			this.BlendTimeToGo = Math.Max(val, val2);
			float blendPercent = this.UpdateBlendPct();
			this.UpdateLocation(blendPercent);
			this.UpdateRotation(blendPercent);
		}

		// Token: 0x06045FA2 RID: 286626 RVA: 0x0125A784 File Offset: 0x01258984
		private void UpdateLocation(float blendPercent)
		{
			if (this.BlendLocation)
			{
				FVectorDouble newRelativeLocation = UKismetMathLibrary.D_VLerp(this.PreBlendLocation.Value, this.TargetLocation.ToUeVector(false), (double)blendPercent);
				double tolerance = 0.1;
				BP_CineCamera_C cineCamera = this.DisplayComponent.CineCamera;
				if (this.IsRelativeLocation)
				{
					FHitResult fhitResult = new FHitResult();
					cineCamera.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult, false);
					if (Vector.Create(cineCamera.SceneComponent.RelativeLocation).Equals(this.TargetLocation, tolerance))
					{
						this.BlendLocation = false;
						return;
					}
				}
				else
				{
					FHitResult fhitResult2 = new FHitResult();
					cineCamera.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult2, false);
					if (Vector.Create(cineCamera.D_K2_GetActorLocation()).Equals(this.TargetLocation, tolerance))
					{
						this.BlendLocation = false;
					}
				}
			}
		}

		// Token: 0x06045FA3 RID: 286627 RVA: 0x0125A84C File Offset: 0x01258A4C
		private void UpdateRotation(float blendPercent)
		{
			if (this.BlendRotation)
			{
				FRotator newRelativeRotation = UKismetMathLibrary.RLerp(this.PreBlendRotation.Value, this.TargetRotation.Value, blendPercent, true);
				float errorTolerance = 0.1f;
				BP_CineCamera_C cineCamera = this.DisplayComponent.CineCamera;
				if (this.IsRelativeRotation)
				{
					FHitResult fhitResult = new FHitResult();
					cineCamera.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult, false);
					if (UKismetMathLibrary.EqualEqual_RotatorRotator(cineCamera.SceneComponent.RelativeRotation, this.TargetRotation.Value, errorTolerance))
					{
						this.BlendLocation = false;
						return;
					}
				}
				else
				{
					FHitResult fhitResult2 = new FHitResult();
					cineCamera.K2_SetActorRelativeRotation(newRelativeRotation, false, ref fhitResult2, false);
					if (UKismetMathLibrary.EqualEqual_RotatorRotator(cineCamera.K2_GetActorRotation(), this.TargetRotation.Value, errorTolerance))
					{
						this.BlendLocation = false;
					}
				}
			}
		}

		// Token: 0x06045FA4 RID: 286628 RVA: 0x0125A908 File Offset: 0x01258B08
		private float UpdateBlendPct()
		{
			float alpha = (float)Singleton<MathUtils>.Instance.SafeDivide((double)(this.BlendTime - this.BlendTimeToGo), (double)this.BlendTime);
			float result = 0f;
			float num = 0f;
			float num2 = 1f;
			float exponent = 3f;
			switch (this.BlendFunction)
			{
			case EViewTargetBlendFunction.VTBlend_Linear:
				result = Singleton<MathUtils>.Instance.Lerp(num, num2, alpha);
				break;
			case EViewTargetBlendFunction.VTBlend_Cubic:
				result = UKismetMathLibrary.FInterpEaseInOut(num, num2, alpha, exponent);
				break;
			case EViewTargetBlendFunction.VTBlend_EaseIn:
				result = UKismetMathLibrary.Ease(num, num2, alpha, this.BlendExp, 2f, 2);
				break;
			case EViewTargetBlendFunction.VTBlend_EaseOut:
				result = UKismetMathLibrary.Ease(num, num2, alpha, this.BlendExp, 2f, 2);
				break;
			case EViewTargetBlendFunction.VTBlend_EaseInOut:
				result = UKismetMathLibrary.Ease(num, num2, alpha, this.BlendExp, 2f, 2);
				break;
			}
			return result;
		}

		// Token: 0x06045FA5 RID: 286629 RVA: 0x0125A9D8 File Offset: 0x01258BD8
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			WidgetCameraBlendComponent widgetCameraBlendComponent = (WidgetCameraBlendComponent)componentTemplate;
			if (base.CanResetComponentProperty("BlendTimeToGo"))
			{
				this.BlendTimeToGo = widgetCameraBlendComponent.BlendTimeToGo;
			}
			if (base.CanResetComponentProperty("BlendTime"))
			{
				this.BlendTime = widgetCameraBlendComponent.BlendTime;
			}
			if (base.CanResetComponentProperty("BlendFunction"))
			{
				this.BlendFunction = widgetCameraBlendComponent.BlendFunction;
			}
			if (base.CanResetComponentProperty("BlendExp"))
			{
				this.BlendExp = widgetCameraBlendComponent.BlendExp;
			}
			if (base.CanResetComponentProperty("TargetLocation") && widgetCameraBlendComponent.TargetLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TargetLocation), "TargetLocation"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("TargetRotation"))
			{
				this.TargetRotation = widgetCameraBlendComponent.TargetRotation;
			}
			if (base.CanResetComponentProperty("BlendLocation"))
			{
				this.BlendLocation = widgetCameraBlendComponent.BlendLocation;
			}
			if (base.CanResetComponentProperty("BlendRotation"))
			{
				this.BlendRotation = widgetCameraBlendComponent.BlendRotation;
			}
			if (base.CanResetComponentProperty("PreBlendRotation"))
			{
				this.PreBlendRotation = widgetCameraBlendComponent.PreBlendRotation;
			}
			if (base.CanResetComponentProperty("PreBlendLocation"))
			{
				this.PreBlendLocation = widgetCameraBlendComponent.PreBlendLocation;
			}
			if (base.CanResetComponentProperty("IsRelativeLocation"))
			{
				this.IsRelativeLocation = widgetCameraBlendComponent.IsRelativeLocation;
			}
			if (base.CanResetComponentProperty("IsRelativeRotation"))
			{
				this.IsRelativeRotation = widgetCameraBlendComponent.IsRelativeRotation;
			}
			if (base.CanResetComponentProperty("<DisplayComponent>k__BackingField"))
			{
				if (widgetCameraBlendComponent.DisplayComponent == null)
				{
					this.DisplayComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<WidgetCameraDisplayComponent>(this.DisplayComponent), "<DisplayComponent>k__BackingField"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x04027383 RID: 160643
		private float BlendTimeToGo;

		// Token: 0x04027384 RID: 160644
		private float BlendTime;

		// Token: 0x04027385 RID: 160645
		private EViewTargetBlendFunction BlendFunction;

		// Token: 0x04027386 RID: 160646
		private EEasingFunc BlendExp;

		// Token: 0x04027387 RID: 160647
		[Nullable(1)]
		private readonly Vector TargetLocation = Vector.Create();

		// Token: 0x04027388 RID: 160648
		private FRotator? TargetRotation;

		// Token: 0x04027389 RID: 160649
		private bool BlendLocation;

		// Token: 0x0402738A RID: 160650
		private bool BlendRotation;

		// Token: 0x0402738B RID: 160651
		private FRotator? PreBlendRotation;

		// Token: 0x0402738C RID: 160652
		private FVectorDouble? PreBlendLocation;

		// Token: 0x0402738D RID: 160653
		private bool IsRelativeLocation;

		// Token: 0x0402738E RID: 160654
		private bool IsRelativeRotation;
	}
}
