using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Config
{
	// Token: 0x02003F84 RID: 16260
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Config/FC_LoadingTips.FC_LoadingTips")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class FC_LoadingTips : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028AB2 RID: 166578 RVA: 0x00A122FF File Offset: 0x00A104FF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (FC_LoadingTips._ScriptStructPtr != 0) ? FC_LoadingTips._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Config/FC_LoadingTips.FC_LoadingTips", ref FC_LoadingTips._ScriptStructPtr);
		}

		// Token: 0x17006361 RID: 25441
		// (get) Token: 0x06028AB3 RID: 166579 RVA: 0x00A12323 File Offset: 0x00A10523
		// (set) Token: 0x06028AB4 RID: 166580 RVA: 0x00A12333 File Offset: 0x00A10533
		public unsafe int KuroRowId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FC_LoadingTips.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FC_LoadingTips.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006362 RID: 25442
		// (get) Token: 0x06028AB5 RID: 166581 RVA: 0x00A12344 File Offset: 0x00A10544
		// (set) Token: 0x06028AB6 RID: 166582 RVA: 0x00A12354 File Offset: 0x00A10554
		public unsafe int Lv
		{
			get
			{
				return *(base.NativePtr + (IntPtr)FC_LoadingTips.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)FC_LoadingTips.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006363 RID: 25443
		// (get) Token: 0x06028AB7 RID: 166583 RVA: 0x00A12368 File Offset: 0x00A10568
		// (set) Token: 0x06028AB8 RID: 166584 RVA: 0x00A123AB File Offset: 0x00A105AB
		public TArray<int> TipsId
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._TipsId) == null)
				{
					result = (this._TipsId = new TArray<int>(base.NativePtr + (IntPtr)FC_LoadingTips.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TipsId.CopyAssign(value);
			}
		}

		// Token: 0x06028AB9 RID: 166585 RVA: 0x00A123B9 File Offset: 0x00A105B9
		public FC_LoadingTips()
		{
		}

		// Token: 0x06028ABA RID: 166586 RVA: 0x00A123C1 File Offset: 0x00A105C1
		public FC_LoadingTips(int KuroRowId, int Lv, TArray<int> TipsId)
		{
			this.KuroRowId = KuroRowId;
			this.Lv = Lv;
			this.TipsId = TipsId;
		}

		// Token: 0x06028ABB RID: 166587 RVA: 0x00A123DE File Offset: 0x00A105DE
		protected override IntPtr GetUStructPtr()
		{
			return FC_LoadingTips.StaticStruct();
		}

		// Token: 0x06028ABC RID: 166588 RVA: 0x00A123EA File Offset: 0x00A105EA
		[NullableContext(2)]
		public FC_LoadingTips(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028ABD RID: 166589 RVA: 0x00A123F4 File Offset: 0x00A105F4
		public FC_LoadingTips(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028ABE RID: 166590 RVA: 0x00A123FF File Offset: 0x00A105FF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new FC_LoadingTips(Pointer, false, true);
		}

		// Token: 0x06028ABF RID: 166591 RVA: 0x00A12409 File Offset: 0x00A10609
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new FC_LoadingTips(Pointer, MemoryOwner);
		}

		// Token: 0x04015732 RID: 87858
		public const string __ObjectPath = "/Game/Aki/Config/FC_LoadingTips.FC_LoadingTips";

		// Token: 0x04015733 RID: 87859
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015734 RID: 87860
		internal static int __PropertyOffset_0;

		// Token: 0x04015735 RID: 87861
		internal static int __PropertyOffset_1;

		// Token: 0x04015736 RID: 87862
		internal static int __PropertyOffset_2;

		// Token: 0x04015737 RID: 87863
		[Nullable(2)]
		private TArray<int> _TipsId;
	}
}
