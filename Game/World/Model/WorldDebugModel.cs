using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.World.Model
{
	// Token: 0x020046D7 RID: 18135
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WorldDebugModel : ModelBase<WorldDebugModel>
	{
		// Token: 0x1700811C RID: 33052
		// (get) Token: 0x0602F294 RID: 193172 RVA: 0x00B2C8A6 File Offset: 0x00B2AAA6
		// (set) Token: 0x0602F295 RID: 193173 RVA: 0x00B2C8AE File Offset: 0x00B2AAAE
		public bool EnableDebug
		{
			get
			{
				return this.EnableDebugInternal;
			}
			set
			{
				this.EnableDebugInternal = value;
			}
		}

		// Token: 0x0602F296 RID: 193174 RVA: 0x00B2C8B7 File Offset: 0x00B2AAB7
		public void AddSummonEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiSummonSet.Add(entity);
			this.AoiTotalSet.Add(entity);
		}

		// Token: 0x0602F297 RID: 193175 RVA: 0x00B2C8DC File Offset: 0x00B2AADC
		public void AddVisionEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiVisionSet.Add(entity);
			this.AoiTotalSet.Add(entity);
		}

		// Token: 0x0602F298 RID: 193176 RVA: 0x00B2C901 File Offset: 0x00B2AB01
		public void AddMonsterEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiMonsterSet.Add(entity);
			this.AoiTotalSet.Add(entity);
		}

		// Token: 0x0602F299 RID: 193177 RVA: 0x00B2C926 File Offset: 0x00B2AB26
		public void AddNpcEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiNpcSet.Add(entity);
			this.AoiTotalSet.Add(entity);
		}

		// Token: 0x0602F29A RID: 193178 RVA: 0x00B2C94B File Offset: 0x00B2AB4B
		public void AddRoleEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiRoleSet.Add(entity);
			this.AoiTotalSet.Add(entity);
		}

		// Token: 0x0602F29B RID: 193179 RVA: 0x00B2C970 File Offset: 0x00B2AB70
		public void RemoveSummonEntity(EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			this.AoiSummonSet.Remove(entity);
			this.AoiTotalSet.Remove(entity);
		}

		// Token: 0x0602F29C RID: 193180 RVA: 0x00B2C998 File Offset: 0x00B2AB98
		public void AddEntity(EEntityType entityType, EntityHandle entity)
		{
			if (!entity)
			{
				return;
			}
			switch (entityType)
			{
			case EEntityType.Player:
				this.AddRoleEntity(entity);
				return;
			case EEntityType.Npc:
				this.AddNpcEntity(entity);
				return;
			case EEntityType.Monster:
				this.AddMonsterEntity(entity);
				return;
			default:
				if (entityType != EEntityType.Vision)
				{
					return;
				}
				this.AddVisionEntity(entity);
				return;
			}
		}

		// Token: 0x0602F29D RID: 193181 RVA: 0x00B2C9E4 File Offset: 0x00B2ABE4
		public void RemoveEntity(EEntityType entityType, EntityHandle handle)
		{
			if (!handle)
			{
				return;
			}
			switch (entityType)
			{
			case EEntityType.Player:
				this.AoiRoleSet.Remove(handle);
				this.AoiTotalSet.Remove(handle);
				return;
			case EEntityType.Npc:
				this.AoiNpcSet.Remove(handle);
				this.AoiTotalSet.Remove(handle);
				return;
			case EEntityType.Monster:
				this.AoiMonsterSet.Remove(handle);
				this.AoiTotalSet.Remove(handle);
				return;
			default:
				if (entityType != EEntityType.Vision)
				{
					return;
				}
				this.AoiVisionSet.Remove(handle);
				this.AoiTotalSet.Remove(handle);
				return;
			}
		}

		// Token: 0x0602F29E RID: 193182 RVA: 0x00B2CA7C File Offset: 0x00B2AC7C
		protected override bool OnLeaveLevel()
		{
			if (!UKuroStaticLibrary.IsEditor(GlobalData.World))
			{
				return true;
			}
			if (!this.EnableDebug)
			{
				return true;
			}
			this.AoiTotalSet.Clear();
			this.AoiSummonSet.Clear();
			this.AoiVisionSet.Clear();
			this.AoiMonsterSet.Clear();
			this.AoiNpcSet.Clear();
			this.AoiRoleSet.Clear();
			return true;
		}

		// Token: 0x0401ADC8 RID: 110024
		public const int FIGHTING_AOI_WEAPON_MAX_COUNT = 4;

		// Token: 0x0401ADC9 RID: 110025
		public const int FIGHTING_AOI_ROLE_MAX_COUNT = 4;

		// Token: 0x0401ADCA RID: 110026
		public const int FIGHTING_AOI_SUMMON_MAX_COUNT = 4;

		// Token: 0x0401ADCB RID: 110027
		public const int FIGHTING_AOI_VISION_MAX_COUNT = 4;

		// Token: 0x0401ADCC RID: 110028
		public const int FIGHTING_AOI_NPC_MONSTER_MAX_COUNT = 50;

		// Token: 0x0401ADCD RID: 110029
		public const int FIGHTING_TOTAL_MAX_COUINT = 97;

		// Token: 0x0401ADCE RID: 110030
		public const int AOI_WEAPON_MAX_COUNT = 6;

		// Token: 0x0401ADCF RID: 110031
		public const int AOI_ROLE_MAX_COUNT = 4;

		// Token: 0x0401ADD0 RID: 110032
		public const int AOI_SUMMON_MAX_COUNT = 4;

		// Token: 0x0401ADD1 RID: 110033
		public const int AOI_VISION_MAX_COUNT = 4;

		// Token: 0x0401ADD2 RID: 110034
		public const int AOI_NPC_MONSTER_MAX_COUNT = 50;

		// Token: 0x0401ADD3 RID: 110035
		public const int TOTAL_MAX_COUINT = 95;

		// Token: 0x0401ADD4 RID: 110036
		private bool EnableDebugInternal = true;

		// Token: 0x0401ADD5 RID: 110037
		public readonly HashSet<EntityHandle> AoiTotalSet = new HashSet<EntityHandle>();

		// Token: 0x0401ADD6 RID: 110038
		public readonly HashSet<EntityHandle> AoiSummonSet = new HashSet<EntityHandle>();

		// Token: 0x0401ADD7 RID: 110039
		public readonly HashSet<EntityHandle> AoiVisionSet = new HashSet<EntityHandle>();

		// Token: 0x0401ADD8 RID: 110040
		public readonly HashSet<EntityHandle> AoiMonsterSet = new HashSet<EntityHandle>();

		// Token: 0x0401ADD9 RID: 110041
		public readonly HashSet<EntityHandle> AoiNpcSet = new HashSet<EntityHandle>();

		// Token: 0x0401ADDA RID: 110042
		public readonly HashSet<EntityHandle> AoiRoleSet = new HashSet<EntityHandle>();
	}
}
