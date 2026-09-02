using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004474 RID: 17524
	public class KuroCharacterShadowLibrary
	{
		// Token: 0x0602E4A5 RID: 189605
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Set_Internal(in FGuid a);

		// Token: 0x0602E4A6 RID: 189606 RVA: 0x00ADD511 File Offset: 0x00ADB711
		public static void Set(in FGuid a)
		{
			KuroCharacterShadowLibrary.Set_Internal(a);
		}

		// Token: 0x0602E4A7 RID: 189607
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetR_Internal(in FArrayBuffer view);

		// Token: 0x0602E4A8 RID: 189608 RVA: 0x00ADD519 File Offset: 0x00ADB719
		public static void SetR(in FArrayBuffer view)
		{
			KuroCharacterShadowLibrary.SetR_Internal(view);
		}
	}
}
