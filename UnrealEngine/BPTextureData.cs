using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace UnrealEngine
{
	// Token: 0x020043EB RID: 17387
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/ImpostorBaker/ImpostorBaker/BP/Structs/BPTextureData.BPTextureData")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class BPTextureData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2BF RID: 189119 RVA: 0x00ADB30C File Offset: 0x00AD950C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BPTextureData._ScriptStructPtr != 0) ? BPTextureData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/ImpostorBaker/ImpostorBaker/BP/Structs/BPTextureData.BPTextureData", ref BPTextureData._ScriptStructPtr);
		}

		// Token: 0x17007F20 RID: 32544
		// (get) Token: 0x0602E2C0 RID: 189120 RVA: 0x00ADB330 File Offset: 0x00AD9530
		// (set) Token: 0x0602E2C1 RID: 189121 RVA: 0x00ADB340 File Offset: 0x00AD9540
		public unsafe int SizeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPTextureData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPTextureData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007F21 RID: 32545
		// (get) Token: 0x0602E2C2 RID: 189122 RVA: 0x00ADB351 File Offset: 0x00AD9551
		// (set) Token: 0x0602E2C3 RID: 189123 RVA: 0x00ADB361 File Offset: 0x00AD9561
		public unsafe int SizeY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BPTextureData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BPTextureData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007F22 RID: 32546
		// (get) Token: 0x0602E2C4 RID: 189124 RVA: 0x00ADB374 File Offset: 0x00AD9574
		// (set) Token: 0x0602E2C5 RID: 189125 RVA: 0x00ADB3B7 File Offset: 0x00AD95B7
		public TArray<FLinearColor> ColorData
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FLinearColor> result;
				if ((result = this._ColorData) == null)
				{
					result = (this._ColorData = new TArray<FLinearColor>(base.NativePtr + (IntPtr)BPTextureData.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ColorData.CopyAssign(value);
			}
		}

		// Token: 0x0602E2C6 RID: 189126 RVA: 0x00ADB3C5 File Offset: 0x00AD95C5
		public BPTextureData()
		{
		}

		// Token: 0x0602E2C7 RID: 189127 RVA: 0x00ADB3CD File Offset: 0x00AD95CD
		public BPTextureData(int SizeX, int SizeY, TArray<FLinearColor> ColorData)
		{
			this.SizeX = SizeX;
			this.SizeY = SizeY;
			this.ColorData = ColorData;
		}

		// Token: 0x0602E2C8 RID: 189128 RVA: 0x00ADB3EA File Offset: 0x00AD95EA
		protected override IntPtr GetUStructPtr()
		{
			return BPTextureData.StaticStruct();
		}

		// Token: 0x0602E2C9 RID: 189129 RVA: 0x00ADB3F6 File Offset: 0x00AD95F6
		[NullableContext(2)]
		public BPTextureData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2CA RID: 189130 RVA: 0x00ADB400 File Offset: 0x00AD9600
		public BPTextureData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2CB RID: 189131 RVA: 0x00ADB40B File Offset: 0x00AD960B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BPTextureData(Pointer, false, true);
		}

		// Token: 0x0602E2CC RID: 189132 RVA: 0x00ADB415 File Offset: 0x00AD9615
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BPTextureData(Pointer, MemoryOwner);
		}

		// Token: 0x0401A206 RID: 107014
		public const string __ObjectPath = "/ImpostorBaker/ImpostorBaker/BP/Structs/BPTextureData.BPTextureData";

		// Token: 0x0401A207 RID: 107015
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A208 RID: 107016
		internal static int __PropertyOffset_0;

		// Token: 0x0401A209 RID: 107017
		internal static int __PropertyOffset_1;

		// Token: 0x0401A20A RID: 107018
		internal static int __PropertyOffset_2;

		// Token: 0x0401A20B RID: 107019
		[Nullable(2)]
		private TArray<FLinearColor> _ColorData;
	}
}
