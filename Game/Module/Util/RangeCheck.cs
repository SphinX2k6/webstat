using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C6D RID: 19565
	[NullableContext(1)]
	[Nullable(0)]
	public class RangeCheck
	{
		// Token: 0x06032F91 RID: 208785 RVA: 0x00CC4B62 File Offset: 0x00CC2D62
		public RangeCheck()
		{
			this.RangeMap = new Dictionary<int, SRangeContainer>();
		}

		// Token: 0x06032F92 RID: 208786 RVA: 0x00CC4B75 File Offset: 0x00CC2D75
		public bool OnInit()
		{
			return true;
		}

		// Token: 0x06032F93 RID: 208787 RVA: 0x00CC4B78 File Offset: 0x00CC2D78
		public bool OnClear()
		{
			if (this.RangeMap != null)
			{
				foreach (SRangeContainer srangeContainer in this.RangeMap.Values)
				{
					srangeContainer.Clear();
				}
				this.RangeMap.Clear();
			}
			this.RangeMap = null;
			return true;
		}

		// Token: 0x06032F94 RID: 208788 RVA: 0x00CC4BE8 File Offset: 0x00CC2DE8
		[NullableContext(2)]
		public SRangeContainer GetOrAdd(int entityId)
		{
			if (this.RangeMap == null)
			{
				this.MakeRange(entityId);
				SRangeContainer result;
				this.RangeMap.TryGetValue(entityId, out result);
				return result;
			}
			SRangeContainer result2;
			if (!this.RangeMap.TryGetValue(entityId, out result2))
			{
				this.MakeRange(entityId);
				this.RangeMap.TryGetValue(entityId, out result2);
			}
			return result2;
		}

		// Token: 0x06032F95 RID: 208789 RVA: 0x00CC4C40 File Offset: 0x00CC2E40
		public bool MakeRange(int entityId)
		{
			if (this.RangeMap == null)
			{
				this.RangeMap = new Dictionary<int, SRangeContainer>();
			}
			SRangeContainer srangeContainer = new SRangeContainer();
			srangeContainer.MakeRange(entityId);
			this.RangeMap[entityId] = srangeContainer;
			return true;
		}

		// Token: 0x06032F96 RID: 208790 RVA: 0x00CC4C7C File Offset: 0x00CC2E7C
		public int[] MapCheckReached()
		{
			List<int> list = new List<int>();
			if (this.RangeMap == null)
			{
				return list.ToArray();
			}
			foreach (KeyValuePair<int, SRangeContainer> keyValuePair in this.RangeMap)
			{
				int num;
				SRangeContainer srangeContainer;
				keyValuePair.Deconstruct(out num, out srangeContainer);
				int num2 = num;
				if (this.CheckReached(new int?(num2)))
				{
					list.Add(num2);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06032F97 RID: 208791 RVA: 0x00CC4D08 File Offset: 0x00CC2F08
		public bool CheckReached(int? entityId)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null && entityId != null)
			{
				int? num = entityId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null))
				{
					WorldEntity entity = getCurrentEntity.Entity;
					Vector playerPosition;
					if (entity == null)
					{
						playerPosition = null;
					}
					else
					{
						BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
						playerPosition = ((component != null) ? component.ActorLocationProxy : null);
					}
					this.PlayerPosition = playerPosition;
					SRangeContainer srangeContainer;
					return this.PlayerPosition != null && this.RangeMap != null && this.RangeMap.TryGetValue(entityId.Value, out srangeContainer) && srangeContainer.CheckPositionReached(this.PlayerPosition);
				}
			}
			return false;
		}

		// Token: 0x06032F98 RID: 208792 RVA: 0x00CC4DA0 File Offset: 0x00CC2FA0
		public void Remove(int entityId)
		{
			if (this.RangeMap == null || !this.RangeMap.ContainsKey(entityId))
			{
				return;
			}
			this.RangeMap.Remove(entityId);
		}

		// Token: 0x06032F99 RID: 208793 RVA: 0x00CC4DC8 File Offset: 0x00CC2FC8
		public int? MapCheckReachedPosition(Vector itemPosition)
		{
			int? result = null;
			if (this.RangeMap == null)
			{
				return result;
			}
			foreach (KeyValuePair<int, SRangeContainer> keyValuePair in this.RangeMap)
			{
				int num;
				SRangeContainer srangeContainer;
				keyValuePair.Deconstruct(out num, out srangeContainer);
				int value = num;
				if (this.CheckReachedPosition(new int?(value), itemPosition))
				{
					result = new int?(value);
				}
			}
			return result;
		}

		// Token: 0x06032F9A RID: 208794 RVA: 0x00CC4E4C File Offset: 0x00CC304C
		public bool CheckReachedPosition(int? entityId, Vector itemPosition)
		{
			if (entityId != null)
			{
				int? num = entityId;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null) && this.RangeMap != null)
				{
					SRangeContainer srangeContainer;
					return this.RangeMap.TryGetValue(entityId.Value, out srangeContainer) && srangeContainer.CheckPositionReached(itemPosition);
				}
			}
			return false;
		}

		// Token: 0x0401DA8E RID: 121486
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, SRangeContainer> RangeMap;

		// Token: 0x0401DA8F RID: 121487
		[Nullable(2)]
		public Vector PlayerPosition;
	}
}
