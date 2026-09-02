using System;

// Token: 0x0200179D RID: 6045
public class AttributeValueData
{
	// Token: 0x0600AAAB RID: 43691 RVA: 0x002D9413 File Offset: 0x002D7613
	public AttributeValueData(int attributeId, double attributeValue, bool isRatio)
	{
		this.AttributeId = attributeId;
		this.AttributeValue = attributeValue;
		this.IsRatio = isRatio;
	}

	// Token: 0x04005030 RID: 20528
	public int AttributeId;

	// Token: 0x04005031 RID: 20529
	public double AttributeValue;

	// Token: 0x04005032 RID: 20530
	public bool IsRatio;
}
