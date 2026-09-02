using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.TypeScript.Game.NewWorld.Bullet.LogicDataClass;
using UnrealEngine;

// Token: 0x02002DE0 RID: 11744
[NullableContext(1)]
[Nullable(0)]
public class BulletActionLogicComponent : EntityComponent
{
	// Token: 0x17001F9D RID: 8093
	// (get) Token: 0x06017AD5 RID: 96981 RVA: 0x0069C835 File Offset: 0x0069AA35
	public bool ObstaclesDetect
	{
		get
		{
			return this.ObstaclesDetectInternal;
		}
	}

	// Token: 0x06017AD6 RID: 96982 RVA: 0x0069C840 File Offset: 0x0069AA40
	protected override bool OnStart()
	{
		BulletEntity bulletEntity = base.Entity as BulletEntity;
		this.BulletInfo = ((bulletEntity != null) ? bulletEntity.GetBulletInfo() : null);
		this.BulletInfo.ActionLogicComponent = this;
		this.BulletData = this.BulletInfo.BulletDataMain;
		this.BulletIsProcessByTime = (this.BulletData.Base.ContinuesCollision && (this.BulletInfo.CollisionInfo.IntervalMs > 0f || this.BulletData.Base.CollisionActiveDelay > 0f));
		List<LogicDataBase> gbDataList = this.BulletData.Execution.GbDataList;
		if (gbDataList != null && gbDataList.Count > 0)
		{
			foreach (LogicDataBase logicDataBase in gbDataList)
			{
				BulletLogicControllerBase bulletLogicControllerBase = this.NewController(logicDataBase);
				if (bulletLogicControllerBase != null)
				{
					if (logicDataBase.ExecuteStage == EBulletLogicStage.OnBegin)
					{
						if (this.OnBeginController == null)
						{
							this.OnBeginController = new List<BulletLogicControllerBase>();
						}
						this.OnBeginController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnDestroy)
					{
						if (this.OnDestroyController == null)
						{
							this.OnDestroyController = new List<BulletLogicControllerBase>();
						}
						this.OnDestroyController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnHit)
					{
						if (this.OnHitController == null)
						{
							this.OnHitController = new List<BulletLogicControllerBase>();
						}
						this.OnHitController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnRebound)
					{
						if (this.OnReboundController == null)
						{
							this.OnReboundController = new List<BulletLogicReboundController>();
						}
						this.OnReboundController.Add(bulletLogicControllerBase as BulletLogicReboundController);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnSupport)
					{
						if (this.OnSupportController == null)
						{
							this.OnSupportController = new List<BulletLogicControllerBase>();
						}
						this.OnSupportController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.ReplaceMove)
					{
						if (this.OnMovementController == null)
						{
							this.OnMovementController = new List<BulletLogicControllerBase>();
						}
						this.OnMovementController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnHitBullet)
					{
						if (this.OnHitBulletController == null)
						{
							this.OnHitBulletController = new List<BulletLogicControllerBase>();
						}
						this.OnHitBulletController.Add(bulletLogicControllerBase);
					}
					else if (logicDataBase.ExecuteStage == EBulletLogicStage.OnBulletCollision)
					{
						if (this.OnCollisionController == null)
						{
							this.OnCollisionController = new List<BulletLogicBulletCollisionController>();
						}
						this.OnCollisionController.Add(bulletLogicControllerBase as BulletLogicBulletCollisionController);
					}
					if (bulletLogicControllerBase.NeedTick)
					{
						if (this.OnTickController == null)
						{
							this.OnTickController = new List<BulletLogicControllerBase>();
						}
						this.OnTickController.Add(bulletLogicControllerBase);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06017AD7 RID: 96983 RVA: 0x0069CAE0 File Offset: 0x0069ACE0
	public void OnAfterInit()
	{
		if (this.OnBeginController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnBeginController)
			{
				bulletLogicControllerBase.OnInit();
				bulletLogicControllerBase.BulletLogicActionFromBase(null);
			}
		}
		if (this.OnDestroyController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase2 in this.OnDestroyController)
			{
				bulletLogicControllerBase2.OnInit();
			}
		}
		if (this.OnHitController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase3 in this.OnHitController)
			{
				bulletLogicControllerBase3.OnInit();
			}
		}
		if (this.OnReboundController != null)
		{
			foreach (BulletLogicReboundController bulletLogicReboundController in this.OnReboundController)
			{
				bulletLogicReboundController.OnInit();
			}
		}
		if (this.OnCollisionController != null)
		{
			foreach (BulletLogicBulletCollisionController bulletLogicBulletCollisionController in this.OnCollisionController)
			{
				bulletLogicBulletCollisionController.OnInit();
			}
		}
		if (this.OnSupportController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase4 in this.OnSupportController)
			{
				bulletLogicControllerBase4.OnInit();
			}
		}
		if (this.OnMovementController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase5 in this.OnMovementController)
			{
				bulletLogicControllerBase5.OnInit();
			}
		}
		if (this.OnHitBulletController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase6 in this.OnHitBulletController)
			{
				bulletLogicControllerBase6.OnInit();
			}
		}
	}

	// Token: 0x06017AD8 RID: 96984 RVA: 0x0069CD30 File Offset: 0x0069AF30
	protected override void OnTick(float delta)
	{
		if (!this.BulletInfo.IsInit)
		{
			return;
		}
		if (this.BulletIsProcessByTime && this.BulletInfo.CollisionInfo.HaveCharacterInBullet && this.OnHitController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnHitController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(null);
			}
		}
		if (!this.BulletInfo.NeedDestroy && this.OnTickController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase2 in this.OnTickController)
			{
				bulletLogicControllerBase2.Tick(delta);
			}
		}
	}

	// Token: 0x06017AD9 RID: 96985 RVA: 0x0069CE08 File Offset: 0x0069B008
	protected override bool OnEnd()
	{
		if (this.OnBeginController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnBeginController)
			{
				bulletLogicControllerBase.OnBulletDestroy();
			}
		}
		if (this.OnHitController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase2 in this.OnHitController)
			{
				bulletLogicControllerBase2.OnBulletDestroy();
			}
		}
		if (this.OnDestroyController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase3 in this.OnDestroyController)
			{
				bulletLogicControllerBase3.OnBulletDestroy();
			}
		}
		if (this.OnReboundController != null)
		{
			foreach (BulletLogicReboundController bulletLogicReboundController in this.OnReboundController)
			{
				bulletLogicReboundController.OnBulletDestroy();
			}
		}
		if (this.OnCollisionController != null)
		{
			foreach (BulletLogicBulletCollisionController bulletLogicBulletCollisionController in this.OnCollisionController)
			{
				bulletLogicBulletCollisionController.OnBulletDestroy();
			}
		}
		if (this.OnSupportController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase4 in this.OnSupportController)
			{
				bulletLogicControllerBase4.OnBulletDestroy();
			}
		}
		if (this.OnMovementController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase5 in this.OnMovementController)
			{
				bulletLogicControllerBase5.OnBulletDestroy();
			}
		}
		if (this.OnHitBulletController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase6 in this.OnHitBulletController)
			{
				bulletLogicControllerBase6.OnBulletDestroy();
			}
		}
		this.ObstaclesDetectInternal = false;
		return true;
	}

	// Token: 0x06017ADA RID: 96986 RVA: 0x0069D05C File Offset: 0x0069B25C
	public void ActionDestroy()
	{
		if (this.OnDestroyController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnDestroyController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(null);
			}
		}
	}

	// Token: 0x06017ADB RID: 96987 RVA: 0x0069D0B8 File Offset: 0x0069B2B8
	public void ActionHit(BulletHitActorData hitActorData)
	{
		if (!this.BulletInfo.IsInit || this.BulletIsProcessByTime)
		{
			return;
		}
		if (this.OnHitController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnHitController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(hitActorData);
			}
		}
	}

	// Token: 0x06017ADC RID: 96988 RVA: 0x0069D128 File Offset: 0x0069B328
	public void ActionHitObstacles(BulletHitActorData hitActorData)
	{
		if (!this.BulletInfo.IsInit)
		{
			return;
		}
		if (this.OnHitController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnHitController)
			{
				bulletLogicControllerBase.BulletLogicActionOnHitObstaclesFromBase(hitActorData);
			}
		}
	}

	// Token: 0x06017ADD RID: 96989 RVA: 0x0069D190 File Offset: 0x0069B390
	public void ActionRebound(BulletInfo otherBulletInfo)
	{
		if (this.OnReboundController != null)
		{
			foreach (BulletLogicReboundController bulletLogicReboundController in this.OnReboundController)
			{
				bulletLogicReboundController.BulletLogicAction(otherBulletInfo);
			}
		}
	}

	// Token: 0x06017ADE RID: 96990 RVA: 0x0069D1EC File Offset: 0x0069B3EC
	public void ActionCollision(BulletInfo otherBulletInfo)
	{
		if (this.OnCollisionController != null)
		{
			foreach (BulletLogicBulletCollisionController bulletLogicBulletCollisionController in this.OnCollisionController)
			{
				bulletLogicBulletCollisionController.BulletLogicAction(otherBulletInfo);
			}
		}
	}

	// Token: 0x06017ADF RID: 96991 RVA: 0x0069D248 File Offset: 0x0069B448
	public unsafe void ActionSupport(Entity otherBullet)
	{
		if (this.OnSupportController == null || this.OnSupportController.Count <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "与子弹碰撞, 执行Support";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("This.Id", this.BulletInfo.BulletRowName);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "this.OnSupportController.Len";
			List<BulletLogicControllerBase> onSupportController = this.OnSupportController;
			ptr = new ValueTuple<string, object>(item, (onSupportController != null) ? new int?(onSupportController.Count) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (this.OnSupportController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnSupportController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(otherBullet);
			}
		}
	}

	// Token: 0x06017AE0 RID: 96992 RVA: 0x0069D33C File Offset: 0x0069B53C
	public void ActionTickMovement(float delta)
	{
		if (this.OnMovementController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnMovementController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(delta);
			}
		}
	}

	// Token: 0x06017AE1 RID: 96993 RVA: 0x0069D39C File Offset: 0x0069B59C
	public void ActionHitBullet(BulletInfo otherBulletInfo)
	{
		if (this.OnHitBulletController != null)
		{
			foreach (BulletLogicControllerBase bulletLogicControllerBase in this.OnHitBulletController)
			{
				bulletLogicControllerBase.BulletLogicActionFromBase(otherBulletInfo);
			}
		}
	}

	// Token: 0x06017AE2 RID: 96994 RVA: 0x0069D3F8 File Offset: 0x0069B5F8
	[return: Nullable(2)]
	private BulletLogicControllerBase NewController(UKuroBpDataAsset bulletLogicBase)
	{
		LogicDataCreateBullet logicDataCreateBullet = bulletLogicBase as LogicDataCreateBullet;
		if (logicDataCreateBullet != null)
		{
			return new BulletLogicCreateBulletController(logicDataCreateBullet, base.Entity);
		}
		LogicDataDestroyBullet logicDataDestroyBullet = bulletLogicBase as LogicDataDestroyBullet;
		if (logicDataDestroyBullet != null)
		{
			return new BulletLogicDestroyBulletController(logicDataDestroyBullet, base.Entity);
		}
		LogicDataForce logicDataForce = bulletLogicBase as LogicDataForce;
		if (logicDataForce != null)
		{
			return new BulletLogicForceController(logicDataForce, base.Entity);
		}
		LogicDataSpeedReduce logicDataSpeedReduce = bulletLogicBase as LogicDataSpeedReduce;
		if (logicDataSpeedReduce != null)
		{
			this.ObstaclesDetectInternal = true;
			return new BulletLogicSpeedReduceController(logicDataSpeedReduce, base.Entity);
		}
		LogicDataAdditiveAccelerate logicDataAdditiveAccelerate = bulletLogicBase as LogicDataAdditiveAccelerate;
		if (logicDataAdditiveAccelerate != null)
		{
			return new BulletLogicAdditiveAccelerateController(logicDataAdditiveAccelerate, base.Entity);
		}
		LogicDataFreeze logicDataFreeze = bulletLogicBase as LogicDataFreeze;
		if (logicDataFreeze != null)
		{
			return new BulletLogicFreezeController(logicDataFreeze, base.Entity);
		}
		LogicDataRebound logicDataRebound = bulletLogicBase as LogicDataRebound;
		if (logicDataRebound != null)
		{
			return new BulletLogicReboundController(logicDataRebound, base.Entity);
		}
		LogicDataBulletCollision logicDataBulletCollision = bulletLogicBase as LogicDataBulletCollision;
		if (logicDataBulletCollision != null)
		{
			return new BulletLogicBulletCollisionController(logicDataBulletCollision, base.Entity);
		}
		LogicDataSupport logicDataSupport = bulletLogicBase as LogicDataSupport;
		if (logicDataSupport != null)
		{
			return new BulletLogicSupportController(logicDataSupport, base.Entity);
		}
		LogicDataSplineMovement logicDataSplineMovement = bulletLogicBase as LogicDataSplineMovement;
		if (logicDataSplineMovement != null)
		{
			return new BulletLogicCurveMovementController(logicDataSplineMovement, base.Entity);
		}
		LogicDataShakeScreen logicDataShakeScreen = bulletLogicBase as LogicDataShakeScreen;
		if (logicDataShakeScreen != null)
		{
			return new BulletLogicShakeCameraController(logicDataShakeScreen, base.Entity);
		}
		LogicDataShowMesh logicDataShowMesh = bulletLogicBase as LogicDataShowMesh;
		if (logicDataShowMesh != null)
		{
			return new BulletLogicShowMesh(logicDataShowMesh, base.Entity);
		}
		LogicDataSuiGuang logicDataSuiGuang = bulletLogicBase as LogicDataSuiGuang;
		if (logicDataSuiGuang != null)
		{
			return new BulletLogicSuiGuang(logicDataSuiGuang, base.Entity);
		}
		LogicDataSpawnObstacles logicDataSpawnObstacles = bulletLogicBase as LogicDataSpawnObstacles;
		if (logicDataSpawnObstacles != null)
		{
			return new BulletLogicSpawnObstacles(logicDataSpawnObstacles, base.Entity);
		}
		LogicDataManipulatableCreateBullet logicDataManipulatableCreateBullet = bulletLogicBase as LogicDataManipulatableCreateBullet;
		if (logicDataManipulatableCreateBullet != null)
		{
			return new BulletLogicManipulatableCreateBullet(logicDataManipulatableCreateBullet, base.Entity);
		}
		LogicDataManipulatableTagsChange logicDataManipulatableTagsChange = bulletLogicBase as LogicDataManipulatableTagsChange;
		if (logicDataManipulatableTagsChange != null)
		{
			return new BulletLogicManipulatableTagsChange(logicDataManipulatableTagsChange, base.Entity);
		}
		LogicDataWhirlpool logicDataWhirlpool = bulletLogicBase as LogicDataWhirlpool;
		if (logicDataWhirlpool != null)
		{
			return new BulletLogicWhirlpool(logicDataWhirlpool, base.Entity);
		}
		LogicDataDestroyOtherBullet logicDataDestroyOtherBullet = bulletLogicBase as LogicDataDestroyOtherBullet;
		if (logicDataDestroyOtherBullet != null)
		{
			return new BulletLogicDestroyOtherBullet(logicDataDestroyOtherBullet, base.Entity);
		}
		LogicDataShield logicDataShield = bulletLogicBase as LogicDataShield;
		if (logicDataShield != null)
		{
			return new BulletLogicShieldController(logicDataShield, base.Entity);
		}
		LogicDataSummonRandom logicDataSummonRandom = bulletLogicBase as LogicDataSummonRandom;
		if (logicDataSummonRandom != null)
		{
			return new BulletLogicSummonRandom(logicDataSummonRandom, base.Entity);
		}
		LogicDataCameraModify logicDataCameraModify = bulletLogicBase as LogicDataCameraModify;
		if (logicDataCameraModify != null)
		{
			return new BulletLogicCameraModify(logicDataCameraModify, base.Entity);
		}
		LogicDataEffectSave logicDataEffectSave = bulletLogicBase as LogicDataEffectSave;
		if (logicDataEffectSave != null)
		{
			return new BulletLogicEffectSave(logicDataEffectSave, base.Entity);
		}
		LogicDataAddBuff logicDataAddBuff = bulletLogicBase as LogicDataAddBuff;
		if (logicDataAddBuff != null)
		{
			return new BulletLogicAddBuff(logicDataAddBuff, base.Entity);
		}
		return null;
	}

	// Token: 0x06017AE3 RID: 96995 RVA: 0x0069D658 File Offset: 0x0069B858
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BulletActionLogicComponent bulletActionLogicComponent = (BulletActionLogicComponent)componentTemplate;
		if (base.CanResetComponentProperty("BulletInfo"))
		{
			if (bulletActionLogicComponent.BulletInfo == null)
			{
				this.BulletInfo = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BulletInfo>(this.BulletInfo), "BulletInfo"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BulletData"))
		{
			if (bulletActionLogicComponent.BulletData == null)
			{
				this.BulletData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BulletDataMain>(this.BulletData), "BulletData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnBeginController"))
		{
			if (bulletActionLogicComponent.OnBeginController == null)
			{
				this.OnBeginController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnBeginController), "OnBeginController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnHitController"))
		{
			if (bulletActionLogicComponent.OnHitController == null)
			{
				this.OnHitController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnHitController), "OnHitController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnDestroyController"))
		{
			if (bulletActionLogicComponent.OnDestroyController == null)
			{
				this.OnDestroyController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnDestroyController), "OnDestroyController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnReboundController"))
		{
			if (bulletActionLogicComponent.OnReboundController == null)
			{
				this.OnReboundController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicReboundController>>(this.OnReboundController), "OnReboundController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnCollisionController"))
		{
			if (bulletActionLogicComponent.OnCollisionController == null)
			{
				this.OnCollisionController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicBulletCollisionController>>(this.OnCollisionController), "OnCollisionController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnSupportController"))
		{
			if (bulletActionLogicComponent.OnSupportController == null)
			{
				this.OnSupportController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnSupportController), "OnSupportController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnMovementController"))
		{
			if (bulletActionLogicComponent.OnMovementController == null)
			{
				this.OnMovementController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnMovementController), "OnMovementController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnHitBulletController"))
		{
			if (bulletActionLogicComponent.OnHitBulletController == null)
			{
				this.OnHitBulletController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnHitBulletController), "OnHitBulletController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnTickController"))
		{
			if (bulletActionLogicComponent.OnTickController == null)
			{
				this.OnTickController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<BulletLogicControllerBase>>(this.OnTickController), "OnTickController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ObstaclesDetectInternal"))
		{
			this.ObstaclesDetectInternal = bulletActionLogicComponent.ObstaclesDetectInternal;
		}
		if (base.CanResetComponentProperty("BulletIsProcessByTime"))
		{
			this.BulletIsProcessByTime = bulletActionLogicComponent.BulletIsProcessByTime;
		}
		return true;
	}

	// Token: 0x0400B69E RID: 46750
	[Nullable(2)]
	private BulletInfo BulletInfo;

	// Token: 0x0400B69F RID: 46751
	[Nullable(2)]
	private BulletDataMain BulletData;

	// Token: 0x0400B6A0 RID: 46752
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnBeginController;

	// Token: 0x0400B6A1 RID: 46753
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnHitController;

	// Token: 0x0400B6A2 RID: 46754
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnDestroyController;

	// Token: 0x0400B6A3 RID: 46755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicReboundController> OnReboundController;

	// Token: 0x0400B6A4 RID: 46756
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicBulletCollisionController> OnCollisionController;

	// Token: 0x0400B6A5 RID: 46757
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnSupportController;

	// Token: 0x0400B6A6 RID: 46758
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnMovementController;

	// Token: 0x0400B6A7 RID: 46759
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnHitBulletController;

	// Token: 0x0400B6A8 RID: 46760
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletLogicControllerBase> OnTickController;

	// Token: 0x0400B6A9 RID: 46761
	private bool ObstaclesDetectInternal;

	// Token: 0x0400B6AA RID: 46762
	private bool BulletIsProcessByTime;
}
