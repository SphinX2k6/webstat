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
	// Token: 0x02005F3A RID: 24378
	public class MoraleOccupiedSuccessView : UiViewBase
	{
		// Token: 0x0603D3F2 RID: 250866 RVA: 0x00F936EA File Offset: 0x00F918EA
		[NullableContext(1)]
		public MoraleOccupiedSuccessView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D3F3 RID: 250867 RVA: 0x00F936F4 File Offset: 0x00F918F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D3F4 RID: 250868 RVA: 0x00F93760 File Offset: 0x00F91960
		protected override void OnStart()
		{
			this.LevelText = base.GetArtText(0);
			if (this.LevelText != null)
			{
				int moraleIndomitableLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel();
				this.LevelText.SetText(moraleIndomitableLevel.ToString());
			}
		}

		// Token: 0x0603D3F5 RID: 250869 RVA: 0x00F9379F File Offset: 0x00F9199F
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x0603D3F6 RID: 250870 RVA: 0x00F937A1 File Offset: 0x00F919A1
		protected override void OnAfterShow()
		{
			this.DelayClose();
		}

		// Token: 0x0603D3F7 RID: 250871 RVA: 0x00F937A9 File Offset: 0x00F919A9
		protected override void OnBeforeDestroy()
		{
			this.ClearDelayTimer();
		}

		// Token: 0x0603D3F8 RID: 250872 RVA: 0x00F937B1 File Offset: 0x00F919B1
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D3F9 RID: 250873 RVA: 0x00F937CF File Offset: 0x00F919CF
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D3FA RID: 250874 RVA: 0x00F937ED File Offset: 0x00F919ED
		[NullableContext(1)]
		private void OnSequenceNetworkStart(PlotInfo plotInfo)
		{
			this.TryCloseMe();
		}

		// Token: 0x0603D3FB RID: 250875 RVA: 0x00F937F5 File Offset: 0x00F919F5
		private void TryCloseMe()
		{
			if (!base.IsHideOrHiding)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603D3FC RID: 250876 RVA: 0x00F93806 File Offset: 0x00F91A06
		private void DelayClose()
		{
			this.ClearDelayTimer();
			this.DelayTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.DelayTimer = null;
				this.TryCloseMe();
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603D3FD RID: 250877 RVA: 0x00F93837 File Offset: 0x00F91A37
		private void ClearDelayTimer()
		{
			if (this.DelayTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimer);
				this.DelayTimer = null;
			}
		}

		// Token: 0x0402259E RID: 140702
		private const float DELAY_CLOSE_TIME = 2000f;

		// Token: 0x0402259F RID: 140703
		[Nullable(2)]
		private UUIArtText LevelText;

		// Token: 0x040225A0 RID: 140704
		[Nullable(2)]
		private TimerHandle DelayTimer;

		// Token: 0x0200BF61 RID: 48993
		private enum EChildType
		{
			// Token: 0x0403AE85 RID: 241285
			LevelText,
			// Token: 0x0403AE86 RID: 241286
			TitleText
		}
	}
}
