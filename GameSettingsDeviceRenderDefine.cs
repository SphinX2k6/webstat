using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000E94 RID: 3732
[NullableContext(2)]
[Nullable(0)]
public class GameSettingsDeviceRenderDefine : IStaticVariableResetter
{
	// Token: 0x06005B90 RID: 23440 RVA: 0x0016E24C File Offset: 0x0016C44C
	static GameSettingsDeviceRenderDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameSettingsDeviceRenderDefine.CreateStaticDefaultValue), new Action(GameSettingsDeviceRenderDefine.ResetStaticDefaultValue));
	}

	// Token: 0x17000695 RID: 1685
	// (get) Token: 0x06005B91 RID: 23441 RVA: 0x0016E26B File Offset: 0x0016C46B
	[Nullable(1)]
	public static Dictionary<string, IPerformanceLimitConfig> PerformanceLimitConfigs
	{
		[NullableContext(1)]
		get
		{
			return GameSettingsDeviceRenderDefine.performanceLimitConfigs;
		}
	}

	// Token: 0x06005B92 RID: 23442 RVA: 0x0016E274 File Offset: 0x0016C474
	public static void CreateStaticDefaultValue()
	{
		GameSettingsDeviceRenderDefine.FrameRateListPc = new int[]
		{
			30,
			45,
			60,
			120
		};
		GameSettingsDeviceRenderDefine.FrameRateListIos = new int[]
		{
			30,
			60,
			120
		};
		GameSettingsDeviceRenderDefine.FrameRateListAndroid = new int[]
		{
			24,
			30,
			45,
			60
		};
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicLow = new int[]
		{
			30,
			60,
			90
		};
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicHigh = new int[]
		{
			30,
			60,
			120
		};
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagic = GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicHigh;
		GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony = new int[]
		{
			24,
			30,
			45,
			60
		};
		GameSettingsDeviceRenderDefine.FrameRateListXSX = new int[]
		{
			60,
			90,
			120
		};
		GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityPc = new int[]
		{
			0,
			0,
			10,
			15,
			15,
			15
		};
		GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityMobile = new int[]
		{
			0,
			0,
			3,
			6,
			6,
			6
		};
		GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityPc = new int[]
		{
			0,
			0,
			2500,
			5000,
			5000,
			5000
		};
		GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityMobile = new int[]
		{
			0,
			0,
			1500,
			3000,
			3000,
			3000
		};
		GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityPc = new int[]
		{
			2000,
			2000,
			4000,
			6000,
			6000,
			6000
		};
		GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityMobile = new int[]
		{
			1500,
			1500,
			2500,
			3500,
			3500,
			3500
		};
		GameSettingsDeviceRenderDefine.MainPlayerRealShadow = new int[]
		{
			0,
			1,
			1,
			1,
			1,
			1
		};
		Dictionary<string, IPerformanceLimitConfig> dictionary = new Dictionary<string, IPerformanceLimitConfig>();
		dictionary["RoleRootView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["RoleLevelUpView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["HandBookEntranceView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["AchievementMainView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["CommonActivityView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["VideoView"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["GachaScanView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["DrawMainView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["GachaResultView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["WorldMapView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["CalabashRootView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["BattlePassMainView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = false
		};
		dictionary["GachaMainView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["PayShopRootView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["AdventureGuideView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["TutorialView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["QuestView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["FriendView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["TimeOfDaySecondView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["EditFormationView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["InventoryView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["MailBoxView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["MenuView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["FunctionView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["DreamLinkMainView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["FishingQteView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["ShipTowerView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["MapRogueMainView_Seq"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		dictionary["FunctionView_Special"] = new PerformanceLimitConfig
		{
			FrameLimit = false,
			CacheWorldFrame = true
		};
		GameSettingsDeviceRenderDefine.performanceLimitConfigs = dictionary;
	}

	// Token: 0x06005B93 RID: 23443 RVA: 0x0016E730 File Offset: 0x0016C930
	public static void ResetStaticDefaultValue()
	{
		GameSettingsDeviceRenderDefine.FrameRateListPc = null;
		GameSettingsDeviceRenderDefine.FrameRateListIos = null;
		GameSettingsDeviceRenderDefine.FrameRateListAndroid = null;
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicLow = null;
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagicHigh = null;
		GameSettingsDeviceRenderDefine.FrameRateListAndroidForRedMagic = null;
		GameSettingsDeviceRenderDefine.FrameRateListOpenHarmony = null;
		GameSettingsDeviceRenderDefine.FrameRateListXSX = null;
		GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityPc = null;
		GameSettingsDeviceRenderDefine.MaxRoleShadowNumWithGameGraphQualityMobile = null;
		GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityPc = null;
		GameSettingsDeviceRenderDefine.MaxRoleShadowDistanceWithGameGraphQualityMobile = null;
		GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityPc = null;
		GameSettingsDeviceRenderDefine.MaxDecalShadowDistanceWithGameGraphQualityMobile = null;
		GameSettingsDeviceRenderDefine.MainPlayerRealShadow = null;
		GameSettingsDeviceRenderDefine.performanceLimitConfigs = null;
	}

	// Token: 0x04002BF6 RID: 11254
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListPc;

	// Token: 0x04002BF7 RID: 11255
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListIos;

	// Token: 0x04002BF8 RID: 11256
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListAndroid;

	// Token: 0x04002BF9 RID: 11257
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListAndroidForRedMagicLow;

	// Token: 0x04002BFA RID: 11258
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListAndroidForRedMagicHigh;

	// Token: 0x04002BFB RID: 11259
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListAndroidForRedMagic;

	// Token: 0x04002BFC RID: 11260
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListOpenHarmony;

	// Token: 0x04002BFD RID: 11261
	[StaticVariableRuleIgnore]
	public static int[] FrameRateListXSX;

	// Token: 0x04002BFE RID: 11262
	[Nullable(1)]
	public const string PERFORMENCELIMIT_SEQ_TAIL = "_Seq";

	// Token: 0x04002BFF RID: 11263
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, IPerformanceLimitConfig> performanceLimitConfigs;

	// Token: 0x04002C00 RID: 11264
	public const int HD_SCREEN_WIDTH = 2000;

	// Token: 0x04002C01 RID: 11265
	public const int HD_SCREEN_HEIGHT = 1100;

	// Token: 0x04002C02 RID: 11266
	[StaticVariableRuleIgnore]
	public static int[] MaxRoleShadowNumWithGameGraphQualityPc;

	// Token: 0x04002C03 RID: 11267
	[StaticVariableRuleIgnore]
	public static int[] MaxRoleShadowNumWithGameGraphQualityMobile;

	// Token: 0x04002C04 RID: 11268
	[StaticVariableRuleIgnore]
	public static int[] MaxRoleShadowDistanceWithGameGraphQualityPc;

	// Token: 0x04002C05 RID: 11269
	[StaticVariableRuleIgnore]
	public static int[] MaxRoleShadowDistanceWithGameGraphQualityMobile;

	// Token: 0x04002C06 RID: 11270
	[StaticVariableRuleIgnore]
	public static int[] MaxDecalShadowDistanceWithGameGraphQualityPc;

	// Token: 0x04002C07 RID: 11271
	[StaticVariableRuleIgnore]
	public static int[] MaxDecalShadowDistanceWithGameGraphQualityMobile;

	// Token: 0x04002C08 RID: 11272
	[StaticVariableRuleIgnore]
	public static int[] MainPlayerRealShadow;

	// Token: 0x04002C09 RID: 11273
	public const int WHOLE_SHADOW_CACHE_DELAY_TIME = 1000;
}
