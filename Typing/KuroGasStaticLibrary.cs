using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004475 RID: 17525
	public static class KuroGasStaticLibrary
	{
		// Token: 0x0602E4AA RID: 189610
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMultiAttributesValue_Internal(IntPtr attributeSet, IntPtr multiAttributes, IntPtr baseValues, IntPtr currentValues);

		// Token: 0x0602E4AB RID: 189611 RVA: 0x00ADD52C File Offset: 0x00ADB72C
		[NullableContext(1)]
		public static void SetMultiAttributesValue([Nullable(2)] UBaseAttributeSet attributeSet, ref TArray<int> multiAttributes, ref TArray<float> baseValues, ref TArray<float> currentValues)
		{
			if (attributeSet == null || !attributeSet.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Core, ELogAuthor.LRX, "[KuroGasStaticLibrary.SetMultiAttributesValue] attributeSet", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			KuroGasStaticLibrary.SetMultiAttributesValue_Internal(attributeSet.NativePtr, multiAttributes.NativePtr, baseValues.NativePtr, currentValues.NativePtr);
		}
	}
}
