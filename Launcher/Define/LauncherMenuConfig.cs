using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004661 RID: 18017
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherMenuConfig
	{
		// Token: 0x0602EFD8 RID: 192472 RVA: 0x00B222EB File Offset: 0x00B204EB
		private LauncherMenuConfig(int functionId, int optionsDefault)
		{
			this.FunctionId = functionId;
			this.OptionsDefault = optionsDefault;
		}

		// Token: 0x0602EFD9 RID: 192473 RVA: 0x00B22301 File Offset: 0x00B20501
		public static string GetTableName()
		{
			return "MenuConfig";
		}

		// Token: 0x0602EFDA RID: 192474 RVA: 0x00B22308 File Offset: 0x00B20508
		public static string GetLanguageTableName()
		{
			return "LanguageDefine";
		}

		// Token: 0x0602EFDB RID: 192475 RVA: 0x00B2230F File Offset: 0x00B2050F
		public static string GetTableFile()
		{
			return "s.设置系统.xlsx";
		}

		// Token: 0x0602EFDC RID: 192476 RVA: 0x00B22318 File Offset: 0x00B20518
		public static LauncherMenuConfig Parse(UKuroSqliteResultSet rs)
		{
			int functionId = 0;
			if (!rs.GetInt("FunctionId", ref functionId))
			{
				return null;
			}
			int optionsDefault = 0;
			if (!rs.GetInt("OptionsDefault", ref optionsDefault))
			{
				return null;
			}
			return new LauncherMenuConfig(functionId, optionsDefault);
		}

		// Token: 0x0602EFDD RID: 192477 RVA: 0x00B22354 File Offset: 0x00B20554
		public static LaunchLanguageDefineConfig ParseLanguageDefine(UKuroSqliteResultSet rs)
		{
			int languageType = 0;
			if (!rs.GetInt("LanguageType", ref languageType))
			{
				return null;
			}
			bool isShow = false;
			if (!rs.GetBool("IsShow", ref isShow))
			{
				return null;
			}
			return new LaunchLanguageDefineConfig(languageType, isShow);
		}

		// Token: 0x0401AC31 RID: 109617
		private const string TableName = "MenuConfig";

		// Token: 0x0401AC32 RID: 109618
		private const string LanguageTableName = "LanguageDefine";

		// Token: 0x0401AC33 RID: 109619
		private const string TableFile = "s.设置系统.xlsx";

		// Token: 0x0401AC34 RID: 109620
		public readonly int FunctionId;

		// Token: 0x0401AC35 RID: 109621
		public readonly int OptionsDefault;
	}
}
