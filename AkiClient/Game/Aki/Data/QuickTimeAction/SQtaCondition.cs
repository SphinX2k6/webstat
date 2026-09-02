using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E1E RID: 15902
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaCondition.SQtaCondition")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SQtaCondition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027300 RID: 160512 RVA: 0x009EBE84 File Offset: 0x009EA084
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCondition._ScriptStructPtr != 0) ? SQtaCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaCondition.SQtaCondition", ref SQtaCondition._ScriptStructPtr);
		}

		// Token: 0x17005B8A RID: 23434
		// (get) Token: 0x06027301 RID: 160513 RVA: 0x009EBEA8 File Offset: 0x009EA0A8
		// (set) Token: 0x06027302 RID: 160514 RVA: 0x009EBEBC File Offset: 0x009EA0BC
		public unsafe string Formula
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SQtaCondition.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SQtaCondition.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005B8B RID: 23435
		// (get) Token: 0x06027303 RID: 160515 RVA: 0x009EBED4 File Offset: 0x009EA0D4
		// (set) Token: 0x06027304 RID: 160516 RVA: 0x009EBF17 File Offset: 0x009EA117
		public TArray<SQtaCondition_Content> Contents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SQtaCondition_Content> result;
				if ((result = this._Contents) == null)
				{
					result = (this._Contents = new TArray<SQtaCondition_Content>(base.NativePtr + (IntPtr)SQtaCondition.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Contents.CopyAssign(value);
			}
		}

		// Token: 0x06027305 RID: 160517 RVA: 0x009EBF25 File Offset: 0x009EA125
		public SQtaCondition()
		{
		}

		// Token: 0x06027306 RID: 160518 RVA: 0x009EBF2D File Offset: 0x009EA12D
		public SQtaCondition(string Formula, TArray<SQtaCondition_Content> Contents)
		{
			this.Formula = Formula;
			this.Contents = Contents;
		}

		// Token: 0x06027307 RID: 160519 RVA: 0x009EBF43 File Offset: 0x009EA143
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCondition.StaticStruct();
		}

		// Token: 0x06027308 RID: 160520 RVA: 0x009EBF4F File Offset: 0x009EA14F
		[NullableContext(2)]
		public SQtaCondition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027309 RID: 160521 RVA: 0x009EBF59 File Offset: 0x009EA159
		public SQtaCondition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602730A RID: 160522 RVA: 0x009EBF64 File Offset: 0x009EA164
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCondition(Pointer, false, true);
		}

		// Token: 0x0602730B RID: 160523 RVA: 0x009EBF6E File Offset: 0x009EA16E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCondition(Pointer, MemoryOwner);
		}

		// Token: 0x040147D5 RID: 83925
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaCondition.SQtaCondition";

		// Token: 0x040147D6 RID: 83926
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147D7 RID: 83927
		internal static int __PropertyOffset_0;

		// Token: 0x040147D8 RID: 83928
		internal static int __PropertyOffset_1;

		// Token: 0x040147D9 RID: 83929
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SQtaCondition_Content> _Contents;
	}
}
