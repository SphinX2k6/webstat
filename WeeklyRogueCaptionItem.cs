using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D2C RID: 11564
public class WeeklyRogueCaptionItem : UiPanelBase
{
	// Token: 0x0601757D RID: 95613 RVA: 0x00678CD0 File Offset: 0x00676ED0
	public WeeklyRogueCaptionItem(bool needCurrency = true)
	{
		this.NeedCurrency = needCurrency;
	}

	// Token: 0x0601757E RID: 95614 RVA: 0x00678D04 File Offset: 0x00676F04
	protected unsafe override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent))
		};
		int num = 3;
		List<ValueTuple<int, Delegate>> list = new List<ValueTuple<int, Delegate>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list, num);
		Span<ValueTuple<int, Delegate>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnBack));
		num2++;
		*span[num2] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnToggleDesc));
		num2++;
		*span[num2] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnInfo));
		this.BtnBindInfo = list;
	}

	// Token: 0x0601757F RID: 95615 RVA: 0x00678E10 File Offset: 0x00677010
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueCaptionItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueCaptionItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017580 RID: 95616 RVA: 0x00678E53 File Offset: 0x00677053
	private void OnBtnBack()
	{
		Action onClickCloseBtnCall = this.OnClickCloseBtnCall;
		if (onClickCloseBtnCall == null)
		{
			return;
		}
		onClickCloseBtnCall();
	}

	// Token: 0x06017581 RID: 95617 RVA: 0x00678E65 File Offset: 0x00677065
	[NullableContext(1)]
	public void SetCloseCallBack(Action call)
	{
		this.OnClickCloseBtnCall = call;
	}

	// Token: 0x06017582 RID: 95618 RVA: 0x00678E6E File Offset: 0x0067706E
	private void OnBtnInfo()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueInfo, null, null);
	}

	// Token: 0x06017583 RID: 95619 RVA: 0x00678E81 File Offset: 0x00677081
	private void OnToggleDesc(EToggleState toggleState)
	{
		ModelBase<WeeklyRogueModel>.Instance.ChangeDescMode();
	}

	// Token: 0x06017584 RID: 95620 RVA: 0x00678E90 File Offset: 0x00677090
	private void RefreshToggleState()
	{
		EToggleState state = (ModelBase<WeeklyRogueModel>.Instance.DescMode == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(2).SetToggleState(state, false, false, false);
	}

	// Token: 0x0400B347 RID: 45895
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400B348 RID: 45896
	[Nullable(1)]
	private Action OnClickCloseBtnCall = delegate()
	{
	};

	// Token: 0x0400B349 RID: 45897
	public bool NeedCurrency;

	// Token: 0x02008FEF RID: 36847
	private enum EComponents
	{
		// Token: 0x040304C0 RID: 197824
		PanelCaption,
		// Token: 0x040304C1 RID: 197825
		BtnBack,
		// Token: 0x040304C2 RID: 197826
		ToggleDesc,
		// Token: 0x040304C3 RID: 197827
		TxtDesc,
		// Token: 0x040304C4 RID: 197828
		BtnInfo
	}
}
