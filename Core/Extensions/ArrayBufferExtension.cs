using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core.Extensions
{
	// Token: 0x0200712E RID: 28974
	public static class ArrayBufferExtension
	{
		// Token: 0x060462A2 RID: 287394 RVA: 0x0126D304 File Offset: 0x0126B504
		[NullableContext(1)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] ToByteArray(this FArrayBuffer buffer)
		{
			int num = (int)buffer.Length;
			byte[] array = new byte[num];
			Span<byte> span = new Span<byte>(buffer.Data, num);
			span.CopyTo(array);
			return array;
		}

		// Token: 0x060462A3 RID: 287395 RVA: 0x0126D33C File Offset: 0x0126B53C
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Span<byte> ToSpan(this FArrayBuffer buffer)
		{
			int length = (int)buffer.Length;
			return new Span<byte>(buffer.Data, length);
		}
	}
}
