using System;
using CSharpScript.Core.Model;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Game.Common
{
	// Token: 0x0200705E RID: 28766
	public class AsyncUtil
	{
		// Token: 0x06045A70 RID: 285296 RVA: 0x01233A38 File Offset: 0x01231C38
		public static void InitializeEnvironment()
		{
			if (!Singleton<JsModelManager>.Instance.HasInitialized)
			{
				Singleton<JsModelManager>.Instance.InitializeEnvironment();
				ConfigBase<AiConfig>.Instance.AsyncAiPerception = true;
				ConfigBase<AiConfig>.Instance.CppAsyncAiPerception = true;
				if (ConfigBase<AiConfig>.Instance.CppAsyncAiPerception)
				{
					TArray<FName> tarray = new TArray<FName>();
					foreach (FName value in EntityHelperConstants.GlobalEntityTypeQueryName)
					{
						tarray.Add(value);
					}
					FKuroAIPerceptionUtils.Initialize(tarray, 496, 15, 9, 0, 1, 2, 3, 16, 0, 0);
				}
			}
		}

		// Token: 0x06045A71 RID: 285297 RVA: 0x01233ABE File Offset: 0x01231CBE
		public static void DestroyEnvironment()
		{
			if (Singleton<JsModelManager>.Instance.HasInitialized)
			{
				FKuroAIPerceptionUtils.Clear();
				Singleton<JsModelManager>.Instance.DestroyEnvironment();
			}
		}
	}
}
