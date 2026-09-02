using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041A9 RID: 16809
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/SInputShow.SInputShow")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 102)]
	public class SInputShow : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CA03 RID: 182787 RVA: 0x00AA8568 File Offset: 0x00AA6768
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputShow._ScriptStructPtr != 0) ? SInputShow._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/SInputShow.SInputShow", ref SInputShow._ScriptStructPtr);
		}

		// Token: 0x17007853 RID: 30803
		// (get) Token: 0x0602CA04 RID: 182788 RVA: 0x00AA858C File Offset: 0x00AA678C
		// (set) Token: 0x0602CA05 RID: 182789 RVA: 0x00AA85A0 File Offset: 0x00AA67A0
		[Nullable(0)]
		public unsafe TEnumAsByte<EInputAction> InputActionType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007854 RID: 30804
		// (get) Token: 0x0602CA06 RID: 182790 RVA: 0x00AA85B5 File Offset: 0x00AA67B5
		// (set) Token: 0x0602CA07 RID: 182791 RVA: 0x00AA85C5 File Offset: 0x00AA67C5
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007855 RID: 30805
		// (get) Token: 0x0602CA08 RID: 182792 RVA: 0x00AA85D8 File Offset: 0x00AA67D8
		// (set) Token: 0x0602CA09 RID: 182793 RVA: 0x00AA861B File Offset: 0x00AA681B
		public FGameplayTagContainer BlockTag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._BlockTag) == null)
				{
					result = (this._BlockTag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007856 RID: 30806
		// (get) Token: 0x0602CA0A RID: 182794 RVA: 0x00AA863C File Offset: 0x00AA683C
		// (set) Token: 0x0602CA0B RID: 182795 RVA: 0x00AA864C File Offset: 0x00AA684C
		public unsafe int ListenAttributeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007857 RID: 30807
		// (get) Token: 0x0602CA0C RID: 182796 RVA: 0x00AA865D File Offset: 0x00AA685D
		// (set) Token: 0x0602CA0D RID: 182797 RVA: 0x00AA866D File Offset: 0x00AA686D
		public unsafe int ListenMaxAttributeId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007858 RID: 30808
		// (get) Token: 0x0602CA0E RID: 182798 RVA: 0x00AA867E File Offset: 0x00AA687E
		// (set) Token: 0x0602CA0F RID: 182799 RVA: 0x00AA869D File Offset: 0x00AA689D
		public TSoftObjectPtr<UNiagaraSystem> MaxAttributeEffect
		{
			get
			{
				return new TSoftObjectPtr<UNiagaraSystem>(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007859 RID: 30809
		// (get) Token: 0x0602CA10 RID: 182800 RVA: 0x00AA86C2 File Offset: 0x00AA68C2
		// (set) Token: 0x0602CA11 RID: 182801 RVA: 0x00AA86D6 File Offset: 0x00AA68D6
		public unsafe FColor MaxAttributeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700785A RID: 30810
		// (get) Token: 0x0602CA12 RID: 182802 RVA: 0x00AA86EB File Offset: 0x00AA68EB
		// (set) Token: 0x0602CA13 RID: 182803 RVA: 0x00AA86FB File Offset: 0x00AA68FB
		public unsafe bool bUseElementColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700785B RID: 30811
		// (get) Token: 0x0602CA14 RID: 182804 RVA: 0x00AA870C File Offset: 0x00AA690C
		// (set) Token: 0x0602CA15 RID: 182805 RVA: 0x00AA871C File Offset: 0x00AA691C
		public unsafe bool bLongPressControlCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputShow.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602CA16 RID: 182806 RVA: 0x00AA872D File Offset: 0x00AA692D
		public SInputShow()
		{
		}

		// Token: 0x0602CA17 RID: 182807 RVA: 0x00AA8738 File Offset: 0x00AA6938
		public SInputShow([Nullable(0)] TEnumAsByte<EInputAction> InputActionType, int SkillId, FGameplayTagContainer BlockTag, int ListenAttributeId, int ListenMaxAttributeId, TSoftObjectPtr<UNiagaraSystem> MaxAttributeEffect, FColor MaxAttributeColor, bool bUseElementColor, bool bLongPressControlCamera)
		{
			this.InputActionType = InputActionType;
			this.SkillId = SkillId;
			this.BlockTag = BlockTag;
			this.ListenAttributeId = ListenAttributeId;
			this.ListenMaxAttributeId = ListenMaxAttributeId;
			this.MaxAttributeEffect = MaxAttributeEffect;
			this.MaxAttributeColor = MaxAttributeColor;
			this.bUseElementColor = bUseElementColor;
			this.bLongPressControlCamera = bLongPressControlCamera;
		}

		// Token: 0x0602CA18 RID: 182808 RVA: 0x00AA8790 File Offset: 0x00AA6990
		protected override IntPtr GetUStructPtr()
		{
			return SInputShow.StaticStruct();
		}

		// Token: 0x0602CA19 RID: 182809 RVA: 0x00AA879C File Offset: 0x00AA699C
		[NullableContext(2)]
		public SInputShow(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CA1A RID: 182810 RVA: 0x00AA87A6 File Offset: 0x00AA69A6
		public SInputShow(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CA1B RID: 182811 RVA: 0x00AA87B1 File Offset: 0x00AA69B1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputShow(Pointer, false, true);
		}

		// Token: 0x0602CA1C RID: 182812 RVA: 0x00AA87BB File Offset: 0x00AA69BB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputShow(Pointer, MemoryOwner);
		}

		// Token: 0x04018D4F RID: 101711
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/SInputShow.SInputShow";

		// Token: 0x04018D50 RID: 101712
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018D51 RID: 101713
		internal static int __PropertyOffset_0;

		// Token: 0x04018D52 RID: 101714
		internal static int __PropertyOffset_1;

		// Token: 0x04018D53 RID: 101715
		internal static int __PropertyOffset_2;

		// Token: 0x04018D54 RID: 101716
		[Nullable(2)]
		private FGameplayTagContainer _BlockTag;

		// Token: 0x04018D55 RID: 101717
		internal static int __PropertyOffset_3;

		// Token: 0x04018D56 RID: 101718
		internal static int __PropertyOffset_4;

		// Token: 0x04018D57 RID: 101719
		internal static int __PropertyOffset_5;

		// Token: 0x04018D58 RID: 101720
		internal static int __PropertyOffset_6;

		// Token: 0x04018D59 RID: 101721
		internal static int __PropertyOffset_7;

		// Token: 0x04018D5A RID: 101722
		internal static int __PropertyOffset_8;
	}
}
