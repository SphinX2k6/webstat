using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002430 RID: 9264
[NullableContext(1)]
[Nullable(0)]
public class PersonalOptionView : UiViewBase
{
	// Token: 0x06011E9E RID: 73374 RVA: 0x004ED677 File Offset: 0x004EB877
	public PersonalOptionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011E9F RID: 73375 RVA: 0x004ED680 File Offset: 0x004EB880
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUITexture)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUITexture)),
			new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(19, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(18, new Action(this.OnClickXboxButton))
		};
	}

	// Token: 0x06011EA0 RID: 73376 RVA: 0x004ED880 File Offset: 0x004EBA80
	private void OnClickXboxButton()
	{
		string thirdPartyUserId = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyUserId();
		if (!string.IsNullOrEmpty(thirdPartyUserId))
		{
			ControllerBase<KuroSdkController>.Instance.OpenProfileCard(thirdPartyUserId);
		}
	}

	// Token: 0x06011EA1 RID: 73377 RVA: 0x004ED8AC File Offset: 0x004EBAAC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBirthChange, new Action(this.OnBirthChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSignChange, new Action(this.OnSignChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPlayerTitleChange, new Action(this.RefreshPlayerTitle));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011EA2 RID: 73378 RVA: 0x004ED964 File Offset: 0x004EBB64
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBirthChange, new Action(this.OnBirthChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHeadIconChange, new Action<int>(this.OnHeadIconChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.OnNameChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSignChange, new Action(this.OnSignChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerTitleChange, new Action(this.RefreshPlayerTitle));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCardChange, new Action(this.OnCardChange));
	}

	// Token: 0x06011EA3 RID: 73379 RVA: 0x004EDA1C File Offset: 0x004EBC1C
	protected override UniTask OnBeforeStartAsync()
	{
		PersonalOptionView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PersonalOptionView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011EA4 RID: 73380 RVA: 0x004EDA60 File Offset: 0x004EBC60
	protected override void OnStart()
	{
		this.HeadPhotoItem = new PlayerHeadItem(base.GetItem(0).GetOwner());
		this.RefreshOptions();
		this.RefreshPlayerName();
		this.RefreshSign();
		int? playerLevel = ModelBase<FunctionModel>.Instance.GetPlayerLevel();
		if (playerLevel != null)
		{
			base.GetText(5).SetText(playerLevel.ToString(), true);
		}
		this.RefreshIcon();
		this.RefreshPlayStationItem();
		base.GetText(4).SetText("", true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "SetPersonalData", Array.Empty<object>());
		this.RefreshCard();
	}

	// Token: 0x06011EA5 RID: 73381 RVA: 0x004EDB04 File Offset: 0x004EBD04
	private ILayoutItem<PersonalOptionItem> InitPersonalOptionItem(object optionId, UUIItem uiItem, int index)
	{
		PersonalOptionItem personalOptionItem = new PersonalOptionItem(uiItem);
		personalOptionItem.Refresh((int)optionId, false, index);
		return new LayoutItem<PersonalOptionItem>
		{
			Key = index,
			Value = personalOptionItem
		};
	}

	// Token: 0x06011EA6 RID: 73382 RVA: 0x004EDB3E File Offset: 0x004EBD3E
	protected override void OnAfterShow()
	{
	}

	// Token: 0x06011EA7 RID: 73383 RVA: 0x004EDB40 File Offset: 0x004EBD40
	private void RefreshIcon()
	{
		int headIconId = ModelBase<PlayerInfoModel>.Instance.GetHeadIconId();
		this.HeadPhotoItem.RefreshByRoleId(headIconId);
	}

	// Token: 0x06011EA8 RID: 73384 RVA: 0x004EDB64 File Offset: 0x004EBD64
	private void RefreshPlayStationItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			string thirdPartyUserId = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyUserId();
			string thirdPartyOnlineId = ModelBase<PlayerInfoModel>.Instance.GetThirdPartyOnlineId();
			bool flag = thirdPartyUserId != "";
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(flag && Singleton<Info>.Instance.IsPs5Platform());
			}
			UUITexture texture = base.GetTexture(15);
			if (texture != null)
			{
				texture.SetUIActive(flag && Singleton<Info>.Instance.IsPs5Platform());
			}
			if (flag && Singleton<Info>.Instance.IsPs5Platform())
			{
				UUIText text = base.GetText(13);
				if (text != null)
				{
					text.SetText(thirdPartyOnlineId, true);
				}
			}
			UUIButtonComponent button = base.GetButton(18);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(flag && Singleton<Info>.Instance.IsXboxPlatform());
				}
			}
			if (flag && Singleton<Info>.Instance.IsXboxPlatform())
			{
				UUIText text2 = base.GetText(19);
				if (text2 != null)
				{
					text2.SetText(thirdPartyOnlineId, true);
				}
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(12);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUITexture texture2 = base.GetTexture(15);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x06011EA9 RID: 73385 RVA: 0x004EDCB8 File Offset: 0x004EBEB8
	private void RefreshPlayerName()
	{
		string playerName = ModelBase<FunctionModel>.Instance.GetPlayerName();
		if (playerName != null)
		{
			base.GetText(2).SetText(playerName, true);
		}
	}

	// Token: 0x06011EAA RID: 73386 RVA: 0x004EDCE4 File Offset: 0x004EBEE4
	private void RefreshSign()
	{
		string signature = ModelBase<PersonalModel>.Instance.GetSignature();
		UUIText text = base.GetText(11);
		if (signature != null && signature != "")
		{
			text.SetText(signature, true);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(text, "EmptySign", Array.Empty<object>());
	}

	// Token: 0x06011EAB RID: 73387 RVA: 0x004EDD34 File Offset: 0x004EBF34
	private void RefreshCard()
	{
		int curCardId = ModelBase<PersonalModel>.Instance.GetCurCardId();
		BackgroundCard? config = ConfigBackgroundCardById.GetConfig(curCardId, true);
		if (config != null)
		{
			base.SetTextureByPath(config.Value.FunctionViewCardPath, base.GetTexture(17), null, null);
		}
	}

	// Token: 0x06011EAC RID: 73388 RVA: 0x004EDD84 File Offset: 0x004EBF84
	private void OnBirthChange()
	{
		this.RefreshOptions();
	}

	// Token: 0x06011EAD RID: 73389 RVA: 0x004EDD8C File Offset: 0x004EBF8C
	private void OnHeadIconChange(int roleId)
	{
		this.RefreshIcon();
	}

	// Token: 0x06011EAE RID: 73390 RVA: 0x004EDD94 File Offset: 0x004EBF94
	private void OnNameChange()
	{
		this.RefreshPlayerName();
	}

	// Token: 0x06011EAF RID: 73391 RVA: 0x004EDD9C File Offset: 0x004EBF9C
	private void OnSignChange()
	{
		this.RefreshSign();
	}

	// Token: 0x06011EB0 RID: 73392 RVA: 0x004EDDA4 File Offset: 0x004EBFA4
	private void RefreshPlayerTitle()
	{
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Refresh(new int?(ModelBase<PersonalModel>.Instance.GetDressedPlayerTitleId()), new int?(ModelBase<PersonalModel>.Instance.GetDressedPlayerTitleLevel()), new int?(ModelBase<PersonalModel>.Instance.GetSex()));
	}

	// Token: 0x06011EB1 RID: 73393 RVA: 0x004EDDE3 File Offset: 0x004EBFE3
	private void OnCardChange()
	{
		this.RefreshCard();
	}

	// Token: 0x06011EB2 RID: 73394 RVA: 0x004EDDEC File Offset: 0x004EBFEC
	protected void RefreshOptions()
	{
		List<int> list = new List<int>();
		list.Add(6);
		if (ModelBase<FunctionModel>.Instance.IsOpen(10061))
		{
			list.Add(7);
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10082))
		{
			list.Add(14);
		}
		list.Add(8);
		list.Add(9);
		list.Add(10);
		if (!Singleton<Info>.Instance.IsHomeConsolePlatform())
		{
			list.Add(11);
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10060))
		{
			list.Add(15);
		}
		if (this.PersonalOptionItemLayout == null)
		{
			this.PersonalOptionItemLayout = new GenericLayoutNew<PersonalOptionItem>(base.GetGridLayout(9), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PersonalOptionItem>(this.InitPersonalOptionItem), null);
		}
		this.PersonalOptionItemLayout.ClearChildren();
		list.Sort(delegate(int a, int b)
		{
			PersonalTips value = ConfigPersonalTipsById.GetConfig(a, true).Value;
			PersonalTips value2 = ConfigPersonalTipsById.GetConfig(b, true).Value;
			return value.Sort - value2.Sort;
		});
		this.PersonalOptionItemLayout.RebuildLayoutByDataNew<int>(list, null);
	}

	// Token: 0x06011EB3 RID: 73395 RVA: 0x004EDEE8 File Offset: 0x004EC0E8
	protected override void OnBeforeDestroy()
	{
		if (this.PersonalOptionItemLayout != null)
		{
			this.PersonalOptionItemLayout.ClearChildren();
			this.PersonalOptionItemLayout = null;
		}
		if (this.TitleItem != null)
		{
			this.TitleItem.Destroy(null);
			this.TitleItem = null;
		}
	}

	// Token: 0x06011EB4 RID: 73396 RVA: 0x004EDF20 File Offset: 0x004EC120
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		int num = 3;
		if (ModelBase<FunctionModel>.Instance.IsOpen(10061))
		{
			num++;
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10082))
		{
			num++;
		}
		UUIItem grid = this.PersonalOptionItemLayout.GetGrid(num);
		if (grid != null)
		{
			return new UUIItem[]
			{
				grid,
				grid
			};
		}
		return null;
	}

	// Token: 0x04008C60 RID: 35936
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<PersonalOptionItem> PersonalOptionItemLayout;

	// Token: 0x04008C61 RID: 35937
	[Nullable(2)]
	private PlayerHeadItem HeadPhotoItem;

	// Token: 0x04008C62 RID: 35938
	[Nullable(2)]
	private PlayerTitleItem TitleItem;
}
