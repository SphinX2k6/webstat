using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002040 RID: 8256
[NullableContext(1)]
[Nullable(0)]
public class PhantomManageViewModel : PhantomManageViewModelBase<EPhantomManageViewData>
{
	// Token: 0x0600FB87 RID: 64391 RVA: 0x00450DCC File Offset: 0x0044EFCC
	public PhantomManageViewModel()
	{
		HashSet<int> value = new HashSet<int>();
		this.DataMap.Add(EPhantomManageViewData.SelectSet, value);
		List<ItemViewData> value2 = new List<ItemViewData>();
		this.DataMap.Add(EPhantomManageViewData.ItemDataList, value2);
	}

	// Token: 0x0600FB88 RID: 64392 RVA: 0x00450E08 File Offset: 0x0044F008
	public void SetSelectState(int uniqueId, bool add, bool notNotify = false)
	{
		HashSet<int> selectSet = this.GetSelectSet();
		if (add && !selectSet.Contains(uniqueId))
		{
			selectSet.Add(uniqueId);
		}
		else if (!add && selectSet.Contains(uniqueId))
		{
			selectSet.Remove(uniqueId);
		}
		this.SetSelectSet(selectSet, notNotify);
	}

	// Token: 0x0600FB89 RID: 64393 RVA: 0x00450E50 File Offset: 0x0044F050
	public void SwitchSelectState(int uniqueId, bool notNotify = false)
	{
		HashSet<int> selectSet = this.GetSelectSet();
		if (selectSet.Contains(uniqueId))
		{
			selectSet.Remove(uniqueId);
		}
		else
		{
			selectSet.Add(uniqueId);
		}
		this.SetSelectSet(selectSet, notNotify);
	}

	// Token: 0x0600FB8A RID: 64394 RVA: 0x00450E88 File Offset: 0x0044F088
	public HashSet<int> GetSelectSet()
	{
		object data = base.GetData(EPhantomManageViewData.SelectSet);
		if (data == null)
		{
			return new HashSet<int>();
		}
		return data as HashSet<int>;
	}

	// Token: 0x0600FB8B RID: 64395 RVA: 0x00450EAC File Offset: 0x0044F0AC
	[NullableContext(2)]
	private void SetSelectSet(HashSet<int> selectSet, bool notNotify = false)
	{
		base.SetData(EPhantomManageViewData.SelectSet, selectSet, notNotify);
		ModelBase<InventoryModel>.Instance.SetPhantomManageSelectSet(selectSet);
	}

	// Token: 0x0600FB8C RID: 64396 RVA: 0x00450EC2 File Offset: 0x0044F0C2
	public void ClearSelectSet()
	{
		this.SetSelectSet(null, false);
	}

	// Token: 0x0600FB8D RID: 64397 RVA: 0x00450ECC File Offset: 0x0044F0CC
	public void SetItemDataList(ItemViewData[] itemDataList, bool notNotify = false)
	{
		base.SetData(EPhantomManageViewData.ItemDataList, itemDataList, notNotify);
	}

	// Token: 0x0600FB8E RID: 64398 RVA: 0x00450ED7 File Offset: 0x0044F0D7
	public ItemViewData[] GetItemDataList()
	{
		return base.GetData(EPhantomManageViewData.ItemDataList) as ItemViewData[];
	}
}
