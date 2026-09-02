using System;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.World.StepSequence
{
	// Token: 0x020046D0 RID: 18128
	public interface ISequenceAbortSignal
	{
		// Token: 0x17008119 RID: 33049
		// (get) Token: 0x0602F266 RID: 193126
		bool Aborted { get; }

		// Token: 0x1700811A RID: 33050
		// (get) Token: 0x0602F267 RID: 193127
		UniTask<bool>? Promise { get; }

		// Token: 0x0602F268 RID: 193128
		void Abort();
	}
}
