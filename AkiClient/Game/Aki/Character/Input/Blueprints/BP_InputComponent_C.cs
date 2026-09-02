using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B3 RID: 16819
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/BP_InputComponent.BP_InputComponent_C")]
	[UnrealStructLayout(592, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 591)]
	public class BP_InputComponent_C : BP_InputBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CABA RID: 182970 RVA: 0x00AAA99C File Offset: 0x00AA8B9C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InputComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/BP_InputComponent.BP_InputComponent_C");
			}
			return BP_InputComponent_C._ClassPtr;
		}

		// Token: 0x0602CABB RID: 182971 RVA: 0x00AAA9C0 File Offset: 0x00AA8BC0
		public BP_InputComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_InputComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CABC RID: 182972 RVA: 0x00AAA9E8 File Offset: 0x00AA8BE8
		[NullableContext(1)]
		public BP_InputComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InputComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007873 RID: 30835
		// (get) Token: 0x0602CABD RID: 182973 RVA: 0x00AAAA1C File Offset: 0x00AA8C1C
		// (set) Token: 0x0602CABE RID: 182974 RVA: 0x00AAAA55 File Offset: 0x00AA8C55
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EInputAction>, SInputCaches> 输入缓存
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EInputAction>, SInputCaches> result;
				if ((result = this._输入缓存) == null)
				{
					result = (this._输入缓存 = new TMap<TEnumAsByte<EInputAction>, SInputCaches>(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.输入缓存.CopyAssign(value);
			}
		}

		// Token: 0x17007874 RID: 30836
		// (get) Token: 0x0602CABF RID: 182975 RVA: 0x00AAAA64 File Offset: 0x00AA8C64
		// (set) Token: 0x0602CAC0 RID: 182976 RVA: 0x00AAAA9D File Offset: 0x00AA8C9D
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<EInputAction>, SInputHoldConfig> 长按配置
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EInputAction>, SInputHoldConfig> result;
				if ((result = this._长按配置) == null)
				{
					result = (this._长按配置 = new TMap<TEnumAsByte<EInputAction>, SInputHoldConfig>(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_1, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.长按配置.CopyAssign(value);
			}
		}

		// Token: 0x17007875 RID: 30837
		// (get) Token: 0x0602CAC1 RID: 182977 RVA: 0x00AAAAAB File Offset: 0x00AA8CAB
		// (set) Token: 0x0602CAC2 RID: 182978 RVA: 0x00AAAABB File Offset: 0x00AA8CBB
		public unsafe bool 通用_攻击按下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007876 RID: 30838
		// (get) Token: 0x0602CAC3 RID: 182979 RVA: 0x00AAAACC File Offset: 0x00AA8CCC
		// (set) Token: 0x0602CAC4 RID: 182980 RVA: 0x00AAAADC File Offset: 0x00AA8CDC
		public unsafe bool 锁定退出
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007877 RID: 30839
		// (get) Token: 0x0602CAC5 RID: 182981 RVA: 0x00AAAAED File Offset: 0x00AA8CED
		// (set) Token: 0x0602CAC6 RID: 182982 RVA: 0x00AAAAFD File Offset: 0x00AA8CFD
		public unsafe bool 通用_技能1按下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007878 RID: 30840
		// (get) Token: 0x0602CAC7 RID: 182983 RVA: 0x00AAAB0E File Offset: 0x00AA8D0E
		// (set) Token: 0x0602CAC8 RID: 182984 RVA: 0x00AAAB1E File Offset: 0x00AA8D1E
		public unsafe bool 锁定切换
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007879 RID: 30841
		// (get) Token: 0x0602CAC9 RID: 182985 RVA: 0x00AAAB2F File Offset: 0x00AA8D2F
		// (set) Token: 0x0602CACA RID: 182986 RVA: 0x00AAAB3F File Offset: 0x00AA8D3F
		public unsafe bool 通用_瞄准按下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700787A RID: 30842
		// (get) Token: 0x0602CACB RID: 182987 RVA: 0x00AAAB50 File Offset: 0x00AA8D50
		// (set) Token: 0x0602CACC RID: 182988 RVA: 0x00AAAB60 File Offset: 0x00AA8D60
		public unsafe bool 是否进入闪避通用
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700787B RID: 30843
		// (get) Token: 0x0602CACD RID: 182989 RVA: 0x00AAAB71 File Offset: 0x00AA8D71
		// (set) Token: 0x0602CACE RID: 182990 RVA: 0x00AAAB81 File Offset: 0x00AA8D81
		public unsafe bool 通用_攻击长按
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputComponent_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CACF RID: 182991 RVA: 0x00AAAB94 File Offset: 0x00AA8D94
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 特殊探索技能(ref bool Result, ref SInputCommand 指令)
		{
			BP_InputComponent_C.__特殊探索技能_FunctionParams* ptr = stackalloc BP_InputComponent_C.__特殊探索技能_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputComponent_C.__特殊探索技能_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__特殊探索技能_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Result = Result;
			if (指令 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SInputCommand.StaticStruct(), &ptr->指令, 指令.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__特殊探索技能_NativeFunctionPtr, (void*)ptr);
			Result = ptr->Result;
			if (指令 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(SInputCommand.StaticStruct(), 指令.NativePtr, &ptr->指令, 1, false);
			}
		}

		// Token: 0x0602CAD0 RID: 182992 RVA: 0x00AAAC2C File Offset: 0x00AA8E2C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 瞄准按下事件(float time)
		{
			BP_InputComponent_C.__瞄准按下事件_FunctionParams* ptr = stackalloc BP_InputComponent_C.__瞄准按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputComponent_C.__瞄准按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__瞄准按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__瞄准按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAD1 RID: 182993 RVA: 0x00AAAC74 File Offset: 0x00AA8E74
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象2长按(float time)
		{
			BP_InputComponent_C.__幻象2长按_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象2长按_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__幻象2长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象2长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象2长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD2 RID: 182994 RVA: 0x00AAACC8 File Offset: 0x00AA8EC8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 瞄准按下(float time)
		{
			BP_InputComponent_C.__瞄准按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__瞄准按下_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__瞄准按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__瞄准按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__瞄准按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD3 RID: 182995 RVA: 0x00AAAD1C File Offset: 0x00AA8F1C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象2抬起(float time)
		{
			BP_InputComponent_C.__幻象2抬起_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象2抬起_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__幻象2抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象2抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象2抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD4 RID: 182996 RVA: 0x00AAAD70 File Offset: 0x00AA8F70
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 技能1按下(float time)
		{
			BP_InputComponent_C.__技能1按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__技能1按下_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__技能1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__技能1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__技能1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD5 RID: 182997 RVA: 0x00AAADC4 File Offset: 0x00AA8FC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 锁定目标按下事件(float time)
		{
			BP_InputComponent_C.__锁定目标按下事件_FunctionParams* ptr = stackalloc BP_InputComponent_C.__锁定目标按下事件_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_InputComponent_C.__锁定目标按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__锁定目标按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__锁定目标按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAD6 RID: 182998 RVA: 0x00AAAE0C File Offset: 0x00AA900C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 通用交互按下(float time)
		{
			BP_InputComponent_C.__通用交互按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__通用交互按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputComponent_C.__通用交互按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__通用交互按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__通用交互按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD7 RID: 182999 RVA: 0x00AAAE60 File Offset: 0x00AA9060
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击长按(float time)
		{
			BP_InputComponent_C.__攻击长按_FunctionParams* ptr = stackalloc BP_InputComponent_C.__攻击长按_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_InputComponent_C.__攻击长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__攻击长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__攻击长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD8 RID: 183000 RVA: 0x00AAAEB4 File Offset: 0x00AA90B4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攻击按下(float time)
		{
			BP_InputComponent_C.__攻击按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__攻击按下_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_InputComponent_C.__攻击按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__攻击按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__攻击按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAD9 RID: 183001 RVA: 0x00AAAF0C File Offset: 0x00AA910C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 锁定目标抬起事件(float time)
		{
			BP_InputComponent_C.__锁定目标抬起事件_FunctionParams* ptr = stackalloc BP_InputComponent_C.__锁定目标抬起事件_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_InputComponent_C.__锁定目标抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__锁定目标抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__锁定目标抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CADA RID: 183002 RVA: 0x00AAAF54 File Offset: 0x00AA9154
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputHoldConfig GetUnrealHoldConfig(int action)
		{
			BP_InputComponent_C.__GetUnrealHoldConfig_FunctionParams* ptr = stackalloc BP_InputComponent_C.__GetUnrealHoldConfig_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_InputComponent_C.__GetUnrealHoldConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__GetUnrealHoldConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->action = action;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__GetUnrealHoldConfig_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CADB RID: 183003 RVA: 0x00AAAFA0 File Offset: 0x00AA91A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCaches GetUnrealCacheConfig(int action)
		{
			BP_InputComponent_C.__GetUnrealCacheConfig_FunctionParams* ptr = stackalloc BP_InputComponent_C.__GetUnrealCacheConfig_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_InputComponent_C.__GetUnrealCacheConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__GetUnrealCacheConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->action = action;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__GetUnrealCacheConfig_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CADC RID: 183004 RVA: 0x00AAAFEC File Offset: 0x00AA91EC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象2按下(float time)
		{
			BP_InputComponent_C.__幻象2按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象2按下_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_InputComponent_C.__幻象2按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象2按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象2按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CADD RID: 183005 RVA: 0x00AAB040 File Offset: 0x00AA9240
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象1长按(float time)
		{
			BP_InputComponent_C.__幻象1长按_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象1长按_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__幻象1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CADE RID: 183006 RVA: 0x00AAB094 File Offset: 0x00AA9294
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象1抬起(float time)
		{
			BP_InputComponent_C.__幻象1抬起_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象1抬起_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(BP_InputComponent_C.__幻象1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CADF RID: 183007 RVA: 0x00AAB0EC File Offset: 0x00AA92EC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 幻象1按下(float time)
		{
			BP_InputComponent_C.__幻象1按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__幻象1按下_FunctionParams[(UIntPtr)279] + 15L / (long)sizeof(BP_InputComponent_C.__幻象1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__幻象1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__幻象1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE0 RID: 183008 RVA: 0x00AAB144 File Offset: 0x00AA9344
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 闪避抬起(float time)
		{
			BP_InputComponent_C.__闪避抬起_FunctionParams* ptr = stackalloc BP_InputComponent_C.__闪避抬起_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_InputComponent_C.__闪避抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__闪避抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__闪避抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE1 RID: 183009 RVA: 0x00AAB19C File Offset: 0x00AA939C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 闪避按下(float time)
		{
			BP_InputComponent_C.__闪避按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__闪避按下_FunctionParams[(UIntPtr)839] + 15L / (long)sizeof(BP_InputComponent_C.__闪避按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__闪避按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__闪避按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE2 RID: 183010 RVA: 0x00AAB1F4 File Offset: 0x00AA93F4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攀爬抬起(float time)
		{
			BP_InputComponent_C.__攀爬抬起_FunctionParams* ptr = stackalloc BP_InputComponent_C.__攀爬抬起_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_InputComponent_C.__攀爬抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__攀爬抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__攀爬抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE3 RID: 183011 RVA: 0x00AAB248 File Offset: 0x00AA9448
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void 跳跃按下事件(float time)
		{
			BP_InputComponent_C.__跳跃按下事件_FunctionParams* ptr = stackalloc BP_InputComponent_C.__跳跃按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputComponent_C.__跳跃按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__跳跃按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__跳跃按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAE4 RID: 183012 RVA: 0x00AAB290 File Offset: 0x00AA9490
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 锁定目标长按(float time)
		{
			BP_InputComponent_C.__锁定目标长按_FunctionParams* ptr = stackalloc BP_InputComponent_C.__锁定目标长按_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(BP_InputComponent_C.__锁定目标长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__锁定目标长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__锁定目标长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE5 RID: 183013 RVA: 0x00AAB2E4 File Offset: 0x00AA94E4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 走跑切换按下(float time)
		{
			BP_InputComponent_C.__走跑切换按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__走跑切换按下_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_InputComponent_C.__走跑切换按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE6 RID: 183014 RVA: 0x00AAB338 File Offset: 0x00AA9538
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 攀爬按下(float time)
		{
			BP_InputComponent_C.__攀爬按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__攀爬按下_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_InputComponent_C.__攀爬按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__攀爬按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__攀爬按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE7 RID: 183015 RVA: 0x00AAB38C File Offset: 0x00AA958C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 跳跃抬起(float time)
		{
			BP_InputComponent_C.__跳跃抬起_FunctionParams* ptr = stackalloc BP_InputComponent_C.__跳跃抬起_FunctionParams[(UIntPtr)59] + 15L / (long)sizeof(BP_InputComponent_C.__跳跃抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE8 RID: 183016 RVA: 0x00AAB3E0 File Offset: 0x00AA95E0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override SInputCommand 跳跃按下(float time)
		{
			BP_InputComponent_C.__跳跃按下_FunctionParams* ptr = stackalloc BP_InputComponent_C.__跳跃按下_FunctionParams[(UIntPtr)183] + 15L / (long)sizeof(BP_InputComponent_C.__跳跃按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputComponent_C.__跳跃按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputComponent_C.__跳跃按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CAE9 RID: 183017 RVA: 0x00AAB437 File Offset: 0x00AA9637
		protected BP_InputComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018E0F RID: 101903
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/BP_InputComponent.BP_InputComponent_C";

		// Token: 0x04018E10 RID: 101904
		private static IntPtr _ClassPtr;

		// Token: 0x04018E11 RID: 101905
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018E12 RID: 101906
		internal new static int __PropertyOffset_0;

		// Token: 0x04018E13 RID: 101907
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EInputAction>, SInputCaches> _输入缓存;

		// Token: 0x04018E14 RID: 101908
		internal new static int __PropertyOffset_1;

		// Token: 0x04018E15 RID: 101909
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<EInputAction>, SInputHoldConfig> _长按配置;

		// Token: 0x04018E16 RID: 101910
		internal new static int __PropertyOffset_2;

		// Token: 0x04018E17 RID: 101911
		internal new static int __PropertyOffset_3;

		// Token: 0x04018E18 RID: 101912
		internal new static int __PropertyOffset_4;

		// Token: 0x04018E19 RID: 101913
		internal new static int __PropertyOffset_5;

		// Token: 0x04018E1A RID: 101914
		internal new static int __PropertyOffset_6;

		// Token: 0x04018E1B RID: 101915
		internal static int __PropertyOffset_7;

		// Token: 0x04018E1C RID: 101916
		internal static int __PropertyOffset_8;

		// Token: 0x04018E1D RID: 101917
		private static IntPtr __特殊探索技能_NativeFunctionPtr;

		// Token: 0x04018E1E RID: 101918
		private static IntPtr __瞄准按下事件_NativeFunctionPtr;

		// Token: 0x04018E1F RID: 101919
		private static IntPtr __幻象2长按_NativeFunctionPtr;

		// Token: 0x04018E20 RID: 101920
		private static IntPtr __瞄准按下_NativeFunctionPtr;

		// Token: 0x04018E21 RID: 101921
		private static IntPtr __幻象2抬起_NativeFunctionPtr;

		// Token: 0x04018E22 RID: 101922
		private static IntPtr __技能1按下_NativeFunctionPtr;

		// Token: 0x04018E23 RID: 101923
		private static IntPtr __锁定目标按下事件_NativeFunctionPtr;

		// Token: 0x04018E24 RID: 101924
		private static IntPtr __通用交互按下_NativeFunctionPtr;

		// Token: 0x04018E25 RID: 101925
		private static IntPtr __攻击长按_NativeFunctionPtr;

		// Token: 0x04018E26 RID: 101926
		private static IntPtr __攻击按下_NativeFunctionPtr;

		// Token: 0x04018E27 RID: 101927
		private static IntPtr __锁定目标抬起事件_NativeFunctionPtr;

		// Token: 0x04018E28 RID: 101928
		private static IntPtr __GetUnrealHoldConfig_NativeFunctionPtr;

		// Token: 0x04018E29 RID: 101929
		private static IntPtr __GetUnrealCacheConfig_NativeFunctionPtr;

		// Token: 0x04018E2A RID: 101930
		private static IntPtr __幻象2按下_NativeFunctionPtr;

		// Token: 0x04018E2B RID: 101931
		private static IntPtr __幻象1长按_NativeFunctionPtr;

		// Token: 0x04018E2C RID: 101932
		private static IntPtr __幻象1抬起_NativeFunctionPtr;

		// Token: 0x04018E2D RID: 101933
		private static IntPtr __幻象1按下_NativeFunctionPtr;

		// Token: 0x04018E2E RID: 101934
		private static IntPtr __闪避抬起_NativeFunctionPtr;

		// Token: 0x04018E2F RID: 101935
		private static IntPtr __闪避按下_NativeFunctionPtr;

		// Token: 0x04018E30 RID: 101936
		private static IntPtr __攀爬抬起_NativeFunctionPtr;

		// Token: 0x04018E31 RID: 101937
		private static IntPtr __跳跃按下事件_NativeFunctionPtr;

		// Token: 0x04018E32 RID: 101938
		private static IntPtr __锁定目标长按_NativeFunctionPtr;

		// Token: 0x04018E33 RID: 101939
		private static IntPtr __走跑切换按下_NativeFunctionPtr;

		// Token: 0x04018E34 RID: 101940
		private static IntPtr __攀爬按下_NativeFunctionPtr;

		// Token: 0x04018E35 RID: 101941
		private static IntPtr __跳跃抬起_NativeFunctionPtr;

		// Token: 0x04018E36 RID: 101942
		private static IntPtr __跳跃按下_NativeFunctionPtr;

		// Token: 0x0200A4C2 RID: 42178
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __特殊探索技能_FunctionParams
		{
			// Token: 0x04033303 RID: 209667
			[FieldOffset(0)]
			public bool Result;

			// Token: 0x04033304 RID: 209668
			[FieldOffset(4)]
			public byte 指令;
		}

		// Token: 0x0200A4C3 RID: 42179
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __瞄准按下事件_FunctionParams
		{
			// Token: 0x04033305 RID: 209669
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4C4 RID: 42180
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __幻象2长按_FunctionParams
		{
			// Token: 0x04033306 RID: 209670
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033307 RID: 209671
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4C5 RID: 42181
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __瞄准按下_FunctionParams
		{
			// Token: 0x04033308 RID: 209672
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033309 RID: 209673
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4C6 RID: 42182
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __幻象2抬起_FunctionParams
		{
			// Token: 0x0403330A RID: 209674
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403330B RID: 209675
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4C7 RID: 42183
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __技能1按下_FunctionParams
		{
			// Token: 0x0403330C RID: 209676
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403330D RID: 209677
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4C8 RID: 42184
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected new ref struct __锁定目标按下事件_FunctionParams
		{
			// Token: 0x0403330E RID: 209678
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4C9 RID: 42185
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected new ref struct __通用交互按下_FunctionParams
		{
			// Token: 0x0403330F RID: 209679
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033310 RID: 209680
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4CA RID: 42186
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected new ref struct __攻击长按_FunctionParams
		{
			// Token: 0x04033311 RID: 209681
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033312 RID: 209682
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4CB RID: 42187
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected new ref struct __攻击按下_FunctionParams
		{
			// Token: 0x04033313 RID: 209683
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033314 RID: 209684
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4CC RID: 42188
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected new ref struct __锁定目标抬起事件_FunctionParams
		{
			// Token: 0x04033315 RID: 209685
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4CD RID: 42189
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected new ref struct __GetUnrealHoldConfig_FunctionParams
		{
			// Token: 0x04033316 RID: 209686
			[FieldOffset(0)]
			public int action;

			// Token: 0x04033317 RID: 209687
			[FieldOffset(4)]
			public SInputHoldConfig __Result;
		}

		// Token: 0x0200A4CE RID: 42190
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected new ref struct __GetUnrealCacheConfig_FunctionParams
		{
			// Token: 0x04033318 RID: 209688
			[FieldOffset(0)]
			public int action;

			// Token: 0x04033319 RID: 209689
			[FieldOffset(4)]
			public SInputCaches __Result;
		}

		// Token: 0x0200A4CF RID: 42191
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected new ref struct __幻象2按下_FunctionParams
		{
			// Token: 0x0403331A RID: 209690
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403331B RID: 209691
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D0 RID: 42192
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __幻象1长按_FunctionParams
		{
			// Token: 0x0403331C RID: 209692
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403331D RID: 209693
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D1 RID: 42193
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected new ref struct __幻象1抬起_FunctionParams
		{
			// Token: 0x0403331E RID: 209694
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403331F RID: 209695
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D2 RID: 42194
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 264)]
		protected new ref struct __幻象1按下_FunctionParams
		{
			// Token: 0x04033320 RID: 209696
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033321 RID: 209697
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D3 RID: 42195
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected new ref struct __闪避抬起_FunctionParams
		{
			// Token: 0x04033322 RID: 209698
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033323 RID: 209699
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D4 RID: 42196
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 824)]
		protected new ref struct __闪避按下_FunctionParams
		{
			// Token: 0x04033324 RID: 209700
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033325 RID: 209701
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D5 RID: 42197
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected new ref struct __攀爬抬起_FunctionParams
		{
			// Token: 0x04033326 RID: 209702
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033327 RID: 209703
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D6 RID: 42198
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __跳跃按下事件_FunctionParams
		{
			// Token: 0x04033328 RID: 209704
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4D7 RID: 42199
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected new ref struct __锁定目标长按_FunctionParams
		{
			// Token: 0x04033329 RID: 209705
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403332A RID: 209706
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D8 RID: 42200
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected new ref struct __走跑切换按下_FunctionParams
		{
			// Token: 0x0403332B RID: 209707
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403332C RID: 209708
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4D9 RID: 42201
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected new ref struct __攀爬按下_FunctionParams
		{
			// Token: 0x0403332D RID: 209709
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403332E RID: 209710
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4DA RID: 42202
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 44)]
		protected new ref struct __跳跃抬起_FunctionParams
		{
			// Token: 0x0403332F RID: 209711
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033330 RID: 209712
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4DB RID: 42203
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 168)]
		protected new ref struct __跳跃按下_FunctionParams
		{
			// Token: 0x04033331 RID: 209713
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033332 RID: 209714
			[FieldOffset(4)]
			public byte __Result;
		}
	}
}
