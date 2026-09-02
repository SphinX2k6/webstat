using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D17 RID: 19735
	public class LongPressWithProgressComponent : HotKeyComponent
	{
		// Token: 0x060334A9 RID: 210089 RVA: 0x00CD6685 File Offset: 0x00CD4885
		public LongPressWithProgressComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334AA RID: 210090 RVA: 0x00CD668E File Offset: 0x00CD488E
		private void TryActivateRefreshTimer()
		{
			if (this.RefreshTimerId != null)
			{
				return;
			}
			this.RefreshTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnRefreshCallback), 20f, 1f, null, null, true);
		}

		// Token: 0x060334AB RID: 210091 RVA: 0x00CD66C4 File Offset: 0x00CD48C4
		private void OnRefreshCallback(float deltaTime)
		{
			float num = this.OnGetProgress();
			if (this.IsPress)
			{
				if (num >= 1f)
				{
					HotKeyCombineComponent curComponent = this.CurComponent;
					if (curComponent != null)
					{
						curComponent.SetLongPressState(0f);
					}
					base.ReleaseWithoutCheck();
					this.DeactivateRefreshTimer();
					return;
				}
			}
			else if (num <= 0f)
			{
				HotKeyCombineComponent curComponent2 = this.CurComponent;
				if (curComponent2 != null)
				{
					curComponent2.SetLongPressState(0f);
				}
				this.DeactivateRefreshTimer();
				return;
			}
			HotKeyCombineComponent curComponent3 = this.CurComponent;
			if (curComponent3 == null)
			{
				return;
			}
			curComponent3.SetLongPressState(num);
		}

		// Token: 0x060334AC RID: 210092 RVA: 0x00CD6741 File Offset: 0x00CD4941
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointDown(config.BindButtonTag, config.Id, null);
			this.TryActivateRefreshTimer();
		}

		// Token: 0x060334AD RID: 210093 RVA: 0x00CD6762 File Offset: 0x00CD4962
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointUp(config.BindButtonTag, config.Id, null);
		}

		// Token: 0x060334AE RID: 210094 RVA: 0x00CD677D File Offset: 0x00CD497D
		private void DeactivateRefreshTimer()
		{
			if (this.RefreshTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimerId);
				this.RefreshTimerId = null;
			}
		}

		// Token: 0x060334AF RID: 210095 RVA: 0x00CD679F File Offset: 0x00CD499F
		protected override void OnClear()
		{
			this.DeactivateRefreshTimer();
		}

		// Token: 0x060334B0 RID: 210096 RVA: 0x00CD67A7 File Offset: 0x00CD49A7
		protected virtual float OnGetProgress()
		{
			return 0f;
		}

		// Token: 0x060334B1 RID: 210097 RVA: 0x00CD67AE File Offset: 0x00CD49AE
		protected override bool GetIsLongPress()
		{
			return true;
		}

		// Token: 0x0401DC4F RID: 121935
		[Nullable(2)]
		private TimerHandle RefreshTimerId;
	}
}
