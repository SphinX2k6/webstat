using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Vehicle.Motor.Abilities.Input
{
	// Token: 0x02003FBE RID: 16318
	[UnrealObjectPath("/Game/Aki/Character/Vehicle/Motor/Abilities/Input/BP_InputComponent_Motorcycle.BP_InputComponent_Motorcycle_C")]
	[UnrealStructLayout(616, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 610)]
	public class BP_InputComponent_Motorcycle_C : BP_InputComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028F35 RID: 167733 RVA: 0x00A1BA9F File Offset: 0x00A19C9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InputComponent_Motorcycle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Vehicle/Motor/Abilities/Input/BP_InputComponent_Motorcycle.BP_InputComponent_Motorcycle_C");
			}
			return BP_InputComponent_Motorcycle_C._ClassPtr;
		}

		// Token: 0x06028F36 RID: 167734 RVA: 0x00A1BAC4 File Offset: 0x00A19CC4
		public BP_InputComponent_Motorcycle_C() : this(BuiltinUtils.AllocNativeUObject(BP_InputComponent_Motorcycle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028F37 RID: 167735 RVA: 0x00A1BAEC File Offset: 0x00A19CEC
		[NullableContext(1)]
		public BP_InputComponent_Motorcycle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InputComponent_Motorcycle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170064EA RID: 25834
		// (get) Token: 0x06028F38 RID: 167736 RVA: 0x00A1BB20 File Offset: 0x00A19D20
		// (set) Token: 0x06028F39 RID: 167737 RVA: 0x00A1BB59 File Offset: 0x00A19D59
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170064EB RID: 25835
		// (get) Token: 0x06028F3A RID: 167738 RVA: 0x00A1BB7A File Offset: 0x00A19D7A
		// (set) Token: 0x06028F3B RID: 167739 RVA: 0x00A1BB8A File Offset: 0x00A19D8A
		public unsafe bool 按下跳跃时在地面
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170064EC RID: 25836
		// (get) Token: 0x06028F3C RID: 167740 RVA: 0x00A1BB9B File Offset: 0x00A19D9B
		// (set) Token: 0x06028F3D RID: 167741 RVA: 0x00A1BBAB File Offset: 0x00A19DAB
		public unsafe bool 已释放蓄力跳
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_Motorcycle_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028F3E RID: 167742 RVA: 0x00A1BBBC File Offset: 0x00A19DBC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 走跑切换抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__走跑切换抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__走跑切换抬起_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__走跑切换抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__走跑切换抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__走跑切换抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F3F RID: 167743 RVA: 0x00A1BC10 File Offset: 0x00A19E10
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 大招抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__大招抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__大招抬起_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__大招抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__大招抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__大招抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F40 RID: 167744 RVA: 0x00A1BC68 File Offset: 0x00A19E68
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 大招长按(float time)
		{
			BP_InputComponent_Motorcycle_C.__大招长按_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__大招长按_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__大招长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__大招长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__大招长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F41 RID: 167745 RVA: 0x00A1BCC0 File Offset: 0x00A19EC0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 大招按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__大招按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__大招按下_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__大招按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__大招按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__大招按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F42 RID: 167746 RVA: 0x00A1BD18 File Offset: 0x00A19F18
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 跳跃抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__跳跃抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__跳跃抬起_FunctionParams[(UIntPtr)231] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__跳跃抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F43 RID: 167747 RVA: 0x00A1BD70 File Offset: 0x00A19F70
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 跳跃按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__跳跃按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__跳跃按下_FunctionParams[(UIntPtr)439] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__跳跃按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__跳跃按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__跳跃按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F44 RID: 167748 RVA: 0x00A1BDC8 File Offset: 0x00A19FC8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 走跑切换按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__走跑切换按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__走跑切换按下_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__走跑切换按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F45 RID: 167749 RVA: 0x00A1BE1C File Offset: 0x00A1A01C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 瞄准按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__瞄准按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__瞄准按下_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__瞄准按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__瞄准按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__瞄准按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F46 RID: 167750 RVA: 0x00A1BE70 File Offset: 0x00A1A070
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象1抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__幻象1抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__幻象1抬起_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__幻象1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F47 RID: 167751 RVA: 0x00A1BEC4 File Offset: 0x00A1A0C4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象1按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__幻象1按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__幻象1按下_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__幻象1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__幻象1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__幻象1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F48 RID: 167752 RVA: 0x00A1BF18 File Offset: 0x00A1A118
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__攻击抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__攻击抬起_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__攻击抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__攻击抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__攻击抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F49 RID: 167753 RVA: 0x00A1BF70 File Offset: 0x00A1A170
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击长按(float time)
		{
			BP_InputComponent_Motorcycle_C.__攻击长按_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__攻击长按_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__攻击长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__攻击长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__攻击长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4A RID: 167754 RVA: 0x00A1BFC8 File Offset: 0x00A1A1C8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__攻击按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__攻击按下_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__攻击按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__攻击按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__攻击按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4B RID: 167755 RVA: 0x00A1C020 File Offset: 0x00A1A220
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__技能1抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__技能1抬起_FunctionParams[(UIntPtr)495] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__技能1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__技能1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__技能1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4C RID: 167756 RVA: 0x00A1C078 File Offset: 0x00A1A278
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1长按(float time)
		{
			BP_InputComponent_Motorcycle_C.__技能1长按_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__技能1长按_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__技能1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__技能1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__技能1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4D RID: 167757 RVA: 0x00A1C0D0 File Offset: 0x00A1A2D0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__技能1按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__技能1按下_FunctionParams[(UIntPtr)519] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__技能1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__技能1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__技能1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4E RID: 167758 RVA: 0x00A1C128 File Offset: 0x00A1A328
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 闪避抬起(float time)
		{
			BP_InputComponent_Motorcycle_C.__闪避抬起_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__闪避抬起_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__闪避抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__闪避抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__闪避抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F4F RID: 167759 RVA: 0x00A1C17C File Offset: 0x00A1A37C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 闪避按下(float time)
		{
			BP_InputComponent_Motorcycle_C.__闪避按下_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__闪避按下_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__闪避按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__闪避按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__闪避按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x06028F50 RID: 167760 RVA: 0x00A1C1D0 File Offset: 0x00A1A3D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028F51 RID: 167761 RVA: 0x00A1C21C File Offset: 0x00A1A41C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F52 RID: 167762 RVA: 0x00A1C268 File Offset: 0x00A1A468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InputComponent_Motorcycle(int EntryPoint)
		{
			BP_InputComponent_Motorcycle_C.__ExecuteUbergraph_BP_InputComponent_Motorcycle_FunctionParams* ptr = stackalloc BP_InputComponent_Motorcycle_C.__ExecuteUbergraph_BP_InputComponent_Motorcycle_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InputComponent_Motorcycle_C.__ExecuteUbergraph_BP_InputComponent_Motorcycle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_Motorcycle_C.__ExecuteUbergraph_BP_InputComponent_Motorcycle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InputComponent_Motorcycle_C.__ExecuteUbergraph_BP_InputComponent_Motorcycle_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028F53 RID: 167763 RVA: 0x00A1C2AF File Offset: 0x00A1A4AF
		protected BP_InputComponent_Motorcycle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015AA4 RID: 88740
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Vehicle/Motor/Abilities/Input/BP_InputComponent_Motorcycle.BP_InputComponent_Motorcycle_C";

		// Token: 0x04015AA5 RID: 88741
		private static IntPtr _ClassPtr;

		// Token: 0x04015AA6 RID: 88742
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015AA7 RID: 88743
		internal new static int __PropertyOffset_0;

		// Token: 0x04015AA8 RID: 88744
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015AA9 RID: 88745
		internal new static int __PropertyOffset_1;

		// Token: 0x04015AAA RID: 88746
		internal new static int __PropertyOffset_2;

		// Token: 0x04015AAB RID: 88747
		private static IntPtr __走跑切换抬起_NativeFunctionPtr;

		// Token: 0x04015AAC RID: 88748
		private static IntPtr __大招抬起_NativeFunctionPtr;

		// Token: 0x04015AAD RID: 88749
		private static IntPtr __大招长按_NativeFunctionPtr;

		// Token: 0x04015AAE RID: 88750
		private static IntPtr __大招按下_NativeFunctionPtr;

		// Token: 0x04015AAF RID: 88751
		private static IntPtr __跳跃抬起_NativeFunctionPtr;

		// Token: 0x04015AB0 RID: 88752
		private static IntPtr __跳跃按下_NativeFunctionPtr;

		// Token: 0x04015AB1 RID: 88753
		private static IntPtr __走跑切换按下_NativeFunctionPtr;

		// Token: 0x04015AB2 RID: 88754
		private static IntPtr __瞄准按下_NativeFunctionPtr;

		// Token: 0x04015AB3 RID: 88755
		private static IntPtr __幻象1抬起_NativeFunctionPtr;

		// Token: 0x04015AB4 RID: 88756
		private static IntPtr __幻象1按下_NativeFunctionPtr;

		// Token: 0x04015AB5 RID: 88757
		private static IntPtr __攻击抬起_NativeFunctionPtr;

		// Token: 0x04015AB6 RID: 88758
		private static IntPtr __攻击长按_NativeFunctionPtr;

		// Token: 0x04015AB7 RID: 88759
		private static IntPtr __攻击按下_NativeFunctionPtr;

		// Token: 0x04015AB8 RID: 88760
		private static IntPtr __技能1抬起_NativeFunctionPtr;

		// Token: 0x04015AB9 RID: 88761
		private static IntPtr __技能1长按_NativeFunctionPtr;

		// Token: 0x04015ABA RID: 88762
		private static IntPtr __技能1按下_NativeFunctionPtr;

		// Token: 0x04015ABB RID: 88763
		private static IntPtr __闪避抬起_NativeFunctionPtr;

		// Token: 0x04015ABC RID: 88764
		private static IntPtr __闪避按下_NativeFunctionPtr;

		// Token: 0x04015ABD RID: 88765
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04015ABE RID: 88766
		private static IntPtr __ExecuteUbergraph_BP_InputComponent_Motorcycle_NativeFunctionPtr;

		// Token: 0x0200A16B RID: 41323
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __走跑切换抬起_FunctionParams
		{
			// Token: 0x04032EAD RID: 208557
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EAE RID: 208558
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A16C RID: 41324
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected new ref struct __大招抬起_FunctionParams
		{
			// Token: 0x04032EAF RID: 208559
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EB0 RID: 208560
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A16D RID: 41325
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected new ref struct __大招长按_FunctionParams
		{
			// Token: 0x04032EB1 RID: 208561
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EB2 RID: 208562
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A16E RID: 41326
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected new ref struct __大招按下_FunctionParams
		{
			// Token: 0x04032EB3 RID: 208563
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EB4 RID: 208564
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A16F RID: 41327
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 216)]
		protected new ref struct __跳跃抬起_FunctionParams
		{
			// Token: 0x04032EB5 RID: 208565
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EB6 RID: 208566
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A170 RID: 41328
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 424)]
		protected new ref struct __跳跃按下_FunctionParams
		{
			// Token: 0x04032EB7 RID: 208567
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EB8 RID: 208568
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A171 RID: 41329
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __走跑切换按下_FunctionParams
		{
			// Token: 0x04032EB9 RID: 208569
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EBA RID: 208570
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A172 RID: 41330
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected new ref struct __瞄准按下_FunctionParams
		{
			// Token: 0x04032EBB RID: 208571
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EBC RID: 208572
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A173 RID: 41331
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __幻象1抬起_FunctionParams
		{
			// Token: 0x04032EBD RID: 208573
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EBE RID: 208574
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A174 RID: 41332
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected new ref struct __幻象1按下_FunctionParams
		{
			// Token: 0x04032EBF RID: 208575
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EC0 RID: 208576
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A175 RID: 41333
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected new ref struct __攻击抬起_FunctionParams
		{
			// Token: 0x04032EC1 RID: 208577
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EC2 RID: 208578
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A176 RID: 41334
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected new ref struct __攻击长按_FunctionParams
		{
			// Token: 0x04032EC3 RID: 208579
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EC4 RID: 208580
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A177 RID: 41335
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected new ref struct __攻击按下_FunctionParams
		{
			// Token: 0x04032EC5 RID: 208581
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EC6 RID: 208582
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A178 RID: 41336
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 480)]
		protected new ref struct __技能1抬起_FunctionParams
		{
			// Token: 0x04032EC7 RID: 208583
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032EC8 RID: 208584
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A179 RID: 41337
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected new ref struct __技能1长按_FunctionParams
		{
			// Token: 0x04032EC9 RID: 208585
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032ECA RID: 208586
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A17A RID: 41338
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 504)]
		protected new ref struct __技能1按下_FunctionParams
		{
			// Token: 0x04032ECB RID: 208587
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032ECC RID: 208588
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A17B RID: 41339
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected new ref struct __闪避抬起_FunctionParams
		{
			// Token: 0x04032ECD RID: 208589
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032ECE RID: 208590
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A17C RID: 41340
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected new ref struct __闪避按下_FunctionParams
		{
			// Token: 0x04032ECF RID: 208591
			[FieldOffset(0)]
			public float time;

			// Token: 0x04032ED0 RID: 208592
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A17D RID: 41341
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04032ED1 RID: 208593
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A17E RID: 41342
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_InputComponent_Motorcycle_FunctionParams
		{
			// Token: 0x04032ED2 RID: 208594
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
