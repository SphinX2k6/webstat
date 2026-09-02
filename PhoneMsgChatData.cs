using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhoneMessage;

// Token: 0x02002560 RID: 9568
[NullableContext(1)]
[Nullable(0)]
public class PhoneMsgChatData
{
	// Token: 0x1700178E RID: 6030
	// (get) Token: 0x060129E4 RID: 76260 RVA: 0x00521D72 File Offset: 0x0051FF72
	public bool IsVoicePlayed
	{
		get
		{
			return this.ContentType == EChatMsgType.Voice && this.VoiceEventHash != 0 && ModelBase<PhoneMsgModel>.Instance.TryGetVoiceRedDot(this.VoiceEventHash);
		}
	}

	// Token: 0x060129E5 RID: 76261 RVA: 0x00521D98 File Offset: 0x0051FF98
	public PhoneMsgChatData(EPhoneMsgContentType chatContentType)
	{
		this.ChatContentType = chatContentType;
	}

	// Token: 0x060129E6 RID: 76262 RVA: 0x00521DD0 File Offset: 0x0051FFD0
	public void SetScrollWaitTime(int time)
	{
		if (time > 0)
		{
			this.ScrollWaitTimeType = EPhoneMsgScrollWaitTimeType.LoadConfig;
			this.ScrollWaitTime = time;
			return;
		}
		if (this.ContentStr.Length > 0)
		{
			int length = this.ContentStr.Length;
			foreach (PhoneMsgInputTimeData phoneMsgInputTimeData in ModelBase<PhoneMsgModel>.Instance.MsgInputTimeList)
			{
				int delayTime = phoneMsgInputTimeData.GetDelayTime(length);
				if (delayTime >= 0)
				{
					this.ScrollWaitTimeType = EPhoneMsgScrollWaitTimeType.AutoGenByChatNum;
					this.ScrollWaitTime = delayTime;
					return;
				}
			}
		}
		this.ScrollWaitTimeType = EPhoneMsgScrollWaitTimeType.FinalTime;
		this.ScrollWaitTime = 1000;
	}

	// Token: 0x04009135 RID: 37173
	public EPhoneMsgContentType ChatContentType = EPhoneMsgContentType.Tips;

	// Token: 0x04009136 RID: 37174
	public EChatMsgType ContentType;

	// Token: 0x04009137 RID: 37175
	public int SpeakerIcon;

	// Token: 0x04009138 RID: 37176
	public string SpeakerHeadIconPath = "";

	// Token: 0x04009139 RID: 37177
	public string SpeakerName = "";

	// Token: 0x0400913A RID: 37178
	public int ChatDialogId;

	// Token: 0x0400913B RID: 37179
	[Nullable(2)]
	public ITalkItem TalkItem;

	// Token: 0x0400913C RID: 37180
	public string ContentStr = "";

	// Token: 0x0400913D RID: 37181
	public int ContentNum;

	// Token: 0x0400913E RID: 37182
	public bool IsSendError;

	// Token: 0x0400913F RID: 37183
	public bool IsFinish;

	// Token: 0x04009140 RID: 37184
	public int QuestId;

	// Token: 0x04009141 RID: 37185
	public int BirthdayCardItemId;

	// Token: 0x04009142 RID: 37186
	public int DropId;

	// Token: 0x04009143 RID: 37187
	public bool IsGroupChat;

	// Token: 0x04009144 RID: 37188
	public int VoiceEventHash;

	// Token: 0x04009145 RID: 37189
	public float VoiceDuration;

	// Token: 0x04009146 RID: 37190
	public EPhoneMessageVoicePushCondition? PushCondition;

	// Token: 0x04009147 RID: 37191
	public bool IsAutoPlay;

	// Token: 0x04009148 RID: 37192
	public int ScrollWaitTime;

	// Token: 0x04009149 RID: 37193
	public EPhoneMsgScrollWaitTimeType ScrollWaitTimeType;

	// Token: 0x0400914A RID: 37194
	public int ShortMessageId;

	// Token: 0x0400914B RID: 37195
	public int ChatPartnerId;

	// Token: 0x0400914C RID: 37196
	public long UnLockTime;
}
