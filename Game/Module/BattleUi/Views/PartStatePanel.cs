using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608D RID: 24717
	[NullableContext(1)]
	[Nullable(0)]
	public class PartStatePanel
	{
		// Token: 0x0603E5CB RID: 255435 RVA: 0x00FED452 File Offset: 0x00FEB652
		public void InitializePartStatePanel()
		{
			this.AddEvents();
			this.InitializeExistingEntities();
		}

		// Token: 0x0603E5CC RID: 255436 RVA: 0x00FED460 File Offset: 0x00FEB660
		private void InitializeExistingEntities()
		{
			IReadOnlyList<EntityHandle> allEntities = ModelBase<CreatureModel>.Instance.GetAllEntities();
			if (allEntities == null)
			{
				return;
			}
			foreach (EntityHandle entityHandle in allEntities)
			{
				if (entityHandle.IsInit)
				{
					this.OnCreateEntity(entityHandle.Entity);
				}
			}
		}

		// Token: 0x0603E5CD RID: 255437 RVA: 0x00FED4C4 File Offset: 0x00FEB6C4
		public void ResetPartStatePanel()
		{
			this.DestroyAllParStates();
			this.RemoveEvents();
		}

		// Token: 0x0603E5CE RID: 255438 RVA: 0x00FED4D2 File Offset: 0x00FEB6D2
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSetPartStateVisible, new Action<int, FName?, bool>(this.OnSetPartStateVisible));
		}

		// Token: 0x0603E5CF RID: 255439 RVA: 0x00FED4F0 File Offset: 0x00FEB6F0
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSetPartStateVisible, new Action<int, FName?, bool>(this.OnSetPartStateVisible));
		}

		// Token: 0x0603E5D0 RID: 255440 RVA: 0x00FED510 File Offset: 0x00FEB710
		private void OnSetPartStateVisible(int entityId, FName? boneName, bool bVisible)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (FNameUtil.IsNothing(boneName))
			{
				if (entity == null)
				{
					return;
				}
				if (bVisible)
				{
					this.ActivatePartStateByRole(entity);
					return;
				}
				this.DestroyPartStateFromRole(entity);
				return;
			}
			else
			{
				if (entity == null)
				{
					return;
				}
				CharacterPart[] parts = entity.GetComponent<CharacterPartComponent>().Parts;
				if (parts.Length == 0)
				{
					return;
				}
				foreach (CharacterPart characterPart in parts)
				{
					if (!(characterPart.BoneName.Value != boneName))
					{
						if (bVisible)
						{
							this.ActivatePartState(entity, characterPart);
						}
						else
						{
							int index = characterPart.Index;
							this.DestroyPartState(entityId, index);
						}
					}
				}
				return;
			}
		}

		// Token: 0x0603E5D1 RID: 255441 RVA: 0x00FED5C0 File Offset: 0x00FEB7C0
		public void OnCreateEntity(Entity entity)
		{
			if (entity == null)
			{
				return;
			}
			CharacterPartComponent component = entity.GetComponent<CharacterPartComponent>();
			if (component == null)
			{
				return;
			}
			CharacterPart[] parts = component.Parts;
			if (parts == null)
			{
				return;
			}
			if (parts.Length == 0)
			{
				return;
			}
			USkeletalMeshComponent mesh = (entity.GetComponent<BaseActorComponent>().Owner as TsBaseCharacter).Mesh;
			foreach (CharacterPart characterPart in parts)
			{
				if (characterPart.IsPartStateVisible)
				{
					FName value = characterPart.PartSocketName.Value;
					if (!mesh.DoesSocketExist(value))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Battle;
						ELogAuthor author = ELogAuthor.CFT;
						string message = "[BattleView]激活部位血条时找不到部位插槽:";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SocketName", value);
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					else
					{
						this.ActivatePartState(entity, characterPart);
					}
				}
			}
		}

		// Token: 0x0603E5D2 RID: 255442 RVA: 0x00FED678 File Offset: 0x00FEB878
		[NullableContext(2)]
		public void ActivatePartStateByRole(Entity entity)
		{
			if (entity == null)
			{
				return;
			}
			CharacterPart[] parts = entity.GetComponent<CharacterPartComponent>().Parts;
			if (parts.Length == 0)
			{
				return;
			}
			foreach (CharacterPart partInfo in parts)
			{
				this.ActivatePartState(entity, partInfo);
			}
		}

		// Token: 0x0603E5D3 RID: 255443 RVA: 0x00FED6B8 File Offset: 0x00FEB8B8
		public void ActivatePartState(Entity entity, CharacterPart partInfo)
		{
			PartState partState = this.GetPartState(entity.Id, partInfo.Index);
			if (partState != null)
			{
				partState.InitializePartState(entity, partInfo);
				return;
			}
			this.NewPartState(entity, partInfo);
		}

		// Token: 0x0603E5D4 RID: 255444 RVA: 0x00FED6F0 File Offset: 0x00FEB8F0
		public void DestroyAllParStates()
		{
			foreach (Dictionary<int, PartState> dictionary in this.PartStateGroupMap.Values)
			{
				foreach (PartState partState in dictionary.Values)
				{
					partState.Destroy(null);
				}
			}
			this.PartStateGroupMap.Clear();
		}

		// Token: 0x0603E5D5 RID: 255445 RVA: 0x00FED78C File Offset: 0x00FEB98C
		public void DestroyPartStateFromRole(Entity entity)
		{
			int id = entity.Id;
			IReadOnlyDictionary<int, PartState> allPartStates = this.GetAllPartStates(id);
			if (allPartStates == null)
			{
				return;
			}
			foreach (PartState partState in allPartStates.Values)
			{
				partState.Destroy(null);
			}
			this.PartStateGroupMap[id].Clear();
		}

		// Token: 0x0603E5D6 RID: 255446 RVA: 0x00FED7FC File Offset: 0x00FEB9FC
		public void DestroyPartState(int entityId, int partIndex)
		{
			PartState partState = this.GetPartState(entityId, partIndex);
			if (partState == null)
			{
				return;
			}
			partState.Destroy(null);
			Dictionary<int, PartState> dictionary;
			if (this.PartStateGroupMap.TryGetValue(entityId, out dictionary))
			{
				dictionary.Remove(partIndex);
			}
		}

		// Token: 0x0603E5D7 RID: 255447 RVA: 0x00FED838 File Offset: 0x00FEBA38
		public void Tick(float delta)
		{
			foreach (Dictionary<int, PartState> dictionary in this.PartStateGroupMap.Values)
			{
				foreach (PartState partState in dictionary.Values)
				{
					partState.Tick(delta);
				}
			}
		}

		// Token: 0x0603E5D8 RID: 255448 RVA: 0x00FED8C8 File Offset: 0x00FEBAC8
		private PartState NewPartState(Entity entity, CharacterPart partInfo)
		{
			int id = entity.Id;
			PartState partState = new PartState(entity, partInfo);
			Dictionary<int, PartState> dictionary;
			if (!this.PartStateGroupMap.TryGetValue(id, out dictionary))
			{
				dictionary = new Dictionary<int, PartState>();
				this.PartStateGroupMap.Add(id, dictionary);
			}
			dictionary[partInfo.Index] = partState;
			return partState;
		}

		// Token: 0x0603E5D9 RID: 255449 RVA: 0x00FED918 File Offset: 0x00FEBB18
		[NullableContext(2)]
		public PartState GetPartState(int entityId, int partIndex)
		{
			Dictionary<int, PartState> dictionary;
			if (!this.PartStateGroupMap.TryGetValue(entityId, out dictionary))
			{
				return null;
			}
			return dictionary.GetValueOrDefault(partIndex);
		}

		// Token: 0x0603E5DA RID: 255450 RVA: 0x00FED93E File Offset: 0x00FEBB3E
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyDictionary<int, PartState> GetAllPartStates(int entityId)
		{
			return this.PartStateGroupMap.GetValueOrDefault(entityId);
		}

		// Token: 0x04022F3D RID: 143165
		private readonly Dictionary<int, Dictionary<int, PartState>> PartStateGroupMap = new Dictionary<int, Dictionary<int, PartState>>();

		// Token: 0x04022F3E RID: 143166
		[StaticVariableRuleIgnore]
		private static readonly Stat BattleViewTickStatsObject = Stat.Create("[BattleView]PartStatePanelTick", "", "");
	}
}
