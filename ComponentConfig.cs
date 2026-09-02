using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020018AD RID: 6317
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ComponentConfig : ConfigBase<ComponentConfig>
{
	// Token: 0x0600B597 RID: 46487 RVA: 0x00304E18 File Offset: 0x00303018
	[return: Nullable(2)]
	public string GetItemConfigParam(string tag)
	{
		ItemIconTag? config = ConfigItemIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetItemConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B598 RID: 46488 RVA: 0x00304E74 File Offset: 0x00303074
	[return: Nullable(2)]
	public string GetQualityConfigParam(string tag)
	{
		QualityIconTag? config = ConfigQualityIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetQualityConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B599 RID: 46489 RVA: 0x00304ED0 File Offset: 0x003030D0
	[return: Nullable(2)]
	public string GetRoleConfigParam(string tag)
	{
		RoleIconTag? config = ConfigRoleIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetRoleConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B59A RID: 46490 RVA: 0x00304F2C File Offset: 0x0030312C
	[return: Nullable(2)]
	public string GetRoleSkinConfigParam(string tag)
	{
		RoleIconTag? config = ConfigRoleIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetRoleConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B59B RID: 46491 RVA: 0x00304F88 File Offset: 0x00303188
	[return: Nullable(2)]
	public string GetElementConfigParam(string tag)
	{
		ElementIconTag? config = ConfigElementIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetElementIconTag]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B59C RID: 46492 RVA: 0x00304FE4 File Offset: 0x003031E4
	[return: Nullable(2)]
	public string GetMonsterConfigParam(string tag)
	{
		MonsterIconTag? config = ConfigMonsterIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetMonsterConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}

	// Token: 0x0600B59D RID: 46493 RVA: 0x00305040 File Offset: 0x00303240
	[return: Nullable(2)]
	public string GetDungeonEntranceConfigParam(string tag)
	{
		EntranceIconTag? config = ConfigEntranceIconTagById.GetConfig(tag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LguiUtil;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ComponentConfig.GetDungeonConfigParam]查找配置数据失败，数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config.Value.ConfigParam;
	}
}
