using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004247 RID: 16967
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBulletGE.SBulletGE")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SBulletGE : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CEAD RID: 183981 RVA: 0x00AB322D File Offset: 0x00AB142D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBulletGE._ScriptStructPtr != 0) ? SBulletGE._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBulletGE.SBulletGE", ref SBulletGE._ScriptStructPtr);
		}

		// Token: 0x170079AF RID: 31151
		// (get) Token: 0x0602CEAE RID: 183982 RVA: 0x00AB3251 File Offset: 0x00AB1451
		// (set) Token: 0x0602CEAF RID: 183983 RVA: 0x00AB3270 File Offset: 0x00AB1470
		public TSoftClassPtr<UGameplayEffect> GE的类型
		{
			get
			{
				return new TSoftClassPtr<UGameplayEffect>(base.NativePtr + (IntPtr)SBulletGE.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBulletGE.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170079B0 RID: 31152
		// (get) Token: 0x0602CEB0 RID: 183984 RVA: 0x00AB3298 File Offset: 0x00AB1498
		// (set) Token: 0x0602CEB1 RID: 183985 RVA: 0x00AB32DB File Offset: 0x00AB14DB
		public FKuroGameplayParameterContainer GE的参数
		{
			get
			{
				base.FastCheckIsValid();
				FKuroGameplayParameterContainer result;
				if ((result = this._GE的参数) == null)
				{
					result = (this._GE的参数 = new FKuroGameplayParameterContainer(base.NativePtr + (IntPtr)SBulletGE.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroGameplayParameterContainer.StaticStruct(), base.NativePtr + (IntPtr)SBulletGE.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CEB2 RID: 183986 RVA: 0x00AB32FC File Offset: 0x00AB14FC
		public SBulletGE()
		{
		}

		// Token: 0x0602CEB3 RID: 183987 RVA: 0x00AB3304 File Offset: 0x00AB1504
		public SBulletGE(TSoftClassPtr<UGameplayEffect> GE的类型, FKuroGameplayParameterContainer GE的参数)
		{
			this.GE的类型 = GE的类型;
			this.GE的参数 = GE的参数;
		}

		// Token: 0x0602CEB4 RID: 183988 RVA: 0x00AB331A File Offset: 0x00AB151A
		protected override IntPtr GetUStructPtr()
		{
			return SBulletGE.StaticStruct();
		}

		// Token: 0x0602CEB5 RID: 183989 RVA: 0x00AB3326 File Offset: 0x00AB1526
		[NullableContext(2)]
		public SBulletGE(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CEB6 RID: 183990 RVA: 0x00AB3330 File Offset: 0x00AB1530
		public SBulletGE(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CEB7 RID: 183991 RVA: 0x00AB333B File Offset: 0x00AB153B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBulletGE(Pointer, false, true);
		}

		// Token: 0x0602CEB8 RID: 183992 RVA: 0x00AB3345 File Offset: 0x00AB1545
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBulletGE(Pointer, MemoryOwner);
		}

		// Token: 0x0401932C RID: 103212
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBulletGE.SBulletGE";

		// Token: 0x0401932D RID: 103213
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401932E RID: 103214
		internal static int __PropertyOffset_0;

		// Token: 0x0401932F RID: 103215
		internal static int __PropertyOffset_1;

		// Token: 0x04019330 RID: 103216
		[Nullable(2)]
		private FKuroGameplayParameterContainer _GE的参数;
	}
}
