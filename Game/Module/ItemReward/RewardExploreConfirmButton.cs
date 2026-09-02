using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B50 RID: 23376
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreConfirmButton : UiPanelBase
	{
		// Token: 0x0603B245 RID: 242245 RVA: 0x00EF6AB3 File Offset: 0x00EF4CB3
		public RewardExploreConfirmButton(AActor rootActor, int buttonIndex)
		{
			this.ButtonIndex = buttonIndex;
			base.CreateThenShowByActor(rootActor, null);
		}

		// Token: 0x0603B246 RID: 242246 RVA: 0x00EF6ACC File Offset: 0x00EF4CCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
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
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B247 RID: 242247 RVA: 0x00EF6BB4 File Offset: 0x00EF4DB4
		protected override void OnBeforeDestroy()
		{
			this.RemoveTimeDown();
			this.ButtonData = null;
		}

		// Token: 0x0603B248 RID: 242248 RVA: 0x00EF6BC4 File Offset: 0x00EF4DC4
		public void Refresh(IRewardExploreConfirmButton buttonData)
		{
			this.ButtonData = buttonData;
			this.SetButtonText(buttonData.ButtonTextId);
			bool flag = !StringUtils.IsEmpty(buttonData.DescriptionTextId);
			this.SetButtonDescriptionVisible(flag);
			if (flag)
			{
				this.RefreshButtonDescription();
			}
		}

		// Token: 0x0603B249 RID: 242249 RVA: 0x00EF6C04 File Offset: 0x00EF4E04
		private void SetButtonText(string textId)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
		}

		// Token: 0x0603B24A RID: 242250 RVA: 0x00EF6C2A File Offset: 0x00EF4E2A
		private void SetButtonDescriptionVisible(bool bVisible)
		{
			UUIItem item = base.GetItem(1);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0603B24B RID: 242251 RVA: 0x00EF6C40 File Offset: 0x00EF4E40
		private void RefreshButtonDescription()
		{
			string descriptionTextId = this.ButtonData.DescriptionTextId;
			List<object> descriptionArgs = this.ButtonData.DescriptionArgs;
			int? timeDown = this.ButtonData.TimeDown;
			UUIText text = base.GetText(2);
			int? num = timeDown;
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionTextId, new <>z__ReadOnlySingleElementList<object>(timeDown / Singleton<TimeUtil>.Instance.InverseMillisecond));
				this.RemoveTimeDown();
				this.AddTimeDown(timeDown.Value);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionTextId, descriptionArgs);
		}

		// Token: 0x0603B24C RID: 242252 RVA: 0x00EF6D00 File Offset: 0x00EF4F00
		private void AddTimeDown(int timeDown)
		{
			if (this.TimeDown == 0)
			{
				this.TimeDown = timeDown / Singleton<TimeUtil>.Instance.InverseMillisecond;
			}
			this.TimeDownTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimeDownRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603B24D RID: 242253 RVA: 0x00EF6D50 File Offset: 0x00EF4F50
		private void RemoveTimeDown()
		{
			if (this.TimeDownTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.TimeDownTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimeDownTimerId);
				this.TimeDownTimerId = null;
			}
		}

		// Token: 0x0603B24E RID: 242254 RVA: 0x00EF6D84 File Offset: 0x00EF4F84
		private void OnTimeDownRefresh(float _)
		{
			this.TimeDown--;
			if (this.TimeDown <= 0)
			{
				this.RemoveTimeDown();
				if (this.ButtonData.OnTimeDownOnCallback != null)
				{
					this.ButtonData.OnTimeDownOnCallback();
				}
				if (this.ButtonData.IsTimeDownCloseView)
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
				}
			}
			string descriptionTextId = this.ButtonData.DescriptionTextId;
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, descriptionTextId, new <>z__ReadOnlySingleElementList<object>(this.TimeDown));
		}

		// Token: 0x0603B24F RID: 242255 RVA: 0x00EF6E18 File Offset: 0x00EF5018
		private void AddCdTimer(int cdTime)
		{
			this.CdTimeDown = cdTime / Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.CdTimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnCdTimeRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603B250 RID: 242256 RVA: 0x00EF6E55 File Offset: 0x00EF5055
		private void RemoveCdTimer()
		{
			if (this.CdTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.CdTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CdTimerId);
				this.CdTimerId = null;
			}
		}

		// Token: 0x0603B251 RID: 242257 RVA: 0x00EF6E8C File Offset: 0x00EF508C
		private void OnCdTimeRefresh(float _)
		{
			this.CdTimeDown--;
			if (this.CdTimeDown > 0)
			{
				UUIText text = base.GetText(0);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.ButtonData.ButtonTextId, null);
				string text2 = ConfigMultiTextLang.GetLocalTextNew("OnClickCd", null);
				text2 = StringUtils.Format(text2, new string[]
				{
					this.CdTimeDown.ToString()
				});
				if (text != null)
				{
					text.SetText(localTextNew + text2, true);
				}
				return;
			}
			this.RemoveCdTimer();
			this.SetButtonText(this.ButtonData.ButtonTextId);
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(true);
		}

		// Token: 0x0603B252 RID: 242258 RVA: 0x00EF6F2C File Offset: 0x00EF512C
		private void OnClickedButton()
		{
			Action<int> onClickedCallback = this.ButtonData.OnClickedCallback;
			if (onClickedCallback != null)
			{
				onClickedCallback(this.ButtonIndex);
			}
			int? clickCd = this.ButtonData.ClickCd;
			int? num = clickCd;
			int num2 = 0;
			if (num.GetValueOrDefault() > num2 & num != null)
			{
				this.AddCdTimer(clickCd.Value);
				UUIButtonComponent button = base.GetButton(3);
				if (button != null)
				{
					button.SetSelfInteractive(false);
				}
				UUIText text = base.GetText(0);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.ButtonData.ButtonTextId, null);
				string text2 = ConfigMultiTextLang.GetLocalTextNew("OnClickCd", null);
				text2 = StringUtils.Format(text2, new string[]
				{
					(clickCd / Singleton<TimeUtil>.Instance.InverseMillisecond).ToString()
				});
				if (text != null)
				{
					text.SetText(localTextNew + text2, true);
				}
			}
			if (this.ButtonData.IsClickedCloseView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
			}
		}

		// Token: 0x04021579 RID: 136569
		[Nullable(2)]
		private IRewardExploreConfirmButton ButtonData;

		// Token: 0x0402157A RID: 136570
		private int TimeDown;

		// Token: 0x0402157B RID: 136571
		[Nullable(2)]
		private TimerHandle TimeDownTimerId;

		// Token: 0x0402157C RID: 136572
		private int CdTimeDown;

		// Token: 0x0402157D RID: 136573
		[Nullable(2)]
		private TimerHandle CdTimerId;

		// Token: 0x0402157E RID: 136574
		private readonly int ButtonIndex;

		// Token: 0x0200BB50 RID: 47952
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039CDE RID: 236766
			public const int ButtonText = 0;

			// Token: 0x04039CDF RID: 236767
			public const int DescriptionItem = 1;

			// Token: 0x04039CE0 RID: 236768
			public const int DescriptionText = 2;

			// Token: 0x04039CE1 RID: 236769
			public const int Button = 3;
		}
	}
}
