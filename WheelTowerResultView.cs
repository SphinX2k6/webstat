using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016E3 RID: 5859
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerResultView : UiViewBase
{
	// Token: 0x0600A296 RID: 41622 RVA: 0x002AE454 File Offset: 0x002AC654
	[NullableContext(1)]
	public WheelTowerResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A297 RID: 41623 RVA: 0x002AE460 File Offset: 0x002AC660
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A298 RID: 41624 RVA: 0x002AE5B4 File Offset: 0x002AC7B4
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerResultView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerResultView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A299 RID: 41625 RVA: 0x002AE5F8 File Offset: 0x002AC7F8
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.SeqPlayer.PlaySequencePurely("Success", false, false, null, null, false);
		this.RefreshButton();
		this.RefreshEndlessUnlockTipsVisibility();
	}

	// Token: 0x0600A29A RID: 41626 RVA: 0x002AE63F File Offset: 0x002AC83F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600A29B RID: 41627 RVA: 0x002AE651 File Offset: 0x002AC851
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.Refresh));
	}

	// Token: 0x0600A29C RID: 41628 RVA: 0x002AE66F File Offset: 0x002AC86F
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.Refresh));
	}

	// Token: 0x0600A29D RID: 41629 RVA: 0x002AE690 File Offset: 0x002AC890
	private void RefreshEndlessUnlockTipsVisibility()
	{
		IWheelTowerResultViewData data = this.Data;
		bool valueOrDefault = ((data != null) ? data.ShowEndlessUnlockTips : null).GetValueOrDefault();
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(valueOrDefault);
	}

	// Token: 0x0600A29E RID: 41630 RVA: 0x002AE6D4 File Offset: 0x002AC8D4
	private void RefreshButton()
	{
		IWheelTowerResultViewData data = this.Data;
		if (((data != null) ? data.LeftButtonData : null) != null)
		{
			ButtonItem btnLeft = this.BtnLeft;
			if (btnLeft != null)
			{
				btnLeft.SetShowText(this.Data.LeftButtonData.Name);
			}
		}
		IWheelTowerResultViewData data2 = this.Data;
		if (((data2 != null) ? data2.CenterButtonData : null) != null)
		{
			ButtonItem btnCenter = this.BtnCenter;
			if (btnCenter != null)
			{
				btnCenter.SetShowText(this.Data.CenterButtonData.Name);
			}
		}
		IWheelTowerResultViewData data3 = this.Data;
		if (((data3 != null) ? data3.RightButtonData : null) != null)
		{
			ButtonItem btnRight = this.BtnRight;
			if (btnRight != null)
			{
				btnRight.SetShowText(this.Data.RightButtonData.Name);
			}
		}
		ButtonItem btnLeft2 = this.BtnLeft;
		if (btnLeft2 != null)
		{
			IWheelTowerResultViewData data4 = this.Data;
			btnLeft2.SetUiActive(((data4 != null) ? data4.LeftButtonData : null) != null);
		}
		ButtonItem btnCenter2 = this.BtnCenter;
		if (btnCenter2 != null)
		{
			IWheelTowerResultViewData data5 = this.Data;
			btnCenter2.SetUiActive(((data5 != null) ? data5.CenterButtonData : null) != null);
		}
		ButtonItem btnRight2 = this.BtnRight;
		if (btnRight2 != null)
		{
			IWheelTowerResultViewData data6 = this.Data;
			btnRight2.SetUiActive(((data6 != null) ? data6.RightButtonData : null) != null);
		}
		ButtonItem btnLeft3 = this.BtnLeft;
		if (btnLeft3 != null)
		{
			btnLeft3.SetFunction(new Action<int>(this.ClickBackCallback));
		}
		ButtonItem btnCenter3 = this.BtnCenter;
		if (btnCenter3 != null)
		{
			btnCenter3.SetFunction(new Action<int>(this.ClickRetryCallback));
		}
		ButtonItem btnRight3 = this.BtnRight;
		if (btnRight3 == null)
		{
			return;
		}
		btnRight3.SetFunction(new Action<int>(this.ClickContinueCallback));
	}

	// Token: 0x0600A29F RID: 41631 RVA: 0x002AE848 File Offset: 0x002ACA48
	[NullableContext(1)]
	private void Refresh(string eventName)
	{
		if (eventName != "EnterS" || this.Data == null)
		{
			return;
		}
		WheelTowerResultRoundItem roundItem = this.RoundItem;
		if (roundItem != null)
		{
			roundItem.Refresh(this.Data.EndlessMode, this.Data.CurrentRound, this.Data.TotalRound);
		}
		WheelTowerResultScoreList scoreList = this.ScoreList;
		if (scoreList != null)
		{
			scoreList.Refresh(this.Data.TotalScore, this.Data.CurrentScore);
		}
		WheelTowerResultBossList bossList = this.BossList;
		if (bossList == null)
		{
			return;
		}
		bossList.Refresh(this.Data.BossInfoList);
	}

	// Token: 0x0600A2A0 RID: 41632 RVA: 0x002AE8DF File Offset: 0x002ACADF
	private void ClickBackCallback(int _)
	{
		IWheelTowerResultViewData data = this.Data;
		this.HandleButtonClick((data != null) ? data.LeftButtonData : null);
	}

	// Token: 0x0600A2A1 RID: 41633 RVA: 0x002AE8F9 File Offset: 0x002ACAF9
	private void ClickRetryCallback(int _)
	{
		IWheelTowerResultViewData data = this.Data;
		this.HandleButtonClick((data != null) ? data.CenterButtonData : null);
	}

	// Token: 0x0600A2A2 RID: 41634 RVA: 0x002AE913 File Offset: 0x002ACB13
	private void ClickContinueCallback(int _)
	{
		IWheelTowerResultViewData data = this.Data;
		this.HandleButtonClick((data != null) ? data.RightButtonData : null);
	}

	// Token: 0x0600A2A3 RID: 41635 RVA: 0x002AE930 File Offset: 0x002ACB30
	private void HandleButtonClick(IWheelTowerResultViewButtonData buttonData)
	{
		IWheelTowerResultViewButtonData buttonData2 = buttonData;
		if (buttonData2 != null && buttonData2.ConfirmBoxId != null)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(buttonData.ConfirmBoxId.Value);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				buttonData.OnClick();
				this.CloseMe(null);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		IWheelTowerResultViewButtonData buttonData3 = buttonData;
		if (buttonData3 != null)
		{
			buttonData3.OnClick();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A2A4 RID: 41636 RVA: 0x002AE9C8 File Offset: 0x002ACBC8
	private UniTask CreateResultContent()
	{
		WheelTowerResultView.<CreateResultContent>d__23 <CreateResultContent>d__;
		<CreateResultContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateResultContent>d__.<>4__this = this;
		<CreateResultContent>d__.<>1__state = -1;
		<CreateResultContent>d__.<>t__builder.Start<WheelTowerResultView.<CreateResultContent>d__23>(ref <CreateResultContent>d__);
		return <CreateResultContent>d__.<>t__builder.Task;
	}

	// Token: 0x04004CFE RID: 19710
	private UUIItem Content;

	// Token: 0x04004CFF RID: 19711
	private WheelTowerResultRoundItem RoundItem;

	// Token: 0x04004D00 RID: 19712
	private WheelTowerResultScoreList ScoreList;

	// Token: 0x04004D01 RID: 19713
	private WheelTowerResultBossList BossList;

	// Token: 0x04004D02 RID: 19714
	private IWheelTowerResultViewData Data;

	// Token: 0x04004D03 RID: 19715
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04004D04 RID: 19716
	private ButtonItem BtnLeft;

	// Token: 0x04004D05 RID: 19717
	private ButtonItem BtnCenter;

	// Token: 0x04004D06 RID: 19718
	private ButtonItem BtnRight;
}
