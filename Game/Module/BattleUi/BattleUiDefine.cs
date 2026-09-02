using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F56 RID: 24406
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiDefine
	{
		// Token: 0x0603D4F5 RID: 251125 RVA: 0x00F98ABC File Offset: 0x00F96CBC
		// Note: this type is marked as 'beforefieldinit'.
		static BattleUiDefine()
		{
			Dictionary<EElementPowerType, int> dictionary = new Dictionary<EElementPowerType, int>();
			dictionary[EElementPowerType.ElementPower1] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.冰"];
			dictionary[EElementPowerType.ElementPower2] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.火"];
			dictionary[EElementPowerType.ElementPower3] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.雷"];
			dictionary[EElementPowerType.ElementPower4] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.风"];
			dictionary[EElementPowerType.ElementPower5] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.光"];
			dictionary[EElementPowerType.ElementPower6] = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.暗"];
			BattleUiDefine.elementTypeToElementTag = dictionary;
			Dictionary<int, EElementPowerType> dictionary2 = new Dictionary<int, EElementPowerType>();
			int key = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.冰"];
			dictionary2[key] = EElementPowerType.ElementPower1;
			int key2 = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.火"];
			dictionary2[key2] = EElementPowerType.ElementPower2;
			int key3 = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.雷"];
			dictionary2[key3] = EElementPowerType.ElementPower3;
			int key4 = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.风"];
			dictionary2[key4] = EElementPowerType.ElementPower4;
			int key5 = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.光"];
			dictionary2[key5] = EElementPowerType.ElementPower5;
			int key6 = GameplayTagDefine.EGameplayTagId["GameplayCue.Common.元素.暗"];
			dictionary2[key6] = EElementPowerType.ElementPower6;
			BattleUiDefine.elementTagToElementType = dictionary2;
			Dictionary<EInputAction, int> dictionary3 = new Dictionary<EInputAction, int>();
			dictionary3[EInputAction.攻击] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏普攻按键"];
			dictionary3[EInputAction.技能1] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏技能按键"];
			dictionary3[EInputAction.幻象1] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏探索幻象按键"];
			dictionary3[EInputAction.幻象2] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏攻击幻象按键"];
			dictionary3[EInputAction.闪避] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏冲刺按键"];
			dictionary3[EInputAction.跳跃] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏跳跃按键"];
			dictionary3[EInputAction.大招] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏大招按键"];
			BattleUiDefine.hideInputTagMap = dictionary3;
			Dictionary<EBossStateViewType, string> dictionary4 = new Dictionary<EBossStateViewType, string>();
			dictionary4[EBossStateViewType.Common] = "UiItem_BossState_Prefab";
			dictionary4[EBossStateViewType.DoubleBar] = "UiItem_BossStateDouble_Prefab";
			dictionary4[EBossStateViewType.MultiLayer] = "UiItem_BossStateMultiLayer_Prefab";
			BattleUiDefine.bossStateViewResourceIdMap = dictionary4;
		}

		// Token: 0x04022674 RID: 140916
		public const float DAMAGE_LEFT_RATIO = 0.25f;

		// Token: 0x04022675 RID: 140917
		public const float DAMAGE_MIDDLE_RATIO = 0.75f;

		// Token: 0x04022676 RID: 140918
		public const float DAMAGE_RIGHT_RATIO = 1f;

		// Token: 0x04022677 RID: 140919
		public const int DAMAGE_ANIMATION_MAX_LENGTH = 240;

		// Token: 0x04022678 RID: 140920
		public const int CURE_DAMAGE_TEXT = 8;

		// Token: 0x04022679 RID: 140921
		public const int IMMUNITY_DAMAGE_TEXT_ID = 9;

		// Token: 0x0402267A RID: 140922
		public const int ATK_DAMAGE_TEXT = 10;

		// Token: 0x0402267B RID: 140923
		public const int SHEILD_COVER_TEXT = 12;

		// Token: 0x0402267C RID: 140924
		public const string IMMUNITY_DAMAGE_TEXT = "Immune";

		// Token: 0x0402267D RID: 140925
		public const int SKILL_COOLDOWN_INTERVAL = 100;

		// Token: 0x0402267E RID: 140926
		public const int SKILL_COOLDOWN_DELAY = 100;

		// Token: 0x0402267F RID: 140927
		public const float SKILL_COOLDOWN_LOOP_INTERVAL = 0.1f;

		// Token: 0x04022680 RID: 140928
		public const int SECOND_TO_MILLISECOND = 1000;

		// Token: 0x04022681 RID: 140929
		public const int HEAD_STATE_RANGE = 1000000;

		// Token: 0x04022682 RID: 140930
		public const int CHANGE_COOLDOWN_INTERVAL = 100;

		// Token: 0x04022683 RID: 140931
		public const int CHANGE_COOLDOWN_DELAY = 100;

		// Token: 0x04022684 RID: 140932
		public const float CHANGE_COOLDOWN_LOOP_INTERVAL = 0.1f;

		// Token: 0x04022685 RID: 140933
		public const int BE_HIT_DELAY = 5000;

		// Token: 0x04022686 RID: 140934
		public const int DAMAGE_VIEW_OFFSET_MAX_DISTANCE = 640000;

		// Token: 0x04022687 RID: 140935
		public const float DAMAGE_VIEW_OFFSET_MIN_RATIO = 0.2f;

		// Token: 0x04022688 RID: 140936
		public const int REFRESH_POSITION_INTERVAL = 1000;

		// Token: 0x04022689 RID: 140937
		public const int CLAMP_RANGE = 130;

		// Token: 0x0402268A RID: 140938
		public const int INPUT_SKILL_ACTION_NUM = 6;

		// Token: 0x0402268B RID: 140939
		public const int SPECIAL_ENERGY_BAR_WIDTH = 440;

		// Token: 0x0402268C RID: 140940
		public const float AREAL_BOX_WIETH_A = 35.2f;

		// Token: 0x0402268D RID: 140941
		public const float AREAL_BOX_WIETH_B = 123.2f;

		// Token: 0x0402268E RID: 140942
		public const float AREAL_BOX_WIETH_C = 250f;

		// Token: 0x0402268F RID: 140943
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EElementPowerType, int> elementTypeToElementTag;

		// Token: 0x04022690 RID: 140944
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<int, EElementPowerType> elementTagToElementType;

		// Token: 0x04022691 RID: 140945
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EInputAction, int> hideInputTagMap;

		// Token: 0x04022692 RID: 140946
		[StaticVariableRuleIgnore]
		public static readonly IReadOnlyDictionary<EBossStateViewType, string> bossStateViewResourceIdMap;

		// Token: 0x04022693 RID: 140947
		public const int DELAY_REFRESH_ELEMENT_BALL = 3000;

		// Token: 0x04022694 RID: 140948
		public const float BUFF_END_REMAINING_TIME = 2f;
	}
}
