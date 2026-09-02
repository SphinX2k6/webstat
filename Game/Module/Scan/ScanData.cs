using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.Module.Scan
{
	// Token: 0x0200500C RID: 20492
	[NullableContext(1)]
	[Nullable(0)]
	internal class ScanData : IStaticVariableResetter
	{
		// Token: 0x06034D28 RID: 216360 RVA: 0x00D42A91 File Offset: 0x00D40C91
		static ScanData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(ScanData.CreateStaticDefaultValue), new Action(ScanData.ResetStaticDefaultValue));
		}

		// Token: 0x06034D29 RID: 216361 RVA: 0x00D42ACA File Offset: 0x00D40CCA
		public static void CreateStaticDefaultValue()
		{
			ScanData.Uid = 0;
		}

		// Token: 0x06034D2A RID: 216362 RVA: 0x00D42AD2 File Offset: 0x00D40CD2
		public static void ResetStaticDefaultValue()
		{
			ScanData.Uid = 0;
		}

		// Token: 0x06034D2B RID: 216363 RVA: 0x00D42ADC File Offset: 0x00D40CDC
		public ScanData(float scanMaxDistance, float scanInteractionEffectMaxDistance)
		{
			this.Id = ScanData.Uid++;
			this.MaxScanDistance = Math.Max(scanMaxDistance, scanInteractionEffectMaxDistance);
		}

		// Token: 0x06034D2C RID: 216364 RVA: 0x00D42B48 File Offset: 0x00D40D48
		public void EndScan()
		{
			foreach (Entity entity in this.NearbyCharacterEntities)
			{
				BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
				if (component != null && component.HasTag(ScanData.scanCharacterTag))
				{
					component.RemoveTag(new int?(ScanData.scanCharacterTag));
				}
			}
			ControllerBase<LevelGamePlayController>.Instance.HandleClearAllScanEffect();
			Singleton<ActorSystem>.Instance.Put("ScanData.EndScan", this.ScanningEffectActor, null);
			this.ScanningEffectActor = null;
			this.NearbyEntityQueue.Clear();
			this.NearbyEntitiesMap.Clear();
			this.NearbyCharacterEntities.Clear();
		}

		// Token: 0x06034D2D RID: 216365 RVA: 0x00D42C04 File Offset: 0x00D40E04
		public void FindNearbyEntities()
		{
			List<EntityHandle> list = new List<EntityHandle>();
			ModelBase<CreatureModel>.Instance.GetEntitiesInRange(this.MaxScanDistance, EEntityTypeQuery.SceneItemOrCharacter, list, true, false);
			if (list.Count == 0)
			{
				return;
			}
			this.HasTarget = true;
			WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.CH, "ScanController.FindNearbyEntities:当前角色组件为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (EntityHandle entityHandle in list)
			{
				if (entityHandle.Valid && entityHandle.Entity != null)
				{
					WorldEntity entity2 = entityHandle.Entity;
					double distance = Vector.Distance(entity2.GetComponent<BaseActorComponent>().ActorLocationProxy, baseActorComponent.ActorLocationProxy);
					this.NearbyEntitiesMap.Add(new NearbyEntityInfo(entity2, distance));
				}
			}
			this.NearbyEntitiesMap.Sort((NearbyEntityInfo a, NearbyEntityInfo b) => a.Distance.CompareTo(b.Distance));
			foreach (NearbyEntityInfo element in this.NearbyEntitiesMap)
			{
				this.NearbyEntityQueue.Push(element);
			}
		}

		// Token: 0x06034D2E RID: 216366 RVA: 0x00D42D74 File Offset: 0x00D40F74
		public bool IsScanComplete()
		{
			return this.CurScanRadius >= this.MaxScanDistance;
		}

		// Token: 0x06034D2F RID: 216367 RVA: 0x00D42D88 File Offset: 0x00D40F88
		public bool UpdateScanRadius(float timeDilation)
		{
			this.CurElapsedTime += timeDilation;
			float num = UKismetMathLibrary.FInterpTo(0f, this.MaxScanDistance, this.CurElapsedTime, 1f / this.ScanEndTime);
			if (num == this.MaxScanDistance)
			{
				this.CurScanRadius = num;
				return true;
			}
			if (num < this.CurScanRadius + this.ScanRadiusSpace && this.CurScanRadius < this.MaxScanDistance)
			{
				return false;
			}
			this.CurScanRadius = num;
			return true;
		}

		// Token: 0x06034D30 RID: 216368 RVA: 0x00D42E00 File Offset: 0x00D41000
		[NullableContext(2)]
		private bool IsReadyToProcessEntity(NearbyEntityInfo nearbyEntityInfo)
		{
			return nearbyEntityInfo != null && nearbyEntityInfo.Distance <= (double)this.CurScanRadius;
		}

		// Token: 0x06034D31 RID: 216369 RVA: 0x00D42E1C File Offset: 0x00D4101C
		private void AddScanTagToEntity(Entity entity)
		{
			if (entity.GetComponent<CharacterActorComponent>() == null)
			{
				return;
			}
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			ECamp? ecamp = (component != null) ? new ECamp?(component.GetEntityCamp()) : null;
			ECamp ecamp2 = ECamp.Player;
			if (ecamp.GetValueOrDefault() == ecamp2 & ecamp != null)
			{
				return;
			}
			this.NearbyCharacterEntities.Add(entity);
			BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
			if (component2 != null)
			{
				component2.AddTag(new int?(ScanData.scanCharacterTag));
			}
		}

		// Token: 0x06034D32 RID: 216370 RVA: 0x00D42E90 File Offset: 0x00D41090
		public void ProcessNearbyEntities()
		{
			while (this.NearbyEntityQueue.Size > 0)
			{
				NearbyEntityInfo front = this.NearbyEntityQueue.Front;
				if (!this.IsReadyToProcessEntity(front))
				{
					break;
				}
				this.NearbyEntityQueue.Pop();
				Entity entity = (front != null) ? front.Entity : null;
				if (entity != null && entity.Valid)
				{
					ControllerBase<LevelGamePlayController>.Instance.HandleScanEntityResponse(entity, 0);
					this.AddScanTagToEntity(entity);
				}
			}
		}

		// Token: 0x0401E71E RID: 124702
		private static int Uid = 0;

		// Token: 0x0401E71F RID: 124703
		private static readonly int scanCharacterTag = GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.扫描感应中"];

		// Token: 0x0401E720 RID: 124704
		public int Id;

		// Token: 0x0401E721 RID: 124705
		public float MaxScanDistance;

		// Token: 0x0401E722 RID: 124706
		[Nullable(2)]
		public BP_Fx_Scanning_C ScanningEffectActor;

		// Token: 0x0401E723 RID: 124707
		public float CurElapsedTime;

		// Token: 0x0401E724 RID: 124708
		public float CurScanRadius;

		// Token: 0x0401E725 RID: 124709
		public readonly float ScanEndTime = 1.6f;

		// Token: 0x0401E726 RID: 124710
		public readonly float ScanRadiusSpace = 200f;

		// Token: 0x0401E727 RID: 124711
		public bool HasTarget;

		// Token: 0x0401E728 RID: 124712
		public HashSet<Entity> NearbyCharacterEntities = new HashSet<Entity>();

		// Token: 0x0401E729 RID: 124713
		private readonly List<NearbyEntityInfo> NearbyEntitiesMap = new List<NearbyEntityInfo>();

		// Token: 0x0401E72A RID: 124714
		public Queue<NearbyEntityInfo> NearbyEntityQueue = new Queue<NearbyEntityInfo>(4);
	}
}
