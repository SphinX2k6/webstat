using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TowerDefenseEvent.Define;
using CSharpScript.Game.Module.TowerDefenseEvent.Model;
using UnrealEngine;

// Token: 0x02002BD0 RID: 11216
[NullableContext(1)]
[Nullable(0)]
public class TowerDefenseEventEntityRedirectFilter : KscEntityRedirectFilter
{
	// Token: 0x06016633 RID: 91699 RVA: 0x00636258 File Offset: 0x00634458
	protected unsafe override bool OnCreateEntity(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo = TowerDefenseEventEntityModelBuilder.Get(entityData, componentDataMap);
		if (towerDefenseEventCombatInfo == null)
		{
			return false;
		}
		string text = TowerDefenseEventConfig.FillUpModelInfo(towerDefenseEventCombatInfo, false);
		if (text != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefenseEvent;
			ELogAuthor author = ELogAuthor.XY;
			string message = "创建塔防实体失败: " + text;
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", towerDefenseEventCombatInfo.Uid);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("templateId", towerDefenseEventCombatInfo.TemplateId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("combatId", towerDefenseEventCombatInfo.CombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("subTypeId", towerDefenseEventCombatInfo.SubTypeId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			towerDefenseEventCombatInfo.Release();
			return true;
		}
		this.CreateEntityFromModel(towerDefenseEventCombatInfo);
		return true;
	}

	// Token: 0x06016634 RID: 91700 RVA: 0x00636348 File Offset: 0x00634548
	private unsafe void CreateEntityFromModel(ITowerDefenseEventCombatInfo model)
	{
		ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo = model;
		TowerDefenseEventModel instance = ModelBase<TowerDefenseEventModel>.Instance;
		ITowerDefenseEventCombatInfo entity = instance.GetEntity(towerDefenseEventCombatInfo.Uid);
		if (entity != null)
		{
			entity.Update(towerDefenseEventCombatInfo);
			towerDefenseEventCombatInfo.Release();
			towerDefenseEventCombatInfo = entity;
		}
		else
		{
			string text = instance.TryAddEntity(towerDefenseEventCombatInfo);
			if (text != null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XY;
				string message = "创建塔防实体失败: " + text;
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", towerDefenseEventCombatInfo.Uid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("templateId", towerDefenseEventCombatInfo.TemplateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("subTypeId", towerDefenseEventCombatInfo.SubTypeId);
				instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				towerDefenseEventCombatInfo.Release();
				return;
			}
		}
		if (ModelBase<GameModeModel>.Instance.MapDone)
		{
			this.InstantiateEntity(towerDefenseEventCombatInfo);
			return;
		}
		this.PendingEntities.Add(towerDefenseEventCombatInfo);
	}

	// Token: 0x06016635 RID: 91701 RVA: 0x0063644C File Offset: 0x0063464C
	protected override void OnInstantiateEntities()
	{
		foreach (ITowerDefenseEventCombatInfo model in this.PendingEntities)
		{
			this.InstantiateEntity(model);
		}
		this.PendingEntities.Clear();
	}

