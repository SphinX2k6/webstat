using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.View.CountDown
{
	// Token: 0x02005CD1 RID: 23761
	public class SimpleLogicTreeCountDownView : UiViewBase
	{
		// Token: 0x0603BE9C RID: 245404 RVA: 0x00F2F184 File Offset: 0x00F2D384
		[NullableContext(1)]
		public SimpleLogicTreeCountDownView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE9D RID: 245405 RVA: 0x00F2F190 File Offset: 0x00F2D390
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

		// Token: 0x0603BE9E RID: 245406 RVA: 0x00F2F1FC File Offset: 0x00F2D3FC
		protected override void OnStart()
		{
			SimpleLogicTreeCountDownViewParam simpleLogicTreeCountDownViewParam = this.OpenParam as SimpleLogicTreeCountDownViewParam;
			if (simpleLogicTreeCountDownViewParam != null)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetText(simpleLogicTreeCountDownViewParam.Title, true);
				}
			}
			Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
		}

		// Token: 0x0603BE9F RID: 245407 RVA: 0x00F2F24D File Offset: 0x00F2D44D
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
		}

		// Token: 0x0603BEA0 RID: 245408 RVA: 0x00F2F26C File Offset: 0x00F2D46C
		private void HandleCountDownEnd()
		{
			ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = true;
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, delegate(bool success)
			{
				if (success)
				{
					ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = false;
				}
			});
		}

		// Token: 0x0603BEA1 RID: 245409 RVA: 0x00F2F2B8 File Offset: 0x00F2D4B8
		private void OnCountDownChanged(double remainTime, double timerEndTime)
		{
			UUIText text = base.GetText(0);
			if (remainTime <= 0.0)
			{
				this.HandleCountDownEnd();
				return;
			}
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5(remainTime);
			if (text != null)
			{
				text.SetText(remainTimeDataFormat, true);
			}
		}

		// Token: 0x0200BD51 RID: 48465
		public static class ESimpleLogicTreeCountDownView
		{
			// Token: 0x0403A54D RID: 238925
			public const int TxtCountDown = 0;

			// Token: 0x0403A54E RID: 238926
			public const int TxtTitle = 1;
		}
	}
}
