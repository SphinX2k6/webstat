using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay.Common;

// Token: 0x02003196 RID: 12694
[NullableContext(1)]
[Nullable(0)]
public class PasserbyGeneratorComponent : EntityComponent
{
	// Token: 0x0601A558 RID: 107864 RVA: 0x007C1E1C File Offset: 0x007C001C
	protected unsafe override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
		PasserbyNpcSpawnComponent component = TdUtils.GetComponent<PasserbyNpcSpawnComponent>(this.CreatureDataComp.GetPbEntityInitData().ComponentsData, EConfigComponent.PasserbyNpcSpawnComponent);
		if (component == null || component.SpawnConfig.MinDistance == null || component.SpawnConfig.MinDistance.Value == 0)
		{
			this.NeedCheckRange = false;
			return true;
		}
		this.MinDistanceSquared = (double)(component.SpawnConfig.MinDistance.Value * component.SpawnConfig.MinDistance.Value);
		foreach (IPasserbyNpcSpline passerbyNpcSpline in component.MoveConfig.Routes)
		{
			int splineEntityId = passerbyNpcSpline.SplineEntityId;
			GameSplineComponent gameSplineComponent = new GameSplineComponent(splineEntityId);
			if (!gameSplineComponent.Initialize())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.NPC;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "行人生成器获取样条信息错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "PbDataId";
				CreatureDataComponent creatureDataComp = this.CreatureDataComp;
				ptr = new ValueTuple<string, object>(item, (creatureDataComp != null) ? new int?(creatureDataComp.GetPbDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplinePbDataId", splineEntityId);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else if (gameSplineComponent.GetNumberOfSplinePoints() != 0)
			{
				this.SplineInfos.Add(new SplineStateInfo(splineEntityId, gameSplineComponent.GetWorldLocationAtSplinePoint(0)));
			}
		}
		if (this.SplineInfos.Count == 0)
		{
			this.NeedCheckRange = false;
		}
		return true;
	}

	// Token: 0x0601A559 RID: 107865 RVA: 0x007C1FEC File Offset: 0x007C01EC
	protected override void OnTick(float delta)
	{
		if (!this.NeedCheckRange)
		{
			return;
		}
		foreach (SplineStateInfo splineStateInfo in this.SplineInfos)
		{
			if (this.IsNearestPlayerInRange(splineStateInfo.Location))
			{
				if (!splineStateInfo.InRange)
				{
					splineStateInfo.InRange = true;
					this.CreateAndSendRequest(splineStateInfo.PbDataId, true);
				}
			}
			else if (splineStateInfo.InRange)
			{
				splineStateInfo.InRange = false;
				this.CreateAndSendRequest(splineStateInfo.PbDataId, false);
			}
		}
	}

	// Token: 0x0601A55A RID: 107866 RVA: 0x007C208C File Offset: 0x007C028C
	private bool IsNearestPlayerInRange(global::Vector checkLocation)
	{
		double num = 3.402823466E+38;
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			num = this.GetMinPlayerDistSquared(checkLocation).Item2;
		}
		else
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter != null && baseCharacter.IsValid())
			{
				baseCharacter.CharacterActorComponent.ActorLocationProxy.Subtraction(checkLocation, this.VectorCache);
				num = this.VectorCache.SizeSquared2D();
			}
		}
		return num < this.MinDistanceSquared;
	}

	// Token: 0x0601A55B RID: 107867 RVA: 0x007C20FC File Offset: 0x007C02FC
	private unsafe void CreateAndSendRequest(int splineId, bool inRange)
	{
		AccessPasserbyNpcSpawnerRequest accessPasserbyNpcSpawnerRequest = AccessPasserbyNpcSpawnerRequest.Create();
		accessPasserbyNpcSpawnerRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
		accessPasserbyNpcSpawnerRequest.SplineConfigId = splineId;
		accessPasserbyNpcSpawnerRequest.IsSplneNotValid = inRange;
		Singleton<Net>.Instance.Call<AccessPasserbyNpcSpawnerResponse>(ERequestMessageId.AccessPasserbyNpcSpawnerRequest, accessPasserbyNpcSpawnerRequest, delegate(AccessPasserbyNpcSpawnerResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.NPC;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "请求行人生成器生成NPC失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
				string item = "CreatureId";
				BaseActorComponent actorComp = this.ActorComp;
				ptr = new ValueTuple<string, object>(item, (actorComp != null) ? new long?(actorComp.CreatureData.GetCreatureDataId()) : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineId", splineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ErrorCode", response.ErrorCode);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
		}, 0);
	}

	// Token: 0x0601A55C RID: 107868 RVA: 0x007C2174 File Offset: 0x007C0374
	[return: TupleElementNames(new string[]
	{
		"PlayerEntity",
		"MinDistSquared"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	private ValueTuple<EntityHandle, double> GetMinPlayerDistSquared(global::Vector selfLocation)
	{
		Dictionary<int, ScenePlayerData> scenePlayerDataMap = ModelBase<CreatureModel>.Instance.ScenePlayerDataMap;
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle item = null;
		double num = 3.402823466E+38;
		foreach (KeyValuePair<int, ScenePlayerData> keyValuePair in scenePlayerDataMap)
		{
			SceneTeamItem teamItem = instance.GetTeamItem((long)keyValuePair.Key, new GetTeamItemOptions
			{
				ParamType = ETeamParamType.PlayerId,
				IsControl = new bool?(true)
			});
			EntityHandle entityHandle = (teamItem != null) ? teamItem.EntityHandle : null;
			if (entityHandle != null)
			{
				entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorLocationProxy.Subtraction(selfLocation, this.VectorCache);
				double num2 = this.VectorCache.SizeSquared2D();
				if (num2 < num)
				{
					num = num2;
					item = entityHandle;
				}
			}
		}
		return new ValueTuple<EntityHandle, double>(item, num);
	}

	// Token: 0x0601A55D RID: 107869 RVA: 0x007C224C File Offset: 0x007C044C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		PasserbyGeneratorComponent passerbyGeneratorComponent = (PasserbyGeneratorComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (passerbyGeneratorComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComp"))
		{
			if (passerbyGeneratorComponent.CreatureDataComp == null)
			{
				this.CreatureDataComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SplineInfos") && passerbyGeneratorComponent.SplineInfos != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<SplineStateInfo>>(this.SplineInfos), "SplineInfos"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MinDistanceSquared"))
		{
			this.MinDistanceSquared = passerbyGeneratorComponent.MinDistanceSquared;
		}
		if (base.CanResetComponentProperty("NeedCheckRange"))
		{
			this.NeedCheckRange = passerbyGeneratorComponent.NeedCheckRange;
		}
		return !base.CanResetComponentProperty("VectorCache") || passerbyGeneratorComponent.VectorCache == null || base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.VectorCache), "VectorCache");
	}

	// Token: 0x0400D45F RID: 54367
	[Nullable(2)]
	private BaseActorComponent ActorComp;

	// Token: 0x0400D460 RID: 54368
	[Nullable(2)]
	private CreatureDataComponent CreatureDataComp;

	// Token: 0x0400D461 RID: 54369
	private readonly List<SplineStateInfo> SplineInfos = new List<SplineStateInfo>();

	// Token: 0x0400D462 RID: 54370
	private double MinDistanceSquared;

	// Token: 0x0400D463 RID: 54371
	private bool NeedCheckRange = true;

	// Token: 0x0400D464 RID: 54372
	private readonly global::Vector VectorCache = global::Vector.Create();
}
