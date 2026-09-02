using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extensions;
using UnrealEngine;

namespace CSharpScript.Core.Config
{
	// Token: 0x02007142 RID: 28994
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonDbConnectManager : IStaticVariableResetter
	{
		// Token: 0x06046330 RID: 287536 RVA: 0x0126FE1C File Offset: 0x0126E01C
		static CommonDbConnectManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CommonDbConnectManager.CreateStaticDefaultValue), new Action(CommonDbConnectManager.ResetStaticDefaultValue));
		}

		// Token: 0x06046331 RID: 287537 RVA: 0x0126FE45 File Offset: 0x0126E045
		private static int CreateIncrementId()
		{
			return ++CommonDbConnectManager.IncrementId;
		}

		// Token: 0x06046332 RID: 287538 RVA: 0x0126FE54 File Offset: 0x0126E054
		[NullableContext(1)]
		private static ConnectDbObject LruCreator(int incrementId)
		{
			CommonDbData dbData;
			if (CommonDbConnectManager.CommonDbDataMap.TryGetValue(incrementId, out dbData))
			{
				ConnectDbObject connectDbObject = new ConnectDbObject();
				connectDbObject.ConnectStatement(dbData);
				return connectDbObject;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(59, 1);
			defaultInterpolatedStringHandler.AppendLiteral("创建 ConnectDbObject失败, incrementId:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(incrementId);
			defaultInterpolatedStringHandler.AppendLiteral("，可能是没有执行InitConnectDbData");
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06046333 RID: 287539 RVA: 0x0126FEB3 File Offset: 0x0126E0B3
		[NullableContext(1)]
		private static void LruClearer(ConnectDbObject data)
		{
			data.DisConnectStatement();
		}

		// Token: 0x06046334 RID: 287540 RVA: 0x0126FEBC File Offset: 0x0126E0BC
		private static ConnectDbObject CreateOrGetConnectDbObject(int incrementId)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.DbConnectLru.Get(incrementId);
			if (connectDbObject == null)
			{
				CommonDbData commonDbData;
				if (CommonDbConnectManager.EditorCheckDbReconnectCreated != null && CommonDbConnectManager.CommonDbDataMap.TryGetValue(incrementId, out commonDbData) && CommonDbConnectManager.EditorCheckDbReconnectCreated(commonDbData))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.CommonDbConnect;
					ELogAuthor author = ELogAuthor.JYT;
					string message = "[EditorCheckDbReconnectCreated] 编辑器检查阻止Db重连";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbName", commonDbData.DbName);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return null;
				}
				connectDbObject = CommonDbConnectManager.DbConnectLru.Create(incrementId);
			}
			CommonDbConnectManager.DbConnectLru.Put(connectDbObject);
			return connectDbObject;
		}

		// Token: 0x06046335 RID: 287541 RVA: 0x0126FF44 File Offset: 0x0126E144
		[NullableContext(1)]
		private static CommonDbData InitConnectDbData(string dbName, string command, string culture)
		{
			int num = CommonDbConnectManager.CreateIncrementId();
			CommonDbData commonDbData = new CommonDbData(num, dbName, command, culture);
			CommonDbConnectManager.CommonDbDataMap[num] = commonDbData;
			return commonDbData;
		}

		// Token: 0x06046336 RID: 287542 RVA: 0x0126FF70 File Offset: 0x0126E170
		[NullableContext(1)]
		public static int InitDataStatement(int incrementId, string dbName, string command)
		{
			if (incrementId != 0)
			{
				return incrementId;
			}
			if (string.IsNullOrEmpty(dbName))
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "dbName为空！请确认该配置表在拆分Db表中是否有正确配置！", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return CommonDbConnectManager.InitConnectDbData(dbName, command, string.Empty).IncrementId;
		}

		// Token: 0x06046337 RID: 287543 RVA: 0x0126FFB8 File Offset: 0x0126E1B8
		[NullableContext(1)]
		public unsafe static int GetLangStatementId(string tableName, string dbName, string command, string culture = "")
		{
			if (string.IsNullOrEmpty(dbName))
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "dbName为空！请确认该配置表在拆分Db表中是否有正确配置！", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			string text = (!string.IsNullOrEmpty(culture)) ? culture : Singleton<LanguageSystem>.Instance.PackageLanguage;
			string key = dbName + tableName;
			Dictionary<string, int> dictionary;
			if (!CommonDbConnectManager.HandleIdMap.TryGetValue(key, out dictionary))
			{
				dictionary = new Dictionary<string, int>();
				CommonDbConnectManager.HandleIdMap[key] = dictionary;
			}
			int result;
			if (dictionary.TryGetValue(text, out result))
			{
				return result;
			}
			CommonDbData commonDbData = CommonDbConnectManager.InitConnectDbData(dbName, command, text);
			int incrementId = commonDbData.IncrementId;
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(commonDbData.IncrementId);
			if (connectDbObject == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CommonDbConnect;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "创建Db连接对象失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbName", dbName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return incrementId;
			}
			int handleId = connectDbObject.HandleId;
			if (handleId != -2)
			{
				if (handleId == -1)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.CommonDbConnect;
					ELogAuthor author2 = ELogAuthor.XXJ;
					string message2 = "找不到语言表Db连接";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dbName", dbName);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.CommonDbConnect;
				ELogAuthor author3 = ELogAuthor.XXJ;
				string message3 = "创建语言表语句失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dbName", dbName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("command", command);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			dictionary[text] = incrementId;
			return incrementId;
		}

		// Token: 0x06046338 RID: 287544 RVA: 0x0127011C File Offset: 0x0126E31C
		[NullableContext(1)]
		public static void ClearLangAllStatementId(string tableName, string dbName)
		{
			string key = dbName + tableName;
			Dictionary<string, int> dictionary;
			if (CommonDbConnectManager.HandleIdMap.TryGetValue(key, out dictionary) && dictionary.Count > 0)
			{
				foreach (int inId in dictionary.Values)
				{
					UKuroPrepareStatementLib.DestroyStatement(inId);
				}
			}
			CommonDbConnectManager.HandleIdMap.Remove(key);
		}

		// Token: 0x06046339 RID: 287545 RVA: 0x01270198 File Offset: 0x0126E398
		public static bool CheckStatement(int incrementId, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			string text = string.Empty;
			bool result = true;
			if (incrementId <= 0)
			{
				text = "未调用InitDataStatement进行初始化";
			}
			else
			{
				ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
				if (connectDbObject == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[CheckStatement]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
					return false;
				}
				switch (connectDbObject.HandleId)
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
			}
			if (!string.IsNullOrEmpty(text))
			{
				result = false;
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, text, pairs);
			}
			return result;
		}

		// Token: 0x0604633A RID: 287546 RVA: 0x01270234 File Offset: 0x0126E434
		public static bool BindBigInt(int incrementId, int bindingIndex, long value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindBigInt]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueBigInt(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 int64 失败", pairs);
			}
			return flag;
		}

		// Token: 0x0604633B RID: 287547 RVA: 0x012702D4 File Offset: 0x0126E4D4
		public static bool BindInt(int incrementId, int bindingIndex, int value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindInt]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueInt(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 int32 失败", pairs);
			}
			return flag;
		}

		// Token: 0x0604633C RID: 287548 RVA: 0x01270374 File Offset: 0x0126E574
		public static bool BindFloat(int incrementId, int bindingIndex, float value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindFloat]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueFloat(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 float 失败", pairs);
			}
			return flag;
		}

		// Token: 0x0604633D RID: 287549 RVA: 0x01270414 File Offset: 0x0126E614
		public static bool BindFloat64(int incrementId, int bindingIndex, double value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindFloat64]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueFloat64(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 float64 失败", pairs);
			}
			return flag;
		}

		// Token: 0x0604633E RID: 287550 RVA: 0x012704B4 File Offset: 0x0126E6B4
		public static bool BindBool(int incrementId, int bindingIndex, bool value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindBool]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueBool(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 bool 失败", pairs);
			}
			return flag;
		}

		// Token: 0x0604633F RID: 287551 RVA: 0x01270554 File Offset: 0x0126E754
		[NullableContext(1)]
		public static bool BindString(int incrementId, int bindingIndex, string value, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[BindString]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.SetBindingValueString(handleId, bindingIndex, value);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				pairs.Add(new ValueTuple<string, object>("bindingIndex", bindingIndex));
				pairs.Add(new ValueTuple<string, object>("value", value));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "绑定参数 string 失败", pairs);
			}
			return flag;
		}

		// Token: 0x06046340 RID: 287552 RVA: 0x012705EC File Offset: 0x0126E7EC
		public static bool Reset(int incrementId, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[Reset]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int handleId = connectDbObject.HandleId;
			bool flag = UKuroPrepareStatementLib.Reset(handleId);
			if (!flag)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "重置语句失败！", pairs);
			}
			return flag;
		}

		// Token: 0x06046341 RID: 287553 RVA: 0x0127065C File Offset: 0x0126E85C
		public static int Step(int incrementId, bool errZero = false, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[Step]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return 0;
			}
			int handleId = connectDbObject.HandleId;
			int result = UKuroPrepareStatementLib.Step(handleId);
			string text = null;
			switch (result)
			{
			case -4:
				text = "执行查询出错！";
				break;
			case -3:
				text = "事务繁忙中，查询失败！";
				break;
			case -2:
				text = "创建的语句无效或已被释放！";
				break;
			case -1:
				text = "找不到创建的语句，确认语句是否已调用过销毁，但业务还持有着句柄！";
				break;
			case 0:
				text = (errZero ? "配置表中没有该数据，请确认该问题，或修改为合理的查询！" : null);
				break;
			}
			if (text != null)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, text, pairs);
			}
			return result;
		}

		// Token: 0x06046342 RID: 287554 RVA: 0x01270718 File Offset: 0x0126E918
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static ValueTuple<bool, byte[]> GetValue(int incrementId, int columnIndex, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[GetValue]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(87, 2);
				defaultInterpolatedStringHandler.AppendLiteral("CommonDbConnectManager->GetValue失败, incrementId:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(incrementId);
				defaultInterpolatedStringHandler.AppendLiteral("，columnIndex:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(columnIndex);
				defaultInterpolatedStringHandler.AppendLiteral(" 未调用InitDataStatement进行初始化");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			int handleId = connectDbObject.HandleId;
			FArrayBuffer buffer = default(FArrayBuffer);
			bool columnValueBytes = UKuroPrepareStatementLib.GetColumnValueBytes(handleId, columnIndex, ref buffer);
			if (!columnValueBytes)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "获取配置表字段数值出错", pairs);
			}
			byte[] item = columnValueBytes ? buffer.ToByteArray() : null;
			return new ValueTuple<bool, byte[]>(columnValueBytes, item);
		}

		// Token: 0x06046343 RID: 287555 RVA: 0x012707EC File Offset: 0x0126E9EC
		[NullableContext(0)]
		public static ValueTuple<bool, int?> GetValueInt(int incrementId, int columnIndex, [ParamCollection] [Nullable(new byte[]
		{
			1,
			0,
			1,
			2
		})] LogList<ValueTuple<string, object>> pairs)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.CreateOrGetConnectDbObject(incrementId);
			if (connectDbObject == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[GetValueInt]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new ValueTuple<bool, int?>(false, null);
			}
			int handleId = connectDbObject.HandleId;
			int num = 0;
			bool columnValueInt = UKuroPrepareStatementLib.GetColumnValueInt32(handleId, columnIndex, ref num);
			if (!columnValueInt)
			{
				pairs.Add(new ValueTuple<string, object>("handleId", handleId));
				Singleton<Log>.Instance.ErrorWithLogList(ELogModule.CommonDbConnect, ELogAuthor.CYK, "获取配置表int字段数值出错", pairs);
			}
			int value = columnValueInt ? num : 0;
			return new ValueTuple<bool, int?>(columnValueInt, new int?(value));
		}

		// Token: 0x06046344 RID: 287556 RVA: 0x01270884 File Offset: 0x0126EA84
		public static void ClearBind(int incrementId)
		{
			ConnectDbObject connectDbObject = CommonDbConnectManager.DbConnectLru.Get(incrementId);
			if (connectDbObject != null)
			{
				connectDbObject.DisConnectStatement();
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[ClearBind]未调用InitDataStatement进行初始化", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06046345 RID: 287557 RVA: 0x012708C4 File Offset: 0x0126EAC4
		[NullableContext(1)]
		public static bool UnloadDb(string dbName)
		{
			bool flag = false;
			int num = 0;
			string b = CommonDbConnectManager.NormalizeDbName(dbName);
			foreach (KeyValuePair<int, CommonDbData> keyValuePair in CommonDbConnectManager.CommonDbDataMap)
			{
				if (CommonDbConnectManager.NormalizeDbName(keyValuePair.Value.DbName) == b)
				{
					ConnectDbObject connectDbObject = CommonDbConnectManager.DbConnectLru.Get(keyValuePair.Key);
					if (connectDbObject != null)
					{
						num++;
						flag = CommonDbConnectManager.DbConnectLru.RemoveExternal(connectDbObject);
						connectDbObject.DisConnectStatement();
					}
				}
			}
			if (flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CommonDbConnect;
				ELogAuthor author = ELogAuthor.JYT;
				string message = "卸载数据库成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbName", dbName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else if (num == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CommonDbConnect;
				ELogAuthor author2 = ELogAuthor.JYT;
				string message2 = "未找到可卸载的数据库连接";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dbName", dbName);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.CommonDbConnect;
				ELogAuthor author3 = ELogAuthor.JYT;
				string message3 = "卸载数据库失败";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("dbName", dbName);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			}
			return flag;
		}

		// Token: 0x06046346 RID: 287558 RVA: 0x012709E4 File Offset: 0x0126EBE4
		public static void CloseAllConnection()
		{
			Singleton<Log>.Instance.Info(ELogModule.CommonDbConnect, ELogAuthor.XXJ, "[CloseAllConnection]关闭所有Db连接", default(ReadOnlySpan<ValueTuple<string, object>>));
			CommonDbConnectManager.DbConnectLru.Clear();
			CommonDbConnectManager.HandleIdMap.Clear();
			CommonDbConnectManager.CommonDbDataMap.Clear();
			ConfigStatementLibSync.CloseAllConnection();
		}

		// Token: 0x06046347 RID: 287559 RVA: 0x01270A30 File Offset: 0x0126EC30
		public static void LogConnection()
		{
			int size = CommonDbConnectManager.DbConnectLru.Size;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonDbConnect;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[LogConnection]连接Db数量";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("connectionCount", size);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06046348 RID: 287560 RVA: 0x01270A74 File Offset: 0x0126EC74
		public static void DynamicChangeLruCapacity(int capacity)
		{
			CommonDbConnectManager.DbConnectLru.Capacity = capacity;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonDbConnect;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[DynamicChangeLruCapacity]修改Db连接LRU容量";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("capacity", capacity);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06046349 RID: 287561 RVA: 0x01270AB8 File Offset: 0x0126ECB8
		[NullableContext(1)]
		private static string NormalizeDbName(string dbName)
		{
			return dbName.Trim().ToLowerInvariant();
		}

		// Token: 0x0604634A RID: 287562 RVA: 0x01270AC8 File Offset: 0x0126ECC8
		public static void CreateStaticDefaultValue()
		{
			CommonDbConnectManager.InitDataStatementStat = Stat.Create("CommonDbConnectManager.InitDataStatement", "", "");
			CommonDbConnectManager.GetLangStatementIdStat = Stat.Create("CommonDbConnectManager.GetLangStatementId", "", "");
			CommonDbConnectManager.BindBigIntStat = Stat.Create("CommonDbConnectManager.BindBigInt", "", "");
			CommonDbConnectManager.BindIntStat = Stat.Create("CommonDbConnectManager.BindInt", "", "");
			CommonDbConnectManager.BindFloatStat = Stat.Create("CommonDbConnectManager.BindFloat", "", "");
			CommonDbConnectManager.BindBoolStat = Stat.Create("CommonDbConnectManager.BindBool", "", "");
			CommonDbConnectManager.BindStringStat = Stat.Create("CommonDbConnectManager.BindString", "", "");
			CommonDbConnectManager.BindFloat64Stat = Stat.Create("CommonDbConnectManager.BindFloat64Stat", "", "");
			CommonDbConnectManager.GetValueStat = Stat.Create("CommonDbConnectManager.GetValue", "", "");
			CommonDbConnectManager.GetValueIntStat = Stat.Create("CommonDbConnectManager.GetValueInt", "", "");
			CommonDbConnectManager.IncrementId = 0;
			CommonDbConnectManager.HandleIdMap = new Dictionary<string, Dictionary<string, int>>();
			CommonDbConnectManager.CommonDbDataMap = new Dictionary<int, CommonDbData>();
			CommonDbConnectManager.EditorCheckDbReconnectCreated = null;
			int db_CONNECT_LRU_SIZE = CommonDbConnectManager.DB_CONNECT_LRU_SIZE;
			Func<int, ConnectDbObject> creator;
			if ((creator = CommonDbConnectManager.<>O.<0>__LruCreator) == null)
			{
				creator = (CommonDbConnectManager.<>O.<0>__LruCreator = new Func<int, ConnectDbObject>(CommonDbConnectManager.LruCreator));
			}
			Action<ConnectDbObject> clearer;
			if ((clearer = CommonDbConnectManager.<>O.<1>__LruClearer) == null)
			{
				clearer = (CommonDbConnectManager.<>O.<1>__LruClearer = new Action<ConnectDbObject>(CommonDbConnectManager.LruClearer));
			}
			CommonDbConnectManager.DbConnectLru = new Lru<int, ConnectDbObject>(db_CONNECT_LRU_SIZE, creator, clearer);
		}

		// Token: 0x0604634B RID: 287563 RVA: 0x01270C34 File Offset: 0x0126EE34
		public static void ResetStaticDefaultValue()
		{
			CommonDbConnectManager.InitDataStatementStat = null;
			CommonDbConnectManager.GetLangStatementIdStat = null;
			CommonDbConnectManager.BindBigIntStat = null;
			CommonDbConnectManager.BindIntStat = null;
			CommonDbConnectManager.BindFloatStat = null;
			CommonDbConnectManager.BindBoolStat = null;
			CommonDbConnectManager.BindStringStat = null;
			CommonDbConnectManager.BindFloat64Stat = null;
			CommonDbConnectManager.GetValueStat = null;
			CommonDbConnectManager.GetValueIntStat = null;
			CommonDbConnectManager.IncrementId = 0;
			CommonDbConnectManager.HandleIdMap = null;
			CommonDbConnectManager.CommonDbDataMap = null;
			CommonDbConnectManager.EditorCheckDbReconnectCreated = null;
			CommonDbConnectManager.DbConnectLru = null;
		}

		// Token: 0x040275A4 RID: 161188
		private static readonly int DB_CONNECT_LRU_SIZE = 200;

		// Token: 0x040275A5 RID: 161189
		private static Stat InitDataStatementStat;

		// Token: 0x040275A6 RID: 161190
		private static Stat GetLangStatementIdStat;

		// Token: 0x040275A7 RID: 161191
		private static Stat BindBigIntStat;

		// Token: 0x040275A8 RID: 161192
		private static Stat BindIntStat;

		// Token: 0x040275A9 RID: 161193
		private static Stat BindFloatStat;

		// Token: 0x040275AA RID: 161194
		private static Stat BindBoolStat;

		// Token: 0x040275AB RID: 161195
		private static Stat BindStringStat;

		// Token: 0x040275AC RID: 161196
		private static Stat BindFloat64Stat;

		// Token: 0x040275AD RID: 161197
		private static Stat GetValueStat;

		// Token: 0x040275AE RID: 161198
		private static Stat GetValueIntStat;

		// Token: 0x040275AF RID: 161199
		private static int IncrementId;

		// Token: 0x040275B0 RID: 161200
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private static Dictionary<string, Dictionary<string, int>> HandleIdMap;

		// Token: 0x040275B1 RID: 161201
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<int, CommonDbData> CommonDbDataMap;

		// Token: 0x040275B2 RID: 161202
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Lru<int, ConnectDbObject> DbConnectLru;

		// Token: 0x040275B3 RID: 161203
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Func<CommonDbData, bool> EditorCheckDbReconnectCreated;

		// Token: 0x0200CCE6 RID: 52454
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403ED4F RID: 257359
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Func<int, ConnectDbObject> <0>__LruCreator;

			// Token: 0x0403ED50 RID: 257360
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<ConnectDbObject> <1>__LruClearer;
		}
	}
}
