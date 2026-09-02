using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MeshDissolve
{
	// Token: 0x02003BC0 RID: 15296
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MeshDissolve/BP_MeshDissolveInteraction.BP_MeshDissolveInteraction_C")]
	[UnrealStructLayout(1568, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1568)]
	public class BP_MeshDissolveInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject, IBulletHitActorInterface, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x06022501 RID: 140545 RVA: 0x00961B8A File Offset: 0x0095FD8A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MeshDissolveInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MeshDissolve/BP_MeshDissolveInteraction.BP_MeshDissolveInteraction_C");
			}
			return BP_MeshDissolveInteraction_C._ClassPtr;
		}

		// Token: 0x06022502 RID: 140546 RVA: 0x00961BAE File Offset: 0x0095FDAE
		int IBulletHitActorInterface.InterfaceOffset()
		{
			return BP_MeshDissolveInteraction_C.__InterfaceOffset_IBulletHitActorInterface;
		}

		// Token: 0x06022503 RID: 140547 RVA: 0x00961BB8 File Offset: 0x0095FDB8
		public BP_MeshDissolveInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_MeshDissolveInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022504 RID: 140548 RVA: 0x00961BE0 File Offset: 0x0095FDE0
		[NullableContext(1)]
		public BP_MeshDissolveInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MeshDissolveInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004039 RID: 16441
		// (get) Token: 0x06022505 RID: 140549 RVA: 0x00961C14 File Offset: 0x0095FE14
		// (set) Token: 0x06022506 RID: 140550 RVA: 0x00961C4D File Offset: 0x0095FE4D
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700403A RID: 16442
		// (get) Token: 0x06022507 RID: 140551 RVA: 0x00961C6E File Offset: 0x0095FE6E
		// (set) Token: 0x06022508 RID: 140552 RVA: 0x00961C82 File Offset: 0x0095FE82
		[Nullable(2)]
		public unsafe UNiagaraComponent NS_Fx_MeshDissolve
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700403B RID: 16443
		// (get) Token: 0x06022509 RID: 140553 RVA: 0x00961C97 File Offset: 0x0095FE97
		// (set) Token: 0x0602250A RID: 140554 RVA: 0x00961CAB File Offset: 0x0095FEAB
		[Nullable(2)]
		public unsafe UStaticMeshComponent Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700403C RID: 16444
		// (get) Token: 0x0602250B RID: 140555 RVA: 0x00961CC0 File Offset: 0x0095FEC0
		// (set) Token: 0x0602250C RID: 140556 RVA: 0x00961CD4 File Offset: 0x0095FED4
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MeshDissolveInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700403D RID: 16445
		// (get) Token: 0x0602250D RID: 140557 RVA: 0x00961CEC File Offset: 0x0095FEEC
		// (set) Token: 0x0602250E RID: 140558 RVA: 0x00961D25 File Offset: 0x0095FF25
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> DMI
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DMI) == null)
				{
					result = (this._DMI = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DMI.CopyAssign(value);
			}
		}

		// Token: 0x1700403E RID: 16446
		// (get) Token: 0x0602250F RID: 140559 RVA: 0x00961D33 File Offset: 0x0095FF33
		// (set) Token: 0x06022510 RID: 140560 RVA: 0x00961D43 File Offset: 0x0095FF43
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700403F RID: 16447
		// (get) Token: 0x06022511 RID: 140561 RVA: 0x00961D54 File Offset: 0x0095FF54
		// (set) Token: 0x06022512 RID: 140562 RVA: 0x00961D64 File Offset: 0x0095FF64
		public unsafe bool Dissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004040 RID: 16448
		// (get) Token: 0x06022513 RID: 140563 RVA: 0x00961D75 File Offset: 0x0095FF75
		// (set) Token: 0x06022514 RID: 140564 RVA: 0x00961D85 File Offset: 0x0095FF85
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004041 RID: 16449
		// (get) Token: 0x06022515 RID: 140565 RVA: 0x00961D96 File Offset: 0x0095FF96
		// (set) Token: 0x06022516 RID: 140566 RVA: 0x00961DAA File Offset: 0x0095FFAA
		public unsafe TEnumAsByte<E_MeshDissolveType> StaticMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004042 RID: 16450
		// (get) Token: 0x06022517 RID: 140567 RVA: 0x00961DC0 File Offset: 0x0095FFC0
		// (set) Token: 0x06022518 RID: 140568 RVA: 0x00961DF9 File Offset: 0x0095FFF9
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> MeshMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> result;
				if ((result = this._MeshMap) == null)
				{
					result = (this._MeshMap = new TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh>(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.MeshMap.CopyAssign(value);
			}
		}

		// Token: 0x17004043 RID: 16451
		// (get) Token: 0x06022519 RID: 140569 RVA: 0x00961E07 File Offset: 0x00960007
		// (set) Token: 0x0602251A RID: 140570 RVA: 0x00961E1B File Offset: 0x0096001B
		public unsafe FVector BulletPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17004044 RID: 16452
		// (get) Token: 0x0602251B RID: 140571 RVA: 0x00961E30 File Offset: 0x00960030
		// (set) Token: 0x0602251C RID: 140572 RVA: 0x00961E40 File Offset: 0x00960040
		public unsafe bool Visbility
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004045 RID: 16453
		// (get) Token: 0x0602251D RID: 140573 RVA: 0x00961E51 File Offset: 0x00960051
		// (set) Token: 0x0602251E RID: 140574 RVA: 0x00961E61 File Offset: 0x00960061
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004046 RID: 16454
		// (get) Token: 0x0602251F RID: 140575 RVA: 0x00961E74 File Offset: 0x00960074
		// (set) Token: 0x06022520 RID: 140576 RVA: 0x00961EAD File Offset: 0x009600AD
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> NiagaraMeshMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> result;
				if ((result = this._NiagaraMeshMap) == null)
				{
					result = (this._NiagaraMeshMap = new TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh>(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.NiagaraMeshMap.CopyAssign(value);
			}
		}

		// Token: 0x17004047 RID: 16455
		// (get) Token: 0x06022521 RID: 140577 RVA: 0x00961EBB File Offset: 0x009600BB
		// (set) Token: 0x06022522 RID: 140578 RVA: 0x00961ECF File Offset: 0x009600CF
		public unsafe FLinearColor DissolveColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MeshDissolveInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x06022523 RID: 140579 RVA: 0x00961EE4 File Offset: 0x009600E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void StartDissolve(FVectorDouble HitPos)
		{
			BP_MeshDissolveInteraction_C.__StartDissolve_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__StartDissolve_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__StartDissolve_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__StartDissolve_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitPos = HitPos;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__StartDissolve_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022524 RID: 140580 RVA: 0x00961F2D File Offset: 0x0096012D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x06022525 RID: 140581 RVA: 0x00961F44 File Offset: 0x00960144
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParams(float dt)
		{
			BP_MeshDissolveInteraction_C.__UpdateParams_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__UpdateParams_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__UpdateParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__UpdateParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__UpdateParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022526 RID: 140582 RVA: 0x00961F8A File Offset: 0x0096018A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022527 RID: 140583 RVA: 0x00961F9E File Offset: 0x0096019E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022528 RID: 140584 RVA: 0x00961FB4 File Offset: 0x009601B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022529 RID: 140585 RVA: 0x00961FFC File Offset: 0x009601FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602252A RID: 140586 RVA: 0x00962044 File Offset: 0x00960244
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBulletHit(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602252B RID: 140587 RVA: 0x00962098 File Offset: 0x00960298
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void OnBulletHit_Implementation(int BulletEntityId, in FVectorDouble HitPoint)
		{
			BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__OnBulletHit_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BulletEntityId = BulletEntityId;
			ptr->HitPoint = HitPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__OnBulletHit_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602252C RID: 140588 RVA: 0x009620EC File Offset: 0x009602EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MeshDissolveInteraction(int EntryPoint)
		{
			BP_MeshDissolveInteraction_C.__ExecuteUbergraph_BP_MeshDissolveInteraction_FunctionParams* ptr = stackalloc BP_MeshDissolveInteraction_C.__ExecuteUbergraph_BP_MeshDissolveInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_MeshDissolveInteraction_C.__ExecuteUbergraph_BP_MeshDissolveInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MeshDissolveInteraction_C.__ExecuteUbergraph_BP_MeshDissolveInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MeshDissolveInteraction_C.__ExecuteUbergraph_BP_MeshDissolveInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602252D RID: 140589 RVA: 0x00962133 File Offset: 0x00960333
		protected BP_MeshDissolveInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040115A8 RID: 71080
		internal static int __InterfaceOffset_IBulletHitActorInterface;

		// Token: 0x040115A9 RID: 71081
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MeshDissolve/BP_MeshDissolveInteraction.BP_MeshDissolveInteraction_C";

		// Token: 0x040115AA RID: 71082
		private static IntPtr _ClassPtr;

		// Token: 0x040115AB RID: 71083
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040115AC RID: 71084
		internal static int __PropertyOffset_0;

		// Token: 0x040115AD RID: 71085
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040115AE RID: 71086
		internal static int __PropertyOffset_1;

		// Token: 0x040115AF RID: 71087
		internal static int __PropertyOffset_2;

		// Token: 0x040115B0 RID: 71088
		internal static int __PropertyOffset_3;

		// Token: 0x040115B1 RID: 71089
		internal static int __PropertyOffset_4;

		// Token: 0x040115B2 RID: 71090
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMI;

		// Token: 0x040115B3 RID: 71091
		internal static int __PropertyOffset_5;

		// Token: 0x040115B4 RID: 71092
		internal static int __PropertyOffset_6;

		// Token: 0x040115B5 RID: 71093
		internal static int __PropertyOffset_7;

		// Token: 0x040115B6 RID: 71094
		internal static int __PropertyOffset_8;

		// Token: 0x040115B7 RID: 71095
		internal static int __PropertyOffset_9;

		// Token: 0x040115B8 RID: 71096
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> _MeshMap;

		// Token: 0x040115B9 RID: 71097
		internal static int __PropertyOffset_10;

		// Token: 0x040115BA RID: 71098
		internal static int __PropertyOffset_11;

		// Token: 0x040115BB RID: 71099
		internal static int __PropertyOffset_12;

		// Token: 0x040115BC RID: 71100
		internal static int __PropertyOffset_13;

		// Token: 0x040115BD RID: 71101
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<E_MeshDissolveType>, UStaticMesh> _NiagaraMeshMap;

		// Token: 0x040115BE RID: 71102
		internal static int __PropertyOffset_14;

		// Token: 0x040115BF RID: 71103
		private static IntPtr __StartDissolve_NativeFunctionPtr;

		// Token: 0x040115C0 RID: 71104
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x040115C1 RID: 71105
		private static IntPtr __UpdateParams_NativeFunctionPtr;

		// Token: 0x040115C2 RID: 71106
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040115C3 RID: 71107
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040115C4 RID: 71108
		private static IntPtr __OnBulletHit_NativeFunctionPtr;

		// Token: 0x040115C5 RID: 71109
		private static IntPtr __ExecuteUbergraph_BP_MeshDissolveInteraction_NativeFunctionPtr;

		// Token: 0x02009BBE RID: 39870
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __StartDissolve_FunctionParams
		{
			// Token: 0x040323F1 RID: 205809
			[FieldOffset(0)]
			public FVectorDouble HitPos;
		}

		// Token: 0x02009BBF RID: 39871
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __UpdateParams_FunctionParams
		{
			// Token: 0x040323F2 RID: 205810
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x02009BC0 RID: 39872
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323F3 RID: 205811
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BC1 RID: 39873
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnBulletHit_FunctionParams
		{
			// Token: 0x040323F4 RID: 205812
			[FieldOffset(0)]
			public int BulletEntityId;

			// Token: 0x040323F5 RID: 205813
			[FieldOffset(8)]
			public FVectorDouble HitPoint;
		}

		// Token: 0x02009BC2 RID: 39874
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __ExecuteUbergraph_BP_MeshDissolveInteraction_FunctionParams
		{
			// Token: 0x040323F6 RID: 205814
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
