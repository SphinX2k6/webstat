using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x02004895 RID: 18581
	[NullableContext(1)]
	[Nullable(0)]
	public class BulletCasterBatch : IBulletCaster
	{
		// Token: 0x060306DF RID: 198367 RVA: 0x00BDE800 File Offset: 0x00BDCA00
		public unsafe BulletCasterBatch(Entity ownerEntity, float loopInterval, float delayTime, List<IBatchBulletCaster> casterList, string warmingEffect, long contextMessageId, List<Transform> casterTransformList, EBatchBulletMovementType? movementType)
		{
			this.OwnerEntity = ownerEntity;
			this.LoopInterval = loopInterval;
			this.DelayTime = delayTime;
			foreach (IBatchBulletCaster batchBulletCaster in casterList)
			{
				int index = batchBulletCaster.BulletIndex - 1;
				BulletCasterInitParam bulletCasterInitParam = new BulletCasterInitParam(ownerEntity, batchBulletCaster, casterTransformList[index], contextMessageId, warmingEffect);
				IBulletCaster instance = Singleton<BulletCasterClassFactory>.Instance.GetInstance(movementType.GetValueOrDefault(), bulletCasterInitParam);
				if (instance != null)
				{
					this.BulletCasters.Add(instance);
				}
				else
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "构建批量发射子弹的时候工厂里面没拿出来";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("movementType", movementType);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("bulletCasterInitParam", bulletCasterInitParam);
					instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}

		// Token: 0x060306E0 RID: 198368 RVA: 0x00BDE914 File Offset: 0x00BDCB14
		public void Start()
		{
			if (this.DelayTime < 20f)
			{
				this.StartImmediately();
			}
			else
			{
				this.BatchDelayStartTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.StartImmediately();
				}, this.DelayTime, null, null, true, 1f);
			}
			this.SetTimeDilationRespectOwnerEntity();
		}

		// Token: 0x060306E1 RID: 198369 RVA: 0x00BDE968 File Offset: 0x00BDCB68
		public void Stop()
		{
			foreach (IBulletCaster bulletCaster in this.BulletCasters)
			{
				bulletCaster.Stop();
			}
			TimerHandle batchLoopTimer = this.BatchLoopTimer;
			if (batchLoopTimer != null && batchLoopTimer.Valid())
			{
				this.BatchLoopTimer.Remove();
			}
			this.BatchLoopTimer = null;
			TimerHandle batchDelayStartTimer = this.BatchDelayStartTimer;
			if (batchDelayStartTimer != null && batchDelayStartTimer.Valid())
			{
				this.BatchDelayStartTimer.Remove();
			}
			this.BatchDelayStartTimer = null;
		}

		// Token: 0x060306E2 RID: 198370 RVA: 0x00BDEA08 File Offset: 0x00BDCC08
		public void SetTimeDilationRespectOwnerEntity()
		{
			PawnTimeScaleComponent component = this.OwnerEntity.GetComponent<PawnTimeScaleComponent>();
			float timeDilation = this.OwnerEntity.TimeDilation * ((component != null) ? component.CurrentTimeScale : 1f);
			this.SetTimeDilation(timeDilation);
		}

		// Token: 0x060306E3 RID: 198371 RVA: 0x00BDEA48 File Offset: 0x00BDCC48
		public void SetTimeDilation(float timeDilation)
		{
			TimerHandle batchDelayStartTimer = this.BatchDelayStartTimer;
			if (batchDelayStartTimer != null && batchDelayStartTimer.Valid())
			{
				BulletCasterUtils.SetTimerHandleTimeDilation(this.BatchDelayStartTimer, timeDilation);
			}
			TimerHandle batchLoopTimer = this.BatchLoopTimer;
			if (batchLoopTimer != null && batchLoopTimer.Valid())
			{
				BulletCasterUtils.SetTimerHandleTimeDilation(this.BatchLoopTimer, timeDilation);
			}
			foreach (IBulletCaster bulletCaster in this.BulletCasters)
			{
				bulletCaster.SetTimeDilation(timeDilation);
			}
		}

		// Token: 0x060306E4 RID: 198372 RVA: 0x00BDEADC File Offset: 0x00BDCCDC
		private void StartImmediately()
		{
			if (this.LoopInterval < 20f)
			{
				this.TriggerCasters();
			}
			else
			{
				this.TriggerCasters();
				this.BatchLoopTimer = TimerSystem.Instance.Forever(delegate(float _)
				{
					this.TriggerCasters();
				}, this.LoopInterval, 1f, null, null, true);
			}
			this.SetTimeDilationRespectOwnerEntity();
		}

		// Token: 0x060306E5 RID: 198373 RVA: 0x00BDEB34 File Offset: 0x00BDCD34
		private void TriggerCasters()
		{
			foreach (IBulletCaster bulletCaster in this.BulletCasters)
			{
				bulletCaster.Start();
			}
		}

		// Token: 0x0401BD01 RID: 113921
		public readonly List<IBulletCaster> BulletCasters = new List<IBulletCaster>();

		// Token: 0x0401BD02 RID: 113922
		[Nullable(2)]
		private TimerHandle BatchDelayStartTimer;

		// Token: 0x0401BD03 RID: 113923
		[Nullable(2)]
		private TimerHandle BatchLoopTimer;

		// Token: 0x0401BD04 RID: 113924
		public Entity OwnerEntity;

		// Token: 0x0401BD05 RID: 113925
		public float LoopInterval;

		// Token: 0x0401BD06 RID: 113926
		public float DelayTime;
	}
}
