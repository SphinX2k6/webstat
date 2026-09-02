using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using CSharpScript.Launcher.Util.Json;
using UnrealEngine;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044AA RID: 17578
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherStorageLib : Singleton<LauncherStorageLib>
	{
		// Token: 0x0602E55C RID: 189788 RVA: 0x00AE1184 File Offset: 0x00ADF384
		private static string GetJournalMode(LauncherStorageLib.EJournalMode mode)
		{
			switch (mode)
			{
			case LauncherStorageLib.EJournalMode.Delete:
				return "PRAGMA journal_mode=DELETE";
			case LauncherStorageLib.EJournalMode.Truncate:
				return "PRAGMA journal_mode=TRUNCATE";
			case LauncherStorageLib.EJournalMode.Persist:
				return "PRAGMA journal_mode=PERSIST";
			case LauncherStorageLib.EJournalMode.Memory:
				return "PRAGMA journal_mode=MEMORY";
			case LauncherStorageLib.EJournalMode.Off:
				return "PRAGMA journal_mode=OFF";
			default:
				return "PRAGMA journal_mode=PERSIST";
			}
		}

		// Token: 0x0602E55D RID: 189789 RVA: 0x00AE11D0 File Offset: 0x00ADF3D0
		public unsafe void LockDbPath(bool isLockDbPath, string reason)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "[LauncherStorageLib][LockDbPath] 设置锁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isLockDbPath", isLockDbPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.IsDbPathLocked = isLockDbPath;
		}

		// Token: 0x0602E55E RID: 189790 RVA: 0x00AE1238 File Offset: 0x00ADF438
		public void Initialize()
		{
			if (this.IsInit)
			{
				return;
			}
			this.IsInit = true;
			this.InitDbPath();
			this.OpenOrCreateDb();
		}

		// Token: 0x0602E55F RID: 189791 RVA: 0x00AE1257 File Offset: 0x00ADF457
		public void Destroy()
		{
		}

		// Token: 0x0602E560 RID: 189792 RVA: 0x00AE125C File Offset: 0x00ADF45C
		[NullableContext(2)]
		public T GetGlobal<T>(ELauncherStorageGlobalKey key, T defaultValue = default(T))
		{
			string text = this.CheckAndGetGlobalKeyName(key);
			if (text == null)
			{
				return default(T);
			}
			ValueTuple<bool, string> value = this.GetValue(text, false);
			bool item = value.Item1;
			string item2 = value.Item2;
			if (!item)
			{
				return default(T);
			}
			if (item2 == null)
			{
				return defaultValue;
			}
			return LauncherStorageLib.Decode<T>(item2);
		}

		// Token: 0x0602E561 RID: 189793 RVA: 0x00AE12AC File Offset: 0x00ADF4AC
		public unsafe bool SetGlobal<[Nullable(2)] T>(ELauncherStorageGlobalKey key, T value)
		{
			string text = this.CheckAndGetGlobalKeyName(key);
			if (text == null)
			{
				return false;
			}
			if (value == null)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			string text2 = LauncherStorageLib.Encode<T>(value);
			return text2 != null && this.SetValue(text, text2, false);
		}

		// Token: 0x0602E562 RID: 189794 RVA: 0x00AE133C File Offset: 0x00ADF53C
		public bool DeleteGlobal(ELauncherStorageGlobalKey key)
		{
			string text = this.CheckAndGetGlobalKeyName(key);
			return text != null && this.DeleteKey(text, false);
		}

		// Token: 0x0602E563 RID: 189795 RVA: 0x00AE1360 File Offset: 0x00ADF560
		[NullableContext(2)]
		public T GetDeviceSaved<T>(ELauncherStorageDeviceKey key, T defaultValue = default(T))
		{
			string text = this.CheckAndGetDeviceKeyName(key);
			if (text == null)
			{
				return default(T);
			}
			ValueTuple<bool, string> value = this.GetValue(text, true);
			bool item = value.Item1;
			string item2 = value.Item2;
			if (!item)
			{
				return default(T);
			}
			if (item2 == null)
			{
				return defaultValue;
			}
			return LauncherStorageLib.Decode<T>(item2);
		}

		// Token: 0x0602E564 RID: 189796 RVA: 0x00AE13B0 File Offset: 0x00ADF5B0
		public unsafe bool SetDeviceSaved<[Nullable(2)] T>(ELauncherStorageDeviceKey key, T value)
		{
			string text = this.CheckAndGetDeviceKeyName(key);
			if (text == null)
			{
				return false;
			}
			if (value == null)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			string text2 = LauncherStorageLib.Encode<T>(value);
			return text2 != null && this.SetValue(text, text2, true);
		}

		// Token: 0x0602E565 RID: 189797 RVA: 0x00AE1440 File Offset: 0x00ADF640
		public bool DeleteDeviceSaved(ELauncherStorageDeviceKey key)
		{
			string text = this.CheckAndGetDeviceKeyName(key);
			return text != null && this.DeleteKey(text, true);
		}

		// Token: 0x0602E566 RID: 189798 RVA: 0x00AE1464 File Offset: 0x00ADF664
		[NullableContext(2)]
		public string GetDeviceSavedString([Nullable(1)] string key, string defaultValue = null)
		{
			if (string.IsNullOrEmpty(key))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "key值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			ValueTuple<bool, string> value = this.GetValue(key, true);
			bool item = value.Item1;
			string item2 = value.Item2;
			if (!item)
			{
				return null;
			}
			if (item2 == null)
			{
				return defaultValue;
			}
			return LauncherStorageLib.Decode<string>(item2);
		}

		// Token: 0x0602E567 RID: 189799 RVA: 0x00AE14C4 File Offset: 0x00ADF6C4
		public unsafe bool SetDeviceSavedString(string key, string value)
		{
			if (string.IsNullOrEmpty(key))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "key值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (value == null)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "value值非法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance2.Error(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			string text = LauncherStorageLib.Encode<string>(value);
			return text != null && this.SetValue(key, text, true);
		}

		// Token: 0x0602E568 RID: 189800 RVA: 0x00AE1568 File Offset: 0x00ADF768
		public bool DeleteDeviceSavedString(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "key值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return this.DeleteKey(key, true);
		}

		// Token: 0x0602E569 RID: 189801 RVA: 0x00AE15AC File Offset: 0x00ADF7AC
		private void InitDbPath()
		{
			string str = UKuroLauncherLibrary.GameSavedDir();
			if (this.DbPath == null)
			{
				this.DbPath = str + "LocalStorage/LocalStorage.db";
			}
			if (this.DeviceDbPath == null)
			{
				this.DeviceDbPath = str + "DeviceSaved/DeviceStorage.db";
			}
		}

		// Token: 0x0602E56A RID: 189802 RVA: 0x00AE15F4 File Offset: 0x00ADF7F4
		private bool OpenOrCreateDb()
		{
			if (!this.IsDbPathLocked)
			{
				string text = this.DbPath;
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "OpenSync";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dbFilePath", text);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				bool flag = UKuroSqliteLibrary.OpenCreateDB(text, false);
				if (!flag)
				{
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "打开DB失败！";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dbFilePath", text);
					instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					for (int i = 2; i <= 10; i++)
					{
						text = UKuroLauncherLibrary.GameSavedDir() + "LocalStorage/LocalStorage" + i.ToString() + ".db";
						flag = UKuroSqliteLibrary.OpenCreateDB(text, false);
						if (flag)
						{
							this.DbPath = text;
							break;
						}
					}
					if (!flag)
					{
						LauncherLog instance3 = Singleton<LauncherLog>.Instance;
						string message3 = "创建10次DB都失败！";
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("dbFilePath", text);
						instance3.Error(message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
						return false;
					}
				}
				UKuroSqliteLibrary.Execute(text, LauncherStorageLib.GetJournalMode(LauncherStorageLib.EJournalMode.Persist));
			}
			string text2 = this.DeviceDbPath;
			LauncherLog instance4 = Singleton<LauncherLog>.Instance;
			string message4 = "OpenSync";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("deviceDbPath", text2);
			instance4.Info(message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			bool flag2 = UKuroSqliteLibrary.OpenCreateDB(text2, false);
			if (!flag2)
			{
				LauncherLog instance5 = Singleton<LauncherLog>.Instance;
				string message5 = "打开DB失败！";
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("deviceDbPath", text2);
				instance5.Error(message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
				for (int j = 2; j <= 10; j++)
				{
					text2 = UKuroLauncherLibrary.GameSavedDir() + "DeviceSaved/DeviceStorage" + j.ToString() + ".db";
					flag2 = UKuroSqliteLibrary.OpenCreateDB(text2, false);
					if (flag2)
					{
						this.DeviceDbPath = text2;
						break;
					}
				}
				if (!flag2)
				{
					LauncherLog instance6 = Singleton<LauncherLog>.Instance;
					string message6 = "创建10次DB都失败！";
					ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("deviceDbPath", text2);
					instance6.Error(message6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
					return false;
				}
			}
			UKuroSqliteLibrary.Execute(text2, LauncherStorageLib.GetJournalMode(LauncherStorageLib.EJournalMode.Persist));
			return this.CreateTable();
		}

		// Token: 0x0602E56B RID: 189803 RVA: 0x00AE17C4 File Offset: 0x00ADF9C4
		private bool CreateTable()
		{
			string text = "create table if not exists LocalStorage(key text primary key not null , value text not null)";
			if (!this.IsDbPathLocked && !UKuroSqliteLibrary.Execute(this.DbPath, text))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "创建DbTable失败！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("command", text);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			bool flag = UKuroSqliteLibrary.Execute(this.DeviceDbPath, text);
			if (!flag)
			{
				LauncherLog instance2 = Singleton<LauncherLog>.Instance;
				string message2 = "创建DeviceDbTable失败！";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("command", text);
				instance2.Error(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return flag;
		}

		// Token: 0x0602E56C RID: 189804 RVA: 0x00AE1844 File Offset: 0x00ADFA44
		[return: TupleElementNames(new string[]
		{
			"success",
			"value"
		})]
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private ValueTuple<bool, string> GetValue(string keyName, bool bIsDeviceDb)
		{
			if (!bIsDeviceDb && this.IsDbPathLocked)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[LauncherStorageLib][LockDbPath] 获取默认值";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("keyName", keyName);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new ValueTuple<bool, string>(true, null);
			}
			string dbPath = bIsDeviceDb ? this.DeviceDbPath : this.DbPath;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT value FROM ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" WHERE key ='");
			defaultInterpolatedStringHandler.AppendFormatted(keyName);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			if (!UKuroSqliteLibrary.Query(dbPath, sql, ukuroSqliteResultSet))
			{
				return new ValueTuple<bool, string>(false, null);
			}
			if (!ukuroSqliteResultSet.HasValue())
			{
				ukuroSqliteResultSet.Release();
				return new ValueTuple<bool, string>(true, null);
			}
			string item = "";
			if (!ukuroSqliteResultSet.GetString("value", ref item))
			{
				ukuroSqliteResultSet.Release();
				return new ValueTuple<bool, string>(true, null);
			}
			ukuroSqliteResultSet.Release();
			return new ValueTuple<bool, string>(true, item);
		}

		// Token: 0x0602E56D RID: 189805 RVA: 0x00AE1940 File Offset: 0x00ADFB40
		private unsafe bool SetValue(string keyName, string value, bool bIsDeviceDb)
		{
			if (!bIsDeviceDb && this.IsDbPathLocked)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[LauncherStorageLib][LockDbPath] 跳过设置值";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("keyName", keyName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("value", value);
				instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return true;
			}
			string dbPath = bIsDeviceDb ? this.DeviceDbPath : this.DbPath;
			string value2 = value.Replace("'", "''");
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(82, 4);
			defaultInterpolatedStringHandler.AppendLiteral("insert into ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" (key,value) values('");
			defaultInterpolatedStringHandler.AppendFormatted(keyName);
			defaultInterpolatedStringHandler.AppendLiteral("' , '");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("') on CONFLICT(key) do update set value = '");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			return UKuroSqliteLibrary.Execute(dbPath, sql);
		}

		// Token: 0x0602E56E RID: 189806 RVA: 0x00AE1A48 File Offset: 0x00ADFC48
		private bool DeleteKey(string key, bool bIsDeviceDb)
		{
			if (!bIsDeviceDb && this.IsDbPathLocked)
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "[LauncherStorageLib][LockDbPath] 跳过删除值";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return true;
			}
			string dbPath = bIsDeviceDb ? this.DeviceDbPath : this.DbPath;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
			defaultInterpolatedStringHandler.AppendLiteral("delete from ");
			defaultInterpolatedStringHandler.AppendFormatted("LocalStorage");
			defaultInterpolatedStringHandler.AppendLiteral(" where key = '");
			defaultInterpolatedStringHandler.AppendFormatted(key);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			return UKuroSqliteLibrary.Execute(dbPath, sql);
		}

		// Token: 0x0602E56F RID: 189807 RVA: 0x00AE1AE8 File Offset: 0x00ADFCE8
		[NullableContext(2)]
		private string CheckAndGetGlobalKeyName(ELauncherStorageGlobalKey key)
		{
			string text = key.ToString();
			if (string.IsNullOrEmpty(text))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "keyName值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return text;
		}

		// Token: 0x0602E570 RID: 189808 RVA: 0x00AE1B38 File Offset: 0x00ADFD38
		[NullableContext(2)]
		private string CheckAndGetDeviceKeyName(ELauncherStorageDeviceKey key)
		{
			string text = key.ToString();
			if (string.IsNullOrEmpty(text))
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "keyName值非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return text;
		}

		// Token: 0x0602E571 RID: 189809 RVA: 0x00AE1B88 File Offset: 0x00ADFD88
		[NullableContext(2)]
		private unsafe static string Encode<T>([Nullable(1)] T value)
		{
			try
			{
				JsonSerializerOptions serializerOptions = LauncherJsonSettings.GetSerializerOptions<T>();
				return JsonSerializer.Serialize<T>(value, serializerOptions);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "序列化异常";
				Exception error = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("value", value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("type", typeof(T).Name);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			return null;
		}

		// Token: 0x0602E572 RID: 189810 RVA: 0x00AE1C48 File Offset: 0x00ADFE48
		[NullableContext(2)]
		private unsafe static T Decode<T>([Nullable(1)] string text)
		{
			try
			{
				JsonSerializerOptions serializerOptions = LauncherJsonSettings.GetSerializerOptions<T>();
				return JsonSerializer.Deserialize<T>(text, serializerOptions);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LocalStorage;
				ELogAuthor author = ELogAuthor.MZJ;
				string message = "反序列化异常";
				Exception error = ex;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("text", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("type", typeof(T).Name);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			return default(T);
		}

		// Token: 0x0602E573 RID: 189811 RVA: 0x00AE1D0C File Offset: 0x00ADFF0C
		[NullableContext(2)]
		private static object Replacer(object value)
		{
			if (value == null)
			{
				return ESpecialValue.Undefined.ToEnumString();
			}
			if (value is double)
			{
				double d = (double)value;
				if (double.IsNaN(d))
				{
					return ESpecialValue.NaN.ToEnumString();
				}
				if (double.IsPositiveInfinity(d))
				{
					return ESpecialValue.Infinity.ToEnumString();
				}
				if (double.IsNegativeInfinity(d))
				{
					return ESpecialValue.InfinityNegative.ToEnumString();
				}
			}
			if (value is bool)
			{
				if (!(bool)value)
				{
					return ESpecialValue.BooleanFalse.ToEnumString();
				}
				return ESpecialValue.BooleanTrue.ToEnumString();
			}
			else
			{
				if (value is long)
				{
					return value.ToString() + ESpecialValue.BigInt.ToEnumString();
				}
				IDictionary dictionary = value as IDictionary;
				if (dictionary != null)
				{
					List<object> list = new List<object>();
					foreach (object obj in dictionary)
					{
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
						list.Add(new object[]
						{
							LauncherStorageLib.Replacer(dictionaryEntry.Key),
							LauncherStorageLib.Replacer(dictionaryEntry.Value)
						});
					}
					Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
					dictionary2["___MetaType___"] = EMetaType.Map.ToEnumString();
					dictionary2["Content"] = list;
					return dictionary2;
				}
				if (value != null && value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(HashSet<>))
				{
					List<object> list2 = new List<object>();
					foreach (object value2 in ((IEnumerable)value))
					{
						list2.Add(LauncherStorageLib.Replacer(value2));
					}
					Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
					dictionary3["___MetaType___"] = EMetaType.Set.ToEnumString();
					dictionary3["Content"] = list2;
					return dictionary3;
				}
				IList list3 = value as IList;
				if (list3 != null)
				{
					List<object> list4 = new List<object>();
					foreach (object value3 in list3)
					{
						list4.Add(LauncherStorageLib.Replacer(value3));
					}
					return list4;
				}
				return value;
			}
		}

		// Token: 0x0602E574 RID: 189812 RVA: 0x00AE1F58 File Offset: 0x00AE0158
		[NullableContext(2)]
		private static object Reviver(object key, object value)
		{
			if (value == null)
			{
				return null;
			}
			string text = value as string;
			if (text == null)
			{
				Dictionary<string, object> dictionary = value as Dictionary<string, object>;
				object obj;
				if (dictionary != null && dictionary.TryGetValue("___MetaType___", out obj))
				{
					string text2 = obj as string;
					if (text2 != null)
					{
						object obj2;
						if (text2 == EMetaType.Map.ToEnumString() && dictionary.TryGetValue("Content", out obj2))
						{
							IList list = obj2 as IList;
							if (list != null)
							{
								Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
								foreach (object obj3 in list)
								{
									IList list2 = obj3 as IList;
									if (list2 != null && list2.Count >= 2)
									{
										object obj4 = LauncherStorageLib.Reviver(null, list2[0]);
										string key2 = ((obj4 != null) ? obj4.ToString() : null) ?? "";
										dictionary2[key2] = LauncherStorageLib.Reviver(list2[0], list2[1]);
									}
								}
								return dictionary2;
							}
						}
						object obj5;
						if (text2 == EMetaType.Set.ToEnumString() && dictionary.TryGetValue("Content", out obj5))
						{
							IList list3 = obj5 as IList;
							if (list3 != null)
							{
								HashSet<object> hashSet = new HashSet<object>();
								foreach (object value2 in list3)
								{
									hashSet.Add(LauncherStorageLib.Reviver(null, value2));
								}
								return hashSet;
							}
						}
					}
				}
				return value;
			}
			if (text == ESpecialValue.Undefined.ToEnumString())
			{
				return null;
			}
			if (text == ESpecialValue.NaN.ToEnumString())
			{
				return double.NaN;
			}
			if (text == ESpecialValue.Infinity.ToEnumString())
			{
				return double.PositiveInfinity;
			}
			if (text == ESpecialValue.InfinityNegative.ToEnumString())
			{
				return double.NegativeInfinity;
			}
			if (text == ESpecialValue.BooleanTrue.ToEnumString())
			{
				return true;
			}
			if (text == ESpecialValue.BooleanFalse.ToEnumString())
			{
				return false;
			}
			string text3 = ESpecialValue.BigInt.ToEnumString();
			if (text.EndsWith(text3, StringComparison.Ordinal))
			{
				return long.Parse(text.Substring(0, text.Length - text3.Length));
			}
			return text;
		}

		// Token: 0x0401A560 RID: 107872
		private const string DBPATH = "LocalStorage/LocalStorage";

		// Token: 0x0401A561 RID: 107873
		private const string DEVICEDBPATH = "DeviceSaved/DeviceStorage";

		// Token: 0x0401A562 RID: 107874
		private const string DBSUFFIX = ".db";

		// Token: 0x0401A563 RID: 107875
		private const string TABLENAME = "LocalStorage";

		// Token: 0x0401A564 RID: 107876
		private const int DBNUM = 10;

		// Token: 0x0401A565 RID: 107877
		private const bool USE_THREAD = false;

		// Token: 0x0401A566 RID: 107878
		private const int SQLITE_ERR = -1;

		// Token: 0x0401A567 RID: 107879
		private const int SQLITE_NO_DATA = 1;

		// Token: 0x0401A568 RID: 107880
		private const LauncherStorageLib.EJournalMode USE_JOURNAL_MODE = LauncherStorageLib.EJournalMode.Persist;

		// Token: 0x0401A569 RID: 107881
		[Nullable(2)]
		private string DbPath;

		// Token: 0x0401A56A RID: 107882
		[Nullable(2)]
		private string DeviceDbPath;

		// Token: 0x0401A56B RID: 107883
		private bool IsInit;

		// Token: 0x0401A56C RID: 107884
		private bool IsDbPathLocked;

		// Token: 0x0200A67E RID: 42622
		[NullableContext(0)]
		private enum EJournalMode
		{
			// Token: 0x04033784 RID: 210820
			Delete,
			// Token: 0x04033785 RID: 210821
			Truncate,
			// Token: 0x04033786 RID: 210822
			Persist,
			// Token: 0x04033787 RID: 210823
			Memory,
			// Token: 0x04033788 RID: 210824
			Off
		}
	}
}
