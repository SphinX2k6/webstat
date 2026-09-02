using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CA6 RID: 7334
[NullableContext(1)]
[Nullable(0)]
public class FriendSearchView : UiViewBase
{
	// Token: 0x0600D727 RID: 55079 RVA: 0x003980D5 File Offset: 0x003962D5
	public FriendSearchView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D728 RID: 55080 RVA: 0x003980EC File Offset: 0x003962EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickSearchConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickSearchTypeButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D729 RID: 55081 RVA: 0x00398303 File Offset: 0x00396503
	private void OnClickSearchTypeButton()
	{
		this.CurrentSearchType = ((this.CurrentSearchType == FriendSearchView.ECurrentSearchType.Uid) ? FriendSearchView.ECurrentSearchType.ThirdPartyId : FriendSearchView.ECurrentSearchType.Uid);
		this.RefreshSearchTypeButton();
		this.RefreshPlaceHolderText();
		this.RefreshSearchColor();
		this.RefreshDescText();
	}

	// Token: 0x0600D72A RID: 55082 RVA: 0x00398330 File Offset: 0x00396530
	private void RefreshSearchColor()
	{
		if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.ThirdPartyId)
		{
			string thirdPartySearchColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartySearchColor(EThirdPartySearchColorSet.Set1);
			string thirdPartySearchColor2 = ConfigBase<UiResourceConfig>.Instance.GetThirdPartySearchColor(EThirdPartySearchColorSet.Set2);
			base.GetSprite(10).SetColor(FColor.FromHex(thirdPartySearchColor));
			base.GetSprite(11).SetColor(FColor.FromHex(thirdPartySearchColor2));
			return;
		}
		base.GetSprite(10).SetColor(FColor.FromHex("E8E8E6FF"));
		base.GetSprite(11).SetColor(FColor.FromHex("FFFFFFFF"));
	}

	// Token: 0x0600D72B RID: 55083 RVA: 0x003983B4 File Offset: 0x003965B4
	private void RefreshPlaceHolderText()
	{
		if (ControllerBase<KuroSdkController>.Instance.SupportSwitchFriendSearchByThirdPartyId())
		{
			string textStringId = "";
			if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.ThirdPartyId)
			{
				if (Singleton<Info>.Instance.IsPs5Platform())
				{
					textStringId = "Search_PSN_ID_Tips";
				}
				else if (Singleton<Info>.Instance.IsXboxPlatform())
				{
					textStringId = "Search_Xbox_ID_Tips";
				}
			}
			else if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.Uid)
			{
				textStringId = "Search_UID_Tips";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Search_UID_Tips", Array.Empty<object>());
	}

	// Token: 0x0600D72C RID: 55084 RVA: 0x00398448 File Offset: 0x00396648
	private void RefreshDescText()
	{
		if (ControllerBase<KuroSdkController>.Instance.SupportSwitchFriendSearchByThirdPartyId())
		{
			string textStringId = "";
			if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.ThirdPartyId)
			{
				if (Singleton<Info>.Instance.IsPs5Platform())
				{
					textStringId = "Search_PSN_ID_Result";
				}
				else if (Singleton<Info>.Instance.IsXboxPlatform())
				{
					textStringId = "Search_Xbox_ID_Result";
				}
			}
			else if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.Uid)
			{
				textStringId = "Search_UID_Result";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), textStringId, Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Search_UID_Result", Array.Empty<object>());
	}

	// Token: 0x0600D72D RID: 55085 RVA: 0x003984DC File Offset: 0x003966DC
	private void RefreshSearchTypeButton()
	{
		if (ControllerBase<KuroSdkController>.Instance.SupportSwitchFriendSearchByThirdPartyId())
		{
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			string textStringId = "";
			if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.ThirdPartyId)
			{
				if (Singleton<Info>.Instance.IsPs5Platform())
				{
					textStringId = "PlayStationSearch";
				}
				else if (Singleton<Info>.Instance.IsXboxPlatform())
				{
					textStringId = "XboxSearch";
				}
			}
			else if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.Uid)
			{
				textStringId = "NormalSearch";
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), textStringId, Array.Empty<object>());
			return;
		}
		base.GetButton(6).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600D72E RID: 55086 RVA: 0x00398588 File Offset: 0x00396788
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SearchPlayerInfo, new Action<int>(this.CallBackSearchPlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.ApplicationSent, new Action<int>(this.CallBackApplicationSent));
		Singleton<EventSystem>.Instance.Add<EFriendItemOperation, IReadOnlyList<int>>(EEventName.ApplicationHandled, new Action<EFriendItemOperation, IReadOnlyList<int>>(this.CallBackApplyPlayer));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshItemMuteState));
	}

	// Token: 0x0600D72F RID: 55087 RVA: 0x00398624 File Offset: 0x00396824
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SearchPlayerInfo, new Action<int>(this.CallBackSearchPlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.ApplicationSent, new Action<int>(this.CallBackApplicationSent));
		Singleton<EventSystem>.Instance.Remove(EEventName.ApplicationHandled, new Action<EFriendItemOperation, IReadOnlyList<int>>(this.CallBackApplyPlayer));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddMutePlayer, new Action<int>(this.RefreshItemMuteState));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveMutePlayer, new Action<int>(this.RefreshItemMuteState));
	}

	// Token: 0x0600D730 RID: 55088 RVA: 0x003986C0 File Offset: 0x003968C0
	protected override UniTask OnBeforeStartAsync()
	{
		FriendSearchView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FriendSearchView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D731 RID: 55089 RVA: 0x003986FC File Offset: 0x003968FC
	protected override void OnStart()
	{
		bool flag = !Singleton<Info>.Instance.IsHomeConsolePlatform();
		if (flag)
		{
			this.FunctionButtonItem = new ButtonAndSpriteItem(base.GetItem(1));
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(3);
		this.ResultListLayout = new LoopScrollView<FriendItem, FriendItemSt>(base.GetLoopScrollViewComponent(4), item2.GetOwner() as AUIBaseActor, new Func<FriendItem>(this.CreateResultItem), true);
		base.GetInputText(0).OnTextChange.Bind(new Action<string>(this.SetClearOrPaste));
		FriendModel instance = ModelBase<FriendModel>.Instance;
		instance.ClearFriendSearchResults();
		this.ResultList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(instance.GetFriendSearchResultListIds(), EFriendItemOperation.Default);
		this.RefreshShow();
	}

	// Token: 0x0600D732 RID: 55090 RVA: 0x003987B7 File Offset: 0x003969B7
	protected override void OnAfterHide()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		instance.ClearApplyFriendList();
		instance.ClearApproveFriendList();
		instance.ClearRefuseFriendList();
	}

	// Token: 0x0600D733 RID: 55091 RVA: 0x003987CF File Offset: 0x003969CF
	protected override void OnBeforeDestroy()
	{
		base.GetInputText(0).OnTextChange.Unbind();
		ModelBase<FriendModel>.Instance.ResetShowingView();
	}

	// Token: 0x0600D734 RID: 55092 RVA: 0x003987EC File Offset: 0x003969EC
	private FriendItem CreateResultItem()
	{
		return new FriendItem(this.ViewInfo.Name, null);
	}

	// Token: 0x0600D735 RID: 55093 RVA: 0x00398800 File Offset: 0x00396A00
	private void RefreshShow()
	{
		if (this.ResultList.Count > 0)
		{
			this.ResultListLayout.RefreshByData(this.ResultList, false, null, false);
		}
		this.RefreshUiComponents();
		this.RefreshSearchTypeButton();
		this.RefreshPlaceHolderText();
		this.RefreshSearchColor();
		this.RefreshDescText();
	}

	// Token: 0x0600D736 RID: 55094 RVA: 0x00398850 File Offset: 0x00396A50
	private void RefreshUiComponents()
	{
		base.GetInputText(0).SetText("", false);
		this.SetClearOrPaste("");
		base.GetItem(5).SetUIActive(this.ResultList.Count <= 0);
		base.GetLoopScrollViewComponent(4).RootUIComp.Get().SetUIActive(this.ResultList.Count > 0);
	}

	// Token: 0x0600D737 RID: 55095 RVA: 0x003988C0 File Offset: 0x00396AC0
	private void SetClearOrPaste(string text)
	{
		if (this.FunctionButtonItem == null)
		{
			return;
		}
		if (base.GetInputText(0).GetText() == "")
		{
			this.FunctionButtonItem.RefreshSprite("SP_Paste");
			this.FunctionButtonItem.BindCallback(new Action(this.OnClickPasteBtn));
			return;
		}
		this.FunctionButtonItem.RefreshSprite("SP_Clear");
		this.FunctionButtonItem.BindCallback(new Action(this.OnClickClearBtn));
	}

	// Token: 0x0600D738 RID: 55096 RVA: 0x0039893D File Offset: 0x00396B3D
	private void OnClickClearBtn()
	{
		base.GetInputText(0).SetText("", false);
		this.SetClearOrPaste("");
	}

	// Token: 0x0600D739 RID: 55097 RVA: 0x0039895C File Offset: 0x00396B5C
	private void OnClickPasteBtn()
	{
		string pasteTarget = "";
		if (Singleton<Platform>.Instance.IsCloudGame())
		{
			UUITextInputComponent inputText = base.GetInputText(0);
			UKuroCloudGameWrapper.ClipBoardPaste();
			TimerSystem.GameplayTimeInstance.Delay(delegate(float delta)
			{
				ULGUIBPLibrary.ClipBoardPaste(ref pasteTarget);
				if (pasteTarget != "")
				{
					inputText.SetText(pasteTarget, false);
					this.SetClearOrPaste("");
				}
			}, 200f, null, null, true, 1f);
			return;
		}
		UUITextInputComponent inputText2 = base.GetInputText(0);
		ULGUIBPLibrary.ClipBoardPaste(ref pasteTarget);
		if (pasteTarget != "")
		{
			inputText2.SetText(pasteTarget, false);
			this.SetClearOrPaste("");
		}
	}

	// Token: 0x0600D73A RID: 55098 RVA: 0x00398A04 File Offset: 0x00396C04
	private void OnClickSearchConfirmBtn()
	{
		FriendModel instance = ModelBase<FriendModel>.Instance;
		instance.ClearApplyFriendList();
		instance.ClearApproveFriendList();
		instance.ClearRefuseFriendList();
		string text = base.GetInputText(0).GetText();
		if (text.Length > 0)
		{
			if (this.CurrentSearchType == FriendSearchView.ECurrentSearchType.Uid)
			{
				int playerId = 0;
				if (int.TryParse(text, out playerId))
				{
					ControllerBase<FriendController>.Instance.RequestSearchPlayerBasicInfo(playerId, false);
					return;
				}
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("InvalidUserId", Array.Empty<object>());
				return;
			}
			else
			{
				ControllerBase<FriendController>.Instance.RequestSearchPlayerBasicInfoBySdkId(text);
			}
		}
	}

	// Token: 0x0600D73B RID: 55099 RVA: 0x00398A7E File Offset: 0x00396C7E
	private void CallBackSearchPlayer(int playerId)
	{
		this.ResultList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(new List<int>
		{
			playerId
		}, EFriendItemOperation.Default);
		this.RefreshShow();
	}

	// Token: 0x0600D73C RID: 55100 RVA: 0x00398AA3 File Offset: 0x00396CA3
	private void CallBackApplicationSent(int playerId)
	{
		this.ResultList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(new List<int>
		{
			playerId
		}, EFriendItemOperation.SendApply);
		this.RefreshShow();
	}

	// Token: 0x0600D73D RID: 55101 RVA: 0x00398AC8 File Offset: 0x00396CC8
	private void CallBackApplyPlayer(EFriendItemOperation operation, IReadOnlyList<int> ids)
	{
		this.ResultList = ControllerBase<FriendController>.Instance.CreateFriendItemSt(ids, operation);
		this.RefreshShow();
	}

	// Token: 0x0600D73E RID: 55102 RVA: 0x00398AE4 File Offset: 0x00396CE4
	private void RefreshItemMuteState(int playerId)
	{
		int i = 0;
		while (i < this.ResultList.Count)
		{
			if (this.ResultList[i].Id == playerId)
			{
				FriendItem friendItem = this.ResultListLayout.UnsafeGetGridProxy(i, false);
				if (friendItem == null)
				{
					return;
				}
				friendItem.RefreshMute();
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x040065FC RID: 26108
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<FriendItem, FriendItemSt> ResultListLayout;

	// Token: 0x040065FD RID: 26109
	private List<FriendItemSt> ResultList = new List<FriendItemSt>();

	// Token: 0x040065FE RID: 26110
	private FriendSearchView.ECurrentSearchType CurrentSearchType;

	// Token: 0x040065FF RID: 26111
	[Nullable(2)]
	private ButtonAndSpriteItem FunctionButtonItem;

	// Token: 0x02007FFC RID: 32764
	[NullableContext(0)]
	private enum ECurrentSearchType
	{
		// Token: 0x0402B8DE RID: 178398
		Uid,
		// Token: 0x0402B8DF RID: 178399
		ThirdPartyId
	}

	// Token: 0x02007FFD RID: 32765
	[NullableContext(0)]
	private class EFriendSearchView
	{
		// Token: 0x0402B8E0 RID: 178400
		public const int SearchUIDTextInput = 0;

		// Token: 0x0402B8E1 RID: 178401
		public const int FunctionButtonItem = 1;

		// Token: 0x0402B8E2 RID: 178402
		public const int SearchConfirmBtn = 2;

		// Token: 0x0402B8E3 RID: 178403
		public const int ResultModelItem = 3;

		// Token: 0x0402B8E4 RID: 178404
		public const int ResultListLoopScrollView = 4;

		// Token: 0x0402B8E5 RID: 178405
		public const int ResultEmptyBox = 5;

		// Token: 0x0402B8E6 RID: 178406
		public const int SearchTypeButton = 6;

		// Token: 0x0402B8E7 RID: 178407
		public const int SearchTypeText = 7;

		// Token: 0x0402B8E8 RID: 178408
		public const int PlaceHolderText = 8;

		// Token: 0x0402B8E9 RID: 178409
		public const int DescText = 9;

		// Token: 0x0402B8EA RID: 178410
		public const int NorSprite = 10;

		// Token: 0x0402B8EB RID: 178411
		public const int HightSprite = 11;
	}
}
