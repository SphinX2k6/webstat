using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Condition.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Condition.Struct
{
	// Token: 0x02003F06 RID: 16134
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Condition/Struct/SConditionGroup.SConditionGroup")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SConditionGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028305 RID: 164613 RVA: 0x00A04C17 File Offset: 0x00A02E17
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SConditionGroup._ScriptStructPtr != 0) ? SConditionGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Condition/Struct/SConditionGroup.SConditionGroup", ref SConditionGroup._ScriptStructPtr);
		}

		// Token: 0x170060F9 RID: 24825
		// (get) Token: 0x06028306 RID: 164614 RVA: 0x00A04C3B File Offset: 0x00A02E3B
		// (set) Token: 0x06028307 RID: 164615 RVA: 0x00A04C4F File Offset: 0x00A02E4F
		public unsafe FName 条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170060FA RID: 24826
		// (get) Token: 0x06028308 RID: 164616 RVA: 0x00A04C64 File Offset: 0x00A02E64
		// (set) Token: 0x06028309 RID: 164617 RVA: 0x00A04C78 File Offset: 0x00A02E78
		[Nullable(0)]
		public unsafe TEnumAsByte<SConditionGroupType> 条件组策略
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170060FB RID: 24827
		// (get) Token: 0x0602830A RID: 164618 RVA: 0x00A04C90 File Offset: 0x00A02E90
		// (set) Token: 0x0602830B RID: 164619 RVA: 0x00A04CD3 File Offset: 0x00A02ED3
		public TArray<SCondition> 条件组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SCondition> result;
				if ((result = this._条件组) == null)
				{
					result = (this._条件组 = new TArray<SCondition>(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.条件组.CopyAssign(value);
			}
		}

		// Token: 0x170060FC RID: 24828
		// (get) Token: 0x0602830C RID: 164620 RVA: 0x00A04CE4 File Offset: 0x00A02EE4
		// (set) Token: 0x0602830D RID: 164621 RVA: 0x00A04D27 File Offset: 0x00A02F27
		public unsafe FText 拦截提示
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._拦截提示) == null)
				{
					result = (this._拦截提示 = new FText(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SConditionGroup.__PropertyOffset_3)), value.NativePtr, 1);
			}
		}

		// Token: 0x170060FD RID: 24829
		// (get) Token: 0x0602830E RID: 164622 RVA: 0x00A04D44 File Offset: 0x00A02F44
		// (set) Token: 0x0602830F RID: 164623 RVA: 0x00A04D87 File Offset: 0x00A02F87
		public unsafe FText 条件组描述
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._条件组描述) == null)
				{
					result = (this._条件组描述 = new FText(base.NativePtr + (IntPtr)SConditionGroup.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SConditionGroup.__PropertyOffset_4)), value.NativePtr, 1);
			}
		}

		// Token: 0x06028310 RID: 164624 RVA: 0x00A04DA2 File Offset: 0x00A02FA2
		public SConditionGroup()
		{
		}

		// Token: 0x06028311 RID: 164625 RVA: 0x00A04DAA File Offset: 0x00A02FAA
		public SConditionGroup(FName 条件组ID, [Nullable(0)] TEnumAsByte<SConditionGroupType> 条件组策略, TArray<SCondition> 条件组, FText 拦截提示, FText 条件组描述)
		{
			this.条件组ID = 条件组ID;
			this.条件组策略 = 条件组策略;
			this.条件组 = 条件组;
			this.拦截提示 = 拦截提示;
			this.条件组描述 = 条件组描述;
		}

		// Token: 0x06028312 RID: 164626 RVA: 0x00A04DD7 File Offset: 0x00A02FD7
		protected override IntPtr GetUStructPtr()
		{
			return SConditionGroup.StaticStruct();
		}

		// Token: 0x06028313 RID: 164627 RVA: 0x00A04DE3 File Offset: 0x00A02FE3
		[NullableContext(2)]
		public SConditionGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028314 RID: 164628 RVA: 0x00A04DED File Offset: 0x00A02FED
		public SConditionGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028315 RID: 164629 RVA: 0x00A04DF8 File Offset: 0x00A02FF8
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SConditionGroup(Pointer, false, true);
		}

		// Token: 0x06028316 RID: 164630 RVA: 0x00A04E02 File Offset: 0x00A03002
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SConditionGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04015206 RID: 86534
		public const string __ObjectPath = "/Game/Aki/Data/Condition/Struct/SConditionGroup.SConditionGroup";

		// Token: 0x04015207 RID: 86535
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015208 RID: 86536
		internal static int __PropertyOffset_0;

		// Token: 0x04015209 RID: 86537
		internal static int __PropertyOffset_1;

		// Token: 0x0401520A RID: 86538
		internal static int __PropertyOffset_2;

		// Token: 0x0401520B RID: 86539
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCondition> _条件组;

		// Token: 0x0401520C RID: 86540
		internal static int __PropertyOffset_3;

		// Token: 0x0401520D RID: 86541
		[Nullable(2)]
		private FText _拦截提示;

		// Token: 0x0401520E RID: 86542
		internal static int __PropertyOffset_4;

		// Token: 0x0401520F RID: 86543
		[Nullable(2)]
		private FText _条件组描述;
	}
}
