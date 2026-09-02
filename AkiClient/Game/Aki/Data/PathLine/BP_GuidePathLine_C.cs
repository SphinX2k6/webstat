using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E4F RID: 15951
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/BP_GuidePathLine.BP_GuidePathLine_C")]
	[UnrealStructLayout(1152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1149)]
	public class BP_GuidePathLine_C : BP_BasePathLine_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060275A6 RID: 161190 RVA: 0x009EFCCC File Offset: 0x009EDECC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GuidePathLine_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/BP_GuidePathLine.BP_GuidePathLine_C");
			}
			return BP_GuidePathLine_C._ClassPtr;
		}

		// Token: 0x060275A7 RID: 161191 RVA: 0x009EFCF0 File Offset: 0x009EDEF0
		public BP_GuidePathLine_C() : this(BuiltinUtils.AllocNativeUObject(BP_GuidePathLine_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060275A8 RID: 161192 RVA: 0x009EFD18 File Offset: 0x009EDF18
		[NullableContext(1)]
		public BP_GuidePathLine_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GuidePathLine_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C5F RID: 23647
		// (get) Token: 0x060275A9 RID: 161193 RVA: 0x009EFD4C File Offset: 0x009EDF4C
		// (set) Token: 0x060275AA RID: 161194 RVA: 0x009EFD85 File Offset: 0x009EDF85
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C60 RID: 23648
		// (get) Token: 0x060275AB RID: 161195 RVA: 0x009EFDA6 File Offset: 0x009EDFA6
		// (set) Token: 0x060275AC RID: 161196 RVA: 0x009EFDBA File Offset: 0x009EDFBA
		public unsafe UMaterialInterface Material
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuidePathLine_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuidePathLine_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005C61 RID: 23649
		// (get) Token: 0x060275AD RID: 161197 RVA: 0x009EFDCF File Offset: 0x009EDFCF
		// (set) Token: 0x060275AE RID: 161198 RVA: 0x009EFDE3 File Offset: 0x009EDFE3
		public unsafe UMaterialInstanceDynamic MaterialInstanceDynamic
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuidePathLine_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GuidePathLine_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005C62 RID: 23650
		// (get) Token: 0x060275AF RID: 161199 RVA: 0x009EFDF8 File Offset: 0x009EDFF8
		// (set) Token: 0x060275B0 RID: 161200 RVA: 0x009EFE0C File Offset: 0x009EE00C
		public unsafe FVector DebugColorVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005C63 RID: 23651
		// (get) Token: 0x060275B1 RID: 161201 RVA: 0x009EFE21 File Offset: 0x009EE021
		// (set) Token: 0x060275B2 RID: 161202 RVA: 0x009EFE31 File Offset: 0x009EE031
		public unsafe float DebugPercentTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005C64 RID: 23652
		// (get) Token: 0x060275B3 RID: 161203 RVA: 0x009EFE42 File Offset: 0x009EE042
		// (set) Token: 0x060275B4 RID: 161204 RVA: 0x009EFE52 File Offset: 0x009EE052
		public unsafe bool Appear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C65 RID: 23653
		// (get) Token: 0x060275B5 RID: 161205 RVA: 0x009EFE63 File Offset: 0x009EE063
		// (set) Token: 0x060275B6 RID: 161206 RVA: 0x009EFE73 File Offset: 0x009EE073
		public unsafe bool DisAppear
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C66 RID: 23654
		// (get) Token: 0x060275B7 RID: 161207 RVA: 0x009EFE84 File Offset: 0x009EE084
		// (set) Token: 0x060275B8 RID: 161208 RVA: 0x009EFE94 File Offset: 0x009EE094
		public unsafe float AppearSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005C67 RID: 23655
		// (get) Token: 0x060275B9 RID: 161209 RVA: 0x009EFEA5 File Offset: 0x009EE0A5
		// (set) Token: 0x060275BA RID: 161210 RVA: 0x009EFEB9 File Offset: 0x009EE0B9
		public unsafe FVector CurrentColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005C68 RID: 23656
		// (get) Token: 0x060275BB RID: 161211 RVA: 0x009EFECE File Offset: 0x009EE0CE
		// (set) Token: 0x060275BC RID: 161212 RVA: 0x009EFEDE File Offset: 0x009EE0DE
		public unsafe bool DebugBool
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GuidePathLine_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x060275BD RID: 161213 RVA: 0x009EFEEF File Offset: 0x009EE0EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisAppearLine()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__DisAppearLine_NativeFunctionPtr, null);
		}

		// Token: 0x060275BE RID: 161214 RVA: 0x009EFF03 File Offset: 0x009EE103
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AppearLine()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__AppearLine_NativeFunctionPtr, null);
		}

		// Token: 0x060275BF RID: 161215 RVA: 0x009EFF17 File Offset: 0x009EE117
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DebugColor()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__DebugColor_NativeFunctionPtr, null);
		}

		// Token: 0x060275C0 RID: 161216 RVA: 0x009EFF2C File Offset: 0x009EE12C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ChangeEffectColor(float PercentTime, bool SuddenChange)
		{
			BP_GuidePathLine_C.__ChangeEffectColor_FunctionParams* ptr = stackalloc BP_GuidePathLine_C.__ChangeEffectColor_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_GuidePathLine_C.__ChangeEffectColor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuidePathLine_C.__ChangeEffectColor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PercentTime = PercentTime;
			ptr->SuddenChange = SuddenChange;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__ChangeEffectColor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060275C1 RID: 161217 RVA: 0x009EFF79 File Offset: 0x009EE179
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ShowEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__ShowEffect_NativeFunctionPtr, null);
		}

		// Token: 0x060275C2 RID: 161218 RVA: 0x009EFF8D File Offset: 0x009EE18D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void HideEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__HideEffect_NativeFunctionPtr, null);
		}

		// Token: 0x060275C3 RID: 161219 RVA: 0x009EFFA1 File Offset: 0x009EE1A1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitEffect()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__InitEffect_NativeFunctionPtr, null);
		}

		// Token: 0x060275C4 RID: 161220 RVA: 0x009EFFB5 File Offset: 0x009EE1B5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060275C5 RID: 161221 RVA: 0x009EFFC9 File Offset: 0x009EE1C9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuidePathLine_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060275C6 RID: 161222 RVA: 0x009EFFDE File Offset: 0x009EE1DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060275C7 RID: 161223 RVA: 0x009EFFF2 File Offset: 0x009EE1F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuidePathLine_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060275C8 RID: 161224 RVA: 0x009F0008 File Offset: 0x009EE208
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GuidePathLine_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuidePathLine_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuidePathLine_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuidePathLine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GuidePathLine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060275C9 RID: 161225 RVA: 0x009F0050 File Offset: 0x009EE250
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GuidePathLine_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GuidePathLine_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GuidePathLine_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuidePathLine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuidePathLine_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060275CA RID: 161226 RVA: 0x009F0098 File Offset: 0x009EE298
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GuidePathLine(int EntryPoint)
		{
			BP_GuidePathLine_C.__ExecuteUbergraph_BP_GuidePathLine_FunctionParams* ptr = stackalloc BP_GuidePathLine_C.__ExecuteUbergraph_BP_GuidePathLine_FunctionParams[(UIntPtr)51] + 15L / (long)sizeof(BP_GuidePathLine_C.__ExecuteUbergraph_BP_GuidePathLine_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GuidePathLine_C.__ExecuteUbergraph_BP_GuidePathLine_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GuidePathLine_C.__ExecuteUbergraph_BP_GuidePathLine_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060275CB RID: 161227 RVA: 0x009F00DF File Offset: 0x009EE2DF
		protected BP_GuidePathLine_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149A0 RID: 84384
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/BP_GuidePathLine.BP_GuidePathLine_C";

		// Token: 0x040149A1 RID: 84385
		private static IntPtr _ClassPtr;

		// Token: 0x040149A2 RID: 84386
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149A3 RID: 84387
		internal new static int __PropertyOffset_0;

		// Token: 0x040149A4 RID: 84388
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040149A5 RID: 84389
		internal new static int __PropertyOffset_1;

		// Token: 0x040149A6 RID: 84390
		internal new static int __PropertyOffset_2;

		// Token: 0x040149A7 RID: 84391
		internal new static int __PropertyOffset_3;

		// Token: 0x040149A8 RID: 84392
		internal new static int __PropertyOffset_4;

		// Token: 0x040149A9 RID: 84393
		internal static int __PropertyOffset_5;

		// Token: 0x040149AA RID: 84394
		internal static int __PropertyOffset_6;

		// Token: 0x040149AB RID: 84395
		internal static int __PropertyOffset_7;

		// Token: 0x040149AC RID: 84396
		internal static int __PropertyOffset_8;

		// Token: 0x040149AD RID: 84397
		internal static int __PropertyOffset_9;

		// Token: 0x040149AE RID: 84398
		private static IntPtr __DisAppearLine_NativeFunctionPtr;

		// Token: 0x040149AF RID: 84399
		private static IntPtr __AppearLine_NativeFunctionPtr;

		// Token: 0x040149B0 RID: 84400
		private static IntPtr __DebugColor_NativeFunctionPtr;

		// Token: 0x040149B1 RID: 84401
		private static IntPtr __ChangeEffectColor_NativeFunctionPtr;

		// Token: 0x040149B2 RID: 84402
		private static IntPtr __ShowEffect_NativeFunctionPtr;

		// Token: 0x040149B3 RID: 84403
		private static IntPtr __HideEffect_NativeFunctionPtr;

		// Token: 0x040149B4 RID: 84404
		private static IntPtr __InitEffect_NativeFunctionPtr;

		// Token: 0x040149B5 RID: 84405
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040149B6 RID: 84406
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040149B7 RID: 84407
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040149B8 RID: 84408
		private static IntPtr __ExecuteUbergraph_BP_GuidePathLine_NativeFunctionPtr;

		// Token: 0x0200A0CF RID: 41167
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ChangeEffectColor_FunctionParams
		{
			// Token: 0x04032D83 RID: 208259
			[FieldOffset(0)]
			public float PercentTime;

			// Token: 0x04032D84 RID: 208260
			[FieldOffset(4)]
			public bool SuddenChange;
		}

		// Token: 0x0200A0D0 RID: 41168
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D85 RID: 208261
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A0D1 RID: 41169
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 36)]
		protected ref struct __ExecuteUbergraph_BP_GuidePathLine_FunctionParams
		{
			// Token: 0x04032D86 RID: 208262
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
