using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.UiNavigation.Struct
{
	// Token: 0x02003DF6 RID: 15862
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Struct/SNavigationDynamicListenerConfig.SNavigationDynamicListenerConfig")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 25)]
	public class SNavigationDynamicListenerConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602704F RID: 159823 RVA: 0x009E8261 File Offset: 0x009E6461
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNavigationDynamicListenerConfig._ScriptStructPtr != 0) ? SNavigationDynamicListenerConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiNavigation/Struct/SNavigationDynamicListenerConfig.SNavigationDynamicListenerConfig", ref SNavigationDynamicListenerConfig._ScriptStructPtr);
		}

		// Token: 0x17005A8B RID: 23179
		// (get) Token: 0x06027050 RID: 159824 RVA: 0x009E8285 File Offset: 0x009E6485
		// (set) Token: 0x06027051 RID: 159825 RVA: 0x009E8295 File Offset: 0x009E6495
		public unsafe int Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationDynamicListenerConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationDynamicListenerConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005A8C RID: 23180
		// (get) Token: 0x06027052 RID: 159826 RVA: 0x009E82A6 File Offset: 0x009E64A6
		// (set) Token: 0x06027053 RID: 159827 RVA: 0x009E82BA File Offset: 0x009E64BA
		public unsafe AActor LayoutActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationDynamicListenerConfig.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationDynamicListenerConfig.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005A8D RID: 23181
		// (get) Token: 0x06027054 RID: 159828 RVA: 0x009E82CF File Offset: 0x009E64CF
		// (set) Token: 0x06027055 RID: 159829 RVA: 0x009E82E3 File Offset: 0x009E64E3
		public unsafe AActor ScrollActor
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationDynamicListenerConfig.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SNavigationDynamicListenerConfig.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005A8E RID: 23182
		// (get) Token: 0x06027056 RID: 159830 RVA: 0x009E82F8 File Offset: 0x009E64F8
		// (set) Token: 0x06027057 RID: 159831 RVA: 0x009E8308 File Offset: 0x009E6508
		public unsafe bool NeedWaitRegister
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationDynamicListenerConfig.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationDynamicListenerConfig.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027058 RID: 159832 RVA: 0x009E8319 File Offset: 0x009E6519
		public SNavigationDynamicListenerConfig()
		{
		}

		// Token: 0x06027059 RID: 159833 RVA: 0x009E8321 File Offset: 0x009E6521
		[NullableContext(1)]
		public SNavigationDynamicListenerConfig(int Index, AActor LayoutActor, AActor ScrollActor, bool NeedWaitRegister)
		{
			this.Index = Index;
			this.LayoutActor = LayoutActor;
			this.ScrollActor = ScrollActor;
			this.NeedWaitRegister = NeedWaitRegister;
		}

		// Token: 0x0602705A RID: 159834 RVA: 0x009E8346 File Offset: 0x009E6546
		protected override IntPtr GetUStructPtr()
		{
			return SNavigationDynamicListenerConfig.StaticStruct();
		}

		// Token: 0x0602705B RID: 159835 RVA: 0x009E8352 File Offset: 0x009E6552
		public SNavigationDynamicListenerConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602705C RID: 159836 RVA: 0x009E835C File Offset: 0x009E655C
		public SNavigationDynamicListenerConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602705D RID: 159837 RVA: 0x009E8367 File Offset: 0x009E6567
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNavigationDynamicListenerConfig(Pointer, false, true);
		}

		// Token: 0x0602705E RID: 159838 RVA: 0x009E8371 File Offset: 0x009E6571
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNavigationDynamicListenerConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401461B RID: 83483
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/UiNavigation/Struct/SNavigationDynamicListenerConfig.SNavigationDynamicListenerConfig";

		// Token: 0x0401461C RID: 83484
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401461D RID: 83485
		internal static int __PropertyOffset_0;

		// Token: 0x0401461E RID: 83486
		internal static int __PropertyOffset_1;

		// Token: 0x0401461F RID: 83487
		internal static int __PropertyOffset_2;

		// Token: 0x04014620 RID: 83488
		internal static int __PropertyOffset_3;
	}
}
