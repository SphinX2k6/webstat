using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools.Data.Struct
{
	// Token: 0x02004295 RID: 17045
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseAnimPathConfig.SBaseAnimPathConfig")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SBaseAnimPathConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D44F RID: 185423 RVA: 0x00ABB84C File Offset: 0x00AB9A4C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBaseAnimPathConfig._ScriptStructPtr != 0) ? SBaseAnimPathConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseAnimPathConfig.SBaseAnimPathConfig", ref SBaseAnimPathConfig._ScriptStructPtr);
		}

		// Token: 0x17007B62 RID: 31586
		// (get) Token: 0x0602D450 RID: 185424 RVA: 0x00ABB870 File Offset: 0x00AB9A70
		// (set) Token: 0x0602D451 RID: 185425 RVA: 0x00ABB884 File Offset: 0x00AB9A84
		public unsafe string RoleABPPath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBaseAnimPathConfig.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBaseAnimPathConfig.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B63 RID: 31587
		// (get) Token: 0x0602D452 RID: 185426 RVA: 0x00ABB89C File Offset: 0x00AB9A9C
		// (set) Token: 0x0602D453 RID: 185427 RVA: 0x00ABB8DF File Offset: 0x00AB9ADF
		public TArray<string> BaseAnimPath
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._BaseAnimPath) == null)
				{
					result = (this._BaseAnimPath = new TArray<string>(base.NativePtr + (IntPtr)SBaseAnimPathConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BaseAnimPath.CopyAssign(value);
			}
		}

		// Token: 0x0602D454 RID: 185428 RVA: 0x00ABB8ED File Offset: 0x00AB9AED
		public SBaseAnimPathConfig()
		{
		}

		// Token: 0x0602D455 RID: 185429 RVA: 0x00ABB8F5 File Offset: 0x00AB9AF5
		public SBaseAnimPathConfig(string RoleABPPath, TArray<string> BaseAnimPath)
		{
			this.RoleABPPath = RoleABPPath;
			this.BaseAnimPath = BaseAnimPath;
		}

		// Token: 0x0602D456 RID: 185430 RVA: 0x00ABB90B File Offset: 0x00AB9B0B
		protected override IntPtr GetUStructPtr()
		{
			return SBaseAnimPathConfig.StaticStruct();
		}

		// Token: 0x0602D457 RID: 185431 RVA: 0x00ABB917 File Offset: 0x00AB9B17
		[NullableContext(2)]
		public SBaseAnimPathConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D458 RID: 185432 RVA: 0x00ABB921 File Offset: 0x00AB9B21
		public SBaseAnimPathConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D459 RID: 185433 RVA: 0x00ABB92C File Offset: 0x00AB9B2C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBaseAnimPathConfig(Pointer, false, true);
		}

		// Token: 0x0602D45A RID: 185434 RVA: 0x00ABB936 File Offset: 0x00AB9B36
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBaseAnimPathConfig(Pointer, MemoryOwner);
		}

		// Token: 0x0401960C RID: 103948
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseAnimPathConfig.SBaseAnimPathConfig";

		// Token: 0x0401960D RID: 103949
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401960E RID: 103950
		internal static int __PropertyOffset_0;

		// Token: 0x0401960F RID: 103951
		internal static int __PropertyOffset_1;

		// Token: 0x04019610 RID: 103952
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _BaseAnimPath;
	}
}
