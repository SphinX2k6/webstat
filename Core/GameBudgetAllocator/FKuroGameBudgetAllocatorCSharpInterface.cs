using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core.GameBudgetAllocator
{
	// Token: 0x02007125 RID: 28965
	[NullableContext(1)]
	[Nullable(0)]
	public class FKuroGameBudgetAllocatorCSharpInterface
	{
		// Token: 0x06046279 RID: 287353
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint RegisterFunction(IntPtr GCHandlePtr, in FName GroupTag, ESignificanceGroup SignificanceGroup, IntPtr ActorPtr, bool OverrideLateUpdate, bool OverrideEnableChange, bool OverrideWasRecentlyRenderedChange, bool OverrideLocationProxy);

		// Token: 0x0604627A RID: 287354
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetAllPlayerEntities(ref IntPtr[] OutEntities);

		// Token: 0x0604627B RID: 287355
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetEntitiesInRangeWithLocation(in FVectorDouble Location, float Distance, in FName GroupName, ref IntPtr[] OutEntities);
	}
}
