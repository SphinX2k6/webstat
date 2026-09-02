using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200691E RID: 26910
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayCollisionMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042D2E RID: 273710 RVA: 0x01126CF5 File Offset: 0x01124EF5
		public DropCatchGameplayCollisionMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042D2F RID: 273711 RVA: 0x01126D14 File Offset: 0x01124F14
		public override void Init()
		{
			this.TmpCollisionList.Clear();
			this.CheckCollisionDropItemInstanceIds.Clear();
		}

		// Token: 0x06042D30 RID: 273712 RVA: 0x01126D2C File Offset: 0x01124F2C
		public override void OnTick(float deltaTime)
		{
			this.UpdateCollisions();
		}

		// Token: 0x06042D31 RID: 273713 RVA: 0x01126D34 File Offset: 0x01124F34
		private void UpdateCollisions()
		{
			IRoleInstance role = this.Context.GetGameplayRoleMgr().GetRole();
			if (role == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "Role is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			IDropCatchBounds bowlBounds = role.GetBowlBounds();
			IDropCatchBounds roleBounds = role.GetRoleBounds();
			this.TmpCollisionList.Clear();
			foreach (int num in this.CheckCollisionDropItemInstanceIds)
			{
				IDropItemInstance dropItem = this.Context.GetGameplayDropItemMgr().GetDropItem(num);
				if (dropItem != null)
				{
					IDropCatchBounds itemBounds = dropItem.GetItemBounds();
					if (this.CheckCollision(bowlBounds, itemBounds))
					{
						this.TmpCollisionList.Add(num);
					}
					else if (this.CheckCollision(roleBounds, itemBounds))
					{
						this.TmpCollisionList.Add(num);
					}
				}
			}
			foreach (int instanceId in this.TmpCollisionList)
			{
				IDropItemInstance dropItem2 = this.Context.GetGameplayDropItemMgr().GetDropItem(instanceId);
				if (dropItem2 != null)
				{
					dropItem2.OnCollision(role);
				}
			}
		}

		// Token: 0x06042D32 RID: 273714 RVA: 0x01126E80 File Offset: 0x01125080
		private bool CheckCollision(IDropCatchBounds collisionA, IDropCatchBounds collisionB)
		{
			return collisionA.Left <= collisionB.Right && collisionA.Right >= collisionB.Left && collisionA.Bottom <= collisionB.Top && collisionA.Top >= collisionB.Bottom;
		}

		// Token: 0x06042D33 RID: 273715 RVA: 0x01126EBF File Offset: 0x011250BF
		public void AddCheckCollisionDropItemInstanceId(int instanceId)
		{
			this.CheckCollisionDropItemInstanceIds.Add(instanceId);
		}

		// Token: 0x06042D34 RID: 273716 RVA: 0x01126ECE File Offset: 0x011250CE
		public void RemoveCheckCollisionDropItemInstanceId(int instanceId)
		{
			this.CheckCollisionDropItemInstanceIds.Remove(instanceId);
		}

		// Token: 0x040253DC RID: 152540
		private readonly List<int> TmpCollisionList = new List<int>();

		// Token: 0x040253DD RID: 152541
		private readonly HashSet<int> CheckCollisionDropItemInstanceIds = new HashSet<int>();
	}
}
