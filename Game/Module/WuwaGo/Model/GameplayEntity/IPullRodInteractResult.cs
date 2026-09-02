using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AEB RID: 19179
	[NullableContext(2)]
	public interface IPullRodInteractResult
	{
		// Token: 0x1700855E RID: 34142
		// (get) Token: 0x06032014 RID: 204820
		// (set) Token: 0x06032015 RID: 204821
		EGameplayEntityState PreviousState { get; set; }

		// Token: 0x1700855F RID: 34143
		// (get) Token: 0x06032016 RID: 204822
		// (set) Token: 0x06032017 RID: 204823
		EGameplayEntityState CurrentState { get; set; }

		// Token: 0x17008560 RID: 34144
		// (get) Token: 0x06032018 RID: 204824
		// (set) Token: 0x06032019 RID: 204825
		IWuWaGoInteractStateAction StateAction { get; set; }
	}
}
