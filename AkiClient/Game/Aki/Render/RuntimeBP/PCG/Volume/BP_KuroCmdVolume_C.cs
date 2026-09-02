using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Volume
{
	// Token: 0x02003B5A RID: 15194
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Volume/BP_KuroCmdVolume.BP_KuroCmdVolume_C")]
	[UnrealStructLayout(1432, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1427)]
	public class BP_KuroCmdVolume_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060212B0 RID: 135856 RVA: 0x00941AB7 File Offset: 0x0093FCB7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCmdVolume_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Volume/BP_KuroCmdVolume.BP_KuroCmdVolume_C");
			}
			return BP_KuroCmdVolume_C._ClassPtr;
		}

		// Token: 0x060212B1 RID: 135857 RVA: 0x00941ADC File Offset: 0x0093FCDC
		public BP_KuroCmdVolume_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCmdVolume_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060212B2 RID: 135858 RVA: 0x00941B04 File Offset: 0x0093FD04
		public BP_KuroCmdVolume_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCmdVolume_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003987 RID: 14727
		// (get) Token: 0x060212B3 RID: 135859 RVA: 0x00941B38 File Offset: 0x0093FD38
		// (set) Token: 0x060212B4 RID: 135860 RVA: 0x00941B71 File Offset: 0x0093FD71
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003988 RID: 14728
		// (get) Token: 0x060212B5 RID: 135861 RVA: 0x00941B92 File Offset: 0x0093FD92
		// (set) Token: 0x060212B6 RID: 135862 RVA: 0x00941BA6 File Offset: 0x0093FDA6
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCmdVolume_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCmdVolume_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003989 RID: 14729
		// (get) Token: 0x060212B7 RID: 135863 RVA: 0x00941BBB File Offset: 0x0093FDBB
		// (set) Token: 0x060212B8 RID: 135864 RVA: 0x00941BCF File Offset: 0x0093FDCF
		public unsafe FVector WorldLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700398A RID: 14730
		// (get) Token: 0x060212B9 RID: 135865 RVA: 0x00941BE4 File Offset: 0x0093FDE4
		// (set) Token: 0x060212BA RID: 135866 RVA: 0x00941BF8 File Offset: 0x0093FDF8
		public unsafe FVector Box_Extent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700398B RID: 14731
		// (get) Token: 0x060212BB RID: 135867 RVA: 0x00941C10 File Offset: 0x0093FE10
		// (set) Token: 0x060212BC RID: 135868 RVA: 0x00941C49 File Offset: 0x0093FE49
		public TArray<string> InBoxCmd
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._InBoxCmd) == null)
				{
					result = (this._InBoxCmd = new TArray<string>(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.InBoxCmd.CopyAssign(value);
			}
		}

		// Token: 0x1700398C RID: 14732
		// (get) Token: 0x060212BD RID: 135869 RVA: 0x00941C58 File Offset: 0x0093FE58
		// (set) Token: 0x060212BE RID: 135870 RVA: 0x00941C91 File Offset: 0x0093FE91
		public TArray<string> OutBoxCmd
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._OutBoxCmd) == null)
				{
					result = (this._OutBoxCmd = new TArray<string>(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				this.OutBoxCmd.CopyAssign(value);
			}
		}

		// Token: 0x1700398D RID: 14733
		// (get) Token: 0x060212BF RID: 135871 RVA: 0x00941C9F File Offset: 0x0093FE9F
		// (set) Token: 0x060212C0 RID: 135872 RVA: 0x00941CAF File Offset: 0x0093FEAF
		public unsafe bool bPC
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700398E RID: 14734
		// (get) Token: 0x060212C1 RID: 135873 RVA: 0x00941CC0 File Offset: 0x0093FEC0
		// (set) Token: 0x060212C2 RID: 135874 RVA: 0x00941CF9 File Offset: 0x0093FEF9
		public TArray<string> InBoxCmdMobile
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._InBoxCmdMobile) == null)
				{
					result = (this._InBoxCmdMobile = new TArray<string>(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.InBoxCmdMobile.CopyAssign(value);
			}
		}

		// Token: 0x1700398F RID: 14735
		// (get) Token: 0x060212C3 RID: 135875 RVA: 0x00941D08 File Offset: 0x0093FF08
		// (set) Token: 0x060212C4 RID: 135876 RVA: 0x00941D41 File Offset: 0x0093FF41
		public TArray<string> OutBoxCmdMobile
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._OutBoxCmdMobile) == null)
				{
					result = (this._OutBoxCmdMobile = new TArray<string>(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				this.OutBoxCmdMobile.CopyAssign(value);
			}
		}

		// Token: 0x17003990 RID: 14736
		// (get) Token: 0x060212C5 RID: 135877 RVA: 0x00941D4F File Offset: 0x0093FF4F
		// (set) Token: 0x060212C6 RID: 135878 RVA: 0x00941D5F File Offset: 0x0093FF5F
		public unsafe bool bValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003991 RID: 14737
		// (get) Token: 0x060212C7 RID: 135879 RVA: 0x00941D70 File Offset: 0x0093FF70
		// (set) Token: 0x060212C8 RID: 135880 RVA: 0x00941D80 File Offset: 0x0093FF80
		public unsafe bool InitOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003992 RID: 14738
		// (get) Token: 0x060212C9 RID: 135881 RVA: 0x00941D91 File Offset: 0x0093FF91
		// (set) Token: 0x060212CA RID: 135882 RVA: 0x00941DA1 File Offset: 0x0093FFA1
		public unsafe bool bIgnoreCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCmdVolume_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x060212CB RID: 135883 RVA: 0x00941DB2 File Offset: 0x0093FFB2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisableCmd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__DisableCmd_NativeFunctionPtr, null);
		}

		// Token: 0x060212CC RID: 135884 RVA: 0x00941DC6 File Offset: 0x0093FFC6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EnableCmd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__EnableCmd_NativeFunctionPtr, null);
		}

		// Token: 0x060212CD RID: 135885 RVA: 0x00941DDC File Offset: 0x0093FFDC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual bool HasValidCmd()
		{
			BP_KuroCmdVolume_C.__HasValidCmd_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__HasValidCmd_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__HasValidCmd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__HasValidCmd_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__HasValidCmd_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060212CE RID: 135886 RVA: 0x00941E21 File Offset: 0x00940021
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060212CF RID: 135887 RVA: 0x00941E35 File Offset: 0x00940035
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060212D0 RID: 135888 RVA: 0x00941E4A File Offset: 0x0094004A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060212D1 RID: 135889 RVA: 0x00941E5E File Offset: 0x0094005E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060212D2 RID: 135890 RVA: 0x00941E74 File Offset: 0x00940074
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212D3 RID: 135891 RVA: 0x00941EBC File Offset: 0x009400BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212D4 RID: 135892 RVA: 0x00941F04 File Offset: 0x00940104
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_KuroCmdVolume_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212D5 RID: 135893 RVA: 0x00941F4C File Offset: 0x0094014C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_KuroCmdVolume_C.__EditorTick_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212D6 RID: 135894 RVA: 0x00941F94 File Offset: 0x00940194
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212D7 RID: 135895 RVA: 0x00941FE0 File Offset: 0x009401E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212D8 RID: 135896 RVA: 0x0094202C File Offset: 0x0094022C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex, bool bFromSweep, in FHitResult SweepResult)
		{
			BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			ptr->bFromSweep = bFromSweep;
			if (SweepResult != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), &ptr->SweepResult, SweepResult.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212D9 RID: 135897 RVA: 0x009420E8 File Offset: 0x009402E8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature(UPrimitiveComponent OverlappedComponent, AActor OtherActor, UPrimitiveComponent OtherComp, int OtherBodyIndex)
		{
			BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OverlappedComponent = ((OverlappedComponent != null) ? OverlappedComponent.NativePtr : IntPtr.Zero);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			ptr->OtherComp = ((OtherComp != null) ? OtherComp.NativePtr : IntPtr.Zero);
			ptr->OtherBodyIndex = OtherBodyIndex;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCmdVolume_C.__BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060212DA RID: 135898 RVA: 0x00942174 File Offset: 0x00940374
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCmdVolume(int EntryPoint)
		{
			BP_KuroCmdVolume_C.__ExecuteUbergraph_BP_KuroCmdVolume_FunctionParams* ptr = stackalloc BP_KuroCmdVolume_C.__ExecuteUbergraph_BP_KuroCmdVolume_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(BP_KuroCmdVolume_C.__ExecuteUbergraph_BP_KuroCmdVolume_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCmdVolume_C.__ExecuteUbergraph_BP_KuroCmdVolume_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCmdVolume_C.__ExecuteUbergraph_BP_KuroCmdVolume_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060212DB RID: 135899 RVA: 0x009421BE File Offset: 0x009403BE
		protected BP_KuroCmdVolume_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010AAB RID: 68267
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Volume/BP_KuroCmdVolume.BP_KuroCmdVolume_C";

		// Token: 0x04010AAC RID: 68268
		private static IntPtr _ClassPtr;

		// Token: 0x04010AAD RID: 68269
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010AAE RID: 68270
		internal static int __PropertyOffset_0;

		// Token: 0x04010AAF RID: 68271
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010AB0 RID: 68272
		internal static int __PropertyOffset_1;

		// Token: 0x04010AB1 RID: 68273
		internal static int __PropertyOffset_2;

		// Token: 0x04010AB2 RID: 68274
		internal static int __PropertyOffset_3;

		// Token: 0x04010AB3 RID: 68275
		internal static int __PropertyOffset_4;

		// Token: 0x04010AB4 RID: 68276
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _InBoxCmd;

		// Token: 0x04010AB5 RID: 68277
		internal static int __PropertyOffset_5;

		// Token: 0x04010AB6 RID: 68278
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _OutBoxCmd;

		// Token: 0x04010AB7 RID: 68279
		internal static int __PropertyOffset_6;

		// Token: 0x04010AB8 RID: 68280
		internal static int __PropertyOffset_7;

		// Token: 0x04010AB9 RID: 68281
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _InBoxCmdMobile;

		// Token: 0x04010ABA RID: 68282
		internal static int __PropertyOffset_8;

		// Token: 0x04010ABB RID: 68283
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _OutBoxCmdMobile;

		// Token: 0x04010ABC RID: 68284
		internal static int __PropertyOffset_9;

		// Token: 0x04010ABD RID: 68285
		internal static int __PropertyOffset_10;

		// Token: 0x04010ABE RID: 68286
		internal static int __PropertyOffset_11;

		// Token: 0x04010ABF RID: 68287
		private static IntPtr __DisableCmd_NativeFunctionPtr;

		// Token: 0x04010AC0 RID: 68288
		private static IntPtr __EnableCmd_NativeFunctionPtr;

		// Token: 0x04010AC1 RID: 68289
		private static IntPtr __HasValidCmd_NativeFunctionPtr;

		// Token: 0x04010AC2 RID: 68290
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010AC3 RID: 68291
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010AC4 RID: 68292
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010AC5 RID: 68293
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010AC6 RID: 68294
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04010AC7 RID: 68295
		private static IntPtr __BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010AC8 RID: 68296
		private static IntPtr __BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04010AC9 RID: 68297
		private static IntPtr __ExecuteUbergraph_BP_KuroCmdVolume_NativeFunctionPtr;

		// Token: 0x02009A89 RID: 39561
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __HasValidCmd_FunctionParams
		{
			// Token: 0x040321E5 RID: 205285
			[FieldOffset(0)]
			public bool __Result;
		}

		// Token: 0x02009A8A RID: 39562
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040321E6 RID: 205286
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A8B RID: 39563
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040321E7 RID: 205287
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A8C RID: 39564
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040321E8 RID: 205288
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009A8D RID: 39565
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_0_ComponentBeginOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321E9 RID: 205289
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321EA RID: 205290
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321EB RID: 205291
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321EC RID: 205292
			[FieldOffset(24)]
			public int OtherBodyIndex;

			// Token: 0x040321ED RID: 205293
			[FieldOffset(28)]
			public bool bFromSweep;

			// Token: 0x040321EE RID: 205294
			[FieldOffset(32)]
			public byte SweepResult;
		}

		// Token: 0x02009A8E RID: 39566
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __BndEvt__BP_KuroCmdVolume_Box_K2Node_ComponentBoundEvent_1_ComponentEndOverlapSignature__DelegateSignature_FunctionParams
		{
			// Token: 0x040321EF RID: 205295
			[FieldOffset(0)]
			public IntPtr OverlappedComponent;

			// Token: 0x040321F0 RID: 205296
			[FieldOffset(8)]
			public IntPtr OtherActor;

			// Token: 0x040321F1 RID: 205297
			[FieldOffset(16)]
			public IntPtr OtherComp;

			// Token: 0x040321F2 RID: 205298
			[FieldOffset(24)]
			public int OtherBodyIndex;
		}

		// Token: 0x02009A8F RID: 39567
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __ExecuteUbergraph_BP_KuroCmdVolume_FunctionParams
		{
			// Token: 0x040321F3 RID: 205299
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
