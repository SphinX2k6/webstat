using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.HotPatch
{
	// Token: 0x02003DBF RID: 15807
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/HotPatch/SHotPatchGamepad.SHotPatchGamepad")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SHotPatchGamepad : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026B40 RID: 158528 RVA: 0x009DF87C File Offset: 0x009DDA7C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHotPatchGamepad._ScriptStructPtr != 0) ? SHotPatchGamepad._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/HotPatch/SHotPatchGamepad.SHotPatchGamepad", ref SHotPatchGamepad._ScriptStructPtr);
		}

		// Token: 0x170058B5 RID: 22709
		// (get) Token: 0x06026B41 RID: 158529 RVA: 0x009DF8A0 File Offset: 0x009DDAA0
		// (set) Token: 0x06026B42 RID: 158530 RVA: 0x009DF8B4 File Offset: 0x009DDAB4
		public unsafe string ActionName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SHotPatchGamepad.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SHotPatchGamepad.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170058B6 RID: 22710
		// (get) Token: 0x06026B43 RID: 158531 RVA: 0x009DF8C9 File Offset: 0x009DDAC9
		// (set) Token: 0x06026B44 RID: 158532 RVA: 0x009DF8DD File Offset: 0x009DDADD
		[Nullable(2)]
		public unsafe AUITextureActor TextureActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AUITextureActor>(base.NativePtr / (IntPtr)sizeof(void*) + SHotPatchGamepad.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHotPatchGamepad.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026B45 RID: 158533 RVA: 0x009DF8F2 File Offset: 0x009DDAF2
		public SHotPatchGamepad()
		{
		}

		// Token: 0x06026B46 RID: 158534 RVA: 0x009DF8FA File Offset: 0x009DDAFA
		public SHotPatchGamepad(string ActionName, AUITextureActor TextureActor)
		{
			this.ActionName = ActionName;
			this.TextureActor = TextureActor;
		}

		// Token: 0x06026B47 RID: 158535 RVA: 0x009DF910 File Offset: 0x009DDB10
		protected override IntPtr GetUStructPtr()
		{
			return SHotPatchGamepad.StaticStruct();
		}

		// Token: 0x06026B48 RID: 158536 RVA: 0x009DF91C File Offset: 0x009DDB1C
		[NullableContext(2)]
		public SHotPatchGamepad(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026B49 RID: 158537 RVA: 0x009DF926 File Offset: 0x009DDB26
		public SHotPatchGamepad(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B4A RID: 158538 RVA: 0x009DF931 File Offset: 0x009DDB31
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHotPatchGamepad(Pointer, false, true);
		}

		// Token: 0x06026B4B RID: 158539 RVA: 0x009DF93B File Offset: 0x009DDB3B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHotPatchGamepad(Pointer, MemoryOwner);
		}

		// Token: 0x040142C4 RID: 82628
		public const string __ObjectPath = "/Game/Aki/HotPatch/SHotPatchGamepad.SHotPatchGamepad";

		// Token: 0x040142C5 RID: 82629
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040142C6 RID: 82630
		internal static int __PropertyOffset_0;

		// Token: 0x040142C7 RID: 82631
		internal static int __PropertyOffset_1;
	}
}
