using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003108 RID: 12552
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntityPhysicsAssetConfig : ConfigBase<EntityPhysicsAssetConfig>
{
	// Token: 0x06019F29 RID: 106281 RVA: 0x00796520 File Offset: 0x00794720
	public PhysicsAssetConfig? GetPhysicsAssetConfigByRoleBody(string height)
	{
		PhysicsAssetConfig? config = ConfigPhysicsAssetConfigByIdWithDefaultId.GetConfig("0", height, height, height, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "该角色未在角色物理资产配置表中默认值配置 /Config/j.角色物理资产";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("默认值Id", "0");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config.Value.Id != height)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "该角色未在角色物理资产配置表中配置 /Config/j.角色物理资产";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("默认值Id", "0");
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return config;
	}

	// Token: 0x0400D008 RID: 53256
	private const string DEFAULT_DB_ID = "0";
}
