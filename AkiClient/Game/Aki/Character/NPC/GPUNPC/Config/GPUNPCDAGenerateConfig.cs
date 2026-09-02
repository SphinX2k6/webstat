using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Npc;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.Config
{
	// Token: 0x020040E0 RID: 16608
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCDAGenerateConfig.GPUNPCDAGenerateConfig")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class GPUNPCDAGenerateConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BC0D RID: 179213 RVA: 0x00A884E9 File Offset: 0x00A866E9
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GPUNPCDAGenerateConfig._ScriptStructPtr != 0) ? GPUNPCDAGenerateConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCDAGenerateConfig.GPUNPCDAGenerateConfig", ref GPUNPCDAGenerateConfig._ScriptStructPtr);
		}

		// Token: 0x170073FF RID: 29695
		// (get) Token: 0x0602BC0E RID: 179214 RVA: 0x00A8850D File Offset: 0x00A8670D
		// (set) Token: 0x0602BC0F RID: 179215 RVA: 0x00A88521 File Offset: 0x00A86721
		[Nullable(2)]
		public unsafe USkeletalMesh 单个网格体_这个设置了NpcSetupData就无效_
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCDAGenerateConfig.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCDAGenerateConfig.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007400 RID: 29696
		// (get) Token: 0x0602BC10 RID: 179216 RVA: 0x00A88536 File Offset: 0x00A86736
		// (set) Token: 0x0602BC11 RID: 179217 RVA: 0x00A8854A File Offset: 0x00A8674A
		[Nullable(2)]
		public unsafe PD_NpcSetupData_C NpcSetupData配置
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_NpcSetupData_C>(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCDAGenerateConfig.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + GPUNPCDAGenerateConfig.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007401 RID: 29697
		// (get) Token: 0x0602BC12 RID: 179218 RVA: 0x00A88560 File Offset: 0x00A86760
		// (set) Token: 0x0602BC13 RID: 179219 RVA: 0x00A885A3 File Offset: 0x00A867A3
		public TArray<UBakedBoneTexture2D> 动画烘焙贴图
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UBakedBoneTexture2D> result;
				if ((result = this._动画烘焙贴图) == null)
				{
					result = (this._动画烘焙贴图 = new TArray<UBakedBoneTexture2D>(base.NativePtr + (IntPtr)GPUNPCDAGenerateConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.动画烘焙贴图.CopyAssign(value);
			}
		}

		// Token: 0x17007402 RID: 29698
		// (get) Token: 0x0602BC14 RID: 179220 RVA: 0x00A885B4 File Offset: 0x00A867B4
		// (set) Token: 0x0602BC15 RID: 179221 RVA: 0x00A885F7 File Offset: 0x00A867F7
		public TArray<UTexture2D> 动画起始时间噪声贴图
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UTexture2D> result;
				if ((result = this._动画起始时间噪声贴图) == null)
				{
					result = (this._动画起始时间噪声贴图 = new TArray<UTexture2D>(base.NativePtr + (IntPtr)GPUNPCDAGenerateConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.动画起始时间噪声贴图.CopyAssign(value);
			}
		}

		// Token: 0x0602BC16 RID: 179222 RVA: 0x00A88605 File Offset: 0x00A86805
		public GPUNPCDAGenerateConfig()
		{
		}

		// Token: 0x0602BC17 RID: 179223 RVA: 0x00A8860D File Offset: 0x00A8680D
		public GPUNPCDAGenerateConfig(USkeletalMesh 单个网格体_这个设置了NpcSetupData就无效_, PD_NpcSetupData_C NpcSetupData配置, TArray<UBakedBoneTexture2D> 动画烘焙贴图, TArray<UTexture2D> 动画起始时间噪声贴图)
		{
			this.单个网格体_这个设置了NpcSetupData就无效_ = 单个网格体_这个设置了NpcSetupData就无效_;
			this.NpcSetupData配置 = NpcSetupData配置;
			this.动画烘焙贴图 = 动画烘焙贴图;
			this.动画起始时间噪声贴图 = 动画起始时间噪声贴图;
		}

		// Token: 0x0602BC18 RID: 179224 RVA: 0x00A88632 File Offset: 0x00A86832
		protected override IntPtr GetUStructPtr()
		{
			return GPUNPCDAGenerateConfig.StaticStruct();
		}

		// Token: 0x0602BC19 RID: 179225 RVA: 0x00A8863E File Offset: 0x00A8683E
		[NullableContext(2)]
		public GPUNPCDAGenerateConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BC1A RID: 179226 RVA: 0x00A88648 File Offset: 0x00A86848
		public GPUNPCDAGenerateConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BC1B RID: 179227 RVA: 0x00A88653 File Offset: 0x00A86853
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GPUNPCDAGenerateConfig(Pointer, false, true);
		}

		// Token: 0x0602BC1C RID: 179228 RVA: 0x00A8865D File Offset: 0x00A8685D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GPUNPCDAGenerateConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040181B7 RID: 98743
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCDAGenerateConfig.GPUNPCDAGenerateConfig";

		// Token: 0x040181B8 RID: 98744
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181B9 RID: 98745
		internal static int __PropertyOffset_0;

		// Token: 0x040181BA RID: 98746
		internal static int __PropertyOffset_1;

		// Token: 0x040181BB RID: 98747
		internal static int __PropertyOffset_2;

		// Token: 0x040181BC RID: 98748
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UBakedBoneTexture2D> _动画烘焙贴图;

		// Token: 0x040181BD RID: 98749
		internal static int __PropertyOffset_3;

		// Token: 0x040181BE RID: 98750
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTexture2D> _动画起始时间噪声贴图;
	}
}
