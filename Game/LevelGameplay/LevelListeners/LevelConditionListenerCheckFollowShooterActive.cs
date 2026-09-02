using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelListeners
{
	// Token: 0x02006B56 RID: 27478
	public class LevelConditionListenerCheckFollowShooterActive : LevelListenerBase
	{
		// Token: 0x06043E26 RID: 278054 RVA: 0x0118DA27 File Offset: 0x0118BC27
		private void FollowerEnableChangeEventHandle(bool isEnable)
		{
			TListenerCallbackFunc callback = this.Callback;
			if (callback == null)
			{
				return;
			}
			callback(ClientEventContext.Create(EEventName.OnPlayerFollowerEnableChange, new object[]
			{
				isEnable
			}), Array.Empty<object>());
		}

		// Token: 0x06043E27 RID: 278055 RVA: 0x0118DA57 File Offset: 0x0118BC57
		[NullableContext(1)]
		protected override void OnListen(object listeningInfo, TListenerCallbackFunc callback, [Nullable(2)] GeneralContext context = null, params object[] otherParams)
		{
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.FollowerEnableChangeEventHandle)))
			{
				Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.FollowerEnableChangeEventHandle));
			}
		}

		// Token: 0x06043E28 RID: 278056 RVA: 0x0118DA94 File Offset: 0x0118BC94
		protected override void OnUnListen()
		{
			if (new Action<bool>(this.FollowerEnableChangeEventHandle) != null && Singleton<EventSystem>.Instance.Has(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.FollowerEnableChangeEventHandle)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerFollowerEnableChange, new Action<bool>(this.FollowerEnableChangeEventHandle));
			}
		}
	}
}
