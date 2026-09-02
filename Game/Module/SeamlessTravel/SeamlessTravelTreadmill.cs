using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x0200500A RID: 20490
	[NullableContext(1)]
	[Nullable(0)]
	public class SeamlessTravelTreadmill
	{
		// Token: 0x17008AC6 RID: 35526
		// (get) Token: 0x06034D13 RID: 216339 RVA: 0x00D42153 File Offset: 0x00D40353
		public bool IsInit
		{
			get
			{
				return this.IsInitInternal;
			}
		}

		// Token: 0x17008AC7 RID: 35527
		// (get) Token: 0x06034D14 RID: 216340 RVA: 0x00D4215B File Offset: 0x00D4035B
		public bool IsActive
		{
			get
			{
				return this.IsActiveInternal;
			}
		}

		// Token: 0x06034D15 RID: 216341 RVA: 0x00D42164 File Offset: 0x00D40364
		public void Init(SeamlessTravelContext config, Action<bool> callback)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			this.ActorComp = ((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null);
			if (this.ActorComp == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Teleport;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[万向跑步机]初始化失败，无效的ActorComp";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName", Global.BaseCharacter);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.IsActiveInternal = false;
			this.Context = config;
			if (this.IsInit)
			{
				callback(true);
				return;
			}
			this.LoadFloor(callback);
		}

		// Token: 0x06034D16 RID: 216342 RVA: 0x00D421E4 File Offset: 0x00D403E4
		public void Tick(float delta)
		{
			if (!this.IsInit)
			{
				return;
			}
			AStaticMeshActor floor = this.Floor;
			if (floor == null || !floor.IsValid())
			{
				return;
			}
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Valid)
			{
				return;
			}
			if (!this.IsActive)
			{
				return;
			}
			this.ActorComp.ActorLocationProxy.Subtraction(this.LockOnLocation, this.LocationDelta);
			this.UpdateFloorMatUV(this.LocationDelta);
			this.LockActorMove();
			SeamlessTravelTreadmill.FloorMaterialParams floorMatParams = this.FloorMatParams;
			if (floorMatParams == null)
			{
				return;
			}
			floorMatParams.Update(delta);
		}

		// Token: 0x06034D17 RID: 216343 RVA: 0x00D42274 File Offset: 0x00D40474
		public void Destroy()
		{
			AStaticMeshActor floor = this.Floor;
			if (floor != null && floor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("SeamlessTravelTreadmill.Destroy", this.Floor, null);
			}
			this.ActorComp = null;
			this.Context = null;
			this.Floor = null;
			this.FloorExtend.Reset();
			this.FloorMatParams = null;
			this.IsLockMove = false;
			this.IsActiveInternal = false;
			this.LockOnLocation.Reset();
			this.LocationDelta.Reset();
			this.TmpVector.Reset();
			this.TmpTransform.Reset();
			this.TmpQuat.Reset();
			this.TmpRotator.Reset();
		}

		// Token: 0x06034D18 RID: 216344 RVA: 0x00D42324 File Offset: 0x00D40524
		public void Reset()
		{
			this.ActorComp = null;
			this.IsLockMove = false;
			this.IsActiveInternal = false;
			if (this.FloorMatParams != null)
			{
				this.FloorMatParams.Reset();
			}
			this.LockOnLocation.Reset();
			this.LocationDelta.Reset();
			this.TmpVector.Reset();
			this.TmpTransform.Reset();
			this.TmpQuat.Reset();
			this.TmpRotator.Reset();
		}

		// Token: 0x06034D19 RID: 216345 RVA: 0x00D4239C File Offset: 0x00D4059C
		protected void GetInitFloorTransform(Transform outTransform)
		{
			this.LockOnGravityDirect.Multiply((double)this.ActorComp.ScaledHalfHeight + this.FloorExtend.Z, this.TmpVector);
			this.TmpVector.AdditionEqual(this.LockOnLocation);
			outTransform.SetLocation(this.TmpVector);
			this.TmpVector.Set(100.0, 100.0, 1.0);
			SeamlessTravelFloorParams floorParams = this.Context.FloorParams;
			if (((floorParams != null) ? floorParams.FloorScale : null) != null)
			{
				Vector tmpVector = this.TmpVector;
				SeamlessTravelFloorParams floorParams2 = this.Context.FloorParams;
				tmpVector.DeepCopy((floorParams2 != null) ? floorParams2.FloorScale : null);
			}
			outTransform.SetScale3D(this.TmpVector);
			Quat quat = Quat.Create(0f, 0f, 0f, 1f);
			Quat.FindBetween(Vector.DownVectorProxy, this.LockOnGravityDirect, this.TmpQuat);
			this.TmpQuat.Multiply(Rotator.ZeroRotatorProxy.Quaternion(null), quat);
			outTransform.SetRotation(quat);
		}

		// Token: 0x06034D1A RID: 216346 RVA: 0x00D424AC File Offset: 0x00D406AC
		protected void HandleFalseInit(Action<bool> callback)
		{
			callback(false);
			this.IsInitInternal = true;
		}

		// Token: 0x06034D1B RID: 216347 RVA: 0x00D424BC File Offset: 0x00D406BC
		protected unsafe void LoadFloor(Action<bool> callback)
		{
			SeamlessTravelTreadmill.<>c__DisplayClass35_0 CS$<>8__locals1 = new SeamlessTravelTreadmill.<>c__DisplayClass35_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			SeamlessTravelTreadmill.<>c__DisplayClass35_0 CS$<>8__locals2 = CS$<>8__locals1;
			SeamlessTravelFloorParams floorParams = this.Context.FloorParams;
			CS$<>8__locals2.meshPath = (((floorParams != null) ? floorParams.FloorMeshPath : null) ?? "/Engine/BasicShapes/Plane.Plane");
			Singleton<ResourceSystem>.Instance.LoadAsync<UStaticMesh>(CS$<>8__locals1.meshPath, delegate([Nullable(2)] UStaticMesh result, string _)
			{
				if (result == null || !result.IsValid())
				{
					CS$<>8__locals1.<>4__this.HandleFalseInit(CS$<>8__locals1.callback);
					return;
				}
				CharacterActorComponent actorComp = CS$<>8__locals1.<>4__this.ActorComp;
				bool flag;
				if (actorComp == null)
				{
					flag = true;
				}
				else
				{
					TsBaseCharacter actor = actorComp.Actor;
					flag = !((actor != null) ? new bool?(actor.IsValid()) : null).GetValueOrDefault();
				}
				if (flag)
				{
					CS$<>8__locals1.<>4__this.HandleFalseInit(CS$<>8__locals1.callback);
					return;
				}
				CS$<>8__locals1.<>4__this.GetInitFloorTransform(CS$<>8__locals1.<>4__this.TmpTransform);
				CS$<>8__locals1.<>4__this.Floor = (Singleton<ActorSystem>.Instance.Get(AStaticMeshActor.StaticClass(), CS$<>8__locals1.<>4__this.TmpTransform.ToUeTransform(), CS$<>8__locals1.<>4__this.ActorComp.Actor, true) as AStaticMeshActor);
				AStaticMeshActor floor = CS$<>8__locals1.<>4__this.Floor;
				if (floor == null || !floor.IsValid())
				{
					CS$<>8__locals1.<>4__this.HandleFalseInit(CS$<>8__locals1.callback);
					return;
				}
				Vector scale3D = CS$<>8__locals1.<>4__this.TmpTransform.GetScale3D();
				FBoxSphereBounds bounds = result.GetBounds();
				CS$<>8__locals1.<>4__this.FloorExtend.X = (double)bounds.BoxExtent.X * scale3D.X;
				CS$<>8__locals1.<>4__this.FloorExtend.Y = (double)bounds.BoxExtent.Y * scale3D.Y;
				CS$<>8__locals1.<>4__this.FloorExtend.Z = (double)bounds.BoxExtent.Z;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[万向跑步机]加载地板Mesh";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bound", CS$<>8__locals1.<>4__this.FloorExtend);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Path", CS$<>8__locals1.meshPath);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				CS$<>8__locals1.<>4__this.Floor.StaticMeshComponent.SetMobility(EComponentMobility.Movable);
				CS$<>8__locals1.<>4__this.Floor.StaticMeshComponent.SetStaticMesh(result);
				CS$<>8__locals1.<>4__this.Floor.StaticMeshComponent.SetEnableGravity(false);
				CS$<>8__locals1.<>4__this.LoadFloorMaterial(CS$<>8__locals1.callback);
				if (CS$<>8__locals1.<>4__this.Context.FloorParams == null)
				{
					CS$<>8__locals1.<>4__this.Floor.SetActorHiddenInGame(true);
				}
			}, ResourceSystem.EResourceLoadPriority.Default, "SeamlessTravel");
		}

		// Token: 0x06034D1C RID: 216348 RVA: 0x00D42528 File Offset: 0x00D40728
		protected void LoadFloorMaterial(Action<bool> callback)
		{
			SeamlessTravelFloorParams floorParams = this.Context.FloorParams;
			if (string.IsNullOrEmpty((floorParams != null) ? floorParams.FloorMaterialPath : null))
			{
				this.HandleFalseInit(callback);
				Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.YJX, "[万向跑步机]没有配置材质，不加载", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.FloorMatParams = new SeamlessTravelTreadmill.FloorMaterialParams(this);
			string matPath = this.Context.FloorParams.FloorMaterialPath;
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInstance>(matPath, delegate([Nullable(2)] UMaterialInstance result, string _)
			{
				if (result == null || !result.IsValid())
				{
					this.HandleFalseInit(callback);
					return;
				}
				AStaticMeshActor floor = this.Floor;
				if (floor == null || !floor.IsValid())
				{
					this.HandleFalseInit(callback);
					return;
				}
				this.Floor.StaticMeshComponent.SetMaterial(0, result);
				UMaterialInstanceDynamic umaterialInstanceDynamic = this.Floor.StaticMeshComponent.CreateDynamicMaterialInstance(0, result, default(FName));
				if (umaterialInstanceDynamic == null || !umaterialInstanceDynamic.IsValid())
				{
					this.HandleFalseInit(callback);
					return;
				}
				callback(true);
				this.IsInitInternal = true;
				this.FloorMatParams.Bind(umaterialInstanceDynamic);
				this.Floor.StaticMeshComponent.SetMaterial(0, umaterialInstanceDynamic);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[万向跑步机]加载地板材质";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", matPath);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, ResourceSystem.EResourceLoadPriority.Default, "SeamlessTravel.Treadmill");
		}

		// Token: 0x06034D1D RID: 216349 RVA: 0x00D425D8 File Offset: 0x00D407D8
		protected void UpdateFloorMatUV(Vector moveDelta)
		{
			if (!this.IsLockMove)
			{
				return;
			}
			if (this.FloorMatParams == null)
			{
				return;
			}
			double num = 2.0 * this.FloorExtend.X;
			double num2 = 2.0 * this.FloorExtend.Y;
			this.GetInitFloorTransform(this.TmpTransform);
			this.TmpTransform.GetRotation().Inverse(this.TmpQuat);
			this.TmpQuat.RotateVector(moveDelta, this.TmpVector);
			SeamlessTravelTreadmill.FloorMaterialParams floorMatParams = this.FloorMatParams;
			floorMatParams.Offset.R = floorMatParams.Offset.R + (float)(this.TmpVector.X % num / num);
			SeamlessTravelTreadmill.FloorMaterialParams floorMatParams2 = this.FloorMatParams;
			floorMatParams2.Offset.G = floorMatParams2.Offset.G + (float)(this.TmpVector.Y % num2 / num2);
		}

		// Token: 0x06034D1E RID: 216350 RVA: 0x00D426A0 File Offset: 0x00D408A0
		protected void LockActorMove()
		{
			if (this.ActorComp == null)
			{
				return;
			}
			if (!this.IsLockMove)
			{
				return;
			}
			BaseGravityComponent component = this.ActorComp.Entity.GetComponent<BaseGravityComponent>();
			if (component != null)
			{
				component.SetGravityByPriority(0, this.LockOnGravityDirect, true, -1f, true);
			}
			this.ActorComp.ActorLocationProxy.Subtraction(this.LockOnLocation, this.TmpVector);
			double inB = Vector.DotProduct(this.TmpVector, this.LockOnGravityDirect);
			this.LockOnGravityDirect.Multiply(inB, this.TmpVector);
			this.TmpVector.AdditionEqual(this.LockOnLocation);
			this.ActorComp.SetActorLocation(this.TmpVector.ToUeVector(false), "万向跑步机锁定位置", true);
		}

		// Token: 0x06034D1F RID: 216351 RVA: 0x00D4275C File Offset: 0x00D4095C
		public void AppearEffect(Action callback)
		{
			if (this.FloorMatParams == null)
			{
				callback();
				return;
			}
			double alphaDelta = 0.5;
			SeamlessTravelFloorParams floorParams = this.Context.FloorParams;
			if (floorParams != null && floorParams.FloorAppearTime > 0f)
			{
				alphaDelta = 1.0 / (double)this.Context.FloorParams.FloorAppearTime;
			}
			this.FloorMatParams.OnAppearEndHandle = callback;
			this.FloorMatParams.AlphaDelta = alphaDelta;
			this.IsActiveInternal = true;
		}

		// Token: 0x06034D20 RID: 216352 RVA: 0x00D427E0 File Offset: 0x00D409E0
		public void DisappearEffect(Action callback)
		{
			if (this.FloorMatParams == null)
			{
				callback();
				return;
			}
			Action onDisappearEndHandle = delegate()
			{
				callback();
				this.IsActiveInternal = false;
			};
			double num = 0.5;
			SeamlessTravelFloorParams floorParams = this.Context.FloorParams;
			if (floorParams != null && floorParams.FloorDisappearTime > 0f)
			{
				num = 1.0 / (double)this.Context.FloorParams.FloorDisappearTime;
			}
			this.FloorMatParams.OnDisappearEndHandle = onDisappearEndHandle;
			this.FloorMatParams.AlphaDelta = -num;
		}

		// Token: 0x06034D21 RID: 216353 RVA: 0x00D42881 File Offset: 0x00D40A81
		public void EnableLockMove(bool enable)
		{
			this.IsLockMove = enable;
		}

		// Token: 0x06034D22 RID: 216354 RVA: 0x00D4288C File Offset: 0x00D40A8C
		[NullableContext(2)]
		public unsafe void ResetLockOnLocation(Vector targetLocation = null, Vector gravityDirect = null)
		{
			if (this.ActorComp == null)
			{
				return;
			}
			if (targetLocation != null)
			{
				this.LockOnLocation.DeepCopy(targetLocation);
			}
			else
			{
				this.LockOnLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			if (gravityDirect != null)
			{
				this.LockOnGravityDirect.DeepCopy(gravityDirect);
			}
			else
			{
				this.LockOnGravityDirect.DeepCopy(this.ActorComp.ActorGravityDirectProxy);
			}
			AStaticMeshActor floor = this.Floor;
			if (floor != null && floor.IsValid())
			{
				this.GetInitFloorTransform(this.TmpTransform);
				AActor floor2 = this.Floor;
				FTransformDouble ftransformDouble = this.TmpTransform.ToUeTransform();
				floor2.D_K2_SetActorTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[万向跑步机]重置Lock位置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("LockLocation", this.LockOnLocation);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "FloorMeshLocation";
			AStaticMeshActor floor3 = this.Floor;
			ptr = new ValueTuple<string, object>(item, (floor3 != null) ? new FVectorDouble?(floor3.D_K2_GetActorLocation()) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06034D23 RID: 216355 RVA: 0x00D429AC File Offset: 0x00D40BAC
		public void GetLockOnLocation(Vector outVec)
		{
			outVec.DeepCopy(this.LockOnLocation);
		}

		// Token: 0x06034D24 RID: 216356 RVA: 0x00D429BA File Offset: 0x00D40BBA
		[NullableContext(2)]
		public AActor GetFloorActor()
		{
			AStaticMeshActor floor = this.Floor;
			if (floor == null || !floor.IsValid())
			{
				return null;
			}
			return this.Floor;
		}

		// Token: 0x0401E704 RID: 124676
		private const string DEFAULT_FLOOR_MESH_PATH = "/Engine/BasicShapes/Plane.Plane";

		// Token: 0x0401E705 RID: 124677
		private static readonly FName floorMeshMaterialOffsetParam = new FName("Offset");

		// Token: 0x0401E706 RID: 124678
		private static readonly FName floorMeshMaterialAlphaParam = new FName("Alpha");

		// Token: 0x0401E707 RID: 124679
		private const float DEFAULT_APPEAR_ALPHA_DELTA = 0.5f;

		// Token: 0x0401E708 RID: 124680
		private const float DEFAULT_DISAPPEAR_ALPHA_DELTA = 0.5f;

		// Token: 0x0401E709 RID: 124681
		private const int DEFAULT_FLOOR_SCALE_X = 100;

		// Token: 0x0401E70A RID: 124682
		private const int DEFAULT_FLOOR_SCALE_Y = 100;

		// Token: 0x0401E70B RID: 124683
		private const int DEFAULT_FLOOR_SCALE_Z = 1;

		// Token: 0x0401E70C RID: 124684
		public const int DEFAULT_SEAMLESS_TRANSITION_HEIGHT = 2000000;

		// Token: 0x0401E70D RID: 124685
		[Nullable(2)]
		protected CharacterActorComponent ActorComp;

		// Token: 0x0401E70E RID: 124686
		[Nullable(2)]
		protected SeamlessTravelContext Context;

		// Token: 0x0401E70F RID: 124687
		[Nullable(2)]
		protected AStaticMeshActor Floor;

		// Token: 0x0401E710 RID: 124688
		protected Vector FloorExtend = Vector.Create();

		// Token: 0x0401E711 RID: 124689
		[Nullable(2)]
		protected SeamlessTravelTreadmill.FloorMaterialParams FloorMatParams;

		// Token: 0x0401E712 RID: 124690
		protected bool IsInitInternal;

		// Token: 0x0401E713 RID: 124691
		protected bool IsLockMove;

		// Token: 0x0401E714 RID: 124692
		protected bool IsActiveInternal;

		// Token: 0x0401E715 RID: 124693
		protected Vector LockOnLocation = Vector.Create();

		// Token: 0x0401E716 RID: 124694
		protected Vector LockOnGravityDirect = Vector.Create();

		// Token: 0x0401E717 RID: 124695
		protected Vector LocationDelta = Vector.Create();

		// Token: 0x0401E718 RID: 124696
		protected Vector TmpVector = Vector.Create();

		// Token: 0x0401E719 RID: 124697
		protected Transform TmpTransform = Transform.Create();

		// Token: 0x0401E71A RID: 124698
		protected Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

		// Token: 0x0401E71B RID: 124699
		protected Rotator TmpRotator = Rotator.Create();

		// Token: 0x0200AFE4 RID: 45028
		[NullableContext(2)]
		[Nullable(0)]
		protected class FloorMaterialParams
		{
			// Token: 0x0604C330 RID: 312112 RVA: 0x014D5B5C File Offset: 0x014D3D5C
			[NullableContext(1)]
			public FloorMaterialParams(SeamlessTravelTreadmill owner)
			{
				this.Owner = owner;
			}

			// Token: 0x0604C331 RID: 312113 RVA: 0x014D5B8A File Offset: 0x014D3D8A
			[NullableContext(1)]
			public void Bind(UMaterialInstanceDynamic mat)
			{
				if (!mat.IsValid())
				{
					return;
				}
				if (this.Material != null)
				{
					return;
				}
				this.Material = mat;
			}

			// Token: 0x0604C332 RID: 312114 RVA: 0x014D5BA8 File Offset: 0x014D3DA8
			public void Reset()
			{
				this.Offset.R = 0f;
				this.Offset.G = 0f;
				this.Alpha = 0f;
				this.AlphaDelta = 0.0;
				this.OnAppearStartHandle = null;
				this.OnAppearEndHandle = null;
				this.OnDisappearStartHandle = null;
				this.OnDisappearEndHandle = null;
			}

			// Token: 0x0604C333 RID: 312115 RVA: 0x014D5C0C File Offset: 0x014D3E0C
			public void Update(float deltaTime)
			{
				if (!this.Owner.IsInit)
				{
					return;
				}
				if (this.AlphaDelta != 0.0)
				{
					if (this.OnAppearStartHandle != null && this.Alpha == 0f && this.AlphaDelta > 0.0)
					{
						this.OnAppearStartHandle();
					}
					else if (this.OnDisappearStartHandle != null && this.Alpha == 1f && this.AlphaDelta < 0.0)
					{
						this.OnDisappearStartHandle();
					}
					double num = this.AlphaDelta * (double)deltaTime * 0.0010000000474974513;
					this.Alpha = (float)Singleton<MathUtils>.Instance.Clamp((double)this.Alpha + num, 0.0, 1.0);
					UMaterialInstanceDynamic material = this.Material;
					if (material != null)
					{
						material.SetScalarParameterValue(SeamlessTravelTreadmill.floorMeshMaterialAlphaParam, this.Alpha);
					}
					if (this.Alpha <= 0f || this.Alpha >= 1f)
					{
						if (this.OnAppearEndHandle != null && this.Alpha == 1f && this.AlphaDelta > 0.0)
						{
							this.OnAppearEndHandle();
						}
						else if (this.OnDisappearEndHandle != null && this.Alpha == 0f && this.AlphaDelta < 0.0)
						{
							this.OnDisappearEndHandle();
						}
						this.AlphaDelta = 0.0;
					}
				}
				if (this.IsVisible())
				{
					UMaterialInstanceDynamic material2 = this.Material;
					if (material2 == null)
					{
						return;
					}
					material2.SetVectorParameterValue(SeamlessTravelTreadmill.floorMeshMaterialOffsetParam, this.Offset);
				}
			}

			// Token: 0x0604C334 RID: 312116 RVA: 0x014D5DAB File Offset: 0x014D3FAB
			public bool IsVisible()
			{
				return this.Alpha > 0f;
			}

			// Token: 0x04036925 RID: 223525
			public FLinearColor Offset = new FLinearColor(0f, 0f, 0f, 0f);

			// Token: 0x04036926 RID: 223526
			public float Alpha;

			// Token: 0x04036927 RID: 223527
			public double AlphaDelta;

			// Token: 0x04036928 RID: 223528
			[Nullable(1)]
			private readonly SeamlessTravelTreadmill Owner;

			// Token: 0x04036929 RID: 223529
			private UMaterialInstanceDynamic Material;

			// Token: 0x0403692A RID: 223530
			public Action OnAppearStartHandle;

			// Token: 0x0403692B RID: 223531
			public Action OnAppearEndHandle;

			// Token: 0x0403692C RID: 223532
			public Action OnDisappearStartHandle;

			// Token: 0x0403692D RID: 223533
			public Action OnDisappearEndHandle;
		}
	}
}
