using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat;
using UnrealEngine;

// Token: 0x02000F30 RID: 3888
[NullableContext(1)]
[Nullable(0)]
public class FinalBattleSubController : KscSubControllerBase
{
	// Token: 0x0600610A RID: 24842 RVA: 0x00184948 File Offset: 0x00182B48
	protected override void CreateModel()
	{
		this.SubModel = new FinalBattleSubModel();
	}

	// Token: 0x0600610B RID: 24843 RVA: 0x00184955 File Offset: 0x00182B55
	public FinalBattleSubModel GetModel()
	{
		return (FinalBattleSubModel)this.SubModel;
	}

	// Token: 0x0600610C RID: 24844 RVA: 0x00184962 File Offset: 0x00182B62
	public override bool IsTargetMap(int instSubType)
	{
		return false;
	}

	// Token: 0x0600610D RID: 24845 RVA: 0x00184965 File Offset: 0x00182B65
	protected override void CreateEntityFilter()
	{
		this.RedirectFilter = this.EntityRedirectFilter;
	}

	// Token: 0x0600610E RID: 24846 RVA: 0x00184973 File Offset: 0x00182B73
	protected override void OnInitMap()
	{
	}

	// Token: 0x0600610F RID: 24847 RVA: 0x00184975 File Offset: 0x00182B75
	protected override void OnMapLoaded()
	{
		this.InitBulletWorld();
		this.LoadBulletDataTable();
	}

	// Token: 0x06006110 RID: 24848 RVA: 0x00184983 File Offset: 0x00182B83
	protected override void OnWorldDone()
	{
		ControllerBase<DamageUiController>.Instance.UpdateKscWorld();
	}

	// Token: 0x06006111 RID: 24849 RVA: 0x0018498F File Offset: 0x00182B8F
	protected override void OnWorldReset()
	{
		this.ClearBulletWorld();
		this.GetModel().BulletDataTable = null;
	}

	// Token: 0x06006112 RID: 24850 RVA: 0x001849A3 File Offset: 0x00182BA3
	protected override void AddKscPlayerEntity()
	{
	}

	// Token: 0x06006113 RID: 24851 RVA: 0x001849A8 File Offset: 0x00182BA8
	private void LoadBulletDataTable()
	{
		FinalBattleSubModel model = this.GetModel();
		string bulletDtPath = model.GetBulletDtPath();
		if (string.IsNullOrEmpty(bulletDtPath))
		{
			model.BulletDataTable = null;
			return;
		}
		UDataTable udataTable = Singleton<ResourceSystem>.Instance.Load<UDataTable>(bulletDtPath, "js_undefined");
		if (udataTable == null || !udataTable.IsValid())
		{
			model.BulletDataTable = null;
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "FinalBattle加载子弹DT失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", bulletDtPath);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		model.BulletDataTable = udataTable;
		UBulletWorld kuroBulletWorld = ModelBase<BulletModel>.Instance.GetKuroBulletWorld();
		if (kuroBulletWorld != null)
		{
			kuroBulletWorld.AddCommonBulletDataTable(udataTable);
		}
	}

	// Token: 0x06006114 RID: 24852 RVA: 0x00184A40 File Offset: 0x00182C40
	public override void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
	{
		IFinalBattleCombatInfo entity = this.GetModel().GetEntity((int)context.CreatureDataId);
		if (entity == null)
		{
			return;
		}
		SimpleCombatEntityDieContext simpleCombatEntityDieContext = SimpleCombatEntityDieContext.Create();
		Aki.Protocol.Vector vector = Aki.Protocol.Vector.Create();
		vector.X = (float)context.Location.X;
		vector.Y = (float)context.Location.Y;
		vector.Z = (float)context.Location.Z;
		simpleCombatEntityDieContext.DiePos = vector;
		if (entity.EntityType == EFinalBattleEntityType.Monster)
		{
			GPUMonsterKilledCtxPb gpumonsterKilledCtxPb = GPUMonsterKilledCtxPb.Create();
			gpumonsterKilledCtxPb.EntityId = context.CreatureDataId;
			simpleCombatEntityDieContext.GPUMonsterKilledCtx = gpumonsterKilledCtxPb;
		}
		else if (entity.EntityType == EFinalBattleEntityType.Role)
		{
			GPURoleKilledCtxPb gpuroleKilledCtxPb = GPURoleKilledCtxPb.Create();
			gpuroleKilledCtxPb.EntityId = context.CreatureDataId;
			simpleCombatEntityDieContext.GPURoleKilledCtx = gpuroleKilledCtxPb;
		}
		protoContexts[context.CreatureDataId] = simpleCombatEntityDieContext;
	}

	// Token: 0x06006115 RID: 24853 RVA: 0x00184B04 File Offset: 0x00182D04
	protected override void SyncPlayerTransform()
	{
		if (this.GetModel().KscPlayerEntity == null)
		{
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			return;
		}
		FTransformDouble ftransformDouble = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>().Actor.D_GetTransform();
		AKSC_Entity kscPlayerEntity = this.GetModel().KscPlayerEntity;
		if (kscPlayerEntity == null)
		{
			return;
		}
		kscPlayerEntity.SetTransformByWorld(ftransformDouble);
	}

	// Token: 0x04002E88 RID: 11912
	private readonly FinalBattleEntityRedirectFilter EntityRedirectFilter = new FinalBattleEntityRedirectFilter();
}
