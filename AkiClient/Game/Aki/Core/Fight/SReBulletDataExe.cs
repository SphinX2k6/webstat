using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F71 RID: 16241
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataExe.SReBulletDataExe")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 216)]
	public class SReBulletDataExe : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602892C RID: 166188 RVA: 0x00A0F354 File Offset: 0x00A0D554
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataExe._ScriptStructPtr != 0) ? SReBulletDataExe._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataExe.SReBulletDataExe", ref SReBulletDataExe._ScriptStructPtr);
		}

		// Token: 0x170062F2 RID: 25330
		// (get) Token: 0x0602892D RID: 166189 RVA: 0x00A0F378 File Offset: 0x00A0D578
		// (set) Token: 0x0602892E RID: 166190 RVA: 0x00A0F38C File Offset: 0x00A0D58C
		public unsafe FGameplayTag 生成时对攻击者发射GameplayEvent标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170062F3 RID: 25331
		// (get) Token: 0x0602892F RID: 166191 RVA: 0x00A0F3A1 File Offset: 0x00A0D5A1
		// (set) Token: 0x06028930 RID: 166192 RVA: 0x00A0F3B5 File Offset: 0x00A0D5B5
		public unsafe FGameplayTag 命中后对攻击者发射GameplayEvent标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170062F4 RID: 25332
		// (get) Token: 0x06028931 RID: 166193 RVA: 0x00A0F3CA File Offset: 0x00A0D5CA
		// (set) Token: 0x06028932 RID: 166194 RVA: 0x00A0F3DE File Offset: 0x00A0D5DE
		public unsafe FGameplayTag 命中后对受击者发射GameplayEvent标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170062F5 RID: 25333
		// (get) Token: 0x06028933 RID: 166195 RVA: 0x00A0F3F3 File Offset: 0x00A0D5F3
		// (set) Token: 0x06028934 RID: 166196 RVA: 0x00A0F407 File Offset: 0x00A0D607
		public unsafe FGameplayTag 结束时对攻击者发射GameplayEvent标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170062F6 RID: 25334
		// (get) Token: 0x06028935 RID: 166197 RVA: 0x00A0F41C File Offset: 0x00A0D61C
		// (set) Token: 0x06028936 RID: 166198 RVA: 0x00A0F45F File Offset: 0x00A0D65F
		public TArray<long> 命中后对攻击者应用GE的Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._命中后对攻击者应用GE的Id) == null)
				{
					result = (this._命中后对攻击者应用GE的Id = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中后对攻击者应用GE的Id.CopyAssign(value);
			}
		}

		// Token: 0x170062F7 RID: 25335
		// (get) Token: 0x06028937 RID: 166199 RVA: 0x00A0F470 File Offset: 0x00A0D670
		// (set) Token: 0x06028938 RID: 166200 RVA: 0x00A0F4B3 File Offset: 0x00A0D6B3
		public TArray<long> 命中后对受击者应用GE的Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._命中后对受击者应用GE的Id) == null)
				{
					result = (this._命中后对受击者应用GE的Id = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中后对受击者应用GE的Id.CopyAssign(value);
			}
		}

		// Token: 0x170062F8 RID: 25336
		// (get) Token: 0x06028939 RID: 166201 RVA: 0x00A0F4C4 File Offset: 0x00A0D6C4
		// (set) Token: 0x0602893A RID: 166202 RVA: 0x00A0F507 File Offset: 0x00A0D707
		public TArray<long> 能量恢复类GE数组的Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._能量恢复类GE数组的Id) == null)
				{
					result = (this._能量恢复类GE数组的Id = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.能量恢复类GE数组的Id.CopyAssign(value);
			}
		}

		// Token: 0x170062F9 RID: 25337
		// (get) Token: 0x0602893B RID: 166203 RVA: 0x00A0F518 File Offset: 0x00A0D718
		// (set) Token: 0x0602893C RID: 166204 RVA: 0x00A0F55B File Offset: 0x00A0D75B
		public TArray<long> 命中后对在场上角色应用的GE的Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._命中后对在场上角色应用的GE的Id) == null)
				{
					result = (this._命中后对在场上角色应用的GE的Id = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.命中后对在场上角色应用的GE的Id.CopyAssign(value);
			}
		}

		// Token: 0x170062FA RID: 25338
		// (get) Token: 0x0602893D RID: 166205 RVA: 0x00A0F56C File Offset: 0x00A0D76C
		// (set) Token: 0x0602893E RID: 166206 RVA: 0x00A0F5AF File Offset: 0x00A0D7AF
		public TArray<long> 受击对象进入应用的GE的Id
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._受击对象进入应用的GE的Id) == null)
				{
					result = (this._受击对象进入应用的GE的Id = new TArray<long>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.受击对象进入应用的GE的Id.CopyAssign(value);
			}
		}

		// Token: 0x170062FB RID: 25339
		// (get) Token: 0x0602893F RID: 166207 RVA: 0x00A0F5BD File Offset: 0x00A0D7BD
		// (set) Token: 0x06028940 RID: 166208 RVA: 0x00A0F5CD File Offset: 0x00A0D7CD
		public unsafe bool 等待回包过程中不重复触发进入GE
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x170062FC RID: 25340
		// (get) Token: 0x06028941 RID: 166209 RVA: 0x00A0F5E0 File Offset: 0x00A0D7E0
		// (set) Token: 0x06028942 RID: 166210 RVA: 0x00A0F623 File Offset: 0x00A0D823
		public FGameplayTagContainer 受击对象进入添加Tag
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._受击对象进入添加Tag) == null)
				{
					result = (this._受击对象进入添加Tag = new FGameplayTagContainer(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170062FD RID: 25341
		// (get) Token: 0x06028943 RID: 166211 RVA: 0x00A0F644 File Offset: 0x00A0D844
		// (set) Token: 0x06028944 RID: 166212 RVA: 0x00A0F663 File Offset: 0x00A0D863
		public TSoftObjectPtr<UKuroBpDataAssetGroup> GB组
		{
			get
			{
				return new TSoftObjectPtr<UKuroBpDataAssetGroup>(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReBulletDataExe.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06028945 RID: 166213 RVA: 0x00A0F688 File Offset: 0x00A0D888
		public SReBulletDataExe()
		{
		}

		// Token: 0x06028946 RID: 166214 RVA: 0x00A0F690 File Offset: 0x00A0D890
		public SReBulletDataExe(FGameplayTag 生成时对攻击者发射GameplayEvent标签, FGameplayTag 命中后对攻击者发射GameplayEvent标签, FGameplayTag 命中后对受击者发射GameplayEvent标签, FGameplayTag 结束时对攻击者发射GameplayEvent标签, TArray<long> 命中后对攻击者应用GE的Id, TArray<long> 命中后对受击者应用GE的Id, TArray<long> 能量恢复类GE数组的Id, TArray<long> 命中后对在场上角色应用的GE的Id, TArray<long> 受击对象进入应用的GE的Id, bool 等待回包过程中不重复触发进入GE, FGameplayTagContainer 受击对象进入添加Tag, TSoftObjectPtr<UKuroBpDataAssetGroup> GB组)
		{
			this.生成时对攻击者发射GameplayEvent标签 = 生成时对攻击者发射GameplayEvent标签;
			this.命中后对攻击者发射GameplayEvent标签 = 命中后对攻击者发射GameplayEvent标签;
			this.命中后对受击者发射GameplayEvent标签 = 命中后对受击者发射GameplayEvent标签;
			this.结束时对攻击者发射GameplayEvent标签 = 结束时对攻击者发射GameplayEvent标签;
			this.命中后对攻击者应用GE的Id = 命中后对攻击者应用GE的Id;
			this.命中后对受击者应用GE的Id = 命中后对受击者应用GE的Id;
			this.能量恢复类GE数组的Id = 能量恢复类GE数组的Id;
			this.命中后对在场上角色应用的GE的Id = 命中后对在场上角色应用的GE的Id;
			this.受击对象进入应用的GE的Id = 受击对象进入应用的GE的Id;
			this.等待回包过程中不重复触发进入GE = 等待回包过程中不重复触发进入GE;
			this.受击对象进入添加Tag = 受击对象进入添加Tag;
			this.GB组 = GB组;
		}

		// Token: 0x06028947 RID: 166215 RVA: 0x00A0F700 File Offset: 0x00A0D900
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataExe.StaticStruct();
		}

		// Token: 0x06028948 RID: 166216 RVA: 0x00A0F70C File Offset: 0x00A0D90C
		[NullableContext(2)]
		public SReBulletDataExe(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028949 RID: 166217 RVA: 0x00A0F716 File Offset: 0x00A0D916
		public SReBulletDataExe(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602894A RID: 166218 RVA: 0x00A0F721 File Offset: 0x00A0D921
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataExe(Pointer, false, true);
		}

		// Token: 0x0602894B RID: 166219 RVA: 0x00A0F72B File Offset: 0x00A0D92B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataExe(Pointer, MemoryOwner);
		}

		// Token: 0x04015659 RID: 87641
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataExe.SReBulletDataExe";

		// Token: 0x0401565A RID: 87642
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401565B RID: 87643
		internal static int __PropertyOffset_0;

		// Token: 0x0401565C RID: 87644
		internal static int __PropertyOffset_1;

		// Token: 0x0401565D RID: 87645
		internal static int __PropertyOffset_2;

		// Token: 0x0401565E RID: 87646
		internal static int __PropertyOffset_3;

		// Token: 0x0401565F RID: 87647
		internal static int __PropertyOffset_4;

		// Token: 0x04015660 RID: 87648
		[Nullable(2)]
		private TArray<long> _命中后对攻击者应用GE的Id;

		// Token: 0x04015661 RID: 87649
		internal static int __PropertyOffset_5;

		// Token: 0x04015662 RID: 87650
		[Nullable(2)]
		private TArray<long> _命中后对受击者应用GE的Id;

		// Token: 0x04015663 RID: 87651
		internal static int __PropertyOffset_6;

		// Token: 0x04015664 RID: 87652
		[Nullable(2)]
		private TArray<long> _能量恢复类GE数组的Id;

		// Token: 0x04015665 RID: 87653
		internal static int __PropertyOffset_7;

		// Token: 0x04015666 RID: 87654
		[Nullable(2)]
		private TArray<long> _命中后对在场上角色应用的GE的Id;

		// Token: 0x04015667 RID: 87655
		internal static int __PropertyOffset_8;

		// Token: 0x04015668 RID: 87656
		[Nullable(2)]
		private TArray<long> _受击对象进入应用的GE的Id;

		// Token: 0x04015669 RID: 87657
		internal static int __PropertyOffset_9;

		// Token: 0x0401566A RID: 87658
		internal static int __PropertyOffset_10;

		// Token: 0x0401566B RID: 87659
		[Nullable(2)]
		private FGameplayTagContainer _受击对象进入添加Tag;

		// Token: 0x0401566C RID: 87660
		internal static int __PropertyOffset_11;
	}
}
