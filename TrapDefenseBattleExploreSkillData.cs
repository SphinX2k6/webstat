using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02001DA4 RID: 7588
public class TrapDefenseBattleExploreSkillData : TrapDefenseBattleSkillData
{
	// Token: 0x17001184 RID: 4484
	// (get) Token: 0x0600DFEC RID: 57324 RVA: 0x003C3FD3 File Offset: 0x003C21D3
	private bool IsUseItem
	{
		get
		{
			return ModelBase<RouletteModel>.Instance.IsEquipItemSelectOn;
		}
	}

	// Token: 0x0600DFED RID: 57325 RVA: 0x003C3FE0 File Offset: 0x003C21E0
	protected override void RefreshSkillTexturePath()
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconSkillNone");
		TrapDefenseItem? trapDefenseItemByExploreToolId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseItemByExploreToolId(this.ExploreSkillId);
		if (trapDefenseItemByExploreToolId == null)
		{
			this.SkillTexturePath = resourcePath;
			return;
		}
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		TrapDefenseBattleItemData trapDefenseBattleItemData = (instance != null) ? instance.BattleInventoryData.GetItemData(trapDefenseItemByExploreToolId.Value.Id) : null;
		if (trapDefenseBattleItemData == null || trapDefenseBattleItemData.InventoryCount <= 0)
		{
			this.SkillTexturePath = resourcePath;
			return;
		}
		this.SkillTexturePath = ModelBase<RouletteModel>.Instance.CurrentExploreSkillIcon;
		if (!string.IsNullOrEmpty(this.SkillTexturePath))
		{
			return;
		}
		if (this.Config == null)
		{
			this.SkillTexturePath = resourcePath;
			return;
		}
		this.SkillTexturePath = this.Config.Value.SkillIcon;
	}

	// Token: 0x0600DFEE RID: 57326 RVA: 0x003C40A6 File Offset: 0x003C22A6
	public override bool IsEnableLongPress()
	{
		return true;
	}

	// Token: 0x0600DFEF RID: 57327 RVA: 0x003C40A9 File Offset: 0x003C22A9
	public override bool IsEnableInput()
	{
		return this.IsEnableInternal;
	}

	// Token: 0x0600DFF0 RID: 57328 RVA: 0x003C40B1 File Offset: 0x003C22B1
	public override bool IsEquippedItemBanReqUse()
	{
		return this.IsUseItem && ModelBase<RouletteModel>.Instance.IsEquippedItemBanReqUse();
	}

	// Token: 0x0600DFF1 RID: 57329 RVA: 0x003C40C7 File Offset: 0x003C22C7
	public override bool IsSkillInItemUseCd()
	{
		return this.IsSkillInItemUseBuffCd() || this.IsSkillInItemUseSkillCd();
	}

	// Token: 0x0600DFF2 RID: 57330 RVA: 0x003C40D9 File Offset: 0x003C22D9
	public override bool IsSkillInItemUseBuffCd()
	{
		return this.IsUseItem && !base.IsExploreAsFight && ModelBase<RouletteModel>.Instance.IsEquipItemInBuffCd();
	}

	// Token: 0x0600DFF3 RID: 57331 RVA: 0x003C40F8 File Offset: 0x003C22F8
	public override bool IsSkillInItemUseSkillCd()
	{
		if (this.IsUseItem && this.CharacterSkillCdComponent != null && !base.IsExploreAsFight)
		{
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(ModelBase<RouletteModel>.Instance.CurrentEquipItemId);
			int skillId;
			if (itemConfig != null && itemConfig.Value.Parameters().TryGetValue(21, out skillId))
			{
				GroupSkillCdInfo groupSkillCdInfo = this.CharacterSkillCdComponent.GetGroupSkillCdInfo(skillId);
				float? num = (groupSkillCdInfo != null) ? new float?(groupSkillCdInfo.CurRemainingCd) : null;
				double? num2 = ((num != null) ? new double?((double)num.GetValueOrDefault()) : null) - Singleton<TimeUtil>.Instance.TimeDeviation;
				double num3 = 0.0;
				return num2.GetValueOrDefault() > num3 & num2 != null;
			}
		}
		return false;
	}

	// Token: 0x0600DFF4 RID: 57332 RVA: 0x003C4200 File Offset: 0x003C2400
	public override ValueTuple<double, double> GetEquippedItemUsingBuffCd()
	{
		if (this.IsUseItem)
		{
			int currentEquipItemId = ModelBase<RouletteModel>.Instance.CurrentEquipItemId;
			BuffItemModel instance = ModelBase<BuffItemModel>.Instance;
			double buffItemRemainCdTime = instance.GetBuffItemRemainCdTime(currentEquipItemId);
			double buffItemTotalCdTime = instance.GetBuffItemTotalCdTime(currentEquipItemId);
			return new ValueTuple<double, double>(buffItemRemainCdTime, buffItemTotalCdTime);
		}
		return new ValueTuple<double, double>(0.0, 0.0);
	}

	// Token: 0x0600DFF5 RID: 57333 RVA: 0x003C4254 File Offset: 0x003C2454
	public override ValueTuple<double, double> GetEquippedItemUsingSkillCd()
	{
		if (this.IsUseItem && this.CharacterSkillCdComponent != null)
		{
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(ModelBase<RouletteModel>.Instance.CurrentEquipItemId);
			int skillId;
			if (itemConfig != null && itemConfig.Value.Parameters().TryGetValue(21, out skillId))
			{
				GroupSkillCdInfo groupSkillCdInfo = this.CharacterSkillCdComponent.GetGroupSkillCdInfo(skillId);
				if (groupSkillCdInfo != null)
				{
					return new ValueTuple<double, double>((double)groupSkillCdInfo.CurRemainingCd, (double)groupSkillCdInfo.CurMaxCd);
				}
			}
		}
		return new ValueTuple<double, double>(0.0, 0.0);
	}

	// Token: 0x0600DFF6 RID: 57334 RVA: 0x003C42E4 File Offset: 0x003C24E4
	public override int GetSkillId()
	{
		return this.ExploreSkillId;
	}

	// Token: 0x0600DFF7 RID: 57335 RVA: 0x003C42EC File Offset: 0x003C24EC
	public void SetExploreSkillId(int exploreSkillId)
	{
		bool exploreSkillChange = this.ExploreSkillId != exploreSkillId;
		this.ExploreSkillId = exploreSkillId;
		base.SetExploreSkillChange(exploreSkillChange);
		this.RefreshSkillTexturePath();
	}

	// Token: 0x0600DFF8 RID: 57336 RVA: 0x003C431A File Offset: 0x003C251A
	public override void RefreshSkillCd()
	{
		if (this.IsUseItem && !base.IsExploreAsFight && (this.IsEquippedItemBanReqUse() || this.IsSkillInItemUseCd()))
		{
			this.IsEnableInternal = false;
			return;
		}
		base.RefreshSkillCd();
	}

	// Token: 0x04006B85 RID: 27525
	[Nullable(1)]
	private const string SKILL_NONE_PATH = "T_IconSkillNone";

	// Token: 0x04006B86 RID: 27526
	protected int ExploreSkillId;
}
