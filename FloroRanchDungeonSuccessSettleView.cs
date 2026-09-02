using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C2F RID: 7215
public class FloroRanchDungeonSuccessSettleView : UiViewBase
{
	// Token: 0x0600D1E1 RID: 53729 RVA: 0x0037BBA3 File Offset: 0x00379DA3
	[NullableContext(1)]
	public FloroRanchDungeonSuccessSettleView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1E2 RID: 53730 RVA: 0x0037BBAC File Offset: 0x00379DAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnEndlessModeButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnExitGameButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1E3 RID: 53731 RVA: 0x0037BC98 File Offset: 0x00379E98
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchDungeonSuccessSettleView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchDungeonSuccessSettleView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D1E4 RID: 53732 RVA: 0x0037BCDC File Offset: 0x00379EDC
	protected override void OnBeforeShow()
	{
		FloroRanchSettleDataResponse floroRanchSettleDataResponse = this.OpenParam as FloroRanchSettleDataResponse;
		FloroRanchPlaySettleData floroRanchPlaySettleData = (floroRanchSettleDataResponse != null) ? floroRanchSettleDataResponse.SettleData : null;
		if (floroRanchSettleDataResponse == null || floroRanchPlaySettleData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, "弗洛洛牧场副本成功结算界面参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SettleItem.RefreshAsync(floroRanchPlaySettleData);
		base.GetButton(1).RootUIComp.Get().SetUIActive(floroRanchPlaySettleData.EnableUnlimitedMode);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnFloroRanchSuccessSettleViewOpen, floroRanchPlaySettleData.EnableUnlimitedMode);
	}

	// Token: 0x0600D1E5 RID: 53733 RVA: 0x0037BD6C File Offset: 0x00379F6C
	private void OnEndlessModeButton()
	{
		global::FloroRanchActivityData currentActivityData = ModelBase<FloroRanchGamePlayModel>.Instance.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		int id = currentActivityData.Id;
		int subInstanceId = ModelBase<FloroRanchGamePlayModel>.Instance.SubInstanceId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchPlayUnlimitedModeRequest(id, subInstanceId, delegate(FloroRanchPlayUnlimitedModeResponse response)
		{
			if (response == null)
			{
				return;
			}
			base.CloseMe(delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				ModelBase<FloroRanchGamePlayModel>.Instance.ChangeState(EFloroRanchStageStateType.DailyInStage);
			});
		});
	}

	// Token: 0x0600D1E6 RID: 53734 RVA: 0x0037BDB2 File Offset: 0x00379FB2
	private void OnExitGameButton()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(true);
	}

	// Token: 0x0400641E RID: 25630
	[Nullable(1)]
	private FloroRanchDungeonSettleItem SettleItem;

	// Token: 0x02007F15 RID: 32533
	private class EComponent
	{
		// Token: 0x0402B3DA RID: 177114
		public const int DungeonSettleItem = 0;

		// Token: 0x0402B3DB RID: 177115
		public const int EndlessModeButton = 1;

		// Token: 0x0402B3DC RID: 177116
		public const int ExitGameButton = 2;
	}
}
