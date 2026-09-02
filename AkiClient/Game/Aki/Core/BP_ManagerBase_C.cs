using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.UI.Manager;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F38 RID: 16184
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/BP_ManagerBase.BP_ManagerBase_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_ManagerBase_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602867F RID: 165503 RVA: 0x00A098F1 File Offset: 0x00A07AF1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ManagerBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_ManagerBase.BP_ManagerBase_C");
			}
			return BP_ManagerBase_C._ClassPtr;
		}

		// Token: 0x06028680 RID: 165504 RVA: 0x00A09918 File Offset: 0x00A07B18
		public BP_ManagerBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_ManagerBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028681 RID: 165505 RVA: 0x00A09940 File Offset: 0x00A07B40
		[NullableContext(1)]
		public BP_ManagerBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ManagerBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700622A RID: 25130
		// (get) Token: 0x06028682 RID: 165506 RVA: 0x00A09973 File Offset: 0x00A07B73
		// (set) Token: 0x06028683 RID: 165507 RVA: 0x00A09987 File Offset: 0x00A07B87
		public unsafe BP_MainGameInstance_C 游戏实例
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MainGameInstance_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700622B RID: 25131
		// (get) Token: 0x06028684 RID: 165508 RVA: 0x00A0999C File Offset: 0x00A07B9C
		// (set) Token: 0x06028685 RID: 165509 RVA: 0x00A099B0 File Offset: 0x00A07BB0
		public unsafe UObject 界面管理器
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700622C RID: 25132
		// (get) Token: 0x06028686 RID: 165510 RVA: 0x00A099C5 File Offset: 0x00A07BC5
		// (set) Token: 0x06028687 RID: 165511 RVA: 0x00A099D9 File Offset: 0x00A07BD9
		public unsafe BP_EventManager_C 事件管理器
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_EventManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ManagerBase_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06028688 RID: 165512 RVA: 0x00A099EE File Offset: 0x00A07BEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnLeaveWorld()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ManagerBase_C.__OnLeaveWorld_NativeFunctionPtr, null);
		}

		// Token: 0x06028689 RID: 165513 RVA: 0x00A09A04 File Offset: 0x00A07C04
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 初始化(BP_MainGameInstance_C 游戏实例)
		{
			BP_ManagerBase_C.__初始化_FunctionParams* ptr = stackalloc BP_ManagerBase_C.__初始化_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_ManagerBase_C.__初始化_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_ManagerBase_C.__初始化_NativeFunctionPtr, (void*)ptr, 1);
			ptr->游戏实例 = ((游戏实例 != null) ? 游戏实例.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_ManagerBase_C.__初始化_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602868A RID: 165514 RVA: 0x00A09A59 File Offset: 0x00A07C59
		protected BP_ManagerBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015405 RID: 87045
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_ManagerBase.BP_ManagerBase_C";

		// Token: 0x04015406 RID: 87046
		private static IntPtr _ClassPtr;

		// Token: 0x04015407 RID: 87047
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015408 RID: 87048
		internal static int __PropertyOffset_0;

		// Token: 0x04015409 RID: 87049
		internal static int __PropertyOffset_1;

		// Token: 0x0401540A RID: 87050
		internal static int __PropertyOffset_2;

		// Token: 0x0401540B RID: 87051
		private static IntPtr __OnLeaveWorld_NativeFunctionPtr;

		// Token: 0x0401540C RID: 87052
		private static IntPtr __初始化_NativeFunctionPtr;

		// Token: 0x0200A0E6 RID: 41190
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __初始化_FunctionParams
		{
			// Token: 0x04032DA5 RID: 208293
			[FieldOffset(0)]
			public IntPtr 游戏实例;
		}
	}
}
