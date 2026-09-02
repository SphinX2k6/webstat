using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Plot.Flow;
using Cysharp.Threading.Tasks;

// Token: 0x02003083 RID: 12419
[NullableContext(1)]
[Nullable(0)]
public class CharacterFlowLogic
{
	// Token: 0x17002276 RID: 8822
	// (get) Token: 0x060199B9 RID: 104889 RVA: 0x0077112D File Offset: 0x0076F32D
	// (set) Token: 0x060199BA RID: 104890 RVA: 0x00771135 File Offset: 0x0076F335
	protected bool IsExecuteFlowEnd
	{
		get
		{
			return this.IsExecuteFlowEndInternal;
		}
		set
		{
			if (this.IsExecuteFlowEndInternal == value)
			{
				return;
			}
			this.IsExecuteFlowEndInternal = value;
			PawnHeadInfoComponent headInfoComp = this.HeadInfoComp;
			if (headInfoComp == null)
			{
				return;
			}
			headInfoComp.UpdateDialogUseState(!value);
		}
	}

	// Token: 0x060199BB RID: 104891 RVA: 0x0077115C File Offset: 0x0076F35C
	public bool IsShowDialogue()
	{
		return !this.IsExecuteFlowEnd && this.EnableUpdate && this.WaitSecondsRemain > 0.0 && !this.IsWaitForDialogueUi;
	}

	// Token: 0x17002277 RID: 8823
	// (get) Token: 0x060199BC RID: 104892 RVA: 0x0077118A File Offset: 0x0076F38A
	public bool IsPlaying
	{
		get
		{
			return !this.IsExecuteFlowEnd;
		}
	}

	// Token: 0x060199BD RID: 104893 RVA: 0x00771198 File Offset: 0x0076F398
	public CharacterFlowLogic(BaseActorComponent actorComp, BubbleComponent bubbleData)
	{
		this.ActorComp = actorComp;
		this.HeadInfoComp = actorComp.Entity.GetComponent<PawnHeadInfoComponent>();
		this.TempFlowInfoList = new List<IConditionBubbleData>();
		this.EntityConfigId = this.ActorComp.CreatureData.GetPbDataId();
		if (bubbleData != null)
		{
			this.EntityList = bubbleData.NpcIds;
			this.FlowInfoList = bubbleData.Flows;
		}
	}

	// Token: 0x060199BE RID: 104894 RVA: 0x00771230 File Offset: 0x0076F430
	public virtual void Tick(float deltaSeconds)
	{
		if (!this.EnableUpdate)
		{
			return;
		}
		if (this.IsWaitForDialogueUi)
		{
			return;
		}
		this.WaitSecondsRemain -= (double)deltaSeconds;
		if (this.WaitSecondsRemain <= 0.0)
		{
			if (this.IsExecuteFlowEnd)
			{
				if (!this.IsPause)
				{
					this.StartFlow();
					return;
				}
				this.EnableUpdate = false;
				return;
			}
			else
			{
				this.PlayTalk(this.CurrentTalkId + 1);
			}
		}
	}

	// Token: 0x060199BF RID: 104895 RVA: 0x0077129C File Offset: 0x0076F49C
	public void StartFlow()
	{
		this.FindRandomFlow();
		this.PlayFlow();
	}

