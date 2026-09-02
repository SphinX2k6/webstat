using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FCA RID: 12234
[NullableContext(1)]
[Nullable(0)]
public class TeamAttributeChangedTrigger : Trigger
{
	// Token: 0x06018F1D RID: 102173 RVA: 0x0071153D File Offset: 0x0070F73D
	[NullableContext(2)]
	public TeamAttributeChangedTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F1E RID: 102174 RVA: 0x00711555 File Offset: 0x0070F755
	public override void OnInitParams(string[] triggerParams)
	{
		this.AttributeId = (EFormationAttributeId)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F1F RID: 102175 RVA: 0x00711570 File Offset: 0x0070F770
	protected override void OnActive()
	{
		FormationAttributeController instance = ControllerBase<FormationAttributeController>.Instance;
		float num = (instance != null) ? instance.GetValue(this.AttributeId) : 0f;
		this.OnEvent(this.AttributeId, num, num);
		FormationAttributeController instance2 = ControllerBase<FormationAttributeController>.Instance;
		if (instance2 == null)
		{
			return;
		}
		instance2.AddValueListener(this.AttributeId, new TValueListener(this.OnEvent), null);
	}

	// Token: 0x06018F20 RID: 102176 RVA: 0x007115C9 File Offset: 0x0070F7C9
	protected override void OnInactive()
	{
		FormationAttributeController instance = ControllerBase<FormationAttributeController>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RemoveValueListener(this.AttributeId, new TValueListener(this.OnEvent));
	}

	// Token: 0x06018F21 RID: 102177 RVA: 0x007115EC File Offset: 0x0070F7EC
	protected void OnEvent(EFormationAttributeId attrId, float newValue, float oldValue)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["NewValue"] = newValue;
		dictionary["OldValue"] = oldValue;
		string key = "MaxValue";
		FormationAttributeController instance = ControllerBase<FormationAttributeController>.Instance;
		dictionary[key] = ((instance != null) ? instance.GetMax(attrId) : 0f);
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F22 RID: 102178 RVA: 0x00711664 File Offset: 0x0070F864
	public override string GetDebugTriggerType()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("队伍属性 #");
		defaultInterpolatedStringHandler.AppendFormatted<EFormationAttributeId>(this.AttributeId);
		defaultInterpolatedStringHandler.AppendLiteral("变化时触发");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C2F2 RID: 49906
	protected EFormationAttributeId AttributeId = EFormationAttributeId.Strength;
}
