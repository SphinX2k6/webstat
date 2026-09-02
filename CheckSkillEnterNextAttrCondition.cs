using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001882 RID: 6274
[NullableContext(1)]
[Nullable(0)]
public class CheckSkillEnterNextAttrCondition : BaseCheckCondition
{
	// Token: 0x0600B3EE RID: 46062 RVA: 0x002FF2A0 File Offset: 0x002FD4A0
	public CheckSkillEnterNextAttrCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Update;
		this.SuccessType = EComboTeachingSuccessCondition.NextAttrStart;
	}

	// Token: 0x17000ED7 RID: 3799
	// (get) Token: 0x0600B3EF RID: 46063 RVA: 0x002FF2C6 File Offset: 0x002FD4C6
	// (set) Token: 0x0600B3F0 RID: 46064 RVA: 0x002FF2CE File Offset: 0x002FD4CE
	public override EComboTeachingCheckType Type { get; set; } = EComboTeachingCheckType.Update;

	// Token: 0x17000ED8 RID: 3800
	// (get) Token: 0x0600B3F1 RID: 46065 RVA: 0x002FF2D7 File Offset: 0x002FD4D7
	// (set) Token: 0x0600B3F2 RID: 46066 RVA: 0x002FF2DF File Offset: 0x002FD4DF
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.NextAttrStart;

	// Token: 0x0600B3F3 RID: 46067 RVA: 0x002FF2E8 File Offset: 0x002FD4E8
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo paramex = null)
	{
		if (this.SuccessParamsArray == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (ModelBase<ComboTeachingModel>.Instance.NextAttrSkillId == (long)int.Parse(list[0]) && ModelBase<ComboTeachingModel>.Instance.NextAttr && !ModelBase<ComboTeachingModel>.Instance.PreNextAttr)
			{
				return true;
			}
		}
		return false;
	}
}
