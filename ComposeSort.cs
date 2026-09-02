using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Manufacture.Compose;

// Token: 0x0200192D RID: 6445
[NullableContext(1)]
[Nullable(0)]
public class ComposeSort : CommonSort<EComposeSortWayType>
{
	// Token: 0x0600B929 RID: 47401 RVA: 0x00313DA0 File Offset: 0x00311FA0
	private int SortMenu(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IReagentProductionData reagentProductionData = a as IReagentProductionData;
		if (reagentProductionData == null)
		{
			return 0;
		}
		IReagentProductionData reagentProductionData2 = b as IReagentProductionData;
		if (reagentProductionData2 == null)
		{
			return 0;
		}
		if (reagentProductionData.SubType != reagentProductionData2.SubType)
		{
			return (reagentProductionData2.SubType - reagentProductionData.SubType) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B92A RID: 47402 RVA: 0x00313DEC File Offset: 0x00311FEC
	private int SortMake(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IReagentProductionData reagentProductionData = a as IReagentProductionData;
		if (reagentProductionData == null)
		{
			return 0;
		}
		IReagentProductionData reagentProductionData2 = b as IReagentProductionData;
		if (reagentProductionData2 == null)
		{
			return 0;
		}
		if (reagentProductionData2.IsUnlock != reagentProductionData.IsUnlock)
		{
			int num = reagentProductionData2.IsUnlock - reagentProductionData.IsUnlock;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			int num2 = (!ModelBase<ComposeModel>.Instance.CheckBaseItemData(reagentProductionData, EBaseItemDataCheckMask.All)) ? 1 : 0;
			int num3 = (!ModelBase<ComposeModel>.Instance.CheckBaseItemData(reagentProductionData2, EBaseItemDataCheckMask.All)) ? 1 : 0;
			if (num2 != num3)
			{
				return num2 - num3;
			}
			return reagentProductionData.SortId - reagentProductionData2.SortId;
		}
	}

	// Token: 0x0600B92B RID: 47403 RVA: 0x00313E78 File Offset: 0x00312078
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IReagentProductionData reagentProductionData = a as IReagentProductionData;
		if (reagentProductionData == null)
		{
			return 0;
		}
		IReagentProductionData reagentProductionData2 = b as IReagentProductionData;
		if (reagentProductionData2 == null)
		{
			return 0;
		}
		if (reagentProductionData2.IsUnlock != reagentProductionData.IsUnlock)
		{
			int num = reagentProductionData2.IsUnlock - reagentProductionData.IsUnlock;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			if (reagentProductionData.Quality != reagentProductionData2.Quality)
			{
				return (reagentProductionData2.Quality - reagentProductionData.Quality) * (isAscending ? -1 : 1);
			}
			return reagentProductionData.SortId - reagentProductionData2.SortId;
		}
	}

	// Token: 0x0600B92C RID: 47404 RVA: 0x00313EF4 File Offset: 0x003120F4
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EComposeSortWayType.Menu, new TSortResult(this.SortMenu));
		this.SortMap.Add(EComposeSortWayType.Make, new TSortResult(this.SortMake));
		this.SortMap.Add(EComposeSortWayType.Quality, new TSortResult(this.SortQuality));
	}
}
