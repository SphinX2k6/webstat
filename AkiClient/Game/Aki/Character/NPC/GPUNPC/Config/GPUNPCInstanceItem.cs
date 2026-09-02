using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.Config
{
	// Token: 0x020040E2 RID: 16610
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceItem.GPUNPCInstanceItem")]
	[UnrealStructLayout(64, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class GPUNPCInstanceItem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BC27 RID: 179239 RVA: 0x00A88728 File Offset: 0x00A86928
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GPUNPCInstanceItem._ScriptStructPtr != 0) ? GPUNPCInstanceItem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceItem.GPUNPCInstanceItem", ref GPUNPCInstanceItem._ScriptStructPtr);
		}

		// Token: 0x17007404 RID: 29700
		// (get) Token: 0x0602BC28 RID: 179240 RVA: 0x00A8874C File Offset: 0x00A8694C
		// (set) Token: 0x0602BC29 RID: 179241 RVA: 0x00A8875C File Offset: 0x00A8695C
		public unsafe int GroupIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007405 RID: 29701
		// (get) Token: 0x0602BC2A RID: 179242 RVA: 0x00A8876D File Offset: 0x00A8696D
		// (set) Token: 0x0602BC2B RID: 179243 RVA: 0x00A8877D File Offset: 0x00A8697D
		public unsafe int AnimTextureIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007406 RID: 29702
		// (get) Token: 0x0602BC2C RID: 179244 RVA: 0x00A8878E File Offset: 0x00A8698E
		// (set) Token: 0x0602BC2D RID: 179245 RVA: 0x00A887A2 File Offset: 0x00A869A2
		public unsafe FTransform InstanceTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)GPUNPCInstanceItem.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602BC2E RID: 179246 RVA: 0x00A887B7 File Offset: 0x00A869B7
		public GPUNPCInstanceItem()
		{
		}

		// Token: 0x0602BC2F RID: 179247 RVA: 0x00A887BF File Offset: 0x00A869BF
		public GPUNPCInstanceItem(int GroupIndex, int AnimTextureIndex, FTransform InstanceTransform)
		{
			this.GroupIndex = GroupIndex;
			this.AnimTextureIndex = AnimTextureIndex;
			this.InstanceTransform = InstanceTransform;
		}

		// Token: 0x0602BC30 RID: 179248 RVA: 0x00A887DC File Offset: 0x00A869DC
		protected override IntPtr GetUStructPtr()
		{
			return GPUNPCInstanceItem.StaticStruct();
		}

		// Token: 0x0602BC31 RID: 179249 RVA: 0x00A887E8 File Offset: 0x00A869E8
		[NullableContext(2)]
		public GPUNPCInstanceItem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BC32 RID: 179250 RVA: 0x00A887F2 File Offset: 0x00A869F2
		public GPUNPCInstanceItem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BC33 RID: 179251 RVA: 0x00A887FD File Offset: 0x00A869FD
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GPUNPCInstanceItem(Pointer, false, true);
		}

		// Token: 0x0602BC34 RID: 179252 RVA: 0x00A88807 File Offset: 0x00A86A07
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GPUNPCInstanceItem(Pointer, MemoryOwner);
		}

		// Token: 0x040181C3 RID: 98755
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceItem.GPUNPCInstanceItem";

		// Token: 0x040181C4 RID: 98756
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181C5 RID: 98757
		internal static int __PropertyOffset_0;

		// Token: 0x040181C6 RID: 98758
		internal static int __PropertyOffset_1;

		// Token: 0x040181C7 RID: 98759
		internal static int __PropertyOffset_2;
	}
}
