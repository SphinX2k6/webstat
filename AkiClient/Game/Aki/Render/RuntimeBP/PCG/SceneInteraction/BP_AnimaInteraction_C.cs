using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneInteraction
{
	// Token: 0x02003B88 RID: 15240
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimaInteraction.BP_AnimaInteraction_C")]
	[UnrealStructLayout(1352, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1349)]
	public class BP_AnimaInteraction_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_DayNightEvent_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06021B85 RID: 138117 RVA: 0x0095105F File Offset: 0x0094F25F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AnimaInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimaInteraction.BP_AnimaInteraction_C");
			}
			return BP_AnimaInteraction_C._ClassPtr;
		}

		// Token: 0x06021B86 RID: 138118 RVA: 0x00951084 File Offset: 0x0094F284
		public BP_AnimaInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_AnimaInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021B87 RID: 138119 RVA: 0x009510AC File Offset: 0x0094F2AC
		[NullableContext(1)]
		public BP_AnimaInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AnimaInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003CAE RID: 15534
		// (get) Token: 0x06021B88 RID: 138120 RVA: 0x009510E0 File Offset: 0x0094F2E0
		// (set) Token: 0x06021B89 RID: 138121 RVA: 0x00951119 File Offset: 0x0094F319
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003CAF RID: 15535
		// (get) Token: 0x06021B8A RID: 138122 RVA: 0x0095113A File Offset: 0x0094F33A
		// (set) Token: 0x06021B8B RID: 138123 RVA: 0x0095114E File Offset: 0x0094F34E
		[Nullable(2)]
		public unsafe USkeletalMeshComponent SK_Col_Bui_42AM
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimaInteraction_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimaInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003CB0 RID: 15536
		// (get) Token: 0x06021B8C RID: 138124 RVA: 0x00951163 File Offset: 0x0094F363
		// (set) Token: 0x06021B8D RID: 138125 RVA: 0x00951177 File Offset: 0x0094F377
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimaInteraction_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AnimaInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003CB1 RID: 15537
		// (get) Token: 0x06021B8E RID: 138126 RVA: 0x0095118C File Offset: 0x0094F38C
		// (set) Token: 0x06021B8F RID: 138127 RVA: 0x0095119C File Offset: 0x0094F39C
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003CB2 RID: 15538
		// (get) Token: 0x06021B90 RID: 138128 RVA: 0x009511AD File Offset: 0x0094F3AD
		// (set) Token: 0x06021B91 RID: 138129 RVA: 0x009511BD File Offset: 0x0094F3BD
		public unsafe bool IsDaytime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimaInteraction_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021B92 RID: 138130 RVA: 0x009511CE File Offset: 0x0094F3CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021B93 RID: 138131 RVA: 0x009511E2 File Offset: 0x0094F3E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimaInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021B94 RID: 138132 RVA: 0x009511F8 File Offset: 0x0094F3F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B95 RID: 138133 RVA: 0x00951240 File Offset: 0x0094F440
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B96 RID: 138134 RVA: 0x00951288 File Offset: 0x0094F488
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_142B7BB44212D48928074EA2B856E6F8(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnInterrupted_142B7BB44212D48928074EA2B856E6F8_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnInterrupted_142B7BB44212D48928074EA2B856E6F8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnInterrupted_142B7BB44212D48928074EA2B856E6F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnInterrupted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnInterrupted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B97 RID: 138135 RVA: 0x009512D0 File Offset: 0x0094F4D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_142B7BB44212D48928074EA2B856E6F8(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnBlendOut_142B7BB44212D48928074EA2B856E6F8_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnBlendOut_142B7BB44212D48928074EA2B856E6F8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnBlendOut_142B7BB44212D48928074EA2B856E6F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnBlendOut_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnBlendOut_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B98 RID: 138136 RVA: 0x00951318 File Offset: 0x0094F518
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_142B7BB44212D48928074EA2B856E6F8(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnCompleted_142B7BB44212D48928074EA2B856E6F8_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnCompleted_142B7BB44212D48928074EA2B856E6F8_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnCompleted_142B7BB44212D48928074EA2B856E6F8_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnCompleted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnCompleted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B99 RID: 138137 RVA: 0x00951360 File Offset: 0x0094F560
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B9A RID: 138138 RVA: 0x009513A8 File Offset: 0x0094F5A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B9B RID: 138139 RVA: 0x009513F0 File Offset: 0x0094F5F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B9C RID: 138140 RVA: 0x00951438 File Offset: 0x0094F638
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B9D RID: 138141 RVA: 0x00951480 File Offset: 0x0094F680
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B(FName NotifyName)
		{
			BP_AnimaInteraction_C.__OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_AnimaInteraction_C.__OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NotifyName = NotifyName;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021B9E RID: 138142 RVA: 0x009514C6 File Offset: 0x0094F6C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnterNight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnEnterNight_NativeFunctionPtr, null);
		}

		// Token: 0x06021B9F RID: 138143 RVA: 0x009514DA File Offset: 0x0094F6DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnterDay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__OnEnterDay_NativeFunctionPtr, null);
		}

		// Token: 0x06021BA0 RID: 138144 RVA: 0x009514EE File Offset: 0x0094F6EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021BA1 RID: 138145 RVA: 0x00951502 File Offset: 0x0094F702
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimaInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021BA2 RID: 138146 RVA: 0x00951518 File Offset: 0x0094F718
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimaInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021BA3 RID: 138147 RVA: 0x00951564 File Offset: 0x0094F764
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_AnimaInteraction_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimaInteraction_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BA4 RID: 138148 RVA: 0x009515B0 File Offset: 0x0094F7B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AnimaInteraction(int EntryPoint)
		{
			BP_AnimaInteraction_C.__ExecuteUbergraph_BP_AnimaInteraction_FunctionParams* ptr = stackalloc BP_AnimaInteraction_C.__ExecuteUbergraph_BP_AnimaInteraction_FunctionParams[(UIntPtr)663] + 15L / (long)sizeof(BP_AnimaInteraction_C.__ExecuteUbergraph_BP_AnimaInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimaInteraction_C.__ExecuteUbergraph_BP_AnimaInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimaInteraction_C.__ExecuteUbergraph_BP_AnimaInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021BA5 RID: 138149 RVA: 0x009515FA File Offset: 0x0094F7FA
		protected BP_AnimaInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401100C RID: 69644
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneInteraction/BP_AnimaInteraction.BP_AnimaInteraction_C";

		// Token: 0x0401100D RID: 69645
		private static IntPtr _ClassPtr;

		// Token: 0x0401100E RID: 69646
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401100F RID: 69647
		internal static int __PropertyOffset_0;

		// Token: 0x04011010 RID: 69648
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011011 RID: 69649
		internal static int __PropertyOffset_1;

		// Token: 0x04011012 RID: 69650
		internal static int __PropertyOffset_2;

		// Token: 0x04011013 RID: 69651
		internal static int __PropertyOffset_3;

		// Token: 0x04011014 RID: 69652
		internal static int __PropertyOffset_4;

		// Token: 0x04011015 RID: 69653
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011016 RID: 69654
		private static IntPtr __OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr;

		// Token: 0x04011017 RID: 69655
		private static IntPtr __OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr;

		// Token: 0x04011018 RID: 69656
		private static IntPtr __OnInterrupted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr;

		// Token: 0x04011019 RID: 69657
		private static IntPtr __OnBlendOut_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr;

		// Token: 0x0401101A RID: 69658
		private static IntPtr __OnCompleted_142B7BB44212D48928074EA2B856E6F8_NativeFunctionPtr;

		// Token: 0x0401101B RID: 69659
		private static IntPtr __OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr;

		// Token: 0x0401101C RID: 69660
		private static IntPtr __OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr;

		// Token: 0x0401101D RID: 69661
		private static IntPtr __OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr;

		// Token: 0x0401101E RID: 69662
		private static IntPtr __OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr;

		// Token: 0x0401101F RID: 69663
		private static IntPtr __OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_NativeFunctionPtr;

		// Token: 0x04011020 RID: 69664
		private static IntPtr __OnEnterNight_NativeFunctionPtr;

		// Token: 0x04011021 RID: 69665
		private static IntPtr __OnEnterDay_NativeFunctionPtr;

		// Token: 0x04011022 RID: 69666
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04011023 RID: 69667
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04011024 RID: 69668
		private static IntPtr __ExecuteUbergraph_BP_AnimaInteraction_NativeFunctionPtr;

		// Token: 0x02009B23 RID: 39715
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_142B7BB44212D48928074EA2B856E6F8_FunctionParams
		{
			// Token: 0x040322DB RID: 205531
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B24 RID: 39716
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_142B7BB44212D48928074EA2B856E6F8_FunctionParams
		{
			// Token: 0x040322DC RID: 205532
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B25 RID: 39717
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_142B7BB44212D48928074EA2B856E6F8_FunctionParams
		{
			// Token: 0x040322DD RID: 205533
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B26 RID: 39718
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_142B7BB44212D48928074EA2B856E6F8_FunctionParams
		{
			// Token: 0x040322DE RID: 205534
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B27 RID: 39719
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_142B7BB44212D48928074EA2B856E6F8_FunctionParams
		{
			// Token: 0x040322DF RID: 205535
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B28 RID: 39720
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyEnd_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams
		{
			// Token: 0x040322E0 RID: 205536
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B29 RID: 39721
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnNotifyBegin_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams
		{
			// Token: 0x040322E1 RID: 205537
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B2A RID: 39722
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnInterrupted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams
		{
			// Token: 0x040322E2 RID: 205538
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B2B RID: 39723
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnBlendOut_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams
		{
			// Token: 0x040322E3 RID: 205539
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B2C RID: 39724
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __OnCompleted_194B232544CEDB40C8F0FA9B8B995E7B_FunctionParams
		{
			// Token: 0x040322E4 RID: 205540
			[FieldOffset(0)]
			public FName NotifyName;
		}

		// Token: 0x02009B2D RID: 39725
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040322E5 RID: 205541
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009B2E RID: 39726
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 648)]
		protected ref struct __ExecuteUbergraph_BP_AnimaInteraction_FunctionParams
		{
			// Token: 0x040322E6 RID: 205542
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
