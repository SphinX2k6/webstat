using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Input.InputActionLogic
{
	// Token: 0x02006FDE RID: 28638
	public class InputActionLogicFactory
	{
		// Token: 0x06045479 RID: 283769 RVA: 0x012186DC File Offset: 0x012168DC
		public static void Initialize()
		{
			InputActionLogicFactory.InputActionLogicMap.Clear();
			InputActionLogicFactory.InputActionLogicMap[EInputAction.跳跃] = new JumpInputActionLogic();
			InputActionLogicFactory.InputActionLogicMap[EInputAction.闪避] = new DodgeInputActionLogic();
		}

		// Token: 0x0604547A RID: 283770 RVA: 0x01218710 File Offset: 0x01216910
		[NullableContext(2)]
		public static InputActionLogicBase GetInputActionLogic(EInputAction action)
		{
			InputActionLogicBase result;
			if (InputActionLogicFactory.InputActionLogicMap.TryGetValue(action, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x04026A85 RID: 158341
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EInputAction, InputActionLogicBase> InputActionLogicMap = new Dictionary<EInputAction, InputActionLogicBase>();
	}
}
