using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using AkiClient.Game.Aki.UI.Manager;
using CSharpScript.Game.Render;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.Module
{
	// Token: 0x02004A84 RID: 19076
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneBattleInteractEffect
	{
		// Token: 0x06031C72 RID: 203890 RVA: 0x00C772CC File Offset: 0x00C754CC
		public void Init(BP_SceneBattleInteract_C dataAsset, float radius = 0f, float halfHeight = 0f)
		{
			this.DataAsset = dataAsset;
			this.Radius = ((this.DataAsset.CollisionRadius > 0f) ? this.DataAsset.CollisionRadius : radius);
			this.HalfHeight = ((this.DataAsset.CollisionHalfHeight > 0f) ? this.DataAsset.CollisionHalfHeight : halfHeight);
			this.ZeroOffset = this.DataAsset.CollisionOffset.IsZero();
			this.TickInterval = this.DataAsset.Interval;
			this.WeaponEventEnable = this.DataAsset.SendWeaponEvent;
			this.InitTraceInfo();
		}

		// Token: 0x06031C73 RID: 203891 RVA: 0x00C7736D File Offset: 0x00C7556D
		public void SetDispatchWeaponEventEnable(bool enable)
		{
			BP_SceneBattleInteract_C dataAsset = this.DataAsset;
			if (dataAsset != null && dataAsset.SendWeaponEvent)
			{
				return;
			}
			this.WeaponEventEnable = enable;
		}

		// Token: 0x06031C74 RID: 203892 RVA: 0x00C7738B File Offset: 0x00C7558B
		public void BindEntityId(int entityId)
		{
			this.EntityId = entityId;
		}

		// Token: 0x06031C75 RID: 203893 RVA: 0x00C77394 File Offset: 0x00C75594
		public void SetUpdateLocationFunc(Action<Vector, FVectorDouble?> updateLocationFunc)
		{
			this.LocationUpdateType = ESceneBattleInteractLocation.Default;
			this.UpdateLocationFunc = updateLocationFunc;
		}

		// Token: 0x06031C76 RID: 203894 RVA: 0x00C773A4 File Offset: 0x00C755A4
		public void SetUpdateLocationActor(AActor actor)
		{
			this.LocationUpdateType = ESceneBattleInteractLocation.Actor;
			this.Actor = actor;
		}

		// Token: 0x06031C77 RID: 203895 RVA: 0x00C773B4 File Offset: 0x00C755B4
		public void SetUpdateLocationSocket(UMeshComponent meshComp, FName socketName)
		{
			this.LocationUpdateType = ESceneBattleInteractLocation.Socket;
			this.MeshComp = meshComp;
			this.SocketName = socketName;
		}

		// Token: 0x06031C78 RID: 203896 RVA: 0x00C773CB File Offset: 0x00C755CB
		public void SetDownVector(Vector downVector)
		{
			this.DownVector.FromUeVector(downVector);
		}

		// Token: 0x06031C79 RID: 203897 RVA: 0x00C773D9 File Offset: 0x00C755D9
		public void SetIsCommonWeapon(bool isCommonWeapon)
		{
			this.IsCommonWeapon = isCommonWeapon;
		}

		// Token: 0x06031C7A RID: 203898 RVA: 0x00C773E4 File Offset: 0x00C755E4
		private void InitTraceInfo()
		{
			this.ShapeType = (SceneBattleInteractEffect.EShapeType)this.DataAsset.ShapeType;
			this.NeedTrace = true;
			this.TraceNeedLastLocation = true;
			switch (this.ShapeType)
			{
			case SceneBattleInteractEffect.EShapeType.Sphere:
				this.TraceElement = SceneBattleInteractPool.GetTraceSphereElement(KuroTraceTypeQuery.Water);
				((UTraceSphereElement)this.TraceElement).Radius = this.Radius;
				break;
			case SceneBattleInteractEffect.EShapeType.Capsule:
				this.TraceElement = SceneBattleInteractPool.GetTraceCapsuleElement(KuroTraceTypeQuery.Water);
				((UTraceCapsuleElement)this.TraceElement).Radius = this.Radius;
				((UTraceCapsuleElement)this.TraceElement).HalfHeight = this.HalfHeight;
				break;
			case SceneBattleInteractEffect.EShapeType.LineDown:
				this.TraceElement = SceneBattleInteractPool.GetTraceLineElement(KuroTraceTypeQuery.Water);
				this.TraceNeedLastLocation = false;
				break;
			default:
				this.NeedTrace = false;
				this.TraceNeedLastLocation = false;
				break;
			}
			if (this.NeedTrace)
			{
				this.TraceDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.TraceHitResultHandle));
				this.SetDebug(ModelBase<SceneBattleInteractModel>.Instance.Debug);
			}
		}

		// Token: 0x06031C7B RID: 203899 RVA: 0x00C774F0 File Offset: 0x00C756F0
		public void OnTick(float delta)
		{
			if (this.IsFinish || !this.Enable)
			{
				return;
			}
			if (this.IsCommonWeapon && ModelBase<SceneBattleInteractModel>.Instance.IgnoreCommonWeapon)
			{
				return;
			}
			if (this.EntityId > 0)
			{
				int entityId = this.EntityId;
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				int? num = (baseCharacter != null) ? new int?(baseCharacter.GetEntityIdNoBlueprint()) : null;
				if (!(entityId == num.GetValueOrDefault() & num != null))
				{
					return;
				}
			}
			if (this.EnableLimitTime > 0f)
			{
				this.EnableLimitTime -= delta;
				if (this.EnableLimitTime <= 0f)
				{
					this.Enable = false;
					return;
				}
			}
			this.GetLocation(this.CurLocation);
			if (this.NextTickTime == -1f)
			{
				this.LastLocation.FromUeVector(this.CurLocation);
				this.NextTickTime = 0f;
				if (this.TraceNeedLastLocation)
				{
					return;
				}
			}
			this.NextTickTime -= delta;
			if (this.NextTickTime > 0f)
			{
				return;
			}
			this.NextTickTime = 0f;
			if (this.WeaponEventEnable)
			{
				BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
				if (bpEventManager != null)
				{
					bpEventManager.武器交互场景时.Broadcast(this.CurLocation.ToUeVector(false), this.DataAsset, this.Id);
				}
			}
			if (!this.NeedTrace)
			{
				if (this.LastLocation.Equals(this.CurLocation, 9.999999747378752E-05))
				{
					return;
				}
				BP_EventManager_C bpEventManager2 = GlobalData.BpEventManager;
				if (bpEventManager2 != null)
				{
					bpEventManager2.子弹撞到水面时.Broadcast(Vector.ZeroVectorDouble, this.DataAsset, this.CurLocation.ToUeVector(false), this.Id);
				}
				this.DrawDebugPoint(this.CurLocation, ColorUtils.LinearRed);
				this.NextTickTime = (float)this.TickInterval;
				this.LastLocation.FromUeVector(this.CurLocation);
				return;
			}
			else
			{
				if (this.TraceDelegate == null || this.TraceElement == null)
				{
					return;
				}
				switch (this.ShapeType)
				{
				case SceneBattleInteractEffect.EShapeType.Sphere:
					Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, this.LastLocation);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, this.CurLocation);
					Singleton<TraceElementCommon>.Instance.AsyncSphereTrace((UTraceSphereElement)this.TraceElement, "BattleInteractWaterTrace", this.TraceDelegate);
					break;
				case SceneBattleInteractEffect.EShapeType.Capsule:
					Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, this.LastLocation);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, this.CurLocation);
					Singleton<TraceElementCommon>.Instance.AsyncCapsuleTrace((UTraceCapsuleElement)this.TraceElement, "BattleInteractWaterTrace", this.TraceDelegate);
					break;
				case SceneBattleInteractEffect.EShapeType.LineDown:
					this.CurLocation.Z += (double)this.HalfHeight;
					this.TempVector.X = this.CurLocation.X + this.DownVector.X * (double)this.Radius;
					this.TempVector.Y = this.CurLocation.Y + this.DownVector.Y * (double)this.Radius;
					this.TempVector.Z = this.CurLocation.Z + this.DownVector.Z * (double)this.Radius;
					Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, this.CurLocation);
					Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, this.TempVector);
					Singleton<TraceElementCommon>.Instance.AsyncLineTrace((UTraceLineElement)this.TraceElement, "BattleInteractWaterTrace", this.TraceDelegate);
					break;
				}
				this.LastLocation.FromUeVector(this.CurLocation);
				return;
			}
		}

		// Token: 0x06031C7C RID: 203900 RVA: 0x00C77884 File Offset: 0x00C75A84
		private void TraceHitResultHandle(bool result, UTraceBaseElement element, double frame, double index)
		{
			if (this.DataAsset == null)
			{
				return;
			}
			if (frame < this.TraceFrame)
			{
				return;
			}
			if (frame == this.TraceFrame && index < this.TraceIndex)
			{
				return;
			}
			if (this.NextTickTime != 0f || this.IsFinish)
			{
				return;
			}
			if (!result)
			{
				return;
			}
			UKuroHitResult hitResult = element.HitResult;
			bool flag = false;
			Vector tempVector = this.TempVector;
			if (hitResult != null && hitResult.bBlockingHit)
			{
				int hitCount = hitResult.GetHitCount();
				TArray<int> itemArray = hitResult.ItemArray;
				for (int i = 0; i < hitCount; i++)
				{
					TWeakObjectPtr<UPrimitiveComponent> weak = hitResult.Components.Get(i);
					int instanceIndex = itemArray.Get(i);
					FName collisionProfileName = UKuroCollisionLibrary.GetCollisionProfileName(weak, instanceIndex);
					if (RenderConfig.WaterCollisionProfileName == collisionProfileName)
					{
						tempVector.X = (double)hitResult.ImpactPointX_Array.Get(i);
						tempVector.Y = (double)hitResult.ImpactPointY_Array.Get(i);
						tempVector.Z = (double)hitResult.ImpactPointZ_Array.Get(i);
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				this.TraceFrame = frame;
				this.TraceIndex = index;
				BP_EventManager_C bpEventManager = GlobalData.BpEventManager;
				if (bpEventManager != null)
				{
					bpEventManager.子弹撞到水面时.Broadcast(tempVector.ToUeVector(false), this.DataAsset, this.LastLocation.ToUeVector(false), this.Id);
				}
				if (this.TickInterval <= 0)
				{
					this.IsFinish = true;
					return;
				}
				this.NextTickTime = (float)this.TickInterval;
			}
		}

		// Token: 0x06031C7D RID: 203901 RVA: 0x00C779EC File Offset: 0x00C75BEC
		private void GetLocation(Vector @out)
		{
			switch (this.LocationUpdateType)
			{
			case ESceneBattleInteractLocation.Default:
				if (this.ZeroOffset)
				{
					Action<Vector, FVectorDouble?> updateLocationFunc = this.UpdateLocationFunc;
					if (updateLocationFunc == null)
					{
						return;
					}
					updateLocationFunc(@out, null);
					return;
				}
				else
				{
					Action<Vector, FVectorDouble?> updateLocationFunc2 = this.UpdateLocationFunc;
					if (updateLocationFunc2 == null)
					{
						return;
					}
					updateLocationFunc2(@out, new FVectorDouble?(this.DataAsset.CollisionOffset));
					return;
				}
				break;
			case ESceneBattleInteractLocation.Actor:
				if (this.Actor != null)
				{
					FVectorDouble fvectorDouble;
					if (this.ZeroOffset)
					{
						fvectorDouble = this.Actor.D_K2_GetActorLocation();
						@out.FromUeVector(fvectorDouble);
						return;
					}
					FTransformDouble ftransformDouble = this.Actor.D_GetTransform();
					fvectorDouble = this.DataAsset.CollisionOffset;
					FVectorDouble fvectorDouble2 = ftransformDouble.TransformPosition(fvectorDouble);
					@out.FromUeVector(fvectorDouble2);
					return;
				}
				break;
			case ESceneBattleInteractLocation.Socket:
				if (this.MeshComp != null)
				{
					FVectorDouble fvectorDouble;
					if (this.ZeroOffset)
					{
						fvectorDouble = this.MeshComp.D_GetSocketLocation(this.SocketName);
						@out.FromUeVector(fvectorDouble);
						return;
					}
					FTransformDouble ftransformDouble2 = this.MeshComp.D_GetSocketTransform(this.SocketName, ERelativeTransformSpace.RTS_World);
					fvectorDouble = this.DataAsset.CollisionOffset;
					FVectorDouble fvectorDouble2 = ftransformDouble2.TransformPosition(fvectorDouble);
					@out.FromUeVector(fvectorDouble2);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06031C7E RID: 203902 RVA: 0x00C77B0A File Offset: 0x00C75D0A
		public void SetEnable(bool enable, float limitTime = 0f)
		{
			this.EnableLimitTime = limitTime;
			if (this.Enable == enable)
			{
				return;
			}
			this.Enable = enable;
			this.NextTickTime = -1f;
		}

		// Token: 0x06031C7F RID: 203903 RVA: 0x00C77B2F File Offset: 0x00C75D2F
		public void SetIgnoreCommonWeapon(bool ignoreCommonWeapon)
		{
			if (this.IgnoreCommonWeapon == ignoreCommonWeapon)
			{
				return;
			}
			this.IgnoreCommonWeapon = ignoreCommonWeapon;
			ModelBase<SceneBattleInteractModel>.Instance.RefreshIgnoreCommonWeapon(ignoreCommonWeapon);
		}

		// Token: 0x06031C80 RID: 203904 RVA: 0x00C77B4D File Offset: 0x00C75D4D
		public bool GetIgnoreCommonWeapon()
		{
			return this.IgnoreCommonWeapon;
		}

		// Token: 0x06031C81 RID: 203905 RVA: 0x00C77B58 File Offset: 0x00C75D58
		public void SetDebug(int debugMode)
		{
			if (this.TraceElement == null)
			{
				return;
			}
			if (debugMode == 0)
			{
				this.TraceElement.SetDrawDebugTrace(EDrawDebugTrace.None);
				return;
			}
			if (debugMode == 1)
			{
				Singleton<TraceElementCommon>.Instance.SetTraceColor(this.TraceElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.TraceElement, ColorUtils.LinearRed);
				this.TraceElement.SetDrawDebugTrace(EDrawDebugTrace.ForOneFrame);
				return;
			}
			if (debugMode == 2)
			{
				this.TraceElement.DrawTime = 3f;
				Singleton<TraceElementCommon>.Instance.SetTraceColor(this.TraceElement, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.TraceElement, ColorUtils.LinearRed);
				this.TraceElement.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
			}
		}

		// Token: 0x06031C82 RID: 203906 RVA: 0x00C77C03 File Offset: 0x00C75E03
		private void DrawDebugPoint(Vector point, FLinearColor color)
		{
			if (ModelBase<SceneBattleInteractModel>.Instance.Debug <= 0)
			{
				return;
			}
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.GameInstance, point.ToUeVector(false), 5f, 12, new FLinearColor?(color), 1f, 0f);
		}

		// Token: 0x06031C83 RID: 203907 RVA: 0x00C77C3C File Offset: 0x00C75E3C
		public void Destroy()
		{
			this.SetIgnoreCommonWeapon(false);
			this.DataAsset = null;
			this.UpdateLocationFunc = null;
			this.Actor = null;
			this.MeshComp = null;
			if (this.TraceDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.TraceHitResultHandle));
				this.TraceDelegate = null;
			}
			if (this.TraceElement != null)
			{
				switch (this.ShapeType)
				{
				case SceneBattleInteractEffect.EShapeType.Sphere:
					SceneBattleInteractPool.RecycleTraceSphereElement((UTraceSphereElement)this.TraceElement);
					break;
				case SceneBattleInteractEffect.EShapeType.Capsule:
					SceneBattleInteractPool.RecycleTraceCapsuleElement((UTraceCapsuleElement)this.TraceElement);
					break;
				case SceneBattleInteractEffect.EShapeType.LineDown:
					SceneBattleInteractPool.RecycleTraceLineElement((UTraceLineElement)this.TraceElement);
					break;
				}
				this.TraceElement = null;
			}
		}

		// Token: 0x0401D253 RID: 119379
		public int Id;

		// Token: 0x0401D254 RID: 119380
		private bool Enable;

		// Token: 0x0401D255 RID: 119381
		private int EntityId;

		// Token: 0x0401D256 RID: 119382
		private float EnableLimitTime;

		// Token: 0x0401D257 RID: 119383
		private float NextTickTime = -1f;

		// Token: 0x0401D258 RID: 119384
		private int TickInterval;

		// Token: 0x0401D259 RID: 119385
		private bool WeaponEventEnable;

		// Token: 0x0401D25A RID: 119386
		[Nullable(2)]
		private BP_SceneBattleInteract_C DataAsset;

		// Token: 0x0401D25B RID: 119387
		private float Radius;

		// Token: 0x0401D25C RID: 119388
		private float HalfHeight;

		// Token: 0x0401D25D RID: 119389
		private ESceneBattleInteractLocation LocationUpdateType;

		// Token: 0x0401D25E RID: 119390
		[Nullable(2)]
		private AActor Actor;

		// Token: 0x0401D25F RID: 119391
		[Nullable(2)]
		private UMeshComponent MeshComp;

		// Token: 0x0401D260 RID: 119392
		private FName SocketName = FNameUtil.EMPTY;

		// Token: 0x0401D261 RID: 119393
		[Nullable(2)]
		private UTraceBaseElement TraceElement;

		// Token: 0x0401D262 RID: 119394
		private SceneBattleInteractEffect.EShapeType ShapeType;

		// Token: 0x0401D263 RID: 119395
		private bool ZeroOffset = true;

		// Token: 0x0401D264 RID: 119396
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x0401D265 RID: 119397
		private readonly Vector DownVector = Vector.Create(0.0, 0.0, -1.0);

		// Token: 0x0401D266 RID: 119398
		private bool IsFinish;

		// Token: 0x0401D267 RID: 119399
		private readonly Vector CurLocation = Vector.Create();

		// Token: 0x0401D268 RID: 119400
		private readonly Vector LastLocation = Vector.Create();

		// Token: 0x0401D269 RID: 119401
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<Vector, FVectorDouble?> UpdateLocationFunc;

		// Token: 0x0401D26A RID: 119402
		private bool NeedTrace;

		// Token: 0x0401D26B RID: 119403
		private bool TraceNeedLastLocation;

		// Token: 0x0401D26C RID: 119404
		private double TraceFrame;

		// Token: 0x0401D26D RID: 119405
		private double TraceIndex;

		// Token: 0x0401D26E RID: 119406
		[Nullable(2)]
		private FAsyncTraceDelegate TraceDelegate;

		// Token: 0x0401D26F RID: 119407
		private bool IgnoreCommonWeapon;

		// Token: 0x0401D270 RID: 119408
		private bool IsCommonWeapon;

		// Token: 0x0401D271 RID: 119409
		private const string PROFILE_BATLLE_INTERACT_WATER_TRACE = "BattleInteractWaterTrace";

		// Token: 0x0200AAF2 RID: 43762
		[NullableContext(0)]
		private enum EShapeType
		{
			// Token: 0x0403534B RID: 217931
			None = -1,
			// Token: 0x0403534C RID: 217932
			Sphere,
			// Token: 0x0403534D RID: 217933
			Capsule,
			// Token: 0x0403534E RID: 217934
			LineDown
		}
	}
}
