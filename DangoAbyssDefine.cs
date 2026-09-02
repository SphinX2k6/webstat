using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001AC6 RID: 6854
public class DangoAbyssDefine : IStaticVariableResetter
{
	// Token: 0x0600C4D5 RID: 50389 RVA: 0x0033EFA5 File Offset: 0x0033D1A5
	static DangoAbyssDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(DangoAbyssDefine.CreateStaticDefaultValue), new Action(DangoAbyssDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600C4D6 RID: 50390 RVA: 0x0033EFC4 File Offset: 0x0033D1C4
	public static void CreateStaticDefaultValue()
	{
		DangoAbyssDefine.textSlotType = new Dictionary<DangoAbyssDefine.ESlotType, string>
		{
			{
				DangoAbyssDefine.ESlotType.Normal,
				"Text_NormalPlugin_Text"
			},
			{
				DangoAbyssDefine.ESlotType.Core,
				"Text_CorePlugin_Text"
			},
			{
				DangoAbyssDefine.ESlotType.Passive,
				"Text_PassivePlugin_Text"
			}
		};
		DangoAbyssDefine.textPluginType = new Dictionary<DangoAbyssDefine.ESlotType, string>
		{
			{
				DangoAbyssDefine.ESlotType.Normal,
				"Text_NormalPluginType_Text"
			},
			{
				DangoAbyssDefine.ESlotType.Core,
				"Text_CorePluginType_Text"
			},
			{
				DangoAbyssDefine.ESlotType.Passive,
				"Text_PassivePluginType_Text"
			}
		};
		DangoAbyssDefine.iconSizeBySlotType = new Dictionary<DangoAbyssDefine.ESlotType, int>
		{
			{
				DangoAbyssDefine.ESlotType.Normal,
				64
			},
			{
				DangoAbyssDefine.ESlotType.Core,
				96
			},
			{
				DangoAbyssDefine.ESlotType.Passive,
				87
			}
		};
	}

	// Token: 0x0600C4D7 RID: 50391 RVA: 0x0033F052 File Offset: 0x0033D252
	public static void ResetStaticDefaultValue()
	{
		DangoAbyssDefine.textSlotType = null;
		DangoAbyssDefine.textPluginType = null;
		DangoAbyssDefine.iconSizeBySlotType = null;
	}

	// Token: 0x04005E7A RID: 24186
	public const int BADDANGOID = 999;

	// Token: 0x04005E7B RID: 24187
	public const int SLOT_COUNT = 9;

	// Token: 0x04005E7C RID: 24188
	public const int CURRENCY_ITEM_EXP_ID = 80200001;

	// Token: 0x04005E7D RID: 24189
	public const int CURRENCY_ITEM_TOKEN_ID = 80200002;

	// Token: 0x04005E7E RID: 24190
	public const int CURRENCY_ITEM_KEY_ID = 80200003;

	// Token: 0x04005E7F RID: 24191
	[Nullable(1)]
	public static Dictionary<DangoAbyssDefine.ESlotType, string> textSlotType;

	// Token: 0x04005E80 RID: 24192
	[Nullable(1)]
	public static Dictionary<DangoAbyssDefine.ESlotType, string> textPluginType;

	// Token: 0x04005E81 RID: 24193
	[Nullable(1)]
	public const string TEXT_EQUIP_ERROR_DANGO = "Text_DangoEquipErrorDango_Text";

	// Token: 0x04005E82 RID: 24194
	[Nullable(1)]
	public const string TEXT_EQUIP_SAME = "Text_DangoEquipSame_Text";

	// Token: 0x04005E83 RID: 24195
	[Nullable(1)]
	public const string TEXT_EQUIP_REPEAT = "Text_DangoEquipRepeat_Text";

	// Token: 0x04005E84 RID: 24196
	[Nullable(1)]
	public const string TEXT_DANGO_LEVEL = "Text_DangoLevel_Text";

	// Token: 0x04005E85 RID: 24197
	[Nullable(1)]
	public const string TEXT_PLUGIN_COUNT = "Text_DangoPluginCount_Text";

	// Token: 0x04005E86 RID: 24198
	[Nullable(1)]
	public const string TEXT_RECOVERY_SELECT = "Text_RecoverySelect_Text";

	// Token: 0x04005E87 RID: 24199
	[Nullable(1)]
	public const string TEXT_RECOVERY_TIMES = "Text_RecoveryTimes_Text";

	// Token: 0x04005E88 RID: 24200
	public const int RECOVERY_NEEDS_COUNT = 1;

	// Token: 0x04005E89 RID: 24201
	public const int ROLE_ATTRIBUTE_LENGTH = 6;

	// Token: 0x04005E8A RID: 24202
	[Nullable(1)]
	public static Dictionary<DangoAbyssDefine.ESlotType, int> iconSizeBySlotType;

	// Token: 0x02007D8D RID: 32141
	public class DangoListRoleData
	{
		// Token: 0x0402AC43 RID: 175171
		public int Id;

		// Token: 0x0402AC44 RID: 175172
		[Nullable(2)]
		public AbyssDangoRoleData Data;

		// Token: 0x0402AC45 RID: 175173
		[Nullable(1)]
		public Action<DangoAbyssDefine.DangoListRoleData> OnClickCallBack = delegate(DangoAbyssDefine.DangoListRoleData data)
		{
		};
	}

	// Token: 0x02007D8E RID: 32142
	public enum EAbyssItemTipsState
	{
		// Token: 0x0402AC47 RID: 175175
		None,
		// Token: 0x0402AC48 RID: 175176
		ErrorDango,
		// Token: 0x0402AC49 RID: 175177
		DiffDango,
		// Token: 0x0402AC4A RID: 175178
		TakeOff,
		// Token: 0x0402AC4B RID: 175179
		Switch,
		// Token: 0x0402AC4C RID: 175180
		Move,
		// Token: 0x0402AC4D RID: 175181
		Replace,
		// Token: 0x0402AC4E RID: 175182
		PutOn,
		// Token: 0x0402AC4F RID: 175183
		Same,
		// Token: 0x0402AC50 RID: 175184
		Repeat
	}

	// Token: 0x02007D8F RID: 32143
	public class IAbyssItemTipsData
	{
		// Token: 0x0402AC51 RID: 175185
		public int DangoId;

		// Token: 0x0402AC52 RID: 175186
		public int SlotIndex;

		// Token: 0x0402AC53 RID: 175187
		public int IncId;
	}

	// Token: 0x02007D90 RID: 32144
	public enum ETagAddType
	{
		// Token: 0x0402AC55 RID: 175189
		Value = 1,
		// Token: 0x0402AC56 RID: 175190
		Ratio,
		// Token: 0x0402AC57 RID: 175191
		Seconds,
		// Token: 0x0402AC58 RID: 175192
		Level,
		// Token: 0x0402AC59 RID: 175193
		Name
	}

	// Token: 0x02007D91 RID: 32145
	public enum ESlotType
	{
		// Token: 0x0402AC5B RID: 175195
		Normal,
		// Token: 0x0402AC5C RID: 175196
		Core,
		// Token: 0x0402AC5D RID: 175197
		Passive
	}

	// Token: 0x02007D92 RID: 32146
	public class DangoAbyssTagData
	{
		// Token: 0x0402AC5E RID: 175198
		public int TagId;

		// Token: 0x0402AC5F RID: 175199
		public int Value;
	}

	// Token: 0x02007D93 RID: 32147
	public enum ETagDataGetType
	{
		// Token: 0x0402AC61 RID: 175201
		All,
		// Token: 0x0402AC62 RID: 175202
		Valid,
		// Token: 0x0402AC63 RID: 175203
		InValid
	}

	// Token: 0x02007D94 RID: 32148
	[NullableContext(2)]
	[Nullable(0)]
	public class EquipViewAttributeData
	{
		// Token: 0x0402AC64 RID: 175204
		public bool IsValid;

		// Token: 0x0402AC65 RID: 175205
		public AttrListScrollData Attribute;

		// Token: 0x0402AC66 RID: 175206
		public DangoAbyssDefine.DangoAbyssTagData Tag;

		// Token: 0x0402AC67 RID: 175207
		public bool IsChange;
	}

	// Token: 0x02007D95 RID: 32149
	[NullableContext(1)]
	[Nullable(0)]
	public class IDangoAbyssActorData
	{
		// Token: 0x0402AC68 RID: 175208
		public int DangoId;

		// Token: 0x0402AC69 RID: 175209
		public int MeshId;

		// Token: 0x0402AC6A RID: 175210
		public string DangoPointCase;

		// Token: 0x0402AC6B RID: 175211
		public FTransform? Transform;

		// Token: 0x0402AC6C RID: 175212
		public string StandAnimationName;
	}

	// Token: 0x02007D96 RID: 32150
	[NullableContext(1)]
	[Nullable(0)]
	public class IDangoUnlockData
	{
		// Token: 0x0402AC6D RID: 175213
		public int DangoId;

		// Token: 0x0402AC6E RID: 175214
		public int DangoLevel;

		// Token: 0x0402AC6F RID: 175215
		public string UnlockTitle;

		// Token: 0x0402AC70 RID: 175216
		public string UnlockSubTitle;

		// Token: 0x0402AC71 RID: 175217
		public string UnlockWutheringWaveTitleSpritePath;

		// Token: 0x0402AC72 RID: 175218
		public string DetailName;

		// Token: 0x0402AC73 RID: 175219
		public string DetailDialog;
	}

	// Token: 0x02007D97 RID: 32151
	public enum ESlotSwitchType
	{
		// Token: 0x0402AC75 RID: 175221
		None,
		// Token: 0x0402AC76 RID: 175222
		TakeOff,
		// Token: 0x0402AC77 RID: 175223
		Replace,
		// Token: 0x0402AC78 RID: 175224
		PutOn
	}

	// Token: 0x02007D98 RID: 32152
	public class IRecoveryRewardData
	{
		// Token: 0x0402AC79 RID: 175225
		public int ItemId;

		// Token: 0x0402AC7A RID: 175226
		public int Count;

		// Token: 0x0402AC7B RID: 175227
		public int? IncId;
	}

	// Token: 0x02007D99 RID: 32153
	public class IAbyssLikeRecord
	{
		// Token: 0x0402AC7C RID: 175228
		public int PlayerId;

		// Token: 0x0402AC7D RID: 175229
		[Nullable(1)]
		public List<int> LikedPlayerIdList;
	}
}
