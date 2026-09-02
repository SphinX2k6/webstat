using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using UnrealEngine;

// Token: 0x02002981 RID: 10625
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerBuffData
{
	// Token: 0x060152C4 RID: 86724 RVA: 0x005DCF06 File Offset: 0x005DB106
	public ShipTowerBuffData()
	{
		this.BuffIds = new List<long>();
		this.ItemNameKey = "";
		this.ObtainedShowDescKey = "";
		this.BgDescKey = "";
	}

	// Token: 0x17001BC9 RID: 7113
	// (get) Token: 0x060152C5 RID: 86725 RVA: 0x005DCF3A File Offset: 0x005DB13A
	public int CanUseCount
	{
		get
		{
			return this.TotalUseCount - this.UsedCount;
		}
	}

	// Token: 0x17001BCA RID: 7114
	// (get) Token: 0x060152C6 RID: 86726 RVA: 0x005DCF49 File Offset: 0x005DB149
	public int CanUseCountNoEdit
	{
		get
		{
			return this.TotalUseCount - this.UsedCountNoEdit;
		}
	}

	// Token: 0x17001BCB RID: 7115
	// (get) Token: 0x060152C7 RID: 86727 RVA: 0x005DCF58 File Offset: 0x005DB158
	public bool IsUnlock
	{
		get
		{
			return this.TotalUseCount > 0;
		}
	}

	// Token: 0x17001BCC RID: 7116
	// (get) Token: 0x060152C8 RID: 86728 RVA: 0x005DCF63 File Offset: 0x005DB163
	public int TotalUseCount
	{
		get
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0);
		}
	}

	// Token: 0x17001BCD RID: 7117
	// (get) Token: 0x060152C9 RID: 86729 RVA: 0x005DCF78 File Offset: 0x005DB178
	public int UsedCount
	{
		get
		{
			IReadOnlyList<ShipTowerStageData> towerStageDataList = ModelBase<ShipTowerModel>.Instance.TowerStageDataList;
			if (towerStageDataList.Count != 0)
			{
				ShipTowerStageData shipTowerStageData = towerStageDataList[0];
				if (shipTowerStageData != null && shipTowerStageData.IsHaveProtoData)
				{
					int num = 0;
					foreach (ShipTowerStageData shipTowerStageData2 in towerStageDataList)
					{
						if (!shipTowerStageData2.IsEndLess && shipTowerStageData2.IsUnLocked())
						{
							foreach (ShipTowerTeamData shipTowerTeamData in shipTowerStageData2.TeamDataList)
							{
								ShipTowerBuffData buffDataEdit = shipTowerTeamData.BuffDataEdit;
								int? num2 = (buffDataEdit != null) ? new int?(buffDataEdit.Id) : null;
								int id = this.Id;
								if (num2.GetValueOrDefault() == id & num2 != null)
								{
									num++;
								}
							}
						}
					}
					return num;
				}
			}
			return 0;
		}
	}

	// Token: 0x17001BCE RID: 7118
	// (get) Token: 0x060152CA RID: 86730 RVA: 0x005DD07C File Offset: 0x005DB27C
	public int UsedCountNoEdit
	{
		get
		{
			IReadOnlyList<ShipTowerStageData> towerStageDataList = ModelBase<ShipTowerModel>.Instance.TowerStageDataList;
			if (towerStageDataList.Count != 0)
			{
				ShipTowerStageData shipTowerStageData = towerStageDataList[0];
				if (shipTowerStageData != null && shipTowerStageData.IsHaveProtoData)
				{
					int num = 0;
					foreach (ShipTowerStageData shipTowerStageData2 in towerStageDataList)
					{
						if (!shipTowerStageData2.IsEndLess && shipTowerStageData2.IsUnLocked())
						{
							foreach (ShipTowerTeamData shipTowerTeamData in shipTowerStageData2.TeamDataList)
							{
								ShipTowerBuffData buffData = shipTowerTeamData.BuffData;
								int? num2 = (buffData != null) ? new int?(buffData.Id) : null;
								int id = this.Id;
								if (num2.GetValueOrDefault() == id & num2 != null)
								{
									num++;
								}
							}
						}
					}
					return num;
				}
			}
			return 0;
		}
	}

	// Token: 0x060152CB RID: 86731 RVA: 0x005DD180 File Offset: 0x005DB380
	public void Init(SlashBuffToItem cfg)
	{
		this.Id = cfg.Id;
		this.ItemId = cfg.ItemId;
		this.Unlimited = cfg.Unlimited;
		this.BuffIds = new List<long>(cfg.BuffIds());
		this.Season = cfg.Season;
		this.UpdateItemInfo();
	}

	// Token: 0x060152CC RID: 86732 RVA: 0x005DD1DC File Offset: 0x005DB3DC
	private void UpdateItemInfo()
	{
		ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(this.ItemId);
		if (config != null)
		{
			this.Quality = config.Value.QualityId;
			this.ItemNameKey = config.Value.Name;
			this.ObtainedShowDescKey = config.Value.ObtainedShowDescription;
			this.BgDescKey = config.Value.BgDescription;
		}
	}

	// Token: 0x060152CD RID: 86733 RVA: 0x005DD257 File Offset: 0x005DB457
	public void SetSelected(bool isSelected)
	{
		if (isSelected)
		{
			ShipTowerBuffData curSelectBuffData = ModelBase<ShipTowerModel>.Instance.CurSelectBuffData;
			if (curSelectBuffData != null)
			{
				curSelectBuffData.SetSelected(false);
			}
			ModelBase<ShipTowerModel>.Instance.CurSelectBuffData = this;
		}
		this.IsSelected = isSelected;
	}

	// Token: 0x060152CE RID: 86734 RVA: 0x005DD284 File Offset: 0x005DB484
	public void ClearSelected()
	{
		this.IsSelected = false;
	}

	// Token: 0x060152CF RID: 86735 RVA: 0x005DD290 File Offset: 0x005DB490
	public string CanUseCountStr(int? stageId = null)
	{
		if (!this.IsUnlimited(stageId))
		{
			return this.CanUseCount.ToString();
		}
		return "∞";
	}

	// Token: 0x060152D0 RID: 86736 RVA: 0x005DD2BA File Offset: 0x005DB4BA
	public bool IsUnlimited(int? stageId = null)
	{
		if (this.Unlimited)
		{
			return true;
		}
		if (stageId != null)
		{
			ShipTowerStageData stageDataById = ModelBase<ShipTowerModel>.Instance.GetStageDataById(stageId.Value);
			if (stageDataById != null && stageDataById.IsEndLess)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060152D1 RID: 86737 RVA: 0x005DD2F1 File Offset: 0x005DB4F1
	public bool IsShowNumTextCallback(int? stageId = null)
	{
		return !this.IsUnlimited(stageId);
	}

	// Token: 0x060152D2 RID: 86738 RVA: 0x005DD300 File Offset: 0x005DB500
	public FColor GetQualityColor()
	{
		QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(this.Quality);
		if (qualityConfig != null)
		{
			return FColor.FromHex(qualityConfig.Value.DropColor);
		}
		return new FColor();
	}

	// Token: 0x060152D3 RID: 86739 RVA: 0x005DD341 File Offset: 0x005DB541
	public bool IsCanUse(int? stageId = null)
	{
		ShipTowerModel instance = ModelBase<ShipTowerModel>.Instance;
		return (instance == null || !instance.IsOldSeason(this.Season)) && this.IsUnlock && (this.IsUnlimited(stageId) || this.CanUseCount > 0);
	}

	// Token: 0x060152D4 RID: 86740 RVA: 0x005DD37C File Offset: 0x005DB57C
	public string GetQualityTitle()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GhostShipItemQuality_Text");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.Quality);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060152D5 RID: 86741 RVA: 0x005DD3B3 File Offset: 0x005DB5B3
	public bool IsFirstGet()
	{
		return this.IsUnlock && !ModelBase<ShipTowerModel>.Instance.PlayerGetBuffSet.Contains(this.Id);
	}

	// Token: 0x060152D6 RID: 86742 RVA: 0x005DD3D9 File Offset: 0x005DB5D9
	public bool AddToGetState()
	{
		if (!this.IsFirstGet())
		{
			return false;
		}
		ModelBase<ShipTowerModel>.Instance.AddPlayerGetBuff(this.Id);
		return true;
	}

	// Token: 0x0400A2EA RID: 41706
	public int Id;

	// Token: 0x0400A2EB RID: 41707
	public List<long> BuffIds;

	// Token: 0x0400A2EC RID: 41708
	public int ItemId;

	// Token: 0x0400A2ED RID: 41709
	public int Quality;

	// Token: 0x0400A2EE RID: 41710
	public string ItemNameKey;

	// Token: 0x0400A2EF RID: 41711
	public string ObtainedShowDescKey;

	// Token: 0x0400A2F0 RID: 41712
	public string BgDescKey;

	// Token: 0x0400A2F1 RID: 41713
	public bool IsSelected;

	// Token: 0x0400A2F2 RID: 41714
	private bool Unlimited;

	// Token: 0x0400A2F3 RID: 41715
	public int Season;
}
