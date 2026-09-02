using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi.RoleBreach;
using Cysharp.Threading.Tasks;

// Token: 0x02002885 RID: 10373
[NullableContext(1)]
[Nullable(0)]
public class RoleBreakPreviewViewModel
{
	// Token: 0x0601487C RID: 84092 RVA: 0x005B1DC2 File Offset: 0x005AFFC2
	public void Dispose()
	{
		this.ChosenLevelCore = -1;
		this.UnbindView();
		this.UnbindCostContentItem();
	}

	// Token: 0x17001AC8 RID: 6856
	// (get) Token: 0x0601487D RID: 84093 RVA: 0x005B1DD7 File Offset: 0x005AFFD7
	// (set) Token: 0x0601487E RID: 84094 RVA: 0x005B1DDF File Offset: 0x005AFFDF
	public RoleDataBase CachedRoleInstance
	{
		get
		{
			return this.CachedRoleInstanceCore;
		}
		set
		{
			if (this.CachedRoleInstanceCore != null && value != null)
			{
				return;
			}
			this.CachedRoleInstanceCore = value;
		}
	}

	// Token: 0x17001AC9 RID: 6857
	// (get) Token: 0x0601487F RID: 84095 RVA: 0x005B1DF4 File Offset: 0x005AFFF4
	// (set) Token: 0x06014880 RID: 84096 RVA: 0x005B1DFC File Offset: 0x005AFFFC
	public int ChosenLevel
	{
		get
		{
			return this.ChosenLevelCore;
		}
		set
		{
			int maxBreachLevel = this.CachedRoleInstance.GetLevelData().GetMaxBreachLevel();
			int num = value;
			if (num < 1)
			{
				num = 1;
			}
			else if (num > maxBreachLevel)
			{
				num = maxBreachLevel;
			}
			this.ChosenLevelCore = num;
			this.CachedViewContextCore.ChosenLevel = num;
			this.CachedCostContentItemContextCore.ChosenLevel = num;
		}
	}

	// Token: 0x06014881 RID: 84097 RVA: 0x005B1E49 File Offset: 0x005B0049
	public LevelLayoutGrid CreateLevelLayoutGrid()
	{
		return new LevelLayoutGrid(this);
	}

	// Token: 0x06014882 RID: 84098 RVA: 0x005B1E54 File Offset: 0x005B0054
	private void ExtendToggleClickedCallback(MediumItemGridExtendCallback callbackParam)
	{
		ISelectedData selectedData = callbackParam.Data as ISelectedData;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(selectedData.ItemId, true, null);
		callbackParam.MediumItemGrid.SetSelected(true, true);
	}

