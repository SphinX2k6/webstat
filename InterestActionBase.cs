using System;
using System.Runtime.CompilerServices;

// Token: 0x020031B7 RID: 12727
[NullableContext(1)]
[Nullable(0)]
public class InterestActionBase
{
	// Token: 0x170023DD RID: 9181
	// (get) Token: 0x0601A64E RID: 108110 RVA: 0x007C8CA1 File Offset: 0x007C6EA1
	public virtual EInterestActionType Type
	{
		get
		{
			return EInterestActionType.LookAt;
		}
	}

	// Token: 0x170023DE RID: 9182
	// (get) Token: 0x0601A64F RID: 108111 RVA: 0x007C8CA4 File Offset: 0x007C6EA4
	public virtual bool IsExclusive
	{
		get
		{
			return false;
		}
	}

	// Token: 0x0601A650 RID: 108112 RVA: 0x007C8CA7 File Offset: 0x007C6EA7
	public virtual void OnEnter(Entity entity, InterestItemBase item)
	{
	}

	// Token: 0x0601A651 RID: 108113 RVA: 0x007C8CA9 File Offset: 0x007C6EA9
	public virtual void OnLeave(Entity entity, InterestItemBase item)
	{
	}

	// Token: 0x0601A652 RID: 108114 RVA: 0x007C8CAB File Offset: 0x007C6EAB
	public virtual int GetPriority(Entity entity, InterestItemBase item)
	{
		return 0;
	}

	// Token: 0x0400D505 RID: 54533
	public int Priority;

	// Token: 0x0400D506 RID: 54534
	[StaticVariableRuleIgnore]
	protected static Vector TmpVector1 = Vector.Create();
}
