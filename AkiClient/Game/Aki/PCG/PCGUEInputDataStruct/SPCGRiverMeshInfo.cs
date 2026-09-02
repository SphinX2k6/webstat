using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DAC RID: 15788
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfo.SPCGRiverMeshInfo")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SPCGRiverMeshInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026A79 RID: 158329 RVA: 0x009DE305 File Offset: 0x009DC505
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGRiverMeshInfo._ScriptStructPtr != 0) ? SPCGRiverMeshInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfo.SPCGRiverMeshInfo", ref SPCGRiverMeshInfo._ScriptStructPtr);
		}

		// Token: 0x17005891 RID: 22673
		// (get) Token: 0x06026A7A RID: 158330 RVA: 0x009DE329 File Offset: 0x009DC529
		// (set) Token: 0x06026A7B RID: 158331 RVA: 0x009DE33D File Offset: 0x009DC53D
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPCGRiverMeshInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPCGRiverMeshInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005892 RID: 22674
		// (get) Token: 0x06026A7C RID: 158332 RVA: 0x009DE354 File Offset: 0x009DC554
		// (set) Token: 0x06026A7D RID: 158333 RVA: 0x009DE397 File Offset: 0x009DC597
		public TArray<float> Location
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new TArray<float>(base.NativePtr + (IntPtr)SPCGRiverMeshInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Location.CopyAssign(value);
			}
		}

		// Token: 0x17005893 RID: 22675
		// (get) Token: 0x06026A7E RID: 158334 RVA: 0x009DE3A8 File Offset: 0x009DC5A8
		// (set) Token: 0x06026A7F RID: 158335 RVA: 0x009DE3EB File Offset: 0x009DC5EB
		public TArray<float> Rotation
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new TArray<float>(base.NativePtr + (IntPtr)SPCGRiverMeshInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Rotation.CopyAssign(value);
			}
		}

		// Token: 0x06026A80 RID: 158336 RVA: 0x009DE3F9 File Offset: 0x009DC5F9
		public SPCGRiverMeshInfo()
		{
		}

		// Token: 0x06026A81 RID: 158337 RVA: 0x009DE401 File Offset: 0x009DC601
		public SPCGRiverMeshInfo(string Name, TArray<float> Location, TArray<float> Rotation)
		{
			this.Name = Name;
			this.Location = Location;
			this.Rotation = Rotation;
		}

		// Token: 0x06026A82 RID: 158338 RVA: 0x009DE41E File Offset: 0x009DC61E
		protected override IntPtr GetUStructPtr()
		{
			return SPCGRiverMeshInfo.StaticStruct();
		}

		// Token: 0x06026A83 RID: 158339 RVA: 0x009DE42A File Offset: 0x009DC62A
		[NullableContext(2)]
		public SPCGRiverMeshInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026A84 RID: 158340 RVA: 0x009DE434 File Offset: 0x009DC634
		public SPCGRiverMeshInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026A85 RID: 158341 RVA: 0x009DE43F File Offset: 0x009DC63F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGRiverMeshInfo(Pointer, false, true);
		}

		// Token: 0x06026A86 RID: 158342 RVA: 0x009DE449 File Offset: 0x009DC649
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGRiverMeshInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014254 RID: 82516
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGRiverMeshInfo.SPCGRiverMeshInfo";

		// Token: 0x04014255 RID: 82517
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014256 RID: 82518
		internal static int __PropertyOffset_0;

		// Token: 0x04014257 RID: 82519
		internal static int __PropertyOffset_1;

		// Token: 0x04014258 RID: 82520
		[Nullable(2)]
		private TArray<float> _Location;

		// Token: 0x04014259 RID: 82521
		internal static int __PropertyOffset_2;

		// Token: 0x0401425A RID: 82522
		[Nullable(2)]
		private TArray<float> _Rotation;
	}
}
