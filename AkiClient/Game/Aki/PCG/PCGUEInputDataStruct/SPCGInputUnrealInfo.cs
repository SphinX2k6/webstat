using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAB RID: 15787
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputUnrealInfo.SPCGInputUnrealInfo")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SPCGInputUnrealInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A6B RID: 158315 RVA: 0x009DE15B File Offset: 0x009DC35B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGInputUnrealInfo._ScriptStructPtr != 0) ? SPCGInputUnrealInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputUnrealInfo.SPCGInputUnrealInfo", ref SPCGInputUnrealInfo._ScriptStructPtr);
		}

		// Token: 0x1700588E RID: 22670
		// (get) Token: 0x06026A6C RID: 158316 RVA: 0x009DE180 File Offset: 0x009DC380
		// (set) Token: 0x06026A6D RID: 158317 RVA: 0x009DE1C3 File Offset: 0x009DC3C3
		public SPCGRiverMeshInfoList RiverMeshInfo
		{
			get
			{
				base.FastCheckIsValid();
				SPCGRiverMeshInfoList result;
				if ((result = this._RiverMeshInfo) == null)
				{
					result = (this._RiverMeshInfo = new SPCGRiverMeshInfoList(base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCGRiverMeshInfoList.StaticStruct(), base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700588F RID: 22671
		// (get) Token: 0x06026A6E RID: 158318 RVA: 0x009DE1E4 File Offset: 0x009DC3E4
		// (set) Token: 0x06026A6F RID: 158319 RVA: 0x009DE227 File Offset: 0x009DC427
		public SPCGRoadMeshInfoList RoadMeshInfo
		{
			get
			{
				base.FastCheckIsValid();
				SPCGRoadMeshInfoList result;
				if ((result = this._RoadMeshInfo) == null)
				{
					result = (this._RoadMeshInfo = new SPCGRoadMeshInfoList(base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCGRoadMeshInfoList.StaticStruct(), base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005890 RID: 22672
		// (get) Token: 0x06026A70 RID: 158320 RVA: 0x009DE248 File Offset: 0x009DC448
		// (set) Token: 0x06026A71 RID: 158321 RVA: 0x009DE28B File Offset: 0x009DC48B
		public SPCGStaticMeshInfoList StaticMeshInfo
		{
			get
			{
				base.FastCheckIsValid();
				SPCGStaticMeshInfoList result;
				if ((result = this._StaticMeshInfo) == null)
				{
					result = (this._StaticMeshInfo = new SPCGStaticMeshInfoList(base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCGStaticMeshInfoList.StaticStruct(), base.NativePtr + (IntPtr)SPCGInputUnrealInfo.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026A72 RID: 158322 RVA: 0x009DE2AC File Offset: 0x009DC4AC
		public SPCGInputUnrealInfo()
		{
		}

		// Token: 0x06026A73 RID: 158323 RVA: 0x009DE2B4 File Offset: 0x009DC4B4
		public SPCGInputUnrealInfo(SPCGRiverMeshInfoList RiverMeshInfo, SPCGRoadMeshInfoList RoadMeshInfo, SPCGStaticMeshInfoList StaticMeshInfo)
		{
			this.RiverMeshInfo = RiverMeshInfo;
			this.RoadMeshInfo = RoadMeshInfo;
			this.StaticMeshInfo = StaticMeshInfo;
		}

		// Token: 0x06026A74 RID: 158324 RVA: 0x009DE2D1 File Offset: 0x009DC4D1
		protected override IntPtr GetUStructPtr()
		{
			return SPCGInputUnrealInfo.StaticStruct();
		}

		// Token: 0x06026A75 RID: 158325 RVA: 0x009DE2DD File Offset: 0x009DC4DD
		[NullableContext(2)]
		public SPCGInputUnrealInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A76 RID: 158326 RVA: 0x009DE2E7 File Offset: 0x009DC4E7
		public SPCGInputUnrealInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A77 RID: 158327 RVA: 0x009DE2F2 File Offset: 0x009DC4F2
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGInputUnrealInfo(Pointer, false, true);
		}

		// Token: 0x06026A78 RID: 158328 RVA: 0x009DE2FC File Offset: 0x009DC4FC
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGInputUnrealInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401424C RID: 82508
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputUnrealInfo.SPCGInputUnrealInfo";

		// Token: 0x0401424D RID: 82509
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401424E RID: 82510
		internal static int __PropertyOffset_0;

		// Token: 0x0401424F RID: 82511
		[Nullable(2)]
		private SPCGRiverMeshInfoList _RiverMeshInfo;

		// Token: 0x04014250 RID: 82512
		internal static int __PropertyOffset_1;

		// Token: 0x04014251 RID: 82513
		[Nullable(2)]
		private SPCGRoadMeshInfoList _RoadMeshInfo;

		// Token: 0x04014252 RID: 82514
		internal static int __PropertyOffset_2;

		// Token: 0x04014253 RID: 82515
		[Nullable(2)]
		private SPCGStaticMeshInfoList _StaticMeshInfo;
	}
}
