using System;
using System.Runtime.CompilerServices;

// Token: 0x0200156D RID: 5485
[NullableContext(1)]
[Nullable(0)]
public static class RoleGiftUtil
{
	// Token: 0x060099FE RID: 39422 RVA: 0x002851AF File Offset: 0x002833AF
	public static void Debug(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x060099FF RID: 39423 RVA: 0x002851B1 File Offset: 0x002833B1
	public static void Error(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
		Singleton<Log>.Instance.Error(ELogModule.Activity, ELogAuthor.TZJ, "[RoleGift] " + message, pairs);
	}
}
