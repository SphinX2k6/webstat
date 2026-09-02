using System;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004AFC RID: 19196
	public interface IAttackSession
	{
		// Token: 0x17008573 RID: 34163
		// (get) Token: 0x0603210C RID: 205068
		UniTask HitOrFinished { get; }

		// Token: 0x17008574 RID: 34164
		// (get) Token: 0x0603210D RID: 205069
		UniTask Finished { get; }
	}
}
