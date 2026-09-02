using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Scene.NewGacha.BP;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002444 RID: 9284
[NullableContext(2)]
[Nullable(0)]
public class PersonalRootView : UiViewBase
{
	// Token: 0x06011F1D RID: 73501 RVA: 0x004F0098 File Offset: 0x004EE298
	[NullableContext(1)]
	public PersonalRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011F1E RID: 73502 RVA: 0x004F00AC File Offset: 0x004EE2AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIText)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUISprite)),
			new ValueTuple<int, Type>(25, typeof(UUISprite)),
			new ValueTuple<int, Type>(26, typeof(UUIItem)),
			new ValueTuple<int, Type>(27, typeof(UUITexture)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(30, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCopyUidClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickDetailButton)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickSignButton)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickWorldLevelTipsButton)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnClickCloseButton)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnClickRenameButton)),
			new ValueTuple<int, Delegate>(16, new Action<EToggleState>(this.OnClickShowViewToggle)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickPersonalCardButton)),
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickExchangePreviewRoleButton)),
			new ValueTuple<int, Delegate>(29, new Action(this.OnClickThirdPartyButton))
		};
	}

	// Token: 0x06011F1F RID: 73503 RVA: 0x004F0488 File Offset: 0x004EE688
	private void OnClickThirdPartyButton()
	{
		string text;
		if (!this.PersonalInfoData.IsOtherData)
		{
			text = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyUserId();
		}
		else
		{
			PersonalInfoData personalInfoData = this.PersonalInfoData;
			text = ((personalInfoData != null) ? personalInfoData.ThirdUserId : null);
		}
		string text2 = text;
		if (!string.IsNullOrEmpty(text2))
		{
			ControllerBase<KuroSdkController>.Instance.OpenProfileCard(text2);
		}
	}

	// Token: 0x06011F20 RID: 73504 RVA: 0x004F04D4 File Offset: 0x004EE6D4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignChange, new Action(this.OnSignChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRoleShowListChange, new Action(this.OnRoleShowListChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCardChange, new Action(this.OnCardChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(this.OnBirthChange));
		Singleton<EventSystem>.Instance.Add(EEventName.CurWorldLevelChange, new Action(this.OnWorldLevelChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleChange, new Action(this.OnPlayerTitleChange));
	}

	// Token: 0x06011F21 RID: 73505 RVA: 0x004F05C4 File Offset: 0x004EE7C4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignChange, new Action(this.OnSignChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleShowListChange, new Action(this.OnRoleShowListChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCardChange, new Action(this.OnCardChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(this.OnBirthChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.CurWorldLevelChange, new Action(this.OnWorldLevelChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleChange, new Action(this.OnPlayerTitleChange));
	}

	// Token: 0x06011F22 RID: 73506 RVA: 0x004F06B1 File Offset: 0x004EE8B1
	protected override void OnBeforeCreate()
	{
		this.GachaSequence = new UiBehaviorGachaSequence();
		base.AddUiBehavior(this.GachaSequence);
	}

	// Token: 0x06011F23 RID: 73507 RVA: 0x004F06CC File Offset: 0x004EE8CC
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalRootView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalRootView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011F24 RID: 73508 RVA: 0x004F0710 File Offset: 0x004EE910
	protected override void OnStart()
	{
		this.RoleItemLayout = new GenericLayout<PersonalRoleDisplayMediumItem, PersonalRoleDisplayContentData>(base.GetHorizontalLayout(10), new Func<PersonalRoleDisplayMediumItem>(this.InitRoleItem), null, false, true);
		if (Singleton<Info>.Instance.IsHomeConsolePlatform())
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
			UUISprite sprite = base.GetSprite(24);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUISprite sprite2 = base.GetSprite(25);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(false);
			}
		}
		this.SetUid();
		this.SetWorldLevelText();
		this.SetPlayerLevelText();
		this.SetBirthText();
		this.SetPlayerName();
		this.SetPlayerSignature();
		this.SetPlayerIcon();
		this.RefreshCard();
		this.RefreshPlayerTitle();
		this.RefreshThirdPartyItem();
		this.RefreshButtonState();
		this.RefreshRedDot();
		base.GetExtendToggle(16).CanExecuteChange.Bind(new Func<bool>(this.OnCanShowToggleExecuteChange));
	}

	// Token: 0x06011F25 RID: 73509 RVA: 0x004F07EC File Offset: 0x004EE9EC
	protected override void OnHandleLoadScene()
	{
		this.OriginalCamera = ControllerBase<CameraController>.Instance.MainModel.CurrentCameraActor;
		this.SceneSequenceCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("SceneCamera1").Value, ECollectActorType.Default);
		this.GachaSequence.BindSceneSequenceCamera(this.SceneSequenceCamera);
		this.SceneEmptyCamera = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("personal").Value, ECollectActorType.Default);
		this.GachaSequence.BindEmptySequenceCamera(this.SceneEmptyCamera);
		this.UpdateInteractBp = (UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("UpdateInteractBP").Value, ECollectActorType.Default) as BP_UpdateInteract_C);
		this.UpdateInteractBp.SetTickableWhenPaused(true);
		this.GachaSequence.BindUpdateInteractBp(this.UpdateInteractBp);
	}

	// Token: 0x06011F26 RID: 73510 RVA: 0x004F08AC File Offset: 0x004EEAAC
	protected override void OnBeforeShow()
	{
		List<RoleShowEntry> roleShowList = this.PersonalInfoData.RoleShowList;
		List<int> list = new List<int>();
		foreach (RoleShowEntry roleShowEntry in roleShowList)
		{
			list.Add(roleShowEntry.Proto_RoleId);
		}
		this.RefreshRoleShowList(list, true, 0);
		this.BindRedDot();
	}

	// Token: 0x06011F27 RID: 73511 RVA: 0x004F0920 File Offset: 0x004EEB20
	[NullableContext(1)]
	protected void RefreshRoleShowList(List<int> roleIdList, bool isLastFrame, int releaseRoleIdAfterPlay = 0)
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("role_show_list_max_count");
		this.ShowRoleList.Clear();
		int num = 0;
		for (;;)
		{
			int num2 = num;
			int? num3 = intConfig;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			if (num < roleIdList.Count)
			{
				int item = roleIdList[num];
				this.ShowRoleList.Add(item);
			}
			else
			{
				this.ShowRoleList.Add(-1);
			}
			num++;
		}
		List<PersonalRoleDisplayContentData> list = new List<PersonalRoleDisplayContentData>();
		foreach (int roleId in this.ShowRoleList)
		{
			list.Add(new PersonalRoleDisplayContentData
			{
				RoleId = roleId,
				IfOtherData = this.PersonalInfoData.IsOtherData
			});
		}
		this.RoleItemLayout.RefreshByData(list, delegate
		{
			if (this.ShowRoleList.Count > 0 && this.ShowRoleList[0] > 0)
			{
				this.CurSelectRoleId = this.ShowRoleList[0];
				this.RoleItemLayout.SelectGridProxy(0, false);
				this.GachaSequence.PlayRoleSequence(this.CurSelectRoleId, releaseRoleIdAfterPlay);
				this.GetItem(15).SetUIActive(false);
				return;
			}
			this.GachaSequence.PlayEmptySequence();
			if (releaseRoleIdAfterPlay > 0)
			{
				this.GachaSequence.ReleaseLevelSequenceActor(releaseRoleIdAfterPlay);
			}
			this.GetItem(15).SetUIActive(true);
		}, false);
	}

	// Token: 0x06011F28 RID: 73512 RVA: 0x004F0A30 File Offset: 0x004EEC30
	protected override void OnBeforeHide()
	{
		this.UnBindRedDot();
	}

	// Token: 0x06011F29 RID: 73513 RVA: 0x004F0A38 File Offset: 0x004EEC38
	protected override void OnBeforeDestroy()
	{
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Destroy(null);
	}

	// Token: 0x06011F2A RID: 73514 RVA: 0x004F0A4C File Offset: 0x004EEC4C
	protected override void OnAfterDestroy()
	{
		ControllerBase<CameraController>.Instance.SetViewTarget(this.OriginalCamera, "PersonalRootView.OnBeforeDestroy", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
	}

	// Token: 0x06011F2B RID: 73515 RVA: 0x004F0A92 File Offset: 0x004EEC92
	[NullableContext(1)]
	private PersonalRoleDisplayMediumItem InitRoleItem()
	{
		PersonalRoleDisplayMediumItem personalRoleDisplayMediumItem = new PersonalRoleDisplayMediumItem();
		personalRoleDisplayMediumItem.BindClickItemCallBack(new Action<int>(this.OnRoleItemClick));
		return personalRoleDisplayMediumItem;
	}

	// Token: 0x06011F2C RID: 73516 RVA: 0x004F0AAC File Offset: 0x004EECAC
	private void SetWorldLevelText()
	{
		int num = this.PersonalInfoData.IsOtherData ? this.PersonalInfoData.WorldLevel : ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		if (num > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(8), "WorldLevelNum", new <>z__ReadOnlySingleElementList<object>(num));
		}
	}

	// Token: 0x06011F2D RID: 73517 RVA: 0x004F0B04 File Offset: 0x004EED04
	private void SetPlayerLevelText()
	{
		int? num = this.PersonalInfoData.IsOtherData ? new int?(this.PersonalInfoData.Level) : ModelBase<FunctionModel>.Instance.GetPlayerLevel();
		if (num != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "PlayerLevelNum", new <>z__ReadOnlySingleElementList<object>(num.Value));
		}
	}

	// Token: 0x06011F2E RID: 73518 RVA: 0x004F0B6C File Offset: 0x004EED6C
	private void SetBirthText()
	{
		UUIText text = base.GetText(7);
		if (this.PersonalInfoData.IsOtherData && !this.PersonalInfoData.IsBirthdayDisplay)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
			{
				"--",
				"--"
			}));
			return;
		}
		int birthday = this.PersonalInfoData.Birthday;
		double num = Math.Floor((double)birthday / 100.0);
		int date = birthday % 100;
		if (birthday == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
			{
				"--",
				"--"
			}));
			return;
		}
		string birthLocalText = ConfigBase<PersonalConfig>.Instance.GetBirthLocalText((int)num, EBirthDateType.MONTH);
		string birthLocalText2 = ConfigBase<PersonalConfig>.Instance.GetBirthLocalText(date, EBirthDateType.DAY);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "BirthDay", new <>z__ReadOnlyArray<object>(new object[]
		{
			birthLocalText,
			birthLocalText2
		}));
	}

	// Token: 0x06011F2F RID: 73519 RVA: 0x004F0C5C File Offset: 0x004EEE5C
	private void SetPlayerName()
	{
		string text = this.PersonalInfoData.IsOtherData ? this.PersonalInfoData.Name : ModelBase<FunctionModel>.Instance.GetPlayerName();
		if (!string.IsNullOrEmpty(text))
		{
			base.GetText(5).SetText(text, true);
		}
	}

	// Token: 0x06011F30 RID: 73520 RVA: 0x004F0CA4 File Offset: 0x004EEEA4
	private void SetPlayerSignature()
	{
		string signature = this.PersonalInfoData.Signature;
		bool isOtherData = this.PersonalInfoData.IsOtherData;
		UUIText text = base.GetText(6);
		if (string.IsNullOrEmpty(signature) && !isOtherData)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "ClickToSetSign", Array.Empty<object>());
			return;
		}
		text.SetText(signature, true);
	}

	// Token: 0x06011F31 RID: 73521 RVA: 0x004F0CFC File Offset: 0x004EEEFC
	private void SetPlayerIcon()
	{
		UUITexture texture = base.GetTexture(4);
		int value = this.PersonalInfoData.HeadPhotoId.Value;
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(value, false);
		if (playerHeadData != null)
		{
			base.SetTextureByPath(playerHeadData.GetRoleHeadIconCircle(), texture, null, null);
			texture.SetUIActive(true);
			return;
		}
		if (value > 0)
		{
			string roleHeadIcon = ConfigBase<RoleConfig>.Instance.GetRoleHeadIcon(value, false);
			base.SetRoleIcon(roleHeadIcon, texture, value, null, null);
		}
	}

	// Token: 0x06011F32 RID: 73522 RVA: 0x004F0D78 File Offset: 0x004EEF78
	private void SetUid()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "UserId", new <>z__ReadOnlySingleElementList<object>(this.PersonalInfoData.IsOtherData ? this.PersonalInfoData.PlayerId : ModelBase<FunctionModel>.Instance.PlayerId));
	}

	// Token: 0x06011F33 RID: 73523 RVA: 0x004F0DCC File Offset: 0x004EEFCC
	protected void RefreshCard()
	{
		int? curCardId = this.PersonalInfoData.CurCardId;
		if (curCardId == null)
		{
			return;
		}
		BackgroundCard? config = ConfigBackgroundCardById.GetConfig(curCardId.Value, true);
		if (config == null)
		{
			return;
		}
		base.SetTextureByPath(config.Value.FunctionViewCardPath, base.GetTexture(3), null, null);
	}

	// Token: 0x06011F34 RID: 73524 RVA: 0x004F0E30 File Offset: 0x004EF030
	private void RefreshThirdPartyItem()
	{
		KuroSdkController instance = ControllerBase<KuroSdkController>.Instance;
		bool? flag = (instance != null) ? new bool?(instance.NeedShowThirdPartyId()) : null;
		if (flag != null && flag.Value)
		{
			string value;
			if (!this.PersonalInfoData.IsOtherData)
			{
				value = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyUserId();
			}
			else
			{
				PersonalInfoData personalInfoData = this.PersonalInfoData;
				value = ((personalInfoData != null) ? personalInfoData.ThirdUserId : null);
			}
			bool flag2 = !string.IsNullOrEmpty(value);
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUITexture texture = base.GetTexture(27);
			if (texture != null)
			{
				texture.SetUIActive(flag2);
			}
			UUIItem item2 = base.GetItem(28);
			if (item2 != null)
			{
				item2.SetUIActive(!flag2);
			}
			UUIItem item3 = base.GetItem(30);
			if (item3 != null)
			{
				item3.SetUIActive(flag2);
			}
			if (flag2)
			{
				string text;
				if (!this.PersonalInfoData.IsOtherData)
				{
					text = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyOnlineId();
				}
				else
				{
					PersonalInfoData personalInfoData2 = this.PersonalInfoData;
					text = (((personalInfoData2 != null) ? personalInfoData2.ThirdOnlineId : null) ?? string.Empty);
				}
				string newText = text;
				UUIText text2 = base.GetText(22);
				if (text2 != null)
				{
					text2.SetText(newText, true);
				}
				string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Small);
				base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(27), null, null);
				string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
				UUIText text3 = base.GetText(22);
				if (text3 != null)
				{
					text3.SetColor(FColor.FromHex(thirdPartyTextColor));
				}
				bool uiactive = Singleton<Info>.Instance.IsXboxPlatform();
				UUIButtonComponent button = base.GetButton(29);
				if (button == null)
				{
					return;
				}
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem == null)
				{
					return;
				}
				uuiitem.SetUIActive(uiactive);
				return;
			}
			else
			{
				UUIText text4 = base.GetText(22);
				if (text4 == null)
				{
					return;
				}
				text4.SetText(string.Empty, true);
				return;
			}
		}
		else
		{
			UUIItem item4 = base.GetItem(30);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(21);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUITexture texture2 = base.GetTexture(27);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(28);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06011F35 RID: 73525 RVA: 0x004F1038 File Offset: 0x004EF238
	protected void RefreshButtonState()
	{
		bool flag = !this.PersonalInfoData.IsOtherData;
		base.GetButton(11).SetSelfInteractive(flag);
		base.GetButton(2).RootUIComp.Get().SetUIActive(flag);
		base.GetButton(12).RootUIComp.Get().SetUIActive(flag);
		base.GetButton(14).RootUIComp.Get().SetUIActive(flag);
		base.GetButton(18).RootUIComp.Get().SetUIActive(flag);
	}

	// Token: 0x06011F36 RID: 73526 RVA: 0x004F10D0 File Offset: 0x004EF2D0
	private void RefreshRedDot()
	{
		bool uiactive = ModelBase<PersonalModel>.Instance.CheckCanShowPersonalTip() && !this.PersonalInfoData.IsOtherData;
		base.GetItem(23).SetUIActive(uiactive);
	}

	// Token: 0x06011F37 RID: 73527 RVA: 0x004F1109 File Offset: 0x004EF309
	private void BindRedDot()
	{
		if (!this.PersonalInfoData.IsOtherData)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.PersonalCard, base.GetItem(19), null, 0);
		}
	}

	// Token: 0x06011F38 RID: 73528 RVA: 0x004F1131 File Offset: 0x004EF331
	private void UnBindRedDot()
	{
		if (!this.PersonalInfoData.IsOtherData)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.PersonalCard, base.GetItem(19), 0);
		}
	}

	// Token: 0x06011F39 RID: 73529 RVA: 0x004F1158 File Offset: 0x004EF358
	private void OnCopyUidClick()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int playerId = this.PersonalInfoData.PlayerId;
		if (id.GetValueOrDefault() == playerId & id != null)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CopiedMyUid", Array.Empty<object>());
		}
		else
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CopyOtherUID", Array.Empty<object>());
		}
		ULGUIBPLibrary.ClipBoardCopy(this.PersonalInfoData.PlayerId.ToString());
	}

	// Token: 0x06011F3A RID: 73530 RVA: 0x004F11CF File Offset: 0x004EF3CF
	protected void OnWorldLevelChange()
	{
		this.SetWorldLevelText();
	}

	// Token: 0x06011F3B RID: 73531 RVA: 0x004F11D7 File Offset: 0x004EF3D7
	protected void OnSignChange()
	{
		this.SetPlayerSignature();
	}

	// Token: 0x06011F3C RID: 73532 RVA: 0x004F11DF File Offset: 0x004EF3DF
	protected void OnNameChange()
	{
		this.SetPlayerName();
	}

	// Token: 0x06011F3D RID: 73533 RVA: 0x004F11E7 File Offset: 0x004EF3E7
	protected void OnBirthChange()
	{
		this.SetBirthText();
	}

	// Token: 0x06011F3E RID: 73534 RVA: 0x004F11EF File Offset: 0x004EF3EF
	protected void OnRoleShowListChange()
	{
	}

	// Token: 0x06011F3F RID: 73535 RVA: 0x004F11F1 File Offset: 0x004EF3F1
	protected void OnHeadIconChange(int roleId)
	{
		this.SetPlayerIcon();
	}

	// Token: 0x06011F40 RID: 73536 RVA: 0x004F11F9 File Offset: 0x004EF3F9
	protected void OnCardChange()
	{
		this.RefreshCard();
	}

	// Token: 0x06011F41 RID: 73537 RVA: 0x004F1201 File Offset: 0x004EF401
	protected void OnPlayerTitleChange()
	{
		this.RefreshPlayerTitle();
	}

	// Token: 0x06011F42 RID: 73538 RVA: 0x004F1209 File Offset: 0x004EF409
	protected void OnClickDetailButton()
	{
		if (this.PersonalInfoData.IsOtherData)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalOptionView, null, null);
	}

	// Token: 0x06011F43 RID: 73539 RVA: 0x004F122A File Offset: 0x004EF42A
	protected void OnClickSignButton()
	{
		if (this.PersonalInfoData.IsOtherData)
		{
			return;
		}
		ControllerBase<CommonInputViewController>.Instance.OpenPersonalSignInputView();
	}

	// Token: 0x06011F44 RID: 73540 RVA: 0x004F1244 File Offset: 0x004EF444
	protected void OnClickWorldLevelTipsButton()
	{
		ControllerBase<WorldLevelController>.Instance.OpenWorldLevelInfoView();
	}

	// Token: 0x06011F45 RID: 73541 RVA: 0x004F1250 File Offset: 0x004EF450
	protected void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x06011F46 RID: 73542 RVA: 0x004F1259 File Offset: 0x004EF459
	protected void OnClickRenameButton()
	{
		ControllerBase<CommonInputViewController>.Instance.OpenSetRoleNameInputView();
	}

	// Token: 0x06011F47 RID: 73543 RVA: 0x004F1268 File Offset: 0x004EF468
	protected void OnClickShowViewToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.UiViewSequence.StopPrevSequence(true, false);
			base.PlaySequence("CloseView", delegate
			{
				UUIItem item = base.GetItem(20);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
			}, false);
			return;
		}
		this.UiViewSequence.StopPrevSequence(true, false);
		base.PlaySequence("StartView", null, false);
		base.GetItem(20).SetUIActive(true);
	}

	// Token: 0x06011F48 RID: 73544 RVA: 0x004F12C7 File Offset: 0x004EF4C7
	protected bool OnCanShowToggleExecuteChange()
	{
		return !this.UiViewSequence.IsInSequence();
	}

	// Token: 0x06011F49 RID: 73545 RVA: 0x004F12D7 File Offset: 0x004EF4D7
	protected void OnClickPersonalCardButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalCardView, this.PersonalInfoData, null);
	}

	// Token: 0x06011F4A RID: 73546 RVA: 0x004F12F0 File Offset: 0x004EF4F0
	protected void OnClickExchangePreviewRoleButton()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.QuickRoleSelectView))
		{
			return;
		}
		ModelBase<PersonalModel>.Instance.SetPersonalTipState(false);
		this.RefreshRedDot();
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		QuickRoleSelectViewData quickRoleSelectViewData = new QuickRoleSelectViewData(EFilterSortGroupId.EditFormation, this.ShowRoleList.ToArray(), roleList.Cast<RoleDataBase>().ToList<RoleDataBase>());
		quickRoleSelectViewData.OnWaitLoadingConfirm = new Func<List<int>, UniTask>(this.OnWaitLoadingConfirmCallBack);
		quickRoleSelectViewData.OnRoleSelectFull = new Action(this.OnRoleSelectFull);
		quickRoleSelectViewData.OnBack = new Action(this.OnSelectBack);
		quickRoleSelectViewData.ShowDetailButton = false;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PersonalQuickRoleSelectView, quickRoleSelectViewData, null);
	}

	// Token: 0x06011F4B RID: 73547 RVA: 0x004F1398 File Offset: 0x004EF598
	[NullableContext(1)]
	protected UniTask OnWaitLoadingConfirmCallBack(List<int> roleIdList)
	{
		PersonalRootView.<OnWaitLoadingConfirmCallBack>d__58 <OnWaitLoadingConfirmCallBack>d__;
		<OnWaitLoadingConfirmCallBack>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnWaitLoadingConfirmCallBack>d__.<>4__this = this;
		<OnWaitLoadingConfirmCallBack>d__.roleIdList = roleIdList;
		<OnWaitLoadingConfirmCallBack>d__.<>1__state = -1;
		<OnWaitLoadingConfirmCallBack>d__.<>t__builder.Start<PersonalRootView.<OnWaitLoadingConfirmCallBack>d__58>(ref <OnWaitLoadingConfirmCallBack>d__);
		return <OnWaitLoadingConfirmCallBack>d__.<>t__builder.Task;
	}

	// Token: 0x06011F4C RID: 73548 RVA: 0x004F13E3 File Offset: 0x004EF5E3
	private void OnSelectBack()
	{
		this.RefreshRedDot();
	}

	// Token: 0x06011F4D RID: 73549 RVA: 0x004F13EC File Offset: 0x004EF5EC
	protected void OnRoleItemClick(int roleId)
	{
		if (this.CurSelectRoleId == roleId)
		{
			return;
		}
		if (!this.CheckClickInterval())
		{
			return;
		}
		this.CurSelectRoleId = roleId;
		int num = -1;
		for (int i = 0; i < this.ShowRoleList.Count; i++)
		{
			if (this.ShowRoleList[i] == roleId)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			this.RoleItemLayout.SelectGridProxy(num, false);
		}
		this.GachaSequence.PlayRoleSequence(roleId, 0);
		this.LastClickTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x06011F4E RID: 73550 RVA: 0x004F146C File Offset: 0x004EF66C
	protected bool CheckClickInterval()
	{
		int value = ConfigCommonParamById.GetIntConfig("IndividualizationRoleSwitchIntervalTime").Value;
		return Singleton<Time>.Instance.Now - this.LastClickTime >= (double)value;
	}

	// Token: 0x06011F4F RID: 73551 RVA: 0x004F14A4 File Offset: 0x004EF6A4
	protected void OnRoleSelectFull()
	{
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("DisplayFull_text", Array.Empty<object>());
	}

	// Token: 0x06011F50 RID: 73552 RVA: 0x004F14BC File Offset: 0x004EF6BC
	protected void RefreshPlayerTitle()
	{
		int? curPlayerTitleId = this.PersonalInfoData.CurPlayerTitleId;
		int? curPlayerTitleLevel = this.PersonalInfoData.CurPlayerTitleLevel;
		int sex = this.PersonalInfoData.Sex;
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Refresh(curPlayerTitleId, curPlayerTitleLevel, new int?(sex));
	}

	// Token: 0x04008CAA RID: 36010
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<PersonalRoleDisplayMediumItem, PersonalRoleDisplayContentData> RoleItemLayout;

	// Token: 0x04008CAB RID: 36011
	[Nullable(1)]
	private readonly List<int> ShowRoleList = new List<int>();

	// Token: 0x04008CAC RID: 36012
	private int CurSelectRoleId;

	// Token: 0x04008CAD RID: 36013
	private PersonalInfoData PersonalInfoData;

	// Token: 0x04008CAE RID: 36014
	private AActor SceneSequenceCamera;

	// Token: 0x04008CAF RID: 36015
	private AActor SceneEmptyCamera;

	// Token: 0x04008CB0 RID: 36016
	private AActor OriginalCamera;

	// Token: 0x04008CB1 RID: 36017
	private BP_UpdateInteract_C UpdateInteractBp;

	// Token: 0x04008CB2 RID: 36018
	private double LastClickTime;

	// Token: 0x04008CB3 RID: 36019
	private PlayerTitleItem TitleItem;

	// Token: 0x04008CB4 RID: 36020
	private UiBehaviorGachaSequence GachaSequence;

	// Token: 0x02008778 RID: 34680
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DCCB RID: 187595
		CopyIdButton,
		// Token: 0x0402DCCC RID: 187596
		IdText,
		// Token: 0x0402DCCD RID: 187597
		DetailButton,
		// Token: 0x0402DCCE RID: 187598
		CardTexture,
		// Token: 0x0402DCCF RID: 187599
		IconTexture,
		// Token: 0x0402DCD0 RID: 187600
		NameText,
		// Token: 0x0402DCD1 RID: 187601
		SignatureText,
		// Token: 0x0402DCD2 RID: 187602
		BirthText,
		// Token: 0x0402DCD3 RID: 187603
		WorldLevelText,
		// Token: 0x0402DCD4 RID: 187604
		PlayerLevelText,
		// Token: 0x0402DCD5 RID: 187605
		HorizontalLayout,
		// Token: 0x0402DCD6 RID: 187606
		SignButton,
		// Token: 0x0402DCD7 RID: 187607
		WorldLevelTipsButton,
		// Token: 0x0402DCD8 RID: 187608
		CloseButton,
		// Token: 0x0402DCD9 RID: 187609
		RenameButton,
		// Token: 0x0402DCDA RID: 187610
		EmptySequenceItem,
		// Token: 0x0402DCDB RID: 187611
		ShowViewToggle,
		// Token: 0x0402DCDC RID: 187612
		PersonalCardButton,
		// Token: 0x0402DCDD RID: 187613
		ExchangePreviewRoleButton,
		// Token: 0x0402DCDE RID: 187614
		PersonalRedDot,
		// Token: 0x0402DCDF RID: 187615
		ShowViewRoot,
		// Token: 0x0402DCE0 RID: 187616
		ThirdPartyItem,
		// Token: 0x0402DCE1 RID: 187617
		ThirdPartyText,
		// Token: 0x0402DCE2 RID: 187618
		ExchangePreviewRoleRedDot,
		// Token: 0x0402DCE3 RID: 187619
		CopyIdButtonSprite,
		// Token: 0x0402DCE4 RID: 187620
		CopyIdButtonHoldSprite,
		// Token: 0x0402DCE5 RID: 187621
		PlayerTitleItem,
		// Token: 0x0402DCE6 RID: 187622
		ThirdPartyTexture,
		// Token: 0x0402DCE7 RID: 187623
		PcItem,
		// Token: 0x0402DCE8 RID: 187624
		ThirdPartyButton,
		// Token: 0x0402DCE9 RID: 187625
		ThirdPartyRootItem
	}
}
