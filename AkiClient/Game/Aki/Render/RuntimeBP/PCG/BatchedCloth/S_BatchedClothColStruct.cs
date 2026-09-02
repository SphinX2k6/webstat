using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BatchedCloth
{
	// Token: 0x02003C43 RID: 15427
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColStruct.S_BatchedClothColStruct")]
	[UnrealStructLayout(64, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class S_BatchedClothColStruct : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023795 RID: 145301 RVA: 0x009834DC File Offset: 0x009816DC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BatchedClothColStruct._ScriptStructPtr != 0) ? S_BatchedClothColStruct._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColStruct.S_BatchedClothColStruct", ref S_BatchedClothColStruct._ScriptStructPtr);
		}

		// Token: 0x1700469D RID: 18077
		// (get) Token: 0x06023796 RID: 145302 RVA: 0x00983500 File Offset: 0x00981700
		// (set) Token: 0x06023797 RID: 145303 RVA: 0x00983514 File Offset: 0x00981714
		[Nullable(2)]
		public unsafe UStaticMesh StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + S_BatchedClothColStruct.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_BatchedClothColStruct.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700469E RID: 18078
		// (get) Token: 0x06023798 RID: 145304 RVA: 0x00983529 File Offset: 0x00981729
		// (set) Token: 0x06023799 RID: 145305 RVA: 0x0098353D File Offset: 0x0098173D
		public unsafe FTransform SMTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_BatchedClothColStruct.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_BatchedClothColStruct.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602379A RID: 145306 RVA: 0x00983552 File Offset: 0x00981752
		public S_BatchedClothColStruct()
		{
		}

		// Token: 0x0602379B RID: 145307 RVA: 0x0098355A File Offset: 0x0098175A
		[NullableContext(1)]
		public S_BatchedClothColStruct(UStaticMesh StaticMesh, FTransform SMTransform)
		{
			this.StaticMesh = StaticMesh;
			this.SMTransform = SMTransform;
		}

		// Token: 0x0602379C RID: 145308 RVA: 0x00983570 File Offset: 0x00981770
		protected override IntPtr GetUStructPtr()
		{
			return S_BatchedClothColStruct.StaticStruct();
		}

		// Token: 0x0602379D RID: 145309 RVA: 0x0098357C File Offset: 0x0098177C
		[NullableContext(2)]
		public S_BatchedClothColStruct(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602379E RID: 145310 RVA: 0x00983586 File Offset: 0x00981786
		public S_BatchedClothColStruct(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602379F RID: 145311 RVA: 0x00983591 File Offset: 0x00981791
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_BatchedClothColStruct(Pointer, false, true);
		}

		// Token: 0x060237A0 RID: 145312 RVA: 0x0098359B File Offset: 0x0098179B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_BatchedClothColStruct(Pointer, MemoryOwner);
		}

		// Token: 0x040120FA RID: 73978
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BatchedCloth/S_BatchedClothColStruct.S_BatchedClothColStruct";

		// Token: 0x040120FB RID: 73979
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040120FC RID: 73980
		internal static int __PropertyOffset_0;

		// Token: 0x040120FD RID: 73981
		internal static int __PropertyOffset_1;
	}
}
