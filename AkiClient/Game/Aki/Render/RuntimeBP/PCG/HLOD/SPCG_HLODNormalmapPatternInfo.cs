using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.HLOD
{
	// Token: 0x02003C0E RID: 15374
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/HLOD/SPCG_HLODNormalmapPatternInfo.SPCG_HLODNormalmapPatternInfo")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SPCG_HLODNormalmapPatternInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022F16 RID: 143126 RVA: 0x00973C2B File Offset: 0x00971E2B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPCG_HLODNormalmapPatternInfo._ScriptStructPtr != 0) ? SPCG_HLODNormalmapPatternInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/HLOD/SPCG_HLODNormalmapPatternInfo.SPCG_HLODNormalmapPatternInfo", ref SPCG_HLODNormalmapPatternInfo._ScriptStructPtr);
		}

		// Token: 0x17004395 RID: 17301
		// (get) Token: 0x06022F17 RID: 143127 RVA: 0x00973C4F File Offset: 0x00971E4F
		// (set) Token: 0x06022F18 RID: 143128 RVA: 0x00973C63 File Offset: 0x00971E63
		public unsafe string pattern_info
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPCG_HLODNormalmapPatternInfo.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPCG_HLODNormalmapPatternInfo.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x06022F19 RID: 143129 RVA: 0x00973C78 File Offset: 0x00971E78
		public SPCG_HLODNormalmapPatternInfo()
		{
		}

		// Token: 0x06022F1A RID: 143130 RVA: 0x00973C80 File Offset: 0x00971E80
		public SPCG_HLODNormalmapPatternInfo(string pattern_info)
		{
			this.pattern_info = pattern_info;
		}

		// Token: 0x06022F1B RID: 143131 RVA: 0x00973C8F File Offset: 0x00971E8F
		protected override IntPtr GetUStructPtr()
		{
			return SPCG_HLODNormalmapPatternInfo.StaticStruct();
		}

		// Token: 0x06022F1C RID: 143132 RVA: 0x00973C9B File Offset: 0x00971E9B
		[NullableContext(2)]
		public SPCG_HLODNormalmapPatternInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022F1D RID: 143133 RVA: 0x00973CA5 File Offset: 0x00971EA5
		public SPCG_HLODNormalmapPatternInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022F1E RID: 143134 RVA: 0x00973CB0 File Offset: 0x00971EB0
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPCG_HLODNormalmapPatternInfo(Pointer, false, true);
		}

		// Token: 0x06022F1F RID: 143135 RVA: 0x00973CBA File Offset: 0x00971EBA
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPCG_HLODNormalmapPatternInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04011BF6 RID: 72694
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/HLOD/SPCG_HLODNormalmapPatternInfo.SPCG_HLODNormalmapPatternInfo";

		// Token: 0x04011BF7 RID: 72695
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011BF8 RID: 72696
		internal static int __PropertyOffset_0;
	}
}
