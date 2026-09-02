using System;
using System.Runtime.CompilerServices;

// Token: 0x020031B9 RID: 12729
[NullableContext(1)]
[Nullable(0)]
public class InterestItemBase
{
	// Token: 0x170023E1 RID: 9185
	// (get) Token: 0x0601A65C RID: 108124 RVA: 0x007C8DCC File Offset: 0x007C6FCC
	public virtual EInterestItemType Type
	{
		get
		{
			return EInterestItemType.Position;
		}
	}

	// Token: 0x0601A65D RID: 108125 RVA: 0x007C8DCF File Offset: 0x007C6FCF
	public virtual bool GetLocation(Vector outVector)
	{
		return false;
	}

	// Token: 0x0601A65E RID: 108126 RVA: 0x007C8DD2 File Offset: 0x007C6FD2
	public virtual string GetDebugInfo()
	{
		return "";
	}

	// Token: 0x0400D507 RID: 54535
	[StaticVariableRuleIgnore]
	protected static Vector TempVector1 = Vector.Create();
}
