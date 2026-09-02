using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066C2 RID: 26306
	public class MotorParkourTimerView : UiTickViewBase
	{
		// Token: 0x06041AE8 RID: 269032 RVA: 0x010D7FA2 File Offset: 0x010D61A2
		[NullableContext(1)]
		public MotorParkourTimerView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041AE9 RID: 269033 RVA: 0x010D7FAC File Offset: 0x010D61AC
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

		// Token: 0x06041AEA RID: 269034 RVA: 0x010D7FF4 File Offset: 0x010D61F4
		protected override void OnStart()
		{
			this.StartFlowTime = (long)this.OpenParam;
		}

		// Token: 0x06041AEB RID: 269035 RVA: 0x010D8008 File Offset: 0x010D6208
		protected override void OnTick(float delta)
		{
			if (this.StartFlowTime == 0L)
			{
				return;
			}
			double num = (Singleton<TimeUtil>.Instance.GetServerStopTimeStamp() - (double)this.StartFlowTime) * Singleton<TimeUtil>.Instance.Millisecond;
			if (Singleton<Time>.Instance.FlowTimeDilation == 0f)
			{
				return;
			}
			int num2 = (int)Math.Floor(num % Singleton<TimeUtil>.Instance.Hour / Singleton<TimeUtil>.Instance.Minute);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num2 < 10) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
			string value = defaultInterpolatedStringHandler.ToStringAndClear();
			int num3 = (int)Math.Floor(num % Singleton<TimeUtil>.Instance.Minute);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num3 < 10) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
			string value2 = defaultInterpolatedStringHandler.ToStringAndClear();
			int num4 = (int)Math.Floor((num - Math.Floor(num)) * 100.0);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted((num4 < 10) ? "0" : "");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
			string value3 = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral(":");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x04024A8D RID: 150157
		private const int ONE_HUNDRED = 100;

		// Token: 0x04024A8E RID: 150158
		private long StartFlowTime;

		// Token: 0x0200C6F3 RID: 50931
		private class EComponent
		{
			// Token: 0x0403D40F RID: 250895
			public const int TextTime = 0;
		}
	}
}
