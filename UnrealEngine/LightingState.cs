using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043ED RID: 17389
	[HasGetTypeHash]
	[UnrealObjectPath("/ImpostorBaker/ImpostorBaker/BP/Structs/LightingState.LightingState")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 9)]
	public class LightingState : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2D9 RID: 189145 RVA: 0x00ADB4E6 File Offset: 0x00AD96E6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (LightingState._ScriptStructPtr != 0) ? LightingState._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/ImpostorBaker/ImpostorBaker/BP/Structs/LightingState.LightingState", ref LightingState._ScriptStructPtr);
		}

		// Token: 0x17007F25 RID: 32549
		// (get) Token: 0x0602E2DA RID: 189146 RVA: 0x00ADB50A File Offset: 0x00AD970A
		// (set) Token: 0x0602E2DB RID: 189147 RVA: 0x00ADB51E File Offset: 0x00AD971E
		[Nullable(2)]
		public unsafe ALight Light
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ALight>(base.NativePtr / (IntPtr)sizeof(void*) + LightingState.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LightingState.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007F26 RID: 32550
		// (get) Token: 0x0602E2DC RID: 189148 RVA: 0x00ADB533 File Offset: 0x00AD9733
		// (set) Token: 0x0602E2DD RID: 189149 RVA: 0x00ADB543 File Offset: 0x00AD9743
		public unsafe bool Visible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)LightingState.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)LightingState.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602E2DE RID: 189150 RVA: 0x00ADB554 File Offset: 0x00AD9754
		public LightingState()
		{
		}

		// Token: 0x0602E2DF RID: 189151 RVA: 0x00ADB55C File Offset: 0x00AD975C
		[NullableContext(1)]
		public LightingState(ALight Light, bool Visible)
		{
			this.Light = Light;
			this.Visible = Visible;
		}

		// Token: 0x0602E2E0 RID: 189152 RVA: 0x00ADB572 File Offset: 0x00AD9772
		protected override IntPtr GetUStructPtr()
		{
			return LightingState.StaticStruct();
		}

		// Token: 0x0602E2E1 RID: 189153 RVA: 0x00ADB57E File Offset: 0x00AD977E
		[NullableContext(2)]
		public LightingState(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2E2 RID: 189154 RVA: 0x00ADB588 File Offset: 0x00AD9788
		public LightingState(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2E3 RID: 189155 RVA: 0x00ADB593 File Offset: 0x00AD9793
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new LightingState(Pointer, false, true);
		}

		// Token: 0x0602E2E4 RID: 189156 RVA: 0x00ADB59D File Offset: 0x00AD979D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new LightingState(Pointer, MemoryOwner);
		}

		// Token: 0x0401A210 RID: 107024
		[Nullable(1)]
		public const string __ObjectPath = "/ImpostorBaker/ImpostorBaker/BP/Structs/LightingState.LightingState";

		// Token: 0x0401A211 RID: 107025
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A212 RID: 107026
		internal static int __PropertyOffset_0;

		// Token: 0x0401A213 RID: 107027
		internal static int __PropertyOffset_1;
	}
}
