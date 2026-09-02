using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;

namespace CSharpScript.Game.NewWorld.SceneItem.BulletCaster
{
	// Token: 0x02004896 RID: 18582
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class BulletCasterCommon : BulletCasterBase
	{
		// Token: 0x060306E8 RID: 198376 RVA: 0x00BDEB94 File Offset: 0x00BDCD94
		protected BulletCasterCommon(BulletCasterInitParam bulletCasterInitParam) : base(bulletCasterInitParam)
		{
		}

		// Token: 0x060306E9 RID: 198377 RVA: 0x00BDEBC0 File Offset: 0x00BDCDC0
		protected override void OnStop()
		{
			foreach (TimerHandle timerHandle in this.BulletWaitWarningTimers)
			{
				if (timerHandle.Valid())
				{
					timerHandle.Remove();
				}
			}
			this.BulletWaitWarningTimers.Clear();
			foreach (int num in this.WarningEffectHandles)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(num))
				{
					Singleton<EffectSystem>.Instance.StopEffectById(num, "[BulletCaster] Stop", false, null);
				}
			}
			this.WarningEffectHandles.Clear();
			foreach (KeyValuePair<int, TimerHandle> keyValuePair in this.DestroyBulletTimers)
			{
				int num2;
				TimerHandle timerHandle2;
				keyValuePair.Deconstruct(out num2, out timerHandle2);
				int id = num2;
				TimerHandle timerHandle3 = timerHandle2;
				if (timerHandle3.Valid())
				{
					timerHandle3.Remove();
				}
				ControllerBase<BulletController>.Instance.DestroyBullet(id, true, EBulletDestroyReason.Normal, false);
			}
			this.DestroyBulletTimers.Clear();
		}

		// Token: 0x060306EA RID: 198378 RVA: 0x00BDED10 File Offset: 0x00BDCF10
		protected override void OnSetTimeDilation(float timeDilation)
		{
			foreach (TimerHandle timerHandle in this.BulletWaitWarningTimers)
			{
				if (timerHandle.Valid())
				{
					BulletCasterUtils.SetTimerHandleTimeDilation(timerHandle, timeDilation);
				}
			}
			float num = (this.CasterConfig.WarningTime > 0) ? (1f / ((float)this.CasterConfig.WarningTime * 0.001f)) : 1f;
			foreach (int id in this.WarningEffectHandles)
			{
				if (Singleton<EffectSystem>.Instance.IsValid(id))
				{
					Singleton<EffectSystem>.Instance.SetTimeScale(id, timeDilation * num, false);
				}
			}
			foreach (KeyValuePair<int, TimerHandle> keyValuePair in this.DestroyBulletTimers)
			{
				int num2;
				TimerHandle timerHandle2;
				keyValuePair.Deconstruct(out num2, out timerHandle2);
				int id2 = num2;
				TimerHandle timerHandle3 = timerHandle2;
				BulletModel instance = ModelBase<BulletModel>.Instance;
				BulletEntity bulletEntity = (instance != null) ? instance.GetBulletEntityById(id2) : null;
				if (bulletEntity != null && bulletEntity.Valid)
				{
					bulletEntity.SetTimeDilation(timeDilation);
				}
				if (timerHandle3.Valid())
				{
					BulletCasterUtils.SetTimerHandleTimeDilation(timerHandle3, timeDilation);
				}
			}
		}

		// Token: 0x0401BD07 RID: 113927
		protected readonly HashSet<int> WarningEffectHandles = new HashSet<int>();

		// Token: 0x0401BD08 RID: 113928
		protected readonly HashSet<TimerHandle> BulletWaitWarningTimers = new HashSet<TimerHandle>();

		// Token: 0x0401BD09 RID: 113929
		protected readonly Dictionary<int, TimerHandle> DestroyBulletTimers = new Dictionary<int, TimerHandle>();
	}
}