	// Token: 0x06016636 RID: 91702 RVA: 0x006364AC File Offset: 0x006346AC
	private unsafe void InstantiateEntity(ITowerDefenseEventCombatInfo model)
	{
		AActor renderActor = null;
		EKSC_Faction? faction = null;
		Action<AKSC_Entity> finishCallback = null;
		ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = model as ITowerDefenseEventTrapInfo;
		FTransformDouble transform;
		if (towerDefenseEventTrapInfo != null)
		{
			AKuroBuildingGrid akuroBuildingGrid = UKuroBuildingGridSubsystem.K2_FindBuildingGrid(GlobalData.World, towerDefenseEventTrapInfo.GridId);
			if (akuroBuildingGrid == null || !akuroBuildingGrid.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XY;
				string message = "创建陷阱失败，找不到目标网格";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", towerDefenseEventTrapInfo.Uid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("templateId", towerDefenseEventTrapInfo.TemplateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("gridId", towerDefenseEventTrapInfo.GridId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("coords", towerDefenseEventTrapInfo.Coords);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return;
			}
			TsTowerDefenseEventActor tsTowerDefenseEventActor = TsTowerDefenseEventActor.GetTrapActor((int)towerDefenseEventTrapInfo.Uid);
			if (tsTowerDefenseEventActor == null)
			{
				tsTowerDefenseEventActor = (Singleton<ActorSystem>.Instance.Get(TsTowerDefenseEventActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as TsTowerDefenseEventActor);
			}
			renderActor = tsTowerDefenseEventActor;
			faction = new EKSC_Faction?(EKSC_Faction.Faction2);
			string text = tsTowerDefenseEventActor.Init(towerDefenseEventTrapInfo, akuroBuildingGrid);
			if (text != null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.TowerDefenseEvent;
				ELogAuthor author2 = ELogAuthor.XY;
				string message2 = "创建陷阱失败: " + text;
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("creatureId", towerDefenseEventTrapInfo.Uid);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("templateId", towerDefenseEventTrapInfo.TemplateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("gridId", towerDefenseEventTrapInfo.GridId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("coords", towerDefenseEventTrapInfo.Coords);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				tsTowerDefenseEventActor.Destroy("TowerDefenseEventController.InstantiateEntity");
				return;
			}
			towerDefenseEventTrapInfo.UpdateTransform(tsTowerDefenseEventActor.D_K2_GetActorLocation(), tsTowerDefenseEventActor.K2_GetActorRotation());
			transform = tsTowerDefenseEventActor.D_GetTransform();
		}
		else
		{
			FRotator frotator = model.Rotation.ToUeRotator();
			FVectorDouble fvectorDouble = model.Position.ToUeVector(false);
			FVector fvector = global::Vector.OneVectorDouble;
			transform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
			ITowerDefenseEventSpecialCellInfo towerDefenseEventSpecialCellInfo = model as ITowerDefenseEventSpecialCellInfo;
			if (towerDefenseEventSpecialCellInfo != null)
			{
				AKuroBuildingGrid akuroBuildingGrid2 = UKuroBuildingGridSubsystem.K2_FindBuildingGrid(GlobalData.World, towerDefenseEventSpecialCellInfo.GridId);
				if (akuroBuildingGrid2 == null || !akuroBuildingGrid2.IsValid())
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.TowerDefenseEvent;
					ELogAuthor author3 = ELogAuthor.CH;
					string message3 = "创建特殊地块失败，找不到目标网格";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("creatureId", towerDefenseEventSpecialCellInfo.Uid);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("templateId", towerDefenseEventSpecialCellInfo.TemplateId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("gridId", towerDefenseEventSpecialCellInfo.GridId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("coords", towerDefenseEventSpecialCellInfo.Coords);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				}
				else
				{
					FKuroBuildingGridCellVector fkuroBuildingGridCellVector = default(FKuroBuildingGridCellVector);
					fkuroBuildingGridCellVector.X = (int)towerDefenseEventSpecialCellInfo.GridSize.X;
					fkuroBuildingGridCellVector.Y = (int)towerDefenseEventSpecialCellInfo.GridSize.Y;
					FKuroBuildingGridCellVector fkuroBuildingGridCellVector2 = default(FKuroBuildingGridCellVector);
					fkuroBuildingGridCellVector2.X = (int)towerDefenseEventSpecialCellInfo.Coords.X;
					fkuroBuildingGridCellVector2.Y = (int)towerDefenseEventSpecialCellInfo.Coords.Y;
					FVectorDouble position = akuroBuildingGrid2.GetPosition(fkuroBuildingGridCellVector, fkuroBuildingGridCellVector2);
					transform.SetLocation(position);
				}
				finishCallback = this.OnSpecialCellTypeCreate(model);
			}
		}
		TowerDefenseEventWorldEntityModel towerDefenseEventWorldEntityModel;
		if (this.InitializedEntities.TryGetValue(model.Uid, out towerDefenseEventWorldEntityModel))
		{
			if (towerDefenseEventWorldEntityModel.CombatId == model.CombatId && towerDefenseEventWorldEntityModel.PropertyId == model.PropertyId)
			{
				int? splineId = towerDefenseEventWorldEntityModel.SplineId;
				int? splineId2 = model.SplineId;
				if ((splineId.GetValueOrDefault() == splineId2.GetValueOrDefault() & splineId != null == (splineId2 != null)) && !(towerDefenseEventWorldEntityModel.AssetPath != model.AssetPath))
				{
					return;
				}
			}
			if (towerDefenseEventWorldEntityModel.SplineId != null && towerDefenseEventWorldEntityModel.SplineId.Value != 0)
			{
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(towerDefenseEventWorldEntityModel.SplineId.Value, model.Uid, EIdType.SimpleCombatId);
			}
			towerDefenseEventWorldEntityModel.CombatId = model.CombatId;
			towerDefenseEventWorldEntityModel.PropertyId = model.PropertyId;
			towerDefenseEventWorldEntityModel.SplineId = model.SplineId;
			towerDefenseEventWorldEntityModel.AssetPath = model.AssetPath;
			towerDefenseEventWorldEntityModel.BuffIdLayers = model.BuffIdLayers;
			ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntity(model.Uid, TowerDefenseEventRemoveReason.CombatDirty);
		}
		else
		{
			TowerDefenseEventWorldEntityModel towerDefenseEventWorldEntityModel2 = TowerDefenseEventEntityRedirectFilter.WorldEntityPool.Get() ?? TowerDefenseEventEntityRedirectFilter.WorldEntityPool.Create();
			towerDefenseEventWorldEntityModel2.Uid = model.Uid;
			towerDefenseEventWorldEntityModel2.CombatId = model.CombatId;
			towerDefenseEventWorldEntityModel2.PropertyId = model.PropertyId;
			towerDefenseEventWorldEntityModel2.AssetPath = model.AssetPath;
			towerDefenseEventWorldEntityModel2.SplineId = model.SplineId;
			towerDefenseEventWorldEntityModel2.BuffIdLayers = model.BuffIdLayers;
			this.InitializedEntities[model.Uid] = towerDefenseEventWorldEntityModel2;
		}
		USplineComponent spline = null;
		if (model.SplineId != null && model.SplineId.Value != 0)
		{
			spline = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(model.SplineId.Value, (int)model.Uid, EIdType.SimpleCombatId);
		}
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = model.Uid,
			SimpleCombatId = model.CombatId,
			AssetPath = model.AssetPath,
			PropertyId = model.PropertyId,
			Transform = transform,
			Spline = spline,
			Buffs = model.BuffIdLayers,
			Faction = faction,
			RenderActor = renderActor,
			FinishCallback = finishCallback
		});
	}

	// Token: 0x06016637 RID: 91703 RVA: 0x00636AA4 File Offset: 0x00634CA4
	protected override bool OnRemoveEntity(int creatureDataId)
	{
		ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo = ModelBase<TowerDefenseEventModel>.Instance.RemoveEntity((long)creatureDataId);
		if (towerDefenseEventCombatInfo != null)
		{
			this.DestroyEntity(towerDefenseEventCombatInfo);
			towerDefenseEventCombatInfo.Release();
		}
		return true;
	}

	// Token: 0x06016638 RID: 91704 RVA: 0x00636AD0 File Offset: 0x00634CD0
	private void DestroyEntity(ITowerDefenseEventCombatInfo model)
	{
		ITowerDefenseEventTrapInfo towerDefenseEventTrapInfo = model as ITowerDefenseEventTrapInfo;
		if (towerDefenseEventTrapInfo != null)
		{
			TsTowerDefenseEventActor trapActor = TsTowerDefenseEventActor.GetTrapActor((int)towerDefenseEventTrapInfo.Uid);
			if (trapActor != null)
			{
				trapActor.Destroy("TowerDefenseEventController.DestroyEntity");
			}
		}
		TowerDefenseEventWorldEntityModel towerDefenseEventWorldEntityModel;
		if (this.InitializedEntities.Remove(model.Uid, out towerDefenseEventWorldEntityModel))
		{
			TowerDefenseEventEntityRedirectFilter.WorldEntityPool.Put(towerDefenseEventWorldEntityModel);
			ControllerBase<KuroSimpleCombatController>.Instance.RemoveEntity(model.Uid, TowerDefenseEventRemoveReason.Destroy);
			if (towerDefenseEventWorldEntityModel.SplineId != null && towerDefenseEventWorldEntityModel.SplineId.Value != 0)
			{
				ModelBase<GameSplineModel>.Instance.ReleaseSpline(towerDefenseEventWorldEntityModel.SplineId.Value, model.Uid, EIdType.SimpleCombatId);
			}
		}
	}

	// Token: 0x06016639 RID: 91705 RVA: 0x00636B70 File Offset: 0x00634D70
	public override void Reset()
	{
		ModelBase<TowerDefenseEventModel>.Instance.GetAllEntities(this.CachedAllEntities);
		foreach (ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo in this.CachedAllEntities)
		{
			base.TryRemoveEntity(towerDefenseEventCombatInfo.Uid);
		}
		this.CachedAllEntities.Clear();
		TowerDefenseEventEntityModelBuilder.Clear();
		base.Reset();
		foreach (TowerDefenseEventWorldEntityModel value in this.InitializedEntities.Values)
		{
			TowerDefenseEventEntityRedirectFilter.WorldEntityPool.Put(value);
		}
		this.InitializedEntities.Clear();
		TowerDefenseEventEntityRedirectFilter.WorldEntityPool.Clear();
		this.PendingEntities.Clear();
	}

	// Token: 0x0601663A RID: 91706 RVA: 0x00636C5C File Offset: 0x00634E5C
	public unsafe void UpdateEntity(TrapDefenseEntityDataChangeNotify data)
	{
		ITowerDefenseEventCombatInfo entity = ModelBase<TowerDefenseEventModel>.Instance.GetEntity(Singleton<MathUtils>.Instance.LongToNumber(data.EntityId));
		if (entity == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefenseEvent;
			ELogAuthor author = ELogAuthor.XY;
			string message = "塔防实体数据变更失败: 未找到实体模型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", data.EntityId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (!(entity is ITowerDefenseEventConfigInfo))
		{
			return;
		}
		TrapDefenseComponentPb newComponentData = data.NewComponentData;
		TrapDefenseBuildingPbData buildingPbData = newComponentData.BuildingPbData;
		int? num;
		if (buildingPbData == null)
		{
			TrapDefenseMonsterPbData monsterPbData = newComponentData.MonsterPbData;
			if (monsterPbData == null)
			{
				TrapDefenseGoldenCoinPbData goldenCoinPbData = newComponentData.GoldenCoinPbData;
				if (goldenCoinPbData == null)
				{
					TrapDefenseSpecialCellPbData specialCellPbData = newComponentData.SpecialCellPbData;
					num = ((specialCellPbData != null) ? new int?(specialCellPbData.ConfigId) : null);
				}
				else
				{
					num = new int?(goldenCoinPbData.ConfigId);
				}
			}
			else
			{
				num = new int?(monsterPbData.ConfigId);
			}
		}
		else
		{
			num = new int?(buildingPbData.ConfigId);
		}
		int? num2 = num;
		if (num2 == null || num2.Value == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TowerDefenseEvent;
			ELogAuthor author2 = ELogAuthor.XY;
			string message2 = "塔防实体数据变更失败: 未找到配置ID";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", data.EntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		ITowerDefenseEventCombatInfo towerDefenseEventCombatInfo = entity.Clone();
		(towerDefenseEventCombatInfo as ITowerDefenseEventConfigInfo).ConfigId = num2.Value;
		if (newComponentData.BuildingPbData != null)
		{
			ITowerDefenseEventTrapBaseInfo towerDefenseEventTrapBaseInfo = towerDefenseEventCombatInfo as ITowerDefenseEventTrapBaseInfo;
			if (towerDefenseEventTrapBaseInfo != null)
			{
				towerDefenseEventTrapBaseInfo.Level = newComponentData.BuildingPbData.BattleLevel;
				towerDefenseEventTrapBaseInfo.DeconstructReturn = newComponentData.BuildingPbData.DeconstructReturn;
			}
		}
		string text = TowerDefenseEventConfig.FillUpModelInfo(towerDefenseEventCombatInfo, true);
		if (text != null)
		{
			towerDefenseEventCombatInfo.Release();
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.TowerDefenseEvent;
			ELogAuthor author3 = ELogAuthor.XY;
			string message3 = "塔防实体数据变更失败: " + text;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureDataId", entity.Uid);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("configId", num2);
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		entity.Update(towerDefenseEventCombatInfo);
		towerDefenseEventCombatInfo.Release();
		if (ModelBase<GameModeModel>.Instance.MapDone)
		{
			this.InstantiateEntity(entity);
		}
	}

	// Token: 0x0601663B RID: 91707 RVA: 0x00636E68 File Offset: 0x00635068
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<AKSC_Entity> OnSpecialCellTypeCreate(ITowerDefenseEventCombatInfo model)
	{
		ITowerDefenseEventSpecialCellBaseInfo towerDefenseEventSpecialCellBaseInfo = model as ITowerDefenseEventSpecialCellBaseInfo;
		if (towerDefenseEventSpecialCellBaseInfo == null)
		{
			return null;
		}
		if (towerDefenseEventSpecialCellBaseInfo.CellType == 1)
		{
			return this.OnLandFireCellCreate(model);
		}
		return null;
	}

	// Token: 0x0601663C RID: 91708 RVA: 0x00636E94 File Offset: 0x00635094
	private Action<AKSC_Entity> OnLandFireCellCreate(ITowerDefenseEventCombatInfo model)
	{
		TowerDefenseEventEntityRedirectFilter.<>c__DisplayClass14_0 CS$<>8__locals1 = new TowerDefenseEventEntityRedirectFilter.<>c__DisplayClass14_0();
		CS$<>8__locals1.model = model;
		ITowerDefenseEventCombatInfo entity = ModelBase<TowerDefenseEventModel>.Instance.GetEntity(CS$<>8__locals1.model.OwnerId);
		Dictionary<ETowerDefenseEventCombatExtraInfoType, CombatExtraInfoBase> extraInfo = (entity != null) ? entity.ExtraInfo : null;
		CS$<>8__locals1.model.ExtraInfo = extraInfo;
		return new Action<AKSC_Entity>(CS$<>8__locals1.<OnLandFireCellCreate>g__Callback|0);
	}

	// Token: 0x0400AD30 RID: 44336
	private static readonly Pool<TowerDefenseEventWorldEntityModel> WorldEntityPool = new Pool<TowerDefenseEventWorldEntityModel>(100, () => new TowerDefenseEventWorldEntityModel(), null);

	// Token: 0x0400AD31 RID: 44337
	private readonly List<ITowerDefenseEventCombatInfo> PendingEntities = new List<ITowerDefenseEventCombatInfo>();

	// Token: 0x0400AD32 RID: 44338
	private readonly List<ITowerDefenseEventCombatInfo> CachedAllEntities = new List<ITowerDefenseEventCombatInfo>();

	// Token: 0x0400AD33 RID: 44339
	private readonly Dictionary<long, TowerDefenseEventWorldEntityModel> InitializedEntities = new Dictionary<long, TowerDefenseEventWorldEntityModel>();
}
