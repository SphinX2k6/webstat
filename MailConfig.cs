using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002221 RID: 8737
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MailConfig : ConfigBase<MailConfig>
{
	// Token: 0x0601078E RID: 67470 RVA: 0x0047FAAB File Offset: 0x0047DCAB
	public int? GetMailSize()
	{
		return ConfigCommonParamById.GetIntConfig("mail_size");
	}

	// Token: 0x0601078F RID: 67471 RVA: 0x0047FAB7 File Offset: 0x0047DCB7
	public int? GetFavoriteMailSize()
	{
		return ConfigCommonParamById.GetIntConfig("MailFavoriteSize");
	}

	// Token: 0x06010790 RID: 67472 RVA: 0x0047FAC4 File Offset: 0x0047DCC4
	public int GetMailSpaceWarningThresholdRate()
	{
		return ConfigCommonParamById.GetIntConfig("MailWarningThreshold").GetValueOrDefault();
	}

	// Token: 0x06010791 RID: 67473 RVA: 0x0047FAE4 File Offset: 0x0047DCE4
	public int GetMailSpaceWarningThreshold()
	{
		double valueOrDefault = (double)this.GetMailSize().GetValueOrDefault();
		int mailSpaceWarningThresholdRate = this.GetMailSpaceWarningThresholdRate();
		return (int)Math.Floor(valueOrDefault * (double)mailSpaceWarningThresholdRate / 100.0);
	}

	// Token: 0x06010792 RID: 67474 RVA: 0x0047FB1C File Offset: 0x0047DD1C
	public IReadOnlyList<MailFilter> GetAllMailFilterConfig()
	{
		IReadOnlyList<MailFilter> configList = ConfigMailFilterAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return new List<MailFilter>();
	}

	// Token: 0x06010793 RID: 67475 RVA: 0x0047FB3C File Offset: 0x0047DD3C
	public EMailFilter[] GetFilterTypeList()
	{
		HashSet<EMailFilter> hashSet = new HashSet<EMailFilter>();
		foreach (MailFilter mailFilter in this.GetAllMailFilterConfig())
		{
			EMailFilter id = (EMailFilter)mailFilter.Id;
			if (id != EMailFilter.FilterUnScanned)
			{
				hashSet.Add(id);
			}
		}
		List<EMailFilter> list = new List<EMailFilter>();
		foreach (EMailFilter item in MailFilterDisplayOrder.mailFilterDisplayOrder)
		{
			if (hashSet.Contains(item))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06010794 RID: 67476 RVA: 0x0047FBE0 File Offset: 0x0047DDE0
	public MailFilter GetMailFilterConfigById(int id)
	{
		MailFilter? config = ConfigMailFilterById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Mail;
			ELogAuthor author = ELogAuthor.LK;
			string message = "缺少邮件筛选配置 ID:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x06010795 RID: 67477 RVA: 0x0047FC34 File Offset: 0x0047DE34
	public MailTo? GetMailToConfigById(int id)
	{
		if (id <= 0)
		{
			return null;
		}
		return ConfigMailToById.GetConfig(id, true);
	}

	// Token: 0x06010796 RID: 67478 RVA: 0x0047FC58 File Offset: 0x0047DE58
	public void ApplyTemplateJumpId(MailData mailData)
	{
		if (mailData.GetSubContentJumpId() > 0)
		{
			return;
		}
		Mail? mail = (mailData.ConfigId > 0) ? ConfigMailByMailId.GetConfig(mailData.ConfigId, true) : null;
		if (mail != null && mail.Value.JumpId > 0)
		{
			mailData.SetShowSubContentJumpId(mail.Value.JumpId);
		}
	}
}
