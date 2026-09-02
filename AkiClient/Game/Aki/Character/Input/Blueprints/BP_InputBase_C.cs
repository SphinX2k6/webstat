using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Blueprints
{
	// Token: 0x020041B2 RID: 16818
	[UnrealObjectPath("/Game/Aki/Character/Input/Blueprints/BP_InputBase.BP_InputBase_C")]
	[UnrealStructLayout(424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 424)]
	public class BP_InputBase_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CA53 RID: 182867 RVA: 0x00AA8CFB File Offset: 0x00AA6EFB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InputBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Input/Blueprints/BP_InputBase.BP_InputBase_C");
			}
			return BP_InputBase_C._ClassPtr;
		}

		// Token: 0x0602CA54 RID: 182868 RVA: 0x00AA8D20 File Offset: 0x00AA6F20
		public BP_InputBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_InputBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CA55 RID: 182869 RVA: 0x00AA8D48 File Offset: 0x00AA6F48
		[NullableContext(1)]
		public BP_InputBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InputBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700786C RID: 30828
		// (get) Token: 0x0602CA56 RID: 182870 RVA: 0x00AA8D7C File Offset: 0x00AA6F7C
		// (set) Token: 0x0602CA57 RID: 182871 RVA: 0x00AA8DB5 File Offset: 0x00AA6FB5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700786D RID: 30829
		// (get) Token: 0x0602CA58 RID: 182872 RVA: 0x00AA8DD6 File Offset: 0x00AA6FD6
		// (set) Token: 0x0602CA59 RID: 182873 RVA: 0x00AA8DEA File Offset: 0x00AA6FEA
		[Nullable(2)]
		public unsafe ABaseCharacter OwnerActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ABaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InputBase_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InputBase_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700786E RID: 30830
		// (get) Token: 0x0602CA5A RID: 182874 RVA: 0x00AA8DFF File Offset: 0x00AA6FFF
		// (set) Token: 0x0602CA5B RID: 182875 RVA: 0x00AA8E0F File Offset: 0x00AA700F
		public unsafe float UnlockLongPressTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700786F RID: 30831
		// (get) Token: 0x0602CA5C RID: 182876 RVA: 0x00AA8E20 File Offset: 0x00AA7020
		// (set) Token: 0x0602CA5D RID: 182877 RVA: 0x00AA8E30 File Offset: 0x00AA7030
		public unsafe float IsLockOnState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007870 RID: 30832
		// (get) Token: 0x0602CA5E RID: 182878 RVA: 0x00AA8E44 File Offset: 0x00AA7044
		// (set) Token: 0x0602CA5F RID: 182879 RVA: 0x00AA8E7D File Offset: 0x00AA707D
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> InputShowMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> result;
				if ((result = this._InputShowMap) == null)
				{
					result = (this._InputShowMap = new TMap<TEnumAsByte<EInputCharacterState>, SInputShowList>(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.InputShowMap.CopyAssign(value);
			}
		}

		// Token: 0x17007871 RID: 30833
		// (get) Token: 0x0602CA60 RID: 182880 RVA: 0x00AA8E8C File Offset: 0x00AA708C
		// (set) Token: 0x0602CA61 RID: 182881 RVA: 0x00AA8EC5 File Offset: 0x00AA70C5
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> MobileInputShowMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> result;
				if ((result = this._MobileInputShowMap) == null)
				{
					result = (this._MobileInputShowMap = new TMap<TEnumAsByte<EInputCharacterState>, SInputShowList>(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.MobileInputShowMap.CopyAssign(value);
			}
		}

		// Token: 0x17007872 RID: 30834
		// (get) Token: 0x0602CA62 RID: 182882 RVA: 0x00AA8ED4 File Offset: 0x00AA70D4
		// (set) Token: 0x0602CA63 RID: 182883 RVA: 0x00AA8F0D File Offset: 0x00AA710D
		[Nullable(1)]
		public SInputActive 激活移动输入映射按键事件
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SInputActive result;
				if ((result = this._激活移动输入映射按键事件) == null)
				{
					result = (this._激活移动输入映射按键事件 = new SInputActive(base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_6, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SInputActive.StaticStruct(), base.NativePtr + (IntPtr)BP_InputBase_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CA64 RID: 182884 RVA: 0x00AA8F30 File Offset: 0x00AA7130
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 移动输入抬起事件(float time, float yaw)
		{
			BP_InputBase_C.__移动输入抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__移动输入抬起事件_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InputBase_C.__移动输入抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__移动输入抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			ptr->yaw = yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__移动输入抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA65 RID: 182885 RVA: 0x00AA8F80 File Offset: 0x00AA7180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 移动输入按下事件(float time, float yaw)
		{
			BP_InputBase_C.__移动输入按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__移动输入按下事件_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InputBase_C.__移动输入按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__移动输入按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			ptr->yaw = yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__移动输入按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA66 RID: 182886 RVA: 0x00AA8FD0 File Offset: 0x00AA71D0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 移动输入长按(float time, float yaw)
		{
			BP_InputBase_C.__移动输入长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__移动输入长按_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_InputBase_C.__移动输入长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__移动输入长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			ptr->yaw = yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__移动输入长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA67 RID: 182887 RVA: 0x00AA902C File Offset: 0x00AA722C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 移动输入抬起(float time, float yaw)
		{
			BP_InputBase_C.__移动输入抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__移动输入抬起_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_InputBase_C.__移动输入抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__移动输入抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			ptr->yaw = yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__移动输入抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA68 RID: 182888 RVA: 0x00AA9088 File Offset: 0x00AA7288
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 移动输入按下(float time, float yaw)
		{
			BP_InputBase_C.__移动输入按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__移动输入按下_FunctionParams[(UIntPtr)43] + 15L / (long)sizeof(BP_InputBase_C.__移动输入按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__移动输入按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			ptr->yaw = yaw;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__移动输入按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA69 RID: 182889 RVA: 0x00AA90E4 File Offset: 0x00AA72E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 下降抬起事件(float time)
		{
			BP_InputBase_C.__下降抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__下降抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__下降抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__下降抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__下降抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA6A RID: 182890 RVA: 0x00AA912C File Offset: 0x00AA732C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 下降按下事件(float time)
		{
			BP_InputBase_C.__下降按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__下降按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__下降按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__下降按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__下降按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA6B RID: 182891 RVA: 0x00AA9174 File Offset: 0x00AA7374
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 下降长按(float time)
		{
			BP_InputBase_C.__下降长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__下降长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__下降长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__下降长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__下降长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA6C RID: 182892 RVA: 0x00AA91C8 File Offset: 0x00AA73C8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 下降抬起(float time)
		{
			BP_InputBase_C.__下降抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__下降抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__下降抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__下降抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__下降抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA6D RID: 182893 RVA: 0x00AA921C File Offset: 0x00AA741C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 下降按下(float time)
		{
			BP_InputBase_C.__下降按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__下降按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__下降按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__下降按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__下降按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA6E RID: 182894 RVA: 0x00AA9270 File Offset: 0x00AA7470
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMoveVector(ref FVector2D ReturnVaule)
		{
			BP_InputBase_C.__GetMoveVector_FunctionParams* ptr = stackalloc BP_InputBase_C.__GetMoveVector_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InputBase_C.__GetMoveVector_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__GetMoveVector_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ReturnVaule = ReturnVaule;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__GetMoveVector_NativeFunctionPtr, (void*)ptr);
			ReturnVaule = ptr->ReturnVaule;
		}

		// Token: 0x0602CA6F RID: 182895 RVA: 0x00AA92C8 File Offset: 0x00AA74C8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 通用交互按下(float time)
		{
			BP_InputBase_C.__通用交互按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__通用交互按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__通用交互按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__通用交互按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__通用交互按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA70 RID: 182896 RVA: 0x00AA931C File Offset: 0x00AA751C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 锁定目标长按(float time)
		{
			BP_InputBase_C.__锁定目标长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__锁定目标长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__锁定目标长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__锁定目标长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__锁定目标长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA71 RID: 182897 RVA: 0x00AA9370 File Offset: 0x00AA7570
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 瞄准长按(float time)
		{
			BP_InputBase_C.__瞄准长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__瞄准长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__瞄准长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__瞄准长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__瞄准长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA72 RID: 182898 RVA: 0x00AA93C4 File Offset: 0x00AA75C4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 瞄准抬起(float time)
		{
			BP_InputBase_C.__瞄准抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__瞄准抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__瞄准抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__瞄准抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__瞄准抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA73 RID: 182899 RVA: 0x00AA9418 File Offset: 0x00AA7618
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 瞄准按下(float time)
		{
			BP_InputBase_C.__瞄准按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__瞄准按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__瞄准按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__瞄准按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__瞄准按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA74 RID: 182900 RVA: 0x00AA946C File Offset: 0x00AA766C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色3长按(float time)
		{
			BP_InputBase_C.__切换角色3长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色3长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色3长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色3长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色3长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA75 RID: 182901 RVA: 0x00AA94C0 File Offset: 0x00AA76C0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色3抬起(float time)
		{
			BP_InputBase_C.__切换角色3抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色3抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色3抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色3抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色3抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA76 RID: 182902 RVA: 0x00AA9514 File Offset: 0x00AA7714
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色3按下(float time)
		{
			BP_InputBase_C.__切换角色3按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色3按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色3按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色3按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色3按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA77 RID: 182903 RVA: 0x00AA9568 File Offset: 0x00AA7768
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色2长按(float time)
		{
			BP_InputBase_C.__切换角色2长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色2长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色2长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色2长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色2长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA78 RID: 182904 RVA: 0x00AA95BC File Offset: 0x00AA77BC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色2抬起(float time)
		{
			BP_InputBase_C.__切换角色2抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色2抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色2抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色2抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色2抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA79 RID: 182905 RVA: 0x00AA9610 File Offset: 0x00AA7810
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色2按下(float time)
		{
			BP_InputBase_C.__切换角色2按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色2按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色2按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色2按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色2按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7A RID: 182906 RVA: 0x00AA9664 File Offset: 0x00AA7864
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色1长按(float time)
		{
			BP_InputBase_C.__切换角色1长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色1长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7B RID: 182907 RVA: 0x00AA96B8 File Offset: 0x00AA78B8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色1抬起(float time)
		{
			BP_InputBase_C.__切换角色1抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色1抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7C RID: 182908 RVA: 0x00AA970C File Offset: 0x00AA790C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 切换角色1按下(float time)
		{
			BP_InputBase_C.__切换角色1按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色1按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__切换角色1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7D RID: 182909 RVA: 0x00AA9760 File Offset: 0x00AA7960
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象2长按(float time)
		{
			BP_InputBase_C.__幻象2长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象2长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象2长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象2长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象2长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7E RID: 182910 RVA: 0x00AA97B4 File Offset: 0x00AA79B4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象2抬起(float time)
		{
			BP_InputBase_C.__幻象2抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象2抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象2抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象2抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象2抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA7F RID: 182911 RVA: 0x00AA9808 File Offset: 0x00AA7A08
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象2按下(float time)
		{
			BP_InputBase_C.__幻象2按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象2按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象2按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象2按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象2按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA80 RID: 182912 RVA: 0x00AA985C File Offset: 0x00AA7A5C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 大招长按(float time)
		{
			BP_InputBase_C.__大招长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__大招长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__大招长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__大招长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__大招长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA81 RID: 182913 RVA: 0x00AA98B0 File Offset: 0x00AA7AB0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 大招抬起(float time)
		{
			BP_InputBase_C.__大招抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__大招抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__大招抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__大招抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__大招抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA82 RID: 182914 RVA: 0x00AA9904 File Offset: 0x00AA7B04
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 大招按下(float time)
		{
			BP_InputBase_C.__大招按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__大招按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__大招按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__大招按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__大招按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA83 RID: 182915 RVA: 0x00AA9958 File Offset: 0x00AA7B58
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象1长按(float time)
		{
			BP_InputBase_C.__幻象1长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象1长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA84 RID: 182916 RVA: 0x00AA99AC File Offset: 0x00AA7BAC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象1抬起(float time)
		{
			BP_InputBase_C.__幻象1抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象1抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA85 RID: 182917 RVA: 0x00AA9A00 File Offset: 0x00AA7C00
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 幻象1按下(float time)
		{
			BP_InputBase_C.__幻象1按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象1按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__幻象1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA86 RID: 182918 RVA: 0x00AA9A54 File Offset: 0x00AA7C54
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 技能1长按(float time)
		{
			BP_InputBase_C.__技能1长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__技能1长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__技能1长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__技能1长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__技能1长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA87 RID: 182919 RVA: 0x00AA9AA8 File Offset: 0x00AA7CA8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 技能1抬起(float time)
		{
			BP_InputBase_C.__技能1抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__技能1抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__技能1抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__技能1抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__技能1抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA88 RID: 182920 RVA: 0x00AA9AFC File Offset: 0x00AA7CFC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 技能1按下(float time)
		{
			BP_InputBase_C.__技能1按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__技能1按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__技能1按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__技能1按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__技能1按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA89 RID: 182921 RVA: 0x00AA9B50 File Offset: 0x00AA7D50
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 闪避长按(float time)
		{
			BP_InputBase_C.__闪避长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__闪避长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__闪避长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__闪避长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__闪避长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8A RID: 182922 RVA: 0x00AA9BA4 File Offset: 0x00AA7DA4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 闪避抬起(float time)
		{
			BP_InputBase_C.__闪避抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__闪避抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__闪避抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__闪避抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__闪避抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8B RID: 182923 RVA: 0x00AA9BF8 File Offset: 0x00AA7DF8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 闪避按下(float time)
		{
			BP_InputBase_C.__闪避按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__闪避按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__闪避按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__闪避按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__闪避按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8C RID: 182924 RVA: 0x00AA9C4C File Offset: 0x00AA7E4C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攻击长按(float time)
		{
			BP_InputBase_C.__攻击长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__攻击长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攻击长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攻击长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攻击长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8D RID: 182925 RVA: 0x00AA9CA0 File Offset: 0x00AA7EA0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攻击抬起(float time)
		{
			BP_InputBase_C.__攻击抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__攻击抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攻击抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攻击抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攻击抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8E RID: 182926 RVA: 0x00AA9CF4 File Offset: 0x00AA7EF4
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攻击按下(float time)
		{
			BP_InputBase_C.__攻击按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__攻击按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攻击按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攻击按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攻击按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA8F RID: 182927 RVA: 0x00AA9D48 File Offset: 0x00AA7F48
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 走跑切换长按(float time)
		{
			BP_InputBase_C.__走跑切换长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__走跑切换长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__走跑切换长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__走跑切换长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__走跑切换长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA90 RID: 182928 RVA: 0x00AA9D9C File Offset: 0x00AA7F9C
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 走跑切换抬起(float time)
		{
			BP_InputBase_C.__走跑切换抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__走跑切换抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__走跑切换抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__走跑切换抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__走跑切换抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA91 RID: 182929 RVA: 0x00AA9DF0 File Offset: 0x00AA7FF0
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 走跑切换按下(float time)
		{
			BP_InputBase_C.__走跑切换按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__走跑切换按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__走跑切换按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__走跑切换按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA92 RID: 182930 RVA: 0x00AA9E44 File Offset: 0x00AA8044
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攀爬长按(float time)
		{
			BP_InputBase_C.__攀爬长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__攀爬长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攀爬长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攀爬长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攀爬长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA93 RID: 182931 RVA: 0x00AA9E98 File Offset: 0x00AA8098
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攀爬抬起(float time)
		{
			BP_InputBase_C.__攀爬抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__攀爬抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攀爬抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攀爬抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攀爬抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA94 RID: 182932 RVA: 0x00AA9EEC File Offset: 0x00AA80EC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 攀爬按下(float time)
		{
			BP_InputBase_C.__攀爬按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__攀爬按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__攀爬按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攀爬按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攀爬按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA95 RID: 182933 RVA: 0x00AA9F40 File Offset: 0x00AA8140
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 跳跃长按(float time)
		{
			BP_InputBase_C.__跳跃长按_FunctionParams* ptr = stackalloc BP_InputBase_C.__跳跃长按_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__跳跃长按_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__跳跃长按_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__跳跃长按_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA96 RID: 182934 RVA: 0x00AA9F94 File Offset: 0x00AA8194
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 跳跃抬起(float time)
		{
			BP_InputBase_C.__跳跃抬起_FunctionParams* ptr = stackalloc BP_InputBase_C.__跳跃抬起_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__跳跃抬起_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__跳跃抬起_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA97 RID: 182935 RVA: 0x00AA9FE8 File Offset: 0x00AA81E8
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCommand 跳跃按下(float time)
		{
			BP_InputBase_C.__跳跃按下_FunctionParams* ptr = stackalloc BP_InputBase_C.__跳跃按下_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_InputBase_C.__跳跃按下_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__跳跃按下_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__跳跃按下_NativeFunctionPtr, (void*)ptr);
			return new SInputCommand(&ptr->__Result, true, true);
		}

		// Token: 0x0602CA98 RID: 182936 RVA: 0x00AAA03C File Offset: 0x00AA823C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 瞄准抬起事件(float time)
		{
			BP_InputBase_C.__瞄准抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__瞄准抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__瞄准抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__瞄准抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__瞄准抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA99 RID: 182937 RVA: 0x00AAA084 File Offset: 0x00AA8284
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 瞄准按下事件(float time)
		{
			BP_InputBase_C.__瞄准按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__瞄准按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__瞄准按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__瞄准按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__瞄准按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9A RID: 182938 RVA: 0x00AAA0CC File Offset: 0x00AA82CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 锁定目标抬起事件(float time)
		{
			BP_InputBase_C.__锁定目标抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__锁定目标抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__锁定目标抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__锁定目标抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__锁定目标抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9B RID: 182939 RVA: 0x00AAA114 File Offset: 0x00AA8314
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 锁定目标按下事件(float time)
		{
			BP_InputBase_C.__锁定目标按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__锁定目标按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__锁定目标按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__锁定目标按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__锁定目标按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9C RID: 182940 RVA: 0x00AAA15C File Offset: 0x00AA835C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色3抬起事件(float time)
		{
			BP_InputBase_C.__切换角色3抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色3抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色3抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色3抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色3抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9D RID: 182941 RVA: 0x00AAA1A4 File Offset: 0x00AA83A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色3按下事件(float time)
		{
			BP_InputBase_C.__切换角色3按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色3按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色3按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色3按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色3按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9E RID: 182942 RVA: 0x00AAA1EC File Offset: 0x00AA83EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色2抬起事件(float time)
		{
			BP_InputBase_C.__切换角色2抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色2抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色2抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色2抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色2抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CA9F RID: 182943 RVA: 0x00AAA234 File Offset: 0x00AA8434
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色2按下事件(float time)
		{
			BP_InputBase_C.__切换角色2按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色2按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色2按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色2按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色2按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA0 RID: 182944 RVA: 0x00AAA27C File Offset: 0x00AA847C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色1抬起事件(float time)
		{
			BP_InputBase_C.__切换角色1抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色1抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色1抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色1抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色1抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA1 RID: 182945 RVA: 0x00AAA2C4 File Offset: 0x00AA84C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 切换角色1按下事件(float time)
		{
			BP_InputBase_C.__切换角色1按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__切换角色1按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__切换角色1按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__切换角色1按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__切换角色1按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA2 RID: 182946 RVA: 0x00AAA30C File Offset: 0x00AA850C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 幻象2抬起事件(float time)
		{
			BP_InputBase_C.__幻象2抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象2抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__幻象2抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象2抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象2抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA3 RID: 182947 RVA: 0x00AAA354 File Offset: 0x00AA8554
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 幻象2按下事件(float time)
		{
			BP_InputBase_C.__幻象2按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象2按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__幻象2按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象2按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象2按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA4 RID: 182948 RVA: 0x00AAA39C File Offset: 0x00AA859C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 大招抬起事件(float time)
		{
			BP_InputBase_C.__大招抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__大招抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__大招抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__大招抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__大招抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA5 RID: 182949 RVA: 0x00AAA3E4 File Offset: 0x00AA85E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 大招按下事件(float time)
		{
			BP_InputBase_C.__大招按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__大招按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__大招按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__大招按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__大招按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA6 RID: 182950 RVA: 0x00AAA42C File Offset: 0x00AA862C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 幻象1抬起事件(float time)
		{
			BP_InputBase_C.__幻象1抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象1抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__幻象1抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象1抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象1抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA7 RID: 182951 RVA: 0x00AAA474 File Offset: 0x00AA8674
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 幻象1按下事件(float time)
		{
			BP_InputBase_C.__幻象1按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__幻象1按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__幻象1按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__幻象1按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__幻象1按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA8 RID: 182952 RVA: 0x00AAA4BC File Offset: 0x00AA86BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 技能1抬起事件(float time)
		{
			BP_InputBase_C.__技能1抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__技能1抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__技能1抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__技能1抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__技能1抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAA9 RID: 182953 RVA: 0x00AAA504 File Offset: 0x00AA8704
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 技能1按下事件(float time)
		{
			BP_InputBase_C.__技能1按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__技能1按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__技能1按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__技能1按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__技能1按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAA RID: 182954 RVA: 0x00AAA54C File Offset: 0x00AA874C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 闪避抬起事件(float time)
		{
			BP_InputBase_C.__闪避抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__闪避抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__闪避抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__闪避抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__闪避抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAB RID: 182955 RVA: 0x00AAA594 File Offset: 0x00AA8794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 闪避按下事件(float time)
		{
			BP_InputBase_C.__闪避按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__闪避按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__闪避按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__闪避按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__闪避按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAC RID: 182956 RVA: 0x00AAA5DC File Offset: 0x00AA87DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 攻击抬起事件(float time)
		{
			BP_InputBase_C.__攻击抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__攻击抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__攻击抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攻击抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攻击抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAD RID: 182957 RVA: 0x00AAA624 File Offset: 0x00AA8824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 攻击按下事件(float time)
		{
			BP_InputBase_C.__攻击按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__攻击按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__攻击按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攻击按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攻击按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAE RID: 182958 RVA: 0x00AAA66C File Offset: 0x00AA886C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 走跑切换抬起事件(float time)
		{
			BP_InputBase_C.__走跑切换抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__走跑切换抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__走跑切换抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__走跑切换抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__走跑切换抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAAF RID: 182959 RVA: 0x00AAA6B4 File Offset: 0x00AA88B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 走跑切换按下事件(float time)
		{
			BP_InputBase_C.__走跑切换按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__走跑切换按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__走跑切换按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__走跑切换按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__走跑切换按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB0 RID: 182960 RVA: 0x00AAA6FC File Offset: 0x00AA88FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 攀爬抬起事件(float time)
		{
			BP_InputBase_C.__攀爬抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__攀爬抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__攀爬抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攀爬抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攀爬抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB1 RID: 182961 RVA: 0x00AAA744 File Offset: 0x00AA8944
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 攀爬按下事件(float time)
		{
			BP_InputBase_C.__攀爬按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__攀爬按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__攀爬按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__攀爬按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__攀爬按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB2 RID: 182962 RVA: 0x00AAA78C File Offset: 0x00AA898C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 跳跃抬起事件(float time)
		{
			BP_InputBase_C.__跳跃抬起事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__跳跃抬起事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__跳跃抬起事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__跳跃抬起事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__跳跃抬起事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB3 RID: 182963 RVA: 0x00AAA7D4 File Offset: 0x00AA89D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 跳跃按下事件(float time)
		{
			BP_InputBase_C.__跳跃按下事件_FunctionParams* ptr = stackalloc BP_InputBase_C.__跳跃按下事件_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_InputBase_C.__跳跃按下事件_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__跳跃按下事件_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__跳跃按下事件_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB4 RID: 182964 RVA: 0x00AAA81C File Offset: 0x00AA8A1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputHoldConfig GetUnrealHoldConfig(int action)
		{
			BP_InputBase_C.__GetUnrealHoldConfig_FunctionParams* ptr = stackalloc BP_InputBase_C.__GetUnrealHoldConfig_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_InputBase_C.__GetUnrealHoldConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__GetUnrealHoldConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->action = action;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__GetUnrealHoldConfig_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CAB5 RID: 182965 RVA: 0x00AAA868 File Offset: 0x00AA8A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual SInputCaches GetUnrealCacheConfig(int action)
		{
			BP_InputBase_C.__GetUnrealCacheConfig_FunctionParams* ptr = stackalloc BP_InputBase_C.__GetUnrealCacheConfig_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_InputBase_C.__GetUnrealCacheConfig_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__GetUnrealCacheConfig_NativeFunctionPtr, (void*)ptr, 1);
			ptr->action = action;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__GetUnrealCacheConfig_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602CAB6 RID: 182966 RVA: 0x00AAA8B4 File Offset: 0x00AA8AB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_InputBase_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_InputBase_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_InputBase_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InputBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CAB7 RID: 182967 RVA: 0x00AAA900 File Offset: 0x00AA8B00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_InputBase_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_InputBase_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_InputBase_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InputBase_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CAB8 RID: 182968 RVA: 0x00AAA94C File Offset: 0x00AA8B4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_InputBase(int EntryPoint)
		{
			BP_InputBase_C.__ExecuteUbergraph_BP_InputBase_FunctionParams* ptr = stackalloc BP_InputBase_C.__ExecuteUbergraph_BP_InputBase_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_InputBase_C.__ExecuteUbergraph_BP_InputBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InputBase_C.__ExecuteUbergraph_BP_InputBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_InputBase_C.__ExecuteUbergraph_BP_InputBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CAB9 RID: 182969 RVA: 0x00AAA993 File Offset: 0x00AA8B93
		protected BP_InputBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018DAD RID: 101805
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Input/Blueprints/BP_InputBase.BP_InputBase_C";

		// Token: 0x04018DAE RID: 101806
		private static IntPtr _ClassPtr;

		// Token: 0x04018DAF RID: 101807
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018DB0 RID: 101808
		internal static int __PropertyOffset_0;

		// Token: 0x04018DB1 RID: 101809
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018DB2 RID: 101810
		internal static int __PropertyOffset_1;

		// Token: 0x04018DB3 RID: 101811
		internal static int __PropertyOffset_2;

		// Token: 0x04018DB4 RID: 101812
		internal static int __PropertyOffset_3;

		// Token: 0x04018DB5 RID: 101813
		internal static int __PropertyOffset_4;

		// Token: 0x04018DB6 RID: 101814
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> _InputShowMap;

		// Token: 0x04018DB7 RID: 101815
		internal static int __PropertyOffset_5;

		// Token: 0x04018DB8 RID: 101816
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EInputCharacterState>, SInputShowList> _MobileInputShowMap;

		// Token: 0x04018DB9 RID: 101817
		internal static int __PropertyOffset_6;

		// Token: 0x04018DBA RID: 101818
		[Nullable(2)]
		private SInputActive _激活移动输入映射按键事件;

		// Token: 0x04018DBB RID: 101819
		private static IntPtr __移动输入抬起事件_NativeFunctionPtr;

		// Token: 0x04018DBC RID: 101820
		private static IntPtr __移动输入按下事件_NativeFunctionPtr;

		// Token: 0x04018DBD RID: 101821
		private static IntPtr __移动输入长按_NativeFunctionPtr;

		// Token: 0x04018DBE RID: 101822
		private static IntPtr __移动输入抬起_NativeFunctionPtr;

		// Token: 0x04018DBF RID: 101823
		private static IntPtr __移动输入按下_NativeFunctionPtr;

		// Token: 0x04018DC0 RID: 101824
		private static IntPtr __下降抬起事件_NativeFunctionPtr;

		// Token: 0x04018DC1 RID: 101825
		private static IntPtr __下降按下事件_NativeFunctionPtr;

		// Token: 0x04018DC2 RID: 101826
		private static IntPtr __下降长按_NativeFunctionPtr;

		// Token: 0x04018DC3 RID: 101827
		private static IntPtr __下降抬起_NativeFunctionPtr;

		// Token: 0x04018DC4 RID: 101828
		private static IntPtr __下降按下_NativeFunctionPtr;

		// Token: 0x04018DC5 RID: 101829
		private static IntPtr __GetMoveVector_NativeFunctionPtr;

		// Token: 0x04018DC6 RID: 101830
		private static IntPtr __通用交互按下_NativeFunctionPtr;

		// Token: 0x04018DC7 RID: 101831
		private static IntPtr __锁定目标长按_NativeFunctionPtr;

		// Token: 0x04018DC8 RID: 101832
		private static IntPtr __瞄准长按_NativeFunctionPtr;

		// Token: 0x04018DC9 RID: 101833
		private static IntPtr __瞄准抬起_NativeFunctionPtr;

		// Token: 0x04018DCA RID: 101834
		private static IntPtr __瞄准按下_NativeFunctionPtr;

		// Token: 0x04018DCB RID: 101835
		private static IntPtr __切换角色3长按_NativeFunctionPtr;

		// Token: 0x04018DCC RID: 101836
		private static IntPtr __切换角色3抬起_NativeFunctionPtr;

		// Token: 0x04018DCD RID: 101837
		private static IntPtr __切换角色3按下_NativeFunctionPtr;

		// Token: 0x04018DCE RID: 101838
		private static IntPtr __切换角色2长按_NativeFunctionPtr;

		// Token: 0x04018DCF RID: 101839
		private static IntPtr __切换角色2抬起_NativeFunctionPtr;

		// Token: 0x04018DD0 RID: 101840
		private static IntPtr __切换角色2按下_NativeFunctionPtr;

		// Token: 0x04018DD1 RID: 101841
		private static IntPtr __切换角色1长按_NativeFunctionPtr;

		// Token: 0x04018DD2 RID: 101842
		private static IntPtr __切换角色1抬起_NativeFunctionPtr;

		// Token: 0x04018DD3 RID: 101843
		private static IntPtr __切换角色1按下_NativeFunctionPtr;

		// Token: 0x04018DD4 RID: 101844
		private static IntPtr __幻象2长按_NativeFunctionPtr;

		// Token: 0x04018DD5 RID: 101845
		private static IntPtr __幻象2抬起_NativeFunctionPtr;

		// Token: 0x04018DD6 RID: 101846
		private static IntPtr __幻象2按下_NativeFunctionPtr;

		// Token: 0x04018DD7 RID: 101847
		private static IntPtr __大招长按_NativeFunctionPtr;

		// Token: 0x04018DD8 RID: 101848
		private static IntPtr __大招抬起_NativeFunctionPtr;

		// Token: 0x04018DD9 RID: 101849
		private static IntPtr __大招按下_NativeFunctionPtr;

		// Token: 0x04018DDA RID: 101850
		private static IntPtr __幻象1长按_NativeFunctionPtr;

		// Token: 0x04018DDB RID: 101851
		private static IntPtr __幻象1抬起_NativeFunctionPtr;

		// Token: 0x04018DDC RID: 101852
		private static IntPtr __幻象1按下_NativeFunctionPtr;

		// Token: 0x04018DDD RID: 101853
		private static IntPtr __技能1长按_NativeFunctionPtr;

		// Token: 0x04018DDE RID: 101854
		private static IntPtr __技能1抬起_NativeFunctionPtr;

		// Token: 0x04018DDF RID: 101855
		private static IntPtr __技能1按下_NativeFunctionPtr;

		// Token: 0x04018DE0 RID: 101856
		private static IntPtr __闪避长按_NativeFunctionPtr;

		// Token: 0x04018DE1 RID: 101857
		private static IntPtr __闪避抬起_NativeFunctionPtr;

		// Token: 0x04018DE2 RID: 101858
		private static IntPtr __闪避按下_NativeFunctionPtr;

		// Token: 0x04018DE3 RID: 101859
		private static IntPtr __攻击长按_NativeFunctionPtr;

		// Token: 0x04018DE4 RID: 101860
		private static IntPtr __攻击抬起_NativeFunctionPtr;

		// Token: 0x04018DE5 RID: 101861
		private static IntPtr __攻击按下_NativeFunctionPtr;

		// Token: 0x04018DE6 RID: 101862
		private static IntPtr __走跑切换长按_NativeFunctionPtr;

		// Token: 0x04018DE7 RID: 101863
		private static IntPtr __走跑切换抬起_NativeFunctionPtr;

		// Token: 0x04018DE8 RID: 101864
		private static IntPtr __走跑切换按下_NativeFunctionPtr;

		// Token: 0x04018DE9 RID: 101865
		private static IntPtr __攀爬长按_NativeFunctionPtr;

		// Token: 0x04018DEA RID: 101866
		private static IntPtr __攀爬抬起_NativeFunctionPtr;

		// Token: 0x04018DEB RID: 101867
		private static IntPtr __攀爬按下_NativeFunctionPtr;

		// Token: 0x04018DEC RID: 101868
		private static IntPtr __跳跃长按_NativeFunctionPtr;

		// Token: 0x04018DED RID: 101869
		private static IntPtr __跳跃抬起_NativeFunctionPtr;

		// Token: 0x04018DEE RID: 101870
		private static IntPtr __跳跃按下_NativeFunctionPtr;

		// Token: 0x04018DEF RID: 101871
		private static IntPtr __瞄准抬起事件_NativeFunctionPtr;

		// Token: 0x04018DF0 RID: 101872
		private static IntPtr __瞄准按下事件_NativeFunctionPtr;

		// Token: 0x04018DF1 RID: 101873
		private static IntPtr __锁定目标抬起事件_NativeFunctionPtr;

		// Token: 0x04018DF2 RID: 101874
		private static IntPtr __锁定目标按下事件_NativeFunctionPtr;

		// Token: 0x04018DF3 RID: 101875
		private static IntPtr __切换角色3抬起事件_NativeFunctionPtr;

		// Token: 0x04018DF4 RID: 101876
		private static IntPtr __切换角色3按下事件_NativeFunctionPtr;

		// Token: 0x04018DF5 RID: 101877
		private static IntPtr __切换角色2抬起事件_NativeFunctionPtr;

		// Token: 0x04018DF6 RID: 101878
		private static IntPtr __切换角色2按下事件_NativeFunctionPtr;

		// Token: 0x04018DF7 RID: 101879
		private static IntPtr __切换角色1抬起事件_NativeFunctionPtr;

		// Token: 0x04018DF8 RID: 101880
		private static IntPtr __切换角色1按下事件_NativeFunctionPtr;

		// Token: 0x04018DF9 RID: 101881
		private static IntPtr __幻象2抬起事件_NativeFunctionPtr;

		// Token: 0x04018DFA RID: 101882
		private static IntPtr __幻象2按下事件_NativeFunctionPtr;

		// Token: 0x04018DFB RID: 101883
		private static IntPtr __大招抬起事件_NativeFunctionPtr;

		// Token: 0x04018DFC RID: 101884
		private static IntPtr __大招按下事件_NativeFunctionPtr;

		// Token: 0x04018DFD RID: 101885
		private static IntPtr __幻象1抬起事件_NativeFunctionPtr;

		// Token: 0x04018DFE RID: 101886
		private static IntPtr __幻象1按下事件_NativeFunctionPtr;

		// Token: 0x04018DFF RID: 101887
		private static IntPtr __技能1抬起事件_NativeFunctionPtr;

		// Token: 0x04018E00 RID: 101888
		private static IntPtr __技能1按下事件_NativeFunctionPtr;

		// Token: 0x04018E01 RID: 101889
		private static IntPtr __闪避抬起事件_NativeFunctionPtr;

		// Token: 0x04018E02 RID: 101890
		private static IntPtr __闪避按下事件_NativeFunctionPtr;

		// Token: 0x04018E03 RID: 101891
		private static IntPtr __攻击抬起事件_NativeFunctionPtr;

		// Token: 0x04018E04 RID: 101892
		private static IntPtr __攻击按下事件_NativeFunctionPtr;

		// Token: 0x04018E05 RID: 101893
		private static IntPtr __走跑切换抬起事件_NativeFunctionPtr;

		// Token: 0x04018E06 RID: 101894
		private static IntPtr __走跑切换按下事件_NativeFunctionPtr;

		// Token: 0x04018E07 RID: 101895
		private static IntPtr __攀爬抬起事件_NativeFunctionPtr;

		// Token: 0x04018E08 RID: 101896
		private static IntPtr __攀爬按下事件_NativeFunctionPtr;

		// Token: 0x04018E09 RID: 101897
		private static IntPtr __跳跃抬起事件_NativeFunctionPtr;

		// Token: 0x04018E0A RID: 101898
		private static IntPtr __跳跃按下事件_NativeFunctionPtr;

		// Token: 0x04018E0B RID: 101899
		private static IntPtr __GetUnrealHoldConfig_NativeFunctionPtr;

		// Token: 0x04018E0C RID: 101900
		private static IntPtr __GetUnrealCacheConfig_NativeFunctionPtr;

		// Token: 0x04018E0D RID: 101901
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04018E0E RID: 101902
		private static IntPtr __ExecuteUbergraph_BP_InputBase_NativeFunctionPtr;

		// Token: 0x0200A46E RID: 42094
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __移动输入抬起事件_FunctionParams
		{
			// Token: 0x04033279 RID: 209529
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403327A RID: 209530
			[FieldOffset(4)]
			public float yaw;
		}

		// Token: 0x0200A46F RID: 42095
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __移动输入按下事件_FunctionParams
		{
			// Token: 0x0403327B RID: 209531
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403327C RID: 209532
			[FieldOffset(4)]
			public float yaw;
		}

		// Token: 0x0200A470 RID: 42096
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __移动输入长按_FunctionParams
		{
			// Token: 0x0403327D RID: 209533
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403327E RID: 209534
			[FieldOffset(4)]
			public float yaw;

			// Token: 0x0403327F RID: 209535
			[FieldOffset(8)]
			public byte __Result;
		}

		// Token: 0x0200A471 RID: 42097
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __移动输入抬起_FunctionParams
		{
			// Token: 0x04033280 RID: 209536
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033281 RID: 209537
			[FieldOffset(4)]
			public float yaw;

			// Token: 0x04033282 RID: 209538
			[FieldOffset(8)]
			public byte __Result;
		}

		// Token: 0x0200A472 RID: 42098
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 28)]
		protected ref struct __移动输入按下_FunctionParams
		{
			// Token: 0x04033283 RID: 209539
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033284 RID: 209540
			[FieldOffset(4)]
			public float yaw;

			// Token: 0x04033285 RID: 209541
			[FieldOffset(8)]
			public byte __Result;
		}

		// Token: 0x0200A473 RID: 42099
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __下降抬起事件_FunctionParams
		{
			// Token: 0x04033286 RID: 209542
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A474 RID: 42100
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __下降按下事件_FunctionParams
		{
			// Token: 0x04033287 RID: 209543
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A475 RID: 42101
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __下降长按_FunctionParams
		{
			// Token: 0x04033288 RID: 209544
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033289 RID: 209545
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A476 RID: 42102
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __下降抬起_FunctionParams
		{
			// Token: 0x0403328A RID: 209546
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403328B RID: 209547
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A477 RID: 42103
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __下降按下_FunctionParams
		{
			// Token: 0x0403328C RID: 209548
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403328D RID: 209549
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A478 RID: 42104
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetMoveVector_FunctionParams
		{
			// Token: 0x0403328E RID: 209550
			[FieldOffset(0)]
			public FVector2D ReturnVaule;
		}

		// Token: 0x0200A479 RID: 42105
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __通用交互按下_FunctionParams
		{
			// Token: 0x0403328F RID: 209551
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033290 RID: 209552
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47A RID: 42106
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __锁定目标长按_FunctionParams
		{
			// Token: 0x04033291 RID: 209553
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033292 RID: 209554
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47B RID: 42107
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __瞄准长按_FunctionParams
		{
			// Token: 0x04033293 RID: 209555
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033294 RID: 209556
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47C RID: 42108
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __瞄准抬起_FunctionParams
		{
			// Token: 0x04033295 RID: 209557
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033296 RID: 209558
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47D RID: 42109
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __瞄准按下_FunctionParams
		{
			// Token: 0x04033297 RID: 209559
			[FieldOffset(0)]
			public float time;

			// Token: 0x04033298 RID: 209560
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47E RID: 42110
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色3长按_FunctionParams
		{
			// Token: 0x04033299 RID: 209561
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403329A RID: 209562
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A47F RID: 42111
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色3抬起_FunctionParams
		{
			// Token: 0x0403329B RID: 209563
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403329C RID: 209564
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A480 RID: 42112
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色3按下_FunctionParams
		{
			// Token: 0x0403329D RID: 209565
			[FieldOffset(0)]
			public float time;

			// Token: 0x0403329E RID: 209566
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A481 RID: 42113
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色2长按_FunctionParams
		{
			// Token: 0x0403329F RID: 209567
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332A0 RID: 209568
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A482 RID: 42114
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色2抬起_FunctionParams
		{
			// Token: 0x040332A1 RID: 209569
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332A2 RID: 209570
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A483 RID: 42115
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色2按下_FunctionParams
		{
			// Token: 0x040332A3 RID: 209571
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332A4 RID: 209572
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A484 RID: 42116
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色1长按_FunctionParams
		{
			// Token: 0x040332A5 RID: 209573
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332A6 RID: 209574
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A485 RID: 42117
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色1抬起_FunctionParams
		{
			// Token: 0x040332A7 RID: 209575
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332A8 RID: 209576
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A486 RID: 42118
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __切换角色1按下_FunctionParams
		{
			// Token: 0x040332A9 RID: 209577
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332AA RID: 209578
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A487 RID: 42119
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象2长按_FunctionParams
		{
			// Token: 0x040332AB RID: 209579
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332AC RID: 209580
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A488 RID: 42120
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象2抬起_FunctionParams
		{
			// Token: 0x040332AD RID: 209581
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332AE RID: 209582
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A489 RID: 42121
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象2按下_FunctionParams
		{
			// Token: 0x040332AF RID: 209583
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332B0 RID: 209584
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48A RID: 42122
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __大招长按_FunctionParams
		{
			// Token: 0x040332B1 RID: 209585
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332B2 RID: 209586
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48B RID: 42123
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __大招抬起_FunctionParams
		{
			// Token: 0x040332B3 RID: 209587
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332B4 RID: 209588
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48C RID: 42124
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __大招按下_FunctionParams
		{
			// Token: 0x040332B5 RID: 209589
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332B6 RID: 209590
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48D RID: 42125
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象1长按_FunctionParams
		{
			// Token: 0x040332B7 RID: 209591
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332B8 RID: 209592
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48E RID: 42126
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象1抬起_FunctionParams
		{
			// Token: 0x040332B9 RID: 209593
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332BA RID: 209594
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A48F RID: 42127
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __幻象1按下_FunctionParams
		{
			// Token: 0x040332BB RID: 209595
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332BC RID: 209596
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A490 RID: 42128
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __技能1长按_FunctionParams
		{
			// Token: 0x040332BD RID: 209597
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332BE RID: 209598
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A491 RID: 42129
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __技能1抬起_FunctionParams
		{
			// Token: 0x040332BF RID: 209599
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332C0 RID: 209600
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A492 RID: 42130
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __技能1按下_FunctionParams
		{
			// Token: 0x040332C1 RID: 209601
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332C2 RID: 209602
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A493 RID: 42131
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __闪避长按_FunctionParams
		{
			// Token: 0x040332C3 RID: 209603
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332C4 RID: 209604
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A494 RID: 42132
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __闪避抬起_FunctionParams
		{
			// Token: 0x040332C5 RID: 209605
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332C6 RID: 209606
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A495 RID: 42133
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __闪避按下_FunctionParams
		{
			// Token: 0x040332C7 RID: 209607
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332C8 RID: 209608
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A496 RID: 42134
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攻击长按_FunctionParams
		{
			// Token: 0x040332C9 RID: 209609
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332CA RID: 209610
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A497 RID: 42135
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攻击抬起_FunctionParams
		{
			// Token: 0x040332CB RID: 209611
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332CC RID: 209612
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A498 RID: 42136
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攻击按下_FunctionParams
		{
			// Token: 0x040332CD RID: 209613
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332CE RID: 209614
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A499 RID: 42137
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __走跑切换长按_FunctionParams
		{
			// Token: 0x040332CF RID: 209615
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332D0 RID: 209616
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49A RID: 42138
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __走跑切换抬起_FunctionParams
		{
			// Token: 0x040332D1 RID: 209617
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332D2 RID: 209618
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49B RID: 42139
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __走跑切换按下_FunctionParams
		{
			// Token: 0x040332D3 RID: 209619
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332D4 RID: 209620
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49C RID: 42140
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攀爬长按_FunctionParams
		{
			// Token: 0x040332D5 RID: 209621
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332D6 RID: 209622
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49D RID: 42141
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攀爬抬起_FunctionParams
		{
			// Token: 0x040332D7 RID: 209623
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332D8 RID: 209624
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49E RID: 42142
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __攀爬按下_FunctionParams
		{
			// Token: 0x040332D9 RID: 209625
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332DA RID: 209626
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A49F RID: 42143
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __跳跃长按_FunctionParams
		{
			// Token: 0x040332DB RID: 209627
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332DC RID: 209628
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4A0 RID: 42144
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __跳跃抬起_FunctionParams
		{
			// Token: 0x040332DD RID: 209629
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332DE RID: 209630
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4A1 RID: 42145
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __跳跃按下_FunctionParams
		{
			// Token: 0x040332DF RID: 209631
			[FieldOffset(0)]
			public float time;

			// Token: 0x040332E0 RID: 209632
			[FieldOffset(4)]
			public byte __Result;
		}

		// Token: 0x0200A4A2 RID: 42146
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __瞄准抬起事件_FunctionParams
		{
			// Token: 0x040332E1 RID: 209633
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A3 RID: 42147
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __瞄准按下事件_FunctionParams
		{
			// Token: 0x040332E2 RID: 209634
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A4 RID: 42148
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __锁定目标抬起事件_FunctionParams
		{
			// Token: 0x040332E3 RID: 209635
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A5 RID: 42149
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __锁定目标按下事件_FunctionParams
		{
			// Token: 0x040332E4 RID: 209636
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A6 RID: 42150
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色3抬起事件_FunctionParams
		{
			// Token: 0x040332E5 RID: 209637
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A7 RID: 42151
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色3按下事件_FunctionParams
		{
			// Token: 0x040332E6 RID: 209638
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A8 RID: 42152
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色2抬起事件_FunctionParams
		{
			// Token: 0x040332E7 RID: 209639
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4A9 RID: 42153
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色2按下事件_FunctionParams
		{
			// Token: 0x040332E8 RID: 209640
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AA RID: 42154
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色1抬起事件_FunctionParams
		{
			// Token: 0x040332E9 RID: 209641
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AB RID: 42155
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __切换角色1按下事件_FunctionParams
		{
			// Token: 0x040332EA RID: 209642
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AC RID: 42156
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __幻象2抬起事件_FunctionParams
		{
			// Token: 0x040332EB RID: 209643
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AD RID: 42157
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __幻象2按下事件_FunctionParams
		{
			// Token: 0x040332EC RID: 209644
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AE RID: 42158
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __大招抬起事件_FunctionParams
		{
			// Token: 0x040332ED RID: 209645
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4AF RID: 42159
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __大招按下事件_FunctionParams
		{
			// Token: 0x040332EE RID: 209646
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B0 RID: 42160
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __幻象1抬起事件_FunctionParams
		{
			// Token: 0x040332EF RID: 209647
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B1 RID: 42161
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __幻象1按下事件_FunctionParams
		{
			// Token: 0x040332F0 RID: 209648
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B2 RID: 42162
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __技能1抬起事件_FunctionParams
		{
			// Token: 0x040332F1 RID: 209649
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B3 RID: 42163
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __技能1按下事件_FunctionParams
		{
			// Token: 0x040332F2 RID: 209650
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B4 RID: 42164
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __闪避抬起事件_FunctionParams
		{
			// Token: 0x040332F3 RID: 209651
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B5 RID: 42165
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __闪避按下事件_FunctionParams
		{
			// Token: 0x040332F4 RID: 209652
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B6 RID: 42166
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __攻击抬起事件_FunctionParams
		{
			// Token: 0x040332F5 RID: 209653
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B7 RID: 42167
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __攻击按下事件_FunctionParams
		{
			// Token: 0x040332F6 RID: 209654
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B8 RID: 42168
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __走跑切换抬起事件_FunctionParams
		{
			// Token: 0x040332F7 RID: 209655
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4B9 RID: 42169
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __走跑切换按下事件_FunctionParams
		{
			// Token: 0x040332F8 RID: 209656
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4BA RID: 42170
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __攀爬抬起事件_FunctionParams
		{
			// Token: 0x040332F9 RID: 209657
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4BB RID: 42171
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __攀爬按下事件_FunctionParams
		{
			// Token: 0x040332FA RID: 209658
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4BC RID: 42172
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __跳跃抬起事件_FunctionParams
		{
			// Token: 0x040332FB RID: 209659
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4BD RID: 42173
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __跳跃按下事件_FunctionParams
		{
			// Token: 0x040332FC RID: 209660
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x0200A4BE RID: 42174
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __GetUnrealHoldConfig_FunctionParams
		{
			// Token: 0x040332FD RID: 209661
			[FieldOffset(0)]
			public int action;

			// Token: 0x040332FE RID: 209662
			[FieldOffset(4)]
			public SInputHoldConfig __Result;
		}

		// Token: 0x0200A4BF RID: 42175
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetUnrealCacheConfig_FunctionParams
		{
			// Token: 0x040332FF RID: 209663
			[FieldOffset(0)]
			public int action;

			// Token: 0x04033300 RID: 209664
			[FieldOffset(4)]
			public SInputCaches __Result;
		}

		// Token: 0x0200A4C0 RID: 42176
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04033301 RID: 209665
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200A4C1 RID: 42177
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_InputBase_FunctionParams
		{
			// Token: 0x04033302 RID: 209666
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
