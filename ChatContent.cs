using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200184D RID: 6221
[NullableContext(2)]
[Nullable(0)]
public class ChatContent : UiPanelBase
{
	// Token: 0x0600B1E8 RID: 45544 RVA: 0x002F6E3C File Offset: 0x002F503C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(12, typeof(UUIItem)));
		}
	}

	// Token: 0x0600B1E9 RID: 45545 RVA: 0x002F701C File Offset: 0x002F521C
	protected override UniTask OnBeforeStartAsync()
	{
		ChatContent.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ChatContent.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B1EA RID: 45546 RVA: 0x002F7060 File Offset: 0x002F5260
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(0);
		this.PlayerHeadItem = new PlayerHeadItem(item.GetOwner());
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.AddEvents();
	}

	// Token: 0x0600B1EB RID: 45547 RVA: 0x002F709D File Offset: 0x002F529D
	protected override void OnBeforeDestroy()
	{
		this.PlayerHeadItem = null;
		PlayerTitleItem titleItem = this.TitleItem;
		if (titleItem != null)
		{
			titleItem.Destroy(null);
		}
		this.RemoveEvents();
	}

	// Token: 0x0600B1EC RID: 45548 RVA: 0x002F70BE File Offset: 0x002F52BE
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnChatPlayerInfoChanged, new Action<int>(this.OnChatPlayerInfoChanged));
	}

	// Token: 0x0600B1ED RID: 45549 RVA: 0x002F70DC File Offset: 0x002F52DC
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChatPlayerInfoChanged, new Action<int>(this.OnChatPlayerInfoChanged));
	}

	// Token: 0x0600B1EE RID: 45550 RVA: 0x002F70FA File Offset: 0x002F52FA
	private void OnChatPlayerInfoChanged(int playerId)
	{
		this.RefreshPlayerTexture();
		this.RefreshPlayerNameAndTitle();
		this.PlayerStartAnimation();
	}

	// Token: 0x0600B1EF RID: 45551 RVA: 0x002F710E File Offset: 0x002F530E
	[NullableContext(1)]
	public void Refresh(ChatContentData data)
	{
		this.ChatContentData = data;
		this.RefreshPlayerTexture();
		this.RefreshContent();
		this.RefreshPlayerNameAndTitle();
		this.RefreshTimeText();
		this.RefreshThirdPartyItem();
	}

	// Token: 0x0600B1F0 RID: 45552 RVA: 0x002F7138 File Offset: 0x002F5338
	private void RefreshPlayerTexture()
	{
		PersonalModel instance = ModelBase<PersonalModel>.Instance;
		int num = (this.ChatContentData == null) ? 0 : this.ChatContentData.SenderPlayerId;
		PersonalInfoData personalInfoData = instance.GetPersonalInfoData();
		if (personalInfoData != null && personalInfoData.PlayerId == num)
		{
			this.PlayerHeadItem.RefreshByRoleIdUseCard(instance.GetHeadPhotoId());
			return;
		}
		ChatPlayerData chatPlayerData = ModelBase<ChatModel>.Instance.GetChatPlayerData(num);
		if (chatPlayerData == null)
		{
			return;
		}
		FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(num);
		if (friendById != null)
		{
			PlayerHeadItem playerHeadItem = this.PlayerHeadItem;
			if (playerHeadItem != null)
			{
				playerHeadItem.SetIsGray(!friendById.PlayerIsOnline);
			}
		}
		int? num2 = (chatPlayerData != null) ? new int?(chatPlayerData.GetPlayerIcon()) : null;
		if (num2 != null)
		{
			this.PlayerHeadItem.RefreshByRoleIdUseCard(num2.Value);
			return;
		}
		this.PlayerHeadItem.RefreshByPlayerId(num, true);
	}

	// Token: 0x0600B1F1 RID: 45553 RVA: 0x002F7208 File Offset: 0x002F5408
	private void RefreshContent()
	{
		UUIItem item = base.GetItem(5);
		UUIItem expressionItem = base.GetItem(3);
		if (this.ChatContentData.ContentType == ChatContentType.Text)
		{
			UUIText text = base.GetText(1);
			string content = this.ChatContentData.Content;
			text.SetText(content, true);
			item.SetUIActive(true);
			expressionItem.SetUIActive(false);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Chat;
			ELogAuthor author = ELogAuthor.LJQ;
			string message = "表情:" + this.ChatContentData.Content;
			string item2 = "expressionItemActive";
			UUIItem expressionItem2 = expressionItem;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item2, (expressionItem2 != null) ? new bool?(expressionItem2.IsUIActiveSelf()) : null);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.ChatContentData.ContentType == ChatContentType.Emoji)
		{
			UUITexture texture = base.GetTexture(4);
			int num = int.Parse(this.ChatContentData.Content);
			ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(num);
			if (expressionConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Chat;
				ELogAuthor author2 = ELogAuthor.LJQ;
				string message2 = "表情表找不到对应的Id";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("expressionId", num);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				item.SetUIActive(false);
				expressionItem.SetUIActive(false);
				return;
			}
			string expressionTexturePath = expressionConfig.Value.ExpressionTexturePath;
			base.SetTextureByPath(expressionTexturePath, texture, null, delegate(bool result)
			{
				expressionItem.SetUIActive(result);
			});
			item.SetUIActive(false);
		}
	}

	// Token: 0x0600B1F2 RID: 45554 RVA: 0x002F738C File Offset: 0x002F558C
	private void RefreshThirdPartyItem()
	{
		if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
		{
			string text = this.ChatContentData.ThirdOnlineId;
			PersonalModel instance = ModelBase<PersonalModel>.Instance;
			int senderPlayerId = this.ChatContentData.SenderPlayerId;
			PersonalInfoData personalInfoData = instance.GetPersonalInfoData();
			string value = null;
			if (personalInfoData != null && personalInfoData.PlayerId == senderPlayerId)
			{
				value = instance.GetThirdUserId();
			}
			else
			{
				FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(senderPlayerId);
				if (friendById != null)
				{
					value = friendById.GetSdkUserId();
					text = friendById.GetSdkOnlineId();
				}
			}
			bool flag = !string.IsNullOrEmpty(value) || !string.IsNullOrEmpty(text);
			UUITexture texture = base.GetTexture(9);
			if (texture != null)
			{
				texture.SetUIActive(flag);
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
			base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(9), null, null);
			UUIText text2 = base.GetText(10);
			if (text2 != null)
			{
				text2.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			if (flag)
			{
				UUIText text3 = base.GetText(10);
				if (text3 != null)
				{
					text3.SetText(text, true);
				}
				string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
				UUIText text4 = base.GetText(10);
				if (text4 == null)
				{
					return;
				}
				text4.SetColor(FColor.FromHex(thirdPartyTextColor));
				return;
			}
			else
			{
				UUIText text5 = base.GetText(10);
				if (text5 == null)
				{
					return;
				}
				text5.SetText("", true);
				return;
			}
		}
		else
		{
			UUITexture texture2 = base.GetTexture(9);
			if (texture2 != null)
			{
				texture2.SetUIActive(false);
			}
			UUIText text6 = base.GetText(10);
			if (text6 != null)
			{
				text6.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(8);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600B1F3 RID: 45555 RVA: 0x002F7544 File Offset: 0x002F5744
	private void RefreshPlayerNameAndTitle()
	{
		int num = (this.ChatContentData == null) ? 0 : this.ChatContentData.SenderPlayerId;
		UUIText text = base.GetText(6);
		EChatRoomType echatRoomType = (this.ChatContentData == null) ? EChatRoomType.None : this.ChatContentData.ChatRoomType;
		if (echatRoomType == EChatRoomType.Team || echatRoomType == EChatRoomType.World)
		{
			PersonalInfoData personalInfoData = ModelBase<PersonalModel>.Instance.GetPersonalInfoData();
			if (personalInfoData != null && personalInfoData.PlayerId == num)
			{
				text.SetText(personalInfoData.Name, true);
				PlayerTitleItem titleItem = this.TitleItem;
				if (titleItem != null)
				{
					titleItem.Refresh(personalInfoData.CurPlayerTitleId, personalInfoData.CurPlayerTitleLevel, new int?(personalInfoData.Sex));
				}
			}
			else
			{
				FriendData friendById = ModelBase<FriendModel>.Instance.GetFriendById(num);
				if (friendById != null)
				{
					string friendRemark = friendById.FriendRemark;
					if (!StringUtils.IsEmpty(friendRemark))
					{
						text.SetText(friendRemark, true);
					}
					else
					{
						text.SetText(friendById.PlayerName, true);
					}
					PlayerTitleItem titleItem2 = this.TitleItem;
					if (titleItem2 != null)
					{
						titleItem2.Refresh(new int?(friendById.PlayerTitleId), new int?(friendById.PlayerTitleStarLevel), new int?(friendById.PlayerSex));
					}
				}
				else
				{
					ChatPlayerData chatPlayerData = ModelBase<ChatModel>.Instance.GetChatPlayerData(num);
					if (chatPlayerData == null)
					{
						text.SetUIActive(false);
						PlayerTitleItem titleItem3 = this.TitleItem;
						if (titleItem3 == null)
						{
							return;
						}
						titleItem3.GetRootItem().SetUIActive(false);
						return;
					}
					else
					{
						text.SetText(chatPlayerData.GetPlayerName(), true);
						PlayerTitleItem titleItem4 = this.TitleItem;
						if (titleItem4 != null)
						{
							titleItem4.Refresh(new int?(chatPlayerData.GetPlayerTitleId()), chatPlayerData.GetPlayerTitleStarLevel(), new int?(chatPlayerData.GetSex()));
						}
					}
				}
			}
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
		PlayerTitleItem titleItem5 = this.TitleItem;
		if (titleItem5 == null)
		{
			return;
		}
		titleItem5.GetRootItem().SetUIActive(false);
	}

	// Token: 0x0600B1F4 RID: 45556 RVA: 0x002F76F0 File Offset: 0x002F58F0
	private void RefreshTimeText()
	{
		UUIText text = base.GetText(2);
		double timeStamp = this.ChatContentData.TimeStamp;
		double lastTimeStamp = this.ChatContentData.LastTimeStamp;
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (timeStamp - lastTimeStamp < ModelBase<ChatModel>.Instance.ShowTimeDifferent && lastTimeStamp != 0.0)
		{
			text.SetUIActive(false);
			return;
		}
		DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(timeStamp);
		DateTime dataFromTimeStamp2 = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(serverTime);
		if (dataFromTimeStamp.Year == dataFromTimeStamp2.Year && dataFromTimeStamp.Month == dataFromTimeStamp2.Month && dataFromTimeStamp.Day == dataFromTimeStamp2.Day)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "HourText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		if ((dataFromTimeStamp.Month != dataFromTimeStamp2.Month || dataFromTimeStamp.Day != dataFromTimeStamp2.Day) && dataFromTimeStamp.Year == dataFromTimeStamp2.Year)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "DayText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Month,
				dataFromTimeStamp.Day,
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		if (dataFromTimeStamp.Year != dataFromTimeStamp2.Year)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, "YearText", new <>z__ReadOnlyArray<object>(new object[]
			{
				dataFromTimeStamp.Year,
				dataFromTimeStamp.Month,
				dataFromTimeStamp.Day,
				dataFromTimeStamp.Hour,
				dataFromTimeStamp.Minute
			}));
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600B1F5 RID: 45557 RVA: 0x002F78F4 File Offset: 0x002F5AF4
	private void PlayerStartAnimation()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600B1F6 RID: 45558 RVA: 0x002F7921 File Offset: 0x002F5B21
	public UUIItem GetBtnItem()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return base.GetItem(12);
		}
		return null;
	}

	// Token: 0x04005455 RID: 21589
	private ChatContentData ChatContentData;

	// Token: 0x04005456 RID: 21590
	private PlayerHeadItem PlayerHeadItem;

	// Token: 0x04005457 RID: 21591
	private PlayerTitleItem TitleItem;

	// Token: 0x04005458 RID: 21592
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007BE9 RID: 31721
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A576 RID: 173430
		public const int PlayerHeadItem = 0;

		// Token: 0x0402A577 RID: 173431
		public const int ChatText = 1;

		// Token: 0x0402A578 RID: 173432
		public const int TimeText = 2;

		// Token: 0x0402A579 RID: 173433
		public const int ExpressionItem = 3;

		// Token: 0x0402A57A RID: 173434
		public const int ExpressionTexture = 4;

		// Token: 0x0402A57B RID: 173435
		public const int TextContentItem = 5;

		// Token: 0x0402A57C RID: 173436
		public const int PlayerNameText = 6;

		// Token: 0x0402A57D RID: 173437
		public const int PlayerTitleItem = 7;

		// Token: 0x0402A57E RID: 173438
		public const int ThirdPartyItem = 8;

		// Token: 0x0402A57F RID: 173439
		public const int ThirdPartyTexture = 9;

		// Token: 0x0402A580 RID: 173440
		public const int ThirdPartyText = 10;

		// Token: 0x0402A581 RID: 173441
		public const int PcItem = 11;

		// Token: 0x0402A582 RID: 173442
		public const int NavItem = 12;
	}
}
