using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020012F2 RID: 4850
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyGridData
{
	// Token: 0x06008348 RID: 33608 RVA: 0x0022AE17 File Offset: 0x00229017
	public static DangoMonopolyGridData Create(DangoMonopolyGrid config, int index, DangoMonopolyBoardData board)
	{
		DangoMonopolyGridData dangoMonopolyGridData = new DangoMonopolyGridData(config.GridId, index, board);
		dangoMonopolyGridData.Init(config);
		return dangoMonopolyGridData;
	}

	// Token: 0x06008349 RID: 33609 RVA: 0x0022AE2E File Offset: 0x0022902E
	private DangoMonopolyGridData(int id, int index, DangoMonopolyBoardData board)
	{
		this.Id = id;
		this.Index = index;
		this.BelongBoard = board;
	}

	// Token: 0x0600834A RID: 33610 RVA: 0x0022AE58 File Offset: 0x00229058
	private void Init(DangoMonopolyGrid config)
	{
		this.GroupId = config.GridGroupId;
		this.AddPropertyId = config.AddPropertyId;
		this.RemovePropertyId = config.RemovePropertyId;
		this.GridInfo = config.GridInfo();
		if (this.GridInfo.Length == 0)
		{
			return;
		}
		this.GridType = (EDangoMonopolyGridType)this.GridInfo[0];
		switch (this.GridType)
		{
		case EDangoMonopolyGridType.Empty:
			break;
		case EDangoMonopolyGridType.Item:
			this.ItemId = ((this.GridInfo.Length > 1) ? this.GridInfo[1] : 0);
			this.ItemCount = ((this.GridInfo.Length > 2) ? this.GridInfo[2] : 0);
			break;
		case EDangoMonopolyGridType.Dango:
			this.DangoId = ((this.GridInfo.Length > 1) ? this.GridInfo[1] : 0);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600834B RID: 33611 RVA: 0x0022AF20 File Offset: 0x00229120
	public bool IsGreaterIndex(int index)
	{
		return this.Index > index;
	}

	// Token: 0x0600834C RID: 33612 RVA: 0x0022AF2B File Offset: 0x0022912B
	public bool IsEqualIndex(int index)
	{
		return this.Index == index;
	}

	// Token: 0x0600834D RID: 33613 RVA: 0x0022AF36 File Offset: 0x00229136
	public bool IsLessIndex(int index)
	{
		return this.Index < index;
	}

	// Token: 0x0600834E RID: 33614 RVA: 0x0022AF41 File Offset: 0x00229141
	public bool IsExistDango()
	{
		return this.GridType == EDangoMonopolyGridType.Dango;
	}

	// Token: 0x0600834F RID: 33615 RVA: 0x0022AF4C File Offset: 0x0022914C
	public bool IsExistItem()
	{
		return this.GridType == EDangoMonopolyGridType.Item;
	}

	// Token: 0x06008350 RID: 33616 RVA: 0x0022AF57 File Offset: 0x00229157
	public bool IsExistEmpty()
	{
		return this.GridType == EDangoMonopolyGridType.Empty;
	}

	// Token: 0x06008351 RID: 33617 RVA: 0x0022AF62 File Offset: 0x00229162
	public int GetPosition()
	{
		return this.Index + 1;
	}

	// Token: 0x06008352 RID: 33618 RVA: 0x0022AF6C File Offset: 0x0022916C
	[NullableContext(2)]
	public DangoData GetDangoData()
	{
		if (this.IsExistDango())
		{
			return Singleton<DangoManager>.Instance.GetDangoData(this.DangoId);
		}
		return null;
	}

	// Token: 0x06008353 RID: 33619 RVA: 0x0022AF88 File Offset: 0x00229188
	public DangoMonopolyProperty? GetAddPropertyConfig()
	{
		if (this.AddPropertyId == 0)
		{
			return null;
		}
		ActivityDangoMonopolyConfig instance = ConfigBase<ActivityDangoMonopolyConfig>.Instance;
		if (instance == null)
		{
			return null;
		}
		return instance.GetProperty(this.AddPropertyId);
	}

	// Token: 0x06008354 RID: 33620 RVA: 0x0022AFC8 File Offset: 0x002291C8
	public EDangoMonopolyBuffType GetAddPropertyType()
	{
		DangoMonopolyProperty? addPropertyConfig = this.GetAddPropertyConfig();
		if (addPropertyConfig == null)
		{
			return EDangoMonopolyBuffType.None;
		}
		return (EDangoMonopolyBuffType)addPropertyConfig.Value.PropertyInfo()[0];
	}

	// Token: 0x06008355 RID: 33621 RVA: 0x0022AFF8 File Offset: 0x002291F8
	public bool IsAddPropertyType(EDangoMonopolyBuffType buffType)
	{
		return this.GetAddPropertyType() == buffType;
	}

	// Token: 0x06008356 RID: 33622 RVA: 0x0022B003 File Offset: 0x00229203
	public bool PropertyIsDouble()
	{
		return this.IsAddPropertyType(EDangoMonopolyBuffType.RewardDouble);
	}

	// Token: 0x06008357 RID: 33623 RVA: 0x0022B00C File Offset: 0x0022920C
	public bool IsFinish()
	{
		return this.BelongBoard.GetFinishGridNum() >= this.GetPosition();
	}

	// Token: 0x06008358 RID: 33624 RVA: 0x0022B024 File Offset: 0x00229224
	public bool IsActiveDouble()
	{
		DangoMonopolyGridData firstDoubleGrid = this.BelongBoard.GetFirstDoubleGrid();
		return firstDoubleGrid != null && !this.IsLessIndex(firstDoubleGrid.Index) && firstDoubleGrid.IsFinish();
	}

	// Token: 0x06008359 RID: 33625 RVA: 0x0022B05D File Offset: 0x0022925D
	public int GetDangoRunningGridId()
	{
		if (!this.IsExistDango())
		{
			return this.Id;
		}
		if (!this.IsFinish())
		{
			return this.Id;
		}
		DangoMonopolyGridData currentGridData = this.BelongBoard.GetCurrentGridData();
		if (currentGridData == null)
		{
			return this.Id;
		}
		return currentGridData.Id;
	}

	// Token: 0x0600835A RID: 33626 RVA: 0x0022B098 File Offset: 0x00229298
	public void UpdateMoveFinishBuffId(int id)
	{
		this.MoveFinishBuffId = id;
	}

	// Token: 0x0600835B RID: 33627 RVA: 0x0022B0A1 File Offset: 0x002292A1
	public bool IsNeedTriggerBuff()
	{
		return this.GetFireBuffId() > 0;
	}

	// Token: 0x0600835C RID: 33628 RVA: 0x0022B0AC File Offset: 0x002292AC
	public int GetFireBuffId()
	{
		if (this.MoveFinishBuffId != 0)
		{
			return this.MoveFinishBuffId;
		}
		if (this.AddPropertyId != 0)
		{
			return this.AddPropertyId;
		}
		return 0;
	}

	// Token: 0x0600835D RID: 33629 RVA: 0x0022B0D0 File Offset: 0x002292D0
	public void LogInfo()
	{
		List<ValueTuple<string, object>> list = new List<ValueTuple<string, object>>();
		if (this.IsExistItem())
		{
			list.Add(new ValueTuple<string, object>("物品Id", this.ItemId));
			list.Add(new ValueTuple<string, object>("物品数量", this.ItemCount));
		}
		else if (this.IsExistDango())
		{
			list.Add(new ValueTuple<string, object>("团子Id", this.DangoId));
			list.Add(new ValueTuple<string, object>("特性Id", this.AddPropertyId));
		}
		if (this.MoveFinishBuffId != 0)
		{
			list.Add(new ValueTuple<string, object>("移动完成触发特性", this.MoveFinishBuffId));
		}
	}

	// Token: 0x04003E6C RID: 15980
	public int Id;

	// Token: 0x04003E6D RID: 15981
	public int GroupId;

	// Token: 0x04003E6E RID: 15982
	public int Index;

	// Token: 0x04003E6F RID: 15983
	public int AddPropertyId;

	// Token: 0x04003E70 RID: 15984
	public int RemovePropertyId;

	// Token: 0x04003E71 RID: 15985
	public int[] GridInfo = Array.Empty<int>();

	// Token: 0x04003E72 RID: 15986
	public EDangoMonopolyGridType GridType;

	// Token: 0x04003E73 RID: 15987
	public int DangoId;

	// Token: 0x04003E74 RID: 15988
	public int ItemId;

	// Token: 0x04003E75 RID: 15989
	public int ItemCount;

	// Token: 0x04003E76 RID: 15990
	public DangoMonopolyBoardData BelongBoard;

	// Token: 0x04003E77 RID: 15991
	public int MoveFinishBuffId;
}
