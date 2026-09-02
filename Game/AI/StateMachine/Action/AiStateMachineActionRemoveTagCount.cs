using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Action
{
	// Token: 0x02007112 RID: 28946
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineActionRemoveTagCount : AiStateMachineAction
	{
		// Token: 0x06046220 RID: 287264 RVA: 0x0126B866 File Offset: 0x01269A66
		public AiStateMachineActionRemoveTagCount(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Action action) : base(stateMachineNode, action)
		{
		}

		// Token: 0x06046221 RID: 287265 RVA: 0x0126B870 File Offset: 0x01269A70
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Action action)
		{
			CombatStateMachineDefine.Fsm.ActionRemoveTagCount actionRemoveTagCount = action.ActionRemoveTagCount;
			this.TagId = ((actionRemoveTagCount != null) ? new int?(actionRemoveTagCount.TagId) : null);
			CombatStateMachineDefine.Fsm.ActionRemoveTagCount actionRemoveTagCount2 = action.ActionRemoveTagCount;
			this.Count = ((actionRemoveTagCount2 != null) ? new int?(actionRemoveTagCount2.Count) : null);
			return true;
		}

		// Token: 0x06046222 RID: 287266 RVA: 0x0126B8C8 File Offset: 0x01269AC8
		public override void DoAction(long? contextId = null)
		{
			BaseTagComponent tagComponent = this.Node.TagComponent;
			if (tagComponent == null || !tagComponent.Valid)
			{
				return;
			}
			if (this.TagId == null || this.Count == null)
			{
				return;
			}
			if (this.Count.GetValueOrDefault() == -1)
			{
				int rawTagCount = tagComponent.TagContainer.GetRawTagCount(ETagChannel.Common, this.TagId.Value);
				tagComponent.TagContainer.UpdateExactTag(ETagChannel.Common, this.TagId.Value, -rawTagCount);
				return;
			}
			int? count = this.Count;
			int num = 0;
			if (count.GetValueOrDefault() > num & count != null)
			{
				tagComponent.TagContainer.UpdateExactTag(ETagChannel.Common, this.TagId.Value, -this.Count.Value);
			}
		}

		// Token: 0x06046223 RID: 287267 RVA: 0x0126B988 File Offset: 0x01269B88
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x04027554 RID: 161108
		public int? TagId;

		// Token: 0x04027555 RID: 161109
		public int? Count;
	}
}
