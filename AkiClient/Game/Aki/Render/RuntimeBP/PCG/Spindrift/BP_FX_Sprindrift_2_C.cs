using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Spindrift
{
	// Token: 0x02003B65 RID: 15205
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrift_2.BP_FX_Sprindrift_2_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_FX_Sprindrift_2_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject, IBPI_EffectInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602168C RID: 136844 RVA: 0x00948557 File Offset: 0x00946757
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FX_Sprindrift_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrift_2.BP_FX_Sprindrift_2_C");
			}
			return BP_FX_Sprindrift_2_C._ClassPtr;
		}

		// Token: 0x0602168D RID: 136845 RVA: 0x0094857C File Offset: 0x0094677C
		public BP_FX_Sprindrift_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_FX_Sprindrift_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602168E RID: 136846 RVA: 0x009485A4 File Offset: 0x009467A4
		[NullableContext(1)]
		public BP_FX_Sprindrift_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FX_Sprindrift_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003B03 RID: 15107
		// (get) Token: 0x0602168F RID: 136847 RVA: 0x009485D8 File Offset: 0x009467D8
		// (set) Token: 0x06021690 RID: 136848 RVA: 0x00948611 File Offset: 0x00946811
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003B04 RID: 15108
		// (get) Token: 0x06021691 RID: 136849 RVA: 0x00948632 File Offset: 0x00946832
		// (set) Token: 0x06021692 RID: 136850 RVA: 0x00948646 File Offset: 0x00946846
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003B05 RID: 15109
		// (get) Token: 0x06021693 RID: 136851 RVA: 0x0094865B File Offset: 0x0094685B
		// (set) Token: 0x06021694 RID: 136852 RVA: 0x0094866F File Offset: 0x0094686F
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003B06 RID: 15110
		// (get) Token: 0x06021695 RID: 136853 RVA: 0x00948684 File Offset: 0x00946884
		// (set) Token: 0x06021696 RID: 136854 RVA: 0x00948698 File Offset: 0x00946898
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003B07 RID: 15111
		// (get) Token: 0x06021697 RID: 136855 RVA: 0x009486AD File Offset: 0x009468AD
		// (set) Token: 0x06021698 RID: 136856 RVA: 0x009486C1 File Offset: 0x009468C1
		public unsafe UNiagaraSystem 粒子特效
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003B08 RID: 15112
		// (get) Token: 0x06021699 RID: 136857 RVA: 0x009486D6 File Offset: 0x009468D6
		// (set) Token: 0x0602169A RID: 136858 RVA: 0x009486E6 File Offset: 0x009468E6
		public unsafe int 全局时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003B09 RID: 15113
		// (get) Token: 0x0602169B RID: 136859 RVA: 0x009486F7 File Offset: 0x009468F7
		// (set) Token: 0x0602169C RID: 136860 RVA: 0x00948707 File Offset: 0x00946907
		public unsafe int 浪花数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003B0A RID: 15114
		// (get) Token: 0x0602169D RID: 136861 RVA: 0x00948718 File Offset: 0x00946918
		// (set) Token: 0x0602169E RID: 136862 RVA: 0x00948728 File Offset: 0x00946928
		public unsafe float 浪花范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003B0B RID: 15115
		// (get) Token: 0x0602169F RID: 136863 RVA: 0x00948739 File Offset: 0x00946939
		// (set) Token: 0x060216A0 RID: 136864 RVA: 0x0094874D File Offset: 0x0094694D
		public unsafe FLinearColor 浪花颜色_白天_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003B0C RID: 15116
		// (get) Token: 0x060216A1 RID: 136865 RVA: 0x00948762 File Offset: 0x00946962
		// (set) Token: 0x060216A2 RID: 136866 RVA: 0x00948776 File Offset: 0x00946976
		public unsafe FLinearColor 浪花颜色_夜晚_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003B0D RID: 15117
		// (get) Token: 0x060216A3 RID: 136867 RVA: 0x0094878B File Offset: 0x0094698B
		// (set) Token: 0x060216A4 RID: 136868 RVA: 0x0094879B File Offset: 0x0094699B
		public unsafe float 浪花周期
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003B0E RID: 15118
		// (get) Token: 0x060216A5 RID: 136869 RVA: 0x009487AC File Offset: 0x009469AC
		// (set) Token: 0x060216A6 RID: 136870 RVA: 0x009487C0 File Offset: 0x009469C0
		public unsafe FVector2D 周期偏移_白天_夜晚_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003B0F RID: 15119
		// (get) Token: 0x060216A7 RID: 136871 RVA: 0x009487D5 File Offset: 0x009469D5
		// (set) Token: 0x060216A8 RID: 136872 RVA: 0x009487E5 File Offset: 0x009469E5
		public unsafe bool Activate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B10 RID: 15120
		// (get) Token: 0x060216A9 RID: 136873 RVA: 0x009487F6 File Offset: 0x009469F6
		// (set) Token: 0x060216AA RID: 136874 RVA: 0x00948806 File Offset: 0x00946A06
		public unsafe bool IsDayTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003B11 RID: 15121
		// (get) Token: 0x060216AB RID: 136875 RVA: 0x00948817 File Offset: 0x00946A17
		// (set) Token: 0x060216AC RID: 136876 RVA: 0x0094882B File Offset: 0x00946A2B
		public unsafe UStaticMeshComponent CaptureMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17003B12 RID: 15122
		// (get) Token: 0x060216AD RID: 136877 RVA: 0x00948840 File Offset: 0x00946A40
		// (set) Token: 0x060216AE RID: 136878 RVA: 0x00948854 File Offset: 0x00946A54
		public unsafe UTextureRenderTarget2D RTCaptureWaveLine
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x17003B13 RID: 15123
		// (get) Token: 0x060216AF RID: 136879 RVA: 0x00948869 File Offset: 0x00946A69
		// (set) Token: 0x060216B0 RID: 136880 RVA: 0x00948879 File Offset: 0x00946A79
		public unsafe float ActivateTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FX_Sprindrift_2_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003B14 RID: 15124
		// (get) Token: 0x060216B1 RID: 136881 RVA: 0x0094888A File Offset: 0x00946A8A
		// (set) Token: 0x060216B2 RID: 136882 RVA: 0x0094889E File Offset: 0x00946A9E
		public unsafe USceneCaptureComponent2D SceneCaptureComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneCaptureComponent2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_17);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FX_Sprindrift_2_C.__PropertyOffset_17, value);
			}
		}

		// Token: 0x060216B3 RID: 136883 RVA: 0x009488B4 File Offset: 0x00946AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetHandle(ref int Handle)
		{
			BP_FX_Sprindrift_2_C.__GetHandle_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__GetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__GetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__GetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__GetHandle_NativeFunctionPtr, (void*)ptr);
			Handle = ptr->Handle;
		}

		// Token: 0x060216B4 RID: 136884 RVA: 0x00948903 File Offset: 0x00946B03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CaptureWaveLine()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__CaptureWaveLine_NativeFunctionPtr, null);
		}

		// Token: 0x060216B5 RID: 136885 RVA: 0x00948918 File Offset: 0x00946B18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DayAndNight(bool IsDayTime)
		{
			BP_FX_Sprindrift_2_C.__DayAndNight_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__DayAndNight_FunctionParams[(UIntPtr)247] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__DayAndNight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__DayAndNight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsDayTime = IsDayTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__DayAndNight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216B6 RID: 136886 RVA: 0x00948961 File Offset: 0x00946B61
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060216B7 RID: 136887 RVA: 0x00948975 File Offset: 0x00946B75
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060216B8 RID: 136888 RVA: 0x0094898C File Offset: 0x00946B8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetHandle(int Handle)
		{
			BP_FX_Sprindrift_2_C.__SetHandle_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__SetHandle_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__SetHandle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__SetHandle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Handle = Handle;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__SetHandle_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216B9 RID: 136889 RVA: 0x009489D2 File Offset: 0x00946BD2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveHandle()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__RemoveHandle_NativeFunctionPtr, null);
		}

		// Token: 0x060216BA RID: 136890 RVA: 0x009489E6 File Offset: 0x00946BE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060216BB RID: 136891 RVA: 0x009489FA File Offset: 0x00946BFA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060216BC RID: 136892 RVA: 0x00948A10 File Offset: 0x00946C10
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216BD RID: 136893 RVA: 0x00948A58 File Offset: 0x00946C58
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216BE RID: 136894 RVA: 0x00948AA0 File Offset: 0x00946CA0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060216BF RID: 136895 RVA: 0x00948AE8 File Offset: 0x00946CE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216C0 RID: 136896 RVA: 0x00948B30 File Offset: 0x00946D30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FX_Sprindrift_2(int EntryPoint)
		{
			BP_FX_Sprindrift_2_C.__ExecuteUbergraph_BP_FX_Sprindrift_2_FunctionParams* ptr = stackalloc BP_FX_Sprindrift_2_C.__ExecuteUbergraph_BP_FX_Sprindrift_2_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_FX_Sprindrift_2_C.__ExecuteUbergraph_BP_FX_Sprindrift_2_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FX_Sprindrift_2_C.__ExecuteUbergraph_BP_FX_Sprindrift_2_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FX_Sprindrift_2_C.__ExecuteUbergraph_BP_FX_Sprindrift_2_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060216C1 RID: 136897 RVA: 0x00948B77 File Offset: 0x00946D77
		protected BP_FX_Sprindrift_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010D12 RID: 68882
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Spindrift/BP_FX_Sprindrift_2.BP_FX_Sprindrift_2_C";

		// Token: 0x04010D13 RID: 68883
		private static IntPtr _ClassPtr;

		// Token: 0x04010D14 RID: 68884
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010D15 RID: 68885
		internal static int __PropertyOffset_0;

		// Token: 0x04010D16 RID: 68886
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010D17 RID: 68887
		internal static int __PropertyOffset_1;

		// Token: 0x04010D18 RID: 68888
		internal static int __PropertyOffset_2;

		// Token: 0x04010D19 RID: 68889
		internal static int __PropertyOffset_3;

		// Token: 0x04010D1A RID: 68890
		internal static int __PropertyOffset_4;

		// Token: 0x04010D1B RID: 68891
		internal static int __PropertyOffset_5;

		// Token: 0x04010D1C RID: 68892
		internal static int __PropertyOffset_6;

		// Token: 0x04010D1D RID: 68893
		internal static int __PropertyOffset_7;

		// Token: 0x04010D1E RID: 68894
		internal static int __PropertyOffset_8;

		// Token: 0x04010D1F RID: 68895
		internal static int __PropertyOffset_9;

		// Token: 0x04010D20 RID: 68896
		internal static int __PropertyOffset_10;

		// Token: 0x04010D21 RID: 68897
		internal static int __PropertyOffset_11;

		// Token: 0x04010D22 RID: 68898
		internal static int __PropertyOffset_12;

		// Token: 0x04010D23 RID: 68899
		internal static int __PropertyOffset_13;

		// Token: 0x04010D24 RID: 68900
		internal static int __PropertyOffset_14;

		// Token: 0x04010D25 RID: 68901
		internal static int __PropertyOffset_15;

		// Token: 0x04010D26 RID: 68902
		internal static int __PropertyOffset_16;

		// Token: 0x04010D27 RID: 68903
		internal static int __PropertyOffset_17;

		// Token: 0x04010D28 RID: 68904
		private static IntPtr __GetHandle_NativeFunctionPtr;

		// Token: 0x04010D29 RID: 68905
		private static IntPtr __CaptureWaveLine_NativeFunctionPtr;

		// Token: 0x04010D2A RID: 68906
		private static IntPtr __DayAndNight_NativeFunctionPtr;

		// Token: 0x04010D2B RID: 68907
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010D2C RID: 68908
		private static IntPtr __SetHandle_NativeFunctionPtr;

		// Token: 0x04010D2D RID: 68909
		private static IntPtr __RemoveHandle_NativeFunctionPtr;

		// Token: 0x04010D2E RID: 68910
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010D2F RID: 68911
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010D30 RID: 68912
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010D31 RID: 68913
		private static IntPtr __ExecuteUbergraph_BP_FX_Sprindrift_2_NativeFunctionPtr;

		// Token: 0x02009ACE RID: 39630
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetHandle_FunctionParams
		{
			// Token: 0x04032252 RID: 205394
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009ACF RID: 39631
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 232)]
		protected ref struct __DayAndNight_FunctionParams
		{
			// Token: 0x04032253 RID: 205395
			[FieldOffset(0)]
			public bool IsDayTime;
		}

		// Token: 0x02009AD0 RID: 39632
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetHandle_FunctionParams
		{
			// Token: 0x04032254 RID: 205396
			[FieldOffset(0)]
			public int Handle;
		}

		// Token: 0x02009AD1 RID: 39633
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032255 RID: 205397
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AD2 RID: 39634
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032256 RID: 205398
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AD3 RID: 39635
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_BP_FX_Sprindrift_2_FunctionParams
		{
			// Token: 0x04032257 RID: 205399
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
