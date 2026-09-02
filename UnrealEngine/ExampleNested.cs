using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace UnrealEngine
{
	// Token: 0x020043EE RID: 17390
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/json2struct/ExampleNested.ExampleNested")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class ExampleNested : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2E5 RID: 189157 RVA: 0x00ADB5A6 File Offset: 0x00AD97A6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ExampleNested._ScriptStructPtr != 0) ? ExampleNested._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/json2struct/ExampleNested.ExampleNested", ref ExampleNested._ScriptStructPtr);
		}

		// Token: 0x17007F27 RID: 32551
		// (get) Token: 0x0602E2E6 RID: 189158 RVA: 0x00ADB5CA File Offset: 0x00AD97CA
		// (set) Token: 0x0602E2E7 RID: 189159 RVA: 0x00ADB5DE File Offset: 0x00AD97DE
		public unsafe string StringNest
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)ExampleNested.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)ExampleNested.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007F28 RID: 32552
		// (get) Token: 0x0602E2E8 RID: 189160 RVA: 0x00ADB5F3 File Offset: 0x00AD97F3
		// (set) Token: 0x0602E2E9 RID: 189161 RVA: 0x00ADB603 File Offset: 0x00AD9803
		public unsafe int IntegerNest
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ExampleNested.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ExampleNested.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602E2EA RID: 189162 RVA: 0x00ADB614 File Offset: 0x00AD9814
		public ExampleNested()
		{
		}

		// Token: 0x0602E2EB RID: 189163 RVA: 0x00ADB61C File Offset: 0x00AD981C
		public ExampleNested(string StringNest, int IntegerNest)
		{
			this.StringNest = StringNest;
			this.IntegerNest = IntegerNest;
		}

		// Token: 0x0602E2EC RID: 189164 RVA: 0x00ADB632 File Offset: 0x00AD9832
		protected override IntPtr GetUStructPtr()
		{
			return ExampleNested.StaticStruct();
		}

		// Token: 0x0602E2ED RID: 189165 RVA: 0x00ADB63E File Offset: 0x00AD983E
		[NullableContext(2)]
		public ExampleNested(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2EE RID: 189166 RVA: 0x00ADB648 File Offset: 0x00AD9848
		public ExampleNested(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2EF RID: 189167 RVA: 0x00ADB653 File Offset: 0x00AD9853
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ExampleNested(Pointer, false, true);
		}

		// Token: 0x0602E2F0 RID: 189168 RVA: 0x00ADB65D File Offset: 0x00AD985D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ExampleNested(Pointer, MemoryOwner);
		}

		// Token: 0x0401A214 RID: 107028
		public const string __ObjectPath = "/json2struct/ExampleNested.ExampleNested";

		// Token: 0x0401A215 RID: 107029
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A216 RID: 107030
		internal static int __PropertyOffset_0;

		// Token: 0x0401A217 RID: 107031
		internal static int __PropertyOffset_1;
	}
}
