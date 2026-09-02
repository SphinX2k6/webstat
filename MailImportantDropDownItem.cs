using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222D RID: 8749
[NullableContext(1)]
[Nullable(0)]
public class MailImportantDropDownItem : MailDropDownItem
{
	// Token: 0x06010864 RID: 67684 RVA: 0x00484A9C File Offset: 0x00482C9C
	public MailImportantDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06010865 RID: 67685 RVA: 0x00484AA8 File Offset: 0x00482CA8
	public override MailData[] GetFilteredMailList()
	{
		List<MailData> importantMails = ModelBase<MailModel>.Instance.GetImportantMails(null);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：获取重要邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("length", (importantMails != null) ? new int?(importantMails.Count) : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return importantMails.ToArray();
	}

	// Token: 0x06010866 RID: 67686 RVA: 0x00484B0C File Offset: 0x00482D0C
	public override string GetTitleText()
	{
		return this.GetFilteredMailList().Length.ToString();
	}

	// Token: 0x06010867 RID: 67687 RVA: 0x00484B29 File Offset: 0x00482D29
	protected override void OnShowDropDownItemBase(MailFilter data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		base.SetMailCount(this.GetTitleText());
	}
}
