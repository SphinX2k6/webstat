using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200187A RID: 6266
[NullableContext(1)]
[Nullable(0)]
public class CheckSkillIdSuccessCondition : BaseCheckCondition
{
	// Token: 0x0600B3B5 RID: 46005 RVA: 0x002FEA75 File Offset: 0x002FCC75
	public CheckSkillIdSuccessCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.SkillIdChecker;
	}

	// Token: 0x17000EC4 RID: 3780
	// (get) Token: 0x0600B3B6 RID: 46006 RVA: 0x002FEA94 File Offset: 0x002FCC94
	// (set) Token: 0x0600B3B7 RID: 46007 RVA: 0x002FEA9C File Offset: 0x002FCC9C
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000EC5 RID: 3781
	// (get) Token: 0x0600B3B8 RID: 46008 RVA: 0x002FEAA5 File Offset: 0x002FCCA5
	// (set) Token: 0x0600B3B9 RID: 46009 RVA: 0x002FEAAD File Offset: 0x002FCCAD
	protected override EComboTeachingSuccessCondition SuccessType { get; set; }

	// Token: 0x0600B3BA RID: 46010 RVA: 0x002FEAB8 File Offset: 0x002FCCB8
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo paramex = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (ModelBase<ComboTeachingModel>.Instance.UseSkillId == (long)int.Parse(list[0]) && ModelBase<ComboTeachingModel>.Instance.UseSkillTime >= float.Parse(list[1]) * 1000f && !ModelBase<ComboTeachingModel>.Instance.IsEmit)
			{
				return true;
			}
		}
		return false;
	}
}
