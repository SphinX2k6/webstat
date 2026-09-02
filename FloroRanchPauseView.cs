using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C39 RID: 7225
public class FloroRanchPauseView : UiViewBase
{
	// Token: 0x0600D29C RID: 53916 RVA: 0x0037FDB5 File Offset: 0x0037DFB5
	[NullableContext(1)]
	public FloroRanchPauseView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D29D RID: 53917 RVA: 0x0037FDC0 File Offset: 0x0037DFC0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickExitButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickReStartButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickContinueButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSaveAndExitButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D29E RID: 53918 RVA: 0x0037FF14 File Offset: 0x0037E114
	private void OnClickExitButton()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchExitConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			if (ModelBase<FloroRanchGamePlayModel>.Instance.IsEndlessMode)
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.ChangeState(EFloroRanchStageStateType.StageSuccess);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.ChangeState(EFloroRanchStageStateType.StageFail);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D29F RID: 53919 RVA: 0x0037FF63 File Offset: 0x0037E163
	private void OnClickReStartButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ReStartGame();
	}

	// Token: 0x0600D2A0 RID: 53920 RVA: 0x0037FF6F File Offset: 0x0037E16F
	private void OnClickContinueButton()
	{
		base.CloseMe(delegate(bool _)
		{
			ModelBase<FloroRanchGamePlayModel>.Instance.ResumeGame();
		});
	}

	// Token: 0x0600D2A1 RID: 53921 RVA: 0x0037FF96 File Offset: 0x0037E196
	private void OnClickSaveAndExitButton()
	{
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchOutRequest(ModelBase<FloroRanchGamePlayModel>.Instance.ActivityId, ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId);
		ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(false);
	}

	// Token: 0x02007F36 RID: 32566
	private class EComponent
	{
		// Token: 0x0402B4C2 RID: 177346
		public const int ExitButton = 0;

		// Token: 0x0402B4C3 RID: 177347
		public const int ReStartButton = 1;

		// Token: 0x0402B4C4 RID: 177348
		public const int ContinueButton = 2;

		// Token: 0x0402B4C5 RID: 177349
		public const int SaveAndExitButton = 3;
	}
}
