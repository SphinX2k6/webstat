using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E2B RID: 15915
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Event.SQtaCustomizationParam_Event")]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class SQtaCustomizationParam_Event : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027388 RID: 160648 RVA: 0x009ECAC9 File Offset: 0x009EACC9
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCustomizationParam_Event._ScriptStructPtr != 0) ? SQtaCustomizationParam_Event._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Event.SQtaCustomizationParam_Event", ref SQtaCustomizationParam_Event._ScriptStructPtr);
		}

		// Token: 0x17005BA8 RID: 23464
		// (get) Token: 0x06027389 RID: 160649 RVA: 0x009ECAED File Offset: 0x009EACED
		// (set) Token: 0x0602738A RID: 160650 RVA: 0x009ECB01 File Offset: 0x009EAD01
		public unsafe FGameplayTag EventTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BA9 RID: 23465
		// (get) Token: 0x0602738B RID: 160651 RVA: 0x009ECB16 File Offset: 0x009EAD16
		// (set) Token: 0x0602738C RID: 160652 RVA: 0x009ECB26 File Offset: 0x009EAD26
		public unsafe float Param1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BAA RID: 23466
		// (get) Token: 0x0602738D RID: 160653 RVA: 0x009ECB37 File Offset: 0x009EAD37
		// (set) Token: 0x0602738E RID: 160654 RVA: 0x009ECB47 File Offset: 0x009EAD47
		public unsafe float Param2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Event.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602738F RID: 160655 RVA: 0x009ECB58 File Offset: 0x009EAD58
		public SQtaCustomizationParam_Event()
		{
		}

		// Token: 0x06027390 RID: 160656 RVA: 0x009ECB60 File Offset: 0x009EAD60
		public SQtaCustomizationParam_Event(FGameplayTag EventTag, float Param1, float Param2)
		{
			this.EventTag = EventTag;
			this.Param1 = Param1;
			this.Param2 = Param2;
		}

		// Token: 0x06027391 RID: 160657 RVA: 0x009ECB7D File Offset: 0x009EAD7D
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCustomizationParam_Event.StaticStruct();
		}

		// Token: 0x06027392 RID: 160658 RVA: 0x009ECB89 File Offset: 0x009EAD89
		[NullableContext(2)]
		public SQtaCustomizationParam_Event(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027393 RID: 160659 RVA: 0x009ECB93 File Offset: 0x009EAD93
		public SQtaCustomizationParam_Event(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027394 RID: 160660 RVA: 0x009ECB9E File Offset: 0x009EAD9E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCustomizationParam_Event(Pointer, false, true);
		}

		// Token: 0x06027395 RID: 160661 RVA: 0x009ECBA8 File Offset: 0x009EADA8
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCustomizationParam_Event(Pointer, MemoryOwner);
		}

		// Token: 0x0401481F RID: 83999
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Event.SQtaCustomizationParam_Event";

		// Token: 0x04014820 RID: 84000
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014821 RID: 84001
		internal static int __PropertyOffset_0;

		// Token: 0x04014822 RID: 84002
		internal static int __PropertyOffset_1;

		// Token: 0x04014823 RID: 84003
		internal static int __PropertyOffset_2;
	}
}
