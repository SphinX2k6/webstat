using System;
using System.Runtime.CompilerServices;

// Token: 0x02001884 RID: 6276
[NullableContext(1)]
[Nullable(0)]
public class CheckSkillExitNextAttrCondition : BaseCheckCondition
{
	// Token: 0x0600B3FA RID: 46074 RVA: 0x002FF3F9 File Offset: 0x002FD5F9
	public CheckSkillExitNextAttrCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.FailType = EComboTeachingFailCondition.NextAttrEnd;
	}

	// Token: 0x17000EDB RID: 3803
	// (get) Token: 0x0600B3FB RID: 46075 RVA: 0x002FF41F File Offset: 0x002FD61F
	// (set) Token: 0x0600B3FC RID: 46076 RVA: 0x002FF427 File Offset: 0x002FD627
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000EDC RID: 3804
	// (get) Token: 0x0600B3FD RID: 46077 RVA: 0x002FF430 File Offset: 0x002FD630
	// (set) Token: 0x0600B3FE RID: 46078 RVA: 0x002FF438 File Offset: 0x002FD638
	protected override EComboTeachingFailCondition FailType { get; set; } = EComboTeachingFailCondition.NextAttrEnd;

	// Token: 0x0600B3FF RID: 46079 RVA: 0x002FF441 File Offset: 0x002FD641
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		return ModelBase<ComboTeachingModel>.Instance.UseSkillId == ModelBase<ComboTeachingModel>.Instance.NextAttrSkillId && !ModelBase<ComboTeachingModel>.Instance.NextAttr && ModelBase<ComboTeachingModel>.Instance.PreNextAttr;
	}
}
