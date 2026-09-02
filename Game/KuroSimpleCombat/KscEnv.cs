using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat
{
	// Token: 0x02006FBC RID: 28604
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KscEnv : Singleton<KscEnv>
	{
		// Token: 0x1700A4AA RID: 42154
		// (get) Token: 0x0604527D RID: 283261 RVA: 0x0120BC74 File Offset: 0x01209E74
		public UKSC_World KscWorld
		{
			get
			{
				return this.KscWorldInternal;
			}
		}

		// Token: 0x1700A4AB RID: 42155
		// (get) Token: 0x0604527E RID: 283262 RVA: 0x0120BC7C File Offset: 0x01209E7C
		public int KscWorldHandle
		{
			get
			{
				return this.KscWorldHandleInternal;
			}
		}

		// Token: 0x1700A4AC RID: 42156
		// (get) Token: 0x0604527F RID: 283263 RVA: 0x0120BC84 File Offset: 0x01209E84
		public UKuroSimpleCombatSubsystem KscSubsystem
		{
			get
			{
				return USubsystemBlueprintLibrary.GetGameInstanceSubsystem(GlobalData.GameInstance, UKuroSimpleCombatSubsystem.StaticClass()) as UKuroSimpleCombatSubsystem;
			}
		}

		// Token: 0x06045280 RID: 283264 RVA: 0x0120BCA0 File Offset: 0x01209EA0
		public void Start(UClass worldClass = null)
		{
			if (this.Started)
			{
				return;
			}
			this.Started = true;
			KscLog.Info(KscLog.EModule.Common, ELogAuthor.PZ, this.KscWorld, "KscEnv启动", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKuroSimpleCombatSubsystem kscSubsystem = this.KscSubsystem;
			if (((kscSubsystem != null) ? kscSubsystem.GetKSCWorld() : null) == null)
			{
				UKuroSimpleCombatSubsystem kscSubsystem2 = this.KscSubsystem;
				if (kscSubsystem2 != null)
				{
					kscSubsystem2.CreateWorld(worldClass);
				}
				int num = this.KscWorldHandleInternal + 1;
				this.KscWorldHandleInternal = num;
				KscUtil.SetKscWorldHandle(num);
				UKuroSimpleCombatSubsystem kscSubsystem3 = this.KscSubsystem;
				this.KscWorldInternal = ((kscSubsystem3 != null) ? kscSubsystem3.GetKSCWorld() : null);
				this.SetupBounds();
			}
			else
			{
				UKuroSimpleCombatSubsystem kscSubsystem4 = this.KscSubsystem;
				this.KscWorldInternal = ((kscSubsystem4 != null) ? kscSubsystem4.GetKSCWorld() : null);
			}
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.log.Buff 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.log.Damage 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.log.Attr 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.log.Skill 1", null);
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.log.Move 0", null);
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "bullet.kfc.enable 1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.entity.kfc.enable 1", null);
			this.OnStart();
			if (this.WorldKillZ != null)
			{
				UKSC_World kscWorld = this.KscWorld;
				if (kscWorld != null)
				{
					kscWorld.SetWorldAttr(EKSC_WorldAttrType.WorldKillZ, (int)this.WorldKillZ.Value);
				}
				this.WorldKillZ = null;
			}
			if (this.ObstacleSegments != null)
			{
				UKSC_World kscWorld2 = this.KscWorld;
				if (kscWorld2 != null)
				{
					kscWorld2.SetObstacleSegments(this.ObstacleSegments);
				}
				this.ObstacleSegments = null;
			}
		}

		// Token: 0x06045281 RID: 283265 RVA: 0x0120BE34 File Offset: 0x0120A034
		private unsafe void SetupBounds()
		{
			if (this.KscWorldInternal == null)
			{
				KscLog.Info(KscLog.EModule.Load, ELogAuthor.HCW, this.KscWorldInternal, "KscWorld 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int curLevelId = ModelBase<SurvivorsRogueModel>.Instance.CurLevelId;
			if (curLevelId == 0)
			{
				KscLog.EModule flag = KscLog.EModule.Load;
				ELogAuthor author = ELogAuthor.HCW;
				UObject kscWorldInternal = this.KscWorldInternal;
				string log = "不在幸存者关卡内";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelId", curLevelId);
				KscLog.Info(flag, author, kscWorldInternal, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.KscWorldInternal.SetWorldBounds(null);
				return;
			}
			SurvivorsLevel? survivorsLevel = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(curLevelId);
			if (survivorsLevel == null)
			{
				KscLog.EModule flag2 = KscLog.EModule.Load;
				ELogAuthor author2 = ELogAuthor.HCW;
				UObject kscWorldInternal2 = this.KscWorldInternal;
				string log2 = "找不到对应的关卡配置";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("LevelId", curLevelId);
				KscLog.Error(flag2, author2, kscWorldInternal2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.KscWorldInternal.SetWorldBounds(null);
				return;
			}
			if (string.IsNullOrEmpty(survivorsLevel.Value.BoundsPath))
			{
				KscLog.EModule flag3 = KscLog.EModule.Load;
				ELogAuthor author3 = ELogAuthor.HCW;
				UObject kscWorldInternal3 = this.KscWorldInternal;
				string log3 = "BoundsPath 为空";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("LevelId", curLevelId);
				KscLog.Info(flag3, author3, kscWorldInternal3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				this.KscWorldInternal.SetWorldBounds(null);
				return;
			}
			UKSC_DA_WorldBounds uksc_DA_WorldBounds = Singleton<ResourceSystem>.Instance.Load<UKSC_DA_WorldBounds>(survivorsLevel.Value.BoundsPath, "js_undefined");
			if (uksc_DA_WorldBounds == null || !uksc_DA_WorldBounds.IsValid())
			{
				KscLog.EModule flag4 = KscLog.EModule.Load;
				ELogAuthor author4 = ELogAuthor.HCW;
				UObject kscWorldInternal4 = this.KscWorldInternal;
				string log4 = "加载不到对应的DA";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Path", survivorsLevel.Value.BoundsPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LevelId", curLevelId);
				KscLog.Error(flag4, author4, kscWorldInternal4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.KscWorldInternal.SetWorldBounds(null);
				return;
			}
			this.KscWorldInternal.SetWorldBounds(uksc_DA_WorldBounds);
		}

		// Token: 0x06045282 RID: 283266 RVA: 0x0120C000 File Offset: 0x0120A200
		private void OnStart()
		{
			UKSC_World kscWorld = this.KscWorld;
			if (kscWorld != null)
			{
				FOnKSCBatchRemoveAfter fonKSCBatchRemoveAfter = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCBatchRemoveAfter>(new <>A{00000003}<TArray<FKSC_RemoveContext>>(this.BatchRemove));
				kscWorld.AssignBatchRemoveDelegate(fonKSCBatchRemoveAfter);
			}
			UKSC_World kscWorld2 = this.KscWorld;
			if (kscWorld2 == null)
			{
				return;
			}
			FOnKSCLandFireSpawn fonKSCLandFireSpawn = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCLandFireSpawn>(new <>A{00000003}<TArray<FKSC_LandFireContext>>(this.LandFireSpawn));
			kscWorld2.AssignLandFireSpawnDelegate(fonKSCLandFireSpawn);
		}

		// Token: 0x06045283 RID: 283267 RVA: 0x0120C056 File Offset: 0x0120A256
		[NullableContext(1)]
		public void BatchRemove(in TArray<FKSC_RemoveContext> contexts)
		{
			if (!this.Started)
			{
				return;
			}
			ControllerBase<KuroSimpleCombatController>.Instance.BatchRemove(contexts);
		}

		// Token: 0x06045284 RID: 283268 RVA: 0x0120C06D File Offset: 0x0120A26D
		[NullableContext(1)]
		public void LandFireSpawn(in TArray<FKSC_LandFireContext> contexts)
		{
			if (!this.Started)
			{
				return;
			}
			ControllerBase<KuroSimpleCombatController>.Instance.LandFireSpawn(contexts);
		}

		// Token: 0x06045285 RID: 283269 RVA: 0x0120C084 File Offset: 0x0120A284
		public void Stop()
		{
			if (!this.Started)
			{
				return;
			}
			this.Started = false;
			KscLog.Info(KscLog.EModule.Common, ELogAuthor.PZ, this.KscWorld, "KscEnv停止", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnStop();
			UKuroSimpleCombatSubsystem kscSubsystem = this.KscSubsystem;
			if (kscSubsystem != null)
			{
				kscSubsystem.DestroyWorld();
			}
			int num = this.KscWorldHandleInternal + 1;
			this.KscWorldHandleInternal = num;
			KscUtil.SetKscWorldHandle(num);
			this.KscWorldInternal = null;
		}

		// Token: 0x06045286 RID: 283270 RVA: 0x0120C0F1 File Offset: 0x0120A2F1
		private void OnStop()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new <>A{00000003}<TArray<FKSC_RemoveContext>>(this.BatchRemove));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new <>A{00000003}<TArray<FKSC_LandFireContext>>(this.LandFireSpawn));
		}

		// Token: 0x06045287 RID: 283271 RVA: 0x0120C115 File Offset: 0x0120A315
		public void CacheWorldKillZ(float killZ)
		{
			this.WorldKillZ = new float?(killZ);
		}

		// Token: 0x06045288 RID: 283272 RVA: 0x0120C123 File Offset: 0x0120A323
		[NullableContext(1)]
		public void CacheObstacleSegments(TArray<FKSC_Segment> inObstacleSegments)
		{
			this.ObstacleSegments = inObstacleSegments;
		}

		// Token: 0x04026951 RID: 158033
		public bool Started;

		// Token: 0x04026952 RID: 158034
		private float? WorldKillZ;

		// Token: 0x04026953 RID: 158035
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FKSC_Segment> ObstacleSegments;

		// Token: 0x04026954 RID: 158036
		private UKSC_World KscWorldInternal;

		// Token: 0x04026955 RID: 158037
		private int KscWorldHandleInternal;
	}
}
