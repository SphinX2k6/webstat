using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.BossPiling;
using CSharpScript.Game.Ui;

// Token: 0x02002007 RID: 8199
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class InstanceDungeonConfig : ConfigBase<InstanceDungeonConfig>
{
	// Token: 0x0600F7BC RID: 63420 RVA: 0x0043D7E3 File Offset: 0x0043B9E3
	protected override bool OnInit()
	{
		this.LimitViewCheckMap[EUiViewName.RoleRootView] = new Func<bool>(this.CheckLimitRoleRootView);
		this.LimitViewCheckMap[EUiViewName.WeaponRootView] = new Func<bool>(this.CheckLimitWeaponRootView);
		return true;
	}

	// Token: 0x0600F7BD RID: 63421 RVA: 0x0043D820 File Offset: 0x0043BA20
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private TWorldLevelToRecommendLevel[] TryGetRecommendLevelLookupList(int id)
	{
		TWorldLevelToRecommendLevel[] array;
		if (!this.RecommendLevelLookupMap.TryGetValue(id, out array))
		{
			InstanceDungeon? config = this.GetConfig(id);
			if (config != null)
			{
				int recommendLevelLength = config.Value.RecommendLevelLength;
				array = new TWorldLevelToRecommendLevel[recommendLevelLength];
				for (int i = 0; i < recommendLevelLength; i++)
				{
					DicIntInt? dicIntInt = config.Value.RecommendLevel(i);
					if (dicIntInt != null)
					{
						array[i] = new TWorldLevelToRecommendLevel(dicIntInt.Value.Key, dicIntInt.Value.Value);
					}
				}
				Array.Sort<TWorldLevelToRecommendLevel>(array, (TWorldLevelToRecommendLevel a, TWorldLevelToRecommendLevel b) => a.Item1 - b.Item1);
				this.RecommendLevelLookupMap[id] = array;
			}
		}
		return array;
	}

	// Token: 0x0600F7BE RID: 63422 RVA: 0x0043D8F4 File Offset: 0x0043BAF4
	public InstanceDungeon? GetConfig(int id)
	{
		InstanceDungeon? config = ConfigInstanceDungeonById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.TL;
			string message = "获取副本配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600F7BF RID: 63423 RVA: 0x0043D94C File Offset: 0x0043BB4C
	public InstanceEnterControl? GetCountConfig(int id)
	{
		InstanceEnterControl? config = ConfigInstanceEnterControlById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.TL;
			string message = "获取副本配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600F7C0 RID: 63424 RVA: 0x0043D9A4 File Offset: 0x0043BBA4
	public InstanceDungeonTitle? GetTitleConfig(int id)
	{
		InstanceDungeonTitle? config = ConfigInstanceDungeonTitleById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.TL;
			string message = "获取副本标题配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600F7C1 RID: 63425 RVA: 0x0043D9FC File Offset: 0x0043BBFC
	public InstanceTrialRoleConfig? GetTrialRoleConfig(int id)
	{
		InstanceTrialRoleConfig? config = ConfigInstanceTrialRoleConfigById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "获取副本试用角色配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600F7C2 RID: 63426 RVA: 0x0043DA54 File Offset: 0x0043BC54
	public InstanceGameplayMode? GetGameplayModeConfig(int id)
	{
		InstanceGameplayMode? config = ConfigInstanceGameplayModeById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InstanceDungeon;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "获取副本玩法模式配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600F7C3 RID: 63427 RVA: 0x0043DAAC File Offset: 0x0043BCAC
	public int GetLimitChallengeTimes(int id)
	{
		InstanceEnterControl? countConfig = this.GetCountConfig(id);
		if (countConfig == null)
		{
			return 0;
		}
		return countConfig.GetValueOrDefault().EnterCount;
	}

	// Token: 0x0600F7C4 RID: 63428 RVA: 0x0043DADC File Offset: 0x0043BCDC
	public bool CheckViewShield(int id, EUiViewName viewName)
	{
		InstanceDungeon? config = this.GetConfig(id);
		Func<bool> func;
		return config != null && config.Value.LimitViewNameLength != 0 && config.Value.LimitViewNameIter().Any((string name) => name == viewName.ToString()) && (!this.LimitViewCheckMap.TryGetValue(viewName, out func) || func());
	}

	// Token: 0x0600F7C5 RID: 63429 RVA: 0x0043DB60 File Offset: 0x0043BD60
	private bool CheckLimitRoleRootView()
	{
		if (ModelBase<TowerModel>.Instance.CheckInTower())
		{
			return !this.TeamRoleSelectIsOpen();
		}
		if (ModelBase<ShipTowerModel>.Instance.CheckInBattleShipTower())
		{
			return !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ShipTowerDescView);
		}
		if (ModelBase<BabelTowerModel>.Instance.CheckInBattleBabelTower())
		{
			return !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BabelTowerHardLevelInfoViewNew);
		}
		if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			return !this.TeamRoleSelectIsOpen();
		}
		if (ModelBase<WheelTowerModel>.Instance.CheckInInstanceDungeon())
		{
			return !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WheelTowerTeamSelectView);
		}
		if (ModelBase<BossPilingModel>.Instance.CheckIsBossPiling())
		{
			return !this.TeamRoleSelectIsOpen();
		}
		return !ControllerBase<AdamSmasherController>.Instance.IsInAdamSmasherDungeon() || !this.TeamRoleSelectIsOpen();
	}

	// Token: 0x0600F7C6 RID: 63430 RVA: 0x0043DC23 File Offset: 0x0043BE23
	private bool CheckLimitWeaponRootView()
	{
		return this.CheckLimitRoleRootView();
	}

	// Token: 0x0600F7C7 RID: 63431 RVA: 0x0043DC2C File Offset: 0x0043BE2C
	private bool TeamRoleSelectIsOpen()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TeamRoleSelectView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MultiTeamRoleSelectView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuickRoleSelectView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.AdamSmasherFormationView);
	}

	// Token: 0x0600F7C8 RID: 63432 RVA: 0x0043DC88 File Offset: 0x0043BE88
	[NullableContext(2)]
	public int[] GetUnlockCondition(int id)
	{
		InstanceDungeon? config = this.GetConfig(id);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().GetEnterConditionArray();
	}

	// Token: 0x0600F7C9 RID: 63433 RVA: 0x0043DCB8 File Offset: 0x0043BEB8
	public string GetUnlockConditionGroupHintText(int id)
	{
		InstanceDungeon? config = this.GetConfig(id);
		return ((config != null) ? config.GetValueOrDefault().EnterConditionText : null) ?? string.Empty;
	}

	// Token: 0x0600F7CA RID: 63434 RVA: 0x0043DCF4 File Offset: 0x0043BEF4
	public int GetRecommendLevel(int id, int worldLevel)
	{
		TWorldLevelToRecommendLevel[] array = this.TryGetRecommendLevelLookupList(id);
		if (array == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.InstanceDungeon, ELogAuthor.TL, "推荐等级区间配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return 0;
		}
		int num = 0;
		foreach (TWorldLevelToRecommendLevel tworldLevelToRecommendLevel in array)
		{
			if (num == 0)
			{
				num = tworldLevelToRecommendLevel.Item2;
			}
			else if (worldLevel >= tworldLevelToRecommendLevel.Item1)
			{
				num = tworldLevelToRecommendLevel.Item2;
			}
		}
		return num;
	}

	// Token: 0x0600F7CB RID: 63435 RVA: 0x0043DD68 File Offset: 0x0043BF68
	public int? GetInstanceRewardId(int id)
	{
		if (this.GetConfig(id) == null)
		{
			return null;
		}
		InstanceDungeon? instanceDungeon;
		return new int?(instanceDungeon.GetValueOrDefault().RewardId);
	}

	// Token: 0x0600F7CC RID: 63436 RVA: 0x0043DDA4 File Offset: 0x0043BFA4
	public int? GetInstanceFirstRewardId(int id)
	{
		if (this.GetConfig(id) == null)
		{
			return null;
		}
		InstanceDungeon? instanceDungeon;
		return new int?(instanceDungeon.GetValueOrDefault().FirstRewardId);
	}

	// Token: 0x0600F7CD RID: 63437 RVA: 0x0043DDE0 File Offset: 0x0043BFE0
	public bool IsMiniMapShow(int id)
	{
		InstanceDungeon? config = this.GetConfig(id);
		return ((config != null) ? config.GetValueOrDefault().MiniMapId : 0) != 0;
	}

	// Token: 0x0600F7CE RID: 63438 RVA: 0x0043DE14 File Offset: 0x0043C014
	[NullableContext(0)]
	public ValueTuple<int, int> GetGuide(int id)
	{
		InstanceDungeon? config = this.GetConfig(id);
		return new ValueTuple<int, int>((config != null) ? config.GetValueOrDefault().GuideType : 0, (config != null) ? config.GetValueOrDefault().GuideValue : 0);
	}

	// Token: 0x0600F7CF RID: 63439 RVA: 0x0043DE64 File Offset: 0x0043C064
	public TowerDefenceInstance? GetTowerDefenseInstanceByInstance(int id)
	{
		return ConfigTowerDefenceInstanceByInstanceId.GetConfig(id, true);
	}

	// Token: 0x0600F7D0 RID: 63440 RVA: 0x0043DE6D File Offset: 0x0043C06D
	public TowerDefenseConfig? GetTowerDefenseConfigByActivityId(int id)
	{
		return ConfigTowerDefenseConfigById.GetConfig(id, true);
	}

	// Token: 0x0600F7D1 RID: 63441 RVA: 0x0043DE76 File Offset: 0x0043C076
	public TowerDefenseSettle? GetTowerDefenseSettleById(int id)
	{
		return ConfigTowerDefenseSettleById.GetConfig(id, true);
	}

	// Token: 0x0600F7D2 RID: 63442 RVA: 0x0043DE7F File Offset: 0x0043C07F
	public TowerDefenceInstance? GetTowerDefenseConfigById(int id)
	{
		return ConfigTowerDefenceInstanceById.GetConfig(id, true);
	}

	// Token: 0x0600F7D3 RID: 63443 RVA: 0x0043DE88 File Offset: 0x0043C088
	public int GetTowerDefenseRankListSize()
	{
		return ConfigCommonParamById.GetIntConfig("TowerDefenceRankListSize").Value;
	}

	// Token: 0x0600F7D4 RID: 63444 RVA: 0x0043DEA7 File Offset: 0x0043C0A7
	public TowerDefencePhantom? GetTowerDefensePhantomById(int id)
	{
		return ConfigTowerDefencePhantomById.GetConfig(id, true);
	}

	// Token: 0x0600F7D5 RID: 63445 RVA: 0x0043DEB0 File Offset: 0x0043C0B0
	public int? GetInstanceMapConfigId(int id)
	{
		if (this.GetConfig(id) == null)
		{
			return null;
		}
		InstanceDungeon? instanceDungeon;
		return new int?(instanceDungeon.GetValueOrDefault().MapConfigId);
	}

	// Token: 0x04007795 RID: 30613
	private readonly Dictionary<int, TWorldLevelToRecommendLevel[]> RecommendLevelLookupMap = new Dictionary<int, TWorldLevelToRecommendLevel[]>();

	// Token: 0x04007796 RID: 30614
	private readonly Dictionary<EUiViewName, Func<bool>> LimitViewCheckMap = new Dictionary<EUiViewName, Func<bool>>();
}
