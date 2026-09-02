using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002B7D RID: 11133
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueExitView : UiViewBase
{
	// Token: 0x060162A4 RID: 90788 RVA: 0x00626876 File Offset: 0x00624A76
	public SurvivorsRogueExitView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060162A5 RID: 90789 RVA: 0x00626880 File Offset: 0x00624A80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnSettle)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnExit))
		};
	}

	// Token: 0x060162A6 RID: 90790 RVA: 0x00626958 File Offset: 0x00624B58
	protected override void OnStart()
	{
		ISurvivorsExitViewParams params_ = this.OpenParam as ISurvivorsExitViewParams;
		this.RefreshInfo(params_);
	}

	// Token: 0x060162A7 RID: 90791 RVA: 0x00626978 File Offset: 0x00624B78
	private void RefreshInfo(ISurvivorsExitViewParams params_)
	{
		bool isExternal = params_.IsExternal;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "SurvivorsExitPopup_confirmText", new <>z__ReadOnlyArray<object>(new object[]
		{
			params_.Batch,
			params_.MaxBatch
		}));
		UUIText text = base.GetText(3);
		UUIText text2 = base.GetText(4);
		UUIText text3 = base.GetText(5);
		if (isExternal)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SurvivorsExit_ExternalTitle", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "SurvivorsExit_ExternalTips", Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, "SurvivorsExit_ExternalBut2", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "SurvivorsExit_InternalTitle", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "SurvivorsExit_InternalTips", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, "SurvivorsExit_InternalBut2", Array.Empty<object>());
	}

	// Token: 0x060162A8 RID: 90792 RVA: 0x00626A64 File Offset: 0x00624C64
	private void OnClickBtnSettle()
	{
		ISurvivorsExitViewParams survivorsExitViewParams = this.OpenParam as ISurvivorsExitViewParams;
		ControllerBase<SurvivorsRogueController>.Instance.RequestInstSettle(survivorsExitViewParams.IsExternal);
		base.CloseMe(null);
	}

	// Token: 0x060162A9 RID: 90793 RVA: 0x00626A94 File Offset: 0x00624C94
	private void OnClickBtnExit()
	{
		if (!(this.OpenParam as ISurvivorsExitViewParams).IsExternal)
		{
			ControllerBase<SurvivorsRogueController>.Instance.LeaveRogueInstance();
		}
		else
		{
			ControllerBase<SurvivorsRogueController>.Instance.RequestEnterInstByLevelInfo();
		}
		base.CloseMe(null);
	}
}
