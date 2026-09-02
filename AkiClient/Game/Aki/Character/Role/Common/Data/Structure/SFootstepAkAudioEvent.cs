using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x0200400C RID: 16396
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/SFootstepAkAudioEvent.SFootstepAkAudioEvent")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SFootstepAkAudioEvent : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602A983 RID: 174467 RVA: 0x00A5D7FB File Offset: 0x00A5B9FB
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFootstepAkAudioEvent._ScriptStructPtr != 0) ? SFootstepAkAudioEvent._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/Common/Data/Structure/SFootstepAkAudioEvent.SFootstepAkAudioEvent", ref SFootstepAkAudioEvent._ScriptStructPtr);
		}

		// Token: 0x17006EEE RID: 28398
		// (get) Token: 0x0602A984 RID: 174468 RVA: 0x00A5D81F File Offset: 0x00A5BA1F
		// (set) Token: 0x0602A985 RID: 174469 RVA: 0x00A5D833 File Offset: 0x00A5BA33
		public unsafe TEnumAsByte<EFootstepAkAudioEventType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAkAudioEvent.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAkAudioEvent.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006EEF RID: 28399
		// (get) Token: 0x0602A986 RID: 174470 RVA: 0x00A5D848 File Offset: 0x00A5BA48
		// (set) Token: 0x0602A987 RID: 174471 RVA: 0x00A5D867 File Offset: 0x00A5BA67
		[Nullable(1)]
		public TSoftObjectPtr<UAkAudioEvent> Event
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SFootstepAkAudioEvent.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SFootstepAkAudioEvent.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602A988 RID: 174472 RVA: 0x00A5D88C File Offset: 0x00A5BA8C
		public SFootstepAkAudioEvent()
		{
		}

		// Token: 0x0602A989 RID: 174473 RVA: 0x00A5D894 File Offset: 0x00A5BA94
		public SFootstepAkAudioEvent(TEnumAsByte<EFootstepAkAudioEventType> Type, [Nullable(1)] TSoftObjectPtr<UAkAudioEvent> Event)
		{
			this.Type = Type;
			this.Event = Event;
		}

		// Token: 0x0602A98A RID: 174474 RVA: 0x00A5D8AA File Offset: 0x00A5BAAA
		protected override IntPtr GetUStructPtr()
		{
			return SFootstepAkAudioEvent.StaticStruct();
		}

		// Token: 0x0602A98B RID: 174475 RVA: 0x00A5D8B6 File Offset: 0x00A5BAB6
		[NullableContext(2)]
		public SFootstepAkAudioEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A98C RID: 174476 RVA: 0x00A5D8C0 File Offset: 0x00A5BAC0
		public SFootstepAkAudioEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A98D RID: 174477 RVA: 0x00A5D8CB File Offset: 0x00A5BACB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFootstepAkAudioEvent(Pointer, false, true);
		}

		// Token: 0x0602A98E RID: 174478 RVA: 0x00A5D8D5 File Offset: 0x00A5BAD5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFootstepAkAudioEvent(Pointer, MemoryOwner);
		}

		// Token: 0x040172A5 RID: 94885
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/SFootstepAkAudioEvent.SFootstepAkAudioEvent";

		// Token: 0x040172A6 RID: 94886
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040172A7 RID: 94887
		internal static int __PropertyOffset_0;

		// Token: 0x040172A8 RID: 94888
		internal static int __PropertyOffset_1;
	}
}
