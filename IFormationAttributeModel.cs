using System;

// Token: 0x02000FC4 RID: 4036
public interface IFormationAttributeModel
{
	// Token: 0x0600677D RID: 26493
	float GetValue(EFormationAttributeId attrId);

	// Token: 0x0600677E RID: 26494
	float GetMax(EFormationAttributeId attrId);

	// Token: 0x0600677F RID: 26495
	float GetSpeed(EFormationAttributeId attrId);
}
