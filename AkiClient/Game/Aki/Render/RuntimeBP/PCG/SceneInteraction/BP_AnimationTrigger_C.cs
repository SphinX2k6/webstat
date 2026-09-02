using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B89 RID: 15241
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimationTrigger.BP_AnimationTrigger_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1548)]
	public class BP_AnimationTrigger_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021BA6 RID: 138150 RVA: 0x00951603 File Offset: 0x0094F803
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AnimationTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimationTrigger.BP_AnimationTrigger_C");
			}
			return BP_AnimationTrigger_C._ClassPtr;
		}

		// Token: 0x06021BA7 RID: 138151 RVA: 0x00951628 File Offset: 0x0094F828
		public BP_AnimationTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_AnimationTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021BA8 RID: 138152 RVA: 0x00951650 File Offset: 0x0094F850
		public BP_AnimationTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AnimationTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CB3 RID: 15539
		// (get) Token: 0x06021BA9 RID: 138153 RVA: 0x00951684 File Offset: 0x0094F884
		// (set) Token: 0x06021BAA RID: 138154 RVA: 0x009516BD File Offset: 0x0094F8BD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CB4 RID: 15540
		// (get) Token: 0x06021BAB RID: 138155 RVA: 0x009516DE File Offset: 0x0094F8DE
		// (set) Token: 0x06021BAC RID: 138156 RVA: 0x009516F2 File Offset: 0x0094F8F2
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimationTrigger_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimationTrigger_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CB5 RID: 15541
		// (get) Token: 0x06021BAD RID: 138157 RVA: 0x00951707 File Offset: 0x0094F907
		// (set) Token: 0x06021BAE RID: 138158 RVA: 0x0095171B File Offset: 0x0094F91B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimationTrigger_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimationTrigger_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CB6 RID: 15542
		// (get) Token: 0x06021BAF RID: 138159 RVA: 0x00951730 File Offset: 0x0094F930
		// (set) Token: 0x06021BB0 RID: 138160 RVA: 0x00951740 File Offset: 0x0094F940
		public unsafe bool IN
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CB7 RID: 15543
		// (get) Token: 0x06021BB1 RID: 138161 RVA: 0x00951751 File Offset: 0x0094F951
		// (set) Token: 0x06021BB2 RID: 138162 RVA: 0x00951761 File Offset: 0x0094F961
		public unsafe bool OUT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CB8 RID: 15544
		// (get) Token: 0x06021BB3 RID: 138163 RVA: 0x00951772 File Offset: 0x0094F972
		// (set) Token: 0x06021BB4 RID: 138164 RVA: 0x00951786 File Offset: 0x0094F986
		public unsafe FVector 触发框大小
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003CB9 RID: 15545
		// (get) Token: 0x06021BB5 RID: 138165 RVA: 0x0095179B File Offset: 0x0094F99B
		// (set) Token: 0x06021BB6 RID: 138166 RVA: 0x009517AB File Offset: 0x0094F9AB
		public unsafe float 动画时长
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003CBA RID: 15546
		// (get) Token: 0x06021BB7 RID: 138167 RVA: 0x009517BC File Offset: 0x0094F9BC
		// (set) Token: 0x06021BB8 RID: 138168 RVA: 0x009517F5 File Offset: 0x0094F9F5
		public TMap<UStaticMesh, int> 模型资产
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMesh, int> result;
				if ((result = this._模型资产) == null)
				{
					result = (this._模型资产 = new TMap<UStaticMesh, int>(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.模型资产.CopyAssign(value);
			}
		}

		// Token: 0x17003CBB RID: 15547
		// (get) Token: 0x06021BB9 RID: 138169 RVA: 0x00951804 File Offset: 0x0094FA04
		// (set) Token: 0x06021BBA RID: 138170 RVA: 0x0095183D File Offset: 0x0094FA3D
		public TMap<UStaticMeshComponent, int> Components
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UStaticMeshComponent, int> result;
				if ((result = this._Components) == null)
				{
					result = (this._Components = new TMap<UStaticMeshComponent, int>(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.Components.CopyAssign(value);
			}
		}

		// Token: 0x17003CBC RID: 15548
		// (get) Token: 0x06021BBB RID: 138171 RVA: 0x0095184B File Offset: 0x0094FA4B
		// (set) Token: 0x06021BBC RID: 138172 RVA: 0x0095185B File Offset: 0x0094FA5B
		public unsafe bool Trigger
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003CBD RID: 15549
		// (get) Token: 0x06021BBD RID: 138173 RVA: 0x0095186C File Offset: 0x0094FA6C
		// (set) Token: 0x06021BBE RID: 138174 RVA: 0x0095187C File Offset: 0x0094FA7C
		public unsafe int InBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003CBE RID: 15550
		// (get) Token: 0x06021BBF RID: 138175 RVA: 0x0095188D File Offset: 0x0094FA8D
		// (set) Token: 0x06021BC0 RID: 138176 RVA: 0x0095189D File Offset: 0x0094FA9D
		public unsafe float LastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003CBF RID: 15551
		// (get) Token: 0x06021BC1 RID: 138177 RVA: 0x009518AE File Offset: 0x0094FAAE
		// (set) Token: 0x06021BC2 RID: 138178 RVA: 0x009518BE File Offset: 0x0094FABE
		public unsafe float CurrentTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003CC0 RID: 15552
		// (get) Token: 0x06021BC3 RID: 138179 RVA: 0x009518CF File Offset: 0x0094FACF
		// (set) Token: 0x06021BC4 RID: 138180 RVA: 0x009518DF File Offset: 0x0094FADF
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimationTrigger_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x06021BC5 RID: 138181 RVA: 0x009518F0 File Offset: 0x0094FAF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimationTrigger_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021BC6 RID: 138182 RVA: 0x00951904 File Offset: 0x0094FB04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimationTrigger_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021BC7 RID: 138183 RVA: 0x00951919 File Offset: 0x0094FB19
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimationTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021BC8 RID: 138184 RVA: 0x0095192D File Offset: 0x0094FB2D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimationTrigger_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021BC9 RID: 138185 RVA: 0x00951944 File Offset: 0x0094FB44
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BCA RID: 138186 RVA: 0x00951A00 File Offset: 0x0094FC00
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimationTrigger_C.__BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BCB RID: 138187 RVA: 0x00951A8C File Offset: 0x0094FC8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AnimationTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AnimationTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AnimationTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimationTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimationTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BCC RID: 138188 RVA: 0x00951AD4 File Offset: 0x0094FCD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AnimationTrigger_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AnimationTrigger_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AnimationTrigger_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimationTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimationTrigger_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BCD RID: 138189 RVA: 0x00951B1C File Offset: 0x0094FD1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AnimationTrigger(int EntryPoint)
		{
			BP_AnimationTrigger_C.__ExecuteUbergraph_BP_AnimationTrigger_FunctionParams* ptr = stackalloc BP_AnimationTrigger_C.__ExecuteUbergraph_BP_AnimationTrigger_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(BP_AnimationTrigger_C.__ExecuteUbergraph_BP_AnimationTrigger_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimationTrigger_C.__ExecuteUbergraph_BP_AnimationTrigger_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimationTrigger_C.__ExecuteUbergraph_BP_AnimationTrigger_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BCE RID: 138190 RVA: 0x00951B66 File Offset: 0x0094FD66
		protected BP_AnimationTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011025 RID: 69669
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimationTrigger.BP_AnimationTrigger_C";

		// Token: 0x04011026 RID: 69670
		private static IntPtr _ClassPtr;

		// Token: 0x04011027 RID: 69671
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011028 RID: 69672
		internal static int __PropertyOffset_0;

		// Token: 0x04011029 RID: 69673
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401102A RID: 69674
		internal static int __PropertyOffset_1;

		// Token: 0x0401102B RID: 69675
		internal static int __PropertyOffset_2;

		// Token: 0x0401102C RID: 69676
		internal static int __PropertyOffset_3;

		// Token: 0x0401102D RID: 69677
		internal static int __PropertyOffset_4;

		// Token: 0x0401102E RID: 69678
		internal static int __PropertyOffset_5;

		// Token: 0x0401102F RID: 69679
		internal static int __PropertyOffset_6;

		// Token: 0x04011030 RID: 69680
		internal static int __PropertyOffset_7;

		// Token: 0x04011031 RID: 69681
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UStaticMesh, int> _模型资产;

		// Token: 0x04011032 RID: 69682
		internal static int __PropertyOffset_8;

		// Token: 0x04011033 RID: 69683
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UStaticMeshComponent, int> _Components;

		// Token: 0x04011034 RID: 69684
		internal static int __PropertyOffset_9;

		// Token: 0x04011035 RID: 69685
		internal static int __PropertyOffset_10;

		// Token: 0x04011036 RID: 69686
		internal static int __PropertyOffset_11;

		// Token: 0x04011037 RID: 69687
		internal static int __PropertyOffset_12;

		// Token: 0x04011038 RID: 69688
		internal static int __PropertyOffset_13;

		// Token: 0x04011039 RID: 69689
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401103A RID: 69690
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401103B RID: 69691
		private static IntPtr __BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401103C RID: 69692
		private static IntPtr __BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0401103D RID: 69693
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401103E RID: 69694
		private static IntPtr __ExecuteUbergraph_BP_AnimationTrigger_NativeFunctionPtr;

		// Token: 0x02009B2F RID: 39727
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322E7 RID: 205543
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322E8 RID: 205544
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322E9 RID: 205545
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322EA RID: 205546
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040322EB RID: 205547
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040322EC RID: 205548
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009B30 RID: 39728
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_AnimationTrigger_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040322ED RID: 205549
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040322EE RID: 205550
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040322EF RID: 205551
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040322F0 RID: 205552
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009B31 RID: 39729
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040322F1 RID: 205553
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B32 RID: 39730
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected ref struct __ExecuteUbergraph_BP_AnimationTrigger_FunctionParams
		{
			// Token: 0x040322F2 RID: 205554
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
