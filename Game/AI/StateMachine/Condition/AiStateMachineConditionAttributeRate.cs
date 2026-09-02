using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Protocol;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Condition
{
	// Token: 0x020070F3 RID: 28915
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineConditionAttributeRate : AiStateMachineCondition
	{
		// Token: 0x06046177 RID: 287095 RVA: 0x01268F52 File Offset: 0x01267152
		public AiStateMachineConditionAttributeRate(AiStateMachineTransition transition, CombatStateMachineDefine.Fsm.Condition condition, int index) : base(transition, condition, index)
		{
		}

		// Token: 0x06046178 RID: 287096 RVA: 0x01268F60 File Offset: 0x01267160
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Condition condition)
		{
			this.Numerator = (EAttributeType)condition.CondAttributeRate.AttributeId;
			this.Denominator = (EAttributeType)condition.CondAttributeRate.Denominator;
			this.Min = condition.CondAttributeRate.Min * 0.0001f;
			this.Max = condition.CondAttributeRate.Max * 0.0001f;
			this.Node.AttributeComponent.AddListeners(new EAttributeType[]
			{
				this.Numerator,
				this.Denominator
			}, new Action<EAttributeType, float, float>(this.OnAttrRateChanged), "AiConditionEvent");
			this.NumeratorValue = this.Node.AttributeComponent.GetCurrentValue(this.Numerator);
			this.DenominatorValue = this.Node.AttributeComponent.GetCurrentValue(this.Denominator);
			float num = this.NumeratorValue / this.DenominatorValue;
			this.ResultSelf = (num >= this.Min && num <= this.Max);
			return true;
		}

		// Token: 0x06046179 RID: 287097 RVA: 0x01269060 File Offset: 0x01267260
		private void OnAttrRateChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (attributeId == this.Numerator)
			{
				this.NumeratorValue = newValue;
			}
			else if (attributeId == this.Denominator)
			{
				this.DenominatorValue = newValue;
			}
			float num = this.NumeratorValue / this.DenominatorValue;
			this.ResultSelf = (num >= this.Min && num <= this.Max);
			AiStateMachineBase node = this.Node;
			if (node != null && node.Activated)
			{
				this.Node.Owner.TickStateMachine(base.Result, "AiStateMachineConditionAttributeRate", this.Node.Name);
			}
		}

		// Token: 0x0604617A RID: 287098 RVA: 0x012690F5 File Offset: 0x012672F5
		protected override void OnClear()
		{
			BaseAttributeComponent attributeComponent = this.Node.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListeners(new EAttributeType[]
			{
				this.Numerator,
				this.Denominator
			}, new Action<EAttributeType, float, float>(this.OnAttrRateChanged));
		}

		// Token: 0x0604617B RID: 287099 RVA: 0x01269130 File Offset: 0x01267330
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			base.ToString(outBuilder, depth);
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 4, outBuilder);
			appendInterpolatedStringHandler.AppendLiteral("属性比例 [");
			appendInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.Numerator);
			appendInterpolatedStringHandler.AppendLiteral("/");
			appendInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.Denominator);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Min);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted<float>(this.Max);
			appendInterpolatedStringHandler.AppendLiteral("]\n");
			outBuilder.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04027524 RID: 161060
		private const float ATTRIBUTE_RATE_COE = 0.0001f;

		// Token: 0x04027525 RID: 161061
		private EAttributeType Numerator;

		// Token: 0x04027526 RID: 161062
		private EAttributeType Denominator;

		// Token: 0x04027527 RID: 161063
		private float Min;

		// Token: 0x04027528 RID: 161064
		private float Max;

		// Token: 0x04027529 RID: 161065
		private float NumeratorValue;

		// Token: 0x0402752A RID: 161066
		private float DenominatorValue;
	}
}
