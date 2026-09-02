using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043EC RID: 17388
	[HasGetTypeHash]
	[UnrealObjectPath("/ImpostorBaker/ImpostorBaker/BP/Structs/ImpostorStaticTextureData.ImpostorStaticTextureData")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 9)]
	public class ImpostorStaticTextureData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2CD RID: 189133 RVA: 0x00ADB41E File Offset: 0x00AD961E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ImpostorStaticTextureData._ScriptStructPtr != 0) ? ImpostorStaticTextureData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/ImpostorBaker/ImpostorBaker/BP/Structs/ImpostorStaticTextureData.ImpostorStaticTextureData", ref ImpostorStaticTextureData._ScriptStructPtr);
		}

		// Token: 0x17007F23 RID: 32547
		// (get) Token: 0x0602E2CE RID: 189134 RVA: 0x00ADB442 File Offset: 0x00AD9642
		// (set) Token: 0x0602E2CF RID: 189135 RVA: 0x00ADB456 File Offset: 0x00AD9656
		[Nullable(2)]
		public unsafe UTexture2D Texture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + ImpostorStaticTextureData.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ImpostorStaticTextureData.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007F24 RID: 32548
		// (get) Token: 0x0602E2D0 RID: 189136 RVA: 0x00ADB46B File Offset: 0x00AD966B
		// (set) Token: 0x0602E2D1 RID: 189137 RVA: 0x00ADB47F File Offset: 0x00AD967F
		public unsafe TEnumAsByte<EImpostorBakeTypes> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ImpostorStaticTextureData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ImpostorStaticTextureData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602E2D2 RID: 189138 RVA: 0x00ADB494 File Offset: 0x00AD9694
		public ImpostorStaticTextureData()
		{
		}

		// Token: 0x0602E2D3 RID: 189139 RVA: 0x00ADB49C File Offset: 0x00AD969C
		public ImpostorStaticTextureData([Nullable(1)] UTexture2D Texture, TEnumAsByte<EImpostorBakeTypes> Type)
		{
			this.Texture = Texture;
			this.Type = Type;
		}

		// Token: 0x0602E2D4 RID: 189140 RVA: 0x00ADB4B2 File Offset: 0x00AD96B2
		protected override IntPtr GetUStructPtr()
		{
			return ImpostorStaticTextureData.StaticStruct();
		}

		// Token: 0x0602E2D5 RID: 189141 RVA: 0x00ADB4BE File Offset: 0x00AD96BE
		[NullableContext(2)]
		public ImpostorStaticTextureData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2D6 RID: 189142 RVA: 0x00ADB4C8 File Offset: 0x00AD96C8
		public ImpostorStaticTextureData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2D7 RID: 189143 RVA: 0x00ADB4D3 File Offset: 0x00AD96D3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ImpostorStaticTextureData(Pointer, false, true);
		}

		// Token: 0x0602E2D8 RID: 189144 RVA: 0x00ADB4DD File Offset: 0x00AD96DD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ImpostorStaticTextureData(Pointer, MemoryOwner);
		}

		// Token: 0x0401A20C RID: 107020
		[Nullable(1)]
		public const string __ObjectPath = "/ImpostorBaker/ImpostorBaker/BP/Structs/ImpostorStaticTextureData.ImpostorStaticTextureData";

		// Token: 0x0401A20D RID: 107021
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A20E RID: 107022
		internal static int __PropertyOffset_0;

		// Token: 0x0401A20F RID: 107023
		internal static int __PropertyOffset_1;
	}
}
