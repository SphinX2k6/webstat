using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Typing
{
	// Token: 0x0200446F RID: 17519
	[NullableContext(1)]
	[Nullable(0)]
	public static class FThinkingAnalyticsForCSharp
	{
		// Token: 0x0602E470 RID: 189552
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Track_Internal(string eventName, string properties, int index = 0);

		// Token: 0x0602E471 RID: 189553 RVA: 0x00ADD43F File Offset: 0x00ADB63F
		public static bool Track(string eventName, string properties, int index = 0)
		{
			return FThinkingAnalyticsForCSharp.Track_Internal(eventName, properties, index);
		}

		// Token: 0x0602E472 RID: 189554
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Flush_Internal(int index = 0);

		// Token: 0x0602E473 RID: 189555 RVA: 0x00ADD449 File Offset: 0x00ADB649
		public static void Flush(int index = 0)
		{
			FThinkingAnalyticsForCSharp.Flush_Internal(index);
		}
	}
}
