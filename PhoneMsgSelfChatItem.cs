using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200258C RID: 9612
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneMsgSelfChatItem : SyncGridProxyAbstract<PhoneMsgChatData>, IPhoneMsgChatItem
{
	// Token: 0x06012AFC RID: 76540 RVA: 0x005270B4 File Offset: 0x005252B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(14, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(18, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIText)),
			new ValueTuple<int, Type>(26, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(27, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnBtnPicClick)),
			new ValueTuple<int, Delegate>(26, new Action(this.OnBtnSelfClick))
		};
	}

	// Token: 0x06012AFD RID: 76541 RVA: 0x00527384 File Offset: 0x00525584
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LinkButton = new PhoneMsgLinkButton();
		UUIText text = base.GetText(4);
		UUIText text2 = base.GetText(2);
		text.bGameRichText = true;
		text.richText = true;
		text2.bGameRichText = true;
		text2.richText = true;
		this.EmojiLayout = new GenericLayout<PhoneMsgEmojiItem, int>(base.GetLayoutBase(18), new Func<PhoneMsgEmojiItem>(this.CreatePhoneMsgEmojiItem), null, false, true);
		this.PhraseLayout = new GenericLayout<PhoneMsgPhraseItem, string>(base.GetLayoutBase(14), new Func<PhoneMsgPhraseItem>(this.CreatePhoneMsgPhraseItem), null, false, true);
		UUIItem item = base.GetItem(20);
		this.TextOptionAnimItemAlpha = item.Alpha;
		this.TextOptionAnimItemAnchorOffsetY = item.GetAnchorOffsetY();
		UUIItem item2 = base.GetItem(16);
		this.EmojiOptionAnimItemAlpha = item2.Alpha;
		this.EmojiOptionAnimItemStretchBottom = item2.GetStretchBottom();
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshChatDialogShowAfterChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnNameChange, new Action(this.RefreshSpeakerName));
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
		this.LinkButton.CreateByActor(base.GetItem(27).GetOwner(), null);
	}

	// Token: 0x06012AFE RID: 76542 RVA: 0x005274CA File Offset: 0x005256CA
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshChatDialogShowAfterChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnNameChange, new Action(this.RefreshSpeakerName));
	}

	// Token: 0x06012AFF RID: 76543 RVA: 0x00527504 File Offset: 0x00525704
	[NullableContext(1)]
	public override void Refresh(PhoneMsgChatData data)
	{
		this.PhoneMsgChatData = data;
		this.IsUnPlayStart = true;
		this.UpdateOptionData();
		this.RefreshDisplayItem();
		this.ResetTextOptionAnimItem();
		this.ResetEmojiOptionAnimItem();
		this.RefreshTimeText();
		this.RefreshSpeakerInfo();
		this.RefreshChatContent();
		this.RefreshChatDialogShow();
	}

	// Token: 0x06012B00 RID: 76544 RVA: 0x00527544 File Offset: 0x00525744
	private void UpdateOptionData()
	{
		if (this.PhoneMsgChatData == null || this.PhoneMsgChatData.TalkItem == null)
		{
			return;
		}
		List<ITalkOption> options = this.PhoneMsgChatData.TalkItem.Options;
		if (options == null || options.Count == 0)
		{
			return;
		}
		this.PhraseDataList.Clear();
		this.EmojiDataList.Clear();
		int count = options.Count;
		for (int i = 0; i < count; i++)
		{
			ITalkOption talkOption = options[i];
			if (talkOption.TypeParams == null)
			{
				if (talkOption.TidTalkOption.Length > 0)
				{
					string item = Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkOption.TidTalkOption) ?? "";
					this.PhraseDataList.Add(item);
				}
			}
			else if (talkOption.TypeParams.Type == ETalkOptionParamType.PhoneMessageEmoji)
			{
				int valueOrDefault = ((ITalkOptionPhoneMessageEmoji)talkOption.TypeParams).EmojiId.GetValueOrDefault();
				this.EmojiDataList.Add(valueOrDefault);
			}
		}
	}

	// Token: 0x06012B01 RID: 76545 RVA: 0x00527631 File Offset: 0x00525831
	private void RefreshTimeText()
	{
		base.GetText(0).SetUIActive(false);
	}

	// Token: 0x06012B02 RID: 76546 RVA: 0x00527640 File Offset: 0x00525840
	private void RefreshSpeakerInfo()
	{
		base.GetText(2).SetText(this.PhoneMsgChatData.SpeakerName, true);
		UUIText text = base.GetText(11);
		if (text != null)
		{
			text.SetText(this.PhoneMsgChatData.SpeakerName, true);
		}
		UUITexture texture = base.GetTexture(1);
		int speakerIcon = this.PhoneMsgChatData.SpeakerIcon;
		if (speakerIcon != 0)
		{
			PlayerHeadData playerHeadData = ModelBase<PersonalModel>.Instance.GetPlayerHeadData(speakerIcon, false);
			if (playerHeadData != null)
			{
				base.SetTextureShowUntilLoaded(playerHeadData.GetRoleHeadIconCircle(), texture, null);
				return;
			}
		}
		else
		{
			string speakerHeadIconPath = this.PhoneMsgChatData.SpeakerHeadIconPath;
			if (StringUtils.IsEmpty(speakerHeadIconPath))
			{
				texture.SetUIActive(false);
				return;
			}
			base.SetTextureShowUntilLoaded(speakerHeadIconPath, texture, null);
		}
	}

	// Token: 0x06012B03 RID: 76547 RVA: 0x005276E4 File Offset: 0x005258E4
	private void RefreshSpeakerName()
	{
		string text = ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "";
		if (!string.IsNullOrEmpty(text) && this.PhoneMsgChatData != null)
		{
			this.PhoneMsgChatData.SpeakerName = text;
			base.GetText(2).SetText(text, true);
			UUIText text2 = base.GetText(11);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}
	}

	// Token: 0x06012B04 RID: 76548 RVA: 0x00527744 File Offset: 0x00525944
	public void RefreshChatDialogShow()
	{
		int currentUsingChatDialogId = ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatDialogId;
		ChatDialog? chatDialogConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(currentUsingChatDialogId);
		if (chatDialogConfig == null)
		{
			return;
		}
		string bgPath = chatDialogConfig.Value.BgPath;
		this.SetSpriteByPath(bgPath, base.GetSprite(10), false, null, null);
		base.GetText(4).SetColor(FColor.FromHex(chatDialogConfig.Value.TextColor));
		base.GetItem(22).SetColor(FColor.FromHex(chatDialogConfig.Value.TextColor));
		this.TryLoadDynamicDialogNode(chatDialogConfig.Value.SpineItemPath);
		bool isUsingDefaultChatBg = ModelBase<PhoneMsgModel>.Instance.IsUsingDefaultChatBg;
		base.GetText(2).SetUIActive(isUsingDefaultChatBg);
		UUIText text = base.GetText(11);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(!isUsingDefaultChatBg);
	}

	// Token: 0x06012B05 RID: 76549 RVA: 0x00527825 File Offset: 0x00525A25
	public void RefreshChatDialogShowAfterChange()
	{
		this.RefreshChatDialogShow();
	}

	// Token: 0x06012B06 RID: 76550 RVA: 0x00527830 File Offset: 0x00525A30
	private void TryLoadDynamicDialogNode(string path)
	{
		PhoneMsgSelfChatItem.<>c__DisplayClass29_0 CS$<>8__locals1 = new PhoneMsgSelfChatItem.<>c__DisplayClass29_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.path = path;
		UiAsyncTask task = new UiAsyncTask("PhoneMsgSelfChatItem.TryLoadDynamicDialogNode", delegate()
		{
			PhoneMsgSelfChatItem.<>c__DisplayClass29_0.<<TryLoadDynamicDialogNode>b__0>d <<TryLoadDynamicDialogNode>b__0>d;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<TryLoadDynamicDialogNode>b__0>d.<>4__this = CS$<>8__locals1;
			<<TryLoadDynamicDialogNode>b__0>d.<>1__state = -1;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Start<PhoneMsgSelfChatItem.<>c__DisplayClass29_0.<<TryLoadDynamicDialogNode>b__0>d>(ref <<TryLoadDynamicDialogNode>b__0>d);
			return <<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x06012B07 RID: 76551 RVA: 0x00527878 File Offset: 0x00525A78
	private UniTask TryLoadDynamicDialogNodeAsync(string path)
	{
		PhoneMsgSelfChatItem.<TryLoadDynamicDialogNodeAsync>d__30 <TryLoadDynamicDialogNodeAsync>d__;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLoadDynamicDialogNodeAsync>d__.<>4__this = this;
		<TryLoadDynamicDialogNodeAsync>d__.path = path;
		<TryLoadDynamicDialogNodeAsync>d__.<>1__state = -1;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<TryLoadDynamicDialogNodeAsync>d__30>(ref <TryLoadDynamicDialogNodeAsync>d__);
		return <TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B08 RID: 76552 RVA: 0x005278C3 File Offset: 0x00525AC3
	private void DestroyDynamicDialogActor()
	{
		if (this.DynamicDialogActor != null && this.DynamicDialogActor.IsValid())
		{
			ULGUIBPLibrary.DestroyActorWithHierarchy(this.DynamicDialogActor, true);
			this.DynamicDialogActor = null;
		}
	}

	// Token: 0x06012B09 RID: 76553 RVA: 0x005278F0 File Offset: 0x00525AF0
	private void RefreshDisplayItem()
	{
		EChatMsgType contentType = this.PhoneMsgChatData.ContentType;
		base.GetItem(12).SetUIActive(contentType == EChatMsgType.TextOption);
		base.GetItem(16).SetUIActive(contentType == EChatMsgType.EmojiOption);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(5).SetUIActive(this.PhoneMsgChatData.IsSendError);
		base.GetTexture(6).SetUIActive(contentType == EChatMsgType.Emoji);
		if (contentType == EChatMsgType.Attachment)
		{
			PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(this.PhoneMsgChatData.ContentNum, true);
			string a = (config != null) ? config.GetValueOrDefault().Type : null;
			base.GetButton(8).RootUIComp.Get().SetUIActive(a == "Image" || a == "Spine");
			base.GetItem(27).SetUIActive(a == "InformationView");
		}
		else
		{
			base.GetButton(8).RootUIComp.Get().SetUIActive(false);
			base.GetItem(27).SetUIActive(false);
		}
		bool flag = contentType == EChatMsgType.Voice;
		base.GetItem(3).SetUIActive(contentType == EChatMsgType.Text || flag);
		base.GetButton(26).SetSelfInteractive(contentType != EChatMsgType.Text);
		base.GetItem(22).SetUIActive(flag);
		base.GetItem(23).SetUIActive(flag);
		base.GetItem(24).SetUIActive(false);
		base.GetText(25).SetUIActive(flag);
	}

	// Token: 0x06012B0A RID: 76554 RVA: 0x00527A70 File Offset: 0x00525C70
	private void RefreshChatContent()
	{
		switch (this.PhoneMsgChatData.ContentType)
		{
		case EChatMsgType.Text:
			base.GetText(4).SetText(this.PhoneMsgChatData.ContentStr, true);
			return;
		case EChatMsgType.Emoji:
		{
			int contentNum = this.PhoneMsgChatData.ContentNum;
			string emojiTexturePathByEmojiId = ModelBase<PhoneMsgModel>.Instance.GetEmojiTexturePathByEmojiId(contentNum);
			if (!string.IsNullOrEmpty(emojiTexturePathByEmojiId))
			{
				base.SetTextureByPath(emojiTexturePathByEmojiId, base.GetTexture(6), null, null);
				return;
			}
			break;
		}
		case EChatMsgType.Attachment:
		{
			PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(this.PhoneMsgChatData.ContentNum, true);
			if (config != null)
			{
				PhoneMessageAttachment value = config.Value;
				bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
				string type = value.Type;
				if (type == "Image" || type == "Spine")
				{
					base.GetButton(8).RootUIComp.Get().SetUIActive(true);
					string text = value.ThumbnailMaleVariant;
					if (string.IsNullOrEmpty(text))
					{
						text = value.Thumbnail;
					}
					else
					{
						text = (flag ? value.ThumbnailMaleVariant : value.Thumbnail);
					}
					base.SetTextureByPath(text, base.GetTexture(9), null, null);
					return;
				}
				if (type == "InformationView")
				{
					base.GetItem(27).SetUIActive(true);
					string text2 = "TryGet男Title";
					int id = value.Id;
					int infoId;
					if (string.IsNullOrEmpty(text2))
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkText");
						text2 = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewId;
					}
					else if (flag)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkTextMaleVariant");
						text2 = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewIdMaleVariant;
					}
					else
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkText");
						text2 = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewId;
					}
					this.LinkButton.RefreshContent(text2, infoId, this.PhoneMsgChatData);
					return;
				}
			}
			break;
		}
		case EChatMsgType.Task:
		case EChatMsgType.Birthday:
		case EChatMsgType.Reward:
		case EChatMsgType.Tips:
			break;
		case EChatMsgType.TextOption:
			this.PhraseLayout.RefreshByData(this.PhraseDataList, null, false);
			return;
		case EChatMsgType.EmojiOption:
			this.EmojiLayout.RefreshByData(this.EmojiDataList, null, false);
			return;
		case EChatMsgType.Voice:
		{
			UUIText text3 = base.GetText(4);
			UUIText text4 = base.GetText(25);
			int num = (int)Math.Round((double)(this.PhoneMsgChatData.VoiceDuration / 1000f), MidpointRounding.AwayFromZero);
			num = Math.Max(num, 1);
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("OneSecondToSpace").GetValueOrDefault(1);
			int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("MaxTimeLength").GetValueOrDefault(40);
			StringBuilder stringBuilder = new StringBuilder();
			if (num > 1)
			{
				int num2 = Math.Min(num - 1, valueOrDefault2);
				stringBuilder.Append(' ', num2 * valueOrDefault);
			}
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendFormatted<int>(num);
			appendInterpolatedStringHandler.AppendLiteral("″");
			stringBuilder3.Append(ref appendInterpolatedStringHandler);
			text3.SetText(stringBuilder.ToString(), true);
			text4.SetText(this.PhoneMsgChatData.ContentStr, true);
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x06012B0B RID: 76555 RVA: 0x00527DEB File Offset: 0x00525FEB
	[NullableContext(1)]
	private PhoneMsgEmojiItem CreatePhoneMsgEmojiItem()
	{
		return new PhoneMsgEmojiItem
		{
			OnClickDelegate = new Action<int>(this.OnOptionItemClickInternal)
		};
	}

	// Token: 0x06012B0C RID: 76556 RVA: 0x00527E04 File Offset: 0x00526004
	[NullableContext(1)]
	private PhoneMsgPhraseItem CreatePhoneMsgPhraseItem()
	{
		return new PhoneMsgPhraseItem
		{
			OnClickDelegate = new Action<int>(this.OnOptionItemClickInternal)
		};
	}

	// Token: 0x06012B0D RID: 76557 RVA: 0x00527E1D File Offset: 0x0052601D
	private void OnOptionItemClickInternal(int selectedIndex)
	{
		Action<int, int> onOptionItemClickDelegate = this.OnOptionItemClickDelegate;
		if (onOptionItemClickDelegate == null)
		{
			return;
		}
		onOptionItemClickDelegate(base.GridIndex, selectedIndex);
	}

	// Token: 0x06012B0E RID: 76558 RVA: 0x00527E36 File Offset: 0x00526036
	private void ResetTextOptionAnimItem()
	{
		UUIItem item = base.GetItem(20);
		item.SetAlpha(this.TextOptionAnimItemAlpha);
		item.SetAnchorOffsetY(this.TextOptionAnimItemAnchorOffsetY);
	}

	// Token: 0x06012B0F RID: 76559 RVA: 0x00527E57 File Offset: 0x00526057
	private void ResetEmojiOptionAnimItem()
	{
		UUIItem item = base.GetItem(16);
		item.SetAlpha(this.EmojiOptionAnimItemAlpha);
		item.SetStretchBottom(this.EmojiOptionAnimItemStretchBottom);
	}

	// Token: 0x06012B10 RID: 76560 RVA: 0x00527E78 File Offset: 0x00526078
	[NullableContext(1)]
	public string GetChatContentSequenceName(bool afterAnswer = false)
	{
		switch (this.PhoneMsgChatData.ContentType)
		{
		case EChatMsgType.Text:
			if (!afterAnswer)
			{
				return "Send_Text";
			}
			return "Send_Text_NoHead";
		case EChatMsgType.Emoji:
			if (!afterAnswer)
			{
				return "Emote_In";
			}
			return "Emote_In_NoHead";
		case EChatMsgType.Attachment:
		{
			PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(this.PhoneMsgChatData.ContentNum, true);
			if (((config != null) ? config.GetValueOrDefault().Type : null) == "InformationView")
			{
				if (!afterAnswer)
				{
					return "Info_In";
				}
				return "Info_In_NoHead";
			}
			else
			{
				if (!afterAnswer)
				{
					return "Pic_In";
				}
				return "Pic_In_NoHead";
			}
			break;
		}
		case EChatMsgType.TextOption:
			return "Reply_In";
		case EChatMsgType.EmojiOption:
			if (!afterAnswer)
			{
				return "Reply_Emote_In";
			}
			return "Reply_Emote_In";
		case EChatMsgType.Voice:
			if (!afterAnswer)
			{
				return "Send_Text";
			}
			return "Send_Text_NoHead";
		}
		return "";
	}

	// Token: 0x06012B11 RID: 76561 RVA: 0x00527F64 File Offset: 0x00526164
	[NullableContext(1)]
	private void OnEventSequence(string sequenceName, string eventName)
	{
		if (this.DialogSequencePlayer != null && eventName == "Sequence_bubble_In" && this.IsUnPlayStart)
		{
			this.IsUnPlayStart = false;
			this.DialogSequencePlayer.StopCurrentSequence(false, false);
			this.DialogSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x06012B12 RID: 76562 RVA: 0x00527FC0 File Offset: 0x005261C0
	public UniTask PlayChatContentAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayChatContentAnimationAsync>d__41 <PlayChatContentAnimationAsync>d__;
		<PlayChatContentAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayChatContentAnimationAsync>d__.<>4__this = this;
		<PlayChatContentAnimationAsync>d__.<>1__state = -1;
		<PlayChatContentAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayChatContentAnimationAsync>d__41>(ref <PlayChatContentAnimationAsync>d__);
		return <PlayChatContentAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B13 RID: 76563 RVA: 0x00528004 File Offset: 0x00526204
	public UniTask PlayChatContentAnimationAsync(bool afterAnswer)
	{
		PhoneMsgSelfChatItem.<PlayChatContentAnimationAsync>d__42 <PlayChatContentAnimationAsync>d__;
		<PlayChatContentAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayChatContentAnimationAsync>d__.<>4__this = this;
		<PlayChatContentAnimationAsync>d__.afterAnswer = afterAnswer;
		<PlayChatContentAnimationAsync>d__.<>1__state = -1;
		<PlayChatContentAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayChatContentAnimationAsync>d__42>(ref <PlayChatContentAnimationAsync>d__);
		return <PlayChatContentAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B14 RID: 76564 RVA: 0x0052804F File Offset: 0x0052624F
	public void StopChatContentAnimation()
	{
		this.StopChatContentAnimation(false);
	}

	// Token: 0x06012B15 RID: 76565 RVA: 0x00528058 File Offset: 0x00526258
	public void StopChatContentAnimation(bool afterAnswer)
	{
		string chatContentSequenceName = this.GetChatContentSequenceName(afterAnswer);
		if (StringUtils.IsEmpty(chatContentSequenceName))
		{
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey(chatContentSequenceName, false, true);
		this.StopRedDotAnimation();
	}

	// Token: 0x06012B16 RID: 76566 RVA: 0x0052808C File Offset: 0x0052628C
	public UniTask PlayRedDotAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayRedDotAnimationAsync>d__45 <PlayRedDotAnimationAsync>d__;
		<PlayRedDotAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRedDotAnimationAsync>d__.<>4__this = this;
		<PlayRedDotAnimationAsync>d__.<>1__state = -1;
		<PlayRedDotAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayRedDotAnimationAsync>d__45>(ref <PlayRedDotAnimationAsync>d__);
		return <PlayRedDotAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B17 RID: 76567 RVA: 0x005280CF File Offset: 0x005262CF
	public void StopRedDotAnimation()
	{
		PhoneMsgChatData phoneMsgChatData = this.PhoneMsgChatData;
		if (phoneMsgChatData == null || !phoneMsgChatData.IsSendError)
		{
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("Red_Tips", false, true);
	}

	// Token: 0x06012B18 RID: 76568 RVA: 0x005280FC File Offset: 0x005262FC
	public UniTask PlayTextOptionAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayTextOptionAnimationAsync>d__47 <PlayTextOptionAnimationAsync>d__;
		<PlayTextOptionAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayTextOptionAnimationAsync>d__.<>4__this = this;
		<PlayTextOptionAnimationAsync>d__.<>1__state = -1;
		<PlayTextOptionAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayTextOptionAnimationAsync>d__47>(ref <PlayTextOptionAnimationAsync>d__);
		return <PlayTextOptionAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B19 RID: 76569 RVA: 0x0052813F File Offset: 0x0052633F
	public void StopTextOptionAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Reply_Out", false, true);
	}

	// Token: 0x06012B1A RID: 76570 RVA: 0x00528154 File Offset: 0x00526354
	public UniTask PlayEmojiOptionAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayEmojiOptionAnimationAsync>d__49 <PlayEmojiOptionAnimationAsync>d__;
		<PlayEmojiOptionAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayEmojiOptionAnimationAsync>d__.<>4__this = this;
		<PlayEmojiOptionAnimationAsync>d__.<>1__state = -1;
		<PlayEmojiOptionAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayEmojiOptionAnimationAsync>d__49>(ref <PlayEmojiOptionAnimationAsync>d__);
		return <PlayEmojiOptionAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B1B RID: 76571 RVA: 0x00528197 File Offset: 0x00526397
	public void StopEmojiOptionAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Reply_Emote_Out", false, true);
	}

	// Token: 0x06012B1C RID: 76572 RVA: 0x005281AC File Offset: 0x005263AC
	public UniTask PlayOptionHideAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayOptionHideAnimationAsync>d__51 <PlayOptionHideAnimationAsync>d__;
		<PlayOptionHideAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayOptionHideAnimationAsync>d__.<>4__this = this;
		<PlayOptionHideAnimationAsync>d__.<>1__state = -1;
		<PlayOptionHideAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayOptionHideAnimationAsync>d__51>(ref <PlayOptionHideAnimationAsync>d__);
		return <PlayOptionHideAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B1D RID: 76573 RVA: 0x005281EF File Offset: 0x005263EF
	public void StopOptionHideAnimation()
	{
		if (this.PhoneMsgChatData.ContentType == EChatMsgType.TextOption)
		{
			this.StopTextOptionAnimation();
			return;
		}
		if (this.PhoneMsgChatData.ContentType == EChatMsgType.EmojiOption)
		{
			this.StopEmojiOptionAnimation();
		}
	}

	// Token: 0x06012B1E RID: 76574 RVA: 0x0052821C File Offset: 0x0052641C
	private void OnBtnPicClick()
	{
		if (this.PhoneMsgChatData == null)
		{
			return;
		}
		int contentNum = this.PhoneMsgChatData.ContentNum;
		if (contentNum <= 0)
		{
			return;
		}
		ControllerBase<PhoneMsgController>.Instance.OpenAttachmentImgView(contentNum);
	}

	// Token: 0x06012B1F RID: 76575 RVA: 0x0052824E File Offset: 0x0052644E
	private void OnBtnSelfClick()
	{
		Action<int> onItemClickDelegate = this.OnItemClickDelegate;
		if (onItemClickDelegate == null)
		{
			return;
		}
		onItemClickDelegate(base.GridIndex);
	}

	// Token: 0x06012B20 RID: 76576 RVA: 0x00528268 File Offset: 0x00526468
	public UniTask PlayVoicePlayingAnimationAsync()
	{
		PhoneMsgSelfChatItem.<PlayVoicePlayingAnimationAsync>d__55 <PlayVoicePlayingAnimationAsync>d__;
		<PlayVoicePlayingAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayVoicePlayingAnimationAsync>d__.<>4__this = this;
		<PlayVoicePlayingAnimationAsync>d__.<>1__state = -1;
		<PlayVoicePlayingAnimationAsync>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<PlayVoicePlayingAnimationAsync>d__55>(ref <PlayVoicePlayingAnimationAsync>d__);
		return <PlayVoicePlayingAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012B21 RID: 76577 RVA: 0x005282AC File Offset: 0x005264AC
	public void SkipVoicePlayingAnimation()
	{
		if (this.VoiceCustomPromise != null)
		{
			this.VoiceCustomPromise.SetResult(false);
			this.VoiceCustomPromise = null;
		}
		this.StopVoicePlayingAnimation();
		if (this.VoiceHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.VoiceHandle);
			this.VoiceHandle = null;
		}
	}

	// Token: 0x06012B22 RID: 76578 RVA: 0x005282FA File Offset: 0x005264FA
	public void StopVoicePlayingAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Voice_Play_Loop", false, true);
	}

	// Token: 0x06012B23 RID: 76579 RVA: 0x00528310 File Offset: 0x00526510
	public UniTask ShowVoiceTextPanel(Action afterShow = null)
	{
		PhoneMsgSelfChatItem.<ShowVoiceTextPanel>d__58 <ShowVoiceTextPanel>d__;
		<ShowVoiceTextPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowVoiceTextPanel>d__.<>1__state = -1;
		<ShowVoiceTextPanel>d__.<>t__builder.Start<PhoneMsgSelfChatItem.<ShowVoiceTextPanel>d__58>(ref <ShowVoiceTextPanel>d__);
		return <ShowVoiceTextPanel>d__.<>t__builder.Task;
	}

	// Token: 0x04009220 RID: 37408
	protected PhoneMsgChatData PhoneMsgChatData;

	// Token: 0x04009221 RID: 37409
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009222 RID: 37410
	private AActor DynamicDialogActor;

	// Token: 0x04009223 RID: 37411
	private LevelSequencePlayer DialogSequencePlayer;

	// Token: 0x04009224 RID: 37412
	[Nullable(1)]
	private readonly List<string> PhraseDataList = new List<string>();

	// Token: 0x04009225 RID: 37413
	[Nullable(1)]
	private readonly List<int> EmojiDataList = new List<int>();

	// Token: 0x04009226 RID: 37414
	private bool IsUnPlayStart = true;

	// Token: 0x04009227 RID: 37415
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<PhoneMsgPhraseItem, string> PhraseLayout;

	// Token: 0x04009228 RID: 37416
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PhoneMsgEmojiItem, int> EmojiLayout;

	// Token: 0x04009229 RID: 37417
	private float TextOptionAnimItemAlpha;

	// Token: 0x0400922A RID: 37418
	private float TextOptionAnimItemAnchorOffsetY;

	// Token: 0x0400922B RID: 37419
	private float EmojiOptionAnimItemAlpha;

	// Token: 0x0400922C RID: 37420
	private float EmojiOptionAnimItemStretchBottom;

	// Token: 0x0400922D RID: 37421
	private TimerHandle VoiceHandle;

	// Token: 0x0400922E RID: 37422
	private CustomPromise<bool> VoiceCustomPromise;

	// Token: 0x0400922F RID: 37423
	protected PhoneMsgLinkButton LinkButton;

	// Token: 0x04009230 RID: 37424
	public Action<int, int> OnOptionItemClickDelegate;

	// Token: 0x04009231 RID: 37425
	public Action<int> OnItemClickDelegate;

	// Token: 0x04009232 RID: 37426
	[Nullable(1)]
	private string DynamicDialogActorPath = string.Empty;
}
