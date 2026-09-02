using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FFF RID: 24575
	public class ChatRowDynamicItemInSide : UiPanelBase
	{
		// Token: 0x0603DE36 RID: 253494 RVA: 0x00FC8948 File Offset: 0x00FC6B48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE37 RID: 253495 RVA: 0x00FC8A14 File Offset: 0x00FC6C14
		[NullableContext(1)]
		public void Update(ChatRowData chatRowData, int index)
		{
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
				UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(0);
				if (horizontalLayout != null)
				{
					horizontalLayout.SetAlign(ELGUILayoutAlignmentType.UpperLeft);
				}
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
				UUIHorizontalLayout horizontalLayout2 = base.GetHorizontalLayout(0);
				if (horizontalLayout2 == null)
				{
					return;
				}
				horizontalLayout2.SetAlign(ELGUILayoutAlignmentType.LowerLeft);
			}
		}

		// Token: 0x0200C089 RID: 49289
		private enum EChild2
		{
			// Token: 0x0403B480 RID: 242816
			PanelHorizon,
			// Token: 0x0403B481 RID: 242817
			PrivateTagBg,
			// Token: 0x0403B482 RID: 242818
			TeamTagBg,
			// Token: 0x0403B483 RID: 242819
			TagText,
			// Token: 0x0403B484 RID: 242820
			ChatText
		}
	}
}
