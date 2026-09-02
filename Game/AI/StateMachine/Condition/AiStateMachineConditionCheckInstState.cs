using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F7 RID: 28919
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionCheckInstState : AiStateMachineCondition
	{
		// Token: 0x0604618B RID: 287115 RVA: 0x01269479 File Offset: 0x01267679
		public AiStateMachineConditionCheckInstState(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x0604618C RID: 287116 RVA: 0x01269490 File Offset: 0x01267690
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.TagId = condition.CondInstStateChange.TagId;
			this.TagName = GameplayTagUtils.GetNameByTagId(this.TagId);
			this.Handle = this.Node.TagComponent.ListenForTagAddOrRemove(new int?(this.TagId), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange), null);
			this.ResultSelf = this.Node.TagComponent.HasTag(this.TagId);
			return true;
		}

		// Token: 0x0604618D RID: 287117 RVA: 0x0126950C File Offset: 0x0126770C
		private void OnTagChange(int tagId, bool tagExists)
		{
			this.ResultSelf = tagExists;
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionCheckInstState", this.Node.Name);
			}
		}

		// Token: 0x0604618E RID: 287118 RVA: 0x0126955A File Offset: 0x0126775A
		protected override void OnClear()
		{
			this.Handle.EndTask();
			this.Handle = null;
		}

		// Token: 0x0604618F RID: 287119 RVA: 0x01269570 File Offset: 0x01267770
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("Tag[");
			appendInterpolatedStringHandler.AppendFormatted(this.TagName);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0402752E RID: 161070
		public string TagName = "";

		// Token: 0x0402752F RID: 161071
		public int TagId;

		// Token: 0x04027530 RID: 161072
		[Nullable(2)]
		private ITagTask Handle;
	}
}
