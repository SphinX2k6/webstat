using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002341 RID: 9025
[NullableContext(2)]
[Nullable(0)]
public class OnlineChallengeApplyView : UiTickViewBase
{
	// Token: 0x06011397 RID: 70551 RVA: 0x004BA6A4 File Offset: 0x004B88A4
	[NullableContext(1)]
	public OnlineChallengeApplyView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011398 RID: 70552 RVA: 0x004BA6C4 File Offset: 0x004B88C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHandleBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickCancelBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06011399 RID: 70553 RVA: 0x004BA900 File Offset: 0x004B8B00
	protected override void OnStart()
	{
		base.GetButton(8).GetRootComponent().SetUIActive(true);
		this.CountDown = base.GetText(5);
		this.CountDownBar = base.GetSprite(6);
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			this.CountDownNumber = (float)ModelBase<OnlineModel>.Instance.ApplyCd;
			this.CountDownNumberMax = (float)ModelBase<OnlineModel>.Instance.ApplyCd;
			this.RefreshViewInInstance();
			return;
		}
		int value = ConfigCommonParamById.GetIntConfig("match_confirm_time_out_seconds").Value;
		this.CountDownNumber = (float)value;
		this.CountDownNumberMax = (float)value;
		this.RefreshViewOutInstance();
	}

	// Token: 0x0601139A RID: 70554 RVA: 0x004BA997 File Offset: 0x004B8B97
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshSuggestChallengePlayerInfo, new Action(this.OnRefreshSuggestChallengePlayerInfo));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStart));
	}

	// Token: 0x0601139B RID: 70555 RVA: 0x004BA9D1 File Offset: 0x004B8BD1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshSuggestChallengePlayerInfo, new Action(this.OnRefreshSuggestChallengePlayerInfo));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.PlotNetworkStart));
	}

	// Token: 0x0601139C RID: 70556 RVA: 0x004BAA0C File Offset: 0x004B8C0C
	protected override void OnTick(float delta)
	{
		if (this.IsViewClose)
		{
			return;
		}
		this.CountDownNumber -= delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
		if (this.CountDownNumber <= 0f)
		{
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.TeamMatchAcceptInviteRequest(false, false);
			}
			else
			{
				ControllerBase<OnlineController>.Instance.ReceiveRechallengeRequest(false, false);
			}
			base.CloseMe(null);
			this.IsViewClose = true;
			return;
		}
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown((double)this.CountDownNumber), true);
		this.CountDownBar.SetFillAmount(this.CountDownNumber / this.CountDownNumberMax);
	}

	// Token: 0x0601139D RID: 70557 RVA: 0x004BAAB4 File Offset: 0x004B8CB4
	private void RefreshViewInInstance()
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		UUIText text = base.GetText(7);
		item.SetUIActive(true);
		item2.SetUIActive(false);
		if (!ModelBase<SceneTeamModel>.Instance.IsAllDid())
		{
			if (ModelBase<CreatureModel>.Instance.IsMyWorld())
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "SuggestContinueChallenge", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "InviteContinueChallenge", Array.Empty<object>());
			}
		}
		else if (ModelBase<CreatureModel>.Instance.IsMyWorld())
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "SuggestChallengeAgain", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "InviteChallengeAgain", Array.Empty<object>());
		}
		int challengeApplyPlayerId = ModelBase<OnlineModel>.Instance.ChallengeApplyPlayerId;
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(challengeApplyPlayerId);
		if (currentTeamListById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiPlayerTeam;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "未找到发起邀请的玩家";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerId：", challengeApplyPlayerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		base.GetText(1).SetText(currentTeamListById.Name, true);
		this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown((double)this.CountDownNumber), true);
		this.CountDownBar.SetFillAmount(this.CountDownNumber / this.CountDownNumberMax);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentTeamListById.HeadId, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(0), null, null);
		}
		this.RefreshThirdPartyItem(currentTeamListById.ThirdPartyOnlineId, currentTeamListById.ThirdPartyUserId);
		this.RefreshPcItem(currentTeamListById.ThirdPartyOnlineId);
	}

	// Token: 0x0601139E RID: 70558 RVA: 0x004BAC48 File Offset: 0x004B8E48
	private void RefreshThirdPartyItem(string onlineId, string userId)
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag = userId != null && userId != "";
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				string newText = onlineId ?? "";
				UUIText text = base.GetText(17);
				if (text != null)
				{
					text.SetText(newText, true);
				}
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(18), null, null);
			string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
			UUIText text2 = base.GetText(17);
			if (text2 == null)
			{
				return;
			}
			text2.SetColor(FColor.FromHex(thirdPartyTextColor));
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0601139F RID: 70559 RVA: 0x004BAD0C File Offset: 0x004B8F0C
	private void RefreshPcItem(string onlineId)
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			bool flag = onlineId != null && onlineId != "";
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!flag);
			return;
		}
		else
		{
			UUIItem item2 = base.GetItem(15);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060113A0 RID: 70560 RVA: 0x004BAD80 File Offset: 0x004B8F80
	private void RefreshViewOutInstance()
	{
		UUIItem item = base.GetItem(3);
		UUIItem item2 = base.GetItem(4);
		item.SetUIActive(true);
		item2.SetUIActive(false);
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "TeamLeaderInviteToInstance", Array.Empty<object>());
		UUIText text2 = base.GetText(7);
		int instanceId = ModelBase<InstanceDungeonModel>.Instance.GetInstanceId();
		string text3 = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.MapName, null);
		text3 += ModelBase<OnlineModel>.Instance.GetMultiInstanceRecommendLevelText(instanceId);
		text2.SetText(text3, true);
		int ownerId = ModelBase<OnlineModel>.Instance.OwnerId;
		OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(ownerId);
		if (currentTeamListById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiPlayerTeam;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "未找到发起邀请的玩家";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("playerId：", ownerId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			UUIItem item3 = base.GetItem(16);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(15);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
		else
		{
			this.CountDown.SetText(Singleton<TimeUtil>.Instance.GetCoolDown((double)this.CountDownNumber), true);
			this.CountDownBar.SetFillAmount(this.CountDownNumber / this.CountDownNumberMax);
			PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentTeamListById.HeadId, false);
			if (playerHeadData != null)
			{
				base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), base.GetTexture(0), null, null);
			}
			UUIItem item5 = base.GetItem(16);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(15);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060113A1 RID: 70561 RVA: 0x004BAF20 File Offset: 0x004B9120
	private void OnClickHandleBtn()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(ModelBase<PlayerInfoModel>.Instance.GetId().Value);
			EContinuingChallenge econtinuingChallenge = EContinuingChallenge.Accept;
			if ((continuingChallengeConfirmState.GetValueOrDefault() == econtinuingChallenge & continuingChallengeConfirmState != null) && ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				ControllerBase<OnlineController>.Instance.InviteRechallengeRequest();
				return;
			}
			ControllerBase<OnlineController>.Instance.ReceiveRechallengeRequest(true, false);
		}
		else
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamMatchAcceptInviteRequest(true, false);
		}
		base.CloseMe(null);
	}

	// Token: 0x060113A2 RID: 70562 RVA: 0x004BAFA4 File Offset: 0x004B91A4
	private void OnClickCancelBtn()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.TeamMatchAcceptInviteRequest(false, true);
		}
		else
		{
			ControllerBase<OnlineController>.Instance.ReceiveRechallengeRequest(false, true);
		}
		base.CloseMe(null);
	}

	// Token: 0x060113A3 RID: 70563 RVA: 0x004BAFD4 File Offset: 0x004B91D4
	private void OnRefreshSuggestChallengePlayerInfo()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			this.CountDownNumber = (float)ModelBase<OnlineModel>.Instance.ApplyCd;
			this.RefreshViewInInstance();
			return;
		}
		int value = ConfigCommonParamById.GetIntConfig("match_confirm_time_out_seconds").Value;
		this.CountDownNumber = (float)value;
		this.RefreshViewOutInstance();
	}

	// Token: 0x060113A4 RID: 70564 RVA: 0x004BB026 File Offset: 0x004B9226
	[NullableContext(1)]
	private void PlotNetworkStart(PlotInfo plotInfo)
	{
		base.CloseMe(null);
	}

	// Token: 0x04008767 RID: 34663
	private float CountDownNumber = -1f;

	// Token: 0x04008768 RID: 34664
	private float CountDownNumberMax = -1f;

	// Token: 0x04008769 RID: 34665
	private UUIText CountDown;

	// Token: 0x0400876A RID: 34666
	private UUISprite CountDownBar;

	// Token: 0x0400876B RID: 34667
	private bool IsViewClose;

	// Token: 0x0200864F RID: 34383
	[NullableContext(0)]
	private enum EOnlineChallengeApplyView
	{
		// Token: 0x0402D6BD RID: 186045
		RoleTexture,
		// Token: 0x0402D6BE RID: 186046
		PlayerName,
		// Token: 0x0402D6BF RID: 186047
		HandleBtn,
		// Token: 0x0402D6C0 RID: 186048
		ApplySprite,
		// Token: 0x0402D6C1 RID: 186049
		MoreSprite,
		// Token: 0x0402D6C2 RID: 186050
		CountDown,
		// Token: 0x0402D6C3 RID: 186051
		CountDownProgressBar,
		// Token: 0x0402D6C4 RID: 186052
		MultipleApplyText,
		// Token: 0x0402D6C5 RID: 186053
		CancelBtn,
		// Token: 0x0402D6C6 RID: 186054
		TexturePc = 15,
		// Token: 0x0402D6C7 RID: 186055
		ThirdPartyItem,
		// Token: 0x0402D6C8 RID: 186056
		ThirdPartyText,
		// Token: 0x0402D6C9 RID: 186057
		ThirdPartyTexture
	}
}
