using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DB1 RID: 15793
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfoList.SPCGStaticMeshInfoList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SPCGStaticMeshInfoList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026AB9 RID: 158393 RVA: 0x009DE8CE File Offset: 0x009DCACE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGStaticMeshInfoList._ScriptStructPtr != 0) ? SPCGStaticMeshInfoList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfoList.SPCGStaticMeshInfoList", ref SPCGStaticMeshInfoList._ScriptStructPtr);
		}

		// Token: 0x1700589D RID: 22685
		// (get) Token: 0x06026ABA RID: 158394 RVA: 0x009DE8F4 File Offset: 0x009DCAF4
		// (set) Token: 0x06026ABB RID: 158395 RVA: 0x009DE937 File Offset: 0x009DCB37
		public TArray<SPCGStaticMeshInfo> StaticMeshList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPCGStaticMeshInfo> result;
				if ((result = this._StaticMeshList) == null)
				{
					result = (this._StaticMeshList = new TArray<SPCGStaticMeshInfo>(base.NativePtr + (IntPtr)SPCGStaticMeshInfoList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.StaticMeshList.CopyAssign(value);
			}
		}

		// Token: 0x06026ABC RID: 158396 RVA: 0x009DE945 File Offset: 0x009DCB45
		public SPCGStaticMeshInfoList()
		{
		}

		// Token: 0x06026ABD RID: 158397 RVA: 0x009DE94D File Offset: 0x009DCB4D
		public SPCGStaticMeshInfoList(TArray<SPCGStaticMeshInfo> StaticMeshList)
		{
			this.StaticMeshList = StaticMeshList;
		}

		// Token: 0x06026ABE RID: 158398 RVA: 0x009DE95C File Offset: 0x009DCB5C
		protected override IntPtr GetUStructPtr()
		{
			return SPCGStaticMeshInfoList.StaticStruct();
		}

		// Token: 0x06026ABF RID: 158399 RVA: 0x009DE968 File Offset: 0x009DCB68
		[NullableContext(2)]
		public SPCGStaticMeshInfoList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026AC0 RID: 158400 RVA: 0x009DE972 File Offset: 0x009DCB72
		public SPCGStaticMeshInfoList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026AC1 RID: 158401 RVA: 0x009DE97D File Offset: 0x009DCB7D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGStaticMeshInfoList(Pointer, false, true);
		}

		// Token: 0x06026AC2 RID: 158402 RVA: 0x009DE987 File Offset: 0x009DCB87
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGStaticMeshInfoList(Pointer, MemoryOwner);
		}

		// Token: 0x04014273 RID: 82547
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfoList.SPCGStaticMeshInfoList";

		// Token: 0x04014274 RID: 82548
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014275 RID: 82549
		internal static int __PropertyOffset_0;

		// Token: 0x04014276 RID: 82550
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPCGStaticMeshInfo> _StaticMeshList;
	}
}
