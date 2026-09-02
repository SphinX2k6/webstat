using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using UnrealEngine;

namespace CSharpScript.Game.Render.Effect.ScreenEffectSystem
{
	// Token: 0x02004798 RID: 18328
	public class ScreenEffectSystem : IStaticVariableResetter
	{
		// Token: 0x0602F909 RID: 194825 RVA: 0x00B55F64 File Offset: 0x00B54164
		static ScreenEffectSystem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ScreenEffectSystem.CreateStaticDefaultValue), new Action(ScreenEffectSystem.ResetStaticDefaultValue));
		}

		// Token: 0x0602F90A RID: 194826 RVA: 0x00B55F83 File Offset: 0x00B54183
		public static void CreateStaticDefaultValue()
		{
		}

		// Token: 0x0602F90B RID: 194827 RVA: 0x00B55F85 File Offset: 0x00B54185
		public static void ResetStaticDefaultValue()
		{
			ScreenEffectSystem._instance = null;
		}

		// Token: 0x0602F90C RID: 194828 RVA: 0x00B55F8D File Offset: 0x00B5418D
		[NullableContext(1)]
		public static BP_ScreenEffectSystem_C GetInstance()
		{
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem._instance;
			if (instance == null || !instance.IsValid())
			{
				ScreenEffectSystem._instance = (Singleton<ActorSystem>.Instance.Get(BP_ScreenEffectSystem_C.StaticClass(), new FTransformDouble(), null, true) as BP_ScreenEffectSystem_C);
			}
			return ScreenEffectSystem._instance;
		}

		// Token: 0x0401B33E RID: 111422
		[Nullable(2)]
		private static BP_ScreenEffectSystem_C _instance;
	}
}
