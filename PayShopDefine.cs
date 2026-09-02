using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;

// Token: 0x020023B6 RID: 9142
[NullableContext(1)]
[Nullable(0)]
public class PayShopDefine : IStaticVariableResetter
{
	// Token: 0x06011A0D RID: 72205 RVA: 0x004D6324 File Offset: 0x004D4524
	static PayShopDefine()
	{
		Dictionary<PayShopDefine.EPayShopUpdateType, string> dictionary = new Dictionary<PayShopDefine.EPayShopUpdateType, string>();
		dictionary[PayShopDefine.EPayShopUpdateType.None] = "RemainNo";
		dictionary[PayShopDefine.EPayShopUpdateType.Daily] = "RemainNoInDay";
		dictionary[PayShopDefine.EPayShopUpdateType.Weekly] = "RemainNoInWeek";
		dictionary[PayShopDefine.EPayShopUpdateType.Monthly] = "RemainNoInMonth";
		dictionary[PayShopDefine.EPayShopUpdateType.Forever] = "RemainNo";
		PayShopDefine.payShopUpdateTypeTextId = dictionary;
		PayShopDefine.PayShopCumulativeTabTypeSet = new HashSet<PayShopDefine.EPayShopTabType>
		{
			PayShopDefine.EPayShopTabType.CumulativeShop,
			PayShopDefine.EPayShopTabType.CumulativeShop3Dot3
		};
		PayShopDefine.payGiftRoutedShopSet = new HashSet<PayShopDefine.EPayShopTabType>
		{
			PayShopDefine.EPayShopTabType.GiftBag,
			PayShopDefine.EPayShopTabType.NewPlayerShop
		};
		PayShopDefine.payShopViewTabType = new List<PayShopDefine.EShopTabViewType>
		{
			PayShopDefine.EShopTabViewType.Recommend,
			PayShopDefine.EShopTabViewType.GiftBag,
			PayShopDefine.EShopTabViewType.ExchangeEntry,
			PayShopDefine.EShopTabViewType.Recharge,
			PayShopDefine.EShopTabViewType.SkinShop,
			PayShopDefine.EShopTabViewType.ActivityShop,
			PayShopDefine.EShopTabViewType.NewPlayerShop
		};
		PayShopDefine.iosLimitModePayShopViewType = new List<PayShopDefine.EShopTabViewType>
		{
			PayShopDefine.EShopTabViewType.Recharge
		};
		Dictionary<PayShopDefine.EPayShopTagType, string> dictionary2 = new Dictionary<PayShopDefine.EPayShopTagType, string>();
		dictionary2[PayShopDefine.EPayShopTagType.Preferential] = "ShopLabelRes_1";
		dictionary2[PayShopDefine.EPayShopTagType.WellWorth] = "ShopLabelRes_1";
		dictionary2[PayShopDefine.EPayShopTagType.Recommend] = "ShopLabelRes_1";
		dictionary2[PayShopDefine.EPayShopTagType.Free] = "ShopLabelRes_1";
		dictionary2[PayShopDefine.EPayShopTagType.Regress] = "ShopLabelRes_5";
		dictionary2[PayShopDefine.EPayShopTagType.Carnival] = "ShopLabelRes_6";
		dictionary2[PayShopDefine.EPayShopTagType.RechargeDouble] = "RechargeItemDefaultTag";
		dictionary2[PayShopDefine.EPayShopTagType.RechargeGiven] = "RechargeItemSpecialTag";
		dictionary2[PayShopDefine.EPayShopTagType.SoldOut] = "ShopItemSoldOutPanel";
		dictionary2[PayShopDefine.EPayShopTagType.Lock] = "ShopItemLockPanel";
		dictionary2[PayShopDefine.EPayShopTagType.Discount] = "ShopItemDiscountLabel";
		dictionary2[PayShopDefine.EPayShopTagType.TotalTopUp] = "UiItem_CumulativeRechargeScoreTag";
		PayShopDefine.payShopTagTypeToResourceId = dictionary2;
		StaticVariableRegister.RegisterAndExecute(new Action(PayShopDefine.CreateStaticDefaultValue), new Action(PayShopDefine.ResetStaticDefaultValue));
	}

