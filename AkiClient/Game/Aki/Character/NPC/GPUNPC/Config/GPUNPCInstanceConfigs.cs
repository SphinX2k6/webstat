using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.NPC.GPUNPC.Config
{
	// Token: 0x020040E1 RID: 16609
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceConfigs.GPUNPCInstanceConfigs")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class GPUNPCInstanceConfigs : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602BC1D RID: 179229 RVA: 0x00A88666 File Offset: 0x00A86866
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GPUNPCInstanceConfigs._ScriptStructPtr != 0) ? GPUNPCInstanceConfigs._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceConfigs.GPUNPCInstanceConfigs", ref GPUNPCInstanceConfigs._ScriptStructPtr);
		}

		// Token: 0x17007403 RID: 29699
		// (get) Token: 0x0602BC1E RID: 179230 RVA: 0x00A8868C File Offset: 0x00A8688C
		// (set) Token: 0x0602BC1F RID: 179231 RVA: 0x00A886CF File Offset: 0x00A868CF
		public TArray<int> RandomItemIndices
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._RandomItemIndices) == null)
				{
					result = (this._RandomItemIndices = new TArray<int>(base.NativePtr + (IntPtr)GPUNPCInstanceConfigs.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RandomItemIndices.CopyAssign(value);
			}
		}

		// Token: 0x0602BC20 RID: 179232 RVA: 0x00A886DD File Offset: 0x00A868DD
		public GPUNPCInstanceConfigs()
		{
		}

		// Token: 0x0602BC21 RID: 179233 RVA: 0x00A886E5 File Offset: 0x00A868E5
		public GPUNPCInstanceConfigs(TArray<int> RandomItemIndices)
		{
			this.RandomItemIndices = RandomItemIndices;
		}

		// Token: 0x0602BC22 RID: 179234 RVA: 0x00A886F4 File Offset: 0x00A868F4
		protected override IntPtr GetUStructPtr()
		{
			return GPUNPCInstanceConfigs.StaticStruct();
		}

		// Token: 0x0602BC23 RID: 179235 RVA: 0x00A88700 File Offset: 0x00A86900
		[NullableContext(2)]
		public GPUNPCInstanceConfigs(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602BC24 RID: 179236 RVA: 0x00A8870A File Offset: 0x00A8690A
		public GPUNPCInstanceConfigs(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602BC25 RID: 179237 RVA: 0x00A88715 File Offset: 0x00A86915
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GPUNPCInstanceConfigs(Pointer, false, true);
		}

		// Token: 0x0602BC26 RID: 179238 RVA: 0x00A8871F File Offset: 0x00A8691F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GPUNPCInstanceConfigs(Pointer, MemoryOwner);
		}

		// Token: 0x040181BF RID: 98751
		public const string __ObjectPath = "/Game/Aki/Character/NPC/GPUNPC/Config/GPUNPCInstanceConfigs.GPUNPCInstanceConfigs";

		// Token: 0x040181C0 RID: 98752
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040181C1 RID: 98753
		internal static int __PropertyOffset_0;

		// Token: 0x040181C2 RID: 98754
		[Nullable(2)]
		private TArray<int> _RandomItemIndices;
	}
}
