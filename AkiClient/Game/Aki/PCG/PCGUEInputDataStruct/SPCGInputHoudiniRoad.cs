using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAA RID: 15786
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputHoudiniRoad.SPCGInputHoudiniRoad")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SPCGInputHoudiniRoad : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A61 RID: 158305 RVA: 0x009DE088 File Offset: 0x009DC288
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGInputHoudiniRoad._ScriptStructPtr != 0) ? SPCGInputHoudiniRoad._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputHoudiniRoad.SPCGInputHoudiniRoad", ref SPCGInputHoudiniRoad._ScriptStructPtr);
		}

		// Token: 0x1700588D RID: 22669
		// (get) Token: 0x06026A62 RID: 158306 RVA: 0x009DE0AC File Offset: 0x009DC2AC
		// (set) Token: 0x06026A63 RID: 158307 RVA: 0x009DE0EF File Offset: 0x009DC2EF
		public SPCGRoadMeshInfoList RoadMeshInfo
		{
			get
			{
				base.FastCheckIsValid();
				SPCGRoadMeshInfoList result;
				if ((result = this._RoadMeshInfo) == null)
				{
					result = (this._RoadMeshInfo = new SPCGRoadMeshInfoList(base.NativePtr + (IntPtr)SPCGInputHoudiniRoad.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SPCGRoadMeshInfoList.StaticStruct(), base.NativePtr + (IntPtr)SPCGInputHoudiniRoad.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026A64 RID: 158308 RVA: 0x009DE110 File Offset: 0x009DC310
		public SPCGInputHoudiniRoad()
		{
		}

		// Token: 0x06026A65 RID: 158309 RVA: 0x009DE118 File Offset: 0x009DC318
		public SPCGInputHoudiniRoad(SPCGRoadMeshInfoList RoadMeshInfo)
		{
			this.RoadMeshInfo = RoadMeshInfo;
		}

		// Token: 0x06026A66 RID: 158310 RVA: 0x009DE127 File Offset: 0x009DC327
		protected override IntPtr GetUStructPtr()
		{
			return SPCGInputHoudiniRoad.StaticStruct();
		}

		// Token: 0x06026A67 RID: 158311 RVA: 0x009DE133 File Offset: 0x009DC333
		[NullableContext(2)]
		public SPCGInputHoudiniRoad(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A68 RID: 158312 RVA: 0x009DE13D File Offset: 0x009DC33D
		public SPCGInputHoudiniRoad(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A69 RID: 158313 RVA: 0x009DE148 File Offset: 0x009DC348
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGInputHoudiniRoad(Pointer, false, true);
		}

		// Token: 0x06026A6A RID: 158314 RVA: 0x009DE152 File Offset: 0x009DC352
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGInputHoudiniRoad(Pointer, MemoryOwner);
		}

		// Token: 0x04014248 RID: 82504
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGInputHoudiniRoad.SPCGInputHoudiniRoad";

		// Token: 0x04014249 RID: 82505
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401424A RID: 82506
		internal static int __PropertyOffset_0;

		// Token: 0x0401424B RID: 82507
		[Nullable(2)]
		private SPCGRoadMeshInfoList _RoadMeshInfo;
	}
}
