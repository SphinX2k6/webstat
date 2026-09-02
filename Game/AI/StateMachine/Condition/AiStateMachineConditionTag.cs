using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x02007103 RID: 28931
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionTag : AiStateMachineCondition
	{
		// Token: 0x060461DE RID: 287198 RVA: 0x0126ADBB File Offset: 0x01268FBB
		public AiStateMachineConditionTag(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x060461DF RID: 287199 RVA: 0x0126ADD4 File Offset: 0x01268FD4
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.TagId = condition.CondTag.TagId;
			this.TagName = condition.CondTag.TagName;
			this.Handle = this.Node.TagComponent.ListenForTagAddOrRemove(new int?(this.TagId), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange), null);
			this.ResultSelf = this.Node.TagComponent.HasTag(this.TagId);
			return true;
		}

		// Token: 0x060461E0 RID: 287200 RVA: 0x0126AE4E File Offset: 0x0126904E
		protected override void OnEnter()
		{
			this.ResultSelf = this.Node.TagComponent.HasTag(this.TagId);
		}

		// Token: 0x060461E1 RID: 287201 RVA: 0x0126AE6C File Offset: 0x0126906C
		private void OnTagChange(int tagId, bool tagExists)
		{
			this.ResultSelf = tagExists;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionTag", this.Node.Name);
			}
		}

		// Token: 0x060461E2 RID: 287202 RVA: 0x0126AEBA File Offset: 0x012690BA
		protected override void OnClear()
		{
			this.Handle.EndTask();
			this.Handle = null;
		}

		// Token: 0x060461E3 RID: 287203 RVA: 0x0126AED0 File Offset: 0x012690D0
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("Tag[");
			appendInterpolatedStringHandler.AppendFormatted(this.TagName);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0402753F RID: 161087
		public string TagName = "";

		// Token: 0x04027540 RID: 161088
		public int TagId;

		// Token: 0x04027541 RID: 161089
		[Nullable(2)]
		private ITagTask Handle;
	}
}
