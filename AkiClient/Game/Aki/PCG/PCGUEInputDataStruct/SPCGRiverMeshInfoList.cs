using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAD RID: 15789
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfoList.SPCGRiverMeshInfoList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SPCGRiverMeshInfoList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A87 RID: 158343 RVA: 0x009DE452 File Offset: 0x009DC652
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGRiverMeshInfoList._ScriptStructPtr != 0) ? SPCGRiverMeshInfoList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfoList.SPCGRiverMeshInfoList", ref SPCGRiverMeshInfoList._ScriptStructPtr);
		}

		// Token: 0x17005894 RID: 22676
		// (get) Token: 0x06026A88 RID: 158344 RVA: 0x009DE478 File Offset: 0x009DC678
		// (set) Token: 0x06026A89 RID: 158345 RVA: 0x009DE4BB File Offset: 0x009DC6BB
		public TArray<SPCGRiverMeshInfo> RiverMeshList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPCGRiverMeshInfo> result;
				if ((result = this._RiverMeshList) == null)
				{
					result = (this._RiverMeshList = new TArray<SPCGRiverMeshInfo>(base.NativePtr + (IntPtr)SPCGRiverMeshInfoList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RiverMeshList.CopyAssign(value);
			}
		}

		// Token: 0x06026A8A RID: 158346 RVA: 0x009DE4C9 File Offset: 0x009DC6C9
		public SPCGRiverMeshInfoList()
		{
		}

		// Token: 0x06026A8B RID: 158347 RVA: 0x009DE4D1 File Offset: 0x009DC6D1
		public SPCGRiverMeshInfoList(TArray<SPCGRiverMeshInfo> RiverMeshList)
		{
			this.RiverMeshList = RiverMeshList;
		}

		// Token: 0x06026A8C RID: 158348 RVA: 0x009DE4E0 File Offset: 0x009DC6E0
		protected override IntPtr GetUStructPtr()
		{
			return SPCGRiverMeshInfoList.StaticStruct();
		}

		// Token: 0x06026A8D RID: 158349 RVA: 0x009DE4EC File Offset: 0x009DC6EC
		[NullableContext(2)]
		public SPCGRiverMeshInfoList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A8E RID: 158350 RVA: 0x009DE4F6 File Offset: 0x009DC6F6
		public SPCGRiverMeshInfoList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A8F RID: 158351 RVA: 0x009DE501 File Offset: 0x009DC701
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGRiverMeshInfoList(Pointer, false, true);
		}

		// Token: 0x06026A90 RID: 158352 RVA: 0x009DE50B File Offset: 0x009DC70B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGRiverMeshInfoList(Pointer, MemoryOwner);
		}

		// Token: 0x0401425B RID: 82523
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfoList.SPCGRiverMeshInfoList";

		// Token: 0x0401425C RID: 82524
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401425D RID: 82525
		internal static int __PropertyOffset_0;

		// Token: 0x0401425E RID: 82526
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPCGRiverMeshInfo> _RiverMeshList;
	}
}
