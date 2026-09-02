using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x02004472 RID: 17522
	[NullableContext(1)]
	[Nullable(0)]
	public static class GameplayTagsManager
	{
		// Token: 0x0602E489 RID: 189577
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetOriginalTag_Internal(in FName tagName);

		// Token: 0x0602E48A RID: 189578 RVA: 0x00ADD4A9 File Offset: 0x00ADB6A9
		public static string GetOriginalTag(in FName tagName)
		{
			return GameplayTagsManager.GetOriginalTag_Internal(tagName);
		}
	}
}
