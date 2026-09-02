using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CC3 RID: 23747
	public class UnOpenedAreaCountDownFloatTips : UiTickViewBase
	{
		// Token: 0x0603BE5D RID: 245341 RVA: 0x00F2E353 File Offset: 0x00F2C553
		[NullableContext(1)]
		public UnOpenedAreaCountDownFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE5E RID: 245342 RVA: 0x00F2E364 File Offset: 0x00F2C564
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

		// Token: 0x0603BE5F RID: 245343 RVA: 0x00F2E3D0 File Offset: 0x00F2C5D0
		protected override void OnStart()
		{
			this.CountDownText = base.GetText(0);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			UnOpenedAreaCountDownFloatTipsParam unOpenedAreaCountDownFloatTipsParam = this.OpenParam as UnOpenedAreaCountDownFloatTipsParam;
			if (!string.IsNullOrEmpty((unOpenedAreaCountDownFloatTipsParam != null) ? unOpenedAreaCountDownFloatTipsParam.TidCountDownTip : null))
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(unOpenedAreaCountDownFloatTipsParam.TidCountDownTip);
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				text.SetText(configTextByKey, true);
			}
		}

		// Token: 0x0603BE60 RID: 245344 RVA: 0x00F2E43E File Offset: 0x00F2C63E
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<float>(EEventName.OnUnOpenedAreaCountDownUpdate, new Action<float>(this.OnCountDownUpdate));
		}

		// Token: 0x0603BE61 RID: 245345 RVA: 0x00F2E45C File Offset: 0x00F2C65C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<float>(EEventName.OnUnOpenedAreaCountDownUpdate, new Action<float>(this.OnCountDownUpdate));
		}

		// Token: 0x0603BE62 RID: 245346 RVA: 0x00F2E47C File Offset: 0x00F2C67C
		protected override void OnTick(float delta)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() != "Loop")
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
		}

		// Token: 0x0603BE63 RID: 245347 RVA: 0x00F2E4BC File Offset: 0x00F2C6BC
		private void OnCountDownUpdate(float remainTimeSec)
		{
			if (remainTimeSec <= 0f)
			{
				this.UpdateCountDown(0);
				base.CloseMe(null);
				return;
			}
			int num = (int)Math.Ceiling((double)remainTimeSec);
			if (num != this.LastDisplayNum)
			{
				this.UpdateCountDown(num);
			}
		}

		// Token: 0x0603BE64 RID: 245348 RVA: 0x00F2E4F9 File Offset: 0x00F2C6F9
		private void UpdateCountDown(int second)
		{
			this.LastDisplayNum = second;
			this.CountDownText.SetText(second.ToString(), true);
		}

		// Token: 0x04021ABD RID: 137917
		[Nullable(2)]
		private UUIText CountDownText;

		// Token: 0x04021ABE RID: 137918
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021ABF RID: 137919
		private int LastDisplayNum = -1;

		// Token: 0x0200BD47 RID: 48455
		private class EChildComponent
		{
			// Token: 0x0403A527 RID: 238887
			public const int CountDownText = 0;

			// Token: 0x0403A528 RID: 238888
			public const int TipText = 1;
		}
	}
}
