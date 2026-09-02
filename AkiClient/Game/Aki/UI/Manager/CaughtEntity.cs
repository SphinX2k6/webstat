using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.UI.Manager
{
	// Token: 0x02003991 RID: 14737
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.MulticastDelegate)]
	public sealed class CaughtEntity : FMulticastScriptDelegate, IUnrealDelegateProxy, IUnrealObject
	{
		// Token: 0x0601DBD1 RID: 121809 RVA: 0x008DF497 File Offset: 0x008DD697
		public static UFunctionStackOnlyPtr StaticFunction()
		{
			return CaughtEntity.StaticFunctionPtr();
		}

		// Token: 0x0601DBD2 RID: 121810 RVA: 0x008DF4A3 File Offset: 0x008DD6A3
		private static IntPtr StaticFunctionPtr()
		{
			if (BP_EventManager_C.__CaughtEntity__DelegateSignature_NativeFunctionPtr == IntPtr.Zero)
			{
				BP_EventManager_C.__CaughtEntity__DelegateSignature_NativeFunctionPtr = UObjectGlobals.StaticLoadDelegateFunctionChecked(null, "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:CaughtEntity__DelegateSignature");
			}
			return BP_EventManager_C.__CaughtEntity__DelegateSignature_NativeFunctionPtr;
		}

		// Token: 0x0601DBD3 RID: 121811 RVA: 0x008DF4C6 File Offset: 0x008DD6C6
		public CaughtEntity()
		{
		}

		// Token: 0x0601DBD4 RID: 121812 RVA: 0x008DF4CE File Offset: 0x008DD6CE
		[NullableContext(2)]
		public CaughtEntity(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DBD5 RID: 121813 RVA: 0x008DF4D8 File Offset: 0x008DD6D8
		public CaughtEntity(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DBD6 RID: 121814 RVA: 0x008DF4E3 File Offset: 0x008DD6E3
		[NullableContext(1)]
		public override void DynamicBind(Delegate Callback)
		{
			this.Add((Callback as Action<int, int, string, TEnumAsByte<ECaughtResultType>>) ?? ((Action<int, int, string, TEnumAsByte<ECaughtResultType>>)Delegate.CreateDelegate(typeof(Action<int, int, string, TEnumAsByte<ECaughtResultType>>), Callback.Target, Callback.Method)));
		}

		// Token: 0x0601DBD7 RID: 121815 RVA: 0x008DF515 File Offset: 0x008DD715
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Add([Nullable(new byte[]
		{
			1,
			1,
			0
		})] Action<int, int, string, TEnumAsByte<ECaughtResultType>> Callback)
		{
			base.Add(Callback, ldftn(OnScriptCallback));
		}

		// Token: 0x0601DBD8 RID: 121816 RVA: 0x008DF524 File Offset: 0x008DD724
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Remove([Nullable(new byte[]
		{
			1,
			1,
			0
		})] Action<int, int, string, TEnumAsByte<ECaughtResultType>> Callback)
		{
			base.Remove(Callback);
		}

		// Token: 0x0601DBD9 RID: 121817 RVA: 0x008DF530 File Offset: 0x008DD730
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void Broadcast(int RoleEntityID, int CaughtEntityID, string CaughtID, ECaughtResultType Result)
		{
			CaughtEntity.__CaughtEntity_DelegateParams* ptr = stackalloc CaughtEntity.__CaughtEntity_DelegateParams[(UIntPtr)47] + 15L / (long)sizeof(CaughtEntity.__CaughtEntity_DelegateParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(CaughtEntity.StaticFunctionPtr(), (void*)ptr, 1);
			ptr->RoleEntityID = RoleEntityID;
			ptr->CaughtEntityID = CaughtEntityID;
			FString.CopyFrom((void*)(&ptr->CaughtID), CaughtID);
			ptr->Result = Result;
			base.BroadcastInternal((void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_EventManager_C.__CaughtEntity__DelegateSignature_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601DBDA RID: 121818 RVA: 0x008DF5A0 File Offset: 0x008DD7A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveOptimization)]
		protected unsafe static void OnScriptCallback(IntPtr __Handle, byte* __Parameters)
		{
			object target = GCHandle.FromIntPtr(__Handle).Target;
			Action<int, int, string, TEnumAsByte<ECaughtResultType>> action = target as Action<int, int, string, TEnumAsByte<ECaughtResultType>>;
			if (action == null)
			{
				throw new ArgumentException((target != null) ? target.GetType().ToString() : null);
			}
			string arg = FString.ToString((void*)(&((CaughtEntity.__CaughtEntity_DelegateParams*)__Parameters)->CaughtID));
			action(((CaughtEntity.__CaughtEntity_DelegateParams*)__Parameters)->RoleEntityID, ((CaughtEntity.__CaughtEntity_DelegateParams*)__Parameters)->CaughtEntityID, arg, ((CaughtEntity.__CaughtEntity_DelegateParams*)__Parameters)->Result);
		}

		// Token: 0x0400E95F RID: 59743
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/UI/Manager/BP_EventManager.BP_EventManager_C:CaughtEntity__DelegateSignature";

		// Token: 0x020096C2 RID: 38594
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __CaughtEntity_DelegateParams
		{
			// Token: 0x04031B9B RID: 203675
			[FieldOffset(0)]
			public int RoleEntityID;

			// Token: 0x04031B9C RID: 203676
			[FieldOffset(4)]
			public int CaughtEntityID;

			// Token: 0x04031B9D RID: 203677
			[FieldOffset(8)]
			public FString CaughtID;

			// Token: 0x04031B9E RID: 203678
			[FieldOffset(24)]
			public TEnumAsByte<ECaughtResultType> Result;
		}
	}
}
