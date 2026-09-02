using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.NewWorld.SceneItem.Controller
{
	// Token: 0x02004879 RID: 18553
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SlashGameplayController : ControllerBase<SlashGameplayController>
	{
		// Token: 0x0603045A RID: 197722 RVA: 0x00BBFC95 File Offset: 0x00BBDE95
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<Entity, bool>(EEventName.OnEntityBeSlashAim, new Action<Entity, bool>(this.OnEntityBeSlashAim));
			return true;
		}

		// Token: 0x0603045B RID: 197723 RVA: 0x00BBFCB4 File Offset: 0x00BBDEB4
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove<Entity, bool>(EEventName.OnEntityBeSlashAim, new Action<Entity, bool>(this.OnEntityBeSlashAim));
			this.SameGroupEntitiesArray.Clear();
			this.BeAimEntities.Clear();
			this.PendingAimEntities.Clear();
			return true;
		}

		// Token: 0x0603045C RID: 197724 RVA: 0x00BBFCF4 File Offset: 0x00BBDEF4
		private void OnEntityBeSlashAim(Entity entity, bool isExist)
		{
			bool flag = false;
			using (HashSet<HashSet<Entity>>.Enumerator enumerator = this.SameGroupEntitiesArray.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Contains(entity))
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				if (component == null || !component.GetRemoveState())
				{
					this.PendingAimEntities.Add(entity);
					return;
				}
			}
			if (isExist)
			{
				this.BeAimEntities.Add(entity);
				return;
			}
			this.BeAimEntities.Remove(entity);
		}

		// Token: 0x0603045D RID: 197725 RVA: 0x00BBFD94 File Offset: 0x00BBDF94
		public bool CheckGroups()
		{
			if (this.BeAimEntities.Count == 0)
			{
				return true;
			}
			foreach (HashSet<Entity> hashSet in this.SameGroupEntitiesArray)
			{
				bool flag = true;
				foreach (Entity item in hashSet)
				{
					if (!this.BeAimEntities.Contains(item))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603045E RID: 197726 RVA: 0x00BBFE44 File Offset: 0x00BBE044
		public void AddGroupEntities(HashSet<Entity> entities)
		{
			this.SameGroupEntitiesArray.Add(entities);
			HashSet<Entity> hashSet = new HashSet<Entity>();
			foreach (Entity item in this.PendingAimEntities)
			{
				if (entities.Contains(item))
				{
					this.BeAimEntities.Add(item);
					hashSet.Add(item);
				}
			}
			foreach (Entity item2 in hashSet)
			{
				this.PendingAimEntities.Remove(item2);
			}
		}

		// Token: 0x0603045F RID: 197727 RVA: 0x00BBFF04 File Offset: 0x00BBE104
		public void RemoveGroupEntities(HashSet<Entity> entities)
		{
			this.SameGroupEntitiesArray.Remove(entities);
		}

		// Token: 0x0401BB89 RID: 113545
		private readonly HashSet<HashSet<Entity>> SameGroupEntitiesArray = new HashSet<HashSet<Entity>>();

		// Token: 0x0401BB8A RID: 113546
		private readonly HashSet<Entity> BeAimEntities = new HashSet<Entity>();

		// Token: 0x0401BB8B RID: 113547
		private readonly HashSet<Entity> PendingAimEntities = new HashSet<Entity>();
	}
}
