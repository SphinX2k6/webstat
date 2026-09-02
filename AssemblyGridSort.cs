using System;
using System.Runtime.CompilerServices;

// Token: 0x02001922 RID: 6434
[NullableContext(1)]
[Nullable(0)]
public class AssemblyGridSort : CommonSort<EAssemblyGridSortWayType>
{
	// Token: 0x0600B909 RID: 47369 RVA: 0x003135F4 File Offset: 0x003117F4
	private int SortConfigIdAscending(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AssemblyGridData assemblyGridData = a as AssemblyGridData;
		if (assemblyGridData == null)
		{
			return 0;
		}
		AssemblyGridData assemblyGridData2 = b as AssemblyGridData;
		if (assemblyGridData2 == null)
		{
			return 0;
		}
		int id = assemblyGridData.Id;
		int id2 = assemblyGridData2.Id;
		return id - id2;
	}

	// Token: 0x0600B90A RID: 47370 RVA: 0x00313628 File Offset: 0x00311828
	private int SortConfigId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AssemblyGridData assemblyGridData = a as AssemblyGridData;
		if (assemblyGridData == null)
		{
			return 0;
		}
		AssemblyGridData assemblyGridData2 = b as AssemblyGridData;
		if (assemblyGridData2 == null)
		{
			return 0;
		}
		int id = assemblyGridData.Id;
		return (assemblyGridData2.Id - id) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B90B RID: 47371 RVA: 0x00313664 File Offset: 0x00311864
	private int SortSortIndex(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AssemblyGridData assemblyGridData = a as AssemblyGridData;
		if (assemblyGridData == null)
		{
			return 0;
		}
		AssemblyGridData assemblyGridData2 = b as AssemblyGridData;
		if (assemblyGridData2 == null)
		{
			return 0;
		}
		int sortId = assemblyGridData.SortId;
		int sortId2 = assemblyGridData2.SortId;
		return (sortId - sortId2) * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B90C RID: 47372 RVA: 0x003136A0 File Offset: 0x003118A0
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AssemblyGridData assemblyGridData = a as AssemblyGridData;
		if (assemblyGridData == null)
		{
			return 0;
		}
		AssemblyGridData assemblyGridData2 = b as AssemblyGridData;
		if (assemblyGridData2 == null)
		{
			return 0;
		}
		int num = 0;
		if (assemblyGridData.GridType == ERouletteGridType.EquipItem)
		{
			AssemblyEquipItemGridData assemblyEquipItemGridData = assemblyGridData as AssemblyEquipItemGridData;
			if (assemblyEquipItemGridData != null)
			{
				AssemblyEquipItemGridData assemblyEquipItemGridData2 = assemblyGridData2 as AssemblyEquipItemGridData;
				if (assemblyEquipItemGridData2 != null)
				{
					int qualityId = assemblyEquipItemGridData.QualityId;
					num = assemblyEquipItemGridData2.QualityId - qualityId;
				}
			}
		}
		return num * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B90D RID: 47373 RVA: 0x00313704 File Offset: 0x00311904
	private int SortCount(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		AssemblyGridData assemblyGridData = a as AssemblyGridData;
		if (assemblyGridData == null)
		{
			return 0;
		}
		AssemblyGridData assemblyGridData2 = b as AssemblyGridData;
		if (assemblyGridData2 == null)
		{
			return 0;
		}
		int num = 0;
		if (assemblyGridData.GridType == ERouletteGridType.EquipItem)
		{
			AssemblyEquipItemGridData assemblyEquipItemGridData = assemblyGridData as AssemblyEquipItemGridData;
			if (assemblyEquipItemGridData != null)
			{
				AssemblyEquipItemGridData assemblyEquipItemGridData2 = assemblyGridData2 as AssemblyEquipItemGridData;
				if (assemblyEquipItemGridData2 != null)
				{
					int itemNum = assemblyEquipItemGridData.ItemNum;
					int itemNum2 = assemblyEquipItemGridData2.ItemNum;
					num = itemNum - itemNum2;
				}
			}
		}
		return num * (isAscending ? -1 : 1);
	}

	// Token: 0x0600B90E RID: 47374 RVA: 0x00313768 File Offset: 0x00311968
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EAssemblyGridSortWayType.ConfigId, new TSortResult(this.SortConfigId));
		this.SortMap.Add(EAssemblyGridSortWayType.ConfigIdAscending, new TSortResult(this.SortConfigIdAscending));
		this.SortMap.Add(EAssemblyGridSortWayType.SortIndex, new TSortResult(this.SortSortIndex));
		this.SortMap.Add(EAssemblyGridSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(EAssemblyGridSortWayType.Count, new TSortResult(this.SortCount));
	}
}
