using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F96 RID: 24470
	public class AlterTime : UiPanelBase
	{
		// Token: 0x0603D705 RID: 251653 RVA: 0x00FA24D0 File Offset: 0x00FA06D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D706 RID: 251654 RVA: 0x00FA2518 File Offset: 0x00FA0718
		protected override void OnBeforeDestroy()
		{
			this.TimeText = null;
		}

		// Token: 0x0603D707 RID: 251655 RVA: 0x00FA2521 File Offset: 0x00FA0721
		protected override void OnStart()
		{
			this.TimeText = base.GetText(0);
			base.SetUiActive(false);
		}

		// Token: 0x0603D708 RID: 251656 RVA: 0x00FA2538 File Offset: 0x00FA0738
		public void SetCountdownText(double time)
		{
			int value = (int)Math.Floor(time / (double)Singleton<TimeUtil>.Instance.InverseMillisecond);
			string value2 = (time % (double)Singleton<TimeUtil>.Instance.InverseMillisecond).ToString(CultureInfo.InvariantCulture).Substring(0, 2);
			UUIText timeText = this.TimeText;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			timeText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0402286C RID: 141420
		[Nullable(2)]
		private UUIText TimeText;

		// Token: 0x0200BF84 RID: 49028
		private enum EComponents
		{
			// Token: 0x0403AF30 RID: 241456
			UITimeText
		}
	}
}
