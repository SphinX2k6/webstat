using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x02006166 RID: 24934
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GameAudioModel : ModelBase<GameAudioModel>
	{
		// Token: 0x17009AF0 RID: 39664
		// (get) Token: 0x0603F024 RID: 258084 RVA: 0x01027D91 File Offset: 0x01025F91
		private VehicleAudioEventInfo VehicleAudioInfo
		{
			get
			{
				if (this.VehicleAudioInfoInternal == null)
				{
					this.VehicleAudioInfoInternal = new VehicleAudioEventInfo();
					this.VehicleAudioInfoInternal.Init();
				}
				return this.VehicleAudioInfoInternal;
			}
		}

		// Token: 0x0603F025 RID: 258085 RVA: 0x01027DB8 File Offset: 0x01025FB8
		public void CheckTimeOutCooldownRecords()
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, EntityCooldownProbability> keyValuePair in this.EntityTagProbabilityMap)
			{
				if (keyValuePair.Value.CheckTimeOutCooldownRecords())
				{
					keyValuePair.Value.Clear();
					list.Add(keyValuePair.Key);
				}
			}
			foreach (int key in list)
			{
				this.EntityTagProbabilityMap.Remove(key);
			}
		}

		// Token: 0x0603F026 RID: 258086 RVA: 0x01027E78 File Offset: 0x01026078
		[NullableContext(2)]
		public bool CheckAudioProbabilityInfo(int entityId, [Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> eventObj, IAudioCoolDownWithTagInfo param = null, bool update = true, bool log = true, bool checkMorph = true)
		{
			if (param == null)
			{
				return true;
			}
			CharacterMorphComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterMorphComponent>(entityId);
			int? num;
			if (component == null)
			{
				num = null;
			}
			else
			{
				IMorphData morphData = component.GetMorphData(null);
				num = ((morphData != null) ? new int?(morphData.ModelId) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			if (checkMorph && valueOrDefault != 0 && !ControllerBase<GameAudioController>.Instance.CheckMorphAudioPlay(valueOrDefault, eventObj))
			{
				return false;
			}
			if (param.TagProbability == null || param.TagProbability.Num() == 0)
			{
				if (param.DefaultCooldownTime == 0)
				{
					return EntityCooldownProbability.GetProbability(param.DefaultProbability);
				}
				if (param.DefaultProbability == 0.0)
				{
					return false;
				}
			}
			int cooldownMapKey = this.GetCooldownMapKey(entityId, valueOrDefault);
			if (!this.EntityTagProbabilityMap.ContainsKey(cooldownMapKey))
			{
				EntityCooldownProbability entityCooldownProbability = new EntityCooldownProbability();
				entityCooldownProbability.Init(entityId, valueOrDefault);
				bool flag = entityCooldownProbability.CheckPlayAudio(eventObj, param, update, log);
				if (flag)
				{
					this.EntityTagProbabilityMap[cooldownMapKey] = entityCooldownProbability;
				}
				return flag;
			}
			return this.EntityTagProbabilityMap[cooldownMapKey].CheckPlayAudio(eventObj, param, update, log);
		}

		// Token: 0x0603F027 RID: 258087 RVA: 0x01027F90 File Offset: 0x01026190
		public void UpdateAudioCooldownRecord(int entityId, [Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> eventObj, double probability, int cooldownTime, bool log = true)
		{
			CharacterMorphComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterMorphComponent>(entityId);
			int? num;
			if (component == null)
			{
				num = null;
			}
			else
			{
				IMorphData morphData = component.GetMorphData(null);
				num = ((morphData != null) ? new int?(morphData.ModelId) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			int cooldownMapKey = this.GetCooldownMapKey(entityId, valueOrDefault);
			this.EntityTagProbabilityMap[cooldownMapKey].UpdateCooldownRecord(eventObj, probability, (double)cooldownTime, log);
		}

		// Token: 0x0603F028 RID: 258088 RVA: 0x01028008 File Offset: 0x01026208
		private int GetCooldownMapKey(int entityId, int modelId)
		{
			int result = entityId;
			if (modelId != 0 && ControllerBase<GameAudioController>.Instance.HasMorphAudioConfig(modelId))
			{
				result = modelId;
			}
			return result;
		}

		// Token: 0x0603F029 RID: 258089 RVA: 0x0102802A File Offset: 0x0102622A
		public void AddAllGondolaMusic(Entity entity)
		{
			this.VehicleAudioInfo.AddAllGondolaMusic(entity);
		}

		// Token: 0x0603F02A RID: 258090 RVA: 0x01028038 File Offset: 0x01026238
		public void StopAllGondolaMusic()
		{
			this.VehicleAudioInfo.StopAllGondolaMusic();
		}

		// Token: 0x0603F02B RID: 258091 RVA: 0x01028045 File Offset: 0x01026245
		public void GondolaGetOnAudioEvent(Entity entity)
		{
			this.VehicleAudioInfo.GondolaGetOnAudioEvent(entity);
		}

		// Token: 0x0603F02C RID: 258092 RVA: 0x01028053 File Offset: 0x01026253
		public void RegisterDriveAudioEvent(int roleId, int roleCreatureId)
		{
			this.VehicleAudioInfo.RegisterDriveAudioEvent(roleId, roleCreatureId);
		}

		// Token: 0x0603F02D RID: 258093 RVA: 0x01028062 File Offset: 0x01026262
		public void RemoveDriveAudioEvent()
		{
			this.VehicleAudioInfo.RemoveDriveAudioEvent();
		}

		// Token: 0x0603F02E RID: 258094 RVA: 0x0102806F File Offset: 0x0102626F
		public bool PlayRideSharingPlotAudio(EGondolaVoiceTriggeredType type)
		{
			return this.VehicleAudioInfo.PlayRideSharingPlotAudio(type);
		}

		// Token: 0x0603F02F RID: 258095 RVA: 0x0102807D File Offset: 0x0102627D
		public bool CheckRideSharingState()
		{
			return this.VehicleAudioInfo.CheckRideSharingState();
		}

		// Token: 0x0603F030 RID: 258096 RVA: 0x0102808A File Offset: 0x0102628A
		public void RegisterFishingAudioEvent()
		{
			this.VehicleAudioInfo.RegisterFishingAudioEvent();
		}

		// Token: 0x0603F031 RID: 258097 RVA: 0x01028097 File Offset: 0x01026297
		public void RemoveFishingAudioEvent()
		{
			this.VehicleAudioInfo.RemoveFishingAudioEvent();
		}

		// Token: 0x0603F032 RID: 258098 RVA: 0x010280A4 File Offset: 0x010262A4
		public bool PlayFishingAudio(EGondolaVoiceTriggeredType type)
		{
			return this.VehicleAudioInfo.PlayFishingAudio(type);
		}

		// Token: 0x0603F033 RID: 258099 RVA: 0x010280B2 File Offset: 0x010262B2
		public void RegisterMotorDriveAudioEvent(int roleId, int roleCreatureId)
		{
			this.VehicleAudioInfo.RegisterMotorDriveAudioEvent(roleId, roleCreatureId);
		}

		// Token: 0x0603F034 RID: 258100 RVA: 0x010280C1 File Offset: 0x010262C1
		public void RemoveMotorDriveAudioEvent()
		{
			this.VehicleAudioInfo.RemoveMotorDriveAudioEvent();
		}

		// Token: 0x0603F035 RID: 258101 RVA: 0x010280CE File Offset: 0x010262CE
		public bool PlayMotorPlotAudio(EGondolaVoiceTriggeredType type)
		{
			return this.VehicleAudioInfo.PlayMotorPlotAudioDefault(type);
		}

		// Token: 0x0603F036 RID: 258102 RVA: 0x010280DC File Offset: 0x010262DC
		public bool CheckMotorState()
		{
			return this.VehicleAudioInfo.CheckMotorState();
		}

		// Token: 0x040235A9 RID: 144809
		[Nullable(2)]
		private VehicleAudioEventInfo VehicleAudioInfoInternal;

		// Token: 0x040235AA RID: 144810
		private readonly Dictionary<int, EntityCooldownProbability> EntityTagProbabilityMap = new Dictionary<int, EntityCooldownProbability>();
	}
}
