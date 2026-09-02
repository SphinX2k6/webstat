using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.State
{
	// Token: 0x020070EC RID: 28908
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineStateMeshVisible : AiStateMachineState
	{
		// Token: 0x06046140 RID: 287040 RVA: 0x01267F0C File Offset: 0x0126610C
		public AiStateMachineStateMeshVisible(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.State state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x06046141 RID: 287041 RVA: 0x01267F16 File Offset: 0x01266116
		protected override bool OnInit(CombatStateMachineDefine.Fsm.State state)
		{
			this.Tag = new FName?(new FName(state.BindMeshVisible.Tag));
			this.Visible = state.BindMeshVisible.Visible;
			this.PropagateToChildren = state.BindMeshVisible.PropagateToChildren;
			return true;
		}

		// Token: 0x06046142 RID: 287042 RVA: 0x01267F58 File Offset: 0x01266158
		private void InitMeshComponentsCache()
		{
			if (this.MeshComponentsCache == null)
			{
				TArray<UActorComponent> componentsByTag = this.Node.ActorComponent.Actor.GetComponentsByTag(USkeletalMeshComponent.StaticClass(), this.Tag.Value);
				this.MeshComponentsCache = new List<USkeletalMeshComponent>();
				foreach (UActorComponent uactorComponent in componentsByTag)
				{
					this.MeshComponentsCache.Add(uactorComponent as USkeletalMeshComponent);
				}
			}
		}

		// Token: 0x06046143 RID: 287043 RVA: 0x01267FE8 File Offset: 0x012661E8
		[NullableContext(2)]
		public override void OnActivate(AiStateMachineBase lastState = null, long? contextId = null)
		{
			this.InitMeshComponentsCache();
			if (this.MeshComponentsCache != null)
			{
				foreach (USkeletalMeshComponent uskeletalMeshComponent in this.MeshComponentsCache)
				{
					uskeletalMeshComponent.SetHiddenInGame(!this.Visible, this.PropagateToChildren);
				}
			}
		}

		// Token: 0x06046144 RID: 287044 RVA: 0x01268058 File Offset: 0x01266258
		[NullableContext(2)]
		public override void OnDeactivate(AiStateMachineBase nextState = null, long? contextId = null)
		{
			if (this.Node.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				return;
			}
			this.InitMeshComponentsCache();
			if (this.MeshComponentsCache != null)
			{
				foreach (USkeletalMeshComponent uskeletalMeshComponent in this.MeshComponentsCache)
				{
					uskeletalMeshComponent.SetHiddenInGame(this.Visible, this.PropagateToChildren);
				}
			}
		}

		// Token: 0x06046145 RID: 287045 RVA: 0x012680E4 File Offset: 0x012662E4
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027508 RID: 161032
		public FName? Tag;

		// Token: 0x04027509 RID: 161033
		public bool Visible;

		// Token: 0x0402750A RID: 161034
		public bool PropagateToChildren;

		// Token: 0x0402750B RID: 161035
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<USkeletalMeshComponent> MeshComponentsCache;
	}
}
