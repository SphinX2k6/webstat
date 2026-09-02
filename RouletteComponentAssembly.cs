using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002927 RID: 10535
[NullableContext(1)]
[Nullable(0)]
public class RouletteComponentAssembly : RouletteComponentBase
{
	// Token: 0x06014E97 RID: 85655 RVA: 0x005C9C17 File Offset: 0x005C7E17
	public void RegisterViewProxy(RouletteAssemblyViewProxy viewProxy)
	{
		this.ViewProxy = viewProxy;
	}

	// Token: 0x06014E98 RID: 85656 RVA: 0x005C9C20 File Offset: 0x005C7E20
	protected override bool IsCurrentEquippedId(RouletteData gridData)
	{
		return false;
	}

	// Token: 0x06014E99 RID: 85657 RVA: 0x005C9C23 File Offset: 0x005C7E23
	protected override void GamepadReturnEmptyGrid()
	{
		this.IsEmptyChoose = false;
	}

	// Token: 0x06014E9A RID: 85658 RVA: 0x005C9C2C File Offset: 0x005C7E2C
	protected override EGridBehavior JudgeGridStateByData(int id, ERouletteGridType gridType)
	{
		if (id == 0)
		{
			return EGridBehavior.CanAdd;
		}
		EGridBehavior? egridBehavior = RouletteGridForbiddenSettings.CheckGridSpecialState(ERouletteViewType.Assembly, gridType, id);
		if (egridBehavior != null)
		{
			return egridBehavior.Value;
		}
		return EGridBehavior.Normal;
	}

	// Token: 0x06014E9B RID: 85659 RVA: 0x005C9C5C File Offset: 0x005C7E5C
	protected override void SetCurrentToggleState(bool bSelect)
	{
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		if (currentGrid == null)
		{
			return;
		}
		currentGrid.SetGridToggleNavigation(bSelect);
	}

	// Token: 0x06014E9C RID: 85660 RVA: 0x005C9C6F File Offset: 0x005C7E6F
	protected override void InitGridEvent(RouletteGridBase grid)
	{
		base.InitGridEvent(grid);
		grid.SetGridToggleChangeEvent();
	}

	// Token: 0x06014E9D RID: 85661 RVA: 0x005C9C7E File Offset: 0x005C7E7E
	protected override RouletteData GridDataDecorator(RouletteData data)
	{
		data.State = this.JudgeGridStateByData(data.Id, data.GridType);
		data.ShowIndex = true;
		data.ShowRedDot = false;
		return data;
	}

	// Token: 0x06014E9E RID: 85662 RVA: 0x005C9CA7 File Offset: 0x005C7EA7
	[return: Nullable(new byte[]
	{
		2,
		0,
		1
	})]
	protected override List<ValueTuple<List<int>, ERouletteComponentNode, ERouletteGridType>> GetRouletteInfoMap()
	{
		return this.ViewProxy.GetRouletteDataMap();
	}

	// Token: 0x06014E9F RID: 85663 RVA: 0x005C9CB4 File Offset: 0x005C7EB4
	protected override int GetGridId(int index, ERouletteGridType gridType)
	{
		return this.ViewProxy.GetRouletteGridId(index, gridType);
	}

	// Token: 0x06014EA0 RID: 85664 RVA: 0x005C9CC4 File Offset: 0x005C7EC4
	[NullableContext(2)]
	public RouletteGridBase GetGridByValidId(int id)
	{
		if (id == 0)
		{
			return null;
		}
		foreach (RouletteGridBase rouletteGridBase in this.RouletteGridList)
		{
			if (rouletteGridBase.Data.Id == id)
			{
				return rouletteGridBase;
			}
		}
		return null;
	}

	// Token: 0x06014EA1 RID: 85665 RVA: 0x005C9D2C File Offset: 0x005C7F2C
	public void SetCurrentGridByData(RouletteData data)
	{
		this.CurrentGridIndex = data.GridIndex;
		base.RefreshRouletteComponent();
	}

	// Token: 0x06014EA2 RID: 85666 RVA: 0x005C9D40 File Offset: 0x005C7F40
	public void RefreshCurrentGridData(RouletteData data)
	{
		this.GridDataDecorator(data);
		RouletteGridBase currentGrid = base.GetCurrentGrid();
		if (currentGrid != null)
		{
			currentGrid.RefreshGrid(data);
		}
		base.RefreshRouletteComponent();
	}

	// Token: 0x06014EA3 RID: 85667 RVA: 0x005C9D64 File Offset: 0x005C7F64
	public void DeactivateGridToggleChangeEvent()
	{
		foreach (RouletteGridBase rouletteGridBase in this.RouletteGridList)
		{
			rouletteGridBase.RemoveGridToggleChangeEvent();
		}
	}

	// Token: 0x06014EA4 RID: 85668 RVA: 0x005C9DB4 File Offset: 0x005C7FB4
	[NullableContext(2)]
	public RouletteGridBase GetGridByIndex(int index)
	{
		if (index < 0 || index >= this.RouletteGridList.Count)
		{
			return null;
		}
		return this.RouletteGridList[index];
	}

	// Token: 0x0400A130 RID: 41264
	protected RouletteAssemblyViewProxy ViewProxy;
}
