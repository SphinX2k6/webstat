using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence.ScreenOut
{
	// Token: 0x02003A63 RID: 14947
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/ScreenOut/BP_PostOutScreen.BP_PostOutScreen_C")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1648)]
	public class BP_PostOutScreen_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F18B RID: 127371 RVA: 0x00907B20 File Offset: 0x00905D20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PostOutScreen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/ScreenOut/BP_PostOutScreen.BP_PostOutScreen_C");
			}
			return BP_PostOutScreen_C._ClassPtr;
		}

		// Token: 0x0601F18C RID: 127372 RVA: 0x00907B44 File Offset: 0x00905D44
		public BP_PostOutScreen_C() : this(BuiltinUtils.AllocNativeUObject(BP_PostOutScreen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F18D RID: 127373 RVA: 0x00907B6C File Offset: 0x00905D6C
		[NullableContext(1)]
		public BP_PostOutScreen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PostOutScreen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E0A RID: 11786
		// (get) Token: 0x0601F18E RID: 127374 RVA: 0x00907BA0 File Offset: 0x00905DA0
		// (set) Token: 0x0601F18F RID: 127375 RVA: 0x00907BD9 File Offset: 0x00905DD9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002E0B RID: 11787
		// (get) Token: 0x0601F190 RID: 127376 RVA: 0x00907BFA File Offset: 0x00905DFA
		// (set) Token: 0x0601F191 RID: 127377 RVA: 0x00907C0E File Offset: 0x00905E0E
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002E0C RID: 11788
		// (get) Token: 0x0601F192 RID: 127378 RVA: 0x00907C23 File Offset: 0x00905E23
		// (set) Token: 0x0601F193 RID: 127379 RVA: 0x00907C37 File Offset: 0x00905E37
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002E0D RID: 11789
		// (get) Token: 0x0601F194 RID: 127380 RVA: 0x00907C4C File Offset: 0x00905E4C
		// (set) Token: 0x0601F195 RID: 127381 RVA: 0x00907C60 File Offset: 0x00905E60
		public unsafe UMaterialInstanceDynamic DynamicMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17002E0E RID: 11790
		// (get) Token: 0x0601F196 RID: 127382 RVA: 0x00907C78 File Offset: 0x00905E78
		// (set) Token: 0x0601F197 RID: 127383 RVA: 0x00907CB1 File Offset: 0x00905EB1
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
					result = (this._Scalar_Parameters = new TMap<FName, float>(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Scalar_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E0F RID: 11791
		// (get) Token: 0x0601F198 RID: 127384 RVA: 0x00907CC0 File Offset: 0x00905EC0
		// (set) Token: 0x0601F199 RID: 127385 RVA: 0x00907CF9 File Offset: 0x00905EF9
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
					result = (this._Vector_Parameters = new TMap<FName, FLinearColor>(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Vector_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E10 RID: 11792
		// (get) Token: 0x0601F19A RID: 127386 RVA: 0x00907D08 File Offset: 0x00905F08
		// (set) Token: 0x0601F19B RID: 127387 RVA: 0x00907D41 File Offset: 0x00905F41
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
					result = (this._Texture_Parameters = new TMap<FName, UTexture>(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Texture_Parameters.CopyAssign(value);
			}
		}

		// Token: 0x17002E11 RID: 11793
		// (get) Token: 0x0601F19C RID: 127388 RVA: 0x00907D4F File Offset: 0x00905F4F
		// (set) Token: 0x0601F19D RID: 127389 RVA: 0x00907D5F File Offset: 0x00905F5F
		public unsafe float TopAndBotRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002E12 RID: 11794
		// (get) Token: 0x0601F19E RID: 127390 RVA: 0x00907D70 File Offset: 0x00905F70
		// (set) Token: 0x0601F19F RID: 127391 RVA: 0x00907D80 File Offset: 0x00905F80
		public unsafe float Aspect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PostOutScreen_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002E13 RID: 11795
		// (get) Token: 0x0601F1A0 RID: 127392 RVA: 0x00907D91 File Offset: 0x00905F91
		// (set) Token: 0x0601F1A1 RID: 127393 RVA: 0x00907DA5 File Offset: 0x00905FA5
		public unsafe UMaterialInstance Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17002E14 RID: 11796
		// (get) Token: 0x0601F1A2 RID: 127394 RVA: 0x00907DBA File Offset: 0x00905FBA
		// (set) Token: 0x0601F1A3 RID: 127395 RVA: 0x00907DCE File Offset: 0x00905FCE
		public unsafe UMediaPlayer BottomMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17002E15 RID: 11797
		// (get) Token: 0x0601F1A4 RID: 127396 RVA: 0x00907DE3 File Offset: 0x00905FE3
		// (set) Token: 0x0601F1A5 RID: 127397 RVA: 0x00907DF7 File Offset: 0x00905FF7
		public unsafe UMediaPlayer CenterMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17002E16 RID: 11798
		// (get) Token: 0x0601F1A6 RID: 127398 RVA: 0x00907E0C File Offset: 0x0090600C
		// (set) Token: 0x0601F1A7 RID: 127399 RVA: 0x00907E20 File Offset: 0x00906020
		public unsafe UMediaPlayer TopMediaPlayer
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x17002E17 RID: 11799
		// (get) Token: 0x0601F1A8 RID: 127400 RVA: 0x00907E35 File Offset: 0x00906035
		// (set) Token: 0x0601F1A9 RID: 127401 RVA: 0x00907E49 File Offset: 0x00906049
		public unsafe UFileMediaSource BottomMediaSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFileMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_13);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_13, value);
			}
		}

		// Token: 0x17002E18 RID: 11800
		// (get) Token: 0x0601F1AA RID: 127402 RVA: 0x00907E5E File Offset: 0x0090605E
		// (set) Token: 0x0601F1AB RID: 127403 RVA: 0x00907E72 File Offset: 0x00906072
		public unsafe UFileMediaSource CenterMediaSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFileMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17002E19 RID: 11801
		// (get) Token: 0x0601F1AC RID: 127404 RVA: 0x00907E87 File Offset: 0x00906087
		// (set) Token: 0x0601F1AD RID: 127405 RVA: 0x00907E9B File Offset: 0x0090609B
		public unsafe UFileMediaSource TopMediaSource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFileMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_15);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PostOutScreen_C.__PropertyOffset_15, value);
			}
		}

		// Token: 0x0601F1AE RID: 127406 RVA: 0x00907EB0 File Offset: 0x009060B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParameter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__SetParameter_NativeFunctionPtr, null);
		}

		// Token: 0x0601F1AF RID: 127407 RVA: 0x00907EC4 File Offset: 0x009060C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601F1B0 RID: 127408 RVA: 0x00907ED8 File Offset: 0x009060D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F1B1 RID: 127409 RVA: 0x00907EED File Offset: 0x009060ED
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F1B2 RID: 127410 RVA: 0x00907F01 File Offset: 0x00906101
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F1B3 RID: 127411 RVA: 0x00907F18 File Offset: 0x00906118
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_PostOutScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PostOutScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostOutScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostOutScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F1B4 RID: 127412 RVA: 0x00907F60 File Offset: 0x00906160
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_PostOutScreen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_PostOutScreen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostOutScreen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostOutScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F1B5 RID: 127413 RVA: 0x00907FA7 File Offset: 0x009061A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveDestroyed()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveDestroyed_NativeFunctionPtr, null);
		}

		// Token: 0x0601F1B6 RID: 127414 RVA: 0x00907FBB File Offset: 0x009061BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveDestroyed_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__ReceiveDestroyed_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F1B7 RID: 127415 RVA: 0x00907FD0 File Offset: 0x009061D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_PostOutScreen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PostOutScreen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostOutScreen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostOutScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PostOutScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F1B8 RID: 127416 RVA: 0x00908018 File Offset: 0x00906218
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_PostOutScreen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_PostOutScreen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_PostOutScreen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostOutScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F1B9 RID: 127417 RVA: 0x00908060 File Offset: 0x00906260
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_PostOutScreen(int EntryPoint)
		{
			BP_PostOutScreen_C.__ExecuteUbergraph_BP_PostOutScreen_FunctionParams* ptr = stackalloc BP_PostOutScreen_C.__ExecuteUbergraph_BP_PostOutScreen_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_PostOutScreen_C.__ExecuteUbergraph_BP_PostOutScreen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PostOutScreen_C.__ExecuteUbergraph_BP_PostOutScreen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PostOutScreen_C.__ExecuteUbergraph_BP_PostOutScreen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F1BA RID: 127418 RVA: 0x009080A7 File Offset: 0x009062A7
		protected BP_PostOutScreen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F65A RID: 63066
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/ScreenOut/BP_PostOutScreen.BP_PostOutScreen_C";

		// Token: 0x0400F65B RID: 63067
		private static IntPtr _ClassPtr;

		// Token: 0x0400F65C RID: 63068
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F65D RID: 63069
		internal static int __PropertyOffset_0;

		// Token: 0x0400F65E RID: 63070
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F65F RID: 63071
		internal static int __PropertyOffset_1;

		// Token: 0x0400F660 RID: 63072
		internal static int __PropertyOffset_2;

		// Token: 0x0400F661 RID: 63073
		internal static int __PropertyOffset_3;

		// Token: 0x0400F662 RID: 63074
		internal static int __PropertyOffset_4;

		// Token: 0x0400F663 RID: 63075
		private TMap<FName, float> _Scalar_Parameters;

		// Token: 0x0400F664 RID: 63076
		internal static int __PropertyOffset_5;

		// Token: 0x0400F665 RID: 63077
		private TMap<FName, FLinearColor> _Vector_Parameters;

		// Token: 0x0400F666 RID: 63078
		internal static int __PropertyOffset_6;

		// Token: 0x0400F667 RID: 63079
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, UTexture> _Texture_Parameters;

		// Token: 0x0400F668 RID: 63080
		internal static int __PropertyOffset_7;

		// Token: 0x0400F669 RID: 63081
		internal static int __PropertyOffset_8;

		// Token: 0x0400F66A RID: 63082
		internal static int __PropertyOffset_9;

		// Token: 0x0400F66B RID: 63083
		internal static int __PropertyOffset_10;

		// Token: 0x0400F66C RID: 63084
		internal static int __PropertyOffset_11;

		// Token: 0x0400F66D RID: 63085
		internal static int __PropertyOffset_12;

		// Token: 0x0400F66E RID: 63086
		internal static int __PropertyOffset_13;

		// Token: 0x0400F66F RID: 63087
		internal static int __PropertyOffset_14;

		// Token: 0x0400F670 RID: 63088
		internal static int __PropertyOffset_15;

		// Token: 0x0400F671 RID: 63089
		private static IntPtr __SetParameter_NativeFunctionPtr;

		// Token: 0x0400F672 RID: 63090
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400F673 RID: 63091
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F674 RID: 63092
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F675 RID: 63093
		private static IntPtr __ReceiveDestroyed_NativeFunctionPtr;

		// Token: 0x0400F676 RID: 63094
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400F677 RID: 63095
		private static IntPtr __ExecuteUbergraph_BP_PostOutScreen_NativeFunctionPtr;

		// Token: 0x0200985F RID: 39007
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E94 RID: 204436
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009860 RID: 39008
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031E95 RID: 204437
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009861 RID: 39009
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __ExecuteUbergraph_BP_PostOutScreen_FunctionParams
		{
			// Token: 0x04031E96 RID: 204438
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
