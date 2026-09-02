using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001CDE RID: 7390
[NullableContext(1)]
[Nullable(0)]
public class GachaDefine
{
	// Token: 0x0600D8E8 RID: 55528 RVA: 0x003A160E File Offset: 0x0039F80E
	// Note: this type is marked as 'beforefieldinit'.
	static GachaDefine()
	{
		Dictionary<GachaDefine.EAwardType, string> dictionary = new Dictionary<GachaDefine.EAwardType, string>();
		dictionary[GachaDefine.EAwardType.Role] = "Role";
		dictionary[GachaDefine.EAwardType.Weapon] = "Weapon";
		GachaDefine.textKeyMap = dictionary;
	}

	// Token: 0x0400677A RID: 26490
	public const string GACHA_ROLE_CAMERA = "1035";

	// Token: 0x0400677B RID: 26491
	public const string GACHA_ROLE_CAMERA_TARGET = "-1035";

	// Token: 0x0400677C RID: 26492
	public const string GACHA_RECORD_CAMERA = "1040";

	// Token: 0x0400677D RID: 26493
	public const string GACHA_WEAPON_CAMERA = "1041_New";

	// Token: 0x0400677E RID: 26494
	public const string GACHA_WEAPON_CAMERA_TARGET = "-1041";

	// Token: 0x0400677F RID: 26495
	public const string CACHA_RESUOT_CAMERA = "1043";

	// Token: 0x04006780 RID: 26496
	public const string GACHA_BLEND_CAMERA = "10007";

	// Token: 0x04006781 RID: 26497
	public const string GACHA_ROLE_CASE = "RoleCase";

	// Token: 0x04006782 RID: 26498
	public const string GACHA_WEAPON_CASE = "WeaponCase";

	// Token: 0x04006783 RID: 26499
	public const string GACHA_3D_SCENE_PATH = "/Game/Aki/Map/Level/Function/ChouKa/Art/Instance_ChouKa_01";

	// Token: 0x04006784 RID: 26500
	public const int ROLE_FUNCTION_ITEM = 5;

	// Token: 0x04006785 RID: 26501
	public const int GACHA_ONE = 1;

	// Token: 0x04006786 RID: 26502
	public const int GACHA_TEN = 10;

	// Token: 0x04006787 RID: 26503
	public const string TOTAL_REST_COUNT = "GachaTotalRestCount";

	// Token: 0x04006788 RID: 26504
	public const string POOL_TODAY_REST_COUNT = "GachaPoolTodayRestCount";

	// Token: 0x04006789 RID: 26505
	public const string POOL_TOTAL_REST_COUNT = "GachaPoolTotalRestCount";

	// Token: 0x0400678A RID: 26506
	public const string POOL_RESIDENT = "PoolResident";

	// Token: 0x0400678B RID: 26507
	public const string POOL_TIME_LIMIT = "PoolTimeLimit";

	// Token: 0x0400678C RID: 26508
	public const string GACHA_TEXT = "GachaText";

	// Token: 0x0400678D RID: 26509
	public const string GACHA_RECORD = "GachaRecord";

	// Token: 0x0400678E RID: 26510
	public const string GACHA_TYPE = "GachaType";

	// Token: 0x0400678F RID: 26511
	public const string GACHA_RECORD_LIMIT = "GachaRecordLimit";

	// Token: 0x04006790 RID: 26512
	public const string GACHA_NO_RECORD = "GachaNoRecord";

	// Token: 0x04006791 RID: 26513
	public static readonly IReadOnlyDictionary<GachaDefine.EAwardType, string> textKeyMap;

	// Token: 0x0200802E RID: 32814
	[NullableContext(0)]
	public enum EAwardType
	{
		// Token: 0x0402B9A9 RID: 178601
		Role,
		// Token: 0x0402B9AA RID: 178602
		Weapon
	}

	// Token: 0x0200802F RID: 32815
	[NullableContext(0)]
	public enum EGachaViewType
	{
		// Token: 0x0402B9AC RID: 178604
		None,
		// Token: 0x0402B9AD RID: 178605
		NewPlayer,
		// Token: 0x0402B9AE RID: 178606
		RoleUp,
		// Token: 0x0402B9AF RID: 178607
		WeaponUp,
		// Token: 0x0402B9B0 RID: 178608
		RoleCommon,
		// Token: 0x0402B9B1 RID: 178609
		WeaponCommon,
		// Token: 0x0402B9B2 RID: 178610
		NewPlayerCustom,
		// Token: 0x0402B9B3 RID: 178611
		AnniversaryRole,
		// Token: 0x0402B9B4 RID: 178612
		AnniversaryWeapon,
		// Token: 0x0402B9B5 RID: 178613
		CarnivalRole,
		// Token: 0x0402B9B6 RID: 178614
		CarnivalWeapon,
		// Token: 0x0402B9B7 RID: 178615
		CyberRole,
		// Token: 0x0402B9B8 RID: 178616
		CyberWeapon,
		// Token: 0x0402B9B9 RID: 178617
		OldCarnivalRole,
		// Token: 0x0402B9BA RID: 178618
		OldCarnivalWeapon
	}

	// Token: 0x02008030 RID: 32816
	[NullableContext(0)]
	public enum EItemQuality
	{
		// Token: 0x0402B9BC RID: 178620
		White = 1,
		// Token: 0x0402B9BD RID: 178621
		Green,
		// Token: 0x0402B9BE RID: 178622
		Blue,
		// Token: 0x0402B9BF RID: 178623
		Purple,
		// Token: 0x0402B9C0 RID: 178624
		Gold
	}
}
