using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020016C6 RID: 5830
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerCoverRecordPopupView : UiViewBase
{
	// Token: 0x0600A1DF RID: 41439 RVA: 0x002A95F8 File Offset: 0x002A77F8
	[NullableContext(1)]
	public WheelTowerCoverRecordPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A1E0 RID: 41440 RVA: 0x002A9604 File Offset: 0x002A7804
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickCancel));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A1E1 RID: 41441 RVA: 0x002A9774 File Offset: 0x002A7974
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerCoverRecordPopupView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerCoverRecordPopupView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A1E2 RID: 41442 RVA: 0x002A97B8 File Offset: 0x002A79B8
	protected override void OnStart()
	{
		IWheelTowerCoverRecordViewData wheelTowerCoverRecordViewData = this.OpenParam as IWheelTowerCoverRecordViewData;
		if (wheelTowerCoverRecordViewData == null)
		{
			return;
		}
		this.ConfirmCallback = wheelTowerCoverRecordViewData.OnClickConfirm;
		this.CancelCallback = wheelTowerCoverRecordViewData.OnClickCancel;
		string id = wheelTowerCoverRecordViewData.IsEndless ? "WheelTowerModeTitle_Endless" : "WheelTowerModeTitle_Normal";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "WheelTowerRecordPopup_Title", new <>z__ReadOnlyArray<object>(new object[]
		{
			ConfigMultiTextLang.GetLocalTextNew(id, null),
			wheelTowerCoverRecordViewData.TeamNum.ToString()
		}));
		WheelTowerCoverRecordItem oldItem = this.OldItem;
		if (oldItem != null)
		{
			oldItem.Refresh(wheelTowerCoverRecordViewData.BeforeData);
		}
		WheelTowerCoverRecordItem newItem = this.NewItem;
		if (newItem != null)
		{
			newItem.Refresh(wheelTowerCoverRecordViewData.AfterData);
		}
		WheelTowerCoverRecordResetScoreItem resetScoreItem = this.ResetScoreItem;
		if (resetScoreItem != null)
		{
			resetScoreItem.Refresh(wheelTowerCoverRecordViewData.BeforeData, wheelTowerCoverRecordViewData.AfterData);
		}
		WheelTowerCoverRecordResetBossItem resetBossItem = this.ResetBossItem;
		if (resetBossItem != null)
		{
			resetBossItem.Refresh(wheelTowerCoverRecordViewData.BeforeData, wheelTowerCoverRecordViewData.AfterData);
		}
		ModelBase<WheelTowerModel>.Instance.BlockEndlessUnlockTips = false;
	}

	// Token: 0x0600A1E3 RID: 41443 RVA: 0x002A98B1 File Offset: 0x002A7AB1
	private void OnClickCancel()
	{
		Action cancelCallback = this.CancelCallback;
		if (cancelCallback != null)
		{
			cancelCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600A1E4 RID: 41444 RVA: 0x002A98CB File Offset: 0x002A7ACB
	private void OnClickConfirm()
	{
		Action confirmCallback = this.ConfirmCallback;
		if (confirmCallback != null)
		{
			confirmCallback();
		}
		base.CloseMe(null);
	}

	// Token: 0x04004BF0 RID: 19440
	private WheelTowerCoverRecordItem OldItem;

	// Token: 0x04004BF1 RID: 19441
	private WheelTowerCoverRecordItem NewItem;

	// Token: 0x04004BF2 RID: 19442
	private WheelTowerCoverRecordResetScoreItem ResetScoreItem;

	// Token: 0x04004BF3 RID: 19443
	private WheelTowerCoverRecordResetBossItem ResetBossItem;

	// Token: 0x04004BF4 RID: 19444
	private Action ConfirmCallback;

	// Token: 0x04004BF5 RID: 19445
	private Action CancelCallback;
}
