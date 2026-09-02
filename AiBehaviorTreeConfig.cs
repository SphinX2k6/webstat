using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02003484 RID: 13444
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AiBehaviorTreeConfig : ConfigBase<AiBehaviorTreeConfig>
{
	// Token: 0x0601C5F3 RID: 116211 RVA: 0x00880CBA File Offset: 0x0087EEBA
	protected override bool OnInit()
	{
		this.ConfigDataMap = new Dictionary<int, AiBehaviorTree>();
		return true;
	}

	// Token: 0x0601C5F4 RID: 116212 RVA: 0x00880CC8 File Offset: 0x0087EEC8
	protected override bool OnClear()
	{
		this.ConfigDataMap = null;
		return true;
	}

	// Token: 0x0601C5F5 RID: 116213 RVA: 0x00880CD4 File Offset: 0x0087EED4
	public AiBehaviorTree? GetAiBehaviorTreeData(int id)
	{
		if (Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			if (!this.ConfigDataMap.ContainsKey(id))
			{
				AiBehaviorTree? config = ConfigAiBehaviorTreeById.GetConfig(id, true);
				if (config == null)
				{
					return null;
				}
				this.ConfigDataMap[id] = config.Value;
			}
			return new AiBehaviorTree?(this.ConfigDataMap[id]);
		}
		this.ParseConfigFromJsonFile();
		AiBehaviorTree value;
		if (this.ConfigDataMap.TryGetValue(id, out value))
		{
			return new AiBehaviorTree?(value);
		}
		return null;
	}

	// Token: 0x0601C5F6 RID: 116214 RVA: 0x00880D64 File Offset: 0x0087EF64
	private void ParseConfigFromJsonFile()
	{
		string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/AiBehaviorTree.json");
		if (!Singleton<PublicUtil>.Instance.IsUseTempData())
		{
			configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/AiBehaviorTree.json");
		}
		if (!UBlueprintPathsLibrary.FileExists(configPath))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "不存在AiBehaviorTree.json文件。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = "";
		UKuroStaticLibrary.LoadFileToString(ref text, configPath);
		foreach (AiBehaviorTree value in Json.Parse<List<AiBehaviorTree>>(text, null))
		{
			this.ConfigDataMap[value.Id] = value;
		}
	}

	// Token: 0x0400E43E RID: 58430
	private Dictionary<int, AiBehaviorTree> ConfigDataMap;
}
