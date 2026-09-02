using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6C RID: 15212
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag2.BP_Soft_clothBag2_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1428)]
	public class BP_Soft_clothBag2_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021767 RID: 137063 RVA: 0x00949E23 File Offset: 0x00948023
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Soft_clothBag2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag2.BP_Soft_clothBag2_C");
			}
			return BP_Soft_clothBag2_C._ClassPtr;
		}

		// Token: 0x06021768 RID: 137064 RVA: 0x00949E48 File Offset: 0x00948048
		public BP_Soft_clothBag2_C() : this(BuiltinUtils.AllocNativeUObject(BP_Soft_clothBag2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021769 RID: 137065 RVA: 0x00949E70 File Offset: 0x00948070
		[NullableContext(1)]
		public BP_Soft_clothBag2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Soft_clothBag2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B4A RID: 15178
		// (get) Token: 0x0602176A RID: 137066 RVA: 0x00949EA4 File Offset: 0x009480A4
		// (set) Token: 0x0602176B RID: 137067 RVA: 0x00949EDD File Offset: 0x009480DD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B4B RID: 15179
		// (get) Token: 0x0602176C RID: 137068 RVA: 0x00949EFE File Offset: 0x009480FE
		// (set) Token: 0x0602176D RID: 137069 RVA: 0x00949F12 File Offset: 0x00948112
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B4C RID: 15180
		// (get) Token: 0x0602176E RID: 137070 RVA: 0x00949F27 File Offset: 0x00948127
		// (set) Token: 0x0602176F RID: 137071 RVA: 0x00949F3B File Offset: 0x0094813B
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B4D RID: 15181
		// (get) Token: 0x06021770 RID: 137072 RVA: 0x00949F50 File Offset: 0x00948150
		// (set) Token: 0x06021771 RID: 137073 RVA: 0x00949F64 File Offset: 0x00948164
		public unsafe USceneComponent Scene
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B4E RID: 15182
		// (get) Token: 0x06021772 RID: 137074 RVA: 0x00949F79 File Offset: 0x00948179
		// (set) Token: 0x06021773 RID: 137075 RVA: 0x00949F8D File Offset: 0x0094818D
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B4F RID: 15183
		// (get) Token: 0x06021774 RID: 137076 RVA: 0x00949FA2 File Offset: 0x009481A2
		// (set) Token: 0x06021775 RID: 137077 RVA: 0x00949FB6 File Offset: 0x009481B6
		public unsafe FVector BoxExtent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B50 RID: 15184
		// (get) Token: 0x06021776 RID: 137078 RVA: 0x00949FCB File Offset: 0x009481CB
		// (set) Token: 0x06021777 RID: 137079 RVA: 0x00949FDB File Offset: 0x009481DB
		public unsafe float Mass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B51 RID: 15185
		// (get) Token: 0x06021778 RID: 137080 RVA: 0x00949FEC File Offset: 0x009481EC
		// (set) Token: 0x06021779 RID: 137081 RVA: 0x0094A000 File Offset: 0x00948200
		public unsafe FLinearColor Color
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B52 RID: 15186
		// (get) Token: 0x0602177A RID: 137082 RVA: 0x0094A015 File Offset: 0x00948215
		// (set) Token: 0x0602177B RID: 137083 RVA: 0x0094A025 File Offset: 0x00948225
		public unsafe float Tightness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B53 RID: 15187
		// (get) Token: 0x0602177C RID: 137084 RVA: 0x0094A036 File Offset: 0x00948236
		// (set) Token: 0x0602177D RID: 137085 RVA: 0x0094A04A File Offset: 0x0094824A
		public unsafe UTextureRenderTarget2D RT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17003B54 RID: 15188
		// (get) Token: 0x0602177E RID: 137086 RVA: 0x0094A05F File Offset: 0x0094825F
		// (set) Token: 0x0602177F RID: 137087 RVA: 0x0094A073 File Offset: 0x00948273
		public unsafe UHoudiniPointCache HoudiniPointCache
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17003B55 RID: 15189
		// (get) Token: 0x06021780 RID: 137088 RVA: 0x0094A088 File Offset: 0x00948288
		// (set) Token: 0x06021781 RID: 137089 RVA: 0x0094A09C File Offset: 0x0094829C
		public unsafe UMaterialInstanceDynamic Dmaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003B56 RID: 15190
		// (get) Token: 0x06021782 RID: 137090 RVA: 0x0094A0B1 File Offset: 0x009482B1
		// (set) Token: 0x06021783 RID: 137091 RVA: 0x0094A0C5 File Offset: 0x009482C5
		public unsafe UMaterialInstance InputMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Soft_clothBag2_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17003B57 RID: 15191
		// (get) Token: 0x06021784 RID: 137092 RVA: 0x0094A0DA File Offset: 0x009482DA
		// (set) Token: 0x06021785 RID: 137093 RVA: 0x0094A0EA File Offset: 0x009482EA
		public unsafe bool AlreadyBegin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B58 RID: 15192
		// (get) Token: 0x06021786 RID: 137094 RVA: 0x0094A0FB File Offset: 0x009482FB
		// (set) Token: 0x06021787 RID: 137095 RVA: 0x0094A10B File Offset: 0x0094830B
		public unsafe bool initOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B59 RID: 15193
		// (get) Token: 0x06021788 RID: 137096 RVA: 0x0094A11C File Offset: 0x0094831C
		// (set) Token: 0x06021789 RID: 137097 RVA: 0x0094A12C File Offset: 0x0094832C
		public unsafe float dt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003B5A RID: 15194
		// (get) Token: 0x0602178A RID: 137098 RVA: 0x0094A13D File Offset: 0x0094833D
		// (set) Token: 0x0602178B RID: 137099 RVA: 0x0094A14D File Offset: 0x0094834D
		public unsafe float fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Soft_clothBag2_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x0602178C RID: 137100 RVA: 0x0094A15E File Offset: 0x0094835E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602178D RID: 137101 RVA: 0x0094A172 File Offset: 0x00948372
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602178E RID: 137102 RVA: 0x0094A188 File Offset: 0x00948388
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602178F RID: 137103 RVA: 0x0094A244 File Offset: 0x00948444
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021790 RID: 137104 RVA: 0x0094A2CD File Offset: 0x009484CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__CustomEvent1_NativeFunctionPtr, null);
		}

		// Token: 0x06021791 RID: 137105 RVA: 0x0094A2E1 File Offset: 0x009484E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomEvent_0()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__CustomEvent_0_NativeFunctionPtr, null);
		}

		// Token: 0x06021792 RID: 137106 RVA: 0x0094A2F8 File Offset: 0x009484F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021793 RID: 137107 RVA: 0x0094A340 File Offset: 0x00948540
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Soft_clothBag2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021794 RID: 137108 RVA: 0x0094A387 File Offset: 0x00948587
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021795 RID: 137109 RVA: 0x0094A39B File Offset: 0x0094859B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021796 RID: 137110 RVA: 0x0094A3B0 File Offset: 0x009485B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06021797 RID: 137111 RVA: 0x0094A3C4 File Offset: 0x009485C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021798 RID: 137112 RVA: 0x0094A3D9 File Offset: 0x009485D9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Soft_clothBag2_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06021799 RID: 137113 RVA: 0x0094A3ED File Offset: 0x009485ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602179A RID: 137114 RVA: 0x0094A404 File Offset: 0x00948604
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Soft_clothBag2(int EntryPoint)
		{
			BP_Soft_clothBag2_C.__ExecuteUbergraph_BP_Soft_clothBag2_FunctionParams* ptr = stackalloc BP_Soft_clothBag2_C.__ExecuteUbergraph_BP_Soft_clothBag2_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_Soft_clothBag2_C.__ExecuteUbergraph_BP_Soft_clothBag2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Soft_clothBag2_C.__ExecuteUbergraph_BP_Soft_clothBag2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Soft_clothBag2_C.__ExecuteUbergraph_BP_Soft_clothBag2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602179B RID: 137115 RVA: 0x0094A44E File Offset: 0x0094864E
		protected BP_Soft_clothBag2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D97 RID: 69015
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/BP_Soft_clothBag2.BP_Soft_clothBag2_C";

		// Token: 0x04010D98 RID: 69016
		private static IntPtr _ClassPtr;

		// Token: 0x04010D99 RID: 69017
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D9A RID: 69018
		internal static int __PropertyOffset_0;

		// Token: 0x04010D9B RID: 69019
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D9C RID: 69020
		internal static int __PropertyOffset_1;

		// Token: 0x04010D9D RID: 69021
		internal static int __PropertyOffset_2;

		// Token: 0x04010D9E RID: 69022
		internal static int __PropertyOffset_3;

		// Token: 0x04010D9F RID: 69023
		internal static int __PropertyOffset_4;

		// Token: 0x04010DA0 RID: 69024
		internal static int __PropertyOffset_5;

		// Token: 0x04010DA1 RID: 69025
		internal static int __PropertyOffset_6;

		// Token: 0x04010DA2 RID: 69026
		internal static int __PropertyOffset_7;

		// Token: 0x04010DA3 RID: 69027
		internal static int __PropertyOffset_8;

		// Token: 0x04010DA4 RID: 69028
		internal static int __PropertyOffset_9;

		// Token: 0x04010DA5 RID: 69029
		internal static int __PropertyOffset_10;

		// Token: 0x04010DA6 RID: 69030
		internal static int __PropertyOffset_11;

		// Token: 0x04010DA7 RID: 69031
		internal static int __PropertyOffset_12;

		// Token: 0x04010DA8 RID: 69032
		internal static int __PropertyOffset_13;

		// Token: 0x04010DA9 RID: 69033
		internal static int __PropertyOffset_14;

		// Token: 0x04010DAA RID: 69034
		internal static int __PropertyOffset_15;

		// Token: 0x04010DAB RID: 69035
		internal static int __PropertyOffset_16;

		// Token: 0x04010DAC RID: 69036
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010DAD RID: 69037
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010DAE RID: 69038
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010DAF RID: 69039
		private static IntPtr __CustomEvent1_NativeFunctionPtr;

		// Token: 0x04010DB0 RID: 69040
		private static IntPtr __CustomEvent_0_NativeFunctionPtr;

		// Token: 0x04010DB1 RID: 69041
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010DB2 RID: 69042
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010DB3 RID: 69043
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x04010DB4 RID: 69044
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x04010DB5 RID: 69045
		private static IntPtr __ExecuteUbergraph_BP_Soft_clothBag2_NativeFunctionPtr;

		// Token: 0x02009AE1 RID: 39649
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x0403226D RID: 205421
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x0403226E RID: 205422
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x0403226F RID: 205423
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032270 RID: 205424
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x04032271 RID: 205425
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x04032272 RID: 205426
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009AE2 RID: 39650
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x04032273 RID: 205427
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x04032274 RID: 205428
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x04032275 RID: 205429
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x04032276 RID: 205430
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009AE3 RID: 39651
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032277 RID: 205431
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AE4 RID: 39652
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected ref struct __ExecuteUbergraph_BP_Soft_clothBag2_FunctionParams
		{
			// Token: 0x04032278 RID: 205432
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
