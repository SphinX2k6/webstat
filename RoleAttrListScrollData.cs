using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002903 RID: 10499
[NullableContext(1)]
[Nullable(0)]
public class RoleAttrListScrollData : AttrListScrollData
{
	// Token: 0x06014DA1 RID: 85409 RVA: 0x005C6CE2 File Offset: 0x005C4EE2
	public RoleAttrListScrollData(int id, double baseValue, double addValue, int priority, bool isRatio, CommonComponentDefine.EAttributeType attributeType) : base(id, baseValue, addValue, priority, isRatio, attributeType)
	{
	}

	// Token: 0x06014DA2 RID: 85410 RVA: 0x005C6CF4 File Offset: 0x005C4EF4
	private PropertyIndex GetConfig()
	{
		return ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(this.Id).Value;
	}

	// Token: 0x06014DA3 RID: 85411 RVA: 0x005C6D1C File Offset: 0x005C4F1C
	public override string GetName()
	{
		return this.GetConfig().Name;
	}

	// Token: 0x06014DA4 RID: 85412 RVA: 0x005C6D38 File Offset: 0x005C4F38
	public override string GetIcon()
	{
		return this.GetConfig().Icon;
	}

	// Token: 0x06014DA5 RID: 85413 RVA: 0x005C6D54 File Offset: 0x005C4F54
	public override string GetDesc()
	{
		return this.GetConfig().Dec;
	}
}
