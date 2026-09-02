using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BDE RID: 7134
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchBuffComponent)]
public class FloroRanchBuffComponent : FloroRanchEntityComponentBase
{
	// Token: 0x0600CF88 RID: 53128 RVA: 0x00371FEC File Offset: 0x003701EC
	public UniTask ShowAddBuff(int buffId)
	{
		FloroRanchBuffComponent.<ShowAddBuff>d__0 <ShowAddBuff>d__;
		<ShowAddBuff>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowAddBuff>d__.<>1__state = -1;
		<ShowAddBuff>d__.<>t__builder.Start<FloroRanchBuffComponent.<ShowAddBuff>d__0>(ref <ShowAddBuff>d__);
		return <ShowAddBuff>d__.<>t__builder.Task;
	}
}
