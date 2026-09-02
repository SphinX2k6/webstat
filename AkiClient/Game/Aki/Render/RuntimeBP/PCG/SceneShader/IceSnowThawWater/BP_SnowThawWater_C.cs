using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.IceSnowThawWater
{
	// Token: 0x02003B7D RID: 15229
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/IceSnowThawWater/BP_SnowThawWater.BP_SnowThawWater_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1416)]
	public class BP_SnowThawWater_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_DayNightEvent_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06021955 RID: 137557 RVA: 0x0094D35F File Offset: 0x0094B55F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowThawWater_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/IceSnowThawWater/BP_SnowThawWater.BP_SnowThawWater_C");
			}
			return BP_SnowThawWater_C._ClassPtr;
		}

		// Token: 0x06021956 RID: 137558 RVA: 0x0094D384 File Offset: 0x0094B584
		public BP_SnowThawWater_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowThawWater_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021957 RID: 137559 RVA: 0x0094D3AC File Offset: 0x0094B5AC
		[NullableContext(1)]
		public BP_SnowThawWater_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowThawWater_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BEA RID: 15338
		// (get) Token: 0x06021958 RID: 137560 RVA: 0x0094D3E0 File Offset: 0x0094B5E0
		// (set) Token: 0x06021959 RID: 137561 RVA: 0x0094D419 File Offset: 0x0094B619
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003BEB RID: 15339
		// (get) Token: 0x0602195A RID: 137562 RVA: 0x0094D43A File Offset: 0x0094B63A
		// (set) Token: 0x0602195B RID: 137563 RVA: 0x0094D44E File Offset: 0x0094B64E
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BEC RID: 15340
		// (get) Token: 0x0602195C RID: 137564 RVA: 0x0094D463 File Offset: 0x0094B663
		// (set) Token: 0x0602195D RID: 137565 RVA: 0x0094D477 File Offset: 0x0094B677
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003BED RID: 15341
		// (get) Token: 0x0602195E RID: 137566 RVA: 0x0094D48C File Offset: 0x0094B68C
		// (set) Token: 0x0602195F RID: 137567 RVA: 0x0094D4A0 File Offset: 0x0094B6A0
		public unsafe UStaticMesh SnowStaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003BEE RID: 15342
		// (get) Token: 0x06021960 RID: 137568 RVA: 0x0094D4B5 File Offset: 0x0094B6B5
		// (set) Token: 0x06021961 RID: 137569 RVA: 0x0094D4C5 File Offset: 0x0094B6C5
		public unsafe float SM_SinkHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003BEF RID: 15343
		// (get) Token: 0x06021962 RID: 137570 RVA: 0x0094D4D6 File Offset: 0x0094B6D6
		// (set) Token: 0x06021963 RID: 137571 RVA: 0x0094D4EA File Offset: 0x0094B6EA
		public unsafe FVectorDouble OriginalPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003BF0 RID: 15344
		// (get) Token: 0x06021964 RID: 137572 RVA: 0x0094D4FF File Offset: 0x0094B6FF
		// (set) Token: 0x06021965 RID: 137573 RVA: 0x0094D50F File Offset: 0x0094B70F
		public unsafe bool IsFirstInit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BF1 RID: 15345
		// (get) Token: 0x06021966 RID: 137574 RVA: 0x0094D520 File Offset: 0x0094B720
		// (set) Token: 0x06021967 RID: 137575 RVA: 0x0094D530 File Offset: 0x0094B730
		public unsafe float StartZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003BF2 RID: 15346
		// (get) Token: 0x06021968 RID: 137576 RVA: 0x0094D541 File Offset: 0x0094B741
		// (set) Token: 0x06021969 RID: 137577 RVA: 0x0094D551 File Offset: 0x0094B751
		public unsafe float TargetZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003BF3 RID: 15347
		// (get) Token: 0x0602196A RID: 137578 RVA: 0x0094D562 File Offset: 0x0094B762
		// (set) Token: 0x0602196B RID: 137579 RVA: 0x0094D572 File Offset: 0x0094B772
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003BF4 RID: 15348
		// (get) Token: 0x0602196C RID: 137580 RVA: 0x0094D583 File Offset: 0x0094B783
		// (set) Token: 0x0602196D RID: 137581 RVA: 0x0094D593 File Offset: 0x0094B793
		public unsafe bool StartEditorTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SnowThawWater_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BF5 RID: 15349
		// (get) Token: 0x0602196E RID: 137582 RVA: 0x0094D5A4 File Offset: 0x0094B7A4
		// (set) Token: 0x0602196F RID: 137583 RVA: 0x0094D5B8 File Offset: 0x0094B7B8
		public unsafe UMaterialInstanceDynamic DMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowThawWater_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x06021970 RID: 137584 RVA: 0x0094D5CD File Offset: 0x0094B7CD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Set_DMI()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__Set_DMI_NativeFunctionPtr, null);
		}

		// Token: 0x06021971 RID: 137585 RVA: 0x0094D5E1 File Offset: 0x0094B7E1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug_Night()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__Debug_Night_NativeFunctionPtr, null);
		}

		// Token: 0x06021972 RID: 137586 RVA: 0x0094D5F5 File Offset: 0x0094B7F5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug_Day()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__Debug_Day_NativeFunctionPtr, null);
		}

		// Token: 0x06021973 RID: 137587 RVA: 0x0094D609 File Offset: 0x0094B809
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetOriginalPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__SetOriginalPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06021974 RID: 137588 RVA: 0x0094D61D File Offset: 0x0094B81D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021975 RID: 137589 RVA: 0x0094D631 File Offset: 0x0094B831
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021976 RID: 137590 RVA: 0x0094D648 File Offset: 0x0094B848
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateSculptureHeight(bool IsDay)
		{
			BP_SnowThawWater_C.__UpdateSculptureHeight_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__UpdateSculptureHeight_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SnowThawWater_C.__UpdateSculptureHeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__UpdateSculptureHeight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDay = IsDay;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__UpdateSculptureHeight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021977 RID: 137591 RVA: 0x0094D68E File Offset: 0x0094B88E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnterDay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__OnEnterDay_NativeFunctionPtr, null);
		}

		// Token: 0x06021978 RID: 137592 RVA: 0x0094D6A2 File Offset: 0x0094B8A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnEnterNight()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__OnEnterNight_NativeFunctionPtr, null);
		}

		// Token: 0x06021979 RID: 137593 RVA: 0x0094D6B6 File Offset: 0x0094B8B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602197A RID: 137594 RVA: 0x0094D6CA File Offset: 0x0094B8CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602197B RID: 137595 RVA: 0x0094D6E0 File Offset: 0x0094B8E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602197C RID: 137596 RVA: 0x0094D72C File Offset: 0x0094B92C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SnowThawWater_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602197D RID: 137597 RVA: 0x0094D778 File Offset: 0x0094B978
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SnowThawWater_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowThawWater_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602197E RID: 137598 RVA: 0x0094D7C0 File Offset: 0x0094B9C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SnowThawWater_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowThawWater_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602197F RID: 137599 RVA: 0x0094D808 File Offset: 0x0094BA08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SnowThawWater_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowThawWater_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021980 RID: 137600 RVA: 0x0094D850 File Offset: 0x0094BA50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SnowThawWater_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SnowThawWater_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021981 RID: 137601 RVA: 0x0094D898 File Offset: 0x0094BA98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SnowThawWater(int EntryPoint)
		{
			BP_SnowThawWater_C.__ExecuteUbergraph_BP_SnowThawWater_FunctionParams* ptr = stackalloc BP_SnowThawWater_C.__ExecuteUbergraph_BP_SnowThawWater_FunctionParams[(UIntPtr)831] + 15L / (long)sizeof(BP_SnowThawWater_C.__ExecuteUbergraph_BP_SnowThawWater_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SnowThawWater_C.__ExecuteUbergraph_BP_SnowThawWater_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SnowThawWater_C.__ExecuteUbergraph_BP_SnowThawWater_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021982 RID: 137602 RVA: 0x0094D8E2 File Offset: 0x0094BAE2
		protected BP_SnowThawWater_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010EBE RID: 69310
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/IceSnowThawWater/BP_SnowThawWater.BP_SnowThawWater_C";

		// Token: 0x04010EBF RID: 69311
		private static IntPtr _ClassPtr;

		// Token: 0x04010EC0 RID: 69312
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010EC1 RID: 69313
		internal static int __PropertyOffset_0;

		// Token: 0x04010EC2 RID: 69314
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010EC3 RID: 69315
		internal static int __PropertyOffset_1;

		// Token: 0x04010EC4 RID: 69316
		internal static int __PropertyOffset_2;

		// Token: 0x04010EC5 RID: 69317
		internal static int __PropertyOffset_3;

		// Token: 0x04010EC6 RID: 69318
		internal static int __PropertyOffset_4;

		// Token: 0x04010EC7 RID: 69319
		internal static int __PropertyOffset_5;

		// Token: 0x04010EC8 RID: 69320
		internal static int __PropertyOffset_6;

		// Token: 0x04010EC9 RID: 69321
		internal static int __PropertyOffset_7;

		// Token: 0x04010ECA RID: 69322
		internal static int __PropertyOffset_8;

		// Token: 0x04010ECB RID: 69323
		internal static int __PropertyOffset_9;

		// Token: 0x04010ECC RID: 69324
		internal static int __PropertyOffset_10;

		// Token: 0x04010ECD RID: 69325
		internal static int __PropertyOffset_11;

		// Token: 0x04010ECE RID: 69326
		private static IntPtr __Set_DMI_NativeFunctionPtr;

		// Token: 0x04010ECF RID: 69327
		private static IntPtr __Debug_Night_NativeFunctionPtr;

		// Token: 0x04010ED0 RID: 69328
		private static IntPtr __Debug_Day_NativeFunctionPtr;

		// Token: 0x04010ED1 RID: 69329
		private static IntPtr __SetOriginalPosition_NativeFunctionPtr;

		// Token: 0x04010ED2 RID: 69330
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010ED3 RID: 69331
		private static IntPtr __UpdateSculptureHeight_NativeFunctionPtr;

		// Token: 0x04010ED4 RID: 69332
		private static IntPtr __OnEnterDay_NativeFunctionPtr;

		// Token: 0x04010ED5 RID: 69333
		private static IntPtr __OnEnterNight_NativeFunctionPtr;

		// Token: 0x04010ED6 RID: 69334
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010ED7 RID: 69335
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010ED8 RID: 69336
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010ED9 RID: 69337
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010EDA RID: 69338
		private static IntPtr __ExecuteUbergraph_BP_SnowThawWater_NativeFunctionPtr;

		// Token: 0x02009AFB RID: 39675
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __UpdateSculptureHeight_FunctionParams
		{
			// Token: 0x0403229B RID: 205467
			[FieldOffset(0)]
			public bool IsDay;
		}

		// Token: 0x02009AFC RID: 39676
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x0403229C RID: 205468
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009AFD RID: 39677
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403229D RID: 205469
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AFE RID: 39678
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403229E RID: 205470
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AFF RID: 39679
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 816)]
		protected ref struct __ExecuteUbergraph_BP_SnowThawWater_FunctionParams
		{
			// Token: 0x0403229F RID: 205471
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
