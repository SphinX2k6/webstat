using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020034AE RID: 13486
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BlackboardModel : ModelBase<BlackboardModel>
{
	// Token: 0x0601C722 RID: 116514 RVA: 0x00886F43 File Offset: 0x00885143
	protected override bool OnClear()
	{
		this.GlobalBlackboard.Clear();
		this.WorldBlackboard.Clear();
		this.CreatureDataComponentMap.Clear();
		return true;
	}

	// Token: 0x0601C723 RID: 116515 RVA: 0x00886F68 File Offset: 0x00885168
	[NullableContext(2)]
	public CreatureDataComponent GetCreatureDataComponent(int entityId)
	{
		if (this.CreatureDataComponentMap.ContainsKey(entityId))
		{
			return this.CreatureDataComponentMap.GetValueOrDefault(entityId);
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		this.CreatureDataComponentMap[entityId] = component;
		return component;
	}

	// Token: 0x0601C724 RID: 116516 RVA: 0x00886FD7 File Offset: 0x008851D7
	public void RemoveCreatureDataComponent(int entityId)
	{
		if (this.CreatureDataComponentMap.ContainsKey(entityId))
		{
			this.CreatureDataComponentMap.Remove(entityId);
		}
	}

	// Token: 0x0601C725 RID: 116517 RVA: 0x00886FF4 File Offset: 0x008851F4
	public int? GetIntValueByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new int?(value.GetIntValue());
	}

	// Token: 0x0601C726 RID: 116518 RVA: 0x00887028 File Offset: 0x00885228
	public void SetIntValueByGlobal(string key, int value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetIntValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Int);
		blackboardParam.SetIntValue(value);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C727 RID: 116519 RVA: 0x00887068 File Offset: 0x00885268
	[return: Nullable(2)]
	public IList<int> GetIntValuesByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetIntValues();
	}

	// Token: 0x0601C728 RID: 116520 RVA: 0x00887084 File Offset: 0x00885284
	public void SetIntValuesByGlobal(string key, int[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetIntValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.IntArray);
		blackboardParam.SetIntValues(values);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C729 RID: 116521 RVA: 0x008870C4 File Offset: 0x008852C4
	public long? GetLongValueByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetLongValue();
	}

	// Token: 0x0601C72A RID: 116522 RVA: 0x008870F0 File Offset: 0x008852F0
	public void SetLongValueByGlobal(string key, long value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetLongValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Long);
		blackboardParam.SetLongValue(value);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C72B RID: 116523 RVA: 0x00887130 File Offset: 0x00885330
	[return: Nullable(2)]
	public IList<long> GetLongValuesByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetLongValues();
	}

	// Token: 0x0601C72C RID: 116524 RVA: 0x0088714C File Offset: 0x0088534C
	public void SetLongValuesByGlobal(string key, long[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetLongValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.LongArray);
		blackboardParam.SetLongValues(values);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C72D RID: 116525 RVA: 0x0088718C File Offset: 0x0088538C
	public bool? GetBooleanValueByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new bool?(value.GetBooleanValue());
	}

	// Token: 0x0601C72E RID: 116526 RVA: 0x008871C0 File Offset: 0x008853C0
	public void SetBooleanValueByGlobal(string key, bool value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetBooleanValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Boolean);
		blackboardParam.SetBooleanValue(value);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C72F RID: 116527 RVA: 0x00887200 File Offset: 0x00885400
	public float? GetFloatValueByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new float?(value.GetFloatValue());
	}

	// Token: 0x0601C730 RID: 116528 RVA: 0x00887234 File Offset: 0x00885434
	public void SetFloatValueByGlobal(string key, float value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetFloatValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Float);
		blackboardParam.SetFloatValue(value);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C731 RID: 116529 RVA: 0x00887274 File Offset: 0x00885474
	[return: Nullable(2)]
	public IList<float> GetFloatValuesByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetFloatValues();
	}

	// Token: 0x0601C732 RID: 116530 RVA: 0x00887290 File Offset: 0x00885490
	public void SetFloatValuesByGlobal(string key, float[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetFloatValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.FloatArray);
		blackboardParam.SetFloatValues(values);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C733 RID: 116531 RVA: 0x008872D1 File Offset: 0x008854D1
	[return: Nullable(2)]
	public string GetStringValueByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetStringValue();
	}

	// Token: 0x0601C734 RID: 116532 RVA: 0x008872EC File Offset: 0x008854EC
	public void SetStringValueByGlobal(string key, string value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetStringValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.String);
		blackboardParam.SetStringValue(value);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C735 RID: 116533 RVA: 0x0088732C File Offset: 0x0088552C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<string> GetStringValuesByGlobal(string key)
	{
		BlackboardMap.BlackboardParam value = this.GlobalBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetStringValues();
	}

	// Token: 0x0601C736 RID: 116534 RVA: 0x00887348 File Offset: 0x00885548
	public void SetStringValuesByGlobal(string key, string[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.GlobalBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetStringValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.StringArray);
		blackboardParam.SetStringValues(values);
		this.GlobalBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C737 RID: 116535 RVA: 0x00887388 File Offset: 0x00885588
	public void SetValueByGlobal(string key, BlackboardMap.BlackboardParam blackboard)
	{
		this.GlobalBlackboard.SetValue(key, blackboard);
	}

	// Token: 0x0601C738 RID: 116536 RVA: 0x00887397 File Offset: 0x00885597
	public void RemoveValueByGlobal(string key)
	{
		this.GlobalBlackboard.RemoveValue(key);
	}

	// Token: 0x0601C739 RID: 116537 RVA: 0x008873A6 File Offset: 0x008855A6
	public void SetWorldBlackboardByProtocol(IList<BlackboardParam> worldBlackboard)
	{
	}

	// Token: 0x0601C73A RID: 116538 RVA: 0x008873A8 File Offset: 0x008855A8
	public int? GetIntValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new int?(value.GetIntValue());
	}

	// Token: 0x0601C73B RID: 116539 RVA: 0x008873DC File Offset: 0x008855DC
	public void SetIntValueByWorld(string key, int value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetIntValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Int);
		blackboardParam.SetIntValue(value);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C73C RID: 116540 RVA: 0x0088741C File Offset: 0x0088561C
	[return: Nullable(2)]
	public IList<int> GetIntValuesByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetIntValues();
	}

	// Token: 0x0601C73D RID: 116541 RVA: 0x00887438 File Offset: 0x00885638
	public void SetIntValuesByWorld(string key, int[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetIntValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.IntArray);
		blackboardParam.SetIntValues(values);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C73E RID: 116542 RVA: 0x00887478 File Offset: 0x00885678
	public long? GetLongValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetLongValue();
	}

	// Token: 0x0601C73F RID: 116543 RVA: 0x008874A4 File Offset: 0x008856A4
	public void SetLongValueByWorld(string key, long value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetLongValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Long);
		blackboardParam.SetLongValue(value);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C740 RID: 116544 RVA: 0x008874E4 File Offset: 0x008856E4
	[return: Nullable(2)]
	public IList<long> GetLongValuesByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetLongValues();
	}

	// Token: 0x0601C741 RID: 116545 RVA: 0x00887500 File Offset: 0x00885700
	public void SetLongValuesByWorld(string key, long[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetLongValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.LongArray);
		blackboardParam.SetLongValues(values);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C742 RID: 116546 RVA: 0x00887540 File Offset: 0x00885740
	public bool? GetBooleanValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new bool?(value.GetBooleanValue());
	}

	// Token: 0x0601C743 RID: 116547 RVA: 0x00887574 File Offset: 0x00885774
	public void SetBooleanValueByWorld(string key, bool value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetBooleanValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Boolean);
		blackboardParam.SetBooleanValue(value);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C744 RID: 116548 RVA: 0x008875B4 File Offset: 0x008857B4
	public float? GetFloatValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return new float?(value.GetFloatValue());
	}

	// Token: 0x0601C745 RID: 116549 RVA: 0x008875E8 File Offset: 0x008857E8
	public void SetFloatValueByWorld(string key, float value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetFloatValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Float);
		blackboardParam.SetFloatValue(value);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C746 RID: 116550 RVA: 0x00887628 File Offset: 0x00885828
	[return: Nullable(2)]
	public IList<float> GetFloatValuesByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetFloatValues();
	}

	// Token: 0x0601C747 RID: 116551 RVA: 0x00887644 File Offset: 0x00885844
	public void SetFloatValuesByWorld(string key, float[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetFloatValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.FloatArray);
		blackboardParam.SetFloatValues(values);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C748 RID: 116552 RVA: 0x00887685 File Offset: 0x00885885
	[return: Nullable(2)]
	public string GetStringValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetStringValue();
	}

	// Token: 0x0601C749 RID: 116553 RVA: 0x008876A0 File Offset: 0x008858A0
	public void SetStringValueByWorld(string key, string value)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetStringValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.String);
		blackboardParam.SetStringValue(value);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C74A RID: 116554 RVA: 0x008876E0 File Offset: 0x008858E0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<string> GetStringValuesByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetStringValues();
	}

	// Token: 0x0601C74B RID: 116555 RVA: 0x008876FC File Offset: 0x008858FC
	public void SetStringValuesByWorld(string key, string[] values)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetStringValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.StringArray);
		blackboardParam.SetStringValues(values);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C74C RID: 116556 RVA: 0x0088773C File Offset: 0x0088593C
	public void SetValueByWorld(string key, BlackboardMap.BlackboardParam blackboard)
	{
		this.WorldBlackboard.SetValue(key, blackboard);
	}

	// Token: 0x0601C74D RID: 116557 RVA: 0x0088774B File Offset: 0x0088594B
	public void RemoveValueByWorld(string key)
	{
		this.WorldBlackboard.RemoveValue(key);
	}

	// Token: 0x0601C74E RID: 116558 RVA: 0x0088775C File Offset: 0x0088595C
	public void SetVectorValueByWorld(string key, float x, float y, float z)
	{
		BlackboardMap.BlackboardParam blackboardParam = this.WorldBlackboard.GetValue(key);
		if (blackboardParam != null)
		{
			blackboardParam.SetVectorValue(x, y, z);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Vector);
		blackboardParam.SetVectorValue(x, y, z);
		this.WorldBlackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C74F RID: 116559 RVA: 0x008877A3 File Offset: 0x008859A3
	[return: Nullable(2)]
	public Aki.Protocol.Vector GetVectorValueByWorld(string key)
	{
		BlackboardMap.BlackboardParam value = this.WorldBlackboard.GetValue(key);
		if (value == null)
		{
			return null;
		}
		return value.GetVectorValue();
	}

	// Token: 0x0601C750 RID: 116560 RVA: 0x008877BC File Offset: 0x008859BC
	public int? GetIntValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return new int?(blackboardParam.GetIntValue());
	}

	// Token: 0x0601C751 RID: 116561 RVA: 0x0088780C File Offset: 0x00885A0C
	public void SetIntValueByEntity(int entityId, string key, int value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Int);
			blackboardParam.SetIntValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Int);
		blackboardParam.SetIntValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C752 RID: 116562 RVA: 0x00887864 File Offset: 0x00885A64
	[return: Nullable(2)]
	public IList<int> GetIntValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetIntValues();
	}

	// Token: 0x0601C753 RID: 116563 RVA: 0x0088789C File Offset: 0x00885A9C
	public void SetIntValuesByEntity(int entityId, string key, IList<int> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.IntArray);
			blackboardParam.SetIntValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.IntArray);
		blackboardParam.SetIntValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C754 RID: 116564 RVA: 0x008878F4 File Offset: 0x00885AF4
	public long? GetLongValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetLongValue();
	}

	// Token: 0x0601C755 RID: 116565 RVA: 0x0088793C File Offset: 0x00885B3C
	public void SetLongValueByEntity(int entityId, string key, long value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Long);
			blackboardParam.SetLongValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Long);
		blackboardParam.SetLongValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C756 RID: 116566 RVA: 0x00887994 File Offset: 0x00885B94
	[return: Nullable(2)]
	public IList<long> GetLongValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetLongValues();
	}

	// Token: 0x0601C757 RID: 116567 RVA: 0x008879CC File Offset: 0x00885BCC
	public void SetLongValuesByEntity(int entityId, string key, IList<long> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.LongArray);
			blackboardParam.SetLongValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.LongArray);
		blackboardParam.SetLongValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C758 RID: 116568 RVA: 0x00887A24 File Offset: 0x00885C24
	public bool? GetBooleanValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return new bool?(blackboardParam.GetBooleanValue());
	}

	// Token: 0x0601C759 RID: 116569 RVA: 0x00887A74 File Offset: 0x00885C74
	public void SetBooleanValueByEntity(int entityId, string key, bool value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Boolean);
			blackboardParam.SetBooleanValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Boolean);
		blackboardParam.SetBooleanValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C75A RID: 116570 RVA: 0x00887ACC File Offset: 0x00885CCC
	public float? GetFloatValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return new float?(blackboardParam.GetFloatValue());
	}

	// Token: 0x0601C75B RID: 116571 RVA: 0x00887B1C File Offset: 0x00885D1C
	public void SetFloatValueByEntity(int entityId, string key, float value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Float);
			blackboardParam.SetFloatValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Float);
		blackboardParam.SetFloatValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C75C RID: 116572 RVA: 0x00887B74 File Offset: 0x00885D74
	[return: Nullable(2)]
	public IList<float> GetFloatValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetFloatValues();
	}

	// Token: 0x0601C75D RID: 116573 RVA: 0x00887BAC File Offset: 0x00885DAC
	public void SetFloatValuesByEntity(int entityId, string key, IList<float> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.FloatArray);
			blackboardParam.SetFloatValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.FloatArray);
		blackboardParam.SetFloatValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C75E RID: 116574 RVA: 0x00887C04 File Offset: 0x00885E04
	[return: Nullable(2)]
	public string GetStringValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetStringValue();
	}

	// Token: 0x0601C75F RID: 116575 RVA: 0x00887C3C File Offset: 0x00885E3C
	public void SetStringValueByEntity(int entityId, string key, string value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.String);
			blackboardParam.SetStringValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.String);
		blackboardParam.SetStringValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C760 RID: 116576 RVA: 0x00887C94 File Offset: 0x00885E94
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<string> GetStringValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetStringValues();
	}

	// Token: 0x0601C761 RID: 116577 RVA: 0x00887CCC File Offset: 0x00885ECC
	public void SetStringValuesByEntity(int entityId, string key, IList<string> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.StringArray);
			blackboardParam.SetStringValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.StringArray);
		blackboardParam.SetStringValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C762 RID: 116578 RVA: 0x00887D24 File Offset: 0x00885F24
	[return: Nullable(2)]
	public Aki.Protocol.Vector GetVectorValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetVectorValue();
	}

	// Token: 0x0601C763 RID: 116579 RVA: 0x00887D5C File Offset: 0x00885F5C
	public void SetVectorValueByEntity(int entityId, string key, float x, float y, float z)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Vector);
			blackboardParam.SetVectorValue(x, y, z);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Vector);
		blackboardParam.SetVectorValue(x, y, z);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C764 RID: 116580 RVA: 0x00887DBC File Offset: 0x00885FBC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<Aki.Protocol.Vector> GetVectorValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetVectorValues();
	}

	// Token: 0x0601C765 RID: 116581 RVA: 0x00887DF4 File Offset: 0x00885FF4
	public void SetVectorValuesByEntity(int entityId, string key, IList<Aki.Protocol.Vector> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.VectorArray);
			blackboardParam.SetVectorValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.VectorArray);
		blackboardParam.SetVectorValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C766 RID: 116582 RVA: 0x00887E4C File Offset: 0x0088604C
	[return: Nullable(2)]
	public Aki.Protocol.Rotator GetRotatorValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetRotatorValue();
	}

	// Token: 0x0601C767 RID: 116583 RVA: 0x00887E84 File Offset: 0x00886084
	public void SetRotatorValueByEntity(int entityId, string key, float pitch, float roll, float yaw)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Rotator);
			blackboardParam.SetRotatorValue(pitch, roll, yaw);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Rotator);
		blackboardParam.SetRotatorValue(pitch, roll, yaw);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C768 RID: 116584 RVA: 0x00887EE4 File Offset: 0x008860E4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<Aki.Protocol.Rotator> GetRotatorValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetRotatorValues();
	}

	// Token: 0x0601C769 RID: 116585 RVA: 0x00887F1C File Offset: 0x0088611C
	public void SetRotatorValuesByEntity(int entityId, string key, IList<Aki.Protocol.Rotator> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.RotatorArray);
			blackboardParam.SetRotatorValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.RotatorArray);
		blackboardParam.SetRotatorValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C76A RID: 116586 RVA: 0x00887F74 File Offset: 0x00886174
	public long? GetEntityIdByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetLongValue();
	}

	// Token: 0x0601C76B RID: 116587 RVA: 0x00887FBC File Offset: 0x008861BC
	public void SetEntityIdByEntity(int entityId, string key, long value)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.Entity);
			blackboardParam.SetLongValue(value);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.Entity);
		blackboardParam.SetLongValue(value);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C76C RID: 116588 RVA: 0x00888014 File Offset: 0x00886214
	[return: Nullable(2)]
	public IList<int> GetEntityIdsByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return null;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		BlackboardMap.BlackboardParam blackboardParam = (blackboard != null) ? blackboard.GetValue(key) : null;
		if (blackboardParam == null)
		{
			return null;
		}
		return blackboardParam.GetIntValues();
	}

	// Token: 0x0601C76D RID: 116589 RVA: 0x0088804C File Offset: 0x0088624C
	public void SetEntityIdsByEntity(int entityId, string key, IList<int> values)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = blackboard.GetValue(key);
		if (blackboardParam != null)
		{
			BlackboardMap.CheckValueType(key, blackboardParam, BlackboardParamType.EntityArray);
			blackboardParam.SetIntValues(values);
			return;
		}
		blackboardParam = new BlackboardMap.BlackboardParam(BlackboardParamType.EntityArray);
		blackboardParam.SetIntValues(values);
		blackboard.SetValue(key, blackboardParam);
	}

	// Token: 0x0601C76E RID: 116590 RVA: 0x008880A4 File Offset: 0x008862A4
	public void SetValueByEntity(int entityId, string key, BlackboardMap.BlackboardParam blackboard)
	{
		CreatureDataComponent creatureDataComponent = this.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		creatureDataComponent.SetBlackboard(key, blackboard);
	}

	// Token: 0x0400E4E8 RID: 58600
	private readonly BlackboardMap GlobalBlackboard = new BlackboardMap();

	// Token: 0x0400E4E9 RID: 58601
	private readonly BlackboardMap WorldBlackboard = new BlackboardMap();

	// Token: 0x0400E4EA RID: 58602
	private readonly Dictionary<int, CreatureDataComponent> CreatureDataComponentMap = new Dictionary<int, CreatureDataComponent>();
}
