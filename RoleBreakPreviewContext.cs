using System;
using System.Runtime.CompilerServices;

// Token: 0x02002886 RID: 10374
[NullableContext(1)]
[Nullable(0)]
public class RoleBreakPreviewContext
{
	// Token: 0x06014893 RID: 84115 RVA: 0x005B218C File Offset: 0x005B038C
	public RoleBreakPreviewContext(RoleBreakPreviewViewModel vm, RoleBreakPreviewView view)
	{
		this.Vm = vm;
		this.CachedView = view;
	}

	// Token: 0x06014894 RID: 84116 RVA: 0x005B21BC File Offset: 0x005B03BC
	public void Dispose()
	{
	}

	// Token: 0x17001ACA RID: 6858
	// (get) Token: 0x06014895 RID: 84117 RVA: 0x005B21BE File Offset: 0x005B03BE
	// (set) Token: 0x06014896 RID: 84118 RVA: 0x005B21C6 File Offset: 0x005B03C6
	public int LevelContent
	{
		get
		{
			return this.LevelContentCore;
		}
		set
		{
			this.LevelContentCore = value;
			this.CachedView.RefreshLevelContent(value);
		}
	}

	// Token: 0x17001ACB RID: 6859
	// (get) Token: 0x06014897 RID: 84119 RVA: 0x005B21DB File Offset: 0x005B03DB
	// (set) Token: 0x06014898 RID: 84120 RVA: 0x005B21E3 File Offset: 0x005B03E3
	public ILevelLayoutGridData[] LevelLayout
	{
		get
		{
			return this.LevelLayoutCore;
		}
		set
		{
			this.LevelLayoutCore = value;
			this.CachedView.RefreshLevelLayout(value);
		}
	}

	// Token: 0x17001ACC RID: 6860
	// (get) Token: 0x06014899 RID: 84121 RVA: 0x005B21F8 File Offset: 0x005B03F8
	// (set) Token: 0x0601489A RID: 84122 RVA: 0x005B2200 File Offset: 0x005B0400
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public ISelectedData[] ItemLayout
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return this.ItemLayoutCore;
		}
		[param: Nullable(new byte[]
		{
			2,
			1
		})]
		set
		{
			this.ItemLayoutCore = value;
			if (value != null)
			{
				this.CachedView.RefreshItemLayout(value);
			}
		}
	}

	// Token: 0x17001ACD RID: 6861
	// (get) Token: 0x0601489B RID: 84123 RVA: 0x005B2218 File Offset: 0x005B0418
	// (set) Token: 0x0601489C RID: 84124 RVA: 0x005B2220 File Offset: 0x005B0420
	public int ChosenLevel
	{
		get
		{
			return this.ChosenLevelCore;
		}
		set
		{
			this.ChosenLevelCore = value;
			RoleLevelData levelData = this.Vm.CachedRoleInstance.GetLevelData();
			int breachLevel = levelData.GetBreachLevel();
			int maxBreachLevel = levelData.GetMaxBreachLevel();
			int maxLevel = levelData.GetBreachConfig(value).Value.MaxLevel;
			if (breachLevel >= value)
			{
				this.CachedView.RefreshLevelContentItem(false);
				this.CachedView.RefreshHasBrokenTip(true);
			}
			else
			{
				this.CachedView.RefreshLevelContentItem(true);
				this.CachedView.RefreshHasBrokenTip(false);
				this.LevelContent = maxLevel;
			}
			this.CachedView.RefreshLeftButton(value != 1);
			this.CachedView.RefreshRightButton(value != maxBreachLevel);
			this.LevelLayout = this.Vm.BuildLevelLayoutData(value);
			this.ItemLayout = this.Vm.BuildItemLayoutData(value);
		}
	}

	// Token: 0x04009EC3 RID: 40643
	[Nullable(2)]
	private readonly RoleBreakPreviewViewModel Vm;

	// Token: 0x04009EC4 RID: 40644
	[Nullable(2)]
	private readonly RoleBreakPreviewView CachedView;

	// Token: 0x04009EC5 RID: 40645
	private int LevelContentCore = -1;

	// Token: 0x04009EC6 RID: 40646
	private ILevelLayoutGridData[] LevelLayoutCore = new ILevelLayoutGridData[0];

	// Token: 0x04009EC7 RID: 40647
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ISelectedData[] ItemLayoutCore;

	// Token: 0x04009EC8 RID: 40648
	private int ChosenLevelCore = -1;
}
