using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleDev;

// Token: 0x0200280E RID: 10254
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDevPhantomViewItemDataBase
{
	// Token: 0x060143C3 RID: 82883 RVA: 0x005A262F File Offset: 0x005A082F
	public void InitByRoleId(int roleId, ERoleDevDataType roleType, RoleDevViewModel roleDevViewModel)
	{
		this.RoleIdInternal = roleId;
		this.RoleTypeInternal = roleType;
		this.RoleDevViewModelInternal = roleDevViewModel;
		this.InitByRoleType(roleId);
	}

	// Token: 0x060143C4 RID: 82884
	protected abstract void InitByRoleType(int roleId);

	// Token: 0x17001A12 RID: 6674
	// (get) Token: 0x060143C5 RID: 82885 RVA: 0x005A264D File Offset: 0x005A084D
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A13 RID: 6675
	// (get) Token: 0x060143C6 RID: 82886 RVA: 0x005A2655 File Offset: 0x005A0855
	public ERoleDevDataType RoleType
	{
		get
		{
			return this.RoleTypeInternal;
		}
	}

	// Token: 0x060143C7 RID: 82887
	protected abstract List<RoleDevPhantomSuitItemData> GetSuitDataList();

	// Token: 0x17001A14 RID: 6676
	// (get) Token: 0x060143C8 RID: 82888 RVA: 0x005A265D File Offset: 0x005A085D
	public List<RoleDevPhantomSuitItemData> SuitDataList
	{
		get
		{
			return this.GetSuitDataList();
		}
	}

	// Token: 0x17001A15 RID: 6677
	// (get) Token: 0x060143C9 RID: 82889 RVA: 0x005A2665 File Offset: 0x005A0865
	public bool IsRoleObtained
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Obtained;
		}
	}

	// Token: 0x17001A16 RID: 6678
	// (get) Token: 0x060143CA RID: 82890 RVA: 0x005A2670 File Offset: 0x005A0870
	public bool IsForecast
	{
		get
		{
			return this.RoleType == ERoleDevDataType.Forecast;
		}
	}

	// Token: 0x17001A17 RID: 6679
	// (get) Token: 0x060143CB RID: 82891 RVA: 0x005A267B File Offset: 0x005A087B
	public bool IsNotObtained
	{
		get
		{
			return this.RoleType == ERoleDevDataType.NotObtained;
		}
	}

	// Token: 0x17001A18 RID: 6680
	// (get) Token: 0x060143CC RID: 82892 RVA: 0x005A2686 File Offset: 0x005A0886
	[Nullable(2)]
	public RoleDevViewModel RoleDevViewModel
	{
		[NullableContext(2)]
		get
		{
			return this.RoleDevViewModelInternal;
		}
	}

	// Token: 0x060143CD RID: 82893
	public abstract void RefreshSuitDataList();

	// Token: 0x04009D71 RID: 40305
	protected int RoleIdInternal;

	// Token: 0x04009D72 RID: 40306
	protected ERoleDevDataType RoleTypeInternal;

	// Token: 0x04009D73 RID: 40307
	[Nullable(2)]
	protected RoleDevViewModel RoleDevViewModelInternal;
}
