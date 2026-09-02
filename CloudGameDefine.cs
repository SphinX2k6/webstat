using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Token: 0x02000E5C RID: 3676
[NullableContext(1)]
[Nullable(0)]
public class CloudGameDefine : IStaticVariableResetter
{
	// Token: 0x0600587D RID: 22653 RVA: 0x00106C31 File Offset: 0x00104E31
	static CloudGameDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CloudGameDefine.CreateStaticDefaultValue), new Action(CloudGameDefine.ResetStaticDefaultValue));
	}

	// Token: 0x1700063C RID: 1596
	// (get) Token: 0x0600587E RID: 22654 RVA: 0x00106C50 File Offset: 0x00104E50
	public static Regex CloudGamePlatformRegex
	{
		get
		{
			return CloudGameDefine._cloudGamePlatformRegex;
		}
	}

	// Token: 0x1700063D RID: 1597
	// (get) Token: 0x0600587F RID: 22655 RVA: 0x00106C57 File Offset: 0x00104E57
	public static Regex CloudGameDeviceRegex
	{
		get
		{
			return CloudGameDefine._cloudGameDeviceRegex;
		}
	}

	// Token: 0x1700063E RID: 1598
	// (get) Token: 0x06005880 RID: 22656 RVA: 0x00106C5E File Offset: 0x00104E5E
	public static Regex CloudGameDpiRegex
	{
		get
		{
			return CloudGameDefine._cloudGameDpiRegex;
		}
	}

	// Token: 0x1700063F RID: 1599
	// (get) Token: 0x06005881 RID: 22657 RVA: 0x00106C65 File Offset: 0x00104E65
	public static Regex CloudGameDeviceScreenResolution
	{
		get
		{
			return CloudGameDefine._cloudGameDeviceScreenResolution;
		}
	}

	// Token: 0x17000640 RID: 1600
	// (get) Token: 0x06005882 RID: 22658 RVA: 0x00106C6C File Offset: 0x00104E6C
	public static Regex CloudGameScreenResolution
	{
		get
		{
			return CloudGameDefine._cloudGameScreenResolution;
		}
	}

	// Token: 0x17000641 RID: 1601
	// (get) Token: 0x06005883 RID: 22659 RVA: 0x00106C73 File Offset: 0x00104E73
	public static Regex CloudGameIsWeb
	{
		get
		{
			return CloudGameDefine._cloudGameIsWeb;
		}
	}

	// Token: 0x17000642 RID: 1602
	// (get) Token: 0x06005884 RID: 22660 RVA: 0x00106C7A File Offset: 0x00104E7A
	public static Dictionary<string, float[]> DeviceMarginMap
	{
		get
		{
			return CloudGameDefine._deviceMarginMap;
		}
	}

	// Token: 0x17000643 RID: 1603
	// (get) Token: 0x06005885 RID: 22661 RVA: 0x00106C81 File Offset: 0x00104E81
	public static IReadOnlyList<float> DefaultDeviceMargin
	{
		get
		{
			return CloudGameDefine._defaultDeviceMargin;
		}
	}

	// Token: 0x06005886 RID: 22662 RVA: 0x00106C88 File Offset: 0x00104E88
	public static void CreateStaticDefaultValue()
	{
		CloudGameDefine._cloudGamePlatformRegex = new Regex("-CloudGamePlatform=([^\\s]+)");
		CloudGameDefine._cloudGameDeviceRegex = new Regex("-Device=([^\\s]+)");
		CloudGameDefine._cloudGameDpiRegex = new Regex("-Dpi=([^\\s]+)");
		CloudGameDefine._cloudGameDeviceScreenResolution = new Regex("-DeviceScreenResolution=(\\d+)x(\\d+)");
		CloudGameDefine._cloudGameScreenResolution = new Regex("Res=(\\d+)x(\\d+)");
		CloudGameDefine._cloudGameIsWeb = new Regex("-IsWeb=([^\\s]+)");
		Dictionary<string, float[]> dictionary = new Dictionary<string, float[]>();
		dictionary["iPhone15,2"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone15,3"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["ELS-AN00"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["PGU110"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone16,1"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone16,2"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["ANA-AN00"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["ELS-AN10"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["JER-TN20"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["WLZ-AN00"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["OXF-AN00"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["OXF-AN10"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone17,1"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone17,2"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone17,3"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone17,4"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		dictionary["iPhone17,5"] = new float[]
		{
			5.4f,
			0f,
			4f,
			0.8f
		};
		CloudGameDefine._deviceMarginMap = dictionary;
		CloudGameDefine._defaultDeviceMargin = new <>z__ReadOnlyArray<float>(new float[]
		{
			3f,
			0f,
			2.7f,
			0.8f
		});
	}

	// Token: 0x06005887 RID: 22663 RVA: 0x00106EF2 File Offset: 0x001050F2
	public static void ResetStaticDefaultValue()
	{
		CloudGameDefine._cloudGamePlatformRegex = null;
		CloudGameDefine._cloudGameDeviceRegex = null;
		CloudGameDefine._cloudGameDpiRegex = null;
		CloudGameDefine._cloudGameDeviceScreenResolution = null;
		CloudGameDefine._cloudGameScreenResolution = null;
		CloudGameDefine._cloudGameIsWeb = null;
		CloudGameDefine._deviceMarginMap = null;
		CloudGameDefine._defaultDeviceMargin = null;
	}

	// Token: 0x04001DFF RID: 7679
	[Nullable(2)]
	private static Regex _cloudGamePlatformRegex;

	// Token: 0x04001E00 RID: 7680
	[Nullable(2)]
	private static Regex _cloudGameDeviceRegex;

	// Token: 0x04001E01 RID: 7681
	[Nullable(2)]
	private static Regex _cloudGameDpiRegex;

	// Token: 0x04001E02 RID: 7682
	[Nullable(2)]
	private static Regex _cloudGameDeviceScreenResolution;

	// Token: 0x04001E03 RID: 7683
	[Nullable(2)]
	private static Regex _cloudGameScreenResolution;

	// Token: 0x04001E04 RID: 7684
	[Nullable(2)]
	private static Regex _cloudGameIsWeb;

	// Token: 0x04001E05 RID: 7685
	public const int CLOUD_GAME_DEFAULT_DPI = 180;

	// Token: 0x04001E06 RID: 7686
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<string, float[]> _deviceMarginMap;

	// Token: 0x04001E07 RID: 7687
	[Nullable(2)]
	private static IReadOnlyList<float> _defaultDeviceMargin;

	// Token: 0x04001E08 RID: 7688
	public const int CLOUD_GAME_DEFAULT_SCREEN_WIDTH = 1920;

	// Token: 0x04001E09 RID: 7689
	public const int CLOUD_GAME_DEFAULT_SCREEN_HEIGHT = 1080;
}
