using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D81 RID: 15745
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatGroup.SMaterialControllerFloatGroup")]
	[UnrealStructLayout(432, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 432)]
	public class SMaterialControllerFloatGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060266F2 RID: 157426 RVA: 0x009D7B16 File Offset: 0x009D5D16
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerFloatGroup._ScriptStructPtr != 0) ? SMaterialControllerFloatGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatGroup.SMaterialControllerFloatGroup", ref SMaterialControllerFloatGroup._ScriptStructPtr);
		}

		// Token: 0x17005760 RID: 22368
		// (get) Token: 0x060266F3 RID: 157427 RVA: 0x009D7B3C File Offset: 0x009D5D3C
		// (set) Token: 0x060266F4 RID: 157428 RVA: 0x009D7B7F File Offset: 0x009D5D7F
		public FKuroCurveFloat Start
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Start) == null)
				{
					result = (this._Start = new FKuroCurveFloat(base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005761 RID: 22369
		// (get) Token: 0x060266F5 RID: 157429 RVA: 0x009D7BA0 File Offset: 0x009D5DA0
		// (set) Token: 0x060266F6 RID: 157430 RVA: 0x009D7BE3 File Offset: 0x009D5DE3
		public FKuroCurveFloat Loop
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._Loop) == null)
				{
					result = (this._Loop = new FKuroCurveFloat(base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005762 RID: 22370
		// (get) Token: 0x060266F7 RID: 157431 RVA: 0x009D7C04 File Offset: 0x009D5E04
		// (set) Token: 0x060266F8 RID: 157432 RVA: 0x009D7C47 File Offset: 0x009D5E47
		public FKuroCurveFloat End
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._End) == null)
				{
					result = (this._End = new FKuroCurveFloat(base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerFloatGroup.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060266F9 RID: 157433 RVA: 0x009D7C68 File Offset: 0x009D5E68
		public SMaterialControllerFloatGroup()
		{
		}

		// Token: 0x060266FA RID: 157434 RVA: 0x009D7C70 File Offset: 0x009D5E70
		public SMaterialControllerFloatGroup(FKuroCurveFloat Start, FKuroCurveFloat Loop, FKuroCurveFloat End)
		{
			this.Start = Start;
			this.Loop = Loop;
			this.End = End;
		}

		// Token: 0x060266FB RID: 157435 RVA: 0x009D7C8D File Offset: 0x009D5E8D
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerFloatGroup.StaticStruct();
		}

		// Token: 0x060266FC RID: 157436 RVA: 0x009D7C99 File Offset: 0x009D5E99
		[NullableContext(2)]
		public SMaterialControllerFloatGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060266FD RID: 157437 RVA: 0x009D7CA3 File Offset: 0x009D5EA3
		public SMaterialControllerFloatGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060266FE RID: 157438 RVA: 0x009D7CAE File Offset: 0x009D5EAE
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerFloatGroup(Pointer, false, true);
		}

		// Token: 0x060266FF RID: 157439 RVA: 0x009D7CB8 File Offset: 0x009D5EB8
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerFloatGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04013F5C RID: 81756
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatGroup.SMaterialControllerFloatGroup";

		// Token: 0x04013F5D RID: 81757
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F5E RID: 81758
		internal static int __PropertyOffset_0;

		// Token: 0x04013F5F RID: 81759
		[Nullable(2)]
		private FKuroCurveFloat _Start;

		// Token: 0x04013F60 RID: 81760
		internal static int __PropertyOffset_1;

		// Token: 0x04013F61 RID: 81761
		[Nullable(2)]
		private FKuroCurveFloat _Loop;

		// Token: 0x04013F62 RID: 81762
		internal static int __PropertyOffset_2;

		// Token: 0x04013F63 RID: 81763
		[Nullable(2)]
		private FKuroCurveFloat _End;
	}
}
