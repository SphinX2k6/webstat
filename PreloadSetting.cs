using System;
using System.Runtime.CompilerServices;

// Token: 0x020032B7 RID: 12983
public class PreloadSetting : IStaticVariableResetter
{
	// Token: 0x0601B36F RID: 111471 RVA: 0x0082D909 File Offset: 0x0082BB09
	static PreloadSetting()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PreloadSetting.CreateStaticDefaultValue), new Action(PreloadSetting.ResetStaticDefaultValue));
	}

	// Token: 0x17002513 RID: 9491
	// (get) Token: 0x0601B370 RID: 111472 RVA: 0x0082D928 File Offset: 0x0082BB28
	[Nullable(1)]
	public static PreloadSetting Default
	{
		[NullableContext(1)]
		get
		{
			return PreloadSetting._default;
		}
	}

	// Token: 0x17002514 RID: 9492
	// (get) Token: 0x0601B371 RID: 111473 RVA: 0x0082D92F File Offset: 0x0082BB2F
	public static bool UseNewPreload
	{
		get
		{
			return PreloadSetting.UseNewPreloadInternal;
		}
	}

	// Token: 0x0601B372 RID: 111474 RVA: 0x0082D936 File Offset: 0x0082BB36
	public static void SetUseNewPreload(bool value)
	{
		PreloadSetting.UseNewPreloadInternal = value;
	}

	// Token: 0x0601B373 RID: 111475 RVA: 0x0082D93E File Offset: 0x0082BB3E
	public static void CreateStaticDefaultValue()
	{
		PreloadSetting._default = new PreloadSetting();
		PreloadSetting.UseNewPreloadInternal = true;
		PreloadSetting.LoadAllPreloadData = false;
	}

	// Token: 0x0601B374 RID: 111476 RVA: 0x0082D956 File Offset: 0x0082BB56
	public static void ResetStaticDefaultValue()
	{
		PreloadSetting._default = null;
		PreloadSetting.UseNewPreloadInternal = true;
		PreloadSetting.LoadAllPreloadData = false;
	}

	// Token: 0x0400DDCE RID: 56782
	[Nullable(2)]
	private static PreloadSetting _default;

	// Token: 0x0400DDCF RID: 56783
	private static bool UseNewPreloadInternal;

	// Token: 0x0400DDD0 RID: 56784
	public static bool LoadAllPreloadData;
}
