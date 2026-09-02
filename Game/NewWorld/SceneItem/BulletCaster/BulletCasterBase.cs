using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x0200489D RID: 18589
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BulletCasterBase : IBulletCaster
	{
		// Token: 0x060306FD RID: 198397 RVA: 0x00BDF69C File Offset: 0x00BDD89C
		public BulletCasterBase(BulletCasterInitParam bulletCasterInitParam)
		{
			this.BulletCasterInitParam = bulletCasterInitParam;
			this.OwnerEntity = bulletCasterInitParam.OwnerEntity;
			this.CasterConfig = bulletCasterInitParam.CasterConfig;
			this.CasterRelTransform = bulletCasterInitParam.CasterRelTransform;
			this.BulletContextId = bulletCasterInitParam.BulletContextId;
			this.WarningEffect = bulletCasterInitParam.WarningEffect;
		}

		// Token: 0x060306FE RID: 198398 RVA: 0x00BDF708 File Offset: 0x00BDD908
		public virtual void Start()
		{
			if ((this.CasterConfig.DelayTime ?? 0) != 0)
			{
				int? delayTime = this.CasterConfig.DelayTime;
				int num = 20;
				if (!(delayTime.GetValueOrDefault() <= num & delayTime != null))
				{
					TimerHandle timerHandle = TimerSystem.Instance.Delay(delegate(float _)
					{
						this.CasterWaitStartTimers.RemoveAt(this.CasterWaitStartTimers.Count - 1);
						this.StartImmediately();
					}, (float)this.CasterConfig.DelayTime.Value, null, null, true, 1f);
					if (timerHandle != null)
					{
						this.CasterWaitStartTimers.Add(timerHandle);
						goto IL_9A;
					}
					goto IL_9A;
				}
			}
			this.StartImmediately();
			IL_9A:
			this.SetTimeDilationRespectOwnerEntity();
			this.OnStart();
		}

		// Token: 0x060306FF RID: 198399
		protected abstract void OnStart();

		// Token: 0x06030700 RID: 198400 RVA: 0x00BDF7BC File Offset: 0x00BDD9BC
		public virtual void Stop()
		{
			foreach (TimerHandle timerHandle in this.CasterWaitStartTimers)
			{
				if (timerHandle.Valid())
				{
					timerHandle.Remove();
				}
			}
			this.CasterWaitStartTimers.Clear();
			this.OnStop();
		}

		// Token: 0x06030701 RID: 198401
		protected abstract void OnStop();

		// Token: 0x06030702 RID: 198402 RVA: 0x00BDF828 File Offset: 0x00BDDA28
		public virtual void SetTimeDilationRespectOwnerEntity()
		{
			PawnTimeScaleComponent component = this.OwnerEntity.GetComponent<PawnTimeScaleComponent>();
			float timeDilation = this.OwnerEntity.TimeDilation * ((component != null) ? component.CurrentTimeScale : 1f);
			this.SetTimeDilation(timeDilation);
		}

		// Token: 0x06030703 RID: 198403 RVA: 0x00BDF868 File Offset: 0x00BDDA68
		public virtual void SetTimeDilation(float timeDilation)
		{
			foreach (TimerHandle timerHandle in this.CasterWaitStartTimers)
			{
				if (timerHandle.Valid())
				{
					BulletCasterUtils.SetTimerHandleTimeDilation(timerHandle, timeDilation);
				}
			}
			this.OnSetTimeDilation(timeDilation);
		}

		// Token: 0x06030704 RID: 198404
		protected abstract void OnSetTimeDilation(float timeDilation);

		// Token: 0x06030705 RID: 198405
		protected abstract void StartImmediately();

		// Token: 0x06030706 RID: 198406 RVA: 0x00BDF8CC File Offset: 0x00BDDACC
		protected int PlayWarningEffect()
		{
			if (this.WarningEffect.Length == 0)
			{
				return 0;
			}
			FTransformDouble actorTransform = this.OwnerEntity.GetComponent<BaseActorComponent>().ActorTransform;
			FTransformDouble ftransformDouble = this.CasterRelTransform.ToUeTransform();
			FTransformDouble value = ftransformDouble * actorTransform;
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble2 = new FTransformDouble?(value);
			int num = instance.SpawnEffect(world, ftransformDouble2, this.WarningEffect, "[BatchBulletCasterComponent] PlayWarningEffect", new EffectContext(new int?(this.OwnerEntity.Id), null, false), EEffectType.Scene, null, null, null, false, false);
			this.SetEffectParam(num);
			return num;
		}

		// Token: 0x06030707 RID: 198407
		protected abstract void SetEffectParam(int effectHandleId);

		// Token: 0x0401BD13 RID: 113939
		[Nullable(2)]
		public Entity OwnerEntity;

		// Token: 0x0401BD14 RID: 113940
		[Nullable(2)]
		public IBatchBulletCaster CasterConfig;

		// Token: 0x0401BD15 RID: 113941
		[Nullable(2)]
		public Transform CasterRelTransform;

		// Token: 0x0401BD16 RID: 113942
		public long BulletContextId;

		// Token: 0x0401BD17 RID: 113943
		public string WarningEffect = "";

		// Token: 0x0401BD18 RID: 113944
		private readonly List<TimerHandle> CasterWaitStartTimers = new List<TimerHandle>();

		// Token: 0x0401BD19 RID: 113945
		protected BulletCasterInitParam BulletCasterInitParam;
	}
}
