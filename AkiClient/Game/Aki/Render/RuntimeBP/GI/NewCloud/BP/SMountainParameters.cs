using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CD0 RID: 15568
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SMountainParameters.SMountainParameters")]
	[UnrealStructLayout(1, 1, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1)]
	public class SMountainParameters : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060251D4 RID: 152020 RVA: 0x009B13F2 File Offset: 0x009AF5F2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMountainParameters._ScriptStructPtr != 0) ? SMountainParameters._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SMountainParameters.SMountainParameters", ref SMountainParameters._ScriptStructPtr);
		}

		// Token: 0x17004FBD RID: 20413
		// (get) Token: 0x060251D5 RID: 152021 RVA: 0x009B1416 File Offset: 0x009AF616
		// (set) Token: 0x060251D6 RID: 152022 RVA: 0x009B1426 File Offset: 0x009AF626
		public unsafe bool HasMountain
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMountainParameters.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMountainParameters.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x060251D7 RID: 152023 RVA: 0x009B1437 File Offset: 0x009AF637
		public SMountainParameters()
		{
		}

		// Token: 0x060251D8 RID: 152024 RVA: 0x009B143F File Offset: 0x009AF63F
		public SMountainParameters(bool HasMountain)
		{
			this.HasMountain = HasMountain;
		}

		// Token: 0x060251D9 RID: 152025 RVA: 0x009B144E File Offset: 0x009AF64E
		protected override IntPtr GetUStructPtr()
		{
			return SMountainParameters.StaticStruct();
		}

		// Token: 0x060251DA RID: 152026 RVA: 0x009B145A File Offset: 0x009AF65A
		[NullableContext(2)]
		public SMountainParameters(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060251DB RID: 152027 RVA: 0x009B1464 File Offset: 0x009AF664
		public SMountainParameters(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060251DC RID: 152028 RVA: 0x009B146F File Offset: 0x009AF66F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMountainParameters(Pointer, false, true);
		}

		// Token: 0x060251DD RID: 152029 RVA: 0x009B1479 File Offset: 0x009AF679
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMountainParameters(Pointer, MemoryOwner);
		}

		// Token: 0x040131B1 RID: 78257
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SMountainParameters.SMountainParameters";

		// Token: 0x040131B2 RID: 78258
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040131B3 RID: 78259
		internal static int __PropertyOffset_0;
	}
}
