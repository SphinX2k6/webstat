using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightningTree
{
	// Token: 0x02003BE2 RID: 15330
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightningTree/BP_LightningTree.BP_LightningTree_C")]
	[UnrealStructLayout(1488, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1473)]
	public class BP_LightningTree_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060226AD RID: 140973 RVA: 0x00964FA8 File Offset: 0x009631A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LightningTree_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LightningTree/BP_LightningTree.BP_LightningTree_C");
			}
			return BP_LightningTree_C._ClassPtr;
		}

		// Token: 0x060226AE RID: 140974 RVA: 0x00964FCC File Offset: 0x009631CC
		public BP_LightningTree_C() : this(BuiltinUtils.AllocNativeUObject(BP_LightningTree_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060226AF RID: 140975 RVA: 0x00964FF4 File Offset: 0x009631F4
		[NullableContext(1)]
		public BP_LightningTree_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LightningTree_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170040A1 RID: 16545
		// (get) Token: 0x060226B0 RID: 140976 RVA: 0x00965028 File Offset: 0x00963228
		// (set) Token: 0x060226B1 RID: 140977 RVA: 0x00965061 File Offset: 0x00963261
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170040A2 RID: 16546
		// (get) Token: 0x060226B2 RID: 140978 RVA: 0x00965082 File Offset: 0x00963282
		// (set) Token: 0x060226B3 RID: 140979 RVA: 0x00965096 File Offset: 0x00963296
		public unsafe UNiagaraComponent NS_Fx_LightningTree
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170040A3 RID: 16547
		// (get) Token: 0x060226B4 RID: 140980 RVA: 0x009650AB File Offset: 0x009632AB
		// (set) Token: 0x060226B5 RID: 140981 RVA: 0x009650BF File Offset: 0x009632BF
		public unsafe UStaticMeshComponent Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170040A4 RID: 16548
		// (get) Token: 0x060226B6 RID: 140982 RVA: 0x009650D4 File Offset: 0x009632D4
		// (set) Token: 0x060226B7 RID: 140983 RVA: 0x009650E8 File Offset: 0x009632E8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170040A5 RID: 16549
		// (get) Token: 0x060226B8 RID: 140984 RVA: 0x009650FD File Offset: 0x009632FD
		// (set) Token: 0x060226B9 RID: 140985 RVA: 0x00965111 File Offset: 0x00963311
		public unsafe UNiagaraSystem LightningEffectNiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170040A6 RID: 16550
		// (get) Token: 0x060226BA RID: 140986 RVA: 0x00965126 File Offset: 0x00963326
		// (set) Token: 0x060226BB RID: 140987 RVA: 0x0096513A File Offset: 0x0096333A
		public unsafe FTransform LightningEffectTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170040A7 RID: 16551
		// (get) Token: 0x060226BC RID: 140988 RVA: 0x00965150 File Offset: 0x00963350
		// (set) Token: 0x060226BD RID: 140989 RVA: 0x00965189 File Offset: 0x00963389
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
					result = (this._DMI = new TArray<UMaterialInstanceDynamic>(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.DMI.CopyAssign(value);
			}
		}

		// Token: 0x170040A8 RID: 16552
		// (get) Token: 0x060226BE RID: 140990 RVA: 0x00965197 File Offset: 0x00963397
		// (set) Token: 0x060226BF RID: 140991 RVA: 0x009651A7 File Offset: 0x009633A7
		public unsafe bool Trigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170040A9 RID: 16553
		// (get) Token: 0x060226C0 RID: 140992 RVA: 0x009651B8 File Offset: 0x009633B8
		// (set) Token: 0x060226C1 RID: 140993 RVA: 0x009651C8 File Offset: 0x009633C8
		public unsafe float DeltaTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170040AA RID: 16554
		// (get) Token: 0x060226C2 RID: 140994 RVA: 0x009651D9 File Offset: 0x009633D9
		// (set) Token: 0x060226C3 RID: 140995 RVA: 0x009651E9 File Offset: 0x009633E9
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170040AB RID: 16555
		// (get) Token: 0x060226C4 RID: 140996 RVA: 0x009651FA File Offset: 0x009633FA
		// (set) Token: 0x060226C5 RID: 140997 RVA: 0x0096520A File Offset: 0x0096340A
		public unsafe float TriggerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170040AC RID: 16556
		// (get) Token: 0x060226C6 RID: 140998 RVA: 0x0096521B File Offset: 0x0096341B
		// (set) Token: 0x060226C7 RID: 140999 RVA: 0x0096522B File Offset: 0x0096342B
		public unsafe float DiffusionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170040AD RID: 16557
		// (get) Token: 0x060226C8 RID: 141000 RVA: 0x0096523C File Offset: 0x0096343C
		// (set) Token: 0x060226C9 RID: 141001 RVA: 0x0096524C File Offset: 0x0096344C
		public unsafe float ParticleEmissionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170040AE RID: 16558
		// (get) Token: 0x060226CA RID: 141002 RVA: 0x0096525D File Offset: 0x0096345D
		// (set) Token: 0x060226CB RID: 141003 RVA: 0x0096526D File Offset: 0x0096346D
		public unsafe float FadedTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170040AF RID: 16559
		// (get) Token: 0x060226CC RID: 141004 RVA: 0x0096527E File Offset: 0x0096347E
		// (set) Token: 0x060226CD RID: 141005 RVA: 0x0096528E File Offset: 0x0096348E
		public unsafe float TriggerDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170040B0 RID: 16560
		// (get) Token: 0x060226CE RID: 141006 RVA: 0x0096529F File Offset: 0x0096349F
		// (set) Token: 0x060226CF RID: 141007 RVA: 0x009652AF File Offset: 0x009634AF
		public unsafe float HitProbability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170040B1 RID: 16561
		// (get) Token: 0x060226D0 RID: 141008 RVA: 0x009652C0 File Offset: 0x009634C0
		// (set) Token: 0x060226D1 RID: 141009 RVA: 0x009652D4 File Offset: 0x009634D4
		public unsafe BP_WeatherController_C WeatherController
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_WeatherController_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170040B2 RID: 16562
		// (get) Token: 0x060226D2 RID: 141010 RVA: 0x009652E9 File Offset: 0x009634E9
		// (set) Token: 0x060226D3 RID: 141011 RVA: 0x009652FD File Offset: 0x009634FD
		public unsafe BP_GlobalGI_C GlobalGI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x170040B3 RID: 16563
		// (get) Token: 0x060226D4 RID: 141012 RVA: 0x00965312 File Offset: 0x00963512
		// (set) Token: 0x060226D5 RID: 141013 RVA: 0x00965326 File Offset: 0x00963526
		public unsafe UMaterialParameterCollection MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LightningTree_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170040B4 RID: 16564
		// (get) Token: 0x060226D6 RID: 141014 RVA: 0x0096533B File Offset: 0x0096353B
		// (set) Token: 0x060226D7 RID: 141015 RVA: 0x0096534B File Offset: 0x0096354B
		public unsafe bool WithinTheRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LightningTree_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x060226D8 RID: 141016 RVA: 0x0096535C File Offset: 0x0096355C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x060226D9 RID: 141017 RVA: 0x00965370 File Offset: 0x00963570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x060226DA RID: 141018 RVA: 0x00965384 File Offset: 0x00963584
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x060226DB RID: 141019 RVA: 0x00965398 File Offset: 0x00963598
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TriggerLightning()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__TriggerLightning_NativeFunctionPtr, null);
		}

		// Token: 0x060226DC RID: 141020 RVA: 0x009653AC File Offset: 0x009635AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060226DD RID: 141021 RVA: 0x009653C0 File Offset: 0x009635C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningTree_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060226DE RID: 141022 RVA: 0x009653D8 File Offset: 0x009635D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LightningTree_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightningTree_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningTree_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060226DF RID: 141023 RVA: 0x00965420 File Offset: 0x00963620
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LightningTree_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LightningTree_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LightningTree_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningTree_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060226E0 RID: 141024 RVA: 0x00965467 File Offset: 0x00963667
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LightningTree_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060226E1 RID: 141025 RVA: 0x0096547B File Offset: 0x0096367B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningTree_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060226E2 RID: 141026 RVA: 0x00965490 File Offset: 0x00963690
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LightningTree(int EntryPoint)
		{
			BP_LightningTree_C.__ExecuteUbergraph_BP_LightningTree_FunctionParams* ptr = stackalloc BP_LightningTree_C.__ExecuteUbergraph_BP_LightningTree_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_LightningTree_C.__ExecuteUbergraph_BP_LightningTree_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LightningTree_C.__ExecuteUbergraph_BP_LightningTree_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LightningTree_C.__ExecuteUbergraph_BP_LightningTree_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060226E3 RID: 141027 RVA: 0x009654D7 File Offset: 0x009636D7
		protected BP_LightningTree_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040116C1 RID: 71361
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightningTree/BP_LightningTree.BP_LightningTree_C";

		// Token: 0x040116C2 RID: 71362
		private static IntPtr _ClassPtr;

		// Token: 0x040116C3 RID: 71363
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040116C4 RID: 71364
		internal static int __PropertyOffset_0;

		// Token: 0x040116C5 RID: 71365
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040116C6 RID: 71366
		internal static int __PropertyOffset_1;

		// Token: 0x040116C7 RID: 71367
		internal static int __PropertyOffset_2;

		// Token: 0x040116C8 RID: 71368
		internal static int __PropertyOffset_3;

		// Token: 0x040116C9 RID: 71369
		internal static int __PropertyOffset_4;

		// Token: 0x040116CA RID: 71370
		internal static int __PropertyOffset_5;

		// Token: 0x040116CB RID: 71371
		internal static int __PropertyOffset_6;

		// Token: 0x040116CC RID: 71372
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceDynamic> _DMI;

		// Token: 0x040116CD RID: 71373
		internal static int __PropertyOffset_7;

		// Token: 0x040116CE RID: 71374
		internal static int __PropertyOffset_8;

		// Token: 0x040116CF RID: 71375
		internal static int __PropertyOffset_9;

		// Token: 0x040116D0 RID: 71376
		internal static int __PropertyOffset_10;

		// Token: 0x040116D1 RID: 71377
		internal static int __PropertyOffset_11;

		// Token: 0x040116D2 RID: 71378
		internal static int __PropertyOffset_12;

		// Token: 0x040116D3 RID: 71379
		internal static int __PropertyOffset_13;

		// Token: 0x040116D4 RID: 71380
		internal static int __PropertyOffset_14;

		// Token: 0x040116D5 RID: 71381
		internal static int __PropertyOffset_15;

		// Token: 0x040116D6 RID: 71382
		internal static int __PropertyOffset_16;

		// Token: 0x040116D7 RID: 71383
		internal static int __PropertyOffset_17;

		// Token: 0x040116D8 RID: 71384
		internal static int __PropertyOffset_18;

		// Token: 0x040116D9 RID: 71385
		internal static int __PropertyOffset_19;

		// Token: 0x040116DA RID: 71386
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x040116DB RID: 71387
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x040116DC RID: 71388
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x040116DD RID: 71389
		private static IntPtr __TriggerLightning_NativeFunctionPtr;

		// Token: 0x040116DE RID: 71390
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040116DF RID: 71391
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040116E0 RID: 71392
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040116E1 RID: 71393
		private static IntPtr __ExecuteUbergraph_BP_LightningTree_NativeFunctionPtr;

		// Token: 0x02009BD5 RID: 39893
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403241B RID: 205851
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD6 RID: 39894
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_LightningTree_FunctionParams
		{
			// Token: 0x0403241C RID: 205852
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
