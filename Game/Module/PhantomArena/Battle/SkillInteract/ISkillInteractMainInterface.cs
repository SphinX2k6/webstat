using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055EC RID: 21996
	[NullableContext(1)]
	public interface ISkillInteractMainInterface
	{
		// Token: 0x06038097 RID: 229527
		UniTask StartSkillInteract();

		// Token: 0x06038098 RID: 229528
		void CancelSkillInteract();

		// Token: 0x06038099 RID: 229529
		ISkillTriggerInfo GetData();

		// Token: 0x0603809A RID: 229530
		void FinishSkillInteract();
	}
}
