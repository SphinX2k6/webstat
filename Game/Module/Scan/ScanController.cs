using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.Scan
{
	// Token: 0x0200500D RID: 20493
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class ScanController : ControllerBase<ScanController>
	{
		// Token: 0x06034D33 RID: 216371 RVA: 0x00D42EFC File Offset: 0x00D410FC
		public void StartScan()
		{
			LevelGamePlayConfig instance = ConfigBase<LevelGamePlayConfig>.Instance;
			float scanMaxDistance = (float)(((instance != null) ? instance.ScanMaxDistance : 0) * 100);
			LevelGamePlayConfig instance2 = ConfigBase<LevelGamePlayConfig>.Instance;
			ScanData scanData = new ScanData(scanMaxDistance, (float)(((instance2 != null) ? instance2.ScanShowInteractionEffectMaxDistance : 0) * 100));
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.CH, "ScanController.StartScan:当前编队实体为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			WorldEntity entity = getCurrentEntity.Entity;
			BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.CH, "ScanController.StartScan:当前角色组件为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			AActor aactor = Singleton<ActorSystem>.Instance.Spawn(BP_Fx_Scanning_C.StaticClass(), baseActorComponent.ActorTransform, baseActorComponent.Owner);
			if (aactor == null)
			{
				Singleton<Log>.Instance.Warn(ELogModule.LevelPlay, ELogAuthor.CH, "ScanController.StartScan:扫描特效Actor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			aactor.D_K2_SetActorLocation(baseActorComponent.ActorLocation, false, ref WorldGlobal.SweepHitResult, false);
			scanData.ScanningEffectActor = (aactor as BP_Fx_Scanning_C);
			scanData.ScanningEffectActor.StartScanEffect();
			scanData.FindNearbyEntities();
			this.ScanDataCache[scanData.Id] = scanData;
		}

		// Token: 0x06034D34 RID: 216372 RVA: 0x00D4301C File Offset: 0x00D4121C
		private bool ScanEffectTick(float delta, int id)
		{
			ScanData scanData;
			if (!this.ScanDataCache.TryGetValue(id, out scanData))
			{
				return false;
			}
			if (!scanData.UpdateScanRadius((float)((double)delta * Singleton<TimeUtil>.Instance.Millisecond * (double)ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation)))
			{
				return true;
			}
			if (!scanData.IsScanComplete())
			{
				scanData.ProcessNearbyEntities();
				return true;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return false;
			}
			TsGameplayBlueprintFunctionLibrary.SendScanSkillUseLogData(getCurrentEntity.Id, scanData.HasTarget);
			scanData.EndScan();
			return false;
		}

		// Token: 0x06034D35 RID: 216373 RVA: 0x00D43098 File Offset: 0x00D41298
		protected override void OnTick(float delta)
		{
			List<int> list = new List<int>();
			foreach (ScanData scanData in this.ScanDataCache.Values)
			{
				if (!this.ScanEffectTick(delta, scanData.Id))
				{
					list.Add(scanData.Id);
				}
			}
			foreach (int key in list)
			{
				this.ScanDataCache.Remove(key);
			}
		}

		// Token: 0x0401E72B RID: 124715
		private readonly Dictionary<int, ScanData> ScanDataCache = new Dictionary<int, ScanData>();

		// Token: 0x0401E72C RID: 124716
		private readonly Stat SpawnStat = Stat.Create("ScanController.StartScan", "", "");

		// Token: 0x0401E72D RID: 124717
		private readonly Stat TickStat = Stat.Create("ScanController.Tick", "", "");
	}
}
