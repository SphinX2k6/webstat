using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelListeners.Capability
{
	// Token: 0x02006B61 RID: 27489
	public class LevelConditionListenerCheckIsInDragActorPlay : LevelListenerBase
	{
		// Token: 0x06043E71 RID: 278129 RVA: 0x0118F957 File Offset: 0x0118DB57
		private void OnDragActorPlayActivationChanged(bool active)
		{
			TListenerCallbackFunc callback = this.Callback;
			if (callback == null)
			{
				return;
			}
			callback(null, Array.Empty<object>());
		}

		// Token: 0x06043E72 RID: 278130 RVA: 0x0118F96F File Offset: 0x0118DB6F
		[NullableContext(1)]
		protected override void OnListen(object listeningInfo, TListenerCallbackFunc callback, [Nullable(2)] GeneralContext context = null, params object[] otherParams)
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.DragActorPlayActivationChanged, new Action<bool>(this.OnDragActorPlayActivationChanged));
		}

		// Token: 0x06043E73 RID: 278131 RVA: 0x0118F98D File Offset: 0x0118DB8D
		protected override void OnUnListen()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.DragActorPlayActivationChanged, new Action<bool>(this.OnDragActorPlayActivationChanged));
		}
	}
}
