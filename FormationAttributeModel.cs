using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000FC5 RID: 4037
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FormationAttributeModel : ModelBase<FormationAttributeModel>, IFormationAttributeModel
{
	// Token: 0x06006780 RID: 26496 RVA: 0x001AFD7C File Offset: 0x001ADF7C
	[NullableContext(2)]
	public IFormationAttributeConfig GetConfig(EFormationAttributeId attrId)
	{
		if (this.Configs.ContainsKey(attrId))
		{
			return this.Configs[attrId];
		}
		FormationProperty? config = ConfigFormationPropertyById.GetConfig((int)attrId, true);
		FormationAttributeConfig formationAttributeConfig = new FormationAttributeConfig
		{
			RawConfig = config,
			ForbidIncreaseTags = new int?[(config != null) ? config.GetValueOrDefault().MarkTagLength : 0],
			ForbidDecreaseTags = new int?[(config != null) ? config.GetValueOrDefault().ResistTagLength : 0]
		};
		if (config != null)
		{
			for (int i = 0; i < config.Value.MarkTagLength; i++)
			{
				formationAttributeConfig.ForbidIncreaseTags[i] = new int?(GameplayTagUtils.GetTagIdByName(config.Value.MarkTag(i)));
			}
		}
		if (config != null)
		{
			for (int j = 0; j < config.Value.ResistTagLength; j++)
			{
				formationAttributeConfig.ForbidDecreaseTags[j] = new int?(GameplayTagUtils.GetTagIdByName(config.Value.ResistTag(j)));
			}
		}
		this.Configs[attrId] = formationAttributeConfig;
		return formationAttributeConfig;
	}

	// Token: 0x06006781 RID: 26497 RVA: 0x001AFEAC File Offset: 0x001AE0AC
	protected override bool OnInit()
	{
		double worldTime = Singleton<Time>.Instance.WorldTime;
		IReadOnlyList<FormationProperty> configList = ConfigFormationPropertyAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (FormationProperty formationProperty in configList)
			{
				this.AttributeSet[(EFormationAttributeId)formationProperty.Id] = new AttributeData
				{
					Max = (float)formationProperty.InitMax,
					BaseMax = (float)formationProperty.InitMax,
					Value = (float)formationProperty.InitValue,
					Speed = (float)formationProperty.InitRecoveryRate,
					BaseSpeed = (float)formationProperty.InitRecoveryRate,
					Timestamp = worldTime
				};
			}
		}
		return true;
	}

	// Token: 0x06006782 RID: 26498 RVA: 0x001AFF6C File Offset: 0x001AE16C
	protected override bool OnClear()
	{
		this.Configs.Clear();
		this.AttributeSet.Clear();
		return true;
	}

	// Token: 0x06006783 RID: 26499 RVA: 0x001AFF88 File Offset: 0x001AE188
	public float GetValue(EFormationAttributeId attrId)
	{
		IAttributeData data = this.GetData(attrId);
		if (data == null)
		{
			return 0f;
		}
		double num = this.GetPredictedServerStopTime() - data.Timestamp;
		float speed = data.Speed;
		if (speed == 0f || num <= 0.0)
		{
			return data.Value;
		}
		double num2 = num * 0.0010000000474974513 * (double)speed;
		return this.ClampValue(attrId, (float)((double)data.Value + num2), 0f, data.Max);
	}

	// Token: 0x06006784 RID: 26500 RVA: 0x001B0001 File Offset: 0x001AE201
	public float GetMax(EFormationAttributeId attrId)
	{
		IAttributeData data = this.GetData(attrId);
		if (data == null)
		{
			return 0f;
		}
		return data.Max;
	}

	// Token: 0x06006785 RID: 26501 RVA: 0x001B0019 File Offset: 0x001AE219
	public float GetBaseMax(EFormationAttributeId attrId)
	{
		IAttributeData data = this.GetData(attrId);
		if (data == null)
		{
			return 0f;
		}
		return data.BaseMax;
	}

	// Token: 0x06006786 RID: 26502 RVA: 0x001B0031 File Offset: 0x001AE231
	public float GetBaseRate(EFormationAttributeId attrId)
	{
		IAttributeData data = this.GetData(attrId);
		if (data == null)
		{
			return 0f;
		}
		return data.BaseSpeed;
	}

	// Token: 0x06006787 RID: 26503 RVA: 0x001B0049 File Offset: 0x001AE249
	public float GetSpeed(EFormationAttributeId attrId)
	{
		IAttributeData data = this.GetData(attrId);
		if (data == null)
		{
			return 0f;
		}
		return data.Speed;
	}

	// Token: 0x06006788 RID: 26504 RVA: 0x001B0064 File Offset: 0x001AE264
	[NullableContext(2)]
	public IAttributeData GetData(EFormationAttributeId attrId)
	{
		if (!this.AttributeSet.ContainsKey(attrId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CombatInfo;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "尝试读取不存在的队伍属性。";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("typeId", attrId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return this.AttributeSet[attrId];
	}

	// Token: 0x06006789 RID: 26505 RVA: 0x001B00BC File Offset: 0x001AE2BC
	public void SetData(EFormationAttributeId attrId, float max, float baseMax, float value, float speed, double timestamp)
	{
		IAttributeData data = this.GetData(attrId);
		if (data != null)
		{
			data.Max = max;
			data.BaseMax = baseMax;
			data.Value = value;
			data.Speed = speed;
			data.Timestamp = timestamp;
		}
	}

	// Token: 0x0600678A RID: 26506 RVA: 0x001B00FC File Offset: 0x001AE2FC
	public void SetSpeed(EFormationAttributeId attrId, float newSpeed)
	{
		IAttributeData data = this.GetData(attrId);
		if (data != null)
		{
			float value = this.GetValue(attrId);
			data.Timestamp = this.GetPredictedServerStopTime();
			data.Value = value;
			data.Speed = newSpeed;
		}
	}

	// Token: 0x0600678B RID: 26507 RVA: 0x001B0138 File Offset: 0x001AE338
	public void SetValue(EFormationAttributeId attrId, float newValue)
	{
		IAttributeData data = this.GetData(attrId);
		if (data != null)
		{
			data.Timestamp = this.GetPredictedServerStopTime();
			data.Value = this.ClampValue(attrId, newValue, 0f, data.Max);
		}
	}

	// Token: 0x0600678C RID: 26508 RVA: 0x001B0178 File Offset: 0x001AE378
	public void SetMax(EFormationAttributeId attrId, float newMax)
	{
		if (this.AttributeSet.ContainsKey(attrId))
		{
			IAttributeData attributeData = this.AttributeSet[attrId];
			float value = this.GetValue(attrId);
			attributeData.Timestamp = this.GetPredictedServerStopTime();
			attributeData.Value = Math.Min(value, newMax);
			attributeData.Max = newMax;
		}
	}

	// Token: 0x0600678D RID: 26509 RVA: 0x001B01C8 File Offset: 0x001AE3C8
	public float ClampValue(EFormationAttributeId attrId, float baseValue, float minValue, float maxValue)
	{
		float num = baseValue;
		float? num2 = new float?(minValue);
		float val = maxValue;
		if (this.BoundsLockerMap.ContainsKey(attrId))
		{
			foreach (IBoundsLocker boundsLocker in this.BoundsLockerMap[attrId].Values)
			{
				if (boundsLocker.LockLowerBounds)
				{
					float num3 = boundsLocker.LowerPercent * maxValue + boundsLocker.LowerOffset;
					num2 = new float?(Math.Max(num2.GetValueOrDefault(num3), num3));
				}
				if (boundsLocker.LockUpperBounds)
				{
					float val2 = boundsLocker.UpperPercent * maxValue + boundsLocker.UpperOffset;
					val = Math.Min(val, val2);
				}
			}
		}
		num = Math.Min(val, num);
		if (num2 != null)
		{
			num = Math.Max(num2.Value, num);
		}
		return num;
	}

	// Token: 0x0600678E RID: 26510 RVA: 0x001B02BC File Offset: 0x001AE4BC
	public unsafe int AddBoundsLocker(EFormationAttributeId attrId, IBoundsLocker locker, int lockerHandle)
	{
		this.SetValue(attrId, this.GetValue(attrId));
		if (!this.BoundsLockerMap.ContainsKey(attrId))
		{
			this.BoundsLockerMap[attrId] = new Dictionary<int, IBoundsLocker>();
		}
		Dictionary<int, IBoundsLocker> dictionary = this.BoundsLockerMap[attrId];
		if (dictionary.ContainsKey(lockerHandle))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "重复添加队伍属性锁";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("attrId", attrId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", lockerHandle);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		dictionary[lockerHandle] = locker;
		this.SetValue(attrId, this.GetValue(attrId));
		return lockerHandle;
	}

	// Token: 0x0600678F RID: 26511 RVA: 0x001B0380 File Offset: 0x001AE580
	public bool RemoveBoundsLocker(EFormationAttributeId attrId, int lockerHandle)
	{
		this.SetValue(attrId, this.GetValue(attrId));
		if (!this.BoundsLockerMap.ContainsKey(attrId))
		{
			return false;
		}
		if (!this.BoundsLockerMap[attrId].Remove(lockerHandle))
		{
			return false;
		}
		this.SetValue(attrId, this.GetValue(attrId));
		return true;
	}

	// Token: 0x06006790 RID: 26512 RVA: 0x001B03D0 File Offset: 0x001AE5D0
	public double GetPredictedServerStopTime()
	{
		return Singleton<Time>.Instance.ServerCombatStopTime;
	}

	// Token: 0x04003168 RID: 12648
	private readonly Dictionary<EFormationAttributeId, IFormationAttributeConfig> Configs = new Dictionary<EFormationAttributeId, IFormationAttributeConfig>();

	// Token: 0x04003169 RID: 12649
	private readonly Dictionary<EFormationAttributeId, IAttributeData> AttributeSet = new Dictionary<EFormationAttributeId, IAttributeData>();

	// Token: 0x0400316A RID: 12650
	protected readonly Dictionary<EFormationAttributeId, Dictionary<int, IBoundsLocker>> BoundsLockerMap = new Dictionary<EFormationAttributeId, Dictionary<int, IBoundsLocker>>();
}
