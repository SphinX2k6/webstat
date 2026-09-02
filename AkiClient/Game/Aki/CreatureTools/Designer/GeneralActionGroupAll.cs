using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2B RID: 16171
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/GeneralActionGroupAll.GeneralActionGroupAll")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class GeneralActionGroupAll : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285B1 RID: 165297 RVA: 0x00A086B2 File Offset: 0x00A068B2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GeneralActionGroupAll._ScriptStructPtr != 0) ? GeneralActionGroupAll._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/GeneralActionGroupAll.GeneralActionGroupAll", ref GeneralActionGroupAll._ScriptStructPtr);
		}

		// Token: 0x170061EF RID: 25071
		// (get) Token: 0x060285B2 RID: 165298 RVA: 0x00A086D6 File Offset: 0x00A068D6
		// (set) Token: 0x060285B3 RID: 165299 RVA: 0x00A086EA File Offset: 0x00A068EA
		public unsafe string DefineMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionGroupAll.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionGroupAll.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061F0 RID: 25072
		// (get) Token: 0x060285B4 RID: 165300 RVA: 0x00A086FF File Offset: 0x00A068FF
		// (set) Token: 0x060285B5 RID: 165301 RVA: 0x00A08713 File Offset: 0x00A06913
		public unsafe string DataMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionGroupAll.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionGroupAll.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170061F1 RID: 25073
		// (get) Token: 0x060285B6 RID: 165302 RVA: 0x00A08728 File Offset: 0x00A06928
		// (set) Token: 0x060285B7 RID: 165303 RVA: 0x00A0876B File Offset: 0x00A0696B
		public TArray<NPCGeneralActionGroup> Data
		{
			get
			{
				base.FastCheckIsValid();
				TArray<NPCGeneralActionGroup> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TArray<NPCGeneralActionGroup>(base.NativePtr + (IntPtr)GeneralActionGroupAll.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x060285B8 RID: 165304 RVA: 0x00A08779 File Offset: 0x00A06979
		public GeneralActionGroupAll()
		{
		}

		// Token: 0x060285B9 RID: 165305 RVA: 0x00A08781 File Offset: 0x00A06981
		public GeneralActionGroupAll(string DefineMd5, string DataMd5, TArray<NPCGeneralActionGroup> Data)
		{
			this.DefineMd5 = DefineMd5;
			this.DataMd5 = DataMd5;
			this.Data = Data;
		}

		// Token: 0x060285BA RID: 165306 RVA: 0x00A0879E File Offset: 0x00A0699E
		protected override IntPtr GetUStructPtr()
		{
			return GeneralActionGroupAll.StaticStruct();
		}

		// Token: 0x060285BB RID: 165307 RVA: 0x00A087AA File Offset: 0x00A069AA
		[NullableContext(2)]
		public GeneralActionGroupAll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060285BC RID: 165308 RVA: 0x00A087B4 File Offset: 0x00A069B4
		public GeneralActionGroupAll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285BD RID: 165309 RVA: 0x00A087BF File Offset: 0x00A069BF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GeneralActionGroupAll(Pointer, false, true);
		}

		// Token: 0x060285BE RID: 165310 RVA: 0x00A087C9 File Offset: 0x00A069C9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GeneralActionGroupAll(Pointer, MemoryOwner);
		}

		// Token: 0x0401539E RID: 86942
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/GeneralActionGroupAll.GeneralActionGroupAll";

		// Token: 0x0401539F RID: 86943
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153A0 RID: 86944
		internal static int __PropertyOffset_0;

		// Token: 0x040153A1 RID: 86945
		internal static int __PropertyOffset_1;

		// Token: 0x040153A2 RID: 86946
		internal static int __PropertyOffset_2;

		// Token: 0x040153A3 RID: 86947
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<NPCGeneralActionGroup> _Data;
	}
}
