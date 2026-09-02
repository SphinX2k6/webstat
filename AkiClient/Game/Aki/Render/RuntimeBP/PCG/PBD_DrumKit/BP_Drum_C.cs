using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PBD_DrumKit
{
	// Token: 0x02003BB7 RID: 15287
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Drum.BP_Drum_C")]
	[UnrealStructLayout(1496, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1492)]
	public class BP_Drum_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060223B6 RID: 140214 RVA: 0x0095F67B File Offset: 0x0095D87B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Drum_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Drum.BP_Drum_C");
			}
			return BP_Drum_C._ClassPtr;
		}

		// Token: 0x060223B7 RID: 140215 RVA: 0x0095F6A0 File Offset: 0x0095D8A0
		public BP_Drum_C() : this(BuiltinUtils.AllocNativeUObject(BP_Drum_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060223B8 RID: 140216 RVA: 0x0095F6C8 File Offset: 0x0095D8C8
		[NullableContext(1)]
		public BP_Drum_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Drum_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003FC4 RID: 16324
		// (get) Token: 0x060223B9 RID: 140217 RVA: 0x0095F6FC File Offset: 0x0095D8FC
		// (set) Token: 0x060223BA RID: 140218 RVA: 0x0095F735 File Offset: 0x0095D935
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003FC5 RID: 16325
		// (get) Token: 0x060223BB RID: 140219 RVA: 0x0095F756 File Offset: 0x0095D956
		// (set) Token: 0x060223BC RID: 140220 RVA: 0x0095F76A File Offset: 0x0095D96A
		public unsafe UStaticMeshComponent StaticMesh3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003FC6 RID: 16326
		// (get) Token: 0x060223BD RID: 140221 RVA: 0x0095F77F File Offset: 0x0095D97F
		// (set) Token: 0x060223BE RID: 140222 RVA: 0x0095F793 File Offset: 0x0095D993
		public unsafe UStaticMeshComponent StaticMesh2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003FC7 RID: 16327
		// (get) Token: 0x060223BF RID: 140223 RVA: 0x0095F7A8 File Offset: 0x0095D9A8
		// (set) Token: 0x060223C0 RID: 140224 RVA: 0x0095F7BC File Offset: 0x0095D9BC
		public unsafe UStaticMeshComponent StaticMesh1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003FC8 RID: 16328
		// (get) Token: 0x060223C1 RID: 140225 RVA: 0x0095F7D1 File Offset: 0x0095D9D1
		// (set) Token: 0x060223C2 RID: 140226 RVA: 0x0095F7E5 File Offset: 0x0095D9E5
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003FC9 RID: 16329
		// (get) Token: 0x060223C3 RID: 140227 RVA: 0x0095F7FA File Offset: 0x0095D9FA
		// (set) Token: 0x060223C4 RID: 140228 RVA: 0x0095F80E File Offset: 0x0095DA0E
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003FCA RID: 16330
		// (get) Token: 0x060223C5 RID: 140229 RVA: 0x0095F823 File Offset: 0x0095DA23
		// (set) Token: 0x060223C6 RID: 140230 RVA: 0x0095F833 File Offset: 0x0095DA33
		public unsafe float MeshBoundRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003FCB RID: 16331
		// (get) Token: 0x060223C7 RID: 140231 RVA: 0x0095F844 File Offset: 0x0095DA44
		// (set) Token: 0x060223C8 RID: 140232 RVA: 0x0095F858 File Offset: 0x0095DA58
		public unsafe FVectorDouble MeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003FCC RID: 16332
		// (get) Token: 0x060223C9 RID: 140233 RVA: 0x0095F86D File Offset: 0x0095DA6D
		// (set) Token: 0x060223CA RID: 140234 RVA: 0x0095F87D File Offset: 0x0095DA7D
		public unsafe float PlayerImpulseLerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003FCD RID: 16333
		// (get) Token: 0x060223CB RID: 140235 RVA: 0x0095F88E File Offset: 0x0095DA8E
		// (set) Token: 0x060223CC RID: 140236 RVA: 0x0095F89E File Offset: 0x0095DA9E
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003FCE RID: 16334
		// (get) Token: 0x060223CD RID: 140237 RVA: 0x0095F8AF File Offset: 0x0095DAAF
		// (set) Token: 0x060223CE RID: 140238 RVA: 0x0095F8BF File Offset: 0x0095DABF
		public unsafe float PlayerImpulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003FCF RID: 16335
		// (get) Token: 0x060223CF RID: 140239 RVA: 0x0095F8D0 File Offset: 0x0095DAD0
		// (set) Token: 0x060223D0 RID: 140240 RVA: 0x0095F8E4 File Offset: 0x0095DAE4
		public unsafe FVector CurWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003FD0 RID: 16336
		// (get) Token: 0x060223D1 RID: 140241 RVA: 0x0095F8F9 File Offset: 0x0095DAF9
		// (set) Token: 0x060223D2 RID: 140242 RVA: 0x0095F90D File Offset: 0x0095DB0D
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003FD1 RID: 16337
		// (get) Token: 0x060223D3 RID: 140243 RVA: 0x0095F922 File Offset: 0x0095DB22
		// (set) Token: 0x060223D4 RID: 140244 RVA: 0x0095F932 File Offset: 0x0095DB32
		public unsafe float HitRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003FD2 RID: 16338
		// (get) Token: 0x060223D5 RID: 140245 RVA: 0x0095F943 File Offset: 0x0095DB43
		// (set) Token: 0x060223D6 RID: 140246 RVA: 0x0095F953 File Offset: 0x0095DB53
		public unsafe float DamageForce
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003FD3 RID: 16339
		// (get) Token: 0x060223D7 RID: 140247 RVA: 0x0095F964 File Offset: 0x0095DB64
		// (set) Token: 0x060223D8 RID: 140248 RVA: 0x0095F978 File Offset: 0x0095DB78
		public unsafe UMaterialInstance MI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Drum_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003FD4 RID: 16340
		// (get) Token: 0x060223D9 RID: 140249 RVA: 0x0095F990 File Offset: 0x0095DB90
		// (set) Token: 0x060223DA RID: 140250 RVA: 0x0095F9C9 File Offset: 0x0095DBC9
		[Nullable(1)]
		public TArray<UMaterialInstanceDynamic> DynamicMaterials
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceDynamic> result;
				if ((result = this._DynamicMaterials) == null)
				{
					result = (this._DynamicMaterials = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_16, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DynamicMaterials.CopyAssign(value);
			}
		}

		// Token: 0x17003FD5 RID: 16341
		// (get) Token: 0x060223DB RID: 140251 RVA: 0x0095F9D8 File Offset: 0x0095DBD8
		// (set) Token: 0x060223DC RID: 140252 RVA: 0x0095FA11 File Offset: 0x0095DC11
		[Nullable(1)]
		public TArray<float> Timer
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Timer) == null)
				{
					result = (this._Timer = new TArray<float>(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_17, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Timer.CopyAssign(value);
			}
		}

		// Token: 0x17003FD6 RID: 16342
		// (get) Token: 0x060223DD RID: 140253 RVA: 0x0095FA20 File Offset: 0x0095DC20
		// (set) Token: 0x060223DE RID: 140254 RVA: 0x0095FA59 File Offset: 0x0095DC59
		[Nullable(1)]
		public TArray<UStaticMeshComponent> Meshes
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._Meshes) == null)
				{
					result = (this._Meshes = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Meshes.CopyAssign(value);
			}
		}

		// Token: 0x17003FD7 RID: 16343
		// (get) Token: 0x060223DF RID: 140255 RVA: 0x0095FA67 File Offset: 0x0095DC67
		// (set) Token: 0x060223E0 RID: 140256 RVA: 0x0095FA77 File Offset: 0x0095DC77
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Drum_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x060223E1 RID: 140257 RVA: 0x0095FA88 File Offset: 0x0095DC88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060223E2 RID: 140258 RVA: 0x0095FA9C File Offset: 0x0095DC9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223E3 RID: 140259 RVA: 0x0095FAB4 File Offset: 0x0095DCB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Completed_971E8CDE49000EC1340651962C6B5599(int PlayingID)
		{
			BP_Drum_C.__Completed_971E8CDE49000EC1340651962C6B5599_FunctionParams* ptr = stackalloc BP_Drum_C.__Completed_971E8CDE49000EC1340651962C6B5599_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Drum_C.__Completed_971E8CDE49000EC1340651962C6B5599_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Drum_C.__Completed_971E8CDE49000EC1340651962C6B5599_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayingID = PlayingID;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__Completed_971E8CDE49000EC1340651962C6B5599_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223E4 RID: 140260 RVA: 0x0095FAFA File Offset: 0x0095DCFA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060223E5 RID: 140261 RVA: 0x0095FB0E File Offset: 0x0095DD0E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223E6 RID: 140262 RVA: 0x0095FB24 File Offset: 0x0095DD24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Drum_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Drum_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Drum_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Drum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223E7 RID: 140263 RVA: 0x0095FB6C File Offset: 0x0095DD6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Drum_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Drum_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Drum_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Drum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060223E8 RID: 140264 RVA: 0x0095FBB3 File Offset: 0x0095DDB3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x060223E9 RID: 140265 RVA: 0x0095FBC7 File Offset: 0x0095DDC7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223EA RID: 140266 RVA: 0x0095FBDC File Offset: 0x0095DDDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x060223EB RID: 140267 RVA: 0x0095FBF0 File Offset: 0x0095DDF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060223EC RID: 140268 RVA: 0x0095FC08 File Offset: 0x0095DE08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_Drum_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_Drum_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_Drum_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Drum_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Drum_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060223ED RID: 140269 RVA: 0x0095FC6C File Offset: 0x0095DE6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Drum(int EntryPoint)
		{
			BP_Drum_C.__ExecuteUbergraph_BP_Drum_FunctionParams* ptr = stackalloc BP_Drum_C.__ExecuteUbergraph_BP_Drum_FunctionParams[(UIntPtr)663] + 15L / (long)sizeof(BP_Drum_C.__ExecuteUbergraph_BP_Drum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Drum_C.__ExecuteUbergraph_BP_Drum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Drum_C.__ExecuteUbergraph_BP_Drum_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060223EE RID: 140270 RVA: 0x0095FCB6 File Offset: 0x0095DEB6
		protected BP_Drum_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040114E4 RID: 70884
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PBD_DrumKit/BP_Drum.BP_Drum_C";

		// Token: 0x040114E5 RID: 70885
		private static IntPtr _ClassPtr;

		// Token: 0x040114E6 RID: 70886
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040114E7 RID: 70887
		internal static int __PropertyOffset_0;

		// Token: 0x040114E8 RID: 70888
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040114E9 RID: 70889
		internal static int __PropertyOffset_1;

		// Token: 0x040114EA RID: 70890
		internal static int __PropertyOffset_2;

		// Token: 0x040114EB RID: 70891
		internal static int __PropertyOffset_3;

		// Token: 0x040114EC RID: 70892
		internal static int __PropertyOffset_4;

		// Token: 0x040114ED RID: 70893
		internal static int __PropertyOffset_5;

		// Token: 0x040114EE RID: 70894
		internal static int __PropertyOffset_6;

		// Token: 0x040114EF RID: 70895
		internal static int __PropertyOffset_7;

		// Token: 0x040114F0 RID: 70896
		internal static int __PropertyOffset_8;

		// Token: 0x040114F1 RID: 70897
		internal static int __PropertyOffset_9;

		// Token: 0x040114F2 RID: 70898
		internal static int __PropertyOffset_10;

		// Token: 0x040114F3 RID: 70899
		internal static int __PropertyOffset_11;

		// Token: 0x040114F4 RID: 70900
		internal static int __PropertyOffset_12;

		// Token: 0x040114F5 RID: 70901
		internal static int __PropertyOffset_13;

		// Token: 0x040114F6 RID: 70902
		internal static int __PropertyOffset_14;

		// Token: 0x040114F7 RID: 70903
		internal static int __PropertyOffset_15;

		// Token: 0x040114F8 RID: 70904
		internal static int __PropertyOffset_16;

		// Token: 0x040114F9 RID: 70905
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DynamicMaterials;

		// Token: 0x040114FA RID: 70906
		internal static int __PropertyOffset_17;

		// Token: 0x040114FB RID: 70907
		private TArray<float> _Timer;

		// Token: 0x040114FC RID: 70908
		internal static int __PropertyOffset_18;

		// Token: 0x040114FD RID: 70909
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _Meshes;

		// Token: 0x040114FE RID: 70910
		internal static int __PropertyOffset_19;

		// Token: 0x040114FF RID: 70911
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011500 RID: 70912
		private static IntPtr __Completed_971E8CDE49000EC1340651962C6B5599_NativeFunctionPtr;

		// Token: 0x04011501 RID: 70913
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011502 RID: 70914
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011503 RID: 70915
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04011504 RID: 70916
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04011505 RID: 70917
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011506 RID: 70918
		private static IntPtr __ExecuteUbergraph_BP_Drum_NativeFunctionPtr;

		// Token: 0x02009BA7 RID: 39847
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Completed_971E8CDE49000EC1340651962C6B5599_FunctionParams
		{
			// Token: 0x040323D8 RID: 205784
			[FieldOffset(0)]
			public int PlayingID;
		}

		// Token: 0x02009BA8 RID: 39848
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040323D9 RID: 205785
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BA9 RID: 39849
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x040323DA RID: 205786
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x040323DB RID: 205787
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x040323DC RID: 205788
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009BAA RID: 39850
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 648)]
		protected ref struct __ExecuteUbergraph_BP_Drum_FunctionParams
		{
			// Token: 0x040323DD RID: 205789
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
