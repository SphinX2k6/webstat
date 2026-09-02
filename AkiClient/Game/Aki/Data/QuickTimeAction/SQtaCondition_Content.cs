using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E1F RID: 15903
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaCondition_Content.SQtaCondition_Content")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 43)]
	public class SQtaCondition_Content : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602730C RID: 160524 RVA: 0x009EBF77 File Offset: 0x009EA177
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCondition_Content._ScriptStructPtr != 0) ? SQtaCondition_Content._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaCondition_Content.SQtaCondition_Content", ref SQtaCondition_Content._ScriptStructPtr);
		}

		// Token: 0x17005B8C RID: 23436
		// (get) Token: 0x0602730D RID: 160525 RVA: 0x009EBF9B File Offset: 0x009EA19B
		// (set) Token: 0x0602730E RID: 160526 RVA: 0x009EBFAF File Offset: 0x009EA1AF
		public unsafe TEnumAsByte<EQtaConditionType> ConditionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B8D RID: 23437
		// (get) Token: 0x0602730F RID: 160527 RVA: 0x009EBFC4 File Offset: 0x009EA1C4
		// (set) Token: 0x06027310 RID: 160528 RVA: 0x009EBFD8 File Offset: 0x009EA1D8
		public unsafe TEnumAsByte<EQtaCondition_CheckInputType> InputMatchType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B8E RID: 23438
		// (get) Token: 0x06027311 RID: 160529 RVA: 0x009EBFF0 File Offset: 0x009EA1F0
		// (set) Token: 0x06027312 RID: 160530 RVA: 0x009EC033 File Offset: 0x009EA233
		[Nullable(1)]
		public FGameplayTagContainer Tags
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._Tags) == null)
				{
					result = (this._Tags = new FGameplayTagContainer(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005B8F RID: 23439
		// (get) Token: 0x06027313 RID: 160531 RVA: 0x009EC054 File Offset: 0x009EA254
		// (set) Token: 0x06027314 RID: 160532 RVA: 0x009EC064 File Offset: 0x009EA264
		public unsafe bool AnyTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B90 RID: 23440
		// (get) Token: 0x06027315 RID: 160533 RVA: 0x009EC075 File Offset: 0x009EA275
		// (set) Token: 0x06027316 RID: 160534 RVA: 0x009EC089 File Offset: 0x009EA289
		public unsafe TEnumAsByte<EQtaCondition_EventName> EventName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005B91 RID: 23441
		// (get) Token: 0x06027317 RID: 160535 RVA: 0x009EC09E File Offset: 0x009EA29E
		// (set) Token: 0x06027318 RID: 160536 RVA: 0x009EC0AE File Offset: 0x009EA2AE
		public unsafe bool Reverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCondition_Content.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027319 RID: 160537 RVA: 0x009EC0BF File Offset: 0x009EA2BF
		public SQtaCondition_Content()
		{
		}

		// Token: 0x0602731A RID: 160538 RVA: 0x009EC0C7 File Offset: 0x009EA2C7
		public SQtaCondition_Content(TEnumAsByte<EQtaConditionType> ConditionType, TEnumAsByte<EQtaCondition_CheckInputType> InputMatchType, [Nullable(1)] FGameplayTagContainer Tags, bool AnyTag, TEnumAsByte<EQtaCondition_EventName> EventName, bool Reverse)
		{
			this.ConditionType = ConditionType;
			this.InputMatchType = InputMatchType;
			this.Tags = Tags;
			this.AnyTag = AnyTag;
			this.EventName = EventName;
			this.Reverse = Reverse;
		}

		// Token: 0x0602731B RID: 160539 RVA: 0x009EC0FC File Offset: 0x009EA2FC
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCondition_Content.StaticStruct();
		}

		// Token: 0x0602731C RID: 160540 RVA: 0x009EC108 File Offset: 0x009EA308
		[NullableContext(2)]
		public SQtaCondition_Content(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602731D RID: 160541 RVA: 0x009EC112 File Offset: 0x009EA312
		public SQtaCondition_Content(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602731E RID: 160542 RVA: 0x009EC11D File Offset: 0x009EA31D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCondition_Content(Pointer, false, true);
		}

		// Token: 0x0602731F RID: 160543 RVA: 0x009EC127 File Offset: 0x009EA327
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCondition_Content(Pointer, MemoryOwner);
		}

		// Token: 0x040147DA RID: 83930
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaCondition_Content.SQtaCondition_Content";

		// Token: 0x040147DB RID: 83931
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147DC RID: 83932
		internal static int __PropertyOffset_0;

		// Token: 0x040147DD RID: 83933
		internal static int __PropertyOffset_1;

		// Token: 0x040147DE RID: 83934
		internal static int __PropertyOffset_2;

		// Token: 0x040147DF RID: 83935
		[Nullable(2)]
		private FGameplayTagContainer _Tags;

		// Token: 0x040147E0 RID: 83936
		internal static int __PropertyOffset_3;

		// Token: 0x040147E1 RID: 83937
		internal static int __PropertyOffset_4;

		// Token: 0x040147E2 RID: 83938
		internal static int __PropertyOffset_5;
	}
}
