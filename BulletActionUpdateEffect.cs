using System;
using System.Collections.Generic;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002D95 RID: 11669
public class BulletActionUpdateEffect : BulletActionBase
{
	// Token: 0x0601786D RID: 96365 RVA: 0x0068A8B0 File Offset: 0x00688AB0
	public BulletActionUpdateEffect(EBulletAction type) : base(type)
	{
	}

	// Token: 0x0601786E RID: 96366 RVA: 0x0068A8BC File Offset: 0x00688ABC
	protected override void OnExecute()
	{
		BulletEffectInfo effectInfo = this.BulletInfo.EffectInfo;
		BulletDataMain bulletDataMain = this.BulletInfo.BulletDataMain;
		effectInfo.EffectData = bulletDataMain.Render;
		effectInfo.IsFinishAuto = effectInfo.EffectData.EffectStopInsteadDestroy;
		Dictionary<EBulletSpecificEffect, FName> specialEffect = effectInfo.EffectData.SpecialEffect;
		effectInfo.DisablePostProcess = !CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.BulletInfo.AttackerHandle);
		this.SpawnBulletEffectOnBegin();
		if (bulletDataMain.Base.Shape == EBulletShape.Ray)
		{
			string s;
			float num = effectInfo.EffectData.EffectBulletParams.TryGetValue(1, out s) ? float.Parse(s) : 1f;
			effectInfo.EffectOriginSize = 1f / (float.IsNaN(num) ? 1f : num);
			FName a;
			if (specialEffect.TryGetValue(EBulletSpecificEffect.激光末端, out a) && a != FName.NAME_None)
			{
				effectInfo.EffectExtremity = BulletStaticFunction.PlayBulletEffect(this.BulletInfo.Actor, a.ToString(), this.BulletInfo.ActorComponent.ActorTransform, this.BulletInfo, "[BulletActionUpdateEffect.OnExecute] 1");
				Singleton<EffectSystem>.Instance.SetEffectHidden(effectInfo.EffectExtremity, true, null, false);
			}
			if (specialEffect.TryGetValue(EBulletSpecificEffect.激光阻碍, out a) && a != FName.NAME_None)
			{
				AActor actor = this.BulletInfo.Actor;
				effectInfo.EffectBlock = BulletStaticFunction.PlayBulletEffect(actor, a.ToString(), actor.D_GetTransform(), this.BulletInfo, "[BulletActionUpdateEffect.OnExecute] 2");
				Singleton<EffectSystem>.Instance.SetEffectHidden(effectInfo.EffectBlock, true, null, false);
				return;
			}
		}
		else
		{
			this.IsFinish = true;
		}
	}

	// Token: 0x0601786F RID: 96367 RVA: 0x0068AA54 File Offset: 0x00688C54
	private void SpawnBulletEffectOnBegin()
	{
		BulletActorComponent actorComponent = this.BulletInfo.ActorComponent;
		if (actorComponent == null)
		{
			return;
		}
		if (this.BulletInfo.BulletDataMain.Render.HandOverParentEffect)
		{
			BulletStaticFunction.HandOverEffectsAfterInitTransform(this.BulletInfo);
			return;
		}
		BulletEffectInfo effectInfo = this.BulletInfo.EffectInfo;
		BulletDataRender effectData = effectInfo.EffectData;
		if (effectData.EffectBullet == FName.NAME_None)
		{
			return;
		}
		Rotator rotator = BulletPool.CreateRotator(false);
		if (this.BulletInfo.IsCollisionRelativeRotationModify)
		{
			Singleton<MathUtils>.Instance.ComposeRotator(Singleton<BulletConstant>.Instance.RotateToRight, this.BulletInfo.BulletDataMain.Base.Rotator, rotator);
		}
		else
		{
			rotator.FromUeRotator(Singleton<BulletConstant>.Instance.RotateToRight);
		}
		FTransformDouble actorTransform = actorComponent.ActorTransform;
		FRotator frotator = UKismetMathLibrary.D_TransformRotation(actorTransform, rotator.ToUeRotator());
		FVectorDouble fvectorDouble = actorComponent.ActorLocation;
		FVectorDouble actorScale = actorComponent.ActorScale;
		FVector fvector = actorScale;
		FTransformDouble transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		BulletPool.RecycleRotator(rotator);
		effectInfo.Effect = BulletStaticFunction.PlayBulletEffect(actorComponent.Owner, effectData.EffectBullet.ToString(), transform, this.BulletInfo, "[BulletActionUpdateEffect.SpawnBulletEffectOnBegin]");
		if (Singleton<EffectSystem>.Instance.IsValid(effectInfo.Effect))
		{
			string s;
			if (this.BulletInfo.BulletDataMain.Render.EffectBulletParams.TryGetValue(5, out s))
			{
				int niagaraQualityLevel = BulletStaticFunction.GetNiagaraQualityLevel((double)int.Parse(s));
				Singleton<EffectSystem>.Instance.SetEffectQualityLevel(effectInfo.Effect, niagaraQualityLevel);
			}
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.Effect);
			if (effectActor.HasValue)
			{
				OneOf<KuroEffectActorHandle, AActor> self = effectActor;
				AActor owner = actorComponent.Owner;
				FName? fname = new FName?(FNameUtil.NONE);
				self.K2_AttachToActor(owner, fname, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true);
				string text;
				if (effectData.EffectBulletParams.TryGetValue(3, out text))
				{
					string[] array = text.Split(',', StringSplitOptions.None);
					int num = array.Length;
					float inPitch = (num > 1) ? float.Parse(array[1]) : 0f;
					float inYaw = (num > 2) ? float.Parse(array[2]) : 0f;
					float inRoll = (num > 0) ? float.Parse(array[0]) : 0f;
					Rotator rotator2 = BulletPool.CreateRotator(false);
					rotator2.Set(inPitch, inYaw, inRoll);
					OneOf<KuroEffectActorHandle, AActor> self2 = effectActor;
					frotator = rotator2.ToUeRotator();
					self2.K2_SetActorRelativeRotation(frotator, false, ref WorldGlobal.SweepHitResult, true);
					BulletPool.RecycleRotator(rotator2);
				}
				if (effectData.EffectBulletParams.TryGetValue(2, out text))
				{
					string[] array2 = text.Split(',', StringSplitOptions.None);
					int num2 = array2.Length;
					float num3 = (num2 > 0) ? float.Parse(array2[0]) : 0f;
					float num4 = (num2 > 1) ? float.Parse(array2[1]) : 0f;
					float num5 = (num2 > 2) ? float.Parse(array2[2]) : 0f;
					Vector vector = BulletPool.CreateVector(false);
					vector.Set((double)num3, (double)num4, (double)num5);
					OneOf<KuroEffectActorHandle, AActor> self3 = effectActor;
					fvectorDouble = vector.ToUeVector(false);
					self3.D_K2_SetActorRelativeLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, true);
					BulletPool.RecycleVector(vector);
				}
				Vector vector2 = BulletPool.CreateVector(true);
				if (effectData.EffectBulletParams.TryGetValue(4, out text))
				{
					string[] array3 = text.Split(',', StringSplitOptions.None);
					int num6 = array3.Length;
					float num7 = (num6 > 1) ? float.Parse(array3[1]) : 0f;
					float num8 = (num6 > 0) ? float.Parse(array3[0]) : 0f;
					float num9 = (num6 > 2) ? float.Parse(array3[2]) : 0f;
					vector2.Set((double)num7, (double)num8, (double)num9);
				}
				BulletAdditionInfo additionInfo = this.BulletInfo.AdditionInfo;
				if (additionInfo != null && additionInfo.Valid && !additionInfo.SizeScale.IsZero())
				{
					if (vector2.IsZero())
					{
						vector2.FromUeVector(additionInfo.SizeScale);
					}
					else
					{
						vector2.MultiplyEqual(additionInfo.SizeScale);
					}
				}
				if (!vector2.IsZero())
				{
					OneOf<KuroEffectActorHandle, AActor> self4 = effectActor;
					fvectorDouble = vector2.ToUeVector(false);
					self4.D_SetActorScale3D(fvectorDouble);
				}
				BulletPool.RecycleVector(vector2);
			}
		}
	}

	// Token: 0x06017870 RID: 96368 RVA: 0x0068AE34 File Offset: 0x00689034
	protected override void OnTick(float delta)
	{
		if (this.BulletInfo.NeedDestroy)
		{
			return;
		}
		BulletEffectInfo effectInfo = this.BulletInfo.EffectInfo;
		Vector vector = BulletPool.CreateVector(false);
		vector.X = 1.0;
		vector.Y = this.BulletInfo.RayInfo.Length * (double)effectInfo.EffectOriginSize;
		vector.Z = 1.0;
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.Effect);
		FVectorDouble fvectorDouble = vector.ToUeVector(false);
		effectActor.D_SetActorScale3D(fvectorDouble);
		BulletPool.RecycleVector(vector);
		Singleton<EffectSystem>.Instance.SetEffectHidden(effectInfo.EffectExtremity, this.BulletInfo.RayInfo.IsBlock, null, false);
		Singleton<EffectSystem>.Instance.SetEffectHidden(effectInfo.EffectBlock, !this.BulletInfo.RayInfo.IsBlock, null, false);
		FRotator actorRotation;
		if (this.BulletInfo.RayInfo.IsBlock)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor2 = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.EffectBlock);
			fvectorDouble = this.BulletInfo.RayInfo.EndPoint.ToUeVector(false);
			effectActor2.D_K2_SetActorLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, true);
			OneOf<KuroEffectActorHandle, AActor> effectActor3 = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.EffectBlock);
			actorRotation = this.BulletInfo.ActorComponent.ActorRotation;
			effectActor3.K2_SetActorRotation(actorRotation, false);
			return;
		}
		OneOf<KuroEffectActorHandle, AActor> effectActor4 = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.EffectExtremity);
		fvectorDouble = this.BulletInfo.RayInfo.EndPoint.ToUeVector(false);
		effectActor4.D_K2_SetActorLocation(fvectorDouble, false, ref WorldGlobal.SweepHitResult, true);
		OneOf<KuroEffectActorHandle, AActor> effectActor5 = Singleton<EffectSystem>.Instance.GetEffectActor(effectInfo.EffectExtremity);
		actorRotation = this.BulletInfo.ActorComponent.ActorRotation;
		effectActor5.K2_SetActorRotation(actorRotation, false);
	}
}
