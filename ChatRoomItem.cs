using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001858 RID: 6232
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ChatRoomItem : GridProxyAbstract<ChatRoom>
{
	// Token: 0x0600B274 RID: 45684 RVA: 0x002FA8AC File Offset: 0x002F8AAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickFriendExtendsToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B275 RID: 45685 RVA: 0x002FAA5C File Offset: 0x002F8C5C
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(4);
		this.PlayerHeadItem = new PlayerHeadItem(item.GetOwner());
	}

	// Token: 0x0600B276 RID: 45686 RVA: 0x002FAA82 File Offset: 0x002F8C82
	protected override void OnBeforeDestroy()
	{
		this.FriendData = null;
		this.ChatRoomType = null;
		this.OwnerId = 0;
	}

	// Token: 0x0600B277 RID: 45687 RVA: 0x002FAA9E File Offset: 0x002F8C9E
	public override void Clear()
	{
	}

	// Token: 0x0600B278 RID: 45688 RVA: 0x002FAAA0 File Offset: 0x002F8CA0
	private void OnClickFriendExtendsToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<EChatRoomType, int> onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback(this.ChatRoomType.Value, this.OwnerId);
	}

	// Token: 0x0600B279 RID: 45689 RVA: 0x002FAAC8 File Offset: 0x002F8CC8
	[NullableContext(1)]
	public override void Refresh(ChatRoom chatRoom, bool isSelected, int gridIndex)
	{
		base.GetItem(6).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetSprite(5).SetIsGray(false);
		PrivateChatRoom privateChatRoom = chatRoom as PrivateChatRoom;
		if (privateChatRoom != null)
		{
			int targetPlayerId = privateChatRoom.GetTargetPlayerId();
			this.FriendData = ModelBase<FriendModel>.Instance.GetFriendById(targetPlayerId);
			if (this.FriendData == null)
			{
				return;
			}
			this.ChatRoomType = new EChatRoomType?(EChatRoomType.Private);
			this.OwnerId = this.FriendData.PlayerId;
			this.RefreshIsOnline(privateChatRoom);
		}
		else if (chatRoom is TeamChatRoom)
		{
			this.FriendData = null;
			this.ChatRoomType = new EChatRoomType?(EChatRoomType.Team);
			this.OwnerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		}
		else if (chatRoom is WorldChatRoom)
		{
			this.FriendData = null;
			this.ChatRoomType = new EChatRoomType?(EChatRoomType.World);
			this.OwnerId = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		}
		bool isShowRedDot = chatRoom.GetIsShowRedDot();
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(isShowRedDot);
		}
		this.RefreshPlayerTexture();
		this.RefreshPlayerName();
		this.RefreshMuteItem();
		this.RefreshThirdPartyItem();
		this.RefreshPcItem();
		if (isSelected)
		{
			this.SetToggleState(EToggleState.ETT_Checked);
			return;
		}
		this.SetToggleState(EToggleState.ETT_UnChecked);
	}

	// Token: 0x0600B27A RID: 45690 RVA: 0x002FAC00 File Offset: 0x002F8E00
	private void RefreshThirdPartyItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag;
			if (this.FriendData != null)
			{
				FriendData friendData = this.FriendData;
				flag = !string.IsNullOrEmpty((friendData != null) ? friendData.GetSdkUserId() : null);
			}
			else
			{
				flag = false;
			}
			bool uiactive = flag;
			UUITexture texture = base.GetTexture(8);
			if (texture != null)
			{
				texture.SetUIActive(uiactive);
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(8), null, null);
			return;
		}
		UUITexture texture2 = base.GetTexture(8);
		if (texture2 == null)
		{
			return;
		}
		texture2.SetUIActive(false);
	}

	// Token: 0x0600B27B RID: 45691 RVA: 0x002FAC8C File Offset: 0x002F8E8C
	private void RefreshPcItem()
	{
		if (this.ChatRoomType == null || this.ChatRoomType.GetValueOrDefault() != EChatRoomType.Private)
		{
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			bool flag;
			if (this.FriendData != null)
			{
				FriendData friendData = this.FriendData;
				flag = !string.IsNullOrEmpty((friendData != null) ? friendData.GetSdkUserId() : null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			UUIItem item2 = base.GetItem(9);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag2);
			return;
		}
		else
		{
			UUIItem item3 = base.GetItem(9);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600B27C RID: 45692 RVA: 0x002FAD24 File Offset: 0x002F8F24
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(EToggleState.ETT_Checked);
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600B27D RID: 45693 RVA: 0x002FAD3F File Offset: 0x002F8F3F
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(EToggleState.ETT_UnChecked);
	}

	// Token: 0x0600B27E RID: 45694 RVA: 0x002FAD48 File Offset: 0x002F8F48
	public void RefreshIsOnline(PrivateChatRoom privateChatRoom)
	{
		UUIItem item = base.GetItem(6);
		bool flag = privateChatRoom.IsOnline();
		item.SetUIActive(!flag);
		base.GetSprite(5).SetIsGray(!flag);
		base.GetItem(7).SetUIActive(flag);
		this.PlayerHeadItem.SetIsGray(!flag);
	}

	// Token: 0x0600B27F RID: 45695 RVA: 0x002FAD98 File Offset: 0x002F8F98
	public void RefreshPlayerTexture()
	{
		UUISprite sprite = base.GetSprite(5);
		if (this.ChatRoomType.GetValueOrDefault() == EChatRoomType.Team)
		{
			sprite.SetUIActive(true);
			this.PlayerHeadItem.SetActive(false);
			return;
		}
		if (this.ChatRoomType.GetValueOrDefault() == EChatRoomType.World)
		{
			sprite.SetUIActive(true);
			this.PlayerHeadItem.SetActive(false);
			return;
		}
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		FriendData friendData = this.FriendData;
		int? num = (friendData != null) ? new int?(friendData.PlayerId) : ModelBase<PlayerInfoModel>.Instance.GetId();
		if (num == null)
		{
			this.PlayerHeadItem.SetActive(false);
			return;
		}
		ChatPlayerData chatPlayerData = ModelBase<ChatModel>.Instance.GetChatPlayerData(num.Value);
		int? num2 = (chatPlayerData != null) ? new int?(chatPlayerData.GetPlayerIcon()) : null;
		if (num2 != null)
		{
			this.PlayerHeadItem.RefreshByRoleIdUseCard(num2.Value);
			return;
		}
		this.PlayerHeadItem.RefreshByPlayerId(num.Value, true);
	}

	// Token: 0x0600B280 RID: 45696 RVA: 0x002FAE8C File Offset: 0x002F908C
	private void RefreshPlayerName()
	{
		UUIText text = base.GetText(1);
		if (this.ChatRoomType.GetValueOrDefault() == EChatRoomType.Team)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "CurrentTeam", Array.Empty<object>());
			return;
		}
		if (this.ChatRoomType.GetValueOrDefault() == EChatRoomType.World)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "CurrentTeam", Array.Empty<object>());
			return;
		}
		string friendRemark = this.FriendData.FriendRemark;
		if (StringUtils.IsEmpty(friendRemark))
		{
			string playerName = this.FriendData.PlayerName;
			text.SetText(playerName, true);
			return;
		}
		text.SetText(friendRemark, true);
	}

	// Token: 0x0600B281 RID: 45697 RVA: 0x002FAF1C File Offset: 0x002F911C
	public void RefreshMuteItem()
	{
		UUIItem item = base.GetItem(3);
		if (this.FriendData == null)
		{
			item.SetUIActive(false);
			return;
		}
		bool uiactive = ModelBase<ChatModel>.Instance.IsInMute(this.FriendData.PlayerId);
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600B282 RID: 45698 RVA: 0x002FAF5E File Offset: 0x002F915E
	[NullableContext(1)]
	public void BindOnClicked(Action<EChatRoomType, int> onClicked)
	{
		this.OnClickedCallback = onClicked;
	}

	// Token: 0x0600B283 RID: 45699 RVA: 0x002FAF68 File Offset: 0x002F9168
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		if (extendToggle.GetToggleState() == state)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x04005476 RID: 21622
	private EChatRoomType? ChatRoomType;

	// Token: 0x04005477 RID: 21623
	private int OwnerId;

	// Token: 0x04005478 RID: 21624
	private FriendData FriendData;

	// Token: 0x04005479 RID: 21625
	private PlayerHeadItem PlayerHeadItem;

	// Token: 0x0400547A RID: 21626
	private Action<EChatRoomType, int> OnClickedCallback;

	// Token: 0x02007BFE RID: 31742
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A5DD RID: 173533
		public const int FriendExtendsToggle = 0;

		// Token: 0x0402A5DE RID: 173534
		public const int FriendNameText = 1;

		// Token: 0x0402A5DF RID: 173535
		public const int RedDotItem = 2;

		// Token: 0x0402A5E0 RID: 173536
		public const int ShieldItem = 3;

		// Token: 0x0402A5E1 RID: 173537
		public const int PlayerHeadItem = 4;

		// Token: 0x0402A5E2 RID: 173538
		public const int TeamHeadSprite = 5;

		// Token: 0x0402A5E3 RID: 173539
		public const int OfflineState = 6;

		// Token: 0x0402A5E4 RID: 173540
		public const int OnlineState = 7;

		// Token: 0x0402A5E5 RID: 173541
		public const int ThirdPartyTexture = 8;

		// Token: 0x0402A5E6 RID: 173542
		public const int PcItem = 9;
	}
}
