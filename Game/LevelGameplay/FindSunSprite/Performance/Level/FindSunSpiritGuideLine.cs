using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine;
using CSharpScript.Game.Effect;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.Level
{
	// Token: 0x02006EBB RID: 28347
	[NullableContext(1)]
	[Nullable(0)]
	public class FindSunSpiritGuideLine
	{
		// Token: 0x06044B86 RID: 281478 RVA: 0x011DD6D4 File Offset: 0x011DB8D4
		public void Init(Transform transform)
		{
			AActor splineActor = this.SplineActor;
			if (splineActor != null && splineActor.IsValid())
			{
				AActor splineActor2 = this.SplineActor;
				FTransformDouble ftransformDouble = transform.ToUeTransform();
				splineActor2.D_K2_SetActorTransform(ftransformDouble, false, null, true);
				return;
			}
			AActor aactor = Singleton<ActorSystem>.Instance.Get(BP_BasePathLine_C.StaticClass(), transform.ToUeTransform(), null, true);
			this.SplineActor = aactor;
			USplineComponent usplineComponent = aactor.GetComponentByClass(USplineComponent.StaticClass()) as USplineComponent;
			usplineComponent.ClearSplinePoints(true);
			this.SplineComp = usplineComponent;
			this.SplinePoints = new TArray<FVectorDouble>();
		}

		// Token: 0x06044B87 RID: 281479 RVA: 0x011DD75C File Offset: 0x011DB95C
		public void Clear()
		{
			this.SplineComp = null;
			this.SplinePoints = null;
			TimerHandle stopEffectTimer = this.StopEffectTimer;
			if (stopEffectTimer != null)
			{
				stopEffectTimer.Remove();
			}
			this.StopEffectTimer = null;
			int effectHandle = this.EffectHandle;
			if (!Singleton<EffectSystem>.Instance.IsValid(effectHandle))
			{
				this.<Clear>g__clearSplineActor|7_0(0);
				return;
			}
			Singleton<EffectSystem>.Instance.AddFinishCallback(effectHandle, new Action<int>(this.<Clear>g__clearSplineActor|7_0));
			Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[FindSunSpiritGuideLine.Clear]", false, null);
		}

		// Token: 0x06044B88 RID: 281480 RVA: 0x011DD7E0 File Offset: 0x011DB9E0
		public void SpawnGuideLine(string effectPath, Vector[] path, int duration)
		{
			AActor splineActor = this.SplineActor;
			if (splineActor == null || !splineActor.IsValid())
			{
				return;
			}
			if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				if (effectPath == this.EffectPath)
				{
					this.UpdateSplinePoint(path);
					TimerHandle stopEffectTimer = this.StopEffectTimer;
					if (stopEffectTimer != null)
					{
						stopEffectTimer.Remove();
					}
					this.StopEffectTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.StopEffect), (float)duration, null, null, true, 1f);
					return;
				}
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[FindSunSpiritGuideLine.Clear]", false, null);
			}
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
			int num = instance.SpawnEffect(world, ftransformDouble, effectPath, "[FindSunSpiritGuideLine.SpawnGuideLine]", new EffectContext(null, this.SplineActor, false), EEffectType.Scene, null, null, null, false, false);
			if (!Singleton<EffectSystem>.Instance.IsValid(num))
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelPlay, ELogAuthor.LYY, "虚影找日灵SpawnGuideLine失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.EffectHandle = num;
			this.EffectPath = effectPath;
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(num);
			AActor splineActor2 = this.SplineActor;
			FName? fname = null;
			effectActor.K2_AttachToActor(splineActor2, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false);
			this.UpdateSplinePoint(path);
			this.StopEffectTimer = TimerSystem.GameplayTimeInstance.Delay(new TTimerAction(this.StopEffect), (float)duration, null, null, true, 1f);
		}

		// Token: 0x06044B89 RID: 281481 RVA: 0x011DD954 File Offset: 0x011DBB54
		private void UpdateSplinePoint(Vector[] path)
		{
			this.SplinePoints.Empty(true);
			foreach (Vector vector in path)
			{
				this.SplinePoints.Add(vector.ToUeVector(false));
			}
			this.SplineComp.D_SetSplinePoints(this.SplinePoints, ESplineCoordinateSpace.World, true);
		}

		// Token: 0x06044B8A RID: 281482 RVA: 0x011DD9A8 File Offset: 0x011DBBA8
		private void StopEffect(float _)
		{
			this.StopEffectTimer = null;
			if (Singleton<EffectSystem>.Instance.IsValid(this.EffectHandle))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.EffectHandle, "[FindSunSpiritGuideLine.Clear]", false, null);
			}
		}

		// Token: 0x06044B8C RID: 281484 RVA: 0x011DDA01 File Offset: 0x011DBC01
		[CompilerGenerated]
		private void <Clear>g__clearSplineActor|7_0(int _)
		{
			AActor splineActor = this.SplineActor;
			if (splineActor != null && splineActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("FindSunSpiritGuideLine.Clear", this.SplineActor, null);
				this.SplineActor = null;
			}
		}

		// Token: 0x0402642F RID: 156719
		[Nullable(2)]
		private AActor SplineActor;

		// Token: 0x04026430 RID: 156720
		[Nullable(2)]
		private USplineComponent SplineComp;

		// Token: 0x04026431 RID: 156721
		[Nullable(2)]
		private TArray<FVectorDouble> SplinePoints;

		// Token: 0x04026432 RID: 156722
		private string EffectPath = "";

		// Token: 0x04026433 RID: 156723
		private int EffectHandle;

		// Token: 0x04026434 RID: 156724
		[Nullable(2)]
		private TimerHandle StopEffectTimer;
	}
}
