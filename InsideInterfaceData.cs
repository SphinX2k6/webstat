using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002057 RID: 8279
[NullableContext(1)]
[Nullable(0)]
public class InsideInterfaceData
{
	// Token: 0x0600FC2B RID: 64555 RVA: 0x00454951 File Offset: 0x00452B51
	public void Clear()
	{
		this.CurIndex = 0;
		this.InterfaceDataUnitArray = new List<InterfaceDataUnit>();
	}

	// Token: 0x0600FC2C RID: 64556 RVA: 0x00454965 File Offset: 0x00452B65
	public bool IsEmpty()
	{
		return this.CurUnit == null || this.CurUnit.WaitList.Count <= 0;
	}

	// Token: 0x0600FC2D RID: 64557 RVA: 0x00454988 File Offset: 0x00452B88
	[NullableContext(2)]
	public ItemRewardInfo ShiftFirstData()
	{
		if (this.CurUnit == null)
		{
			return null;
		}
		if (this.CurUnit.WaitList.Count > 0)
		{
			ItemRewardInfo result = this.CurUnit.WaitList[0];
			this.CurUnit.WaitList.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x0600FC2E RID: 64558 RVA: 0x004549D8 File Offset: 0x00452BD8
	public int GetMaxCount()
	{
		if (this.CurUnit == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.ItemHint, ELogAuthor.ZJC, "里列表当前单元无效!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		return this.CurUnit.GetMaxCount();
	}

	// Token: 0x0600FC2F RID: 64559 RVA: 0x00454A18 File Offset: 0x00452C18
	public int GetAddItemTime()
	{
		if (this.CurUnit == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.ItemHint, ELogAuthor.ZJC, "里列表当前单元无效!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		return this.CurUnit.GetAddItemTime();
	}

	// Token: 0x0600FC30 RID: 64560 RVA: 0x00454A55 File Offset: 0x00452C55
	public void PostBattleViewOpen()
	{
		this.UpdateIndex();
		this.UpdateAllUnitMode();
	}

	// Token: 0x0600FC31 RID: 64561 RVA: 0x00454A63 File Offset: 0x00452C63
	private void UpdateIndex()
	{
		this.CurIndex++;
	}

	// Token: 0x0600FC32 RID: 64562 RVA: 0x00454A74 File Offset: 0x00452C74
	private void UpdateAllUnitMode()
	{
		foreach (InterfaceDataUnit interfaceDataUnit in this.InterfaceDataUnitArray)
		{
			interfaceDataUnit.Mode = EPlayMode.Fast;
		}
	}

	// Token: 0x0600FC33 RID: 64563 RVA: 0x00454AC8 File Offset: 0x00452CC8
	public void ShiftFirstUnit()
	{
		if (this.CurUnit == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.ItemHint, ELogAuthor.XXJ, "里列表关闭时没有数据可以拿", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurUnit.WaitList.Count > 0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.ItemHint, ELogAuthor.ZJC, "里列表关闭时, 还有数据在队列中未开始播放!", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (this.InterfaceDataUnitArray.Count > 0)
		{
			this.InterfaceDataUnitArray.RemoveAt(0);
		}
		this.CurUnit = null;
		this.UpdateCurUnit();
	}

	// Token: 0x0600FC34 RID: 64564 RVA: 0x00454B50 File Offset: 0x00452D50
	public void InsertItemRewardInfo(AddCountItemInfo[] addCountItemInfo)
	{
		InterfaceDataUnit interfaceDataUnit = this.FindOrAddUnit();
		foreach (AddCountItemInfo addCountItemInfo2 in addCountItemInfo)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(addCountItemInfo2.Id);
			if (itemConfigData != null && itemConfigData.ShowInBag)
			{
				ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
				itemRewardInfo.ItemCount = new int?(addCountItemInfo2.Count);
				itemRewardInfo.ItemId = new int?(addCountItemInfo2.Id);
				itemRewardInfo.Quality = itemConfigData.QualityId;
				interfaceDataUnit.WaitList.Add(itemRewardInfo);
			}
		}
		this.UpdateCurUnit();
	}

	// Token: 0x0600FC35 RID: 64565 RVA: 0x00454BE3 File Offset: 0x00452DE3
	private void UpdateCurUnit()
	{
		if (this.CurUnit == null && this.InterfaceDataUnitArray.Count > 0)
		{
			this.CurUnit = this.InterfaceDataUnitArray[0];
		}
	}

	// Token: 0x0600FC36 RID: 64566 RVA: 0x00454C10 File Offset: 0x00452E10
	private InterfaceDataUnit FindOrAddUnit()
	{
		foreach (InterfaceDataUnit interfaceDataUnit in this.InterfaceDataUnitArray)
		{
			if (interfaceDataUnit.Index == this.CurIndex)
			{
				return interfaceDataUnit;
			}
		}
		InterfaceDataUnit interfaceDataUnit2 = new InterfaceDataUnit(this.CurIndex);
		this.InterfaceDataUnitArray.Add(interfaceDataUnit2);
		return interfaceDataUnit2;
	}

	// Token: 0x0400790A RID: 30986
	private int CurIndex;

	// Token: 0x0400790B RID: 30987
	[Nullable(2)]
	private InterfaceDataUnit CurUnit;

	// Token: 0x0400790C RID: 30988
	private List<InterfaceDataUnit> InterfaceDataUnitArray = new List<InterfaceDataUnit>();
}
