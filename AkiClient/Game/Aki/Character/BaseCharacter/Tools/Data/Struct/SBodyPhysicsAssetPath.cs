using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools.Data.Struct
{
	// Token: 0x02004297 RID: 17047
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBodyPhysicsAssetPath.SBodyPhysicsAssetPath")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SBodyPhysicsAssetPath : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D46B RID: 185451 RVA: 0x00ABBB12 File Offset: 0x00AB9D12
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBodyPhysicsAssetPath._ScriptStructPtr != 0) ? SBodyPhysicsAssetPath._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBodyPhysicsAssetPath.SBodyPhysicsAssetPath", ref SBodyPhysicsAssetPath._ScriptStructPtr);
		}

		// Token: 0x17007B68 RID: 31592
		// (get) Token: 0x0602D46C RID: 185452 RVA: 0x00ABBB36 File Offset: 0x00AB9D36
		// (set) Token: 0x0602D46D RID: 185453 RVA: 0x00ABBB4A File Offset: 0x00AB9D4A
		[Nullable(2)]
		public unsafe USkeletalMesh Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + SBodyPhysicsAssetPath.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SBodyPhysicsAssetPath.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007B69 RID: 31593
		// (get) Token: 0x0602D46E RID: 185454 RVA: 0x00ABBB5F File Offset: 0x00AB9D5F
		// (set) Token: 0x0602D46F RID: 185455 RVA: 0x00ABBB73 File Offset: 0x00AB9D73
		public unsafe string Path
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBodyPhysicsAssetPath.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBodyPhysicsAssetPath.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x0602D470 RID: 185456 RVA: 0x00ABBB88 File Offset: 0x00AB9D88
		public SBodyPhysicsAssetPath()
		{
		}

		// Token: 0x0602D471 RID: 185457 RVA: 0x00ABBB90 File Offset: 0x00AB9D90
		public SBodyPhysicsAssetPath(USkeletalMesh Mesh, string Path)
		{
			this.Mesh = Mesh;
			this.Path = Path;
		}

		// Token: 0x0602D472 RID: 185458 RVA: 0x00ABBBA6 File Offset: 0x00AB9DA6
		protected override IntPtr GetUStructPtr()
		{
			return SBodyPhysicsAssetPath.StaticStruct();
		}

		// Token: 0x0602D473 RID: 185459 RVA: 0x00ABBBB2 File Offset: 0x00AB9DB2
		[NullableContext(2)]
		public SBodyPhysicsAssetPath(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D474 RID: 185460 RVA: 0x00ABBBBC File Offset: 0x00AB9DBC
		public SBodyPhysicsAssetPath(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D475 RID: 185461 RVA: 0x00ABBBC7 File Offset: 0x00AB9DC7
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBodyPhysicsAssetPath(Pointer, false, true);
		}

		// Token: 0x0602D476 RID: 185462 RVA: 0x00ABBBD1 File Offset: 0x00AB9DD1
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBodyPhysicsAssetPath(Pointer, MemoryOwner);
		}

		// Token: 0x0401961B RID: 103963
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBodyPhysicsAssetPath.SBodyPhysicsAssetPath";

		// Token: 0x0401961C RID: 103964
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401961D RID: 103965
		internal static int __PropertyOffset_0;

		// Token: 0x0401961E RID: 103966
		internal static int __PropertyOffset_1;
	}
}
