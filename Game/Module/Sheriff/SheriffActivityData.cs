using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FA5 RID: 20389
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffActivityData : ActivityBaseData
	{
		// Token: 0x060349ED RID: 215533 RVA: 0x00D3352A File Offset: 0x00D3172A
		protected override void OnInit(ActivityData data)
		{
		}

		// Token: 0x060349EE RID: 215534 RVA: 0x00D3352C File Offset: 0x00D3172C
		protected override void PhraseEx(ActivityData data)
		{
			if (base.GetIfFirstOpen() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 101, 0, 0) == 0)
			{
				ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 101, 0, 0, 1);
			}
		}

		// Token: 0x060349EF RID: 215535 RVA: 0x00D33562 File Offset: 0x00D31762
		public override ERedDotName? GetExternalButtonRedPointName()
		{
			return new ERedDotName?(ERedDotName.CommonActivityPage);
		}

		// Token: 0x060349F0 RID: 215536 RVA: 0x00D3356B File Offset: 0x00D3176B
		public override int GetExternalButtonRedPointId()
		{
			return base.Id;
		}

		// Token: 0x060349F1 RID: 215537 RVA: 0x00D33573 File Offset: 0x00D31773
		public override bool GetExDataRedPointShowState()
		{
			return base.IsUnLock() && (ModelBase<SheriffModel>.Instance.CheckShopRedDot() || this.IsUnlockRedDotActive());
		}

		// Token: 0x060349F2 RID: 215538 RVA: 0x00D33593 File Offset: 0x00D31793
		public bool GetTerminalRedPointShowState()
		{
			return this.CheckIfInShowTime() && !base.IsHiddenByConfig() && (this.IsTerminalFirstOpenRedDotActive() || this.GetExDataRedPointShowState());
		}

		// Token: 0x060349F3 RID: 215539 RVA: 0x00D335B9 File Offset: 0x00D317B9
		public bool IsTerminalFirstOpenRedDotActive()
		{
			return base.IsUnLock() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 101, 0, 0) == 1;
		}

		// Token: 0x060349F4 RID: 215540 RVA: 0x00D335DD File Offset: 0x00D317DD
		public bool IsUnlockRedDotActive()
		{
			return base.IsUnLock() && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0;
		}

		// Token: 0x060349F5 RID: 215541 RVA: 0x00D33601 File Offset: 0x00D31801
		public void ReadTerminalFirstOpenRedDot()
		{
			if (!this.MarkTerminalFirstOpenRedDotRead())
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x060349F6 RID: 215542 RVA: 0x00D33622 File Offset: 0x00D31822
		public void ReadRedDot()
		{
			if (!base.IsUnLock())
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
			this.MarkTerminalFirstOpenRedDotRead();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x060349F7 RID: 215543 RVA: 0x00D3365F File Offset: 0x00D3185F
		private bool MarkTerminalFirstOpenRedDotRead()
		{
			if (!this.IsTerminalFirstOpenRedDotActive())
			{
				return false;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 101, 0, 0, 2);
			return true;
		}

		// Token: 0x0401E55E RID: 124254
		private const int SHERIFF_UNLOCK_RED_DOT_CACHE_KEY = 100;

		// Token: 0x0401E55F RID: 124255
		private const int SHERIFF_TERMINAL_FIRST_OPEN_RED_DOT_CACHE_KEY = 101;
	}
}
