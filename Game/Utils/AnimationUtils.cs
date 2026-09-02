using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046F0 RID: 18160
	[NullableContext(1)]
	[Nullable(0)]
	public class AnimationUtils
	{
		// Token: 0x0602F3C5 RID: 193477 RVA: 0x00B32FE4 File Offset: 0x00B311E4
		public static void GetRootLocationCurveValue(Entity entity, Vector outV)
		{
			outV.Reset();
			if (!entity.Valid)
			{
				return;
			}
			CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
			UAnimInstance uanimInstance = (component != null) ? component.MainAnimInstance : null;
			if (uanimInstance == null)
			{
				return;
			}
			float curveValue = uanimInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.ROOT_X);
			float curveValue2 = uanimInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.ROOT_Y);
			float curveValue3 = uanimInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.ROOT_Z);
			outV.Set((double)curveValue, (double)curveValue2, (double)curveValue3);
		}

		// Token: 0x0602F3C6 RID: 193478 RVA: 0x00B33058 File Offset: 0x00B31258
		public static void GetRootLocationCurveValueWithDelta(Entity entity, float deltaTime, Vector outV)
		{
			outV.Reset();
			if (!entity.Valid)
			{
				return;
			}
			CharacterAnimationComponent component = entity.GetComponent<CharacterAnimationComponent>();
			UAnimInstance uanimInstance = (component != null) ? component.MainAnimInstance : null;
			if (uanimInstance == null)
			{
				return;
			}
			float mainAnimsCurveValueWithDelta = uanimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_X, deltaTime, false, false);
			float mainAnimsCurveValueWithDelta2 = uanimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_Y, deltaTime, false, false);
			float mainAnimsCurveValueWithDelta3 = uanimInstance.GetMainAnimsCurveValueWithDelta(Singleton<CharacterNameDefines>.Instance.ROOT_Z, deltaTime, false, false);
			outV.Set((double)mainAnimsCurveValueWithDelta, (double)mainAnimsCurveValueWithDelta2, (double)mainAnimsCurveValueWithDelta3);
		}
	}
}
