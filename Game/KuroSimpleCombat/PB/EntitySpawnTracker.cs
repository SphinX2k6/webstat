using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC4 RID: 28612
	[NullableContext(1)]
	[Nullable(0)]
	public class EntitySpawnTracker
	{
		// Token: 0x06045352 RID: 283474 RVA: 0x01211FD3 File Offset: 0x012101D3
		public void Add(int creatureId)
		{
			if (!this.IsServerDataAllReceived)
			{
				this.PendingCreatureIds.Add(creatureId);
			}
		}

		// Token: 0x06045353 RID: 283475 RVA: 0x01211FEA File Offset: 0x012101EA
		[NullableContext(2)]
		public void Complete(int creatureId, AKSC_Entity entity = null)
		{
			if (entity != null)
			{
				this.SpawnedEntities.Add(entity);
			}
			this.PendingCreatureIds.Remove(creatureId);
			this.TryTrigger();
		}

		// Token: 0x06045354 RID: 283476 RVA: 0x0121200E File Offset: 0x0121020E
		public void MarkServerDone()
		{
			this.IsServerDataAllReceived = true;
			this.TryTrigger();
		}

		// Token: 0x06045355 RID: 283477 RVA: 0x0121201D File Offset: 0x0121021D
		private void TryTrigger()
		{
			if (this.IsServerDataAllReceived && this.PendingCreatureIds.Count == 0)
			{
				Action onAllSpawned = this.OnAllSpawned;
				if (onAllSpawned != null)
				{
					onAllSpawned();
				}
				this.Reset();
			}
		}

		// Token: 0x06045356 RID: 283478 RVA: 0x0121204B File Offset: 0x0121024B
		public void Reset()
		{
			this.IsServerDataAllReceived = false;
			this.PendingCreatureIds.Clear();
			this.SpawnedEntities.Clear();
		}

		// Token: 0x040269C9 RID: 158153
		private readonly HashSet<int> PendingCreatureIds = new HashSet<int>();

		// Token: 0x040269CA RID: 158154
		public readonly List<AKSC_Entity> SpawnedEntities = new List<AKSC_Entity>();

		// Token: 0x040269CB RID: 158155
		private bool IsServerDataAllReceived;

		// Token: 0x040269CC RID: 158156
		[Nullable(2)]
		public Action OnAllSpawned;
	}
}
