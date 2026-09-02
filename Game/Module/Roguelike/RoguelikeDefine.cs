using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200511B RID: 20763
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeDefine : IStaticVariableResetter
	{
		// Token: 0x06035779 RID: 219001 RVA: 0x00D6B3B9 File Offset: 0x00D695B9
		static RoguelikeDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoguelikeDefine.CreateStaticDefaultValue), new Action(RoguelikeDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603577A RID: 219002 RVA: 0x00D6B3D8 File Offset: 0x00D695D8
		public static void CreateStaticDefaultValue()
		{
			RoguelikeDefine.sortElementArray = new EElementType[]
			{
				EElementType.Element1,
				EElementType.Element2,
				EElementType.Element3,
				EElementType.Element4
			};
		}

		// Token: 0x0603577B RID: 219003 RVA: 0x00D6B3F0 File Offset: 0x00D695F0
		public static void ResetStaticDefaultValue()
		{
			RoguelikeDefine.sortElementArray = null;
		}

		// Token: 0x0401EBAE RID: 125870
		[Nullable(2)]
		public static EElementType[] sortElementArray;

		// Token: 0x0401EBAF RID: 125871
		public const int ROGUELIKE_FORMATION_COUNT = 3;

		// Token: 0x0401EBB0 RID: 125872
		public const int ROGUELIKE_FORMATION_MAIN_INDEX = 0;

		// Token: 0x0401EBB1 RID: 125873
		public const int OUTSIDE_CURRENCY_ID = 80100001;

		// Token: 0x0401EBB2 RID: 125874
		public const int INSIDE_CURRENCY_ID = 80100000;

		// Token: 0x0401EBB3 RID: 125875
		public const int COLLECT_SCORE_ID = 80100002;

		// Token: 0x0401EBB4 RID: 125876
		public const int SKILL_POINT_ID = 80100003;

		// Token: 0x0401EBB5 RID: 125877
		public const int ROGUE_DETECTION_TAB_ID = 18;

		// Token: 0x0401EBB6 RID: 125878
		public const int ROGUELIKE_HELP_ID = 76;

		// Token: 0x0401EBB7 RID: 125879
		public const int DEFAULT_ROGUELIKE_ENTRY_RATE = 10000;

		// Token: 0x0401EBB8 RID: 125880
		public const string PHANTOM_SELECT_ITEM = "UiItem_PhantomSelectItem_Prefab";

		// Token: 0x0401EBB9 RID: 125881
		public const string ROLE_SELECT_ITEM = "UiItem_RoleSelectItem_Prefab";

		// Token: 0x0401EBBA RID: 125882
		public const string COMMON_SELECT_ITEM = "UiItem_CommonSelectItem_Prefab";

		// Token: 0x0401EBBB RID: 125883
		public const string ROGUELIKEVIEW_1_TEXT = "RoguelikeView_1_Text";

		// Token: 0x0401EBBC RID: 125884
		public const string ROGUELIKEVIEW_2_TEXT = "RoguelikeView_2_Text";

		// Token: 0x0401EBBD RID: 125885
		public const string ROGUELIKEVIEW_3_TEXT = "RoguelikeView_3_Text";

		// Token: 0x0401EBBE RID: 125886
		public const string ROGUELIKEVIEW_4_TEXT = "RoguelikeView_4_Text";

		// Token: 0x0401EBBF RID: 125887
		public const string ROGUELIKEVIEW_5_TEXT = "RoguelikeView_5_Text";

		// Token: 0x0401EBC0 RID: 125888
		public const string ROGUELIKEVIEW_6_TEXT = "RoguelikeView_6_Text";

		// Token: 0x0401EBC1 RID: 125889
		public const string ROGUELIKEVIEW_7_TEXT = "RoguelikeView_7_Text";

		// Token: 0x0401EBC2 RID: 125890
		public const string ROGUELIKEVIEW_8_TEXT = "RoguelikeView_8_Text";

		// Token: 0x0401EBC3 RID: 125891
		public const string ROGUELIKEVIEW_9_TEXT = "RoguelikeView_9_Text";

		// Token: 0x0401EBC4 RID: 125892
		public const string ROGUELIKEVIEW_10_TEXT = "RoguelikeView_10_Text";

		// Token: 0x0401EBC5 RID: 125893
		public const string ROGUELIKEVIEW_11_TEXT = "RoguelikeView_11_Text";

		// Token: 0x0401EBC6 RID: 125894
		public const string ROGUELIKEVIEW_12_TEXT = "RoguelikeView_12_Text";

		// Token: 0x0401EBC7 RID: 125895
		public const string ROGUELIKEVIEW_13_TEXT = "RoguelikeView_13_Text";

		// Token: 0x0401EBC8 RID: 125896
		public const string ROGUELIKEVIEW_14_TEXT = "RoguelikeView_14_Text";

		// Token: 0x0401EBC9 RID: 125897
		public const string ROGUELIKEVIEW_15_TEXT = "RoguelikeView_15_Text";

		// Token: 0x0401EBCA RID: 125898
		public const string ROGUELIKEVIEW_16_TEXT = "RoguelikeView_16_Text";

		// Token: 0x0401EBCB RID: 125899
		public const string ROGUELIKEVIEW_17_TEXT = "RoguelikeView_17_Text";

		// Token: 0x0401EBCC RID: 125900
		public const string ROGUELIKEVIEW_18_TEXT = "RoguelikeView_18_Text";

		// Token: 0x0401EBCD RID: 125901
		public const string ROGUELIKEVIEW_19_TEXT = "RoguelikeView_19_Text";

		// Token: 0x0401EBCE RID: 125902
		public const string ROGUELIKEVIEW_20_TEXT = "RoguelikeView_20_Text";

		// Token: 0x0401EBCF RID: 125903
		public const string ROGUELIKEVIEW_21_TEXT = "RoguelikeView_21_Text";

		// Token: 0x0401EBD0 RID: 125904
		public const string ROGUELIKEVIEW_22_TEXT = "RoguelikeView_22_Text";

		// Token: 0x0401EBD1 RID: 125905
		public const string ROGUELIKEVIEW_23_TEXT = "RoguelikeView_23_Text";

		// Token: 0x0401EBD2 RID: 125906
		public const string ROGUELIKEVIEW_24_TEXT = "RoguelikeView_24_Text";

		// Token: 0x0401EBD3 RID: 125907
		public const string ROGUELIKEVIEW_25_TEXT = "RoguelikeView_25_Text";

		// Token: 0x0401EBD4 RID: 125908
		public const string COMPLETE = "Complete";

		// Token: 0x0401EBD5 RID: 125909
		public const string ROGUELIKEVIEW_NOTFINIST_TEXT = "RoguelikeView_NotFinish_Text";

		// Token: 0x0401EBD6 RID: 125910
		public const string ROGUELIKEVIEW_PREVIEW_TEXT = "RoguelikeView_Preview_Text";

		// Token: 0x0401EBD7 RID: 125911
		public const string ROGUELIKEVIEW_FINIST_TEXT = "RoguelikeView_Finish_Text";

		// Token: 0x0401EBD8 RID: 125912
		public const string T_ROGUELIKETOTALELEMENT = "T_RoguelikeTotalElement";

		// Token: 0x0401EBD9 RID: 125913
		public const float ROGUELIKE_SPECIAL_ITEM_UNLOCK_ALPHA = 1f;

		// Token: 0x0401EBDA RID: 125914
		public const float ROGUELIKE_SPECIAL_ITEM_LOCK_ALPHA = 0.6f;
	}
}
