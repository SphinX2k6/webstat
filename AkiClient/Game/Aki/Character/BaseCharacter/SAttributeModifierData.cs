using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004238 RID: 16952
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SAttributeModifierData.SAttributeModifierData")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SAttributeModifierData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CD55 RID: 183637 RVA: 0x00AB135C File Offset: 0x00AAF55C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAttributeModifierData._ScriptStructPtr != 0) ? SAttributeModifierData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SAttributeModifierData.SAttributeModifierData", ref SAttributeModifierData._ScriptStructPtr);
		}

		// Token: 0x1700793F RID: 31039
		// (get) Token: 0x0602CD56 RID: 183638 RVA: 0x00AB1380 File Offset: 0x00AAF580
		// (set) Token: 0x0602CD57 RID: 183639 RVA: 0x00AB13C3 File Offset: 0x00AAF5C3
		[Nullable(1)]
		public FGameplayAttribute 属性类型
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FGameplayAttribute result;
				if ((result = this._属性类型) == null)
				{
					result = (this._属性类型 = new FGameplayAttribute(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayAttribute.StaticStruct(), base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007940 RID: 31040
		// (get) Token: 0x0602CD58 RID: 183640 RVA: 0x00AB13E4 File Offset: 0x00AAF5E4
		// (set) Token: 0x0602CD59 RID: 183641 RVA: 0x00AB13F8 File Offset: 0x00AAF5F8
		public unsafe TEnumAsByte<EAttributeTarget> 操作对象
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007941 RID: 31041
		// (get) Token: 0x0602CD5A RID: 183642 RVA: 0x00AB140D File Offset: 0x00AAF60D
		// (set) Token: 0x0602CD5B RID: 183643 RVA: 0x00AB1421 File Offset: 0x00AAF621
		public unsafe TEnumAsByte<EAttributeOperation> 操作
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007942 RID: 31042
		// (get) Token: 0x0602CD5C RID: 183644 RVA: 0x00AB1436 File Offset: 0x00AAF636
		// (set) Token: 0x0602CD5D RID: 183645 RVA: 0x00AB1446 File Offset: 0x00AAF646
		public unsafe float 值
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAttributeModifierData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602CD5E RID: 183646 RVA: 0x00AB1457 File Offset: 0x00AAF657
		public SAttributeModifierData()
		{
		}

		// Token: 0x0602CD5F RID: 183647 RVA: 0x00AB145F File Offset: 0x00AAF65F
		public SAttributeModifierData([Nullable(1)] FGameplayAttribute 属性类型, TEnumAsByte<EAttributeTarget> 操作对象, TEnumAsByte<EAttributeOperation> 操作, float 值)
		{
			this.属性类型 = 属性类型;
			this.操作对象 = 操作对象;
			this.操作 = 操作;
			this.值 = 值;
		}

		// Token: 0x0602CD60 RID: 183648 RVA: 0x00AB1484 File Offset: 0x00AAF684
		protected override IntPtr GetUStructPtr()
		{
			return SAttributeModifierData.StaticStruct();
		}

		// Token: 0x0602CD61 RID: 183649 RVA: 0x00AB1490 File Offset: 0x00AAF690
		[NullableContext(2)]
		public SAttributeModifierData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CD62 RID: 183650 RVA: 0x00AB149A File Offset: 0x00AAF69A
		public SAttributeModifierData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CD63 RID: 183651 RVA: 0x00AB14A5 File Offset: 0x00AAF6A5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAttributeModifierData(Pointer, false, true);
		}

		// Token: 0x0602CD64 RID: 183652 RVA: 0x00AB14AF File Offset: 0x00AAF6AF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAttributeModifierData(Pointer, MemoryOwner);
		}

		// Token: 0x0401928C RID: 103052
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SAttributeModifierData.SAttributeModifierData";

		// Token: 0x0401928D RID: 103053
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401928E RID: 103054
		internal static int __PropertyOffset_0;

		// Token: 0x0401928F RID: 103055
		[Nullable(2)]
		private FGameplayAttribute _属性类型;

		// Token: 0x04019290 RID: 103056
		internal static int __PropertyOffset_1;

		// Token: 0x04019291 RID: 103057
		internal static int __PropertyOffset_2;

		// Token: 0x04019292 RID: 103058
		internal static int __PropertyOffset_3;
	}
}
