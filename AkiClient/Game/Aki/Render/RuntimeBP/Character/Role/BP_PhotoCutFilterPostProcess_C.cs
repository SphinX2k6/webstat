using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.Role
{
	// Token: 0x02003D60 RID: 15712
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/Role/BP_PhotoCutFilterPostProcess.BP_PhotoCutFilterPostProcess_C")]
	[UnrealStructLayout(1456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1452)]
	public class BP_PhotoCutFilterPostProcess_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026321 RID: 156449 RVA: 0x009D09B6 File Offset: 0x009CEBB6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhotoCutFilterPostProcess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/Role/BP_PhotoCutFilterPostProcess.BP_PhotoCutFilterPostProcess_C");
			}
			return BP_PhotoCutFilterPostProcess_C._ClassPtr;
		}

		// Token: 0x06026322 RID: 156450 RVA: 0x009D09DC File Offset: 0x009CEBDC
		public BP_PhotoCutFilterPostProcess_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhotoCutFilterPostProcess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026323 RID: 156451 RVA: 0x009D0A04 File Offset: 0x009CEC04
		[NullableContext(1)]
		public BP_PhotoCutFilterPostProcess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhotoCutFilterPostProcess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055EE RID: 21998
		// (get) Token: 0x06026324 RID: 156452 RVA: 0x009D0A38 File Offset: 0x009CEC38
		// (set) Token: 0x06026325 RID: 156453 RVA: 0x009D0A71 File Offset: 0x009CEC71
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170055EF RID: 21999
		// (get) Token: 0x06026326 RID: 156454 RVA: 0x009D0A92 File Offset: 0x009CEC92
		// (set) Token: 0x06026327 RID: 156455 RVA: 0x009D0AA6 File Offset: 0x009CECA6
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055F0 RID: 22000
		// (get) Token: 0x06026328 RID: 156456 RVA: 0x009D0ABB File Offset: 0x009CECBB
		// (set) Token: 0x06026329 RID: 156457 RVA: 0x009D0ACF File Offset: 0x009CECCF
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170055F1 RID: 22001
		// (get) Token: 0x0602632A RID: 156458 RVA: 0x009D0AE4 File Offset: 0x009CECE4
		// (set) Token: 0x0602632B RID: 156459 RVA: 0x009D0AF8 File Offset: 0x009CECF8
		public unsafe UMaterialInterface PostProcessMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170055F2 RID: 22002
		// (get) Token: 0x0602632C RID: 156460 RVA: 0x009D0B0D File Offset: 0x009CED0D
		// (set) Token: 0x0602632D RID: 156461 RVA: 0x009D0B21 File Offset: 0x009CED21
		public unsafe UMaterialInstanceDynamic PostProcessMI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhotoCutFilterPostProcess_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170055F3 RID: 22003
		// (get) Token: 0x0602632E RID: 156462 RVA: 0x009D0B36 File Offset: 0x009CED36
		// (set) Token: 0x0602632F RID: 156463 RVA: 0x009D0B46 File Offset: 0x009CED46
		public unsafe float AspectRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170055F4 RID: 22004
		// (get) Token: 0x06026330 RID: 156464 RVA: 0x009D0B57 File Offset: 0x009CED57
		// (set) Token: 0x06026331 RID: 156465 RVA: 0x009D0B67 File Offset: 0x009CED67
		public unsafe float FieldOfView
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170055F5 RID: 22005
		// (get) Token: 0x06026332 RID: 156466 RVA: 0x009D0B78 File Offset: 0x009CED78
		// (set) Token: 0x06026333 RID: 156467 RVA: 0x009D0B88 File Offset: 0x009CED88
		public unsafe float NearPlaneOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170055F6 RID: 22006
		// (get) Token: 0x06026334 RID: 156468 RVA: 0x009D0B99 File Offset: 0x009CED99
		// (set) Token: 0x06026335 RID: 156469 RVA: 0x009D0BAD File Offset: 0x009CEDAD
		public unsafe FLinearColor CameraPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170055F7 RID: 22007
		// (get) Token: 0x06026336 RID: 156470 RVA: 0x009D0BC2 File Offset: 0x009CEDC2
		// (set) Token: 0x06026337 RID: 156471 RVA: 0x009D0BD6 File Offset: 0x009CEDD6
		public unsafe FLinearColor CameraUp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170055F8 RID: 22008
		// (get) Token: 0x06026338 RID: 156472 RVA: 0x009D0BEB File Offset: 0x009CEDEB
		// (set) Token: 0x06026339 RID: 156473 RVA: 0x009D0BFF File Offset: 0x009CEDFF
		public unsafe FLinearColor CameraForward
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170055F9 RID: 22009
		// (get) Token: 0x0602633A RID: 156474 RVA: 0x009D0C14 File Offset: 0x009CEE14
		// (set) Token: 0x0602633B RID: 156475 RVA: 0x009D0C28 File Offset: 0x009CEE28
		public unsafe FLinearColor CameraRight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170055FA RID: 22010
		// (get) Token: 0x0602633C RID: 156476 RVA: 0x009D0C3D File Offset: 0x009CEE3D
		// (set) Token: 0x0602633D RID: 156477 RVA: 0x009D0C4D File Offset: 0x009CEE4D
		public unsafe bool UseScreenUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055FB RID: 22011
		// (get) Token: 0x0602633E RID: 156478 RVA: 0x009D0C5E File Offset: 0x009CEE5E
		// (set) Token: 0x0602633F RID: 156479 RVA: 0x009D0C6E File Offset: 0x009CEE6E
		public unsafe bool IsTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055FC RID: 22012
		// (get) Token: 0x06026340 RID: 156480 RVA: 0x009D0C7F File Offset: 0x009CEE7F
		// (set) Token: 0x06026341 RID: 156481 RVA: 0x009D0C8F File Offset: 0x009CEE8F
		public unsafe bool IsTickEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055FD RID: 22013
		// (get) Token: 0x06026342 RID: 156482 RVA: 0x009D0CA0 File Offset: 0x009CEEA0
		// (set) Token: 0x06026343 RID: 156483 RVA: 0x009D0CB0 File Offset: 0x009CEEB0
		public unsafe float CameraClipMaskInt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170055FE RID: 22014
		// (get) Token: 0x06026344 RID: 156484 RVA: 0x009D0CC1 File Offset: 0x009CEEC1
		// (set) Token: 0x06026345 RID: 156485 RVA: 0x009D0CD1 File Offset: 0x009CEED1
		public unsafe float ElapsedTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170055FF RID: 22015
		// (get) Token: 0x06026346 RID: 156486 RVA: 0x009D0CE2 File Offset: 0x009CEEE2
		// (set) Token: 0x06026347 RID: 156487 RVA: 0x009D0CF2 File Offset: 0x009CEEF2
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17005600 RID: 22016
		// (get) Token: 0x06026348 RID: 156488 RVA: 0x009D0D03 File Offset: 0x009CEF03
		// (set) Token: 0x06026349 RID: 156489 RVA: 0x009D0D13 File Offset: 0x009CEF13
		public unsafe float LifeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x17005601 RID: 22017
		// (get) Token: 0x0602634A RID: 156490 RVA: 0x009D0D24 File Offset: 0x009CEF24
		// (set) Token: 0x0602634B RID: 156491 RVA: 0x009D0D34 File Offset: 0x009CEF34
		public unsafe float EndTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PhotoCutFilterPostProcess_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x0602634C RID: 156492 RVA: 0x009D0D45 File Offset: 0x009CEF45
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SwitchScreenUV()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__SwitchScreenUV_NativeFunctionPtr, null);
		}

		// Token: 0x0602634D RID: 156493 RVA: 0x009D0D59 File Offset: 0x009CEF59
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetUpPostProcess()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__SetUpPostProcess_NativeFunctionPtr, null);
		}

		// Token: 0x0602634E RID: 156494 RVA: 0x009D0D70 File Offset: 0x009CEF70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateFxParams(FVectorDouble CameraLocation, FRotator CameraRotation, float AspectRatio, float FieldOfView)
		{
			BP_PhotoCutFilterPostProcess_C.__UpdateFxParams_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__UpdateFxParams_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__UpdateFxParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__UpdateFxParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CameraLocation = CameraLocation;
			ptr->CameraRotation = CameraRotation;
			ptr->AspectRatio = AspectRatio;
			ptr->FieldOfView = FieldOfView;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__UpdateFxParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602634F RID: 156495 RVA: 0x009D0DCF File Offset: 0x009CEFCF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06026350 RID: 156496 RVA: 0x009D0DE3 File Offset: 0x009CEFE3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06026351 RID: 156497 RVA: 0x009D0DF8 File Offset: 0x009CEFF8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026352 RID: 156498 RVA: 0x009D0E40 File Offset: 0x009CF040
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026353 RID: 156499 RVA: 0x009D0E88 File Offset: 0x009CF088
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026354 RID: 156500 RVA: 0x009D0ED0 File Offset: 0x009CF0D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026355 RID: 156501 RVA: 0x009D0F17 File Offset: 0x009CF117
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DelayToFadeOut()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__DelayToFadeOut_NativeFunctionPtr, null);
		}

		// Token: 0x06026356 RID: 156502 RVA: 0x009D0F2C File Offset: 0x009CF12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PhotoCutFilterPostProcess(int EntryPoint)
		{
			BP_PhotoCutFilterPostProcess_C.__ExecuteUbergraph_BP_PhotoCutFilterPostProcess_FunctionParams* ptr = stackalloc BP_PhotoCutFilterPostProcess_C.__ExecuteUbergraph_BP_PhotoCutFilterPostProcess_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_PhotoCutFilterPostProcess_C.__ExecuteUbergraph_BP_PhotoCutFilterPostProcess_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhotoCutFilterPostProcess_C.__ExecuteUbergraph_BP_PhotoCutFilterPostProcess_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PhotoCutFilterPostProcess_C.__ExecuteUbergraph_BP_PhotoCutFilterPostProcess_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026357 RID: 156503 RVA: 0x009D0F73 File Offset: 0x009CF173
		protected BP_PhotoCutFilterPostProcess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013CA2 RID: 81058
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/Role/BP_PhotoCutFilterPostProcess.BP_PhotoCutFilterPostProcess_C";

		// Token: 0x04013CA3 RID: 81059
		private static IntPtr _ClassPtr;

		// Token: 0x04013CA4 RID: 81060
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013CA5 RID: 81061
		internal static int __PropertyOffset_0;

		// Token: 0x04013CA6 RID: 81062
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013CA7 RID: 81063
		internal static int __PropertyOffset_1;

		// Token: 0x04013CA8 RID: 81064
		internal static int __PropertyOffset_2;

		// Token: 0x04013CA9 RID: 81065
		internal static int __PropertyOffset_3;

		// Token: 0x04013CAA RID: 81066
		internal static int __PropertyOffset_4;

		// Token: 0x04013CAB RID: 81067
		internal static int __PropertyOffset_5;

		// Token: 0x04013CAC RID: 81068
		internal static int __PropertyOffset_6;

		// Token: 0x04013CAD RID: 81069
		internal static int __PropertyOffset_7;

		// Token: 0x04013CAE RID: 81070
		internal static int __PropertyOffset_8;

		// Token: 0x04013CAF RID: 81071
		internal static int __PropertyOffset_9;

		// Token: 0x04013CB0 RID: 81072
		internal static int __PropertyOffset_10;

		// Token: 0x04013CB1 RID: 81073
		internal static int __PropertyOffset_11;

		// Token: 0x04013CB2 RID: 81074
		internal static int __PropertyOffset_12;

		// Token: 0x04013CB3 RID: 81075
		internal static int __PropertyOffset_13;

		// Token: 0x04013CB4 RID: 81076
		internal static int __PropertyOffset_14;

		// Token: 0x04013CB5 RID: 81077
		internal static int __PropertyOffset_15;

		// Token: 0x04013CB6 RID: 81078
		internal static int __PropertyOffset_16;

		// Token: 0x04013CB7 RID: 81079
		internal static int __PropertyOffset_17;

		// Token: 0x04013CB8 RID: 81080
		internal static int __PropertyOffset_18;

		// Token: 0x04013CB9 RID: 81081
		internal static int __PropertyOffset_19;

		// Token: 0x04013CBA RID: 81082
		private static IntPtr __SwitchScreenUV_NativeFunctionPtr;

		// Token: 0x04013CBB RID: 81083
		private static IntPtr __SetUpPostProcess_NativeFunctionPtr;

		// Token: 0x04013CBC RID: 81084
		private static IntPtr __UpdateFxParams_NativeFunctionPtr;

		// Token: 0x04013CBD RID: 81085
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013CBE RID: 81086
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013CBF RID: 81087
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013CC0 RID: 81088
		private static IntPtr __DelayToFadeOut_NativeFunctionPtr;

		// Token: 0x04013CC1 RID: 81089
		private static IntPtr __ExecuteUbergraph_BP_PhotoCutFilterPostProcess_NativeFunctionPtr;

		// Token: 0x0200A018 RID: 40984
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __UpdateFxParams_FunctionParams
		{
			// Token: 0x04032C01 RID: 207873
			[FieldOffset(0)]
			public FVectorDouble CameraLocation;

			// Token: 0x04032C02 RID: 207874
			[FieldOffset(24)]
			public FRotator CameraRotation;

			// Token: 0x04032C03 RID: 207875
			[FieldOffset(36)]
			public float AspectRatio;

			// Token: 0x04032C04 RID: 207876
			[FieldOffset(40)]
			public float FieldOfView;
		}

		// Token: 0x0200A019 RID: 40985
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032C05 RID: 207877
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A01A RID: 40986
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032C06 RID: 207878
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A01B RID: 40987
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __ExecuteUbergraph_BP_PhotoCutFilterPostProcess_FunctionParams
		{
			// Token: 0x04032C07 RID: 207879
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
