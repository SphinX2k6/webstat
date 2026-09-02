using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.InteractCar
{
	// Token: 0x02003C0B RID: 15371
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/InteractCar/BP_GashaponCar.BP_GashaponCar_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1446)]
	public class BP_GashaponCar_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022E90 RID: 142992 RVA: 0x00972D17 File Offset: 0x00970F17
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GashaponCar_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/InteractCar/BP_GashaponCar.BP_GashaponCar_C");
			}
			return BP_GashaponCar_C._ClassPtr;
		}

		// Token: 0x06022E91 RID: 142993 RVA: 0x00972D3C File Offset: 0x00970F3C
		public BP_GashaponCar_C() : this(BuiltinUtils.AllocNativeUObject(BP_GashaponCar_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022E92 RID: 142994 RVA: 0x00972D64 File Offset: 0x00970F64
		[NullableContext(1)]
		public BP_GashaponCar_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GashaponCar_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004364 RID: 17252
		// (get) Token: 0x06022E93 RID: 142995 RVA: 0x00972D98 File Offset: 0x00970F98
		// (set) Token: 0x06022E94 RID: 142996 RVA: 0x00972DD1 File Offset: 0x00970FD1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004365 RID: 17253
		// (get) Token: 0x06022E95 RID: 142997 RVA: 0x00972DF2 File Offset: 0x00970FF2
		// (set) Token: 0x06022E96 RID: 142998 RVA: 0x00972E06 File Offset: 0x00971006
		public unsafe UStaticMeshComponent InnerSphere2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004366 RID: 17254
		// (get) Token: 0x06022E97 RID: 142999 RVA: 0x00972E1B File Offset: 0x0097101B
		// (set) Token: 0x06022E98 RID: 143000 RVA: 0x00972E2F File Offset: 0x0097102F
		public unsafe UStaticMeshComponent InnerSphere1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004367 RID: 17255
		// (get) Token: 0x06022E99 RID: 143001 RVA: 0x00972E44 File Offset: 0x00971044
		// (set) Token: 0x06022E9A RID: 143002 RVA: 0x00972E58 File Offset: 0x00971058
		public unsafe UStaticMeshComponent InnerSphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004368 RID: 17256
		// (get) Token: 0x06022E9B RID: 143003 RVA: 0x00972E6D File Offset: 0x0097106D
		// (set) Token: 0x06022E9C RID: 143004 RVA: 0x00972E81 File Offset: 0x00971081
		public unsafe UStaticMeshComponent SM_Col_Car_03AM
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17004369 RID: 17257
		// (get) Token: 0x06022E9D RID: 143005 RVA: 0x00972E96 File Offset: 0x00971096
		// (set) Token: 0x06022E9E RID: 143006 RVA: 0x00972EAA File Offset: 0x009710AA
		public unsafe UStaticMeshComponent OutputLocation
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700436A RID: 17258
		// (get) Token: 0x06022E9F RID: 143007 RVA: 0x00972EBF File Offset: 0x009710BF
		// (set) Token: 0x06022EA0 RID: 143008 RVA: 0x00972ED3 File Offset: 0x009710D3
		public unsafe USphereComponent StartLocation
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x1700436B RID: 17259
		// (get) Token: 0x06022EA1 RID: 143009 RVA: 0x00972EE8 File Offset: 0x009710E8
		// (set) Token: 0x06022EA2 RID: 143010 RVA: 0x00972EFC File Offset: 0x009710FC
		public unsafe USphereComponent WaitLocation
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USphereComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x1700436C RID: 17260
		// (get) Token: 0x06022EA3 RID: 143011 RVA: 0x00972F11 File Offset: 0x00971111
		// (set) Token: 0x06022EA4 RID: 143012 RVA: 0x00972F25 File Offset: 0x00971125
		public unsafe UStaticMeshComponent WaitMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x1700436D RID: 17261
		// (get) Token: 0x06022EA5 RID: 143013 RVA: 0x00972F3A File Offset: 0x0097113A
		// (set) Token: 0x06022EA6 RID: 143014 RVA: 0x00972F4E File Offset: 0x0097114E
		public unsafe UStaticMeshComponent SM_Col_Car_03AM_BP
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700436E RID: 17262
		// (get) Token: 0x06022EA7 RID: 143015 RVA: 0x00972F63 File Offset: 0x00971163
		// (set) Token: 0x06022EA8 RID: 143016 RVA: 0x00972F77 File Offset: 0x00971177
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x1700436F RID: 17263
		// (get) Token: 0x06022EA9 RID: 143017 RVA: 0x00972F8C File Offset: 0x0097118C
		// (set) Token: 0x06022EAA RID: 143018 RVA: 0x00972F9C File Offset: 0x0097119C
		public unsafe float Timeline_0_NewTrack_1_FE9F8C634D2F625B15B8BBB79A742339
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004370 RID: 17264
		// (get) Token: 0x06022EAB RID: 143019 RVA: 0x00972FAD File Offset: 0x009711AD
		// (set) Token: 0x06022EAC RID: 143020 RVA: 0x00972FC1 File Offset: 0x009711C1
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_FE9F8C634D2F625B15B8BBB79A742339
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004371 RID: 17265
		// (get) Token: 0x06022EAD RID: 143021 RVA: 0x00972FD6 File Offset: 0x009711D6
		// (set) Token: 0x06022EAE RID: 143022 RVA: 0x00972FEA File Offset: 0x009711EA
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GashaponCar_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17004372 RID: 17266
		// (get) Token: 0x06022EAF RID: 143023 RVA: 0x00973000 File Offset: 0x00971200
		// (set) Token: 0x06022EB0 RID: 143024 RVA: 0x00973039 File Offset: 0x00971239
		[Nullable(1)]
		public TArray<UStaticMesh> SphereList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._SphereList) == null)
				{
					result = (this._SphereList = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_14, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SphereList.CopyAssign(value);
			}
		}

		// Token: 0x17004373 RID: 17267
		// (get) Token: 0x06022EB1 RID: 143025 RVA: 0x00973047 File Offset: 0x00971247
		// (set) Token: 0x06022EB2 RID: 143026 RVA: 0x00973057 File Offset: 0x00971257
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004374 RID: 17268
		// (get) Token: 0x06022EB3 RID: 143027 RVA: 0x00973068 File Offset: 0x00971268
		// (set) Token: 0x06022EB4 RID: 143028 RVA: 0x00973078 File Offset: 0x00971278
		public unsafe float SphereDestroyTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004375 RID: 17269
		// (get) Token: 0x06022EB5 RID: 143029 RVA: 0x00973089 File Offset: 0x00971289
		// (set) Token: 0x06022EB6 RID: 143030 RVA: 0x00973099 File Offset: 0x00971299
		public unsafe int RandomIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17004376 RID: 17270
		// (get) Token: 0x06022EB7 RID: 143031 RVA: 0x009730AA File Offset: 0x009712AA
		// (set) Token: 0x06022EB8 RID: 143032 RVA: 0x009730BA File Offset: 0x009712BA
		public unsafe bool StartReload
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004377 RID: 17271
		// (get) Token: 0x06022EB9 RID: 143033 RVA: 0x009730CB File Offset: 0x009712CB
		// (set) Token: 0x06022EBA RID: 143034 RVA: 0x009730DB File Offset: 0x009712DB
		public unsafe float ReloadTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17004378 RID: 17272
		// (get) Token: 0x06022EBB RID: 143035 RVA: 0x009730EC File Offset: 0x009712EC
		// (set) Token: 0x06022EBC RID: 143036 RVA: 0x009730FC File Offset: 0x009712FC
		public unsafe bool IsFirstHit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004379 RID: 17273
		// (get) Token: 0x06022EBD RID: 143037 RVA: 0x0097310D File Offset: 0x0097130D
		// (set) Token: 0x06022EBE RID: 143038 RVA: 0x0097311D File Offset: 0x0097131D
		public unsafe bool HitCarMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GashaponCar_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022EBF RID: 143039 RVA: 0x0097312E File Offset: 0x0097132E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GashaponCar_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06022EC0 RID: 143040 RVA: 0x00973142 File Offset: 0x00971342
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GashaponCar_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x06022EC1 RID: 143041 RVA: 0x00973158 File Offset: 0x00971358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GashaponCar_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GashaponCar_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GashaponCar_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GashaponCar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GashaponCar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022EC2 RID: 143042 RVA: 0x009731A0 File Offset: 0x009713A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GashaponCar_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GashaponCar_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GashaponCar_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GashaponCar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GashaponCar_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022EC3 RID: 143043 RVA: 0x009731E7 File Offset: 0x009713E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GashaponCar_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022EC4 RID: 143044 RVA: 0x009731FB File Offset: 0x009713FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GashaponCar_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022EC5 RID: 143045 RVA: 0x00973210 File Offset: 0x00971410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_GashaponCar_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_GashaponCar_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_GashaponCar_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GashaponCar_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GashaponCar_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022EC6 RID: 143046 RVA: 0x00973274 File Offset: 0x00971474
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GashaponCar(int EntryPoint)
		{
			BP_GashaponCar_C.__ExecuteUbergraph_BP_GashaponCar_FunctionParams* ptr = stackalloc BP_GashaponCar_C.__ExecuteUbergraph_BP_GashaponCar_FunctionParams[(UIntPtr)943] + 15L / (long)sizeof(BP_GashaponCar_C.__ExecuteUbergraph_BP_GashaponCar_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GashaponCar_C.__ExecuteUbergraph_BP_GashaponCar_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GashaponCar_C.__ExecuteUbergraph_BP_GashaponCar_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022EC7 RID: 143047 RVA: 0x009732BE File Offset: 0x009714BE
		protected BP_GashaponCar_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011BA7 RID: 72615
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/InteractCar/BP_GashaponCar.BP_GashaponCar_C";

		// Token: 0x04011BA8 RID: 72616
		private static IntPtr _ClassPtr;

		// Token: 0x04011BA9 RID: 72617
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011BAA RID: 72618
		internal static int __PropertyOffset_0;

		// Token: 0x04011BAB RID: 72619
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011BAC RID: 72620
		internal static int __PropertyOffset_1;

		// Token: 0x04011BAD RID: 72621
		internal static int __PropertyOffset_2;

		// Token: 0x04011BAE RID: 72622
		internal static int __PropertyOffset_3;

		// Token: 0x04011BAF RID: 72623
		internal static int __PropertyOffset_4;

		// Token: 0x04011BB0 RID: 72624
		internal static int __PropertyOffset_5;

		// Token: 0x04011BB1 RID: 72625
		internal static int __PropertyOffset_6;

		// Token: 0x04011BB2 RID: 72626
		internal static int __PropertyOffset_7;

		// Token: 0x04011BB3 RID: 72627
		internal static int __PropertyOffset_8;

		// Token: 0x04011BB4 RID: 72628
		internal static int __PropertyOffset_9;

		// Token: 0x04011BB5 RID: 72629
		internal static int __PropertyOffset_10;

		// Token: 0x04011BB6 RID: 72630
		internal static int __PropertyOffset_11;

		// Token: 0x04011BB7 RID: 72631
		internal static int __PropertyOffset_12;

		// Token: 0x04011BB8 RID: 72632
		internal static int __PropertyOffset_13;

		// Token: 0x04011BB9 RID: 72633
		internal static int __PropertyOffset_14;

		// Token: 0x04011BBA RID: 72634
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _SphereList;

		// Token: 0x04011BBB RID: 72635
		internal static int __PropertyOffset_15;

		// Token: 0x04011BBC RID: 72636
		internal static int __PropertyOffset_16;

		// Token: 0x04011BBD RID: 72637
		internal static int __PropertyOffset_17;

		// Token: 0x04011BBE RID: 72638
		internal static int __PropertyOffset_18;

		// Token: 0x04011BBF RID: 72639
		internal static int __PropertyOffset_19;

		// Token: 0x04011BC0 RID: 72640
		internal static int __PropertyOffset_20;

		// Token: 0x04011BC1 RID: 72641
		internal static int __PropertyOffset_21;

		// Token: 0x04011BC2 RID: 72642
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04011BC3 RID: 72643
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04011BC4 RID: 72644
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011BC5 RID: 72645
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011BC6 RID: 72646
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04011BC7 RID: 72647
		private static IntPtr __ExecuteUbergraph_BP_GashaponCar_NativeFunctionPtr;

		// Token: 0x02009C4E RID: 40014
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032503 RID: 206083
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C4F RID: 40015
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032504 RID: 206084
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032505 RID: 206085
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032506 RID: 206086
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x02009C50 RID: 40016
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 928)]
		protected ref struct __ExecuteUbergraph_BP_GashaponCar_FunctionParams
		{
			// Token: 0x04032507 RID: 206087
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
