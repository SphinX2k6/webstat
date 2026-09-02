using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.LevelListeners
{
	// Token: 0x02006B55 RID: 27477
	public class LevelConditionListenerCheckEntitySelfDirection : LevelListenerBase
	{
		// Token: 0x06043E22 RID: 278050 RVA: 0x0118D967 File Offset: 0x0118BB67
		private void EventHandle()
		{
			TListenerCallbackFunc callback = this.Callback;
			if (callback == null)
			{
				return;
			}
			callback(ClientEventContext.Create(EEventName.OnEntitySelfDirectionUpdate, Array.Empty<object>()), Array.Empty<object>());
		}

		// Token: 0x06043E23 RID: 278051 RVA: 0x0118D990 File Offset: 0x0118BB90
		[NullableContext(1)]
		protected override void OnListen(object listeningInfo, TListenerCallbackFunc callback, [Nullable(2)] GeneralContext context = null, params object[] otherParams)
		{
			EntityHandle entityHandle = LevelGamePlayUtils.GetEntityHandle(null, context);
			WorldEntity worldEntity = (entityHandle != null) ? entityHandle.Entity : null;
			if (entityHandle == null || !entityHandle.Valid || (worldEntity == null || !worldEntity.Valid))
			{
				return;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(worldEntity, EEventName.OnEntitySelfDirectionUpdate, new Action(this.EventHandle)))
			{
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey(this, worldEntity, EEventName.OnEntitySelfDirectionUpdate, new Action(this.EventHandle));
			}
		}

		// Token: 0x06043E24 RID: 278052 RVA: 0x0118DA11 File Offset: 0x0118BC11
		protected override void OnUnListen()
		{
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
		}
	}
}
