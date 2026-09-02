using System;
using Aki.Protocol;

// Token: 0x02002E95 RID: 11925
public interface IAttributeSet
{
	// Token: 0x060187AE RID: 100270
	float GetBaseValue(EAttributeType attrId);

	// Token: 0x060187AF RID: 100271
	float GetCurrentValue(EAttributeType attrId);
}
