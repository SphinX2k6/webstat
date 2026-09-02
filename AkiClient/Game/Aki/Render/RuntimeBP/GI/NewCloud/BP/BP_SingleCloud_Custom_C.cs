using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CC8 RID: 15560
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud_Custom.BP_SingleCloud_Custom_C")]
	[UnrealStructLayout(1720, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1720)]
	public class BP_SingleCloud_Custom_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025056 RID: 151638 RVA: 0x009AEB7B File Offset: 0x009ACD7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SingleCloud_Custom_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud_Custom.BP_SingleCloud_Custom_C");
			}
			return BP_SingleCloud_Custom_C._ClassPtr;
		}

		// Token: 0x06025057 RID: 151639 RVA: 0x009AEBA0 File Offset: 0x009ACDA0
		public BP_SingleCloud_Custom_C() : this(BuiltinUtils.AllocNativeUObject(BP_SingleCloud_Custom_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025058 RID: 151640 RVA: 0x009AEBC8 File Offset: 0x009ACDC8
		[NullableContext(1)]
		public BP_SingleCloud_Custom_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SingleCloud_Custom_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004F1B RID: 20251
		// (get) Token: 0x06025059 RID: 151641 RVA: 0x009AEBFC File Offset: 0x009ACDFC
		// (set) Token: 0x0602505A RID: 151642 RVA: 0x009AEC35 File Offset: 0x009ACE35
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004F1C RID: 20252
		// (get) Token: 0x0602505B RID: 151643 RVA: 0x009AEC56 File Offset: 0x009ACE56
		// (set) Token: 0x0602505C RID: 151644 RVA: 0x009AEC6A File Offset: 0x009ACE6A
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004F1D RID: 20253
		// (get) Token: 0x0602505D RID: 151645 RVA: 0x009AEC7F File Offset: 0x009ACE7F
		// (set) Token: 0x0602505E RID: 151646 RVA: 0x009AEC93 File Offset: 0x009ACE93
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004F1E RID: 20254
		// (get) Token: 0x0602505F RID: 151647 RVA: 0x009AECA8 File Offset: 0x009ACEA8
		// (set) Token: 0x06025060 RID: 151648 RVA: 0x009AECB8 File Offset: 0x009ACEB8
		public unsafe bool bTowardCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F1F RID: 20255
		// (get) Token: 0x06025061 RID: 151649 RVA: 0x009AECC9 File Offset: 0x009ACEC9
		// (set) Token: 0x06025062 RID: 151650 RVA: 0x009AECD9 File Offset: 0x009ACED9
		public unsafe float MinDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004F20 RID: 20256
		// (get) Token: 0x06025063 RID: 151651 RVA: 0x009AECEA File Offset: 0x009ACEEA
		// (set) Token: 0x06025064 RID: 151652 RVA: 0x009AECFA File Offset: 0x009ACEFA
		public unsafe float MaxDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17004F21 RID: 20257
		// (get) Token: 0x06025065 RID: 151653 RVA: 0x009AED0B File Offset: 0x009ACF0B
		// (set) Token: 0x06025066 RID: 151654 RVA: 0x009AED1F File Offset: 0x009ACF1F
		public unsafe UStaticMesh CustomMesh_Y_Aix
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17004F22 RID: 20258
		// (get) Token: 0x06025067 RID: 151655 RVA: 0x009AED34 File Offset: 0x009ACF34
		// (set) Token: 0x06025068 RID: 151656 RVA: 0x009AED44 File Offset: 0x009ACF44
		public unsafe float Opacity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17004F23 RID: 20259
		// (get) Token: 0x06025069 RID: 151657 RVA: 0x009AED55 File Offset: 0x009ACF55
		// (set) Token: 0x0602506A RID: 151658 RVA: 0x009AED65 File Offset: 0x009ACF65
		public unsafe bool bInverseFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F24 RID: 20260
		// (get) Token: 0x0602506B RID: 151659 RVA: 0x009AED76 File Offset: 0x009ACF76
		// (set) Token: 0x0602506C RID: 151660 RVA: 0x009AED86 File Offset: 0x009ACF86
		public unsafe bool bEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F25 RID: 20261
		// (get) Token: 0x0602506D RID: 151661 RVA: 0x009AED97 File Offset: 0x009ACF97
		// (set) Token: 0x0602506E RID: 151662 RVA: 0x009AEDA7 File Offset: 0x009ACFA7
		public unsafe bool bTowardCameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004F26 RID: 20262
		// (get) Token: 0x0602506F RID: 151663 RVA: 0x009AEDB8 File Offset: 0x009ACFB8
		// (set) Token: 0x06025070 RID: 151664 RVA: 0x009AEDCC File Offset: 0x009ACFCC
		public unsafe FVector boundCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17004F27 RID: 20263
		// (get) Token: 0x06025071 RID: 151665 RVA: 0x009AEDE1 File Offset: 0x009ACFE1
		// (set) Token: 0x06025072 RID: 151666 RVA: 0x009AEDF5 File Offset: 0x009ACFF5
		public unsafe FVectorDouble CameraPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17004F28 RID: 20264
		// (get) Token: 0x06025073 RID: 151667 RVA: 0x009AEE0A File Offset: 0x009AD00A
		// (set) Token: 0x06025074 RID: 151668 RVA: 0x009AEE1E File Offset: 0x009AD01E
		public unsafe FRotator CameraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17004F29 RID: 20265
		// (get) Token: 0x06025075 RID: 151669 RVA: 0x009AEE33 File Offset: 0x009AD033
		// (set) Token: 0x06025076 RID: 151670 RVA: 0x009AEE43 File Offset: 0x009AD043
		public unsafe double DistanceFade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17004F2A RID: 20266
		// (get) Token: 0x06025077 RID: 151671 RVA: 0x009AEE54 File Offset: 0x009AD054
		// (set) Token: 0x06025078 RID: 151672 RVA: 0x009AEE68 File Offset: 0x009AD068
		public unsafe FRotator CloudRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17004F2B RID: 20267
		// (get) Token: 0x06025079 RID: 151673 RVA: 0x009AEE7D File Offset: 0x009AD07D
		// (set) Token: 0x0602507A RID: 151674 RVA: 0x009AEE91 File Offset: 0x009AD091
		public unsafe FVectorDouble ToBoundDir
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17004F2C RID: 20268
		// (get) Token: 0x0602507B RID: 151675 RVA: 0x009AEEA6 File Offset: 0x009AD0A6
		// (set) Token: 0x0602507C RID: 151676 RVA: 0x009AEEBA File Offset: 0x009AD0BA
		public unsafe UMaterialInstanceConstant CloudMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceConstant>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SingleCloud_Custom_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x17004F2D RID: 20269
		// (get) Token: 0x0602507D RID: 151677 RVA: 0x009AEED0 File Offset: 0x009AD0D0
		// (set) Token: 0x0602507E RID: 151678 RVA: 0x009AEF09 File Offset: 0x009AD109
		[Nullable(1)]
		public TMap<FName, float> Scalar_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, float> result;
				if ((result = this._Scalar_Parameters) == null)
				{
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_18, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004F2E RID: 20270
		// (get) Token: 0x0602507F RID: 151679 RVA: 0x009AEF18 File Offset: 0x009AD118
		// (set) Token: 0x06025080 RID: 151680 RVA: 0x009AEF51 File Offset: 0x009AD151
		[Nullable(1)]
		public TMap<FName, FLinearColor> Vector_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, FLinearColor> result;
				if ((result = this._Vector_Parameters) == null)
				{
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_19, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17004F2F RID: 20271
		// (get) Token: 0x06025081 RID: 151681 RVA: 0x009AEF60 File Offset: 0x009AD160
		// (set) Token: 0x06025082 RID: 151682 RVA: 0x009AEF99 File Offset: 0x009AD199
		[Nullable(1)]
		public TMap<FName, UTexture> Texture_Parameters
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<FName, UTexture> result;
				if ((result = this._Texture_Parameters) == null)
				{
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_SingleCloud_Custom_C.__PropertyOffset_20, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x06025083 RID: 151683 RVA: 0x009AEFA7 File Offset: 0x009AD1A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Init()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__Init_NativeFunctionPtr, null);
		}

		// Token: 0x06025084 RID: 151684 RVA: 0x009AEFBB File Offset: 0x009AD1BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Clear()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__Clear_NativeFunctionPtr, null);
		}

		// Token: 0x06025085 RID: 151685 RVA: 0x009AEFCF File Offset: 0x009AD1CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCloudRotation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UpdateCloudRotation_NativeFunctionPtr, null);
		}

		// Token: 0x06025086 RID: 151686 RVA: 0x009AEFE3 File Offset: 0x009AD1E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateDistanceFade()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UpdateDistanceFade_NativeFunctionPtr, null);
		}

		// Token: 0x06025087 RID: 151687 RVA: 0x009AEFF7 File Offset: 0x009AD1F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateCameraPosition()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UpdateCameraPosition_NativeFunctionPtr, null);
		}

		// Token: 0x06025088 RID: 151688 RVA: 0x009AF00C File Offset: 0x009AD20C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateMaterialParams(UMaterialInstanceDynamic MID)
		{
			BP_SingleCloud_Custom_C.__UpdateMaterialParams_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__UpdateMaterialParams_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__UpdateMaterialParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__UpdateMaterialParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MID = ((MID != null) ? MID.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UpdateMaterialParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025089 RID: 151689 RVA: 0x009AF064 File Offset: 0x009AD264
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602508A RID: 151690 RVA: 0x009AF078 File Offset: 0x009AD278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602508B RID: 151691 RVA: 0x009AF090 File Offset: 0x009AD290
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SingleCloud_Custom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602508C RID: 151692 RVA: 0x009AF0D8 File Offset: 0x009AD2D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SingleCloud_Custom_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602508D RID: 151693 RVA: 0x009AF11F File Offset: 0x009AD31F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602508E RID: 151694 RVA: 0x009AF133 File Offset: 0x009AD333
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602508F RID: 151695 RVA: 0x009AF148 File Offset: 0x009AD348
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025090 RID: 151696 RVA: 0x009AF190 File Offset: 0x009AD390
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025091 RID: 151697 RVA: 0x009AF1D8 File Offset: 0x009AD3D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SingleCloud_Custom(int EntryPoint)
		{
			BP_SingleCloud_Custom_C.__ExecuteUbergraph_BP_SingleCloud_Custom_FunctionParams* ptr = stackalloc BP_SingleCloud_Custom_C.__ExecuteUbergraph_BP_SingleCloud_Custom_FunctionParams[(UIntPtr)415] + 15L / (long)sizeof(BP_SingleCloud_Custom_C.__ExecuteUbergraph_BP_SingleCloud_Custom_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SingleCloud_Custom_C.__ExecuteUbergraph_BP_SingleCloud_Custom_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SingleCloud_Custom_C.__ExecuteUbergraph_BP_SingleCloud_Custom_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025092 RID: 151698 RVA: 0x009AF222 File Offset: 0x009AD422
		protected BP_SingleCloud_Custom_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401306E RID: 77934
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/BP_SingleCloud_Custom.BP_SingleCloud_Custom_C";

		// Token: 0x0401306F RID: 77935
		private static IntPtr _ClassPtr;

		// Token: 0x04013070 RID: 77936
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013071 RID: 77937
		internal static int __PropertyOffset_0;

		// Token: 0x04013072 RID: 77938
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013073 RID: 77939
		internal static int __PropertyOffset_1;

		// Token: 0x04013074 RID: 77940
		internal static int __PropertyOffset_2;

		// Token: 0x04013075 RID: 77941
		internal static int __PropertyOffset_3;

		// Token: 0x04013076 RID: 77942
		internal static int __PropertyOffset_4;

		// Token: 0x04013077 RID: 77943
		internal static int __PropertyOffset_5;

		// Token: 0x04013078 RID: 77944
		internal static int __PropertyOffset_6;

		// Token: 0x04013079 RID: 77945
		internal static int __PropertyOffset_7;

		// Token: 0x0401307A RID: 77946
		internal static int __PropertyOffset_8;

		// Token: 0x0401307B RID: 77947
		internal static int __PropertyOffset_9;

		// Token: 0x0401307C RID: 77948
		internal static int __PropertyOffset_10;

		// Token: 0x0401307D RID: 77949
		internal static int __PropertyOffset_11;

		// Token: 0x0401307E RID: 77950
		internal static int __PropertyOffset_12;

		// Token: 0x0401307F RID: 77951
		internal static int __PropertyOffset_13;

		// Token: 0x04013080 RID: 77952
		internal static int __PropertyOffset_14;

		// Token: 0x04013081 RID: 77953
		internal static int __PropertyOffset_15;

		// Token: 0x04013082 RID: 77954
		internal static int __PropertyOffset_16;

		// Token: 0x04013083 RID: 77955
		internal static int __PropertyOffset_17;

		// Token: 0x04013084 RID: 77956
		internal static int __PropertyOffset_18;

		// Token: 0x04013085 RID: 77957
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x04013086 RID: 77958
		internal static int __PropertyOffset_19;

		// Token: 0x04013087 RID: 77959
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x04013088 RID: 77960
		internal static int __PropertyOffset_20;

		// Token: 0x04013089 RID: 77961
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0401308A RID: 77962
		private static IntPtr __Init_NativeFunctionPtr;

		// Token: 0x0401308B RID: 77963
		private static IntPtr __Clear_NativeFunctionPtr;

		// Token: 0x0401308C RID: 77964
		private static IntPtr __UpdateCloudRotation_NativeFunctionPtr;

		// Token: 0x0401308D RID: 77965
		private static IntPtr __UpdateDistanceFade_NativeFunctionPtr;

		// Token: 0x0401308E RID: 77966
		private static IntPtr __UpdateCameraPosition_NativeFunctionPtr;

		// Token: 0x0401308F RID: 77967
		private static IntPtr __UpdateMaterialParams_NativeFunctionPtr;

		// Token: 0x04013090 RID: 77968
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013091 RID: 77969
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04013092 RID: 77970
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013093 RID: 77971
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013094 RID: 77972
		private static IntPtr __ExecuteUbergraph_BP_SingleCloud_Custom_NativeFunctionPtr;

		// Token: 0x02009EB9 RID: 40633
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __UpdateMaterialParams_FunctionParams
		{
			// Token: 0x0403297D RID: 207229
			[FieldOffset(0)]
			public IntPtr MID;
		}

		// Token: 0x02009EBA RID: 40634
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403297E RID: 207230
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EBB RID: 40635
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403297F RID: 207231
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EBC RID: 40636
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 400)]
		protected ref struct __ExecuteUbergraph_BP_SingleCloud_Custom_FunctionParams
		{
			// Token: 0x04032980 RID: 207232
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
