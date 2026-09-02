using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.Assets.PCG.BP_Tools.FoliageLUT
{
	// Token: 0x020039F2 RID: 14834
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Scene/Assets/PCG/BP_Tools/FoliageLUT/S_FoliageLutData.S_FoliageLutData")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class S_FoliageLutData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601E221 RID: 123425 RVA: 0x008ECF63 File Offset: 0x008EB163
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_FoliageLutData._ScriptStructPtr != 0) ? S_FoliageLutData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Scene/Assets/PCG/BP_Tools/FoliageLUT/S_FoliageLutData.S_FoliageLutData", ref S_FoliageLutData._ScriptStructPtr);
		}

		// Token: 0x170028A1 RID: 10401
		// (get) Token: 0x0601E222 RID: 123426 RVA: 0x008ECF87 File Offset: 0x008EB187
		// (set) Token: 0x0601E223 RID: 123427 RVA: 0x008ECF97 File Offset: 0x008EB197
		public unsafe int FoliageLutIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_FoliageLutData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_FoliageLutData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170028A2 RID: 10402
		// (get) Token: 0x0601E224 RID: 123428 RVA: 0x008ECFA8 File Offset: 0x008EB1A8
		// (set) Token: 0x0601E225 RID: 123429 RVA: 0x008ECFBC File Offset: 0x008EB1BC
		public unsafe UObject MainWidget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UObject>(base.NativePtr / (IntPtr)sizeof(void*) + S_FoliageLutData.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_FoliageLutData.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170028A3 RID: 10403
		// (get) Token: 0x0601E226 RID: 123430 RVA: 0x008ECFD1 File Offset: 0x008EB1D1
		// (set) Token: 0x0601E227 RID: 123431 RVA: 0x008ECFE5 File Offset: 0x008EB1E5
		public unsafe UTexture2DArray LutArray
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2DArray>(base.NativePtr / (IntPtr)sizeof(void*) + S_FoliageLutData.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_FoliageLutData.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0601E228 RID: 123432 RVA: 0x008ECFFA File Offset: 0x008EB1FA
		public S_FoliageLutData()
		{
		}

		// Token: 0x0601E229 RID: 123433 RVA: 0x008ED002 File Offset: 0x008EB202
		[NullableContext(1)]
		public S_FoliageLutData(int FoliageLutIndex, UObject MainWidget, UTexture2DArray LutArray)
		{
			this.FoliageLutIndex = FoliageLutIndex;
			this.MainWidget = MainWidget;
			this.LutArray = LutArray;
		}

		// Token: 0x0601E22A RID: 123434 RVA: 0x008ED01F File Offset: 0x008EB21F
		protected override IntPtr GetUStructPtr()
		{
			return S_FoliageLutData.StaticStruct();
		}

		// Token: 0x0601E22B RID: 123435 RVA: 0x008ED02B File Offset: 0x008EB22B
		public S_FoliageLutData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601E22C RID: 123436 RVA: 0x008ED035 File Offset: 0x008EB235
		public S_FoliageLutData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601E22D RID: 123437 RVA: 0x008ED040 File Offset: 0x008EB240
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_FoliageLutData(Pointer, false, true);
		}

		// Token: 0x0601E22E RID: 123438 RVA: 0x008ED04A File Offset: 0x008EB24A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_FoliageLutData(Pointer, MemoryOwner);
		}

		// Token: 0x0400ECBE RID: 60606
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Scene/Assets/PCG/BP_Tools/FoliageLUT/S_FoliageLutData.S_FoliageLutData";

		// Token: 0x0400ECBF RID: 60607
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400ECC0 RID: 60608
		internal static int __PropertyOffset_0;

		// Token: 0x0400ECC1 RID: 60609
		internal static int __PropertyOffset_1;

		// Token: 0x0400ECC2 RID: 60610
		internal static int __PropertyOffset_2;
	}
}
