using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F3D RID: 28477
	[NullableContext(2)]
	[Nullable(0)]
	public class NpcStopMontageAction : GameplayAction
	{
		// Token: 0x06044EF4 RID: 282356 RVA: 0x011F19F0 File Offset: 0x011EFBF0
		[NullableContext(1)]
		public void Init(EntityHandle entityHandle, UAnimMontage montage, float blendOutTime = 0.1f)
		{
			this.EntityHandle = entityHandle;
			this.Montage = montage;
			this.BlendOutTime = blendOutTime;
		}

		// Token: 0x06044EF5 RID: 282357 RVA: 0x011F1A08 File Offset: 0x011EFC08
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
			component.StopPerformMontage(EPerformMode.Action, new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendOut),
				Montage = montage,
				BlendOutTime = new float?(this.BlendOutTime)
			}, null, null);
		}

		// Token: 0x06044EF6 RID: 282358 RVA: 0x011F1A90 File Offset: 0x011EFC90
		protected override void OnInterruptAction()
		{
		}

		// Token: 0x040266F7 RID: 157431
		private EntityHandle EntityHandle;

		// Token: 0x040266F8 RID: 157432
		private UAnimMontage Montage;

		// Token: 0x040266F9 RID: 157433
		private float BlendOutTime;
	}
}
