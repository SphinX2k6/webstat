using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA042.Abilities.Input
{
	// Token: 0x0200414B RID: 16715
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA042/Abilities/Input/BP_Input_Temple.BP_Input_Temple_C")]
	[UnrealStructLayout(600, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 596)]
	public class BP_Input_Temple_C : BP_InputComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C644 RID: 181828 RVA: 0x00A9FC60 File Offset: 0x00A9DE60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Input_Temple_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA042/Abilities/Input/BP_Input_Temple.BP_Input_Temple_C");
			}
			return BP_Input_Temple_C._ClassPtr;
		}

		// Token: 0x0602C645 RID: 181829 RVA: 0x00A9FC84 File Offset: 0x00A9DE84
		public BP_Input_Temple_C() : this(BuiltinUtils.AllocNativeUObject(BP_Input_Temple_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C646 RID: 181830 RVA: 0x00A9FCAC File Offset: 0x00A9DEAC
		[NullableContext(1)]
		public BP_Input_Temple_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Input_Temple_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700776C RID: 30572
		// (get) Token: 0x0602C647 RID: 181831 RVA: 0x00A9FCDF File Offset: 0x00A9DEDF
		// (set) Token: 0x0602C648 RID: 181832 RVA: 0x00A9FCEF File Offset: 0x00A9DEEF
		public unsafe float 散华蓄力值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Input_Temple_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Input_Temple_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602C649 RID: 181833 RVA: 0x00A9FD00 File Offset: 0x00A9DF00
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 瞄准按下(float time)
		{
			BP_Input_Temple_C.__瞄准按下_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__瞄准按下_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__瞄准按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__瞄准按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__瞄准按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64A RID: 181834 RVA: 0x00A9FD54 File Offset: 0x00A9DF54
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1抬起(float time)
		{
			BP_Input_Temple_C.__技能1抬起_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__技能1抬起_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__技能1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__技能1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__技能1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64B RID: 181835 RVA: 0x00A9FDA8 File Offset: 0x00A9DFA8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1长按(float time)
		{
			BP_Input_Temple_C.__技能1长按_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__技能1长按_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__技能1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__技能1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__技能1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64C RID: 181836 RVA: 0x00A9FDFC File Offset: 0x00A9DFFC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1按下(float time)
		{
			BP_Input_Temple_C.__技能1按下_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__技能1按下_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__技能1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__技能1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__技能1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64D RID: 181837 RVA: 0x00A9FE50 File Offset: 0x00A9E050
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击抬起(float time)
		{
			BP_Input_Temple_C.__攻击抬起_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__攻击抬起_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__攻击抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__攻击抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__攻击抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64E RID: 181838 RVA: 0x00A9FEA4 File Offset: 0x00A9E0A4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击长按(float time)
		{
			BP_Input_Temple_C.__攻击长按_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__攻击长按_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__攻击长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__攻击长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__攻击长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C64F RID: 181839 RVA: 0x00A9FEF8 File Offset: 0x00A9E0F8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击按下(float time)
		{
			BP_Input_Temple_C.__攻击按下_FunctionParams* ptr = stackalloc BP_Input_Temple_C.__攻击按下_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_Input_Temple_C.__攻击按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Input_Temple_C.__攻击按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Input_Temple_C.__攻击按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602C650 RID: 181840 RVA: 0x00A9FF4C File Offset: 0x00A9E14C
		protected BP_Input_Temple_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A4F RID: 100943
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA042/Abilities/Input/BP_Input_Temple.BP_Input_Temple_C";

		// Token: 0x04018A50 RID: 100944
		private static IntPtr _ClassPtr;

		// Token: 0x04018A51 RID: 100945
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018A52 RID: 100946
		internal new static int __PropertyOffset_0;

		// Token: 0x04018A53 RID: 100947
		private static IntPtr __瞄准按下_NativeFunctionPtr;

		// Token: 0x04018A54 RID: 100948
		private static IntPtr __技能1抬起_NativeFunctionPtr;

		// Token: 0x04018A55 RID: 100949
		private static IntPtr __技能1长按_NativeFunctionPtr;

		// Token: 0x04018A56 RID: 100950
		private static IntPtr __技能1按下_NativeFunctionPtr;

		// Token: 0x04018A57 RID: 100951
		private static IntPtr __攻击抬起_NativeFunctionPtr;

		// Token: 0x04018A58 RID: 100952
		private static IntPtr __攻击长按_NativeFunctionPtr;

		// Token: 0x04018A59 RID: 100953
		private static IntPtr __攻击按下_NativeFunctionPtr;

		// Token: 0x0200A444 RID: 42052
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __瞄准按下_FunctionParams
		{
			// Token: 0x0403323F RID: 209471
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033240 RID: 209472
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A445 RID: 42053
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __技能1抬起_FunctionParams
		{
			// Token: 0x04033241 RID: 209473
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033242 RID: 209474
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A446 RID: 42054
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __技能1长按_FunctionParams
		{
			// Token: 0x04033243 RID: 209475
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033244 RID: 209476
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A447 RID: 42055
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __技能1按下_FunctionParams
		{
			// Token: 0x04033245 RID: 209477
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033246 RID: 209478
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A448 RID: 42056
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __攻击抬起_FunctionParams
		{
			// Token: 0x04033247 RID: 209479
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033248 RID: 209480
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A449 RID: 42057
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __攻击长按_FunctionParams
		{
			// Token: 0x04033249 RID: 209481
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403324A RID: 209482
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A44A RID: 42058
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __攻击按下_FunctionParams
		{
			// Token: 0x0403324B RID: 209483
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403324C RID: 209484
			[FieldOffset(4)]
			public byte __Result;
		}
	}
}
