using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Config;
using CSharpScript.Core.Framework;
using UnrealEngine;

// Token: 0x02002E9A RID: 11930
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class BuffController : ControllerBase<BuffController>
{
	// Token: 0x06018800 RID: 100352 RVA: 0x006DDE0F File Offset: 0x006DC00F
	protected override bool OnInit()
	{
		this.PreloadAllBuffDefs();
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			this.ReloadCallback = new Action(this.OnConfigReload);
			ConfigReloadHub.RegisterReloadCallback("db_buff.db", this.ReloadCallback);
		}
		return base.OnInit();
	}

	// Token: 0x06018801 RID: 100353 RVA: 0x006DDE4C File Offset: 0x006DC04C
	private void PreloadAllBuffDefs()
	{
		if (!UKuroStaticLibrary.IsLowMemoryDevice())
		{
			IReadOnlyList<Buff> configList = ConfigBuffGetAll.GetConfigList(false);
			if (configList != null)
			{
				foreach (Buff buff in configList)
				{
					this.AddBuffRef(buff);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.GHY;
				string message = "[热更][db_buff.db] 全量预热完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("预热条数", configList.Count);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<Log>.Instance.Warn(ELogModule.Character, ELogAuthor.GHY, "[Buff] 预热全表失败：GetConfigList 返回空，解析后缓存未重建，将依赖运行时懒加载", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06018802 RID: 100354 RVA: 0x006DDEFC File Offset: 0x006DC0FC
	public void OnConfigReload()
	{
		ModelBase<BuffModel>.Instance.ClearAllDefs();
		this.PreloadAllBuffDefs();
		Singleton<Log>.Instance.Info(ELogModule.CombatInfo, ELogAuthor.GHY, "[热更][db_buff.db] 配置热更回调：已清空并重建解析后缓存", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06018803 RID: 100355 RVA: 0x006DDF38 File Offset: 0x006DC138
	protected override bool OnClear()
	{
		if (this.ReloadCallback != null)
		{
			ConfigReloadHub.UnregisterReloadCallback("db_buff.db", this.ReloadCallback);
			this.ReloadCallback = null;
		}
		this.ComponentsWithPendingCues.Clear();
		return base.OnClear();
	}

	// Token: 0x06018804 RID: 100356 RVA: 0x006DDF6A File Offset: 0x006DC16A
	public void RegisterBuffComponent(BaseBuffComponent component)
	{
		this.ComponentsWithPendingCues.Add(component);
	}

	// Token: 0x06018805 RID: 100357 RVA: 0x006DDF79 File Offset: 0x006DC179
	public void UnregisterBuffComponent(BaseBuffComponent component)
	{
		this.ComponentsWithPendingCues.Remove(component);
	}

	// Token: 0x06018806 RID: 100358 RVA: 0x006DDF88 File Offset: 0x006DC188
	protected override void OnTick(float delta)
	{
		this.CueTimeLimit.ResetCost();
		foreach (BaseBuffComponent baseBuffComponent in this.ComponentsWithPendingCues)
		{
			baseBuffComponent.ProcessPendingCues();
			if (this.CueTimeLimit.IsTimeLimitExceeded())
			{
				break;
			}
		}
	}

	// Token: 0x06018807 RID: 100359 RVA: 0x006DDFF4 File Offset: 0x006DC1F4
	public unsafe void SetHandlePrefix(int prefix, int handleIdStart)
	{
		int num = 15;
		if (prefix < 0 || prefix > num)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "Invalid Buff Handle prefix.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("prefix", prefix);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handleStart", handleIdStart);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			prefix &= num;
		}
		BuffModel instance2 = ModelBase<BuffModel>.Instance;
		instance2.HandlePrefix = prefix << 28;
		instance2.LastHandle = Math.Max(handleIdStart, instance2.LastHandle);
	}

	// Token: 0x06018808 RID: 100360 RVA: 0x006DE090 File Offset: 0x006DC290
	public int GenerateHandle()
	{
		BuffModel instance = ModelBase<BuffModel>.Instance;
		BuffModel buffModel = instance;
		int num = buffModel.LastHandle + 1;
		buffModel.LastHandle = num;
		return (num & 268435455) + (instance.HandlePrefix & -268435456);
	}

	// Token: 0x06018809 RID: 100361 RVA: 0x006DE0C8 File Offset: 0x006DC2C8
	[NullableContext(2)]
	public unsafe BuffDefinition GetBuffDefinition(long buffId, string reason = null)
	{
		BuffDefinition buffDefinition = ModelBase<BuffModel>.Instance.Get(buffId);
		if (buffDefinition != null)
		{
			return buffDefinition;
		}
		if (buffId == -3L)
		{
			return null;
		}
		Buff? config = ConfigBuffById.GetConfig(buffId, true);
		if (config == null)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
			Entity entity = null;
			string message = "无法查找到对应编号的Buff。";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("原因", reason ?? "");
			instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return this.AddBuffRef(config.Value);
	}

	// Token: 0x0601880A RID: 100362 RVA: 0x006DE170 File Offset: 0x006DC370
	[NullableContext(2)]
	protected ExtraEffectParameters ParseExtraEffect(Buff buff, int index)
	{
		if (buff.ExtraEffectID == 0)
		{
			return null;
		}
		ExtraEffectParameters extraEffectParameters = new ExtraEffectParameters();
		extraEffectParameters.ExtraEffectId = (EExtraEffectId)buff.ExtraEffectID;
		extraEffectParameters.ExtraEffectParameters_ = BuffController.GetStringArray(buff, buff.ExtraEffectParametersLength, new Func<int, string>(buff.ExtraEffectParameters));
		extraEffectParameters.ExtraEffectGrowParameters1 = BuffController.ConvertIntArrayToFloat(buff.GetExtraEffectParametersGrow1Array());
		extraEffectParameters.ExtraEffectGrowParameters2 = BuffController.ConvertIntArrayToFloat(buff.GetExtraEffectParametersGrow2Array());
		extraEffectParameters.ExtraEffectGrowParameters3 = BuffController.GetStringArray(buff, buff.ExtraEffectParametersGrow3Length, new Func<int, string>(buff.ExtraEffectParametersGrow3));
		extraEffectParameters.ExtraEffectRequirement = buff.GetExtraEffectRequirementsArray();
		extraEffectParameters.ExtraEffectRequirementPara = BuffController.GetStringArray(buff, buff.ExtraEffectReqParaLength, new Func<int, string>(buff.ExtraEffectReqPara));
		extraEffectParameters.ExtraEffectRequirementSetting = buff.ExtraEffectReqSetting;
		extraEffectParameters.ExtraEffectCd = buff.GetExtraEffectCDArray();
		extraEffectParameters.ExtraEffectCdForTarget = buff.GetExtraEffectCdForTargetArray();
		extraEffectParameters.ExtraEffectRemoveStackNum = buff.ExtraEffectRemoveStackNum;
		extraEffectParameters.ExtraEffectProbability = BuffController.ConvertIntArrayToFloat(buff.GetExtraEffectProbabilityArray());
		RequireAndLimits requireAndLimits = ExtraEffectLibrary.BuffExtraEffectLibrary.ResolveRequireAndLimits(buff.Id, extraEffectParameters, 1);
		Type buffExecutionClass = ExtraEffectDefine.GetBuffExecutionClass((EExtraEffectId)buff.ExtraEffectID);
		if (buffExecutionClass != null)
		{
			BuffExecution executionEffect = (BuffExecution)typeof(BuffExecution).GetMethod("Create").MakeGenericMethod(new Type[]
			{
				buffExecutionClass
			}).Invoke(null, new object[]
			{
				buff.Id,
				index,
				requireAndLimits,
				extraEffectParameters
			});
			extraEffectParameters.ExecutionEffect = executionEffect;
		}
		return extraEffectParameters;
	}

	// Token: 0x0601880B RID: 100363 RVA: 0x006DE300 File Offset: 0x006DC500
	private static string[] GetStringArray(Buff buff, int length, [Nullable(new byte[]
	{
		1,
		2
	})] Func<int, string> getter)
	{
		string[] array = new string[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = (getter(i) ?? "");
		}
		return array;
	}

	// Token: 0x0601880C RID: 100364 RVA: 0x006DE334 File Offset: 0x006DC534
	private static float[] ConvertIntArrayToFloat([Nullable(2)] int[] intArray)
	{
		if (intArray == null)
		{
			return Array.Empty<float>();
		}
		float[] array = new float[intArray.Length];
		for (int i = 0; i < intArray.Length; i++)
		{
			array[i] = (float)intArray[i];
		}
		return array;
	}

	// Token: 0x0601880D RID: 100365 RVA: 0x006DE36C File Offset: 0x006DC56C
	private List<Buff> GetEffectBuffs(Buff buff)
	{
		List<Buff> list = new List<Buff>
		{
			buff
		};
		for (int i = 0; i < buff.RelatedExtraEffectBuffIdLength; i++)
		{
			Buff? config = ConfigBuffById.GetConfig(buff.RelatedExtraEffectBuffId(i), true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		return list;
	}

	// Token: 0x0601880E RID: 100366 RVA: 0x006DE3C0 File Offset: 0x006DC5C0
	private List<Buff> GetAttributeBuffs(Buff buff)
	{
		List<Buff> list = new List<Buff>
		{
			buff
		};
		for (int i = 0; i < buff.RelatedAttributeBuffIdLength; i++)
		{
			Buff? config = ConfigBuffById.GetConfig(buff.RelatedAttributeBuffId(i), true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		return list;
	}

	// Token: 0x0601880F RID: 100367 RVA: 0x006DE412 File Offset: 0x006DC612
	public void AssignDesc(BuffDefinition newRef, string desc)
	{
		newRef.Desc = desc;
	}

	// Token: 0x06018810 RID: 100368 RVA: 0x006DE41C File Offset: 0x006DC61C
	public unsafe BuffDefinition AddBuffRef(Buff buff)
	{
		BuffDefinition buffDefinition = new BuffDefinition();
		buffDefinition.Id = new long?(buff.Id);
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			buffDefinition.Desc = "";
			this.AssignDesc(buffDefinition, buff.GeDesc ?? "");
		}
		buffDefinition.StackLimitCount = buff.StackLimitCount;
		buffDefinition.FormationPolicy = (EBuffFormationPolicy)buff.FormationPolicy;
		buffDefinition.StackingType = (EBuffStackingType)buff.StackingType;
		buffDefinition.DefaultStackCount = buff.DefaultStackCount;
		buffDefinition.StackAppendCount = buff.StackAppendCount;
		buffDefinition.Probability = buff.Probability;
		buffDefinition.DurationMagnitude = buff.GetDurationMagnitudeArray();
		buffDefinition.DurationPolicy = (EBuffDurationType)buff.DurationPolicy;
		buffDefinition.DurationMagnitude2 = buff.GetDurationMagnitude2Array();
		buffDefinition.DurationCalculationPolicy = buff.GetDurationCalculationPolicyArray();
		buffDefinition.DurationAffectedByBulletTime = buff.BDurationAffectedByBulletTime;
		buffDefinition.Period = buff.Period;
		buffDefinition.PeriodicInhibitionPolicy = (EBuffPeriodicInhibitionPolicy)buff.PeriodicInhibitionPolicy;
		buffDefinition.ExecutePeriodicOnAdd = buff.BExecutePeriodicEffectOnApplication;
		buffDefinition.StackDurationRefreshPolicy = (EBuffStackDurationRefreshPolicy)buff.StackDurationRefreshPolicy;
		buffDefinition.StackPeriodResetPolicy = (EBuffStackPeriodResetPolicy)buff.StackPeriodResetPolicy;
		buffDefinition.StackExpirationRemoveNumber = buff.StackExpirationRemoveNumber;
		buffDefinition.DenyOverflowAdd = buff.BDenyOverflowApplication;
		buffDefinition.ClearStackOnOverflow = buff.BClearStackOnOverflow;
		if (buff.BOnlyLocalAdd)
		{
			if (buff.GameAttributeID == 0 && buff.RelatedAttributeBuffIdLength == 0 && buff.GrantedTagsLength == 0 && buff.OverflowEffectsLength == 0 && buff.RoutineExpirationEffectsLength == 0 && buff.PrematureExpirationEffectsLength == 0 && buff.RelatedExtraEffectBuffIdLength == 0 && buff.ExtraEffectID == 0 && buff.BuffActionLength == 0)
			{
				buffDefinition.OnlyLocalAdd = buff.BOnlyLocalAdd;
			}
			else
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity = null;
				string message = "非纯特效Buff，被标记为仅本地添加，请检查Buff配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", buff.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BuffDesc", buff.GeDesc ?? "");
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		List<Buff> attributeBuffs = this.GetAttributeBuffs(buff);
		List<IBuffModifierData> list = new List<IBuffModifierData>(buffDefinition.Modifiers);
		for (int i = 0; i < attributeBuffs.Count; i++)
		{
			Buff buff2 = attributeBuffs[i];
			if (buff2.GameAttributeID > 0)
			{
				list.Add(new BuffModifierData
				{
					AttributeId = (EAttributeType)buff2.GameAttributeID,
					Value1 = BuffController.ConvertIntArrayToFloat(buff2.GetModifierMagnitudeArray()),
					Value2 = BuffController.ConvertIntArrayToFloat(buff2.GetModifierMagnitude2Array()),
					CalculationPolicy = buff2.GetCalculationPolicyArray()
				});
			}
		}
		buffDefinition.Modifiers = list.ToArray();
		buffDefinition.PrematureExpirationEffects = buff.GetPrematureExpirationEffectsArray();
		buffDefinition.RoutineExpirationEffects = buff.GetRoutineExpirationEffectsArray();
		buffDefinition.OverflowEffects = buff.GetOverflowEffectsArray();
		buffDefinition.GameplayCueIds = buff.GetGameplayCueIdsArray();
		buffDefinition.DeadRemove = buff.DeadRemove;
		if (buff.RemoveBuffWithTagsLength > 0)
		{
			List<int> list2 = new List<int>();
			for (int j = 0; j < buff.RemoveBuffWithTagsLength; j++)
			{
				int tagIdByName = GameplayTagUtils.GetTagIdByName(buff.RemoveBuffWithTags(j));
				if (tagIdByName != 0)
				{
					list2.Add(tagIdByName);
				}
			}
			buffDefinition.RemoveBuffWithTags = list2.ToArray();
		}
		if (buff.GrantedTagsLength > 0)
		{
			List<int> list3 = new List<int>();
			for (int k = 0; k < buff.GrantedTagsLength; k++)
			{
				int tagIdByName2 = GameplayTagUtils.GetTagIdByName(buff.GrantedTags(k));
				if (tagIdByName2 != 0)
				{
					list3.Add(tagIdByName2);
				}
			}
			buffDefinition.GrantedTags = list3.ToArray();
		}
		if (buff.ApplicationSourceTagRequirementsLength > 0)
		{
			List<int> list4 = new List<int>();
			for (int l = 0; l < buff.ApplicationSourceTagRequirementsLength; l++)
			{
				int tagIdByName3 = GameplayTagUtils.GetTagIdByName(buff.ApplicationSourceTagRequirements(l));
				if (tagIdByName3 != 0)
				{
					list4.Add(tagIdByName3);
				}
			}
			buffDefinition.AddInstigatorTagRequirements = list4.ToArray();
		}
		if (buff.ApplicationSourceTagIgnoresLength > 0)
		{
			List<int> list5 = new List<int>();
			for (int m = 0; m < buff.ApplicationSourceTagIgnoresLength; m++)
			{
				int tagIdByName4 = GameplayTagUtils.GetTagIdByName(buff.ApplicationSourceTagIgnores(m));
				if (tagIdByName4 != 0)
				{
					list5.Add(tagIdByName4);
				}
			}
			buffDefinition.AddInstigatorTagIgnores = list5.ToArray();
		}
		if (buff.ApplicationTagRequirementsLength > 0)
		{
			List<int> list6 = new List<int>();
			for (int n = 0; n < buff.ApplicationTagRequirementsLength; n++)
			{
				int tagIdByName5 = GameplayTagUtils.GetTagIdByName(buff.ApplicationTagRequirements(n));
				if (tagIdByName5 != 0)
				{
					list6.Add(tagIdByName5);
				}
			}
			buffDefinition.AddTagRequirements = list6.ToArray();
		}
		if (buff.ApplicationTagIgnoresLength > 0)
		{
			List<int> list7 = new List<int>();
			for (int num = 0; num < buff.ApplicationTagIgnoresLength; num++)
			{
				int tagIdByName6 = GameplayTagUtils.GetTagIdByName(buff.ApplicationTagIgnores(num));
				if (tagIdByName6 != 0)
				{
					list7.Add(tagIdByName6);
				}
			}
			buffDefinition.AddTagIgnores = list7.ToArray();
		}
		if (buff.OngoingTagRequirementsLength > 0)
		{
			List<int> list8 = new List<int>();
			for (int num2 = 0; num2 < buff.OngoingTagRequirementsLength; num2++)
			{
				int tagIdByName7 = GameplayTagUtils.GetTagIdByName(buff.OngoingTagRequirements(num2));
				if (tagIdByName7 != 0)
				{
					list8.Add(tagIdByName7);
				}
			}
			buffDefinition.ActivateTagRequirements = list8.ToArray();
		}
		if (buff.OngoingTagIgnoresLength > 0)
		{
			List<int> list9 = new List<int>();
			for (int num3 = 0; num3 < buff.OngoingTagIgnoresLength; num3++)
			{
				int tagIdByName8 = GameplayTagUtils.GetTagIdByName(buff.OngoingTagIgnores(num3));
				if (tagIdByName8 != 0)
				{
					list9.Add(tagIdByName8);
				}
			}
			buffDefinition.ActivateTagIgnores = list9.ToArray();
		}
		if (buff.RemovalTagRequirementsLength > 0)
		{
			List<int> list10 = new List<int>();
			for (int num4 = 0; num4 < buff.RemovalTagRequirementsLength; num4++)
			{
				int tagIdByName9 = GameplayTagUtils.GetTagIdByName(buff.RemovalTagRequirements(num4));
				if (tagIdByName9 != 0)
				{
					list10.Add(tagIdByName9);
				}
			}
			buffDefinition.RemoveTagExistAll = list10.ToArray();
		}
		if (buff.RemovalTagIgnoresLength > 0)
		{
			List<int> list11 = new List<int>();
			for (int num5 = 0; num5 < buff.RemovalTagIgnoresLength; num5++)
			{
				int tagIdByName10 = GameplayTagUtils.GetTagIdByName(buff.RemovalTagIgnores(num5));
				if (tagIdByName10 != 0)
				{
					list11.Add(tagIdByName10);
				}
			}
			buffDefinition.RemoveTagIgnores = list11.ToArray();
		}
		if (buff.GrantedApplicationImmunityTagsLength > 0)
		{
			List<int> list12 = new List<int>();
			for (int num6 = 0; num6 < buff.GrantedApplicationImmunityTagsLength; num6++)
			{
				int tagIdByName11 = GameplayTagUtils.GetTagIdByName(buff.GrantedApplicationImmunityTags(num6));
				if (tagIdByName11 != 0)
				{
					list12.Add(tagIdByName11);
				}
			}
			buffDefinition.ImmuneTags = list12.ToArray();
		}
		if (buff.GrantedApplicationImmunityTagIgnoresLength > 0)
		{
			List<int> list13 = new List<int>();
			for (int num7 = 0; num7 < buff.GrantedApplicationImmunityTagIgnoresLength; num7++)
			{
				int tagIdByName12 = GameplayTagUtils.GetTagIdByName(buff.GrantedApplicationImmunityTagIgnores(num7));
				if (tagIdByName12 != 0)
				{
					list13.Add(tagIdByName12);
				}
			}
			buffDefinition.ImmuneTagIgnores = list13.ToArray();
		}
		List<Buff> effectBuffs = this.GetEffectBuffs(buff);
		for (int num8 = 0; num8 < effectBuffs.Count; num8++)
		{
			Buff buff3 = effectBuffs[num8];
			if (this.CheckExtraEffectParams(buff3))
			{
				EExtraEffectId extraEffectID = (EExtraEffectId)buff3.ExtraEffectID;
				if (extraEffectID != EExtraEffectId.RemoveSelfByTag)
				{
					if (extraEffectID != EExtraEffectId.GetBuffByStackCountOnRemoved)
					{
						ExtraEffectParameters extraEffectParameters = this.ParseExtraEffect(buff3, num8);
						if (extraEffectParameters != null)
						{
							buffDefinition.EffectInfos.Add(extraEffectParameters);
						}
					}
					else
					{
						List<long> list14 = (buffDefinition.BuffsAddedByStackCountOnRemoved != null) ? new List<long>(buffDefinition.BuffsAddedByStackCountOnRemoved) : new List<long>();
						string text = buff3.ExtraEffectParameters(0);
						if (text != null)
						{
							foreach (string s in text.Split('#', StringSplitOptions.None))
							{
								list14.Add(long.Parse(s));
							}
						}
						buffDefinition.BuffsAddedByStackCountOnRemoved = list14.ToArray();
					}
				}
				else
				{
					List<int> list15 = (buffDefinition.RemoveTagExistAny != null) ? new List<int>(buffDefinition.RemoveTagExistAny) : new List<int>();
					string text2 = buff3.ExtraEffectParameters(0);
					if (text2 != null)
					{
						foreach (string text3 in text2.Split('#', StringSplitOptions.None))
						{
							int tagIdByName13 = GameplayTagUtils.GetTagIdByName((text3 != null) ? text3.Trim() : null);
							if (tagIdByName13 != 0)
							{
								list15.Add(tagIdByName13);
							}
						}
					}
					buffDefinition.RemoveTagExistAny = list15.ToArray();
				}
			}
		}
		if (buff.BuffActionLength > 0)
		{
			List<TBuffAction> list16 = new List<TBuffAction>();
			for (int num10 = 0; num10 < buff.BuffActionLength; num10++)
			{
				string text4 = buff.BuffAction(num10);
				if (text4 != null)
				{
					string[] array2 = text4.Split('#', StringSplitOptions.None);
					string[] array3 = new string[array2.Length];
					for (int num11 = 0; num11 < array2.Length; num11++)
					{
						array3[num11] = array2[num11].Trim();
					}
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("BuffId", buff.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Action", text4);
					ReadOnlySpan<ValueTuple<string, object>> pairs = <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2);
					if (array3.Length < 2)
					{
						Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Buff, null, "BuffAction参数过少", pairs);
					}
					else
					{
						EBuffActionType ebuffActionType = (EBuffActionType)int.Parse(array3[0]);
						if (ebuffActionType - EBuffActionType.RemoveBuffWhenInstigatorHasSomeTag > 7)
						{
							if (ebuffActionType - EBuffActionType.RemoveBuffWhenInstigatorHasSomeBuff > 7)
							{
								switch (ebuffActionType)
								{
								case EBuffActionType.RemoveBuffWhenVictimHasSomeTag:
								case EBuffActionType.RemoveBuffWhenVictimHasEveryTag:
								case EBuffActionType.RemoveBuffWhenVictimNotHasSomeTag:
								case EBuffActionType.RemoveBuffWhenVictimNotHasEveryTag:
								case EBuffActionType.InactiveBuffWhenVictimHasSomeTag:
								case EBuffActionType.InactiveBuffWhenVictimHasEveryTag:
								case EBuffActionType.InactiveBuffWhenVictimNotHasSomeTag:
								case EBuffActionType.InactiveBuffWhenVictimNotHasEveryTag:
									goto IL_9C6;
								case EBuffActionType.RemoveBuffWhenVictimHasSomeBuff:
								case EBuffActionType.RemoveBuffWhenVictimHasEveryBuff:
								case EBuffActionType.RemoveBuffWhenVictimNotHasSomeBuff:
								case EBuffActionType.RemoveBuffWhenVictimNotHasEveryBuff:
								case EBuffActionType.InactiveBuffWhenVictimHasSomeBuff:
								case EBuffActionType.InactiveBuffWhenVictimHasEveryBuff:
								case EBuffActionType.InactiveBuffWhenVictimNotHasSomeBuff:
								case EBuffActionType.InactiveBuffWhenVictimNotHasEveryBuff:
									goto IL_958;
								case EBuffActionType.RemoveBuffWhenInstigatorDeadOrRemoved:
									try
									{
										List<int> list17 = new List<int>();
										for (int num12 = 1; num12 < array3.Length; num12++)
										{
											list17.Add(int.Parse(array3[num12]));
										}
										list16.Add(new TBuffAction
										{
											Type = ebuffActionType,
											CustomParams = list17.ToArray()
										});
										goto IL_AAC;
									}
									catch (Exception e)
									{
										Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, null, "BuffAction自定义参数解析失败", e, pairs);
										goto IL_AAC;
									}
									break;
								}
								Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Buff, null, "BuffAction参数不合法", pairs);
								goto IL_AAC;
							}
							IL_958:
							try
							{
								List<long> list18 = new List<long>();
								for (int num13 = 1; num13 < array3.Length; num13++)
								{
									list18.Add(long.Parse(array3[num13]));
								}
								list16.Add(new TBuffAction
								{
									Type = ebuffActionType,
									Buffs = list18.ToArray()
								});
								goto IL_AAC;
							}
							catch (Exception e2)
							{
								Singleton<CombatLog>.Instance.ErrorWithStack(CombatLog.EDebugModule.Buff, null, "BuffAction参数解析失败", e2, pairs);
								goto IL_AAC;
							}
						}
						IL_9C6:
						List<int> list19 = new List<int>();
						for (int num14 = 1; num14 < array3.Length; num14++)
						{
							int tagIdByName14 = GameplayTagUtils.GetTagIdByName(array3[num14]);
							if (tagIdByName14 == 0)
							{
								Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Buff, null, "BuffAction找不到对应的Tag", pairs);
							}
							else
							{
								list19.Add(tagIdByName14);
							}
						}
						list16.Add(new TBuffAction
						{
							Type = ebuffActionType,
							Tags = list19.ToArray()
						});
					}
				}
				IL_AAC:;
			}
			buffDefinition.BuffAction = list16.ToArray();
		}
		buffDefinition.HasBuffEffect = this.HasBuffEffects(buffDefinition.EffectInfos);
		buffDefinition.HasBuffPeriodExecution = this.HasBuffPeriodExecutions(buffDefinition.EffectInfos);
		int replaceBuffIdsLength = buff.ReplaceBuffIdsLength;
		if (replaceBuffIdsLength > 0)
		{
			int replaceConditionsLength = buff.ReplaceConditionsLength;
			if (replaceConditionsLength != replaceBuffIdsLength)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
				Entity entity2 = null;
				string message2 = "ConfigOverride配置错误：ReplaceBuffIds和ReplaceConditions长度不一致";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("BuffId", buff.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ReplaceBuffIds长度", replaceBuffIdsLength);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("ReplaceConditions长度", replaceConditionsLength);
				instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			}
			else
			{
				List<IConfigOverrideRule> list20 = new List<IConfigOverrideRule>();
				for (int num15 = 0; num15 < replaceBuffIdsLength; num15++)
				{
					long overrideConfigId = buff.ReplaceBuffIds(num15);
					string text5 = buff.ReplaceConditions(num15);
					string[] array4 = text5.Split('#', StringSplitOptions.None);
					if (array4.Length < 1)
					{
						CombatLog instance3 = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Buff;
						Entity entity3 = null;
						string message3 = "ConfigOverride条件字符串格式错误";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("BuffId", buff.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Condition", text5);
						instance3.Error(flag3, entity3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
					else
					{
						EConfigOverrideConditionType econfigOverrideConditionType = (EConfigOverrideConditionType)int.Parse(array4[0]);
						if (econfigOverrideConditionType != EConfigOverrideConditionType.None)
						{
							ConfigOverrideConditionListener.ConfigOverrideRule item = new ConfigOverrideConditionListener.ConfigOverrideRule
							{
								OverrideConfigId = overrideConfigId,
								ConditionType = econfigOverrideConditionType,
								ConditionString = text5
							};
							list20.Add(item);
						}
					}
				}
				buffDefinition.ConfigOverrides = list20.ToArray();
			}
		}
		ModelBase<BuffModel>.Instance.Add(buff.Id, buffDefinition);
		return buffDefinition;
	}

	// Token: 0x06018811 RID: 100369 RVA: 0x006DF0DC File Offset: 0x006DD2DC
	public BuffDefinition CreateDynamicBuffRef()
	{
		return new BuffDefinition
		{
			Id = new long?(-3L),
			DurationPolicy = EBuffDurationType.Infinite
		};
	}

	// Token: 0x06018812 RID: 100370 RVA: 0x006DF0F8 File Offset: 0x006DD2F8
	private unsafe bool CheckExtraEffectParams(Buff buff)
	{
		EExtraEffectId extraEffectID = (EExtraEffectId)buff.ExtraEffectID;
		if (extraEffectID != EExtraEffectId.LockValue)
		{
			if (extraEffectID - EExtraEffectId.LockUpperBound <= 1)
			{
				if (buff.ExtraEffectParametersLength < 1)
				{
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
					Entity entity = null;
					string message = "带有锁定上下限属性额外效果15或16的Buff配置的效果参数过少 < 1，此效果无效";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BuffId", buff.Id);
					instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				EAttributeType eattributeType = (EAttributeType)int.Parse(buff.ExtraEffectParameters(0) ?? "0");
				if (!CharacterAttributeTypes.stateAttributeIds.Contains(eattributeType))
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Buff;
					Entity entity2 = null;
					string message2 = "带有锁定属性上下限额外效果的Buff配置的属性Id不是状态属性（生命、能量等），此效果无效(如锁定生命，应该填生命属性的Id而不是上限属性的Id)";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BuffId", buff.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AttributeId", eattributeType);
					instance2.Error(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return false;
				}
			}
		}
		else if (buff.ExtraEffectParametersLength < 2)
		{
			CombatLog instance3 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.Buff;
			Entity entity3 = null;
			string message3 = "带有锁定属性额外效果14的Buff配置的效果参数过少 < 2，此效果无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("BuffId", buff.Id);
			instance3.Error(flag3, entity3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		return true;
	}

	// Token: 0x06018813 RID: 100371 RVA: 0x006DF22C File Offset: 0x006DD42C
	public bool HasBuffEffects(IReadOnlyList<ExtraEffectParameters> effectInfos)
	{
		using (IEnumerator<ExtraEffectParameters> enumerator = effectInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (ExtraEffectDefine.GetBuffEffectClass(enumerator.Current.ExtraEffectId) != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06018814 RID: 100372 RVA: 0x006DF288 File Offset: 0x006DD488
	public bool HasBuffPeriodExecutions(IReadOnlyList<ExtraEffectParameters> effectInfos)
	{
		foreach (ExtraEffectParameters extraEffectParameters in effectInfos)
		{
			if (ExtraEffectIdSets.periodExecutionIds.Contains(extraEffectParameters.ExtraEffectId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018815 RID: 100373 RVA: 0x006DF2E4 File Offset: 0x006DD4E4
	public static long[] GetBuffIdsByGroup(int buffGroupId)
	{
		BuffGroup? config = ConfigBuffGroupById.GetConfig(buffGroupId, true);
		if (config != null)
		{
			return config.Value.GetBuffsArray();
		}
		return Array.Empty<long>();
	}

	// Token: 0x0400BCE9 RID: 48361
	private const bool UseBuffConfigCache = true;

	// Token: 0x0400BCEA RID: 48362
	private const string BuffDbName = "db_buff.db";

	// Token: 0x0400BCEB RID: 48363
	private HashSet<BaseBuffComponent> ComponentsWithPendingCues = new HashSet<BaseBuffComponent>();

	// Token: 0x0400BCEC RID: 48364
	[Nullable(2)]
	private Action ReloadCallback;

	// Token: 0x0400BCED RID: 48365
	public TimeLimit CueTimeLimit = new TimeLimit(new long?(1000L));

	// Token: 0x0400BCEE RID: 48366
	[StaticVariableRuleIgnore]
	private static readonly Stat AddBuffRefStat = Stat.Create("BuffController.AddBuffRef", "", "");
}
