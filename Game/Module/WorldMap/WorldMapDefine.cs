using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B1C RID: 19228
	[NullableContext(1)]
	[Nullable(0)]
	public static class WorldMapDefine
	{
		// Token: 0x060322BF RID: 205503 RVA: 0x00C8EF60 File Offset: 0x00C8D160
		// Note: this type is marked as 'beforefieldinit'.
		unsafe static WorldMapDefine()
		{
			int num = 52;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(44, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(45, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(46, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(47, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(48, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(49, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(50, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(51, typeof(UUIText));
			WorldMapDefine.SecondaryUiPanelComponentsRegisterInfoA = list;
			num2 = 17;
			List<ValueTuple<int, Type>> list2 = new List<ValueTuple<int, Type>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list2, num2);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list2);
			num = 0;
			*span[num] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num++;
			*span[num] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num++;
			*span[num] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num++;
			*span[num] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num++;
			*span[num] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num++;
			*span[num] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num++;
			*span[num] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num++;
			*span[num] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num++;
			*span[num] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			WorldMapDefine.SecondaryUiPanelComponentsRegisterInfoB = list2;
			WorldMapDefine.OnlinePlayerIconPathList = new string[]
			{
				"SP_MapFollowing1",
				"SP_MapFollowing2",
				"SP_MapFollowing3"
			};
			WorldMapDefine.OnlinePlayerIconPathList2 = new string[]
			{
				"SP_IconMap_Mark_1P_UI",
				"SP_IconMap_Mark_2P_UI",
				"SP_IconMap_Mark_3P_UI"
			};
		}

		// Token: 0x0401D4FD RID: 120061
		public const string MULTI_MAP_SELECT_ICON_PATH = "SP_MarkMultiMapSelect";

		// Token: 0x0401D4FE RID: 120062
		public const string BLOCK_MARK_ICON_PATH = "SP_MarkBlock";

		// Token: 0x0401D4FF RID: 120063
		public const string SUB_ICON_PATH = "SP_MarkRecommend";

		// Token: 0x0401D500 RID: 120064
		public const string MULTI_MAP_ICON_PATH = "SP_MarkMultiMap";

		// Token: 0x0401D501 RID: 120065
		public const string TEMPORARY_TELEPORT_NORMAL_ICON_PATH = "SP_MarkTime";

		// Token: 0x0401D502 RID: 120066
		public const string MORALE_FLAG_BOX_ICON_PATH = "SP_MarkGift";

		// Token: 0x0401D503 RID: 120067
		public const string MARK_ITEM_VIEW_PATH = "UiItem_WorldMapMark_Prefab";

		// Token: 0x0401D504 RID: 120068
		public const int MARK_CLICK_RANGE = 50;

		// Token: 0x0401D505 RID: 120069
		public const int DEBUG_SPHERE_DEFAULT_RADIUS = 30;

		// Token: 0x0401D506 RID: 120070
		public const int DEBUG_SPHERE_DEFAULT_SEGMENTS = 30;

		// Token: 0x0401D507 RID: 120071
		public const int DEBUG_SPHERE_DEFAULT_DURATION = 3;

		// Token: 0x0401D508 RID: 120072
		public const float SCALE_STEP = 0.1f;

		// Token: 0x0401D509 RID: 120073
		public const int HUANG_LONG_COUNTRY_ID = 1;

		// Token: 0x0401D50A RID: 120074
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		public static List<ValueTuple<int, Type>> SecondaryUiPanelComponentsRegisterInfoA;

		// Token: 0x0401D50B RID: 120075
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		[StaticVariableRuleIgnore]
		public static List<ValueTuple<int, Type>> SecondaryUiPanelComponentsRegisterInfoB;

		// Token: 0x0401D50C RID: 120076
		[StaticVariableRuleIgnore]
		public static readonly string[] OnlinePlayerIconPathList;

		// Token: 0x0401D50D RID: 120077
		[StaticVariableRuleIgnore]
		public static readonly string[] OnlinePlayerIconPathList2;
	}
}
