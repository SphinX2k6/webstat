using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using Google.Protobuf.Collections;

// Token: 0x02002817 RID: 10263
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RoleDevConfig : ConfigBase<RoleDevConfig>
{
	// Token: 0x0601441E RID: 82974 RVA: 0x005A3AFC File Offset: 0x005A1CFC
	public void UpdateDevProsListConfig(RepeatedField<RoleDevPropsConfig> devPropsLists)
	{
		this.DevProsListMap.Clear();
		foreach (RoleDevPropsConfig roleDevPropsConfig in devPropsLists)
		{
			List<IRoleDevProsSpecialGachaConfig> list = new List<IRoleDevProsSpecialGachaConfig>();
			foreach (SpecialGachaPair specialGachaPair in roleDevPropsConfig.SpecialGachaPair)
			{
				list.Add(new RoleDevProsSpecialGachaConfig(specialGachaPair.TypeId, specialGachaPair.GachaId));
			}
			RoleDevProsConfig value = new RoleDevProsConfig
			{
				Id = roleDevPropsConfig.Id,
				ProspectBeginTime = Singleton<MathUtils>.Instance.LongToBigInt(roleDevPropsConfig.ProspectBeginTime) / (long)Singleton<TimeUtil>.Instance.InverseMillisecond,
				ProspectEndTime = Singleton<MathUtils>.Instance.LongToBigInt(roleDevPropsConfig.ProspectEndTime) / (long)Singleton<TimeUtil>.Instance.InverseMillisecond,
				TypeId = roleDevPropsConfig.TypeId,
				GachaId = roleDevPropsConfig.GachaId,
				SpecialGachaId = list,
				SortId = roleDevPropsConfig.SortId
			};
			this.DevProsListMap[(long)roleDevPropsConfig.Id] = value;
		}
	}

	// Token: 0x0601441F RID: 82975 RVA: 0x005A3C3C File Offset: 0x005A1E3C
	public void UpdateDevPropsProjectConfig(RepeatedField<RoleDevPropsProjectConfig> devPropsProjects)
	{
		this.DevPropsProjectMap.Clear();
		foreach (RoleDevPropsProjectConfig roleDevPropsProjectConfig in devPropsProjects)
		{
			RoleDevProsProjectConfig value = new RoleDevProsProjectConfig
			{
				Id = roleDevPropsProjectConfig.Id,
				ElementId = roleDevPropsProjectConfig.ElementId,
				RoleName = roleDevPropsProjectConfig.RoleName,
				RoleExperience = roleDevPropsProjectConfig.RoleExperience,
				RoleGoalLevel = roleDevPropsProjectConfig.RoleGoalLevel,
				WeaponGoalLevel = roleDevPropsProjectConfig.WeaponGoalLevel,
				WeaponExperience = roleDevPropsProjectConfig.WeaponExperience,
				RoleItemGroup = roleDevPropsProjectConfig.RoleItemGroup.ToList<int>(),
				WeaponBreachItemGroup = roleDevPropsProjectConfig.WeaponBreachItemGroup.ToList<int>(),
				WeaponType = roleDevPropsProjectConfig.WeaponType,
				SkillItemGroup = roleDevPropsProjectConfig.SkillItemGroup.ToList<int>(),
				PrefectSkillLevel = roleDevPropsProjectConfig.PrefectSkillLevel.ToList<int>(),
				RoleHeadIcon = roleDevPropsProjectConfig.RoleHeadIcon,
				RoleHeadIconSmall = roleDevPropsProjectConfig.RoleHeadIconSmall,
				FormationRoleCard = roleDevPropsProjectConfig.FormationRoleCard
			};
			this.DevPropsProjectMap[(long)roleDevPropsProjectConfig.Id] = value;
		}
	}

	// Token: 0x06014420 RID: 82976 RVA: 0x005A3D70 File Offset: 0x005A1F70
	public RoleDevProject? GetRoleDevProjectConfig(int roleId)
	{
		RoleDevProject? config = ConfigRoleDevProjectByRoleId.GetConfig(roleId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevProject表无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014421 RID: 82977 RVA: 0x005A3DC8 File Offset: 0x005A1FC8
	public RoleDevCultivateProject? GetCultivateProjectConfig(int cultivateProjectId)
	{
		RoleDevCultivateProject? config = ConfigRoleDevCultivateProjectByProjectProjectId.GetConfig(cultivateProjectId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevCultivateProject表无效cultivateProjectId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cultivateProjectId", cultivateProjectId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014422 RID: 82978 RVA: 0x005A3E20 File Offset: 0x005A2020
	public IReadOnlyList<RoleDevLevelLimit> GetLevelLimitConfigList()
	{
		IReadOnlyList<RoleDevLevelLimit> configList = ConfigRoleDevLevelLimitAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RoleDev, ELogAuthor.WMQ, "RoleDevLevelLimit表获取失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new List<RoleDevLevelLimit>();
		}
		return configList;
	}

	// Token: 0x06014423 RID: 82979 RVA: 0x005A3E60 File Offset: 0x005A2060
	public RoleDevItemJumpGroup? GetItemJumpGroupConfig(int itemId)
	{
		RoleDevItemJumpGroup? config = ConfigRoleDevItemJumpGroupByItemId.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevItemJumpGroup表无效itemId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemId", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014424 RID: 82980 RVA: 0x005A3EB8 File Offset: 0x005A20B8
	[NullableContext(2)]
	public IReadOnlyList<RoleDevItemJumpGroup> GetAllItemJumpGroupConfigs()
	{
		return ConfigRoleDevItemJumpGroupAll.GetConfigList(true);
	}

	// Token: 0x06014425 RID: 82981 RVA: 0x005A3EC0 File Offset: 0x005A20C0
	public RoleDevTypeManage? GetTypeManageConfig(int type)
	{
		RoleDevTypeManage? config = ConfigRoleDevTypeManageByItemType.GetConfig(type, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevTypeManage表无效type";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014426 RID: 82982 RVA: 0x005A3F18 File Offset: 0x005A2118
	public RoleDevPhantomJumpGroup? GetPhantomJumpGroupConfig(int fetterGroupId)
	{
		RoleDevPhantomJumpGroup? config = ConfigRoleDevPhantomJumpGroupByPhantomId.GetConfig(fetterGroupId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevPhantomJumpGroup表无效fetterGroupId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("fetterGroupId", fetterGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014427 RID: 82983 RVA: 0x005A3F70 File Offset: 0x005A2170
	public PropertyIndex? GetPropertyIndexConfigByIndex(int index)
	{
		PropertyIndex? config = ConfigPropertyIndexById.GetConfig(index, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "PropertyIndex表无效index";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", index);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014428 RID: 82984 RVA: 0x005A3FC8 File Offset: 0x005A21C8
	public int[] GetWeaponRecommendListConfig(int roleId)
	{
		RoleDevProject? config = ConfigRoleDevProjectByRoleId.GetConfig(roleId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevProject表无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new int[0];
		}
		return config.Value.RecommandWeapon();
	}

	// Token: 0x06014429 RID: 82985 RVA: 0x005A402C File Offset: 0x005A222C
	public RoleDevWeaponJumpGroup? GetWeaponJumpGroupConfigByWeaponId(int weaponId)
	{
		RoleDevWeaponJumpGroup? config = ConfigRoleDevWeaponJumpGroupByWeaponId.GetConfig(weaponId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevWeaponJumpGroup表无效weaponId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("weaponId", weaponId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0601442A RID: 82986 RVA: 0x005A4084 File Offset: 0x005A2284
	public bool HasRoleDevProsListConfig(int roleId)
	{
		return this.DevProsListMap.ContainsKey((long)roleId);
	}

	// Token: 0x0601442B RID: 82987 RVA: 0x005A4094 File Offset: 0x005A2294
	[NullableContext(2)]
	public IRoleDevProsConfig GetRoleDevProsListConfig(int roleId)
	{
		IRoleDevProsConfig result;
		if (!this.DevProsListMap.TryGetValue((long)roleId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.LJS;
			string message = "服务器DevPropsList无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0601442C RID: 82988 RVA: 0x005A40E4 File Offset: 0x005A22E4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<IRoleDevProsConfig> GetAllRoleDevProsListConfig()
	{
		return this.DevProsListMap.Values.ToList<IRoleDevProsConfig>();
	}

	// Token: 0x0601442D RID: 82989 RVA: 0x005A40F8 File Offset: 0x005A22F8
	[NullableContext(2)]
	public IRoleDevProsProjectConfig GetRoleDevProsProjectConfig(int roleId)
	{
		IRoleDevProsProjectConfig result;
		if (!this.DevPropsProjectMap.TryGetValue((long)roleId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.LJS;
			string message = "服务器DevPropsProjectList无效roleId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0601442E RID: 82990 RVA: 0x005A4148 File Offset: 0x005A2348
	public RoleDevProsRoleItem? GetRoleDevProsRoleItemConfig(int itemGroupId)
	{
		RoleDevProsRoleItem? config = ConfigRoleDevProsRoleItemByItemGroupId.GetConfig(itemGroupId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevProsRoleItem表无效itemGroupId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("itemGroupId", itemGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0601442F RID: 82991 RVA: 0x005A41A0 File Offset: 0x005A23A0
	public RoleDevWeaponItem? GetRoleDevWeaponItemConfig(int weaponType)
	{
		RoleDevWeaponItem? config = ConfigRoleDevWeaponItemByWeaponType.GetConfig(weaponType, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevWeaponItem表无效weaponType";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("weaponType", weaponType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014430 RID: 82992 RVA: 0x005A41F8 File Offset: 0x005A23F8
	public RoleDevCulProjectConfig? GetRoleDevStaticConfig()
	{
		RoleDevCulProjectConfig? config = ConfigRoleDevCulProjectConfigById.GetConfig(1, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RoleDev;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "RoleDevStatic表无效configId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", 1);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06014431 RID: 82993 RVA: 0x005A4250 File Offset: 0x005A2450
	public int[] GetCanLevelUpSkillNodeIndexList()
	{
		return ConfigCommonParamById.GetIntArrayConfig("RoleDevCanLevelUpSkillNodeIndexList").ToArray<int>();
	}

	// Token: 0x06014432 RID: 82994 RVA: 0x005A4264 File Offset: 0x005A2464
	public int GetDefaultSkillNodeIndex()
	{
		int[] canLevelUpSkillNodeIndexList = this.GetCanLevelUpSkillNodeIndexList();
		if (canLevelUpSkillNodeIndexList.Length == 0)
		{
			return 0;
		}
		return canLevelUpSkillNodeIndexList[0];
	}

	// Token: 0x04009D98 RID: 40344
	private readonly Dictionary<long, IRoleDevProsConfig> DevProsListMap = new Dictionary<long, IRoleDevProsConfig>();

	// Token: 0x04009D99 RID: 40345
	private readonly Dictionary<long, IRoleDevProsProjectConfig> DevPropsProjectMap = new Dictionary<long, IRoleDevProsProjectConfig>();
}
