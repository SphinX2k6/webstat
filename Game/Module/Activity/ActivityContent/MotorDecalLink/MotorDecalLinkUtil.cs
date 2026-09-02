using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorDecalLink
{
	// Token: 0x020066FD RID: 26365
	[NullableContext(1)]
	[Nullable(0)]
	public static class MotorDecalLinkUtil
	{
		// Token: 0x06041CD9 RID: 269529 RVA: 0x010E210A File Offset: 0x010E030A
		public static void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
		}

		// Token: 0x06041CDA RID: 269530 RVA: 0x010E210C File Offset: 0x010E030C
		public static void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.TZJ, "[摩托贴纸联动33] " + message, pairs);
		}
	}
}
