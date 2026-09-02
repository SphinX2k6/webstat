using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Pawn.SensoryInfo
{
	// Token: 0x020048A2 RID: 18594
	[NullableContext(1)]
	[Nullable(0)]
	public class ConnectNearbySensory : BaseSensoryInfo
	{
		// Token: 0x170082A2 RID: 33442
		// (get) Token: 0x0603072B RID: 198443 RVA: 0x00BE05B0 File Offset: 0x00BDE7B0
		public override ERangePerceptionType RangePerceptionType
		{
			get
			{
				return ERangePerceptionType.Dynamic;
			}
		}

		// Token: 0x0603072C RID: 198444 RVA: 0x00BE05B3 File Offset: 0x00BDE7B3
		protected override void OnInit(params object[] @params)
		{
			this.SensoryRange = Convert.ToDouble(@params[0]);
		}

		// Token: 0x0603072D RID: 198445 RVA: 0x00BE05C3 File Offset: 0x00BDE7C3
		protected override void OnClear()
		{
			this.LastFindEntities.Clear();
			this.CacheEntityList.Clear();
			this.OnEnterSensoryRange = null;
			this.OnExitSensoryRange = null;
		}

		// Token: 0x0603072E RID: 198446 RVA: 0x00BE05E9 File Offset: 0x00BDE7E9
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x0603072F RID: 198447 RVA: 0x00BE05EB File Offset: 0x00BDE7EB
		public override bool CheckEntity(Entity entity)
		{
			return true;
		}

		// Token: 0x06030730 RID: 198448 RVA: 0x00BE05F0 File Offset: 0x00BDE7F0
		public override void EnterRange(Entity entity)
		{
			this.InRange = true;
			if (!this.LastFindEntities.Contains(entity.Id) && this.OnEnterSensoryRange != null && !this.OnEnterSensoryRange(entity))
			{
				return;
			}
			this.CacheEntityList.Add(entity.Id);
			this.LastFindEntities.Remove(entity.Id);
		}

		// Token: 0x06030731 RID: 198449 RVA: 0x00BE0654 File Offset: 0x00BDE854
		public override void ExitRange()
		{
			this.InRange = (this.CacheEntityList.Count != 0);
			foreach (int num in this.LastFindEntities)
			{
				Action<int> onExitSensoryRange = this.OnExitSensoryRange;
				if (onExitSensoryRange != null)
				{
					onExitSensoryRange(num);
				}
				this.CacheEntityList.Remove(num);
			}
			this.LastFindEntities.Clear();
			foreach (int item in this.CacheEntityList)
			{
				this.LastFindEntities.Add(item);
			}
		}

		// Token: 0x06030732 RID: 198450 RVA: 0x00BE0728 File Offset: 0x00BDE928
		public void OnEntityExitConnectRange(int entityId)
		{
			this.LastFindEntities.Remove(entityId);
			this.CacheEntityList.Remove(entityId);
		}

		// Token: 0x0401BD47 RID: 113991
		protected readonly HashSet<int> CacheEntityList = new HashSet<int>();

		// Token: 0x0401BD48 RID: 113992
		protected readonly HashSet<int> LastFindEntities = new HashSet<int>();

		// Token: 0x0401BD49 RID: 113993
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<Entity, bool> OnEnterSensoryRange;

		// Token: 0x0401BD4A RID: 113994
		[Nullable(2)]
		public Action<int> OnExitSensoryRange;
	}
}
