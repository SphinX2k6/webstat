using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Condition.Struct
{
	// Token: 0x02003F05 RID: 16133
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Condition/Struct/SCondition.SCondition")]
	[UnrealStructLayout(120, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 120)]
	public class SCondition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060282F7 RID: 164599 RVA: 0x00A04ABE File Offset: 0x00A02CBE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCondition._ScriptStructPtr != 0) ? SCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Condition/Struct/SCondition.SCondition", ref SCondition._ScriptStructPtr);
		}

		// Token: 0x170060F6 RID: 24822
		// (get) Token: 0x060282F8 RID: 164600 RVA: 0x00A04AE2 File Offset: 0x00A02CE2
		// (set) Token: 0x060282F9 RID: 164601 RVA: 0x00A04AF6 File Offset: 0x00A02CF6
		public unsafe FName 条件ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCondition.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCondition.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170060F7 RID: 24823
		// (get) Token: 0x060282FA RID: 164602 RVA: 0x00A04B0C File Offset: 0x00A02D0C
		// (set) Token: 0x060282FB RID: 164603 RVA: 0x00A04B4F File Offset: 0x00A02D4F
		public TMap<FName, string> 参数组
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, string> result;
				if ((result = this._参数组) == null)
				{
					result = (this._参数组 = new TMap<FName, string>(base.NativePtr + (IntPtr)SCondition.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.参数组.CopyAssign(value);
			}
		}

		// Token: 0x170060F8 RID: 24824
		// (get) Token: 0x060282FC RID: 164604 RVA: 0x00A04B60 File Offset: 0x00A02D60
		// (set) Token: 0x060282FD RID: 164605 RVA: 0x00A04BA3 File Offset: 0x00A02DA3
		public unsafe FText 描述
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._描述) == null)
				{
					result = (this._描述 = new FText(base.NativePtr + (IntPtr)SCondition.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SCondition.__PropertyOffset_2)), value.NativePtr, 1);
			}
		}

		// Token: 0x060282FE RID: 164606 RVA: 0x00A04BBE File Offset: 0x00A02DBE
		public SCondition()
		{
		}

		// Token: 0x060282FF RID: 164607 RVA: 0x00A04BC6 File Offset: 0x00A02DC6
		public SCondition(FName 条件ID, TMap<FName, string> 参数组, FText 描述)
		{
			this.条件ID = 条件ID;
			this.参数组 = 参数组;
			this.描述 = 描述;
		}

		// Token: 0x06028300 RID: 164608 RVA: 0x00A04BE3 File Offset: 0x00A02DE3
		protected override IntPtr GetUStructPtr()
		{
			return SCondition.StaticStruct();
		}

		// Token: 0x06028301 RID: 164609 RVA: 0x00A04BEF File Offset: 0x00A02DEF
		[NullableContext(2)]
		public SCondition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028302 RID: 164610 RVA: 0x00A04BF9 File Offset: 0x00A02DF9
		public SCondition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028303 RID: 164611 RVA: 0x00A04C04 File Offset: 0x00A02E04
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCondition(Pointer, false, true);
		}

		// Token: 0x06028304 RID: 164612 RVA: 0x00A04C0E File Offset: 0x00A02E0E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCondition(Pointer, MemoryOwner);
		}

		// Token: 0x040151FF RID: 86527
		public const string __ObjectPath = "/Game/Aki/Data/Condition/Struct/SCondition.SCondition";

		// Token: 0x04015200 RID: 86528
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015201 RID: 86529
		internal static int __PropertyOffset_0;

		// Token: 0x04015202 RID: 86530
		internal static int __PropertyOffset_1;

		// Token: 0x04015203 RID: 86531
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, string> _参数组;

		// Token: 0x04015204 RID: 86532
		internal static int __PropertyOffset_2;

		// Token: 0x04015205 RID: 86533
		[Nullable(2)]
		private FText _描述;
	}
}
