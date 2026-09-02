using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F35 RID: 16181
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/BP_MainGameInstance.BP_MainGameInstance_C")]
	[UnrealStructLayout(480, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 473)]
	public class BP_MainGameInstance_C : UGameInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028662 RID: 165474 RVA: 0x00A09599 File Offset: 0x00A07799
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MainGameInstance_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_MainGameInstance.BP_MainGameInstance_C");
			}
			return BP_MainGameInstance_C._ClassPtr;
		}

		// Token: 0x06028663 RID: 165475 RVA: 0x00A095C0 File Offset: 0x00A077C0
		public BP_MainGameInstance_C() : this(BuiltinUtils.AllocNativeUObject(BP_MainGameInstance_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028664 RID: 165476 RVA: 0x00A095E8 File Offset: 0x00A077E8
		public BP_MainGameInstance_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MainGameInstance_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006225 RID: 25125
		// (get) Token: 0x06028665 RID: 165477 RVA: 0x00A0961C File Offset: 0x00A0781C
		// (set) Token: 0x06028666 RID: 165478 RVA: 0x00A09655 File Offset: 0x00A07855
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MainGameInstance_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MainGameInstance_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006226 RID: 25126
		// (get) Token: 0x06028667 RID: 165479 RVA: 0x00A09676 File Offset: 0x00A07876
		// (set) Token: 0x06028668 RID: 165480 RVA: 0x00A0968A File Offset: 0x00A0788A
		[Nullable(2)]
		public unsafe ULoadMapNotify 场景加载通知器
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ULoadMapNotify>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainGameInstance_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainGameInstance_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006227 RID: 25127
		// (get) Token: 0x06028669 RID: 165481 RVA: 0x00A0969F File Offset: 0x00A0789F
		// (set) Token: 0x0602866A RID: 165482 RVA: 0x00A096AF File Offset: 0x00A078AF
		public unsafe bool IsStartFromLaunch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MainGameInstance_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MainGameInstance_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602866B RID: 165483 RVA: 0x00A096C0 File Offset: 0x00A078C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StartGame()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MainGameInstance_C.__StartGame_NativeFunctionPtr, null);
		}

		// Token: 0x0602866C RID: 165484 RVA: 0x00A096D4 File Offset: 0x00A078D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reboot()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MainGameInstance_C.__Reboot_NativeFunctionPtr, null);
		}

		// Token: 0x0602866D RID: 165485 RVA: 0x00A096E8 File Offset: 0x00A078E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MountGamePak()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MainGameInstance_C.__MountGamePak_NativeFunctionPtr, null);
		}

		// Token: 0x0602866E RID: 165486 RVA: 0x00A096FC File Offset: 0x00A078FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void MountLauncherPak()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MainGameInstance_C.__MountLauncherPak_NativeFunctionPtr, null);
		}

		// Token: 0x0602866F RID: 165487 RVA: 0x00A09710 File Offset: 0x00A07910
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveInit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MainGameInstance_C.__ReceiveInit_NativeFunctionPtr, null);
		}

		// Token: 0x06028670 RID: 165488 RVA: 0x00A09724 File Offset: 0x00A07924
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveInit_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MainGameInstance_C.__ReceiveInit_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028671 RID: 165489 RVA: 0x00A0973C File Offset: 0x00A0793C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MainGameInstance(int EntryPoint)
		{
			BP_MainGameInstance_C.__ExecuteUbergraph_BP_MainGameInstance_FunctionParams* ptr = stackalloc BP_MainGameInstance_C.__ExecuteUbergraph_BP_MainGameInstance_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MainGameInstance_C.__ExecuteUbergraph_BP_MainGameInstance_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MainGameInstance_C.__ExecuteUbergraph_BP_MainGameInstance_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MainGameInstance_C.__ExecuteUbergraph_BP_MainGameInstance_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028672 RID: 165490 RVA: 0x00A09783 File Offset: 0x00A07983
		protected BP_MainGameInstance_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040153F0 RID: 87024
		public new const string __ObjectPath = "/Game/Aki/Core/BP_MainGameInstance.BP_MainGameInstance_C";

		// Token: 0x040153F1 RID: 87025
		private static IntPtr _ClassPtr;

		// Token: 0x040153F2 RID: 87026
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040153F3 RID: 87027
		internal static int __PropertyOffset_0;

		// Token: 0x040153F4 RID: 87028
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040153F5 RID: 87029
		internal static int __PropertyOffset_1;

		// Token: 0x040153F6 RID: 87030
		internal static int __PropertyOffset_2;

		// Token: 0x040153F7 RID: 87031
		private static IntPtr __StartGame_NativeFunctionPtr;

		// Token: 0x040153F8 RID: 87032
		private static IntPtr __Reboot_NativeFunctionPtr;

		// Token: 0x040153F9 RID: 87033
		private static IntPtr __MountGamePak_NativeFunctionPtr;

		// Token: 0x040153FA RID: 87034
		private static IntPtr __MountLauncherPak_NativeFunctionPtr;

		// Token: 0x040153FB RID: 87035
		private static IntPtr __ReceiveInit_NativeFunctionPtr;

		// Token: 0x040153FC RID: 87036
		private static IntPtr __ExecuteUbergraph_BP_MainGameInstance_NativeFunctionPtr;

		// Token: 0x0200A0E5 RID: 41189
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_MainGameInstance_FunctionParams
		{
			// Token: 0x04032DA4 RID: 208292
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
