using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D48 RID: 11592
public class WeeklyRogueExtraRoomConfirmView : UiViewBase
{
	// Token: 0x0601762F RID: 95791 RVA: 0x0067BFE9 File Offset: 0x0067A1E9
	[NullableContext(1)]
	public WeeklyRogueExtraRoomConfirmView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017630 RID: 95792 RVA: 0x0067BFF4 File Offset: 0x0067A1F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickLeft)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickRight))
		};
	}

	// Token: 0x06017631 RID: 95793 RVA: 0x0067C0CC File Offset: 0x0067A2CC
	protected override void OnStart()
	{
		ExtraRoomTipsData extraRoomTipsData = this.OpenParam as ExtraRoomTipsData;
		if (extraRoomTipsData == null)
		{
			return;
		}
		this.Data = extraRoomTipsData;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WeRogueScorePopupText", new <>z__ReadOnlyArray<object>(new object[]
		{
			extraRoomTipsData.CurScore,
			extraRoomTipsData.MaxScore
		}));
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView == null)
		{
			return;
		}
		childPopView.PopItem.OverrideBackBtnCallBack(new Action(this.OnClickLeft));
	}

	// Token: 0x06017632 RID: 95794 RVA: 0x0067C14E File Offset: 0x0067A34E
	private void OnClickLeft()
	{
		Action cancelFunc = this.Data.CancelFunc;
		if (cancelFunc != null)
		{
			cancelFunc();
		}
		base.CloseMe(null);
	}

	// Token: 0x06017633 RID: 95795 RVA: 0x0067C16D File Offset: 0x0067A36D
	private void OnClickRight()
	{
		Action confirmFunc = this.Data.ConfirmFunc;
		if (confirmFunc != null)
		{
			confirmFunc();
		}
		base.CloseMe(null);
	}

	// Token: 0x0400B381 RID: 45953
	[Nullable(1)]
	protected ExtraRoomTipsData Data;

	// Token: 0x0200900F RID: 36879
	private enum EComponents
	{
		// Token: 0x04030557 RID: 197975
		TxtDesc,
		// Token: 0x04030558 RID: 197976
		TxtCount,
		// Token: 0x04030559 RID: 197977
		PanelTips,
		// Token: 0x0403055A RID: 197978
		TxtTips,
		// Token: 0x0403055B RID: 197979
		BtnLeft,
		// Token: 0x0403055C RID: 197980
		BtnRight
	}
}
