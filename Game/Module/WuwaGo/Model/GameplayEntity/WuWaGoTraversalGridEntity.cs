using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AF0 RID: 19184
	public class WuWaGoTraversalGridEntity : WuWaGoGameplayEntityBase
	{
		// Token: 0x0603203F RID: 204863 RVA: 0x00C83F23 File Offset: 0x00C82123
		[NullableContext(1)]
		public WuWaGoTraversalGridEntity(EWuWaGoEntityType entityType, int pbDataId, Vector coordinate, Rotator rotator) : base(entityType, pbDataId, coordinate, rotator)
		{
		}

		// Token: 0x17008566 RID: 34150
		// (get) Token: 0x06032040 RID: 204864 RVA: 0x00C83F30 File Offset: 0x00C82130
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<IWuWaGoHintStepBase> HintSteps
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return this.HintStepsInner;
			}
		}

		// Token: 0x06032041 RID: 204865 RVA: 0x00C83F38 File Offset: 0x00C82138
		public void SetHintSteps([Nullable(new byte[]
		{
			2,
			1
		})] IReadOnlyList<IWuWaGoHintStepBase> steps)
		{
			this.HintStepsInner = steps;
		}

		// Token: 0x06032042 RID: 204866 RVA: 0x00C83F44 File Offset: 0x00C82144
		public override void Unlock()
		{
			EGameplayEntityState state = (this.EntityType == EWuWaGoEntityType.StartGrid) ? EGameplayEntityState.Activated : EGameplayEntityState.Normal;
			this.SetState(state);
		}

		// Token: 0x06032043 RID: 204867 RVA: 0x00C83F68 File Offset: 0x00C82168
		public override void RestoreInitialStateForGameOver()
		{
			this.SetState(EGameplayEntityState.Locked);
		}

		// Token: 0x06032044 RID: 204868 RVA: 0x00C83F72 File Offset: 0x00C82172
		protected override void OnStateChanged(EGameplayEntityState newState)
		{
			base.SwitchSceneItemStateByGameplayEntityState(newState, true, false);
		}

		// Token: 0x0401D40B RID: 119819
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private IReadOnlyList<IWuWaGoHintStepBase> HintStepsInner;
	}
}
