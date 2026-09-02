using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x0200159F RID: 5535
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketConditionData
{
	// Token: 0x06009BAF RID: 39855 RVA: 0x0028BC3C File Offset: 0x00289E3C
	public void Init(ScratchCardTimeInfo condition)
	{
		this.Id = condition.Id;
		this.Config = ConfigBase<ActivityScratchTicketConfig>.Instance.GetScratchTicketConditionConfig(this.Id);
		if (this.Config == null)
		{
			return;
		}
		this.ConditionType = (EScratchTicketConditionType)this.Config.Value.TaskType;
		this.RefreshCondition(condition);
	}

	// Token: 0x06009BB0 RID: 39856 RVA: 0x0028BC99 File Offset: 0x00289E99
	public void RefreshCondition(ScratchCardTimeInfo condition)
	{
		this.Progress = condition.Progress;
		this.FinishCount = condition.FinishCount;
	}

	// Token: 0x06009BB1 RID: 39857 RVA: 0x0028BCB4 File Offset: 0x00289EB4
	public bool IsFinish()
	{
		return this.FinishCount >= this.Config.Value.RefreshTimesLimit;
	}

	// Token: 0x06009BB2 RID: 39858 RVA: 0x0028BCE0 File Offset: 0x00289EE0
	public string GetConditionDesc()
	{
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.Config.Value.TaskName, null);
		if (this.ConditionType == EScratchTicketConditionType.DailyLogin)
		{
			return localTextNew;
		}
		int[] array = this.Config.Value.TaskParams();
		if (array.Length == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ScratchTicket;
			ELogAuthor author = ELogAuthor.BB;
			string message = "刮刮乐ScratchCardTimesRe参数TaskParams配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "";
		}
		return StringUtils.Format(localTextNew, new string[]
		{
			array[0].ToString(),
			this.Progress.ToString(),
			this.FinishCount.ToString(),
			this.Config.Value.RefreshTimesLimit.ToString()
		});
	}

	// Token: 0x06009BB3 RID: 39859 RVA: 0x0028BDBC File Offset: 0x00289FBC
	public string GetConditionTypeName()
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.Config.Value.TaskTypeName, null);
	}

	// Token: 0x040047BA RID: 18362
	public int Id;

	// Token: 0x040047BB RID: 18363
	private ScratchCardTimesRe? Config;

	// Token: 0x040047BC RID: 18364
	private EScratchTicketConditionType ConditionType = EScratchTicketConditionType.DailyLogin;

	// Token: 0x040047BD RID: 18365
	private int Progress;

	// Token: 0x040047BE RID: 18366
	private int FinishCount;
}
