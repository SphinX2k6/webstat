using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002854 RID: 10324
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RoleFavorConfig : ConfigBase<RoleFavorConfig>
{
	// Token: 0x0601479E RID: 83870 RVA: 0x005AED88 File Offset: 0x005ACF88
	public FavorLevel? GetFavorLevelConfig(int level)
	{
		FavorLevel? config = ConfigFavorLevelByLevel.GetConfig(level, true);
		if (config == null)
		{
			return null;
		}
		return new FavorLevel?(config.Value);
	}

	// Token: 0x0601479F RID: 83871 RVA: 0x005AEDBC File Offset: 0x005ACFBC
	public FavorRoleInfo? GetFavorRoleInfoConfig(int roleId)
	{
		FavorRoleInfo? config = ConfigFavorRoleInfoByRoleId.GetConfig(roleId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "角色档案配置表获取配置失败,RoleId = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new FavorRoleInfo?(config.Value);
	}

	// Token: 0x060147A0 RID: 83872 RVA: 0x005AEE1C File Offset: 0x005AD01C
	public FavorWord? GetFavorWordConfigById(int id)
	{
		return ConfigFavorWordById.GetConfig(id, true);
	}

	// Token: 0x060147A1 RID: 83873 RVA: 0x005AEE28 File Offset: 0x005AD028
	public IReadOnlyList<FavorGoods> GetFavorGoodsConfig(int roleId)
	{
		IReadOnlyList<FavorGoods> configList = ConfigFavorGoodsByRoleId.GetConfigList(roleId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "好感度物品配置表获取配置失败,RoleId = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x060147A2 RID: 83874 RVA: 0x005AEE70 File Offset: 0x005AD070
	public IReadOnlyList<FavorStory> GetFavorStoryConfig(int roleId)
	{
		IReadOnlyList<FavorStory> configList = ConfigFavorStoryByRoleId.GetConfigList(roleId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "好感度故事配置表获取配置失败,RoleId =  Order By Sort";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x060147A3 RID: 83875 RVA: 0x005AEEB8 File Offset: 0x005AD0B8
	public IReadOnlyList<FavorWord> GetFavorWordConfig(int roleId, int type)
	{
		IReadOnlyList<FavorWord> configList = ConfigFavorWordByRoleIdAndType.GetConfigList(roleId, type, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
			defaultInterpolatedStringHandler.AppendLiteral("好感度语音配置表获取配置失败,RoleId = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
			defaultInterpolatedStringHandler.AppendLiteral(" Type = ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(type);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return configList;
	}

	// Token: 0x060147A4 RID: 83876 RVA: 0x005AEF24 File Offset: 0x005AD124
	public FavorTabCamera? GetFavorTabCameraConfig(EFavorTabType favorTabType)
	{
		FavorTabCamera? config = ConfigFavorTabCameraById.GetConfig((int)favorTabType, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "好感度切页镜头配置获取失败,Id = ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("favorTabType", favorTabType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new FavorTabCamera?(config.Value);
	}
}
