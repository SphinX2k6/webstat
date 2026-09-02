using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.RefCompController
{
	// Token: 0x0200482C RID: 18476
	public class RefCompDefine
	{
		// Token: 0x0200A911 RID: 43281
		public enum ERefCompControllerType
		{
			// Token: 0x0403468E RID: 214670
			LevelSequence,
			// Token: 0x0403468F RID: 214671
			AirWall,
			// Token: 0x04034690 RID: 214672
			ModifyActorMaterial,
			// Token: 0x04034691 RID: 214673
			ModifyActorMedia
		}

		// Token: 0x0200A912 RID: 43282
		public class TransitStruct
		{
			// Token: 0x0604B0D7 RID: 307415 RVA: 0x0146E373 File Offset: 0x0146C573
			public TransitStruct(ELevelSequenceTransition transitType = ELevelSequenceTransition.Camera, float? duration = null, float? transitFadeIn = null, float? transitFadeOut = null, bool? bIsValid = false, ETransitionMask? mask = null)
			{
			}

			// Token: 0x04034692 RID: 214674
			public ELevelSequenceTransition TransitType = transitType;

			// Token: 0x04034693 RID: 214675
			public float? Duration = duration;

			// Token: 0x04034694 RID: 214676
			public float? TransitFadeIn = transitFadeIn;

			// Token: 0x04034695 RID: 214677
			public float? TransitFadeOut = transitFadeOut;

			// Token: 0x04034696 RID: 214678
			public bool? IsValid = bIsValid;

			// Token: 0x04034697 RID: 214679
			public ETransitionMask? Mask = mask;
		}

		// Token: 0x0200A913 RID: 43283
		public class PlayRateStruct
		{
			// Token: 0x0604B0D8 RID: 307416 RVA: 0x0146E3A8 File Offset: 0x0146C5A8
			public PlayRateStruct(float? playRateAbs = 1f, EKuroEasingFuncType easeType = EKuroEasingFuncType.KEF_Linear, float? easeDuration = 0f, float? easeExponent = 0f)
			{
			}

			// Token: 0x04034698 RID: 214680
			public float? PlayRateAbs = playRateAbs;

			// Token: 0x04034699 RID: 214681
			public EKuroEasingFuncType EaseType = easeType;

			// Token: 0x0403469A RID: 214682
			public float? EaseDuration = easeDuration;

			// Token: 0x0403469B RID: 214683
			public float? EaseExponent = easeExponent;
		}

		// Token: 0x0200A914 RID: 43284
		public class PrePhysicsSequenceConfig : IStaticVariableResetter
		{
			// Token: 0x0604B0D9 RID: 307417 RVA: 0x0146E3CD File Offset: 0x0146C5CD
			static PrePhysicsSequenceConfig()
			{
				StaticVariableRegister.RegisterAndExecute(new Action(RefCompDefine.PrePhysicsSequenceConfig.CreateStaticDefaultValue), new Action(RefCompDefine.PrePhysicsSequenceConfig.ResetStaticDefaultValue));
			}

			// Token: 0x0604B0DA RID: 307418 RVA: 0x0146E3EC File Offset: 0x0146C5EC
			public static void CreateStaticDefaultValue()
			{
				RefCompDefine.PrePhysicsSequenceConfig.Paths = new HashSet<string>();
				RefCompDefine.PrePhysicsSequenceConfig.IsInit = false;
			}

			// Token: 0x0604B0DB RID: 307419 RVA: 0x0146E3FE File Offset: 0x0146C5FE
			public static void ResetStaticDefaultValue()
			{
				RefCompDefine.PrePhysicsSequenceConfig.Paths = null;
				RefCompDefine.PrePhysicsSequenceConfig.IsInit = false;
			}

			// Token: 0x0604B0DC RID: 307420 RVA: 0x0146E40C File Offset: 0x0146C60C
			[NullableContext(2)]
			public static bool Check(string path = null)
			{
				if (string.IsNullOrEmpty(path))
				{
					return false;
				}
				if (!RefCompDefine.PrePhysicsSequenceConfig.IsInit)
				{
					IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("UpdateAnimRefLevelSequencePaths");
					if (stringArrayConfig != null)
					{
						foreach (string item in stringArrayConfig)
						{
							RefCompDefine.PrePhysicsSequenceConfig.Paths.Add(item);
						}
					}
					RefCompDefine.PrePhysicsSequenceConfig.IsInit = true;
				}
				return RefCompDefine.PrePhysicsSequenceConfig.Paths.Contains(path);
			}

			// Token: 0x0403469C RID: 214684
			[Nullable(1)]
			private static HashSet<string> Paths;

			// Token: 0x0403469D RID: 214685
			private static bool IsInit;
		}
	}
}
