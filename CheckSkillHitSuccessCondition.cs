using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200187B RID: 6267
[NullableContext(1)]
[Nullable(0)]
public class CheckSkillHitSuccessCondition : BaseCheckCondition
{
	// Token: 0x0600B3BB RID: 46011 RVA: 0x002FEB58 File Offset: 0x002FCD58
	public CheckSkillHitSuccessCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Event;
		this.SuccessType = EComboTeachingSuccessCondition.SkillIdHit;
	}

	// Token: 0x17000EC6 RID: 3782
	// (get) Token: 0x0600B3BC RID: 46012 RVA: 0x002FEB77 File Offset: 0x002FCD77
	// (set) Token: 0x0600B3BD RID: 46013 RVA: 0x002FEB7F File Offset: 0x002FCD7F
	public override EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EC7 RID: 3783
	// (get) Token: 0x0600B3BE RID: 46014 RVA: 0x002FEB88 File Offset: 0x002FCD88
	// (set) Token: 0x0600B3BF RID: 46015 RVA: 0x002FEB90 File Offset: 0x002FCD90
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.SkillIdHit;

	// Token: 0x0600B3C0 RID: 46016 RVA: 0x002FEB9C File Offset: 0x002FCD9C
	public override bool Check(IComboTeachingInfo data, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckSkillHitCondition checkSkillHitCondition = extra as ICheckSkillHitCondition;
		if (this.SuccessParamsArray == null || checkSkillHitCondition == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (checkSkillHitCondition.HitSkillId == (long)int.Parse(list[0]))
			{
				return true;
			}
		}
		return false;
	}
}
