using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA043
{
	// Token: 0x02004147 RID: 16711
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA043/BP_NA043.BP_NA043_C")]
	[UnrealStructLayout(2288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2280)]
	public class BP_NA043_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C628 RID: 181800 RVA: 0x00A9F8CC File Offset: 0x00A9DACC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA043_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA043/BP_NA043.BP_NA043_C");
			}
			return BP_NA043_C._ClassPtr;
		}

		// Token: 0x0602C629 RID: 181801 RVA: 0x00A9F8F0 File Offset: 0x00A9DAF0
		public BP_NA043_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA043_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C62A RID: 181802 RVA: 0x00A9F918 File Offset: 0x00A9DB18
		public BP_NA043_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA043_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007766 RID: 30566
		// (get) Token: 0x0602C62B RID: 181803 RVA: 0x00A9F94B File Offset: 0x00A9DB4B
		// (set) Token: 0x0602C62C RID: 181804 RVA: 0x00A9F95F File Offset: 0x00A9DB5F
		[Nullable(2)]
		public unsafe UCapsuleComponent Bip001Spine1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA043_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA043_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17007767 RID: 30567
		// (get) Token: 0x0602C62D RID: 181805 RVA: 0x00A9F974 File Offset: 0x00A9DB74
		// (set) Token: 0x0602C62E RID: 181806 RVA: 0x00A9F988 File Offset: 0x00A9DB88
		[Nullable(2)]
		public unsafe UCapsuleComponent Bip001Head
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA043_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA043_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007768 RID: 30568
		// (get) Token: 0x0602C62F RID: 181807 RVA: 0x00A9F9A0 File Offset: 0x00A9DBA0
		// (set) Token: 0x0602C630 RID: 181808 RVA: 0x00A9F9D9 File Offset: 0x00A9DBD9
		public TArray<string> SocketNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._SocketNames) == null)
				{
					result = (this._SocketNames = new TArray<string>(base.NativePtr + (IntPtr)BP_NA043_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.SocketNames.CopyAssign(value);
			}
		}

		// Token: 0x17007769 RID: 30569
		// (get) Token: 0x0602C631 RID: 181809 RVA: 0x00A9F9E8 File Offset: 0x00A9DBE8
		// (set) Token: 0x0602C632 RID: 181810 RVA: 0x00A9FA21 File Offset: 0x00A9DC21
		public TArray<FVector> Size
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._Size) == null)
				{
					result = (this._Size = new TArray<FVector>(base.NativePtr + (IntPtr)BP_NA043_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.Size.CopyAssign(value);
			}
		}

		// Token: 0x0602C633 RID: 181811 RVA: 0x00A9FA2F File Offset: 0x00A9DC2F
		protected BP_NA043_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A39 RID: 100921
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA043/BP_NA043.BP_NA043_C";

		// Token: 0x04018A3A RID: 100922
		private static IntPtr _ClassPtr;

		// Token: 0x04018A3B RID: 100923
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018A3C RID: 100924
		internal new static int __PropertyOffset_0;

		// Token: 0x04018A3D RID: 100925
		internal static int __PropertyOffset_1;

		// Token: 0x04018A3E RID: 100926
		internal static int __PropertyOffset_2;

		// Token: 0x04018A3F RID: 100927
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _SocketNames;

		// Token: 0x04018A40 RID: 100928
		internal static int __PropertyOffset_3;

		// Token: 0x04018A41 RID: 100929
		[Nullable(2)]
		private TArray<FVector> _Size;
	}
}
