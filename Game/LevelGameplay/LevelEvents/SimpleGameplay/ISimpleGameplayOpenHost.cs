using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay
{
	// Token: 0x02006C2E RID: 27694
	[NullableContext(1)]
	public interface ISimpleGameplayOpenHost
	{
		// Token: 0x1700A34F RID: 41807
		// (get) Token: 0x060441DC RID: 279004
		GeneralContext Context { get; }

		// Token: 0x1700A350 RID: 41808
		// (get) Token: 0x060441DD RID: 279005
		[Nullable(new byte[]
		{
			1,
			2
		})]
		Action<string> SetFinishSendSelfEvent { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; }

		// Token: 0x1700A351 RID: 41809
		// (get) Token: 0x060441DE RID: 279006
		[Nullable(new byte[]
		{
			1,
			2
		})]
		Action<string> SetFailSendSelfEvent { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; }

		// Token: 0x1700A352 RID: 41810
		// (get) Token: 0x060441DF RID: 279007
		Action<long> SetCreatureDataId { get; }

		// Token: 0x1700A353 RID: 41811
		// (get) Token: 0x060441E0 RID: 279008
		Action FinishCallback { get; }

		// Token: 0x1700A354 RID: 41812
		// (get) Token: 0x060441E1 RID: 279009
		Action<bool> FinishWithResultCallback { get; }
	}
}
