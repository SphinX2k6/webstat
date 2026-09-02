using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02001B72 RID: 7026
[NullableContext(2)]
[Nullable(0)]
public class ExploreProgressDefine : IStaticVariableResetter
{
	// Token: 0x0600CC00 RID: 52224 RVA: 0x0036660A File Offset: 0x0036480A
	static ExploreProgressDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ExploreProgressDefine.CreateStaticDefaultValue), new Action(ExploreProgressDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600CC01 RID: 52225 RVA: 0x0036662C File Offset: 0x0036482C
	public static void CreateStaticDefaultValue()
	{
		Dictionary<int, EMarkType> dictionary = new Dictionary<int, EMarkType>();
		dictionary[4] = EMarkType.SightSpot;
		dictionary[5] = EMarkType.FlyingHunter;
		dictionary[9] = EMarkType.Frostbite;
		ExploreProgressDefine.exploreType2MarkType = dictionary;
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		dictionary2[4] = 10;
		dictionary2[5] = 11;
		dictionary2[9] = 12;
		ExploreProgressDefine.exploreType2Config = dictionary2;
		Dictionary<EExploratoryDegree, EMarkType> dictionary3 = new Dictionary<EExploratoryDegree, EMarkType>();
		dictionary3[EExploratoryDegree.FlyingHunter] = EMarkType.FlyingHunter;
		dictionary3[EExploratoryDegree.Frostbite] = EMarkType.Frostbite;
		ExploreProgressDefine.exploratoryDegree2MarkType = dictionary3;
	}

	// Token: 0x0600CC02 RID: 52226 RVA: 0x003666A2 File Offset: 0x003648A2
	public static void ResetStaticDefaultValue()
	{
		ExploreProgressDefine.exploreType2MarkType = null;
		ExploreProgressDefine.exploreType2Config = null;
		ExploreProgressDefine.exploratoryDegree2MarkType = null;
	}

	// Token: 0x0400618D RID: 24973
	public static Dictionary<int, EMarkType> exploreType2MarkType;

	// Token: 0x0400618E RID: 24974
	public static Dictionary<int, int> exploreType2Config;

	// Token: 0x0400618F RID: 24975
	public static Dictionary<EExploratoryDegree, EMarkType> exploratoryDegree2MarkType;

	// Token: 0x04006190 RID: 24976
	public const int DEFAULT_COUNTRY_ID = 1;

	// Token: 0x04006191 RID: 24977
	public const int MAP_MARK_ID = 3;

	// Token: 0x04006192 RID: 24978
	public const int MAP_MARK_TYPE = 8;

	// Token: 0x04006193 RID: 24979
	public const int AREA_LEVEL = 2;

	// Token: 0x04006194 RID: 24980
	public const int NONE_STATE_ID = 0;

	// Token: 0x04006195 RID: 24981
	public const int AREA_ICON_UNLOCK_COUNT = 4;

	// Token: 0x04006196 RID: 24982
	public const float AREA_ICON_UNLOCK_PERCENT = 25f;

	// Token: 0x04006197 RID: 24983
	public const int MAX_RECOMMEND_PLAY_POINT_SHOW_NUM = 2;

	// Token: 0x04006198 RID: 24984
	public const int RECOMMEND_PLAY_DELAY_TIME = 20;
}
