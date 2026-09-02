using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BakePlanet.BluePrint
{
	// Token: 0x02003C45 RID: 15429
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_GasPlanet.BP_Baked_GasPlanet_C")]
	[UnrealStructLayout(1248, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1248)]
	public class BP_Baked_GasPlanet_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060237B4 RID: 145332 RVA: 0x00983947 File Offset: 0x00981B47
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Baked_GasPlanet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_GasPlanet.BP_Baked_GasPlanet_C");
			}
			return BP_Baked_GasPlanet_C._ClassPtr;
		}

		// Token: 0x060237B5 RID: 145333 RVA: 0x0098396C File Offset: 0x00981B6C
		public BP_Baked_GasPlanet_C() : this(BuiltinUtils.AllocNativeUObject(BP_Baked_GasPlanet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060237B6 RID: 145334 RVA: 0x00983994 File Offset: 0x00981B94
		[NullableContext(1)]
		public BP_Baked_GasPlanet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Baked_GasPlanet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046A2 RID: 18082
		// (get) Token: 0x060237B7 RID: 145335 RVA: 0x009839C8 File Offset: 0x00981BC8
		// (set) Token: 0x060237B8 RID: 145336 RVA: 0x00983A01 File Offset: 0x00981C01
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046A3 RID: 18083
		// (get) Token: 0x060237B9 RID: 145337 RVA: 0x00983A22 File Offset: 0x00981C22
		// (set) Token: 0x060237BA RID: 145338 RVA: 0x00983A36 File Offset: 0x00981C36
		public unsafe UStaticMeshComponent Rings
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046A4 RID: 18084
		// (get) Token: 0x060237BB RID: 145339 RVA: 0x00983A4B File Offset: 0x00981C4B
		// (set) Token: 0x060237BC RID: 145340 RVA: 0x00983A5F File Offset: 0x00981C5F
		public unsafe UStaticMeshComponent Planet
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046A5 RID: 18085
		// (get) Token: 0x060237BD RID: 145341 RVA: 0x00983A74 File Offset: 0x00981C74
		// (set) Token: 0x060237BE RID: 145342 RVA: 0x00983A88 File Offset: 0x00981C88
		public unsafe UStaticMeshComponent root
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170046A6 RID: 18086
		// (get) Token: 0x060237BF RID: 145343 RVA: 0x00983A9D File Offset: 0x00981C9D
		// (set) Token: 0x060237C0 RID: 145344 RVA: 0x00983AB1 File Offset: 0x00981CB1
		public unsafe UMaterialInstanceDynamic DMI_Atmosphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170046A7 RID: 18087
		// (get) Token: 0x060237C1 RID: 145345 RVA: 0x00983AC6 File Offset: 0x00981CC6
		// (set) Token: 0x060237C2 RID: 145346 RVA: 0x00983ADA File Offset: 0x00981CDA
		public unsafe UMaterialInstanceDynamic DMI_Planet
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170046A8 RID: 18088
		// (get) Token: 0x060237C3 RID: 145347 RVA: 0x00983AEF File Offset: 0x00981CEF
		// (set) Token: 0x060237C4 RID: 145348 RVA: 0x00983B03 File Offset: 0x00981D03
		public unsafe UMaterialInstanceDynamic DMI_Rings
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170046A9 RID: 18089
		// (get) Token: 0x060237C5 RID: 145349 RVA: 0x00983B18 File Offset: 0x00981D18
		// (set) Token: 0x060237C6 RID: 145350 RVA: 0x00983B2C File Offset: 0x00981D2C
		public unsafe ADirectionalLight SunLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ADirectionalLight>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170046AA RID: 18090
		// (get) Token: 0x060237C7 RID: 145351 RVA: 0x00983B41 File Offset: 0x00981D41
		// (set) Token: 0x060237C8 RID: 145352 RVA: 0x00983B51 File Offset: 0x00981D51
		public unsafe float PlanetRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170046AB RID: 18091
		// (get) Token: 0x060237C9 RID: 145353 RVA: 0x00983B62 File Offset: 0x00981D62
		// (set) Token: 0x060237CA RID: 145354 RVA: 0x00983B76 File Offset: 0x00981D76
		public unsafe UMaterialInstance Planet_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x170046AC RID: 18092
		// (get) Token: 0x060237CB RID: 145355 RVA: 0x00983B8B File Offset: 0x00981D8B
		// (set) Token: 0x060237CC RID: 145356 RVA: 0x00983B9F File Offset: 0x00981D9F
		public unsafe UMaterialInstance Rings_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Baked_GasPlanet_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x170046AD RID: 18093
		// (get) Token: 0x060237CD RID: 145357 RVA: 0x00983BB4 File Offset: 0x00981DB4
		// (set) Token: 0x060237CE RID: 145358 RVA: 0x00983BC4 File Offset: 0x00981DC4
		public unsafe float Global_Tile_Ratio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170046AE RID: 18094
		// (get) Token: 0x060237CF RID: 145359 RVA: 0x00983BD5 File Offset: 0x00981DD5
		// (set) Token: 0x060237D0 RID: 145360 RVA: 0x00983BE5 File Offset: 0x00981DE5
		public unsafe float Inner_Edge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170046AF RID: 18095
		// (get) Token: 0x060237D1 RID: 145361 RVA: 0x00983BF6 File Offset: 0x00981DF6
		// (set) Token: 0x060237D2 RID: 145362 RVA: 0x00983C06 File Offset: 0x00981E06
		public unsafe float Outer_Edge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170046B0 RID: 18096
		// (get) Token: 0x060237D3 RID: 145363 RVA: 0x00983C17 File Offset: 0x00981E17
		// (set) Token: 0x060237D4 RID: 145364 RVA: 0x00983C27 File Offset: 0x00981E27
		public unsafe float Frequency_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170046B1 RID: 18097
		// (get) Token: 0x060237D5 RID: 145365 RVA: 0x00983C38 File Offset: 0x00981E38
		// (set) Token: 0x060237D6 RID: 145366 RVA: 0x00983C48 File Offset: 0x00981E48
		public unsafe float Frequency_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170046B2 RID: 18098
		// (get) Token: 0x060237D7 RID: 145367 RVA: 0x00983C59 File Offset: 0x00981E59
		// (set) Token: 0x060237D8 RID: 145368 RVA: 0x00983C69 File Offset: 0x00981E69
		public unsafe float Density
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170046B3 RID: 18099
		// (get) Token: 0x060237D9 RID: 145369 RVA: 0x00983C7A File Offset: 0x00981E7A
		// (set) Token: 0x060237DA RID: 145370 RVA: 0x00983C8A File Offset: 0x00981E8A
		public unsafe float Seed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170046B4 RID: 18100
		// (get) Token: 0x060237DB RID: 145371 RVA: 0x00983C9B File Offset: 0x00981E9B
		// (set) Token: 0x060237DC RID: 145372 RVA: 0x00983CAB File Offset: 0x00981EAB
		public unsafe float Edge_Hardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170046B5 RID: 18101
		// (get) Token: 0x060237DD RID: 145373 RVA: 0x00983CBC File Offset: 0x00981EBC
		// (set) Token: 0x060237DE RID: 145374 RVA: 0x00983CCC File Offset: 0x00981ECC
		public unsafe float Shadow_Strength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170046B6 RID: 18102
		// (get) Token: 0x060237DF RID: 145375 RVA: 0x00983CDD File Offset: 0x00981EDD
		// (set) Token: 0x060237E0 RID: 145376 RVA: 0x00983CED File Offset: 0x00981EED
		public unsafe float Shadow_Hardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170046B7 RID: 18103
		// (get) Token: 0x060237E1 RID: 145377 RVA: 0x00983CFE File Offset: 0x00981EFE
		// (set) Token: 0x060237E2 RID: 145378 RVA: 0x00983D0E File Offset: 0x00981F0E
		public unsafe float Scattering_Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170046B8 RID: 18104
		// (get) Token: 0x060237E3 RID: 145379 RVA: 0x00983D1F File Offset: 0x00981F1F
		// (set) Token: 0x060237E4 RID: 145380 RVA: 0x00983D2F File Offset: 0x00981F2F
		public unsafe float Scattering_Power
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x170046B9 RID: 18105
		// (get) Token: 0x060237E5 RID: 145381 RVA: 0x00983D40 File Offset: 0x00981F40
		// (set) Token: 0x060237E6 RID: 145382 RVA: 0x00983D54 File Offset: 0x00981F54
		public unsafe FLinearColor Rings_Color_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x170046BA RID: 18106
		// (get) Token: 0x060237E7 RID: 145383 RVA: 0x00983D69 File Offset: 0x00981F69
		// (set) Token: 0x060237E8 RID: 145384 RVA: 0x00983D7D File Offset: 0x00981F7D
		public unsafe FLinearColor Rings_Color_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170046BB RID: 18107
		// (get) Token: 0x060237E9 RID: 145385 RVA: 0x00983D92 File Offset: 0x00981F92
		// (set) Token: 0x060237EA RID: 145386 RVA: 0x00983DA6 File Offset: 0x00981FA6
		public unsafe FLinearColor Rings_Color_3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170046BC RID: 18108
		// (get) Token: 0x060237EB RID: 145387 RVA: 0x00983DBB File Offset: 0x00981FBB
		// (set) Token: 0x060237EC RID: 145388 RVA: 0x00983DCF File Offset: 0x00981FCF
		public unsafe FLinearColor Rings_Color_4
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170046BD RID: 18109
		// (get) Token: 0x060237ED RID: 145389 RVA: 0x00983DE4 File Offset: 0x00981FE4
		// (set) Token: 0x060237EE RID: 145390 RVA: 0x00983DF8 File Offset: 0x00981FF8
		public unsafe FLinearColor Rings_Scatering_Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Baked_GasPlanet_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x060237EF RID: 145391 RVA: 0x00983E0D File Offset: 0x0098200D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Baked_GasPlanet_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060237F0 RID: 145392 RVA: 0x00983E21 File Offset: 0x00982021
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_GasPlanet_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060237F1 RID: 145393 RVA: 0x00983E36 File Offset: 0x00982036
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Baked_GasPlanet_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060237F2 RID: 145394 RVA: 0x00983E4A File Offset: 0x0098204A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_GasPlanet_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060237F3 RID: 145395 RVA: 0x00983E60 File Offset: 0x00982060
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Baked_GasPlanet(int EntryPoint)
		{
			BP_Baked_GasPlanet_C.__ExecuteUbergraph_BP_Baked_GasPlanet_FunctionParams* ptr = stackalloc BP_Baked_GasPlanet_C.__ExecuteUbergraph_BP_Baked_GasPlanet_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Baked_GasPlanet_C.__ExecuteUbergraph_BP_Baked_GasPlanet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Baked_GasPlanet_C.__ExecuteUbergraph_BP_Baked_GasPlanet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Baked_GasPlanet_C.__ExecuteUbergraph_BP_Baked_GasPlanet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060237F4 RID: 145396 RVA: 0x00983EA7 File Offset: 0x009820A7
		protected BP_Baked_GasPlanet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401210B RID: 73995
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BakePlanet/BluePrint/BP_Baked_GasPlanet.BP_Baked_GasPlanet_C";

		// Token: 0x0401210C RID: 73996
		private static IntPtr _ClassPtr;

		// Token: 0x0401210D RID: 73997
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401210E RID: 73998
		internal static int __PropertyOffset_0;

		// Token: 0x0401210F RID: 73999
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012110 RID: 74000
		internal static int __PropertyOffset_1;

		// Token: 0x04012111 RID: 74001
		internal static int __PropertyOffset_2;

		// Token: 0x04012112 RID: 74002
		internal static int __PropertyOffset_3;

		// Token: 0x04012113 RID: 74003
		internal static int __PropertyOffset_4;

		// Token: 0x04012114 RID: 74004
		internal static int __PropertyOffset_5;

		// Token: 0x04012115 RID: 74005
		internal static int __PropertyOffset_6;

		// Token: 0x04012116 RID: 74006
		internal static int __PropertyOffset_7;

		// Token: 0x04012117 RID: 74007
		internal static int __PropertyOffset_8;

		// Token: 0x04012118 RID: 74008
		internal static int __PropertyOffset_9;

		// Token: 0x04012119 RID: 74009
		internal static int __PropertyOffset_10;

		// Token: 0x0401211A RID: 74010
		internal static int __PropertyOffset_11;

		// Token: 0x0401211B RID: 74011
		internal static int __PropertyOffset_12;

		// Token: 0x0401211C RID: 74012
		internal static int __PropertyOffset_13;

		// Token: 0x0401211D RID: 74013
		internal static int __PropertyOffset_14;

		// Token: 0x0401211E RID: 74014
		internal static int __PropertyOffset_15;

		// Token: 0x0401211F RID: 74015
		internal static int __PropertyOffset_16;

		// Token: 0x04012120 RID: 74016
		internal static int __PropertyOffset_17;

		// Token: 0x04012121 RID: 74017
		internal static int __PropertyOffset_18;

		// Token: 0x04012122 RID: 74018
		internal static int __PropertyOffset_19;

		// Token: 0x04012123 RID: 74019
		internal static int __PropertyOffset_20;

		// Token: 0x04012124 RID: 74020
		internal static int __PropertyOffset_21;

		// Token: 0x04012125 RID: 74021
		internal static int __PropertyOffset_22;

		// Token: 0x04012126 RID: 74022
		internal static int __PropertyOffset_23;

		// Token: 0x04012127 RID: 74023
		internal static int __PropertyOffset_24;

		// Token: 0x04012128 RID: 74024
		internal static int __PropertyOffset_25;

		// Token: 0x04012129 RID: 74025
		internal static int __PropertyOffset_26;

		// Token: 0x0401212A RID: 74026
		internal static int __PropertyOffset_27;

		// Token: 0x0401212B RID: 74027
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401212C RID: 74028
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401212D RID: 74029
		private static IntPtr __ExecuteUbergraph_BP_Baked_GasPlanet_NativeFunctionPtr;

		// Token: 0x02009CF2 RID: 40178
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_Baked_GasPlanet_FunctionParams
		{
			// Token: 0x04032692 RID: 206482
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
