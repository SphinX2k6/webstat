using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

// Token: 0x02003089 RID: 12425
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class DynamicFlowController : ControllerBase<DynamicFlowController>
{
	// Token: 0x060199DC RID: 104924 RVA: 0x00772074 File Offset: 0x00770274
	protected override bool OnInit()
	{
		this.SetUpDynamicFlowTypePriority();
		Singleton<Net>.Instance.Register<EntityAddBubbleNotify>(ENotifyMessageId.EntityAddBubbleNotify, new Action<EntityAddBubbleNotify, Net.CallbackStatus>(this.AddDynamicFlowNotify));
		Singleton<Net>.Instance.Register<EntityRemoveBubbleNotify>(ENotifyMessageId.EntityRemoveBubbleNotify, new Action<EntityRemoveBubbleNotify, Net.CallbackStatus>(this.ClearDynamicFlowNotify));
		return true;
	}

	// Token: 0x060199DD RID: 104925 RVA: 0x007720C0 File Offset: 0x007702C0
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityAddBubbleNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityRemoveBubbleNotify);
		return true;
	}

	// Token: 0x060199DE RID: 104926 RVA: 0x007720E3 File Offset: 0x007702E3
	private void SetUpDynamicFlowTypePriority()
	{
		this.DynamicFlowTypePriority[EDynamicFlowType.LevelAi] = 5;
		this.DynamicFlowTypePriority[EDynamicFlowType.LevelEventClient] = 20;
		this.DynamicFlowTypePriority[EDynamicFlowType.LevelEventServer] = 20;
		this.DynamicFlowTypePriority[EDynamicFlowType.FlowAction] = 20;
	}

	// Token: 0x060199DF RID: 104927 RVA: 0x0077211C File Offset: 0x0077031C
	[NullableContext(2)]
	private void AddDynamicFlowNotify(EntityAddBubbleNotify data, Net.CallbackStatus status)
	{
		AddPlayBubble bubbleData = ConfigBase<BubbleConfig>.Instance.GetBubbleData(data.ActionGuid);
		long creatureId = Singleton<MathUtils>.Instance.LongToNumber(data.EntityId);
		if (bubbleData == null)
		{
			return;
		}
		CharacterDynamicFlowData data2 = (bubbleData.EntityIds.Count != 0) ? this.CreateCharacterFlowData(bubbleData) : this.CreateCharacterFlowDataForMasterCreatureId(creatureId, bubbleData);
		this.AddDynamicFlow(data2);
	}

	// Token: 0x060199E0 RID: 104928 RVA: 0x00772178 File Offset: 0x00770378
	[NullableContext(2)]
	private void ClearDynamicFlowNotify(EntityRemoveBubbleNotify data, Net.CallbackStatus status)
	{
		AddPlayBubble bubbleData = ConfigBase<BubbleConfig>.Instance.GetBubbleData(data.ActionGuid);
		long creatureId = Singleton<MathUtils>.Instance.LongToNumber(data.EntityId);
		if (bubbleData == null)
		{
			return;
		}
		DynamicFlowActorInfo dynamicFlowActorInfo = new DynamicFlowActorInfo();
		if (bubbleData.EntityIds.Count != 0)
		{
			dynamicFlowActorInfo.PbDataId = bubbleData.EntityIds[0];
		}
		else
		{
			dynamicFlowActorInfo.CreatureId = creatureId;
		}
		this.RemoveDynamicFlow(dynamicFlowActorInfo);
	}

	// Token: 0x060199E1 RID: 104929 RVA: 0x007721E4 File Offset: 0x007703E4
	public CharacterDynamicFlowData CreateCharacterFlowData(AddPlayBubble flowData)
	{
		return new CharacterDynamicFlowData
		{
			MasterInfo = new DynamicFlowActorInfo
			{
				PbDataId = ((flowData.EntityIds.Count != 0) ? flowData.EntityIds[0] : 0)
			},
			BubbleData = flowData,
			Type = new EDynamicFlowType?(EDynamicFlowType.LevelEventServer)
		};
	}

	// Token: 0x060199E2 RID: 104930 RVA: 0x00772238 File Offset: 0x00770438
	public CharacterDynamicFlowData CreateCharacterFlowDataForMasterCreatureId(long creatureId, AddPlayBubble flowData)
	{
		return new CharacterDynamicFlowData
		{
			MasterInfo = new DynamicFlowActorInfo
			{
				CreatureId = creatureId
			},
			BubbleData = flowData,
			Type = new EDynamicFlowType?(EDynamicFlowType.LevelEventServer)
		};
	}

	// Token: 0x060199E3 RID: 104931 RVA: 0x00772274 File Offset: 0x00770474
	public bool AddDynamicFlow(CharacterDynamicFlowData data)
	{
		if (((data != null) ? data.BubbleData : null) == null)
		{
			return false;
		}
		int dynamicFlowPriority = this.GetDynamicFlowPriority(data.Type);
		foreach (int num in data.BubbleData.EntityIds)
		{
			if (this.PbDataIdFlowActors.ContainsKey(num))
			{
				CharacterDynamicFlowData dynamicFlowByActorPbDataId = this.GetDynamicFlowByActorPbDataId(num);
				int dynamicFlowPriority2 = this.GetDynamicFlowPriority(dynamicFlowByActorPbDataId.Type);
				if (dynamicFlowPriority <= dynamicFlowPriority2)
				{
					return false;
				}
			}
		}
		DynamicFlowActorInfo masterInfo = data.MasterInfo;
		if (masterInfo == null || !masterInfo.IsValid())
		{
			return false;
		}
		EntityHandle flowActorEntityHandle = this.GetFlowActorEntityHandle(data.MasterInfo);
		if (flowActorEntityHandle != null)
		{
			WorldEntity entity = flowActorEntityHandle.Entity;
			if (((entity != null) ? new bool?(entity.IsInit) : null).GetValueOrDefault())
			{
				WorldEntity entity2 = flowActorEntityHandle.Entity;
				CharacterFlowComponent characterFlowComponent = (entity2 != null) ? entity2.GetComponent<CharacterFlowComponent>() : null;
				if (characterFlowComponent != null)
				{
					characterFlowComponent.PlayDynamicFlowBegin(data);
				}
			}
		}
		this.UpdateDynamicFlowCache(data, true);
		return true;
	}

	// Token: 0x060199E4 RID: 104932 RVA: 0x00772394 File Offset: 0x00770594
	public bool RemoveDynamicFlow(DynamicFlowActorInfo actorInfo)
	{
		DynamicFlowActorInfo masterActorInfoByActorInfo = this.GetMasterActorInfoByActorInfo(actorInfo);
		if (masterActorInfoByActorInfo == null)
		{
			return false;
		}
		CharacterDynamicFlowData dynamicFlowByMasterActorInfo = this.GetDynamicFlowByMasterActorInfo(masterActorInfoByActorInfo);
		if (dynamicFlowByMasterActorInfo == null)
		{
			return false;
		}
		EntityHandle flowActorEntityHandle = this.GetFlowActorEntityHandle(masterActorInfoByActorInfo);
		if (flowActorEntityHandle != null)
		{
			WorldEntity entity = flowActorEntityHandle.Entity;
			if (((entity != null) ? new bool?(entity.IsInit) : null).GetValueOrDefault())
			{
				WorldEntity entity2 = flowActorEntityHandle.Entity;
				CharacterFlowComponent characterFlowComponent = (entity2 != null) ? entity2.GetComponent<CharacterFlowComponent>() : null;
				if (characterFlowComponent != null)
				{
					characterFlowComponent.PlayDynamicFlowEnd();
				}
			}
		}
		this.UpdateDynamicFlowCache(dynamicFlowByMasterActorInfo, false);
		return true;
	}

	// Token: 0x060199E5 RID: 104933 RVA: 0x00772418 File Offset: 0x00770618
	protected void UpdateDynamicFlowCache(CharacterDynamicFlowData data, bool isAdd)
	{
		DynamicFlowActorInfo masterInfo = data.MasterInfo;
		if (isAdd)
		{
			if (masterInfo.PbDataId != 0)
			{
				this.PbDataIdFlowDataMap[masterInfo.PbDataId] = data;
				this.PbDataIdFlowActors[masterInfo.PbDataId] = masterInfo;
			}
			if (masterInfo.CreatureId != 0L)
			{
				this.CreatureIdFlowDataMap[masterInfo.CreatureId] = data;
				this.CreatureIdFlowActors[masterInfo.CreatureId] = masterInfo;
			}
			using (List<int>.Enumerator enumerator = data.BubbleData.EntityIds.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int key = enumerator.Current;
					this.PbDataIdFlowActors[key] = masterInfo;
				}
				return;
			}
		}
		foreach (int key2 in data.BubbleData.EntityIds)
		{
			this.PbDataIdFlowActors.Remove(key2);
		}
		this.PbDataIdFlowDataMap.Remove(masterInfo.PbDataId);
		this.PbDataIdFlowActors.Remove(masterInfo.PbDataId);
		this.CreatureIdFlowDataMap.Remove(masterInfo.CreatureId);
		this.CreatureIdFlowActors.Remove(masterInfo.CreatureId);
	}

	// Token: 0x060199E6 RID: 104934 RVA: 0x00772574 File Offset: 0x00770774
	[NullableContext(2)]
	public EntityHandle GetFlowActorEntityHandle(DynamicFlowActorInfo actorInfo)
	{
		if (actorInfo == null)
		{
			return null;
		}
		EntityHandle entityHandle = null;
		if (entityHandle == null && actorInfo.PbDataId != 0)
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(actorInfo.PbDataId);
		}
		if (entityHandle == null && actorInfo.CreatureId != 0L)
		{
			entityHandle = ModelBase<CreatureModel>.Instance.GetEntity(actorInfo.CreatureId);
		}
		return entityHandle;
	}

	// Token: 0x060199E7 RID: 104935 RVA: 0x007725C4 File Offset: 0x007707C4
	[NullableContext(2)]
	public CharacterDynamicFlowData GetDynamicFlowByActorPbDataId(int pbDataId)
	{
		DynamicFlowActorInfo valueOrDefault = this.PbDataIdFlowActors.GetValueOrDefault(pbDataId);
		if (valueOrDefault == null)
		{
			return null;
		}
		return this.GetDynamicFlowByMasterActorInfo(valueOrDefault);
	}

	// Token: 0x060199E8 RID: 104936 RVA: 0x007725EA File Offset: 0x007707EA
	[NullableContext(2)]
	public CharacterDynamicFlowData GetDynamicFlowByMasterActorPbDataId(int masterPbDataId)
	{
		if (masterPbDataId == 0)
		{
			return null;
		}
		return this.PbDataIdFlowDataMap.GetValueOrDefault(masterPbDataId);
	}

	// Token: 0x060199E9 RID: 104937 RVA: 0x00772600 File Offset: 0x00770800
	[return: Nullable(2)]
	public DynamicFlowActorInfo GetMasterActorInfoByActorInfo(DynamicFlowActorInfo actorInfo)
	{
		if (actorInfo == null || !actorInfo.IsValid())
		{
			return null;
		}
		if (actorInfo.PbDataId != 0 && this.PbDataIdFlowActors.ContainsKey(actorInfo.PbDataId))
		{
			return this.PbDataIdFlowActors.GetValueOrDefault(actorInfo.PbDataId);
		}
		if (actorInfo.CreatureId != 0L && this.CreatureIdFlowActors.ContainsKey(actorInfo.CreatureId))
		{
			return this.CreatureIdFlowActors.GetValueOrDefault(actorInfo.CreatureId);
		}
		return null;
	}

	// Token: 0x060199EA RID: 104938 RVA: 0x0077267C File Offset: 0x0077087C
	[return: Nullable(2)]
	public CharacterDynamicFlowData GetDynamicFlowByActorInfo(DynamicFlowActorInfo actorInfo)
	{
		DynamicFlowActorInfo masterActorInfoByActorInfo = this.GetMasterActorInfoByActorInfo(actorInfo);
		if (masterActorInfoByActorInfo == null || !masterActorInfoByActorInfo.IsValid())
		{
			return null;
		}
		return this.GetDynamicFlowByMasterActorInfo(masterActorInfoByActorInfo);
	}

	// Token: 0x060199EB RID: 104939 RVA: 0x007726AC File Offset: 0x007708AC
	[return: Nullable(2)]
	public CharacterDynamicFlowData GetDynamicFlowByMasterActorInfo(DynamicFlowActorInfo masterInfo)
	{
		if (!masterInfo.IsValid())
		{
			return null;
		}
		if (masterInfo.PbDataId != 0 && this.PbDataIdFlowDataMap.ContainsKey(masterInfo.PbDataId))
		{
			return this.PbDataIdFlowDataMap.GetValueOrDefault(masterInfo.PbDataId);
		}
		if (masterInfo.CreatureId != 0L && this.CreatureIdFlowDataMap.ContainsKey(masterInfo.CreatureId))
		{
			return this.CreatureIdFlowDataMap.GetValueOrDefault(masterInfo.CreatureId);
		}
		return null;
	}

	// Token: 0x060199EC RID: 104940 RVA: 0x0077271E File Offset: 0x0077091E
	public int GetDynamicFlowPriority(EDynamicFlowType? type)
	{
		if (type == null || !this.DynamicFlowTypePriority.ContainsKey(type.Value))
		{
			return 1;
		}
		return this.DynamicFlowTypePriority[type.Value];
	}

	// Token: 0x060199ED RID: 104941 RVA: 0x00772754 File Offset: 0x00770954
	public FlowRangeInfo GetRangeInfoFromConfig(float minRadius, float maxRadius, [Nullable(2)] IBubbleRangeCylinderConfig config)
	{
		FlowRangeInfo flowRangeInfo = new FlowRangeInfo();
		flowRangeInfo.MinRadius = minRadius;
		flowRangeInfo.MaxRadius = maxRadius;
		flowRangeInfo.MinHeight = 0f;
		flowRangeInfo.MaxHeight = 0f;
		if (config != null)
		{
			flowRangeInfo.MinRadius = config.InnerConfig.Radius;
			flowRangeInfo.MaxRadius = config.OuterConfig.Radius;
			flowRangeInfo.MinHeight = config.InnerConfig.Height;
			flowRangeInfo.MaxHeight = config.OuterConfig.Height;
		}
		return flowRangeInfo;
	}

	// Token: 0x0400CBDF RID: 52191
	public const float DEFAULT_BUBBLE_ENTER_RANGE = 500f;

	// Token: 0x0400CBE0 RID: 52192
	public const float DEFAULT_BUBBLE_LEAVE_RANGE = 1500f;

	// Token: 0x0400CBE1 RID: 52193
	public const float DEFAULT_BUBBLE_LEAVE_HEIGHT = 3000f;

	// Token: 0x0400CBE2 RID: 52194
	private readonly Dictionary<int, CharacterDynamicFlowData> PbDataIdFlowDataMap = new Dictionary<int, CharacterDynamicFlowData>();

	// Token: 0x0400CBE3 RID: 52195
	private readonly Dictionary<long, CharacterDynamicFlowData> CreatureIdFlowDataMap = new Dictionary<long, CharacterDynamicFlowData>();

	// Token: 0x0400CBE4 RID: 52196
	private readonly Dictionary<int, DynamicFlowActorInfo> PbDataIdFlowActors = new Dictionary<int, DynamicFlowActorInfo>();

	// Token: 0x0400CBE5 RID: 52197
	private readonly Dictionary<long, DynamicFlowActorInfo> CreatureIdFlowActors = new Dictionary<long, DynamicFlowActorInfo>();

	// Token: 0x0400CBE6 RID: 52198
	private readonly Dictionary<EDynamicFlowType, int> DynamicFlowTypePriority = new Dictionary<EDynamicFlowType, int>();

	// Token: 0x0400CBE7 RID: 52199
	private const int DEFAULT_TYPE_PRIORITY = 1;
}
