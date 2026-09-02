using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002223 RID: 8739
[NullableContext(1)]
[Nullable(0)]
public class MailData : ScrollViewDataBase
{
	// Token: 0x060107B7 RID: 67511 RVA: 0x00480E50 File Offset: 0x0047F050
	public EMailAttachment GetAttachmentStatus()
	{
		return this.AttachmentStatus;
	}

	// Token: 0x060107B8 RID: 67512 RVA: 0x00480E58 File Offset: 0x0047F058
	public unsafe void SetAttachmentStatus(EMailAttachment attachmentStatus)
	{
		this.AttachmentStatus = attachmentStatus;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件详情：设置附件领取状态";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MailId", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("attachmentStatus", attachmentStatus);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x060107B9 RID: 67513 RVA: 0x00480EC9 File Offset: 0x0047F0C9
	public bool GetWasScanned()
	{
		return this.MailScannedState == 1;
	}

	// Token: 0x060107BA RID: 67514 RVA: 0x00480ED4 File Offset: 0x0047F0D4
	public unsafe void SetWasScanned(int scanned)
	{
		this.MailScannedState = ((scanned == 1) ? scanned : 0);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件详情：设置阅读状态";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MailId", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("scanned", scanned);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x060107BB RID: 67515 RVA: 0x00480F4C File Offset: 0x0047F14C
	public void SetShowSubIconId(int iconId)
	{
		this.ShowSubIconId = iconId;
	}

	// Token: 0x060107BC RID: 67516 RVA: 0x00480F55 File Offset: 0x0047F155
	public void SetShowSubContentColor(string color)
	{
		this.ShowSubContentColor = color;
	}

	// Token: 0x060107BD RID: 67517 RVA: 0x00480F5E File Offset: 0x0047F15E
	public void SetShowSubContentJumpId(int jumpId)
	{
		this.ShowSubContentJumpId = jumpId;
	}

	// Token: 0x060107BE RID: 67518 RVA: 0x00480F67 File Offset: 0x0047F167
	public void SetShowSubContentJumpParam(int jumpParam)
	{
		this.ShowSubContentJumpParam = jumpParam;
	}

	// Token: 0x060107BF RID: 67519 RVA: 0x00480F70 File Offset: 0x0047F170
	public void SetShowSubContentJumpParam2(int jumpParam2)
	{
		this.ShowSubContentJumpParam2 = jumpParam2;
	}

	// Token: 0x060107C0 RID: 67520 RVA: 0x00480F79 File Offset: 0x0047F179
	public void SetQuestionActiveId(string questionId)
	{
		this.QuestionActiveId = questionId;
	}

	// Token: 0x060107C1 RID: 67521 RVA: 0x00480F82 File Offset: 0x0047F182
	public void SetSubTitle(string title)
	{
		this.SubTitle = title;
	}

	// Token: 0x060107C2 RID: 67522 RVA: 0x00480F8B File Offset: 0x0047F18B
	public void SetSubUrl(string url)
	{
		this.SubUrl = url;
	}

	// Token: 0x060107C3 RID: 67523 RVA: 0x00480F94 File Offset: 0x0047F194
	public void SetIsQuestion(bool isQuestion)
	{
		this.IsQuestion = isQuestion;
	}

	// Token: 0x060107C4 RID: 67524 RVA: 0x00480F9D File Offset: 0x0047F19D
	public void SetIfShowNewMail(bool show)
	{
		this.IfShowNewMail = show;
	}

	// Token: 0x060107C5 RID: 67525 RVA: 0x00480FA6 File Offset: 0x0047F1A6
	public void SetUseDefaultBrowser(bool use)
	{
		this.UseDefaultBrowser = use;
	}

	// Token: 0x060107C6 RID: 67526 RVA: 0x00480FAF File Offset: 0x0047F1AF
	public void SetQuestionPass(string pass)
	{
		this.QuestionPass = pass;
	}

	// Token: 0x060107C7 RID: 67527 RVA: 0x00480FB8 File Offset: 0x0047F1B8
	public void SetIfLandscape(bool landscape)
	{
		this.IfLandscape = landscape;
	}

	// Token: 0x060107C8 RID: 67528 RVA: 0x00480FC1 File Offset: 0x0047F1C1
	public void SetNeedPlayerInfo(bool need)
	{
		this.NeedPlayerInfo = need;
	}

	// Token: 0x060107C9 RID: 67529 RVA: 0x00480FCA File Offset: 0x0047F1CA
	public void SetPlayerInfoFormatStyle(int style)
	{
		this.PlayerInfoFormatStyle = style;
	}

	// Token: 0x060107CA RID: 67530 RVA: 0x00480FD3 File Offset: 0x0047F1D3
	public int GetReceiveTime()
	{
		return this.Time;
	}

	// Token: 0x060107CB RID: 67531 RVA: 0x00480FDB File Offset: 0x0047F1DB
	public int GetMailLevel()
	{
		return this.Level;
	}

	// Token: 0x060107CC RID: 67532 RVA: 0x00480FE3 File Offset: 0x0047F1E3
	public string GetTitle()
	{
		return this.Title;
	}

	// Token: 0x060107CD RID: 67533 RVA: 0x00480FEC File Offset: 0x0047F1EC
	public void SetText(string text)
	{
		this.Content = text;
		string[] array = text.Split(new string[]
		{
			"@&&"
		}, StringSplitOptions.None);
		this.ShowMainContent = array[0];
		if (array.Length > 1)
		{
			this.PhraseExtraItem(array[1]);
		}
	}

	// Token: 0x060107CE RID: 67534 RVA: 0x00481030 File Offset: 0x0047F230
	private void PhraseExtraItem(string subText)
	{
		this.ShowSubContentColor = "FFFFFFFF";
		this.ShowSubIconId = 0;
		this.ShowSubContentJumpId = 0;
		this.ShowSubContentJumpParam = 0;
		this.ShowSubContentJumpParam2 = 0;
		this.SubUrl = "";
		this.IsQuestion = false;
		this.QuestionActiveId = "";
		this.ShowSubContent = "";
		List<string> list = (from key in MailParamHandlerDefine.mailParamHandlerMapDefine.Keys
		orderby key.Length descending
		select key).ToList<string>();
		string separator = "|";
		IEnumerable<string> source = list;
		Func<string, string> selector;
		if ((selector = MailData.<>O.<0>__Escape) == null)
		{
			selector = (MailData.<>O.<0>__Escape = new Func<string, string>(Regex.Escape));
		}
		string str = string.Join(separator, source.Select(selector));
		foreach (string text in (from item in new Regex("[,\\s;]+(?=(?:" + str + ")(?:=|[,\\s;]|$))").Split(subText)
		where item.Length > 0
		select item).ToArray<string>())
		{
			int num = text.IndexOf('=');
			string key2 = (num != -1) ? text.Substring(0, num) : text;
			IMailParamHandler mailParamHandler;
			if (MailParamHandlerDefine.mailParamHandlerMapDefine.TryGetValue(key2, out mailParamHandler))
			{
				string value = (num != -1) ? text.Substring(num + 1) : "";
				mailParamHandler.Handler(this, value);
			}
			else
			{
				this.ShowSubContent += text;
			}
		}
	}

	// Token: 0x060107CF RID: 67535 RVA: 0x004811AC File Offset: 0x0047F3AC
	public bool GetIfLandscape()
	{
		return this.IfLandscape;
	}

	// Token: 0x060107D0 RID: 67536 RVA: 0x004811B4 File Offset: 0x0047F3B4
	public bool GetUseDefaultBrowser()
	{
		return this.UseDefaultBrowser;
	}

	// Token: 0x060107D1 RID: 67537 RVA: 0x004811BC File Offset: 0x0047F3BC
	public bool GetIfShowNewMail()
	{
		return this.IfShowNewMail;
	}

	// Token: 0x060107D2 RID: 67538 RVA: 0x004811C4 File Offset: 0x0047F3C4
	public string GetText()
	{
		return this.ShowMainContent;
	}

	// Token: 0x060107D3 RID: 67539 RVA: 0x004811CC File Offset: 0x0047F3CC
	public string GetSubText()
	{
		return this.ShowSubContent;
	}

	// Token: 0x060107D4 RID: 67540 RVA: 0x004811D4 File Offset: 0x0047F3D4
	public string GetQuestionPass()
	{
		return this.QuestionPass;
	}

	// Token: 0x060107D5 RID: 67541 RVA: 0x004811DC File Offset: 0x0047F3DC
	public int GetSubTextIconId()
	{
		return this.ShowSubIconId;
	}

	// Token: 0x060107D6 RID: 67542 RVA: 0x004811E4 File Offset: 0x0047F3E4
	public string GetSubTextColor()
	{
		return this.ShowSubContentColor;
	}

	// Token: 0x060107D7 RID: 67543 RVA: 0x004811EC File Offset: 0x0047F3EC
	public bool IsQuestionMail()
	{
		return this.IsQuestion;
	}

	// Token: 0x060107D8 RID: 67544 RVA: 0x004811F4 File Offset: 0x0047F3F4
	public string GetQuestionUrl()
	{
		LoginModel instance = ModelBase<LoginModel>.Instance;
		PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
		string stringConfig = ConfigCommonParamById.GetStringConfig("mail_question_key");
		string[] array = new string[5];
		array[0] = this.QuestionActiveId;
		int num = 1;
		int? id = instance2.GetId();
		array[num] = ((id != null) ? id.GetValueOrDefault().ToString() : null);
		array[2] = ";";
		int num2 = 3;
		string serverId = instance.GetServerId();
		array[num2] = ((serverId != null) ? serverId.ToString() : null);
		array[4] = stringConfig;
		string text = string.Concat(array);
		text = UKuroStaticLibrary.HashStringWithSHA1(text);
		int questionnaireId = ConfigBase<LanguageConfig>.Instance.GetLanguageDefineByLanguageCode(Singleton<LanguageSystem>.Instance.PackageLanguage).Value.QuestionnaireId;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 5);
		defaultInterpolatedStringHandler.AppendFormatted(this.SubUrl);
		defaultInterpolatedStringHandler.AppendLiteral("?sojumpparm=");
		id = instance2.GetId();
		defaultInterpolatedStringHandler.AppendFormatted((id != null) ? id.GetValueOrDefault().ToString() : null);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		string serverId2 = instance.GetServerId();
		defaultInterpolatedStringHandler.AppendFormatted((serverId2 != null) ? serverId2.ToString() : null);
		defaultInterpolatedStringHandler.AppendLiteral("&parmsign=");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		defaultInterpolatedStringHandler.AppendLiteral("&langv=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(questionnaireId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060107D9 RID: 67545 RVA: 0x00481348 File Offset: 0x0047F548
	public string GetSubUrl()
	{
		string text = this.SubUrl;
		if (this.NeedPlayerInfo)
		{
			PublicUtil.EExternalUrlReason reason = (this.PlayerInfoFormatStyle == 0) ? PublicUtil.EExternalUrlReason.Mail : PublicUtil.EExternalUrlReason.MailH5;
			text = (Singleton<PublicUtil>.Instance.GetExternalUrl(text, reason) ?? text);
			text = Singleton<PublicUtil>.Instance.GetExtendExternalUrl(text, !this.UseDefaultBrowser);
		}
		return text;
	}

	// Token: 0x060107DA RID: 67546 RVA: 0x00481399 File Offset: 0x0047F599
	public string GetSubTitle()
	{
		return this.SubTitle;
	}

	// Token: 0x060107DB RID: 67547 RVA: 0x004813A1 File Offset: 0x0047F5A1
	public string GetLinkButtonTitle()
	{
		if (this.ShowSubContent.Length > 0)
		{
			return this.ShowSubContent;
		}
		return this.SubTitle;
	}

	// Token: 0x060107DC RID: 67548 RVA: 0x004813BE File Offset: 0x0047F5BE
	public int GetSubContentJumpId()
	{
		return this.ShowSubContentJumpId;
	}

	// Token: 0x060107DD RID: 67549 RVA: 0x004813C6 File Offset: 0x0047F5C6
	public int GetSubContentJumpParam()
	{
		return this.ShowSubContentJumpParam;
	}

	// Token: 0x060107DE RID: 67550 RVA: 0x004813CE File Offset: 0x0047F5CE
	public int GetSubContentJumpParam2()
	{
		return this.ShowSubContentJumpParam2;
	}

	// Token: 0x060107DF RID: 67551 RVA: 0x004813D6 File Offset: 0x0047F5D6
	public string GetSender()
	{
		return this.Sender;
	}

	// Token: 0x060107E0 RID: 67552 RVA: 0x004813DE File Offset: 0x0047F5DE
	public PbMailAttachment[] GetAttachmentInfo()
	{
		return this.AttachmentInfos;
	}

	// Token: 0x060107E1 RID: 67553 RVA: 0x004813E6 File Offset: 0x0047F5E6
	public long GetExpiryTime()
	{
		return this.ExpiryTime;
	}

	// Token: 0x060107E2 RID: 67554 RVA: 0x004813F0 File Offset: 0x0047F5F0
	public bool IsPastScheduledDeletionTime()
	{
		if (!this.IsIntervalMail)
		{
			return false;
		}
		long num = (this.IntervalExpiryTime > 0L) ? this.IntervalExpiryTime : this.ExpiryTime;
		return num > 0L && Singleton<TimeUtil>.Instance.GetServerTimeStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond >= (double)num;
	}

	// Token: 0x060107E3 RID: 67555 RVA: 0x00481444 File Offset: 0x0047F644
	public bool NeedExpiredUnfavoriteConfirm()
	{
		return this.IsIntervalMail && this.IsFavorite && this.IsPastScheduledDeletionTime();
	}

	// Token: 0x060107E4 RID: 67556 RVA: 0x0048145E File Offset: 0x0047F65E
	public bool CanShowFavoriteControl()
	{
		return this.GetWasScanned() && this.GetAttachmentStatus() != EMailAttachment.AttachmentRemained;
	}

	// Token: 0x060107E5 RID: 67557 RVA: 0x00481476 File Offset: 0x0047F676
	public void SetFavorite(bool isFavorite)
	{
		this.IsFavorite = isFavorite;
	}

	// Token: 0x060107E6 RID: 67558 RVA: 0x0048147F File Offset: 0x0047F67F
	public void SetAddReason(int reason)
	{
		this.AddReason = reason;
	}

	// Token: 0x060107E7 RID: 67559 RVA: 0x00481488 File Offset: 0x0047F688
	public int GetAddReason()
	{
		return this.AddReason;
	}

	// Token: 0x040081B5 RID: 33205
	public string Id = "0";

	// Token: 0x040081B6 RID: 33206
	public int ConfigId;

	// Token: 0x040081B7 RID: 33207
	public int Time;

	// Token: 0x040081B8 RID: 33208
	public int FinishTime;

	// Token: 0x040081B9 RID: 33209
	public int Level = 1;

	// Token: 0x040081BA RID: 33210
	public string Title = "";

	// Token: 0x040081BB RID: 33211
	public string Content = "";

	// Token: 0x040081BC RID: 33212
	public string Sender = "";

	// Token: 0x040081BD RID: 33213
	public long ExpiryTime;

	// Token: 0x040081BE RID: 33214
	public bool IsIntervalMail;

	// Token: 0x040081BF RID: 33215
	public long IntervalExpiryTime;

	// Token: 0x040081C0 RID: 33216
	public PbMailAttachment[] AttachmentInfos = new PbMailAttachment[0];

	// Token: 0x040081C1 RID: 33217
	public long ReadTime;

	// Token: 0x040081C2 RID: 33218
	private EMailAttachment AttachmentStatus;

	// Token: 0x040081C3 RID: 33219
	private int MailScannedState;

	// Token: 0x040081C4 RID: 33220
	private string ShowMainContent = "";

	// Token: 0x040081C5 RID: 33221
	private string ShowSubContent = "";

	// Token: 0x040081C6 RID: 33222
	private int ShowSubIconId;

	// Token: 0x040081C7 RID: 33223
	private string ShowSubContentColor = "";

	// Token: 0x040081C8 RID: 33224
	private int ShowSubContentJumpId;

	// Token: 0x040081C9 RID: 33225
	private int ShowSubContentJumpParam;

	// Token: 0x040081CA RID: 33226
	private int ShowSubContentJumpParam2;

	// Token: 0x040081CB RID: 33227
	private string QuestionActiveId = "";

	// Token: 0x040081CC RID: 33228
	private string SubTitle = "";

	// Token: 0x040081CD RID: 33229
	private string SubUrl = "";

	// Token: 0x040081CE RID: 33230
	private bool IsQuestion;

	// Token: 0x040081CF RID: 33231
	private bool IfShowNewMail;

	// Token: 0x040081D0 RID: 33232
	private bool UseDefaultBrowser;

	// Token: 0x040081D1 RID: 33233
	private string QuestionPass = "";

	// Token: 0x040081D2 RID: 33234
	private bool IfLandscape = true;

	// Token: 0x040081D3 RID: 33235
	private bool NeedPlayerInfo;

	// Token: 0x040081D4 RID: 33236
	private int PlayerInfoFormatStyle;

	// Token: 0x040081D5 RID: 33237
	public bool IsFavorite;

	// Token: 0x040081D6 RID: 33238
	private int AddReason;

	// Token: 0x020084FE RID: 34046
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402D092 RID: 184466
		[Nullable(0)]
		public static Func<string, string> <0>__Escape;
	}
}
