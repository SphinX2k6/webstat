using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Module.MonsterGroup;

namespace CSharpScript.Game.NewWorld.Character.Monster.Controller
{
	// Token: 0x020048DC RID: 18652
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class MonsterGroupEcologyController : ControllerBase<MonsterGroupEcologyController>
	{
		// Token: 0x06030A9D RID: 199325 RVA: 0x00BFE323 File Offset: 0x00BFC523
		protected override bool OnClear()
		{
			this.PendingEcologyGroups.Clear();
			this.EntityIdToGroupId.Clear();
			return true;
		}

		// Token: 0x06030A9E RID: 199326 RVA: 0x00BFE33C File Offset: 0x00BFC53C
		protected override void OnTick(float delta)
		{
			this.DeltaTime += delta;
			if (this.DeltaTime < 1000f)
			{
				return;
			}
			this.DeltaTime = 0f;
			this.TryGenerateAllPendingGroups();
			MonsterGroupEcologyModel instance = ModelBase<MonsterGroupEcologyModel>.Instance;
			Dictionary<int, MonsterGroupEcologyInfo> dictionary = (instance != null) ? instance.EcologyGroups : null;
			if (dictionary == null || dictionary.Count == 0)
			{
				return;
			}
			List<int> list = null;
			foreach (KeyValuePair<int, MonsterGroupEcologyInfo> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				MonsterGroupEcologyInfo value = keyValuePair.Value;
				value.CheckMembersValid();
				value.Tick();
				if (value.ShouldRemove())
				{
					if (list == null)
					{
						list = new List<int>();
					}
					list.Add(key);
				}
			}
			if (list != null)
			{
				foreach (int groupEntityId in list)
				{
					MonsterGroupEcologyModel instance2 = ModelBase<MonsterGroupEcologyModel>.Instance;
					if (instance2 != null)
					{
						instance2.RemoveEcologyGroup(groupEntityId);
					}
				}
			}
		}

		// Token: 0x06030A9F RID: 199327 RVA: 0x00BFE454 File Offset: 0x00BFC654
		private void TryGenerateAllPendingGroups()
		{
			if (this.PendingEcologyGroups.Count == 0)
			{
				return;
			}
			List<int> list = new List<int>(this.PendingEcologyGroups.Count);
			foreach (KeyValuePair<int, IPendingEcologyGroup> keyValuePair in this.PendingEcologyGroups)
			{
				list.Add(keyValuePair.Key);
			}
			foreach (int groupEntityId in list)
			{
				this.TryGeneratePendingGroup(groupEntityId);
			}
		}

		// Token: 0x06030AA0 RID: 199328 RVA: 0x00BFE50C File Offset: 0x00BFC70C
		private void TryGeneratePendingGroup(int groupEntityId)
		{
			MonsterGroupEcologyModel instance = ModelBase<MonsterGroupEcologyModel>.Instance;
			if (instance == null)
			{
				return;
			}
			IPendingEcologyGroup pendingEcologyGroup;
			if (!this.PendingEcologyGroups.TryGetValue(groupEntityId, out pendingEcologyGroup))
			{
				return;
			}
			MonsterGroupEcologyInfo ecologyGroup = instance.GetEcologyGroup(groupEntityId);
			if (ecologyGroup != null)
			{
				List<int> list = new List<int>();
				foreach (int num in pendingEcologyGroup.RegisteredPbDataIds)
				{
					if (!ecologyGroup.HasMemberByPbDataId(num) && !instance.TryAddMemberToEcologyGroup(groupEntityId, num))
					{
						list.Add(num);
					}
				}
				if (list.Count == 0)
				{
					this.PendingEcologyGroups.Remove(groupEntityId);
					return;
				}
				pendingEcologyGroup.RegisteredPbDataIds = new HashSet<int>(list);
				return;
			}
			else
			{
				int count = pendingEcologyGroup.GroupComp.Entities.Count;
				if (pendingEcologyGroup.RegisteredPbDataIds.Count < count)
				{
					return;
				}
				if (!instance.GenerateAddEcologyGroup(groupEntityId, pendingEcologyGroup.GroupComp, new List<int>(pendingEcologyGroup.RegisteredPbDataIds)))
				{
					return;
				}
				this.PendingEcologyGroups.Remove(groupEntityId);
				return;
			}
		}

		// Token: 0x06030AA1 RID: 199329 RVA: 0x00BFE614 File Offset: 0x00BFC814
		public unsafe void RegisterMonsterPbDataId(int groupEntityId, Entity entity, int pbDataId, GroupAiComponent groupComp)
		{
			if (ModelBase<MonsterGroupEcologyModel>.Instance == null)
			{
				return;
			}
			if (!groupComp.Entities.Contains(pbDataId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "[GroupAi.Ecology] 注册的PbDataId不在群组配置中";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("GroupEntityId", groupEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", pbDataId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.EntityIdToGroupId[entity.Id] = groupEntityId;
			IPendingEcologyGroup pendingEcologyGroup;
			if (!this.PendingEcologyGroups.TryGetValue(groupEntityId, out pendingEcologyGroup))
			{
				pendingEcologyGroup = new PendingEcologyGroup
				{
					GroupComp = groupComp,
					RegisteredPbDataIds = new HashSet<int>()
				};
				this.PendingEcologyGroups[groupEntityId] = pendingEcologyGroup;
			}
			if (pendingEcologyGroup.RegisteredPbDataIds.Contains(pbDataId))
			{
				return;
			}
			pendingEcologyGroup.RegisteredPbDataIds.Add(pbDataId);
			this.DeltaTime = 0f;
		}

		// Token: 0x06030AA2 RID: 199330 RVA: 0x00BFE708 File Offset: 0x00BFC908
		public void RemoveEntityFromMonsterGroup(int entityId, int pbDataId)
		{
			int num;
			if (!this.EntityIdToGroupId.TryGetValue(entityId, out num))
			{
				return;
			}
			this.EntityIdToGroupId.Remove(entityId);
			MonsterGroupEcologyModel instance = ModelBase<MonsterGroupEcologyModel>.Instance;
			if (instance != null)
			{
				instance.RemoveMemberOnEntityDestroyed(num, entityId);
			}
			IPendingEcologyGroup pendingEcologyGroup;
			if (this.PendingEcologyGroups.TryGetValue(num, out pendingEcologyGroup))
			{
				pendingEcologyGroup.RegisteredPbDataIds.Remove(pbDataId);
				if (pendingEcologyGroup.RegisteredPbDataIds.Count == 0)
				{
					this.PendingEcologyGroups.Remove(num);
				}
			}
		}

		// Token: 0x06030AA3 RID: 199331 RVA: 0x00BFE780 File Offset: 0x00BFC980
		public bool CheckEntityInMonsterGroup(int entityId)
		{
			int key;
			if (!this.EntityIdToGroupId.TryGetValue(entityId, out key))
			{
				return false;
			}
			MonsterGroupEcologyModel instance = ModelBase<MonsterGroupEcologyModel>.Instance;
			Dictionary<int, MonsterGroupEcologyInfo> dictionary = (instance != null) ? instance.EcologyGroups : null;
			MonsterGroupEcologyInfo monsterGroupEcologyInfo;
			return dictionary != null && dictionary.TryGetValue(key, out monsterGroupEcologyInfo) && monsterGroupEcologyInfo.GroupInfo.ContainsKey(entityId);
		}

		// Token: 0x06030AA4 RID: 199332 RVA: 0x00BFE7D0 File Offset: 0x00BFC9D0
		[NullableContext(2)]
		public MonsterEcologyInfo GetMonsterInfoByEntityId(int entityId)
		{
			int key;
			if (!this.EntityIdToGroupId.TryGetValue(entityId, out key))
			{
				return null;
			}
			MonsterGroupEcologyModel instance = ModelBase<MonsterGroupEcologyModel>.Instance;
			Dictionary<int, MonsterGroupEcologyInfo> dictionary = (instance != null) ? instance.EcologyGroups : null;
			if (dictionary == null)
			{
				return null;
			}
			MonsterGroupEcologyInfo monsterGroupEcologyInfo;
			if (!dictionary.TryGetValue(key, out monsterGroupEcologyInfo))
			{
				return null;
			}
			MonsterEcologyInfo result;
			monsterGroupEcologyInfo.GroupInfo.TryGetValue(entityId, out result);
			return result;
		}

		// Token: 0x0401BF89 RID: 114569
		private float DeltaTime;

		// Token: 0x0401BF8A RID: 114570
		private readonly Dictionary<int, IPendingEcologyGroup> PendingEcologyGroups = new Dictionary<int, IPendingEcologyGroup>();

		// Token: 0x0401BF8B RID: 114571
		private readonly Dictionary<int, int> EntityIdToGroupId = new Dictionary<int, int>();
	}
}
