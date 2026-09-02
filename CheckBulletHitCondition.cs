using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001887 RID: 6279
[NullableContext(1)]
[Nullable(0)]
public class CheckBulletHitCondition : BaseCheckCondition
{
	// Token: 0x0600B40C RID: 46092 RVA: 0x002FF5CA File Offset: 0x002FD7CA
	public CheckBulletHitCondition(string paramsString, bool isSuccessNode) : base(paramsString, isSuccessNode)
	{
		this.Type = EComboTeachingCheckType.Event;
		this.SuccessType = EComboTeachingSuccessCondition.BulletHit;
	}

	// Token: 0x17000EE1 RID: 3809
	// (get) Token: 0x0600B40D RID: 46093 RVA: 0x002FF5EB File Offset: 0x002FD7EB
	// (set) Token: 0x0600B40E RID: 46094 RVA: 0x002FF5F3 File Offset: 0x002FD7F3
	public override EComboTeachingCheckType Type { get; set; }

	// Token: 0x17000EE2 RID: 3810
	// (get) Token: 0x0600B40F RID: 46095 RVA: 0x002FF5FC File Offset: 0x002FD7FC
	// (set) Token: 0x0600B410 RID: 46096 RVA: 0x002FF604 File Offset: 0x002FD804
	protected override EComboTeachingSuccessCondition SuccessType { get; set; } = EComboTeachingSuccessCondition.BulletHit;

	// Token: 0x0600B411 RID: 46097 RVA: 0x002FF610 File Offset: 0x002FD810
	public override bool Check(IComboTeachingInfo node, [Nullable(2)] IBaseCheckConditionInfo extra = null)
	{
		ICheckSkillHitCondition checkSkillHitCondition = extra as ICheckSkillHitCondition;
		if (this.SuccessParamsArray == null || checkSkillHitCondition == null)
		{
			return false;
		}
		foreach (List<string> list in this.SuccessParamsArray)
		{
			if (checkSkillHitCondition.BulletId == long.Parse(list[0]))
			{
				return true;
			}
		}
		return false;
	}
}
