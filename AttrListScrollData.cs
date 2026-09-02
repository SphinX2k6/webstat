using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;

// Token: 0x02002900 RID: 10496
[NullableContext(1)]
[Nullable(0)]
public class AttrListScrollData : ScrollViewDataBase
{
	// Token: 0x06014D97 RID: 85399 RVA: 0x005C6B72 File Offset: 0x005C4D72
	public AttrListScrollData(int id, double baseValue, double addValue, int priority, bool isRatio, CommonComponentDefine.EAttributeType attributeType)
	{
		this.Id = id;
		this.BaseValue = baseValue;
		this.AddValue = addValue;
		this.Priority = priority;
		this.IsRatio = isRatio;
		this.AttributeType = attributeType;
	}

	// Token: 0x06014D98 RID: 85400 RVA: 0x005C6BA7 File Offset: 0x005C4DA7
	public virtual string GetName()
	{
		return "";
	}

	// Token: 0x06014D99 RID: 85401 RVA: 0x005C6BAE File Offset: 0x005C4DAE
	public virtual string GetIcon()
	{
		return "";
	}

	// Token: 0x06014D9A RID: 85402 RVA: 0x005C6BB5 File Offset: 0x005C4DB5
	public virtual string GetDesc()
	{
		return "";
	}

	// Token: 0x0400A06A RID: 41066
	public int Id;

	// Token: 0x0400A06B RID: 41067
	public double BaseValue;

	// Token: 0x0400A06C RID: 41068
	public double AddValue;

	// Token: 0x0400A06D RID: 41069
	public int Priority;

	// Token: 0x0400A06E RID: 41070
	public bool IsRatio;

	// Token: 0x0400A06F RID: 41071
	public CommonComponentDefine.EAttributeType AttributeType;

	// Token: 0x0400A070 RID: 41072
	public bool IsUnknown;

	// Token: 0x0400A071 RID: 41073
	public int CombineNum;

	// Token: 0x0400A072 RID: 41074
	public bool NeedHighLight;
}
