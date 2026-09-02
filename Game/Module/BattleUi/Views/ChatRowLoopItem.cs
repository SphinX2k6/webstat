using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FFC RID: 24572
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ChatRowLoopItem : GridProxyAbstract<ChatRowData>
	{
		// Token: 0x0603DE26 RID: 253478 RVA: 0x00FC82F8 File Offset: 0x00FC64F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE27 RID: 253479 RVA: 0x00FC83C4 File Offset: 0x00FC65C4
		[NullableContext(1)]
		public override void Refresh(ChatRowData chatRowData, bool isSelected, int gridIndex)
		{
			this.ChatRowData = chatRowData;
			UUIText text = base.GetText(4);
			UUISprite sprite = base.GetSprite(1);
			UUISprite sprite2 = base.GetSprite(2);
			UUIText text2 = base.GetText(3);
			FriendModel instance = ModelBase<FriendModel>.Instance;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int senderPlayerId = chatRowData.SenderPlayerId;
			int? targetPlayerId = chatRowData.TargetPlayerId;
			string content = chatRowData.Content;
			string text3;
			if (chatRowData.ContentChatRoomType == EChatRoomType.Private)
			{
				if (targetPlayerId == null)
				{
					return;
				}
				FriendData friendById = instance.GetFriendById(targetPlayerId.Value);
				if (friendById == null)
				{
					return;
				}
				text3 = friendById.PlayerName;
				text3 = "<color=#e5d5a1>[" + text3 + "]</color>";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_FriendTag_Text", Array.Empty<object>());
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				if (sprite2 != null)
				{
					sprite2.SetUIActive(false);
				}
			}
			else
			{
				int? num = chatRowData.SenderPlayerNumber;
				int? num2;
				if (num == null)
				{
					OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(senderPlayerId);
					num2 = ((currentTeamListById != null) ? new int?(currentTeamListById.PlayerNumber) : null);
				}
				else
				{
					num2 = num;
				}
				int? value = num2;
				string text4;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (value == null)
				{
					text4 = "";
				}
				else
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
					defaultInterpolatedStringHandler.AppendLiteral("[");
					defaultInterpolatedStringHandler.AppendFormatted<int?>(value);
					defaultInterpolatedStringHandler.AppendLiteral("P]");
					text4 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				string value2 = text4;
				text3 = chatRowData.SenderPlayerName;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#aadcef>");
				defaultInterpolatedStringHandler.AppendFormatted(value2);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted(text3);
				defaultInterpolatedStringHandler.AppendLiteral("]</color>");
				text3 = defaultInterpolatedStringHandler.ToStringAndClear();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_TeamTag_Text", Array.Empty<object>());
				if (sprite != null)
				{
					sprite.SetUIActive(false);
				}
				if (sprite2 != null)
				{
					sprite2.SetUIActive(true);
				}
			}
			if (chatRowData.ContentType == ChatContentType.Text)
			{
				if (chatRowData.ContentChatRoomType == EChatRoomType.Private)
				{
					LguiUtil instance2 = Singleton<LguiUtil>.Instance;
					UUIText uiText = text;
					int? num = id;
					int num3 = senderPlayerId;
					instance2.SetLocalTextNew(uiText, (num.GetValueOrDefault() == num3 & num != null) ? "Text_TalkToFriendWithOutTag_Text" : "Text_FriendTalkToMeExpressionWithOutTag_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						text3,
						content
					}));
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_TeamTalkWithoutTag_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						text3,
						content
					}));
				}
				text.SetUIActive(true);
				text.bBestFit = false;
			}
			if (chatRowData.ContentType == ChatContentType.Emoji)
			{
				int expressionId = int.Parse(chatRowData.Content);
				ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(expressionId);
				string text5 = string.Empty;
				if (expressionConfig != null)
				{
					string expressionTexturePath = expressionConfig.Value.ExpressionTexturePath;
					if (expressionTexturePath == null)
					{
						return;
					}
					text5 = "<texture=" + expressionTexturePath + ",0.3/>";
				}
				if (chatRowData.ContentChatRoomType == EChatRoomType.Private)
				{
					LguiUtil instance3 = Singleton<LguiUtil>.Instance;
					UUIText uiText2 = text;
					int? num = id;
					int num3 = senderPlayerId;
					instance3.SetLocalTextNew(uiText2, (num.GetValueOrDefault() == num3 & num != null) ? "Text_TalkToFriendWithOutTag_Text" : "Text_FriendTalkToMeExpressionWithOutTag_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						text3,
						text5
					}));
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_TeamTalkWithoutTag_Text", new <>z__ReadOnlyArray<object>(new object[]
					{
						text3,
						text5
					}));
				}
				text.SetUIActive(true);
				UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
				if (horizontalLayout == null)
				{
					return;
				}
				horizontalLayout.SetAlign(ELGUILayoutAlignmentType.LowerLeft);
			}
		}

		// Token: 0x0603DE28 RID: 253480 RVA: 0x00FC8717 File Offset: 0x00FC6917
		public ChatRowData GetChatRowData()
		{
			return this.ChatRowData;
		}

		// Token: 0x04022B60 RID: 142176
		private ChatRowData ChatRowData;

		// Token: 0x0200C083 RID: 49283
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B466 RID: 242790
			HorizontalLayout,
			// Token: 0x0403B467 RID: 242791
			PrivateTagBg,
			// Token: 0x0403B468 RID: 242792
			TeamTagBg,
			// Token: 0x0403B469 RID: 242793
			TagText,
			// Token: 0x0403B46A RID: 242794
			ChatText
		}
	}
}
