using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Rain2
{
	// Token: 0x02003B3B RID: 15163
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Rain2/BP_RoofRainDropActivator.BP_RoofRainDropActivator_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1384)]
	public class BP_RoofRainDropActivator_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020CEF RID: 134383 RVA: 0x009375AB File Offset: 0x009357AB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RoofRainDropActivator_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Rain2/BP_RoofRainDropActivator.BP_RoofRainDropActivator_C");
			}
			return BP_RoofRainDropActivator_C._ClassPtr;
		}

		// Token: 0x06020CF0 RID: 134384 RVA: 0x009375D0 File Offset: 0x009357D0
		public BP_RoofRainDropActivator_C() : this(BuiltinUtils.AllocNativeUObject(BP_RoofRainDropActivator_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020CF1 RID: 134385 RVA: 0x009375F8 File Offset: 0x009357F8
		[NullableContext(1)]
		public BP_RoofRainDropActivator_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RoofRainDropActivator_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003765 RID: 14181
		// (get) Token: 0x06020CF2 RID: 134386 RVA: 0x0093762C File Offset: 0x0093582C
		// (set) Token: 0x06020CF3 RID: 134387 RVA: 0x00937665 File Offset: 0x00935865
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003766 RID: 14182
		// (get) Token: 0x06020CF4 RID: 134388 RVA: 0x00937686 File Offset: 0x00935886
		// (set) Token: 0x06020CF5 RID: 134389 RVA: 0x0093769A File Offset: 0x0093589A
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003767 RID: 14183
		// (get) Token: 0x06020CF6 RID: 134390 RVA: 0x009376B0 File Offset: 0x009358B0
		// (set) Token: 0x06020CF7 RID: 134391 RVA: 0x009376E9 File Offset: 0x009358E9
		[Nullable(1)]
		public TArray<AActor> RoofDropLists
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._RoofDropLists) == null)
				{
					result = (this._RoofDropLists = new TArray<AActor>(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RoofDropLists.CopyAssign(value);
			}
		}

		// Token: 0x17003768 RID: 14184
		// (get) Token: 0x06020CF8 RID: 134392 RVA: 0x009376F7 File Offset: 0x009358F7
		// (set) Token: 0x06020CF9 RID: 134393 RVA: 0x00937707 File Offset: 0x00935907
		public unsafe float Rain_Intensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003769 RID: 14185
		// (get) Token: 0x06020CFA RID: 134394 RVA: 0x00937718 File Offset: 0x00935918
		// (set) Token: 0x06020CFB RID: 134395 RVA: 0x00937728 File Offset: 0x00935928
		public unsafe float Gravity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700376A RID: 14186
		// (get) Token: 0x06020CFC RID: 134396 RVA: 0x00937739 File Offset: 0x00935939
		// (set) Token: 0x06020CFD RID: 134397 RVA: 0x0093774D File Offset: 0x0093594D
		public unsafe TEnumAsByte<EKuroRainType> RainType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700376B RID: 14187
		// (get) Token: 0x06020CFE RID: 134398 RVA: 0x00937762 File Offset: 0x00935962
		// (set) Token: 0x06020CFF RID: 134399 RVA: 0x00937772 File Offset: 0x00935972
		public unsafe bool Is_in_Cave
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700376C RID: 14188
		// (get) Token: 0x06020D00 RID: 134400 RVA: 0x00937783 File Offset: 0x00935983
		// (set) Token: 0x06020D01 RID: 134401 RVA: 0x00937793 File Offset: 0x00935993
		public unsafe float WeatherChangePastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700376D RID: 14189
		// (get) Token: 0x06020D02 RID: 134402 RVA: 0x009377A4 File Offset: 0x009359A4
		// (set) Token: 0x06020D03 RID: 134403 RVA: 0x009377B4 File Offset: 0x009359B4
		public unsafe float FadeDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_RoofRainDropActivator_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700376E RID: 14190
		// (get) Token: 0x06020D04 RID: 134404 RVA: 0x009377C5 File Offset: 0x009359C5
		// (set) Token: 0x06020D05 RID: 134405 RVA: 0x009377D9 File Offset: 0x009359D9
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MID_WaterDrop
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x1700376F RID: 14191
		// (get) Token: 0x06020D06 RID: 134406 RVA: 0x009377EE File Offset: 0x009359EE
		// (set) Token: 0x06020D07 RID: 134407 RVA: 0x00937802 File Offset: 0x00935A02
		[Nullable(2)]
		public unsafe BP_GlobalGI_C GlobalGI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GlobalGI_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_10);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RoofRainDropActivator_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x06020D08 RID: 134408 RVA: 0x00937818 File Offset: 0x00935A18
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetBasicDropletParameters(float RainIntensity, float Gravity, EKuroRainType RainType, bool IsInCave)
		{
			BP_RoofRainDropActivator_C.__SetBasicDropletParameters_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__SetBasicDropletParameters_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__SetBasicDropletParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__SetBasicDropletParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->RainIntensity = RainIntensity;
			ptr->Gravity = Gravity;
			ptr->RainType = RainType;
			ptr->IsInCave = IsInCave;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__SetBasicDropletParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D09 RID: 134409 RVA: 0x00937879 File Offset: 0x00935A79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06020D0A RID: 134410 RVA: 0x0093788D File Offset: 0x00935A8D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020D0B RID: 134411 RVA: 0x009378A4 File Offset: 0x00935AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D0C RID: 134412 RVA: 0x009378EC File Offset: 0x00935AEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D0D RID: 134413 RVA: 0x00937934 File Offset: 0x00935B34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_RoofRainDropActivator_C.__EditorTick_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020D0E RID: 134414 RVA: 0x0093797C File Offset: 0x00935B7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_RoofRainDropActivator_C.__EditorTick_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D0F RID: 134415 RVA: 0x009379C4 File Offset: 0x00935BC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RoofRainDropActivator(int EntryPoint)
		{
			BP_RoofRainDropActivator_C.__ExecuteUbergraph_BP_RoofRainDropActivator_FunctionParams* ptr = stackalloc BP_RoofRainDropActivator_C.__ExecuteUbergraph_BP_RoofRainDropActivator_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_RoofRainDropActivator_C.__ExecuteUbergraph_BP_RoofRainDropActivator_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RoofRainDropActivator_C.__ExecuteUbergraph_BP_RoofRainDropActivator_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RoofRainDropActivator_C.__ExecuteUbergraph_BP_RoofRainDropActivator_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020D10 RID: 134416 RVA: 0x00937A0E File Offset: 0x00935C0E
		protected BP_RoofRainDropActivator_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401072B RID: 67371
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Rain2/BP_RoofRainDropActivator.BP_RoofRainDropActivator_C";

		// Token: 0x0401072C RID: 67372
		private static IntPtr _ClassPtr;

		// Token: 0x0401072D RID: 67373
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401072E RID: 67374
		internal static int __PropertyOffset_0;

		// Token: 0x0401072F RID: 67375
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010730 RID: 67376
		internal static int __PropertyOffset_1;

		// Token: 0x04010731 RID: 67377
		internal static int __PropertyOffset_2;

		// Token: 0x04010732 RID: 67378
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _RoofDropLists;

		// Token: 0x04010733 RID: 67379
		internal static int __PropertyOffset_3;

		// Token: 0x04010734 RID: 67380
		internal static int __PropertyOffset_4;

		// Token: 0x04010735 RID: 67381
		internal static int __PropertyOffset_5;

		// Token: 0x04010736 RID: 67382
		internal static int __PropertyOffset_6;

		// Token: 0x04010737 RID: 67383
		internal static int __PropertyOffset_7;

		// Token: 0x04010738 RID: 67384
		internal static int __PropertyOffset_8;

		// Token: 0x04010739 RID: 67385
		internal static int __PropertyOffset_9;

		// Token: 0x0401073A RID: 67386
		internal static int __PropertyOffset_10;

		// Token: 0x0401073B RID: 67387
		private static IntPtr __SetBasicDropletParameters_NativeFunctionPtr;

		// Token: 0x0401073C RID: 67388
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401073D RID: 67389
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401073E RID: 67390
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401073F RID: 67391
		private static IntPtr __ExecuteUbergraph_BP_RoofRainDropActivator_NativeFunctionPtr;

		// Token: 0x02009A30 RID: 39472
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SetBasicDropletParameters_FunctionParams
		{
			// Token: 0x04032127 RID: 205095
			[FieldOffset(0)]
			public float RainIntensity;

			// Token: 0x04032128 RID: 205096
			[FieldOffset(4)]
			public float Gravity;

			// Token: 0x04032129 RID: 205097
			[FieldOffset(8)]
			public TEnumAsByte<EKuroRainType> RainType;

			// Token: 0x0403212A RID: 205098
			[FieldOffset(9)]
			public bool IsInCave;
		}

		// Token: 0x02009A31 RID: 39473
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403212B RID: 205099
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A32 RID: 39474
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403212C RID: 205100
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009A33 RID: 39475
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected ref struct __ExecuteUbergraph_BP_RoofRainDropActivator_FunctionParams
		{
			// Token: 0x0403212D RID: 205101
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
