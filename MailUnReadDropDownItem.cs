using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222F RID: 8751
[NullableContext(1)]
[Nullable(0)]
public class MailUnReadDropDownItem : MailDropDownItem
{
	// Token: 0x0601086C RID: 67692 RVA: 0x00484CA4 File Offset: 0x00482EA4
	public MailUnReadDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0601086D RID: 67693 RVA: 0x00484CB0 File Offset: 0x00482EB0
	public override MailData[] GetFilteredMailList()
	{
		List<MailData> unScanMails = ModelBase<MailModel>.Instance.GetUnScanMails(null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：获取未读邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("length", (unScanMails != null) ? new int?(unScanMails.Count) : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return unScanMails.ToArray();
	}

	// Token: 0x0601086E RID: 67694 RVA: 0x00484D14 File Offset: 0x00482F14
	public override string GetTitleText()
	{
		return this.GetFilteredMailList().Length.ToString();
	}

	// Token: 0x0601086F RID: 67695 RVA: 0x00484D31 File Offset: 0x00482F31
	protected override void OnShowDropDownItemBase(MailFilter data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		base.SetMailCount(this.GetTitleText());
	}
}
