using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BC4 RID: 27588
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventGuestAnimation : LevelEventBase
	{
		// Token: 0x06044056 RID: 278614 RVA: 0x011A344B File Offset: 0x011A164B
		public LevelEventGuestAnimation(int id) : base(id)
		{
		}

		// Token: 0x06044057 RID: 278615 RVA: 0x011A3454 File Offset: 0x011A1654
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			GuestOperateUiAnimation guestOperateUiAnimation = inParams as GuestOperateUiAnimation;
			EGuestOperateUiAnimation type = guestOperateUiAnimation.UiAnimationConfig.Type;
			if (type == EGuestOperateUiAnimation.Play)
			{
				this.PlayUiEffect(guestOperateUiAnimation.UiAnimationConfig as IPlayGuestUiAnimation);
				return;
			}
			if (type != EGuestOperateUiAnimation.Stop)
			{
				return;
			}
			this.StopUiEffect(guestOperateUiAnimation.UiAnimationConfig as IStopGuestUiAnimation);
		}

		// Token: 0x06044058 RID: 278616 RVA: 0x011A349F File Offset: 0x011A169F
		private void PlayUiEffect(IPlayGuestUiAnimation config)
		{
			if (config.PlayGuestUiAnimation.Type == EGuestUiAnimationType.GuestCartethyia)
			{
				ModelBase<BattleUiModel>.Instance.GuestEffect = true;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ShowGuestEffect, true);
			}
		}

		// Token: 0x06044059 RID: 278617 RVA: 0x011A34CA File Offset: 0x011A16CA
		private void StopUiEffect(IStopGuestUiAnimation config)
		{
			if (config.StopGuestUiAnimation.Type == EGuestUiAnimationType.GuestCartethyia)
			{
				ModelBase<BattleUiModel>.Instance.GuestEffect = false;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ShowGuestEffect, false);
			}
		}
	}
}
