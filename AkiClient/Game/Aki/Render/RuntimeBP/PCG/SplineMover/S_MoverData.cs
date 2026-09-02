using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SplineMover
{
	// Token: 0x02003B64 RID: 15204
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SplineMover/S_MoverData.S_MoverData")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 12)]
	public class S_MoverData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06021680 RID: 136832 RVA: 0x00948497 File Offset: 0x00946697
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_MoverData._ScriptStructPtr != 0) ? S_MoverData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/SplineMover/S_MoverData.S_MoverData", ref S_MoverData._ScriptStructPtr);
		}

		// Token: 0x17003B01 RID: 15105
		// (get) Token: 0x06021681 RID: 136833 RVA: 0x009484BB File Offset: 0x009466BB
		// (set) Token: 0x06021682 RID: 136834 RVA: 0x009484CF File Offset: 0x009466CF
		[Nullable(2)]
		public unsafe UStaticMeshComponent TargetMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + S_MoverData.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_MoverData.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003B02 RID: 15106
		// (get) Token: 0x06021683 RID: 136835 RVA: 0x009484E4 File Offset: 0x009466E4
		// (set) Token: 0x06021684 RID: 136836 RVA: 0x009484F4 File Offset: 0x009466F4
		public unsafe float CurrentDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_MoverData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_MoverData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x06021685 RID: 136837 RVA: 0x00948505 File Offset: 0x00946705
		public S_MoverData()
		{
		}

		// Token: 0x06021686 RID: 136838 RVA: 0x0094850D File Offset: 0x0094670D
		[NullableContext(1)]
		public S_MoverData(UStaticMeshComponent TargetMesh, float CurrentDistance)
		{
			this.TargetMesh = TargetMesh;
			this.CurrentDistance = CurrentDistance;
		}

		// Token: 0x06021687 RID: 136839 RVA: 0x00948523 File Offset: 0x00946723
		protected override IntPtr GetUStructPtr()
		{
			return S_MoverData.StaticStruct();
		}

		// Token: 0x06021688 RID: 136840 RVA: 0x0094852F File Offset: 0x0094672F
		[NullableContext(2)]
		public S_MoverData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06021689 RID: 136841 RVA: 0x00948539 File Offset: 0x00946739
		public S_MoverData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602168A RID: 136842 RVA: 0x00948544 File Offset: 0x00946744
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_MoverData(Pointer, false, true);
		}

		// Token: 0x0602168B RID: 136843 RVA: 0x0094854E File Offset: 0x0094674E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_MoverData(Pointer, MemoryOwner);
		}

		// Token: 0x04010D0E RID: 68878
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SplineMover/S_MoverData.S_MoverData";

		// Token: 0x04010D0F RID: 68879
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010D10 RID: 68880
		internal static int __PropertyOffset_0;

		// Token: 0x04010D11 RID: 68881
		internal static int __PropertyOffset_1;
	}
}
