using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200234E RID: 9038
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class OnlineTeamItem : GridProxyAbstract<OnlineTeamData>
{
	// Token: 0x0601143B RID: 70715 RVA: 0x004BF0A8 File Offset: 0x004BD2A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
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
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
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
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickOperationBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickKickOutBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action(this.OnClickItemBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickExitBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601143C RID: 70716 RVA: 0x004BF3FC File Offset: 0x004BD5FC
	protected override UniTask OnBeforeStartAsync()
	{
		OnlineTeamItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<OnlineTeamItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601143D RID: 70717 RVA: 0x004BF43F File Offset: 0x004BD63F
	protected override void OnStart()
	{
		base.GetItem(18).SetUIActive(false);
		base.GetItem(13).SetUIActive(true);
		this.AddEventListener();
	}

	// Token: 0x0601143E RID: 70718 RVA: 0x004BF463 File Offset: 0x004BD663
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, ENetPingState>(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
	}

	// Token: 0x0601143F RID: 70719 RVA: 0x004BF481 File Offset: 0x004BD681
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshPlayerPing, new Action<int, ENetPingState>(this.OnRefreshPlayerPing));
	}

	// Token: 0x06011440 RID: 70720 RVA: 0x004BF49F File Offset: 0x004BD69F
	protected override void OnBeforeDestroy()
	{
		this.RemoveEventListener();
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.Destroy(null);
		}
		this.TitleItem = null;
	}

	// Token: 0x06011441 RID: 70721 RVA: 0x004BF4C0 File Offset: 0x004BD6C0
	[NullableContext(1)]
	public override void Refresh(OnlineTeamData data, bool isSelected, int gridIndex)
	{
		base.GetButton(22).RootUIComp.Get().SetRaycastTarget(data.PlayerId != ModelBase<FunctionModel>.Instance.PlayerId);
		this.OnlineTeamData = data;
		bool uiactive = false;
		bool uiactive2 = false;
		bool uiactive3 = false;
		bool uiactive4 = false;
		if (data.IsSelf)
		{
			uiactive3 = true;
		}
		else if (!ModelBase<FriendModel>.Instance.IsMyFriend(data.PlayerId))
		{
			uiactive = ModelBase<OnlineModel>.Instance.GetIsMyTeam();
			uiactive2 = true;
		}
		else if (this.IsApplyFriend)
		{
			uiactive = ModelBase<OnlineModel>.Instance.GetIsMyTeam();
		}
		else
		{
			uiactive = ModelBase<OnlineModel>.Instance.GetIsMyTeam();
			uiactive4 = true;
		}
		base.GetButton(16).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(14).RootUIComp.Get().SetUIActive(uiactive2);
		base.GetButton(15).RootUIComp.Get().SetUIActive(uiactive3);
		base.GetText(1).SetUIActive(uiactive4);
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
				text.SetText(data.GetRawName(), true);
			}
		}
		else
		{
			text.SetText(data.GetRawName(), true);
		}
		UUIText text3 = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
		defaultInterpolatedStringHandler.AppendLiteral("Lv.");
		defaultInterpolatedStringHandler.AppendFormatted<int>(data.Level);
		text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text4 = base.GetText(7);
		if (data.Signature == null || data.Signature == "")
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text4, "DefaultSign", Array.Empty<object>());
			base.GetItem(20).SetUIActive(true);
		}
		else
		{
			text4.SetText(data.Signature, true);
			base.GetItem(20).SetUIActive(true);
		}
		string inString;
		if (data.PlayerId == ModelBase<CreatureModel>.Instance.GetPlayerId())
		{
			inString = "SP_Online{0}PIcon_Self";
		}
		else
		{
			inString = "SP_Online{0}PIcon";
		}
		UUISprite sprite = base.GetSprite(17);
		string resourceId = StringUtils.Format(inString, new string[]
		{
			this.OnlineTeamData.PlayerNumber.ToString()
		});
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		if (string.IsNullOrEmpty(resourcePath))
		{
			sprite.SetUIActive(false);
		}
		else
		{
			sprite.SetUIActive(true);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}
		this.RefreshPlayerPingItem(data.PingState);
		int curCard = data.PlayerDetails.CurCard;
		if (curCard > 0)
		{
			base.SetTextureByPath(ConfigBackgroundCardById.GetConfig(curCard, true).Value.LongCardPath, base.GetTexture(21), null, null);
		}
		this.RefreshPlayStationItem(data.GetOnlineName());
		this.RefreshPcItem(data.GetOnlineName());
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Refresh(new int?(data.PlayerTitleId), new int?(data.PlayerTitleStarLevel), new int?(data.Sex));
	}

	// Token: 0x06011442 RID: 70722 RVA: 0x004BF840 File Offset: 0x004BDA40
	private void RefreshPcItem(string onlineName)
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			if (onlineName != null && onlineName != "")
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

	// Token: 0x06011443 RID: 70723 RVA: 0x004BF8C4 File Offset: 0x004BDAC4
	private void RefreshPlayStationItem(string onlineName)
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		if (((instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null).GetValueOrDefault())
		{
			bool flag = onlineName != "" && onlineName != null;
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
				string newText = onlineName ?? "";
				UUIText text2 = base.GetText(24);
				if (text2 != null)
				{
					text2.SetText(newText, true);
				}
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(23), null, null);
			string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
			UUIText text3 = base.GetText(24);
			if (text3 == null)
			{
				return;
			}
			text3.SetColor(FColor.FromHex(thirdPartyTextColor));
			return;
		}
		else
		{
			UUITexture texture2 = base.GetTexture(23);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIText text4 = base.GetText(24);
			if (text4 == null)
			{
				return;
			}
			text4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06011444 RID: 70724 RVA: 0x004BF9D2 File Offset: 0x004BDBD2
	private void OnClickOperationBtn()
	{
		ControllerBase<FriendController>.Instance.RequestFriendApplyAddSend(this.OnlineTeamData.PlayerId, FriendApplyWay.RecentlyTeam);
		this.IsApplyFriend = true;
	}

	// Token: 0x06011445 RID: 70725 RVA: 0x004BF9F4 File Offset: 0x004BDBF4
	private void OnClickExitBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew;
		if (ModelBase<OnlineModel>.Instance.GetIsMyTeam())
		{
			confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuitOnlineWorldAndReduceTeam);
		}
		else
		{
			confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.QuitOnlineWorld);
		}
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<OnlineController>.Instance.LeaveWorldTeamRequest(this.OnlineTeamData.PlayerId, null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011446 RID: 70726 RVA: 0x004BFA44 File Offset: 0x004BDC44
	private void OnClickKickOutBtn()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KnockPlayerOnlineWorld);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<OnlineController>.Instance.KickWorldTeamRequest(this.OnlineTeamData.PlayerId);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06011447 RID: 70727 RVA: 0x004BFA7D File Offset: 0x004BDC7D
	private void OnClickItemBtn()
	{
		ModelBase<OnlineModel>.Instance.CachePlayerData = this.OnlineTeamData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.OnlineProcessView, null, null);
	}

	// Token: 0x06011448 RID: 70728 RVA: 0x004BFAA0 File Offset: 0x004BDCA0
	private void OnRefreshPlayerPing(int playerId, ENetPingState ping)
	{
		if (this.OnlineTeamData.PlayerId != playerId)
		{
			return;
		}
		this.RefreshPlayerPingItem(ping);
	}

	// Token: 0x06011449 RID: 70729 RVA: 0x004BFAB8 File Offset: 0x004BDCB8
	private void RefreshPlayerPingItem(ENetPingState ping)
	{
		UUISprite sprite = base.GetSprite(19);
		sprite.SetUIActive(true);
		if (ping == ENetPingState.Unknown)
		{
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			string path = (instance != null) ? instance.GetResourcePath("SP_SignalUnknown") : null;
			this.SetSpriteByPath(path, sprite, false, null, null);
			return;
		}
		if (ping == ENetPingState.Great)
		{
			UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
			string path2 = (instance2 != null) ? instance2.GetResourcePath("SP_SignalGreat") : null;
			this.SetSpriteByPath(path2, sprite, false, null, null);
			return;
		}
		if (ping == ENetPingState.Good)
		{
			UiResourceConfig instance3 = ConfigBase<UiResourceConfig>.Instance;
			string path3 = (instance3 != null) ? instance3.GetResourcePath("SP_SignalGood") : null;
			this.SetSpriteByPath(path3, sprite, false, null, null);
			return;
		}
		if (ping == ENetPingState.Poor)
		{
			UiResourceConfig instance4 = ConfigBase<UiResourceConfig>.Instance;
			string path4 = (instance4 != null) ? instance4.GetResourcePath("SP_SignalPoor") : null;
			this.SetSpriteByPath(path4, sprite, false, null, null);
		}
	}

	// Token: 0x0400879C RID: 34716
	private OnlineTeamData OnlineTeamData;

	// Token: 0x0400879D RID: 34717
	private bool IsApplyFriend;

	// Token: 0x0400879E RID: 34718
	private PlayerTitleItem TitleItem;

	// Token: 0x02008668 RID: 34408
	[NullableContext(0)]
	private enum EOnlineTeamItem
	{
		// Token: 0x0402D76E RID: 186222
		PlayerName,
		// Token: 0x0402D76F RID: 186223
		TipText,
		// Token: 0x0402D770 RID: 186224
		Level,
		// Token: 0x0402D771 RID: 186225
		RoleHead,
		// Token: 0x0402D772 RID: 186226
		ApplyEnterBtn,
		// Token: 0x0402D773 RID: 186227
		PlayerCount2,
		// Token: 0x0402D774 RID: 186228
		PlayerCount3,
		// Token: 0x0402D775 RID: 186229
		Sign,
		// Token: 0x0402D776 RID: 186230
		ApplyEnterBtnInteraction,
		// Token: 0x0402D777 RID: 186231
		ApplyEnterBtnText,
		// Token: 0x0402D778 RID: 186232
		ApplyCountDown,
		// Token: 0x0402D779 RID: 186233
		ApplyCountDownText,
		// Token: 0x0402D77A RID: 186234
		TeamCount,
		// Token: 0x0402D77B RID: 186235
		TeamItem,
		// Token: 0x0402D77C RID: 186236
		OperationBtn,
		// Token: 0x0402D77D RID: 186237
		ExitBtn,
		// Token: 0x0402D77E RID: 186238
		KickOutBtn,
		// Token: 0x0402D77F RID: 186239
		PlayerSprite,
		// Token: 0x0402D780 RID: 186240
		HallItem,
		// Token: 0x0402D781 RID: 186241
		NetStateSprite,
		// Token: 0x0402D782 RID: 186242
		SignTeamItem,
		// Token: 0x0402D783 RID: 186243
		PlayerTextureBg,
		// Token: 0x0402D784 RID: 186244
		BtnPlayerHead,
		// Token: 0x0402D785 RID: 186245
		ThirdPartyTexture,
		// Token: 0x0402D786 RID: 186246
		ThirdPartyText,
		// Token: 0x0402D787 RID: 186247
		PcItem,
		// Token: 0x0402D788 RID: 186248
		PlayerTitleItem
	}
}
