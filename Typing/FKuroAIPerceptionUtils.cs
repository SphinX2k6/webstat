using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004468 RID: 17512
	[NullableContext(2)]
	[Nullable(0)]
	public static class FKuroAIPerceptionUtils
	{
		// Token: 0x0602E419 RID: 189465
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartAsyncAiPerception_Internal(IntPtr callback, int dataId, double nowTime, IntPtr lineElement);

		// Token: 0x0602E41A RID: 189466 RVA: 0x00ADCED0 File Offset: 0x00ADB0D0
		public static void StartAsyncAiPerception(in FAIAsyncPerceptionCallback callback, int dataId, double nowTime, UTraceLineElement lineElement)
		{
			if (callback == null || !callback.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroAIPerceptionUtils.StartAsyncAiPerception] callback", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (lineElement == null || !lineElement.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroAIPerceptionUtils.StartAsyncAiPerception] lineElement", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroAIPerceptionUtils.StartAsyncAiPerception_Internal(callback.NativePtr, dataId, nowTime, lineElement.NativePtr);
		}

		// Token: 0x0602E41B RID: 189467
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Initialize_Internal(IntPtr entityTypeQueryNames, int eEntityTypeQueryCharacter, int eEntityTypeQuerySceneItem, int eEntityTypeQueryMaxIndex, int eCharMoveStateOther, int eCharMoveStateStand, int eCharMoveStateWalk, int eCharMoveStateWalkStop, int eCharMoveStateGlide, int eCharPositionStateGround, int eSenseTargetTypeCharacter);

		// Token: 0x0602E41C RID: 189468 RVA: 0x00ADCF44 File Offset: 0x00ADB144
		public static void Initialize(in TArray<FName> entityTypeQueryNames, int eEntityTypeQueryCharacter, int eEntityTypeQuerySceneItem, int eEntityTypeQueryMaxIndex, int eCharMoveStateOther, int eCharMoveStateStand, int eCharMoveStateWalk, int eCharMoveStateWalkStop, int eCharMoveStateGlide, int eCharPositionStateGround, int eSenseTargetTypeCharacter)
		{
			if (entityTypeQueryNames == null || !entityTypeQueryNames.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroAIPerceptionUtils.Initialize] EntityTypeQueryNames无效", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroAIPerceptionUtils.Initialize_Internal(entityTypeQueryNames.NativePtr, eEntityTypeQueryCharacter, eEntityTypeQuerySceneItem, eEntityTypeQueryMaxIndex, eCharMoveStateOther, eCharMoveStateStand, eCharMoveStateWalk, eCharMoveStateWalkStop, eCharMoveStateGlide, eCharPositionStateGround, eSenseTargetTypeCharacter);
		}

		// Token: 0x0602E41D RID: 189469
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Clear_Internal();

		// Token: 0x0602E41E RID: 189470 RVA: 0x00ADCF97 File Offset: 0x00ADB197
		public static void Clear()
		{
			FKuroAIPerceptionUtils.Clear_Internal();
		}
	}
}
