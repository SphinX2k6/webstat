using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUBoxSimulation
{
	// Token: 0x02003C23 RID: 15395
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BubbleCol.BP_BubbleCol_C")]
	[UnrealStructLayout(1616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1616)]
	public class BP_BubbleCol_C : AKuroCSRpbd, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023208 RID: 143880 RVA: 0x009798CB File Offset: 0x00977ACB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BubbleCol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BubbleCol.BP_BubbleCol_C");
			}
			return BP_BubbleCol_C._ClassPtr;
		}

		// Token: 0x06023209 RID: 143881 RVA: 0x009798F0 File Offset: 0x00977AF0
		public BP_BubbleCol_C() : this(BuiltinUtils.AllocNativeUObject(BP_BubbleCol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602320A RID: 143882 RVA: 0x00979918 File Offset: 0x00977B18
		[NullableContext(1)]
		public BP_BubbleCol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BubbleCol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004489 RID: 17545
		// (get) Token: 0x0602320B RID: 143883 RVA: 0x0097994C File Offset: 0x00977B4C
		// (set) Token: 0x0602320C RID: 143884 RVA: 0x00979985 File Offset: 0x00977B85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700448A RID: 17546
		// (get) Token: 0x0602320D RID: 143885 RVA: 0x009799A6 File Offset: 0x00977BA6
		// (set) Token: 0x0602320E RID: 143886 RVA: 0x009799BA File Offset: 0x00977BBA
		public unsafe UBoxComponent ValidBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700448B RID: 17547
		// (get) Token: 0x0602320F RID: 143887 RVA: 0x009799CF File Offset: 0x00977BCF
		// (set) Token: 0x06023210 RID: 143888 RVA: 0x009799E3 File Offset: 0x00977BE3
		public unsafe UStaticMeshComponent xpbd_test
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700448C RID: 17548
		// (get) Token: 0x06023211 RID: 143889 RVA: 0x009799F8 File Offset: 0x00977BF8
		// (set) Token: 0x06023212 RID: 143890 RVA: 0x00979A0C File Offset: 0x00977C0C
		public unsafe UTextureRenderTarget2D RT_Pos
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700448D RID: 17549
		// (get) Token: 0x06023213 RID: 143891 RVA: 0x00979A21 File Offset: 0x00977C21
		// (set) Token: 0x06023214 RID: 143892 RVA: 0x00979A35 File Offset: 0x00977C35
		public unsafe UDataTable DT
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700448E RID: 17550
		// (get) Token: 0x06023215 RID: 143893 RVA: 0x00979A4A File Offset: 0x00977C4A
		// (set) Token: 0x06023216 RID: 143894 RVA: 0x00979A5E File Offset: 0x00977C5E
		public unsafe UMaterialInstanceDynamic MID
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x1700448F RID: 17551
		// (get) Token: 0x06023217 RID: 143895 RVA: 0x00979A73 File Offset: 0x00977C73
		// (set) Token: 0x06023218 RID: 143896 RVA: 0x00979A83 File Offset: 0x00977C83
		public unsafe bool debugDraw
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004490 RID: 17552
		// (get) Token: 0x06023219 RID: 143897 RVA: 0x00979A94 File Offset: 0x00977C94
		// (set) Token: 0x0602321A RID: 143898 RVA: 0x00979AA8 File Offset: 0x00977CA8
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x17004491 RID: 17553
		// (get) Token: 0x0602321B RID: 143899 RVA: 0x00979ABD File Offset: 0x00977CBD
		// (set) Token: 0x0602321C RID: 143900 RVA: 0x00979ACD File Offset: 0x00977CCD
		public unsafe float force
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17004492 RID: 17554
		// (get) Token: 0x0602321D RID: 143901 RVA: 0x00979ADE File Offset: 0x00977CDE
		// (set) Token: 0x0602321E RID: 143902 RVA: 0x00979AEE File Offset: 0x00977CEE
		public unsafe bool Pressing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004493 RID: 17555
		// (get) Token: 0x0602321F RID: 143903 RVA: 0x00979AFF File Offset: 0x00977CFF
		// (set) Token: 0x06023220 RID: 143904 RVA: 0x00979B0F File Offset: 0x00977D0F
		public unsafe bool FS_isPhysicSimulation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004494 RID: 17556
		// (get) Token: 0x06023221 RID: 143905 RVA: 0x00979B20 File Offset: 0x00977D20
		// (set) Token: 0x06023222 RID: 143906 RVA: 0x00979B30 File Offset: 0x00977D30
		public unsafe float mass_in_kg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004495 RID: 17557
		// (get) Token: 0x06023223 RID: 143907 RVA: 0x00979B41 File Offset: 0x00977D41
		// (set) Token: 0x06023224 RID: 143908 RVA: 0x00979B51 File Offset: 0x00977D51
		public unsafe bool editorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004496 RID: 17558
		// (get) Token: 0x06023225 RID: 143909 RVA: 0x00979B62 File Offset: 0x00977D62
		// (set) Token: 0x06023226 RID: 143910 RVA: 0x00979B72 File Offset: 0x00977D72
		public unsafe bool _2DRT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004497 RID: 17559
		// (get) Token: 0x06023227 RID: 143911 RVA: 0x00979B83 File Offset: 0x00977D83
		// (set) Token: 0x06023228 RID: 143912 RVA: 0x00979B93 File Offset: 0x00977D93
		public unsafe int XCount_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004498 RID: 17560
		// (get) Token: 0x06023229 RID: 143913 RVA: 0x00979BA4 File Offset: 0x00977DA4
		// (set) Token: 0x0602322A RID: 143914 RVA: 0x00979BB4 File Offset: 0x00977DB4
		public unsafe bool ReadFromBPL
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004499 RID: 17561
		// (get) Token: 0x0602322B RID: 143915 RVA: 0x00979BC5 File Offset: 0x00977DC5
		// (set) Token: 0x0602322C RID: 143916 RVA: 0x00979BD9 File Offset: 0x00977DD9
		public unsafe UStaticMesh inputStaticMesh_ForBPL_
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x1700449A RID: 17562
		// (get) Token: 0x0602322D RID: 143917 RVA: 0x00979BEE File Offset: 0x00977DEE
		// (set) Token: 0x0602322E RID: 143918 RVA: 0x00979BFE File Offset: 0x00977DFE
		public unsafe bool extraOneMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700449B RID: 17563
		// (get) Token: 0x0602322F RID: 143919 RVA: 0x00979C0F File Offset: 0x00977E0F
		// (set) Token: 0x06023230 RID: 143920 RVA: 0x00979C23 File Offset: 0x00977E23
		public unsafe UMaterialInstance InputMat1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x1700449C RID: 17564
		// (get) Token: 0x06023231 RID: 143921 RVA: 0x00979C38 File Offset: 0x00977E38
		// (set) Token: 0x06023232 RID: 143922 RVA: 0x00979C4C File Offset: 0x00977E4C
		public unsafe UMaterialInstanceDynamic MID1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_19);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BubbleCol_C.__PropertyOffset_19, value);
			}
		}

		// Token: 0x1700449D RID: 17565
		// (get) Token: 0x06023233 RID: 143923 RVA: 0x00979C61 File Offset: 0x00977E61
		// (set) Token: 0x06023234 RID: 143924 RVA: 0x00979C71 File Offset: 0x00977E71
		public unsafe bool StopBP
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700449E RID: 17566
		// (get) Token: 0x06023235 RID: 143925 RVA: 0x00979C82 File Offset: 0x00977E82
		// (set) Token: 0x06023236 RID: 143926 RVA: 0x00979C92 File Offset: 0x00977E92
		public unsafe bool UseYCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_21) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_21) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700449F RID: 17567
		// (get) Token: 0x06023237 RID: 143927 RVA: 0x00979CA3 File Offset: 0x00977EA3
		// (set) Token: 0x06023238 RID: 143928 RVA: 0x00979CB3 File Offset: 0x00977EB3
		public unsafe int YCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BubbleCol_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x06023239 RID: 143929 RVA: 0x00979CC4 File Offset: 0x00977EC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602323A RID: 143930 RVA: 0x00979CD8 File Offset: 0x00977ED8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BubbleCol_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602323B RID: 143931 RVA: 0x00979CED File Offset: 0x00977EED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602323C RID: 143932 RVA: 0x00979D01 File Offset: 0x00977F01
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602323D RID: 143933 RVA: 0x00979D18 File Offset: 0x00977F18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BubbleCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BubbleCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602323E RID: 143934 RVA: 0x00979D60 File Offset: 0x00977F60
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BubbleCol_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BubbleCol_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602323F RID: 143935 RVA: 0x00979DA8 File Offset: 0x00977FA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023240 RID: 143936 RVA: 0x00979DF4 File Offset: 0x00977FF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_BubbleCol_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BubbleCol_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023241 RID: 143937 RVA: 0x00979E40 File Offset: 0x00978040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature(UPrimitiveComponent HitComponent, AActor OtherActor, UPrimitiveComponent OtherComp, FVector NormalImpulse, in FHitResult Hit)
		{
			BP_BubbleCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BubbleCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->HitComponent = ((HitComponent != null) ? HitComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->NormalImpulse = NormalImpulse;
			if (Hit != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->Hit, Hit.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023242 RID: 143938 RVA: 0x00979EF4 File Offset: 0x009780F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023243 RID: 143939 RVA: 0x00979FB0 File Offset: 0x009781B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BubbleCol_C.__BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023244 RID: 143940 RVA: 0x0097A03C File Offset: 0x0097823C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BubbleCol(int EntryPoint)
		{
			BP_BubbleCol_C.__ExecuteUbergraph_BP_BubbleCol_FunctionParams* ptr = stackalloc BP_BubbleCol_C.__ExecuteUbergraph_BP_BubbleCol_FunctionParams[(UIntPtr)2111] + 15L / (long)sizeof(BP_BubbleCol_C.__ExecuteUbergraph_BP_BubbleCol_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BubbleCol_C.__ExecuteUbergraph_BP_BubbleCol_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BubbleCol_C.__ExecuteUbergraph_BP_BubbleCol_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023245 RID: 143941 RVA: 0x0097A086 File Offset: 0x00978286
		protected BP_BubbleCol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011DCA RID: 73162
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUBoxSimulation/BP_BubbleCol.BP_BubbleCol_C";

		// Token: 0x04011DCB RID: 73163
		private static IntPtr _ClassPtr;

		// Token: 0x04011DCC RID: 73164
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011DCD RID: 73165
		internal static int __PropertyOffset_0;

		// Token: 0x04011DCE RID: 73166
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011DCF RID: 73167
		internal static int __PropertyOffset_1;

		// Token: 0x04011DD0 RID: 73168
		internal static int __PropertyOffset_2;

		// Token: 0x04011DD1 RID: 73169
		internal static int __PropertyOffset_3;

		// Token: 0x04011DD2 RID: 73170
		internal static int __PropertyOffset_4;

		// Token: 0x04011DD3 RID: 73171
		internal static int __PropertyOffset_5;

		// Token: 0x04011DD4 RID: 73172
		internal static int __PropertyOffset_6;

		// Token: 0x04011DD5 RID: 73173
		internal static int __PropertyOffset_7;

		// Token: 0x04011DD6 RID: 73174
		internal static int __PropertyOffset_8;

		// Token: 0x04011DD7 RID: 73175
		internal static int __PropertyOffset_9;

		// Token: 0x04011DD8 RID: 73176
		internal static int __PropertyOffset_10;

		// Token: 0x04011DD9 RID: 73177
		internal static int __PropertyOffset_11;

		// Token: 0x04011DDA RID: 73178
		internal static int __PropertyOffset_12;

		// Token: 0x04011DDB RID: 73179
		internal static int __PropertyOffset_13;

		// Token: 0x04011DDC RID: 73180
		internal static int __PropertyOffset_14;

		// Token: 0x04011DDD RID: 73181
		internal static int __PropertyOffset_15;

		// Token: 0x04011DDE RID: 73182
		internal static int __PropertyOffset_16;

		// Token: 0x04011DDF RID: 73183
		internal static int __PropertyOffset_17;

		// Token: 0x04011DE0 RID: 73184
		internal static int __PropertyOffset_18;

		// Token: 0x04011DE1 RID: 73185
		internal static int __PropertyOffset_19;

		// Token: 0x04011DE2 RID: 73186
		internal static int __PropertyOffset_20;

		// Token: 0x04011DE3 RID: 73187
		internal static int __PropertyOffset_21;

		// Token: 0x04011DE4 RID: 73188
		internal static int __PropertyOffset_22;

		// Token: 0x04011DE5 RID: 73189
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011DE6 RID: 73190
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011DE7 RID: 73191
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04011DE8 RID: 73192
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011DE9 RID: 73193
		private static IntPtr __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DEA RID: 73194
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DEB RID: 73195
		private static IntPtr __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04011DEC RID: 73196
		private static IntPtr __ExecuteUbergraph_BP_BubbleCol_NativeFunctionPtr;

		// Token: 0x02009C97 RID: 40087
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040325B5 RID: 206261
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009C98 RID: 40088
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040325B6 RID: 206262
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009C99 RID: 40089
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_xpbd_test_K2Node_ComponentBoundEvent_1_ComponentHitSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325B7 RID: 206263
			[FieldOffset(0)]
			public IntPtr HitComponent;

			// Token: 0x040325B8 RID: 206264
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325B9 RID: 206265
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325BA RID: 206266
			[FieldOffset(24)]
			public FVector NormalImpulse;

			// Token: 0x040325BB RID: 206267
			[FieldOffset(36)]
			public byte Hit;
		}

		// Token: 0x02009C9A RID: 40090
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325BC RID: 206268
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325BD RID: 206269
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325BE RID: 206270
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325BF RID: 206271
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040325C0 RID: 206272
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040325C1 RID: 206273
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009C9B RID: 40091
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_RPBD_ValidBox_K2Node_ComponentBoundEvent_3_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040325C2 RID: 206274
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040325C3 RID: 206275
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040325C4 RID: 206276
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040325C5 RID: 206277
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009C9C RID: 40092
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2096)]
		protected ref struct __ExecuteUbergraph_BP_BubbleCol_FunctionParams
		{
			// Token: 0x040325C6 RID: 206278
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
