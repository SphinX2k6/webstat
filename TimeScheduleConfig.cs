using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x020034A5 RID: 13477
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TimeScheduleConfig : ConfigBase<TimeScheduleConfig>
{
	// Token: 0x0601C6C4 RID: 116420 RVA: 0x008846AD File Offset: 0x008828AD
	protected override bool OnInit()
	{
		this.ConfigDataMap = new Dictionary<int, TimeSchedule>();
		return true;
	}

	// Token: 0x0601C6C5 RID: 116421 RVA: 0x008846BB File Offset: 0x008828BB
	protected override bool OnClear()
	{
		this.ConfigDataMap = null;
		return true;
	}

	// Token: 0x0601C6C6 RID: 116422 RVA: 0x008846C8 File Offset: 0x008828C8
	public TimeSchedule? GetTimeScheduleData(int id)
	{
		if (Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			if (!this.ConfigDataMap.ContainsKey(id))
			{
				TimeSchedule? config = ConfigTimeScheduleById.GetConfig(id, true);
				if (config == null)
				{
					return null;
				}
				this.ConfigDataMap[id] = config.Value;
			}
			TimeSchedule value;
			if (!this.ConfigDataMap.TryGetValue(id, out value))
			{
				return null;
			}
			return new TimeSchedule?(value);
		}
		else
		{
			this.ParseConfigFromJsonFile();
			TimeSchedule value2;
			if (this.ConfigDataMap.TryGetValue(id, out value2))
			{
				return new TimeSchedule?(value2);
			}
			return null;
		}
	}

	// Token: 0x0601C6C7 RID: 116423 RVA: 0x00884764 File Offset: 0x00882964
	private void ParseConfigFromJsonFile()
	{
		string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/TimeSchedule.json");
		if (!Singleton<PublicUtil>.Instance.IsUseTempData())
		{
			configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/TimeSchedule.json");
		}
		if (!UBlueprintPathsLibrary.FileExists(configPath))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "不存在TimeSchedule.json文件。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = "";
		UKuroStaticLibrary.LoadFileToString(ref text, configPath);
		TimeSchedule[] array = Json.Parse<TimeSchedule[]>(text, null);
		if (array == null)
		{
			return;
		}
		foreach (TimeSchedule value in array)
		{
			this.ConfigDataMap[value.Id] = value;
		}
	}

	// Token: 0x0400E4B2 RID: 58546
	private Dictionary<int, TimeSchedule> ConfigDataMap;
}
