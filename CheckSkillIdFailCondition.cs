using System;
using System.Runtime.CompilerServices;

// Token: 0x02001883 RID: 6275
[NullableContext(1)]
[Nullable(0)]
public class CheckSkillIdFailCondition : BaseCheckCondition
{
	// Token: 0x0600B3F4 RID: 46068 RVA: 0x002FF378 File Offset: 0x002FD578
	public CheckSkillIdFailCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Event;
		this.FailType = EComboTeachingFailCondition.SkillIdChecker;
	}

	// Token: 0x17000ED9 RID: 3801
	// (get) Token: 0x0600B3F5 RID: 46069 RVA: 0x002FF390 File Offset: 0x002FD590
	// (set) Token: 0x0600B3F6 RID: 46070 RVA: 0x002FF398 File Offset: 0x002FD598
	public override EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EDA RID: 3802
	// (get) Token: 0x0600B3F7 RID: 46071 RVA: 0x002FF3A1 File Offset: 0x002FD5A1
	// (set) Token: 0x0600B3F8 RID: 46072 RVA: 0x002FF3A9 File Offset: 0x002FD5A9
	protected override EComboTeachingFailCondition FailType { get; set; }

	// Token: 0x0600B3F9 RID: 46073 RVA: 0x002FF3B4 File Offset: 0x002FD5B4
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo param = null)
	{
		return this.ParamsArray != null && (ModelBase<ComboTeachingModel>.Instance.UseSkillId != 0L && !this.OriginString.Contains(ModelBase<ComboTeachingModel>.Instance.UseSkillId.ToString()));
	}
}
