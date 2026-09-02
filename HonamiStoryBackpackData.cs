using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED1 RID: 7889
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryBackpackData : IHonamiStoryBackpackData
{
	// Token: 0x0600E96B RID: 59755 RVA: 0x003F4E54 File Offset: 0x003F3054
	public void Init(HonamiStoryBagInfo bagInfo)
	{
		this.Width = bagInfo.Width;
		this.Capacity = bagInfo.BagSize;
		this.ClearBackpack();
		this.SelfBackpackId = bagInfo.BagConfigId;
		this.SelfBackpackType = (EHonamiStoryBackpackType)ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBackPack(bagInfo.BagConfigId).Value.Type;
		this.InitData(bagInfo.HonamiStoryBagItemInfos.ToList<HonamiStoryBagItemInfo>());
	}

	// Token: 0x0600E96C RID: 59756 RVA: 0x003F4EC4 File Offset: 0x003F30C4
	private void InitData(List<HonamiStoryBagItemInfo> itemInfo)
	{
		foreach (HonamiStoryBagItemInfo itemInfo2 in itemInfo)
		{
			this.UpdateItemData(itemInfo2);
		}
		this.RefreshOverflowCapacity();
	}

	// Token: 0x0600E96D RID: 59757 RVA: 0x003F4F1C File Offset: 0x003F311C
	public void Update(List<HonamiStoryBagItemInfo> updateInfo)
	{
		foreach (HonamiStoryBagItemInfo itemInfo in updateInfo)
		{
			HonamiStoryItemDataBase honamiStoryItemDataBase = this.UpdateItemData(itemInfo);
			if (honamiStoryItemDataBase != null)
			{
				honamiStoryItemDataBase.SetNewInBackpack(true);
			}
		}
		this.RefreshOverflowCapacity();
	}

	// Token: 0x0600E96E RID: 59758 RVA: 0x003F4F80 File Offset: 0x003F3180
	[return: Nullable(2)]
	private HonamiStoryItemDataBase UpdateItemData(HonamiStoryBagItemInfo itemInfo)
	{
		HonamiStoryItemDataBase honamiStoryItemDataBase = null;
		HonamiStoryItemDataBase honamiStoryItemDataBase2;
		if (this.ItemMap.TryGetValue(itemInfo.HonamiStoryItemInfo.IncrId, out honamiStoryItemDataBase2))
		{
			honamiStoryItemDataBase = honamiStoryItemDataBase2;
			foreach (int num in honamiStoryItemDataBase.GetGridFillPositionList())
			{
				this.ItemPosMap.Remove(num);
				this.EmptyGridSet.Add(num);
			}
			honamiStoryItemDataBase.Init(itemInfo.HonamiStoryItemInfo);
			honamiStoryItemDataBase.UpdatePositionInfo(itemInfo.HonamiStoryPosInfo);
		}
		else
		{
			honamiStoryItemDataBase = ModelBase<HonamiStoryModel>.Instance.CreateHonamiStoryItemData(itemInfo.HonamiStoryItemInfo, itemInfo.HonamiStoryPosInfo);
		}
		honamiStoryItemDataBase.SetBackpackWidth(this.Width);
		this.RefreshItemMapByAddItem(honamiStoryItemDataBase);
		return honamiStoryItemDataBase;
	}

	// Token: 0x0600E96F RID: 59759 RVA: 0x003F504C File Offset: 0x003F324C
	protected void RefreshItemMapByAddItem(HonamiStoryItemDataBase itemData)
	{
		foreach (int num in itemData.GetGridFillPositionList())
		{
			this.ItemPosMap[num] = itemData;
			this.EmptyGridSet.Remove(num);
		}
		this.ItemList.Add(itemData);
		this.ItemMap[itemData.GetIncId()] = itemData;
	}

	// Token: 0x0600E970 RID: 59760 RVA: 0x003F50D0 File Offset: 0x003F32D0
	public void UpdateByContext(List<HonamiStoryBagUpdateInfo> updateInfoList)
	{
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo in updateInfoList)
		{
			if (honamiStoryBagUpdateInfo.Type != 0)
			{
				this.RemoveItemData(honamiStoryBagUpdateInfo);
			}
		}
		foreach (HonamiStoryBagUpdateInfo honamiStoryBagUpdateInfo2 in updateInfoList)
		{
			if (honamiStoryBagUpdateInfo2.Type != 2)
			{
				this.AddItemData(honamiStoryBagUpdateInfo2);
			}
		}
	}

	// Token: 0x0600E971 RID: 59761 RVA: 0x003F516C File Offset: 0x003F336C
	public void AddItemData(HonamiStoryBagUpdateInfo updateInfo)
	{
		HonamiStoryItemDataBase itemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(updateInfo.ItemIncrId);
		itemData.UpdatePositionInfo(updateInfo.HonamiStoryPosInfo);
		itemData.SetBackpackWidth(this.Width);
		this.RefreshItemMapByAddItem(itemData);
	}

	// Token: 0x0600E972 RID: 59762 RVA: 0x003F51AC File Offset: 0x003F33AC
	private void RemoveItemData(HonamiStoryBagUpdateInfo updateInfo)
	{
		HonamiStoryItemDataBase itemDataByInstanceId = this.GetItemDataByInstanceId(updateInfo.ItemIncrId, true);
		foreach (int num in itemDataByInstanceId.GetGridFillPositionByPosition(updateInfo.OriHonamiStoryPosInfo.Position, updateInfo.OriHonamiStoryPosInfo.IsCross))
		{
			this.ItemPosMap.Remove(num);
			this.EmptyGridSet.Add(num);
		}
		this.ItemList.Remove(itemDataByInstanceId);
		this.ItemMap.Remove(itemDataByInstanceId.GetIncId());
	}

	// Token: 0x0600E973 RID: 59763 RVA: 0x003F5258 File Offset: 0x003F3458
	public virtual bool PushItemData(HonamiStoryItemDataBase itemData)
	{
		return false;
	}

	// Token: 0x0600E974 RID: 59764 RVA: 0x003F525C File Offset: 0x003F345C
	public void ClearBackpack()
	{
		foreach (KeyValuePair<int, HonamiStoryItemDataBase> keyValuePair in this.ItemMap)
		{
			ModelBase<HonamiStoryModel>.Instance.RemoveItemData(keyValuePair.Key);
		}
		this.EmptyGridSet.Clear();
		for (int i = 0; i < this.GetCapacity(); i++)
		{
			this.EmptyGridSet.Add(i);
		}
		this.OverflowCapacity = 0;
		this.ItemList.Clear();
		this.ItemMap.Clear();
		this.ItemPosMap.Clear();
	}

	// Token: 0x170011ED RID: 4589
	// (get) Token: 0x0600E975 RID: 59765 RVA: 0x003F530C File Offset: 0x003F350C
	public int BackpackId
	{
		get
		{
			return this.SelfBackpackId;
		}
	}

	// Token: 0x170011EE RID: 4590
	// (get) Token: 0x0600E976 RID: 59766 RVA: 0x003F5314 File Offset: 0x003F3514
	public EHonamiStoryBackpackType BackpackType
	{
		get
		{
			return this.SelfBackpackType;
		}
	}

	// Token: 0x0600E977 RID: 59767 RVA: 0x003F531C File Offset: 0x003F351C
	public List<HonamiStoryItemDataBase> GetItemDataList()
	{
		List<HonamiStoryItemDataBase> list = new List<HonamiStoryItemDataBase>();
		foreach (HonamiStoryItemDataBase item in this.ItemList)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600E978 RID: 59768 RVA: 0x003F5378 File Offset: 0x003F3578
	[NullableContext(2)]
	public HonamiStoryItemDataBase GetItemDataByInstanceId(int instanceId, bool needLog = true)
	{
		HonamiStoryItemDataBase result;
		if (this.ItemMap.TryGetValue(instanceId, out result))
		{
			return result;
		}
		if (needLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.HonamiStory;
			ELogAuthor author = ELogAuthor.BB;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ItemDataMap not found instanceId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(instanceId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return null;
	}

	// Token: 0x0600E979 RID: 59769 RVA: 0x003F53DC File Offset: 0x003F35DC
	[NullableContext(2)]
	public HonamiStoryItemDataBase GetItemDataByPosition(int position)
	{
		HonamiStoryItemDataBase result;
		if (this.ItemPosMap.TryGetValue(position, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600E97A RID: 59770 RVA: 0x003F53FC File Offset: 0x003F35FC
	public int GetWidthCount()
	{
		return this.Width;
	}

	// Token: 0x0600E97B RID: 59771 RVA: 0x003F5404 File Offset: 0x003F3604
	public int GetHeightCount()
	{
		return this.GetHeightCount(false);
	}

	// Token: 0x0600E97C RID: 59772 RVA: 0x003F540D File Offset: 0x003F360D
	public int GetHeightCount(bool needOverflow = false)
	{
		return (int)Math.Floor((double)(needOverflow ? (this.GetCapacity() + this.OverflowCapacity) : this.GetCapacity()) / (double)this.GetWidthCount());
	}

	// Token: 0x0600E97D RID: 59773 RVA: 0x003F5436 File Offset: 0x003F3636
	public int GetCellWidth()
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return 134;
		}
		return 86;
	}

	// Token: 0x0600E97E RID: 59774 RVA: 0x003F5447 File Offset: 0x003F3647
	public int GetCellHeight()
	{
		if (HonamiStoryUtil.IsMobileView())
		{
			return 134;
		}
		return 86;
	}

	// Token: 0x0600E97F RID: 59775 RVA: 0x003F5458 File Offset: 0x003F3658
	public int GetCellHorizontalInterval()
	{
		HonamiStoryUtil.IsMobileView();
		return 2;
	}

	// Token: 0x0600E980 RID: 59776 RVA: 0x003F5461 File Offset: 0x003F3661
	public int GetCellVerticalInterval()
	{
		HonamiStoryUtil.IsMobileView();
		return 2;
	}

	// Token: 0x0600E981 RID: 59777 RVA: 0x003F546A File Offset: 0x003F366A
	public void SetCapacity(int value)
	{
		this.Capacity = value;
	}

	// Token: 0x0600E982 RID: 59778 RVA: 0x003F5473 File Offset: 0x003F3673
	public int GetCapacity()
	{
		return this.Capacity;
	}

	// Token: 0x0600E983 RID: 59779 RVA: 0x003F547B File Offset: 0x003F367B
	public int GetOverflowCapacity()
	{
		return this.OverflowCapacity;
	}

	// Token: 0x0600E984 RID: 59780 RVA: 0x003F5484 File Offset: 0x003F3684
	public int RefreshOverflowCapacity()
	{
		if (this.BackpackType != EHonamiStoryBackpackType.Inventory)
		{
			this.OverflowCapacity = 0;
			return 0;
		}
		int num = this.Capacity / this.Width;
		int overflowCapacity = this.OverflowCapacity;
		int num2 = 0;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.ItemList)
		{
			int num3 = (int)Math.Floor((double)honamiStoryItemDataBase.GetPosition() / (double)this.Width);
			if (num3 + honamiStoryItemDataBase.GetGridHeight() > num)
			{
				num2 = Math.Max(num2, num3 + honamiStoryItemDataBase.GetGridHeight() - num);
				foreach (int num4 in honamiStoryItemDataBase.GetGridFillPositionList())
				{
					if (num4 >= this.Capacity)
					{
						hashSet.Add(num4);
					}
				}
			}
		}
		this.OverflowCapacity = num2 * this.Width;
		int capacity = this.GetCapacity();
		if (overflowCapacity > this.OverflowCapacity)
		{
			for (int i = this.OverflowCapacity; i < overflowCapacity; i++)
			{
				this.EmptyGridSet.Remove(capacity + i);
			}
		}
		else
		{
			for (int j = overflowCapacity; j < this.OverflowCapacity; j++)
			{
				if (!hashSet.Contains(capacity + j))
				{
					this.EmptyGridSet.Add(capacity + j);
				}
			}
		}
		return this.OverflowCapacity;
	}

	// Token: 0x0600E985 RID: 59781 RVA: 0x003F5610 File Offset: 0x003F3810
	public int GetOccupy()
	{
		int num = 0;
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.ItemList)
		{
			num += honamiStoryItemDataBase.GetGridHeight() * honamiStoryItemDataBase.GetGridWidth();
		}
		return num;
	}

	// Token: 0x0600E986 RID: 59782 RVA: 0x003F5670 File Offset: 0x003F3870
	public int GetTotalValue()
	{
		int num = 0;
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.ItemList)
		{
			num += honamiStoryItemDataBase.GetSellPrice();
		}
		return num;
	}

	// Token: 0x0600E987 RID: 59783 RVA: 0x003F56C8 File Offset: 0x003F38C8
	public bool CheckIsNewInBackpack()
	{
		using (List<HonamiStoryItemDataBase>.Enumerator enumerator = this.ItemList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetNewInBackpack())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E988 RID: 59784 RVA: 0x003F5724 File Offset: 0x003F3924
	public void ClearNewInBackpack()
	{
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.ItemList)
		{
			if (honamiStoryItemDataBase.GetNewInBackpack())
			{
				honamiStoryItemDataBase.SetNewInBackpack(false);
			}
		}
	}

	// Token: 0x0600E989 RID: 59785 RVA: 0x003F5780 File Offset: 0x003F3980
	public HashSet<int> GetEmptyGridSet()
	{
		return this.EmptyGridSet;
	}

	// Token: 0x0400709E RID: 28830
	protected int Width;

	// Token: 0x0400709F RID: 28831
	protected int Capacity;

	// Token: 0x040070A0 RID: 28832
	private int OverflowCapacity;

	// Token: 0x040070A1 RID: 28833
	protected EHonamiStoryBackpackType SelfBackpackType;

	// Token: 0x040070A2 RID: 28834
	protected int SelfBackpackId = -1;

	// Token: 0x040070A3 RID: 28835
	protected List<HonamiStoryItemDataBase> ItemList = new List<HonamiStoryItemDataBase>();

	// Token: 0x040070A4 RID: 28836
	private readonly Dictionary<int, HonamiStoryItemDataBase> ItemMap = new Dictionary<int, HonamiStoryItemDataBase>();

	// Token: 0x040070A5 RID: 28837
	protected Dictionary<int, HonamiStoryItemDataBase> ItemPosMap = new Dictionary<int, HonamiStoryItemDataBase>();

	// Token: 0x040070A6 RID: 28838
	protected HashSet<int> EmptyGridSet = new HashSet<int>();
}
