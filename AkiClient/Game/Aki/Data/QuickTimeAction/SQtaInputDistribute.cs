using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E20 RID: 15904
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaInputDistribute.SQtaInputDistribute")]
	[UnrealStructLayout(5, 1, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 5)]
	public class SQtaInputDistribute : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027320 RID: 160544 RVA: 0x009EC130 File Offset: 0x009EA330
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaInputDistribute._ScriptStructPtr != 0) ? SQtaInputDistribute._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaInputDistribute.SQtaInputDistribute", ref SQtaInputDistribute._ScriptStructPtr);
		}

		// Token: 0x17005B92 RID: 23442
		// (get) Token: 0x06027321 RID: 160545 RVA: 0x009EC154 File Offset: 0x009EA354
		// (set) Token: 0x06027322 RID: 160546 RVA: 0x009EC164 File Offset: 0x009EA364
		public unsafe bool FightInputRoot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B93 RID: 23443
		// (get) Token: 0x06027323 RID: 160547 RVA: 0x009EC175 File Offset: 0x009EA375
		// (set) Token: 0x06027324 RID: 160548 RVA: 0x009EC185 File Offset: 0x009EA385
		public unsafe bool FightActionInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B94 RID: 23444
		// (get) Token: 0x06027325 RID: 160549 RVA: 0x009EC196 File Offset: 0x009EA396
		// (set) Token: 0x06027326 RID: 160550 RVA: 0x009EC1A6 File Offset: 0x009EA3A6
		public unsafe bool FightAxisInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B95 RID: 23445
		// (get) Token: 0x06027327 RID: 160551 RVA: 0x009EC1B7 File Offset: 0x009EA3B7
		// (set) Token: 0x06027328 RID: 160552 RVA: 0x009EC1C7 File Offset: 0x009EA3C7
		public unsafe bool InteractionRoot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B96 RID: 23446
		// (get) Token: 0x06027329 RID: 160553 RVA: 0x009EC1D8 File Offset: 0x009EA3D8
		// (set) Token: 0x0602732A RID: 160554 RVA: 0x009EC1E8 File Offset: 0x009EA3E8
		public unsafe bool UiInputRoot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaInputDistribute.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602732B RID: 160555 RVA: 0x009EC1F9 File Offset: 0x009EA3F9
		public SQtaInputDistribute()
		{
		}

		// Token: 0x0602732C RID: 160556 RVA: 0x009EC201 File Offset: 0x009EA401
		public SQtaInputDistribute(bool FightInputRoot, bool FightActionInput, bool FightAxisInput, bool InteractionRoot, bool UiInputRoot)
		{
			this.FightInputRoot = FightInputRoot;
			this.FightActionInput = FightActionInput;
			this.FightAxisInput = FightAxisInput;
			this.InteractionRoot = InteractionRoot;
			this.UiInputRoot = UiInputRoot;
		}

		// Token: 0x0602732D RID: 160557 RVA: 0x009EC22E File Offset: 0x009EA42E
		protected override IntPtr GetUStructPtr()
		{
			return SQtaInputDistribute.StaticStruct();
		}

		// Token: 0x0602732E RID: 160558 RVA: 0x009EC23A File Offset: 0x009EA43A
		[NullableContext(2)]
		public SQtaInputDistribute(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602732F RID: 160559 RVA: 0x009EC244 File Offset: 0x009EA444
		public SQtaInputDistribute(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027330 RID: 160560 RVA: 0x009EC24F File Offset: 0x009EA44F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaInputDistribute(Pointer, false, true);
		}

		// Token: 0x06027331 RID: 160561 RVA: 0x009EC259 File Offset: 0x009EA459
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaInputDistribute(Pointer, MemoryOwner);
		}

		// Token: 0x040147E3 RID: 83939
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaInputDistribute.SQtaInputDistribute";

		// Token: 0x040147E4 RID: 83940
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147E5 RID: 83941
		internal static int __PropertyOffset_0;

		// Token: 0x040147E6 RID: 83942
		internal static int __PropertyOffset_1;

		// Token: 0x040147E7 RID: 83943
		internal static int __PropertyOffset_2;

		// Token: 0x040147E8 RID: 83944
		internal static int __PropertyOffset_3;

		// Token: 0x040147E9 RID: 83945
		internal static int __PropertyOffset_4;
	}
}