	// Token: 0x17001661 RID: 5729
	// (get) Token: 0x06011A0E RID: 72206 RVA: 0x004D64EA File Offset: 0x004D46EA
	public static IReadOnlyDictionary<PayShopDefine.ERecommendTabType, EUiTabViewName> RecommendTabView
	{
		get
		{
			return PayShopDefine._recommendTabView;
		}
	}

	// Token: 0x17001662 RID: 5730
	// (get) Token: 0x06011A0F RID: 72207 RVA: 0x004D64F1 File Offset: 0x004D46F1
	public static IReadOnlyDictionary<PayShopDefine.ESkinTabType, EUiTabViewName> SkinTabView
	{
		get
		{
			return PayShopDefine._skinTabView;
		}
	}

	// Token: 0x17001663 RID: 5731
	// (get) Token: 0x06011A10 RID: 72208 RVA: 0x004D64F8 File Offset: 0x004D46F8
	public static IReadOnlyList<PayShopDefine.EPayShopTagType> payShopTagSortList
	{
		get
		{
			return PayShopDefine._payShopTagSortList;
		}
	}

	// Token: 0x17001664 RID: 5732
	// (get) Token: 0x06011A11 RID: 72209 RVA: 0x004D64FF File Offset: 0x004D46FF
	public static IReadOnlyDictionary<PayShopDefine.EPayShopTagType, Func<PayShopExtraTagItem>> payShopTagTypeToExtraConstructor
	{
		get
		{
			return PayShopDefine._payShopTagTypeToExtraConstructor;
		}
	}

	// Token: 0x17001665 RID: 5733
	// (get) Token: 0x06011A12 RID: 72210 RVA: 0x004D6506 File Offset: 0x004D4706
	public static IReadOnlyList<int> GiftBagShopSpecialTabList
	{
		get
		{
			return PayShopDefine._giftBagShopSpecialTabList;
		}
	}

	// Token: 0x06011A13 RID: 72211 RVA: 0x004D6510 File Offset: 0x004D4710
	public static void CreateStaticDefaultValue()
	{
		PayShopDefine._payShopTagSortList = new List<PayShopDefine.EPayShopTagType>
		{
			PayShopDefine.EPayShopTagType.TotalTopUp
		};
		PayShopDefine._giftBagShopSpecialTabList = new List<int>
		{
			5,
			2
		};
		Dictionary<PayShopDefine.ESkinTabType, EUiTabViewName> dictionary = new Dictionary<PayShopDefine.ESkinTabType, EUiTabViewName>();
		dictionary[PayShopDefine.ESkinTabType.RoleSkinTabView] = EUiTabViewName.RoleShopSkinTabView;
		dictionary[PayShopDefine.ESkinTabType.FlySkinTabView] = EUiTabViewName.ShopFlySkinTabView;
		dictionary[PayShopDefine.ESkinTabType.MotorSkinTabView] = EUiTabViewName.MotorSkinTabView;
		dictionary[PayShopDefine.ESkinTabType.RoleOrnamentTabView] = EUiTabViewName.RoleShopOrnamentTabView;
		PayShopDefine._skinTabView = dictionary;
		Dictionary<PayShopDefine.ERecommendTabType, EUiTabViewName> dictionary2 = new Dictionary<PayShopDefine.ERecommendTabType, EUiTabViewName>();
		dictionary2[PayShopDefine.ERecommendTabType.MonthCard] = EUiTabViewName.MonthCardView;
		dictionary2[PayShopDefine.ERecommendTabType.RoleSkinRecommendView] = EUiTabViewName.RoleSkinRecommendView;
		dictionary2[PayShopDefine.ERecommendTabType.WeekCard] = EUiTabViewName.WeekCardView;
		dictionary2[PayShopDefine.ERecommendTabType.MotorSkin] = EUiTabViewName.MotorSkinRecommendView;
		PayShopDefine._recommendTabView = dictionary2;
		Dictionary<PayShopDefine.EPayShopTagType, Func<PayShopExtraTagItem>> dictionary3 = new Dictionary<PayShopDefine.EPayShopTagType, Func<PayShopExtraTagItem>>();
		dictionary3[PayShopDefine.EPayShopTagType.TotalTopUp] = (() => new TotalTopUpPayShopTagItem());
		PayShopDefine._payShopTagTypeToExtraConstructor = dictionary3;
	}

