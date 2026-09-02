using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform
{
	// Token: 0x02006AB2 RID: 27314
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritEffectPerform : SunSpiritBasePerform, ISunSpiritScenePerform
	{
		// Token: 0x06043890 RID: 276624 RVA: 0x01169620 File Offset: 0x01167820
		public SunSpiritEffectPerform(SunSpiritData sunSpiritData, Transform initTransform) : base(sunSpiritData)
		{
			this.InitTransform.Set(initTransform.GetLocation(), initTransform.GetRotation(), initTransform.GetScale3D());
		}

		// Token: 0x06043891 RID: 276625 RVA: 0x0116965C File Offset: 0x0116785C
		protected override bool OnInit()
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			this.EffectPath = ((instance != null) ? instance.GetSunSpiritConfig().FlyingEffectDaPath : null);
			return this.GenerateSunSpiritEffectOwner(this.InitTransform) && this.GenerateSunSpiritEffect();
		}

		// Token: 0x06043892 RID: 276626 RVA: 0x01169690 File Offset: 0x01167890
		protected override void OnDestroy()
		{
			this.DestroySunSpiritEffect("SunSpiritEffectPerform.OnDestroy");
			this.DestroySunSpiritEffectOwner("SunSpiritEffectPerform.OnDestroy");
		}

		// Token: 0x06043893 RID: 276627 RVA: 0x011696A8 File Offset: 0x011678A8
		public bool GetTransform(Transform outTransform)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner == null || !effectOwner.IsValid())
			{
				return false;
			}
			FTransformDouble ftransformDouble = this.EffectOwner.D_GetTransform();
			outTransform.FromUeTransform(ftransformDouble);
			return true;
		}

		// Token: 0x06043894 RID: 276628 RVA: 0x011696E4 File Offset: 0x011678E4
		[NullableContext(2)]
		public bool GetTransformData(Vector outLocation = null, object outRotation = null, Vector outScale = null)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner == null || !effectOwner.IsValid())
			{
				return false;
			}
			if (outLocation != null)
			{
				FVectorDouble fvectorDouble = this.EffectOwner.D_K2_GetActorLocation();
				outLocation.FromUeVector(fvectorDouble);
			}
			Quat quat = outRotation as Quat;
			if (quat != null)
			{
				quat.FromUeQuat(this.EffectOwner.K2_GetActorQuaternion());
			}
			else
			{
				Rotator rotator = outRotation as Rotator;
				if (rotator != null)
				{
					Rotator rotator2 = rotator;
					FRotator frotator = this.EffectOwner.K2_GetActorRotation();
					rotator2.FromUeRotator(frotator);
				}
			}
			if (outScale != null)
			{
				FVectorDouble fvectorDouble = this.EffectOwner.D_GetActorScale3D();
				outScale.FromUeVector(fvectorDouble);
			}
			return true;
		}

		// Token: 0x06043895 RID: 276629 RVA: 0x01169774 File Offset: 0x01167974
		public bool SetTransform(Transform inTransform)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner == null || !effectOwner.IsValid())
			{
				return false;
			}
			AActor effectOwner2 = this.EffectOwner;
			FTransformDouble ftransformDouble = inTransform.ToUeTransform();
			effectOwner2.D_K2_SetActorTransform(ftransformDouble, false, null, true);
			return true;
		}

		// Token: 0x06043896 RID: 276630 RVA: 0x011697B4 File Offset: 0x011679B4
		[NullableContext(2)]
		public bool SetTransformData(Vector inLocation = null, object inRotation = null, Vector inScale = null)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner == null || !effectOwner.IsValid())
			{
				return false;
			}
			if (inLocation != null && inRotation != null && inScale != null)
			{
				Transform tempTransform = this.TempTransform;
				Quat quat = inRotation as Quat;
				tempTransform.Set(inLocation, (quat != null) ? quat : ((Rotator)inRotation).Quaternion(Singleton<MathUtils>.Instance.CommonTempQuat), inScale);
				AActor effectOwner2 = this.EffectOwner;
				FTransformDouble ftransformDouble = this.TempTransform.ToUeTransform();
				effectOwner2.D_K2_SetActorTransform(ftransformDouble, false, null, true);
			}
			else if (inLocation != null && inRotation != null)
			{
				AActor effectOwner3 = this.EffectOwner;
				FVectorDouble newLocation = inLocation.ToUeVector(false);
				Quat quat2 = inRotation as Quat;
				effectOwner3.D_K2_SetActorLocationAndRotation(newLocation, (quat2 != null) ? quat2.Rotator(Singleton<MathUtils>.Instance.CommonTempRotator).ToUeRotator() : ((Rotator)inRotation).ToUeRotator(), false, ref WorldGlobal.SweepHitResult, true);
			}
			else
			{
				if (inLocation != null)
				{
					this.EffectOwner.D_K2_SetActorLocation(inLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, true);
				}
				Quat quat3 = inRotation as Quat;
				if (quat3 != null)
				{
					this.EffectOwner.K2_SetActorRotation(quat3.Rotator(Singleton<MathUtils>.Instance.CommonTempRotator).ToUeRotator(), false);
				}
				else
				{
					Rotator rotator = inRotation as Rotator;
					if (rotator != null)
					{
						this.EffectOwner.K2_SetActorRotation(rotator.ToUeRotator(), false);
					}
				}
				if (inScale != null)
				{
					this.EffectOwner.D_SetActorScale3D(inScale.ToUeVector(false));
				}
			}
			return true;
		}

		// Token: 0x06043897 RID: 276631 RVA: 0x01169908 File Offset: 0x01167B08
		[NullableContext(2)]
		private bool GenerateSunSpiritEffectOwner(Transform transform = null)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner != null && effectOwner.IsValid())
			{
				return true;
			}
			AActor aactor = Singleton<ActorSystem>.Instance.Get(AActor.StaticClass(), (transform != null) ? transform.ToUeTransform() : FTransformDouble.Identity, null, true);
			if (aactor == null)
			{
				return false;
			}
			if (aactor.GetComponentByClass(USceneComponent.StaticClass()) == null)
			{
				aactor.AddComponentByClass(USceneComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName));
			}
			if (transform != null)
			{
				AActor actor = aactor;
				FTransformDouble ftransformDouble = transform.ToUeTransform();
				actor.D_K2_SetActorTransform(ftransformDouble, false, null, true);
			}
			this.EffectOwner = aactor;
			return true;
		}

		// Token: 0x06043898 RID: 276632 RVA: 0x011699A8 File Offset: 0x01167BA8
		private void DestroySunSpiritEffectOwner(string reason)
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner != null && effectOwner.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put(reason, this.EffectOwner, null);
			}
			this.EffectOwner = null;
		}

		// Token: 0x06043899 RID: 276633 RVA: 0x011699D8 File Offset: 0x01167BD8
		private bool GenerateSunSpiritEffect()
		{
			AActor effectOwner = this.EffectOwner;
			if (effectOwner == null || !effectOwner.IsValid())
			{
				return false;
			}
			if (this.EffectPath == null || this.EffectPath.Length <= 0)
			{
				return false;
			}
			if (this.FlyingEffectHandle == 0 || !Singleton<EffectSystem>.Instance.IsValid(this.FlyingEffectHandle))
			{
				EffectSystem instance = Singleton<EffectSystem>.Instance;
				UObject world = GlobalData.World;
				FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
				this.FlyingEffectHandle = instance.SpawnEffect(world, ftransformDouble, this.EffectPath, "SunSpiritEffectPerform", new EffectContext(null, this.EffectOwner, false), EEffectType.Scene, null, null, null, false, false);
			}
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.FlyingEffectHandle);
			if (!effectActor.HasValue)
			{
				return false;
			}
			OneOf<KuroEffectActorHandle, AActor> self = effectActor;
			AActor effectOwner2 = this.EffectOwner;
			FName? fname = null;
			self.K2_AttachToActor(effectOwner2, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
			return true;
		}

		// Token: 0x0604389A RID: 276634 RVA: 0x01169AB4 File Offset: 0x01167CB4
		private void DestroySunSpiritEffect(string reason)
		{
			if (this.FlyingEffectHandle != 0 && Singleton<EffectSystem>.Instance.IsValid(this.FlyingEffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.FlyingEffectHandle, reason, false, null);
			}
			this.FlyingEffectHandle = 0;
		}

		// Token: 0x04025BAE RID: 154542
		[Nullable(2)]
		private AActor EffectOwner;

		// Token: 0x04025BAF RID: 154543
		private int FlyingEffectHandle;

		// Token: 0x04025BB0 RID: 154544
		[Nullable(2)]
		private string EffectPath;

		// Token: 0x04025BB1 RID: 154545
		private readonly Transform InitTransform = Transform.Create();

		// Token: 0x04025BB2 RID: 154546
		private readonly Transform TempTransform = Transform.Create();
	}
}
