using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055ED RID: 21997
	[NullableContext(1)]
	public interface ISkillInteractMainUiInteract
	{
		// Token: 0x0603809B RID: 229531
		bool ReceiveClickData(ESkillInteractMainUiInteractType type, params object[] data);
	}
}
