using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002345 RID: 9029
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OnlineHallItem : GridProxyAbstract<OnlineHallData>
{
	// Token: 0x060113B3 RID: 70579 RVA: 0x004BB5B4 File Offset: 0x004B97B4
	public OnlineHallItem(EUiViewName belongView)
	{
		this.BelongView = new EUiViewName?(belongView);
	}

	// Token: 0x060113B4 RID: 70580 RVA: 0x004BB5C8 File Offset: 0x004B97C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 26;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickApplyEnterBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickItemBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060113B5 RID: 70581 RVA: 0x004BB9BC File Offset: 0x004B9BBC
	protected override UniTask OnBeforeStartAsync()
	{
		OnlineHallItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<OnlineHallItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060113B6 RID: 70582 RVA: 0x004BBA00 File Offset: 0x004B9C00
	protected override void OnStart()
	{
		base.GetText(1).SetUIActive(false);
		base.GetSprite(19).SetUIActive(false);
		base.GetButton(16).RootUIComp.Get().SetUIActive(false);
		base.GetButton(14).RootUIComp.Get().SetUIActive(false);
		base.GetButton(15).RootUIComp.Get().SetUIActive(false);
		base.GetItem(18).SetUIActive(true);
		this.CountDown = base.GetText(11);
	}

	// Token: 0x060113B7 RID: 70583 RVA: 0x004BBA98 File Offset: 0x004B9C98
	protected override void OnBeforeDestroy()
	{
		this.OnlineHallData = null;
		this.BelongView = null;
		if (this.CountDownTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CountDownTimer);
		}
		this.CountDownTimer = null;
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Destroy(null);
	}

	// Token: 0x060113B8 RID: 70584 RVA: 0x004BBAEC File Offset: 0x004B9CEC
	private void UpdateCountDown(float _)
	{
		if (this.OnlineHallData == null)
		{
			if (this.CountDownTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CountDownTimer);
			}
			this.CountDownTimer = null;
			return;
		}
		if (this.OnlineHallData.ApplyTimeLeftTime > 0.0)
		{
			this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(this.OnlineHallData.ApplyTimeLeftTime), true);
			return;
		}
		this.ShowApplyBtn(true);
		if (this.CountDownTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.CountDownTimer);
		}
		this.CountDownTimer = null;
	}

	// Token: 0x060113B9 RID: 70585 RVA: 0x004BBB84 File Offset: 0x004B9D84
	[NullableContext(1)]
	public override void Refresh(OnlineHallData data, bool isSelected, int gridIndex)
	{
		this.OnlineHallData = data;
		if (this.OnlineHallData.ApplyTimeLeftTime > 0.0)
		{
			this.ShowApplyBtn(false);
			this.CountDownTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.UpdateCountDown), 100f, 1f, null, null, true);
		}
		else
		{
			this.ShowApplyBtn(true);
		}
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(data.HeadId, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(3), null, null);
		}
		bool flag = ModelBase<FriendModel>.Instance.IsMyFriend(data.PlayerId);
		UUIText text = base.GetText(0);
		if (flag)
		{
			FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(data.PlayerId);
			string text2 = (friendById != null) ? friendById.FriendRemark : null;
			if (text2 != null && text2 != "")
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "NameMark", new <>z__ReadOnlySingleElementList<object>(text2));
			}
			else
			{
				text.SetText(data.Name, true);
			}
		}
		else
		{
			text.SetText(data.Name, true);
		}
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.Refresh(new int?(data.PlayerTitleId), new int?(data.PlayerTitleStarLevel), new int?(data.Sex));
		}
		UUIText text3 = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Lv.");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Level);
		text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text4 = base.GetText(7);
		if (data.Signature == null || data.Signature == "")
		{
			base.GetItem(20).SetUIActive(false);
		}
		else
		{
			text4.SetText(data.Signature, true);
			base.GetItem(20).SetUIActive(true);
		}
		UUIItem item = base.GetItem(5);
		UUIItem item2 = base.GetItem(6);
		EPlayerCount playerCount = (EPlayerCount)data.PlayerCount;
		if (playerCount != EPlayerCount.TwoPlayer)
		{
			if (playerCount != EPlayerCount.ThreePlayer)
			{
				item.SetUIActive(false);
				item2.SetUIActive(false);
			}
			else
			{
				item.SetUIActive(true);
				item2.SetUIActive(true);
			}
		}
		else
		{
			item.SetUIActive(true);
			item2.SetUIActive(false);
		}
		int originWorldLevel = ModelBase<WorldLevelModel>.Instance.OriginWorldLevel;
		int enterDiff = ModelBase<OnlineModel>.Instance.EnterDiff;
		UUIInteractionGroup interactionGroup = base.GetInteractionGroup(8);
		UUIText text5 = base.GetText(9);
		if (data.WorldLevel > originWorldLevel + enterDiff)
		{
			interactionGroup.SetInteractable(false);
			int num = data.WorldLevel - enterDiff;
			Singleton<LguiUtil>.Instance.SetLocalText(text5, "ApplyBtnDisable", new <>z__ReadOnlySingleElementList<object>(num));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text5, "ApplyBtnEnable", Array.Empty<object>());
			interactionGroup.SetInteractable(true);
		}
		int playerCard = data.PlayerCard;
		if (playerCard > 0)
		{
			base.SetTextureByPath(ConfigBackgroundCardById.GetConfig(playerCard, true).Value.LongCardPath, base.GetTexture(21), null, null);
		}
		this.RefreshThirdPartyItem(data);
		this.RefreshPcItem(data);
	}

	// Token: 0x060113BA RID: 70586 RVA: 0x004BBE7C File Offset: 0x004BA07C
	private void ShowApplyBtn(bool show)
	{
		base.GetButton(4).RootUIComp.Get().SetUIActive(show);
		base.GetItem(12).SetUIActive(show);
		base.GetItem(10).SetUIActive(!show);
	}

	// Token: 0x060113BB RID: 70587 RVA: 0x004BBEC4 File Offset: 0x004BA0C4
	private void OnClickApplyEnterBtn()
	{
		if (this.BelongView == EUiViewName.OnlineWorldHallView)
		{
			ControllerBase<OnlineController>.Instance.ApplyJoinWorldRequest(this.OnlineHallData.PlayerId, (ModelBase<OnlineModel>.Instance.ShowFriend || ModelBase<OnlineModel>.Instance.HallViewIsShowSearching) ? WorldEnterWay.QueryJoin : WorldEnterWay.LobbyJoin);
		}
		else
		{
			ControllerBase<OnlineController>.Instance.ApplyJoinWorldRequest(this.OnlineHallData.PlayerId, WorldEnterWay.QueryJoin);
		}
		this.OnlineHallData.SetApplyTime(Singleton<TimeUtil>.Instance.GetServerTime() + (double)ModelBase<OnlineModel>.Instance.ApplyCd);
		this.ShowApplyBtn(false);
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown(this.OnlineHallData.ApplyTimeLeftTime), true);
		this.CountDownTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.UpdateCountDown), 100f, 1f, null, null, true);
	}

	// Token: 0x060113BC RID: 70588 RVA: 0x004BBFB4 File Offset: 0x004BA1B4
	private void OnClickItemBtn()
	{
		ModelBase<OnlineModel>.Instance.CachePlayerData = this.OnlineHallData;
		int playerId = this.OnlineHallData.PlayerId;
		ControllerBase<FriendController>.Instance.RequestPlayerCurrentDeactivationState(playerId, delegate(bool deactivation)
		{
			if (deactivation)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("PlayerDeleteSelf", null);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new <>z__ReadOnlySingleElementList<object>(localTextNew), null, null, null, null, null, false, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineProcessView, null, null);
		});
	}

	// Token: 0x060113BD RID: 70589 RVA: 0x004BC008 File Offset: 0x004BA208
	[NullableContext(1)]
	private void RefreshThirdPartyItem(OnlineHallData data)
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			bool flag = (Singleton<Info>.Instance.IsPs5Platform() ? data.PlayerDetails.PsnUserId : data.PlayerDetails.XboxUserId) != "";
			UUITexture texture = base.GetTexture(23);
			if (texture != null)
			{
				texture.SetUIActive(flag);
			}
			UUIText text = base.GetText(24);
			if (text != null)
			{
				text.SetUIActive(flag);
			}
			if (flag)
			{
				string text2 = Singleton<Info>.Instance.IsPs5Platform() ? data.PlayerDetails.PsnOnlineId : data.PlayerDetails.XboxOnlineId;
				UUIText text3 = base.GetText(24);
				if (text3 != null)
				{
					text3.SetText(text2 ?? "", true);
				}
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(23), null, null);
			string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
			UUIText text4 = base.GetText(24);
			if (text4 == null)
			{
				return;
			}
			text4.SetColor(FColor.FromHex(thirdPartyTextColor));
			return;
		}
		else
		{
			UUITexture texture2 = base.GetTexture(23);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIText text5 = base.GetText(24);
			if (text5 == null)
			{
				return;
			}
			text5.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060113BE RID: 70590 RVA: 0x004BC154 File Offset: 0x004BA354
	[NullableContext(1)]
	private void RefreshPcItem(OnlineHallData data)
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			if ((Singleton<Info>.Instance.IsPs5Platform() ? data.PlayerDetails.PsnUserId : data.PlayerDetails.XboxUserId) != "")
			{
				UUIItem item = base.GetItem(25);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(25);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
				return;
			}
		}
		else
		{
			UUIItem item3 = base.GetItem(25);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x04008775 RID: 34677
	private const int TICK_INTERVAL_TIME = 100;

	// Token: 0x04008776 RID: 34678
	private OnlineHallData OnlineHallData;

	// Token: 0x04008777 RID: 34679
	private EUiViewName? BelongView;

	// Token: 0x04008778 RID: 34680
	private UUIText CountDown;

	// Token: 0x04008779 RID: 34681
	private TimerHandle CountDownTimer;

	// Token: 0x0400877A RID: 34682
	private PlayerTitleItem TitleItem;

	// Token: 0x02008652 RID: 34386
	[NullableContext(0)]
	private enum EOnlineHallItem
	{
		// Token: 0x0402D6D5 RID: 186069
		PlayerName,
		// Token: 0x0402D6D6 RID: 186070
		TipText,
		// Token: 0x0402D6D7 RID: 186071
		Level,
		// Token: 0x0402D6D8 RID: 186072
		RoleHead,
		// Token: 0x0402D6D9 RID: 186073
		ApplyEnterBtn,
		// Token: 0x0402D6DA RID: 186074
		PlayerCount2,
		// Token: 0x0402D6DB RID: 186075
		PlayerCount3,
		// Token: 0x0402D6DC RID: 186076
		Sign,
		// Token: 0x0402D6DD RID: 186077
		ApplyEnterBtnInteraction,
		// Token: 0x0402D6DE RID: 186078
		ApplyEnterBtnText,
		// Token: 0x0402D6DF RID: 186079
		ApplyCountDown,
		// Token: 0x0402D6E0 RID: 186080
		ApplyCountDownText,
		// Token: 0x0402D6E1 RID: 186081
		TeamCount,
		// Token: 0x0402D6E2 RID: 186082
		TeamItem,
		// Token: 0x0402D6E3 RID: 186083
		OperationBtn,
		// Token: 0x0402D6E4 RID: 186084
		ExitBtn,
		// Token: 0x0402D6E5 RID: 186085
		KickOutBtn,
		// Token: 0x0402D6E6 RID: 186086
		PlayerSprite,
		// Token: 0x0402D6E7 RID: 186087
		HallItem,
		// Token: 0x0402D6E8 RID: 186088
		NetStateSprite,
		// Token: 0x0402D6E9 RID: 186089
		SignTeamItem,
		// Token: 0x0402D6EA RID: 186090
		PlayerTextureBg,
		// Token: 0x0402D6EB RID: 186091
		BtnPlayerHead,
		// Token: 0x0402D6EC RID: 186092
		ThirdPartyTexture,
		// Token: 0x0402D6ED RID: 186093
		ThirdPartyText,
		// Token: 0x0402D6EE RID: 186094
		PcItem,
		// Token: 0x0402D6EF RID: 186095
		PlayerTitleItem
	}
}
