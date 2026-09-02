using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Camera;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004908 RID: 18696
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterMeshDitherDetectComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x17008348 RID: 33608
		// (get) Token: 0x06030DC4 RID: 200132 RVA: 0x00C1A15A File Offset: 0x00C1835A
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(CharacterActorComponent),
					typeof(CharacterMoveComponent)
				};
			}
		}

		// Token: 0x06030DC5 RID: 200133 RVA: 0x00C1A17C File Offset: 0x00C1837C
		private static int CompareMeshDitherDetectConfigPriority(MeshDitherDetectConfig a, MeshDitherDetectConfig b)
		{
			if (a.Priority == b.Priority)
			{
				return -1;
			}
			return b.Priority - a.Priority;
		}

		// Token: 0x17008349 RID: 33609
		// (get) Token: 0x06030DC6 RID: 200134 RVA: 0x00C1A19C File Offset: 0x00C1839C
		public float TraceCapsuleWidth
		{
			get
			{
				float val = 0f;
				CharacterActorComponent actorComp = this.ActorComp;
				float? num;
				if (actorComp == null)
				{
					num = null;
				}
				else
				{
					UCapsuleComponent capsuleComponent = actorComp.Actor.CapsuleComponent;
					num = ((capsuleComponent != null) ? new float?(capsuleComponent.GetScaledCapsuleRadius()) : null);
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault();
				MeshDitherDetectConfig meshDitherDetectConfig = this.MeshDitherDetectConfig;
				return Math.Max(val, valueOrDefault + ((meshDitherDetectConfig != null) ? meshDitherDetectConfig.CapsuleAdditionRadius : 0f));
			}
		}

		// Token: 0x1700834A RID: 33610
		// (get) Token: 0x06030DC7 RID: 200135 RVA: 0x00C1A20C File Offset: 0x00C1840C
		public float TraceCapsuleHeight
		{
			get
			{
				float val = 0f;
				CharacterActorComponent actorComp = this.ActorComp;
				float? num;
				if (actorComp == null)
				{
					num = null;
				}
				else
				{
					UCapsuleComponent capsuleComponent = actorComp.Actor.CapsuleComponent;
					num = ((capsuleComponent != null) ? new float?(capsuleComponent.GetScaledCapsuleHalfHeight()) : null);
				}
				float? num2 = num;
				float valueOrDefault = num2.GetValueOrDefault();
				MeshDitherDetectConfig meshDitherDetectConfig = this.MeshDitherDetectConfig;
				return Math.Max(val, valueOrDefault + ((meshDitherDetectConfig != null) ? meshDitherDetectConfig.CapsuleAdditionHeight : 0f));
			}
		}

		// Token: 0x06030DC8 RID: 200136 RVA: 0x00C1A27C File Offset: 0x00C1847C
		protected override bool OnStart()
		{
			base.OnStart();
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
			this.EntityHandle = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
			this.ComponentDisableHandle = base.Disable("[Mesh虚化检测]组件默认禁用");
			return true;
		}

		// Token: 0x06030DC9 RID: 200137 RVA: 0x00C1A2DC File Offset: 0x00C184DC
		public int EnableDetectDither(SMeshDitherDetectConfig config)
		{
			int num = this.MeshDitherDetectConfigId + 1;
			this.MeshDitherDetectConfigId = num;
			MeshDitherDetectConfig meshDitherDetectConfig = new MeshDitherDetectConfig(config, num);
			this.MeshDitherDetectConfigList.Push(meshDitherDetectConfig);
			this.MeshDitherDetectConfigMap[meshDitherDetectConfig.Id] = meshDitherDetectConfig;
			this.UpdateValidMeshDitherDetectConfig();
			return meshDitherDetectConfig.Id;
		}

		// Token: 0x06030DCA RID: 200138 RVA: 0x00C1A32C File Offset: 0x00C1852C
		public void DisableDetectDither(int id)
		{
			MeshDitherDetectConfig meshDitherDetectConfig;
			if (!this.MeshDitherDetectConfigMap.TryGetValue(id, out meshDitherDetectConfig))
			{
				return;
			}
			meshDitherDetectConfig.MarkDelete = true;
			this.UpdateValidMeshDitherDetectConfig();
		}

		// Token: 0x06030DCB RID: 200139 RVA: 0x00C1A358 File Offset: 0x00C18558
		protected override void OnTick(float delta)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Valid)
			{
				return;
			}
			if (!this.EnableDither)
			{
				this.RecoverDither();
				return;
			}
			this.InitTraceElement();
			this.UpdateTraceElement();
			if (!Singleton<TraceElementCommon>.Instance.CapsuleTrace(this.TraceElement, "MeshDitherDetectTrace"))
			{
				this.RecoverDither();
				return;
			}
			UKuroHitResult hitResult = this.TraceElement.HitResult;
			this.UpdateDitherDistance(hitResult);
			this.UpdateDitherCharacterValue();
		}

		// Token: 0x06030DCC RID: 200140 RVA: 0x00C1A3D0 File Offset: 0x00C185D0
		private void InitTraceElement()
		{
			if (this.TraceElement != null)
			{
				return;
			}
			this.TraceElement = new UTraceCapsuleElement();
			this.TraceElement.bIsSingle = false;
			this.TraceElement.bIgnoreSelf = true;
			this.TraceElement.WorldContextObject = this.ActorComp.Owner;
			this.TraceElement.ActorsToIgnore.Add(this.ActorComp.Actor);
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldDynamic);
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.Vehicle);
		}

		// Token: 0x06030DCD RID: 200141 RVA: 0x00C1A46C File Offset: 0x00C1866C
		private void UpdateTraceElement()
		{
			if (!this.MoveComp.IsStandardGravity)
			{
				Quat.FindBetween(Vector.UpVectorProxy, this.MoveComp.GravityUp, this.GravityQuat);
				this.GravityQuat.Inverse(this.GravityQuatInverse);
			}
			CameraUtility.GetSocketLocation(null, new FName?(this.MeshDitherDetectConfig.BasisBoneName), this.TmpVector, this.EntityHandle);
			if (this.MoveComp.IsStandardGravity)
			{
				this.ActorComp.ActorQuatProxy.RotateVector(this.MeshDitherDetectConfig.CapsuleAdditionOffset, this.TmpVector2);
				this.TmpVector.AdditionEqual(this.TmpVector2);
			}
			else
			{
				this.GravityQuatInverse.Multiply(this.ActorComp.ActorQuatProxy, this.TmpQuat2);
				this.TmpQuat2.RotateVector(this.MeshDitherDetectConfig.CapsuleAdditionOffset, this.TmpVector2);
				this.GravityQuat.RotateVector(this.TmpVector2, this.TmpVector1);
				this.TmpVector.AdditionEqual(this.TmpVector1);
			}
			this.TraceStartLocation.DeepCopy(this.TmpVector);
			this.TraceEndLocation.DeepCopy(this.TmpVector);
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, this.TraceStartLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, this.TraceEndLocation);
			CameraUtility.GetSocketLocation(null, new FName?(this.MeshDitherDetectConfig.BaseBoneName), this.TmpVector, this.EntityHandle);
			CameraUtility.GetSocketLocation(null, new FName?(this.MeshDitherDetectConfig.TargetBoneName), this.TmpVector1, this.EntityHandle);
			this.TmpVector1.SubtractionEqual(this.TmpVector);
			Singleton<MathUtils>.Instance.LookRotationUpFirst(this.ActorComp.ActorForwardProxy, this.TmpVector1, this.TmpRotator);
			if (this.MoveComp.IsStandardGravity)
			{
				Quat.FindBetween(Vector.UpVectorProxy, this.TmpVector1, this.GravityQuat);
				this.GravityQuat.Inverse(this.GravityQuatInverse);
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpRotator, this.GravityQuatInverse, this.TmpRotator1);
				this.TmpRotator1.AdditionEqual(this.MeshDitherDetectConfig.CapsuleAdditionRotator);
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator1, this.GravityQuat, this.TmpRotator);
			}
			else
			{
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpRotator, this.GravityQuatInverse, this.TmpRotator1);
				Quat.FindBetween(this.MoveComp.GravityUp, this.TmpVector1, this.GravityQuat1);
				this.GravityQuat1.Inverse(this.GravityQuatInverse1);
				Singleton<GravityUtils>.Instance.GetRotatorInGravity(this.TmpRotator1, this.GravityQuatInverse1, this.TmpRotator2);
				this.TmpRotator2.AdditionEqual(this.MeshDitherDetectConfig.CapsuleAdditionRotator);
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator2, this.GravityQuat1, this.TmpRotator1);
				Singleton<GravityUtils>.Instance.GetRotatorInNormal(this.TmpRotator1, this.GravityQuat, this.TmpRotator);
			}
			Singleton<TraceElementCommon>.Instance.SetCapsuleOrientation(this.TraceElement, this.TmpRotator.Normalize(this.TmpRotator));
			this.TraceElement.Radius = this.TraceCapsuleWidth;
			this.TraceElement.HalfHeight = this.TraceCapsuleHeight;
		}

		// Token: 0x06030DCE RID: 200142 RVA: 0x00C1A7C4 File Offset: 0x00C189C4
		private void UpdateDitherDistance(UKuroHitResult hitResult)
		{
			int hitCount = hitResult.GetHitCount();
			this.CharacterDitherDistance = 9999999f;
			for (int i = 0; i < hitCount; i++)
			{
				hitResult.Actors.Get(i);
				TArray<TWeakObjectPtr<UPrimitiveComponent>> components = hitResult.Components;
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr = (components != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(components.Get(i)) : null;
				if (tweakObjectPtr == null || !tweakObjectPtr.GetValueOrDefault().IsValid(false, false))
				{
					return;
				}
				Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, i, this.TmpVector);
				double num = Vector.Dist(this.TmpVector, this.TraceStartLocation);
				if (num < (double)this.CharacterDitherDistance)
				{
					this.CharacterDitherDistance = (float)num;
				}
			}
		}

		// Token: 0x06030DCF RID: 200143 RVA: 0x00C1A880 File Offset: 0x00C18A80
		private void UpdateValidMeshDitherDetectConfig()
		{
			MeshDitherDetectConfig meshDitherDetectConfig = this.GetMeshDitherDetectConfig();
			this.EnableDither = (meshDitherDetectConfig != null);
			this.MeshDitherDetectConfig = meshDitherDetectConfig;
			if (this.EnableDither)
			{
				if (this.ComponentDisableHandle != -1)
				{
					base.Enable(new int?(this.ComponentDisableHandle), "[Mesh虚化检测]开启组件Tick功能");
					this.ComponentDisableHandle = -1;
				}
				ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetIsDitherEffectEnable(false);
				return;
			}
			if (this.ComponentDisableHandle == -1)
			{
				this.ComponentDisableHandle = base.Disable("[Mesh虚化检测]关闭组件Tick功能");
			}
			this.RecoverDither();
			ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.SetIsDitherEffectEnable(true);
		}

		// Token: 0x06030DD0 RID: 200144 RVA: 0x00C1A92C File Offset: 0x00C18B2C
		[NullableContext(2)]
		private MeshDitherDetectConfig GetMeshDitherDetectConfig()
		{
			while (!this.MeshDitherDetectConfigList.Empty)
			{
				MeshDitherDetectConfig top = this.MeshDitherDetectConfigList.Top;
				if (top == null)
				{
					return null;
				}
				if (!top.MarkDelete)
				{
					return top;
				}
				this.MeshDitherDetectConfigList.Pop();
				this.MeshDitherDetectConfigMap.Remove(top.Id);
			}
			return null;
		}

		// Token: 0x06030DD1 RID: 200145 RVA: 0x00C1A984 File Offset: 0x00C18B84
		private void UpdateDitherCharacterValue()
		{
			float dither = this.MeshDitherDetectConfig.OverrideDitherConfig ? Singleton<MathUtils>.Instance.RangeClamp(this.CharacterDitherDistance, this.MeshDitherDetectConfig.CompleteHideDistance, this.MeshDitherDetectConfig.StartHideDistance, 0.01f, this.MeshDitherDetectConfig.StartDitherValue) : Singleton<MathUtils>.Instance.RangeClamp(this.CharacterDitherDistance, this.ActorComp.CompleteHideDistance, this.ActorComp.StartHideDistance, 0.01f, this.ActorComp.StartDitherValue);
			this.ActorComp.Actor.SetDitherEffect(dither, ECharacterDitherType.Fight);
		}

		// Token: 0x06030DD2 RID: 200146 RVA: 0x00C1AA1F File Offset: 0x00C18C1F
		private void RecoverDither()
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.SetDitherEffect(1f, ECharacterDitherType.Fight);
		}

		// Token: 0x06030DD3 RID: 200147 RVA: 0x00C1AA3C File Offset: 0x00C18C3C
		private void ClearMeshDitherDetectConfig()
		{
			this.MeshDitherDetectConfig = null;
			this.MeshDitherDetectConfigList.Clear();
			this.MeshDitherDetectConfigMap.Clear();
		}

		// Token: 0x06030DD4 RID: 200148 RVA: 0x00C1AA5B File Offset: 0x00C18C5B
		protected override bool OnEnd()
		{
			base.OnEnd();
			this.ClearMeshDitherDetectConfig();
			this.ActorComp = null;
			this.MoveComp = null;
			return true;
		}

		// Token: 0x06030DD5 RID: 200149 RVA: 0x00C1AA7C File Offset: 0x00C18C7C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterMeshDitherDetectComponent characterMeshDitherDetectComponent = (CharacterMeshDitherDetectComponent)componentTemplate;
			if (base.CanResetComponentProperty("MeshDitherDetectConfig"))
			{
				if (characterMeshDitherDetectComponent.MeshDitherDetectConfig == null)
				{
					this.MeshDitherDetectConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<MeshDitherDetectConfig>(this.MeshDitherDetectConfig), "MeshDitherDetectConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MeshDitherDetectConfigId"))
			{
				this.MeshDitherDetectConfigId = characterMeshDitherDetectComponent.MeshDitherDetectConfigId;
			}
			if (base.CanResetComponentProperty("MeshDitherDetectConfigMap") && characterMeshDitherDetectComponent.MeshDitherDetectConfigMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, MeshDitherDetectConfig>>(this.MeshDitherDetectConfigMap), "MeshDitherDetectConfigMap"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("MeshDitherDetectConfigList") && characterMeshDitherDetectComponent.MeshDitherDetectConfigList != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<PriorityQueue<MeshDitherDetectConfig>>(this.MeshDitherDetectConfigList), "MeshDitherDetectConfigList"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EntityHandle"))
			{
				if (characterMeshDitherDetectComponent.EntityHandle == null)
				{
					this.EntityHandle = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<EntityHandle>(this.EntityHandle), "EntityHandle"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterMeshDitherDetectComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MoveComp"))
			{
				if (characterMeshDitherDetectComponent.MoveComp == null)
				{
					this.MoveComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TraceElement"))
			{
				if (characterMeshDitherDetectComponent.TraceElement == null)
				{
					this.TraceElement = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceCapsuleElement>(this.TraceElement), "TraceElement"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ComponentDisableHandle"))
			{
				this.ComponentDisableHandle = characterMeshDitherDetectComponent.ComponentDisableHandle;
			}
			if (base.CanResetComponentProperty("EnableDither"))
			{
				this.EnableDither = characterMeshDitherDetectComponent.EnableDither;
			}
			if (base.CanResetComponentProperty("CharacterDitherDistance"))
			{
				this.CharacterDitherDistance = characterMeshDitherDetectComponent.CharacterDitherDistance;
			}
			return (!base.CanResetComponentProperty("GravityQuat") || characterMeshDitherDetectComponent.GravityQuat == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.GravityQuat), "GravityQuat")) && (!base.CanResetComponentProperty("GravityQuatInverse") || characterMeshDitherDetectComponent.GravityQuatInverse == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.GravityQuatInverse), "GravityQuatInverse")) && (!base.CanResetComponentProperty("GravityQuat1") || characterMeshDitherDetectComponent.GravityQuat1 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.GravityQuat1), "GravityQuat1")) && (!base.CanResetComponentProperty("GravityQuatInverse1") || characterMeshDitherDetectComponent.GravityQuatInverse1 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.GravityQuatInverse1), "GravityQuatInverse1")) && (!base.CanResetComponentProperty("TraceStartLocation") || characterMeshDitherDetectComponent.TraceStartLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TraceStartLocation), "TraceStartLocation")) && (!base.CanResetComponentProperty("TraceEndLocation") || characterMeshDitherDetectComponent.TraceEndLocation == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TraceEndLocation), "TraceEndLocation")) && (!base.CanResetComponentProperty("TmpVector") || characterMeshDitherDetectComponent.TmpVector == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector")) && (!base.CanResetComponentProperty("TmpVector1") || characterMeshDitherDetectComponent.TmpVector1 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector1), "TmpVector1")) && (!base.CanResetComponentProperty("TmpVector2") || characterMeshDitherDetectComponent.TmpVector2 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector2), "TmpVector2")) && (!base.CanResetComponentProperty("TmpRotator") || characterMeshDitherDetectComponent.TmpRotator == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator), "TmpRotator")) && (!base.CanResetComponentProperty("TmpRotator1") || characterMeshDitherDetectComponent.TmpRotator1 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator1), "TmpRotator1")) && (!base.CanResetComponentProperty("TmpRotator2") || characterMeshDitherDetectComponent.TmpRotator2 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TmpRotator2), "TmpRotator2")) && (!base.CanResetComponentProperty("TmpQuat2") || characterMeshDitherDetectComponent.TmpQuat2 == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TmpQuat2), "TmpQuat2"));
		}

		// Token: 0x06030DD6 RID: 200150 RVA: 0x00C1AEDC File Offset: 0x00C190DC
		public CharacterMeshDitherDetectComponent()
		{
			Comparison<MeshDitherDetectConfig> compare;
			if ((compare = CharacterMeshDitherDetectComponent.<>O.<0>__CompareMeshDitherDetectConfigPriority) == null)
			{
				compare = (CharacterMeshDitherDetectComponent.<>O.<0>__CompareMeshDitherDetectConfigPriority = new Comparison<MeshDitherDetectConfig>(CharacterMeshDitherDetectComponent.CompareMeshDitherDetectConfigPriority));
			}
			this.MeshDitherDetectConfigList = new PriorityQueue<MeshDitherDetectConfig>(compare);
			this.ComponentDisableHandle = -1;
			this.CharacterDitherDistance = 9999999f;
			this.GravityQuat = Quat.Create(0f, 0f, 0f, 1f);
			this.GravityQuatInverse = Quat.Create(0f, 0f, 0f, 1f);
			this.GravityQuat1 = Quat.Create(0f, 0f, 0f, 1f);
			this.GravityQuatInverse1 = Quat.Create(0f, 0f, 0f, 1f);
			this.TraceStartLocation = Vector.Create();
			this.TraceEndLocation = Vector.Create();
			this.TmpVector = Vector.Create();
			this.TmpVector1 = Vector.Create();
			this.TmpVector2 = Vector.Create();
			this.TmpRotator = Rotator.Create();
			this.TmpRotator1 = Rotator.Create();
			this.TmpRotator2 = Rotator.Create();
			this.TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);
			base..ctor();
		}

		// Token: 0x0401C14C RID: 115020
		private const float MIN_DITHER = 0.01f;

		// Token: 0x0401C14D RID: 115021
		private const float MAX_VALUE = 9999999f;

		// Token: 0x0401C14E RID: 115022
		private const int COMPONENT_DISABLE_KEY = -1;

		// Token: 0x0401C14F RID: 115023
		private const string PROFILE_KEY = "MeshDitherDetectTrace";

		// Token: 0x0401C150 RID: 115024
		[Nullable(2)]
		public MeshDitherDetectConfig MeshDitherDetectConfig;

		// Token: 0x0401C151 RID: 115025
		private int MeshDitherDetectConfigId;

		// Token: 0x0401C152 RID: 115026
		private readonly Dictionary<int, MeshDitherDetectConfig> MeshDitherDetectConfigMap = new Dictionary<int, MeshDitherDetectConfig>();

		// Token: 0x0401C153 RID: 115027
		private readonly PriorityQueue<MeshDitherDetectConfig> MeshDitherDetectConfigList;

		// Token: 0x0401C154 RID: 115028
		[Nullable(2)]
		private EntityHandle EntityHandle;

		// Token: 0x0401C155 RID: 115029
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C156 RID: 115030
		[Nullable(2)]
		private CharacterMoveComponent MoveComp;

		// Token: 0x0401C157 RID: 115031
		[Nullable(2)]
		private UTraceCapsuleElement TraceElement;

		// Token: 0x0401C158 RID: 115032
		private int ComponentDisableHandle;

		// Token: 0x0401C159 RID: 115033
		private bool EnableDither;

		// Token: 0x0401C15A RID: 115034
		private float CharacterDitherDistance;

		// Token: 0x0401C15B RID: 115035
		private readonly Quat GravityQuat;

		// Token: 0x0401C15C RID: 115036
		private readonly Quat GravityQuatInverse;

		// Token: 0x0401C15D RID: 115037
		private readonly Quat GravityQuat1;

		// Token: 0x0401C15E RID: 115038
		private readonly Quat GravityQuatInverse1;

		// Token: 0x0401C15F RID: 115039
		private readonly Vector TraceStartLocation;

		// Token: 0x0401C160 RID: 115040
		private readonly Vector TraceEndLocation;

		// Token: 0x0401C161 RID: 115041
		private readonly Vector TmpVector;

		// Token: 0x0401C162 RID: 115042
		private readonly Vector TmpVector1;

		// Token: 0x0401C163 RID: 115043
		private readonly Vector TmpVector2;

		// Token: 0x0401C164 RID: 115044
		private readonly Rotator TmpRotator;

		// Token: 0x0401C165 RID: 115045
		private readonly Rotator TmpRotator1;

		// Token: 0x0401C166 RID: 115046
		private readonly Rotator TmpRotator2;

		// Token: 0x0401C167 RID: 115047
		private readonly Quat TmpQuat2;

		// Token: 0x0200A9BF RID: 43455
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040348B4 RID: 215220
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<MeshDitherDetectConfig> <0>__CompareMeshDitherDetectConfigPriority;
		}
	}
}
