using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041CC RID: 16844
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_KuroCheatManager.BP_KuroCheatManager_C")]
	[UnrealStructLayout(296, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 296)]
	public class BP_KuroCheatManager_C : UCheatManager, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CCB5 RID: 183477 RVA: 0x00AAFC7C File Offset: 0x00AADE7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroCheatManager_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_KuroCheatManager.BP_KuroCheatManager_C");
			}
			return BP_KuroCheatManager_C._ClassPtr;
		}

		// Token: 0x0602CCB6 RID: 183478 RVA: 0x00AAFCA0 File Offset: 0x00AADEA0
		public BP_KuroCheatManager_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroCheatManager_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CCB7 RID: 183479 RVA: 0x00AAFCC8 File Offset: 0x00AADEC8
		public BP_KuroCheatManager_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroCheatManager_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007913 RID: 30995
		// (get) Token: 0x0602CCB8 RID: 183480 RVA: 0x00AAFCFC File Offset: 0x00AADEFC
		// (set) Token: 0x0602CCB9 RID: 183481 RVA: 0x00AAFD35 File Offset: 0x00AADF35
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007914 RID: 30996
		// (get) Token: 0x0602CCBA RID: 183482 RVA: 0x00AAFD56 File Offset: 0x00AADF56
		// (set) Token: 0x0602CCBB RID: 183483 RVA: 0x00AAFD6A File Offset: 0x00AADF6A
		[Nullable(2)]
		public unsafe BP_CharacterController_C CharacterController
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_CharacterController_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCheatManager_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroCheatManager_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007915 RID: 30997
		// (get) Token: 0x0602CCBC RID: 183484 RVA: 0x00AAFD80 File Offset: 0x00AADF80
		// (set) Token: 0x0602CCBD RID: 183485 RVA: 0x00AAFDB9 File Offset: 0x00AADFB9
		public FKey 输入按键
		{
			get
			{
				base.FastCheckIsValid();
				FKey result;
				if ((result = this._输入按键) == null)
				{
					result = (this._输入按键 = new FKey(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007916 RID: 30998
		// (get) Token: 0x0602CCBE RID: 183486 RVA: 0x00AAFDDA File Offset: 0x00AADFDA
		// (set) Token: 0x0602CCBF RID: 183487 RVA: 0x00AAFDEA File Offset: 0x00AADFEA
		public unsafe bool 按下
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007917 RID: 30999
		// (get) Token: 0x0602CCC0 RID: 183488 RVA: 0x00AAFDFB File Offset: 0x00AADFFB
		// (set) Token: 0x0602CCC1 RID: 183489 RVA: 0x00AAFE0B File Offset: 0x00AAE00B
		public unsafe bool LeftAlt
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007918 RID: 31000
		// (get) Token: 0x0602CCC2 RID: 183490 RVA: 0x00AAFE1C File Offset: 0x00AAE01C
		// (set) Token: 0x0602CCC3 RID: 183491 RVA: 0x00AAFE2C File Offset: 0x00AAE02C
		public unsafe bool LeftCtrl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007919 RID: 31001
		// (get) Token: 0x0602CCC4 RID: 183492 RVA: 0x00AAFE3D File Offset: 0x00AAE03D
		// (set) Token: 0x0602CCC5 RID: 183493 RVA: 0x00AAFE4D File Offset: 0x00AAE04D
		public unsafe float 全局TimeDilation倍数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700791A RID: 31002
		// (get) Token: 0x0602CCC6 RID: 183494 RVA: 0x00AAFE5E File Offset: 0x00AAE05E
		// (set) Token: 0x0602CCC7 RID: 183495 RVA: 0x00AAFE6E File Offset: 0x00AAE06E
		public unsafe float LastDebugPressTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700791B RID: 31003
		// (get) Token: 0x0602CCC8 RID: 183496 RVA: 0x00AAFE7F File Offset: 0x00AAE07F
		// (set) Token: 0x0602CCC9 RID: 183497 RVA: 0x00AAFE8F File Offset: 0x00AAE08F
		public unsafe bool DebugSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700791C RID: 31004
		// (get) Token: 0x0602CCCA RID: 183498 RVA: 0x00AAFEA0 File Offset: 0x00AAE0A0
		// (set) Token: 0x0602CCCB RID: 183499 RVA: 0x00AAFEB0 File Offset: 0x00AAE0B0
		public unsafe bool GhostMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700791D RID: 31005
		// (get) Token: 0x0602CCCC RID: 183500 RVA: 0x00AAFEC4 File Offset: 0x00AAE0C4
		// (set) Token: 0x0602CCCD RID: 183501 RVA: 0x00AAFEFD File Offset: 0x00AAE0FD
		public TSet<TsBaseCharacter> 被销毁怪物缓存
		{
			get
			{
				base.FastCheckIsValid();
				TSet<TsBaseCharacter> result;
				if ((result = this._被销毁怪物缓存) == null)
				{
					result = (this._被销毁怪物缓存 = new TSet<TsBaseCharacter>(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.被销毁怪物缓存.CopyAssign(value);
			}
		}

		// Token: 0x1700791E RID: 31006
		// (get) Token: 0x0602CCCE RID: 183502 RVA: 0x00AAFF0B File Offset: 0x00AAE10B
		// (set) Token: 0x0602CCCF RID: 183503 RVA: 0x00AAFF1B File Offset: 0x00AAE11B
		public unsafe float TouchDebugSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700791F RID: 31007
		// (get) Token: 0x0602CCD0 RID: 183504 RVA: 0x00AAFF2C File Offset: 0x00AAE12C
		// (set) Token: 0x0602CCD1 RID: 183505 RVA: 0x00AAFF3C File Offset: 0x00AAE13C
		public unsafe bool 角色是否已强化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007920 RID: 31008
		// (get) Token: 0x0602CCD2 RID: 183506 RVA: 0x00AAFF4D File Offset: 0x00AAE14D
		// (set) Token: 0x0602CCD3 RID: 183507 RVA: 0x00AAFF5D File Offset: 0x00AAE15D
		public unsafe bool RightCtrl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_KuroCheatManager_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CCD4 RID: 183508 RVA: 0x00AAFF70 File Offset: 0x00AAE170
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 强化或还原角色(bool 是否需要强化)
		{
			BP_KuroCheatManager_C.__强化或还原角色_FunctionParams* ptr = stackalloc BP_KuroCheatManager_C.__强化或还原角色_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroCheatManager_C.__强化或还原角色_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCheatManager_C.__强化或还原角色_NativeFunctionPtr, (void*)ptr, 1);
			ptr->是否需要强化 = 是否需要强化;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__强化或还原角色_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602CCD5 RID: 183509 RVA: 0x00AAFFB6 File Offset: 0x00AAE1B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TouchDebug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__TouchDebug_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCD6 RID: 183510 RVA: 0x00AAFFCA File Offset: 0x00AAE1CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void PrintTimeScale()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__PrintTimeScale_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCD7 RID: 183511 RVA: 0x00AAFFDE File Offset: 0x00AAE1DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateFunctionKey()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__UpdateFunctionKey_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCD8 RID: 183512 RVA: 0x00AAFFF4 File Offset: 0x00AAE1F4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 作弊指令(FKey 输入按键, bool 按下)
		{
			BP_KuroCheatManager_C.__作弊指令_FunctionParams* ptr = stackalloc BP_KuroCheatManager_C.__作弊指令_FunctionParams[(UIntPtr)287] + 15L / (long)sizeof(BP_KuroCheatManager_C.__作弊指令_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCheatManager_C.__作弊指令_NativeFunctionPtr, (void*)ptr, 1);
			if (输入按键 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FKey.StaticStruct(), &ptr->输入按键, 输入按键.NativePtr, 1, false);
			}
			ptr->按下 = 按下;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__作弊指令_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_KuroCheatManager_C.__作弊指令_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602CCD9 RID: 183513 RVA: 0x00AB0070 File Offset: 0x00AAE270
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveInitCheatManager()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroCheatManager_C.__ReceiveInitCheatManager_NativeFunctionPtr, null);
		}

		// Token: 0x0602CCDA RID: 183514 RVA: 0x00AB0084 File Offset: 0x00AAE284
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveInitCheatManager_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCheatManager_C.__ReceiveInitCheatManager_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602CCDB RID: 183515 RVA: 0x00AB009C File Offset: 0x00AAE29C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_KuroCheatManager(int EntryPoint)
		{
			BP_KuroCheatManager_C.__ExecuteUbergraph_BP_KuroCheatManager_FunctionParams* ptr = stackalloc BP_KuroCheatManager_C.__ExecuteUbergraph_BP_KuroCheatManager_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_KuroCheatManager_C.__ExecuteUbergraph_BP_KuroCheatManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroCheatManager_C.__ExecuteUbergraph_BP_KuroCheatManager_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroCheatManager_C.__ExecuteUbergraph_BP_KuroCheatManager_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602CCDC RID: 183516 RVA: 0x00AB00E3 File Offset: 0x00AAE2E3
		protected BP_KuroCheatManager_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F6C RID: 102252
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_KuroCheatManager.BP_KuroCheatManager_C";

		// Token: 0x04018F6D RID: 102253
		private static IntPtr _ClassPtr;

		// Token: 0x04018F6E RID: 102254
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F6F RID: 102255
		internal static int __PropertyOffset_0;

		// Token: 0x04018F70 RID: 102256
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018F71 RID: 102257
		internal static int __PropertyOffset_1;

		// Token: 0x04018F72 RID: 102258
		internal static int __PropertyOffset_2;

		// Token: 0x04018F73 RID: 102259
		[Nullable(2)]
		private FKey _输入按键;

		// Token: 0x04018F74 RID: 102260
		internal static int __PropertyOffset_3;

		// Token: 0x04018F75 RID: 102261
		internal static int __PropertyOffset_4;

		// Token: 0x04018F76 RID: 102262
		internal static int __PropertyOffset_5;

		// Token: 0x04018F77 RID: 102263
		internal static int __PropertyOffset_6;

		// Token: 0x04018F78 RID: 102264
		internal static int __PropertyOffset_7;

		// Token: 0x04018F79 RID: 102265
		internal static int __PropertyOffset_8;

		// Token: 0x04018F7A RID: 102266
		internal static int __PropertyOffset_9;

		// Token: 0x04018F7B RID: 102267
		internal static int __PropertyOffset_10;

		// Token: 0x04018F7C RID: 102268
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<TsBaseCharacter> _被销毁怪物缓存;

		// Token: 0x04018F7D RID: 102269
		internal static int __PropertyOffset_11;

		// Token: 0x04018F7E RID: 102270
		internal static int __PropertyOffset_12;

		// Token: 0x04018F7F RID: 102271
		internal static int __PropertyOffset_13;

		// Token: 0x04018F80 RID: 102272
		internal static int __PropertyOffset_14;

		// Token: 0x04018F81 RID: 102273
		private static IntPtr __强化或还原角色_NativeFunctionPtr;

		// Token: 0x04018F82 RID: 102274
		private static IntPtr __TouchDebug_NativeFunctionPtr;

		// Token: 0x04018F83 RID: 102275
		private static IntPtr __PrintTimeScale_NativeFunctionPtr;

		// Token: 0x04018F84 RID: 102276
		private static IntPtr __UpdateFunctionKey_NativeFunctionPtr;

		// Token: 0x04018F85 RID: 102277
		private static IntPtr __作弊指令_NativeFunctionPtr;

		// Token: 0x04018F86 RID: 102278
		private static IntPtr __ReceiveInitCheatManager_NativeFunctionPtr;

		// Token: 0x04018F87 RID: 102279
		private static IntPtr __ExecuteUbergraph_BP_KuroCheatManager_NativeFunctionPtr;

		// Token: 0x0200A521 RID: 42273
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __强化或还原角色_FunctionParams
		{
			// Token: 0x040333C8 RID: 209864
			[FieldOffset(0)]
			public bool 是否需要强化;
		}

		// Token: 0x0200A522 RID: 42274
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 272)]
		protected ref struct __作弊指令_FunctionParams
		{
			// Token: 0x040333C9 RID: 209865
			[FieldOffset(0)]
			public byte 输入按键;

			// Token: 0x040333CA RID: 209866
			[FieldOffset(32)]
			public bool 按下;
		}

		// Token: 0x0200A523 RID: 42275
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_KuroCheatManager_FunctionParams
		{
			// Token: 0x040333CB RID: 209867
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
