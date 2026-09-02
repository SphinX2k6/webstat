using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.Config
{
	// Token: 0x020040DF RID: 16607
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCCombinationConfig.GPUNPCCombinationConfig")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class GPUNPCCombinationConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BBFF RID: 179199 RVA: 0x00A883F9 File Offset: 0x00A865F9
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GPUNPCCombinationConfig._ScriptStructPtr != 0) ? GPUNPCCombinationConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCCombinationConfig.GPUNPCCombinationConfig", ref GPUNPCCombinationConfig._ScriptStructPtr);
		}

		// Token: 0x170073FC RID: 29692
		// (get) Token: 0x0602BC00 RID: 179200 RVA: 0x00A8841D File Offset: 0x00A8661D
		// (set) Token: 0x0602BC01 RID: 179201 RVA: 0x00A88431 File Offset: 0x00A86631
		public unsafe USkeletalMesh MergedSkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCCombinationConfig.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCCombinationConfig.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170073FD RID: 29693
		// (get) Token: 0x0602BC02 RID: 179202 RVA: 0x00A88446 File Offset: 0x00A86646
		// (set) Token: 0x0602BC03 RID: 179203 RVA: 0x00A88456 File Offset: 0x00A86656
		public unsafe int AnimTextureIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCCombinationConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCCombinationConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170073FE RID: 29694
		// (get) Token: 0x0602BC04 RID: 179204 RVA: 0x00A88467 File Offset: 0x00A86667
		// (set) Token: 0x0602BC05 RID: 179205 RVA: 0x00A8847B File Offset: 0x00A8667B
		public unsafe UBakedBoneTexture2D Combined_BakedBone_Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBakedBoneTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCCombinationConfig.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCCombinationConfig.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602BC06 RID: 179206 RVA: 0x00A88490 File Offset: 0x00A86690
		public GPUNPCCombinationConfig()
		{
		}

		// Token: 0x0602BC07 RID: 179207 RVA: 0x00A88498 File Offset: 0x00A86698
		[NullableContext(1)]
		public GPUNPCCombinationConfig(USkeletalMesh MergedSkeletalMesh, int AnimTextureIndex, UBakedBoneTexture2D Combined_BakedBone_Texture)
		{
			this.MergedSkeletalMesh = MergedSkeletalMesh;
			this.AnimTextureIndex = AnimTextureIndex;
			this.Combined_BakedBone_Texture = Combined_BakedBone_Texture;
		}

		// Token: 0x0602BC08 RID: 179208 RVA: 0x00A884B5 File Offset: 0x00A866B5
		protected override IntPtr GetUStructPtr()
		{
			return GPUNPCCombinationConfig.StaticStruct();
		}

		// Token: 0x0602BC09 RID: 179209 RVA: 0x00A884C1 File Offset: 0x00A866C1
		public GPUNPCCombinationConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BC0A RID: 179210 RVA: 0x00A884CB File Offset: 0x00A866CB
		public GPUNPCCombinationConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BC0B RID: 179211 RVA: 0x00A884D6 File Offset: 0x00A866D6
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GPUNPCCombinationConfig(Pointer, false, true);
		}

		// Token: 0x0602BC0C RID: 179212 RVA: 0x00A884E0 File Offset: 0x00A866E0
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GPUNPCCombinationConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040181B2 RID: 98738
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCCombinationConfig.GPUNPCCombinationConfig";

		// Token: 0x040181B3 RID: 98739
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181B4 RID: 98740
		internal static int __PropertyOffset_0;

		// Token: 0x040181B5 RID: 98741
		internal static int __PropertyOffset_1;

		// Token: 0x040181B6 RID: 98742
		internal static int __PropertyOffset_2;
	}
}
