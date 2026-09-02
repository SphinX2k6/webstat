using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6D RID: 15213
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag.BP_Soft_clothBag_C")]
	[UnrealStructLayout(1472, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1468)]
	public class BP_Soft_clothBag_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602179C RID: 137116 RVA: 0x0094A457 File Offset: 0x00948657
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Soft_clothBag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag.BP_Soft_clothBag_C");
			}
			return BP_Soft_clothBag_C._ClassPtr;
		}

		// Token: 0x0602179D RID: 137117 RVA: 0x0094A47C File Offset: 0x0094867C
		public BP_Soft_clothBag_C() : this(BuiltinUtils.AllocNativeUObject(BP_Soft_clothBag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602179E RID: 137118 RVA: 0x0094A4A4 File Offset: 0x009486A4
		[NullableContext(1)]
		public BP_Soft_clothBag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Soft_clothBag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B5B RID: 15195
		// (get) Token: 0x0602179F RID: 137119 RVA: 0x0094A4D8 File Offset: 0x009486D8
		// (set) Token: 0x060217A0 RID: 137120 RVA: 0x0094A511 File Offset: 0x00948711
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B5C RID: 15196
		// (get) Token: 0x060217A1 RID: 137121 RVA: 0x0094A532 File Offset: 0x00948732
		// (set) Token: 0x060217A2 RID: 137122 RVA: 0x0094A546 File Offset: 0x00948746
		public unsafe UPhysicsConstraintComponent PhysicsConstraint1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B5D RID: 15197
		// (get) Token: 0x060217A3 RID: 137123 RVA: 0x0094A55B File Offset: 0x0094875B
		// (set) Token: 0x060217A4 RID: 137124 RVA: 0x0094A56F File Offset: 0x0094876F
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B5E RID: 15198
		// (get) Token: 0x060217A5 RID: 137125 RVA: 0x0094A584 File Offset: 0x00948784
		// (set) Token: 0x060217A6 RID: 137126 RVA: 0x0094A598 File Offset: 0x00948798
		public unsafe UPhysicsConstraintComponent PhysicsConstraint
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPhysicsConstraintComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B5F RID: 15199
		// (get) Token: 0x060217A7 RID: 137127 RVA: 0x0094A5AD File Offset: 0x009487AD
		// (set) Token: 0x060217A8 RID: 137128 RVA: 0x0094A5C1 File Offset: 0x009487C1
		public unsafe UStaticMeshComponent SoftBox5_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B60 RID: 15200
		// (get) Token: 0x060217A9 RID: 137129 RVA: 0x0094A5D6 File Offset: 0x009487D6
		// (set) Token: 0x060217AA RID: 137130 RVA: 0x0094A5EA File Offset: 0x009487EA
		public unsafe UStaticMeshComponent SoftBox5_2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003B61 RID: 15201
		// (get) Token: 0x060217AB RID: 137131 RVA: 0x0094A5FF File Offset: 0x009487FF
		// (set) Token: 0x060217AC RID: 137132 RVA: 0x0094A613 File Offset: 0x00948813
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003B62 RID: 15202
		// (get) Token: 0x060217AD RID: 137133 RVA: 0x0094A628 File Offset: 0x00948828
		// (set) Token: 0x060217AE RID: 137134 RVA: 0x0094A63C File Offset: 0x0094883C
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17003B63 RID: 15203
		// (get) Token: 0x060217AF RID: 137135 RVA: 0x0094A651 File Offset: 0x00948851
		// (set) Token: 0x060217B0 RID: 137136 RVA: 0x0094A665 File Offset: 0x00948865
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17003B64 RID: 15204
		// (get) Token: 0x060217B1 RID: 137137 RVA: 0x0094A67A File Offset: 0x0094887A
		// (set) Token: 0x060217B2 RID: 137138 RVA: 0x0094A68E File Offset: 0x0094888E
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003B65 RID: 15205
		// (get) Token: 0x060217B3 RID: 137139 RVA: 0x0094A6A3 File Offset: 0x009488A3
		// (set) Token: 0x060217B4 RID: 137140 RVA: 0x0094A6B7 File Offset: 0x009488B7
		public unsafe FVector BoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003B66 RID: 15206
		// (get) Token: 0x060217B5 RID: 137141 RVA: 0x0094A6CC File Offset: 0x009488CC
		// (set) Token: 0x060217B6 RID: 137142 RVA: 0x0094A6DC File Offset: 0x009488DC
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003B67 RID: 15207
		// (get) Token: 0x060217B7 RID: 137143 RVA: 0x0094A6ED File Offset: 0x009488ED
		// (set) Token: 0x060217B8 RID: 137144 RVA: 0x0094A701 File Offset: 0x00948901
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003B68 RID: 15208
		// (get) Token: 0x060217B9 RID: 137145 RVA: 0x0094A716 File Offset: 0x00948916
		// (set) Token: 0x060217BA RID: 137146 RVA: 0x0094A726 File Offset: 0x00948926
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003B69 RID: 15209
		// (get) Token: 0x060217BB RID: 137147 RVA: 0x0094A737 File Offset: 0x00948937
		// (set) Token: 0x060217BC RID: 137148 RVA: 0x0094A74B File Offset: 0x0094894B
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003B6A RID: 15210
		// (get) Token: 0x060217BD RID: 137149 RVA: 0x0094A760 File Offset: 0x00948960
		// (set) Token: 0x060217BE RID: 137150 RVA: 0x0094A774 File Offset: 0x00948974
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003B6B RID: 15211
		// (get) Token: 0x060217BF RID: 137151 RVA: 0x0094A789 File Offset: 0x00948989
		// (set) Token: 0x060217C0 RID: 137152 RVA: 0x0094A79D File Offset: 0x0094899D
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003B6C RID: 15212
		// (get) Token: 0x060217C1 RID: 137153 RVA: 0x0094A7B2 File Offset: 0x009489B2
		// (set) Token: 0x060217C2 RID: 137154 RVA: 0x0094A7C6 File Offset: 0x009489C6
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17003B6D RID: 15213
		// (get) Token: 0x060217C3 RID: 137155 RVA: 0x0094A7DB File Offset: 0x009489DB
		// (set) Token: 0x060217C4 RID: 137156 RVA: 0x0094A7EB File Offset: 0x009489EB
		public unsafe bool AlreadyBegin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_18) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_18) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B6E RID: 15214
		// (get) Token: 0x060217C5 RID: 137157 RVA: 0x0094A7FC File Offset: 0x009489FC
		// (set) Token: 0x060217C6 RID: 137158 RVA: 0x0094A80C File Offset: 0x00948A0C
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B6F RID: 15215
		// (get) Token: 0x060217C7 RID: 137159 RVA: 0x0094A81D File Offset: 0x00948A1D
		// (set) Token: 0x060217C8 RID: 137160 RVA: 0x0094A82D File Offset: 0x00948A2D
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17003B70 RID: 15216
		// (get) Token: 0x060217C9 RID: 137161 RVA: 0x0094A83E File Offset: 0x00948A3E
		// (set) Token: 0x060217CA RID: 137162 RVA: 0x0094A84E File Offset: 0x00948A4E
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x060217CB RID: 137163 RVA: 0x0094A85F File Offset: 0x00948A5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060217CC RID: 137164 RVA: 0x0094A873 File Offset: 0x00948A73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060217CD RID: 137165 RVA: 0x0094A888 File Offset: 0x00948A88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060217CE RID: 137166 RVA: 0x0094A944 File Offset: 0x00948B44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060217CF RID: 137167 RVA: 0x0094A9CD File Offset: 0x00948BCD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x060217D0 RID: 137168 RVA: 0x0094A9E1 File Offset: 0x00948BE1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x060217D1 RID: 137169 RVA: 0x0094A9F8 File Offset: 0x00948BF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Soft_clothBag_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_clothBag_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_clothBag_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060217D2 RID: 137170 RVA: 0x0094AA40 File Offset: 0x00948C40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Soft_clothBag_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_clothBag_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_clothBag_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060217D3 RID: 137171 RVA: 0x0094AA87 File Offset: 0x00948C87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060217D4 RID: 137172 RVA: 0x0094AA9B File Offset: 0x00948C9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060217D5 RID: 137173 RVA: 0x0094AAB0 File Offset: 0x00948CB0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x060217D6 RID: 137174 RVA: 0x0094AAC4 File Offset: 0x00948CC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060217D7 RID: 137175 RVA: 0x0094AAD9 File Offset: 0x00948CD9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x060217D8 RID: 137176 RVA: 0x0094AAED File Offset: 0x00948CED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060217D9 RID: 137177 RVA: 0x0094AB04 File Offset: 0x00948D04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Soft_clothBag(int EntryPoint)
		{
			BP_Soft_clothBag_C.__ExecuteUbergraph_BP_Soft_clothBag_FunctionParams* ptr = stackalloc BP_Soft_clothBag_C.__ExecuteUbergraph_BP_Soft_clothBag_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_Soft_clothBag_C.__ExecuteUbergraph_BP_Soft_clothBag_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag_C.__ExecuteUbergraph_BP_Soft_clothBag_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag_C.__ExecuteUbergraph_BP_Soft_clothBag_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060217DA RID: 137178 RVA: 0x0094AB4E File Offset: 0x00948D4E
		protected BP_Soft_clothBag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010DB6 RID: 69046
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag.BP_Soft_clothBag_C";

		// Token: 0x04010DB7 RID: 69047
		private static IntPtr _ClassPtr;

		// Token: 0x04010DB8 RID: 69048
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010DB9 RID: 69049
		internal static int __PropertyOffset_0;

		// Token: 0x04010DBA RID: 69050
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010DBB RID: 69051
		internal static int __PropertyOffset_1;

		// Token: 0x04010DBC RID: 69052
		internal static int __PropertyOffset_2;

		// Token: 0x04010DBD RID: 69053
		internal static int __PropertyOffset_3;

		// Token: 0x04010DBE RID: 69054
		internal static int __PropertyOffset_4;

		// Token: 0x04010DBF RID: 69055
		internal static int __PropertyOffset_5;

		// Token: 0x04010DC0 RID: 69056
		internal static int __PropertyOffset_6;

		// Token: 0x04010DC1 RID: 69057
		internal static int __PropertyOffset_7;

		// Token: 0x04010DC2 RID: 69058
		internal static int __PropertyOffset_8;

		// Token: 0x04010DC3 RID: 69059
		internal static int __PropertyOffset_9;

		// Token: 0x04010DC4 RID: 69060
		internal static int __PropertyOffset_10;

		// Token: 0x04010DC5 RID: 69061
		internal static int __PropertyOffset_11;

		// Token: 0x04010DC6 RID: 69062
		internal static int __PropertyOffset_12;

		// Token: 0x04010DC7 RID: 69063
		internal static int __PropertyOffset_13;

		// Token: 0x04010DC8 RID: 69064
		internal static int __PropertyOffset_14;

		// Token: 0x04010DC9 RID: 69065
		internal static int __PropertyOffset_15;

		// Token: 0x04010DCA RID: 69066
		internal static int __PropertyOffset_16;

		// Token: 0x04010DCB RID: 69067
		internal static int __PropertyOffset_17;

		// Token: 0x04010DCC RID: 69068
		internal static int __PropertyOffset_18;

		// Token: 0x04010DCD RID: 69069
		internal static int __PropertyOffset_19;

		// Token: 0x04010DCE RID: 69070
		internal static int __PropertyOffset_20;

		// Token: 0x04010DCF RID: 69071
		internal static int __PropertyOffset_21;

		// Token: 0x04010DD0 RID: 69072
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010DD1 RID: 69073
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010DD2 RID: 69074
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010DD3 RID: 69075
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010DD4 RID: 69076
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010DD5 RID: 69077
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010DD6 RID: 69078
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010DD7 RID: 69079
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04010DD8 RID: 69080
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04010DD9 RID: 69081
		private static IntPtr __ExecuteUbergraph_BP_Soft_clothBag_NativeFunctionPtr;

		// Token: 0x02009AE5 RID: 39653
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032279 RID: 205433
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403227A RID: 205434
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403227B RID: 205435
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x0403227C RID: 205436
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x0403227D RID: 205437
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x0403227E RID: 205438
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009AE6 RID: 39654
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403227F RID: 205439
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032280 RID: 205440
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032281 RID: 205441
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032282 RID: 205442
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009AE7 RID: 39655
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032283 RID: 205443
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AE8 RID: 39656
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __ExecuteUbergraph_BP_Soft_clothBag_FunctionParams
		{
			// Token: 0x04032284 RID: 205444
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
