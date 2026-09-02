using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.ExploreInteractiveCondition
{
	// Token: 0x02004864 RID: 18532
	public class CustomConditionDefine : IStaticVariableResetter
	{
		// Token: 0x06030370 RID: 197488 RVA: 0x00BB8A96 File Offset: 0x00BB6C96
		[NullableContext(1)]
		public static CustomConditionListener CreateConditionListener(CustomConditionDefine.ECustomConditionType type, Action<bool> onConditionChange)
		{
			return CustomConditionDefine._customConditionMap[type](onConditionChange);
		}

		// Token: 0x06030371 RID: 197489 RVA: 0x00BB8AA9 File Offset: 0x00BB6CA9
		static CustomConditionDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CustomConditionDefine.CreateStaticDefaultValue), new Action(CustomConditionDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06030372 RID: 197490 RVA: 0x00BB8AC8 File Offset: 0x00BB6CC8
		public static void CreateStaticDefaultValue()
		{
			Dictionary<CustomConditionDefine.ECustomConditionType, Func<Action<bool>, CustomConditionListener>> dictionary = new Dictionary<CustomConditionDefine.ECustomConditionType, Func<Action<bool>, CustomConditionListener>>();
			dictionary.Add(CustomConditionDefine.ECustomConditionType.QuantumDiffusion, (Action<bool> onConditionChange) => new QuantumDiffusionConditionListener(onConditionChange));
			CustomConditionDefine._customConditionMap = dictionary;
		}

		// Token: 0x06030373 RID: 197491 RVA: 0x00BB8AFA File Offset: 0x00BB6CFA
		public static void ResetStaticDefaultValue()
		{
			CustomConditionDefine._customConditionMap = null;
		}

		// Token: 0x0401BAFE RID: 113406
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private static Dictionary<CustomConditionDefine.ECustomConditionType, Func<Action<bool>, CustomConditionListener>> _customConditionMap;

		// Token: 0x0200A932 RID: 43314
		public enum ECustomConditionType
		{
			// Token: 0x040346F5 RID: 214773
			QuantumDiffusion
		}
	}
}
