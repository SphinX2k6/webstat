using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.NPC.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x02000D13 RID: 3347
[NullableContext(2)]
[Nullable(0)]
public class NpcDecisionController
{
	// Token: 0x06004349 RID: 17225 RVA: 0x0007EC9C File Offset: 0x0007CE9C
	[NullableContext(1)]
	public void Init(AiController aiCtrl)
	{
		if (aiCtrl == null)
		{
			return;
		}
		this.AiComp = aiCtrl.CharAiDesignComp;
		if (this.AiComp == null)
		{
			return;
		}
		this.CheckQuestSet = new HashSet<int>();
		this.AddEvents();
	}

	// Token: 0x0600434A RID: 17226 RVA: 0x0007ECC8 File Offset: 0x0007CEC8
	private void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DayStateChange, new Action(this.OnDayStateChanged));
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestChanged));
	}

	// Token: 0x0600434B RID: 17227 RVA: 0x0007ED02 File Offset: 0x0007CF02
	private void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DayStateChange, new Action(this.OnDayStateChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestChanged));
	}

	// Token: 0x0600434C RID: 17228 RVA: 0x0007ED3C File Offset: 0x0007CF3C
	private void OnQuestChanged(int questId, QuestState state, EQuestStatusUpdateReason _)
	{
		if (this.AiComp == null)
		{
			return;
		}
		if (state != QuestState.Progress && state != QuestState.Finish)
		{
			return;
		}
		if (this.CheckQuestSet == null || !this.CheckQuestSet.Contains(questId))
		{
			return;
		}
		TsAiController tsAiController = this.AiComp.TsAiController;
		if (tsAiController == null)
		{
			return;
		}
		IBPI_NpcEcological_C ibpi_NpcEcological_C = tsAiController as IBPI_NpcEcological_C;
		if (ibpi_NpcEcological_C == null)
		{
			return;
		}
		ibpi_NpcEcological_C.HandleQuestChanged();
	}

	// Token: 0x0600434D RID: 17229 RVA: 0x0007ED94 File Offset: 0x0007CF94
	private void OnDayStateChanged()
	{
		if (!this.CheckDayState)
		{
			return;
		}
		if (this.AiComp == null)
		{
			return;
		}
		TsAiController tsAiController = this.AiComp.TsAiController;
		if (tsAiController == null)
		{
			return;
		}
		IBPI_NpcEcological_C ibpi_NpcEcological_C = tsAiController as IBPI_NpcEcological_C;
		if (ibpi_NpcEcological_C == null)
		{
			return;
		}
		ibpi_NpcEcological_C.HandleDayStateChanged();
	}

	// Token: 0x0600434E RID: 17230 RVA: 0x0007EDD3 File Offset: 0x0007CFD3
	public void AddQuestToCheckList(int questId)
	{
		HashSet<int> checkQuestSet = this.CheckQuestSet;
		if (checkQuestSet == null)
		{
			return;
		}
		checkQuestSet.Add(questId);
	}

	// Token: 0x0600434F RID: 17231 RVA: 0x0007EDE7 File Offset: 0x0007CFE7
	public void Destroy()
	{
		this.RemoveEvents();
		this.AiComp = null;
	}

	// Token: 0x040011A1 RID: 4513
	private CharacterAiComponent AiComp;

	// Token: 0x040011A2 RID: 4514
	private HashSet<int> CheckQuestSet;

	// Token: 0x040011A3 RID: 4515
	public bool CheckPlayerImpact;

	// Token: 0x040011A4 RID: 4516
	public bool CheckPlayerAttack;

	// Token: 0x040011A5 RID: 4517
	public bool CheckDayState;

	// Token: 0x040011A6 RID: 4518
	public bool CheckWeatherState;
}
