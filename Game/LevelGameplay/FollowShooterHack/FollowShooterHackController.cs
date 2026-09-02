using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FollowShooterHack
{
	// Token: 0x02006E84 RID: 28292
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FollowShooterHackController : ControllerBase<FollowShooterHackController>
	{
		// Token: 0x060449CD RID: 281037 RVA: 0x011D691C File Offset: 0x011D4B1C
		public void AddRelationship(long followerId, long hackTargetId)
		{
			if (!this.HackRelationshipMap.ContainsKey(followerId))
			{
				this.HackRelationshipMap[followerId] = new HashSet<long>();
			}
			if (this.HackRelationshipMap[followerId].Contains(hackTargetId))
			{
				return;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(hackTargetId);
			if (entity != null)
			{
				WorldEntity entity2 = entity.Entity;
				if (entity2 != null && entity2.Valid)
				{
					BaseGameplayCueComponent component = entity.Entity.GetComponent<BaseGameplayCueComponent>();
					if (component == null)
					{
						return;
					}
					int num = component.AddCue(640015002L, null);
					this.HackedTargetGameplayCueMap[hackTargetId] = (long)num;
					this.HackRelationshipMap[followerId].Add(hackTargetId);
					return;
				}
			}
		}

		// Token: 0x060449CE RID: 281038 RVA: 0x011D69CC File Offset: 0x011D4BCC
		public void RemoveRelationship(long followerId, long hackTargetId)
		{
			if (!this.HackRelationshipMap.ContainsKey(followerId))
			{
				return;
			}
			if (!this.HackRelationshipMap[followerId].Contains(hackTargetId))
			{
				return;
			}
			if (this.HackedTargetGameplayCueMap.ContainsKey(hackTargetId))
			{
				long cueHandleId = this.HackedTargetGameplayCueMap[hackTargetId];
				this.HackedTargetGameplayCueMap.Remove(hackTargetId);
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(hackTargetId);
				if (entity != null)
				{
					WorldEntity entity2 = entity.Entity;
					if (entity2 != null && entity2.Valid)
					{
						BaseGameplayCueComponent component = entity.Entity.GetComponent<BaseGameplayCueComponent>();
						if (component == null)
						{
							return;
						}
						component.RemoveCueByHandle(cueHandleId);
						goto IL_8A;
					}
				}
				return;
			}
			IL_8A:
			this.HackRelationshipMap[followerId].Remove(hackTargetId);
		}

		// Token: 0x0402631F RID: 156447
		private const int GAMEPLAY_CUE_ID = 640015002;

		// Token: 0x04026320 RID: 156448
		private readonly Dictionary<long, HashSet<long>> HackRelationshipMap = new Dictionary<long, HashSet<long>>();

		// Token: 0x04026321 RID: 156449
		private readonly Dictionary<long, long> HackedTargetGameplayCueMap = new Dictionary<long, long>();
	}
}
