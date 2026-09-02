using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F2 RID: 28914
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionAttribute : AiStateMachineCondition
	{
		// Token: 0x06046172 RID: 287090 RVA: 0x01268D92 File Offset: 0x01266F92
		public AiStateMachineConditionAttribute(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046173 RID: 287091 RVA: 0x01268DA0 File Offset: 0x01266FA0
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.AttributeId = (EAttributeType)condition.CondAttribute.AttributeId;
			this.Min = condition.CondAttribute.Min;
			this.Max = condition.CondAttribute.Max;
			this.Node.AttributeComponent.AddListener(this.AttributeId, new Action<EAttributeType, float, float>(this.OnAttrChanged), "AiConditionEvent");
			float currentValue = this.Node.AttributeComponent.GetCurrentValue(this.AttributeId);
			this.ResultSelf = (currentValue >= this.Min && currentValue <= this.Max);
			return true;
		}

		// Token: 0x06046174 RID: 287092 RVA: 0x01268E40 File Offset: 0x01267040
		private void OnAttrChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.ResultSelf = (newValue >= this.Min && newValue <= this.Max);
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionAttribute", this.Node.Name);
			}
		}

		// Token: 0x06046175 RID: 287093 RVA: 0x01268EA5 File Offset: 0x012670A5
		protected override void OnClear()
		{
			BaseAttributeComponent attributeComponent = this.Node.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListener(this.AttributeId, new Action<EAttributeType, float, float>(this.OnAttrChanged));
		}

		// Token: 0x06046176 RID: 287094 RVA: 0x01268ED0 File Offset: 0x012670D0
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 3, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("属性 [");
			appendInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Min);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Max);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027521 RID: 161057
		private EAttributeType AttributeId;

		// Token: 0x04027522 RID: 161058
		private float Min;

		// Token: 0x04027523 RID: 161059
		private float Max;
	}
}
