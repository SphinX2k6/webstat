using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.NewWorld.Pawn.Controllers;

namespace CSharpScript.Game.NewWorld.Pawn.SensoryInfo
{
	// Token: 0x020048A3 RID: 18595
	[NullableContext(1)]
	[Nullable(0)]
	public class MonsterNearbySensory : BaseSensoryInfo
	{
		// Token: 0x170082A3 RID: 33443
		// (get) Token: 0x06030734 RID: 198452 RVA: 0x00BE0762 File Offset: 0x00BDE962
		public override ESensoryInfoType SensoryInfoType
		{
			get
			{
				return ESensoryInfoType.EnterAndExit;
			}
		}

		// Token: 0x06030735 RID: 198453 RVA: 0x00BE0765 File Offset: 0x00BDE965
		protected override void OnInit(params object[] @params)
		{
			this.SensoryRange = (double)((float)@params[0]);
		}

		// Token: 0x06030736 RID: 198454 RVA: 0x00BE0776 File Offset: 0x00BDE976
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x06030737 RID: 198455 RVA: 0x00BE0778 File Offset: 0x00BDE978
		protected override void OnClear()
		{
			this.LastFindEntities.Clear();
			this.CacheEntityList.Clear();
			this.OnEnterSensoryRange = null;
			this.OnExitSensoryRange = null;
		}

		// Token: 0x06030738 RID: 198456 RVA: 0x00BE079E File Offset: 0x00BDE99E
		public override void ClearCacheList()
		{
			this.CacheEntityList.Clear();
		}

		// Token: 0x06030739 RID: 198457 RVA: 0x00BE07AC File Offset: 0x00BDE9AC
		public override bool CheckEntity(Entity entity)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			return component != null && component.IsMonster() && MonsterNearbySensory.MonsterCamp.Contains(component.GetEntityCamp());
		}

		// Token: 0x0603073A RID: 198458 RVA: 0x00BE07E0 File Offset: 0x00BDE9E0
		public override void EnterRange(Entity entity)
		{
			this.InRange = true;
			if (!this.LastFindEntities.Contains(entity.Id) && (this.SensoryInfoType & ESensoryInfoType.EnterAndExit) != (ESensoryInfoType)0 && this.OnEnterSensoryRange != null && !this.OnEnterSensoryRange(entity))
			{
				return;
			}
			this.CacheEntityList.Add(entity.Id);
			this.LastFindEntities.Remove(entity.Id);
		}

		// Token: 0x0603073B RID: 198459 RVA: 0x00BE084C File Offset: 0x00BDEA4C
		public override void ExitRange()
		{
			this.InRange = (this.CacheEntityList.Count != 0);
			if ((this.SensoryInfoType & ESensoryInfoType.EnterAndExit) != (ESensoryInfoType)0)
			{
				foreach (int obj in this.LastFindEntities)
				{
					Action<int> onExitSensoryRange = this.OnExitSensoryRange;
					if (onExitSensoryRange != null)
					{
						onExitSensoryRange(obj);
					}
				}
			}
			this.LastFindEntities.Clear();
			foreach (int item in this.CacheEntityList)
			{
				this.LastFindEntities.Add(item);
			}
		}

		// Token: 0x0401BD4B RID: 113995
		[StaticVariableRuleIgnore]
		private static readonly HashSet<ECamp> MonsterCamp = new HashSet<ECamp>
		{
			ECamp.Monster,
			ECamp.liufangzhe_e,
			ECamp.Common_enemy
		};

		// Token: 0x0401BD4C RID: 113996
		protected readonly List<int> CacheEntityList = new List<int>();

		// Token: 0x0401BD4D RID: 113997
		protected readonly HashSet<int> LastFindEntities = new HashSet<int>();

		// Token: 0x0401BD4E RID: 113998
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<Entity, bool> OnEnterSensoryRange;

		// Token: 0x0401BD4F RID: 113999
		[Nullable(2)]
		public Action<int> OnExitSensoryRange;
	}
}
