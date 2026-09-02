using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200465A RID: 18010
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherConfigLib : Singleton<LauncherConfigLib>
	{
		// Token: 0x0602EFC5 RID: 192453 RVA: 0x00B21A80 File Offset: 0x00B1FC80
		public void Initialize()
		{
			if (this.IsInit)
			{
				return;
			}
			this.IsInit = true;
			string str = KuroApplication.ProjectContentDir();
			this.BaseDir = str + "Aki/ConfigDB/";
			string tableName = LauncherMenuConfig.GetTableName();
			string tableName2 = LauncherServerLimitConfig.GetTableName();
			string tableName3 = LauncherDownLoadConfig.GetTableName();
			int num = 0;
			TArray<string> tarray = UKuroStaticLibrary.LoadFileToStringArray(str + "Aki/ConfigDB/aki_base.csv");
			for (int i = 1; i < tarray.Num(); i++)
			{
				string[] array = tarray.Get(i).Split(',', StringSplitOptions.None);
				if (array.Length > 2)
				{
					if (this.MenuConfigDbInfo == null && array[0] == tableName)
					{
						this.MenuConfigDbInfo = new DbInfo(this.BaseDir + array[1], array[2]);
						num++;
					}
					if (this.ServerLimitConfigDbInfo == null && array[0] == tableName2)
					{
						this.ServerLimitConfigDbInfo = new DbInfo(this.BaseDir + array[1], array[2]);
						num++;
					}
					if (this.DownLoadDbInfo == null && array[0] == tableName3)
					{
						this.DownLoadDbInfo = new DbInfo(this.BaseDir + array[1], array[2]);
						num++;
					}
					if (num >= 3)
					{
						break;
					}
				}
			}
		}

		// Token: 0x0602EFC6 RID: 192454 RVA: 0x00B21BC4 File Offset: 0x00B1FDC4
		public LauncherMenuConfig GetMenuConfigByFunctionId(int functionId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT * FROM `");
			defaultInterpolatedStringHandler.AppendFormatted(LauncherMenuConfig.GetTableName());
			defaultInterpolatedStringHandler.AppendLiteral("` WHERE FunctionId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(functionId);
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			LauncherMenuConfig result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.MenuConfigDbInfo.ConfigDbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询LauncherMenuConfig失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", functionId);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = null;
				}
				else
				{
					result = LauncherMenuConfig.Parse(ukuroSqliteResultSet);
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602EFC7 RID: 192455 RVA: 0x00B21C80 File Offset: 0x00B1FE80
		public LaunchGameSettingMenuConfig GetGameSettingsMenuConfigByFunctionId(int functionId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT * FROM `");
			defaultInterpolatedStringHandler.AppendFormatted(LaunchGameSettingMenuConfig.GetTableName());
			defaultInterpolatedStringHandler.AppendLiteral("` WHERE FunctionId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(functionId);
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			LaunchGameSettingMenuConfig result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.MenuConfigDbInfo.ConfigDbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询LauncherMenuConfig失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("functionId", functionId);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = null;
				}
				else
				{
					result = LaunchGameSettingMenuConfig.Parse(ukuroSqliteResultSet);
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602EFC8 RID: 192456 RVA: 0x00B21D3C File Offset: 0x00B1FF3C
		public LauncherServerLimitConfig GetServerLimitConfig(string regionId)
		{
			string sql = "SELECT * FROM `" + LauncherServerLimitConfig.GetTableName() + "` WHERE Id=" + regionId;
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			LauncherServerLimitConfig result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.ServerLimitConfigDbInfo.ConfigDbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询LauncherServerLimitConfig失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("regionId", regionId);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = null;
				}
				else
				{
					result = LauncherServerLimitConfig.Parse(ukuroSqliteResultSet);
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602EFC9 RID: 192457 RVA: 0x00B21DC8 File Offset: 0x00B1FFC8
		public unsafe bool IsLanguageValid(string languageCode)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT * FROM `");
			defaultInterpolatedStringHandler.AppendFormatted(LauncherMenuConfig.GetLanguageTableName());
			defaultInterpolatedStringHandler.AppendLiteral("` WHERE LanguageCode='");
			defaultInterpolatedStringHandler.AppendFormatted(languageCode);
			defaultInterpolatedStringHandler.AppendLiteral("'");
			string sql = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			bool result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.MenuConfigDbInfo.ConfigDbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询LanguageDefine失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("languageCode", languageCode);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = false;
				}
				else
				{
					LaunchLanguageDefineConfig launchLanguageDefineConfig = LauncherMenuConfig.ParseLanguageDefine(ukuroSqliteResultSet);
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "读取到的多语言配置";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("languageCode", languageCode);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("config", launchLanguageDefineConfig);
					instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					result = (launchLanguageDefineConfig != null && launchLanguageDefineConfig.IsShow);
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602EFCA RID: 192458 RVA: 0x00B21EEC File Offset: 0x00B200EC
		[return: Nullable(2)]
		public unsafe string GetHotPatchText(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return null;
			}
			string text = null;
			if (this.HotPatchTextMap.TryGetValue(id, out text))
			{
				return text;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
			defaultInterpolatedStringHandler.AppendLiteral("SELECT * FROM `");
			defaultInterpolatedStringHandler.AppendFormatted("HotPatchText");
			defaultInterpolatedStringHandler.AppendLiteral("` WHERE Id=\"");
			defaultInterpolatedStringHandler.AppendFormatted(id);
			defaultInterpolatedStringHandler.AppendLiteral("\"");
			string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			string result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.GetTextDbPath("lang_hot_patch.db", null), text2, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询HotPatchText多语言表失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("textId", id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DB", this.GetTextDbPath("lang_hot_patch.db", null));
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("command", text2);
					instance.Error(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					result = null;
				}
				else if (!ukuroSqliteResultSet.GetString("Content", ref text))
				{
					Singleton<LauncherLog>.Instance.Error("获取HotPatchText多语言数据字段失败，没有Content字段", default(ReadOnlySpan<ValueTuple<string, object>>));
					result = null;
				}
				else
				{
					this.HotPatchTextMap[id] = text;
					result = text;
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0602EFCB RID: 192459 RVA: 0x00B22054 File Offset: 0x00B20254
		private string GetTextDbPath(string dbName, string culture = null)
		{
			string str = ((!string.IsNullOrEmpty(culture)) ? culture : Singleton<LauncherLanguageLib>.Instance.GetPackageLanguage()) + "/" + dbName;
			return this.BaseDir + str;
		}

		// Token: 0x0602EFCC RID: 192460 RVA: 0x00B22090 File Offset: 0x00B20290
		public unsafe LauncherDownLoadConfig GetDownLoadTabConfig(string regionId)
		{
			string sql = "SELECT * FROM `" + LauncherDownLoadConfig.GetTableName() + "` WHERE Id=" + regionId;
			UKuroSqliteResultSet ukuroSqliteResultSet = new UKuroSqliteResultSet();
			LauncherDownLoadConfig result;
			try
			{
				if (!UKuroSqliteLibrary.Query(this.DownLoadDbInfo.ConfigDbPath, sql, ukuroSqliteResultSet) || !ukuroSqliteResultSet.HasValue())
				{
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "查询LauncherDownLoadConfig失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("regionId", regionId);
					instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					result = null;
				}
				else
				{
					LauncherDownLoadConfig launcherDownLoadConfig = LauncherDownLoadConfig.Parse(ukuroSqliteResultSet);
					LauncherLog instance2 = Singleton<LauncherLog>.Instance;
					string message2 = "GetDownLoadTabConfig";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("config.Id", regionId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("config", launcherDownLoadConfig);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("rs.IsValid();", ukuroSqliteResultSet.IsValid());
					instance2.Info(message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					result = launcherDownLoadConfig;
				}
			}
			finally
			{
				ukuroSqliteResultSet.Release();
			}
			return result;
		}

		// Token: 0x0401ABFB RID: 109563
		private string BaseDir = "";

		// Token: 0x0401ABFC RID: 109564
		private DbInfo MenuConfigDbInfo;

		// Token: 0x0401ABFD RID: 109565
		private DbInfo ServerLimitConfigDbInfo;

		// Token: 0x0401ABFE RID: 109566
		private DbInfo DownLoadDbInfo;

		// Token: 0x0401ABFF RID: 109567
		private readonly Dictionary<string, string> HotPatchTextMap = new Dictionary<string, string>();

		// Token: 0x0401AC00 RID: 109568
		private bool IsInit;

		// Token: 0x0401AC01 RID: 109569
		private const string DB = "lang_hot_patch.db";

		// Token: 0x0401AC02 RID: 109570
		private const string TABLE = "HotPatchText";
	}
}
