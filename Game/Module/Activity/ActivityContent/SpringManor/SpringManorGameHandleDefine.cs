using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062F5 RID: 25333
	public class SpringManorGameHandleDefine : IStaticVariableResetter
	{
		// Token: 0x0603FADF RID: 260831 RVA: 0x0105327A File Offset: 0x0105147A
		static SpringManorGameHandleDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SpringManorGameHandleDefine.CreateStaticDefaultValue), new Action(SpringManorGameHandleDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603FAE0 RID: 260832 RVA: 0x01053299 File Offset: 0x01051499
		public static void CreateStaticDefaultValue()
		{
			SpringManorGameHandleDefine.springManorGameHandleDefine = new Dictionary<ESpringFunctionType, SpringManorGameHandleBase>
			{
				{
					ESpringFunctionType.Card,
					new SpringManorGuessJokerHandle()
				},
				{
					ESpringFunctionType.Drink,
					new SpringManorDrinkHandle()
				},
				{
					ESpringFunctionType.Publicity,
					new SpringManorBrochureHandle()
				},
				{
					ESpringFunctionType.Draw,
					new SpringManorDrawHandle()
				}
			};
		}

		// Token: 0x0603FAE1 RID: 260833 RVA: 0x010532D5 File Offset: 0x010514D5
		public static void ResetStaticDefaultValue()
		{
			SpringManorGameHandleDefine.springManorGameHandleDefine = null;
		}

		// Token: 0x04023C08 RID: 146440
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<ESpringFunctionType, SpringManorGameHandleBase> springManorGameHandleDefine;
	}
}
