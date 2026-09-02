using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200185C RID: 6236
[NullableContext(2)]
[Nullable(0)]
public class SelectedFriendItem : GridProxyAbstract<int>
{
	// Token: 0x0600B29B RID: 45723 RVA: 0x002FB73C File Offset: 0x002F993C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickSelectedButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B29C RID: 45724 RVA: 0x002FB8A8 File Offset: 0x002F9AA8
	[NullableContext(1)]
	public void BindOnClicked(Action<int> onClickedCallback)
	{
		this.OnClickedCallback = onClickedCallback;
	}

	// Token: 0x0600B29D RID: 45725 RVA: 0x002FB8B4 File Offset: 0x002F9AB4
	protected override UniTask OnBeforeStartAsync()
	{
		SelectedFriendItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SelectedFriendItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B29E RID: 45726 RVA: 0x002FB8F7 File Offset: 0x002F9AF7
	protected override void OnBeforeDestroy()
	{
		this.OnClickedCallback = null;
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Destroy(null);
	}

	// Token: 0x0600B29F RID: 45727 RVA: 0x002FB911 File Offset: 0x002F9B11
	public override void Refresh(int playerId, bool isSelected, int gridIndex)
	{
		this.FriendData = ModelBase<FriendModel>.Instance.GetFriendById(playerId);
		if (this.FriendData == null)
		{
			return;
		}
		this.RefreshRoleTexture();
		this.RefreshName();
		this.RefreshLevel();
		this.RefreshOnlineState();
		this.RefreshShieldState();
		this.RefreshPlayerTitle();
	}

	// Token: 0x0600B2A0 RID: 45728 RVA: 0x002FB954 File Offset: 0x002F9B54
	private void RefreshRoleTexture()
	{
		int playerHeadPhoto = this.FriendData.PlayerHeadPhoto;
		UUITexture texture = base.GetTexture(1);
		PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(playerHeadPhoto, false);
		if (playerHeadData != null)
		{
			base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), texture, null);
		}
	}

	// Token: 0x0600B2A1 RID: 45729 RVA: 0x002FB994 File Offset: 0x002F9B94
	private void RefreshName()
	{
		UUIText text = base.GetText(2);
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.SetUIActive(false);
		}
		if (!string.IsNullOrEmpty(this.FriendData.FriendRemark))
		{
			text.SetText(this.FriendData.FriendRemark, true);
			if (text != null)
			{
				text.SetColor(ChatDefine.playerMarkNameColor);
				return;
			}
		}
		else
		{
			text.SetText(this.FriendData.PlayerName, true);
			if (text != null)
			{
				text.SetColor(ChatDefine.playerRealNameColor);
			}
		}
	}

	// Token: 0x0600B2A2 RID: 45730 RVA: 0x002FBA10 File Offset: 0x002F9C10
	private void RefreshLevel()
	{
		int playerLevel = this.FriendData.PlayerLevel;
		UUIText text = base.GetText(5);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelShow", new <>z__ReadOnlySingleElementList<object>(playerLevel));
	}

	// Token: 0x0600B2A3 RID: 45731 RVA: 0x002FBA4C File Offset: 0x002F9C4C
	private void RefreshOnlineState()
	{
		bool playerIsOnline = this.FriendData.PlayerIsOnline;
		UUIText text = base.GetText(4);
		FColor color = FColor.FromHex(playerIsOnline ? "00D67E" : "D64600");
		text.SetColor(color);
		if (playerIsOnline)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "FriendOnline", Array.Empty<object>());
			return;
		}
		if (this.FriendData.PlayerLastOfflineTime == 0L)
		{
			text.SetText("", true);
			return;
		}
		int offlineDay = this.FriendData.GetOfflineDay();
		string offlineTimeString = ControllerBase<FriendController>.Instance.GetOfflineTimeString(offlineDay);
		Singleton<LguiUtil>.Instance.SetLocalText(text, offlineTimeString, new <>z__ReadOnlySingleElementList<object>(offlineDay));
	}

	// Token: 0x0600B2A4 RID: 45732 RVA: 0x002FBAE9 File Offset: 0x002F9CE9
	private void RefreshShieldState()
	{
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x0600B2A5 RID: 45733 RVA: 0x002FBAF8 File Offset: 0x002F9CF8
	private void RefreshPlayerTitle()
	{
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem == null)
		{
			return;
		}
		titleItem.Refresh(new int?(this.FriendData.PlayerTitleId), new int?(this.FriendData.PlayerTitleStarLevel), new int?(this.FriendData.PlayerSex));
	}

	// Token: 0x0600B2A6 RID: 45734 RVA: 0x002FBB45 File Offset: 0x002F9D45
	private void OnClickSelectedButton()
	{
		Action<int> onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback(this.FriendData.PlayerId);
	}

	// Token: 0x04005480 RID: 21632
	private FriendData FriendData;

	// Token: 0x04005481 RID: 21633
	private PlayerTitleItem TitleItem;

	// Token: 0x04005482 RID: 21634
	private Action<int> OnClickedCallback;

	// Token: 0x02007C02 RID: 31746
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A5F0 RID: 173552
		public const int SelectedButton = 0;

		// Token: 0x0402A5F1 RID: 173553
		public const int RoleTexture = 1;

		// Token: 0x0402A5F2 RID: 173554
		public const int NameText = 2;

		// Token: 0x0402A5F3 RID: 173555
		public const int RemarkText = 3;

		// Token: 0x0402A5F4 RID: 173556
		public const int OnlineText = 4;

		// Token: 0x0402A5F5 RID: 173557
		public const int LevelText = 5;

		// Token: 0x0402A5F6 RID: 173558
		public const int ShieldItem = 6;

		// Token: 0x0402A5F7 RID: 173559
		public const int PlayerTitleItem = 7;
	}
}
