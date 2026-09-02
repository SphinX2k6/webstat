using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED6 RID: 16086
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SNpcData.SNpcData")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SNpcData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028001 RID: 163841 RVA: 0x00A000A2 File Offset: 0x009FE2A2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNpcData._ScriptStructPtr != 0) ? SNpcData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SNpcData.SNpcData", ref SNpcData._ScriptStructPtr);
		}

		// Token: 0x17005FED RID: 24557
		// (get) Token: 0x06028002 RID: 163842 RVA: 0x00A000C6 File Offset: 0x009FE2C6
		// (set) Token: 0x06028003 RID: 163843 RVA: 0x00A000DA File Offset: 0x009FE2DA
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<TsBaseCharacter> 蓝图类
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SNpcData.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SNpcData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x06028004 RID: 163844 RVA: 0x00A000EF File Offset: 0x009FE2EF
		public SNpcData()
		{
		}

		// Token: 0x06028005 RID: 163845 RVA: 0x00A000F7 File Offset: 0x009FE2F7
		public SNpcData([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<TsBaseCharacter> 蓝图类)
		{
			this.蓝图类 = 蓝图类;
		}

		// Token: 0x06028006 RID: 163846 RVA: 0x00A00106 File Offset: 0x009FE306
		protected override IntPtr GetUStructPtr()
		{
			return SNpcData.StaticStruct();
		}

		// Token: 0x06028007 RID: 163847 RVA: 0x00A00112 File Offset: 0x009FE312
		[NullableContext(2)]
		public SNpcData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028008 RID: 163848 RVA: 0x00A0011C File Offset: 0x009FE31C
		public SNpcData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028009 RID: 163849 RVA: 0x00A00127 File Offset: 0x009FE327
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNpcData(Pointer, false, true);
		}

		// Token: 0x0602800A RID: 163850 RVA: 0x00A00131 File Offset: 0x009FE331
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNpcData(Pointer, MemoryOwner);
		}

		// Token: 0x04015000 RID: 86016
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SNpcData.SNpcData";

		// Token: 0x04015001 RID: 86017
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015002 RID: 86018
		internal static int __PropertyOffset_0;
	}
}