	// Token: 0x06011A14 RID: 72212 RVA: 0x004D65EC File Offset: 0x004D47EC
	public static void ResetStaticDefaultValue()
	{
		PayShopDefine._payShopTagSortList = null;
		PayShopDefine._giftBagShopSpecialTabList = null;
		PayShopDefine._skinTabView = null;
		PayShopDefine._recommendTabView = null;
		PayShopDefine._payShopTagTypeToExtraConstructor = null;
	}

	// Token: 0x04008A27 RID: 35367
	public const int DISCOUNT_PERCENT = 100;

	// Token: 0x04008A28 RID: 35368
	public const int MS_PER_SECOND = 1000;

	// Token: 0x04008A29 RID: 35369
	public const int MONTH_CARD_SHOP_ID = 42;

	// Token: 0x04008A2A RID: 35370
	public const int BATTLE_PASS_PRIMARY_ID = 43;

	// Token: 0x04008A2B RID: 35371
	public const int BATTLE_PASS_HIGH_ID = 44;

	// Token: 0x04008A2C RID: 35372
	public const int BATTLE_PASS_PRIMARY_TO_HIGH_ID = 45;

	// Token: 0x04008A2D RID: 35373
	public const int MONTH_CARD_CONFIG_ID = 1;

	// Token: 0x04008A2E RID: 35374
	public const int MONTH_CARD_HELP_ID = 9;

	// Token: 0x04008A2F RID: 35375
	public const int LORD_GYM_TAB_INDEX = 2;

	// Token: 0x04008A30 RID: 35376
	public const int NEW_LORD_GYM_TAB_INDEX = 3;

	// Token: 0x04008A31 RID: 35377
	public const int NEW_LORD_GYM_FIRST_TAB_INDEX = 2;

	// Token: 0x04008A32 RID: 35378
	public const int LORD_GYM_THIRD_TAB_INDEX = 4;

	// Token: 0x04008A33 RID: 35379
	public const int LORD_GYM_THIRD5_TAB_INDEX = 5;

	// Token: 0x04008A34 RID: 35380
	public const int LORD_GYM_CURRENCY_ID = 34;

	// Token: 0x04008A35 RID: 35381
	public const int LORD_GYM_FIRST_CURRENCY_ID = 11;

	// Token: 0x04008A36 RID: 35382
	public const int LORD_GYM_THIRD_CURRENCY_ID = 63;

	// Token: 0x04008A37 RID: 35383
	public const int LORD_GYM_THIRD5_CURRENCY_ID = 82;

	// Token: 0x04008A38 RID: 35384
	public const int CARNIVAL_TABID = 5;

	// Token: 0x04008A39 RID: 35385
	public const int LEVELUP_BACKPACK_TABID = 2;

	// Token: 0x04008A3A RID: 35386
	public const int GOLD_QUALITY = 5;

	// Token: 0x04008A3B RID: 35387
	public static readonly IReadOnlySet<InventoryDefine.EItemDataType> PayShopNeedCheckBtnItemTypeSet = new HashSet<InventoryDefine.EItemDataType>
	{
		InventoryDefine.EItemDataType.OrnamentItem,
		InventoryDefine.EItemDataType.MotorDecorationItem
	};

