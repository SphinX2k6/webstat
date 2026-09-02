using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Map.BlockOut.Tools.LevelMarker
{
	// Token: 0x02003DB9 RID: 15801
	[UnrealObjectPath("/Game/Aki/Map/BlockOut/Tools/LevelMarker/SLevelMarkerInfo.SLevelMarkerInfo")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SLevelMarkerInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026B02 RID: 158466 RVA: 0x009DF0F6 File Offset: 0x009DD2F6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLevelMarkerInfo._ScriptStructPtr != 0) ? SLevelMarkerInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Map/BlockOut/Tools/LevelMarker/SLevelMarkerInfo.SLevelMarkerInfo", ref SLevelMarkerInfo._ScriptStructPtr);
		}

		// Token: 0x170058B3 RID: 22707
		// (get) Token: 0x06026B03 RID: 158467 RVA: 0x009DF11A File Offset: 0x009DD31A
		// (set) Token: 0x06026B04 RID: 158468 RVA: 0x009DF12E File Offset: 0x009DD32E
		public unsafe TEnumAsByte<ELevelMarkerType> MarkInfoType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLevelMarkerInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLevelMarkerInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170058B4 RID: 22708
		// (get) Token: 0x06026B05 RID: 158469 RVA: 0x009DF144 File Offset: 0x009DD344
		// (set) Token: 0x06026B06 RID: 158470 RVA: 0x009DF187 File Offset: 0x009DD387
		[Nullable(1)]
		public unsafe FText MarkInfo
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._MarkInfo) == null)
				{
					result = (this._MarkInfo = new FText(base.NativePtr + (IntPtr)SLevelMarkerInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SLevelMarkerInfo.__PropertyOffset_1)), value.NativePtr, 1);
			}
		}

		// Token: 0x06026B07 RID: 158471 RVA: 0x009DF1A2 File Offset: 0x009DD3A2
		public SLevelMarkerInfo()
		{
		}

		// Token: 0x06026B08 RID: 158472 RVA: 0x009DF1AA File Offset: 0x009DD3AA
		public SLevelMarkerInfo(TEnumAsByte<ELevelMarkerType> MarkInfoType, [Nullable(1)] FText MarkInfo)
		{
			this.MarkInfoType = MarkInfoType;
			this.MarkInfo = MarkInfo;
		}

		// Token: 0x06026B09 RID: 158473 RVA: 0x009DF1C0 File Offset: 0x009DD3C0
		protected override IntPtr GetUStructPtr()
		{
			return SLevelMarkerInfo.StaticStruct();
		}

		// Token: 0x06026B0A RID: 158474 RVA: 0x009DF1CC File Offset: 0x009DD3CC
		[NullableContext(2)]
		public SLevelMarkerInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B0B RID: 158475 RVA: 0x009DF1D6 File Offset: 0x009DD3D6
		public SLevelMarkerInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B0C RID: 158476 RVA: 0x009DF1E1 File Offset: 0x009DD3E1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLevelMarkerInfo(Pointer, false, true);
		}

		// Token: 0x06026B0D RID: 158477 RVA: 0x009DF1EB File Offset: 0x009DD3EB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLevelMarkerInfo(Pointer, MemoryOwner);
		}

		// Token: 0x040142BA RID: 82618
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Map/BlockOut/Tools/LevelMarker/SLevelMarkerInfo.SLevelMarkerInfo";

		// Token: 0x040142BB RID: 82619
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040142BC RID: 82620
		internal static int __PropertyOffset_0;

		// Token: 0x040142BD RID: 82621
		internal static int __PropertyOffset_1;

		// Token: 0x040142BE RID: 82622
		[Nullable(2)]
		private FText _MarkInfo;
	}
}
