using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF0 RID: 28400
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabFloatCountDownView : UiTickViewBase
	{
		// Token: 0x06044D5D RID: 281949 RVA: 0x011E93F6 File Offset: 0x011E75F6
		public DollGrabFloatCountDownView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D5E RID: 281950 RVA: 0x011E9420 File Offset: 0x011E7620
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044D5F RID: 281951 RVA: 0x011E948C File Offset: 0x011E768C
		protected override void OnBeforeShow()
		{
			this.CurrentTime = ControllerBase<DollGrabMachineController>.Instance.RemainingTime / 1000f;
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorOffsetY(this.RootItem.GetAnchorOffsetY() + 50f);
			}
			Singleton<EventSystem>.Instance.Add<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnRemainingTimeAdd));
			Singleton<EventSystem>.Instance.Add(EEventName.OnDollGrabMachinePause, new Action(this.OnDollGrabMachinePause));
			Singleton<EventSystem>.Instance.Add(EEventName.OnDollGrabMachineResume, new Action(this.OnDollGrabMachineResume));
		}

		// Token: 0x06044D60 RID: 281952 RVA: 0x011E9528 File Offset: 0x011E7728
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.OnDollGrabMachineRemainingTimeAdd, new Action<float>(this.OnRemainingTimeAdd));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachinePause, new Action(this.OnDollGrabMachinePause));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnDollGrabMachineResume, new Action(this.OnDollGrabMachineResume));
		}

		// Token: 0x06044D61 RID: 281953 RVA: 0x011E958C File Offset: 0x011E778C
		protected override void OnTick(float delta)
		{
			if (Singleton<TickSystem>.Instance.IsPaused || this.IsPaused)
			{
				return;
			}
			this.CurrentTime -= delta * Singleton<Time>.Instance.TimeDilation / 1000f;
			this.CurrentTime = Math.Max(this.CurrentTime, 0f);
			this.UpdateCountDown();
			this.SetExtraText(this.MinuteText, this.SecondText, this.Millisecond);
		}

		// Token: 0x06044D62 RID: 281954 RVA: 0x011E9604 File Offset: 0x011E7804
		private void UpdateCountDown()
		{
			float currentTime = this.CurrentTime;
			double num = Math.Floor((double)currentTime % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num);
			this.MinuteText = defaultInterpolatedStringHandler.ToStringAndClear();
			double num2 = Math.Floor((double)currentTime % Singleton<TimeUtil>.Instance.Minute);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num2 < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num2);
			this.SecondText = defaultInterpolatedStringHandler.ToStringAndClear();
			double num3 = Math.Floor(((double)currentTime - Math.Floor((double)currentTime)) * 100.0);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num3 < 10.0) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
			this.Millisecond = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06044D63 RID: 281955 RVA: 0x011E971C File Offset: 0x011E791C
		protected void SetExtraText(string minute, string second, string millionSecond)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(minute);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(second);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(millionSecond);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06044D64 RID: 281956 RVA: 0x011E977B File Offset: 0x011E797B
		private void OnRemainingTimeAdd(float num)
		{
			this.CurrentTime = ControllerBase<DollGrabMachineController>.Instance.RemainingTime / 1000f;
		}

		// Token: 0x06044D65 RID: 281957 RVA: 0x011E9793 File Offset: 0x011E7993
		private void OnDollGrabMachinePause()
		{
			this.IsPaused = true;
		}

		// Token: 0x06044D66 RID: 281958 RVA: 0x011E979C File Offset: 0x011E799C
		private void OnDollGrabMachineResume()
		{
			this.IsPaused = false;
		}

		// Token: 0x04026587 RID: 157063
		private float CurrentTime;

		// Token: 0x04026588 RID: 157064
		private string Millisecond = "";

		// Token: 0x04026589 RID: 157065
		private string MinuteText = "";

		// Token: 0x0402658A RID: 157066
		private string SecondText = "";

		// Token: 0x0402658B RID: 157067
		private bool IsPaused;
	}
}
