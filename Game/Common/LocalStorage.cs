using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Common.LocalStorageJson;
using UnrealEngine;

namespace CSharpScript.Game.Common
{
	// Token: 0x0200705F RID: 28767
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalStorage : IStaticVariableResetter
	{
		// Token: 0x06045A73 RID: 285299 RVA: 0x01233AE4 File Offset: 0x01231CE4
		static LocalStorage()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LocalStorage.CreateStaticDefaultValue), new Action(LocalStorage.ResetStaticDefaultValue));
		}

		// Token: 0x06045A74 RID: 285300 RVA: 0x01233B48 File Offset: 0x01231D48
		private static string GetJournalMode(LocalStorage.EJournalMode mode)
		{
			switch (mode)
			{
			case LocalStorage.EJournalMode.Delete:
				return "PRAGMA journal_mode=DELETE";
			case LocalStorage.EJournalMode.Truncate:
				return "PRAGMA journal_mode=TRUNCATE";
			case LocalStorage.EJournalMode.Persist:
				return "PRAGMA journal_mode=PERSIST";
			case LocalStorage.EJournalMode.Memory:
				return "PRAGMA journal_mode=MEMORY";
			case LocalStorage.EJournalMode.Off:
				return "PRAGMA journal_mode=OFF";
			default:
				return "";
			}
		}

		// Token: 0x06045A75 RID: 285301 RVA: 0x01233B94 File Offset: 0x01231D94
		public static void Initialize()
		{
			if (LocalStorage.IsInited)
			{
				return;
			}
			LocalStorage.IsInited = true;
			LocalStorage.InitDbPath();
			LocalStorage.OpenOrCreateDb();
			LocalStorage.AddEventListener();
		}

		// Token: 0x06045A76 RID: 285302 RVA: 0x01233BB4 File Offset: 0x01231DB4
		public static void Destroy()
		{
			LocalStorage.PlayerId = null;
			LocalStorageCache cache = LocalStorage.Cache;
			if (cache != null)
			{
				cache.Clear();
			}
			LocalStorage.RemoveEventListener();
		}

		// Token: 0x06045A77 RID: 285303 RVA: 0x01233BD6 File Offset: 0x01231DD6
		public static bool HasPlayerId()
		{
			return LocalStorage.PlayerId != null;
		}

		// Token: 0x06045A78 RID: 285304 RVA: 0x01233BE4 File Offset: 0x01231DE4
		[NullableContext(2)]
		public static T GetGlobal<T>(ELocalStorageGlobalKey key, T defaultValue = default(T))
		{
			T result;
			if (!LocalStorage.IsInited)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.TL;
				string message = "GetGlobal LocalStorage未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				result = default(T);
				return result;
			}
			string text = LocalStorage.CheckAndGetGlobalKeyName(key);
			if (text == null)
			{
				result = default(T);
				return result;
			}
			string cacheEncodeValue = LocalStorage.GetCacheEncodeValue(text);
			if (!string.IsNullOrEmpty(cacheEncodeValue))
			{
				using (LocalStorageJsonContext.EnterScope(key))
				{
					return LocalStorageSerializer.Decode<T>(cacheEncodeValue);
				}
			}
			ValueTuple<bool, string> value = LocalStorage.GetValue(text, false);
			if (!value.Item1)
			{
				return default(T);
			}
			string item = value.Item2;
			if (string.IsNullOrEmpty(item))
			{
				return defaultValue;
			}
			using (LocalStorageJsonContext.EnterScope(key))
			{
				T t = LocalStorageSerializer.Decode<T>(item);
				LocalStorage.SetCacheValue(text, item);
				result = t;
			}
			return result;
		}

		// Token: 0x06045A79 RID: 285305 RVA: 0x01233CEC File Offset: 0x01231EEC
		[NullableContext(2)]
		public unsafe static bool SetGlobal<T>(ELocalStorageGlobalKey key, T value)
		{
			if (!LocalStorage.IsInited)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.TL;
				string message = "GetGlobal LocalStorage未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			string text = LocalStorage.CheckAndGetGlobalKeyName(key);
			if (text == null)
			{
				return false;
			}
			if (value == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LocalStorage;
				ELogAuthor author2 = ELogAuthor.MZJ;
				string message2 = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			bool result;
			using (LocalStorageJsonContext.EnterScope(key))
			{
				string text2 = LocalStorageSerializer.Encode<T>(value);
				if (text2 == null)
				{
					result = false;
				}
				else if (LocalStorage.GetCacheEncodeValue(text) == text2)
				{
					result = true;
				}
				else
				{
					LocalStorage.SetCacheValue(text, text2);
					result = LocalStorage.SetValue(text, text2, false);
				}
			}
			return result;
		}

		// Token: 0x06045A7A RID: 285306 RVA: 0x01233E00 File Offset: 0x01232000
		public static bool DeleteGlobal(ELocalStorageGlobalKey key)
		{
			string text = LocalStorage.CheckAndGetGlobalKeyName(key);
			return text != null && LocalStorage.DeleteKey(text, false);
		}

		// Token: 0x06045A7B RID: 285307 RVA: 0x01233E20 File Offset: 0x01232020
		[NullableContext(2)]
		public static T GetDeviceSaved<[Nullable(1)] T>(ELocalStorageDeviceKey key, T defaultValue = default(T)) where T : class
		{
			string text = LocalStorage.CheckAndGetDeviceKeyName(key);
			T result;
			if (text == null)
			{
				result = default(T);
				return result;
			}
			string cacheEncodeValue = LocalStorage.GetCacheEncodeValue(text);
			if (!string.IsNullOrEmpty(cacheEncodeValue))
			{
				using (LocalStorageJsonContext.EnterScope(key))
				{
					return LocalStorageSerializer.Decode<T>(cacheEncodeValue);
				}
			}
			ValueTuple<bool, string> value = LocalStorage.GetValue(text, true);
			if (!value.Item1)
			{
				return default(T);
			}
			string item = value.Item2;
			if (string.IsNullOrEmpty(item))
			{
				return defaultValue;
			}
			using (LocalStorageJsonContext.EnterScope(key))
			{
				T t = LocalStorageSerializer.Decode<T>(item);
				LocalStorage.SetCacheValue(text, item);
				result = t;
			}
			return result;
		}

		// Token: 0x06045A7C RID: 285308 RVA: 0x01233EE4 File Offset: 0x012320E4
		[NullableContext(2)]
		public unsafe static bool SetDeviceSaved<T>(ELocalStorageDeviceKey key, T value)
		{
			string text = LocalStorage.CheckAndGetDeviceKeyName(key);
			if (text == null)
			{
				return false;
			}
			if (value == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			bool result;
			using (LocalStorageJsonContext.EnterScope(key))
			{
				string text2 = LocalStorageSerializer.Encode<T>(value);
				if (text2 == null)
				{
					result = false;
				}
				else if (LocalStorage.GetCacheEncodeValue(text) == text2)
				{
					result = true;
				}
				else
				{
					LocalStorage.SetCacheValue(text, text2);
					result = LocalStorage.SetValue(text, text2, true);
				}
			}
			return result;
		}

		// Token: 0x06045A7D RID: 285309 RVA: 0x01233FC0 File Offset: 0x012321C0
		public static bool DeleteDeviceSaved(ELocalStorageDeviceKey key)
		{
			string text = LocalStorage.CheckAndGetDeviceKeyName(key);
			return text != null && LocalStorage.DeleteKey(text, true);
		}

		// Token: 0x06045A7E RID: 285310 RVA: 0x01233FE0 File Offset: 0x012321E0
		[NullableContext(2)]
		public static T GetPlayer<T>(ELocalStoragePlayerKey key, T defaultValue = default(T))
		{
			string text = LocalStorage.CheckAndGetPlayerKeyName(key);
			T result;
			if (text == null)
			{
				result = default(T);
				return result;
			}
			string cacheEncodeValue = LocalStorage.GetCacheEncodeValue(text);
			if (!string.IsNullOrEmpty(cacheEncodeValue))
			{
				using (LocalStorageJsonContext.EnterScope(key))
				{
					return LocalStorageSerializer.Decode<T>(cacheEncodeValue);
				}
			}
			ValueTuple<bool, string> value = LocalStorage.GetValue(text, false);
			if (!value.Item1)
			{
				return default(T);
			}
			string item = value.Item2;
			if (string.IsNullOrEmpty(item))
			{
				return defaultValue;
			}
			using (LocalStorageJsonContext.EnterScope(key))
			{
				T t = LocalStorageSerializer.Decode<T>(item);
				LocalStorage.SetCacheValue(text, item);
				result = t;
			}
			return result;
		}

		// Token: 0x06045A7F RID: 285311 RVA: 0x012340A4 File Offset: 0x012322A4
		public unsafe static bool SetPlayer<[Nullable(2)] T>(ELocalStoragePlayerKey key, T value)
		{
			string text = LocalStorage.CheckAndGetPlayerKeyName(key);
			if (text == null)
			{
				return false;
			}
			if (value == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			bool result;
			using (LocalStorageJsonContext.EnterScope(key))
			{
				string text2 = LocalStorageSerializer.Encode<T>(value);
				if (text2 == null)
				{
					result = false;
				}
				else if (LocalStorage.GetCacheEncodeValue(text) == text2)
				{
					result = true;
				}
				else
				{
					LocalStorage.SetCacheValue(text, text2);
					result = LocalStorage.SetValue(text, text2, false);
				}
			}
			return result;
		}

		// Token: 0x06045A80 RID: 285312 RVA: 0x01234180 File Offset: 0x01232380
		public static bool DeletePlayer(ELocalStoragePlayerKey key)
		{
			string text = LocalStorage.CheckAndGetPlayerKeyName(key);
			return text != null && LocalStorage.DeleteKey(text, false);
		}

		// Token: 0x06045A81 RID: 285313 RVA: 0x012341A0 File Offset: 0x012323A0
		private static void InitDbPath()
		{
			if (string.IsNullOrEmpty(LocalStorage.DbPath))
			{
				string str = UKuroLauncherLibrary.GameSavedDir();
				LocalStorage.DbPath = str + "LocalStorage/LocalStorage.db";
				LocalStorage.DeviceDbPath = str + "DeviceSaved/DeviceStorage.db";
			}
		}

		// Token: 0x06045A82 RID: 285314 RVA: 0x012341D4 File Offset: 0x012323D4
		private static bool OpenOrCreateDb()
		{
			string text = LocalStorage.DbPath;
			bool flag = UKuroSqliteLibrary.OpenCreateDB(text, true);
			if (!flag)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "打开DB失败！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbFilePath", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				for (int i = 2; i <= 10; i++)
				{
					text = UKuroLauncherLibrary.GameSavedDir() + "LocalStorage/LocalStorage" + i.ToString() + ".db";
					flag = UKuroSqliteLibrary.OpenCreateDB(text, true);
					if (flag)
					{
						LocalStorage.DbPath = text;
						break;
					}
				}
				if (!flag)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.LocalStorage;
					ELogAuthor author2 = ELogAuthor.MZJ;
					string message2 = "创建10次DB都失败！";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dbFilePath", text);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
			}
			UKuroSqliteLibrary.Execute(text, LocalStorage.GetJournalMode(LocalStorage.EJournalMode.Persist));
			string text2 = LocalStorage.DeviceDbPath;
			flag = UKuroSqliteLibrary.OpenCreateDB(text2, true);
			if (!flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LocalStorage;
				ELogAuthor author3 = ELogAuthor.LZP;
				string message3 = "打开DB失败！";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("deviceDbPath", text2);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				for (int j = 2; j <= 10; j++)
				{
					text2 = UKuroLauncherLibrary.GameSavedDir() + "DeviceSaved/DeviceStorage" + j.ToString() + ".db";
					flag = UKuroSqliteLibrary.OpenCreateDB(text2, true);
					if (flag)
					{
						LocalStorage.DeviceDbPath = text2;
						break;
					}
				}
				if (!flag)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.LocalStorage;
					ELogAuthor author4 = ELogAuthor.LZP;
					string message4 = "创建10次DB都失败！";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("deviceDbPath", text2);
					instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					return false;
				}
			}
			UKuroSqliteLibrary.Execute(text2, LocalStorage.GetJournalMode(LocalStorage.EJournalMode.Persist));
			return LocalStorage.CreateTable();
		}

		// Token: 0x06045A83 RID: 285315 RVA: 0x0123435C File Offset: 0x0123255C
		private static bool CreateTable()
		{
			string dbPath = LocalStorage.DbPath;
			string text = "create table if not exists LocalStorage(key text primary key not null , value text not null)";
			if (!UKuroSqliteLibrary.Execute(dbPath, text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "创建DbTable失败！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("command", text);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			bool flag = UKuroSqliteLibrary.Execute(LocalStorage.DeviceDbPath, text);
			if (!flag)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LocalStorage;
				ELogAuthor author2 = ELogAuthor.LZP;
				string message2 = "创建DeviceDbTable失败！";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("command", text);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return flag;
		}

		// Token: 0x06045A84 RID: 285316 RVA: 0x012343E0 File Offset: 0x012325E0
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static ValueTuple<bool, string> GetValue(string keyName, bool bIsDeviceDb)
		{
			string dbPath = bIsDeviceDb ? LocalStorage.DeviceDbPath : LocalStorage.DbPath;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT value FROM ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" WHERE key ='");
			defaultInterpolatedStringHandler.AppendFormatted(keyName);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			string item = null;
			int num = UKuroSqliteLibrary.QueryValue(dbPath, sql, ref item);
			if (num == -1)
			{
				return new ValueTuple<bool, string>(false, null);
			}
			if (num == 1)
			{
				return new ValueTuple<bool, string>(true, null);
			}
			return new ValueTuple<bool, string>(true, item);
		}

		// Token: 0x06045A85 RID: 285317 RVA: 0x01234470 File Offset: 0x01232670
		private static bool SetValue(string keyName, string value, bool bIsDeviceDb)
		{
			string dbPath = bIsDeviceDb ? LocalStorage.DeviceDbPath : LocalStorage.DbPath;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(82, 4);
			defaultInterpolatedStringHandler.AppendLiteral("insert into ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" (key,value) values('");
			defaultInterpolatedStringHandler.AppendFormatted(keyName);
			defaultInterpolatedStringHandler.AppendLiteral("' , '");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("') on CONFLICT(key) do update set value = '");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteLibrary.ExecuteAsync(dbPath, sql);
			return true;
		}

		// Token: 0x06045A86 RID: 285318 RVA: 0x01234507 File Offset: 0x01232707
		[return: Nullable(2)]
		private static string GetCacheEncodeValue(string keyName)
		{
			return LocalStorage.Cache.Get(keyName);
		}

		// Token: 0x06045A87 RID: 285319 RVA: 0x01234514 File Offset: 0x01232714
		private static void SetCacheValue(string keyName, string encodeValue)
		{
			LocalStorage.Cache.Set(keyName, encodeValue);
		}

		// Token: 0x06045A88 RID: 285320 RVA: 0x01234524 File Offset: 0x01232724
		private static bool DeleteKey(string key, bool bIsDeviceDb)
		{
			string dbPath = bIsDeviceDb ? LocalStorage.DeviceDbPath : LocalStorage.DbPath;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
			defaultInterpolatedStringHandler.AppendLiteral("delete from ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" where key = '");
			defaultInterpolatedStringHandler.AppendFormatted(key);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteLibrary.ExecuteAsync(dbPath, sql);
			return true;
		}

		// Token: 0x06045A89 RID: 285321 RVA: 0x01234593 File Offset: 0x01232793
		private static void AddEventListener()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ChangePlayerInfoId;
			Action<int> handle;
			if ((handle = LocalStorage.<>O.<0>__SetPlayerId) == null)
			{
				handle = (LocalStorage.<>O.<0>__SetPlayerId = new Action<int>(LocalStorage.SetPlayerId));
			}
			instance.Add(name, handle);
		}

		// Token: 0x06045A8A RID: 285322 RVA: 0x012345C0 File Offset: 0x012327C0
		private static void RemoveEventListener()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ChangePlayerInfoId;
			Action<int> handle;
			if ((handle = LocalStorage.<>O.<0>__SetPlayerId) == null)
			{
				handle = (LocalStorage.<>O.<0>__SetPlayerId = new Action<int>(LocalStorage.SetPlayerId));
			}
			instance.Remove(name, handle);
		}

		// Token: 0x06045A8B RID: 285323 RVA: 0x012345ED File Offset: 0x012327ED
		private static void SetPlayerId(int id)
		{
			LocalStorage.PlayerId = new int?(id);
			Singleton<EventSystem>.Instance.Emit(EEventName.LocalStorageInitPlayerId);
		}

		// Token: 0x06045A8C RID: 285324 RVA: 0x0123460C File Offset: 0x0123280C
		[NullableContext(2)]
		private static string CheckAndGetGlobalKeyName(ELocalStorageGlobalKey key)
		{
			string text = key.ToString();
			if (string.IsNullOrEmpty(text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "keyName值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return text;
		}

		// Token: 0x06045A8D RID: 285325 RVA: 0x01234664 File Offset: 0x01232864
		[NullableContext(2)]
		private static string CheckAndGetDeviceKeyName(ELocalStorageDeviceKey key)
		{
			string text = key.ToString();
			if (string.IsNullOrEmpty(text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "keyName值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return text;
		}

		// Token: 0x06045A8E RID: 285326 RVA: 0x012346BC File Offset: 0x012328BC
		[NullableContext(2)]
		private unsafe static string CheckAndGetPlayerKeyName(ELocalStoragePlayerKey key)
		{
			string text = key.ToString();
			if (string.IsNullOrEmpty(text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "keyName值非法！";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("keyName", text);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			if (LocalStorage.PlayerId == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LocalStorage;
				ELogAuthor author2 = ELogAuthor.MZJ;
				string message2 = "尚未获取到playerId，无法操作Player相关的存储值！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keyName", text);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(text);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int?>(LocalStorage.PlayerId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06045A8F RID: 285327 RVA: 0x012347A4 File Offset: 0x012329A4
		public static void CreateStaticDefaultValue()
		{
			LocalStorage.Cache = new LocalStorageCache();
		}

		// Token: 0x06045A90 RID: 285328 RVA: 0x012347B0 File Offset: 0x012329B0
		public static void ResetStaticDefaultValue()
		{
			LocalStorage.DbPath = null;
			LocalStorage.Cache = null;
			LocalStorage.DeviceDbPath = null;
			LocalStorage.PlayerId = null;
			LocalStorage.IsInited = false;
		}

		// Token: 0x04026E26 RID: 159270
		private const string DBPATH = "LocalStorage/LocalStorage";

		// Token: 0x04026E27 RID: 159271
		private const string DEVICEDBPATH = "DeviceSaved/DeviceStorage";

		// Token: 0x04026E28 RID: 159272
		private const string DBSUFFIX = ".db";

		// Token: 0x04026E29 RID: 159273
		private const string TABLENAME = "LocalStorage";

		// Token: 0x04026E2A RID: 159274
		private const int DBNUM = 10;

		// Token: 0x04026E2B RID: 159275
		private const bool ISUSEDB = true;

		// Token: 0x04026E2C RID: 159276
		private const bool USE_THREAD = true;

		// Token: 0x04026E2D RID: 159277
		private const bool USE_CACHE = true;

		// Token: 0x04026E2E RID: 159278
		private const int SQLITE_ERR = -1;

		// Token: 0x04026E2F RID: 159279
		private const int SQLITE_NO_DATA = 1;

		// Token: 0x04026E30 RID: 159280
		private const int CHECK_COMPLEX_THRESHOLD = 600;

		// Token: 0x04026E31 RID: 159281
		private const LocalStorage.EJournalMode USE_JOURNAL_MODE = LocalStorage.EJournalMode.Persist;

		// Token: 0x04026E32 RID: 159282
		[Nullable(2)]
		private static string DbPath;

		// Token: 0x04026E33 RID: 159283
		[Nullable(2)]
		private static string DeviceDbPath;

		// Token: 0x04026E34 RID: 159284
		private static int? PlayerId;

		// Token: 0x04026E35 RID: 159285
		[Nullable(2)]
		private static LocalStorageCache Cache;

		// Token: 0x04026E36 RID: 159286
		private static bool IsInited = false;

		// Token: 0x04026E37 RID: 159287
		[StaticVariableRuleIgnore]
		private static readonly Stat StatOpenOrCreateDb = Stat.Create("LocalStorage_OpenOrCreateDb", "", "");

		// Token: 0x04026E38 RID: 159288
		[StaticVariableRuleIgnore]
		private static readonly Stat StatCreateTable = Stat.Create("LocalStorage_CreateTable", "", "");

		// Token: 0x0200CC7D RID: 52349
		[NullableContext(0)]
		private enum EJournalMode
		{
			// Token: 0x0403EB07 RID: 256775
			Delete,
			// Token: 0x0403EB08 RID: 256776
			Truncate,
			// Token: 0x0403EB09 RID: 256777
			Persist,
			// Token: 0x0403EB0A RID: 256778
			Memory,
			// Token: 0x0403EB0B RID: 256779
			Off
		}

		// Token: 0x0200CC7E RID: 52350
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403EB0C RID: 256780
			[Nullable(0)]
			public static Action<int> <0>__SetPlayerId;
		}
	}
}
