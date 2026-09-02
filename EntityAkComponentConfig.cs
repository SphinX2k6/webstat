using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02003008 RID: 12296
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntityAkComponentConfig : ConfigBase<EntityAkComponentConfig>
{
	// Token: 0x060190BC RID: 102588 RVA: 0x0071C148 File Offset: 0x0071A348
	public EntityAudioConfig? GetEntityAkComponentConfig(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		string entityPbModelConfigId = component.EntityPbModelConfigId;
		return ConfigEntityAudioConfigByIdWithZero.GetConfig(entityPbModelConfigId, entityPbModelConfigId, entityPbModelConfigId, true);
	}

	// Token: 0x060190BD RID: 102589 RVA: 0x0071C178 File Offset: 0x0071A378
	[return: Nullable(2)]
	public unsafe FoleySynthAllConfig GetEntityFoleySynthConfig(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(component.GetPbDataId(), true);
		int num = (roleDataById != null && roleDataById.IsTrialRole()) ? roleDataById.GetRoleId() : component.GetPbDataId();
		FoleySynthConfig? config3 = ConfigFoleySynthConfigByIdWithDefaultId.GetConfig(0, num, num, num, true);
		if (config3 == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "该角色未在角色音频配置表中默认值配置 /Config/y.音频组件配置表/音频运动实体配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("默认值Id", 0);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		FoleySynthConfig valueOrDefault = config3.GetValueOrDefault();
		if (valueOrDefault.Id == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "该角色未在角色音频配置表中配置 /Config/y.音频组件配置表/音频运动实体配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("现替换Id", 0);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		FoleySynthAllConfig allConfig = new FoleySynthAllConfig();
		foreach (int num2 in valueOrDefault.Model1ConfigIter())
		{
			FoleySynthBoneConfig? config2 = ConfigFoleySynthBoneConfigById.GetConfig(num2, true);
			if (config2 != null)
			{
				FoleySynthBoneConfig config = config2.GetValueOrDefault();
				FoleySynthModel1Config model1Config = new FoleySynthModel1Config
				{
					BoneName = FNameUtil.GetDynamicFName(config.BoneName),
					Ceil = config.Model1Ceil,
					CeilEvent = config.Model1CeilEventPath,
					Floor = config.Model1Floor,
					FloorEvent = config.Model1FloorEventPath
				};
				allConfig.CurLoadCount++;
				Singleton<ResourceSystem>.Instance.LoadAsync<UAkRtpc>(config.Model1RtpcPath, delegate([Nullable(2)] UAkRtpc rptc, string _)
				{
					model1Config.Rtpc = rptc;
					allConfig.CurLoadCount--;
					if (model1Config.Rtpc == null)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Audio;
						ELogAuthor author5 = ELogAuthor.LJM;
						string message5 = "音频组件配置表配置的音频路径无效 /Config/y.音频组件配置表/角色音频配置";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Id", config.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Path", config.Model1RtpcPath);
						instance5.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
				}, 100, "js_undefined");
				model1Config.CeilInterpolation = config.Model1CeilInterpolation;
				model1Config.FloorInterpolation = config.Model1FloorInterpolation;
				allConfig.FoleySynthModel1Configs.Add(model1Config);
			}
			else
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Audio;
				ELogAuthor author3 = ELogAuthor.LJM;
				string message3 = "音频组件配置表配置的音频骨骼Id无效 /Config/y.音频组件配置表/角色音频配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Id", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ConfigId", num2);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
		}
		foreach (int num3 in valueOrDefault.Model2ConfigIter())
		{
			FoleySynthBoneConfig? config2 = ConfigFoleySynthBoneConfigById.GetConfig(num3, true);
			if (config2 != null)
			{
				FoleySynthBoneConfig config = config2.GetValueOrDefault();
				FoleySynthModel2Config model2Config = new FoleySynthModel2Config
				{
					BoneName = FNameUtil.GetDynamicFName(config.BoneName),
					Ceil = config.Model2Ceil,
					CeilEvent = config.Model2CeilEventPath,
					Floor = config.Model2Floor,
					FloorEvent = config.Model2FloorPath,
					FloorPrecent = config.Model2FloorPrecent
				};
				allConfig.CurLoadCount++;
				Singleton<ResourceSystem>.Instance.LoadAsync<UAkRtpc>(config.Model2RptcVelocityMax, delegate([Nullable(2)] UAkRtpc rtpcVelMax, string _)
				{
					model2Config.RtpcVelMax = rtpcVelMax;
					allConfig.CurLoadCount--;
					if (model2Config.RtpcVelMax == null)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Audio;
						ELogAuthor author5 = ELogAuthor.LJM;
						string message5 = "音频组件配置表配置的音频路径无效 /Config/y.音频组件配置表/角色音频配置";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Id", config.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Path", config.Model2RptcVelocityMax);
						instance5.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
				}, 100, "js_undefined");
				allConfig.CurLoadCount++;
				Singleton<ResourceSystem>.Instance.LoadAsync<UAkRtpc>(config.Model2RptcAccelerationMax, delegate([Nullable(2)] UAkRtpc rptcAccMax, string _)
				{
					model2Config.RtpcAccMax = rptcAccMax;
					allConfig.CurLoadCount--;
					if (model2Config.RtpcAccMax == null)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Audio;
						ELogAuthor author5 = ELogAuthor.LJM;
						string message5 = "音频组件配置表配置的音频路径无效 /Config/y.音频组件配置表/角色音频配置";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Id", config.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Path", config.Model2RptcAccelerationMax);
						instance5.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
				}, 100, "js_undefined");
				allConfig.CurLoadCount++;
				Singleton<ResourceSystem>.Instance.LoadAsync<UAkRtpc>(config.Model2RptcVelocityDuring, delegate([Nullable(2)] UAkRtpc rtpcVelDur, string _)
				{
					model2Config.RtpcVelDur = rtpcVelDur;
					allConfig.CurLoadCount--;
					if (model2Config.RtpcVelDur == null)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module5 = ELogModule.Audio;
						ELogAuthor author5 = ELogAuthor.LJM;
						string message5 = "音频组件配置表配置的音频路径无效 /Config/y.音频组件配置表/角色音频配置";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Id", config.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Path", config.Model2RptcVelocityDuring);
						instance5.Warn(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
					}
				}, 100, "js_undefined");
				model2Config.CeilInterpolation = config.Model2CeilInterpolation;
				model2Config.FloorInterpolation = config.Model2FloorInterpolation;
				allConfig.FoleySynthModel2Configs.Add(model2Config);
			}
			else
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Audio;
				ELogAuthor author4 = ELogAuthor.LJM;
				string message4 = "音频组件配置表配置的音频骨骼Id无效 /Config/y.音频组件配置表/角色音频配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Id", num3);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ConfigId", num3);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			}
		}
		allConfig.Model2AccelerationMaxCount = valueOrDefault.Model2AccMaxCount;
		allConfig.Model2VelocityMaxCount = valueOrDefault.Model2VelMaxCount;
		return allConfig;
	}

	// Token: 0x060190BE RID: 102590 RVA: 0x0071C70C File Offset: 0x0071A90C
	public CharacterAudioConfig? GetCharacterAudioConfigByEntity(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(component.GetPbDataId(), true);
		int configId = (roleDataById != null && roleDataById.IsTrialRole()) ? roleDataById.GetRoleId() : component.GetPbDataId();
		return this.GetCharacterAudioConfigByConfigId(configId);
	}

	// Token: 0x060190BF RID: 102591 RVA: 0x0071C760 File Offset: 0x0071A960
	public unsafe CharacterAudioConfig? GetCharacterAudioConfigByConfigId(int configId)
	{
		CharacterAudioConfig? config = ConfigCharacterAudioConfigByIdWithDefaultId.GetConfig(0, configId, configId, configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "该角色未在角色音频配置表中默认值配置 /Config/y.音频组件配置表/角色音频配置 ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("默认值Id", 0);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (config.Value.Id == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "该角色未在角色音频配置表中配置 /Config/y.音频组件配置表/角色音频配置 ";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", configId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("现替换Id", 0);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return config;
	}

	// Token: 0x0400C424 RID: 50212
	private const int DEFAULT_DB_ID = 0;
}
