using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.ConfigTable
{
	// Token: 0x02003F86 RID: 16262
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/ConfigTable/ForBaseStruct.ForBaseStruct")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class ForBaseStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028AD2 RID: 166610 RVA: 0x00A12554 File Offset: 0x00A10754
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ForBaseStruct._ScriptStructPtr != 0) ? ForBaseStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/ConfigTable/ForBaseStruct.ForBaseStruct", ref ForBaseStruct._ScriptStructPtr);
		}

		// Token: 0x17006369 RID: 25449
		// (get) Token: 0x06028AD3 RID: 166611 RVA: 0x00A12578 File Offset: 0x00A10778
		// (set) Token: 0x06028AD4 RID: 166612 RVA: 0x00A1258C File Offset: 0x00A1078C
		public unsafe FVector MemberVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700636A RID: 25450
		// (get) Token: 0x06028AD5 RID: 166613 RVA: 0x00A125A1 File Offset: 0x00A107A1
		// (set) Token: 0x06028AD6 RID: 166614 RVA: 0x00A125B5 File Offset: 0x00A107B5
		public unsafe FRotator MemberVar_2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700636B RID: 25451
		// (get) Token: 0x06028AD7 RID: 166615 RVA: 0x00A125CC File Offset: 0x00A107CC
		// (set) Token: 0x06028AD8 RID: 166616 RVA: 0x00A1260F File Offset: 0x00A1080F
		public FGameplayAttributeData MemberVar_4
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayAttributeData result;
				if ((result = this._MemberVar_4) == null)
				{
					result = (this._MemberVar_4 = new FGameplayAttributeData(base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAttributeData.StaticStruct(), base.NativePtr + (IntPtr)ForBaseStruct.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06028AD9 RID: 166617 RVA: 0x00A12630 File Offset: 0x00A10830
		public ForBaseStruct()
		{
		}

		// Token: 0x06028ADA RID: 166618 RVA: 0x00A12638 File Offset: 0x00A10838
		public ForBaseStruct(FVector MemberVar_0, FRotator MemberVar_2, FGameplayAttributeData MemberVar_4)
		{
			this.MemberVar_0 = MemberVar_0;
			this.MemberVar_2 = MemberVar_2;
			this.MemberVar_4 = MemberVar_4;
		}

		// Token: 0x06028ADB RID: 166619 RVA: 0x00A12655 File Offset: 0x00A10855
		protected override IntPtr GetUStructPtr()
		{
			return ForBaseStruct.StaticStruct();
		}

		// Token: 0x06028ADC RID: 166620 RVA: 0x00A12661 File Offset: 0x00A10861
		[NullableContext(2)]
		public ForBaseStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028ADD RID: 166621 RVA: 0x00A1266B File Offset: 0x00A1086B
		public ForBaseStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028ADE RID: 166622 RVA: 0x00A12676 File Offset: 0x00A10876
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ForBaseStruct(Pointer, false, true);
		}

		// Token: 0x06028ADF RID: 166623 RVA: 0x00A12680 File Offset: 0x00A10880
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ForBaseStruct(Pointer, MemoryOwner);
		}

		// Token: 0x0401573F RID: 87871
		public const string __ObjectPath = "/Game/Aki/ConfigTable/ForBaseStruct.ForBaseStruct";

		// Token: 0x04015740 RID: 87872
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015741 RID: 87873
		internal static int __PropertyOffset_0;

		// Token: 0x04015742 RID: 87874
		internal static int __PropertyOffset_1;

		// Token: 0x04015743 RID: 87875
		internal static int __PropertyOffset_2;

		// Token: 0x04015744 RID: 87876
		[Nullable(2)]
		private FGameplayAttributeData _MemberVar_4;
	}
}
