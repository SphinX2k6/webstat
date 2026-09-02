using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.CherryBlossomsInteraction
{
	// Token: 0x02003D59 RID: 15705
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/CherryBlossomsInteraction/BP_CherryBlossomsInteraction.BP_CherryBlossomsInteraction_C")]
	[UnrealStructLayout(1672, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1672)]
	public class BP_CherryBlossomsInteraction_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026259 RID: 156249 RVA: 0x009CF460 File Offset: 0x009CD660
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CherryBlossomsInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/CherryBlossomsInteraction/BP_CherryBlossomsInteraction.BP_CherryBlossomsInteraction_C");
			}
			return BP_CherryBlossomsInteraction_C._ClassPtr;
		}

		// Token: 0x0602625A RID: 156250 RVA: 0x009CF484 File Offset: 0x009CD684
		public BP_CherryBlossomsInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BP_CherryBlossomsInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602625B RID: 156251 RVA: 0x009CF4AC File Offset: 0x009CD6AC
		[NullableContext(1)]
		public BP_CherryBlossomsInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CherryBlossomsInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055AC RID: 21932
		// (get) Token: 0x0602625C RID: 156252 RVA: 0x009CF4E0 File Offset: 0x009CD6E0
		// (set) Token: 0x0602625D RID: 156253 RVA: 0x009CF519 File Offset: 0x009CD719
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170055AD RID: 21933
		// (get) Token: 0x0602625E RID: 156254 RVA: 0x009CF53A File Offset: 0x009CD73A
		// (set) Token: 0x0602625F RID: 156255 RVA: 0x009CF54E File Offset: 0x009CD74E
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055AE RID: 21934
		// (get) Token: 0x06026260 RID: 156256 RVA: 0x009CF563 File Offset: 0x009CD763
		// (set) Token: 0x06026261 RID: 156257 RVA: 0x009CF577 File Offset: 0x009CD777
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170055AF RID: 21935
		// (get) Token: 0x06026262 RID: 156258 RVA: 0x009CF58C File Offset: 0x009CD78C
		// (set) Token: 0x06026263 RID: 156259 RVA: 0x009CF5A0 File Offset: 0x009CD7A0
		public unsafe UStaticMeshComponent Sphere4
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170055B0 RID: 21936
		// (get) Token: 0x06026264 RID: 156260 RVA: 0x009CF5B5 File Offset: 0x009CD7B5
		// (set) Token: 0x06026265 RID: 156261 RVA: 0x009CF5C9 File Offset: 0x009CD7C9
		public unsafe UStaticMeshComponent Sphere3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170055B1 RID: 21937
		// (get) Token: 0x06026266 RID: 156262 RVA: 0x009CF5DE File Offset: 0x009CD7DE
		// (set) Token: 0x06026267 RID: 156263 RVA: 0x009CF5F2 File Offset: 0x009CD7F2
		public unsafe UStaticMeshComponent Sphere2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170055B2 RID: 21938
		// (get) Token: 0x06026268 RID: 156264 RVA: 0x009CF607 File Offset: 0x009CD807
		// (set) Token: 0x06026269 RID: 156265 RVA: 0x009CF61B File Offset: 0x009CD81B
		public unsafe UStaticMeshComponent Sphere1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x170055B3 RID: 21939
		// (get) Token: 0x0602626A RID: 156266 RVA: 0x009CF630 File Offset: 0x009CD830
		// (set) Token: 0x0602626B RID: 156267 RVA: 0x009CF644 File Offset: 0x009CD844
		public unsafe UNiagaraComponent NS_FX_CherryBlossomsInteraction
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170055B4 RID: 21940
		// (get) Token: 0x0602626C RID: 156268 RVA: 0x009CF659 File Offset: 0x009CD859
		// (set) Token: 0x0602626D RID: 156269 RVA: 0x009CF66D File Offset: 0x009CD86D
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170055B5 RID: 21941
		// (get) Token: 0x0602626E RID: 156270 RVA: 0x009CF682 File Offset: 0x009CD882
		// (set) Token: 0x0602626F RID: 156271 RVA: 0x009CF696 File Offset: 0x009CD896
		public unsafe FVector FieldSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170055B6 RID: 21942
		// (get) Token: 0x06026270 RID: 156272 RVA: 0x009CF6AB File Offset: 0x009CD8AB
		// (set) Token: 0x06026271 RID: 156273 RVA: 0x009CF6BB File Offset: 0x009CD8BB
		public unsafe int Resolution
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170055B7 RID: 21943
		// (get) Token: 0x06026272 RID: 156274 RVA: 0x009CF6CC File Offset: 0x009CD8CC
		// (set) Token: 0x06026273 RID: 156275 RVA: 0x009CF6E0 File Offset: 0x009CD8E0
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x170055B8 RID: 21944
		// (get) Token: 0x06026274 RID: 156276 RVA: 0x009CF6F5 File Offset: 0x009CD8F5
		// (set) Token: 0x06026275 RID: 156277 RVA: 0x009CF709 File Offset: 0x009CD909
		public unsafe USkeletalMeshComponent Weapon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_12);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_12, value);
			}
		}

		// Token: 0x170055B9 RID: 21945
		// (get) Token: 0x06026276 RID: 156278 RVA: 0x009CF71E File Offset: 0x009CD91E
		// (set) Token: 0x06026277 RID: 156279 RVA: 0x009CF732 File Offset: 0x009CD932
		public unsafe FVector LastWeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170055BA RID: 21946
		// (get) Token: 0x06026278 RID: 156280 RVA: 0x009CF747 File Offset: 0x009CD947
		// (set) Token: 0x06026279 RID: 156281 RVA: 0x009CF75B File Offset: 0x009CD95B
		public unsafe FVector WeaponPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170055BB RID: 21947
		// (get) Token: 0x0602627A RID: 156282 RVA: 0x009CF770 File Offset: 0x009CD970
		// (set) Token: 0x0602627B RID: 156283 RVA: 0x009CF784 File Offset: 0x009CD984
		public unsafe FVector WeaponVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170055BC RID: 21948
		// (get) Token: 0x0602627C RID: 156284 RVA: 0x009CF799 File Offset: 0x009CD999
		// (set) Token: 0x0602627D RID: 156285 RVA: 0x009CF7AD File Offset: 0x009CD9AD
		public unsafe UMaterialParameterCollection Global_MPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_16);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_16, value);
			}
		}

		// Token: 0x170055BD RID: 21949
		// (get) Token: 0x0602627E RID: 156286 RVA: 0x009CF7C2 File Offset: 0x009CD9C2
		// (set) Token: 0x0602627F RID: 156287 RVA: 0x009CF7D2 File Offset: 0x009CD9D2
		public unsafe bool TriggerAll
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055BE RID: 21950
		// (get) Token: 0x06026280 RID: 156288 RVA: 0x009CF7E3 File Offset: 0x009CD9E3
		// (set) Token: 0x06026281 RID: 156289 RVA: 0x009CF7F7 File Offset: 0x009CD9F7
		public unsafe FLinearColor GlobalWorldPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170055BF RID: 21951
		// (get) Token: 0x06026282 RID: 156290 RVA: 0x009CF80C File Offset: 0x009CDA0C
		// (set) Token: 0x06026283 RID: 156291 RVA: 0x009CF81C File Offset: 0x009CDA1C
		public unsafe float PlayerSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170055C0 RID: 21952
		// (get) Token: 0x06026284 RID: 156292 RVA: 0x009CF82D File Offset: 0x009CDA2D
		// (set) Token: 0x06026285 RID: 156293 RVA: 0x009CF83D File Offset: 0x009CDA3D
		public unsafe float WeaponSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170055C1 RID: 21953
		// (get) Token: 0x06026286 RID: 156294 RVA: 0x009CF84E File Offset: 0x009CDA4E
		// (set) Token: 0x06026287 RID: 156295 RVA: 0x009CF862 File Offset: 0x009CDA62
		public unsafe FVector DepthCapturePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170055C2 RID: 21954
		// (get) Token: 0x06026288 RID: 156296 RVA: 0x009CF877 File Offset: 0x009CDA77
		// (set) Token: 0x06026289 RID: 156297 RVA: 0x009CF88B File Offset: 0x009CDA8B
		public unsafe UTexture DepthTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_22);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_22, value);
			}
		}

		// Token: 0x170055C3 RID: 21955
		// (get) Token: 0x0602628A RID: 156298 RVA: 0x009CF8A0 File Offset: 0x009CDAA0
		// (set) Token: 0x0602628B RID: 156299 RVA: 0x009CF8B0 File Offset: 0x009CDAB0
		public unsafe bool UseSamplePoints
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055C4 RID: 21956
		// (get) Token: 0x0602628C RID: 156300 RVA: 0x009CF8C1 File Offset: 0x009CDAC1
		// (set) Token: 0x0602628D RID: 156301 RVA: 0x009CF8D1 File Offset: 0x009CDAD1
		public unsafe int LeavesIDStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x170055C5 RID: 21957
		// (get) Token: 0x0602628E RID: 156302 RVA: 0x009CF8E2 File Offset: 0x009CDAE2
		// (set) Token: 0x0602628F RID: 156303 RVA: 0x009CF8F2 File Offset: 0x009CDAF2
		public unsafe int LeavesIDEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x170055C6 RID: 21958
		// (get) Token: 0x06026290 RID: 156304 RVA: 0x009CF903 File Offset: 0x009CDB03
		// (set) Token: 0x06026291 RID: 156305 RVA: 0x009CF913 File Offset: 0x009CDB13
		public unsafe int LeavesNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x170055C7 RID: 21959
		// (get) Token: 0x06026292 RID: 156306 RVA: 0x009CF924 File Offset: 0x009CDB24
		// (set) Token: 0x06026293 RID: 156307 RVA: 0x009CF934 File Offset: 0x009CDB34
		public unsafe float BoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x170055C8 RID: 21960
		// (get) Token: 0x06026294 RID: 156308 RVA: 0x009CF945 File Offset: 0x009CDB45
		// (set) Token: 0x06026295 RID: 156309 RVA: 0x009CF955 File Offset: 0x009CDB55
		public unsafe float LeavesScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x170055C9 RID: 21961
		// (get) Token: 0x06026296 RID: 156310 RVA: 0x009CF966 File Offset: 0x009CDB66
		// (set) Token: 0x06026297 RID: 156311 RVA: 0x009CF976 File Offset: 0x009CDB76
		public unsafe int LUTIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x170055CA RID: 21962
		// (get) Token: 0x06026298 RID: 156312 RVA: 0x009CF987 File Offset: 0x009CDB87
		// (set) Token: 0x06026299 RID: 156313 RVA: 0x009CF997 File Offset: 0x009CDB97
		public unsafe float LeavesRoughness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x170055CB RID: 21963
		// (get) Token: 0x0602629A RID: 156314 RVA: 0x009CF9A8 File Offset: 0x009CDBA8
		// (set) Token: 0x0602629B RID: 156315 RVA: 0x009CF9B8 File Offset: 0x009CDBB8
		public unsafe float LeavesAO
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x170055CC RID: 21964
		// (get) Token: 0x0602629C RID: 156316 RVA: 0x009CF9C9 File Offset: 0x009CDBC9
		// (set) Token: 0x0602629D RID: 156317 RVA: 0x009CF9D9 File Offset: 0x009CDBD9
		public unsafe float LutProbabilityPower
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x170055CD RID: 21965
		// (get) Token: 0x0602629E RID: 156318 RVA: 0x009CF9EA File Offset: 0x009CDBEA
		// (set) Token: 0x0602629F RID: 156319 RVA: 0x009CF9FE File Offset: 0x009CDBFE
		public unsafe UTexture LeavesMaskTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_33);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_33, value);
			}
		}

		// Token: 0x170055CE RID: 21966
		// (get) Token: 0x060262A0 RID: 156320 RVA: 0x009CFA13 File Offset: 0x009CDC13
		// (set) Token: 0x060262A1 RID: 156321 RVA: 0x009CFA23 File Offset: 0x009CDC23
		public unsafe bool UseLUT
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_34) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_34) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055CF RID: 21967
		// (get) Token: 0x060262A2 RID: 156322 RVA: 0x009CFA34 File Offset: 0x009CDC34
		// (set) Token: 0x060262A3 RID: 156323 RVA: 0x009CFA44 File Offset: 0x009CDC44
		public unsafe float OffsetDis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170055D0 RID: 21968
		// (get) Token: 0x060262A4 RID: 156324 RVA: 0x009CFA58 File Offset: 0x009CDC58
		// (set) Token: 0x060262A5 RID: 156325 RVA: 0x009CFA91 File Offset: 0x009CDC91
		[Nullable(1)]
		public TArray<FVector4> SamplePointsArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FVector4> result;
				if ((result = this._SamplePointsArray) == null)
				{
					result = (this._SamplePointsArray = new TArray<FVector4>(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_36, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SamplePointsArray.CopyAssign(value);
			}
		}

		// Token: 0x170055D1 RID: 21969
		// (get) Token: 0x060262A6 RID: 156326 RVA: 0x009CFA9F File Offset: 0x009CDC9F
		// (set) Token: 0x060262A7 RID: 156327 RVA: 0x009CFAAF File Offset: 0x009CDCAF
		public unsafe float CullingHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x170055D2 RID: 21970
		// (get) Token: 0x060262A8 RID: 156328 RVA: 0x009CFAC0 File Offset: 0x009CDCC0
		// (set) Token: 0x060262A9 RID: 156329 RVA: 0x009CFAD4 File Offset: 0x009CDCD4
		public unsafe FVector RuntimeDepthCapturePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_38);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_38) = value;
			}
		}

		// Token: 0x170055D3 RID: 21971
		// (get) Token: 0x060262AA RID: 156330 RVA: 0x009CFAE9 File Offset: 0x009CDCE9
		// (set) Token: 0x060262AB RID: 156331 RVA: 0x009CFAFD File Offset: 0x009CDCFD
		public unsafe UTexture RuntimeDepthTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_39);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_39, value);
			}
		}

		// Token: 0x170055D4 RID: 21972
		// (get) Token: 0x060262AC RID: 156332 RVA: 0x009CFB12 File Offset: 0x009CDD12
		// (set) Token: 0x060262AD RID: 156333 RVA: 0x009CFB26 File Offset: 0x009CDD26
		public unsafe FVector RuntimeDepthCaptureBoxSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170055D5 RID: 21973
		// (get) Token: 0x060262AE RID: 156334 RVA: 0x009CFB3B File Offset: 0x009CDD3B
		// (set) Token: 0x060262AF RID: 156335 RVA: 0x009CFB4B File Offset: 0x009CDD4B
		public unsafe bool UseRuntimeCapture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055D6 RID: 21974
		// (get) Token: 0x060262B0 RID: 156336 RVA: 0x009CFB5C File Offset: 0x009CDD5C
		// (set) Token: 0x060262B1 RID: 156337 RVA: 0x009CFB70 File Offset: 0x009CDD70
		public unsafe UHoudiniPointCache HPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_42);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_42, value);
			}
		}

		// Token: 0x170055D7 RID: 21975
		// (get) Token: 0x060262B2 RID: 156338 RVA: 0x009CFB85 File Offset: 0x009CDD85
		// (set) Token: 0x060262B3 RID: 156339 RVA: 0x009CFB95 File Offset: 0x009CDD95
		public unsafe bool InTheBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055D8 RID: 21976
		// (get) Token: 0x060262B4 RID: 156340 RVA: 0x009CFBA6 File Offset: 0x009CDDA6
		// (set) Token: 0x060262B5 RID: 156341 RVA: 0x009CFBB6 File Offset: 0x009CDDB6
		public unsafe bool IsResetParam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_44) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_44) = (value ? 1 : 0);
			}
		}

		// Token: 0x170055D9 RID: 21977
		// (get) Token: 0x060262B6 RID: 156342 RVA: 0x009CFBC7 File Offset: 0x009CDDC7
		// (set) Token: 0x060262B7 RID: 156343 RVA: 0x009CFBDB File Offset: 0x009CDDDB
		public unsafe FColor ColorTint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170055DA RID: 21978
		// (get) Token: 0x060262B8 RID: 156344 RVA: 0x009CFBF0 File Offset: 0x009CDDF0
		// (set) Token: 0x060262B9 RID: 156345 RVA: 0x009CFC00 File Offset: 0x009CDE00
		public unsafe float DetectionRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170055DB RID: 21979
		// (get) Token: 0x060262BA RID: 156346 RVA: 0x009CFC11 File Offset: 0x009CDE11
		// (set) Token: 0x060262BB RID: 156347 RVA: 0x009CFC21 File Offset: 0x009CDE21
		public unsafe int MapNumXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_47);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CherryBlossomsInteraction_C.__PropertyOffset_47) = value;
			}
		}

		// Token: 0x170055DC RID: 21980
		// (get) Token: 0x060262BC RID: 156348 RVA: 0x009CFC32 File Offset: 0x009CDE32
		// (set) Token: 0x060262BD RID: 156349 RVA: 0x009CFC46 File Offset: 0x009CDE46
		public unsafe UMaterialInterface LeavesMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_48);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_48, value);
			}
		}

		// Token: 0x170055DD RID: 21981
		// (get) Token: 0x060262BE RID: 156350 RVA: 0x009CFC5B File Offset: 0x009CDE5B
		// (set) Token: 0x060262BF RID: 156351 RVA: 0x009CFC6F File Offset: 0x009CDE6F
		public unsafe UTexture LeavesIDBaseColorMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_49);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_49, value);
			}
		}

		// Token: 0x170055DE RID: 21982
		// (get) Token: 0x060262C0 RID: 156352 RVA: 0x009CFC84 File Offset: 0x009CDE84
		// (set) Token: 0x060262C1 RID: 156353 RVA: 0x009CFC98 File Offset: 0x009CDE98
		public unsafe UTexture LeavesIDNormalMap
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_50);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CherryBlossomsInteraction_C.__PropertyOffset_50, value);
			}
		}

		// Token: 0x060262C2 RID: 156354 RVA: 0x009CFCAD File Offset: 0x009CDEAD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetHPCParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__SetHPCParam_NativeFunctionPtr, null);
		}

		// Token: 0x060262C3 RID: 156355 RVA: 0x009CFCC1 File Offset: 0x009CDEC1
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetMaterialParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__SetMaterialParam_NativeFunctionPtr, null);
		}

		// Token: 0x060262C4 RID: 156356 RVA: 0x009CFCD5 File Offset: 0x009CDED5
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ResetParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ResetParam_NativeFunctionPtr, null);
		}

		// Token: 0x060262C5 RID: 156357 RVA: 0x009CFCE9 File Offset: 0x009CDEE9
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetDepthCameraPos()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__SetDepthCameraPos_NativeFunctionPtr, null);
		}

		// Token: 0x060262C6 RID: 156358 RVA: 0x009CFD00 File Offset: 0x009CDF00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetInTheBox(FVector pos, ref bool IntheBox)
		{
			BP_CherryBlossomsInteraction_C.__GetInTheBox_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__GetInTheBox_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__GetInTheBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__GetInTheBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->pos = pos;
			ptr->IntheBox = IntheBox;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__GetInTheBox_NativeFunctionPtr, (void*)ptr);
			IntheBox = ptr->IntheBox;
		}

		// Token: 0x060262C7 RID: 156359 RVA: 0x009CFD56 File Offset: 0x009CDF56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void DisplaySamplePoint()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__DisplaySamplePoint_NativeFunctionPtr, null);
		}

		// Token: 0x060262C8 RID: 156360 RVA: 0x009CFD6A File Offset: 0x009CDF6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetLeavesParameters()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__SetLeavesParameters_NativeFunctionPtr, null);
		}

		// Token: 0x060262C9 RID: 156361 RVA: 0x009CFD7E File Offset: 0x009CDF7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Debug()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__Debug_NativeFunctionPtr, null);
		}

		// Token: 0x060262CA RID: 156362 RVA: 0x009CFD94 File Offset: 0x009CDF94
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Choose_Available_Point(FVectorDouble CollisionPoint, FVectorDouble WeaponPoint, BP_SceneBattleInteract_C ConfigDA, ref FVectorDouble AvailblePoint)
		{
			BP_CherryBlossomsInteraction_C.__Choose_Available_Point_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__Choose_Available_Point_FunctionParams[(UIntPtr)103] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__Choose_Available_Point_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CollisionPoint = CollisionPoint;
			ptr->WeaponPoint = WeaponPoint;
			ptr->ConfigDA = ((ConfigDA != null) ? ConfigDA.NativePtr : IntPtr.Zero);
			ptr->AvailblePoint = AvailblePoint;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__Choose_Available_Point_NativeFunctionPtr, (void*)ptr);
			AvailblePoint = ptr->AvailblePoint;
		}

		// Token: 0x060262CB RID: 156363 RVA: 0x009CFE11 File Offset: 0x009CE011
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__WeaponData_NativeFunctionPtr, null);
		}

		// Token: 0x060262CC RID: 156364 RVA: 0x009CFE28 File Offset: 0x009CE028
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateParam(float dt)
		{
			BP_CherryBlossomsInteraction_C.__UpdateParam_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__UpdateParam_FunctionParams[(UIntPtr)335] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__UpdateParam_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr, 1);
			ptr->dt = dt;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__UpdateParam_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060262CD RID: 156365 RVA: 0x009CFE71 File Offset: 0x009CE071
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__InitParam_NativeFunctionPtr, null);
		}

		// Token: 0x060262CE RID: 156366 RVA: 0x009CFE85 File Offset: 0x009CE085
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060262CF RID: 156367 RVA: 0x009CFE99 File Offset: 0x009CE099
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060262D0 RID: 156368 RVA: 0x009CFEAE File Offset: 0x009CE0AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060262D1 RID: 156369 RVA: 0x009CFEC2 File Offset: 0x009CE0C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060262D2 RID: 156370 RVA: 0x009CFED8 File Offset: 0x009CE0D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_CherryBlossomsInteraction_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060262D3 RID: 156371 RVA: 0x009CFF3B File Offset: 0x009CE13B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CustomTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__CustomTick_NativeFunctionPtr, null);
		}

		// Token: 0x060262D4 RID: 156372 RVA: 0x009CFF50 File Offset: 0x009CE150
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060262D5 RID: 156373 RVA: 0x009CFF98 File Offset: 0x009CE198
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060262D6 RID: 156374 RVA: 0x009CFFE0 File Offset: 0x009CE1E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CustomEvent(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_CherryBlossomsInteraction_C.__CustomEvent_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__CustomEvent_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__CustomEvent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__CustomEvent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__CustomEvent_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060262D7 RID: 156375 RVA: 0x009D0044 File Offset: 0x009CE244
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_CherryBlossomsInteraction(int EntryPoint)
		{
			BP_CherryBlossomsInteraction_C.__ExecuteUbergraph_BP_CherryBlossomsInteraction_FunctionParams* ptr = stackalloc BP_CherryBlossomsInteraction_C.__ExecuteUbergraph_BP_CherryBlossomsInteraction_FunctionParams[(UIntPtr)367] + 15L / (long)sizeof(BP_CherryBlossomsInteraction_C.__ExecuteUbergraph_BP_CherryBlossomsInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_CherryBlossomsInteraction_C.__ExecuteUbergraph_BP_CherryBlossomsInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_CherryBlossomsInteraction_C.__ExecuteUbergraph_BP_CherryBlossomsInteraction_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060262D8 RID: 156376 RVA: 0x009D008E File Offset: 0x009CE28E
		protected BP_CherryBlossomsInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C2B RID: 80939
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/CherryBlossomsInteraction/BP_CherryBlossomsInteraction.BP_CherryBlossomsInteraction_C";

		// Token: 0x04013C2C RID: 80940
		private static IntPtr _ClassPtr;

		// Token: 0x04013C2D RID: 80941
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C2E RID: 80942
		internal static int __PropertyOffset_0;

		// Token: 0x04013C2F RID: 80943
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04013C30 RID: 80944
		internal static int __PropertyOffset_1;

		// Token: 0x04013C31 RID: 80945
		internal static int __PropertyOffset_2;

		// Token: 0x04013C32 RID: 80946
		internal static int __PropertyOffset_3;

		// Token: 0x04013C33 RID: 80947
		internal static int __PropertyOffset_4;

		// Token: 0x04013C34 RID: 80948
		internal static int __PropertyOffset_5;

		// Token: 0x04013C35 RID: 80949
		internal static int __PropertyOffset_6;

		// Token: 0x04013C36 RID: 80950
		internal static int __PropertyOffset_7;

		// Token: 0x04013C37 RID: 80951
		internal static int __PropertyOffset_8;

		// Token: 0x04013C38 RID: 80952
		internal static int __PropertyOffset_9;

		// Token: 0x04013C39 RID: 80953
		internal static int __PropertyOffset_10;

		// Token: 0x04013C3A RID: 80954
		internal static int __PropertyOffset_11;

		// Token: 0x04013C3B RID: 80955
		internal static int __PropertyOffset_12;

		// Token: 0x04013C3C RID: 80956
		internal static int __PropertyOffset_13;

		// Token: 0x04013C3D RID: 80957
		internal static int __PropertyOffset_14;

		// Token: 0x04013C3E RID: 80958
		internal static int __PropertyOffset_15;

		// Token: 0x04013C3F RID: 80959
		internal static int __PropertyOffset_16;

		// Token: 0x04013C40 RID: 80960
		internal static int __PropertyOffset_17;

		// Token: 0x04013C41 RID: 80961
		internal static int __PropertyOffset_18;

		// Token: 0x04013C42 RID: 80962
		internal static int __PropertyOffset_19;

		// Token: 0x04013C43 RID: 80963
		internal static int __PropertyOffset_20;

		// Token: 0x04013C44 RID: 80964
		internal static int __PropertyOffset_21;

		// Token: 0x04013C45 RID: 80965
		internal static int __PropertyOffset_22;

		// Token: 0x04013C46 RID: 80966
		internal static int __PropertyOffset_23;

		// Token: 0x04013C47 RID: 80967
		internal static int __PropertyOffset_24;

		// Token: 0x04013C48 RID: 80968
		internal static int __PropertyOffset_25;

		// Token: 0x04013C49 RID: 80969
		internal static int __PropertyOffset_26;

		// Token: 0x04013C4A RID: 80970
		internal static int __PropertyOffset_27;

		// Token: 0x04013C4B RID: 80971
		internal static int __PropertyOffset_28;

		// Token: 0x04013C4C RID: 80972
		internal static int __PropertyOffset_29;

		// Token: 0x04013C4D RID: 80973
		internal static int __PropertyOffset_30;

		// Token: 0x04013C4E RID: 80974
		internal static int __PropertyOffset_31;

		// Token: 0x04013C4F RID: 80975
		internal static int __PropertyOffset_32;

		// Token: 0x04013C50 RID: 80976
		internal static int __PropertyOffset_33;

		// Token: 0x04013C51 RID: 80977
		internal static int __PropertyOffset_34;

		// Token: 0x04013C52 RID: 80978
		internal static int __PropertyOffset_35;

		// Token: 0x04013C53 RID: 80979
		internal static int __PropertyOffset_36;

		// Token: 0x04013C54 RID: 80980
		private TArray<FVector4> _SamplePointsArray;

		// Token: 0x04013C55 RID: 80981
		internal static int __PropertyOffset_37;

		// Token: 0x04013C56 RID: 80982
		internal static int __PropertyOffset_38;

		// Token: 0x04013C57 RID: 80983
		internal static int __PropertyOffset_39;

		// Token: 0x04013C58 RID: 80984
		internal static int __PropertyOffset_40;

		// Token: 0x04013C59 RID: 80985
		internal static int __PropertyOffset_41;

		// Token: 0x04013C5A RID: 80986
		internal static int __PropertyOffset_42;

		// Token: 0x04013C5B RID: 80987
		internal static int __PropertyOffset_43;

		// Token: 0x04013C5C RID: 80988
		internal static int __PropertyOffset_44;

		// Token: 0x04013C5D RID: 80989
		internal static int __PropertyOffset_45;

		// Token: 0x04013C5E RID: 80990
		internal static int __PropertyOffset_46;

		// Token: 0x04013C5F RID: 80991
		internal static int __PropertyOffset_47;

		// Token: 0x04013C60 RID: 80992
		internal static int __PropertyOffset_48;

		// Token: 0x04013C61 RID: 80993
		internal static int __PropertyOffset_49;

		// Token: 0x04013C62 RID: 80994
		internal static int __PropertyOffset_50;

		// Token: 0x04013C63 RID: 80995
		private static IntPtr __SetHPCParam_NativeFunctionPtr;

		// Token: 0x04013C64 RID: 80996
		private static IntPtr __SetMaterialParam_NativeFunctionPtr;

		// Token: 0x04013C65 RID: 80997
		private static IntPtr __ResetParam_NativeFunctionPtr;

		// Token: 0x04013C66 RID: 80998
		private static IntPtr __SetDepthCameraPos_NativeFunctionPtr;

		// Token: 0x04013C67 RID: 80999
		private static IntPtr __GetInTheBox_NativeFunctionPtr;

		// Token: 0x04013C68 RID: 81000
		private static IntPtr __DisplaySamplePoint_NativeFunctionPtr;

		// Token: 0x04013C69 RID: 81001
		private static IntPtr __SetLeavesParameters_NativeFunctionPtr;

		// Token: 0x04013C6A RID: 81002
		private static IntPtr __Debug_NativeFunctionPtr;

		// Token: 0x04013C6B RID: 81003
		private static IntPtr __Choose_Available_Point_NativeFunctionPtr;

		// Token: 0x04013C6C RID: 81004
		private static IntPtr __WeaponData_NativeFunctionPtr;

		// Token: 0x04013C6D RID: 81005
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04013C6E RID: 81006
		private static IntPtr __InitParam_NativeFunctionPtr;

		// Token: 0x04013C6F RID: 81007
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04013C70 RID: 81008
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04013C71 RID: 81009
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x04013C72 RID: 81010
		private static IntPtr __CustomTick_NativeFunctionPtr;

		// Token: 0x04013C73 RID: 81011
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013C74 RID: 81012
		private static IntPtr __CustomEvent_NativeFunctionPtr;

		// Token: 0x04013C75 RID: 81013
		private static IntPtr __ExecuteUbergraph_BP_CherryBlossomsInteraction_NativeFunctionPtr;

		// Token: 0x0200A00D RID: 40973
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __GetInTheBox_FunctionParams
		{
			// Token: 0x04032BEC RID: 207852
			[FieldOffset(0)]
			public FVector pos;

			// Token: 0x04032BED RID: 207853
			[FieldOffset(12)]
			public bool IntheBox;
		}

		// Token: 0x0200A00E RID: 40974
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 88)]
		protected ref struct __Choose_Available_Point_FunctionParams
		{
			// Token: 0x04032BEE RID: 207854
			[FieldOffset(0)]
			public FVectorDouble CollisionPoint;

			// Token: 0x04032BEF RID: 207855
			[FieldOffset(24)]
			public FVectorDouble WeaponPoint;

			// Token: 0x04032BF0 RID: 207856
			[FieldOffset(48)]
			public IntPtr ConfigDA;

			// Token: 0x04032BF1 RID: 207857
			[FieldOffset(56)]
			public FVectorDouble AvailblePoint;
		}

		// Token: 0x0200A00F RID: 40975
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 320)]
		protected ref struct __UpdateParam_FunctionParams
		{
			// Token: 0x04032BF2 RID: 207858
			[FieldOffset(0)]
			public float dt;
		}

		// Token: 0x0200A010 RID: 40976
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032BF3 RID: 207859
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032BF4 RID: 207860
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032BF5 RID: 207861
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x0200A011 RID: 40977
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032BF6 RID: 207862
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A012 RID: 40978
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __CustomEvent_FunctionParams
		{
			// Token: 0x04032BF7 RID: 207863
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032BF8 RID: 207864
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032BF9 RID: 207865
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x0200A013 RID: 40979
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 352)]
		protected ref struct __ExecuteUbergraph_BP_CherryBlossomsInteraction_FunctionParams
		{
			// Token: 0x04032BFA RID: 207866
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
