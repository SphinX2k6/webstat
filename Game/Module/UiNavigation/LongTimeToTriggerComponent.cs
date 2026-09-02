using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D18 RID: 19736
	public class LongTimeToTriggerComponent : HotKeyComponent
	{
		// Token: 0x060334B2 RID: 210098 RVA: 0x00CD67B1 File Offset: 0x00CD49B1
		public LongTimeToTriggerComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334B3 RID: 210099 RVA: 0x00CD67BA File Offset: 0x00CD49BA
		protected override void OnPress(HotKeyMap config)
		{
			this.DeactivateLongPress();
			this.TryActivateLongPress();
			this.OnPressAction();
		}

		// Token: 0x060334B4 RID: 210100 RVA: 0x00CD67D0 File Offset: 0x00CD49D0
		protected override void OnRelease(HotKeyMap config)
		{
			if (this.CurPressTime >= (float)(config.LongPressTime + config.ReleaseFailureTime))
			{
				this.ClickButton(config.BindButtonTag);
			}
			this.SetLongPressState(0f);
			this.SetCurComponentAlpha(0f);
			this.DeactivateLongPress();
			this.OnReleaseAction();
			this.IsLockActionName = false;
		}

		// Token: 0x060334B5 RID: 210101 RVA: 0x00CD6830 File Offset: 0x00CD4A30
		[NullableContext(1)]
		protected virtual void ClickButton(string tag)
		{
			if (tag == "tag1")
			{
				ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(tag);
		}

		// Token: 0x060334B6 RID: 210102 RVA: 0x00CD6855 File Offset: 0x00CD4A55
		protected override void OnUnRegisterMe()
		{
			this.DeactivateLongPress();
		}

		// Token: 0x060334B7 RID: 210103 RVA: 0x00CD685D File Offset: 0x00CD4A5D
		private void DeactivateLongPress()
		{
			if (this.LongPressRefreshTimerId != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.LongPressRefreshTimerId);
				this.LongPressRefreshTimerId = null;
			}
			this.CurPressTime = 0f;
		}

		// Token: 0x060334B8 RID: 210104 RVA: 0x00CD688A File Offset: 0x00CD4A8A
		private void TryActivateLongPress()
		{
			this.LongPressRefreshTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnLongPressRefreshCallback), 20f, 1f, null, null, true);
		}

		// Token: 0x060334B9 RID: 210105 RVA: 0x00CD68B8 File Offset: 0x00CD4AB8
		private void OnLongPressRefreshCallback(float _)
		{
			this.CurPressTime += 20f;
			HotKeyMap? hotKeyConfig = base.GetHotKeyConfig();
			if (hotKeyConfig == null)
			{
				return;
			}
			float num = 0f;
			if (this.CurPressTime > (float)hotKeyConfig.Value.ReleaseFailureTime)
			{
				this.HandleLockActionName();
				int longPressTime = hotKeyConfig.Value.LongPressTime;
				num = (this.CurPressTime - (float)hotKeyConfig.Value.ReleaseFailureTime) / (float)longPressTime;
			}
			if (num >= 1f)
			{
				this.OnHandleLongPressRefresh(num);
				base.ReleaseWithoutCheck();
				return;
			}
			this.SetLongPressState(num);
			this.SetCurComponentAlpha(num > 0f);
		}

		// Token: 0x060334BA RID: 210106 RVA: 0x00CD6963 File Offset: 0x00CD4B63
		private void SetLongPressState(float percent)
		{
			this.CurComponent.SetLongPressState(percent);
			this.OnHandleLongPressRefresh(percent);
		}

		// Token: 0x060334BB RID: 210107 RVA: 0x00CD6978 File Offset: 0x00CD4B78
		private void SetCurComponentAlpha(float alpha)
		{
			HotKeyMap? hotKeyConfig = base.GetHotKeyConfig();
			if (hotKeyConfig == null)
			{
				return;
			}
			if (hotKeyConfig.Value.ApplicableType == 6)
			{
				this.CurComponent.SetLongPressItemAlpha(alpha);
			}
		}

		// Token: 0x060334BC RID: 210108 RVA: 0x00CD69B4 File Offset: 0x00CD4BB4
		private void HandleLockActionName()
		{
			if (this.IsLockActionName)
			{
				return;
			}
			this.IsLockActionName = true;
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			if (instance == null)
			{
				return;
			}
			foreach (HotKeyComponent hotKeyComponent in instance.GetActionHotKeyComponentSet(base.GetActionName()))
			{
				hotKeyComponent.ResetPressState();
			}
		}

		// Token: 0x060334BD RID: 210109 RVA: 0x00CD6A24 File Offset: 0x00CD4C24
		protected virtual void OnPressAction()
		{
		}

		// Token: 0x060334BE RID: 210110 RVA: 0x00CD6A26 File Offset: 0x00CD4C26
		protected virtual void OnReleaseAction()
		{
		}

		// Token: 0x060334BF RID: 210111 RVA: 0x00CD6A28 File Offset: 0x00CD4C28
		protected virtual void OnHandleLongPressRefresh(float percent)
		{
		}

		// Token: 0x0401DC50 RID: 121936
		private float CurPressTime;

		// Token: 0x0401DC51 RID: 121937
		[Nullable(2)]
		private TimerHandle LongPressRefreshTimerId;

		// Token: 0x0401DC52 RID: 121938
		private bool IsLockActionName;
	}
}
