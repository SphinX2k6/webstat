using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x0200446E RID: 17518
	[NullableContext(2)]
	[Nullable(0)]
	public static class FKuroWaterDetectedInterfaceHelper
	{
		// Token: 0x0602E46A RID: 189546
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Execute_BroadcastWaterDetectedTick_Internal(IntPtr obj, float deltaTime, float waterSurface, FVector location);

		// Token: 0x0602E46B RID: 189547 RVA: 0x00ADD37C File Offset: 0x00ADB57C
		public static void Execute_BroadcastWaterDetectedTick(UObject obj, float deltaTime, float waterSurface, FVector location)
		{
			if (obj == null || !obj.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedTick] UObject为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedTick_Internal(obj.NativePtr, deltaTime, waterSurface, location);
		}

		// Token: 0x0602E46C RID: 189548
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Execute_BroadcastWaterDetectedStart_Internal(IntPtr obj);

		// Token: 0x0602E46D RID: 189549 RVA: 0x00ADD3C0 File Offset: 0x00ADB5C0
		public static void Execute_BroadcastWaterDetectedStart(UObject obj)
		{
			if (obj == null || !obj.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedStart] UObject为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedStart_Internal(obj.NativePtr);
		}

		// Token: 0x0602E46E RID: 189550
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Execute_BroadcastWaterDetectedEnd_Internal(IntPtr obj);

		// Token: 0x0602E46F RID: 189551 RVA: 0x00ADD400 File Offset: 0x00ADB600
		public static void Execute_BroadcastWaterDetectedEnd(UObject obj)
		{
			if (obj == null || !obj.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedEnd] UObject为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroWaterDetectedInterfaceHelper.Execute_BroadcastWaterDetectedEnd_Internal(obj.NativePtr);
		}
	}
}
