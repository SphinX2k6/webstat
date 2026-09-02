using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002417 RID: 9239
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PersonalOptionController : UiControllerBase<PersonalOptionController>
{
	// Token: 0x06011DF2 RID: 73202 RVA: 0x004EA238 File Offset: 0x004E8438
	public PersonalOptionController()
	{
		this.InitOptionMap();
	}

	// Token: 0x06011DF3 RID: 73203 RVA: 0x004EA248 File Offset: 0x004E8448
	protected void InitOptionMap()
	{
		this.OptionMap = new Dictionary<int, Action>();
		Dictionary<int, Action> optionMap = this.OptionMap;
		int key = 1;
		Action value;
		if ((value = PersonalOptionController.<>O.<0>__OnClickShieldBtn) == null)
		{
			value = (PersonalOptionController.<>O.<0>__OnClickShieldBtn = new Action(PersonalOptionController.OnClickShieldBtn));
		}
		optionMap.TryAdd(key, value);
		Dictionary<int, Action> optionMap2 = this.OptionMap;
		int key2 = 2;
		Action value2;
		if ((value2 = PersonalOptionController.<>O.<0>__OnClickShieldBtn) == null)
		{
			value2 = (PersonalOptionController.<>O.<0>__OnClickShieldBtn = new Action(PersonalOptionController.OnClickShieldBtn));
		}
		optionMap2.TryAdd(key2, value2);
		Dictionary<int, Action> optionMap3 = this.OptionMap;
		int key3 = 3;
		Action value3;
		if ((value3 = PersonalOptionController.<>O.<1>__OnClickBlockBtn) == null)
		{
			value3 = (PersonalOptionController.<>O.<1>__OnClickBlockBtn = new Action(PersonalOptionController.OnClickBlockBtn));
		}
		optionMap3.TryAdd(key3, value3);
		Dictionary<int, Action> optionMap4 = this.OptionMap;
		int key4 = 4;
		Action value4;
		if ((value4 = PersonalOptionController.<>O.<2>__OnClickDeleteBtn) == null)
		{
			value4 = (PersonalOptionController.<>O.<2>__OnClickDeleteBtn = new Action(PersonalOptionController.OnClickDeleteBtn));
		}
		optionMap4.TryAdd(key4, value4);
		Dictionary<int, Action> optionMap5 = this.OptionMap;
		int key5 = 5;
		Action value5;
		if ((value5 = PersonalOptionController.<>O.<3>__OnClickReportBtn) == null)
		{
			value5 = (PersonalOptionController.<>O.<3>__OnClickReportBtn = new Action(PersonalOptionController.OnClickReportBtn));
		}
		optionMap5.TryAdd(key5, value5);
		Dictionary<int, Action> optionMap6 = this.OptionMap;
		int key6 = 11;
		Action value6;
		if ((value6 = PersonalOptionController.<>O.<4>__CopyUidClick) == null)
		{
			value6 = (PersonalOptionController.<>O.<4>__CopyUidClick = new Action(PersonalOptionController.CopyUidClick));
		}
		optionMap6.TryAdd(key6, value6);
		Dictionary<int, Action> optionMap7 = this.OptionMap;
		int key7 = 6;
		Action value7;
		if ((value7 = PersonalOptionController.<>O.<5>__ChangeHeadIcon) == null)
		{
			value7 = (PersonalOptionController.<>O.<5>__ChangeHeadIcon = new Action(PersonalOptionController.ChangeHeadIcon));
		}
		optionMap7.TryAdd(key7, value7);
		Dictionary<int, Action> optionMap8 = this.OptionMap;
		int key8 = 7;
		Action value8;
		if ((value8 = PersonalOptionController.<>O.<6>__ChangeCard) == null)
		{
			value8 = (PersonalOptionController.<>O.<6>__ChangeCard = new Action(PersonalOptionController.ChangeCard));
		}
		optionMap8.TryAdd(key8, value8);
		Dictionary<int, Action> optionMap9 = this.OptionMap;
		int key9 = 8;
		Action value9;
		if ((value9 = PersonalOptionController.<>O.<7>__ChangeName) == null)
		{
			value9 = (PersonalOptionController.<>O.<7>__ChangeName = new Action(PersonalOptionController.ChangeName));
		}
		optionMap9.TryAdd(key9, value9);
		Dictionary<int, Action> optionMap10 = this.OptionMap;
		int key10 = 9;
		Action value10;
		if ((value10 = PersonalOptionController.<>O.<8>__ChangeSign) == null)
		{
			value10 = (PersonalOptionController.<>O.<8>__ChangeSign = new Action(PersonalOptionController.ChangeSign));
		}
		optionMap10.TryAdd(key10, value10);
		Dictionary<int, Action> optionMap11 = this.OptionMap;
		int key11 = 10;
		Action value11;
		if ((value11 = PersonalOptionController.<>O.<9>__SetBirth) == null)
		{
			value11 = (PersonalOptionController.<>O.<9>__SetBirth = new Action(PersonalOptionController.SetBirth));
		}
		optionMap11.TryAdd(key11, value11);
		Dictionary<int, Action> optionMap12 = this.OptionMap;
		int key12 = 12;
		Action value12;
		if ((value12 = PersonalOptionController.<>O.<10>__LookCard) == null)
		{
			value12 = (PersonalOptionController.<>O.<10>__LookCard = new Action(PersonalOptionController.LookCard));
		}
		optionMap12.TryAdd(key12, value12);
		Dictionary<int, Action> optionMap13 = this.OptionMap;
		int key13 = 13;
		Action value13;
		if ((value13 = PersonalOptionController.<>O.<11>__ChangeRemark) == null)
		{
			value13 = (PersonalOptionController.<>O.<11>__ChangeRemark = new Action(PersonalOptionController.ChangeRemark));
		}
		optionMap13.TryAdd(key13, value13);
		Dictionary<int, Action> optionMap14 = this.OptionMap;
		int key14 = 14;
		Action value14;
		if ((value14 = PersonalOptionController.<>O.<12>__ChangePlayerTitle) == null)
		{
			value14 = (PersonalOptionController.<>O.<12>__ChangePlayerTitle = new Action(PersonalOptionController.ChangePlayerTitle));
		}
		optionMap14.TryAdd(key14, value14);
		Dictionary<int, Action> optionMap15 = this.OptionMap;
		int key15 = 15;
		Action value15;
		if ((value15 = PersonalOptionController.<>O.<13>__OpenPersonalRootView) == null)
		{
			value15 = (PersonalOptionController.<>O.<13>__OpenPersonalRootView = new Action(PersonalOptionController.OpenPersonalRootView));
		}
		optionMap15.TryAdd(key15, value15);
		Dictionary<int, Action> optionMap16 = this.OptionMap;
		int key16 = 16;
		Action value16;
		if ((value16 = PersonalOptionController.<>O.<14>__OpenFeedBackMainView) == null)
		{
			value16 = (PersonalOptionController.<>O.<14>__OpenFeedBackMainView = new Action(PersonalOptionController.OpenFeedBackMainView));
		}
		optionMap16.TryAdd(key16, value16);
	}

	// Token: 0x06011DF4 RID: 73204 RVA: 0x004EA4E8 File Offset: 0x004E86E8
	public Action GetOptionFunc(EPersonalOptionDefine optionId)
	{
		if (this.OptionMap.Count == 0)
		{
			this.InitOptionMap();
		}
		Action result;
		this.OptionMap.TryGetValue((int)optionId, out result);
		return result;
	}

	// Token: 0x06011DF5 RID: 73205 RVA: 0x004EA518 File Offset: 0x004E8718
	private static void OnClickShieldBtn()
	{
		IPlayerData playerData;
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineProcessView))
		{
			IPlayerData cachePlayerData = ModelBase<FriendModel>.Instance.CachePlayerData;
			playerData = cachePlayerData;
		}
		else
		{
			IPlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
			playerData = cachePlayerData;
		}
		IPlayerData playerData2 = playerData;
		if (!ModelBase<FriendModel>.Instance.IsMyFriend(playerData2.PlayerId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("NotFriendShieldTips", Array.Empty<object>());
			return;
		}
		if (ModelBase<ChatModel>.Instance.IsInMute(playerData2.PlayerId))
		{
			ControllerBase<ChatController>.Instance.ChatMutePlayerRequest(playerData2.PlayerId, false);
			return;
		}
		ControllerBase<ChatController>.Instance.ChatMutePlayerRequest(playerData2.PlayerId, true);
	}

	// Token: 0x06011DF6 RID: 73206 RVA: 0x004EA5B0 File Offset: 0x004E87B0
	private static void OnClickReportBtn()
	{
		IPlayerData playerData;
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineProcessView))
		{
			IPlayerData cachePlayerData = ModelBase<FriendModel>.Instance.CachePlayerData;
			playerData = cachePlayerData;
		}
		else
		{
			IPlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
			playerData = cachePlayerData;
		}
		IPlayerData friendData = playerData;
		ControllerBase<ReportController>.Instance.OpenReportView(friendData, EReportSourceType.FriendSystem);
	}

	// Token: 0x06011DF7 RID: 73207 RVA: 0x004EA5F8 File Offset: 0x004E87F8
	private static void OnClickDeleteBtn()
	{
		PersonalOptionController.<>c__DisplayClass6_0 CS$<>8__locals1 = new PersonalOptionController.<>c__DisplayClass6_0();
		FriendModel instance = ModelBase<FriendModel>.Instance;
		PersonalOptionController.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
		IPlayerData player;
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.OnlineProcessView))
		{
			IPlayerData cachePlayerData = instance.CachePlayerData;
			player = cachePlayerData;
		}
		else
		{
			IPlayerData cachePlayerData = ModelBase<OnlineModel>.Instance.CachePlayerData;
			player = cachePlayerData;
		}
		CS$<>8__locals2.player = player;
		if (!instance.HasFriend(CS$<>8__locals1.player.PlayerId))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("NotOnFriendList", Array.Empty<object>());
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendProcessView, null);
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DeleteFriend);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			CS$<>8__locals1.player.PlayerName
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<FriendController>.Instance.RequestFriendDelete(CS$<>8__locals1.player.PlayerId);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011DF8 RID: 73208 RVA: 0x004EA6BC File Offset: 0x004E88BC
	private static void OnClickBlockBtn()
	{
		FriendData player = ModelBase<FriendModel>.Instance.CachePlayerData;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BlockFriend);
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			player.PlayerName
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<FriendController>.Instance.RequestBlockPlayer(player.PlayerId);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011DF9 RID: 73209 RVA: 0x004EA728 File Offset: 0x004E8928
	private static void CopyUidClick()
	{
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CopiedMyUid", Array.Empty<object>());
		ULGUIBPLibrary.ClipBoardCopy(ModelBase<PlayerInfoModel>.Instance.GetId().ToString());
	}

	// Token: 0x06011DFA RID: 73210 RVA: 0x004EA766 File Offset: 0x004E8966
	private static void ChangeHeadIcon()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalEditView, EPersonalEditDefine.HeadPhoto, null);
	}

	// Token: 0x06011DFB RID: 73211 RVA: 0x004EA77E File Offset: 0x004E897E
	private static void ChangeCard()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalEditView, EPersonalEditDefine.Card, null);
	}

	// Token: 0x06011DFC RID: 73212 RVA: 0x004EA796 File Offset: 0x004E8996
	private static void ChangePlayerTitle()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalEditView, EPersonalEditDefine.PlayerTitle, null);
	}

	// Token: 0x06011DFD RID: 73213 RVA: 0x004EA7AE File Offset: 0x004E89AE
	private static void OpenPersonalRootView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalRootView, ModelBase<PersonalModel>.Instance.GetPersonalInfoData(), null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalOptionView, null);
	}

	// Token: 0x06011DFE RID: 73214 RVA: 0x004EA7DA File Offset: 0x004E89DA
	private static void OpenFeedBackMainView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FeedbackRewardMainView, null, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PersonalOptionView, null);
	}

	// Token: 0x06011DFF RID: 73215 RVA: 0x004EA7FD File Offset: 0x004E89FD
	private static void ChangeName()
	{
		ControllerBase<CommonInputViewController>.Instance.OpenSetRoleNameInputView();
	}

	// Token: 0x06011E00 RID: 73216 RVA: 0x004EA809 File Offset: 0x004E8A09
	private static void ChangeSign()
	{
		ControllerBase<CommonInputViewController>.Instance.OpenPersonalSignInputView();
	}

	// Token: 0x06011E01 RID: 73217 RVA: 0x004EA815 File Offset: 0x004E8A15
	private static void SetBirth()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10084))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("BirthdaySet_OpenCondition_Tips", Array.Empty<object>());
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalBirthView, null, null);
	}

	// Token: 0x06011E02 RID: 73218 RVA: 0x004EA84E File Offset: 0x004E8A4E
	private static void LookCard()
	{
		PersonalOptionController.CheckOpenLookCardView().Forget();
	}

	// Token: 0x06011E03 RID: 73219 RVA: 0x004EA85C File Offset: 0x004E8A5C
	private static UniTask CheckOpenLookCardView()
	{
		PersonalOptionController.<CheckOpenLookCardView>d__18 <CheckOpenLookCardView>d__;
		<CheckOpenLookCardView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckOpenLookCardView>d__.<>1__state = -1;
		<CheckOpenLookCardView>d__.<>t__builder.Start<PersonalOptionController.<CheckOpenLookCardView>d__18>(ref <CheckOpenLookCardView>d__);
		return <CheckOpenLookCardView>d__.<>t__builder.Task;
	}

	// Token: 0x06011E04 RID: 73220 RVA: 0x004EA897 File Offset: 0x004E8A97
	private static void ChangeRemark()
	{
		ControllerBase<CommonInputViewController>.Instance.OpenSetPlayerRemarkNameInputView();
	}

	// Token: 0x06011E05 RID: 73221 RVA: 0x004EA8A4 File Offset: 0x004E8AA4
	public PersonalInfoData GetPersonalData()
	{
		PersonalInfoData personalInfoData = new PersonalInfoData();
		FriendData selectedPlayerOrItemInstance = ModelBase<FriendModel>.Instance.GetSelectedPlayerOrItemInstance(null, null);
		if (selectedPlayerOrItemInstance != null)
		{
			personalInfoData.RoleShowList = selectedPlayerOrItemInstance.RoleShowList;
			personalInfoData.CardShowList = selectedPlayerOrItemInstance.CardShowList;
			personalInfoData.CurCardId = new int?(selectedPlayerOrItemInstance.CurCard);
			personalInfoData.Birthday = selectedPlayerOrItemInstance.Birthday;
			personalInfoData.IsBirthdayDisplay = selectedPlayerOrItemInstance.IsBirthdayDisplay;
			personalInfoData.CardDataList = selectedPlayerOrItemInstance.CardUnlockList;
			personalInfoData.Signature = selectedPlayerOrItemInstance.Signature;
			personalInfoData.HeadPhotoId = new int?(selectedPlayerOrItemInstance.PlayerHeadPhoto);
			personalInfoData.IsOtherData = true;
			personalInfoData.Name = selectedPlayerOrItemInstance.PlayerName;
			personalInfoData.PlayerId = selectedPlayerOrItemInstance.PlayerId;
			personalInfoData.Level = selectedPlayerOrItemInstance.PlayerLevel;
			personalInfoData.WorldLevel = selectedPlayerOrItemInstance.WorldLevel;
			personalInfoData.CurPlayerTitleId = new int?(selectedPlayerOrItemInstance.PlayerTitleId);
			personalInfoData.CurPlayerTitleLevel = new int?(selectedPlayerOrItemInstance.PlayerTitleStarLevel);
			personalInfoData.Sex = selectedPlayerOrItemInstance.PlayerSex;
			personalInfoData.ThirdUserId = selectedPlayerOrItemInstance.GetSdkUserId();
			personalInfoData.ThirdOnlineId = selectedPlayerOrItemInstance.GetSdkOnlineId();
		}
		else
		{
			PlayerDetails playerDetails = ModelBase<OnlineModel>.Instance.CachePlayerData.PlayerDetails;
			List<global::RoleShowEntry> list = new List<global::RoleShowEntry>();
			foreach (Aki.Protocol.RoleShowEntry roleShowEntry in playerDetails.RoleShowList)
			{
				global::RoleShowEntry item = new global::RoleShowEntry(roleShowEntry.RoleId, roleShowEntry.Level);
				list.Add(item);
			}
			personalInfoData.RoleShowList = list;
			personalInfoData.CardShowList = playerDetails.CardShowList.ToList<int>();
			personalInfoData.CurCardId = new int?(playerDetails.CurCard);
			personalInfoData.Birthday = playerDetails.Birthday;
			personalInfoData.IsBirthdayDisplay = playerDetails.DisplayBirthday;
			personalInfoData.CardDataList = ModelBase<OnlineModel>.Instance.CachePlayerData.CardUnlockList;
			personalInfoData.Signature = (playerDetails.Signature ?? "");
			personalInfoData.HeadPhotoId = new int?(playerDetails.HeadId);
			personalInfoData.IsOtherData = true;
			personalInfoData.Name = (playerDetails.Name ?? "");
			personalInfoData.PlayerId = playerDetails.PlayerId;
			personalInfoData.Level = playerDetails.Level;
			personalInfoData.WorldLevel = playerDetails.CurWorldLevel;
			string thirdUserId = Singleton<Info>.Instance.IsPs5Platform() ? playerDetails.PsnUserId : playerDetails.XboxUserId;
			personalInfoData.ThirdUserId = thirdUserId;
			string thirdOnlineId = Singleton<Info>.Instance.IsPs5Platform() ? playerDetails.PsnOnlineId : playerDetails.XboxOnlineId;
			personalInfoData.ThirdOnlineId = thirdOnlineId;
			personalInfoData.CurPlayerTitleId = new int?(playerDetails.PlayerTitleId);
			personalInfoData.CurPlayerTitleLevel = new int?(playerDetails.PlayerTitleExtraParam);
			personalInfoData.Sex = playerDetails.Sex;
		}
		return personalInfoData;
	}

	// Token: 0x04008BDE RID: 35806
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, Action> OptionMap;

	// Token: 0x02008754 RID: 34644
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402DC28 RID: 187432
		[Nullable(0)]
		public static Action <0>__OnClickShieldBtn;

		// Token: 0x0402DC29 RID: 187433
		[Nullable(0)]
		public static Action <1>__OnClickBlockBtn;

		// Token: 0x0402DC2A RID: 187434
		[Nullable(0)]
		public static Action <2>__OnClickDeleteBtn;

		// Token: 0x0402DC2B RID: 187435
		[Nullable(0)]
		public static Action <3>__OnClickReportBtn;

		// Token: 0x0402DC2C RID: 187436
		[Nullable(0)]
		public static Action <4>__CopyUidClick;

		// Token: 0x0402DC2D RID: 187437
		[Nullable(0)]
		public static Action <5>__ChangeHeadIcon;

		// Token: 0x0402DC2E RID: 187438
		[Nullable(0)]
		public static Action <6>__ChangeCard;

		// Token: 0x0402DC2F RID: 187439
		[Nullable(0)]
		public static Action <7>__ChangeName;

		// Token: 0x0402DC30 RID: 187440
		[Nullable(0)]
		public static Action <8>__ChangeSign;

		// Token: 0x0402DC31 RID: 187441
		[Nullable(0)]
		public static Action <9>__SetBirth;

		// Token: 0x0402DC32 RID: 187442
		[Nullable(0)]
		public static Action <10>__LookCard;

		// Token: 0x0402DC33 RID: 187443
		[Nullable(0)]
		public static Action <11>__ChangeRemark;

		// Token: 0x0402DC34 RID: 187444
		[Nullable(0)]
		public static Action <12>__ChangePlayerTitle;

		// Token: 0x0402DC35 RID: 187445
		[Nullable(0)]
		public static Action <13>__OpenPersonalRootView;

		// Token: 0x0402DC36 RID: 187446
		[Nullable(0)]
		public static Action <14>__OpenFeedBackMainView;
	}
}
