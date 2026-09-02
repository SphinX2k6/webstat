using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA042
{
	// Token: 0x0200414A RID: 16714
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA042/BP_NA042.BP_NA042_C")]
	[UnrealStructLayout(2272, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2264)]
	public class BP_NA042_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C63C RID: 181820 RVA: 0x00A9FB48 File Offset: 0x00A9DD48
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA042_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA042/BP_NA042.BP_NA042_C");
			}
			return BP_NA042_C._ClassPtr;
		}

		// Token: 0x0602C63D RID: 181821 RVA: 0x00A9FB6C File Offset: 0x00A9DD6C
		public BP_NA042_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA042_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C63E RID: 181822 RVA: 0x00A9FB94 File Offset: 0x00A9DD94
		public BP_NA042_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA042_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700776A RID: 30570
		// (get) Token: 0x0602C63F RID: 181823 RVA: 0x00A9FBC8 File Offset: 0x00A9DDC8
		// (set) Token: 0x0602C640 RID: 181824 RVA: 0x00A9FC01 File Offset: 0x00A9DE01
		public TArray<string> SocketNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._SocketNames) == null)
				{
					result = (this._SocketNames = new TArray<string>(base.NativePtr + (IntPtr)BP_NA042_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SocketNames.CopyAssign(value);
			}
		}

		// Token: 0x1700776B RID: 30571
		// (get) Token: 0x0602C641 RID: 181825 RVA: 0x00A9FC10 File Offset: 0x00A9DE10
		// (set) Token: 0x0602C642 RID: 181826 RVA: 0x00A9FC49 File Offset: 0x00A9DE49
		public TArray<FVector> Size
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Size) == null)
				{
					result = (this._Size = new TArray<FVector>(base.NativePtr + (IntPtr)BP_NA042_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.Size.CopyAssign(value);
			}
		}

		// Token: 0x0602C643 RID: 181827 RVA: 0x00A9FC57 File Offset: 0x00A9DE57
		protected BP_NA042_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A48 RID: 100936
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA042/BP_NA042.BP_NA042_C";

		// Token: 0x04018A49 RID: 100937
		private static IntPtr _ClassPtr;

		// Token: 0x04018A4A RID: 100938
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018A4B RID: 100939
		internal new static int __PropertyOffset_0;

		// Token: 0x04018A4C RID: 100940
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _SocketNames;

		// Token: 0x04018A4D RID: 100941
		internal static int __PropertyOffset_1;

		// Token: 0x04018A4E RID: 100942
		[Nullable(2)]
		private TArray<FVector> _Size;
	}
}
