using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02002657 RID: 9815
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class QuestNewConfig : ConfigBase<QuestNewConfig>
{
	// Token: 0x0601357C RID: 79228 RVA: 0x00561DAD File Offset: 0x0055FFAD
	protected override bool OnInit()
	{
		this.InitQuestAreaConfigs();
		return true;
	}

	// Token: 0x0601357D RID: 79229 RVA: 0x00561DB8 File Offset: 0x0055FFB8
	private void InitQuestAreaConfigs()
	{
		if (Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			return;
		}
		string text = UKismetSystemLibrary.ConvertToAbsolutePath(UKismetSystemLibrary.ConvertToAbsolutePath(UBlueprintPathsLibrary.ProjectDir()) + "../Config/Raw/Tables/k.可视化编辑/AreaQuestTracking.json");
		if (!UBlueprintPathsLibrary.FileExists(text))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Editor;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "globalConfigTemp文件不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", text);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		string text2 = "";
		UKuroStaticLibrary.LoadFileToString(ref text2, text);
		foreach (IAreaQuestTracking areaQuestTracking in Json.Decode<List<IAreaQuestTracking>>(text2, null))
		{
			Dictionary<string, List<int>> areaQuestTrackingList = this.AreaQuestTrackingList;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(areaQuestTracking.QuestId);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(areaQuestTracking.NodeId);
			areaQuestTrackingList[defaultInterpolatedStringHandler.ToStringAndClear()] = areaQuestTracking.AreaIds;
		}
	}

	// Token: 0x0601357E RID: 79230 RVA: 0x00561EB8 File Offset: 0x005600B8
	[return: Nullable(2)]
	public unsafe string GetTrackEffectPath(string trackEffectEnum)
	{
		if (StringUtils.IsEmpty(trackEffectEnum))
		{
			return null;
		}
		string item = "Name = 'ETrackEffect." + trackEffectEnum + "'";
		GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig("ETrackEffect." + trackEffectEnum, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到全局配置表的配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("全局表路径", "Source/Config/Raw/Tables/q.全局配置");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("查询条件", item);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return config.Value.Value;
	}

	// Token: 0x0601357F RID: 79231 RVA: 0x00561F64 File Offset: 0x00560164
	[return: Nullable(2)]
	public unsafe string GetGlobalConfig(string paramName)
	{
		if (StringUtils.IsEmpty(paramName))
		{
			return null;
		}
		string item = "Name = '" + paramName + "'";
		GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig(paramName, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到全局配置表的配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("全局表路径", "Source/Config/Raw/Tables/q.全局配置");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("查询条件", item);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return config.Value.Value;
	}

	// Token: 0x06013580 RID: 79232 RVA: 0x00562008 File Offset: 0x00560208
	public DropPackage? GetDropConfig(int? rewardId)
	{
		bool flag = (rewardId ?? 0) == 0;
		if (flag)
		{
			return null;
		}
		DropPackage? config = ConfigDropPackageById.GetConfig(rewardId.Value, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "DropPackage表配置没找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rewardId", rewardId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06013581 RID: 79233 RVA: 0x00562080 File Offset: 0x00560280
	public ItemInfo? GetItemInfoConfig(int itemId)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(itemId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "ItemInfo表配置没找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", itemId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06013582 RID: 79234 RVA: 0x005620CB File Offset: 0x005602CB
	[NullableContext(2)]
	public IReadOnlyList<QuestType> GetQuestTypeConfigs()
	{
		return ConfigQuestTypeAll.GetConfigList(true);
	}

	// Token: 0x06013583 RID: 79235 RVA: 0x005620D4 File Offset: 0x005602D4
	public QuestType? GetQuestTypeConfig(int questType)
	{
		QuestType? config = ConfigQuestTypeById.GetConfig(questType, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "QuestType表配置没找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", questType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06013584 RID: 79236 RVA: 0x00562120 File Offset: 0x00560320
	public QuestMainType? GetQuestMainTypeConfig(int mainTypeId)
	{
		QuestMainType? config = ConfigQuestMainTypeById.GetConfig(mainTypeId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "QuestMainType表配置没找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", mainTypeId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06013585 RID: 79237 RVA: 0x0056216B File Offset: 0x0056036B
	[NullableContext(2)]
	public IReadOnlyList<QuestType> GetQuesTypesByMainType(int questType)
	{
		return ConfigQuestTypeByMainId.GetConfigList(questType, true);
	}

	// Token: 0x06013586 RID: 79238 RVA: 0x00562174 File Offset: 0x00560374
	public string GetQuestMainTypeName(int questType)
	{
		QuestMainType? questMainTypeConfig = this.GetQuestMainTypeConfig(questType);
		if (questMainTypeConfig == null)
		{
			return "";
		}
		return ConfigMultiTextLang.GetLocalTextNew(questMainTypeConfig.Value.MainTypeName, null) ?? "";
	}

	// Token: 0x06013587 RID: 79239 RVA: 0x005621B8 File Offset: 0x005603B8
	public string GetQuestTabIcon(int questType)
	{
		QuestMainType? questMainTypeConfig = this.GetQuestMainTypeConfig(questType);
		if (questMainTypeConfig == null)
		{
			return "";
		}
		return questMainTypeConfig.Value.QuestTabIcon;
	}

	// Token: 0x06013588 RID: 79240 RVA: 0x005621EC File Offset: 0x005603EC
	public string GetQuestTypeMark(int markId)
	{
		TaskMark? config = ConfigTaskMarkByMarkId.GetConfig(markId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "地图标记表TaskMark：MarkId = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "";
		}
		if (StringUtils.IsBlank(config.Value.MarkPic))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Quest;
			ELogAuthor author2 = ELogAuthor.JLY;
			string message2 = "地图标记表MarkPic为空";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("markId", markId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return config.Value.MarkPic;
	}

	// Token: 0x06013589 RID: 79241 RVA: 0x00562290 File Offset: 0x00560490
	public TaskMark? GetQuestMarkConfig(int markId)
	{
		TaskMark? config = ConfigTaskMarkByMarkId.GetConfig(markId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "地图标记表TaskMark：MarkId = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x0601358A RID: 79242 RVA: 0x005622DC File Offset: 0x005604DC
	public int? GetQuestTypeMarkId(int questType)
	{
		QuestMainType? questMainTypeConfig = this.GetQuestMainTypeConfig(questType);
		if (questMainTypeConfig == null)
		{
			return null;
		}
		return new int?(questMainTypeConfig.Value.TrackIconId);
	}

	// Token: 0x0601358B RID: 79243 RVA: 0x00562318 File Offset: 0x00560518
	public QuestChapter? GetChapterConfig(int chapterId)
	{
		QuestChapter? config = ConfigQuestChapterById.GetConfig(chapterId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务章节表：id = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("chapterId", chapterId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new QuestChapter?(config.Value);
	}

	// Token: 0x0601358C RID: 79244 RVA: 0x00562378 File Offset: 0x00560578
	public unsafe OccupationConfig? GetOccupationConfig(string occupationId)
	{
		OccupationConfig? config = ConfigOccupationConfigById.GetConfig(occupationId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到占用配置表的配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("全局表路径", "Source/Config/Raw/Tables/k.可视化编辑/z.占用组配置");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", occupationId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x0601358D RID: 79245 RVA: 0x005623F0 File Offset: 0x005605F0
	public unsafe NewOccupationConfig? GetNewOccupationConfig(string occupationId)
	{
		NewOccupationConfig? config = ConfigNewOccupationConfigById.GetConfig(occupationId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到占用配置表的配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("全局表路径", "Source/Config/Raw/Tables/k.可视化编辑/z.占用组配置");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Id", occupationId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x0601358E RID: 79246 RVA: 0x00562468 File Offset: 0x00560668
	[return: Nullable(2)]
	public string GetOccupationResourceName(string occupationId)
	{
		OccupationConfig? occupationConfig = this.GetOccupationConfig(occupationId);
		if (occupationConfig == null)
		{
			return "";
		}
		return Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.OccupationConfigName, occupationConfig.Value.Id);
	}

	// Token: 0x0601358F RID: 79247 RVA: 0x005624A8 File Offset: 0x005606A8
	[return: Nullable(2)]
	public string GetOccupationType(string occupationId)
	{
		OccupationConfig? occupationConfig = this.GetOccupationConfig(occupationId);
		if (occupationConfig == null)
		{
			return "";
		}
		return occupationConfig.Value.OccupationType;
	}

	// Token: 0x06013590 RID: 79248 RVA: 0x005624DC File Offset: 0x005606DC
	public QuestData? GetQuestConfig(int questId)
	{
		QuestData? config = ConfigQuestDataById.GetConfig(questId, false);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到任务配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questId", questId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}

	// Token: 0x06013591 RID: 79249 RVA: 0x00562528 File Offset: 0x00560728
	public unsafe QuestNodeData? GetQuestNodeConfig(int questId, int nodeId)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(nodeId);
		QuestNodeData? config = ConfigQuestNodeDataByKey.GetConfig(defaultInterpolatedStringHandler.ToStringAndClear(), false);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到任务节点配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("questId", questId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nodeId", nodeId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return config;
	}

	// Token: 0x06013592 RID: 79250 RVA: 0x005625D0 File Offset: 0x005607D0
	[NullableContext(2)]
	public string GetQuestTypeColor(int questType)
	{
		QuestType? questTypeConfig = this.GetQuestTypeConfig(questType);
		if (questTypeConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务类型表：id = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questType", questType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return questTypeConfig.Value.TypeColor;
	}

	// Token: 0x06013593 RID: 79251 RVA: 0x0056262C File Offset: 0x0056082C
	[NullableContext(2)]
	public string GetQuestMainTypeCircleColor(int questType)
	{
		QuestType? questTypeConfig = this.GetQuestTypeConfig(questType);
		if (questTypeConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务类型表：id = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questType", questType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.GetQuestMainTypeConfig(questTypeConfig.Value.MainId).Value.CircleColor;
	}

	// Token: 0x06013594 RID: 79252 RVA: 0x005626A0 File Offset: 0x005608A0
	[NullableContext(2)]
	public string GetQuestMainTypeTrackBgColor(int questType)
	{
		QuestType? questTypeConfig = this.GetQuestTypeConfig(questType);
		if (questTypeConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务类型表：id = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questType", questType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.GetQuestMainTypeConfig(questTypeConfig.Value.MainId).Value.TrackBgColor;
	}

	// Token: 0x06013595 RID: 79253 RVA: 0x00562714 File Offset: 0x00560914
	[NullableContext(2)]
	public string GetQuestTypeTextColor(int questType)
	{
		QuestType? questTypeConfig = this.GetQuestTypeConfig(questType);
		if (questTypeConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "任务类型表：id = 的配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("questType", questType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return questTypeConfig.Value.TextColor;
	}

	// Token: 0x06013596 RID: 79254 RVA: 0x00562770 File Offset: 0x00560970
	public int? GetNewTipsShowTime(int questType)
	{
		QuestMainType? questMainTypeConfig = this.GetQuestMainTypeConfig(questType);
		if (questMainTypeConfig == null)
		{
			return new int?(0);
		}
		return new int?(questMainTypeConfig.Value.NewQuestTipTime);
	}

	// Token: 0x06013597 RID: 79255 RVA: 0x005627AC File Offset: 0x005609AC
	public int? GetQuestUpdateShowTime(int questType)
	{
		QuestMainType? questMainTypeConfig = this.GetQuestMainTypeConfig(questType);
		if (questMainTypeConfig == null)
		{
			return new int?(0);
		}
		return new int?(questMainTypeConfig.Value.QuestUpdateTipsTime);
	}

	// Token: 0x06013598 RID: 79256 RVA: 0x005627E8 File Offset: 0x005609E8
	[NullableContext(2)]
	public unsafe List<int> GetQuestNodeAreaInfo(int questId, int nodeId)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(questId);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted<int>(nodeId);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		if (!Singleton<PublicUtil>.Instance.UseDbConfig())
		{
			return this.AreaQuestTrackingList.GetValueOrDefault(text);
		}
		AreaQuestTracking? config = ConfigAreaQuestTrackingById.GetConfig(text, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "找不到任务节点所在的区域信息";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("questId", questId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("nodeId", nodeId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return new List<int>(config.Value.GetAreaListArray());
	}

	// Token: 0x040096F4 RID: 38644
	private readonly Dictionary<string, List<int>> AreaQuestTrackingList = new Dictionary<string, List<int>>();
}
