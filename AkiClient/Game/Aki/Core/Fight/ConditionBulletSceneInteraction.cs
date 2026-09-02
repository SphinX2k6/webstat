using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F51 RID: 16209
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/ConditionBulletSceneInteraction.ConditionBulletSceneInteraction")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class ConditionBulletSceneInteraction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602885F RID: 165983 RVA: 0x00A0DE7B File Offset: 0x00A0C07B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (ConditionBulletSceneInteraction._ScriptStructPtr != 0) ? ConditionBulletSceneInteraction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/ConditionBulletSceneInteraction.ConditionBulletSceneInteraction", ref ConditionBulletSceneInteraction._ScriptStructPtr);
		}

		// Token: 0x170062B0 RID: 25264
		// (get) Token: 0x06028860 RID: 165984 RVA: 0x00A0DE9F File Offset: 0x00A0C09F
		// (set) Token: 0x06028861 RID: 165985 RVA: 0x00A0DEAF File Offset: 0x00A0C0AF
		public unsafe float RangeMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ConditionBulletSceneInteraction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ConditionBulletSceneInteraction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062B1 RID: 25265
		// (get) Token: 0x06028862 RID: 165986 RVA: 0x00A0DEC0 File Offset: 0x00A0C0C0
		// (set) Token: 0x06028863 RID: 165987 RVA: 0x00A0DEDF File Offset: 0x00A0C0DF
		public TSoftObjectPtr<BulletSceneInteraction_C> Config
		{
			get
			{
				return new TSoftObjectPtr<BulletSceneInteraction_C>(base.NativePtr + (IntPtr)ConditionBulletSceneInteraction.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)ConditionBulletSceneInteraction.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06028864 RID: 165988 RVA: 0x00A0DF04 File Offset: 0x00A0C104
		public ConditionBulletSceneInteraction()
		{
		}

		// Token: 0x06028865 RID: 165989 RVA: 0x00A0DF0C File Offset: 0x00A0C10C
		public ConditionBulletSceneInteraction(float RangeMin, TSoftObjectPtr<BulletSceneInteraction_C> Config)
		{
			this.RangeMin = RangeMin;
			this.Config = Config;
		}

		// Token: 0x06028866 RID: 165990 RVA: 0x00A0DF22 File Offset: 0x00A0C122
		protected override IntPtr GetUStructPtr()
		{
			return ConditionBulletSceneInteraction.StaticStruct();
		}

		// Token: 0x06028867 RID: 165991 RVA: 0x00A0DF2E File Offset: 0x00A0C12E
		[NullableContext(2)]
		public ConditionBulletSceneInteraction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028868 RID: 165992 RVA: 0x00A0DF38 File Offset: 0x00A0C138
		public ConditionBulletSceneInteraction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028869 RID: 165993 RVA: 0x00A0DF43 File Offset: 0x00A0C143
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new ConditionBulletSceneInteraction(Pointer, false, true);
		}

		// Token: 0x0602886A RID: 165994 RVA: 0x00A0DF4D File Offset: 0x00A0C14D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new ConditionBulletSceneInteraction(Pointer, MemoryOwner);
		}

		// Token: 0x0401553B RID: 87355
		public const string __ObjectPath = "/Game/Aki/Core/Fight/ConditionBulletSceneInteraction.ConditionBulletSceneInteraction";

		// Token: 0x0401553C RID: 87356
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401553D RID: 87357
		internal static int __PropertyOffset_0;

		// Token: 0x0401553E RID: 87358
		internal static int __PropertyOffset_1;
	}
}
