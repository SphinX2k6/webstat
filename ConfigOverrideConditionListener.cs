using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002E8F RID: 11919
[NullableContext(1)]
[Nullable(0)]
public class ConfigOverrideConditionListener : IClear
{
	// Token: 0x06018787 RID: 100231 RVA: 0x006DA6A8 File Offset: 0x006D88A8
	public IConfigOverrideRule ResolveOverrideConfigRule(List<IConfigOverrideRule> configOverrides)
	{
		if (configOverrides == null || configOverrides.Count == 0)
		{
			return null;
		}
		foreach (IConfigOverrideRule configOverrideRule in configOverrides)
		{
			if (this.EvaluateOverrideCondition(configOverrideRule))
			{
				return configOverrideRule;
			}
		}
		return null;
	}

	// Token: 0x06018788 RID: 100232 RVA: 0x006DA70C File Offset: 0x006D890C
	public long? GetCurrentConfigId(int listenerId)
	{
		ConfigOverrideConditionListener.ConfigOverrideListenerRuntime configOverrideListenerRuntime;
		if (this.listenerMap.TryGetValue(listenerId, out configOverrideListenerRuntime))
		{
			return configOverrideListenerRuntime.CurrentOverrideConfigId;
		}
		return null;
	}

	// Token: 0x06018789 RID: 100233 RVA: 0x006DA73C File Offset: 0x006D893C
	public ConfigOverrideConditionListener.ConfigOverrideListenerRegistration AddListener(List<IConfigOverrideRule> configOverrides, Action callback, bool triggerOnRegister, long currentOverrideConfigId)
	{
		if (configOverrides == null || configOverrides.Count == 0)
		{
			return null;
		}
		HashSet<EConfigOverrideConditionType> hashSet = new HashSet<EConfigOverrideConditionType>();
		foreach (IConfigOverrideRule configOverrideRule in configOverrides)
		{
			hashSet.Add(configOverrideRule.ConditionType);
		}
		foreach (EConfigOverrideConditionType conditionType in hashSet)
		{
			this.RegisterConditionListener(conditionType);
		}
		int num = this.listenerIdGenerator + 1;
		this.listenerIdGenerator = num;
		int num2 = num;
		ConfigOverrideConditionListener.ConfigOverrideListenerRuntime configOverrideListenerRuntime = new ConfigOverrideConditionListener.ConfigOverrideListenerRuntime
		{
			ListenerId = num2,
			ConditionTypes = hashSet,
			CurrentOverrideConfigId = new long?(currentOverrideConfigId),
			ConfigOverrides = new List<IConfigOverrideRule>(configOverrides),
			Callback = callback
		};
		this.listenerMap[num2] = configOverrideListenerRuntime;
		if (triggerOnRegister && callback != null)
		{
			callback();
		}
		return new ConfigOverrideConditionListener.ConfigOverrideListenerRegistration
		{
			ListenerId = configOverrideListenerRuntime.ListenerId
		};
	}

	// Token: 0x0601878A RID: 100234 RVA: 0x006DA858 File Offset: 0x006D8A58
	public ConfigOverrideConditionListener.ConfigOverrideListenerRegistration RemoveListener(int listenerId)
	{
		ConfigOverrideConditionListener.ConfigOverrideListenerRuntime configOverrideListenerRuntime;
		if (!this.listenerMap.TryGetValue(listenerId, out configOverrideListenerRuntime))
		{
			return null;
		}
		this.listenerMap.Remove(listenerId);
		foreach (EConfigOverrideConditionType conditionType in configOverrideListenerRuntime.ConditionTypes)
		{
			this.UnregisterConditionListener(conditionType);
		}
		return new ConfigOverrideConditionListener.ConfigOverrideListenerRegistration
		{
			ListenerId = configOverrideListenerRuntime.ListenerId
		};
	}

	// Token: 0x0601878B RID: 100235 RVA: 0x006DA8DC File Offset: 0x006D8ADC
	public void Clear()
	{
		this.listenerMap.Clear();
		foreach (KeyValuePair<EConfigOverrideConditionType, int> keyValuePair in this.conditionListenerCountMap.ToList<KeyValuePair<EConfigOverrideConditionType, int>>())
		{
			if (keyValuePair.Value > 0)
			{
				this.UnregisterConditionEvent(keyValuePair.Key);
			}
		}
		this.conditionListenerCountMap.Clear();
	}

	// Token: 0x0601878C RID: 100236 RVA: 0x006DA95C File Offset: 0x006D8B5C
	public bool ClearObject()
	{
		return true;
	}

