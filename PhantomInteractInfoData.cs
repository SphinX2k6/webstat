using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020024B4 RID: 9396
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractInfoData
{
	// Token: 0x060123D6 RID: 74710 RVA: 0x00505121 File Offset: 0x00503321
	private int GridSortFunc(IPhantomInteractGridData a, IPhantomInteractGridData b)
	{
		return a.SortId - b.SortId;
	}

	// Token: 0x060123D7 RID: 74711 RVA: 0x00505130 File Offset: 0x00503330
	public void LoadFromProto(PhantomInteractionUnlockNotify proto)
	{
		this.EquippedMonsterIdMap.Clear();
		this.GridItemDataMap.Clear();
		this.EquippedVisionData.Clear();
		this.GridItemDataList.Clear();
		List<int> list = new List<int>();
		foreach (int item in proto.EquipedMonsterIds)
		{
			list.Add(item);
		}
		if (list.Count <= 0)
		{
			list = new List<int>
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
		}
		foreach (int num in list)
		{
			if (num <= 0)
			{
				PhantomInteractItemData phantomInteractItemData = new PhantomInteractItemData();
				phantomInteractItemData.LoadEmpty(this.EquippedVisionData.Count);
				this.EquippedVisionData.Add(phantomInteractItemData);
			}
			else
			{
				PhantomInteractItemData phantomInteractItemData2 = new PhantomInteractItemData();
				int count = this.EquippedVisionData.Count;
				phantomInteractItemData2.LoadData(count, num);
				this.EquippedVisionData.Add(phantomInteractItemData2);
				this.EquippedMonsterIdMap[num] = count;
			}
		}
		foreach (UnlockIllustratedPhantom unlockIllustratedPhantom in proto.UnlockIllustratedPhantoms)
		{
			PhantomInteractGridData phantomInteractGridData = new PhantomInteractGridData();
			int monsterId = unlockIllustratedPhantom.MonsterId;
			int num2;
			int inSlotIndex = this.EquippedMonsterIdMap.TryGetValue(monsterId, out num2) ? num2 : -1;
			phantomInteractGridData.LoadData(unlockIllustratedPhantom);
			phantomInteractGridData.InSlotIndex = inSlotIndex;
			this.GridItemDataList.Add(phantomInteractGridData);
			this.GridItemDataMap[monsterId] = phantomInteractGridData;
		}
	}

	// Token: 0x060123D8 RID: 74712 RVA: 0x00505328 File Offset: 0x00503528
	public void UpdateFromProto(PhantomInteractionInfoUpdateNotify proto)
	{
		UnlockIllustratedPhantom unlockIllustratedPhantom = proto.UnlockIllustratedPhantom;
		if (unlockIllustratedPhantom == null)
		{
			return;
		}
		int monsterId = unlockIllustratedPhantom.MonsterId;
		PhantomInteractGridData phantomInteractGridData;
		if (this.GridItemDataMap.TryGetValue(monsterId, out phantomInteractGridData) && phantomInteractGridData != null)
		{
			return;
		}
		PhantomInteractGridData phantomInteractGridData2 = new PhantomInteractGridData();
		phantomInteractGridData2.LoadData(unlockIllustratedPhantom);
		this.GridItemDataMap[monsterId] = phantomInteractGridData2;
		this.GridItemDataList.Add(phantomInteractGridData2);
		this.GridItemDataList.Sort(new Comparison<IPhantomInteractGridData>(this.GridSortFunc));
	}

	// Token: 0x04008E46 RID: 36422
	public Dictionary<int, int> EquippedMonsterIdMap = new Dictionary<int, int>();

	// Token: 0x04008E47 RID: 36423
	public List<PhantomInteractItemData> EquippedVisionData = new List<PhantomInteractItemData>();

	// Token: 0x04008E48 RID: 36424
	public List<IPhantomInteractGridData> GridItemDataList = new List<IPhantomInteractGridData>();

	// Token: 0x04008E49 RID: 36425
	public Dictionary<int, PhantomInteractGridData> GridItemDataMap = new Dictionary<int, PhantomInteractGridData>();
}
