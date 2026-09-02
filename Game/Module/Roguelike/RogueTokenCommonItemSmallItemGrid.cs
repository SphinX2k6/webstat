using System;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051AF RID: 20911
	internal class RogueTokenCommonItemSmallItemGrid : CommonItemSmallItemGrid
	{
		// Token: 0x06035C3A RID: 220218 RVA: 0x00D8570F File Offset: 0x00D8390F
		protected override void OnExtendToggleClicked()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeGetTokenReward);
		}
	}
}
