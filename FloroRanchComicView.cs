using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C29 RID: 7209
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchComicView : UiViewBase
{
	// Token: 0x0600D1AF RID: 53679 RVA: 0x0037A86C File Offset: 0x00378A6C
	public FloroRanchComicView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D1B0 RID: 53680 RVA: 0x0037A8CC File Offset: 0x00378ACC
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnNextBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnSkipBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnCloseBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D1B1 RID: 53681 RVA: 0x0037A9FC File Offset: 0x00378BFC
	protected override void OnStart()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(0);
		if (button2 != null)
		{
			button2.SetSelfInteractive(false);
		}
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600D1B2 RID: 53682 RVA: 0x0037AA50 File Offset: 0x00378C50
	protected override void OnAfterShow()
	{
		if (this.ViewInfo.Name == EUiViewName.FloroRanchComicView4)
		{
			ControllerBase<FloroRanchController>.Instance.RequestComicRead();
		}
		int comicIntervalTime = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true).GetFloroRanchParamConfig().ComicIntervalTime;
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(true);
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}, (float)comicIntervalTime, null, null, true, 1f);
	}

	// Token: 0x0600D1B3 RID: 53683 RVA: 0x0037AABC File Offset: 0x00378CBC
	protected void OnNextBtnClick()
	{
		EUiViewName openViewName;
		if (this.NextViewMap.TryGetValue(this.ViewInfo.Name, out openViewName))
		{
			Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, openViewName, null, null, true);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.FloroRanch;
		ELogAuthor author = ELogAuthor.CXJ;
		string message = "弗洛洛漫画缺少下一个界面的声明";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("viewName", this.ViewInfo.Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600D1B4 RID: 53684 RVA: 0x0037AB38 File Offset: 0x00378D38
	protected void OnSkipBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FloroRanchSkipComic);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<FloroRanchController>.Instance.RequestComicRead();
			this.OnCloseBtnClick();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600D1B5 RID: 53685 RVA: 0x0037AB74 File Offset: 0x00378D74
	protected void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseAndOpenView(this.ViewInfo.Name, EUiViewName.FloroRanchMainView, null, null, true);
	}

	// Token: 0x0400640C RID: 25612
	private readonly Dictionary<EUiViewName, EUiViewName> NextViewMap = new Dictionary<EUiViewName, EUiViewName>
	{
		{
			EUiViewName.FloroRanchComicView,
			EUiViewName.FloroRanchComicView2
		},
		{
			EUiViewName.FloroRanchComicView2,
			EUiViewName.FloroRanchComicView3
		},
		{
			EUiViewName.FloroRanchComicView3,
			EUiViewName.FloroRanchComicView4
		},
		{
			EUiViewName.FloroRanchComicView4,
			EUiViewName.FloroRanchMainView
		}
	};

	// Token: 0x0400640D RID: 25613
	protected TimerHandle TimerHandle;

	// Token: 0x02007F09 RID: 32521
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B39D RID: 177053
		public const int BtnNext = 0;

		// Token: 0x0402B39E RID: 177054
		public const int BtnSkip = 1;

		// Token: 0x0402B39F RID: 177055
		public const int BtnClose = 2;

		// Token: 0x0402B3A0 RID: 177056
		public const int ItemNextPanel = 3;
	}
}
