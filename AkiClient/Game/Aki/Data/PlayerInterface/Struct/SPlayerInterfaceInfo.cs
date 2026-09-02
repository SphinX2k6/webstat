using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.PlayerInterface.Struct
{
	// Token: 0x02003E4D RID: 15949
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/PlayerInterface/Struct/SPlayerInterfaceInfo.SPlayerInterfaceInfo")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SPlayerInterfaceInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027587 RID: 161159 RVA: 0x009EF9EC File Offset: 0x009EDBEC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPlayerInterfaceInfo._ScriptStructPtr != 0) ? SPlayerInterfaceInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/PlayerInterface/Struct/SPlayerInterfaceInfo.SPlayerInterfaceInfo", ref SPlayerInterfaceInfo._ScriptStructPtr);
		}

		// Token: 0x17005C58 RID: 23640
		// (get) Token: 0x06027588 RID: 161160 RVA: 0x009EFA10 File Offset: 0x009EDC10
		// (set) Token: 0x06027589 RID: 161161 RVA: 0x009EFA24 File Offset: 0x009EDC24
		public unsafe FName 接口名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPlayerInterfaceInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPlayerInterfaceInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C59 RID: 23641
		// (get) Token: 0x0602758A RID: 161162 RVA: 0x009EFA39 File Offset: 0x009EDC39
		// (set) Token: 0x0602758B RID: 161163 RVA: 0x009EFA4D File Offset: 0x009EDC4D
		public unsafe string 函数名称
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPlayerInterfaceInfo.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPlayerInterfaceInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x0602758C RID: 161164 RVA: 0x009EFA62 File Offset: 0x009EDC62
		public SPlayerInterfaceInfo()
		{
		}

		// Token: 0x0602758D RID: 161165 RVA: 0x009EFA6A File Offset: 0x009EDC6A
		public SPlayerInterfaceInfo(FName 接口名称, string 函数名称)
		{
			this.接口名称 = 接口名称;
			this.函数名称 = 函数名称;
		}

		// Token: 0x0602758E RID: 161166 RVA: 0x009EFA80 File Offset: 0x009EDC80
		protected override IntPtr GetUStructPtr()
		{
			return SPlayerInterfaceInfo.StaticStruct();
		}

		// Token: 0x0602758F RID: 161167 RVA: 0x009EFA8C File Offset: 0x009EDC8C
		[NullableContext(2)]
		public SPlayerInterfaceInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027590 RID: 161168 RVA: 0x009EFA96 File Offset: 0x009EDC96
		public SPlayerInterfaceInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027591 RID: 161169 RVA: 0x009EFAA1 File Offset: 0x009EDCA1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPlayerInterfaceInfo(Pointer, false, true);
		}

		// Token: 0x06027592 RID: 161170 RVA: 0x009EFAAB File Offset: 0x009EDCAB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPlayerInterfaceInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401498F RID: 84367
		public const string __ObjectPath = "/Game/Aki/Data/PlayerInterface/Struct/SPlayerInterfaceInfo.SPlayerInterfaceInfo";

		// Token: 0x04014990 RID: 84368
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014991 RID: 84369
		internal static int __PropertyOffset_0;

		// Token: 0x04014992 RID: 84370
		internal static int __PropertyOffset_1;
	}
}
