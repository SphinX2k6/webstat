using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200626A RID: 25194
	[NullableContext(1)]
	[Nullable(0)]
	public static class TotalTopUpUtil
	{
		// Token: 0x0603F78A RID: 259978 RVA: 0x010457FD File Offset: 0x010439FD
		public static void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
		}

		// Token: 0x0603F78B RID: 259979 RVA: 0x010457FF File Offset: 0x010439FF
		public static void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			Singleton<Log>.Instance.Error(ELogModule.ActivityTotalTopUp, ELogAuthor.TZJ, message, pairs);
		}
	}
}
