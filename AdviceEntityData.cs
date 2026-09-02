using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001771 RID: 6001
[NullableContext(1)]
[Nullable(0)]
public class AdviceEntityData
{
	// Token: 0x0600A8EB RID: 43243 RVA: 0x002CFE2B File Offset: 0x002CE02B
	public void Phrase(AdviceComponentPb data)
	{
		this.AdviceData = new AdviceData();
		this.PlayerId = (long)data.PlayerId;
		this.PlayerName = data.PlayerName;
		this.AdviceData.Phrase(data.Advice);
	}

	// Token: 0x0600A8EC RID: 43244 RVA: 0x002CFE62 File Offset: 0x002CE062
	public void PhraseVote(long up)
	{
		this.AdviceData.PhraseUpDownData(up);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceEntityNotify);
	}

	// Token: 0x0600A8ED RID: 43245 RVA: 0x002CFE80 File Offset: 0x002CE080
	public void PhraseContent(List<PbAdviceContent> data)
	{
		this.AdviceData.PhraseData(data);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAdviceEntityNotify);
	}

	// Token: 0x0600A8EE RID: 43246 RVA: 0x002CFE9E File Offset: 0x002CE09E
	public long GetPlayerId()
	{
		return this.PlayerId;
	}

	// Token: 0x0600A8EF RID: 43247 RVA: 0x002CFEA6 File Offset: 0x002CE0A6
	public string GetPlayerName()
	{
		return this.PlayerName;
	}

	// Token: 0x0600A8F0 RID: 43248 RVA: 0x002CFEAE File Offset: 0x002CE0AE
	[NullableContext(2)]
	public AdviceData GetAdviceData()
	{
		return this.AdviceData;
	}

	// Token: 0x04004F87 RID: 20359
	private long PlayerId;

	// Token: 0x04004F88 RID: 20360
	private string PlayerName = "";

	// Token: 0x04004F89 RID: 20361
	[Nullable(2)]
	private AdviceData AdviceData;
}
