using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001729 RID: 5929
public class ActivityDefine : IStaticVariableResetter
{
	// Token: 0x0600A535 RID: 42293 RVA: 0x002BA025 File Offset: 0x002B8225
	static ActivityDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityDefine.CreateStaticDefaultValue), new Action(ActivityDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600A536 RID: 42294 RVA: 0x002BA044 File Offset: 0x002B8244
	public static void CreateStaticDefaultValue()
	{
		Dictionary<ECaptionDecorationFunc, Func<ActivityCaptionDecorationTagBase>> dictionary = new Dictionary<ECaptionDecorationFunc, Func<ActivityCaptionDecorationTagBase>>();
		dictionary.Add(ECaptionDecorationFunc.AnniversaryCelebrationTitleIcon, () => new AnniversaryCelebrationTitleIcon());
		ActivityDefine.captionDecorationFuncMap = dictionary;
		ActivityDefine.captionDecorationResourceIdMap = new Dictionary<ECaptionDecorationFunc, string>
		{
			{
				ECaptionDecorationFunc.AnniversaryCelebrationTitleIcon,
				"UiItem_AnniversaryCelebrationTitleIcon"
			}
		};
	}

	// Token: 0x0600A537 RID: 42295 RVA: 0x002BA097 File Offset: 0x002B8297
	public static void ResetStaticDefaultValue()
	{
		ActivityDefine.captionDecorationFuncMap = null;
		ActivityDefine.captionDecorationResourceIdMap = null;
	}

	// Token: 0x04004E66 RID: 20070
	public const int LOW_MEMORY_CACHE_VIEW_COUNT = 3;

	// Token: 0x04004E67 RID: 20071
	public const int NORMAL_MEMORY_CACHE_VIEW_COUNT = 10;

	// Token: 0x04004E68 RID: 20072
	[Nullable(1)]
	public static Dictionary<ECaptionDecorationFunc, Func<ActivityCaptionDecorationTagBase>> captionDecorationFuncMap;

	// Token: 0x04004E69 RID: 20073
	[Nullable(1)]
	public static Dictionary<ECaptionDecorationFunc, string> captionDecorationResourceIdMap;

	// Token: 0x04004E6A RID: 20074
	public const int ACTIVITY_BUBBLE_CACHE_KEY = 1011;
}