	// Token: 0x060199C0 RID: 104896 RVA: 0x007712AC File Offset: 0x0076F4AC
	public void StopFlow()
	{
		this.IsExecuteFlowEnd = true;
		this.WaitSecondsRemain = 0.0;
		List<int> list;
		if (this.DynamicFlowData != null)
		{
			list = this.DynamicFlowData.EntityIds;
		}
		else
		{
			list = this.EntityList;
		}
		if (list != null && list.Count >= 2)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				Entity entity = this.GetEntity(list[i]);
				if (entity != null)
				{
					CharacterFlowComponent component = entity.GetComponent<CharacterFlowComponent>();
					if (component != null)
					{
						component.RemoveFlowActions();
					}
				}
				i++;
			}
			return;
		}
		CharacterFlowComponent component2 = this.ActorComp.Entity.GetComponent<CharacterFlowComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.RemoveFlowActions();
	}

	// Token: 0x060199C1 RID: 104897 RVA: 0x0077134C File Offset: 0x0076F54C
	protected void PlayFlow()
	{
		if (this.CurrentFlowInfo == null && this.DynamicFlowData == null)
		{
			this.HandleFlowEnd();
			return;
		}
		if (!this.IsFlowActorsReady())
		{
			return;
		}
		IBubbleIndex bubbleIndex = null;
		int value = 0;
		if (this.DynamicFlowData != null)
		{
			bubbleIndex = this.DynamicFlowData.Flow;
			IBubbleIndex flow = this.DynamicFlowData.Flow;
			value = ((flow != null) ? flow.StateId : null).GetValueOrDefault();
		}
		else
		{
			IBubbleData flow2 = this.CurrentFlowInfo.Flow;
			if (flow2 != null)
			{
				bubbleIndex = flow2.FlowIndex;
				IBubbleIndex flowIndex = flow2.FlowIndex;
				value = ((flowIndex != null) ? flowIndex.StateId : null).GetValueOrDefault();
			}
		}
		if (bubbleIndex == null)
		{
			this.HandleFlowEnd();
			return;
		}
		ShowTalk randomFlow = ConfigBase<FlowConfig>.Instance.GetRandomFlow(bubbleIndex.FlowListName, bubbleIndex.FlowId, this.ActorComp.Owner.GetName(), new int?(value));
		if (randomFlow != null)
		{
			this.CurrentTalkItems = randomFlow.TalkItems;
			this.IsExecuteFlowEnd = false;
			this.PlayTalk(0);
			this.TryToSendLogReport(bubbleIndex);
			return;
		}
		this.HandleFlowEnd();
	}

	// Token: 0x060199C2 RID: 104898 RVA: 0x0077145C File Offset: 0x0076F65C
	protected unsafe virtual void PlayTalk(int id)
	{
		this.CurrentTalkId = id;
		List<ITalkItem> currentTalkItems = this.CurrentTalkItems;
		if (id >= currentTalkItems.Count)
		{
			this.HandleFlowEnd();
			return;
		}
		IBubbleIndex bubbleIndex;
		if (this.DynamicFlowData == null)
		{
			IConditionBubbleData currentFlowInfo = this.CurrentFlowInfo;
			bubbleIndex = ((currentFlowInfo != null) ? currentFlowInfo.Flow.FlowIndex : null);
		}
		else
		{
			bubbleIndex = this.DynamicFlowData.Flow;
		}
		IBubbleIndex bubbleIndex2 = bubbleIndex;
		List<int> list = (this.DynamicFlowData != null) ? this.DynamicFlowData.EntityIds : this.EntityList;
		ITalkItem talkItem = currentTalkItems[id];
		Entity entity = this.ActorComp.Entity;
		if (list != null && list.Count >= 2)
		{
			int flowActorIndex = SimpleNpcFlowConditionChecker.GetFlowActorIndex(talkItem.WhoId.Value);
			if (flowActorIndex == -1)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Level;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "请配置演出目标";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("FlowName", (bubbleIndex2 != null) ? bubbleIndex2.FlowListName : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", (bubbleIndex2 != null) ? new int?(bubbleIndex2.FlowId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("StateId", (bubbleIndex2 != null) ? bubbleIndex2.StateId : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("TalkId", id);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
				this.PlayTalk(id + 1);
				return;
			}
			if (flowActorIndex >= list.Count)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Level;
				ELogAuthor author2 = ELogAuthor.YJX;
				string message2 = "演出目标索引越界";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("FlowName", (bubbleIndex2 != null) ? bubbleIndex2.FlowListName : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("FlowId", (bubbleIndex2 != null) ? new int?(bubbleIndex2.FlowId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("StateId", (bubbleIndex2 != null) ? bubbleIndex2.StateId : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("Index", flowActorIndex);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
				this.PlayTalk(id + 1);
				return;
			}
			int num = list[flowActorIndex];
			entity = this.GetEntity(num);
			if (entity == null)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Level;
				ELogAuthor author3 = ELogAuthor.YJX;
				string message3 = "播放多人冒泡时找不到演员,停止冒泡";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("MasterPbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ActorPbDataId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("FlowName", (bubbleIndex2 != null) ? bubbleIndex2.FlowListName : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("FlowId", (bubbleIndex2 != null) ? new int?(bubbleIndex2.FlowId) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("StateId", (bubbleIndex2 != null) ? bubbleIndex2.StateId : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 5) = new ValueTuple<string, object>("Index", flowActorIndex);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 6));
				this.HandleFlowEnd();
				return;
			}
		}
		if (this.HandleTalkAction(entity, talkItem))
		{
			this.IsExecuteFlowEnd = false;
			if (this.WaitSecondsRemain <= 0.0)
			{
				this.WaitSecondsRemain = (double)this.GetWaitSeconds(talkItem, 0f);
			}
			this.ActorComp.CreatureData.GetPbDataId();
			this.GetFlowText(talkItem.TidTalk);
			return;
		}
		this.PlayTalk(id + 1);
	}

	// Token: 0x060199C3 RID: 104899 RVA: 0x007718B8 File Offset: 0x0076FAB8
	protected virtual bool HandleTalkAction(Entity entity, ITalkItem config)
	{
		if (entity == null)
		{
			return false;
		}
		bool result = false;
		string flowText = this.GetFlowText(config.TidTalk);
		if (flowText != null)
		{
			result = true;
			this.WaitSecondsRemain = (double)this.GetWaitSeconds(config, 0f);
			double num = this.WaitSecondsRemain + 0.05000000074505806;
			this.IsWaitForDialogueUi = true;
			PawnHeadInfoComponent component = entity.GetComponent<PawnHeadInfoComponent>();
			if (component != null)
			{
				component.SetDialogueText(flowText, (float)num, false).ContinueWith(() => this.IsWaitForDialogueUi = false);
			}
		}
		return result;
	}

	// Token: 0x060199C4 RID: 104900 RVA: 0x00771934 File Offset: 0x0076FB34
	protected void HandleFlowEnd()
	{
		this.IsExecuteFlowEnd = true;
		this.IsWaitForDialogueUi = false;
		if (this.DynamicFlowData != null)
		{
			int? waitTime = this.DynamicFlowData.WaitTime;
			this.WaitSecondsRemain = (double)((waitTime != null) ? ((float)waitTime.GetValueOrDefault()) : 10f);
			DynamicFlowActorInfo dynamicFlowActorInfo = new DynamicFlowActorInfo();
			dynamicFlowActorInfo.PbDataId = this.ActorComp.CreatureData.GetPbDataId();
			dynamicFlowActorInfo.CreatureId = this.ActorComp.CreatureData.GetCreatureDataId();
			Action callback = ControllerBase<DynamicFlowController>.Instance.GetDynamicFlowByMasterActorInfo(dynamicFlowActorInfo).Callback;
			if (callback != null)
			{
				callback();
			}
		}
		else if (this.CurrentFlowInfo != null)
		{
			IBubbleData flow = this.CurrentFlowInfo.Flow;
			float num = 10f;
			if (flow.WaitTime != 0)
			{
				num = (float)flow.WaitTime;
			}
			this.WaitSecondsRemain = (double)num;
		}
		this.ResetFlowState();
	}

	// Token: 0x060199C5 RID: 104901 RVA: 0x00771A09 File Offset: 0x0076FC09
	protected virtual void ResetFlowState()
	{
		this.CurrentTalkItems = null;
		this.CurrentTalkId = 0;
		this.CurrentFlowInfo = null;
		this.DynamicFlowData = null;
	}

	// Token: 0x060199C6 RID: 104902 RVA: 0x00771A28 File Offset: 0x0076FC28
	protected void FindRandomFlow()
	{
		if (this.FindDynamicFlow())
		{
			return;
		}
		this.TempFlowInfoList.Clear();
		this.CurrentFlowInfo = null;
		foreach (IConditionBubbleData conditionBubbleData in this.FlowInfoList)
		{
			if (ControllerBase<LevelGeneralController>.Instance.CheckConditionNew(conditionBubbleData.Condition, this.ActorComp.Owner, EntityContext.Create(this.ActorComp.Entity.Id, null), null))
			{
				this.TempFlowInfoList.Add(conditionBubbleData);
			}
		}
		this.CurrentFlowInfo = ObjectUtils.GetRandomArrayItem<IConditionBubbleData>(this.TempFlowInfoList);
	}

	// Token: 0x060199C7 RID: 104903 RVA: 0x00771AF0 File Offset: 0x0076FCF0
	public void ResetWaitTime()
	{
		this.WaitSecondsRemain = 0.0;
	}

	// Token: 0x060199C8 RID: 104904 RVA: 0x00771B01 File Offset: 0x0076FD01
	public bool HasValidFlow()
	{
		return this.FlowInfoList.Count > 0;
	}

	// Token: 0x060199C9 RID: 104905 RVA: 0x00771B11 File Offset: 0x0076FD11
	[NullableContext(2)]
	protected Entity GetEntity(int pbDataId)
	{
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
		if (entityByPbDataId == null)
		{
			return null;
		}
		return entityByPbDataId.Entity;
	}

	// Token: 0x060199CA RID: 104906 RVA: 0x00771B2C File Offset: 0x0076FD2C
	protected float GetWaitSeconds(ITalkItem config, float offset = 0f)
	{
		return config.WaitTime.GetValueOrDefault(3f) + offset;
	}

	// Token: 0x060199CB RID: 104907 RVA: 0x00771B4E File Offset: 0x0076FD4E
	[NullableContext(2)]
	protected string GetFlowText(string textId)
	{
		if (!string.IsNullOrEmpty(textId))
		{
			return Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(textId);
		}
		return null;
	}

	// Token: 0x060199CC RID: 104908 RVA: 0x00771B68 File Offset: 0x0076FD68
	private void TryToSendLogReport(IBubbleIndex flowIndex)
	{
		PlayFlowLogData playFlowLogData = new PlayFlowLogData();
		playFlowLogData.i_bubble_type = ((this.DynamicFlowData != null) ? 2 : 1);
		playFlowLogData.s_flow_file = flowIndex.FlowListName;
		playFlowLogData.i_flow_id = flowIndex.FlowId;
		playFlowLogData.i_flow_status_id = flowIndex.StateId.GetValueOrDefault();
		playFlowLogData.i_config_id = this.EntityConfigId;
		playFlowLogData.i_area_id = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
		playFlowLogData.i_father_area_id = ModelBase<AreaModel>.Instance.AreaInfo.Value.Father;
		Vector actorLocationProxy = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
		playFlowLogData.f_pos_x = (float)actorLocationProxy.X;
		playFlowLogData.f_pos_y = (float)actorLocationProxy.Y;
		playFlowLogData.f_pos_z = (float)actorLocationProxy.Z;
		ControllerBase<LogReportController>.Instance.LogReport(playFlowLogData);
	}

	// Token: 0x060199CD RID: 104909 RVA: 0x00771C42 File Offset: 0x0076FE42
	public void HideDialogueText()
	{
		this.IsWaitForDialogueUi = false;
		PawnHeadInfoComponent headInfoComp = this.HeadInfoComp;
		if (headInfoComp == null)
		{
			return;
		}
		headInfoComp.HideDialogueText();
	}

	// Token: 0x060199CE RID: 104910 RVA: 0x00771C5B File Offset: 0x0076FE5B
	public bool HasDynamicFlow()
	{
		return this.DynamicFlowData != null;
	}

	// Token: 0x060199CF RID: 104911 RVA: 0x00771C68 File Offset: 0x0076FE68
	protected bool FindDynamicFlow()
	{
		DynamicFlowActorInfo dynamicFlowActorInfo = new DynamicFlowActorInfo();
		dynamicFlowActorInfo.PbDataId = this.ActorComp.CreatureData.GetPbDataId();
		dynamicFlowActorInfo.CreatureId = this.ActorComp.CreatureData.GetCreatureDataId();
		CharacterDynamicFlowData dynamicFlowByMasterActorInfo = ControllerBase<DynamicFlowController>.Instance.GetDynamicFlowByMasterActorInfo(dynamicFlowActorInfo);
		this.DynamicFlowData = ((dynamicFlowByMasterActorInfo != null) ? dynamicFlowByMasterActorInfo.BubbleData : null);
		return dynamicFlowByMasterActorInfo != null;
	}

	// Token: 0x060199D0 RID: 104912 RVA: 0x00771CCC File Offset: 0x0076FECC
	protected bool IsFlowActorsReady()
	{
		List<int> list;
		if (this.DynamicFlowData != null)
		{
			list = this.DynamicFlowData.EntityIds;
		}
		else
		{
			list = this.EntityList;
		}
		if (list == null || list.Count == 0)
		{
			BaseActorComponent actorComp = this.ActorComp;
			return actorComp != null && actorComp.Entity.IsInit;
		}
		foreach (int pbDataId in list)
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (entityByPbDataId == null || !entityByPbDataId.IsInit)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400CBBC RID: 52156
	private const float DEFAULT_WAIT_TIME = 3f;

	// Token: 0x0400CBBD RID: 52157
	private const float DEFAULT_LOOP_TIME = 10f;

	// Token: 0x0400CBBE RID: 52158
	private readonly int EntityConfigId;

	// Token: 0x0400CBBF RID: 52159
	[Nullable(2)]
	protected readonly BaseActorComponent ActorComp;

	// Token: 0x0400CBC0 RID: 52160
	[Nullable(2)]
	protected readonly PawnHeadInfoComponent HeadInfoComp;

	// Token: 0x0400CBC1 RID: 52161
	protected readonly List<IConditionBubbleData> FlowInfoList = new List<IConditionBubbleData>();

	// Token: 0x0400CBC2 RID: 52162
	protected readonly List<IConditionBubbleData> TempFlowInfoList = new List<IConditionBubbleData>();

	// Token: 0x0400CBC3 RID: 52163
	[Nullable(2)]
	protected IConditionBubbleData CurrentFlowInfo;

	// Token: 0x0400CBC4 RID: 52164
	protected List<int> EntityList = new List<int>();

	// Token: 0x0400CBC5 RID: 52165
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<ITalkItem> CurrentTalkItems;

	// Token: 0x0400CBC6 RID: 52166
	protected int CurrentTalkId;

	// Token: 0x0400CBC7 RID: 52167
	[Nullable(2)]
	protected AddPlayBubble DynamicFlowData;

	// Token: 0x0400CBC8 RID: 52168
	public bool IsPause = true;

	// Token: 0x0400CBC9 RID: 52169
	public bool EnableUpdate;

	// Token: 0x0400CBCA RID: 52170
	protected bool IsExecuteFlowEndInternal = true;

	// Token: 0x0400CBCB RID: 52171
	protected double WaitSecondsRemain;

	// Token: 0x0400CBCC RID: 52172
	protected bool IsWaitForDialogueUi;
}
