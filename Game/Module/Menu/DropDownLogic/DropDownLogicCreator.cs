using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.DropDownLogic
{
	// Token: 0x020057D1 RID: 22481
	public class DropDownLogicCreator : IStaticVariableResetter
	{
		// Token: 0x06039248 RID: 234056 RVA: 0x00E7D1D2 File Offset: 0x00E7B3D2
		static DropDownLogicCreator()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(DropDownLogicCreator.CreateStaticDefaultValue), new Action(DropDownLogicCreator.ResetStaticDefaultValue));
		}

		// Token: 0x06039249 RID: 234057 RVA: 0x00E7D1F1 File Offset: 0x00E7B3F1
		public static void CreateStaticDefaultValue()
		{
			DropDownLogicCreator.LogicMap = new Dictionary<EFunction, DropDownLogicBase>
			{
				{
					EFunction.TEXTLANGUAGE,
					new LanguageLogic()
				},
				{
					EFunction.SkillLockEnemyMode,
					new SkillLockEnemyLogic()
				}
			};
		}

		// Token: 0x0603924A RID: 234058 RVA: 0x00E7D21A File Offset: 0x00E7B41A
		public static void ResetStaticDefaultValue()
		{
			DropDownLogicCreator.LogicMap = null;
		}

		// Token: 0x0603924B RID: 234059 RVA: 0x00E7D224 File Offset: 0x00E7B424
		[NullableContext(2)]
		public static DropDownLogicBase GetDropDownLogic(EFunction type)
		{
			DropDownLogicBase result;
			if (!DropDownLogicCreator.LogicMap.TryGetValue(type, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0402085C RID: 133212
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EFunction, DropDownLogicBase> LogicMap;
	}
}
