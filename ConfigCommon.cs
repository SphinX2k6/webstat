using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Config;
using CSharpScript.Core.Extensions;
using Google.FlatBuffers;
using UnrealEngine;

// Token: 0x02000058 RID: 88
[NullableContext(2)]
[Nullable(0)]
public class ConfigCommon : IStaticVariableResetter
{
	// Token: 0x060001B7 RID: 439 RVA: 0x0000A2F0 File Offset: 0x000084F0
	static ConfigCommon()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ConfigCommon.CreateStaticDefaultValue), new Action(ConfigCommon.ResetStaticDefaultValue));
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0000A310 File Offset: 0x00008510
	public static void CreateStaticDefaultValue()
	{
		ConfigCommon.ProjectContentDir = "";
		ConfigCommon.HandleIdMap = new Dictionary<string, Dictionary<string, int>>();
		ConfigCommon.LruBuffer = new TrimLru<string, ByteBuffer>(2000, false);
		ConfigCommon.Lru = new TrimLru<string, object>(3000, false);
		ConfigCommon.InitDataStatementStat = Stat.Create("ConfigCommon.InitDataStatement", "", "");
		ConfigCommon.GetLangStatementIdStat = Stat.Create("ConfigCommon.GetLangStatementId", "", "");
		ConfigCommon.BindBigIntStat = Stat.Create("ConfigCommon.BindBigInt", "", "");
		ConfigCommon.BindIntStat = Stat.Create("ConfigCommon.BindInt", "", "");
		ConfigCommon.BindFloatStat = Stat.Create("ConfigCommon.BindFloat", "", "");
		ConfigCommon.BindBoolStat = Stat.Create("ConfigCommon.BindBool", "", "");
		ConfigCommon.BindStringStat = Stat.Create("ConfigCommon.BindString", "", "");
		ConfigCommon.BindFloat64Stat = Stat.Create("ConfigCommon.BindFloat64Stat", "", "");
		ConfigCommon.GetValueStat = Stat.Create("ConfigCommon.GetValue", "", "");
		ConfigCommon.GetValueIntStat = Stat.Create("ConfigCommon.GetValueInt", "", "");
		ConfigCommon.AllConfigStatementStat = Stat.Create("ConfigCommon.AllConfig", "", "");
		ConfigCommon.IsUseDynamicConnectDb = true;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0000A46C File Offset: 0x0000866C
	public static void ResetStaticDefaultValue()
	{
		ConfigCommon.ProjectContentDir = null;
		ConfigCommon.HandleIdMap = null;
		ConfigCommon.LruBuffer = null;
		ConfigCommon.Lru = null;
		ConfigCommon.InitDataStatementStat = null;
		ConfigCommon.GetLangStatementIdStat = null;
		ConfigCommon.BindBigIntStat = null;
		ConfigCommon.BindIntStat = null;
		ConfigCommon.BindFloatStat = null;
		ConfigCommon.BindBoolStat = null;
		ConfigCommon.BindStringStat = null;
		ConfigCommon.BindFloat64Stat = null;
		ConfigCommon.GetValueStat = null;
		ConfigCommon.GetValueIntStat = null;
		ConfigCommon.AllConfigStatementStat = null;
		ConfigCommon.IsUseDynamicConnectDb = true;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0000A4D9 File Offset: 0x000086D9
	public static void SetLruBufferCapacity(int capacity)
	{
		if (ConfigCommon.LruBuffer != null)
		{
			ConfigCommon.LruBuffer.Capacity = capacity;
		}
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0000A4ED File Offset: 0x000086ED
	public static void SetLruCapacity(int capacity)
	{
		if (ConfigCommon.Lru != null)
		{
			ConfigCommon.Lru.Capacity = capacity;
		}
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0000A501 File Offset: 0x00008701
	public static void SetDynamicConnectDb(bool isDynamic)
	{
		ConfigCommon.IsUseDynamicConnectDb = isDynamic;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0000A509 File Offset: 0x00008709
	public static bool GetDynamicConnectDb()
	{
		return ConfigCommon.IsUseDynamicConnectDb;
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000A510 File Offset: 0x00008710
	[NullableContext(1)]
	public static void SaveConfig(string key, object config, int valueSize = 1)
	{
		ConfigCommon.Lru.Put(key, config, valueSize);
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000A520 File Offset: 0x00008720
	[NullableContext(1)]
	[return: Nullable(2)]
	public static object GetConfig(string key)
	{
		return ConfigCommon.Lru.Get(key);
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000A52D File Offset: 0x0000872D
	[NullableContext(1)]
	public static void SaveConfigBuffer(string key, ByteBuffer configBuffer, int valueSize = 1)
	{
		ConfigCommon.LruBuffer.Put(key, configBuffer, valueSize);
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000A53D File Offset: 0x0000873D
	[NullableContext(1)]
	[return: Nullable(2)]
	public static ByteBuffer GetConfigBuffer(string key)
	{
		return ConfigCommon.LruBuffer.Get(key);
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000A54C File Offset: 0x0000874C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public static List<T> ToList<T>([Nullable(new byte[]
	{
		2,
		1
	})] IReadOnlyList<T> readonlyArray)
	{
		if (readonlyArray == null)
		{
			return null;
		}
		List<T> list = new List<T>(readonlyArray.Count);
		for (int i = 0; i < readonlyArray.Count; i++)
		{
			list.Add(readonlyArray[i]);
		}
		return list;
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000A589 File Offset: 0x00008789
	[NullableContext(1)]
	public static string GetProjectContentDir()
	{
		if (string.IsNullOrEmpty(ConfigCommon.ProjectContentDir))
		{
			ConfigCommon.ProjectContentDir = UBlueprintPathsLibrary.ProjectContentDir();
		}
		return ConfigCommon.ProjectContentDir;
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0000A5A8 File Offset: 0x000087A8
	[NullableContext(1)]
	public unsafe static int InitDataStatement(int handleId, string dbName, string command)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.InitDataStatement(handleId, dbName, command);
		}
		if (handleId != 0)
		{
			return handleId;
		}
		if (string.IsNullOrEmpty(dbName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LZP, "dbName为空！请确认该配置表在拆分Db表中是否有正确配置！", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		string text = Path.Combine(ConfigCommon.GetProjectContentDir(), "Aki/ConfigDB", dbName);
		int num = ConfigStatementLibSync.CreateStatement(text, command);
		if (num != -2)
		{
			if (num == -1)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.LZP;
				string message = "找不到Db连接";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Config;
			ELogAuthor author2 = ELogAuthor.LZP;
			string message2 = "创建语句失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("command", command);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return num;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000A68C File Offset: 0x0000888C
	[NullableContext(1)]
	public unsafe static int GetLangStatementId(string tableName, string dbName, string command, string culture = "")
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.GetLangStatementId(tableName, dbName, command, culture);
		}
		if (string.IsNullOrEmpty(dbName))
		{
			Singleton<Log>.Instance.Error(ELogModule.Config, ELogAuthor.LZP, "dbName为空！请确认该配置表在拆分Db表中是否有正确配置！", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		string text = (!string.IsNullOrEmpty(culture)) ? culture : Singleton<LanguageSystem>.Instance.PackageLanguage;
		string key = dbName + tableName;
		Dictionary<string, int> dictionary;
		if (!ConfigCommon.HandleIdMap.TryGetValue(key, out dictionary))
		{
			dictionary = new Dictionary<string, int>();
			ConfigCommon.HandleIdMap[key] = dictionary;
		}
		int num;
		if (!dictionary.TryGetValue(text, out num))
		{
			string text2 = Path.Combine(ConfigCommon.GetProjectContentDir(), "Aki/ConfigDB/" + text, dbName);
			num = ConfigStatementLibSync.CreateStatement(text2, command);
			if (num != -2)
			{
				if (num == -1)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Config;
					ELogAuthor author = ELogAuthor.LZP;
					string message = "找不到语言表Db连接";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", text2);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Config;
				ELogAuthor author2 = ELogAuthor.LZP;
				string message2 = "创建语言表语句失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("path", text2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("command", command);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			dictionary[text] = num;
		}
		return num;
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000A7CC File Offset: 0x000089CC
	[NullableContext(1)]
	public static void ClearLangAllStatementId(string tableName, string dbName)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			CommonDbConnectManager.ClearLangAllStatementId(tableName, dbName);
			return;
		}
		string key = dbName + tableName;
		Dictionary<string, int> dictionary;
		if (ConfigCommon.HandleIdMap.TryGetValue(key, out dictionary) && dictionary.Count > 0)
		{
			foreach (int inId in dictionary.Values)
			{
				UKuroPrepareStatementLib.DestroyStatement(inId);
			}
		}
		ConfigCommon.HandleIdMap.Remove(key);
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000A858 File Offset: 0x00008A58
	public static bool CheckStatement(int handleId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.CheckStatement(handleId, pairs);
		}
		bool result = true;
		string text = "";
		switch (handleId)
		{
		case -2:
			text = "语句创建不成功！";
			break;
		case -1:
			text = "找不到该语句的 DB 连接！";
			break;
		case 0:
			text = "语句未初始化！";
			break;
		}
		if (!string.IsNullOrEmpty(text))
		{
			result = false;
			Singleton<Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.LZP, text, pairs);
		}
		return result;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000A8C4 File Offset: 0x00008AC4
	public static bool BindBigInt(int handleId, int bindingIndex, long value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindBigInt(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueBigInt(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 int64 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000A934 File Offset: 0x00008B34
	public static bool BindInt(int handleId, int bindingIndex, int value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindInt(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueInt(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 int32 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000A9A4 File Offset: 0x00008BA4
	public static bool BindFloat(int handleId, int bindingIndex, float value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindFloat(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueFloat(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 float 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000AA14 File Offset: 0x00008C14
	public static bool BindFloat64(int handleId, int bindingIndex, double value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindFloat64(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueFloat64(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.CYK;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 float64 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000AA88 File Offset: 0x00008C88
	public static bool BindBool(int handleId, int bindingIndex, bool value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindBool(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueBool(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 bool 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000AAF8 File Offset: 0x00008CF8
	[NullableContext(1)]
	public static bool BindString(int handleId, int bindingIndex, string value, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.BindString(handleId, bindingIndex, value, pairs);
		}
		bool flag = UKuroPrepareStatementLib.SetBindingValueString(handleId, bindingIndex, value);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
			defaultInterpolatedStringHandler.AppendLiteral("绑定参数 string 失败 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			defaultInterpolatedStringHandler.AppendLiteral(" bindingIndex ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(bindingIndex);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000AB68 File Offset: 0x00008D68
	public static void ClearBind(int handleId)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			CommonDbConnectManager.ClearBind(handleId);
			return;
		}
		UKuroPrepareStatementLib.ClearBindings(handleId);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0000AB80 File Offset: 0x00008D80
	public static bool Reset(int handleId, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.Reset(handleId, pairs);
		}
		bool flag = UKuroPrepareStatementLib.Reset(handleId);
		if (!flag)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("重置语句失败！ handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return flag;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000ABD8 File Offset: 0x00008DD8
	public static int Step(int handleId, bool errZero = false, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.Step(handleId, errZero, pairs);
		}
		int result = UKuroPrepareStatementLib.Step(handleId);
		string value = "";
		switch (result)
		{
		case -4:
			value = "执行查询出错！";
			break;
		case -3:
			value = "事务繁忙中，查询失败！";
			break;
		case -2:
			value = "创建的语句无效或已被释放！";
			break;
		case -1:
			value = "找不到创建的语句，确认语句是否已调用过销毁，但业务还持有着句柄！";
			break;
		case 0:
			value = (errZero ? "配置表中没有该数据，请确认该问题，或修改为合理的查询！" : null);
			break;
		}
		if (!string.IsNullOrEmpty(value))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(" handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		return result;
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0000AC94 File Offset: 0x00008E94
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public static ValueTuple<bool, byte[]> GetValue(int handleId, int columnIndex, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.GetValue(handleId, columnIndex, pairs);
		}
		FArrayBuffer buffer = default(FArrayBuffer);
		bool columnValueBytes = UKuroPrepareStatementLib.GetColumnValueBytes(handleId, columnIndex, ref buffer);
		if (!columnValueBytes)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Config;
			ELogAuthor author = ELogAuthor.LZP;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("获取配置表字段数值出错 handleId ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(handleId);
			instance.ErrorWithLogList(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), pairs);
		}
		byte[] item = columnValueBytes ? buffer.ToByteArray() : null;
		return new ValueTuple<bool, byte[]>(columnValueBytes, item);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000AD0C File Offset: 0x00008F0C
	[NullableContext(0)]
	public static ValueTuple<bool, int?> GetValueInt(int handleId, int columnIndex, [ParamCollection] [Nullable(new byte[]
	{
		1,
		0,
		1,
		2
	})] LogList<ValueTuple<string, object>> pairs)
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			return CommonDbConnectManager.GetValueInt(handleId, columnIndex, pairs);
		}
		int num = 0;
		bool columnValueInt = UKuroPrepareStatementLib.GetColumnValueInt32(handleId, columnIndex, ref num);
		if (!columnValueInt)
		{
			pairs.Add(new ValueTuple<string, object>("handleId", handleId));
			Singleton<Log>.Instance.ErrorWithLogList(ELogModule.Config, ELogAuthor.CYK, "获取配置表int字段数值出错", pairs);
		}
		int value = columnValueInt ? num : 0;
		return new ValueTuple<bool, int?>(columnValueInt, new int?(value));
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0000AD74 File Offset: 0x00008F74
	public static void CloseAllConnection()
	{
		if (ConfigCommon.IsUseDynamicConnectDb)
		{
			CommonDbConnectManager.CloseAllConnection();
			return;
		}
		ConfigStatementLibSync.CloseAllConnection();
	}

	// Token: 0x0400018F RID: 399
	private static string ProjectContentDir;

	// Token: 0x04000190 RID: 400
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private static Dictionary<string, Dictionary<string, int>> HandleIdMap;

	// Token: 0x04000191 RID: 401
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static TrimLru<string, ByteBuffer> LruBuffer;

	// Token: 0x04000192 RID: 402
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static TrimLru<string, object> Lru;

	// Token: 0x04000193 RID: 403
	private static Stat InitDataStatementStat;

	// Token: 0x04000194 RID: 404
	private static Stat GetLangStatementIdStat;

	// Token: 0x04000195 RID: 405
	private static Stat BindBigIntStat;

	// Token: 0x04000196 RID: 406
	private static Stat BindIntStat;

	// Token: 0x04000197 RID: 407
	private static Stat BindFloatStat;

	// Token: 0x04000198 RID: 408
	private static Stat BindBoolStat;

	// Token: 0x04000199 RID: 409
	private static Stat BindStringStat;

	// Token: 0x0400019A RID: 410
	private static Stat BindFloat64Stat;

	// Token: 0x0400019B RID: 411
	private static Stat GetValueStat;

	// Token: 0x0400019C RID: 412
	private static Stat GetValueIntStat;

	// Token: 0x0400019D RID: 413
	public static Stat AllConfigStatementStat;

	// Token: 0x0400019E RID: 414
	public static bool IsUseDynamicConnectDb;
}
