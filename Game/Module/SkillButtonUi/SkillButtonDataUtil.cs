using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkillButtonUi
{
	// Token: 0x02004F81 RID: 20353
	[NullableContext(1)]
	[Nullable(0)]
	public class SkillButtonDataUtil
	{
		// Token: 0x0603483F RID: 215103 RVA: 0x00D25600 File Offset: 0x00D23800
		// Note: this type is marked as 'beforefieldinit'.
		static SkillButtonDataUtil()
		{
			Dictionary<ESkillButtonType, int> dictionary = new Dictionary<ESkillButtonType, int>();
			dictionary[ESkillButtonType.攻击] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"];
			dictionary[ESkillButtonType.技能1] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"];
			dictionary[ESkillButtonType.大招] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"];
			dictionary[ESkillButtonType.闪避] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"];
			dictionary[ESkillButtonType.幻象1] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象1"];
			dictionary[ESkillButtonType.跳跃] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止跳跃"];
			dictionary[ESkillButtonType.攀爬] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攀爬"];
			dictionary[ESkillButtonType.幻象2] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象2"];
			dictionary[ESkillButtonType.副闪避] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"];
			dictionary[ESkillButtonType.副开火] = GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"];
			SkillButtonDataUtil.DisableTagMap = dictionary;
			Dictionary<ESkillButtonType, int> dictionary2 = new Dictionary<ESkillButtonType, int>();
			dictionary2[ESkillButtonType.攻击] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏普攻按键"];
			dictionary2[ESkillButtonType.技能1] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏技能按键"];
			dictionary2[ESkillButtonType.大招] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏大招按键"];
			dictionary2[ESkillButtonType.闪避] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏冲刺按键"];
			dictionary2[ESkillButtonType.幻象1] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏探索幻象按键"];
			dictionary2[ESkillButtonType.跳跃] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏跳跃按键"];
			dictionary2[ESkillButtonType.幻象2] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏攻击幻象按键"];
			dictionary2[ESkillButtonType.副闪避] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏冲刺按键"];
			dictionary2[ESkillButtonType.副开火] = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏普攻按键"];
			SkillButtonDataUtil.HiddenTagMap = dictionary2;
		}

		// Token: 0x0401E412 RID: 123922
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ESkillButtonType, int> DisableTagMap;

		// Token: 0x0401E413 RID: 123923
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<ESkillButtonType, int> HiddenTagMap;
	}
}
