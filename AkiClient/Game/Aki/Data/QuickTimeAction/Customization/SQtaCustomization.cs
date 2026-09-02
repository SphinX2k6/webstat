using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E29 RID: 15913
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization.SQtaCustomization")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SQtaCustomization : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602736C RID: 160620 RVA: 0x009EC888 File Offset: 0x009EAA88
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCustomization._ScriptStructPtr != 0) ? SQtaCustomization._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization.SQtaCustomization", ref SQtaCustomization._ScriptStructPtr);
		}

		// Token: 0x17005BA2 RID: 23458
		// (get) Token: 0x0602736D RID: 160621 RVA: 0x009EC8AC File Offset: 0x009EAAAC
		// (set) Token: 0x0602736E RID: 160622 RVA: 0x009EC8C0 File Offset: 0x009EAAC0
		[Nullable(0)]
		public unsafe TEnumAsByte<EQtaCustomizationViewType> ViewType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomization.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomization.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BA3 RID: 23459
		// (get) Token: 0x0602736F RID: 160623 RVA: 0x009EC8D5 File Offset: 0x009EAAD5
		// (set) Token: 0x06027370 RID: 160624 RVA: 0x009EC8E9 File Offset: 0x009EAAE9
		public unsafe string ViewName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SQtaCustomization.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SQtaCustomization.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005BA4 RID: 23460
		// (get) Token: 0x06027371 RID: 160625 RVA: 0x009EC8FE File Offset: 0x009EAAFE
		// (set) Token: 0x06027372 RID: 160626 RVA: 0x009EC91D File Offset: 0x009EAB1D
		public TSoftObjectPtr<BP_QtaCustomizationBase_C> DaConfig
		{
			get
			{
				return new TSoftObjectPtr<BP_QtaCustomizationBase_C>(base.NativePtr + (IntPtr)SQtaCustomization.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaCustomization.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027373 RID: 160627 RVA: 0x009EC942 File Offset: 0x009EAB42
		public SQtaCustomization()
		{
		}

		// Token: 0x06027374 RID: 160628 RVA: 0x009EC94A File Offset: 0x009EAB4A
		public SQtaCustomization([Nullable(0)] TEnumAsByte<EQtaCustomizationViewType> ViewType, string ViewName, TSoftObjectPtr<BP_QtaCustomizationBase_C> DaConfig)
		{
			this.ViewType = ViewType;
			this.ViewName = ViewName;
			this.DaConfig = DaConfig;
		}

		// Token: 0x06027375 RID: 160629 RVA: 0x009EC967 File Offset: 0x009EAB67
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCustomization.StaticStruct();
		}

		// Token: 0x06027376 RID: 160630 RVA: 0x009EC973 File Offset: 0x009EAB73
		[NullableContext(2)]
		public SQtaCustomization(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027377 RID: 160631 RVA: 0x009EC97D File Offset: 0x009EAB7D
		public SQtaCustomization(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027378 RID: 160632 RVA: 0x009EC988 File Offset: 0x009EAB88
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCustomization(Pointer, false, true);
		}

		// Token: 0x06027379 RID: 160633 RVA: 0x009EC992 File Offset: 0x009EAB92
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCustomization(Pointer, MemoryOwner);
		}

		// Token: 0x04014814 RID: 83988
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomization.SQtaCustomization";

		// Token: 0x04014815 RID: 83989
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014816 RID: 83990
		internal static int __PropertyOffset_0;

		// Token: 0x04014817 RID: 83991
		internal static int __PropertyOffset_1;

		// Token: 0x04014818 RID: 83992
		internal static int __PropertyOffset_2;
	}
}
