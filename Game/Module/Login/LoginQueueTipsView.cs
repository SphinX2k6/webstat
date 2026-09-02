using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Login
{
	// Token: 0x02005A0A RID: 23050
	public class LoginQueueTipsView : UiTickViewBase
	{
		// Token: 0x0603A5FA RID: 239098 RVA: 0x00ECD019 File Offset: 0x00ECB219
		[NullableContext(1)]
		public LoginQueueTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A5FB RID: 239099 RVA: 0x00ECD024 File Offset: 0x00ECB224
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.QuitButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A5FC RID: 239100 RVA: 0x00ECD10C File Offset: 0x00ECB30C
		private void QuitButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603A5FD RID: 239101 RVA: 0x00ECD115 File Offset: 0x00ECB315
		protected override void OnBeforeDestroy()
		{
			if (ModelBase<LoginModel>.Instance.HasAutoLoginPromise())
			{
				ModelBase<LoginModel>.Instance.FinishAutoLoginPromise(false);
			}
		}

		// Token: 0x0603A5FE RID: 239102 RVA: 0x00ECD130 File Offset: 0x00ECB330
		protected override void OnStart()
		{
			this.LoginQueueConfig = (this.OpenParam as LoginQueueConfig);
			LoginQueueConfig loginQueueConfig = this.LoginQueueConfig;
			int? num = (loginQueueConfig != null) ? new int?(loginQueueConfig.ClientWaitingMode) : null;
			if (num != null)
			{
				int valueOrDefault = num.GetValueOrDefault();
				if (valueOrDefault == 0)
				{
					UUIText text = base.GetText(0);
					if (text != null)
					{
						text.ShowTextNew("NormalWaitTipsText");
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "ExpectWaitingTimeText", new <>z__ReadOnlySingleElementList<object>(Math.Floor((double)this.LoginQueueConfig.ClientWaitingTime / Singleton<TimeUtil>.Instance.Minute + 0.5).ToString().PadLeft(2, '0')));
					this.RefreshAddTimeText();
					return;
				}
				if (valueOrDefault != 1)
				{
					return;
				}
				UUIText text2 = base.GetText(0);
				if (text2 != null)
				{
					text2.ShowTextNew("specialWaitTipsText");
				}
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					text3.SetUIActive(false);
				}
				UUIText text4 = base.GetText(2);
				if (text4 == null)
				{
					return;
				}
				text4.SetUIActive(false);
			}
		}

		// Token: 0x0603A5FF RID: 239103 RVA: 0x00ECD235 File Offset: 0x00ECB435
		protected override void OnTick(float delta)
		{
			this.AddTimeMs += delta;
			this.RefreshAddTimeText();
		}

		// Token: 0x0603A600 RID: 239104 RVA: 0x00ECD24C File Offset: 0x00ECB44C
		private void RefreshAddTimeText()
		{
			UUIText text = base.GetText(2);
			if (text == null || !text.IsUIActiveInHierarchy())
			{
				return;
			}
			double num = Math.Floor(Singleton<TimeUtil>.Instance.SetTimeSecond((double)this.AddTimeMs) + 0.5);
			double num2 = Math.Floor(num / Singleton<TimeUtil>.Instance.Minute);
			double num3 = num % Singleton<TimeUtil>.Instance.Minute;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "AddWaitingTimeText", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2.ToString().PadLeft(2, '0'),
				num3.ToString().PadLeft(2, '0')
			}));
		}

		// Token: 0x040210EB RID: 135403
		[Nullable(2)]
		private LoginQueueConfig LoginQueueConfig;

		// Token: 0x040210EC RID: 135404
		private float AddTimeMs;
	}
}
