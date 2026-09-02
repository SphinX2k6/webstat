using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048C5 RID: 18629
	[NullableContext(2)]
	[Nullable(0)]
	public class LockComponent : EntityComponent
	{
		// Token: 0x06030941 RID: 198977 RVA: 0x00BF196C File Offset: 0x00BEFB6C
		protected override bool OnStart()
		{
			this.LevelTagComponent = base.Entity.GetComponent<LevelTagComponent>();
			this.CreatureDataComponent = base.Entity.GetComponent<CreatureDataComponent>();
			EntranceState? entityEnterComponentState = this.CreatureDataComponent.GetEntityEnterComponentState();
			if (entityEnterComponentState != null)
			{
				if (entityEnterComponentState != null)
				{
					switch (entityEnterComponentState.GetValueOrDefault())
					{
					case EntranceState.NotUnlock:
						this.CurLockTagId = GameplayTagDefine.EGameplayTagId["物体.物体阶段.不可解锁"];
						goto IL_B6;
					case EntranceState.Unlockable:
						this.CurLockTagId = GameplayTagDefine.EGameplayTagId["物体.物体阶段.可解锁"];
						goto IL_B6;
					case EntranceState.Unlocked:
						this.CurLockTagId = GameplayTagDefine.EGameplayTagId["物体.物体阶段.已解锁"];
						goto IL_B6;
					}
				}
				this.CurLockTagId = GameplayTagDefine.EGameplayTagId["物体.物体阶段.不可解锁"];
			}
			IL_B6:
			if (this.CurLockTagId == 0)
			{
				this.CurLockTagId = GameplayTagDefine.EGameplayTagId["物体.物体阶段.不可解锁"];
			}
			this.LevelTagComponent.AddTag(new int?(this.CurLockTagId));
			return true;
		}

		// Token: 0x06030942 RID: 198978 RVA: 0x00BF1A64 File Offset: 0x00BEFC64
		public void ChangeLockTag(int tagId)
		{
			int curLockTagId = this.CurLockTagId;
			this.CurLockTagId = tagId;
			this.LevelTagComponent.ChangeLocalLevelTag(this.CurLockTagId, curLockTagId);
		}

		// Token: 0x06030943 RID: 198979 RVA: 0x00BF1A94 File Offset: 0x00BEFC94
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			LockComponent lockComponent = (LockComponent)componentTemplate;
			if (base.CanResetComponentProperty("LevelTagComponent"))
			{
				if (lockComponent.LevelTagComponent == null)
				{
					this.LevelTagComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<LevelTagComponent>(this.LevelTagComponent), "LevelTagComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComponent"))
			{
				if (lockComponent.CreatureDataComponent == null)
				{
					this.CreatureDataComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurLockTagId"))
			{
				this.CurLockTagId = lockComponent.CurLockTagId;
			}
			return true;
		}

		// Token: 0x0401BEA0 RID: 114336
		private LevelTagComponent LevelTagComponent;

		// Token: 0x0401BEA1 RID: 114337
		private CreatureDataComponent CreatureDataComponent;

		// Token: 0x0401BEA2 RID: 114338
		private int CurLockTagId;
	}
}
