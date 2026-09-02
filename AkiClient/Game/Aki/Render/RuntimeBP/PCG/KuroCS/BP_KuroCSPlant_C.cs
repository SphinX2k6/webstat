using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUGrassInteraction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS
{
	// Token: 0x02003BF6 RID: 15350
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSPlant.BP_KuroCSPlant_C")]
	[UnrealStructLayout(1480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1474)]
	public class BP_KuroCSPlant_C : AKuroCSSkeltalPlant, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022B28 RID: 142120 RVA: 0x0096C14B File Offset: 0x0096A34B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCSPlant_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSPlant.BP_KuroCSPlant_C");
			}
			return BP_KuroCSPlant_C._ClassPtr;
		}

		// Token: 0x06022B29 RID: 142121 RVA: 0x0096C170 File Offset: 0x0096A370
		public BP_KuroCSPlant_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSPlant_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022B2A RID: 142122 RVA: 0x0096C198 File Offset: 0x0096A398
		[NullableContext(1)]
		public BP_KuroCSPlant_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCSPlant_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700424C RID: 16972
		// (get) Token: 0x06022B2B RID: 142123 RVA: 0x0096C1CC File Offset: 0x0096A3CC
		// (set) Token: 0x06022B2C RID: 142124 RVA: 0x0096C205 File Offset: 0x0096A405
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700424D RID: 16973
		// (get) Token: 0x06022B2D RID: 142125 RVA: 0x0096C226 File Offset: 0x0096A426
		// (set) Token: 0x06022B2E RID: 142126 RVA: 0x0096C23A File Offset: 0x0096A43A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700424E RID: 16974
		// (get) Token: 0x06022B2F RID: 142127 RVA: 0x0096C24F File Offset: 0x0096A44F
		// (set) Token: 0x06022B30 RID: 142128 RVA: 0x0096C263 File Offset: 0x0096A463
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700424F RID: 16975
		// (get) Token: 0x06022B31 RID: 142129 RVA: 0x0096C278 File Offset: 0x0096A478
		// (set) Token: 0x06022B32 RID: 142130 RVA: 0x0096C28C File Offset: 0x0096A48C
		public unsafe UStaticMesh Mesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004250 RID: 16976
		// (get) Token: 0x06022B33 RID: 142131 RVA: 0x0096C2A1 File Offset: 0x0096A4A1
		// (set) Token: 0x06022B34 RID: 142132 RVA: 0x0096C2B1 File Offset: 0x0096A4B1
		public unsafe int First_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004251 RID: 16977
		// (get) Token: 0x06022B35 RID: 142133 RVA: 0x0096C2C2 File Offset: 0x0096A4C2
		// (set) Token: 0x06022B36 RID: 142134 RVA: 0x0096C2D2 File Offset: 0x0096A4D2
		public unsafe int Last_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004252 RID: 16978
		// (get) Token: 0x06022B37 RID: 142135 RVA: 0x0096C2E3 File Offset: 0x0096A4E3
		// (set) Token: 0x06022B38 RID: 142136 RVA: 0x0096C2F3 File Offset: 0x0096A4F3
		public unsafe bool MultiMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004253 RID: 16979
		// (get) Token: 0x06022B39 RID: 142137 RVA: 0x0096C304 File Offset: 0x0096A504
		// (set) Token: 0x06022B3A RID: 142138 RVA: 0x0096C318 File Offset: 0x0096A518
		public unsafe UMaterialInterface Dynamic_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004254 RID: 16980
		// (get) Token: 0x06022B3B RID: 142139 RVA: 0x0096C32D File Offset: 0x0096A52D
		// (set) Token: 0x06022B3C RID: 142140 RVA: 0x0096C341 File Offset: 0x0096A541
		public unsafe UMaterialInterface Static_Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17004255 RID: 16981
		// (get) Token: 0x06022B3D RID: 142141 RVA: 0x0096C358 File Offset: 0x0096A558
		// (set) Token: 0x06022B3E RID: 142142 RVA: 0x0096C391 File Offset: 0x0096A591
		[Nullable(1)]
		public TArray<UMaterialInterface> Dynamic_Material_list
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Dynamic_Material_list) == null)
				{
					result = (this._Dynamic_Material_list = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Dynamic_Material_list.CopyAssign(value);
			}
		}

		// Token: 0x17004256 RID: 16982
		// (get) Token: 0x06022B3F RID: 142143 RVA: 0x0096C3A0 File Offset: 0x0096A5A0
		// (set) Token: 0x06022B40 RID: 142144 RVA: 0x0096C3D9 File Offset: 0x0096A5D9
		[Nullable(1)]
		public TArray<UMaterialInterface> Static_Material_list
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Static_Material_list) == null)
				{
					result = (this._Static_Material_list = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_10, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Static_Material_list.CopyAssign(value);
			}
		}

		// Token: 0x17004257 RID: 16983
		// (get) Token: 0x06022B41 RID: 142145 RVA: 0x0096C3E8 File Offset: 0x0096A5E8
		// (set) Token: 0x06022B42 RID: 142146 RVA: 0x0096C421 File Offset: 0x0096A621
		[Nullable(1)]
		public TArray<float> CustomData
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CustomData) == null)
				{
					result = (this._CustomData = new TArray<float>(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_11, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomData.CopyAssign(value);
			}
		}

		// Token: 0x17004258 RID: 16984
		// (get) Token: 0x06022B43 RID: 142147 RVA: 0x0096C42F File Offset: 0x0096A62F
		// (set) Token: 0x06022B44 RID: 142148 RVA: 0x0096C443 File Offset: 0x0096A643
		public unsafe BP_GPUFoliageInteraction_C DataAsset
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GPUFoliageInteraction_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCSPlant_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17004259 RID: 16985
		// (get) Token: 0x06022B45 RID: 142149 RVA: 0x0096C458 File Offset: 0x0096A658
		// (set) Token: 0x06022B46 RID: 142150 RVA: 0x0096C491 File Offset: 0x0096A691
		[Nullable(1)]
		public FKuroCurveFloat Curve_Float
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Curve_Float) == null)
				{
					result = (this._Curve_Float = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_13, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700425A RID: 16986
		// (get) Token: 0x06022B47 RID: 142151 RVA: 0x0096C4B2 File Offset: 0x0096A6B2
		// (set) Token: 0x06022B48 RID: 142152 RVA: 0x0096C4C2 File Offset: 0x0096A6C2
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700425B RID: 16987
		// (get) Token: 0x06022B49 RID: 142153 RVA: 0x0096C4D3 File Offset: 0x0096A6D3
		// (set) Token: 0x06022B4A RID: 142154 RVA: 0x0096C4E3 File Offset: 0x0096A6E3
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCSPlant_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022B4B RID: 142155 RVA: 0x0096C4F4 File Offset: 0x0096A6F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugDraw()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__DebugDraw_NativeFunctionPtr, null);
		}

		// Token: 0x06022B4C RID: 142156 RVA: 0x0096C508 File Offset: 0x0096A708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_CS_Data_From_DA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__Set_CS_Data_From_DA_NativeFunctionPtr, null);
		}

		// Token: 0x06022B4D RID: 142157 RVA: 0x0096C51C File Offset: 0x0096A71C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CopyCustomPrimitiveData(UStaticMeshComponent Target)
		{
			BP_KuroCSPlant_C.__CopyCustomPrimitiveData_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__CopyCustomPrimitiveData_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSPlant_C.__CopyCustomPrimitiveData_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Target = ((Target != null) ? Target.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__CopyCustomPrimitiveData_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B4E RID: 142158 RVA: 0x0096C574 File Offset: 0x0096A774
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool Set_Plant_Data(Struct_GPUInteractiveFoliage Foliage_Data)
		{
			BP_KuroCSPlant_C.__Set_Plant_Data_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__Set_Plant_Data_FunctionParams[(UIntPtr)591] + 15L / (long)sizeof(BP_KuroCSPlant_C.__Set_Plant_Data_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__Set_Plant_Data_NativeFunctionPtr, (void*)ptr, 1);
			if (Foliage_Data != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(Struct_GPUInteractiveFoliage.StaticStruct(), &ptr->Foliage_Data, Foliage_Data.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__Set_Plant_Data_NativeFunctionPtr, (void*)ptr);
			bool _Result = ptr->__Result;
			UnrealReflectionUtils.DestroyStruct(BP_KuroCSPlant_C.__Set_Plant_Data_NativeFunctionPtr, (void*)ptr, 1);
			return _Result;
		}

		// Token: 0x06022B4F RID: 142159 RVA: 0x0096C5EF File Offset: 0x0096A7EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_Params_And_MID()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__Set_Params_And_MID_NativeFunctionPtr, null);
		}

		// Token: 0x06022B50 RID: 142160 RVA: 0x0096C603 File Offset: 0x0096A803
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop_Interaction()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__Stop_Interaction_NativeFunctionPtr, null);
		}

		// Token: 0x06022B51 RID: 142161 RVA: 0x0096C617 File Offset: 0x0096A817
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Draw_Transfrom()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__Draw_Transfrom_NativeFunctionPtr, null);
		}

		// Token: 0x06022B52 RID: 142162 RVA: 0x0096C62B File Offset: 0x0096A82B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06022B53 RID: 142163 RVA: 0x0096C63F File Offset: 0x0096A83F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlant_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B54 RID: 142164 RVA: 0x0096C654 File Offset: 0x0096A854
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCSPlant_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSPlant_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B55 RID: 142165 RVA: 0x0096C69C File Offset: 0x0096A89C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCSPlant_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCSPlant_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B56 RID: 142166 RVA: 0x0096C6E4 File Offset: 0x0096A8E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B57 RID: 142167 RVA: 0x0096C7A0 File Offset: 0x0096A9A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B58 RID: 142168 RVA: 0x0096C829 File Offset: 0x0096AA29
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06022B59 RID: 142169 RVA: 0x0096C83D File Offset: 0x0096AA3D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022B5A RID: 142170 RVA: 0x0096C854 File Offset: 0x0096AA54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022B5B RID: 142171 RVA: 0x0096C8A0 File Offset: 0x0096AAA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCSPlant_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlant_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B5C RID: 142172 RVA: 0x0096C8EC File Offset: 0x0096AAEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCSPlant(int EntryPoint)
		{
			BP_KuroCSPlant_C.__ExecuteUbergraph_BP_KuroCSPlant_FunctionParams* ptr = stackalloc BP_KuroCSPlant_C.__ExecuteUbergraph_BP_KuroCSPlant_FunctionParams[(UIntPtr)527] + 15L / (long)sizeof(BP_KuroCSPlant_C.__ExecuteUbergraph_BP_KuroCSPlant_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCSPlant_C.__ExecuteUbergraph_BP_KuroCSPlant_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCSPlant_C.__ExecuteUbergraph_BP_KuroCSPlant_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022B5D RID: 142173 RVA: 0x0096C936 File Offset: 0x0096AB36
		protected BP_KuroCSPlant_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401195F RID: 72031
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/BP_KuroCSPlant.BP_KuroCSPlant_C";

		// Token: 0x04011960 RID: 72032
		private static IntPtr _ClassPtr;

		// Token: 0x04011961 RID: 72033
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011962 RID: 72034
		internal static int __PropertyOffset_0;

		// Token: 0x04011963 RID: 72035
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011964 RID: 72036
		internal static int __PropertyOffset_1;

		// Token: 0x04011965 RID: 72037
		internal static int __PropertyOffset_2;

		// Token: 0x04011966 RID: 72038
		internal static int __PropertyOffset_3;

		// Token: 0x04011967 RID: 72039
		internal static int __PropertyOffset_4;

		// Token: 0x04011968 RID: 72040
		internal static int __PropertyOffset_5;

		// Token: 0x04011969 RID: 72041
		internal static int __PropertyOffset_6;

		// Token: 0x0401196A RID: 72042
		internal static int __PropertyOffset_7;

		// Token: 0x0401196B RID: 72043
		internal static int __PropertyOffset_8;

		// Token: 0x0401196C RID: 72044
		internal static int __PropertyOffset_9;

		// Token: 0x0401196D RID: 72045
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Dynamic_Material_list;

		// Token: 0x0401196E RID: 72046
		internal static int __PropertyOffset_10;

		// Token: 0x0401196F RID: 72047
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Static_Material_list;

		// Token: 0x04011970 RID: 72048
		internal static int __PropertyOffset_11;

		// Token: 0x04011971 RID: 72049
		private TArray<float> _CustomData;

		// Token: 0x04011972 RID: 72050
		internal static int __PropertyOffset_12;

		// Token: 0x04011973 RID: 72051
		internal static int __PropertyOffset_13;

		// Token: 0x04011974 RID: 72052
		private FKuroCurveFloat _Curve_Float;

		// Token: 0x04011975 RID: 72053
		internal static int __PropertyOffset_14;

		// Token: 0x04011976 RID: 72054
		internal static int __PropertyOffset_15;

		// Token: 0x04011977 RID: 72055
		private static IntPtr __DebugDraw_NativeFunctionPtr;

		// Token: 0x04011978 RID: 72056
		private static IntPtr __Set_CS_Data_From_DA_NativeFunctionPtr;

		// Token: 0x04011979 RID: 72057
		private static IntPtr __CopyCustomPrimitiveData_NativeFunctionPtr;

		// Token: 0x0401197A RID: 72058
		private static IntPtr __Set_Plant_Data_NativeFunctionPtr;

		// Token: 0x0401197B RID: 72059
		private static IntPtr __Set_Params_And_MID_NativeFunctionPtr;

		// Token: 0x0401197C RID: 72060
		private static IntPtr __Stop_Interaction_NativeFunctionPtr;

		// Token: 0x0401197D RID: 72061
		private static IntPtr __Draw_Transfrom_NativeFunctionPtr;

		// Token: 0x0401197E RID: 72062
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401197F RID: 72063
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011980 RID: 72064
		private static IntPtr __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011981 RID: 72065
		private static IntPtr __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011982 RID: 72066
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011983 RID: 72067
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011984 RID: 72068
		private static IntPtr __ExecuteUbergraph_BP_KuroCSPlant_NativeFunctionPtr;

		// Token: 0x02009C0E RID: 39950
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CopyCustomPrimitiveData_FunctionParams
		{
			// Token: 0x04032468 RID: 205928
			[FieldOffset(0)]
			public IntPtr Target;
		}

		// Token: 0x02009C0F RID: 39951
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 576)]
		protected ref struct __Set_Plant_Data_FunctionParams
		{
			// Token: 0x04032469 RID: 205929
			[FieldOffset(0)]
			public byte Foliage_Data;

			// Token: 0x0403246A RID: 205930
			[FieldOffset(56)]
			public bool __Result;
		}

		// Token: 0x02009C10 RID: 39952
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403246B RID: 205931
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C11 RID: 39953
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403246C RID: 205932
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403246D RID: 205933
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403246E RID: 205934
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403246F RID: 205935
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032470 RID: 205936
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032471 RID: 205937
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C12 RID: 39954
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_LongGrass_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032472 RID: 205938
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032473 RID: 205939
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032474 RID: 205940
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032475 RID: 205941
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C13 RID: 39955
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032476 RID: 205942
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C14 RID: 39956
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 512)]
		protected ref struct __ExecuteUbergraph_BP_KuroCSPlant_FunctionParams
		{
			// Token: 0x04032477 RID: 205943
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
