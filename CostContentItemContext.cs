using System;
using System.Runtime.CompilerServices;

// Token: 0x02002887 RID: 10375
[NullableContext(2)]
[Nullable(0)]
public class CostContentItemContext
{
	// Token: 0x0601489D RID: 84125 RVA: 0x005B22EF File Offset: 0x005B04EF
	[NullableContext(1)]
	public CostContentItemContext(RoleBreakPreviewViewModel vm, CostContentItem item)
	{
		this.Vm = vm;
		this.CachedPanel = item;
	}

	// Token: 0x0601489E RID: 84126 RVA: 0x005B2313 File Offset: 0x005B0513
	public void Dispose()
	{
	}

	// Token: 0x17001ACE RID: 6862
	// (get) Token: 0x0601489F RID: 84127 RVA: 0x005B2315 File Offset: 0x005B0515
	// (set) Token: 0x060148A0 RID: 84128 RVA: 0x005B231D File Offset: 0x005B051D
	public int CostNumber
	{
		get
		{
			return this.CostNumberCore;
		}
		set
		{
			this.CostNumberCore = value;
			this.CachedPanel.RefreshCostNumber(value.ToString());
		}
	}

	// Token: 0x17001ACF RID: 6863
	// (get) Token: 0x060148A1 RID: 84129 RVA: 0x005B2338 File Offset: 0x005B0538
	// (set) Token: 0x060148A2 RID: 84130 RVA: 0x005B2340 File Offset: 0x005B0540
	public EItemId MoneyIcon
	{
		get
		{
			return this.MoneyIconCore;
		}
		set
		{
			this.MoneyIconCore = value;
			this.CachedPanel.RefreshMoneyIcon(value);
		}
	}

	// Token: 0x17001AD0 RID: 6864
	// (get) Token: 0x060148A3 RID: 84131 RVA: 0x005B2355 File Offset: 0x005B0555
	// (set) Token: 0x060148A4 RID: 84132 RVA: 0x005B2360 File Offset: 0x005B0560
	public int ChosenLevel
	{
		get
		{
			return this.ChosenLevelCore;
		}
		set
		{
			this.ChosenLevelCore = value;
			ICostContentItemData costContentItemData = this.Vm.BuildCostContentItemData(value);
			if (costContentItemData != null)
			{
				this.CostNumber = costContentItemData.CostNum;
				this.MoneyIcon = costContentItemData.CostType;
				this.CachedPanel.Show(null);
				return;
			}
			this.CachedPanel.Hide(null);
		}
	}

	// Token: 0x04009EC9 RID: 40649
	private readonly RoleBreakPreviewViewModel Vm;

	// Token: 0x04009ECA RID: 40650
	private readonly CostContentItem CachedPanel;

	// Token: 0x04009ECB RID: 40651
	private int CostNumberCore;

	// Token: 0x04009ECC RID: 40652
	private EItemId MoneyIconCore = EItemId.Gold;

	// Token: 0x04009ECD RID: 40653
	private int ChosenLevelCore = -1;
}
