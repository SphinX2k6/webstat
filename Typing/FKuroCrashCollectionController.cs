using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x0200446A RID: 17514
	public static class FKuroCrashCollectionController
	{
		// Token: 0x0602E423 RID: 189475
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Initialize_Internal(IntPtr world, FName actorLocationName, FName actorRotationName, FName cameraLocationName, FName cameraRotationName, FName worldName);

		// Token: 0x0602E424 RID: 189476 RVA: 0x00ADCFB0 File Offset: 0x00ADB1B0
		[NullableContext(2)]
		public static void Initialize(UWorld world, FName actorLocationName, FName actorRotationName, FName cameraLocationName, FName cameraRotationName, FName worldName)
		{
			if (world == null || !world.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[FKuroCrashCollectionController.Initialize] World为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			FKuroCrashCollectionController.Initialize_Internal(world.NativePtr, actorLocationName, actorRotationName, cameraLocationName, cameraRotationName, worldName);
		}
	}
}
