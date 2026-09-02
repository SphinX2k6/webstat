using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interface;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneCapture_3To2
{
	// Token: 0x02003B32 RID: 15154
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneCapture_3To2/BP_SceneCapture_3To2.BP_SceneCapture_3To2_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1441)]
	public class BP_SceneCapture_3To2_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_SceneBp_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x06020B15 RID: 133909 RVA: 0x009343A0 File Offset: 0x009325A0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneCapture_3To2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneCapture_3To2/BP_SceneCapture_3To2.BP_SceneCapture_3To2_C");
			}
			return BP_SceneCapture_3To2_C._ClassPtr;
		}

		// Token: 0x06020B16 RID: 133910 RVA: 0x009343C4 File Offset: 0x009325C4
		public BP_SceneCapture_3To2_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneCapture_3To2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020B17 RID: 133911 RVA: 0x009343EC File Offset: 0x009325EC
		public BP_SceneCapture_3To2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneCapture_3To2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170036BD RID: 14013
		// (get) Token: 0x06020B18 RID: 133912 RVA: 0x00934420 File Offset: 0x00932620
		// (set) Token: 0x06020B19 RID: 133913 RVA: 0x00934459 File Offset: 0x00932659
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170036BE RID: 14014
		// (get) Token: 0x06020B1A RID: 133914 RVA: 0x0093447A File Offset: 0x0093267A
		// (set) Token: 0x06020B1B RID: 133915 RVA: 0x0093448E File Offset: 0x0093268E
		[Nullable(2)]
		public unsafe USceneCaptureComponent2D SceneCaptureComponent2D
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036BF RID: 14015
		// (get) Token: 0x06020B1C RID: 133916 RVA: 0x009344A3 File Offset: 0x009326A3
		// (set) Token: 0x06020B1D RID: 133917 RVA: 0x009344B7 File Offset: 0x009326B7
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170036C0 RID: 14016
		// (get) Token: 0x06020B1E RID: 133918 RVA: 0x009344CC File Offset: 0x009326CC
		// (set) Token: 0x06020B1F RID: 133919 RVA: 0x00934505 File Offset: 0x00932705
		public TArray<AActor> HiddenActor
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._HiddenActor) == null)
				{
					result = (this._HiddenActor = new TArray<AActor>(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.HiddenActor.CopyAssign(value);
			}
		}

		// Token: 0x170036C1 RID: 14017
		// (get) Token: 0x06020B20 RID: 133920 RVA: 0x00934514 File Offset: 0x00932714
		// (set) Token: 0x06020B21 RID: 133921 RVA: 0x0093454D File Offset: 0x0093274D
		public TArray<AActor> ActorPosition
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ActorPosition) == null)
				{
					result = (this._ActorPosition = new TArray<AActor>(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.ActorPosition.CopyAssign(value);
			}
		}

		// Token: 0x170036C2 RID: 14018
		// (get) Token: 0x06020B22 RID: 133922 RVA: 0x0093455B File Offset: 0x0093275B
		// (set) Token: 0x06020B23 RID: 133923 RVA: 0x0093456B File Offset: 0x0093276B
		public unsafe bool Capture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170036C3 RID: 14019
		// (get) Token: 0x06020B24 RID: 133924 RVA: 0x0093457C File Offset: 0x0093277C
		// (set) Token: 0x06020B25 RID: 133925 RVA: 0x00934590 File Offset: 0x00932790
		[Nullable(2)]
		public unsafe AKuroPostProcessVolume PPV
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AKuroPostProcessVolume>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170036C4 RID: 14020
		// (get) Token: 0x06020B26 RID: 133926 RVA: 0x009345A5 File Offset: 0x009327A5
		// (set) Token: 0x06020B27 RID: 133927 RVA: 0x009345BA File Offset: 0x009327BA
		public TSoftObjectPtr<UTextureRenderTarget2D> RTSoft
		{
			get
			{
				return new TSoftObjectPtr<UTextureRenderTarget2D>(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_7, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170036C5 RID: 14021
		// (get) Token: 0x06020B28 RID: 133928 RVA: 0x009345DF File Offset: 0x009327DF
		// (set) Token: 0x06020B29 RID: 133929 RVA: 0x009345F3 File Offset: 0x009327F3
		[Nullable(2)]
		public unsafe UTextureRenderTarget2D RT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_8);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneCapture_3To2_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170036C6 RID: 14022
		// (get) Token: 0x06020B2A RID: 133930 RVA: 0x00934608 File Offset: 0x00932808
		// (set) Token: 0x06020B2B RID: 133931 RVA: 0x00934618 File Offset: 0x00932818
		public unsafe bool First
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SceneCapture_3To2_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x06020B2C RID: 133932 RVA: 0x0093462C File Offset: 0x0093282C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetAoiRange(ref int ret)
		{
			BP_SceneCapture_3To2_C.__GetAoiRange_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__GetAoiRange_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__GetAoiRange_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__GetAoiRange_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020B2D RID: 133933 RVA: 0x0093467C File Offset: 0x0093287C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShouldStopOnHide(ref bool ret)
		{
			BP_SceneCapture_3To2_C.__ShouldStopOnHide_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__ShouldStopOnHide_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__ShouldStopOnHide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ret = ret;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ShouldStopOnHide_NativeFunctionPtr, (void*)ptr);
			ret = ptr->ret;
		}

		// Token: 0x06020B2E RID: 133934 RVA: 0x009346CB File Offset: 0x009328CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableToonDepth()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__DisableToonDepth_NativeFunctionPtr, null);
		}

		// Token: 0x06020B2F RID: 133935 RVA: 0x009346DF File Offset: 0x009328DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableToonDepth()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__EnableToonDepth_NativeFunctionPtr, null);
		}

		// Token: 0x06020B30 RID: 133936 RVA: 0x009346F3 File Offset: 0x009328F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AllowOcclusionQueries()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__AllowOcclusionQueries_NativeFunctionPtr, null);
		}

		// Token: 0x06020B31 RID: 133937 RVA: 0x00934707 File Offset: 0x00932907
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ClearRT()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ClearRT_NativeFunctionPtr, null);
		}

		// Token: 0x06020B32 RID: 133938 RVA: 0x0093471C File Offset: 0x0093291C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetEnablePPV(float Enable3To2Toggle)
		{
			BP_SceneCapture_3To2_C.__SetEnablePPV_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__SetEnablePPV_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__SetEnablePPV_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__SetEnablePPV_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Enable3To2Toggle = Enable3To2Toggle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__SetEnablePPV_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020B33 RID: 133939 RVA: 0x00934762 File Offset: 0x00932962
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CaptureScene_Running()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__CaptureScene_Running_NativeFunctionPtr, null);
		}

		// Token: 0x06020B34 RID: 133940 RVA: 0x00934776 File Offset: 0x00932976
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TickOutside()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__TickOutside_NativeFunctionPtr, null);
		}

		// Token: 0x06020B35 RID: 133941 RVA: 0x0093478A File Offset: 0x0093298A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Start()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__Start_NativeFunctionPtr, null);
		}

		// Token: 0x06020B36 RID: 133942 RVA: 0x0093479E File Offset: 0x0093299E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x06020B37 RID: 133943 RVA: 0x009347B2 File Offset: 0x009329B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Pause()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__Pause_NativeFunctionPtr, null);
		}

		// Token: 0x06020B38 RID: 133944 RVA: 0x009347C6 File Offset: 0x009329C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Resume()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__Resume_NativeFunctionPtr, null);
		}

		// Token: 0x06020B39 RID: 133945 RVA: 0x009347DC File Offset: 0x009329DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SceneCapture_3To2_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020B3A RID: 133946 RVA: 0x00934824 File Offset: 0x00932A24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SceneCapture_3To2_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B3B RID: 133947 RVA: 0x0093486B File Offset: 0x00932A6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06020B3C RID: 133948 RVA: 0x0093487F File Offset: 0x00932A7F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B3D RID: 133949 RVA: 0x00934894 File Offset: 0x00932A94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06020B3E RID: 133950 RVA: 0x009348A8 File Offset: 0x00932AA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020B3F RID: 133951 RVA: 0x009348C0 File Offset: 0x00932AC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneCapture_3To2(int EntryPoint)
		{
			BP_SceneCapture_3To2_C.__ExecuteUbergraph_BP_SceneCapture_3To2_FunctionParams* ptr = stackalloc BP_SceneCapture_3To2_C.__ExecuteUbergraph_BP_SceneCapture_3To2_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_SceneCapture_3To2_C.__ExecuteUbergraph_BP_SceneCapture_3To2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneCapture_3To2_C.__ExecuteUbergraph_BP_SceneCapture_3To2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneCapture_3To2_C.__ExecuteUbergraph_BP_SceneCapture_3To2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020B40 RID: 133952 RVA: 0x00934907 File Offset: 0x00932B07
		protected BP_SceneCapture_3To2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010606 RID: 67078
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneCapture_3To2/BP_SceneCapture_3To2.BP_SceneCapture_3To2_C";

		// Token: 0x04010607 RID: 67079
		private static IntPtr _ClassPtr;

		// Token: 0x04010608 RID: 67080
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010609 RID: 67081
		internal static int __PropertyOffset_0;

		// Token: 0x0401060A RID: 67082
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401060B RID: 67083
		internal static int __PropertyOffset_1;

		// Token: 0x0401060C RID: 67084
		internal static int __PropertyOffset_2;

		// Token: 0x0401060D RID: 67085
		internal static int __PropertyOffset_3;

		// Token: 0x0401060E RID: 67086
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _HiddenActor;

		// Token: 0x0401060F RID: 67087
		internal static int __PropertyOffset_4;

		// Token: 0x04010610 RID: 67088
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ActorPosition;

		// Token: 0x04010611 RID: 67089
		internal static int __PropertyOffset_5;

		// Token: 0x04010612 RID: 67090
		internal static int __PropertyOffset_6;

		// Token: 0x04010613 RID: 67091
		internal static int __PropertyOffset_7;

		// Token: 0x04010614 RID: 67092
		internal static int __PropertyOffset_8;

		// Token: 0x04010615 RID: 67093
		internal static int __PropertyOffset_9;

		// Token: 0x04010616 RID: 67094
		private static IntPtr __GetAoiRange_NativeFunctionPtr;

		// Token: 0x04010617 RID: 67095
		private static IntPtr __ShouldStopOnHide_NativeFunctionPtr;

		// Token: 0x04010618 RID: 67096
		private static IntPtr __DisableToonDepth_NativeFunctionPtr;

		// Token: 0x04010619 RID: 67097
		private static IntPtr __EnableToonDepth_NativeFunctionPtr;

		// Token: 0x0401061A RID: 67098
		private static IntPtr __AllowOcclusionQueries_NativeFunctionPtr;

		// Token: 0x0401061B RID: 67099
		private static IntPtr __ClearRT_NativeFunctionPtr;

		// Token: 0x0401061C RID: 67100
		private static IntPtr __SetEnablePPV_NativeFunctionPtr;

		// Token: 0x0401061D RID: 67101
		private static IntPtr __CaptureScene_Running_NativeFunctionPtr;

		// Token: 0x0401061E RID: 67102
		private static IntPtr __TickOutside_NativeFunctionPtr;

		// Token: 0x0401061F RID: 67103
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x04010620 RID: 67104
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x04010621 RID: 67105
		private static IntPtr __Pause_NativeFunctionPtr;

		// Token: 0x04010622 RID: 67106
		private static IntPtr __Resume_NativeFunctionPtr;

		// Token: 0x04010623 RID: 67107
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010624 RID: 67108
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04010625 RID: 67109
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010626 RID: 67110
		private static IntPtr __ExecuteUbergraph_BP_SceneCapture_3To2_NativeFunctionPtr;

		// Token: 0x02009A16 RID: 39446
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetAoiRange_FunctionParams
		{
			// Token: 0x04032104 RID: 205060
			[FieldOffset(0)]
			public int ret;
		}

		// Token: 0x02009A17 RID: 39447
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ShouldStopOnHide_FunctionParams
		{
			// Token: 0x04032105 RID: 205061
			[FieldOffset(0)]
			public bool ret;
		}

		// Token: 0x02009A18 RID: 39448
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetEnablePPV_FunctionParams
		{
			// Token: 0x04032106 RID: 205062
			[FieldOffset(0)]
			public float Enable3To2Toggle;
		}

		// Token: 0x02009A19 RID: 39449
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032107 RID: 205063
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A1A RID: 39450
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ExecuteUbergraph_BP_SceneCapture_3To2_FunctionParams
		{
			// Token: 0x04032108 RID: 205064
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
