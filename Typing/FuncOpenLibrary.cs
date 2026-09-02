using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004471 RID: 17521
	[NullableContext(1)]
	[Nullable(0)]
	public class FuncOpenLibrary
	{
		// Token: 0x0602E47E RID: 189566
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFirstTimestamp_Internal(uint timestamp);

		// Token: 0x0602E47F RID: 189567 RVA: 0x00ADD479 File Offset: 0x00ADB679
		public static void SetFirstTimestamp(long timestamp)
		{
			FuncOpenLibrary.SetFirstTimestamp_Internal((uint)timestamp);
		}

		// Token: 0x0602E480 RID: 189568
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void TryOpen_Internal(ref FArrayBuffer view);

		// Token: 0x0602E481 RID: 189569 RVA: 0x00ADD482 File Offset: 0x00ADB682
		public static void TryOpen(ref FArrayBuffer view)
		{
			FuncOpenLibrary.TryOpen_Internal(ref view);
		}

		// Token: 0x0602E482 RID: 189570
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern FArrayBuffer GetEBuffer_Internal();

		// Token: 0x0602E483 RID: 189571 RVA: 0x00ADD48A File Offset: 0x00ADB68A
		public static FArrayBuffer GetEBuffer()
		{
			return FuncOpenLibrary.GetEBuffer_Internal();
		}

		// Token: 0x0602E484 RID: 189572
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FreeArrayBuffer_Internal(ref FArrayBuffer view);

		// Token: 0x0602E485 RID: 189573 RVA: 0x00ADD491 File Offset: 0x00ADB691
		public static void FreeArrayBuffer(ref FArrayBuffer view)
		{
			FuncOpenLibrary.FreeArrayBuffer_Internal(ref view);
		}

		// Token: 0x0602E486 RID: 189574
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetIsCheckEncrypt_Internal(string str);

		// Token: 0x0602E487 RID: 189575 RVA: 0x00ADD499 File Offset: 0x00ADB699
		public static void SetIsCheckEncrypt(string str)
		{
			FuncOpenLibrary.SetIsCheckEncrypt_Internal(str);
		}
	}
}
