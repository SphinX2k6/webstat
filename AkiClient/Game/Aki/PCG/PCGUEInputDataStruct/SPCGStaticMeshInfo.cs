using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.PCG.PCGUEInputDataStruct
{
	// Token: 0x02003DB0 RID: 15792
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfo.SPCGStaticMeshInfo")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SPCGStaticMeshInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026AA9 RID: 158377 RVA: 0x009DE724 File Offset: 0x009DC924
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCGStaticMeshInfo._ScriptStructPtr != 0) ? SPCGStaticMeshInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfo.SPCGStaticMeshInfo", ref SPCGStaticMeshInfo._ScriptStructPtr);
		}

		// Token: 0x17005899 RID: 22681
		// (get) Token: 0x06026AAA RID: 158378 RVA: 0x009DE748 File Offset: 0x009DC948
		// (set) Token: 0x06026AAB RID: 158379 RVA: 0x009DE75C File Offset: 0x009DC95C
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPCGStaticMeshInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPCGStaticMeshInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x1700589A RID: 22682
		// (get) Token: 0x06026AAC RID: 158380 RVA: 0x009DE774 File Offset: 0x009DC974
		// (set) Token: 0x06026AAD RID: 158381 RVA: 0x009DE7B7 File Offset: 0x009DC9B7
		public TArray<float> Location
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Location) == null)
				{
					result = (this._Location = new TArray<float>(base.NativePtr + (IntPtr)SPCGStaticMeshInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Location.CopyAssign(value);
			}
		}

		// Token: 0x1700589B RID: 22683
		// (get) Token: 0x06026AAE RID: 158382 RVA: 0x009DE7C8 File Offset: 0x009DC9C8
		// (set) Token: 0x06026AAF RID: 158383 RVA: 0x009DE80B File Offset: 0x009DCA0B
		public TArray<float> Rotation
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Rotation) == null)
				{
					result = (this._Rotation = new TArray<float>(base.NativePtr + (IntPtr)SPCGStaticMeshInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Rotation.CopyAssign(value);
			}
		}

		// Token: 0x1700589C RID: 22684
		// (get) Token: 0x06026AB0 RID: 158384 RVA: 0x009DE81C File Offset: 0x009DCA1C
		// (set) Token: 0x06026AB1 RID: 158385 RVA: 0x009DE85F File Offset: 0x009DCA5F
		public TArray<float> Scale
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Scale) == null)
				{
					result = (this._Scale = new TArray<float>(base.NativePtr + (IntPtr)SPCGStaticMeshInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Scale.CopyAssign(value);
			}
		}

		// Token: 0x06026AB2 RID: 158386 RVA: 0x009DE86D File Offset: 0x009DCA6D
		public SPCGStaticMeshInfo()
		{
		}

		// Token: 0x06026AB3 RID: 158387 RVA: 0x009DE875 File Offset: 0x009DCA75
		public SPCGStaticMeshInfo(string Name, TArray<float> Location, TArray<float> Rotation, TArray<float> Scale)
		{
			this.Name = Name;
			this.Location = Location;
			this.Rotation = Rotation;
			this.Scale = Scale;
		}

		// Token: 0x06026AB4 RID: 158388 RVA: 0x009DE89A File Offset: 0x009DCA9A
		protected override IntPtr GetUStructPtr()
		{
			return SPCGStaticMeshInfo.StaticStruct();
		}

		// Token: 0x06026AB5 RID: 158389 RVA: 0x009DE8A6 File Offset: 0x009DCAA6
		[NullableContext(2)]
		public SPCGStaticMeshInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026AB6 RID: 158390 RVA: 0x009DE8B0 File Offset: 0x009DCAB0
		public SPCGStaticMeshInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026AB7 RID: 158391 RVA: 0x009DE8BB File Offset: 0x009DCABB
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCGStaticMeshInfo(Pointer, false, true);
		}

		// Token: 0x06026AB8 RID: 158392 RVA: 0x009DE8C5 File Offset: 0x009DCAC5
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCGStaticMeshInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401426A RID: 82538
		public const string __ObjectPath = "/Game/Aki/PCG/PCGUEInputDataStruct/SPCGStaticMeshInfo.SPCGStaticMeshInfo";

		// Token: 0x0401426B RID: 82539
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401426C RID: 82540
		internal static int __PropertyOffset_0;

		// Token: 0x0401426D RID: 82541
		internal static int __PropertyOffset_1;

		// Token: 0x0401426E RID: 82542
		[Nullable(2)]
		private TArray<float> _Location;

		// Token: 0x0401426F RID: 82543
		internal static int __PropertyOffset_2;

		// Token: 0x04014270 RID: 82544
		[Nullable(2)]
		private TArray<float> _Rotation;

		// Token: 0x04014271 RID: 82545
		internal static int __PropertyOffset_3;

		// Token: 0x04014272 RID: 82546
		[Nullable(2)]
		private TArray<float> _Scale;
	}
}
