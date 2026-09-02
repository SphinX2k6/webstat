using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200616B RID: 24939
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleAudioVolumeInfo : IStaticVariableResetter
	{
		// Token: 0x0603F04C RID: 258124 RVA: 0x01028982 File Offset: 0x01026B82
		static RoleAudioVolumeInfo()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoleAudioVolumeInfo.CreateStaticDefaultValue), new Action(RoleAudioVolumeInfo.ResetStaticDefaultValue));
		}

		// Token: 0x17009AF1 RID: 39665
		// (get) Token: 0x0603F04D RID: 258125 RVA: 0x010289A1 File Offset: 0x01026BA1
		public static List<string> CheckEventList
		{
			get
			{
				return RoleAudioVolumeInfo.CheckEventListInternal;
			}
		}

		// Token: 0x0603F04E RID: 258126 RVA: 0x010289A8 File Offset: 0x01026BA8
		public void Init()
		{
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("BgmMaxDistance").GetValueOrDefault();
			RoleAudioVolumeInfo.MaxDistanceSquared = (double)(valueOrDefault * valueOrDefault);
			int valueOrDefault2 = ConfigCommonParamById.GetIntConfig("BgmSplitDistance").GetValueOrDefault();
			RoleAudioVolumeInfo.SplitDistanceSquared = (double)(valueOrDefault2 * valueOrDefault2);
			RoleAudioVolumeInfo.DelayTime = ConfigCommonParamById.GetIntConfig("BgmDelayTime").GetValueOrDefault();
			RoleAudioVolumeInfo.CorrectionRatio = (double)ConfigCommonParamById.GetFloatConfig("BgmCorrectionRatio").GetValueOrDefault();
			IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("BgmCheckEventList");
			if (stringArrayConfig != null && stringArrayConfig.Count > 0)
			{
				foreach (string item in stringArrayConfig)
				{
					RoleAudioVolumeInfo.CheckEventList.Add(item);
				}
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}

		// Token: 0x0603F04F RID: 258127 RVA: 0x01028A8C File Offset: 0x01026C8C
		public void Clear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		}

		// Token: 0x0603F050 RID: 258128 RVA: 0x01028AAA File Offset: 0x01026CAA
		public void Update()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null && baseCharacter.IsValid())
			{
				this.RoleAudioHandleMap.UpdateVolume();
			}
		}

		// Token: 0x0603F051 RID: 258129 RVA: 0x01028ACC File Offset: 0x01026CCC
		public int PostEvent(AActor owner, string eventName, FName? socket = null)
		{
			UAkComponent akComponent = ControllerBase<GameAudioController>.Instance.GetAkComponent(owner, socket);
			if (akComponent == null || !akComponent.IsValid())
			{
				return 0;
			}
			bool flag = false;
			int handle = 0;
			if (RoleAudioVolumeInfo.CheckEventList.Contains(eventName))
			{
				TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					int entityId = tsBaseCharacter.EntityId;
					CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
					int? num = (characterActorComponent != null) ? new int?(characterActorComponent.CreatureData.GetPbDataId()) : null;
					int num2 = (num != null) ? RoleAudioVolumeInfo.GetRoleId(num.Value) : 0;
					if (num2 != 0)
					{
						handle = Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, new PostEventArgs?(new PostEventArgs
						{
							CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
							CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
							{
								this.RoleAudioHandleMap.RemoveEvent(entityId, handle);
							}
						}));
						this.RoleAudioHandleMap.AddEvent(entityId, num2, handle, eventName, tsBaseCharacter);
						flag = true;
					}
				}
			}
			if (!flag)
			{
				handle = Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, null);
			}
			return handle;
		}

		// Token: 0x0603F052 RID: 258130 RVA: 0x01028C00 File Offset: 0x01026E00
		public void RemoveEvent(AActor owner, int handle)
		{
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			if (tsBaseCharacter == null)
			{
				return;
			}
			int entityId = tsBaseCharacter.EntityId;
			this.RoleAudioHandleMap.RemoveEvent(entityId, handle);
		}

		// Token: 0x0603F053 RID: 258131 RVA: 0x01028C2C File Offset: 0x01026E2C
		private void OnUpdateSceneTeam()
		{
			this.RoleAudioHandleMap.OnUpdateTeam();
		}

		// Token: 0x0603F054 RID: 258132 RVA: 0x01028C3C File Offset: 0x01026E3C
		public static int GetRoleId(int pbDataId)
		{
			int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(pbDataId);
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(baseRoleId);
			if (roleConfig == null || roleConfig.Value.RoleType != 1)
			{
				return 0;
			}
			return baseRoleId;
		}

		// Token: 0x0603F055 RID: 258133 RVA: 0x01028C7F File Offset: 0x01026E7F
		public static void CreateStaticDefaultValue()
		{
			RoleAudioVolumeInfo.CheckEventListInternal = new List<string>();
		}

		// Token: 0x0603F056 RID: 258134 RVA: 0x01028C8B File Offset: 0x01026E8B
		public static void ResetStaticDefaultValue()
		{
			RoleAudioVolumeInfo.MaxDistanceSquared = 0.0;
			RoleAudioVolumeInfo.SplitDistanceSquared = 0.0;
			RoleAudioVolumeInfo.DelayTime = 0;
			RoleAudioVolumeInfo.CorrectionRatio = 0.0;
			RoleAudioVolumeInfo.CheckEventListInternal = null;
		}

		// Token: 0x040235C0 RID: 144832
		public static double MaxDistanceSquared;

		// Token: 0x040235C1 RID: 144833
		public static double SplitDistanceSquared;

		// Token: 0x040235C2 RID: 144834
		public static int DelayTime;

		// Token: 0x040235C3 RID: 144835
		public static double CorrectionRatio;

		// Token: 0x040235C4 RID: 144836
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static List<string> CheckEventListInternal;

		// Token: 0x040235C5 RID: 144837
		private readonly RoleVolumeMapInfo RoleAudioHandleMap = new RoleVolumeMapInfo();
	}
}
