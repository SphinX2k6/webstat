using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F37 RID: 24375
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleIndomitableLevelView : UiViewBase
	{
		// Token: 0x0603D3CC RID: 250828 RVA: 0x00F92E80 File Offset: 0x00F91080
		[NullableContext(1)]
		public MoraleIndomitableLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D3CD RID: 250829 RVA: 0x00F92E8C File Offset: 0x00F9108C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D3CE RID: 250830 RVA: 0x00F92ED4 File Offset: 0x00F910D4
		protected override void OnStart()
		{
			this.LevelText = base.GetArtText(0);
			if (this.LevelText != null)
			{
				int moraleIndomitableLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel();
				this.LevelText.SetText(moraleIndomitableLevel.ToString());
			}
		}

		// Token: 0x0603D3CF RID: 250831 RVA: 0x00F92F13 File Offset: 0x00F91113
		protected override void OnBeforeShow()
		{
			this.DelayRefresh();
		}

		// Token: 0x0603D3D0 RID: 250832 RVA: 0x00F92F1B File Offset: 0x00F9111B
		protected override void OnAfterShow()
		{
			this.DelayClose();
		}

		// Token: 0x0603D3D1 RID: 250833 RVA: 0x00F92F23 File Offset: 0x00F91123
		protected override void OnBeforeDestroy()
		{
			this.ClearDelayTimer();
			this.ClearRefreshTimer();
		}

		// Token: 0x0603D3D2 RID: 250834 RVA: 0x00F92F31 File Offset: 0x00F91131
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D3D3 RID: 250835 RVA: 0x00F92F4F File Offset: 0x00F9114F
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D3D4 RID: 250836 RVA: 0x00F92F6D File Offset: 0x00F9116D
		[NullableContext(1)]
		private void OnSequenceNetworkStart(PlotInfo plotInfo)
		{
			this.TryCloseMe();
		}

		// Token: 0x0603D3D5 RID: 250837 RVA: 0x00F92F75 File Offset: 0x00F91175
		private void TryCloseMe()
		{
			if (!base.IsHideOrHiding)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603D3D6 RID: 250838 RVA: 0x00F92F86 File Offset: 0x00F91186
		private void DelayClose()
		{
			this.ClearDelayTimer();
			this.DelayTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.DelayTimer = null;
				this.TryCloseMe();
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603D3D7 RID: 250839 RVA: 0x00F92FB7 File Offset: 0x00F911B7
		private void DelayRefresh()
		{
			this.ClearRefreshTimer();
			this.RefreshTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RefreshTimer = null;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMoralePlayIndomitableLevelAnim);
			}, 1500f, null, null, true, 1f);
		}

		// Token: 0x0603D3D8 RID: 250840 RVA: 0x00F92FE8 File Offset: 0x00F911E8
		private void ClearDelayTimer()
		{
			if (this.DelayTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimer);
				this.DelayTimer = null;
			}
		}

		// Token: 0x0603D3D9 RID: 250841 RVA: 0x00F9300A File Offset: 0x00F9120A
		private void ClearRefreshTimer()
		{
			if (this.RefreshTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x04022581 RID: 140673
		private const float DELAY_CLOSE_TIME = 2000f;

		// Token: 0x04022582 RID: 140674
		private const float DELAY_EVENT_TIME = 1500f;

		// Token: 0x04022583 RID: 140675
		private UUIArtText LevelText;

		// Token: 0x04022584 RID: 140676
		private TimerHandle DelayTimer;

		// Token: 0x04022585 RID: 140677
		private TimerHandle RefreshTimer;

		// Token: 0x0200BF5B RID: 48987
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AE6F RID: 241263
			LevelText
		}
	}
}
