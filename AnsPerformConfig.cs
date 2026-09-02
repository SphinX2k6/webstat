using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02003485 RID: 13445
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class AnsPerformConfig : ConfigBase<AnsPerformConfig>
{
	// Token: 0x0601C5F8 RID: 116216 RVA: 0x00880E3C File Offset: 0x0087F03C
	protected override bool OnInit()
	{
		this.ConfigDataMap = new Dictionary<int, AnsPerform>();
		return true;
	}

	// Token: 0x0601C5F9 RID: 116217 RVA: 0x00880E4A File Offset: 0x0087F04A
	protected override bool OnClear()
	{
		this.ConfigDataMap = null;
		return true;
	}

	// Token: 0x0601C5FA RID: 116218 RVA: 0x00880E54 File Offset: 0x0087F054
	private AnsPerform? GetConfig(int id)
	{
		AnsPerform? config = ConfigAnsPerformById.GetConfig(id, false);
		if (config == null)
		{
			return null;
		}
		return config;
	}

	// Token: 0x0601C5FB RID: 116219 RVA: 0x00880E80 File Offset: 0x0087F080
	public AnsPerform? GetConfigData(int id)
	{
		AnsPerform? result = null;
		if (Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			if (!this.ConfigDataMap.ContainsKey(id))
			{
				result = this.GetConfig(id);
				if (result == null)
				{
					return null;
				}
				this.ConfigDataMap[id] = result.Value;
			}
			result = new AnsPerform?(this.ConfigDataMap[id]);
			if (result == null)
			{
				return null;
			}
			return result;
		}
		else
		{
			this.ParseConfigFromJsonFile();
			AnsPerform value;
			result = (this.ConfigDataMap.TryGetValue(id, out value) ? new AnsPerform?(value) : null);
			if (result == null)
			{
				return null;
			}
			return result;
		}
	}

	// Token: 0x0601C5FC RID: 116220 RVA: 0x00880F44 File Offset: 0x0087F144
	private void ParseConfigFromJsonFile()
	{
		string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/AnsPerformData.json");
		if (!Singleton<PublicUtil>.Instance.IsUseTempData())
		{
			configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/AnsPerformData.json");
		}
		if (!UBlueprintPathsLibrary.FileExists(configPath))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[CharacterFlowDynamic] 不存在AnsPerform.json文件。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = "";
		UKuroStaticLibrary.LoadFileToString(ref text, configPath);
		foreach (AnsPerform value in Json.Parse<AnsPerform[]>(text, null))
		{
			if (!this.ConfigDataMap.ContainsKey(value.Id))
			{
				this.ConfigDataMap[value.Id] = value;
			}
		}
	}

	// Token: 0x0400E43F RID: 58431
	private Dictionary<int, AnsPerform> ConfigDataMap;
}
