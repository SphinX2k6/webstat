using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D7F RID: 15743
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorGroup.SMaterialControllerColorGroup")]
	[UnrealStructLayout(1632, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1632)]
	public class SMaterialControllerColorGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060266D8 RID: 157400 RVA: 0x009D7868 File Offset: 0x009D5A68
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerColorGroup._ScriptStructPtr != 0) ? SMaterialControllerColorGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorGroup.SMaterialControllerColorGroup", ref SMaterialControllerColorGroup._ScriptStructPtr);
		}

		// Token: 0x1700575B RID: 22363
		// (get) Token: 0x060266D9 RID: 157401 RVA: 0x009D788C File Offset: 0x009D5A8C
		// (set) Token: 0x060266DA RID: 157402 RVA: 0x009D78CF File Offset: 0x009D5ACF
		public FKuroCurveLinearColor Start
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._Start) == null)
				{
					result = (this._Start = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700575C RID: 22364
		// (get) Token: 0x060266DB RID: 157403 RVA: 0x009D78F0 File Offset: 0x009D5AF0
		// (set) Token: 0x060266DC RID: 157404 RVA: 0x009D7933 File Offset: 0x009D5B33
		public FKuroCurveLinearColor Loop
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._Loop) == null)
				{
					result = (this._Loop = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700575D RID: 22365
		// (get) Token: 0x060266DD RID: 157405 RVA: 0x009D7954 File Offset: 0x009D5B54
		// (set) Token: 0x060266DE RID: 157406 RVA: 0x009D7997 File Offset: 0x009D5B97
		public FKuroCurveLinearColor End
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._End) == null)
				{
					result = (this._End = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerColorGroup.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060266DF RID: 157407 RVA: 0x009D79B8 File Offset: 0x009D5BB8
		public SMaterialControllerColorGroup()
		{
		}

		// Token: 0x060266E0 RID: 157408 RVA: 0x009D79C0 File Offset: 0x009D5BC0
		public SMaterialControllerColorGroup(FKuroCurveLinearColor Start, FKuroCurveLinearColor Loop, FKuroCurveLinearColor End)
		{
			this.Start = Start;
			this.Loop = Loop;
			this.End = End;
		}

		// Token: 0x060266E1 RID: 157409 RVA: 0x009D79DD File Offset: 0x009D5BDD
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerColorGroup.StaticStruct();
		}

		// Token: 0x060266E2 RID: 157410 RVA: 0x009D79E9 File Offset: 0x009D5BE9
		[NullableContext(2)]
		public SMaterialControllerColorGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060266E3 RID: 157411 RVA: 0x009D79F3 File Offset: 0x009D5BF3
		public SMaterialControllerColorGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060266E4 RID: 157412 RVA: 0x009D79FE File Offset: 0x009D5BFE
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerColorGroup(Pointer, false, true);
		}

		// Token: 0x060266E5 RID: 157413 RVA: 0x009D7A08 File Offset: 0x009D5C08
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerColorGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04013F4F RID: 81743
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorGroup.SMaterialControllerColorGroup";

		// Token: 0x04013F50 RID: 81744
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F51 RID: 81745
		internal static int __PropertyOffset_0;

		// Token: 0x04013F52 RID: 81746
		[Nullable(2)]
		private FKuroCurveLinearColor _Start;

		// Token: 0x04013F53 RID: 81747
		internal static int __PropertyOffset_1;

		// Token: 0x04013F54 RID: 81748
		[Nullable(2)]
		private FKuroCurveLinearColor _Loop;

		// Token: 0x04013F55 RID: 81749
		internal static int __PropertyOffset_2;

		// Token: 0x04013F56 RID: 81750
		[Nullable(2)]
		private FKuroCurveLinearColor _End;
	}
}
