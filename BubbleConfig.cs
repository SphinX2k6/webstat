using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x0200348A RID: 13450
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BubbleConfig : ConfigBase<BubbleConfig>
{
	// Token: 0x0601C60F RID: 116239 RVA: 0x00881441 File Offset: 0x0087F641
	protected override bool OnInit()
	{
		this.BubbleDataMap = new Dictionary<string, AddPlayBubble>();
		return true;
	}

	// Token: 0x0601C610 RID: 116240 RVA: 0x0088144F File Offset: 0x0087F64F
	protected override bool OnClear()
	{
		this.BubbleDataMap = null;
		return true;
	}

	// Token: 0x0601C611 RID: 116241 RVA: 0x0088145C File Offset: 0x0087F65C
	private BubbleData? GetBubbleConfig(string actionGuid)
	{
		BubbleData? config = ConfigBubbleDataByActionGuid.GetConfig(actionGuid, false);
		if (config == null)
		{
			return null;
		}
		return config;
	}

	// Token: 0x0601C612 RID: 116242 RVA: 0x00881488 File Offset: 0x0087F688
	[return: Nullable(2)]
	public AddPlayBubble GetBubbleData(string actionGuid)
	{
		if (Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			AddPlayBubble addPlayBubble;
			if (!this.BubbleDataMap.TryGetValue(actionGuid, out addPlayBubble))
			{
				BubbleData? bubbleConfig = this.GetBubbleConfig(actionGuid);
				if (bubbleConfig == null)
				{
					return null;
				}
				AddPlayBubble addPlayBubble2 = Json.Decode<AddPlayBubble>(bubbleConfig.Value.Params, null);
				if (addPlayBubble2 != null)
				{
					this.BubbleDataMap[actionGuid] = addPlayBubble2;
				}
			}
			return this.BubbleDataMap.GetValueOrDefault(actionGuid);
		}
		this.ParseConfigFromJsonFile();
		return this.BubbleDataMap.GetValueOrDefault(actionGuid);
	}

	// Token: 0x0601C613 RID: 116243 RVA: 0x0088150C File Offset: 0x0087F70C
	private void ParseConfigFromJsonFile()
	{
		string configPath = Singleton<PublicUtil>.Instance.GetConfigPath("../Config/Raw/Tables/k.可视化编辑/__Temp__/Json/BubbleConfig.json");
		if (!Singleton<PublicUtil>.Instance.IsUseTempData())
		{
			configPath = Singleton<PublicUtil>.Instance.GetConfigPath("Content/Aki/UniverseEditorConfig/Json/BubbleConfig.json");
		}
		if (!UBlueprintPathsLibrary.FileExists(configPath))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[CharacterFlowDynamic] 不存在BubbleConfig.json文件。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", configPath);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text = "";
		UKuroStaticLibrary.LoadFileToString(ref text, configPath);
		ActionInfo[] array = Json.Parse<ActionInfo[]>(text, null);
		if (array == null)
		{
			return;
		}
		foreach (ActionInfo actionInfo in array)
		{
			if (!string.IsNullOrEmpty(actionInfo.ActionGuid))
			{
				AddPlayBubble addPlayBubble = actionInfo.Params as AddPlayBubble;
				if (addPlayBubble != null && !this.BubbleDataMap.ContainsKey(actionInfo.ActionGuid))
				{
					this.BubbleDataMap[actionInfo.ActionGuid] = addPlayBubble;
				}
			}
		}
	}

	// Token: 0x0400E44F RID: 58447
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<string, AddPlayBubble> BubbleDataMap;
}
