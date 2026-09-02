using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x0200710A RID: 28938
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionAddTagCount : AiStateMachineAction
	{
		// Token: 0x06046205 RID: 287237 RVA: 0x0126B349 File Offset: 0x01269549
		public AiStateMachineActionAddTagCount(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046206 RID: 287238 RVA: 0x0126B354 File Offset: 0x01269554
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			CombatStateMachineDefine.Fsm.ActionAddTagCount actionAddTagCount = action.ActionAddTagCount;
			this.TagId = ((actionAddTagCount != null) ? new int?(actionAddTagCount.TagId) : null);
			CombatStateMachineDefine.Fsm.ActionAddTagCount actionAddTagCount2 = action.ActionAddTagCount;
			this.Count = ((actionAddTagCount2 != null) ? new int?(actionAddTagCount2.Count) : null);
			return true;
		}

		// Token: 0x06046207 RID: 287239 RVA: 0x0126B3AC File Offset: 0x012695AC
		public override void DoAction(long? contextId = null)
		{
			BaseTagComponent tagComponent = this.Node.TagComponent;
			if (tagComponent == null || !tagComponent.Valid)
			{
				return;
			}
			if (this.TagId != null && this.Count != null)
			{
				int? count = this.Count;
				int num = 0;
				if (!(count.GetValueOrDefault() <= num & count != null))
				{
					tagComponent.TagContainer.UpdateExactTag(ETagChannel.Common, this.TagId.Value, this.Count.Value);
					return;
				}
			}
		}

		// Token: 0x06046208 RID: 287240 RVA: 0x0126B42E File Offset: 0x0126962E
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x0402754A RID: 161098
		public int? TagId;

		// Token: 0x0402754B RID: 161099
		public int? Count;
	}
}
