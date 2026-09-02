using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200346B RID: 13419
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BlackboardController : ControllerBase<BlackboardController>
{
	// Token: 0x0601C3B7 RID: 115639 RVA: 0x0086C38C File Offset: 0x0086A58C
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<WorldBlackboardNotify>(ENotifyMessageId.WorldBlackboardNotify, new Action<WorldBlackboardNotify, Net.CallbackStatus>(this.WorldBlackboardNotify));
		Singleton<Net>.Instance.Register<EntityBlackboardNotify>(ENotifyMessageId.EntityBlackboardNotify, new Action<EntityBlackboardNotify, Net.CallbackStatus>(this.EntityBlackboardNotify));
		Singleton<EventSystem>.Instance.Add(EEventName.RemoveCreatureDataComponentCache, new Action<int>(this.OnRemoveCreatureDataComponent));
		return true;
	}

	// Token: 0x0601C3B8 RID: 115640 RVA: 0x0086C3EE File Offset: 0x0086A5EE
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WorldBlackboardNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EntityBlackboardNotify);
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveCreatureDataComponentCache, new Action<int>(this.OnRemoveCreatureDataComponent));
		return true;
	}

	// Token: 0x0601C3B9 RID: 115641 RVA: 0x0086C42D File Offset: 0x0086A62D
	private void OnRemoveCreatureDataComponent(int entityId)
	{
		ModelBase<BlackboardModel>.Instance.RemoveCreatureDataComponent(entityId);
	}

	// Token: 0x0601C3BA RID: 115642 RVA: 0x0086C43C File Offset: 0x0086A63C
	private void WorldBlackboardPush(IList<BlackboardParam> blackboardFields)
	{
		WorldBlackboardRequest worldBlackboardRequest = new WorldBlackboardRequest();
		worldBlackboardRequest.Params.AddRange(blackboardFields);
		Singleton<Net>.Instance.Call<WorldBlackboardResponse>(ERequestMessageId.WorldBlackboardRequest, worldBlackboardRequest, delegate(WorldBlackboardResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x0601C3BB RID: 115643 RVA: 0x0086C48B File Offset: 0x0086A68B
	private void WorldBlackboardNotify(WorldBlackboardNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		this.SetWorldBlackboardsByProtocol(data.Params);
	}

	// Token: 0x0601C3BC RID: 115644 RVA: 0x0086C499 File Offset: 0x0086A699
	private void EntityBlackboardPush(long creatureDataId, IList<BlackboardParam> blackboardFields)
	{
		if (!this.IsNetworkMode())
		{
			return;
		}
		new EntityBlackboardRequest
		{
			EntityId = creatureDataId
		}.Params.AddRange(blackboardFields);
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.PushBlackboardParam(creatureDataId, blackboardFields);
		}
	}

	// Token: 0x0601C3BD RID: 115645 RVA: 0x0086C4D0 File Offset: 0x0086A6D0
	public void PushBlackboardParam(long creatureDataId, IList<BlackboardParam> blackboardFields)
	{
		Dictionary<string, BlackboardParam> dictionary;
		if (!this.PendingBlackboardParams.TryGetValue(creatureDataId, out dictionary))
		{
			dictionary = new Dictionary<string, BlackboardParam>();
			this.PendingBlackboardParams[creatureDataId] = dictionary;
		}
		foreach (BlackboardParam blackboardParam in blackboardFields)
		{
			if (ConfigBase<AiConfig>.Instance.CheckBlackboardWhiteList(blackboardParam.Key))
			{
				dictionary[blackboardParam.Key] = blackboardParam;
			}
		}
	}

	// Token: 0x0601C3BE RID: 115646 RVA: 0x0086C554 File Offset: 0x0086A754
	[return: Nullable(2)]
	public object GetBlackboardValue(BlackboardParam blackboardParam)
	{
		switch (blackboardParam.ValueCase)
		{
		case BlackboardParam.ValueOneofCase.IntValue:
			return blackboardParam.IntValue;
		case BlackboardParam.ValueOneofCase.IntValues:
			return blackboardParam.IntValues;
		case BlackboardParam.ValueOneofCase.LongValue:
			return blackboardParam.LongValue;
		case BlackboardParam.ValueOneofCase.LongValues:
			return blackboardParam.LongValues;
		case BlackboardParam.ValueOneofCase.BooleanValue:
			return blackboardParam.BooleanValue;
		case BlackboardParam.ValueOneofCase.StringValue:
			return blackboardParam.StringValue;
		case BlackboardParam.ValueOneofCase.StringValues:
			return blackboardParam.StringValues;
		case BlackboardParam.ValueOneofCase.FloatValue:
			return blackboardParam.FloatValue;
		case BlackboardParam.ValueOneofCase.FloatValues:
			return blackboardParam.FloatValues;
		case BlackboardParam.ValueOneofCase.VectorValue:
			return blackboardParam.VectorValue;
		case BlackboardParam.ValueOneofCase.VectorValues:
			return blackboardParam.VectorValues;
		case BlackboardParam.ValueOneofCase.RotatorValue:
			return blackboardParam.RotatorValue;
		case BlackboardParam.ValueOneofCase.RotatorValues:
			return blackboardParam.RotatorValues;
		default:
			return null;
		}
	}

	// Token: 0x0601C3BF RID: 115647 RVA: 0x0086C618 File Offset: 0x0086A818
	private void EntityBlackboardNotify(EntityBlackboardNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		long entityId = data.EntityId;
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
		if (entity == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[CreatureController.EntityBlackboardNotify] 不存在实体数据CreatureData。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreatureDataId", entityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		WorldEntity entity2 = entity.Entity;
		CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
		if (creatureDataComponent == null)
		{
			return;
		}
		creatureDataComponent.SetBlackboardsByProtocol(data.Params);
	}

	// Token: 0x0601C3C0 RID: 115648 RVA: 0x0086C689 File Offset: 0x0086A889
	public int? GetIntValueByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetIntValueByWorld(key);
	}

	// Token: 0x0601C3C1 RID: 115649 RVA: 0x0086C698 File Offset: 0x0086A898
	public void SetIntValueByWorld(string key, int value)
	{
		ModelBase<BlackboardModel>.Instance.SetIntValueByWorld(key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.Int,
				Key = key,
				IntValue = value
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3C2 RID: 115650 RVA: 0x0086C6E7 File Offset: 0x0086A8E7
	[return: Nullable(2)]
	public IList<int> GetIntValuesByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetIntValuesByWorld(key);
	}

	// Token: 0x0601C3C3 RID: 115651 RVA: 0x0086C6F4 File Offset: 0x0086A8F4
	public void SetIntValuesByWorld(string key, int[] values)
	{
		ModelBase<BlackboardModel>.Instance.SetIntValuesByWorld(key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.IntArray;
		blackboardParam.Key = key;
		blackboardParam.IntValues = new IntArrayBlackboard();
		blackboardParam.IntValues.Values.AddRange(values);
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3C4 RID: 115652 RVA: 0x0086C758 File Offset: 0x0086A958
	public long? GetLongValueByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetLongValueByWorld(key);
	}

	// Token: 0x0601C3C5 RID: 115653 RVA: 0x0086C768 File Offset: 0x0086A968
	public void SetLongValueByWorld(string key, long value)
	{
		ModelBase<BlackboardModel>.Instance.SetLongValueByWorld(key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.Long,
				Key = key,
				LongValue = Singleton<MathUtils>.Instance.BigIntToLong(value)
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3C6 RID: 115654 RVA: 0x0086C7C1 File Offset: 0x0086A9C1
	[return: Nullable(2)]
	public IList<long> GetLongValuesByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetLongValuesByWorld(key);
	}

	// Token: 0x0601C3C7 RID: 115655 RVA: 0x0086C7D0 File Offset: 0x0086A9D0
	public void SetLongValuesByWorld(string key, long[] values)
	{
		ModelBase<BlackboardModel>.Instance.SetLongValuesByWorld(key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.LongArray;
		blackboardParam.Key = key;
		blackboardParam.LongValues = new LongArrayBlackboard();
		for (int i = 0; i < values.Length; i++)
		{
			long item = Singleton<MathUtils>.Instance.BigIntToLong(values[i]);
			blackboardParam.LongValues.Values.Add(item);
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3C8 RID: 115656 RVA: 0x0086C850 File Offset: 0x0086AA50
	public bool? GetBooleanValueByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetBooleanValueByWorld(key);
	}

	// Token: 0x0601C3C9 RID: 115657 RVA: 0x0086C860 File Offset: 0x0086AA60
	public void SetBooleanValueByWorld(string key, bool value)
	{
		ModelBase<BlackboardModel>.Instance.SetBooleanValueByWorld(key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.Boolean,
				Key = key,
				BooleanValue = value
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3CA RID: 115658 RVA: 0x0086C8AF File Offset: 0x0086AAAF
	public float? GetFloatValueByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetFloatValueByWorld(key);
	}

	// Token: 0x0601C3CB RID: 115659 RVA: 0x0086C8BC File Offset: 0x0086AABC
	public void SetFloatValueByWorld(string key, float value)
	{
		ModelBase<BlackboardModel>.Instance.SetFloatValueByWorld(key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.Float,
				Key = key,
				FloatValue = value
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3CC RID: 115660 RVA: 0x0086C90B File Offset: 0x0086AB0B
	[return: Nullable(2)]
	public IList<float> GetFloatValuesByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetFloatValuesByWorld(key);
	}

	// Token: 0x0601C3CD RID: 115661 RVA: 0x0086C918 File Offset: 0x0086AB18
	public void SetFloatValuesByWorld(string key, float[] values)
	{
		ModelBase<BlackboardModel>.Instance.SetFloatValuesByWorld(key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.FloatArray;
		blackboardParam.Key = key;
		blackboardParam.FloatValues = new FloatArrayBlackboard();
		blackboardParam.FloatValues.Values.AddRange(values);
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3CE RID: 115662 RVA: 0x0086C97D File Offset: 0x0086AB7D
	[return: Nullable(2)]
	public string GetStringValueByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetStringValueByWorld(key);
	}

	// Token: 0x0601C3CF RID: 115663 RVA: 0x0086C98C File Offset: 0x0086AB8C
	public void SetStringValueByWorld(string key, string value)
	{
		ModelBase<BlackboardModel>.Instance.SetStringValueByWorld(key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.String,
				Key = key,
				StringValue = value
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3D0 RID: 115664 RVA: 0x0086C9DB File Offset: 0x0086ABDB
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<string> GetStringValuesByWorld(string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetStringValuesByWorld(key);
	}

	// Token: 0x0601C3D1 RID: 115665 RVA: 0x0086C9E8 File Offset: 0x0086ABE8
	public void SetStringValuesByWorld(string key, string[] values)
	{
		ModelBase<BlackboardModel>.Instance.SetStringValuesByWorld(key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.StringArray;
		blackboardParam.Key = key;
		blackboardParam.StringValues = new StringArrayBlackboard();
		blackboardParam.StringValues.Values.AddRange(values);
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3D2 RID: 115666 RVA: 0x0086CA4C File Offset: 0x0086AC4C
	public void RemoveValueByWorld(string key)
	{
		ModelBase<BlackboardModel>.Instance.RemoveValueByWorld(key);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.None,
				Key = key
			}
		};
		this.WorldBlackboardPush(blackboardFields);
	}

	// Token: 0x0601C3D3 RID: 115667 RVA: 0x0086CA94 File Offset: 0x0086AC94
	public void SetWorldBlackboardsByProtocol([Nullable(new byte[]
	{
		2,
		1
	})] IList<BlackboardParam> blackboards)
	{
		if (blackboards == null)
		{
			return;
		}
		foreach (BlackboardParam worldBlackboardByProtocol in blackboards)
		{
			this.SetWorldBlackboardByProtocol(worldBlackboardByProtocol);
		}
	}

	// Token: 0x0601C3D4 RID: 115668 RVA: 0x0086CAE0 File Offset: 0x0086ACE0
	[NullableContext(2)]
	public void SetWorldBlackboardByProtocol(BlackboardParam blackboard)
	{
		if (blackboard == null)
		{
			return;
		}
		BlackboardMap.BlackboardParam blackboardParam = BlackboardMap.BlackboardParam.CreateByProtocol(blackboard);
		if (blackboardParam != null)
		{
			ModelBase<BlackboardModel>.Instance.SetValueByWorld(blackboardParam.GetKey(), blackboardParam);
		}
	}

	// Token: 0x0601C3D5 RID: 115669 RVA: 0x0086CB0C File Offset: 0x0086AD0C
	public int? GetIntValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetIntValueByEntity(entityId, key);
	}

	// Token: 0x0601C3D6 RID: 115670 RVA: 0x0086CB1C File Offset: 0x0086AD1C
	public void SetIntValueByEntity(int entityId, string key, int value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetIntValueByEntity(entityId, key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Int;
		blackboardParam.Key = key;
		blackboardParam.IntValue = value;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3D7 RID: 115671 RVA: 0x0086CB84 File Offset: 0x0086AD84
	[return: Nullable(2)]
	public IList<int> GetIntValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetIntValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3D8 RID: 115672 RVA: 0x0086CB94 File Offset: 0x0086AD94
	public void SetIntValuesByEntity(int entityId, string key, IList<int> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetIntValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.IntArray;
		blackboardParam.Key = key;
		blackboardParam.IntValues = new IntArrayBlackboard();
		blackboardParam.IntValues.Values.AddRange(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3D9 RID: 115673 RVA: 0x0086CC11 File Offset: 0x0086AE11
	public long? GetLongValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetLongValueByEntity(entityId, key);
	}

	// Token: 0x0601C3DA RID: 115674 RVA: 0x0086CC20 File Offset: 0x0086AE20
	public void SetLongValueByEntity(int entityId, string key, long value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetLongValueByEntity(entityId, key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Long;
		blackboardParam.Key = key;
		blackboardParam.LongValue = Singleton<MathUtils>.Instance.BigIntToLong(value);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3DB RID: 115675 RVA: 0x0086CC92 File Offset: 0x0086AE92
	[return: Nullable(2)]
	public IList<long> GetLongValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetLongValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3DC RID: 115676 RVA: 0x0086CCA0 File Offset: 0x0086AEA0
	public void SetLongValuesByEntity(int entityId, string key, IList<long> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetLongValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.LongArray;
		blackboardParam.Key = key;
		blackboardParam.LongValues = new LongArrayBlackboard();
		for (int i = 0; i < values.Count; i++)
		{
			blackboardParam.LongValues.Values.Add(values[i]);
		}
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3DD RID: 115677 RVA: 0x0086CD39 File Offset: 0x0086AF39
	public bool? GetBooleanValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetBooleanValueByEntity(entityId, key);
	}

	// Token: 0x0601C3DE RID: 115678 RVA: 0x0086CD48 File Offset: 0x0086AF48
	public void SetBooleanValueByEntity(int entityId, string key, bool value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetBooleanValueByEntity(entityId, key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Boolean;
		blackboardParam.Key = key;
		blackboardParam.BooleanValue = value;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3DF RID: 115679 RVA: 0x0086CDB0 File Offset: 0x0086AFB0
	public float? GetFloatValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetFloatValueByEntity(entityId, key);
	}

	// Token: 0x0601C3E0 RID: 115680 RVA: 0x0086CDC0 File Offset: 0x0086AFC0
	public void SetFloatValueByEntity(int entityId, string key, float value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetFloatValueByEntity(entityId, key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Float;
		blackboardParam.Key = key;
		blackboardParam.FloatValue = value;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3E1 RID: 115681 RVA: 0x0086CE28 File Offset: 0x0086B028
	[return: Nullable(2)]
	public IList<float> GetFloatValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetFloatValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3E2 RID: 115682 RVA: 0x0086CE38 File Offset: 0x0086B038
	public void SetFloatValuesByEntity(int entityId, string key, IList<float> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetFloatValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.FloatArray;
		blackboardParam.Key = key;
		blackboardParam.FloatValues = new FloatArrayBlackboard();
		blackboardParam.FloatValues.Values.AddRange(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3E3 RID: 115683 RVA: 0x0086CEB6 File Offset: 0x0086B0B6
	[return: Nullable(2)]
	public string GetStringValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetStringValueByEntity(entityId, key);
	}

	// Token: 0x0601C3E4 RID: 115684 RVA: 0x0086CEC4 File Offset: 0x0086B0C4
	public void SetStringValueByEntity(int entityId, string key, string value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetStringValueByEntity(entityId, key, value);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.String;
		blackboardParam.Key = key;
		blackboardParam.StringValue = value;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3E5 RID: 115685 RVA: 0x0086CF2C File Offset: 0x0086B12C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<string> GetStringValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetStringValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3E6 RID: 115686 RVA: 0x0086CF3C File Offset: 0x0086B13C
	public void SetStringValuesByEntity(int entityId, string key, IList<string> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetStringValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.StringArray;
		blackboardParam.Key = key;
		blackboardParam.StringValues = new StringArrayBlackboard();
		blackboardParam.StringValues.Values.AddRange(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3E7 RID: 115687 RVA: 0x0086CFB9 File Offset: 0x0086B1B9
	[return: Nullable(2)]
	public Aki.Protocol.Vector GetVectorValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetVectorValueByEntity(entityId, key);
	}

	// Token: 0x0601C3E8 RID: 115688 RVA: 0x0086CFC7 File Offset: 0x0086B1C7
	public void SetVectorValueByGlobal(string key, float x, float y, float z)
	{
		ModelBase<BlackboardModel>.Instance.SetVectorValueByWorld(key, x, y, z);
	}

	// Token: 0x0601C3E9 RID: 115689 RVA: 0x0086CFD8 File Offset: 0x0086B1D8
	public void SetVectorValueByEntity(int entityId, string key, double x, double y, double z)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetVectorValueByEntity(entityId, key, (float)x, (float)y, (float)z);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Vector;
		blackboardParam.Key = key;
		blackboardParam.VectorValue = Aki.Protocol.Vector.Create();
		blackboardParam.VectorValue.X = (float)x;
		blackboardParam.VectorValue.Y = (float)y;
		blackboardParam.VectorValue.Z = (float)z;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3EA RID: 115690 RVA: 0x0086D075 File Offset: 0x0086B275
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<Aki.Protocol.Vector> GetVectorValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetVectorValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3EB RID: 115691 RVA: 0x0086D084 File Offset: 0x0086B284
	public void SetVectorValuesByEntity(int entityId, string key, IList<Aki.Protocol.Vector> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetVectorValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.VectorArray;
		blackboardParam.Key = key;
		blackboardParam.VectorValues = new VectorArrayBlackboard();
		blackboardParam.VectorValues.Values.Add(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3EC RID: 115692 RVA: 0x0086D102 File Offset: 0x0086B302
	[return: Nullable(2)]
	public Aki.Protocol.Rotator GetRotatorValueByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetRotatorValueByEntity(entityId, key);
	}

	// Token: 0x0601C3ED RID: 115693 RVA: 0x0086D110 File Offset: 0x0086B310
	public void SetRotatorValueByEntity(int entityId, string key, float pitch, float roll, float yaw)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetRotatorValueByEntity(entityId, key, pitch, roll, yaw);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.Rotator;
		blackboardParam.Key = key;
		blackboardParam.RotatorValue = Aki.Protocol.Rotator.Create();
		blackboardParam.RotatorValue.Pitch = pitch;
		blackboardParam.RotatorValue.Roll = roll;
		blackboardParam.RotatorValue.Yaw = yaw;
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3EE RID: 115694 RVA: 0x0086D1A7 File Offset: 0x0086B3A7
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public IList<Aki.Protocol.Rotator> GetRotatorValuesByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetRotatorValuesByEntity(entityId, key);
	}

	// Token: 0x0601C3EF RID: 115695 RVA: 0x0086D1B8 File Offset: 0x0086B3B8
	public void SetRotatorValuesByEntity(int entityId, string key, IList<Aki.Protocol.Rotator> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetRotatorValuesByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.RotatorArray;
		blackboardParam.Key = key;
		blackboardParam.RotatorValues = new RotatorArrayBlackboard();
		blackboardParam.RotatorValues.Values.AddRange(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3F0 RID: 115696 RVA: 0x0086D238 File Offset: 0x0086B438
	public int? GetEntityIdByEntity(int entityId, string key)
	{
		long? entityIdByEntity = ModelBase<BlackboardModel>.Instance.GetEntityIdByEntity(entityId, key);
		if (entityIdByEntity == null)
		{
			return null;
		}
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityIdByEntity.Value);
		return new int?((entity != null) ? entity.Id : 0);
	}

	// Token: 0x0601C3F1 RID: 115697 RVA: 0x0086D288 File Offset: 0x0086B488
	public void SetEntityIdByEntity(int entityId, string key, int value)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(value);
		if (creatureDataComponent == null)
		{
			return;
		}
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		ModelBase<BlackboardModel>.Instance.SetEntityIdByEntity(entityId, key, creatureDataId);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.Entity,
				Key = key,
				LongValue = (long)value
			}
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3F2 RID: 115698 RVA: 0x0086D2F2 File Offset: 0x0086B4F2
	[return: Nullable(2)]
	public IList<int> GetEntityIdsByEntity(int entityId, string key)
	{
		return ModelBase<BlackboardModel>.Instance.GetEntityIdsByEntity(entityId, key);
	}

	// Token: 0x0601C3F3 RID: 115699 RVA: 0x0086D300 File Offset: 0x0086B500
	public void SetEntityIdsByEntity(int entityId, string key, IList<int> values)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		ModelBase<BlackboardModel>.Instance.SetEntityIdsByEntity(entityId, key, values);
		if (!this.IsNetworkMode())
		{
			return;
		}
		BlackboardParam blackboardParam = new BlackboardParam();
		blackboardParam.Type = BlackboardParamType.EntityArray;
		blackboardParam.Key = key;
		blackboardParam.IntValues.Values.AddRange(values);
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			blackboardParam
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3F4 RID: 115700 RVA: 0x0086D374 File Offset: 0x0086B574
	public void RemoveValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		if (!creatureDataComponent.RemoveBlackboard(key) && !this.IsNetworkMode())
		{
			return;
		}
		long creatureDataId = creatureDataComponent.GetCreatureDataId();
		BlackboardParam[] blackboardFields = new BlackboardParam[]
		{
			new BlackboardParam
			{
				Type = BlackboardParamType.None,
				Key = key
			}
		};
		this.EntityBlackboardPush(creatureDataId, blackboardFields);
	}

	// Token: 0x0601C3F5 RID: 115701 RVA: 0x0086D3D4 File Offset: 0x0086B5D4
	public bool HasValueByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return false;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		return blackboard != null && blackboard.HasValue(key);
	}

	// Token: 0x0601C3F6 RID: 115702 RVA: 0x0086D404 File Offset: 0x0086B604
	public void ClearValuesByEntity(int entityId, string key)
	{
		CreatureDataComponent creatureDataComponent = ModelBase<BlackboardModel>.Instance.GetCreatureDataComponent(entityId);
		if (creatureDataComponent == null)
		{
			return;
		}
		BlackboardMap blackboard = creatureDataComponent.GetBlackboard();
		if (!this.IsNetworkMode())
		{
			if (blackboard != null)
			{
				blackboard.Clear();
				return;
			}
		}
		else
		{
			List<BlackboardParam> list = new List<BlackboardParam>();
			if (((blackboard != null) ? blackboard.Map : null) != null)
			{
				foreach (string key2 in blackboard.Map.Keys)
				{
					list.Add(new BlackboardParam
					{
						Type = BlackboardParamType.None,
						Key = key2
					});
				}
			}
			if (list.Count > 0)
			{
				long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(entityId);
				this.EntityBlackboardPush(creatureDataId, list);
			}
			if (blackboard != null)
			{
				blackboard.Clear();
			}
		}
	}

	// Token: 0x0601C3F7 RID: 115703 RVA: 0x0086D4E0 File Offset: 0x0086B6E0
	private bool IsNetworkMode()
	{
		return GlobalData.Networking();
	}

	// Token: 0x0400E354 RID: 58196
	public readonly Dictionary<long, Dictionary<string, BlackboardParam>> PendingBlackboardParams = new Dictionary<long, Dictionary<string, BlackboardParam>>();
}
