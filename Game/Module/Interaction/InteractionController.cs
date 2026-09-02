using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Interaction
{
	// Token: 0x02005B93 RID: 23443
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InteractionController : UiControllerBase<InteractionController>
	{
		// Token: 0x0603B489 RID: 242825 RVA: 0x00F028E1 File Offset: 0x00F00AE1
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LocalStorageInitPlayerId, new Action(this.OnLocalStorageInitPlayerId));
		}

		// Token: 0x0603B48A RID: 242826 RVA: 0x00F028FF File Offset: 0x00F00AFF
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LocalStorageInitPlayerId, new Action(this.OnLocalStorageInitPlayerId));
		}

		// Token: 0x0603B48B RID: 242827 RVA: 0x00F0291D File Offset: 0x00F00B1D
		private void OnLocalStorageInitPlayerId()
		{
			InteractionModel instance = ModelBase<InteractionModel>.Instance;
			instance.LoadInteractGuideData();
			instance.LoadAutoInteractionGuideAppearCount();
		}
	}
}
