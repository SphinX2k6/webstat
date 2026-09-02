using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED4 RID: 7892
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemDataBase : IHonamiStoryGridItemData
{
	// Token: 0x0600E9A1 RID: 59809 RVA: 0x003F5BD0 File Offset: 0x003F3DD0
	public virtual void Init(HonamiStoryItemInfo itemInfo)
	{
		this.IncId = itemInfo.IncrId;
		this.ItemId = itemInfo.HonamiStoryItemId;
		this.FuncValue = itemInfo.FuncValue;
		this.ItemType = (EHonamiStoryItemType)this.GetBaseConfig(this.ItemId).Value.ItemType;
	}

	// Token: 0x0600E9A2 RID: 59810 RVA: 0x003F5C23 File Offset: 0x003F3E23
	public bool IsLock()
	{
		return (this.FuncValue & 1) > 0;
	}

	// Token: 0x0600E9A3 RID: 59811 RVA: 0x003F5C30 File Offset: 0x003F3E30
	public void SetIsLock(bool value)
	{
		if (value)
		{
			this.FuncValue |= 1;
			return;
		}
		this.FuncValue &= -2;
	}

	// Token: 0x0600E9A4 RID: 59812 RVA: 0x003F5C53 File Offset: 0x003F3E53
	public HonamiStoryItem? GetBaseConfig(int id)
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItem(this.ItemId);
	}

	// Token: 0x0600E9A5 RID: 59813 RVA: 0x003F5C68 File Offset: 0x003F3E68
	[NullableContext(2)]
	public void UpdatePositionInfo(HonamiStoryPosInfo posInfo)
	{
		if (posInfo == null)
		{
			this.Position = -1;
			this.IsCross = false;
			this.IsDragCross = false;
			this.FillPositionList.Clear();
			return;
		}
		this.Position = posInfo.Position;
		this.IsCross = posInfo.IsCross;
		this.IsDragCross = this.IsCross;
		this.FillPositionList.Clear();
	}

	// Token: 0x0600E9A6 RID: 59814 RVA: 0x003F5CC8 File Offset: 0x003F3EC8
	private void InitGridFillPositionList()
	{
		this.FillPositionList = this.GetGridFillPositionByPosition(this.Position, this.IsCross);
	}

	// Token: 0x0600E9A7 RID: 59815 RVA: 0x003F5CE2 File Offset: 0x003F3EE2
	public void SetBackpackWidth(int width)
	{
		this.BackpackWidth = width;
	}

	// Token: 0x0600E9A8 RID: 59816 RVA: 0x003F5CEB File Offset: 0x003F3EEB
	public int GetItemId()
	{
		return this.ItemId;
	}

	// Token: 0x0600E9A9 RID: 59817 RVA: 0x003F5CF3 File Offset: 0x003F3EF3
	public int GetIncId()
	{
		return this.IncId;
	}

	// Token: 0x0600E9AA RID: 59818 RVA: 0x003F5CFC File Offset: 0x003F3EFC
	public string GetName()
	{
		return this.GetBaseConfig(this.ItemId).Value.Name;
	}

	// Token: 0x0600E9AB RID: 59819 RVA: 0x003F5D28 File Offset: 0x003F3F28
	public int GetQuality()
	{
		if (this.QualityId == -1)
		{
			this.QualityId = this.GetBaseConfig(this.ItemId).Value.QualityId;
		}
		return this.QualityId;
	}

	// Token: 0x0600E9AC RID: 59820 RVA: 0x003F5D68 File Offset: 0x003F3F68
	public HonamiStoryItemQuality? GetQualityConfig()
	{
		HonamiStoryItem? baseConfig = this.GetBaseConfig(this.ItemId);
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(baseConfig.Value.QualityId);
	}

	// Token: 0x0600E9AD RID: 59821 RVA: 0x003F5D9C File Offset: 0x003F3F9C
	public string GetDesc()
	{
		return this.GetBaseConfig(this.ItemId).Value.AttributesDescription;
	}

	// Token: 0x0600E9AE RID: 59822 RVA: 0x003F5DC5 File Offset: 0x003F3FC5
	public EHonamiStoryItemType GetItemType()
	{
		return this.ItemType;
	}

	// Token: 0x0600E9AF RID: 59823 RVA: 0x003F5DD0 File Offset: 0x003F3FD0
	public int GetSellPrice()
	{
		if (this.SellPrice == -1)
		{
			this.SellPrice = this.GetBaseConfig(this.ItemId).Value.SellPrice;
		}
		return this.SellPrice;
	}

	// Token: 0x0600E9B0 RID: 59824 RVA: 0x003F5E10 File Offset: 0x003F4010
	public string GetItemTypeText()
	{
		string result;
		if (Singleton<HonamiStoryDefine>.Instance.honamiItemTypeMap.TryGetValue(this.ItemType, out result))
		{
			return result;
		}
		return "";
	}

	// Token: 0x0600E9B1 RID: 59825 RVA: 0x003F5E40 File Offset: 0x003F4040
	public int GetSubType()
	{
		if (this.SubType == -1)
		{
			this.SubType = this.GetBaseConfig(this.ItemId).Value.SubType;
		}
		return this.SubType;
	}

	// Token: 0x0600E9B2 RID: 59826 RVA: 0x003F5E7E File Offset: 0x003F407E
	public int GetPosition()
	{
		return this.Position;
	}

	// Token: 0x0600E9B3 RID: 59827 RVA: 0x003F5E86 File Offset: 0x003F4086
	public bool GetIsCross()
	{
		return this.IsCross;
	}

	// Token: 0x0600E9B4 RID: 59828 RVA: 0x003F5E8E File Offset: 0x003F408E
	public bool GetIsDragCross()
	{
		return this.IsDragCross;
	}

	// Token: 0x0600E9B5 RID: 59829 RVA: 0x003F5E96 File Offset: 0x003F4096
	public void SetIsDragCross(bool value)
	{
		this.IsDragCross = value;
	}

	// Token: 0x0600E9B6 RID: 59830 RVA: 0x003F5E9F File Offset: 0x003F409F
	public bool GetOldCross()
	{
		return this.OldCross;
	}

	// Token: 0x0600E9B7 RID: 59831 RVA: 0x003F5EA7 File Offset: 0x003F40A7
	public void SetOldCross(bool value)
	{
		this.OldCross = value;
	}

	// Token: 0x0600E9B8 RID: 59832 RVA: 0x003F5EB0 File Offset: 0x003F40B0
	public int GetGridHeight()
	{
		if (this.BaseWidth == -1 || this.BaseHeight == -1)
		{
			HonamiStoryItem? baseConfig = this.GetBaseConfig(this.ItemId);
			this.BaseWidth = baseConfig.Value.GridOccupy(0);
			this.BaseHeight = baseConfig.Value.GridOccupy(1);
		}
		if (!this.IsCross)
		{
			return this.BaseHeight;
		}
		return this.BaseWidth;
	}

	// Token: 0x0600E9B9 RID: 59833 RVA: 0x003F5F20 File Offset: 0x003F4120
	public int GetGridWidth()
	{
		if (this.BaseWidth == -1 || this.BaseHeight == -1)
		{
			HonamiStoryItem? baseConfig = this.GetBaseConfig(this.ItemId);
			this.BaseWidth = baseConfig.Value.GridOccupy(0);
			this.BaseHeight = baseConfig.Value.GridOccupy(1);
		}
		if (!this.IsCross)
		{
			return this.BaseWidth;
		}
		return this.BaseHeight;
	}

	// Token: 0x0600E9BA RID: 59834 RVA: 0x003F5F90 File Offset: 0x003F4190
	public int GetBaseGridHeight(bool isCross)
	{
		if (this.BaseWidth == -1 || this.BaseHeight == -1)
		{
			HonamiStoryItem? baseConfig = this.GetBaseConfig(this.ItemId);
			this.BaseWidth = baseConfig.Value.GridOccupy(0);
			this.BaseHeight = baseConfig.Value.GridOccupy(1);
		}
		if (!isCross)
		{
			return this.BaseHeight;
		}
		return this.BaseWidth;
	}

	// Token: 0x0600E9BB RID: 59835 RVA: 0x003F5FF8 File Offset: 0x003F41F8
	public int GetBaseGridWidth(bool isCross)
	{
		if (this.BaseWidth == -1 || this.BaseHeight == -1)
		{
			HonamiStoryItem? baseConfig = this.GetBaseConfig(this.ItemId);
			this.BaseWidth = baseConfig.Value.GridOccupy(0);
			this.BaseHeight = baseConfig.Value.GridOccupy(1);
		}
		if (!isCross)
		{
			return this.BaseWidth;
		}
		return this.BaseHeight;
	}

	// Token: 0x0600E9BC RID: 59836 RVA: 0x003F6060 File Offset: 0x003F4260
	public int GetRow()
	{
		return (int)Math.Floor((double)this.GetPosition() / (double)this.BackpackWidth);
	}

	// Token: 0x0600E9BD RID: 59837 RVA: 0x003F6077 File Offset: 0x003F4277
	public int GetColumn()
	{
		return this.GetPosition() % this.BackpackWidth;
	}

	// Token: 0x0600E9BE RID: 59838 RVA: 0x003F6086 File Offset: 0x003F4286
	public List<int> GetGridFillPositionList()
	{
		if (this.FillPositionList.Count <= 0)
		{
			this.InitGridFillPositionList();
		}
		return this.FillPositionList;
	}

	// Token: 0x0600E9BF RID: 59839 RVA: 0x003F60A4 File Offset: 0x003F42A4
	public List<int> GetGridFillPositionByPosition(int position, bool isCross)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.GetBaseGridWidth(isCross); i++)
		{
			for (int j = 0; j < this.GetBaseGridHeight(isCross); j++)
			{
				list.Add(position + i + j * this.BackpackWidth);
			}
		}
		return list;
	}

	// Token: 0x0600E9C0 RID: 59840 RVA: 0x003F60F0 File Offset: 0x003F42F0
	public string GetIconTexture()
	{
		return this.GetBaseConfig(this.ItemId).Value.Icon;
	}

	// Token: 0x0600E9C1 RID: 59841 RVA: 0x003F611C File Offset: 0x003F431C
	public string GetIconBackpack()
	{
		return this.GetBaseConfig(this.ItemId).Value.IconBackpack;
	}

	// Token: 0x0600E9C2 RID: 59842 RVA: 0x003F6145 File Offset: 0x003F4345
	public bool GetIsSelected()
	{
		return this.IsSelected;
	}

	// Token: 0x0600E9C3 RID: 59843 RVA: 0x003F614D File Offset: 0x003F434D
	public void SetIsSelected(bool value)
	{
		this.IsSelected = value;
	}

	// Token: 0x0600E9C4 RID: 59844 RVA: 0x003F6156 File Offset: 0x003F4356
	public bool GetNewInBackpack()
	{
		return this.IsNewInBackpack;
	}

	// Token: 0x0600E9C5 RID: 59845 RVA: 0x003F615E File Offset: 0x003F435E
	public void SetNewInBackpack(bool value)
	{
		this.IsNewInBackpack = value;
	}

	// Token: 0x0600E9C6 RID: 59846 RVA: 0x003F6168 File Offset: 0x003F4368
	public int GetTransPosIndex(int oldIndex)
	{
		bool isDragCross = this.IsDragCross;
		int num = (int)Math.Floor((double)oldIndex / (double)this.GetBaseGridHeight(isDragCross));
		return oldIndex % this.GetBaseGridHeight(isDragCross) * this.GetBaseGridWidth(isDragCross) + num;
	}

	// Token: 0x040070B2 RID: 28850
	private int IncId;

	// Token: 0x040070B3 RID: 28851
	private int ItemId;

	// Token: 0x040070B4 RID: 28852
	private EHonamiStoryItemType ItemType = EHonamiStoryItemType.Normal;

	// Token: 0x040070B5 RID: 28853
	protected int Position;

	// Token: 0x040070B6 RID: 28854
	protected int QualityId = -1;

	// Token: 0x040070B7 RID: 28855
	protected int SubType = -1;

	// Token: 0x040070B8 RID: 28856
	protected int SellPrice = -1;

	// Token: 0x040070B9 RID: 28857
	protected bool IsCross;

	// Token: 0x040070BA RID: 28858
	protected bool OldCross;

	// Token: 0x040070BB RID: 28859
	protected bool IsDragCross;

	// Token: 0x040070BC RID: 28860
	protected List<int> FillPositionList = new List<int>();

	// Token: 0x040070BD RID: 28861
	protected int BackpackWidth;

	// Token: 0x040070BE RID: 28862
	protected int FuncValue;

	// Token: 0x040070BF RID: 28863
	protected bool IsSelected;

	// Token: 0x040070C0 RID: 28864
	protected int BaseWidth = -1;

	// Token: 0x040070C1 RID: 28865
	protected int BaseHeight = -1;

	// Token: 0x040070C2 RID: 28866
	protected bool IsNewInBackpack;
}
