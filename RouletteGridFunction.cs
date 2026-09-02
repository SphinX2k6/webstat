using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002938 RID: 10552
public class RouletteGridFunction : RouletteGridBase
{
	// Token: 0x06014F28 RID: 85800 RVA: 0x005CC0A4 File Offset: 0x005CA2A4
	protected override UniTask Init()
	{
		RouletteGridFunction.<Init>d__0 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<RouletteGridFunction.<Init>d__0>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06014F29 RID: 85801 RVA: 0x005CC0E7 File Offset: 0x005CA2E7
	protected override void OnSelect(bool bSelect)
	{
		if (!bSelect)
		{
			return;
		}
		if (!base.IsDataValid() || this.Data == null)
		{
			return;
		}
		ControllerBase<RouletteController>.Instance.FunctionOpenRequest(this.Data.Id);
	}
}
