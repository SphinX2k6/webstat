using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000F44 RID: 3908
[NullableContext(2)]
[Nullable(0)]
public class KscSubControllerBase
{
	// Token: 0x17000749 RID: 1865
	// (get) Token: 0x060061D0 RID: 25040 RVA: 0x001870D8 File Offset: 0x001852D8
	public KscSubModelBase Model
	{
		get
		{
			return this.SubModel;
		}
	}

	// Token: 0x060061D1 RID: 25041 RVA: 0x001870E0 File Offset: 0x001852E0
	public void Init(EKscGameplayType kscGameplayType)
	{
		this.CreateModel();
		this.Model.KscGameplayType = kscGameplayType;
		this.OnInit();
	}

	// Token: 0x060061D2 RID: 25042 RVA: 0x001870FA File Offset: 0x001852FA
	public void InitMap()
	{
		this.Model.Init();
		this.Model.KscInitState = EKscInitState.InitMap;
		this.InitConstVar();
		this.InitPropertyConfigs();
		this.InitEntityAndSkillDt();
		this.InitEntityFilter();
		this.OnInitMap();
		this.AddEvents();
	}

	// Token: 0x060061D3 RID: 25043 RVA: 0x00187138 File Offset: 0x00185338
	[return: TupleElementNames(new string[]
	{
		"Name",
		"Promise"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public virtual ValueTuple<string, CustomPromise<bool>>? OnPreload()
	{
		CustomPromise<bool> promise = new CustomPromise<bool>();
		this.PreloadAsync().ContinueWith(delegate()
		{
			promise.SetResult(true);
		}).Forget(delegate(Exception error)
		{
			if (error != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.CombatInfo;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "Preload异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", error.Message);
				instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.CombatInfo;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "Preload异常";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", error);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			promise.SetResult(false);
		}, true);
		return new ValueTuple<string, CustomPromise<bool>>?(new ValueTuple<string, CustomPromise<bool>>("KSC Preload", promise));
	}

	// Token: 0x060061D4 RID: 25044 RVA: 0x00187194 File Offset: 0x00185394
	public virtual UniTask PreloadAsync()
	{
		KscSubControllerBase.<PreloadAsync>d__8 <PreloadAsync>d__;
		<PreloadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadAsync>d__.<>4__this = this;
		<PreloadAsync>d__.<>1__state = -1;
		<PreloadAsync>d__.<>t__builder.Start<KscSubControllerBase.<PreloadAsync>d__8>(ref <PreloadAsync>d__);
		return <PreloadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060061D5 RID: 25045 RVA: 0x001871D7 File Offset: 0x001853D7
	public void MapLoaded()
	{
		this.Model.KscInitState = EKscInitState.MapLoad;
		this.StartEngine();
		this.LastTimeDilation = 1f;
		this.InitDamageConfigs();
		this.OnMapLoaded();
	}

	// Token: 0x060061D6 RID: 25046 RVA: 0x00187202 File Offset: 0x00185402
	public void WorldDone()
	{
		this.Model.KscInitState = EKscInitState.WorldDone;
		this.OnWorldDone();
		this.InitHeadStateManagerRes();
		this.AddKscPlayerEntity();
	}

	// Token: 0x060061D7 RID: 25047 RVA: 0x00187222 File Offset: 0x00185422
	public void WorldReset()
	{
		this.ResetPlayerTurnRate();
		this.RemoveInputLayer();
		this.OnWorldReset();
		this.StopEngine();
	}

	// Token: 0x060061D8 RID: 25048 RVA: 0x0018723D File Offset: 0x0018543D
	public void ClearMap()
	{
		this.RemoveEvents();
		this.ResetEntityFilter();
		this.OnClearMap();
		this.ClearHeadState();
		this.Model.Clear();
	}

	// Token: 0x060061D9 RID: 25049 RVA: 0x00187264 File Offset: 0x00185464
	public void Tick(float delta)
	{
		if (Singleton<Time>.Instance.TimeDilation != this.LastTimeDilation)
		{
			this.LastTimeDilation = Singleton<Time>.Instance.TimeDilation;
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld != null)
			{
				kscWorld.SetWorldTimeDilation(this.LastTimeDilation);
			}
		}
		this.SyncPlayerTransform();
		this.HandleHeadHpInfos(delta);
		this.PushPlayerHp();
		this.OnTick(delta);
	}

	// Token: 0x060061DA RID: 25050 RVA: 0x001872C8 File Offset: 0x001854C8
	public void Clear()
	{
		this.OnClear();
	}

	// Token: 0x060061DB RID: 25051 RVA: 0x001872D0 File Offset: 0x001854D0
	public virtual bool IsTargetMap(int instSubType)
	{
		return false;
	}

	// Token: 0x060061DC RID: 25052 RVA: 0x001872D3 File Offset: 0x001854D3
	protected virtual void CreateModel()
	{
	}

	// Token: 0x060061DD RID: 25053 RVA: 0x001872D5 File Offset: 0x001854D5
	protected virtual void ClearModel()
	{
	}

	// Token: 0x060061DE RID: 25054 RVA: 0x001872D7 File Offset: 0x001854D7
	protected virtual void OnInit()
	{
	}

	// Token: 0x060061DF RID: 25055 RVA: 0x001872D9 File Offset: 0x001854D9
	protected virtual void OnInitMap()
	{
	}

	// Token: 0x060061E0 RID: 25056 RVA: 0x001872DB File Offset: 0x001854DB
	protected virtual void OnMapLoaded()
	{
	}

	// Token: 0x060061E1 RID: 25057 RVA: 0x001872DD File Offset: 0x001854DD
	protected virtual void OnWorldDone()
	{
	}

	// Token: 0x060061E2 RID: 25058 RVA: 0x001872DF File Offset: 0x001854DF
	protected virtual void OnWorldReset()
	{
	}

	// Token: 0x060061E3 RID: 25059 RVA: 0x001872E1 File Offset: 0x001854E1
	protected virtual void OnClearMap()
	{
	}

	// Token: 0x060061E4 RID: 25060 RVA: 0x001872E3 File Offset: 0x001854E3
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060061E5 RID: 25061 RVA: 0x001872E5 File Offset: 0x001854E5
	protected virtual void OnClear()
	{
	}

	// Token: 0x060061E6 RID: 25062 RVA: 0x001872E7 File Offset: 0x001854E7
	public virtual void OnSystemInfoNotify()
	{
	}

	// Token: 0x060061E7 RID: 25063 RVA: 0x001872E9 File Offset: 0x001854E9
	protected virtual void AddEvents()
	{
	}

	// Token: 0x060061E8 RID: 25064 RVA: 0x001872EB File Offset: 0x001854EB
	protected virtual void RemoveEvents()
	{
	}

	// Token: 0x060061E9 RID: 25065 RVA: 0x001872ED File Offset: 0x001854ED
	protected virtual UClass GetKscWorldClass()
	{
		return null;
	}

	// Token: 0x060061EA RID: 25066 RVA: 0x001872F0 File Offset: 0x001854F0
	protected virtual void UnregisterCollisionAlgorithm()
	{
		if (this.GetCollisionAlgorithmConfig() != null)
		{
			ControllerBase<KuroFastCollisionController>.Instance.DestroyAlgorithm(this.Model.KfcAlgorithm);
		}
	}

	// Token: 0x060061EB RID: 25067 RVA: 0x00187324 File Offset: 0x00185524
	protected virtual void RegisterCollisionAlgorithm()
	{
		KscCollisionAlgorithmConfig? collisionAlgorithmConfig = this.GetCollisionAlgorithmConfig();
		if (collisionAlgorithmConfig == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.HXY;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "玩法不使用KFC碰撞系统，跳过注册";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gameplayType", this.Model.GameplayType);
			KscLog.Info(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Model.KfcAlgorithm = ControllerBase<KuroFastCollisionController>.Instance.CreateAlgorithm(collisionAlgorithmConfig.Value.AlgorithmClass, collisionAlgorithmConfig.Value.TickEnabled);
	}

	// Token: 0x060061EC RID: 25068 RVA: 0x001873AC File Offset: 0x001855AC
	protected virtual KscCollisionAlgorithmConfig? GetCollisionAlgorithmConfig()
	{
		return new KscCollisionAlgorithmConfig?(new KscCollisionAlgorithmConfig
		{
			AlgorithmClass = UKuroFastCollisionAlgorithm_Grid.StaticClass().ToWeakClass(),
			TickEnabled = true
		});
	}

	// Token: 0x060061ED RID: 25069 RVA: 0x001873E8 File Offset: 0x001855E8
	protected virtual void InitBulletWorld()
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld != null)
		{
			kscWorld.SetKFCAlgorithm(this.Model.KfcAlgorithm);
		}
		ModelBase<BulletModel>.Instance.StartKuroBulletWorld(this.Model.KfcAlgorithm, false);
		ModelBase<BulletModel>.Instance.StartKscBullet();
	}

	// Token: 0x060061EE RID: 25070 RVA: 0x00187435 File Offset: 0x00185635
	protected virtual void ClearBulletWorld()
	{
		ModelBase<BulletModel>.Instance.StopKuroBulletWorld();
		ModelBase<BulletModel>.Instance.StopKscBullet();
	}

	// Token: 0x060061EF RID: 25071 RVA: 0x0018744B File Offset: 0x0018564B
	private void StartEngine()
	{
		this.RegisterCollisionAlgorithm();
		Singleton<KscEnv>.Instance.Start(this.GetKscWorldClass());
		ControllerBase<KuroSimpleCombatController>.Instance.StartKscHeadStateManager();
	}

	// Token: 0x060061F0 RID: 25072 RVA: 0x0018746D File Offset: 0x0018566D
	private void StopEngine()
	{
		this.UnregisterCollisionAlgorithm();
		ControllerBase<KuroSimpleCombatController>.Instance.StopKscHeadStateManager();
		Singleton<KscEnv>.Instance.Stop();
	}

	// Token: 0x060061F1 RID: 25073 RVA: 0x00187489 File Offset: 0x00185689
	[NullableContext(1)]
	public virtual void OnEntityRemoved(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> protoContexts)
	{
	}

	// Token: 0x060061F2 RID: 25074 RVA: 0x0018748B File Offset: 0x0018568B
	protected virtual void InitConstVar()
	{
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "ksc.damage.defense.const 1520.0", null);
	}

	// Token: 0x060061F3 RID: 25075 RVA: 0x001874A0 File Offset: 0x001856A0
	public virtual void InitPropertyConfigs()
	{
		if (this.Model == null)
		{
			return;
		}
		IReadOnlyList<KSCBaseProperty> configList = ConfigKSCBasePropertyByKscGameplayType.GetConfigList((int)this.Model.GameplayType, true);
		if (configList != null)
		{
			foreach (KSCBaseProperty value in configList)
			{
				this.Model.PropertyConfigs[value.Id] = value;
			}
		}
	}

	// Token: 0x060061F4 RID: 25076 RVA: 0x00187518 File Offset: 0x00185718
	[NullableContext(1)]
	public unsafe virtual void SetAttrs(AKSC_Entity entity, int propertyId, [Nullable(2)] Dictionary<int, int> attributeMap = null)
	{
		if (propertyId == 0)
		{
			return;
		}
		if (entity == null)
		{
			KscLog.EModule flag = KscLog.EModule.Attr;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "塔防属性设置失败:异常Entity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("propertyId", propertyId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Dictionary<EKSC_AttrType, float> attrsDefault = this.GetAttrsDefault(propertyId);
		if (attrsDefault == null || attrsDefault.Count <= 0)
		{
			KscLog.EModule flag2 = KscLog.EModule.Attr;
			ELogAuthor author2 = ELogAuthor.CFT;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "塔防属性设置失败:异常配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", entity.EntityId_);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("propertyId", propertyId);
			KscLog.Warn(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			KscLog.EModule flag3 = KscLog.EModule.Attr;
			ELogAuthor author3 = ELogAuthor.CFT;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "塔防属性设置成功";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityId", entity.EntityId_);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("propertyId", propertyId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("attrConfig", attrsDefault);
			KscLog.Debug(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		if (attributeMap != null)
		{
			using (Dictionary<EKSC_AttrType, float>.Enumerator enumerator = attrsDefault.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<EKSC_AttrType, float> keyValuePair = enumerator.Current;
					int key = (int)keyValuePair.Key;
					float value = keyValuePair.Value;
					int num2;
					float num = attributeMap.TryGetValue(key, out num2) ? ((float)num2) : value;
					if (key == 3)
					{
						int num4;
						float num5;
						float num3 = attributeMap.TryGetValue(2, out num4) ? ((float)num4) : (attrsDefault.TryGetValue(EKSC_AttrType.LifeMax, out num5) ? num5 : 0f);
						if (num3 > 0f && num3 < num)
						{
							entity.SetAttr((EKSC_AttrType)key, (int)num3);
							continue;
						}
					}
					entity.SetAttr((EKSC_AttrType)key, (int)num);
				}
				return;
			}
		}
		foreach (KeyValuePair<EKSC_AttrType, float> keyValuePair2 in attrsDefault)
		{
			entity.SetAttr(keyValuePair2.Key, (int)keyValuePair2.Value);
		}
	}

	// Token: 0x060061F5 RID: 25077 RVA: 0x00187774 File Offset: 0x00185974
	[NullableContext(1)]
	public virtual Dictionary<EKSC_AttrType, float> GetAttrsDefault(int propertyId)
	{
		KSCBaseProperty config;
		if (this.Model.PropertyConfigs.TryGetValue(propertyId, out config))
		{
			return KscUtil.GetAttrsDataByPropertyConfig(config);
		}
		return new Dictionary<EKSC_AttrType, float>();
	}

	// Token: 0x060061F6 RID: 25078 RVA: 0x001877A4 File Offset: 0x001859A4
	public virtual void InitDamageConfigs()
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld == null)
		{
			KscLog.Error(KscLog.EModule.Load, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防InitDamageIdConfig failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKSC_DamageId damageData = kscWorld.DamageData;
		if (damageData == null || !damageData.IsValid())
		{
			KscLog.Error(KscLog.EModule.Load, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防InitDamageIdConfig failed", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscLog.Debug(KscLog.EModule.Load, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "塔防InitDamageIdConfig ", default(ReadOnlySpan<ValueTuple<string, object>>));
		Dictionary<int, FKSCDamage> damageIds = this.Model.DamageIds;
		IReadOnlyList<KSCDamage> configList = ConfigKSCDamageByKscGameplayType.GetConfigList((int)this.Model.GameplayType, true);
		if (configList != null)
		{
			foreach (KSCDamage kscdamage in configList)
			{
				int num = (int)kscdamage.Id;
				FKSCDamage fkscdamage = new FKSCDamage();
				fkscdamage.DamageID = num;
				fkscdamage.CalculateType = (EKSC_CalculateType)kscdamage.CalculateType;
				fkscdamage.Element = (EKSC_Element)kscdamage.Element;
				fkscdamage.Amplify = (float)kscdamage.Amplify * 0.0001f;
				fkscdamage.RelatedProperty = (EKSC_AttrType)kscdamage.RelatedProperty;
				fkscdamage.CritAttrType = (EKSC_AttrType)kscdamage.CritAttrType;
				fkscdamage.Knocked = kscdamage.Knocked;
				damageIds[num] = fkscdamage;
				damageData.AddDamageData(num, fkscdamage);
			}
		}
	}

	// Token: 0x060061F7 RID: 25079 RVA: 0x00187928 File Offset: 0x00185B28
	protected virtual void InitEntityAndSkillDt()
	{
		KscUtil.LoadDt<FKSCEntityTableRow>(Singleton<KscEnv>.Instance.KscWorld, this.Model.GetEntityDtPath(), this.Model.EntityDataDt);
		KscUtil.LoadDt<FKSCSkillTableRow>(Singleton<KscEnv>.Instance.KscWorld, this.Model.GetSkillDtPath(), this.Model.SkillDataDt);
	}

	// Token: 0x060061F8 RID: 25080 RVA: 0x0018797F File Offset: 0x00185B7F
	protected void InitEntityFilter()
	{
		this.CreateEntityFilter();
		ControllerBase<CreatureController>.Instance.RegisterCreateEntityFilter(this.RedirectFilter);
	}

	// Token: 0x060061F9 RID: 25081 RVA: 0x00187997 File Offset: 0x00185B97
	protected virtual void CreateEntityFilter()
	{
		this.RedirectFilter = new KscEntityRedirectFilter();
	}

	// Token: 0x060061FA RID: 25082 RVA: 0x001879A4 File Offset: 0x00185BA4
	protected void ResetEntityFilter()
	{
		this.RedirectFilter.Reset();
		ControllerBase<CreatureController>.Instance.UnregisterCreateEntityFilter(this.RedirectFilter);
	}

	// Token: 0x060061FB RID: 25083 RVA: 0x001879C4 File Offset: 0x00185BC4
	protected virtual void AddKscPlayerEntity()
	{
		KscSubControllerBase.<>c__DisplayClass47_0 CS$<>8__locals1 = new KscSubControllerBase.<>c__DisplayClass47_0();
		CS$<>8__locals1.<>4__this = this;
		if (Singleton<KscEnv>.Instance.KscWorld == null)
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "Ksc尝试添加玩家角色,世界非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscSubControllerBase.<>c__DisplayClass47_0 CS$<>8__locals2 = CS$<>8__locals1;
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		CS$<>8__locals2.entityHandle = ((instance != null) ? instance.GetCurrentEntity : null);
		EntityHandle entityHandle = CS$<>8__locals1.entityHandle;
		if (entityHandle == null || !entityHandle.Valid)
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "Ksc尝试添加玩家角色,entity非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.CFT;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "Ksc尝试添加玩家角色";
		string item = "Player";
		EntityHandle entityHandle2 = CS$<>8__locals1.entityHandle;
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (entityHandle2 != null) ? new int?(entityHandle2.Id) : null);
		KscLog.Info(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		FTransformDouble actorTransform = CS$<>8__locals1.entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorTransform;
		ControllerBase<KuroSimpleCombatController>.Instance.AddEntityDt(CS$<>8__locals1.entityHandle.CreatureDataId, 1001, null, actorTransform, delegate(AKSC_Entity kscEntity)
		{
			CS$<>8__locals1.<>4__this.FinishPlayerEntityCreated(kscEntity, CS$<>8__locals1.entityHandle.CreatureDataId);
		});
	}

	// Token: 0x060061FC RID: 25084 RVA: 0x00187AF0 File Offset: 0x00185CF0
	[NullableContext(1)]
	private void FinishPlayerEntityCreated(AKSC_Entity kscEntity, long creatureDataId)
	{
		this.Model.SetKscPlayerEntity(kscEntity, creatureDataId);
		this.OnPlayerEntityCreated();
		this.AddInputLayer();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnKscPlayerCreate);
	}

	// Token: 0x060061FD RID: 25085 RVA: 0x00187B1C File Offset: 0x00185D1C
	[NullableContext(1)]
	private unsafe bool TryAddGmPlayerEntityByConfig(EntityHandle entityHandle, IKscGmPlayerEntityParam param)
	{
		SimpleCombatDetailConfig? config = ConfigSimpleCombatDetailConfigBySimpleCombatIdAndSubTypeId.GetConfig(param.SimpleCombatId, param.SubTypeId, true);
		if (config == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "Ksc添加玩家角色失败,SimpleCombatDetailConfig不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			KscLog.Warn(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		string daPath = config.Value.DaPath;
		if (string.IsNullOrEmpty(daPath))
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.CFT;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "Ksc添加玩家角色失败,配置DaPath非法";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PrefabPath", config.Value.PrefabPath);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("DaPath", daPath);
			KscLog.Warn(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
			return false;
		}
		KscLog.EModule flag3 = KscLog.EModule.Common;
		ELogAuthor author3 = ELogAuthor.CFT;
		UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
		string log3 = "Ksc添加玩家角色使用SimpleCombatDetailConfig";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("PropertyId", config.Value.PropertyId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("DaPath", daPath);
		KscLog.Info(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
		FTransformDouble actorTransform = entityHandle.Entity.GetComponent<CharacterActorComponent>().ActorTransform;
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = entityHandle.CreatureDataId,
			SimpleCombatId = param.SimpleCombatId,
			AssetPath = daPath,
			PropertyId = config.Value.PropertyId,
			Transform = actorTransform,
			FinishCallback = delegate(AKSC_Entity kscEntity)
			{
				this.FinishPlayerEntityCreated(kscEntity, entityHandle.CreatureDataId);
			}
		});
		return true;
	}

	// Token: 0x060061FE RID: 25086 RVA: 0x00187DB6 File Offset: 0x00185FB6
	public virtual void OnPlayerEntityCreated()
	{
		this.SyncPlayerTransform();
		this.ApplyPlayerTurnRate();
	}

	// Token: 0x060061FF RID: 25087 RVA: 0x00187DC4 File Offset: 0x00185FC4
	protected virtual bool AddInputLayer()
	{
		return false;
	}

	// Token: 0x06006200 RID: 25088 RVA: 0x00187DC7 File Offset: 0x00185FC7
	protected virtual bool RemoveInputLayer()
	{
		return false;
	}

	// Token: 0x06006201 RID: 25089 RVA: 0x00187DCA File Offset: 0x00185FCA
	protected virtual void SyncPlayerTransform()
	{
		KscEntityHandle possessedPlayer = this.GetPossessedPlayer();
		if (possessedPlayer == null)
		{
			return;
		}
		possessedPlayer.SyncEntityLocation();
	}

	// Token: 0x06006202 RID: 25090 RVA: 0x00187DDC File Offset: 0x00185FDC
	private void ApplyPlayerTurnRate()
	{
		KscSubModelBase model = this.Model;
		object obj;
		if (model == null)
		{
			obj = null;
		}
		else
		{
			AKSC_Entity kscPlayerEntity = model.KscPlayerEntity;
			obj = ((kscPlayerEntity != null) ? kscPlayerEntity.DaEntity_ : null);
		}
		UKSC_DA_Entity_Player uksc_DA_Entity_Player = obj as UKSC_DA_Entity_Player;
		if (uksc_DA_Entity_Player == null)
		{
			return;
		}
		float turnRateScale = uksc_DA_Entity_Player.TurnRateScale;
		if (!float.IsFinite(turnRateScale) || turnRateScale <= 0f)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.HCW;
			UObject obj2 = null;
			string log = "ApplyPlayerTurnRate: TurnRateScale非法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("turnRate", turnRateScale);
			KscLog.Error(flag, author, obj2, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (Singleton<MathUtils>.Instance.IsNearlyEqual(1.0, (double)turnRateScale, null))
		{
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		BaseMoveComponent baseMoveComponent;
		if (entityHandle == null)
		{
			baseMoveComponent = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			baseMoveComponent = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		BaseMoveComponent baseMoveComponent2 = baseMoveComponent;
		if (baseMoveComponent2 == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.HCW, null, "ApplyPlayerTurnRate: 获取MoveComp失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		baseMoveComponent2.SetTurnRate(turnRateScale);
	}

	// Token: 0x06006203 RID: 25091 RVA: 0x00187EBF File Offset: 0x001860BF
	private void ResetPlayerTurnRate()
	{
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		object obj;
		if (entityHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.ResetTurnRate();
	}

	// Token: 0x06006204 RID: 25092 RVA: 0x00187EF4 File Offset: 0x001860F4
	private KscEntityHandle GetPossessedPlayer()
	{
		KscSubModelBase model = this.Model;
		AKSC_Entity aksc_Entity = (model != null) ? model.KscPlayerEntity : null;
		if (aksc_Entity == null)
		{
			return null;
		}
		KscSubModelBase model2 = this.Model;
		KscEntityHandle result;
		if (model2 == null || !model2.KscEntities.TryGetValue(aksc_Entity.EntityId_, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06006205 RID: 25093 RVA: 0x00187F40 File Offset: 0x00186140
	protected virtual EntityHandle GetPossessedPlayerEntity()
	{
		KscEntityHandle possessedPlayer = this.GetPossessedPlayer();
		long? num = (possessedPlayer != null) ? new long?(possessedPlayer.CreatureDataId) : null;
		if (num != null && num.GetValueOrDefault() != 0L && possessedPlayer.Valid)
		{
			return ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
		}
		return null;
	}

	// Token: 0x06006206 RID: 25094 RVA: 0x00187F9C File Offset: 0x0018619C
	protected UniTask PreloadHeadStateRes()
	{
		KscSubControllerBase.<PreloadHeadStateRes>d__62 <PreloadHeadStateRes>d__;
		<PreloadHeadStateRes>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PreloadHeadStateRes>d__.<>4__this = this;
		<PreloadHeadStateRes>d__.<>1__state = -1;
		<PreloadHeadStateRes>d__.<>t__builder.Start<KscSubControllerBase.<PreloadHeadStateRes>d__62>(ref <PreloadHeadStateRes>d__);
		return <PreloadHeadStateRes>d__.<>t__builder.Task;
	}

	// Token: 0x06006207 RID: 25095 RVA: 0x00187FE0 File Offset: 0x001861E0
	protected virtual UniTask LoadHeadStateCurve()
	{
		KscSubControllerBase.<LoadHeadStateCurve>d__63 <LoadHeadStateCurve>d__;
		<LoadHeadStateCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadHeadStateCurve>d__.<>4__this = this;
		<LoadHeadStateCurve>d__.<>1__state = -1;
		<LoadHeadStateCurve>d__.<>t__builder.Start<KscSubControllerBase.<LoadHeadStateCurve>d__63>(ref <LoadHeadStateCurve>d__);
		return <LoadHeadStateCurve>d__.<>t__builder.Task;
	}

	// Token: 0x06006208 RID: 25096 RVA: 0x00188024 File Offset: 0x00186224
	protected virtual UniTask LoadHeadStateDynamicBatchActor()
	{
		KscSubControllerBase.<LoadHeadStateDynamicBatchActor>d__64 <LoadHeadStateDynamicBatchActor>d__;
		<LoadHeadStateDynamicBatchActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadHeadStateDynamicBatchActor>d__.<>4__this = this;
		<LoadHeadStateDynamicBatchActor>d__.<>1__state = -1;
		<LoadHeadStateDynamicBatchActor>d__.<>t__builder.Start<KscSubControllerBase.<LoadHeadStateDynamicBatchActor>d__64>(ref <LoadHeadStateDynamicBatchActor>d__);
		return <LoadHeadStateDynamicBatchActor>d__.<>t__builder.Task;
	}

	// Token: 0x06006209 RID: 25097 RVA: 0x00188068 File Offset: 0x00186268
	protected virtual UniTask LoadHeadStateViewActor()
	{
		KscSubControllerBase.<LoadHeadStateViewActor>d__65 <LoadHeadStateViewActor>d__;
		<LoadHeadStateViewActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadHeadStateViewActor>d__.<>4__this = this;
		<LoadHeadStateViewActor>d__.<>1__state = -1;
		<LoadHeadStateViewActor>d__.<>t__builder.Start<KscSubControllerBase.<LoadHeadStateViewActor>d__65>(ref <LoadHeadStateViewActor>d__);
		return <LoadHeadStateViewActor>d__.<>t__builder.Task;
	}

	// Token: 0x0600620A RID: 25098 RVA: 0x001880AC File Offset: 0x001862AC
	protected void InitHeadStateManagerRes()
	{
		if (this.HeadStateScaleCurve != null && this.HeadStateViewActor != null && this.HeadStateDynamicBatchActor != null)
		{
			UKSC_HeadStateManager kscHeadStateManager = ControllerBase<KuroSimpleCombatController>.Instance.KscHeadStateManager;
			if (kscHeadStateManager == null)
			{
				return;
			}
			kscHeadStateManager.InitAllRes(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, this.HeadStateDynamicBatchActor, this.HeadStateViewActor, this.HeadStateScaleCurve);
		}
	}

	// Token: 0x0600620B RID: 25099 RVA: 0x00188104 File Offset: 0x00186304
	protected void HandleHeadHpInfos(float delta)
	{
		if (ControllerBase<KuroSimpleCombatController>.Instance.KscHeadStateManager != null)
		{
			global::Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
			UKSC_HeadStateManager kscHeadStateManager = ControllerBase<KuroSimpleCombatController>.Instance.KscHeadStateManager;
			float num = delta * (float)Singleton<TimeUtil>.Instance.Millisecond;
			FVectorDouble fvectorDouble = cameraLocation.ToUeVector(false);
			kscHeadStateManager.Update(num, fvectorDouble);
		}
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld == null)
		{
			return;
		}
		kscWorld.GetHeadHpInfos(ref this.HeadInfos);
		int num2 = this.HeadInfos.Num();
		KscSubModelBase model = this.Model;
		KscHeadStateData kscHeadStateData = (model != null) ? model.KscPlayerHeadStateData : null;
		if (kscHeadStateData == null)
		{
			for (int i = 0; i < num2; i++)
			{
				FKSC_HeadHpContext headInfo = this.HeadInfos.Get(i);
				this.OnHandleHeadHpInfo(headInfo);
			}
			return;
		}
		for (int j = 0; j < num2; j++)
		{
			FKSC_HeadHpContext fksc_HeadHpContext = this.HeadInfos.Get(j);
			if (fksc_HeadHpContext.EntityId == kscHeadStateData.EntityId)
			{
				this.SubModel.IsHpModify = true;
				this.OnHandlePlayerHeadHpInfo(kscHeadStateData, fksc_HeadHpContext);
			}
			else
			{
				this.OnHandleHeadHpInfo(fksc_HeadHpContext);
			}
		}
	}

	// Token: 0x0600620C RID: 25100 RVA: 0x0018820C File Offset: 0x0018640C
	protected virtual void PushPlayerHp()
	{
		KscSubModelBase model = this.Model;
		if (model == null || !model.IsHpModify)
		{
			return;
		}
		if ((double)this.Model.NextPlayerHpSyncTime > Singleton<Time>.Instance.FlowTime)
		{
			return;
		}
		if (this.Model.KscPlayerCreatureDataId == 0L)
		{
			return;
		}
		ControllerBase<KuroSimpleCombatController>.Instance.PushSimpleCombatEntityHp(this.Model.KscPlayerCreatureDataId, (float)this.Model.KscPlayerHeadStateData.Hp, (float)this.Model.KscPlayerHeadStateData.MaxHp);
		this.SubModel.IsHpModify = false;
		this.Model.NextPlayerHpSyncTime = (float)Singleton<Time>.Instance.FlowTime + 1000f;
	}

	// Token: 0x0600620D RID: 25101 RVA: 0x001882B8 File Offset: 0x001864B8
	[NullableContext(1)]
	protected virtual void OnHandlePlayerHeadHpInfo(KscHeadStateData kscPlayerHeadStateData, FKSC_HeadHpContext headInfo)
	{
		if (headInfo.ActionType == EKSC_HeadHpContextType.Add || headInfo.ActionType == EKSC_HeadHpContextType.Update)
		{
			kscPlayerHeadStateData.MaxHp = headInfo.MaxHp;
			kscPlayerHeadStateData.Hp = headInfo.CurHp;
			kscPlayerHeadStateData.Shield = headInfo.Shield;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnKscPlayerHpChanged);
	}

	// Token: 0x0600620E RID: 25102 RVA: 0x0018830C File Offset: 0x0018650C
	[NullableContext(1)]
	protected virtual void OnHandleHeadHpInfo(FKSC_HeadHpContext headInfo)
	{
		KscLog.Warn(KscLog.EModule.Common, ELogAuthor.CFT, Singleton<KscEnv>.Instance.KscWorld, "推送的血条数据没有处理", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600620F RID: 25103 RVA: 0x0018833C File Offset: 0x0018653C
	protected void ClearHeadState()
	{
		this.HeadStateScaleCurve = null;
		AUIBaseActor headStateDynamicBatchActor = this.HeadStateDynamicBatchActor;
		if (headStateDynamicBatchActor != null && headStateDynamicBatchActor.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("Ksc.ClearHeadState", this.HeadStateDynamicBatchActor, null);
			this.HeadStateDynamicBatchActor = null;
		}
		AUIBaseActor headStateViewActor = this.HeadStateViewActor;
		if (headStateViewActor != null && headStateViewActor.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("Ksc.ClearHeadState", this.HeadStateViewActor, null);
			this.HeadStateViewActor = null;
		}
		this.HeadInfos.Empty(true);
	}

	// Token: 0x06006210 RID: 25104 RVA: 0x001883C0 File Offset: 0x001865C0
	[NullableContext(1)]
	public unsafe void GmAddPlayerEntity(IKscGmPlayerEntityParam param)
	{
		if (param.SimpleCombatId < 0 || param.SubTypeId < 0)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "Ksc尝试添加玩家角色,参数非法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			KscLog.Warn(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (Singleton<KscEnv>.Instance.KscWorld == null)
		{
			KscLog.EModule flag2 = KscLog.EModule.Common;
			ELogAuthor author2 = ELogAuthor.CFT;
			UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
			string log2 = "Ksc尝试添加玩家角色,世界非法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			KscLog.Warn(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		EntityHandle entityHandle = (instance != null) ? instance.GetCurrentEntity : null;
		if (entityHandle == null || !entityHandle.Valid)
		{
			KscLog.EModule flag3 = KscLog.EModule.Common;
			ELogAuthor author3 = ELogAuthor.CFT;
			UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "Ksc尝试添加玩家角色,entity非法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			KscLog.Warn(flag3, author3, kscWorld3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return;
		}
		KscLog.EModule flag4 = KscLog.EModule.Common;
		ELogAuthor author4 = ELogAuthor.CFT;
		UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
		string log4 = "Ksc尝试添加玩家角色";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Player", (entityHandle != null) ? new int?(entityHandle.Id) : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
		KscLog.Info(flag4, author4, kscWorld4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
		this.TryAddGmPlayerEntityByConfig(entityHandle, param);
	}

	// Token: 0x06006211 RID: 25105 RVA: 0x001885FC File Offset: 0x001867FC
	public virtual void GmPrintInfo()
	{
	}

	// Token: 0x04002EE7 RID: 12007
	private float LastTimeDilation = 1f;

	// Token: 0x04002EE8 RID: 12008
	protected KscSubModelBase SubModel;

	// Token: 0x04002EE9 RID: 12009
	public KscEntityRedirectFilter RedirectFilter;

	// Token: 0x04002EEA RID: 12010
	[Nullable(1)]
	protected TArray<FKSC_HeadHpContext> HeadInfos = new TArray<FKSC_HeadHpContext>();

	// Token: 0x04002EEB RID: 12011
	protected UCurveFloat HeadStateScaleCurve;

	// Token: 0x04002EEC RID: 12012
	protected AUIBaseActor HeadStateDynamicBatchActor;

	// Token: 0x04002EED RID: 12013
	protected AUIBaseActor HeadStateViewActor;
}
