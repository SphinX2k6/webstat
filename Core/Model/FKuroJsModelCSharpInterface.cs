using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Core.Model
{
	// Token: 0x02007123 RID: 28963
	public class FKuroJsModelCSharpInterface
	{
		// Token: 0x0604626D RID: 287341
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern bool ContainsActivateAiSenseObjects(int AiPerceptionDataHandle, byte SenseTarget, void* AiSenseObjectData);

		// Token: 0x0604626E RID: 287342
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void AddActivateAiSenseObjects(int AiPerceptionDataHandle, byte SenseTarget, void* AiSenseObjectData);

		// Token: 0x0604626F RID: 287343
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void RemoveActivateAiSenseObjects(int AiPerceptionDataHandle, byte SenseTarget, void* AiSenseObjectData);

		// Token: 0x06046270 RID: 287344
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetAiPerceptionDataMap(int AiPerceptionDataHandle, ref IntPtr OutEntitiesInSense, ref IntPtr OutEntitiesToAdd, ref IntPtr OutEntitiesRemoveTime, ref IntPtr OutEntitiesNotSense);

		// Token: 0x06046271 RID: 287345
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool GetEntitySenseType(int AiPerceptionDataHandle, int EntityId, ref byte OutSenseType);
	}
}
