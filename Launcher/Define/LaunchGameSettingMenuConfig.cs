using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004663 RID: 18019
	[NullableContext(1)]
	[Nullable(0)]
	public class LaunchGameSettingMenuConfig
	{
		// Token: 0x170080B4 RID: 32948
		// (get) Token: 0x0602EFE3 RID: 192483 RVA: 0x00B223DE File Offset: 0x00B205DE
		// (set) Token: 0x0602EFE4 RID: 192484 RVA: 0x00B223E6 File Offset: 0x00B205E6
		public int FunctionId { get; private set; }

		// Token: 0x170080B5 RID: 32949
		// (get) Token: 0x0602EFE5 RID: 192485 RVA: 0x00B223EF File Offset: 0x00B205EF
		// (set) Token: 0x0602EFE6 RID: 192486 RVA: 0x00B223F7 File Offset: 0x00B205F7
		public int OptionsDefault { get; private set; }

		// Token: 0x170080B6 RID: 32950
		// (get) Token: 0x0602EFE7 RID: 192487 RVA: 0x00B22400 File Offset: 0x00B20600
		// (set) Token: 0x0602EFE8 RID: 192488 RVA: 0x00B22408 File Offset: 0x00B20608
		public float SliderDefault { get; private set; }

		// Token: 0x0602EFE9 RID: 192489 RVA: 0x00B22411 File Offset: 0x00B20611
		private LaunchGameSettingMenuConfig(int functionId, int optionsDefault, float sliderDefault)
		{
			this.FunctionId = functionId;
			this.OptionsDefault = optionsDefault;
			this.SliderDefault = sliderDefault;
		}

		// Token: 0x0602EFEA RID: 192490 RVA: 0x00B2242E File Offset: 0x00B2062E
		public static string GetTableName()
		{
			return "MenuConfig";
		}

		// Token: 0x0602EFEB RID: 192491 RVA: 0x00B22435 File Offset: 0x00B20635
		public static string GetLanguageTableName()
		{
			return "LanguageDefine";
		}

		// Token: 0x0602EFEC RID: 192492 RVA: 0x00B2243C File Offset: 0x00B2063C
		public static string GetTableFile()
		{
			return "s.设置系统.xlsx";
		}

		// Token: 0x0602EFED RID: 192493 RVA: 0x00B22444 File Offset: 0x00B20644
		public static LaunchGameSettingMenuConfig Parse(UKuroSqliteResultSet rs)
		{
			int functionId = 0;
			if (!rs.GetInt("FunctionId", ref functionId))
			{
				Singleton<LauncherLog>.Instance.Warn("[GameSettings]解析MenuConfig失败-找不到FunctionId", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			int optionsDefault = 0;
			if (!rs.GetInt("OptionsDefault", ref optionsDefault))
			{
				Singleton<LauncherLog>.Instance.Warn("[GameSettings]解析MenuConfig失败-找不到OptionsDefault", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			float sliderDefault = 0f;
			if (!rs.GetFloat("SliderDefault", ref sliderDefault))
			{
				Singleton<LauncherLog>.Instance.Warn("[GameSettings]解析MenuConfig失败-找不到SliderDefault", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return new LaunchGameSettingMenuConfig(functionId, optionsDefault, sliderDefault);
		}

		// Token: 0x0602EFEE RID: 192494 RVA: 0x00B224DE File Offset: 0x00B206DE
		public float GetDefaultValue()
		{
			if (this.SliderDefault == 0f)
			{
				return (float)this.OptionsDefault;
			}
			return this.SliderDefault;
		}

		// Token: 0x0401AC38 RID: 109624
		private const string TableName = "MenuConfig";

		// Token: 0x0401AC39 RID: 109625
		private const string LanguageTableName = "LanguageDefine";

		// Token: 0x0401AC3A RID: 109626
		private const string TableFile = "s.设置系统.xlsx";
	}
}
