using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Typing
{
	// Token: 0x02004478 RID: 17528
	public class KuroTime
	{
		// Token: 0x0602E4C6 RID: 189638
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetCycles64();

		// Token: 0x0602E4C7 RID: 189639
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern ulong GetCycles64BigInt();

		// Token: 0x0602E4C8 RID: 189640
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetMicroseconds64();

		// Token: 0x0602E4C9 RID: 189641
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetMilliseconds64();

		// Token: 0x0602E4CA RID: 189642
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double GetSecondsPerCycle();
	}
}
