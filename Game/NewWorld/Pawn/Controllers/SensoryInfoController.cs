using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.SensoryInfo;

namespace CSharpScript.Game.NewWorld.Pawn.Controllers
{
	// Token: 0x020048AA RID: 18602
	[NullableContext(1)]
	[Nullable(0)]
	[Controller(0)]
	public class SensoryInfoController
	{
		// Token: 0x060307A7 RID: 198567 RVA: 0x00BE43EC File Offset: 0x00BE25EC
		public void Tick(float delta)
		{
			if ((this.SensoryInfoType & 2) != 0)
			{
				foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair in this.SensoryList)
				{
					if (keyValuePair.Value.CheckInRange())
					{
						keyValuePair.Value.Tick(delta);
					}
				}
			}
		}

		// Token: 0x060307A8 RID: 198568 RVA: 0x00BE4460 File Offset: 0x00BE2660
		public void HandleEntities(EntityHandle[] handles, Vector actorLocation, int curEntityId)
		{
			foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair in this.SensoryList)
			{
				keyValuePair.Value.ClearCacheList();
			}
			foreach (EntityHandle entityHandle in handles)
			{
				int id = entityHandle.Id;
				WorldEntity entity = entityHandle.Entity;
				BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
				if (entityHandle != null)
				{
					WorldEntity entity2 = entityHandle.Entity;
					if (entity2 != null && entity2.Active && baseActorComponent != null && id != curEntityId)
					{
						double num = Vector.Distance(baseActorComponent.ActorLocationProxy, actorLocation);
						foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair2 in this.SensoryList)
						{
							if (num <= keyValuePair2.Value.SensoryRange && keyValuePair2.Value.CheckEntity(entityHandle.Entity))
							{
								keyValuePair2.Value.EnterRange(entityHandle.Entity);
							}
						}
					}
				}
			}
			foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair3 in this.SensoryList)
			{
				keyValuePair3.Value.ExitRange();
			}
		}

		// Token: 0x060307A9 RID: 198569 RVA: 0x00BE45E8 File Offset: 0x00BE27E8
		public int AddSensoryInfo(BaseSensoryInfo sensoryParam)
		{
			this.SensoryInfoType |= (int)sensoryParam.SensoryInfoType;
			this.MaxSensoryRange = Math.Max(this.MaxSensoryRange, sensoryParam.SensoryRange);
			int num = this.Uid + 1;
			this.Uid = num;
			int num2 = num;
			this.SensoryList[num2] = sensoryParam;
			return num2;
		}

		// Token: 0x060307AA RID: 198570 RVA: 0x00BE463F File Offset: 0x00BE283F
		public bool RemoveSensoryInfo(int key)
		{
			if (!this.SensoryList.ContainsKey(key))
			{
				return false;
			}
			this.SensoryList.Remove(key);
			this.UpdateInfoType();
			this.UpdateSensoryRange();
			return true;
		}

		// Token: 0x060307AB RID: 198571 RVA: 0x00BE466C File Offset: 0x00BE286C
		public void UpdateInfoType()
		{
			this.SensoryInfoType = 0;
			foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair in this.SensoryList)
			{
				this.SensoryInfoType |= (int)keyValuePair.Value.SensoryInfoType;
			}
		}

		// Token: 0x060307AC RID: 198572 RVA: 0x00BE46D8 File Offset: 0x00BE28D8
		public void UpdateSensoryRange()
		{
			this.MaxSensoryRange = 0.0;
			foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair in this.SensoryList)
			{
				this.MaxSensoryRange = Math.Max(this.MaxSensoryRange, keyValuePair.Value.SensoryRange);
			}
		}

		// Token: 0x060307AD RID: 198573 RVA: 0x00BE4750 File Offset: 0x00BE2950
		public void Clear()
		{
			this.Uid = 0;
			this.SensoryInfoType = 0;
			this.MaxSensoryRange = 0.0;
			foreach (KeyValuePair<int, BaseSensoryInfo> keyValuePair in this.SensoryList)
			{
				keyValuePair.Value.Clear();
			}
			this.SensoryList.Clear();
		}

		// Token: 0x0401BD9F RID: 114079
		private int Uid;

		// Token: 0x0401BDA0 RID: 114080
		public int SensoryInfoType;

		// Token: 0x0401BDA1 RID: 114081
		public double MaxSensoryRange;

		// Token: 0x0401BDA2 RID: 114082
		private readonly Dictionary<int, BaseSensoryInfo> SensoryList = new Dictionary<int, BaseSensoryInfo>();
	}
}
