using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Scene3DUI.Struct
{
	// Token: 0x02003E07 RID: 15879
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Scene3DUI/Struct/SSceneDecorationConfig.SSceneDecorationConfig")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SSceneDecorationConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060271EF RID: 160239 RVA: 0x009EA4AF File Offset: 0x009E86AF
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneDecorationConfig._ScriptStructPtr != 0) ? SSceneDecorationConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Scene3DUI/Struct/SSceneDecorationConfig.SSceneDecorationConfig", ref SSceneDecorationConfig._ScriptStructPtr);
		}

		// Token: 0x17005B33 RID: 23347
		// (get) Token: 0x060271F0 RID: 160240 RVA: 0x009EA4D3 File Offset: 0x009E86D3
		// (set) Token: 0x060271F1 RID: 160241 RVA: 0x009EA4E7 File Offset: 0x009E86E7
		public unsafe string ResourcePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005B34 RID: 23348
		// (get) Token: 0x060271F2 RID: 160242 RVA: 0x009EA4FC File Offset: 0x009E86FC
		// (set) Token: 0x060271F3 RID: 160243 RVA: 0x009EA510 File Offset: 0x009E8710
		public unsafe string SceneClassTag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005B35 RID: 23349
		// (get) Token: 0x060271F4 RID: 160244 RVA: 0x009EA525 File Offset: 0x009E8725
		// (set) Token: 0x060271F5 RID: 160245 RVA: 0x009EA539 File Offset: 0x009E8739
		public unsafe string ViewClassTag
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSceneDecorationConfig.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x060271F6 RID: 160246 RVA: 0x009EA54E File Offset: 0x009E874E
		public SSceneDecorationConfig()
		{
		}

		// Token: 0x060271F7 RID: 160247 RVA: 0x009EA556 File Offset: 0x009E8756
		public SSceneDecorationConfig(string ResourcePath, string SceneClassTag, string ViewClassTag)
		{
			this.ResourcePath = ResourcePath;
			this.SceneClassTag = SceneClassTag;
			this.ViewClassTag = ViewClassTag;
		}

		// Token: 0x060271F8 RID: 160248 RVA: 0x009EA573 File Offset: 0x009E8773
		protected override IntPtr GetUStructPtr()
		{
			return SSceneDecorationConfig.StaticStruct();
		}

		// Token: 0x060271F9 RID: 160249 RVA: 0x009EA57F File Offset: 0x009E877F
		[NullableContext(2)]
		public SSceneDecorationConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060271FA RID: 160250 RVA: 0x009EA589 File Offset: 0x009E8789
		public SSceneDecorationConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060271FB RID: 160251 RVA: 0x009EA594 File Offset: 0x009E8794
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneDecorationConfig(Pointer, false, true);
		}

		// Token: 0x060271FC RID: 160252 RVA: 0x009EA59E File Offset: 0x009E879E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneDecorationConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014714 RID: 83732
		public const string __ObjectPath = "/Game/Aki/Data/Scene3DUI/Struct/SSceneDecorationConfig.SSceneDecorationConfig";

		// Token: 0x04014715 RID: 83733
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014716 RID: 83734
		internal static int __PropertyOffset_0;

		// Token: 0x04014717 RID: 83735
		internal static int __PropertyOffset_1;

		// Token: 0x04014718 RID: 83736
		internal static int __PropertyOffset_2;
	}
}
