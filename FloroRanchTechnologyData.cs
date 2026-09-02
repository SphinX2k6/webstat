using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BD3 RID: 7123
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTechnologyData
{
	// Token: 0x0600CF4F RID: 53071 RVA: 0x00371C37 File Offset: 0x0036FE37
	public FloroRanchTechnologyData(FloroRanchTech config)
	{
		this.Config = config;
	}

	// Token: 0x0600CF50 RID: 53072 RVA: 0x00371C46 File Offset: 0x0036FE46
	public void UpdateUnLockState(bool isUnLock)
	{
		this.IsUnLockInternal = isUnLock;
	}

	// Token: 0x170010E4 RID: 4324
	// (get) Token: 0x0600CF51 RID: 53073 RVA: 0x00371C4F File Offset: 0x0036FE4F
	public bool IsUnLock
	{
		get
		{
			return this.IsUnLockInternal;
		}
	}

	// Token: 0x170010E5 RID: 4325
	// (get) Token: 0x0600CF52 RID: 53074 RVA: 0x00371C57 File Offset: 0x0036FE57
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010E6 RID: 4326
	// (get) Token: 0x0600CF53 RID: 53075 RVA: 0x00371C64 File Offset: 0x0036FE64
	public string Name
	{
		get
		{
			return this.Config.Name;
		}
	}

	// Token: 0x170010E7 RID: 4327
	// (get) Token: 0x0600CF54 RID: 53076 RVA: 0x00371C71 File Offset: 0x0036FE71
	public int Column
	{
		get
		{
			return this.Config.Column;
		}
	}

	// Token: 0x170010E8 RID: 4328
	// (get) Token: 0x0600CF55 RID: 53077 RVA: 0x00371C7E File Offset: 0x0036FE7E
	public int Row
	{
		get
		{
			return this.Config.Row;
		}
	}

	// Token: 0x170010E9 RID: 4329
	// (get) Token: 0x0600CF56 RID: 53078 RVA: 0x00371C8B File Offset: 0x0036FE8B
	public int Cost
	{
		get
		{
			return this.Config.Cost;
		}
	}

	// Token: 0x170010EA RID: 4330
	// (get) Token: 0x0600CF57 RID: 53079 RVA: 0x00371C98 File Offset: 0x0036FE98
	public string Des
	{
		get
		{
			return this.Config.Desc;
		}
	}

	// Token: 0x170010EB RID: 4331
	// (get) Token: 0x0600CF58 RID: 53080 RVA: 0x00371CA5 File Offset: 0x0036FEA5
	public int[] PreNode
	{
		get
		{
			return this.Config.GetPreNodeArray();
		}
	}

	// Token: 0x170010EC RID: 4332
	// (get) Token: 0x0600CF59 RID: 53081 RVA: 0x00371CB2 File Offset: 0x0036FEB2
	public string Icon
	{
		get
		{
			return this.Config.Icon;
		}
	}

	// Token: 0x040062BD RID: 25277
	private FloroRanchTech Config;

	// Token: 0x040062BE RID: 25278
	private bool IsUnLockInternal;
}
