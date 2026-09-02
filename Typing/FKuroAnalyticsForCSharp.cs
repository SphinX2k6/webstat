using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Typing
{
	// Token: 0x02004469 RID: 17513
	[NullableContext(1)]
	[Nullable(0)]
	public static class FKuroAnalyticsForCSharp
	{
		// Token: 0x0602E41F RID: 189471
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Track_Internal(string eventName, string properties, int index = 0);

		// Token: 0x0602E420 RID: 189472 RVA: 0x00ADCF9E File Offset: 0x00ADB19E
		public static bool Track(string eventName, string properties, int index = 0)
		{
			return FKuroAnalyticsForCSharp.Track_Internal(eventName, properties, index);
		}

		// Token: 0x0602E421 RID: 189473
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Flush_Internal(int index = 0);

		// Token: 0x0602E422 RID: 189474 RVA: 0x00ADCFA8 File Offset: 0x00ADB1A8
		public static void Flush(int index = 0)
		{
			FKuroAnalyticsForCSharp.Flush_Internal(index);
		}
	}
}
