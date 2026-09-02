using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm
{
	// Token: 0x02003C59 RID: 15449
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm.BP_MagneticStorm_C")]
	[UnrealStructLayout(1368, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1365)]
	public class BP_MagneticStorm_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023B51 RID: 146257 RVA: 0x00989BA0 File Offset: 0x00987DA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MagneticStorm_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm.BP_MagneticStorm_C");
			}
			return BP_MagneticStorm_C._ClassPtr;
		}

		// Token: 0x06023B52 RID: 146258 RVA: 0x00989BC4 File Offset: 0x00987DC4
		public BP_MagneticStorm_C() : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023B53 RID: 146259 RVA: 0x00989BEC File Offset: 0x00987DEC
		[NullableContext(1)]
		public BP_MagneticStorm_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MagneticStorm_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170047EE RID: 18414
		// (get) Token: 0x06023B54 RID: 146260 RVA: 0x00989C20 File Offset: 0x00987E20
		// (set) Token: 0x06023B55 RID: 146261 RVA: 0x00989C59 File Offset: 0x00987E59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170047EF RID: 18415
		// (get) Token: 0x06023B56 RID: 146262 RVA: 0x00989C7A File Offset: 0x00987E7A
		// (set) Token: 0x06023B57 RID: 146263 RVA: 0x00989C8E File Offset: 0x00987E8E
		public unsafe UNiagaraComponent NS_Fx_SC3_MagneticStorm_Mobile_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170047F0 RID: 18416
		// (get) Token: 0x06023B58 RID: 146264 RVA: 0x00989CA3 File Offset: 0x00987EA3
		// (set) Token: 0x06023B59 RID: 146265 RVA: 0x00989CB7 File Offset: 0x00987EB7
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170047F1 RID: 18417
		// (get) Token: 0x06023B5A RID: 146266 RVA: 0x00989CCC File Offset: 0x00987ECC
		// (set) Token: 0x06023B5B RID: 146267 RVA: 0x00989CE0 File Offset: 0x00987EE0
		public unsafe UNiagaraComponent NS_Fx_MagneticStorm
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170047F2 RID: 18418
		// (get) Token: 0x06023B5C RID: 146268 RVA: 0x00989CF5 File Offset: 0x00987EF5
		// (set) Token: 0x06023B5D RID: 146269 RVA: 0x00989D09 File Offset: 0x00987F09
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MagneticStorm_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170047F3 RID: 18419
		// (get) Token: 0x06023B5E RID: 146270 RVA: 0x00989D1E File Offset: 0x00987F1E
		// (set) Token: 0x06023B5F RID: 146271 RVA: 0x00989D32 File Offset: 0x00987F32
		public unsafe FVector WroldOriginLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170047F4 RID: 18420
		// (get) Token: 0x06023B60 RID: 146272 RVA: 0x00989D47 File Offset: 0x00987F47
		// (set) Token: 0x06023B61 RID: 146273 RVA: 0x00989D57 File Offset: 0x00987F57
		public unsafe bool DisplayShockwave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047F5 RID: 18421
		// (get) Token: 0x06023B62 RID: 146274 RVA: 0x00989D68 File Offset: 0x00987F68
		// (set) Token: 0x06023B63 RID: 146275 RVA: 0x00989D78 File Offset: 0x00987F78
		public unsafe bool DisplayParticle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047F6 RID: 18422
		// (get) Token: 0x06023B64 RID: 146276 RVA: 0x00989D89 File Offset: 0x00987F89
		// (set) Token: 0x06023B65 RID: 146277 RVA: 0x00989D99 File Offset: 0x00987F99
		public unsafe bool DisplayGrid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x170047F7 RID: 18423
		// (get) Token: 0x06023B66 RID: 146278 RVA: 0x00989DAA File Offset: 0x00987FAA
		// (set) Token: 0x06023B67 RID: 146279 RVA: 0x00989DBA File Offset: 0x00987FBA
		public unsafe float AttenuationDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170047F8 RID: 18424
		// (get) Token: 0x06023B68 RID: 146280 RVA: 0x00989DCB File Offset: 0x00987FCB
		// (set) Token: 0x06023B69 RID: 146281 RVA: 0x00989DDB File Offset: 0x00987FDB
		public unsafe bool bInTheBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MagneticStorm_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06023B6A RID: 146282 RVA: 0x00989DEC File Offset: 0x00987FEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateNS()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__UpdateNS_NativeFunctionPtr, null);
		}

		// Token: 0x06023B6B RID: 146283 RVA: 0x00989E00 File Offset: 0x00988000
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RemoveParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__RemoveParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B6C RID: 146284 RVA: 0x00989E14 File Offset: 0x00988014
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CloseAllShockwave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__CloseAllShockwave_NativeFunctionPtr, null);
		}

		// Token: 0x06023B6D RID: 146285 RVA: 0x00989E28 File Offset: 0x00988028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InTheBox(FVector pos, ref bool IntheBox)
		{
			BP_MagneticStorm_C.__InTheBox_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__InTheBox_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_MagneticStorm_C.__InTheBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__InTheBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->pos = pos;
			ptr->IntheBox = IntheBox;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__InTheBox_NativeFunctionPtr, (void*)ptr);
			IntheBox = ptr->IntheBox;
		}

		// Token: 0x06023B6E RID: 146286 RVA: 0x00989E7E File Offset: 0x0098807E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OpenShockwave()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__OpenShockwave_NativeFunctionPtr, null);
		}

		// Token: 0x06023B6F RID: 146287 RVA: 0x00989E92 File Offset: 0x00988092
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B70 RID: 146288 RVA: 0x00989EA6 File Offset: 0x009880A6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__SetParam_NativeFunctionPtr, null);
		}

		// Token: 0x06023B71 RID: 146289 RVA: 0x00989EBA File Offset: 0x009880BA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06023B72 RID: 146290 RVA: 0x00989ECE File Offset: 0x009880CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B73 RID: 146291 RVA: 0x00989EE3 File Offset: 0x009880E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06023B74 RID: 146292 RVA: 0x00989EF7 File Offset: 0x009880F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B75 RID: 146293 RVA: 0x00989F0C File Offset: 0x0098810C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MagneticStorm_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B76 RID: 146294 RVA: 0x00989F54 File Offset: 0x00988154
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MagneticStorm_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MagneticStorm_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B77 RID: 146295 RVA: 0x00989F9B File Offset: 0x0098819B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x06023B78 RID: 146296 RVA: 0x00989FAF File Offset: 0x009881AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x06023B79 RID: 146297 RVA: 0x00989FC3 File Offset: 0x009881C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06023B7A RID: 146298 RVA: 0x00989FD8 File Offset: 0x009881D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023B7B RID: 146299 RVA: 0x0098A024 File Offset: 0x00988224
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_MagneticStorm_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B7C RID: 146300 RVA: 0x0098A070 File Offset: 0x00988270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MagneticStorm(int EntryPoint)
		{
			BP_MagneticStorm_C.__ExecuteUbergraph_BP_MagneticStorm_FunctionParams* ptr = stackalloc BP_MagneticStorm_C.__ExecuteUbergraph_BP_MagneticStorm_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_MagneticStorm_C.__ExecuteUbergraph_BP_MagneticStorm_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MagneticStorm_C.__ExecuteUbergraph_BP_MagneticStorm_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MagneticStorm_C.__ExecuteUbergraph_BP_MagneticStorm_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06023B7D RID: 146301 RVA: 0x0098A0B7 File Offset: 0x009882B7
		protected BP_MagneticStorm_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012357 RID: 74583
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/MagneticStorm/BP_MagneticStorm.BP_MagneticStorm_C";

		// Token: 0x04012358 RID: 74584
		private static IntPtr _ClassPtr;

		// Token: 0x04012359 RID: 74585
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401235A RID: 74586
		internal static int __PropertyOffset_0;

		// Token: 0x0401235B RID: 74587
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401235C RID: 74588
		internal static int __PropertyOffset_1;

		// Token: 0x0401235D RID: 74589
		internal static int __PropertyOffset_2;

		// Token: 0x0401235E RID: 74590
		internal static int __PropertyOffset_3;

		// Token: 0x0401235F RID: 74591
		internal static int __PropertyOffset_4;

		// Token: 0x04012360 RID: 74592
		internal static int __PropertyOffset_5;

		// Token: 0x04012361 RID: 74593
		internal static int __PropertyOffset_6;

		// Token: 0x04012362 RID: 74594
		internal static int __PropertyOffset_7;

		// Token: 0x04012363 RID: 74595
		internal static int __PropertyOffset_8;

		// Token: 0x04012364 RID: 74596
		internal static int __PropertyOffset_9;

		// Token: 0x04012365 RID: 74597
		internal static int __PropertyOffset_10;

		// Token: 0x04012366 RID: 74598
		private static IntPtr __UpdateNS_NativeFunctionPtr;

		// Token: 0x04012367 RID: 74599
		private static IntPtr __RemoveParam_NativeFunctionPtr;

		// Token: 0x04012368 RID: 74600
		private static IntPtr __CloseAllShockwave_NativeFunctionPtr;

		// Token: 0x04012369 RID: 74601
		private static IntPtr __InTheBox_NativeFunctionPtr;

		// Token: 0x0401236A RID: 74602
		private static IntPtr __OpenShockwave_NativeFunctionPtr;

		// Token: 0x0401236B RID: 74603
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x0401236C RID: 74604
		private static IntPtr __SetParam_NativeFunctionPtr;

		// Token: 0x0401236D RID: 74605
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401236E RID: 74606
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401236F RID: 74607
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012370 RID: 74608
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x04012371 RID: 74609
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x04012372 RID: 74610
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04012373 RID: 74611
		private static IntPtr __ExecuteUbergraph_BP_MagneticStorm_NativeFunctionPtr;

		// Token: 0x02009D21 RID: 40225
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __InTheBox_FunctionParams
		{
			// Token: 0x040326DD RID: 206557
			[FieldOffset(0)]
			public FVector pos;

			// Token: 0x040326DE RID: 206558
			[FieldOffset(12)]
			public bool IntheBox;
		}

		// Token: 0x02009D22 RID: 40226
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040326DF RID: 206559
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009D23 RID: 40227
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040326E0 RID: 206560
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009D24 RID: 40228
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_MagneticStorm_FunctionParams
		{
			// Token: 0x040326E1 RID: 206561
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
