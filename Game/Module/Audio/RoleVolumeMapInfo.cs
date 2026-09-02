using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200616A RID: 24938
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleVolumeMapInfo
	{
		// Token: 0x0603F043 RID: 258115 RVA: 0x010283F2 File Offset: 0x010265F2
		public void OnUpdateTeam()
		{
			this.MaintainCurrentList();
			this.MaintainMapData();
			this.LastPlayEntityId = -1;
		}

		// Token: 0x0603F044 RID: 258116 RVA: 0x01028408 File Offset: 0x01026608
		public void UpdateVolume()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			if (this.Empty() || characterActorComponent == null)
			{
				return;
			}
			EEventVolumePriority eeventVolumePriority = EEventVolumePriority.Mute;
			List<int> list = new List<int>();
			foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
			{
				WorldEntity entity = entityHandle.Entity;
				CharacterActorComponent characterActorComponent2 = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
				int id = entityHandle.Id;
				if (characterActorComponent2 != null && this.RoleVolumeMap.ContainsKey(id))
				{
					RoleVolumeInfo roleVolumeInfo = this.RoleVolumeMap[id];
					RoleModel instance = ModelBase<RoleModel>.Instance;
					double value = (instance != null && instance.GetRoleBackgroundMusicEnabled(roleVolumeInfo.RoleId)) ? ((id == characterActorComponent.Entity.Id) ? 0.0 : Vector.DistSquared(characterActorComponent.ActorLocationProxy, characterActorComponent2.ActorLocationProxy)) : RoleAudioVolumeInfo.MaxDistanceSquared;
					roleVolumeInfo.UpdateDistSquared(value);
					if (eeventVolumePriority < roleVolumeInfo.Priority)
					{
						eeventVolumePriority = roleVolumeInfo.Priority;
						list.Clear();
						list.Add(id);
					}
					else if (eeventVolumePriority == roleVolumeInfo.Priority)
					{
						list.Add(id);
					}
				}
			}
			if (list.Count == 0 || eeventVolumePriority == EEventVolumePriority.Mute)
			{
				this.CurrentPlayEntityId = 0;
			}
			else if (list.Count == 1)
			{
				this.CurrentPlayEntityId = list[0];
			}
			else if (list.Count > 1)
			{
				this.TempQueue.Clear();
				foreach (int key in list)
				{
					this.TempQueue.Push(this.RoleVolumeMap[key]);
				}
				RoleVolumeInfo top = this.TempQueue.Top;
				this.CurrentPlayEntityId = ((top != null) ? top.EntityId : 0);
			}
			if (this.LastPlayEntityId == this.CurrentPlayEntityId)
			{
				return;
			}
			foreach (KeyValuePair<int, RoleVolumeInfo> keyValuePair in this.RoleVolumeMap)
			{
				keyValuePair.Value.SetPlayEvent(keyValuePair.Key == this.CurrentPlayEntityId);
			}
			this.LastPlayEntityId = this.CurrentPlayEntityId;
		}

		// Token: 0x0603F045 RID: 258117 RVA: 0x01028678 File Offset: 0x01026878
		public void MaintainCurrentList()
		{
			this.TeamEntityIdList.Clear();
			foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
			{
				WorldEntity entity = entityHandle.Entity;
				CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent != null)
				{
					this.TeamEntityIdList.Add(characterActorComponent.Entity.Id);
				}
			}
		}

		// Token: 0x0603F046 RID: 258118 RVA: 0x01028700 File Offset: 0x01026900
		public void MaintainMapData()
		{
			if (this.RoleVolumeMap.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (int item in this.RoleVolumeMap.Keys)
			{
				if (!this.TeamEntityIdList.Contains(item))
				{
					list.Add(item);
				}
			}
			foreach (int key in list)
			{
				this.RoleVolumeMap.Remove(key);
			}
		}

		// Token: 0x0603F047 RID: 258119 RVA: 0x010287C0 File Offset: 0x010269C0
		public void AddEvent(int entityId, int roleId, int handle, string eventName, AActor owner)
		{
			EventVolumeInfo info = new EventVolumeInfo(handle, eventName, owner);
			this.GetRoleVolumeInfo(entityId, roleId).AddEvent(handle, info);
			this.UpdateVolume();
		}

		// Token: 0x0603F048 RID: 258120 RVA: 0x010287F0 File Offset: 0x010269F0
		public void RemoveEvent(int entityId, int handle)
		{
			if (this.RoleVolumeMap.ContainsKey(entityId))
			{
				this.RoleVolumeMap[entityId].RemoveEvent(handle);
			}
			if (this.RoleVolumeMap.ContainsKey(entityId) && this.RoleVolumeMap[entityId].Empty())
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					if (!this.RoleVolumeMap.ContainsKey(entityId))
					{
						return;
					}
					if (this.RoleVolumeMap[entityId].Empty())
					{
						this.RoleVolumeMap.Remove(entityId);
						if (this.CurrentPlayEntityId == entityId)
						{
							this.LastPlayEntityId = -1;
						}
					}
				}, (float)RoleAudioVolumeInfo.DelayTime, null, null, true, 1f);
			}
		}

		// Token: 0x0603F049 RID: 258121 RVA: 0x0102888B File Offset: 0x01026A8B
		private RoleVolumeInfo GetRoleVolumeInfo(int entityId, int roleId)
		{
			if (!this.RoleVolumeMap.ContainsKey(entityId))
			{
				this.RoleVolumeMap[entityId] = new RoleVolumeInfo(roleId, entityId);
			}
			return this.RoleVolumeMap[entityId];
		}

		// Token: 0x0603F04A RID: 258122 RVA: 0x010288BC File Offset: 0x01026ABC
		public bool Empty()
		{
			if (this.RoleVolumeMap.Count == 0)
			{
				return true;
			}
			foreach (KeyValuePair<int, RoleVolumeInfo> keyValuePair in this.RoleVolumeMap)
			{
				if (!keyValuePair.Value.Empty())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603F04B RID: 258123 RVA: 0x0102892C File Offset: 0x01026B2C
		public RoleVolumeMapInfo()
		{
			Comparison<RoleVolumeInfo> compare;
			if ((compare = RoleVolumeMapInfo.<>O.<0>__Compare) == null)
			{
				compare = (RoleVolumeMapInfo.<>O.<0>__Compare = new Comparison<RoleVolumeInfo>(RoleVolumeInfo.Compare));
			}
			this.TempQueue = new PriorityQueue<RoleVolumeInfo>(compare);
			base..ctor();
		}

		// Token: 0x040235BB RID: 144827
		public List<int> TeamEntityIdList = new List<int>();

		// Token: 0x040235BC RID: 144828
		public Dictionary<int, RoleVolumeInfo> RoleVolumeMap = new Dictionary<int, RoleVolumeInfo>();

		// Token: 0x040235BD RID: 144829
		public int CurrentPlayEntityId;

		// Token: 0x040235BE RID: 144830
		public int LastPlayEntityId = -1;

		// Token: 0x040235BF RID: 144831
		private readonly PriorityQueue<RoleVolumeInfo> TempQueue;

		// Token: 0x0200C2ED RID: 49901
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403C184 RID: 246148
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<RoleVolumeInfo> <0>__Compare;
		}
	}
}
