using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.PivotPainter2_Winds
{
	// Token: 0x02003BA4 RID: 15268
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/PivotPainter2_Winds/BP_CharacterTraceRT.BP_CharacterTraceRT_C")]
	[UnrealStructLayout(1408, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1408)]
	public class BP_CharacterTraceRT_C : AKuroBPEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021F23 RID: 139043 RVA: 0x00957EF4 File Offset: 0x009560F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterTraceRT_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/PivotPainter2_Winds/BP_CharacterTraceRT.BP_CharacterTraceRT_C");
			}
			return BP_CharacterTraceRT_C._ClassPtr;
		}

		// Token: 0x06021F24 RID: 139044 RVA: 0x00957F18 File Offset: 0x00956118
		public BP_CharacterTraceRT_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterTraceRT_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021F25 RID: 139045 RVA: 0x00957F40 File Offset: 0x00956140
		[NullableContext(1)]
		public BP_CharacterTraceRT_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterTraceRT_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003DE2 RID: 15842
		// (get) Token: 0x06021F26 RID: 139046 RVA: 0x00957F74 File Offset: 0x00956174
		// (set) Token: 0x06021F27 RID: 139047 RVA: 0x00957FAD File Offset: 0x009561AD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003DE3 RID: 15843
		// (get) Token: 0x06021F28 RID: 139048 RVA: 0x00957FCE File Offset: 0x009561CE
		// (set) Token: 0x06021F29 RID: 139049 RVA: 0x00957FE2 File Offset: 0x009561E2
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003DE4 RID: 15844
		// (get) Token: 0x06021F2A RID: 139050 RVA: 0x00957FF7 File Offset: 0x009561F7
		// (set) Token: 0x06021F2B RID: 139051 RVA: 0x0095800B File Offset: 0x0095620B
		public unsafe UTextureRenderTarget2D Texture_Render_Target
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003DE5 RID: 15845
		// (get) Token: 0x06021F2C RID: 139052 RVA: 0x00958020 File Offset: 0x00956220
		// (set) Token: 0x06021F2D RID: 139053 RVA: 0x00958034 File Offset: 0x00956234
		public unsafe UMaterialInterface Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003DE6 RID: 15846
		// (get) Token: 0x06021F2E RID: 139054 RVA: 0x00958049 File Offset: 0x00956249
		// (set) Token: 0x06021F2F RID: 139055 RVA: 0x0095805D File Offset: 0x0095625D
		public unsafe UTextureRenderTarget2D Texture_Render_Target_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003DE7 RID: 15847
		// (get) Token: 0x06021F30 RID: 139056 RVA: 0x00958072 File Offset: 0x00956272
		// (set) Token: 0x06021F31 RID: 139057 RVA: 0x00958086 File Offset: 0x00956286
		public unsafe UMaterialInterface Material_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterTraceRT_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003DE8 RID: 15848
		// (get) Token: 0x06021F32 RID: 139058 RVA: 0x0095809B File Offset: 0x0095629B
		// (set) Token: 0x06021F33 RID: 139059 RVA: 0x009580AB File Offset: 0x009562AB
		public unsafe int TexRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003DE9 RID: 15849
		// (get) Token: 0x06021F34 RID: 139060 RVA: 0x009580BC File Offset: 0x009562BC
		// (set) Token: 0x06021F35 RID: 139061 RVA: 0x009580CC File Offset: 0x009562CC
		public unsafe int TexRange_Vehicle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003DEA RID: 15850
		// (get) Token: 0x06021F36 RID: 139062 RVA: 0x009580DD File Offset: 0x009562DD
		// (set) Token: 0x06021F37 RID: 139063 RVA: 0x009580ED File Offset: 0x009562ED
		public unsafe int InteractionRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003DEB RID: 15851
		// (get) Token: 0x06021F38 RID: 139064 RVA: 0x009580FE File Offset: 0x009562FE
		// (set) Token: 0x06021F39 RID: 139065 RVA: 0x0095810E File Offset: 0x0095630E
		public unsafe int InteractionRange_Vehicle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003DEC RID: 15852
		// (get) Token: 0x06021F3A RID: 139066 RVA: 0x0095811F File Offset: 0x0095631F
		// (set) Token: 0x06021F3B RID: 139067 RVA: 0x0095812F File Offset: 0x0095632F
		public unsafe int OffsetStep
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003DED RID: 15853
		// (get) Token: 0x06021F3C RID: 139068 RVA: 0x00958140 File Offset: 0x00956340
		// (set) Token: 0x06021F3D RID: 139069 RVA: 0x00958150 File Offset: 0x00956350
		public unsafe int SnapCenterX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003DEE RID: 15854
		// (get) Token: 0x06021F3E RID: 139070 RVA: 0x00958161 File Offset: 0x00956361
		// (set) Token: 0x06021F3F RID: 139071 RVA: 0x00958171 File Offset: 0x00956371
		public unsafe int SnapCenterY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003DEF RID: 15855
		// (get) Token: 0x06021F40 RID: 139072 RVA: 0x00958182 File Offset: 0x00956382
		// (set) Token: 0x06021F41 RID: 139073 RVA: 0x00958192 File Offset: 0x00956392
		public unsafe int SnapCenterX_Pre
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003DF0 RID: 15856
		// (get) Token: 0x06021F42 RID: 139074 RVA: 0x009581A3 File Offset: 0x009563A3
		// (set) Token: 0x06021F43 RID: 139075 RVA: 0x009581B3 File Offset: 0x009563B3
		public unsafe int SnapCenterY_Pre
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003DF1 RID: 15857
		// (get) Token: 0x06021F44 RID: 139076 RVA: 0x009581C4 File Offset: 0x009563C4
		// (set) Token: 0x06021F45 RID: 139077 RVA: 0x009581D4 File Offset: 0x009563D4
		public unsafe float InteractionDamping
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterTraceRT_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x06021F46 RID: 139078 RVA: 0x009581E5 File Offset: 0x009563E5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SnapCenterXY()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterTraceRT_C.__SnapCenterXY_NativeFunctionPtr, null);
		}

		// Token: 0x06021F47 RID: 139079 RVA: 0x009581F9 File Offset: 0x009563F9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterTraceRT_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021F48 RID: 139080 RVA: 0x0095820D File Offset: 0x0095640D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterTraceRT_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F49 RID: 139081 RVA: 0x00958222 File Offset: 0x00956422
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterTraceRT_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021F4A RID: 139082 RVA: 0x00958236 File Offset: 0x00956436
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterTraceRT_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021F4B RID: 139083 RVA: 0x0095824C File Offset: 0x0095644C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterTraceRT_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterTraceRT_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021F4C RID: 139084 RVA: 0x00958294 File Offset: 0x00956494
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterTraceRT_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterTraceRT_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterTraceRT_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F4D RID: 139085 RVA: 0x009582DC File Offset: 0x009564DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_CharacterTraceRT_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CharacterTraceRT_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterTraceRT_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterTraceRT_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CharacterTraceRT_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021F4E RID: 139086 RVA: 0x00958324 File Offset: 0x00956524
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_CharacterTraceRT_C.__EditorTick_FunctionParams* ptr = stackalloc BP_CharacterTraceRT_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CharacterTraceRT_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterTraceRT_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterTraceRT_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F4F RID: 139087 RVA: 0x0095836C File Offset: 0x0095656C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CharacterTraceRT(int EntryPoint)
		{
			BP_CharacterTraceRT_C.__ExecuteUbergraph_BP_CharacterTraceRT_FunctionParams* ptr = stackalloc BP_CharacterTraceRT_C.__ExecuteUbergraph_BP_CharacterTraceRT_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_CharacterTraceRT_C.__ExecuteUbergraph_BP_CharacterTraceRT_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CharacterTraceRT_C.__ExecuteUbergraph_BP_CharacterTraceRT_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CharacterTraceRT_C.__ExecuteUbergraph_BP_CharacterTraceRT_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021F50 RID: 139088 RVA: 0x009583B3 File Offset: 0x009565B3
		protected BP_CharacterTraceRT_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011243 RID: 70211
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/PivotPainter2_Winds/BP_CharacterTraceRT.BP_CharacterTraceRT_C";

		// Token: 0x04011244 RID: 70212
		private static IntPtr _ClassPtr;

		// Token: 0x04011245 RID: 70213
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011246 RID: 70214
		internal static int __PropertyOffset_0;

		// Token: 0x04011247 RID: 70215
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011248 RID: 70216
		internal static int __PropertyOffset_1;

		// Token: 0x04011249 RID: 70217
		internal static int __PropertyOffset_2;

		// Token: 0x0401124A RID: 70218
		internal static int __PropertyOffset_3;

		// Token: 0x0401124B RID: 70219
		internal static int __PropertyOffset_4;

		// Token: 0x0401124C RID: 70220
		internal static int __PropertyOffset_5;

		// Token: 0x0401124D RID: 70221
		internal static int __PropertyOffset_6;

		// Token: 0x0401124E RID: 70222
		internal static int __PropertyOffset_7;

		// Token: 0x0401124F RID: 70223
		internal static int __PropertyOffset_8;

		// Token: 0x04011250 RID: 70224
		internal static int __PropertyOffset_9;

		// Token: 0x04011251 RID: 70225
		internal static int __PropertyOffset_10;

		// Token: 0x04011252 RID: 70226
		internal static int __PropertyOffset_11;

		// Token: 0x04011253 RID: 70227
		internal static int __PropertyOffset_12;

		// Token: 0x04011254 RID: 70228
		internal static int __PropertyOffset_13;

		// Token: 0x04011255 RID: 70229
		internal static int __PropertyOffset_14;

		// Token: 0x04011256 RID: 70230
		internal static int __PropertyOffset_15;

		// Token: 0x04011257 RID: 70231
		private static IntPtr __SnapCenterXY_NativeFunctionPtr;

		// Token: 0x04011258 RID: 70232
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04011259 RID: 70233
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401125A RID: 70234
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401125B RID: 70235
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401125C RID: 70236
		private static IntPtr __ExecuteUbergraph_BP_CharacterTraceRT_NativeFunctionPtr;

		// Token: 0x02009B77 RID: 39799
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403236A RID: 205674
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B78 RID: 39800
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403236B RID: 205675
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009B79 RID: 39801
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_CharacterTraceRT_FunctionParams
		{
			// Token: 0x0403236C RID: 205676
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
