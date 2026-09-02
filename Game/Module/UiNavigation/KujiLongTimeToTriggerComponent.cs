using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D14 RID: 19732
	public class KujiLongTimeToTriggerComponent : LongTimeToTriggerComponent
	{
		// Token: 0x0603349C RID: 210076 RVA: 0x00CD64EE File Offset: 0x00CD46EE
		public KujiLongTimeToTriggerComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603349D RID: 210077 RVA: 0x00CD64F7 File Offset: 0x00CD46F7
		protected override void OnInit()
		{
			this.ActivityView = (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PrizeDrawingTearView) as ActivityPrizeDrawingTearView);
		}

		// Token: 0x0603349E RID: 210078 RVA: 0x00CD6513 File Offset: 0x00CD4713
		protected override void OnHandleLongPressRefresh(float percent)
		{
			if (this.ActivityView == null)
			{
				return;
			}
			this.ActivityView.OnGamepadHold(percent);
		}

		// Token: 0x0603349F RID: 210079 RVA: 0x00CD652A File Offset: 0x00CD472A
		protected override void OnPressAction()
		{
			if (this.ActivityView == null)
			{
				return;
			}
			this.ActivityView.OnGamepadPress();
		}

		// Token: 0x060334A0 RID: 210080 RVA: 0x00CD6540 File Offset: 0x00CD4740
		protected override void OnReleaseAction()
		{
			if (this.ActivityView == null)
			{
				return;
			}
			this.ActivityView.OnGamepadRelease();
		}

		// Token: 0x060334A1 RID: 210081 RVA: 0x00CD6558 File Offset: 0x00CD4758
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PrizeDrawingTearView);
			if (viewByName == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			ActivityPrizeDrawingTearView activityPrizeDrawingTearView = viewByName as ActivityPrizeDrawingTearView;
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activityPrizeDrawingTearView.GetGamepadCanPress(), false);
		}

		// Token: 0x0401DC4D RID: 121933
		[Nullable(2)]
		private ActivityPrizeDrawingTearView ActivityView;
	}
}
