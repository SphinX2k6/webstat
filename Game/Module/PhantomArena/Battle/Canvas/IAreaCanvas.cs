using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Canvas
{
	// Token: 0x0200562A RID: 22058
	[NullableContext(1)]
	public interface IAreaCanvas
	{
		// Token: 0x06038371 RID: 230257
		bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo);

		// Token: 0x06038372 RID: 230258
		void HandleSortOrder();

		// Token: 0x06038373 RID: 230259
		void CancelSortOrder();

		// Token: 0x06038374 RID: 230260
		[NullableContext(2)]
		void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract);
	}
}