	// Token: 0x06014883 RID: 84099 RVA: 0x005B1E8C File Offset: 0x005B008C
	public CostMediumItemGrid CreateItemLayoutGrid()
	{
		CostMediumItemGrid costMediumItemGrid = new CostMediumItemGrid();
		costMediumItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.ExtendToggleClickedCallback));
		return costMediumItemGrid;
	}

	// Token: 0x06014884 RID: 84100 RVA: 0x005B1EA5 File Offset: 0x005B00A5
	public void BindView(RoleBreakPreviewView view)
	{
		this.CachedViewContextCore = new RoleBreakPreviewContext(this, view);
	}

	// Token: 0x06014885 RID: 84101 RVA: 0x005B1EB4 File Offset: 0x005B00B4
	public void UnbindView()
	{
		RoleBreakPreviewContext cachedViewContextCore = this.CachedViewContextCore;
		if (cachedViewContextCore != null)
		{
			cachedViewContextCore.Dispose();
		}
		this.CachedViewContextCore = null;
	}

	// Token: 0x06014886 RID: 84102 RVA: 0x005B1ECE File Offset: 0x005B00CE
	public void BindCostContentItem(CostContentItem item)
	{
		this.CachedCostContentItemContextCore = new CostContentItemContext(this, item);
	}

	// Token: 0x06014887 RID: 84103 RVA: 0x005B1EDD File Offset: 0x005B00DD
	public void UnbindCostContentItem()
	{
		CostContentItemContext cachedCostContentItemContextCore = this.CachedCostContentItemContextCore;
		if (cachedCostContentItemContextCore != null)
		{
			cachedCostContentItemContextCore.Dispose();
		}
		this.CachedCostContentItemContextCore = null;
	}

	// Token: 0x06014888 RID: 84104 RVA: 0x005B1EF8 File Offset: 0x005B00F8
	public void HandleViewOnStart()
	{
		int breachLevel = this.CachedRoleInstance.GetLevelData().GetBreachLevel();
		this.ChosenLevel = breachLevel + 1;
	}

	// Token: 0x06014889 RID: 84105 RVA: 0x005B1F20 File Offset: 0x005B0120
	public void HandleCostContentItemOnStart()
	{
		RoleLevelData levelData = this.CachedRoleInstance.GetLevelData();
		this.CachedCostContentItemContextCore.ChosenLevel = levelData.GetBreachLevel();
	}

	// Token: 0x0601488A RID: 84106 RVA: 0x005B1F4A File Offset: 0x005B014A
	[NullableContext(0)]
	public void HandleViewClosePromise(UniTask<bool> booleanPromise)
	{
		booleanPromise.ContinueWith(delegate(bool _)
		{
			this.CachedRoleInstance = null;
		}).Forget();
	}

	// Token: 0x0601488B RID: 84107 RVA: 0x005B1F63 File Offset: 0x005B0163
	public void HandleItemOnClickToggle(int gridIndex)
	{
		this.ChosenLevel = gridIndex + 1;
	}

	// Token: 0x0601488C RID: 84108 RVA: 0x005B1F6E File Offset: 0x005B016E
	public void HandleClickLeft()
	{
		this.ChosenLevel--;
	}

	// Token: 0x0601488D RID: 84109 RVA: 0x005B1F7E File Offset: 0x005B017E
	public void HandleClickRight()
	{
		this.ChosenLevel++;
	}

	// Token: 0x0601488E RID: 84110 RVA: 0x005B1F90 File Offset: 0x005B0190
	public ILevelLayoutGridData[] BuildLevelLayoutData(int chosenBreakLevel)
	{
		List<ILevelLayoutGridData> list = new List<ILevelLayoutGridData>();
		RoleLevelData levelData = this.CachedRoleInstance.GetLevelData();
		int breachLevel = levelData.GetBreachLevel();
		for (int i = 0; i < levelData.GetMaxBreachLevel(); i++)
		{
			int num = i + 1;
			list.Add(new LevelLayoutGridData
			{
				IsChosen = (num == chosenBreakLevel),
				IsAvailable = (i < breachLevel),
				LevelContent = num
			});
		}
		return list.ToArray();
	}

	// Token: 0x0601488F RID: 84111 RVA: 0x005B1FFC File Offset: 0x005B01FC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public ISelectedData[] BuildItemLayoutData(int chosenLevel)
	{
		RoleLevelData levelData = this.CachedRoleInstance.GetLevelData();
		bool flag = levelData.GetBreachLevel() >= chosenLevel;
		List<ISelectedData> list = new List<ISelectedData>();
		foreach (KeyValuePair<int, int> keyValuePair in levelData.GetBreachConfig(chosenLevel).Value.BreachConsume())
		{
			if (keyValuePair.Key != 2)
			{
				list.Add(new SelectedData
				{
					ItemId = keyValuePair.Key,
					Count = keyValuePair.Value,
					IncId = 0,
					SelectedCount = (flag ? 0 : ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0)),
					OnlyTextFlag = new bool?(flag)
				});
			}
		}
		return list.ToArray();
	}

	// Token: 0x06014890 RID: 84112 RVA: 0x005B20E0 File Offset: 0x005B02E0
	[NullableContext(2)]
	public ICostContentItemData BuildCostContentItemData(int chosenLevel)
	{
		Dictionary<int, int> dictionary = this.CachedRoleInstance.GetLevelData().GetBreachConfig(chosenLevel).Value.BreachConsume();
		int costNum = 0;
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			if (keyValuePair.Key == 2)
			{
				costNum = keyValuePair.Value;
				break;
			}
		}
		return new CostContentItemData
		{
			CostNum = costNum,
			CostType = EItemId.Gold
		};
	}

	// Token: 0x04009EBF RID: 40639
	[Nullable(2)]
	private RoleBreakPreviewContext CachedViewContextCore;

	// Token: 0x04009EC0 RID: 40640
	[Nullable(2)]
	private CostContentItemContext CachedCostContentItemContextCore;

	// Token: 0x04009EC1 RID: 40641
	[Nullable(2)]
	private RoleDataBase CachedRoleInstanceCore;

	// Token: 0x04009EC2 RID: 40642
	private int ChosenLevelCore = -1;
}
