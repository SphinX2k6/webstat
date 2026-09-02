using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAF RID: 15791
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfoList.SPCGRoadMeshInfoList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SPCGRoadMeshInfoList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A9F RID: 158367 RVA: 0x009DE662 File Offset: 0x009DC862
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGRoadMeshInfoList._ScriptStructPtr != 0) ? SPCGRoadMeshInfoList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfoList.SPCGRoadMeshInfoList", ref SPCGRoadMeshInfoList._ScriptStructPtr);
		}

		// Token: 0x17005898 RID: 22680
		// (get) Token: 0x06026AA0 RID: 158368 RVA: 0x009DE688 File Offset: 0x009DC888
		// (set) Token: 0x06026AA1 RID: 158369 RVA: 0x009DE6CB File Offset: 0x009DC8CB
		public TArray<SPCGRoadMeshInfo> RoadMeshList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPCGRoadMeshInfo> result;
				if ((result = this._RoadMeshList) == null)
				{
					result = (this._RoadMeshList = new TArray<SPCGRoadMeshInfo>(base.NativePtr + (IntPtr)SPCGRoadMeshInfoList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RoadMeshList.CopyAssign(value);
			}
		}

		// Token: 0x06026AA2 RID: 158370 RVA: 0x009DE6D9 File Offset: 0x009DC8D9
		public SPCGRoadMeshInfoList()
		{
		}

		// Token: 0x06026AA3 RID: 158371 RVA: 0x009DE6E1 File Offset: 0x009DC8E1
		public SPCGRoadMeshInfoList(TArray<SPCGRoadMeshInfo> RoadMeshList)
		{
			this.RoadMeshList = RoadMeshList;
		}

		// Token: 0x06026AA4 RID: 158372 RVA: 0x009DE6F0 File Offset: 0x009DC8F0
		protected override IntPtr GetUStructPtr()
		{
			return SPCGRoadMeshInfoList.StaticStruct();
		}

		// Token: 0x06026AA5 RID: 158373 RVA: 0x009DE6FC File Offset: 0x009DC8FC
		[NullableContext(2)]
		public SPCGRoadMeshInfoList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026AA6 RID: 158374 RVA: 0x009DE706 File Offset: 0x009DC906
		public SPCGRoadMeshInfoList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026AA7 RID: 158375 RVA: 0x009DE711 File Offset: 0x009DC911
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGRoadMeshInfoList(Pointer, false, true);
		}

		// Token: 0x06026AA8 RID: 158376 RVA: 0x009DE71B File Offset: 0x009DC91B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGRoadMeshInfoList(Pointer, MemoryOwner);
		}

		// Token: 0x04014266 RID: 82534
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfoList.SPCGRoadMeshInfoList";

		// Token: 0x04014267 RID: 82535
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014268 RID: 82536
		internal static int __PropertyOffset_0;

		// Token: 0x04014269 RID: 82537
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPCGRoadMeshInfo> _RoadMeshList;
	}
}
