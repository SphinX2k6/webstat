using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

// Token: 0x02001C1B RID: 7195
[NullableContext(1)]
[Nullable(0)]
public struct FloroRanchPhaseTargetViewParam
{
	// Token: 0x040063EC RID: 25580
	public FloroRanchStageStart StageStartData;

	// Token: 0x040063ED RID: 25581
	public Func<UniTask> CloseCallback;
}
