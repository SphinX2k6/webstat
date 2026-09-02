using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using UnrealEngine;

// Token: 0x0200234C RID: 9036
[NullableContext(1)]
[Nullable(0)]
public class OnlineSearchView : UiTickViewBase
{
	// Token: 0x06011424 RID: 70692 RVA: 0x004BE9CE File Offset: 0x004BCBCE
	public OnlineSearchView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011425 RID: 70693 RVA: 0x004BE9D8 File Offset: 0x004BCBD8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITextInputComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickSearchConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011426 RID: 70694 RVA: 0x004BEB04 File Offset: 0x004BCD04
	protected override void OnStart()
	{
		this.FunctionButtonItem = new ButtonAndSpriteItem(base.GetItem(1));
		this.FunctionButtonItem.BindCallback(new Action(this.OnClickClearSearchInputBtn));
		UUIItem item = base.GetItem(4);
		this.ResultList = new LoopScrollView<OnlineHallItem, OnlineHallData>(base.GetLoopScrollViewComponent(3), item.GetOwner() as AUIBaseActor, new Func<OnlineHallItem>(this.ProxyCreateFunction), true);
		base.GetInputText(0).OnTextChange.Bind(new Action<string>(this.SetClearOrPaste));
		this.RefreshShow();
	}

	// Token: 0x06011427 RID: 70695 RVA: 0x004BEB8F File Offset: 0x004BCD8F
	protected override void OnBeforeDestroy()
	{
		ModelBase<OnlineModel>.Instance.CleanSearchResultList();
		base.GetInputText(0).OnTextChange.Unbind();
	}

	// Token: 0x06011428 RID: 70696 RVA: 0x004BEBAC File Offset: 0x004BCDAC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSearchWorld, new Action<int>(this.CallBackSearchWorld));
	}

	// Token: 0x06011429 RID: 70697 RVA: 0x004BEBCA File Offset: 0x004BCDCA
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSearchWorld, new Action<int>(this.CallBackSearchWorld));
	}

	// Token: 0x0601142A RID: 70698 RVA: 0x004BEBE8 File Offset: 0x004BCDE8
	private void RefreshShow()
	{
		this.ResultList.RefreshByData(ModelBase<OnlineModel>.Instance.SearchResult, false, delegate
		{
			OnlineHallItem onlineHallItem = this.ResultList.UnsafeGetGridProxy(0, false);
			if (onlineHallItem == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.UiComponent, ELogAuthor.LJQ, "OnlineSearchView_Item_Alpha:" + onlineHallItem.GetRootItem().GetAlpha().ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}, true);
		this.RefreshUiComponents();
	}

	// Token: 0x0601142B RID: 70699 RVA: 0x004BEC13 File Offset: 0x004BCE13
	private void RefreshUiComponents()
	{
		this.SetClearOrPaste(null);
		base.GetItem(5).SetUIActive(ModelBase<OnlineModel>.Instance.SearchResult.Count <= 0);
	}

	// Token: 0x0601142C RID: 70700 RVA: 0x004BEC3D File Offset: 0x004BCE3D
	private void CallBackSearchWorld(int i)
	{
		this.RefreshShow();
	}

	// Token: 0x0601142D RID: 70701 RVA: 0x004BEC45 File Offset: 0x004BCE45
	private OnlineHallItem ProxyCreateFunction()
	{
		return new OnlineHallItem(this.ViewInfo.Name);
	}

	// Token: 0x0601142E RID: 70702 RVA: 0x004BEC58 File Offset: 0x004BCE58
	private void OnClickClearSearchInputBtn()
	{
		UUITextInputComponent inputText = base.GetInputText(0);
		if (inputText.GetText() == "")
		{
			if (Singleton<Platform>.Instance.IsCloudGame())
			{
				string pasteTarget = "";
				UKuroCloudGameWrapper.ClipBoardPaste();
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					ULGUIBPLibrary.ClipBoardPaste(ref pasteTarget);
					inputText.SetText(pasteTarget, false);
				}, 200f, null, null, true, 1f);
			}
			else
			{
				string inText = "";
				ULGUIBPLibrary.ClipBoardPaste(ref inText);
				inputText.SetText(inText, false);
			}
		}
		else
		{
			inputText.SetText("", false);
		}
		this.SetClearOrPaste(null);
	}

	// Token: 0x0601142F RID: 70703 RVA: 0x004BED05 File Offset: 0x004BCF05
	private void SetClearOrPaste(string _)
	{
		if (base.GetInputText(0).GetText() == "")
		{
			this.FunctionButtonItem.RefreshSprite("SP_Paste");
			return;
		}
		this.FunctionButtonItem.RefreshSprite("SP_Clear");
	}

	// Token: 0x06011430 RID: 70704 RVA: 0x004BED40 File Offset: 0x004BCF40
	private void OnClickSearchConfirmBtn()
	{
		string text = base.GetInputText(0).GetText();
		if (text.Length > 0)
		{
			ControllerBase<OnlineController>.Instance.LobbyQueryPlayersRequest(int.Parse(text));
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("OnlineInvalidUserId", Array.Empty<object>());
	}

	// Token: 0x04008797 RID: 34711
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<OnlineHallItem, OnlineHallData> ResultList;

	// Token: 0x04008798 RID: 34712
	[Nullable(2)]
	private ButtonAndSpriteItem FunctionButtonItem;

	// Token: 0x02008665 RID: 34405
	[NullableContext(0)]
	private enum EOnlineSearchViewComponents
	{
		// Token: 0x0402D761 RID: 186209
		SearchUIDTextInput,
		// Token: 0x0402D762 RID: 186210
		UIDClearOrPasteBtn,
		// Token: 0x0402D763 RID: 186211
		SearchConfirmBtn,
		// Token: 0x0402D764 RID: 186212
		ResultListLoopScrollView,
		// Token: 0x0402D765 RID: 186213
		ResultModelItem,
		// Token: 0x0402D766 RID: 186214
		ResultEmptyText
	}
}
