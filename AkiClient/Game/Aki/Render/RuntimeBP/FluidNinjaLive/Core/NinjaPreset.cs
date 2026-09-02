using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D05 RID: 15621
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaPreset.NinjaPreset")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class NinjaPreset : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025B8B RID: 154507 RVA: 0x009C2FF4 File Offset: 0x009C11F4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NinjaPreset._ScriptStructPtr != 0) ? NinjaPreset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaPreset.NinjaPreset", ref NinjaPreset._ScriptStructPtr);
		}

		// Token: 0x17005377 RID: 21367
		// (get) Token: 0x06025B8C RID: 154508 RVA: 0x009C3018 File Offset: 0x009C1218
		// (set) Token: 0x06025B8D RID: 154509 RVA: 0x009C302C File Offset: 0x009C122C
		public unsafe string SourceString
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaPreset.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaPreset.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x06025B8E RID: 154510 RVA: 0x009C3041 File Offset: 0x009C1241
		public NinjaPreset()
		{
		}

		// Token: 0x06025B8F RID: 154511 RVA: 0x009C3049 File Offset: 0x009C1249
		public NinjaPreset(string SourceString)
		{
			this.SourceString = SourceString;
		}

		// Token: 0x06025B90 RID: 154512 RVA: 0x009C3058 File Offset: 0x009C1258
		protected override IntPtr GetUStructPtr()
		{
			return NinjaPreset.StaticStruct();
		}

		// Token: 0x06025B91 RID: 154513 RVA: 0x009C3064 File Offset: 0x009C1264
		[NullableContext(2)]
		public NinjaPreset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025B92 RID: 154514 RVA: 0x009C306E File Offset: 0x009C126E
		public NinjaPreset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025B93 RID: 154515 RVA: 0x009C3079 File Offset: 0x009C1279
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NinjaPreset(Pointer, false, true);
		}

		// Token: 0x06025B94 RID: 154516 RVA: 0x009C3083 File Offset: 0x009C1283
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NinjaPreset(Pointer, MemoryOwner);
		}

		// Token: 0x040137A6 RID: 79782
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaPreset.NinjaPreset";

		// Token: 0x040137A7 RID: 79783
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040137A8 RID: 79784
		internal static int __PropertyOffset_0;
	}
}
