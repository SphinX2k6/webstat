using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200222E RID: 8750
[NullableContext(1)]
[Nullable(0)]
public class MailTotalDropDownItem : MailDropDownItem
{
	// Token: 0x06010868 RID: 67688 RVA: 0x00484B54 File Offset: 0x00482D54
	public MailTotalDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06010869 RID: 67689 RVA: 0x00484B60 File Offset: 0x00482D60
	public override MailData[] GetFilteredMailList()
	{
		List<MailData> mailList = ModelBase<MailModel>.Instance.GetMailList();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Mail;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "邮件界面：获取全部邮件";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("length", (mailList != null) ? new int?(mailList.Count) : null);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return mailList.ToArray();
	}

	// Token: 0x0601086A RID: 67690 RVA: 0x00484BC4 File Offset: 0x00482DC4
	public override string GetTitleText()
	{
		int mailListLength = ModelBase<MailModel>.Instance.GetMailListLength();
		int mailCapacity = ModelBase<MailModel>.Instance.GetMailCapacity();
		if (ModelBase<MailModel>.Instance.IsMailSpaceNearFull())
		{
			return StringUtils.Format("<color=#c25757>{0}</color>/{1}", new string[]
			{
				mailListLength.ToString(),
				mailCapacity.ToString()
			});
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Email_Inbox_Number", null);
		if (string.IsNullOrEmpty(localTextNew))
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(mailListLength);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(mailCapacity);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return StringUtils.Format(localTextNew, new string[]
		{
			mailListLength.ToString(),
			mailCapacity.ToString()
		});
	}

	// Token: 0x0601086B RID: 67691 RVA: 0x00484C79 File Offset: 0x00482E79
	protected override void OnShowDropDownItemBase(MailFilter data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		base.SetMailCount(this.GetTitleText());
	}
}
