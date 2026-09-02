using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.NPC.GPUNPC;
using AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003199 RID: 12697
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class CrowdAiController : ControllerBase<CrowdAiController>
{
	// Token: 0x170023CB RID: 9163
	// (get) Token: 0x0601A561 RID: 107873 RVA: 0x007C23C9 File Offset: 0x007C05C9
	public bool IsCrowdAiEnable
	{
		get
		{
			UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
			return crowdAiSubsystem != null && crowdAiSubsystem.IsValid() && this.CrowdAiSwitch;
		}
	}

	// Token: 0x0601A562 RID: 107874 RVA: 0x007C23E7 File Offset: 0x007C05E7
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601A563 RID: 107875 RVA: 0x007C23EC File Offset: 0x007C05EC
	protected override void OnTick(float delta)
	{
		float num = delta * 0.001f;
		this.HandleDelayRemoveActors(num);
		this.TryUpdateBoidActorSystemBounds((double)num);
		foreach (BP_CrowdAiBoidActorSystemBase_C bp_CrowdAiBoidActorSystemBase_C in this.BoidActorSystemPool)
		{
			UBakedBoneMeshComponent bakedBoneMeshComp = bp_CrowdAiBoidActorSystemBase_C.BakedBoneMeshComp;
			if (bakedBoneMeshComp != null)
			{
				bakedBoneMeshComp.KuroTickComponentOutside(num);
			}
		}
		AKuroCrowdAiManagerProxyActor proxyActor = this.ProxyActor;
		if (proxyActor == null)
		{
			return;
		}
		proxyActor.KuroTickActorOutside(num);
	}

	// Token: 0x0601A564 RID: 107876 RVA: 0x007C2470 File Offset: 0x007C0670
	protected override bool OnClear()
	{
		this.DisableCrowdAiSystem(true);
		return true;
	}

	// Token: 0x0601A565 RID: 107877 RVA: 0x007C247A File Offset: 0x007C067A
	protected void InitCrowdAiConfigByPath(string path)
	{
		if (path == "" || path == "None")
		{
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<BP_CrowdAiConfig_C>(path, delegate([Nullable(2)] BP_CrowdAiConfig_C asset, string _)
		{
			if (asset == null || !asset.IsValid())
			{
				return;
			}
			this.InitCrowdAiConfigByAsset(asset);
		}, 100, "js_undefined");
	}

	// Token: 0x0601A566 RID: 107878 RVA: 0x007C24B8 File Offset: 0x007C06B8
	protected void InitCrowdAiConfigByAsset(BP_CrowdAiConfig_C asset)
	{
		if (asset == null || !asset.IsValid())
		{
			return;
		}
		this.CrowdAiSubsystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroCrowdAiSubsystem.StaticClass()) as UKuroCrowdAiSubsystem);
		this.InitCrowdAiSubsystem(asset);
		this.InitRoleBoidParams(asset);
		int num = asset.Boid种类配置.Num();
		for (int i = 0; i < num; i++)
		{
			BP_Struct_CrowdAiBoidConfig config = asset.Boid种类配置.Get(i);
			if (!this.CreateBoidActorSystemFromConfig(config))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.NPC;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "CrowdAiActorSystem初始化错误!";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Index", i);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x0601A567 RID: 107879 RVA: 0x007C2564 File Offset: 0x007C0764
	protected bool CreateBoidActorSystemFromConfig(BP_Struct_CrowdAiBoidConfig config)
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null || !crowdAiSubsystem.IsValid())
		{
			return false;
		}
		GPUNPCData_C gpuNpcDa = config.GpuNpcDa;
		if (gpuNpcDa == null || !gpuNpcDa.IsValid())
		{
			return false;
		}
		this.TmpVector1.Set((double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS, (double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS, (double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS);
		BP_CrowdAiBoidActorSystemBase_C bp_CrowdAiBoidActorSystemBase_C = Singleton<ActorSystem>.Instance.Get(BP_CrowdAiBoidActorSystemBase_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_CrowdAiBoidActorSystemBase_C;
		bp_CrowdAiBoidActorSystemBase_C.SetActorTickEnabled(false);
		UBakedBoneMeshComponent bakedBoneMeshComp = bp_CrowdAiBoidActorSystemBase_C.BakedBoneMeshComp;
		if (bakedBoneMeshComp != null)
		{
			bakedBoneMeshComp.SetComponentTickEnabled(false);
		}
		UBakedBoneMeshComponent bakedBoneMeshComp2 = bp_CrowdAiBoidActorSystemBase_C.BakedBoneMeshComp;
		if (bakedBoneMeshComp2 != null)
		{
			FVector fvector = this.BoundsOrigin.ToUeVectorOld();
			FVector fvector2 = this.TmpVector1.ToUeVectorOld();
			FBoxSphereBounds fboxSphereBounds = new FBoxSphereBounds(ref fvector, ref fvector2, this.DEFAULT_ACTOR_SYSTEM_BOUNDS);
			bakedBoneMeshComp2.SetCustomBounds(fboxSphereBounds);
		}
		if (!this.InitBoidActorSystem(bp_CrowdAiBoidActorSystemBase_C, config))
		{
			Singleton<ActorSystem>.Instance.Put("CreateBoidActorSystemFromConfig初始化错误", bp_CrowdAiBoidActorSystemBase_C, null);
			return false;
		}
		this.BoidActorSystemPool.Add(bp_CrowdAiBoidActorSystemBase_C);
		return true;
	}

	// Token: 0x0601A568 RID: 107880 RVA: 0x007C2664 File Offset: 0x007C0864
	protected void InitCrowdAiSubsystem(BP_CrowdAiConfig_C asset)
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null || !crowdAiSubsystem.IsValid())
		{
			return;
		}
		this.CrowdAiSubsystem.GroupNavigationInterval = asset.组寻路间隔;
		this.CrowdAiSubsystem.GroupSplitRadius = asset.分组最大距离;
		this.CrowdAiSubsystem.PauseSeekMinDist = asset.停驻最小目标距离;
		this.CrowdAiSubsystem.PauseSeekMaxTime = asset.停驻计时时间;
		this.CrowdAiSubsystem.PauseSeekMaxSpeed = asset.停驻最大速度;
		this.CrowdAiSubsystem.bEnableTeleport = asset.启用传送;
		this.CrowdAiSubsystem.TeleportMinPlanarDist = asset.触发传送最小水平距离;
		this.CrowdAiSubsystem.TeleportMinVerticalDist = asset.触发传送最小垂直距离;
		this.CrowdAiSubsystem.PauseTeleportMaxPlanarSpeed = asset.暂停传送最大水平速度;
		this.CrowdAiSubsystem.TeleportMinTime = asset.传送最小计数时间;
		this.CrowdAiSubsystem.TeleportMaxTime = asset.传送最大计数时间;
		this.CrowdAiSubsystem.TeleportTargetMaxRadius = asset.传送目标最大半径;
		this.CrowdAiSubsystem.TeleportTargetMinRadius = asset.传送目标最小半径;
		this.CrowdAiSubsystem.TeleportTryCount = asset.最大尝试寻点次数;
		this.CrowdAiSubsystem.bEnableFollowLimitation = asset.启用跟随区域限制;
		this.CrowdAiSubsystem.FanWingEdgesAngle = asset.跟随扇形区域夹角;
		this.CrowdAiSubsystem.FanWingEdgesLen = asset.跟随扇形区域两边长度;
		this.CrowdAiSubsystem.FanBottomEdgeHalfLen = asset.跟随扇形区域底边半长;
		this.CrowdAiSubsystem.FanBottomEdgeDistToWatchingBoid = asset.跟随扇形区域底边距离;
		this.CrowdAiSubsystem.bStickToGround = asset.启用Navmesh贴地修正;
		this.CrowdAiSubsystem.BornDelayMaxTime = asset.出生最大随机延迟时间;
		this.CrowdAiSubsystem.DestroyDelayMaxTime = asset.销毁最大随机延迟时间;
		this.ProxyActor = this.GetNewProxyActor();
		this.ProxyActor.SetActorTickEnabled(false);
		this.ProxyActor.SetEnableParallelUpdate(this.UseParallelUpdate);
	}

	// Token: 0x0601A569 RID: 107881 RVA: 0x007C2828 File Offset: 0x007C0A28
	protected void InitRoleBoidParams(BP_CrowdAiConfig_C asset)
	{
		this.RoleParams = new RoleBoidParams();
		this.RoleParams.MinRadius = asset.玩家移动半径;
		this.RoleParams.MaxRadius = asset.玩家待机半径;
		this.RoleParams.MaxRadiusChangeTime = asset.玩家半径变化时间;
	}

	// Token: 0x0601A56A RID: 107882 RVA: 0x007C2868 File Offset: 0x007C0A68
	protected bool InitBoidActorSystem(BP_CrowdAiBoidActorSystemBase_C actorSystem, BP_Struct_CrowdAiBoidConfig config)
	{
		actorSystem.Radius = config.半径;
		actorSystem.HalfHeight = config.半高;
		actorSystem.RelativeTrans = config.相对变换;
		actorSystem.MaxSpeed = config.最大速度;
		actorSystem.MaxAccel = config.最大加速度;
		actorSystem.GroundFriction = config.地面转向摩擦力;
		actorSystem.MovingRadiusFactor = config.移动半径缩放系数;
		actorSystem.WalkMinSpeed = config.移动表现阈值速度;
		actorSystem.IdleMaxSpeed = config.待机表现阈值速度;
		actorSystem.TurnInterpSpeed = config.转向插值速度;
		actorSystem.IdlePerformMinCD = config.待机表演最小冷却时间;
		actorSystem.IdlePerformMaxCD = config.待机表演最大冷却时间;
		actorSystem.IdlePerformMaxPortion = config.待机表演最大比例;
		actorSystem.FleeRadius = config.斥力额外半径;
		actorSystem.MovingFleeRadiusFactor = config.移动斥力额外半径缩放系数;
		actorSystem.ArrivalRadius = config.临近目标减速距离;
		actorSystem.MinDistToNavEdge = config.边界空气墙距离;
		actorSystem.ExtraQueryOffset = config.额外探测距离;
		actorSystem.AnimSequenceConfig = config.动画配置;
		actorSystem.AnimStateConfig = config.状态配置;
		actorSystem.MaterialEffectWithTextureConfig = config.材质贴图DA配置;
		actorSystem.Data = config.GpuNpcDa;
		return actorSystem.InitGpuNpc();
	}

	// Token: 0x0601A56B RID: 107883 RVA: 0x007C2984 File Offset: 0x007C0B84
	[NullableContext(2)]
	public void EnableCrowdAiSystemByConfigPath(string path = null)
	{
		if (path == null)
		{
			path = this.SUN_SPIRIT_CONFIG_PATH;
		}
		if (this.CrowdAiSwitch)
		{
			return;
		}
		this.CrowdAiSwitch = true;
		this.BoundsOrigin.Reset();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null && baseCharacter.IsValid())
		{
			this.BoundsOrigin.DeepCopy(Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy);
			this.ToWorldRelativeLocation(this.BoundsOrigin);
		}
		this.InitCrowdAiConfigByPath(path);
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.YJX, "[KuroCrowdAi] 启用CrowdAiSystem", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnEnableCrowdAiSystem, true);
	}

	// Token: 0x0601A56C RID: 107884 RVA: 0x007C2A7C File Offset: 0x007C0C7C
	public void EnableCrowdAiSystemByConfigAsset(BP_CrowdAiConfig_C config)
	{
		if (this.CrowdAiSwitch)
		{
			return;
		}
		this.CrowdAiSwitch = true;
		this.BoundsOrigin.Reset();
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null && baseCharacter.IsValid())
		{
			this.BoundsOrigin.DeepCopy(Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy);
			this.ToWorldRelativeLocation(this.BoundsOrigin);
		}
		this.InitCrowdAiConfigByAsset(config);
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.YJX, "[KuroCrowdAi] 启用CrowdAiSystem", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnClearWorld));
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnEnableCrowdAiSystem, true);
	}

	// Token: 0x0601A56D RID: 107885 RVA: 0x007C2B68 File Offset: 0x007C0D68
	public void DisableCrowdAiSystem(bool bForce = false)
	{
		if (!this.CrowdAiSwitch)
		{
			return;
		}
		this.CrowdAiSwitch = false;
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.YJX, "[KuroCrowdAi] 关闭CrowdAiSystem", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnEnableCrowdAiSystem, false);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnClearWorld));
		foreach (int boidId in this.CrowdAiBoidIdSet)
		{
			this.DestroyCrowdAiBoid(boidId, bForce);
		}
		this.CrowdAiBoidIdSet.Clear();
		if (!bForce)
		{
			this.DelayRemovedProxyActorInfo = new DelayRemoveInfo(this.ProxyActor);
			this.DelayRemovedItemSet.Add(this.DelayRemovedProxyActorInfo);
			using (List<BP_CrowdAiBoidActorSystemBase_C>.Enumerator enumerator2 = this.BoidActorSystemPool.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					BP_CrowdAiBoidActorSystemBase_C actor = enumerator2.Current;
					this.DelayRemovedItemSet.Add(new DelayRemoveInfo(actor));
				}
				goto IL_1F8;
			}
		}
		Singleton<ActorSystem>.Instance.Put("DisableCrowdAiSystem", this.ProxyActor, null);
		foreach (BP_CrowdAiBoidActorSystemBase_C actor2 in this.BoidActorSystemPool)
		{
			Singleton<ActorSystem>.Instance.Put("DisableCrowdAiSystem", actor2, null);
		}
		foreach (DelayRemoveInfo delayRemoveInfo in this.DelayRemovedItemSet)
		{
			Singleton<ActorSystem>.Instance.Put("OnWorldDone", delayRemoveInfo.Actor, null);
		}
		this.DelayRemovedItemSet.Clear();
		this.DelayRemovedProxyActorInfo = null;
		IL_1F8:
		this.CurPlayerEntityId = 0;
		this.ProxyActor = null;
		this.BoidActorSystemPool.Clear();
	}

	// Token: 0x0601A56E RID: 107886 RVA: 0x007C2DBC File Offset: 0x007C0FBC
	public int SpawnCrowdAiBoid(int actorSystemIndex, global::Transform transform, bool force = true)
	{
		if (!this.IsCrowdAiEnable)
		{
			return 0;
		}
		if (actorSystemIndex >= this.BoidActorSystemPool.Count)
		{
			return 0;
		}
		AKuroCrowdAiBoidActorSystem akuroCrowdAiBoidActorSystem = this.BoidActorSystemPool[actorSystemIndex];
		FTransform ftransform = transform.ToUeTransformOld();
		int num = akuroCrowdAiBoidActorSystem.SpawnBoidActor(ftransform, force);
		if (num == 0)
		{
			return 0;
		}
		this.CrowdAiBoidIdSet.Add(num);
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter != null && baseCharacter.IsValid())
		{
			CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
			CharacterCrowdAiComponent characterCrowdAiComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterCrowdAiComponent>() : null;
			UKuroCrowdAiBoidComponent ukuroCrowdAiBoidComponent = (characterCrowdAiComponent != null) ? characterCrowdAiComponent.BoidComponent : null;
			int num2 = (ukuroCrowdAiBoidComponent != null) ? ukuroCrowdAiBoidComponent.BoidId : 0;
			if (num2 != 0)
			{
				this.CurPlayerEntityId = characterActorComponent.Entity.Id;
				UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
				if (crowdAiSubsystem != null)
				{
					crowdAiSubsystem.SetWatchingBoidAndJoinGroup(num, num2);
				}
			}
		}
		return num;
	}

	// Token: 0x0601A56F RID: 107887 RVA: 0x007C2E84 File Offset: 0x007C1084
	public int GetRandomExistBoidId()
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null || !crowdAiSubsystem.IsValid())
		{
			return 0;
		}
		List<int> array = new List<int>(this.CrowdAiBoidIdSet);
		return Singleton<MathUtils>.Instance.GetRandomItem<int>(array);
	}

	// Token: 0x0601A570 RID: 107888 RVA: 0x007C2EC4 File Offset: 0x007C10C4
	public bool DestroyCrowdAiBoid(int boidId, bool bForce = false)
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null || !crowdAiSubsystem.IsValid())
		{
			return false;
		}
		if (!this.CrowdAiBoidIdSet.Contains(boidId))
		{
			return false;
		}
		this.CrowdAiSubsystem.RemoveBoid(boidId, bForce);
		this.CrowdAiBoidIdSet.Remove(boidId);
		return true;
	}

	// Token: 0x0601A571 RID: 107889 RVA: 0x007C2F16 File Offset: 0x007C1116
	public bool HasCrowdAiBoid(int boidId)
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		return crowdAiSubsystem != null && crowdAiSubsystem.IsValid() && this.CrowdAiBoidIdSet.Contains(boidId);
	}

	// Token: 0x0601A572 RID: 107890 RVA: 0x007C2F3D File Offset: 0x007C113D
	public void NotifyBoidsAround()
	{
		if (this.CrowdAiSubsystem == null)
		{
			return;
		}
		this.CrowdAiSubsystem.NotifyBoidsAround();
	}

	// Token: 0x0601A573 RID: 107891 RVA: 0x007C2F54 File Offset: 0x007C1154
	public void NotifyBoidsMoveTo(global::Vector targetLoc)
	{
		if (this.CrowdAiSubsystem == null)
		{
			return;
		}
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		FVector fvector = targetLoc.ToUeVectorOld();
		crowdAiSubsystem.NotifyBoidsMoveTo(fvector);
	}

	// Token: 0x0601A574 RID: 107892 RVA: 0x007C2F7E File Offset: 0x007C117E
	public void EnableParallelUpdateCrowdAi(bool enable)
	{
		if (this.UseParallelUpdate == enable)
		{
			return;
		}
		this.UseParallelUpdate = enable;
		AKuroCrowdAiManagerProxyActor proxyActor = this.ProxyActor;
		if (proxyActor == null)
		{
			return;
		}
		proxyActor.SetEnableParallelUpdate(enable);
	}

	// Token: 0x0601A575 RID: 107893 RVA: 0x007C2FA2 File Offset: 0x007C11A2
	public void EnableCrowdAiDebugMode(bool enable)
	{
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null)
		{
			return;
		}
		crowdAiSubsystem.EnableDebugMode(enable);
	}

	// Token: 0x0601A576 RID: 107894 RVA: 0x007C2FB8 File Offset: 0x007C11B8
	public void UpdateDebugNavMeshEdges(double rangeDist)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
		if (characterActorComponent == null)
		{
			return;
		}
		global::Vector actorLocationProxy = characterActorComponent.ActorLocationProxy;
		global::Vector vector = global::Vector.Create(actorLocationProxy);
		global::Vector vector2 = global::Vector.Create(actorLocationProxy);
		global::Vector inB = global::Vector.Create(rangeDist, rangeDist, 500.0);
		vector.AdditionEqual(inB);
		vector2.SubtractionEqual(inB);
		FBox fbox = new FBox();
		fbox.Min = vector2.ToUeVectorOld();
		fbox.Max = vector.ToUeVectorOld();
		fbox.IsValid = 1;
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem == null)
		{
			return;
		}
		crowdAiSubsystem.UpdateDebugNavMeshEdges(fbox);
	}

	// Token: 0x0601A577 RID: 107895 RVA: 0x007C304C File Offset: 0x007C124C
	protected void ToWorldRelativeLocation(global::Vector inOut)
	{
		FIntVector worldOriginLocation = UGameplayStatics.GetWorldOriginLocation(GlobalData.World.GetWorld());
		inOut.X -= (double)worldOriginLocation.X;
		inOut.Y -= (double)worldOriginLocation.Y;
		inOut.Z -= (double)worldOriginLocation.Z;
	}

	// Token: 0x0601A578 RID: 107896 RVA: 0x007C30A8 File Offset: 0x007C12A8
	protected void TryUpdateBoidActorSystemBounds(double deltaSeconds)
	{
		if (this.BoidActorSystemPool.Count == 0)
		{
			this.BoundsUpdateCounter = 0.0;
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null || !baseCharacter.IsValid())
		{
			return;
		}
		this.BoundsUpdateCounter += deltaSeconds;
		if (this.BoundsUpdateCounter > this.BOUNDS_UPDATE_INTERVAL)
		{
			this.BoundsUpdateCounter = 0.0;
			this.BoundsOrigin.DeepCopy(Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy);
			this.ToWorldRelativeLocation(this.BoundsOrigin);
			this.TmpVector1.Set((double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS, (double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS, (double)this.DEFAULT_ACTOR_SYSTEM_BOUNDS);
			foreach (BP_CrowdAiBoidActorSystemBase_C bp_CrowdAiBoidActorSystemBase_C in this.BoidActorSystemPool)
			{
				UBakedBoneMeshComponent bakedBoneMeshComp = bp_CrowdAiBoidActorSystemBase_C.BakedBoneMeshComp;
				if (bakedBoneMeshComp != null)
				{
					FVector fvector = this.BoundsOrigin.ToUeVectorOld();
					FVector fvector2 = this.TmpVector1.ToUeVectorOld();
					FBoxSphereBounds fboxSphereBounds = new FBoxSphereBounds(ref fvector, ref fvector2, this.DEFAULT_ACTOR_SYSTEM_BOUNDS);
					bakedBoneMeshComp.SetCustomBounds(fboxSphereBounds);
				}
			}
		}
	}

	// Token: 0x0601A579 RID: 107897 RVA: 0x007C31D8 File Offset: 0x007C13D8
	protected AKuroCrowdAiManagerProxyActor GetNewProxyActor()
	{
		DelayRemoveInfo delayRemovedProxyActorInfo = this.DelayRemovedProxyActorInfo;
		bool flag;
		if (delayRemovedProxyActorInfo == null)
		{
			flag = false;
		}
		else
		{
			AActor actor = delayRemovedProxyActorInfo.Actor;
			flag = ((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			AKuroCrowdAiManagerProxyActor result = this.DelayRemovedProxyActorInfo.Actor as AKuroCrowdAiManagerProxyActor;
			this.DelayRemovedItemSet.Remove(this.DelayRemovedProxyActorInfo);
			this.DelayRemovedProxyActorInfo = null;
			return result;
		}
		return Singleton<ActorSystem>.Instance.Get(AKuroCrowdAiManagerProxyActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as AKuroCrowdAiManagerProxyActor;
	}

	// Token: 0x0601A57A RID: 107898 RVA: 0x007C3264 File Offset: 0x007C1464
	protected BP_CrowdAiBoidActorSystemBase_C GetNewActorSystem()
	{
		int num = (this.DelayRemovedProxyActorInfo != null) ? 2 : 1;
		if (this.DelayRemovedItemSet.Count >= num)
		{
			foreach (DelayRemoveInfo delayRemoveInfo in this.DelayRemovedItemSet)
			{
				if (delayRemoveInfo != this.DelayRemovedProxyActorInfo)
				{
					AActor actor = delayRemoveInfo.Actor;
					if (actor != null && actor.IsValid())
					{
						BP_CrowdAiBoidActorSystemBase_C bp_CrowdAiBoidActorSystemBase_C = delayRemoveInfo.Actor as BP_CrowdAiBoidActorSystemBase_C;
						if (bp_CrowdAiBoidActorSystemBase_C != null)
						{
							this.DelayRemovedItemSet.Remove(delayRemoveInfo);
							return bp_CrowdAiBoidActorSystemBase_C;
						}
					}
				}
			}
		}
		return Singleton<ActorSystem>.Instance.Get(BP_CrowdAiBoidActorSystemBase_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_CrowdAiBoidActorSystemBase_C;
	}

	// Token: 0x0601A57B RID: 107899 RVA: 0x007C3330 File Offset: 0x007C1530
	protected void HandleDelayRemoveActors(float deltaSeconds)
	{
		if (this.DelayRemovedItemSet.Count == 0)
		{
			return;
		}
		List<DelayRemoveInfo> list = new List<DelayRemoveInfo>();
		foreach (DelayRemoveInfo delayRemoveInfo in this.DelayRemovedItemSet)
		{
			delayRemoveInfo.Counter += (double)deltaSeconds;
			AActor actor = delayRemoveInfo.Actor;
			if (actor == null || !actor.IsValid() || delayRemoveInfo.Counter > this.DEFAULT_DELAY_REMOVE_TIME)
			{
				Singleton<ActorSystem>.Instance.Put("HandleDelayRemoveActors", delayRemoveInfo.Actor, null);
				list.Add(delayRemoveInfo);
			}
			else if (delayRemoveInfo != this.DelayRemovedProxyActorInfo)
			{
				BP_CrowdAiBoidActorSystemBase_C bp_CrowdAiBoidActorSystemBase_C = delayRemoveInfo.Actor as BP_CrowdAiBoidActorSystemBase_C;
				if (bp_CrowdAiBoidActorSystemBase_C != null)
				{
					UBakedBoneMeshComponent bakedBoneMeshComp = bp_CrowdAiBoidActorSystemBase_C.BakedBoneMeshComp;
					if (bakedBoneMeshComp != null)
					{
						bakedBoneMeshComp.KuroTickComponentOutside(deltaSeconds);
					}
				}
			}
		}
		foreach (DelayRemoveInfo delayRemoveInfo2 in list)
		{
			if (delayRemoveInfo2 == this.DelayRemovedProxyActorInfo)
			{
				this.DelayRemovedProxyActorInfo = null;
			}
			this.DelayRemovedItemSet.Remove(delayRemoveInfo2);
		}
		DelayRemoveInfo delayRemovedProxyActorInfo = this.DelayRemovedProxyActorInfo;
		if (delayRemovedProxyActorInfo == null)
		{
			return;
		}
		AActor actor2 = delayRemovedProxyActorInfo.Actor;
		if (actor2 == null)
		{
			return;
		}
		actor2.KuroTickActorOutside(deltaSeconds);
	}

	// Token: 0x0601A57C RID: 107900 RVA: 0x007C3488 File Offset: 0x007C1688
	protected unsafe void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (!this.IsCrowdAiEnable || this.CrowdAiBoidIdSet.Count == 0)
		{
			return;
		}
		WorldEntity entity = newEntity.Entity;
		CharacterCrowdAiComponent characterCrowdAiComponent = (entity != null) ? entity.GetComponent<CharacterCrowdAiComponent>() : null;
		UKuroCrowdAiBoidComponent ukuroCrowdAiBoidComponent = (characterCrowdAiComponent != null) ? characterCrowdAiComponent.BoidComponent : null;
		if (ukuroCrowdAiBoidComponent == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[KuroCrowdAi] 切换玩家实体，更换跟随对象";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("oldEntityId", (oldEntity != null) ? new int?(oldEntity.Id) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("newEntityId", newEntity.Id);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.CurPlayerEntityId = newEntity.Id;
		int boidId = ukuroCrowdAiBoidComponent.BoidId;
		TArray<int> tarray = new TArray<int>();
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem != null)
		{
			crowdAiSubsystem.GetAllGroupIds(ref tarray);
		}
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			this.CrowdAiSubsystem.ChangeGroupWatchingBoid(tarray.Get(i), boidId);
		}
		foreach (int boidId2 in this.CrowdAiBoidIdSet)
		{
			if (this.CrowdAiSubsystem.GetBoidGroupId(boidId2) == 0)
			{
				this.CrowdAiSubsystem.SetWatchingBoidAndJoinGroup(boidId2, boidId);
			}
		}
	}

	// Token: 0x0601A57D RID: 107901 RVA: 0x007C3604 File Offset: 0x007C1804
	protected void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		if (!this.IsCrowdAiEnable || this.CrowdAiBoidIdSet.Count == 0)
		{
			return;
		}
		if (this.CurPlayerEntityId != handle.Id)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.YJX;
		string message = "[KuroCrowdAi] 玩家实体销毁，取消所有Boid跟随";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", handle.Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		TArray<int> tarray = new TArray<int>();
		UKuroCrowdAiSubsystem crowdAiSubsystem = this.CrowdAiSubsystem;
		if (crowdAiSubsystem != null)
		{
			crowdAiSubsystem.GetAllGroupIds(ref tarray);
		}
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			this.CrowdAiSubsystem.ChangeGroupWatchingBoid(tarray.Get(i), 0);
		}
	}

	// Token: 0x0601A57E RID: 107902 RVA: 0x007C36AC File Offset: 0x007C18AC
	protected void OnClearWorld()
	{
		Singleton<Log>.Instance.Info(ELogModule.NPC, ELogAuthor.YJX, "[KuroCrowdAi] 切换地图清空数据", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.CrowdAiSubsystem = (UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroCrowdAiSubsystem.StaticClass()) as UKuroCrowdAiSubsystem);
		this.DisableCrowdAiSystem(true);
		this.CurPlayerEntityId = 0;
		this.ProxyActor = null;
		this.BoidActorSystemPool.Clear();
		this.DelayRemovedItemSet.Clear();
		this.DelayRemovedProxyActorInfo = null;
	}

	// Token: 0x0400D46D RID: 54381
	private readonly float DEFAULT_ACTOR_SYSTEM_BOUNDS = 100000f;

	// Token: 0x0400D46E RID: 54382
	private readonly double BOUNDS_UPDATE_INTERVAL = 3.0;

	// Token: 0x0400D46F RID: 54383
	private readonly double DEFAULT_DELAY_REMOVE_TIME = 10.0;

	// Token: 0x0400D470 RID: 54384
	private readonly string SUN_SPIRIT_CONFIG_PATH = "/Game/Aki/Character/NPC/GPUNPC/BP/CrowdAi/DA_SunSpiritConfig.DA_SunSpiritConfig";

	// Token: 0x0400D471 RID: 54385
	[Nullable(2)]
	public UKuroCrowdAiSubsystem CrowdAiSubsystem;

	// Token: 0x0400D472 RID: 54386
	public bool UseParallelUpdate;

	// Token: 0x0400D473 RID: 54387
	[Nullable(2)]
	protected AKuroCrowdAiManagerProxyActor ProxyActor;

	// Token: 0x0400D474 RID: 54388
	protected List<BP_CrowdAiBoidActorSystemBase_C> BoidActorSystemPool = new List<BP_CrowdAiBoidActorSystemBase_C>();

	// Token: 0x0400D475 RID: 54389
	protected HashSet<int> CrowdAiBoidIdSet = new HashSet<int>();

	// Token: 0x0400D476 RID: 54390
	protected bool CrowdAiSwitch;

	// Token: 0x0400D477 RID: 54391
	[Nullable(2)]
	public RoleBoidParams RoleParams;

	// Token: 0x0400D478 RID: 54392
	protected int CurPlayerEntityId;

	// Token: 0x0400D479 RID: 54393
	protected double BoundsUpdateCounter;

	// Token: 0x0400D47A RID: 54394
	protected global::Vector BoundsOrigin = global::Vector.Create();

	// Token: 0x0400D47B RID: 54395
	[Nullable(2)]
	protected DelayRemoveInfo DelayRemovedProxyActorInfo;

	// Token: 0x0400D47C RID: 54396
	protected HashSet<DelayRemoveInfo> DelayRemovedItemSet = new HashSet<DelayRemoveInfo>();

	// Token: 0x0400D47D RID: 54397
	protected global::Vector TmpVector1 = global::Vector.Create();
}
