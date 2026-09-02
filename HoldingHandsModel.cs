using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001EC5 RID: 7877
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class HoldingHandsModel : ModelBase<HoldingHandsModel>
{
	// Token: 0x0600E8F9 RID: 59641 RVA: 0x003F14D6 File Offset: 0x003EF6D6
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600E8FA RID: 59642 RVA: 0x003F14D9 File Offset: 0x003EF6D9
	protected override bool OnClear()
	{
		this.Relations.Clear();
		return true;
	}

	// Token: 0x0600E8FB RID: 59643 RVA: 0x003F14E7 File Offset: 0x003EF6E7
	public void SetRelation(string key, HoldingHandsRelation relation)
	{
		this.Relations[key] = relation;
	}

	// Token: 0x0600E8FC RID: 59644 RVA: 0x003F14F6 File Offset: 0x003EF6F6
	public void DeleteRelation(string key)
	{
		this.Relations.Remove(key);
	}

	// Token: 0x0600E8FD RID: 59645 RVA: 0x003F1508 File Offset: 0x003EF708
	[return: Nullable(2)]
	public HoldingHandsRelation GetRelation(string key)
	{
		HoldingHandsRelation result;
		if (this.Relations.TryGetValue(key, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x04007036 RID: 28726
	public readonly Dictionary<string, HoldingHandsRelation> Relations = new Dictionary<string, HoldingHandsRelation>();
}
