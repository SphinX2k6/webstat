using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FCF RID: 28623
	[NullableContext(1)]
	[Nullable(0)]
	public class InputFilterManager : IStaticVariableResetter
	{
		// Token: 0x06045418 RID: 283672 RVA: 0x01217820 File Offset: 0x01215A20
		static InputFilterManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(InputFilterManager.CreateStaticDefaultValue), new Action(InputFilterManager.ResetStaticDefaultValue));
		}

		// Token: 0x06045419 RID: 283673 RVA: 0x01217966 File Offset: 0x01215B66
		public static void UpdateCharacterSystemActions(EInputAction inputAction, EUiViewName uiViewName)
		{
			InputFilterManager.CharacterSystemActions[inputAction] = uiViewName;
		}

		// Token: 0x0604541A RID: 283674 RVA: 0x01217974 File Offset: 0x01215B74
		public static void CreateStaticDefaultValue()
		{
			InputFilterManager.CharacterSystemActions = new Dictionary<EInputAction, EUiViewName>();
			Dictionary<EUiViewName, HashSet<EInputAction>> dictionary = new Dictionary<EUiViewName, HashSet<EInputAction>>();
			EUiViewName plotSubtitleView = EUiViewName.PlotSubtitleView;
			dictionary[plotSubtitleView] = new HashSet<EInputAction>();
			InputFilterManager.CharacterSystemViewActions = dictionary;
		}

		// Token: 0x0604541B RID: 283675 RVA: 0x012179A7 File Offset: 0x01215BA7
		public static void ResetStaticDefaultValue()
		{
			InputFilterManager.CharacterSystemActions = null;
			InputFilterManager.CharacterSystemViewActions = null;
		}

		// Token: 0x04026A59 RID: 158297
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EInputAction> CharacterActions = new HashSet<EInputAction>
		{
			EInputAction.跳跃,
			EInputAction.攀爬,
			EInputAction.走跑切换,
			EInputAction.攻击,
			EInputAction.闪避,
			EInputAction.技能1,
			EInputAction.幻象1,
			EInputAction.大招,
			EInputAction.幻象2,
			EInputAction.切换角色1,
			EInputAction.切换角色2,
			EInputAction.切换角色3,
			EInputAction.锁定目标,
			EInputAction.瞄准,
			EInputAction.通用交互,
			EInputAction.下降,
			EInputAction.移动输入按键事件
		};

		// Token: 0x04026A5A RID: 158298
		public static Dictionary<EInputAction, EUiViewName> CharacterSystemActions;

		// Token: 0x04026A5B RID: 158299
		public static Dictionary<EUiViewName, HashSet<EInputAction>> CharacterSystemViewActions;

		// Token: 0x04026A5C RID: 158300
		[StaticVariableRuleIgnore]
		public static readonly HashSet<EInputAxis> CharacterAxes = new HashSet<EInputAxis>
		{
			EInputAxis.MoveForward,
			EInputAxis.MoveRight,
			EInputAxis.LookUp,
			EInputAxis.Turn,
			EInputAxis.Zoom
		};
	}
}