	// Token: 0x0601878D RID: 100237 RVA: 0x006DA960 File Offset: 0x006D8B60
	private bool EvaluateOverrideCondition(IConfigOverrideRule overrideRule)
	{
		if (overrideRule.ConditionType != EConfigOverrideConditionType.FormationRoleHasTag)
		{
			return false;
		}
		string[] array = overrideRule.ConditionString.Split('#', StringSplitOptions.None);
		if (array.Length < 2)
		{
			return false;
		}
		if (int.Parse(array[0]) != 1)
		{
			return false;
		}
		string tagName = array[1];
		return this.CheckFormationRoleHasTag(tagName);
	}

	// Token: 0x0601878E RID: 100238 RVA: 0x006DA9A8 File Offset: 0x006D8BA8
	private bool CheckFormationRoleHasTag(string tagName)
	{
		return ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false).Any(delegate(EntityHandle entityHandle)
		{
			WorldEntity entity = entityHandle.Entity;
			object obj = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			int tagIdByName = GameplayTagUtils.GetTagIdByName(tagName);
			object obj2 = obj;
			return obj2 != null && obj2.HasTag(tagIdByName);
		});
	}

	// Token: 0x0601878F RID: 100239 RVA: 0x006DA9E0 File Offset: 0x006D8BE0
	private void RegisterConditionListener(EConfigOverrideConditionType conditionType)
	{
		int num;
		this.conditionListenerCountMap.TryGetValue(conditionType, out num);
		if (!this.conditionListenerCountMap.ContainsKey(conditionType))
		{
			num = 0;
		}
		if (num == 0)
		{
			this.RegisterConditionEvent(conditionType);
		}
		this.conditionListenerCountMap[conditionType] = num + 1;
	}

	// Token: 0x06018790 RID: 100240 RVA: 0x006DAA25 File Offset: 0x006D8C25
	private void RegisterConditionEvent(EConfigOverrideConditionType conditionType)
	{
		if (conditionType == EConfigOverrideConditionType.FormationRoleHasTag)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationConditionChanged));
		}
	}

	// Token: 0x06018791 RID: 100241 RVA: 0x006DAA48 File Offset: 0x006D8C48
	private void UnregisterConditionListener(EConfigOverrideConditionType conditionType)
	{
		int num;
		if (!this.conditionListenerCountMap.TryGetValue(conditionType, out num) || num <= 0)
		{
			return;
		}
		int num2 = num - 1;
		this.conditionListenerCountMap[conditionType] = num2;
		if (num2 == 0)
		{
			this.UnregisterConditionEvent(conditionType);
		}
	}

	// Token: 0x06018792 RID: 100242 RVA: 0x006DAA85 File Offset: 0x006D8C85
	private void UnregisterConditionEvent(EConfigOverrideConditionType conditionType)
	{
		if (conditionType == EConfigOverrideConditionType.FormationRoleHasTag)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationConditionChanged));
		}
	}

	// Token: 0x06018793 RID: 100243 RVA: 0x006DAAA7 File Offset: 0x006D8CA7
	private void OnFormationConditionChanged()
	{
		this.DispatchFormationListeners();
	}

	// Token: 0x06018794 RID: 100244 RVA: 0x006DAAB0 File Offset: 0x006D8CB0
	private void DispatchFormationListeners()
	{
		foreach (KeyValuePair<int, ConfigOverrideConditionListener.ConfigOverrideListenerRuntime> keyValuePair in this.listenerMap.ToList<KeyValuePair<int, ConfigOverrideConditionListener.ConfigOverrideListenerRuntime>>())
		{
			if (keyValuePair.Value.ConditionTypes.Contains(EConfigOverrideConditionType.FormationRoleHasTag))
			{
				this.DispatchListeners(new List<int>
				{
					keyValuePair.Key
				});
			}
		}
	}

	// Token: 0x06018795 RID: 100245 RVA: 0x006DAB30 File Offset: 0x006D8D30
	private void DispatchListeners(List<int> listenerIds)
	{
		foreach (int key in listenerIds)
		{
			ConfigOverrideConditionListener.ConfigOverrideListenerRuntime configOverrideListenerRuntime;
			if (this.listenerMap.TryGetValue(key, out configOverrideListenerRuntime))
			{
				IConfigOverrideRule configOverrideRule = this.ResolveOverrideConfigRule(configOverrideListenerRuntime.ConfigOverrides);
				long? num = (configOverrideRule != null) ? new long?(configOverrideRule.OverrideConfigId) : null;
				long? num2 = num;
				long? currentOverrideConfigId = configOverrideListenerRuntime.CurrentOverrideConfigId;
				if (!(num2.GetValueOrDefault() == currentOverrideConfigId.GetValueOrDefault() & num2 != null == (currentOverrideConfigId != null)))
				{
					configOverrideListenerRuntime.CurrentOverrideConfigId = num;
					Action callback = configOverrideListenerRuntime.Callback;
					if (callback != null)
					{
						callback();
					}
				}
			}
		}
	}

	// Token: 0x0400BCAE RID: 48302
	private readonly Dictionary<int, ConfigOverrideConditionListener.ConfigOverrideListenerRuntime> listenerMap = new Dictionary<int, ConfigOverrideConditionListener.ConfigOverrideListenerRuntime>();

	// Token: 0x0400BCAF RID: 48303
	private int listenerIdGenerator;

	// Token: 0x0400BCB0 RID: 48304
	private readonly Dictionary<EConfigOverrideConditionType, int> conditionListenerCountMap = new Dictionary<EConfigOverrideConditionType, int>();

	// Token: 0x02009301 RID: 37633
	[Nullable(0)]
	public class ConfigOverrideRule : IConfigOverrideRule
	{
		// Token: 0x1700A887 RID: 43143
		// (get) Token: 0x06049F64 RID: 302948 RVA: 0x0140C393 File Offset: 0x0140A593
		// (set) Token: 0x06049F65 RID: 302949 RVA: 0x0140C39B File Offset: 0x0140A59B
		public long OverrideConfigId { get; set; }

		// Token: 0x1700A888 RID: 43144
		// (get) Token: 0x06049F66 RID: 302950 RVA: 0x0140C3A4 File Offset: 0x0140A5A4
		// (set) Token: 0x06049F67 RID: 302951 RVA: 0x0140C3AC File Offset: 0x0140A5AC
		public EConfigOverrideConditionType ConditionType { get; set; }

		// Token: 0x1700A889 RID: 43145
		// (get) Token: 0x06049F68 RID: 302952 RVA: 0x0140C3B5 File Offset: 0x0140A5B5
		// (set) Token: 0x06049F69 RID: 302953 RVA: 0x0140C3BD File Offset: 0x0140A5BD
		public string ConditionString { get; set; }
	}

	// Token: 0x02009302 RID: 37634
	[Nullable(0)]
	private class ConfigOverrideListenerRuntime
	{
		// Token: 0x1700A88A RID: 43146
		// (get) Token: 0x06049F6B RID: 302955 RVA: 0x0140C3CE File Offset: 0x0140A5CE
		// (set) Token: 0x06049F6C RID: 302956 RVA: 0x0140C3D6 File Offset: 0x0140A5D6
		public int ListenerId { get; set; }

		// Token: 0x1700A88B RID: 43147
		// (get) Token: 0x06049F6D RID: 302957 RVA: 0x0140C3DF File Offset: 0x0140A5DF
		// (set) Token: 0x06049F6E RID: 302958 RVA: 0x0140C3E7 File Offset: 0x0140A5E7
		public HashSet<EConfigOverrideConditionType> ConditionTypes { get; set; }

		// Token: 0x1700A88C RID: 43148
		// (get) Token: 0x06049F6F RID: 302959 RVA: 0x0140C3F0 File Offset: 0x0140A5F0
		// (set) Token: 0x06049F70 RID: 302960 RVA: 0x0140C3F8 File Offset: 0x0140A5F8
		public long? CurrentOverrideConfigId { get; set; }

		// Token: 0x1700A88D RID: 43149
		// (get) Token: 0x06049F71 RID: 302961 RVA: 0x0140C401 File Offset: 0x0140A601
		// (set) Token: 0x06049F72 RID: 302962 RVA: 0x0140C409 File Offset: 0x0140A609
		public List<IConfigOverrideRule> ConfigOverrides { get; set; }

		// Token: 0x1700A88E RID: 43150
		// (get) Token: 0x06049F73 RID: 302963 RVA: 0x0140C412 File Offset: 0x0140A612
		// (set) Token: 0x06049F74 RID: 302964 RVA: 0x0140C41A File Offset: 0x0140A61A
		public Action Callback { get; set; }
	}

	// Token: 0x02009303 RID: 37635
	[NullableContext(0)]
	public class ConfigOverrideListenerRegistration
	{
		// Token: 0x1700A88F RID: 43151
		// (get) Token: 0x06049F76 RID: 302966 RVA: 0x0140C42B File Offset: 0x0140A62B
		// (set) Token: 0x06049F77 RID: 302967 RVA: 0x0140C433 File Offset: 0x0140A633
		public int ListenerId { get; set; }
	}
}
