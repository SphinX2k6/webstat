using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Furniture.Structure
{
	// Token: 0x02003EB6 RID: 16054
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Furniture/Structure/FurnitureLevelGenerateInfo.FurnitureLevelGenerateInfo")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class FurnitureLevelGenerateInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027DD6 RID: 163286 RVA: 0x009FC76C File Offset: 0x009FA96C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (FurnitureLevelGenerateInfo._ScriptStructPtr != 0) ? FurnitureLevelGenerateInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Furniture/Structure/FurnitureLevelGenerateInfo.FurnitureLevelGenerateInfo", ref FurnitureLevelGenerateInfo._ScriptStructPtr);
		}

		// Token: 0x17005F49 RID: 24393
		// (get) Token: 0x06027DD7 RID: 163287 RVA: 0x009FC790 File Offset: 0x009FA990
		// (set) Token: 0x06027DD8 RID: 163288 RVA: 0x009FC7AF File Offset: 0x009FA9AF
		public TSoftObjectPtr<UStaticMesh> SourcePath
		{
			get
			{
				return new TSoftObjectPtr<UStaticMesh>(base.NativePtr + (IntPtr)FurnitureLevelGenerateInfo.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)FurnitureLevelGenerateInfo.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F4A RID: 24394
		// (get) Token: 0x06027DD9 RID: 163289 RVA: 0x009FC7D4 File Offset: 0x009FA9D4
		// (set) Token: 0x06027DDA RID: 163290 RVA: 0x009FC7E8 File Offset: 0x009FA9E8
		public unsafe string TargetSubPath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)FurnitureLevelGenerateInfo.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)FurnitureLevelGenerateInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x06027DDB RID: 163291 RVA: 0x009FC7FD File Offset: 0x009FA9FD
		public FurnitureLevelGenerateInfo()
		{
		}

		// Token: 0x06027DDC RID: 163292 RVA: 0x009FC805 File Offset: 0x009FAA05
		public FurnitureLevelGenerateInfo(TSoftObjectPtr<UStaticMesh> SourcePath, string TargetSubPath)
		{
			this.SourcePath = SourcePath;
			this.TargetSubPath = TargetSubPath;
		}

		// Token: 0x06027DDD RID: 163293 RVA: 0x009FC81B File Offset: 0x009FAA1B
		protected override IntPtr GetUStructPtr()
		{
			return FurnitureLevelGenerateInfo.StaticStruct();
		}

		// Token: 0x06027DDE RID: 163294 RVA: 0x009FC827 File Offset: 0x009FAA27
		[NullableContext(2)]
		public FurnitureLevelGenerateInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027DDF RID: 163295 RVA: 0x009FC831 File Offset: 0x009FAA31
		public FurnitureLevelGenerateInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027DE0 RID: 163296 RVA: 0x009FC83C File Offset: 0x009FAA3C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new FurnitureLevelGenerateInfo(Pointer, false, true);
		}

		// Token: 0x06027DE1 RID: 163297 RVA: 0x009FC846 File Offset: 0x009FAA46
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new FurnitureLevelGenerateInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014EBE RID: 85694
		public const string __ObjectPath = "/Game/Aki/Data/Furniture/Structure/FurnitureLevelGenerateInfo.FurnitureLevelGenerateInfo";

		// Token: 0x04014EBF RID: 85695
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EC0 RID: 85696
		internal static int __PropertyOffset_0;

		// Token: 0x04014EC1 RID: 85697
		internal static int __PropertyOffset_1;
	}
}
