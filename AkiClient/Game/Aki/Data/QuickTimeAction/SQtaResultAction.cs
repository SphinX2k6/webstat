using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E23 RID: 15907
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaResultAction.SQtaResultAction")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SQtaResultAction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027352 RID: 160594 RVA: 0x009EC5A2 File Offset: 0x009EA7A2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaResultAction._ScriptStructPtr != 0) ? SQtaResultAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaResultAction.SQtaResultAction", ref SQtaResultAction._ScriptStructPtr);
		}

		// Token: 0x17005B9F RID: 23455
		// (get) Token: 0x06027353 RID: 160595 RVA: 0x009EC5C6 File Offset: 0x009EA7C6
		// (set) Token: 0x06027354 RID: 160596 RVA: 0x009EC5DA File Offset: 0x009EA7DA
		public unsafe TEnumAsByte<EQtaResultType> ResultType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaResultAction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaResultAction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BA0 RID: 23456
		// (get) Token: 0x06027355 RID: 160597 RVA: 0x009EC5F0 File Offset: 0x009EA7F0
		// (set) Token: 0x06027356 RID: 160598 RVA: 0x009EC633 File Offset: 0x009EA833
		[Nullable(1)]
		public TArray<SBattleQteAction> Actions
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SBattleQteAction> result;
				if ((result = this._Actions) == null)
				{
					result = (this._Actions = new TArray<SBattleQteAction>(base.NativePtr + (IntPtr)SQtaResultAction.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Actions.CopyAssign(value);
			}
		}

		// Token: 0x06027357 RID: 160599 RVA: 0x009EC641 File Offset: 0x009EA841
		public SQtaResultAction()
		{
		}

		// Token: 0x06027358 RID: 160600 RVA: 0x009EC649 File Offset: 0x009EA849
		public SQtaResultAction(TEnumAsByte<EQtaResultType> ResultType, [Nullable(1)] TArray<SBattleQteAction> Actions)
		{
			this.ResultType = ResultType;
			this.Actions = Actions;
		}

		// Token: 0x06027359 RID: 160601 RVA: 0x009EC65F File Offset: 0x009EA85F
		protected override IntPtr GetUStructPtr()
		{
			return SQtaResultAction.StaticStruct();
		}

		// Token: 0x0602735A RID: 160602 RVA: 0x009EC66B File Offset: 0x009EA86B
		[NullableContext(2)]
		public SQtaResultAction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602735B RID: 160603 RVA: 0x009EC675 File Offset: 0x009EA875
		public SQtaResultAction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602735C RID: 160604 RVA: 0x009EC680 File Offset: 0x009EA880
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaResultAction(Pointer, false, true);
		}

		// Token: 0x0602735D RID: 160605 RVA: 0x009EC68A File Offset: 0x009EA88A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaResultAction(Pointer, MemoryOwner);
		}

		// Token: 0x040147F8 RID: 83960
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaResultAction.SQtaResultAction";

		// Token: 0x040147F9 RID: 83961
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147FA RID: 83962
		internal static int __PropertyOffset_0;

		// Token: 0x040147FB RID: 83963
		internal static int __PropertyOffset_1;

		// Token: 0x040147FC RID: 83964
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SBattleQteAction> _Actions;
	}
}
