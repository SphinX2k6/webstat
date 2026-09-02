using System;
using System.Runtime.CompilerServices;

// Token: 0x020031BC RID: 12732
[NullableContext(1)]
[Nullable(0)]
public class InterestConditionBase
{
	// Token: 0x170023E4 RID: 9188
	// (get) Token: 0x0601A66A RID: 108138 RVA: 0x007C8F0B File Offset: 0x007C710B
	public virtual EInterestConditionType Type
	{
		get
		{
			return EInterestConditionType.Angle;
		}
	}

	// Token: 0x0601A66B RID: 108139 RVA: 0x007C8F0E File Offset: 0x007C710E
	public virtual bool CheckCondition(Entity entity, InterestItemBase item)
	{
		return false;
	}

	// Token: 0x0400D50A RID: 54538
	[StaticVariableRuleIgnore]
	protected static Vector TmpVector1 = Vector.Create();
}
