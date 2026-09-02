using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F3C RID: 28476
	[NullableContext(2)]
	[Nullable(0)]
	public class NpcPlayMontageAction : GameplayAction
	{
		// Token: 0x06044EEE RID: 282350 RVA: 0x011F1891 File Offset: 0x011EFA91
		[NullableContext(1)]
		public void Init(EntityHandle entityHandle, UAnimMontage montage, bool isLoop, bool needInterrupt = true)
		{
			this.IsLoopInner = isLoop;
			this.EntityHandle = entityHandle;
			this.Montage = montage;
			this.NeedInterrupt = needInterrupt;
		}

		// Token: 0x06044EEF RID: 282351 RVA: 0x011F18B0 File Offset: 0x011EFAB0
		protected override void OnExecuteAction()
		{
			UAnimMontage montage = this.Montage;
			if (montage == null || !montage.IsValid())
			{
				base.FinishExecute();
				return;
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.IsInit)
			{
				base.FinishExecute();
				return;
			}
			BasePerformComponent component = entityHandle.Entity.GetComponent<BasePerformComponent>();
			if (component == null)
			{
				base.FinishExecute();
				return;
			}
			bool isLoopInner = this.IsLoopInner;
			component.PlayPerformMontage(EPerformMode.Action, new IPlayMontageParam
			{
				MontageAsset = montage,
				IsLoop = new bool?(isLoopInner)
			}, null, isLoopInner ? null : new Action<int>(delegate(int _)
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					base.FinishExecute();
				}, null, null);
			}), false);
		}

		// Token: 0x06044EF0 RID: 282352 RVA: 0x011F1940 File Offset: 0x011EFB40
		protected override void OnInterruptAction()
		{
			if (!this.NeedInterrupt)
			{
				return;
			}
			UAnimMontage montage = this.Montage;
			if (montage == null || !montage.IsValid())
			{
				return;
			}
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null || !entityHandle.IsInit)
			{
				return;
			}
			BasePerformComponent component = entityHandle.Entity.GetComponent<BasePerformComponent>();
			if (component == null)
			{
				return;
			}
			component.StopPerformMontage(EPerformMode.Action, new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				Montage = montage,
				BlendOutTime = new float?(0.1f)
			}, null, null);
		}

		// Token: 0x040266F4 RID: 157428
		private EntityHandle EntityHandle;

		// Token: 0x040266F5 RID: 157429
		private UAnimMontage Montage;

		// Token: 0x040266F6 RID: 157430
		private bool NeedInterrupt = true;
	}
}
