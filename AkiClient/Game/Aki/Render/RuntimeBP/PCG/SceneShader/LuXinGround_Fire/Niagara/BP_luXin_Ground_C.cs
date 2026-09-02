using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.LuXinGround_Fire.Niagara
{
	// Token: 0x02003B7C RID: 15228
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/LuXinGround_Fire/Niagara/BP_luXin_Ground.BP_luXin_Ground_C")]
	[UnrealStructLayout(1416, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1413)]
	public class BP_luXin_Ground_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021922 RID: 137506 RVA: 0x0094CE3F File Offset: 0x0094B03F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_luXin_Ground_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/LuXinGround_Fire/Niagara/BP_luXin_Ground.BP_luXin_Ground_C");
			}
			return BP_luXin_Ground_C._ClassPtr;
		}

		// Token: 0x06021923 RID: 137507 RVA: 0x0094CE64 File Offset: 0x0094B064
		public BP_luXin_Ground_C() : this(BuiltinUtils.AllocNativeUObject(BP_luXin_Ground_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021924 RID: 137508 RVA: 0x0094CE8C File Offset: 0x0094B08C
		[NullableContext(1)]
		public BP_luXin_Ground_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_luXin_Ground_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BD8 RID: 15320
		// (get) Token: 0x06021925 RID: 137509 RVA: 0x0094CEC0 File Offset: 0x0094B0C0
		// (set) Token: 0x06021926 RID: 137510 RVA: 0x0094CEF9 File Offset: 0x0094B0F9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003BD9 RID: 15321
		// (get) Token: 0x06021927 RID: 137511 RVA: 0x0094CF1A File Offset: 0x0094B11A
		// (set) Token: 0x06021928 RID: 137512 RVA: 0x0094CF2E File Offset: 0x0094B12E
		public unsafe UStaticMeshComponent SM_lUXinFire_ES3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BDA RID: 15322
		// (get) Token: 0x06021929 RID: 137513 RVA: 0x0094CF43 File Offset: 0x0094B143
		// (set) Token: 0x0602192A RID: 137514 RVA: 0x0094CF57 File Offset: 0x0094B157
		public unsafe UTextRenderComponent TextRender
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextRenderComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003BDB RID: 15323
		// (get) Token: 0x0602192B RID: 137515 RVA: 0x0094CF6C File Offset: 0x0094B16C
		// (set) Token: 0x0602192C RID: 137516 RVA: 0x0094CF80 File Offset: 0x0094B180
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003BDC RID: 15324
		// (get) Token: 0x0602192D RID: 137517 RVA: 0x0094CF95 File Offset: 0x0094B195
		// (set) Token: 0x0602192E RID: 137518 RVA: 0x0094CFA9 File Offset: 0x0094B1A9
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_luXin_Ground_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003BDD RID: 15325
		// (get) Token: 0x0602192F RID: 137519 RVA: 0x0094CFBE File Offset: 0x0094B1BE
		// (set) Token: 0x06021930 RID: 137520 RVA: 0x0094CFCE File Offset: 0x0094B1CE
		public unsafe bool EditorDebug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BDE RID: 15326
		// (get) Token: 0x06021931 RID: 137521 RVA: 0x0094CFDF File Offset: 0x0094B1DF
		// (set) Token: 0x06021932 RID: 137522 RVA: 0x0094CFEF File Offset: 0x0094B1EF
		public unsafe float Delta_Seconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003BDF RID: 15327
		// (get) Token: 0x06021933 RID: 137523 RVA: 0x0094D000 File Offset: 0x0094B200
		// (set) Token: 0x06021934 RID: 137524 RVA: 0x0094D010 File Offset: 0x0094B210
		public unsafe bool Active
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BE0 RID: 15328
		// (get) Token: 0x06021935 RID: 137525 RVA: 0x0094D021 File Offset: 0x0094B221
		// (set) Token: 0x06021936 RID: 137526 RVA: 0x0094D031 File Offset: 0x0094B231
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003BE1 RID: 15329
		// (get) Token: 0x06021937 RID: 137527 RVA: 0x0094D042 File Offset: 0x0094B242
		// (set) Token: 0x06021938 RID: 137528 RVA: 0x0094D052 File Offset: 0x0094B252
		public unsafe float Spread_Niagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003BE2 RID: 15330
		// (get) Token: 0x06021939 RID: 137529 RVA: 0x0094D063 File Offset: 0x0094B263
		// (set) Token: 0x0602193A RID: 137530 RVA: 0x0094D073 File Offset: 0x0094B273
		public unsafe bool SetNiagaraActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BE3 RID: 15331
		// (get) Token: 0x0602193B RID: 137531 RVA: 0x0094D084 File Offset: 0x0094B284
		// (set) Token: 0x0602193C RID: 137532 RVA: 0x0094D094 File Offset: 0x0094B294
		public unsafe float Spread_Burnt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17003BE4 RID: 15332
		// (get) Token: 0x0602193D RID: 137533 RVA: 0x0094D0A5 File Offset: 0x0094B2A5
		// (set) Token: 0x0602193E RID: 137534 RVA: 0x0094D0B5 File Offset: 0x0094B2B5
		public unsafe float Spread_BurntDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003BE5 RID: 15333
		// (get) Token: 0x0602193F RID: 137535 RVA: 0x0094D0C6 File Offset: 0x0094B2C6
		// (set) Token: 0x06021940 RID: 137536 RVA: 0x0094D0D6 File Offset: 0x0094B2D6
		public unsafe float BoundSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17003BE6 RID: 15334
		// (get) Token: 0x06021941 RID: 137537 RVA: 0x0094D0E7 File Offset: 0x0094B2E7
		// (set) Token: 0x06021942 RID: 137538 RVA: 0x0094D0F7 File Offset: 0x0094B2F7
		public unsafe float Width
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003BE7 RID: 15335
		// (get) Token: 0x06021943 RID: 137539 RVA: 0x0094D108 File Offset: 0x0094B308
		// (set) Token: 0x06021944 RID: 137540 RVA: 0x0094D11C File Offset: 0x0094B31C
		public unsafe FLinearColor FireColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17003BE8 RID: 15336
		// (get) Token: 0x06021945 RID: 137541 RVA: 0x0094D131 File Offset: 0x0094B331
		// (set) Token: 0x06021946 RID: 137542 RVA: 0x0094D141 File Offset: 0x0094B341
		public unsafe float End_Fade
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17003BE9 RID: 15337
		// (get) Token: 0x06021947 RID: 137543 RVA: 0x0094D152 File Offset: 0x0094B352
		// (set) Token: 0x06021948 RID: 137544 RVA: 0x0094D162 File Offset: 0x0094B362
		public unsafe bool IsES3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_luXin_Ground_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x06021949 RID: 137545 RVA: 0x0094D173 File Offset: 0x0094B373
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Is_ES3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__Is_ES3_NativeFunctionPtr, null);
		}

		// Token: 0x0602194A RID: 137546 RVA: 0x0094D187 File Offset: 0x0094B387
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void initial()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__initial_NativeFunctionPtr, null);
		}

		// Token: 0x0602194B RID: 137547 RVA: 0x0094D19B File Offset: 0x0094B39B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602194C RID: 137548 RVA: 0x0094D1AF File Offset: 0x0094B3AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_luXin_Ground_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602194D RID: 137549 RVA: 0x0094D1C4 File Offset: 0x0094B3C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_luXin_Ground_C.__EditorTick_FunctionParams* ptr = stackalloc BP_luXin_Ground_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_luXin_Ground_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_luXin_Ground_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602194E RID: 137550 RVA: 0x0094D20C File Offset: 0x0094B40C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_luXin_Ground_C.__EditorTick_FunctionParams* ptr = stackalloc BP_luXin_Ground_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_luXin_Ground_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_luXin_Ground_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_luXin_Ground_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602194F RID: 137551 RVA: 0x0094D254 File Offset: 0x0094B454
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_luXin_Ground_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_luXin_Ground_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_luXin_Ground_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_luXin_Ground_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06021950 RID: 137552 RVA: 0x0094D29C File Offset: 0x0094B49C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_luXin_Ground_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_luXin_Ground_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_luXin_Ground_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_luXin_Ground_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_luXin_Ground_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021951 RID: 137553 RVA: 0x0094D2E3 File Offset: 0x0094B4E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_luXin_Ground_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06021952 RID: 137554 RVA: 0x0094D2F7 File Offset: 0x0094B4F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_luXin_Ground_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021953 RID: 137555 RVA: 0x0094D30C File Offset: 0x0094B50C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_luXin_Ground(int EntryPoint)
		{
			BP_luXin_Ground_C.__ExecuteUbergraph_BP_luXin_Ground_FunctionParams* ptr = stackalloc BP_luXin_Ground_C.__ExecuteUbergraph_BP_luXin_Ground_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_luXin_Ground_C.__ExecuteUbergraph_BP_luXin_Ground_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_luXin_Ground_C.__ExecuteUbergraph_BP_luXin_Ground_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_luXin_Ground_C.__ExecuteUbergraph_BP_luXin_Ground_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06021954 RID: 137556 RVA: 0x0094D356 File Offset: 0x0094B556
		protected BP_luXin_Ground_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010EA1 RID: 69281
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/LuXinGround_Fire/Niagara/BP_luXin_Ground.BP_luXin_Ground_C";

		// Token: 0x04010EA2 RID: 69282
		private static IntPtr _ClassPtr;

		// Token: 0x04010EA3 RID: 69283
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010EA4 RID: 69284
		internal static int __PropertyOffset_0;

		// Token: 0x04010EA5 RID: 69285
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04010EA6 RID: 69286
		internal static int __PropertyOffset_1;

		// Token: 0x04010EA7 RID: 69287
		internal static int __PropertyOffset_2;

		// Token: 0x04010EA8 RID: 69288
		internal static int __PropertyOffset_3;

		// Token: 0x04010EA9 RID: 69289
		internal static int __PropertyOffset_4;

		// Token: 0x04010EAA RID: 69290
		internal static int __PropertyOffset_5;

		// Token: 0x04010EAB RID: 69291
		internal static int __PropertyOffset_6;

		// Token: 0x04010EAC RID: 69292
		internal static int __PropertyOffset_7;

		// Token: 0x04010EAD RID: 69293
		internal static int __PropertyOffset_8;

		// Token: 0x04010EAE RID: 69294
		internal static int __PropertyOffset_9;

		// Token: 0x04010EAF RID: 69295
		internal static int __PropertyOffset_10;

		// Token: 0x04010EB0 RID: 69296
		internal static int __PropertyOffset_11;

		// Token: 0x04010EB1 RID: 69297
		internal static int __PropertyOffset_12;

		// Token: 0x04010EB2 RID: 69298
		internal static int __PropertyOffset_13;

		// Token: 0x04010EB3 RID: 69299
		internal static int __PropertyOffset_14;

		// Token: 0x04010EB4 RID: 69300
		internal static int __PropertyOffset_15;

		// Token: 0x04010EB5 RID: 69301
		internal static int __PropertyOffset_16;

		// Token: 0x04010EB6 RID: 69302
		internal static int __PropertyOffset_17;

		// Token: 0x04010EB7 RID: 69303
		private static IntPtr __Is_ES3_NativeFunctionPtr;

		// Token: 0x04010EB8 RID: 69304
		private static IntPtr __initial_NativeFunctionPtr;

		// Token: 0x04010EB9 RID: 69305
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04010EBA RID: 69306
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04010EBB RID: 69307
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04010EBC RID: 69308
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04010EBD RID: 69309
		private static IntPtr __ExecuteUbergraph_BP_luXin_Ground_NativeFunctionPtr;

		// Token: 0x02009AF8 RID: 39672
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032298 RID: 205464
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AF9 RID: 39673
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032299 RID: 205465
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009AFA RID: 39674
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_BP_luXin_Ground_FunctionParams
		{
			// Token: 0x0403229A RID: 205466
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
