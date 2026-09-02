using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;

// Token: 0x02000FBF RID: 4031
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class FormationAttributeController : ControllerBase<FormationAttributeController>
{
	// Token: 0x06006730 RID: 26416 RVA: 0x001AEC88 File Offset: 0x001ACE88
	protected override bool OnInit()
	{
		this.ConfigList = ConfigFormationPropertyAll.GetConfigList(true);
		Singleton<Net>.Instance.Register<FormationAttrNotify>(ENotifyMessageId.FormationAttrNotify, new Action<FormationAttrNotify, Net.CallbackStatus>(this.FormationAttrNotify));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		return true;
	}

	// Token: 0x06006731 RID: 26417 RVA: 0x001AECDC File Offset: 0x001ACEDC
	protected override void OnTick(float delta)
	{
		if (this.ConfigList == null)
		{
			return;
		}
		foreach (FormationProperty formationProperty in this.ConfigList)
		{
			this.RefreshValue((EFormationAttributeId)formationProperty.Id);
		}
	}

	// Token: 0x06006732 RID: 26418 RVA: 0x001AED38 File Offset: 0x001ACF38
	protected override bool OnClear()
	{
		this.ClearListeners();
		this.PauseLocks.Clear();
		this.PauseRateLocks.Clear();
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FormationAttrNotify);
		return true;
	}

	// Token: 0x06006733 RID: 26419 RVA: 0x001AED68 File Offset: 0x001ACF68
	[NullableContext(2)]
	public void FormationAttrNotify(FormationAttrNotify notify, Net.CallbackStatus status)
	{
		long curTime = notify.CurTime;
		foreach (FormationAttr formationAttr in notify.FormationAttrs)
		{
			int attrId = formationAttr.AttrId;
			float max = this.Model.GetMax((EFormationAttributeId)formationAttr.AttrId);
			int maxValue = formationAttr.MaxValue;
			int baseMaxValue = formationAttr.BaseMaxValue;
			float value = (float)formationAttr.CurrentValue;
			float speed = (float)formationAttr.Ratio;
			if (this.HasAuthority((EFormationAttributeId)attrId))
			{
				value = this.GetValue((EFormationAttributeId)attrId);
				speed = this.GetSpeed((EFormationAttributeId)attrId);
			}
			this.Model.SetData((EFormationAttributeId)attrId, (float)maxValue, (float)baseMaxValue, value, speed, (double)curTime);
			this.OnSetMax((EFormationAttributeId)attrId, (float)maxValue, max);
		}
	}

	// Token: 0x06006734 RID: 26420 RVA: 0x001AEE38 File Offset: 0x001AD038
	protected void OnFormationAttrChanged(EFormationAttributeId attrId)
	{
		FormationAttributeModel model = this.Model;
		IAttributeData attributeData = (model != null) ? model.GetData(attrId) : null;
		if (attributeData == null)
		{
			return;
		}
		FormationAttrRequest formationAttrRequest = new FormationAttrRequest();
		FormationAttr formationAttr = new FormationAttr();
		formationAttrRequest.FormationAttrs.Add(formationAttr);
		formationAttrRequest.CurTime = (long)attributeData.Timestamp;
		formationAttr.AttrId = (int)attrId;
		formationAttr.CurrentValue = (int)attributeData.Value;
		formationAttr.MaxValue = (int)attributeData.Max;
		formationAttr.BaseMaxValue = (int)attributeData.BaseMax;
		formationAttr.Ratio = (int)attributeData.Speed;
		Singleton<Net>.Instance.Call<FormationAttrResponse>(ERequestMessageId.FormationAttrRequest, formationAttrRequest, null, 0);
	}

	// Token: 0x06006735 RID: 26421 RVA: 0x001AEED0 File Offset: 0x001AD0D0
	public void SetValue(EFormationAttributeId attrId, float value)
	{
		if (!this.HasAuthority(attrId))
		{
			return;
		}
		float value2 = this.GetValue(attrId);
		this.Model.SetValue(attrId, value);
		this.RefreshValue(attrId);
		if (this.GetValue(attrId) != value2)
		{
			this.OnFormationAttrChanged(attrId);
		}
	}

	// Token: 0x06006736 RID: 26422 RVA: 0x001AEF14 File Offset: 0x001AD114
	public void AddValue(EFormationAttributeId attrId, float value)
	{
		if (!this.HasAuthority(attrId))
		{
			return;
		}
		this.SetValue(attrId, this.Model.GetValue(attrId) + value);
	}

	// Token: 0x06006737 RID: 26423 RVA: 0x001AEF35 File Offset: 0x001AD135
	public float GetValue(EFormationAttributeId attrId)
	{
		if (this.AttributeCache.ContainsKey(attrId))
		{
			return this.AttributeCache[attrId];
		}
		return this.Model.GetValue(attrId);
	}

	// Token: 0x06006738 RID: 26424 RVA: 0x001AEF5E File Offset: 0x001AD15E
	public float GetMax(EFormationAttributeId attrId)
	{
		return this.Model.GetMax(attrId);
	}

	// Token: 0x06006739 RID: 26425 RVA: 0x001AEF6C File Offset: 0x001AD16C
	public void AddMaxModifier(string key, EFormationAttributeId attrId, float percent, float offset)
	{
		if (!this.MaxModifiers.ContainsKey(attrId))
		{
			this.MaxModifiers[attrId] = new Dictionary<string, IMaxModifier>();
		}
		this.MaxModifiers[attrId][key] = new MaxModifier
		{
			Percent = percent,
			Offset = offset
		};
		this.RefreshMax(attrId);
	}

	// Token: 0x0600673A RID: 26426 RVA: 0x001AEFC5 File Offset: 0x001AD1C5
	public void RemoveMaxModifier(string key, EFormationAttributeId attrId)
	{
		if (this.MaxModifiers.ContainsKey(attrId))
		{
			Dictionary<string, IMaxModifier> dictionary = this.MaxModifiers[attrId];
			dictionary.Remove(key);
			if (dictionary.Count == 0)
			{
				this.MaxModifiers.Remove(attrId);
			}
			this.RefreshMax(attrId);
		}
	}

	// Token: 0x0600673B RID: 26427 RVA: 0x001AF004 File Offset: 0x001AD204
	public float GetBaseMax(EFormationAttributeId attrId)
	{
		return this.Model.GetBaseMax(attrId);
	}

	// Token: 0x0600673C RID: 26428 RVA: 0x001AF012 File Offset: 0x001AD212
	public float GetSpeed(EFormationAttributeId attrId)
	{
		return this.Model.GetSpeed(attrId);
	}

	// Token: 0x0600673D RID: 26429 RVA: 0x001AF020 File Offset: 0x001AD220
	public float GetRatio(EFormationAttributeId attrId)
	{
		return this.GetValue(attrId) / this.GetMax(attrId) * 10000f;
	}

	// Token: 0x0600673E RID: 26430 RVA: 0x001AF038 File Offset: 0x001AD238
	public void AddSpeedModifier(string key, EFormationAttributeId attrId, EModifierType type, float value, int priority = 100)
	{
		if (!this.SpeedModifiers.ContainsKey(attrId))
		{
			this.SpeedModifiers[attrId] = new Dictionary<string, ISpeedModifier>();
		}
		this.SpeedModifiers[attrId][key] = new SpeedModifier
		{
			Type = type,
			Value = value,
			Priority = priority
		};
		this.RefreshSpeed(attrId);
	}

	// Token: 0x0600673F RID: 26431 RVA: 0x001AF099 File Offset: 0x001AD299
	public void RemoveSpeedModifier(string key, EFormationAttributeId attrId)
	{
		if (this.SpeedModifiers.ContainsKey(attrId))
		{
			Dictionary<string, ISpeedModifier> dictionary = this.SpeedModifiers[attrId];
			dictionary.Remove(key);
			if (dictionary.Count == 0)
			{
				this.SpeedModifiers.Remove(attrId);
			}
			this.RefreshSpeed(attrId);
		}
	}

	// Token: 0x06006740 RID: 26432 RVA: 0x001AF0D8 File Offset: 0x001AD2D8
	public int AddBoundsLocker(EFormationAttributeId attrId, IBoundsLocker locker, int lockerHandle)
	{
		FormationAttributeModel model = this.Model;
		if (model == null)
		{
			return -1;
		}
		return model.AddBoundsLocker(attrId, locker, lockerHandle);
	}

	// Token: 0x06006741 RID: 26433 RVA: 0x001AF0EE File Offset: 0x001AD2EE
	public bool RemoveBoundsLocker(EFormationAttributeId attrId, int lockerHandle)
	{
		FormationAttributeModel model = this.Model;
		return model != null && model.RemoveBoundsLocker(attrId, lockerHandle);
	}

	// Token: 0x06006742 RID: 26434 RVA: 0x001AF104 File Offset: 0x001AD304
	public void AddPauseLock(string key, float timeScale = 0f)
	{
		if (timeScale <= 0f)
		{
			this.PauseLocks.Add(key);
			this.PauseRateLocks.Remove(key);
		}
		else
		{
			this.PauseLocks.Remove(key);
			this.PauseRateLocks[key] = Singleton<MathUtils>.Instance.Clamp(timeScale, 0f, 1f);
		}
		this.RefreshAllSpeed();
	}

	// Token: 0x06006743 RID: 26435 RVA: 0x001AF169 File Offset: 0x001AD369
	public void RemovePauseLock(string key)
	{
		this.PauseLocks.Remove(key);
		this.PauseRateLocks.Remove(key);
		this.RefreshAllSpeed();
	}

	// Token: 0x06006744 RID: 26436 RVA: 0x001AF18B File Offset: 0x001AD38B
	public bool IsPaused()
	{
		return this.PauseLocks.Count > 0;
	}

	// Token: 0x06006745 RID: 26437 RVA: 0x001AF19C File Offset: 0x001AD39C
	public float GetPauseRate()
	{
		float num = 1f;
		foreach (float val in this.PauseRateLocks.Values)
		{
			num = Math.Min(num, val);
		}
		return num;
	}

	// Token: 0x06006746 RID: 26438 RVA: 0x001AF1FC File Offset: 0x001AD3FC
	private bool HasAuthority(EFormationAttributeId attrId)
	{
		return attrId == EFormationAttributeId.Strength || attrId == EFormationAttributeId.MigrationStrength || attrId == EFormationAttributeId.MotorcycleStrength || attrId == EFormationAttributeId.MotorcycleSoarStrength || attrId == EFormationAttributeId.LevelQuickHackRam;
	}

	// Token: 0x06006747 RID: 26439 RVA: 0x001AF218 File Offset: 0x001AD418
	private BaseTagComponent.TTagSwitchedCallback GetCheckTagCallback(EFormationAttributeId attrId)
	{
		if (!this.CheckTagCallbacks.ContainsKey(attrId))
		{
			this.CheckTagCallbacks[attrId] = delegate(int _, bool _)
			{
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				BaseTagComponent baseTagComponent;
				if (getCurrentEntity == null)
				{
					baseTagComponent = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					baseTagComponent = ((entity != null) ? entity.CheckGetComponent<BaseTagComponent>() : null);
				}
				BaseTagComponent baseTagComponent2 = baseTagComponent;
				IFormationAttributeConfig config = this.Model.GetConfig(attrId);
				if (config == null || baseTagComponent2 == null)
				{
					return;
				}
				if (baseTagComponent2.HasAnyTag(config.ForbidIncreaseTags))
				{
					this.AddSpeedModifier("TagForbidIncrease", attrId, EModifierType.IncreaseModify, float.NegativeInfinity, 100);
				}
				else
				{
					this.RemoveSpeedModifier("TagForbidIncrease", attrId);
				}
				if (baseTagComponent2.HasAnyTag(config.ForbidDecreaseTags))
				{
					this.AddSpeedModifier("TagForbidDecrease", attrId, EModifierType.DecreaseModify, float.NegativeInfinity, 100);
					return;
				}
				this.RemoveSpeedModifier("TagForbidDecrease", attrId);
			};
		}
		return this.CheckTagCallbacks[attrId];
	}

	// Token: 0x06006748 RID: 26440 RVA: 0x001AF27C File Offset: 0x001AD47C
	private void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		if (this.ConfigList == null)
		{
			return;
		}
		foreach (FormationProperty formationProperty in this.ConfigList)
		{
			EFormationAttributeId id = (EFormationAttributeId)formationProperty.Id;
			WorldEntity entity = newEntityHandle.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.CheckGetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				IFormationAttributeConfig config = this.Model.GetConfig(id);
				BaseTagComponent.TTagSwitchedCallback checkTagCallback = this.GetCheckTagCallback(id);
				int?[] array = (config != null) ? config.ForbidIncreaseTags : null;
				if (array != null)
				{
					foreach (int num in array)
					{
						if (num != null && num.Value != 0 && !baseTagComponent.HasTagAddOrRemoveListener(num.Value, checkTagCallback))
						{
							baseTagComponent.AddTagAddOrRemoveListener(num.Value, checkTagCallback, null);
						}
					}
				}
				int?[] array3 = (config != null) ? config.ForbidDecreaseTags : null;
				if (array3 != null)
				{
					foreach (int num2 in array3)
					{
						if (num2 != null && num2.Value != 0 && !baseTagComponent.HasTagAddOrRemoveListener(num2.Value, checkTagCallback))
						{
							baseTagComponent.AddTagAddOrRemoveListener(num2.Value, checkTagCallback, null);
						}
					}
				}
			}
			this.GetCheckTagCallback(id)(0, false);
		}
	}

	// Token: 0x17000814 RID: 2068
	// (get) Token: 0x06006749 RID: 26441 RVA: 0x001AF3F8 File Offset: 0x001AD5F8
	[Nullable(2)]
	public FormationAttributeModel Model
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<FormationAttributeModel>.Instance;
		}
	}

	// Token: 0x0600674A RID: 26442 RVA: 0x001AF400 File Offset: 0x001AD600
	protected void OnSetMax(EFormationAttributeId attrId, float newMax, float oldMax)
	{
		if (newMax != oldMax && this.MaxListeners.ContainsKey(attrId))
		{
			foreach (TValueListener tvalueListener in this.MaxListeners[attrId])
			{
				tvalueListener(attrId, newMax, oldMax);
			}
		}
	}

	// Token: 0x0600674B RID: 26443 RVA: 0x001AF46C File Offset: 0x001AD66C
	protected void RefreshAllSpeed()
	{
		if (this.ConfigList != null)
		{
			foreach (FormationProperty formationProperty in this.ConfigList)
			{
				this.RefreshSpeed((EFormationAttributeId)formationProperty.Id);
			}
		}
	}

	// Token: 0x0600674C RID: 26444 RVA: 0x001AF4C8 File Offset: 0x001AD6C8
	protected void RefreshSpeed(EFormationAttributeId attrId)
	{
		Dictionary<string, ISpeedModifier> dictionary = this.SpeedModifiers.ContainsKey(attrId) ? this.SpeedModifiers[attrId] : null;
		float num = this.Model.GetBaseRate(attrId);
		float num2 = num;
		float speed = this.Model.GetSpeed(attrId);
		if (this.IsPaused())
		{
			num2 = 0f;
		}
		else if (dictionary != null)
		{
			float num3 = 0f;
			float num4 = 0f;
			int num5 = 0;
			foreach (ISpeedModifier speedModifier in dictionary.Values)
			{
				switch (speedModifier.Type)
				{
				case EModifierType.Override:
					if (speedModifier.Priority >= num5)
					{
						num5 = speedModifier.Priority;
						num = speedModifier.Value;
					}
					break;
				case EModifierType.IncreaseModify:
					num3 += speedModifier.Value;
					break;
				case EModifierType.DecreaseModify:
					num4 += speedModifier.Value;
					break;
				}
			}
			float num6 = Math.Max(1f + ((num > 0f) ? num3 : num4) * 0.0001f, 0f);
			num2 = num * num6;
		}
		if (!this.IsPaused())
		{
			num2 *= this.GetPauseRate();
		}
		if (num2 != speed)
		{
			this.Model.SetSpeed(attrId, num2);
			this.OnFormationAttrChanged(attrId);
		}
	}

	// Token: 0x0600674D RID: 26445 RVA: 0x001AF628 File Offset: 0x001AD828
	protected void RefreshMax(EFormationAttributeId attrId)
	{
		Dictionary<string, IMaxModifier> dictionary = this.MaxModifiers.ContainsKey(attrId) ? this.MaxModifiers[attrId] : null;
		float baseMax = this.Model.GetBaseMax(attrId);
		float num = baseMax;
		float max = this.Model.GetMax(attrId);
		if (dictionary != null)
		{
			float num2 = 0f;
			float num3 = 0f;
			foreach (IMaxModifier maxModifier in dictionary.Values)
			{
				num2 += maxModifier.Offset;
				num3 += maxModifier.Percent;
			}
			num = baseMax + num2 + baseMax * num3 * 0.0001f;
		}
		if (max != num)
		{
			this.Model.SetMax(attrId, num);
			this.RefreshValue(attrId);
			this.OnSetMax(attrId, num, max);
			this.OnFormationAttrChanged(attrId);
		}
	}

	// Token: 0x0600674E RID: 26446 RVA: 0x001AF714 File Offset: 0x001AD914
	private unsafe void RefreshValue(EFormationAttributeId attrId)
	{
		float value = this.Model.GetValue(attrId);
		float num = this.AttributeCache.ContainsKey(attrId) ? this.AttributeCache[attrId] : value;
		if (!this.AttributeCache.ContainsKey(attrId))
		{
			this.AttributeCache[attrId] = value;
			num = value;
		}
		if (value != num)
		{
			this.AttributeCache[attrId] = value;
			if (this.ValueListeners.ContainsKey(attrId))
			{
				HashSet<TValueListener> hashSet = this.ValueListeners[attrId];
				TValueListener[] array = new TValueListener[hashSet.Count];
				hashSet.CopyTo(array);
				foreach (TValueListener tvalueListener in array)
				{
					if (hashSet.Contains(tvalueListener))
					{
						try
						{
							tvalueListener(attrId, value, num);
						}
						catch (Exception ex)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Event;
							ELogAuthor author = ELogAuthor.ZQR;
							string message = "队伍属性回调异常";
							Exception error = ex;
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attrId);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newValue", value);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("oldValue", num);
							instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						}
					}
				}
			}
			if (this.ThresholdListeners.ContainsKey(attrId))
			{
				List<IThresholdListenerInfo> list = this.ThresholdListeners[attrId];
				float ratio = this.GetRatio(attrId);
				IThresholdListenerInfo[] array3 = new IThresholdListenerInfo[list.Count];
				list.CopyTo(array3);
				foreach (IThresholdListenerInfo thresholdListenerInfo in array3)
				{
					if (list.Contains(thresholdListenerInfo))
					{
						bool flag = ratio >= thresholdListenerInfo.Min && ratio <= thresholdListenerInfo.Max;
						if (flag != thresholdListenerInfo.InInterval)
						{
							thresholdListenerInfo.InInterval = flag;
							try
							{
								thresholdListenerInfo.Func(attrId, flag, ratio);
							}
							catch (Exception ex2)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.Event;
								ELogAuthor author2 = ELogAuthor.ZQR;
								string message2 = "队伍属性回调异常";
								Exception error2 = ex2;
								<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("attrId", attrId);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("inInterval", flag);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("ratio", ratio);
								instance2.ErrorWithStack(module2, author2, message2, error2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600674F RID: 26447 RVA: 0x001AF9D0 File Offset: 0x001ADBD0
	private void ClearListeners()
	{
		this.ValueListeners.Clear();
		this.ThresholdListeners.Clear();
		this.MaxListeners.Clear();
	}

	// Token: 0x06006750 RID: 26448 RVA: 0x001AF9F3 File Offset: 0x001ADBF3
	public void AddValueListener(EFormationAttributeId attrId, TValueListener listener, [Nullable(2)] string profileLabel = null)
	{
		if (!this.ValueListeners.ContainsKey(attrId))
		{
			this.ValueListeners[attrId] = new HashSet<TValueListener>();
		}
		this.ValueListeners[attrId].Add(listener);
	}

	// Token: 0x06006751 RID: 26449 RVA: 0x001AFA27 File Offset: 0x001ADC27
	public void RemoveValueListener(EFormationAttributeId attrId, TValueListener listener)
	{
		if (this.ValueListeners.ContainsKey(attrId))
		{
			HashSet<TValueListener> hashSet = this.ValueListeners[attrId];
			hashSet.Remove(listener);
			if (hashSet.Count == 0)
			{
				this.ValueListeners.Remove(attrId);
			}
		}
	}

	// Token: 0x06006752 RID: 26450 RVA: 0x001AFA60 File Offset: 0x001ADC60
	public unsafe void AddThresholdListener(EFormationAttributeId attrId, TThresholdListener listener, float maxLimit, float minLimit, [Nullable(2)] string profileLabel = null)
	{
		if (maxLimit < minLimit)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Formation;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "尝试添加的阈值监听器上限小于下限";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attrId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("区间上限", maxLimit);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("区间下限", minLimit);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (!this.ThresholdListeners.ContainsKey(attrId))
		{
			this.ThresholdListeners[attrId] = new List<IThresholdListenerInfo>();
		}
		List<IThresholdListenerInfo> list = this.ThresholdListeners[attrId];
		bool flag = false;
		using (List<IThresholdListenerInfo>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Func == listener)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			float ratio = this.GetRatio(attrId);
			bool inInterval = ratio >= minLimit && ratio <= maxLimit;
			list.Add(new ThresholdListenerInfo
			{
				Func = listener,
				Max = maxLimit,
				Min = minLimit,
				InInterval = inInterval
			});
		}
	}

	// Token: 0x06006753 RID: 26451 RVA: 0x001AFBB0 File Offset: 0x001ADDB0
	public void RemoveThresholdListener(EFormationAttributeId attrId, TThresholdListener listener)
	{
		if (!this.ThresholdListeners.ContainsKey(attrId))
		{
			return;
		}
		List<IThresholdListenerInfo> list = this.ThresholdListeners[attrId];
		int num = list.FindIndex((IThresholdListenerInfo info) => info.Func == listener);
		if (num >= 0)
		{
			list.RemoveAt(num);
		}
	}

	// Token: 0x06006754 RID: 26452 RVA: 0x001AFC04 File Offset: 0x001ADE04
	public void AddMaxListener(EFormationAttributeId attrId, TValueListener listener, [Nullable(2)] string profileLabel = null)
	{
		if (!this.MaxListeners.ContainsKey(attrId))
		{
			this.MaxListeners[attrId] = new HashSet<TValueListener>();
		}
		this.MaxListeners[attrId].Add(listener);
	}

	// Token: 0x06006755 RID: 26453 RVA: 0x001AFC38 File Offset: 0x001ADE38
	public void RemoveMaxListener(EFormationAttributeId attrId, TValueListener listener)
	{
		if (this.MaxListeners.ContainsKey(attrId))
		{
			this.MaxListeners[attrId].Remove(listener);
		}
	}

	// Token: 0x04003155 RID: 12629
	[Nullable(2)]
	protected IReadOnlyList<FormationProperty> ConfigList;

	// Token: 0x04003156 RID: 12630
	public Dictionary<EFormationAttributeId, Dictionary<string, ISpeedModifier>> SpeedModifiers = new Dictionary<EFormationAttributeId, Dictionary<string, ISpeedModifier>>();

	// Token: 0x04003157 RID: 12631
	public Dictionary<EFormationAttributeId, Dictionary<string, IMaxModifier>> MaxModifiers = new Dictionary<EFormationAttributeId, Dictionary<string, IMaxModifier>>();

	// Token: 0x04003158 RID: 12632
	protected HashSet<string> PauseLocks = new HashSet<string>();

	// Token: 0x04003159 RID: 12633
	protected readonly Dictionary<string, float> PauseRateLocks = new Dictionary<string, float>();

	// Token: 0x0400315A RID: 12634
	private readonly Dictionary<EFormationAttributeId, BaseTagComponent.TTagSwitchedCallback> CheckTagCallbacks = new Dictionary<EFormationAttributeId, BaseTagComponent.TTagSwitchedCallback>();

	// Token: 0x0400315B RID: 12635
	private readonly Dictionary<EFormationAttributeId, float> AttributeCache = new Dictionary<EFormationAttributeId, float>();

	// Token: 0x0400315C RID: 12636
	private readonly Dictionary<EFormationAttributeId, HashSet<TValueListener>> ValueListeners = new Dictionary<EFormationAttributeId, HashSet<TValueListener>>();

	// Token: 0x0400315D RID: 12637
	private readonly Dictionary<EFormationAttributeId, List<IThresholdListenerInfo>> ThresholdListeners = new Dictionary<EFormationAttributeId, List<IThresholdListenerInfo>>();

	// Token: 0x0400315E RID: 12638
	private readonly Dictionary<EFormationAttributeId, HashSet<TValueListener>> MaxListeners = new Dictionary<EFormationAttributeId, HashSet<TValueListener>>();
}
