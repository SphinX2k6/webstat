using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG._2DRayCastingGamePlay.BuildNewVertexBuffer
{
	// Token: 0x02003C55 RID: 15445
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/S_FSBoxArr.S_FSBoxArr")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class S_FSBoxArr : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023A9C RID: 146076 RVA: 0x0098897C File Offset: 0x00986B7C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_FSBoxArr._ScriptStructPtr != 0) ? S_FSBoxArr._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/S_FSBoxArr.S_FSBoxArr", ref S_FSBoxArr._ScriptStructPtr);
		}

		// Token: 0x170047B6 RID: 18358
		// (get) Token: 0x06023A9D RID: 146077 RVA: 0x009889A0 File Offset: 0x00986BA0
		// (set) Token: 0x06023A9E RID: 146078 RVA: 0x009889E3 File Offset: 0x00986BE3
		public TArray<FVector> Origin
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Origin) == null)
				{
					result = (this._Origin = new TArray<FVector>(base.NativePtr + (IntPtr)S_FSBoxArr.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Origin.CopyAssign(value);
			}
		}

		// Token: 0x170047B7 RID: 18359
		// (get) Token: 0x06023A9F RID: 146079 RVA: 0x009889F4 File Offset: 0x00986BF4
		// (set) Token: 0x06023AA0 RID: 146080 RVA: 0x00988A37 File Offset: 0x00986C37
		public TArray<FVector> BoxExtent
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._BoxExtent) == null)
				{
					result = (this._BoxExtent = new TArray<FVector>(base.NativePtr + (IntPtr)S_FSBoxArr.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BoxExtent.CopyAssign(value);
			}
		}

		// Token: 0x06023AA1 RID: 146081 RVA: 0x00988A45 File Offset: 0x00986C45
		public S_FSBoxArr()
		{
		}

		// Token: 0x06023AA2 RID: 146082 RVA: 0x00988A4D File Offset: 0x00986C4D
		public S_FSBoxArr(TArray<FVector> Origin, TArray<FVector> BoxExtent)
		{
			this.Origin = Origin;
			this.BoxExtent = BoxExtent;
		}

		// Token: 0x06023AA3 RID: 146083 RVA: 0x00988A63 File Offset: 0x00986C63
		protected override IntPtr GetUStructPtr()
		{
			return S_FSBoxArr.StaticStruct();
		}

		// Token: 0x06023AA4 RID: 146084 RVA: 0x00988A6F File Offset: 0x00986C6F
		[NullableContext(2)]
		public S_FSBoxArr(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023AA5 RID: 146085 RVA: 0x00988A79 File Offset: 0x00986C79
		public S_FSBoxArr(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023AA6 RID: 146086 RVA: 0x00988A84 File Offset: 0x00986C84
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_FSBoxArr(Pointer, false, true);
		}

		// Token: 0x06023AA7 RID: 146087 RVA: 0x00988A8E File Offset: 0x00986C8E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_FSBoxArr(Pointer, MemoryOwner);
		}

		// Token: 0x040122E8 RID: 74472
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/2DRayCastingGamePlay/BuildNewVertexBuffer/S_FSBoxArr.S_FSBoxArr";

		// Token: 0x040122E9 RID: 74473
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040122EA RID: 74474
		internal static int __PropertyOffset_0;

		// Token: 0x040122EB RID: 74475
		[Nullable(2)]
		private TArray<FVector> _Origin;

		// Token: 0x040122EC RID: 74476
		internal static int __PropertyOffset_1;

		// Token: 0x040122ED RID: 74477
		[Nullable(2)]
		private TArray<FVector> _BoxExtent;
	}
}
