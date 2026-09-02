using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAE RID: 15790
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfo.SPCGRoadMeshInfo")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SPCGRoadMeshInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A91 RID: 158353 RVA: 0x009DE514 File Offset: 0x009DC714
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGRoadMeshInfo._ScriptStructPtr != 0) ? SPCGRoadMeshInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfo.SPCGRoadMeshInfo", ref SPCGRoadMeshInfo._ScriptStructPtr);
		}

		// Token: 0x17005895 RID: 22677
		// (get) Token: 0x06026A92 RID: 158354 RVA: 0x009DE538 File Offset: 0x009DC738
		// (set) Token: 0x06026A93 RID: 158355 RVA: 0x009DE54C File Offset: 0x009DC74C
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPCGRoadMeshInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPCGRoadMeshInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005896 RID: 22678
		// (get) Token: 0x06026A94 RID: 158356 RVA: 0x009DE564 File Offset: 0x009DC764
		// (set) Token: 0x06026A95 RID: 158357 RVA: 0x009DE5A7 File Offset: 0x009DC7A7
		public TArray<float> Location
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new TArray<float>(base.NativePtr + (IntPtr)SPCGRoadMeshInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Location.CopyAssign(value);
			}
		}

		// Token: 0x17005897 RID: 22679
		// (get) Token: 0x06026A96 RID: 158358 RVA: 0x009DE5B8 File Offset: 0x009DC7B8
		// (set) Token: 0x06026A97 RID: 158359 RVA: 0x009DE5FB File Offset: 0x009DC7FB
		public TArray<float> Rotation
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new TArray<float>(base.NativePtr + (IntPtr)SPCGRoadMeshInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Rotation.CopyAssign(value);
			}
		}

		// Token: 0x06026A98 RID: 158360 RVA: 0x009DE609 File Offset: 0x009DC809
		public SPCGRoadMeshInfo()
		{
		}

		// Token: 0x06026A99 RID: 158361 RVA: 0x009DE611 File Offset: 0x009DC811
		public SPCGRoadMeshInfo(string Name, TArray<float> Location, TArray<float> Rotation)
		{
			this.Name = Name;
			this.Location = Location;
			this.Rotation = Rotation;
		}

		// Token: 0x06026A9A RID: 158362 RVA: 0x009DE62E File Offset: 0x009DC82E
		protected override IntPtr GetUStructPtr()
		{
			return SPCGRoadMeshInfo.StaticStruct();
		}

		// Token: 0x06026A9B RID: 158363 RVA: 0x009DE63A File Offset: 0x009DC83A
		[NullableContext(2)]
		public SPCGRoadMeshInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A9C RID: 158364 RVA: 0x009DE644 File Offset: 0x009DC844
		public SPCGRoadMeshInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A9D RID: 158365 RVA: 0x009DE64F File Offset: 0x009DC84F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGRoadMeshInfo(Pointer, false, true);
		}

		// Token: 0x06026A9E RID: 158366 RVA: 0x009DE659 File Offset: 0x009DC859
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGRoadMeshInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401425F RID: 82527
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRoadMeshInfo.SPCGRoadMeshInfo";

		// Token: 0x04014260 RID: 82528
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014261 RID: 82529
		internal static int __PropertyOffset_0;

		// Token: 0x04014262 RID: 82530
		internal static int __PropertyOffset_1;

		// Token: 0x04014263 RID: 82531
		[Nullable(2)]
		private TArray<float> _Location;

		// Token: 0x04014264 RID: 82532
		internal static int __PropertyOffset_2;

		// Token: 0x04014265 RID: 82533
		[Nullable(2)]
		private TArray<float> _Rotation;
	}
}
