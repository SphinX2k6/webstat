using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.PhoneMessage;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002589 RID: 9609
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneMsgOtherChatItem : SyncGridProxyAbstract<PhoneMsgChatData>, IPhoneMsgChatItem
{
	// Token: 0x06012AD5 RID: 76501 RVA: 0x0052625C File Offset: 0x0052445C
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
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(8, new Action(this.OnBtnPicClick)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnBtnSelfClick))
		};
	}

	// Token: 0x06012AD6 RID: 76502 RVA: 0x0052645C File Offset: 0x0052465C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LinkButton = new PhoneMsgLinkButton();
		UUIText text = base.GetText(4);
		UUIText text2 = base.GetText(2);
		UUIText text3 = base.GetText(11);
		text.bGameRichText = true;
		text.richText = true;
		text2.bGameRichText = true;
		text2.richText = true;
		text3.bGameRichText = true;
		text3.richText = true;
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshSpeakerNameTextColor));
		this.LinkButton.CreateByActor(base.GetItem(18).GetOwner(), null);
	}

	// Token: 0x06012AD7 RID: 76503 RVA: 0x005264FB File Offset: 0x005246FB
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneMsgChatShowChange, new Action(this.RefreshSpeakerNameTextColor));
	}

	// Token: 0x06012AD8 RID: 76504 RVA: 0x00526519 File Offset: 0x00524719
	[NullableContext(1)]
	public override void Refresh(PhoneMsgChatData data)
	{
		this.PhoneMsgChatData = data;
		this.RefreshDisplayItem();
		this.RefreshTimeText();
		this.RefreshSpeakerInfo();
		this.RefreshChatContent();
	}

	// Token: 0x06012AD9 RID: 76505 RVA: 0x0052653A File Offset: 0x0052473A
	public void RefreshVoiceStatus()
	{
		this.RefreshVoiceDisplayItem();
	}

	// Token: 0x06012ADA RID: 76506 RVA: 0x00526544 File Offset: 0x00524744
	private void RefreshVoiceDisplayItem()
	{
		if (this.PhoneMsgChatData == null)
		{
			return;
		}
		UUIItem item = base.GetItem(13);
		if (item == null)
		{
			return;
		}
		bool flag = this.PhoneMsgChatData.ContentType == EChatMsgType.Voice;
		item.SetUIActive(flag);
		if (flag)
		{
			UUISprite sprite = base.GetSprite(12);
			if (sprite != null)
			{
				sprite.SetUIActive(!this.PhoneMsgChatData.IsVoicePlayed);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 != null)
			{
				item2.SetUIActive(this.PhoneMsgChatData.IsVoicePlayed);
			}
			UUIItem item3 = base.GetItem(15);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(this.PhoneMsgChatData.IsVoicePlayed);
		}
	}

	// Token: 0x06012ADB RID: 76507 RVA: 0x005265F1 File Offset: 0x005247F1
	[NullableContext(1)]
	public string GetChatContent()
	{
		return this.PhoneMsgChatData.ContentStr;
	}

	// Token: 0x06012ADC RID: 76508 RVA: 0x005265FE File Offset: 0x005247FE
	public int GetChatContentNum()
	{
		return this.PhoneMsgChatData.ContentStr.Length;
	}

	// Token: 0x06012ADD RID: 76509 RVA: 0x00526610 File Offset: 0x00524810
	public EPhoneMsgScrollWaitTimeType GetScrollWaitTimeType()
	{
		return this.PhoneMsgChatData.ScrollWaitTimeType;
	}

	// Token: 0x06012ADE RID: 76510 RVA: 0x0052661D File Offset: 0x0052481D
	public float GetScrollWaitTime()
	{
		return (float)this.PhoneMsgChatData.ScrollWaitTime;
	}

	// Token: 0x06012ADF RID: 76511 RVA: 0x0052662B File Offset: 0x0052482B
	public bool IsVoiceAndAutoPlay()
	{
		return this.PhoneMsgChatData.ContentType == EChatMsgType.Voice && !this.PhoneMsgChatData.IsVoicePlayed;
	}

	// Token: 0x06012AE0 RID: 76512 RVA: 0x0052664C File Offset: 0x0052484C
	public EPhoneMessageVoicePushCondition? GetPushCondition()
	{
		return this.PhoneMsgChatData.PushCondition;
	}

	// Token: 0x06012AE1 RID: 76513 RVA: 0x0052665C File Offset: 0x0052485C
	public void RefreshDisplayItem()
	{
		EChatMsgType contentType = this.PhoneMsgChatData.ContentType;
		base.GetItem(7).SetUIActive(false);
		base.GetItem(5).SetUIActive(this.PhoneMsgChatData.IsSendError);
		base.GetTexture(6).SetUIActive(contentType == EChatMsgType.Emoji);
		if (contentType == EChatMsgType.Attachment)
		{
			PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(this.PhoneMsgChatData.ContentNum, true);
			string a = (config != null) ? config.GetValueOrDefault().Type : null;
			base.GetButton(8).RootUIComp.Get().SetUIActive(a == "Image" || a == "Spine");
			base.GetItem(18).SetUIActive(a == "InformationView");
		}
		else
		{
			base.GetButton(8).RootUIComp.Get().SetUIActive(false);
			base.GetItem(18).SetUIActive(false);
		}
		bool flag = contentType == EChatMsgType.Voice;
		bool isVoicePlayed = this.PhoneMsgChatData.IsVoicePlayed;
		base.GetItem(13).SetUIActive(flag);
		base.GetItem(3).SetUIActive(contentType == EChatMsgType.Text || flag);
		base.GetSprite(12).SetUIActive(flag && !isVoicePlayed);
		base.GetItem(14).SetUIActive(flag && isVoicePlayed);
		base.GetItem(15).SetUIActive(false);
		base.GetItem(16).SetUIActive(flag && isVoicePlayed);
		base.GetButton(17).SetSelfInteractive(contentType != EChatMsgType.Text);
	}

	// Token: 0x06012AE2 RID: 76514 RVA: 0x005267E6 File Offset: 0x005249E6
	private void RefreshTimeText()
	{
		base.GetText(0).SetUIActive(false);
	}

	// Token: 0x06012AE3 RID: 76515 RVA: 0x005267F8 File Offset: 0x005249F8
	private void RefreshSpeakerInfo()
	{
		base.GetText(2).SetText(this.PhoneMsgChatData.SpeakerName, true);
		base.GetText(11).SetText(this.PhoneMsgChatData.SpeakerName, true);
		this.RefreshSpeakerNameTextColor();
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

	// Token: 0x06012AE4 RID: 76516 RVA: 0x00526898 File Offset: 0x00524A98
	private void RefreshChatContent()
	{
		EChatMsgType contentType = this.PhoneMsgChatData.ContentType;
		bool uiactive = contentType == EChatMsgType.Voice;
		base.GetItem(13).SetUIActive(uiactive);
		switch (contentType)
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
					base.GetItem(18).SetUIActive(true);
					int id = value.Id;
					string textKey;
					int infoId;
					if (value.InformationViewIdMaleVariant == 0)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkText");
						textKey = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewId;
					}
					else if (flag)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(63, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkTextMaleVariant");
						textKey = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewIdMaleVariant;
					}
					else
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
						defaultInterpolatedStringHandler.AppendLiteral("PhoneMessageAttachment_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(id);
						defaultInterpolatedStringHandler.AppendLiteral("_InformationViewHyperlinkText");
						textKey = defaultInterpolatedStringHandler.ToStringAndClear();
						infoId = value.InformationViewId;
					}
					this.LinkButton.RefreshContent(textKey, infoId, this.PhoneMsgChatData);
					return;
				}
			}
			break;
		}
		default:
		{
			if (contentType != EChatMsgType.Voice)
			{
				return;
			}
			if (this.VoicePlayPromise != null)
			{
				return;
			}
			UUIText text2 = base.GetText(4);
			UUIText text3 = base.GetText(16);
			int num = (int)Math.Round((double)(this.PhoneMsgChatData.VoiceDuration / 1000f), MidpointRounding.AwayFromZero);
			num = Math.Max(num, 1);
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("OneSecondToSpace").GetValueOrDefault(1);
			int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("MaxTimeLength").GetValueOrDefault(40);
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
			appendInterpolatedStringHandler.AppendFormatted<int>(num);
			appendInterpolatedStringHandler.AppendLiteral("″");
			stringBuilder3.Append(ref appendInterpolatedStringHandler);
			if (num > 1)
			{
				int num2 = Math.Min(num - 1, valueOrDefault2);
				stringBuilder.Append(' ', num2 * valueOrDefault);
			}
			text2.SetText(stringBuilder.ToString(), true);
			text3.SetText(this.PhoneMsgChatData.ContentStr, true);
			break;
		}
		}
	}

	// Token: 0x06012AE5 RID: 76517 RVA: 0x00526BF4 File Offset: 0x00524DF4
	private void HideAllItemsExceptInputtingItem()
	{
		base.GetTexture(6).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		base.GetButton(8).RootUIComp.Get().SetUIActive(false);
		base.GetItem(18).SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
	}

	// Token: 0x06012AE6 RID: 76518 RVA: 0x00526C50 File Offset: 0x00524E50
	public UniTask PlayInputtingAnimationAsync(float delayTime)
	{
		PhoneMsgOtherChatItem.<PlayInputtingAnimationAsync>d__26 <PlayInputtingAnimationAsync>d__;
		<PlayInputtingAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayInputtingAnimationAsync>d__.<>4__this = this;
		<PlayInputtingAnimationAsync>d__.delayTime = delayTime;
		<PlayInputtingAnimationAsync>d__.<>1__state = -1;
		<PlayInputtingAnimationAsync>d__.<>t__builder.Start<PhoneMsgOtherChatItem.<PlayInputtingAnimationAsync>d__26>(ref <PlayInputtingAnimationAsync>d__);
		return <PlayInputtingAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012AE7 RID: 76519 RVA: 0x00526C9C File Offset: 0x00524E9C
	public void SkipInputtingAnimationTask()
	{
		if (this.InputPromise != null)
		{
			this.InputPromise.SetResult(false);
			this.InputPromise = null;
		}
		this.StopInputtingAnimation();
		if (this.InputHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.InputHandle);
			this.InputHandle = null;
		}
	}

	// Token: 0x06012AE8 RID: 76520 RVA: 0x00526CEA File Offset: 0x00524EEA
	public void StopInputtingAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Send_Text_1", false, true);
	}

	// Token: 0x06012AE9 RID: 76521 RVA: 0x00526D00 File Offset: 0x00524F00
	[NullableContext(1)]
	private string GetChatContentSequenceName()
	{
		EChatMsgType contentType = this.PhoneMsgChatData.ContentType;
		switch (contentType)
		{
		case EChatMsgType.Text:
			return "Send_Text_2";
		case EChatMsgType.Emoji:
			return "Emote_In";
		case EChatMsgType.Attachment:
		{
			PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(this.PhoneMsgChatData.ContentNum, true);
			if (((config != null) ? config.GetValueOrDefault().Type : null) == "InformationView")
			{
				return "Info_In";
			}
			return "Pic_In";
		}
		default:
			if (contentType != EChatMsgType.Voice)
			{
				return "";
			}
			return "Send_Text_2";
		}
	}

	// Token: 0x06012AEA RID: 76522 RVA: 0x00526D90 File Offset: 0x00524F90
	public UniTask PlayChatContentAnimationAsync()
	{
		PhoneMsgOtherChatItem.<PlayChatContentAnimationAsync>d__30 <PlayChatContentAnimationAsync>d__;
		<PlayChatContentAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayChatContentAnimationAsync>d__.<>4__this = this;
		<PlayChatContentAnimationAsync>d__.<>1__state = -1;
		<PlayChatContentAnimationAsync>d__.<>t__builder.Start<PhoneMsgOtherChatItem.<PlayChatContentAnimationAsync>d__30>(ref <PlayChatContentAnimationAsync>d__);
		return <PlayChatContentAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012AEB RID: 76523 RVA: 0x00526DD4 File Offset: 0x00524FD4
	public void StopChatContentAnimation()
	{
		string chatContentSequenceName = this.GetChatContentSequenceName();
		if (StringUtils.IsEmpty(chatContentSequenceName))
		{
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey(chatContentSequenceName, false, true);
		this.StopRedDotAnimation();
	}

	// Token: 0x06012AEC RID: 76524 RVA: 0x00526E08 File Offset: 0x00525008
	public UniTask PlayRedDotAnimationAsync()
	{
		PhoneMsgOtherChatItem.<PlayRedDotAnimationAsync>d__32 <PlayRedDotAnimationAsync>d__;
		<PlayRedDotAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayRedDotAnimationAsync>d__.<>4__this = this;
		<PlayRedDotAnimationAsync>d__.<>1__state = -1;
		<PlayRedDotAnimationAsync>d__.<>t__builder.Start<PhoneMsgOtherChatItem.<PlayRedDotAnimationAsync>d__32>(ref <PlayRedDotAnimationAsync>d__);
		return <PlayRedDotAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012AED RID: 76525 RVA: 0x00526E4B File Offset: 0x0052504B
	public void StopRedDotAnimation()
	{
		PhoneMsgChatData phoneMsgChatData = this.PhoneMsgChatData;
		if (phoneMsgChatData == null || !phoneMsgChatData.IsSendError)
		{
			return;
		}
		this.LevelSequencePlayer.StopSequenceByKey("Red_Tips", false, true);
	}

	// Token: 0x06012AEE RID: 76526 RVA: 0x00526E78 File Offset: 0x00525078
	public UniTask PlayVoicePlayingAnimationAsync()
	{
		PhoneMsgOtherChatItem.<PlayVoicePlayingAnimationAsync>d__34 <PlayVoicePlayingAnimationAsync>d__;
		<PlayVoicePlayingAnimationAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayVoicePlayingAnimationAsync>d__.<>4__this = this;
		<PlayVoicePlayingAnimationAsync>d__.<>1__state = -1;
		<PlayVoicePlayingAnimationAsync>d__.<>t__builder.Start<PhoneMsgOtherChatItem.<PlayVoicePlayingAnimationAsync>d__34>(ref <PlayVoicePlayingAnimationAsync>d__);
		return <PlayVoicePlayingAnimationAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012AEF RID: 76527 RVA: 0x00526EBB File Offset: 0x005250BB
	public void TryPlayVoiceTxtInAnimation()
	{
		base.GetSprite(12).SetUIActive(false);
		base.GetItem(14).SetUIActive(true);
		base.GetItem(15).SetUIActive(true);
		this.LevelSequencePlayer.StopSequenceByKey("Voice_LoadText", false, true);
	}

	// Token: 0x06012AF0 RID: 76528 RVA: 0x00526EFC File Offset: 0x005250FC
	public void SkipVoicePlayingAnimation()
	{
		if (this.VoicePlayPromise != null)
		{
			this.VoicePlayPromise.SetResult(false);
			this.VoicePlayPromise = null;
		}
		this.StopVoicePlayingAnimation();
		if (this.VoiceHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.VoiceHandle);
			this.VoiceHandle = null;
		}
	}

	// Token: 0x06012AF1 RID: 76529 RVA: 0x00526F4A File Offset: 0x0052514A
	public void StopVoicePlayingAnimation()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Voice_Play_Loop", false, true);
	}

	// Token: 0x06012AF2 RID: 76530 RVA: 0x00526F60 File Offset: 0x00525160
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

	// Token: 0x06012AF3 RID: 76531 RVA: 0x00526F92 File Offset: 0x00525192
	private void OnBtnSelfClick()
	{
		Action<int> onItemClickDelegate = this.OnItemClickDelegate;
		if (onItemClickDelegate != null)
		{
			onItemClickDelegate(base.GridIndex);
		}
		this.RefreshVoiceDisplayItem();
	}

	// Token: 0x06012AF4 RID: 76532 RVA: 0x00526FB1 File Offset: 0x005251B1
	private void RefreshSpeakerNameTextColor()
	{
		base.GetText(2).SetUIActive(ModelBase<PhoneMsgModel>.Instance.IsUsingDefaultChatBg);
		base.GetText(11).SetUIActive(!ModelBase<PhoneMsgModel>.Instance.IsUsingDefaultChatBg);
	}

	// Token: 0x06012AF5 RID: 76533 RVA: 0x00526FE4 File Offset: 0x005251E4
	public UniTask ShowVoiceTextPanel(Action afterShow = null)
	{
		PhoneMsgOtherChatItem.<ShowVoiceTextPanel>d__41 <ShowVoiceTextPanel>d__;
		<ShowVoiceTextPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowVoiceTextPanel>d__.<>4__this = this;
		<ShowVoiceTextPanel>d__.afterShow = afterShow;
		<ShowVoiceTextPanel>d__.<>1__state = -1;
		<ShowVoiceTextPanel>d__.<>t__builder.Start<PhoneMsgOtherChatItem.<ShowVoiceTextPanel>d__41>(ref <ShowVoiceTextPanel>d__);
		return <ShowVoiceTextPanel>d__.<>t__builder.Task;
	}

	// Token: 0x040091F8 RID: 37368
	protected PhoneMsgChatData PhoneMsgChatData;

	// Token: 0x040091F9 RID: 37369
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040091FA RID: 37370
	private TimerHandle InputHandle;

	// Token: 0x040091FB RID: 37371
	private TimerHandle VoiceHandle;

	// Token: 0x040091FC RID: 37372
	private CustomPromise<bool> InputPromise;

	// Token: 0x040091FD RID: 37373
	private CustomPromise<bool> VoicePlayPromise;

	// Token: 0x040091FE RID: 37374
	protected PhoneMsgLinkButton LinkButton;

	// Token: 0x040091FF RID: 37375
	public int ItemIndex = -1;

	// Token: 0x04009200 RID: 37376
	public Action<int> OnItemClickDelegate;
}
