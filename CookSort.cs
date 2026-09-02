using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Cook;

// Token: 0x02001931 RID: 6449
[NullableContext(1)]
[Nullable(0)]
public class CookSort : CommonSort<ECookSortWayType>
{
	// Token: 0x0600B933 RID: 47411 RVA: 0x00314104 File Offset: 0x00312304
	private int SortMenu(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ICookingData cookingData = a as ICookingData;
		ICookingData cookingData2 = b as ICookingData;
		if (cookingData.SubType != cookingData2.SubType)
		{
			return (cookingData2.SubType - cookingData.SubType) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B934 RID: 47412 RVA: 0x00314144 File Offset: 0x00312344
	private int SortMake(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ICookingData cookingData = a as ICookingData;
		ICookingData cookingData2 = b as ICookingData;
		if (cookingData2.IsUnLock != cookingData.IsUnLock)
		{
			int num = cookingData2.IsUnLock ? 1 : -1;
			if (!isAscending)
			{
				return -num;
			}
			return num;
		}
		else
		{
			if (cookingData2.IsCook == cookingData.IsCook)
			{
				return 0;
			}
			int num2 = cookingData2.IsCook - cookingData.IsCook;
			if (!isAscending)
			{
				return -num2;
			}
			return num2;
		}
	}

	// Token: 0x0600B935 RID: 47413 RVA: 0x003141A8 File Offset: 0x003123A8
	private int SortMakeMachining(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		IMachiningData machiningData = a as IMachiningData;
		IMachiningData machiningData2 = b as IMachiningData;
		int num = 0;
		if (machiningData.IsUnLock == machiningData2.IsUnLock)
		{
			num = machiningData2.IsMachining - machiningData.IsMachining;
		}
		else if (machiningData.IsUnLock)
		{
			num = -1;
		}
		else if (machiningData2.IsUnLock)
		{
			num = 1;
		}
		return isAscending ? num : (num * -1);
	}

	// Token: 0x0600B936 RID: 47414 RVA: 0x00314204 File Offset: 0x00312404
	private int SortQuality(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ICookItemData cookItemData = a as ICookItemData;
		ICookItemData cookItemData2 = b as ICookItemData;
		if (cookItemData.Quality != cookItemData2.Quality)
		{
			return (cookItemData2.Quality - cookItemData.Quality) * (isAscending ? -1 : 1);
		}
		return 0;
	}

	// Token: 0x0600B937 RID: 47415 RVA: 0x00314244 File Offset: 0x00312444
	private int SortItemId(object a, object b, bool isAscending, [Nullable(new byte[]
	{
		2,
		1
	})] object[] param = null)
	{
		ICookItemData cookItemData = a as ICookItemData;
		ICookItemData cookItemData2 = b as ICookItemData;
		if (cookItemData.ItemId != cookItemData2.ItemId)
		{
			return cookItemData.ItemId - cookItemData2.ItemId;
		}
		return 0;
	}

	// Token: 0x0600B938 RID: 47416 RVA: 0x0031427C File Offset: 0x0031247C
	protected override void OnInitSortMap()
	{
		this.SortMap.Add(ECookSortWayType.Menu, new TSortResult(this.SortMenu));
		this.SortMap.Add(ECookSortWayType.MakeMachining, new TSortResult(this.SortMakeMachining));
		this.SortMap.Add(ECookSortWayType.Quality, new TSortResult(this.SortQuality));
		this.SortMap.Add(ECookSortWayType.ItemId, new TSortResult(this.SortItemId));
		this.SortMap.Add(ECookSortWayType.Make, new TSortResult(this.SortMake));
	}
}
