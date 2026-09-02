using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041A7 RID: 16807
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/sInputCommand.SInputCommand")]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class SInputCommand : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602C9EE RID: 182766 RVA: 0x00AA83D2 File Offset: 0x00AA65D2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputCommand._ScriptStructPtr != 0) ? SInputCommand._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/sInputCommand.SInputCommand", ref SInputCommand._ScriptStructPtr);
		}

		// Token: 0x17007850 RID: 30800
		// (get) Token: 0x0602C9EF RID: 182767 RVA: 0x00AA83F6 File Offset: 0x00AA65F6
		// (set) Token: 0x0602C9F0 RID: 182768 RVA: 0x00AA840A File Offset: 0x00AA660A
		public unsafe TEnumAsByte<ECommandType> CommandType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007851 RID: 30801
		// (get) Token: 0x0602C9F1 RID: 182769 RVA: 0x00AA841F File Offset: 0x00AA661F
		// (set) Token: 0x0602C9F2 RID: 182770 RVA: 0x00AA842F File Offset: 0x00AA662F
		public unsafe int IntValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007852 RID: 30802
		// (get) Token: 0x0602C9F3 RID: 182771 RVA: 0x00AA8440 File Offset: 0x00AA6640
		// (set) Token: 0x0602C9F4 RID: 182772 RVA: 0x00AA8454 File Offset: 0x00AA6654
		public unsafe FGameplayTag TagValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInputCommand.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602C9F5 RID: 182773 RVA: 0x00AA8469 File Offset: 0x00AA6669
		public SInputCommand()
		{
		}

		// Token: 0x0602C9F6 RID: 182774 RVA: 0x00AA8471 File Offset: 0x00AA6671
		public SInputCommand(TEnumAsByte<ECommandType> CommandType, int IntValue, FGameplayTag TagValue)
		{
			this.CommandType = CommandType;
			this.IntValue = IntValue;
			this.TagValue = TagValue;
		}

		// Token: 0x0602C9F7 RID: 182775 RVA: 0x00AA848E File Offset: 0x00AA668E
		protected override IntPtr GetUStructPtr()
		{
			return SInputCommand.StaticStruct();
		}

		// Token: 0x0602C9F8 RID: 182776 RVA: 0x00AA849A File Offset: 0x00AA669A
		[NullableContext(2)]
		public SInputCommand(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602C9F9 RID: 182777 RVA: 0x00AA84A4 File Offset: 0x00AA66A4
		public SInputCommand(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602C9FA RID: 182778 RVA: 0x00AA84AF File Offset: 0x00AA66AF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputCommand(Pointer, false, true);
		}

		// Token: 0x0602C9FB RID: 182779 RVA: 0x00AA84B9 File Offset: 0x00AA66B9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputCommand(Pointer, MemoryOwner);
		}

		// Token: 0x04018D46 RID: 101702
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/sInputCommand.SInputCommand";

		// Token: 0x04018D47 RID: 101703
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018D48 RID: 101704
		internal static int __PropertyOffset_0;

		// Token: 0x04018D49 RID: 101705
		internal static int __PropertyOffset_1;

		// Token: 0x04018D4A RID: 101706
		internal static int __PropertyOffset_2;
	}
}