	// Token: 0x04008A3C RID: 35388
	public static readonly IReadOnlySet<PayShopDefine.EPayShopTabType> PayShopNeedOrnamentRoleIconShopSet = new HashSet<PayShopDefine.EPayShopTabType>
	{
		PayShopDefine.EPayShopTabType.SkinShop
	};

	// Token: 0x04008A3D RID: 35389
	public static readonly IReadOnlyDictionary<PayShopDefine.EPayShopUpdateType, string> payShopUpdateTypeTextId;

	// Token: 0x04008A3E RID: 35390
	public static readonly IReadOnlySet<PayShopDefine.EPayShopTabType> PayShopCumulativeTabTypeSet;

	// Token: 0x04008A3F RID: 35391
	public static readonly IReadOnlySet<PayShopDefine.EPayShopTabType> payGiftRoutedShopSet;

	// Token: 0x04008A40 RID: 35392
	public static readonly IReadOnlyList<PayShopDefine.EShopTabViewType> payShopViewTabType;

	// Token: 0x04008A41 RID: 35393
	public static readonly IReadOnlyList<PayShopDefine.EShopTabViewType> iosLimitModePayShopViewType;

	// Token: 0x04008A42 RID: 35394
	[Nullable(2)]
	private static IReadOnlyDictionary<PayShopDefine.ERecommendTabType, EUiTabViewName> _recommendTabView;

	// Token: 0x04008A43 RID: 35395
	[Nullable(2)]
	private static IReadOnlyDictionary<PayShopDefine.ESkinTabType, EUiTabViewName> _skinTabView;

	// Token: 0x04008A44 RID: 35396
	[Nullable(2)]
	private static IReadOnlyList<PayShopDefine.EPayShopTagType> _payShopTagSortList;

	// Token: 0x04008A45 RID: 35397
	public static readonly IReadOnlyDictionary<PayShopDefine.EPayShopTagType, string> payShopTagTypeToResourceId;

	// Token: 0x04008A46 RID: 35398
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static IReadOnlyDictionary<PayShopDefine.EPayShopTagType, Func<PayShopExtraTagItem>> _payShopTagTypeToExtraConstructor;

	// Token: 0x04008A47 RID: 35399
	[Nullable(2)]
	private static IReadOnlyList<int> _giftBagShopSpecialTabList;

	// Token: 0x04008A48 RID: 35400
	public const int NEW_PLAYER_SHOP_WEEK_CARD_TAB_ID = 1;

	// Token: 0x020086D1 RID: 34513
	[NullableContext(0)]
	public enum EPayShopUpdateType
	{
		// Token: 0x0402D977 RID: 186743
		None,
		// Token: 0x0402D978 RID: 186744
		Daily,
		// Token: 0x0402D979 RID: 186745
		Weekly,
		// Token: 0x0402D97A RID: 186746
		Monthly,
		// Token: 0x0402D97B RID: 186747
		Forever
	}

	// Token: 0x020086D2 RID: 34514
	[NullableContext(0)]
	public enum EPayShopItemType
	{
		// Token: 0x0402D97D RID: 186749
		Normal,
		// Token: 0x0402D97E RID: 186750
		Direct
	}

