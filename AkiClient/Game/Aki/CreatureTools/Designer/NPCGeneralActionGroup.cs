using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2E RID: 16174
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/NPCGeneralActionGroup.NPCGeneralActionGroup")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class NPCGeneralActionGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285F3 RID: 165363 RVA: 0x00A08C20 File Offset: 0x00A06E20
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NPCGeneralActionGroup._ScriptStructPtr != 0) ? NPCGeneralActionGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/NPCGeneralActionGroup.NPCGeneralActionGroup", ref NPCGeneralActionGroup._ScriptStructPtr);
		}

		// Token: 0x17006204 RID: 25092
		// (get) Token: 0x060285F4 RID: 165364 RVA: 0x00A08C44 File Offset: 0x00A06E44
		// (set) Token: 0x060285F5 RID: 165365 RVA: 0x00A08C54 File Offset: 0x00A06E54
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCGeneralActionGroup.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCGeneralActionGroup.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006205 RID: 25093
		// (get) Token: 0x060285F6 RID: 165366 RVA: 0x00A08C68 File Offset: 0x00A06E68
		// (set) Token: 0x060285F7 RID: 165367 RVA: 0x00A08CAB File Offset: 0x00A06EAB
		public TArray<int> ActionIdGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._ActionIdGroup) == null)
				{
					result = (this._ActionIdGroup = new TArray<int>(base.NativePtr + (IntPtr)NPCGeneralActionGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ActionIdGroup.CopyAssign(value);
			}
		}

		// Token: 0x060285F8 RID: 165368 RVA: 0x00A08CB9 File Offset: 0x00A06EB9
		public NPCGeneralActionGroup()
		{
		}

		// Token: 0x060285F9 RID: 165369 RVA: 0x00A08CC1 File Offset: 0x00A06EC1
		public NPCGeneralActionGroup(int Id, TArray<int> ActionIdGroup)
		{
			this.Id = Id;
			this.ActionIdGroup = ActionIdGroup;
		}

		// Token: 0x060285FA RID: 165370 RVA: 0x00A08CD7 File Offset: 0x00A06ED7
		protected override IntPtr GetUStructPtr()
		{
			return NPCGeneralActionGroup.StaticStruct();
		}

		// Token: 0x060285FB RID: 165371 RVA: 0x00A08CE3 File Offset: 0x00A06EE3
		[NullableContext(2)]
		public NPCGeneralActionGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060285FC RID: 165372 RVA: 0x00A08CED File Offset: 0x00A06EED
		public NPCGeneralActionGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285FD RID: 165373 RVA: 0x00A08CF8 File Offset: 0x00A06EF8
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NPCGeneralActionGroup(Pointer, false, true);
		}

		// Token: 0x060285FE RID: 165374 RVA: 0x00A08D02 File Offset: 0x00A06F02
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NPCGeneralActionGroup(Pointer, MemoryOwner);
		}

		// Token: 0x040153BB RID: 86971
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/NPCGeneralActionGroup.NPCGeneralActionGroup";

		// Token: 0x040153BC RID: 86972
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153BD RID: 86973
		internal static int __PropertyOffset_0;

		// Token: 0x040153BE RID: 86974
		internal static int __PropertyOffset_1;

		// Token: 0x040153BF RID: 86975
		[Nullable(2)]
		private TArray<int> _ActionIdGroup;
	}
}
