using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Scene3DUI.Struct
{
	// Token: 0x02003E08 RID: 15880
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Scene3DUI/Struct/SSceneUITagConfig.SSceneUITagConfig")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SSceneUITagConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060271FD RID: 160253 RVA: 0x009EA5A7 File Offset: 0x009E87A7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneUITagConfig._ScriptStructPtr != 0) ? SSceneUITagConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Scene3DUI/Struct/SSceneUITagConfig.SSceneUITagConfig", ref SSceneUITagConfig._ScriptStructPtr);
		}

		// Token: 0x17005B36 RID: 23350
		// (get) Token: 0x060271FE RID: 160254 RVA: 0x009EA5CB File Offset: 0x009E87CB
		// (set) Token: 0x060271FF RID: 160255 RVA: 0x009EA5DF File Offset: 0x009E87DF
		public unsafe string DecorativeID
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSceneUITagConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSceneUITagConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x06027200 RID: 160256 RVA: 0x009EA5F4 File Offset: 0x009E87F4
		public SSceneUITagConfig()
		{
		}

		// Token: 0x06027201 RID: 160257 RVA: 0x009EA5FC File Offset: 0x009E87FC
		public SSceneUITagConfig(string DecorativeID)
		{
			this.DecorativeID = DecorativeID;
		}

		// Token: 0x06027202 RID: 160258 RVA: 0x009EA60B File Offset: 0x009E880B
		protected override IntPtr GetUStructPtr()
		{
			return SSceneUITagConfig.StaticStruct();
		}

		// Token: 0x06027203 RID: 160259 RVA: 0x009EA617 File Offset: 0x009E8817
		[NullableContext(2)]
		public SSceneUITagConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027204 RID: 160260 RVA: 0x009EA621 File Offset: 0x009E8821
		public SSceneUITagConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027205 RID: 160261 RVA: 0x009EA62C File Offset: 0x009E882C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneUITagConfig(Pointer, false, true);
		}

		// Token: 0x06027206 RID: 160262 RVA: 0x009EA636 File Offset: 0x009E8836
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneUITagConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014719 RID: 83737
		public const string __ObjectPath = "/Game/Aki/Data/Scene3DUI/Struct/SSceneUITagConfig.SSceneUITagConfig";

		// Token: 0x0401471A RID: 83738
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401471B RID: 83739
		internal static int __PropertyOffset_0;
	}
}