	// Token: 0x020086D3 RID: 34515
	[NullableContext(0)]
	public enum EPayShopTabType
	{
		// Token: 0x0402D980 RID: 186752
		None = -1,
		// Token: 0x0402D981 RID: 186753
		Default,
		// Token: 0x0402D982 RID: 186754
		Recommend,
		// Token: 0x0402D983 RID: 186755
		GiftBag = 3,
		// Token: 0x0402D984 RID: 186756
		ExchangeEntry,
		// Token: 0x0402D985 RID: 186757
		SkinShop = 6,
		// Token: 0x0402D986 RID: 186758
		Recharge = 100,
		// Token: 0x0402D987 RID: 186759
		Roguelike = 201,
		// Token: 0x0402D988 RID: 186760
		ActivityShop = 5,
		// Token: 0x0402D989 RID: 186761
		MoonChasing = 205,
		// Token: 0x0402D98A RID: 186762
		FishingShopOne = 208,
		// Token: 0x0402D98B RID: 186763
		FishingLimitTimeReward,
		// Token: 0x0402D98C RID: 186764
		FishingShopTwo,
		// Token: 0x0402D98D RID: 186765
		FishingShopThree,
		// Token: 0x0402D98E RID: 186766
		FishingShopFour,
		// Token: 0x0402D98F RID: 186767
		BabelTowerShop,
		// Token: 0x0402D990 RID: 186768
		CumulativeShop = 215,
		// Token: 0x0402D991 RID: 186769
		InfrFireShop = 219,
		// Token: 0x0402D992 RID: 186770
		FurnitureShop,
		// Token: 0x0402D993 RID: 186771
		CumulativeShop3Dot3,
		// Token: 0x0402D994 RID: 186772
		SheriffShop = 225,
		// Token: 0x0402D995 RID: 186773
		NewPlayerShop = 7
	}

	// Token: 0x020086D4 RID: 34516
	[NullableContext(0)]
	public enum EShopTabViewType
	{
		// Token: 0x0402D997 RID: 186775
		Recommend = 1,
		// Token: 0x0402D998 RID: 186776
		GiftBag = 3,
		// Token: 0x0402D999 RID: 186777
		ExchangeEntry,
		// Token: 0x0402D99A RID: 186778
		Recharge,
		// Token: 0x0402D99B RID: 186779
		ActivityShop,
		// Token: 0x0402D99C RID: 186780
		Roguelike,
		// Token: 0x0402D99D RID: 186781
		MoonChasing,
		// Token: 0x0402D99E RID: 186782
		SkinShop,
		// Token: 0x0402D99F RID: 186783
		NewPlayerShop
	}

	// Token: 0x020086D5 RID: 34517
	[NullableContext(0)]
	public enum ERecommendTabType
	{
		// Token: 0x0402D9A1 RID: 186785
		MonthCard = 2,
		// Token: 0x0402D9A2 RID: 186786
		RoleSkinRecommendView,
		// Token: 0x0402D9A3 RID: 186787
		WeekCard,
		// Token: 0x0402D9A4 RID: 186788
		MotorSkin
	}

	// Token: 0x020086D6 RID: 34518
	[NullableContext(0)]
	public enum ESkinTabType
	{
		// Token: 0x0402D9A6 RID: 186790
		RoleSkinTabView = 1,
		// Token: 0x0402D9A7 RID: 186791
		FlySkinTabView,
		// Token: 0x0402D9A8 RID: 186792
		MotorSkinTabView,
		// Token: 0x0402D9A9 RID: 186793
		RoleOrnamentTabView
	}

	// Token: 0x020086D7 RID: 34519
	[NullableContext(0)]
	public enum EPayShopTagType
	{
		// Token: 0x0402D9AB RID: 186795
		Preferential = 1,
		// Token: 0x0402D9AC RID: 186796
		WellWorth,
		// Token: 0x0402D9AD RID: 186797
		Recommend,
		// Token: 0x0402D9AE RID: 186798
		Free,
		// Token: 0x0402D9AF RID: 186799
		Regress,
		// Token: 0x0402D9B0 RID: 186800
		Carnival,
		// Token: 0x0402D9B1 RID: 186801
		RechargeDouble,
		// Token: 0x0402D9B2 RID: 186802
		RechargeGiven,
		// Token: 0x0402D9B3 RID: 186803
		SoldOut,
		// Token: 0x0402D9B4 RID: 186804
		Lock,
		// Token: 0x0402D9B5 RID: 186805
		Discount,
		// Token: 0x0402D9B6 RID: 186806
		TotalTopUp
	}

	// Token: 0x020086D8 RID: 34520
	[NullableContext(0)]
	public enum EGiftPackCheckGoodsMethod
	{
		// Token: 0x0402D9B8 RID: 186808
		Default,
		// Token: 0x0402D9B9 RID: 186809
		NormalGift
	}
}
