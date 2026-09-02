using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Manufacture.Compose;

// Token: 0x0200192F RID: 6447
[NullableContext(1)]
[Nullable(0)]
public class ComposeStructureSort : CommonSort<EComposeStructureSortWayType>
{
	// Token: 0x0600B92E RID: 47406 RVA: 0x00313F54 File Offset: 0x00312154
	private int SortMenu(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IStructureData structureData = a as IStructureData;
		if (structureData == null)
		{
			return 0;
		}
		IStructureData structureData2 = b as IStructureData;
		if (structureData2 == null)
		{
			return 0;
		}
		if (structureData.SubType != structureData2.SubType)
		{
			return (structureData2.SubType - structureData.SubType) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B92F RID: 47407 RVA: 0x00313FA0 File Offset: 0x003121A0
	private int SortMake(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IStructureData structureData = a as IStructureData;
		if (structureData == null)
		{
			return 0;
		}
		IStructureData structureData2 = b as IStructureData;
		if (structureData2 == null)
		{
			return 0;
		}
		int isUnlock = structureData.IsUnlock;
		int isUnlock2 = structureData2.IsUnlock;
		if (isUnlock != isUnlock2)
		{
			if (!isAscending)
			{
				return isUnlock - isUnlock2;
			}
			return isUnlock2 - isUnlock;
		}
		else
		{
			int num = (!ModelBase<ComposeModel>.Instance.CheckBaseItemData(structureData, EBaseItemDataCheckMask.All)) ? 1 : 0;
			int num2 = (!ModelBase<ComposeModel>.Instance.CheckBaseItemData(structureData2, EBaseItemDataCheckMask.All)) ? 1 : 0;
			if (num != num2)
			{
				return num - num2;
			}
			return structureData.SortId - structureData2.SortId;
		}
	}

	// Token: 0x0600B930 RID: 47408 RVA: 0x00314028 File Offset: 0x00312228
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IStructureData structureData = a as IStructureData;
		if (structureData == null)
		{
			return 0;
		}
		IStructureData structureData2 = b as IStructureData;
		if (structureData2 == null)
		{
			return 0;
		}
		if (structureData2.IsUnlock != structureData.IsUnlock)
		{
			int num = structureData2.IsUnlock - structureData.IsUnlock;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			if (structureData.Quality != structureData2.Quality)
			{
				return (structureData2.Quality - structureData.Quality) * (isAscending ? -1 : 1);
			}
			return structureData.SortId - structureData2.SortId;
		}
	}

	// Token: 0x0600B931 RID: 47409 RVA: 0x003140A4 File Offset: 0x003122A4
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(EComposeStructureSortWayType.Menu, new TSortResult(this.SortMenu));
		this.SortMap.Add(EComposeStructureSortWayType.Make, new TSortResult(this.SortMake));
		this.SortMap.Add(EComposeStructureSortWayType.Quality, new TSortResult(this.SortQuality));
	}
}
