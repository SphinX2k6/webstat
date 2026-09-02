using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D68 RID: 3432
internal class TsAnimNotifyStateQtaParam
{
	// Token: 0x06004A0A RID: 18954 RVA: 0x000A0C89 File Offset: 0x0009EE89
	public TsAnimNotifyStateQtaParam(int qtaHandleId)
	{
		this.QtaHandleId = qtaHandleId;
	}

	// Token: 0x06004A0B RID: 18955 RVA: 0x000A0C98 File Offset: 0x0009EE98
	[NullableContext(1)]
	public static string GetKey(int entityId, int notifyId)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
		defaultInterpolatedStringHandler.AppendLiteral("$");
		defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
		defaultInterpolatedStringHandler.AppendLiteral("_$");
		defaultInterpolatedStringHandler.AppendFormatted<int>(notifyId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x040014F1 RID: 5361
	public int QtaHandleId;
}
