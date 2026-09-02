using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039CA RID: 14794
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C")]
	[UnrealStructLayout(2184, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2177)]
	public class BP_UpdateInteract_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DEFD RID: 122621 RVA: 0x008E769F File Offset: 0x008E589F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UpdateInteract_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C");
			}
			return BP_UpdateInteract_C._ClassPtr;
		}

		// Token: 0x0601DEFE RID: 122622 RVA: 0x008E76C4 File Offset: 0x008E58C4
		public BP_UpdateInteract_C() : this(BuiltinUtils.AllocNativeUObject(BP_UpdateInteract_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DEFF RID: 122623 RVA: 0x008E76EC File Offset: 0x008E58EC
		public BP_UpdateInteract_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UpdateInteract_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170027E1 RID: 10209
		// (get) Token: 0x0601DF00 RID: 122624 RVA: 0x008E7720 File Offset: 0x008E5920
		// (set) Token: 0x0601DF01 RID: 122625 RVA: 0x008E7759 File Offset: 0x008E5959
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170027E2 RID: 10210
		// (get) Token: 0x0601DF02 RID: 122626 RVA: 0x008E777A File Offset: 0x008E597A
		// (set) Token: 0x0601DF03 RID: 122627 RVA: 0x008E778E File Offset: 0x008E598E
		[Nullable(2)]
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170027E3 RID: 10211
		// (get) Token: 0x0601DF04 RID: 122628 RVA: 0x008E77A3 File Offset: 0x008E59A3
		// (set) Token: 0x0601DF05 RID: 122629 RVA: 0x008E77B7 File Offset: 0x008E59B7
		[Nullable(2)]
		public unsafe UBoxComponent Box
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170027E4 RID: 10212
		// (get) Token: 0x0601DF06 RID: 122630 RVA: 0x008E77CC File Offset: 0x008E59CC
		// (set) Token: 0x0601DF07 RID: 122631 RVA: 0x008E77E0 File Offset: 0x008E59E0
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UpdateInteract_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170027E5 RID: 10213
		// (get) Token: 0x0601DF08 RID: 122632 RVA: 0x008E77F5 File Offset: 0x008E59F5
		// (set) Token: 0x0601DF09 RID: 122633 RVA: 0x008E7809 File Offset: 0x008E5A09
		[Nullable(0)]
		public unsafe TEnumAsByte<E_GachaResultNew> GachaResults
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170027E6 RID: 10214
		// (get) Token: 0x0601DF0A RID: 122634 RVA: 0x008E781E File Offset: 0x008E5A1E
		// (set) Token: 0x0601DF0B RID: 122635 RVA: 0x008E7832 File Offset: 0x008E5A32
		public unsafe FLinearColor NormalColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170027E7 RID: 10215
		// (get) Token: 0x0601DF0C RID: 122636 RVA: 0x008E7847 File Offset: 0x008E5A47
		// (set) Token: 0x0601DF0D RID: 122637 RVA: 0x008E785B File Offset: 0x008E5A5B
		public unsafe FLinearColor PurpleColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170027E8 RID: 10216
		// (get) Token: 0x0601DF0E RID: 122638 RVA: 0x008E7870 File Offset: 0x008E5A70
		// (set) Token: 0x0601DF0F RID: 122639 RVA: 0x008E78A9 File Offset: 0x008E5AA9
		public TArray<ANiagaraActor> AwardParticles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ANiagaraActor> result;
				if ((result = this._AwardParticles) == null)
				{
					result = (this._AwardParticles = new TArray<ANiagaraActor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.AwardParticles.CopyAssign(value);
			}
		}

		// Token: 0x170027E9 RID: 10217
		// (get) Token: 0x0601DF10 RID: 122640 RVA: 0x008E78B7 File Offset: 0x008E5AB7
		// (set) Token: 0x0601DF11 RID: 122641 RVA: 0x008E78CB File Offset: 0x008E5ACB
		public unsafe FLinearColor GoldColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170027EA RID: 10218
		// (get) Token: 0x0601DF12 RID: 122642 RVA: 0x008E78E0 File Offset: 0x008E5AE0
		// (set) Token: 0x0601DF13 RID: 122643 RVA: 0x008E7919 File Offset: 0x008E5B19
		public ResultWeaponNormal ResultWeaponNormal
		{
			get
			{
				base.FastCheckIsValid();
				ResultWeaponNormal result;
				if ((result = this._ResultWeaponNormal) == null)
				{
					result = (this._ResultWeaponNormal = new ResultWeaponNormal(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_9, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027EB RID: 10219
		// (get) Token: 0x0601DF14 RID: 122644 RVA: 0x008E793C File Offset: 0x008E5B3C
		// (set) Token: 0x0601DF15 RID: 122645 RVA: 0x008E7975 File Offset: 0x008E5B75
		public ResultWeaponPurple ResultWeaponPurple
		{
			get
			{
				base.FastCheckIsValid();
				ResultWeaponPurple result;
				if ((result = this._ResultWeaponPurple) == null)
				{
					result = (this._ResultWeaponPurple = new ResultWeaponPurple(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_10, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027EC RID: 10220
		// (get) Token: 0x0601DF16 RID: 122646 RVA: 0x008E7998 File Offset: 0x008E5B98
		// (set) Token: 0x0601DF17 RID: 122647 RVA: 0x008E79D1 File Offset: 0x008E5BD1
		public ResultWeaponGolden ResultWeaponGolden
		{
			get
			{
				base.FastCheckIsValid();
				ResultWeaponGolden result;
				if ((result = this._ResultWeaponGolden) == null)
				{
					result = (this._ResultWeaponGolden = new ResultWeaponGolden(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_11, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027ED RID: 10221
		// (get) Token: 0x0601DF18 RID: 122648 RVA: 0x008E79F4 File Offset: 0x008E5BF4
		// (set) Token: 0x0601DF19 RID: 122649 RVA: 0x008E7A2D File Offset: 0x008E5C2D
		public TMap<int, FLinearColor> ParticleColor
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, FLinearColor> result;
				if ((result = this._ParticleColor) == null)
				{
					result = (this._ParticleColor = new TMap<int, FLinearColor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				this.ParticleColor.CopyAssign(value);
			}
		}

		// Token: 0x170027EE RID: 10222
		// (get) Token: 0x0601DF1A RID: 122650 RVA: 0x008E7A3C File Offset: 0x008E5C3C
		// (set) Token: 0x0601DF1B RID: 122651 RVA: 0x008E7A75 File Offset: 0x008E5C75
		public TMap<int, UKuroWeatherDataAsset> DataAsset
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, UKuroWeatherDataAsset> result;
				if ((result = this._DataAsset) == null)
				{
					result = (this._DataAsset = new TMap<int, UKuroWeatherDataAsset>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				this.DataAsset.CopyAssign(value);
			}
		}

		// Token: 0x170027EF RID: 10223
		// (get) Token: 0x0601DF1C RID: 122652 RVA: 0x008E7A83 File Offset: 0x008E5C83
		// (set) Token: 0x0601DF1D RID: 122653 RVA: 0x008E7A97 File Offset: 0x008E5C97
		public unsafe FLinearColor ParticleColorFinal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x170027F0 RID: 10224
		// (get) Token: 0x0601DF1E RID: 122654 RVA: 0x008E7AAC File Offset: 0x008E5CAC
		// (set) Token: 0x0601DF1F RID: 122655 RVA: 0x008E7AC0 File Offset: 0x008E5CC0
		[Nullable(0)]
		public unsafe TEnumAsByte<E_GachaResultFinal> GachaResultForShow
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170027F1 RID: 10225
		// (get) Token: 0x0601DF20 RID: 122656 RVA: 0x008E7AD8 File Offset: 0x008E5CD8
		// (set) Token: 0x0601DF21 RID: 122657 RVA: 0x008E7B11 File Offset: 0x008E5D11
		public ResultCharacterPurple ResultCharacterPurple
		{
			get
			{
				base.FastCheckIsValid();
				ResultCharacterPurple result;
				if ((result = this._ResultCharacterPurple) == null)
				{
					result = (this._ResultCharacterPurple = new ResultCharacterPurple(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_16, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F2 RID: 10226
		// (get) Token: 0x0601DF22 RID: 122658 RVA: 0x008E7B34 File Offset: 0x008E5D34
		// (set) Token: 0x0601DF23 RID: 122659 RVA: 0x008E7B6D File Offset: 0x008E5D6D
		public ResultCharacterGolden ResultCharacterGolden
		{
			get
			{
				base.FastCheckIsValid();
				ResultCharacterGolden result;
				if ((result = this._ResultCharacterGolden) == null)
				{
					result = (this._ResultCharacterGolden = new ResultCharacterGolden(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_17, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F3 RID: 10227
		// (get) Token: 0x0601DF24 RID: 122660 RVA: 0x008E7B90 File Offset: 0x008E5D90
		// (set) Token: 0x0601DF25 RID: 122661 RVA: 0x008E7BC9 File Offset: 0x008E5DC9
		public ResultYinlin ResultYinlin
		{
			get
			{
				base.FastCheckIsValid();
				ResultYinlin result;
				if ((result = this._ResultYinlin) == null)
				{
					result = (this._ResultYinlin = new ResultYinlin(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_18, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F4 RID: 10228
		// (get) Token: 0x0601DF26 RID: 122662 RVA: 0x008E7BEC File Offset: 0x008E5DEC
		// (set) Token: 0x0601DF27 RID: 122663 RVA: 0x008E7C25 File Offset: 0x008E5E25
		public ResultAnke ResultAnke
		{
			get
			{
				base.FastCheckIsValid();
				ResultAnke result;
				if ((result = this._ResultAnke) == null)
				{
					result = (this._ResultAnke = new ResultAnke(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_19, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F5 RID: 10229
		// (get) Token: 0x0601DF28 RID: 122664 RVA: 0x008E7C48 File Offset: 0x008E5E48
		// (set) Token: 0x0601DF29 RID: 122665 RVA: 0x008E7C81 File Offset: 0x008E5E81
		public ResultAwu ResultAwu
		{
			get
			{
				base.FastCheckIsValid();
				ResultAwu result;
				if ((result = this._ResultAwu) == null)
				{
					result = (this._ResultAwu = new ResultAwu(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_20, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F6 RID: 10230
		// (get) Token: 0x0601DF2A RID: 122666 RVA: 0x008E7CA4 File Offset: 0x008E5EA4
		// (set) Token: 0x0601DF2B RID: 122667 RVA: 0x008E7CDD File Offset: 0x008E5EDD
		public ResultKakaluo ResultKakaluo
		{
			get
			{
				base.FastCheckIsValid();
				ResultKakaluo result;
				if ((result = this._ResultKakaluo) == null)
				{
					result = (this._ResultKakaluo = new ResultKakaluo(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_21, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F7 RID: 10231
		// (get) Token: 0x0601DF2C RID: 122668 RVA: 0x008E7D00 File Offset: 0x008E5F00
		// (set) Token: 0x0601DF2D RID: 122669 RVA: 0x008E7D39 File Offset: 0x008E5F39
		public ResultChun ResultChun
		{
			get
			{
				base.FastCheckIsValid();
				ResultChun result;
				if ((result = this._ResultChun) == null)
				{
					result = (this._ResultChun = new ResultChun(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_22, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F8 RID: 10232
		// (get) Token: 0x0601DF2E RID: 122670 RVA: 0x008E7D5C File Offset: 0x008E5F5C
		// (set) Token: 0x0601DF2F RID: 122671 RVA: 0x008E7D95 File Offset: 0x008E5F95
		public ResultJiyan ResultJiyan
		{
			get
			{
				base.FastCheckIsValid();
				ResultJiyan result;
				if ((result = this._ResultJiyan) == null)
				{
					result = (this._ResultJiyan = new ResultJiyan(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_23, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027F9 RID: 10233
		// (get) Token: 0x0601DF30 RID: 122672 RVA: 0x008E7DB8 File Offset: 0x008E5FB8
		// (set) Token: 0x0601DF31 RID: 122673 RVA: 0x008E7DF1 File Offset: 0x008E5FF1
		public ResultJueyuan ResultJueyuan
		{
			get
			{
				base.FastCheckIsValid();
				ResultJueyuan result;
				if ((result = this._ResultJueyuan) == null)
				{
					result = (this._ResultJueyuan = new ResultJueyuan(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_24, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170027FA RID: 10234
		// (get) Token: 0x0601DF32 RID: 122674 RVA: 0x008E7E14 File Offset: 0x008E6014
		// (set) Token: 0x0601DF33 RID: 122675 RVA: 0x008E7E4D File Offset: 0x008E604D
		public TArray<AActor> ChangeHiddenObject
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._ChangeHiddenObject) == null)
				{
					result = (this._ChangeHiddenObject = new TArray<AActor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				this.ChangeHiddenObject.CopyAssign(value);
			}
		}

		// Token: 0x170027FB RID: 10235
		// (get) Token: 0x0601DF34 RID: 122676 RVA: 0x008E7E5C File Offset: 0x008E605C
		// (set) Token: 0x0601DF35 RID: 122677 RVA: 0x008E7E95 File Offset: 0x008E6095
		public TMap<int, bool> MeshHidden
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, bool> result;
				if ((result = this._MeshHidden) == null)
				{
					result = (this._MeshHidden = new TMap<int, bool>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				this.MeshHidden.CopyAssign(value);
			}
		}

		// Token: 0x170027FC RID: 10236
		// (get) Token: 0x0601DF36 RID: 122678 RVA: 0x008E7EA3 File Offset: 0x008E60A3
		// (set) Token: 0x0601DF37 RID: 122679 RVA: 0x008E7EB3 File Offset: 0x008E60B3
		public unsafe bool SceneObjectVisibility
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027FD RID: 10237
		// (get) Token: 0x0601DF38 RID: 122680 RVA: 0x008E7EC4 File Offset: 0x008E60C4
		// (set) Token: 0x0601DF39 RID: 122681 RVA: 0x008E7EFD File Offset: 0x008E60FD
		public TArray<ANiagaraActor> CharacterHiddenParticles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ANiagaraActor> result;
				if ((result = this._CharacterHiddenParticles) == null)
				{
					result = (this._CharacterHiddenParticles = new TArray<ANiagaraActor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				this.CharacterHiddenParticles.CopyAssign(value);
			}
		}

		// Token: 0x170027FE RID: 10238
		// (get) Token: 0x0601DF3A RID: 122682 RVA: 0x008E7F0B File Offset: 0x008E610B
		// (set) Token: 0x0601DF3B RID: 122683 RVA: 0x008E7F1B File Offset: 0x008E611B
		public unsafe bool IsCharacter_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027FF RID: 10239
		// (get) Token: 0x0601DF3C RID: 122684 RVA: 0x008E7F2C File Offset: 0x008E612C
		// (set) Token: 0x0601DF3D RID: 122685 RVA: 0x008E7F65 File Offset: 0x008E6165
		public TArray<ANiagaraActor> UpParticles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ANiagaraActor> result;
				if ((result = this._UpParticles) == null)
				{
					result = (this._UpParticles = new TArray<ANiagaraActor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				this.UpParticles.CopyAssign(value);
			}
		}

		// Token: 0x17002800 RID: 10240
		// (get) Token: 0x0601DF3E RID: 122686 RVA: 0x008E7F74 File Offset: 0x008E6174
		// (set) Token: 0x0601DF3F RID: 122687 RVA: 0x008E7FAD File Offset: 0x008E61AD
		public TArray<ANiagaraActor> DownParticles
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ANiagaraActor> result;
				if ((result = this._DownParticles) == null)
				{
					result = (this._DownParticles = new TArray<ANiagaraActor>(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				this.DownParticles.CopyAssign(value);
			}
		}

		// Token: 0x17002801 RID: 10241
		// (get) Token: 0x0601DF40 RID: 122688 RVA: 0x008E7FBB File Offset: 0x008E61BB
		// (set) Token: 0x0601DF41 RID: 122689 RVA: 0x008E7FCB File Offset: 0x008E61CB
		public unsafe bool IsEditor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002802 RID: 10242
		// (get) Token: 0x0601DF42 RID: 122690 RVA: 0x008E7FDC File Offset: 0x008E61DC
		// (set) Token: 0x0601DF43 RID: 122691 RVA: 0x008E8015 File Offset: 0x008E6215
		public ResultBaer ResultBaer
		{
			get
			{
				base.FastCheckIsValid();
				ResultBaer result;
				if ((result = this._ResultBaer) == null)
				{
					result = (this._ResultBaer = new ResultBaer(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_33, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002803 RID: 10243
		// (get) Token: 0x0601DF44 RID: 122692 RVA: 0x008E8038 File Offset: 0x008E6238
		// (set) Token: 0x0601DF45 RID: 122693 RVA: 0x008E8071 File Offset: 0x008E6271
		public ResultBailian ResultBailian
		{
			get
			{
				base.FastCheckIsValid();
				ResultBailian result;
				if ((result = this._ResultBailian) == null)
				{
					result = (this._ResultBailian = new ResultBailian(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_34, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002804 RID: 10244
		// (get) Token: 0x0601DF46 RID: 122694 RVA: 0x008E8094 File Offset: 0x008E6294
		// (set) Token: 0x0601DF47 RID: 122695 RVA: 0x008E80CD File Offset: 0x008E62CD
		public ResultJianxin ResultJianxin
		{
			get
			{
				base.FastCheckIsValid();
				ResultJianxin result;
				if ((result = this._ResultJianxin) == null)
				{
					result = (this._ResultJianxin = new ResultJianxin(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_35, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002805 RID: 10245
		// (get) Token: 0x0601DF48 RID: 122696 RVA: 0x008E80F0 File Offset: 0x008E62F0
		// (set) Token: 0x0601DF49 RID: 122697 RVA: 0x008E8129 File Offset: 0x008E6329
		public ResultMaxiaofang ResultMaxiaofang
		{
			get
			{
				base.FastCheckIsValid();
				ResultMaxiaofang result;
				if ((result = this._ResultMaxiaofang) == null)
				{
					result = (this._ResultMaxiaofang = new ResultMaxiaofang(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_36, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002806 RID: 10246
		// (get) Token: 0x0601DF4A RID: 122698 RVA: 0x008E814C File Offset: 0x008E634C
		// (set) Token: 0x0601DF4B RID: 122699 RVA: 0x008E8185 File Offset: 0x008E6385
		public ResultMicai ResultMicai
		{
			get
			{
				base.FastCheckIsValid();
				ResultMicai result;
				if ((result = this._ResultMicai) == null)
				{
					result = (this._ResultMicai = new ResultMicai(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_37, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002807 RID: 10247
		// (get) Token: 0x0601DF4C RID: 122700 RVA: 0x008E81A8 File Offset: 0x008E63A8
		// (set) Token: 0x0601DF4D RID: 122701 RVA: 0x008E81E1 File Offset: 0x008E63E1
		public ResultQiushui ResultQiushui
		{
			get
			{
				base.FastCheckIsValid();
				ResultQiushui result;
				if ((result = this._ResultQiushui) == null)
				{
					result = (this._ResultQiushui = new ResultQiushui(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_38, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002808 RID: 10248
		// (get) Token: 0x0601DF4E RID: 122702 RVA: 0x008E8204 File Offset: 0x008E6404
		// (set) Token: 0x0601DF4F RID: 122703 RVA: 0x008E823D File Offset: 0x008E643D
		public ResultSanhua ResultSanhua
		{
			get
			{
				base.FastCheckIsValid();
				ResultSanhua result;
				if ((result = this._ResultSanhua) == null)
				{
					result = (this._ResultSanhua = new ResultSanhua(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_39, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002809 RID: 10249
		// (get) Token: 0x0601DF50 RID: 122704 RVA: 0x008E8260 File Offset: 0x008E6460
		// (set) Token: 0x0601DF51 RID: 122705 RVA: 0x008E8299 File Offset: 0x008E6499
		public ResultTaoqi ResultTaoqi
		{
			get
			{
				base.FastCheckIsValid();
				ResultTaoqi result;
				if ((result = this._ResultTaoqi) == null)
				{
					result = (this._ResultTaoqi = new ResultTaoqi(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_40, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700280A RID: 10250
		// (get) Token: 0x0601DF52 RID: 122706 RVA: 0x008E82BC File Offset: 0x008E64BC
		// (set) Token: 0x0601DF53 RID: 122707 RVA: 0x008E82F5 File Offset: 0x008E64F5
		public ResultYangyang ResultYangyang
		{
			get
			{
				base.FastCheckIsValid();
				ResultYangyang result;
				if ((result = this._ResultYangyang) == null)
				{
					result = (this._ResultYangyang = new ResultYangyang(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_41, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700280B RID: 10251
		// (get) Token: 0x0601DF54 RID: 122708 RVA: 0x008E8318 File Offset: 0x008E6518
		// (set) Token: 0x0601DF55 RID: 122709 RVA: 0x008E8351 File Offset: 0x008E6551
		public ResultYuanwu ResultYuanwu
		{
			get
			{
				base.FastCheckIsValid();
				ResultYuanwu result;
				if ((result = this._ResultYuanwu) == null)
				{
					result = (this._ResultYuanwu = new ResultYuanwu(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_42, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700280C RID: 10252
		// (get) Token: 0x0601DF56 RID: 122710 RVA: 0x008E8372 File Offset: 0x008E6572
		// (set) Token: 0x0601DF57 RID: 122711 RVA: 0x008E8382 File Offset: 0x008E6582
		public unsafe bool IsCallable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700280D RID: 10253
		// (get) Token: 0x0601DF58 RID: 122712 RVA: 0x008E8393 File Offset: 0x008E6593
		// (set) Token: 0x0601DF59 RID: 122713 RVA: 0x008E83A3 File Offset: 0x008E65A3
		public unsafe float OriMotionBlur
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x1700280E RID: 10254
		// (get) Token: 0x0601DF5A RID: 122714 RVA: 0x008E83B4 File Offset: 0x008E65B4
		// (set) Token: 0x0601DF5B RID: 122715 RVA: 0x008E83ED File Offset: 0x008E65ED
		public ResultJinxi ResultJinxi
		{
			get
			{
				base.FastCheckIsValid();
				ResultJinxi result;
				if ((result = this._ResultJinxi) == null)
				{
					result = (this._ResultJinxi = new ResultJinxi(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_45, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700280F RID: 10255
		// (get) Token: 0x0601DF5C RID: 122716 RVA: 0x008E8410 File Offset: 0x008E6610
		// (set) Token: 0x0601DF5D RID: 122717 RVA: 0x008E8449 File Offset: 0x008E6649
		public ResultChangli ResultChangli
		{
			get
			{
				base.FastCheckIsValid();
				ResultChangli result;
				if ((result = this._ResultChangli) == null)
				{
					result = (this._ResultChangli = new ResultChangli(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_46, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002810 RID: 10256
		// (get) Token: 0x0601DF5E RID: 122718 RVA: 0x008E846C File Offset: 0x008E666C
		// (set) Token: 0x0601DF5F RID: 122719 RVA: 0x008E84A5 File Offset: 0x008E66A5
		public ResultMain ResultMain
		{
			get
			{
				base.FastCheckIsValid();
				ResultMain result;
				if ((result = this._ResultMain) == null)
				{
					result = (this._ResultMain = new ResultMain(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_47, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x17002811 RID: 10257
		// (get) Token: 0x0601DF60 RID: 122720 RVA: 0x008E84C6 File Offset: 0x008E66C6
		// (set) Token: 0x0601DF61 RID: 122721 RVA: 0x008E84D6 File Offset: 0x008E66D6
		public unsafe bool OpenLerPerFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_48) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UpdateInteract_C.__PropertyOffset_48) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DF62 RID: 122722 RVA: 0x008E84E8 File Offset: 0x008E66E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void QualityColorModification(E_GachaResultFinal GachaResult, int ID, bool IsCharacter)
		{
			BP_UpdateInteract_C.__QualityColorModification_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__QualityColorModification_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_UpdateInteract_C.__QualityColorModification_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__QualityColorModification_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GachaResult = GachaResult;
			ptr->ID = ID;
			ptr->IsCharacter = IsCharacter;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__QualityColorModification_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF63 RID: 122723 RVA: 0x008E8544 File Offset: 0x008E6744
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void IsNewWorkFlow(ref bool IsNew)
		{
			BP_UpdateInteract_C.__IsNewWorkFlow_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__IsNewWorkFlow_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_UpdateInteract_C.__IsNewWorkFlow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__IsNewWorkFlow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IsNew = IsNew;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__IsNewWorkFlow_NativeFunctionPtr, (void*)ptr);
			IsNew = ptr->IsNew;
		}

		// Token: 0x0601DF64 RID: 122724 RVA: 0x008E8594 File Offset: 0x008E6794
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void TSUpdateGachaResult_deprecated_(E_GachaResultNew GachaResults)
		{
			BP_UpdateInteract_C.__TSUpdateGachaResult_deprecated__FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__TSUpdateGachaResult_deprecated__FunctionParams[(UIntPtr)17] + 15L / (long)sizeof(BP_UpdateInteract_C.__TSUpdateGachaResult_deprecated__FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__TSUpdateGachaResult_deprecated__NativeFunctionPtr, (void*)ptr, 1);
			ptr->GachaResults = GachaResults;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__TSUpdateGachaResult_deprecated__NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF65 RID: 122725 RVA: 0x008E85DF File Offset: 0x008E67DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF66 RID: 122726 RVA: 0x008E85F3 File Offset: 0x008E67F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UpdateInteract_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DF67 RID: 122727 RVA: 0x008E8608 File Offset: 0x008E6808
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Sanhua()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Sanhua_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF68 RID: 122728 RVA: 0x008E861C File Offset: 0x008E681C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Taoqi()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Taoqi_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF69 RID: 122729 RVA: 0x008E8630 File Offset: 0x008E6830
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Yangyang()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Yangyang_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6A RID: 122730 RVA: 0x008E8644 File Offset: 0x008E6844
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Yuanwu()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Yuanwu_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6B RID: 122731 RVA: 0x008E8658 File Offset: 0x008E6858
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Kakaluo()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Kakaluo_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6C RID: 122732 RVA: 0x008E866C File Offset: 0x008E686C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Awu()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Awu_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6D RID: 122733 RVA: 0x008E8680 File Offset: 0x008E6880
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Yinlin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Yinlin_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6E RID: 122734 RVA: 0x008E8694 File Offset: 0x008E6894
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Anke()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Anke_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF6F RID: 122735 RVA: 0x008E86A8 File Offset: 0x008E68A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CharacterGolden()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__CharacterGolden_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF70 RID: 122736 RVA: 0x008E86BC File Offset: 0x008E68BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void CharacterPurple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__CharacterPurple_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF71 RID: 122737 RVA: 0x008E86D0 File Offset: 0x008E68D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponGolden()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__WeaponGolden_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF72 RID: 122738 RVA: 0x008E86E4 File Offset: 0x008E68E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponPurple()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__WeaponPurple_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF73 RID: 122739 RVA: 0x008E86F8 File Offset: 0x008E68F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void WeaponNormal()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__WeaponNormal_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF74 RID: 122740 RVA: 0x008E870C File Offset: 0x008E690C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_UpdateInteract_C.__EditorTick_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UpdateInteract_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF75 RID: 122741 RVA: 0x008E8754 File Offset: 0x008E6954
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_UpdateInteract_C.__EditorTick_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UpdateInteract_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UpdateInteract_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DF76 RID: 122742 RVA: 0x008E879C File Offset: 0x008E699C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_UpdateInteract_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UpdateInteract_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF77 RID: 122743 RVA: 0x008E87E4 File Offset: 0x008E69E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_UpdateInteract_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UpdateInteract_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UpdateInteract_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DF78 RID: 122744 RVA: 0x008E882B File Offset: 0x008E6A2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF79 RID: 122745 RVA: 0x008E883F File Offset: 0x008E6A3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UpdateInteract_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601DF7A RID: 122746 RVA: 0x008E8854 File Offset: 0x008E6A54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Qiushui()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Qiushui_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF7B RID: 122747 RVA: 0x008E8868 File Offset: 0x008E6A68
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Micai()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Micai_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF7C RID: 122748 RVA: 0x008E887C File Offset: 0x008E6A7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Maxiaofang()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Maxiaofang_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF7D RID: 122749 RVA: 0x008E8890 File Offset: 0x008E6A90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Jianxin()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Jianxin_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF7E RID: 122750 RVA: 0x008E88A4 File Offset: 0x008E6AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Bailian()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Bailian_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF7F RID: 122751 RVA: 0x008E88B8 File Offset: 0x008E6AB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Baer()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Baer_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF80 RID: 122752 RVA: 0x008E88CC File Offset: 0x008E6ACC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateGachaShowItem(int ID, byte GachaResults)
		{
			BP_UpdateInteract_C.__UpdateGachaShowItem_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__UpdateGachaShowItem_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_UpdateInteract_C.__UpdateGachaShowItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__UpdateGachaShowItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ID = ID;
			ptr->GachaResults = GachaResults;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__UpdateGachaShowItem_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF81 RID: 122753 RVA: 0x008E891C File Offset: 0x008E6B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HiddenShowDownParticles(bool Show_)
		{
			BP_UpdateInteract_C.__HiddenShowDownParticles_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__HiddenShowDownParticles_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_UpdateInteract_C.__HiddenShowDownParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__HiddenShowDownParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Show_ = Show_;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__HiddenShowDownParticles_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF82 RID: 122754 RVA: 0x008E8964 File Offset: 0x008E6B64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void HiddenShowUpParticles(bool Show_)
		{
			BP_UpdateInteract_C.__HiddenShowUpParticles_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__HiddenShowUpParticles_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_UpdateInteract_C.__HiddenShowUpParticles_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__HiddenShowUpParticles_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Show_ = Show_;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__HiddenShowUpParticles_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601DF83 RID: 122755 RVA: 0x008E89AA File Offset: 0x008E6BAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EndGachaScene()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__EndGachaScene_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF84 RID: 122756 RVA: 0x008E89BE File Offset: 0x008E6BBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Jiyan()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Jiyan_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF85 RID: 122757 RVA: 0x008E89D2 File Offset: 0x008E6BD2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Chun()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Chun_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF86 RID: 122758 RVA: 0x008E89E6 File Offset: 0x008E6BE6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateGacha()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__UpdateGacha_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF87 RID: 122759 RVA: 0x008E89FA File Offset: 0x008E6BFA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Jueyuan()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Jueyuan_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF88 RID: 122760 RVA: 0x008E8A0E File Offset: 0x008E6C0E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Jinxi()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Jinxi_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF89 RID: 122761 RVA: 0x008E8A22 File Offset: 0x008E6C22
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Changli()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UpdateInteract_C.__Changli_NativeFunctionPtr, null);
		}

		// Token: 0x0601DF8A RID: 122762 RVA: 0x008E8A38 File Offset: 0x008E6C38
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_UpdateInteract(int EntryPoint)
		{
			BP_UpdateInteract_C.__ExecuteUbergraph_BP_UpdateInteract_FunctionParams* ptr = stackalloc BP_UpdateInteract_C.__ExecuteUbergraph_BP_UpdateInteract_FunctionParams[(UIntPtr)319] + 15L / (long)sizeof(BP_UpdateInteract_C.__ExecuteUbergraph_BP_UpdateInteract_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UpdateInteract_C.__ExecuteUbergraph_BP_UpdateInteract_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UpdateInteract_C.__ExecuteUbergraph_BP_UpdateInteract_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601DF8B RID: 122763 RVA: 0x008E8A82 File Offset: 0x008E6C82
		protected BP_UpdateInteract_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EACC RID: 60108
		public new const string __ObjectPath = "/Game/Aki/Scene/NewGacha/BP/BP_UpdateInteract.BP_UpdateInteract_C";

		// Token: 0x0400EACD RID: 60109
		private static IntPtr _ClassPtr;

		// Token: 0x0400EACE RID: 60110
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EACF RID: 60111
		public static IntPtr __ResultMain__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD0 RID: 60112
		public static IntPtr __ResultChangli__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD1 RID: 60113
		public static IntPtr __ResultJinxi__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD2 RID: 60114
		public static IntPtr __ResultYuanwu__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD3 RID: 60115
		public static IntPtr __ResultYangyang__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD4 RID: 60116
		public static IntPtr __ResultTaoqi__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD5 RID: 60117
		public static IntPtr __ResultSanhua__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD6 RID: 60118
		public static IntPtr __ResultQiushui__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD7 RID: 60119
		public static IntPtr __ResultMicai__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD8 RID: 60120
		public static IntPtr __ResultMaxiaofang__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAD9 RID: 60121
		public static IntPtr __ResultJianxin__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADA RID: 60122
		public static IntPtr __ResultBailian__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADB RID: 60123
		public static IntPtr __ResultBaer__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADC RID: 60124
		public static IntPtr __ResultJueyuan__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADD RID: 60125
		public static IntPtr __ResultJiyan__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADE RID: 60126
		public static IntPtr __ResultChun__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EADF RID: 60127
		public static IntPtr __ResultKakaluo__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE0 RID: 60128
		public static IntPtr __ResultAwu__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE1 RID: 60129
		public static IntPtr __ResultAnke__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE2 RID: 60130
		public static IntPtr __ResultYinlin__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE3 RID: 60131
		public static IntPtr __ResultCharacterGolden__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE4 RID: 60132
		public static IntPtr __ResultCharacterPurple__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE5 RID: 60133
		public static IntPtr __ResultWeaponGolden__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE6 RID: 60134
		public static IntPtr __ResultWeaponPurple__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE7 RID: 60135
		public static IntPtr __ResultWeaponNormal__DelegateSignature_NativeFunctionPtr;

		// Token: 0x0400EAE8 RID: 60136
		internal static int __PropertyOffset_0;

		// Token: 0x0400EAE9 RID: 60137
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EAEA RID: 60138
		internal static int __PropertyOffset_1;

		// Token: 0x0400EAEB RID: 60139
		internal static int __PropertyOffset_2;

		// Token: 0x0400EAEC RID: 60140
		internal static int __PropertyOffset_3;

		// Token: 0x0400EAED RID: 60141
		internal static int __PropertyOffset_4;

		// Token: 0x0400EAEE RID: 60142
		internal static int __PropertyOffset_5;

		// Token: 0x0400EAEF RID: 60143
		internal static int __PropertyOffset_6;

		// Token: 0x0400EAF0 RID: 60144
		internal static int __PropertyOffset_7;

		// Token: 0x0400EAF1 RID: 60145
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ANiagaraActor> _AwardParticles;

		// Token: 0x0400EAF2 RID: 60146
		internal static int __PropertyOffset_8;

		// Token: 0x0400EAF3 RID: 60147
		internal static int __PropertyOffset_9;

		// Token: 0x0400EAF4 RID: 60148
		[Nullable(2)]
		private ResultWeaponNormal _ResultWeaponNormal;

		// Token: 0x0400EAF5 RID: 60149
		internal static int __PropertyOffset_10;

		// Token: 0x0400EAF6 RID: 60150
		[Nullable(2)]
		private ResultWeaponPurple _ResultWeaponPurple;

		// Token: 0x0400EAF7 RID: 60151
		internal static int __PropertyOffset_11;

		// Token: 0x0400EAF8 RID: 60152
		[Nullable(2)]
		private ResultWeaponGolden _ResultWeaponGolden;

		// Token: 0x0400EAF9 RID: 60153
		internal static int __PropertyOffset_12;

		// Token: 0x0400EAFA RID: 60154
		[Nullable(2)]
		private TMap<int, FLinearColor> _ParticleColor;

		// Token: 0x0400EAFB RID: 60155
		internal static int __PropertyOffset_13;

		// Token: 0x0400EAFC RID: 60156
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, UKuroWeatherDataAsset> _DataAsset;

		// Token: 0x0400EAFD RID: 60157
		internal static int __PropertyOffset_14;

		// Token: 0x0400EAFE RID: 60158
		internal static int __PropertyOffset_15;

		// Token: 0x0400EAFF RID: 60159
		internal static int __PropertyOffset_16;

		// Token: 0x0400EB00 RID: 60160
		[Nullable(2)]
		private ResultCharacterPurple _ResultCharacterPurple;

		// Token: 0x0400EB01 RID: 60161
		internal static int __PropertyOffset_17;

		// Token: 0x0400EB02 RID: 60162
		[Nullable(2)]
		private ResultCharacterGolden _ResultCharacterGolden;

		// Token: 0x0400EB03 RID: 60163
		internal static int __PropertyOffset_18;

		// Token: 0x0400EB04 RID: 60164
		[Nullable(2)]
		private ResultYinlin _ResultYinlin;

		// Token: 0x0400EB05 RID: 60165
		internal static int __PropertyOffset_19;

		// Token: 0x0400EB06 RID: 60166
		[Nullable(2)]
		private ResultAnke _ResultAnke;

		// Token: 0x0400EB07 RID: 60167
		internal static int __PropertyOffset_20;

		// Token: 0x0400EB08 RID: 60168
		[Nullable(2)]
		private ResultAwu _ResultAwu;

		// Token: 0x0400EB09 RID: 60169
		internal static int __PropertyOffset_21;

		// Token: 0x0400EB0A RID: 60170
		[Nullable(2)]
		private ResultKakaluo _ResultKakaluo;

		// Token: 0x0400EB0B RID: 60171
		internal static int __PropertyOffset_22;

		// Token: 0x0400EB0C RID: 60172
		[Nullable(2)]
		private ResultChun _ResultChun;

		// Token: 0x0400EB0D RID: 60173
		internal static int __PropertyOffset_23;

		// Token: 0x0400EB0E RID: 60174
		[Nullable(2)]
		private ResultJiyan _ResultJiyan;

		// Token: 0x0400EB0F RID: 60175
		internal static int __PropertyOffset_24;

		// Token: 0x0400EB10 RID: 60176
		[Nullable(2)]
		private ResultJueyuan _ResultJueyuan;

		// Token: 0x0400EB11 RID: 60177
		internal static int __PropertyOffset_25;

		// Token: 0x0400EB12 RID: 60178
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _ChangeHiddenObject;

		// Token: 0x0400EB13 RID: 60179
		internal static int __PropertyOffset_26;

		// Token: 0x0400EB14 RID: 60180
		[Nullable(2)]
		private TMap<int, bool> _MeshHidden;

		// Token: 0x0400EB15 RID: 60181
		internal static int __PropertyOffset_27;

		// Token: 0x0400EB16 RID: 60182
		internal static int __PropertyOffset_28;

		// Token: 0x0400EB17 RID: 60183
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ANiagaraActor> _CharacterHiddenParticles;

		// Token: 0x0400EB18 RID: 60184
		internal static int __PropertyOffset_29;

		// Token: 0x0400EB19 RID: 60185
		internal static int __PropertyOffset_30;

		// Token: 0x0400EB1A RID: 60186
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ANiagaraActor> _UpParticles;

		// Token: 0x0400EB1B RID: 60187
		internal static int __PropertyOffset_31;

		// Token: 0x0400EB1C RID: 60188
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ANiagaraActor> _DownParticles;

		// Token: 0x0400EB1D RID: 60189
		internal static int __PropertyOffset_32;

		// Token: 0x0400EB1E RID: 60190
		internal static int __PropertyOffset_33;

		// Token: 0x0400EB1F RID: 60191
		[Nullable(2)]
		private ResultBaer _ResultBaer;

		// Token: 0x0400EB20 RID: 60192
		internal static int __PropertyOffset_34;

		// Token: 0x0400EB21 RID: 60193
		[Nullable(2)]
		private ResultBailian _ResultBailian;

		// Token: 0x0400EB22 RID: 60194
		internal static int __PropertyOffset_35;

		// Token: 0x0400EB23 RID: 60195
		[Nullable(2)]
		private ResultJianxin _ResultJianxin;

		// Token: 0x0400EB24 RID: 60196
		internal static int __PropertyOffset_36;

		// Token: 0x0400EB25 RID: 60197
		[Nullable(2)]
		private ResultMaxiaofang _ResultMaxiaofang;

		// Token: 0x0400EB26 RID: 60198
		internal static int __PropertyOffset_37;

		// Token: 0x0400EB27 RID: 60199
		[Nullable(2)]
		private ResultMicai _ResultMicai;

		// Token: 0x0400EB28 RID: 60200
		internal static int __PropertyOffset_38;

		// Token: 0x0400EB29 RID: 60201
		[Nullable(2)]
		private ResultQiushui _ResultQiushui;

		// Token: 0x0400EB2A RID: 60202
		internal static int __PropertyOffset_39;

		// Token: 0x0400EB2B RID: 60203
		[Nullable(2)]
		private ResultSanhua _ResultSanhua;

		// Token: 0x0400EB2C RID: 60204
		internal static int __PropertyOffset_40;

		// Token: 0x0400EB2D RID: 60205
		[Nullable(2)]
		private ResultTaoqi _ResultTaoqi;

		// Token: 0x0400EB2E RID: 60206
		internal static int __PropertyOffset_41;

		// Token: 0x0400EB2F RID: 60207
		[Nullable(2)]
		private ResultYangyang _ResultYangyang;

		// Token: 0x0400EB30 RID: 60208
		internal static int __PropertyOffset_42;

		// Token: 0x0400EB31 RID: 60209
		[Nullable(2)]
		private ResultYuanwu _ResultYuanwu;

		// Token: 0x0400EB32 RID: 60210
		internal static int __PropertyOffset_43;

		// Token: 0x0400EB33 RID: 60211
		internal static int __PropertyOffset_44;

		// Token: 0x0400EB34 RID: 60212
		internal static int __PropertyOffset_45;

		// Token: 0x0400EB35 RID: 60213
		[Nullable(2)]
		private ResultJinxi _ResultJinxi;

		// Token: 0x0400EB36 RID: 60214
		internal static int __PropertyOffset_46;

		// Token: 0x0400EB37 RID: 60215
		[Nullable(2)]
		private ResultChangli _ResultChangli;

		// Token: 0x0400EB38 RID: 60216
		internal static int __PropertyOffset_47;

		// Token: 0x0400EB39 RID: 60217
		[Nullable(2)]
		private ResultMain _ResultMain;

		// Token: 0x0400EB3A RID: 60218
		internal static int __PropertyOffset_48;

		// Token: 0x0400EB3B RID: 60219
		private static IntPtr __QualityColorModification_NativeFunctionPtr;

		// Token: 0x0400EB3C RID: 60220
		private static IntPtr __IsNewWorkFlow_NativeFunctionPtr;

		// Token: 0x0400EB3D RID: 60221
		private static IntPtr __TSUpdateGachaResult_deprecated__NativeFunctionPtr;

		// Token: 0x0400EB3E RID: 60222
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0400EB3F RID: 60223
		private static IntPtr __Sanhua_NativeFunctionPtr;

		// Token: 0x0400EB40 RID: 60224
		private static IntPtr __Taoqi_NativeFunctionPtr;

		// Token: 0x0400EB41 RID: 60225
		private static IntPtr __Yangyang_NativeFunctionPtr;

		// Token: 0x0400EB42 RID: 60226
		private static IntPtr __Yuanwu_NativeFunctionPtr;

		// Token: 0x0400EB43 RID: 60227
		private static IntPtr __Kakaluo_NativeFunctionPtr;

		// Token: 0x0400EB44 RID: 60228
		private static IntPtr __Awu_NativeFunctionPtr;

		// Token: 0x0400EB45 RID: 60229
		private static IntPtr __Yinlin_NativeFunctionPtr;

		// Token: 0x0400EB46 RID: 60230
		private static IntPtr __Anke_NativeFunctionPtr;

		// Token: 0x0400EB47 RID: 60231
		private static IntPtr __CharacterGolden_NativeFunctionPtr;

		// Token: 0x0400EB48 RID: 60232
		private static IntPtr __CharacterPurple_NativeFunctionPtr;

		// Token: 0x0400EB49 RID: 60233
		private static IntPtr __WeaponGolden_NativeFunctionPtr;

		// Token: 0x0400EB4A RID: 60234
		private static IntPtr __WeaponPurple_NativeFunctionPtr;

		// Token: 0x0400EB4B RID: 60235
		private static IntPtr __WeaponNormal_NativeFunctionPtr;

		// Token: 0x0400EB4C RID: 60236
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0400EB4D RID: 60237
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EB4E RID: 60238
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EB4F RID: 60239
		private static IntPtr __Qiushui_NativeFunctionPtr;

		// Token: 0x0400EB50 RID: 60240
		private static IntPtr __Micai_NativeFunctionPtr;

		// Token: 0x0400EB51 RID: 60241
		private static IntPtr __Maxiaofang_NativeFunctionPtr;

		// Token: 0x0400EB52 RID: 60242
		private static IntPtr __Jianxin_NativeFunctionPtr;

		// Token: 0x0400EB53 RID: 60243
		private static IntPtr __Bailian_NativeFunctionPtr;

		// Token: 0x0400EB54 RID: 60244
		private static IntPtr __Baer_NativeFunctionPtr;

		// Token: 0x0400EB55 RID: 60245
		private static IntPtr __UpdateGachaShowItem_NativeFunctionPtr;

		// Token: 0x0400EB56 RID: 60246
		private static IntPtr __HiddenShowDownParticles_NativeFunctionPtr;

		// Token: 0x0400EB57 RID: 60247
		private static IntPtr __HiddenShowUpParticles_NativeFunctionPtr;

		// Token: 0x0400EB58 RID: 60248
		private static IntPtr __EndGachaScene_NativeFunctionPtr;

		// Token: 0x0400EB59 RID: 60249
		private static IntPtr __Jiyan_NativeFunctionPtr;

		// Token: 0x0400EB5A RID: 60250
		private static IntPtr __Chun_NativeFunctionPtr;

		// Token: 0x0400EB5B RID: 60251
		private static IntPtr __UpdateGacha_NativeFunctionPtr;

		// Token: 0x0400EB5C RID: 60252
		private static IntPtr __Jueyuan_NativeFunctionPtr;

		// Token: 0x0400EB5D RID: 60253
		private static IntPtr __Jinxi_NativeFunctionPtr;

		// Token: 0x0400EB5E RID: 60254
		private static IntPtr __Changli_NativeFunctionPtr;

		// Token: 0x0400EB5F RID: 60255
		private static IntPtr __ExecuteUbergraph_BP_UpdateInteract_NativeFunctionPtr;

		// Token: 0x02009740 RID: 38720
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __QualityColorModification_FunctionParams
		{
			// Token: 0x04031CB2 RID: 203954
			[FieldOffset(0)]
			public TEnumAsByte<E_GachaResultFinal> GachaResult;

			// Token: 0x04031CB3 RID: 203955
			[FieldOffset(4)]
			public int ID;

			// Token: 0x04031CB4 RID: 203956
			[FieldOffset(8)]
			public bool IsCharacter;
		}

		// Token: 0x02009741 RID: 38721
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __IsNewWorkFlow_FunctionParams
		{
			// Token: 0x04031CB5 RID: 203957
			[FieldOffset(0)]
			public bool IsNew;
		}

		// Token: 0x02009742 RID: 38722
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		protected ref struct __TSUpdateGachaResult_deprecated__FunctionParams
		{
			// Token: 0x04031CB6 RID: 203958
			[FieldOffset(0)]
			public TEnumAsByte<E_GachaResultNew> GachaResults;
		}

		// Token: 0x02009743 RID: 38723
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04031CB7 RID: 203959
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009744 RID: 38724
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031CB8 RID: 203960
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009745 RID: 38725
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __UpdateGachaShowItem_FunctionParams
		{
			// Token: 0x04031CB9 RID: 203961
			[FieldOffset(0)]
			public int ID;

			// Token: 0x04031CBA RID: 203962
			[FieldOffset(4)]
			public byte GachaResults;
		}

		// Token: 0x02009746 RID: 38726
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HiddenShowDownParticles_FunctionParams
		{
			// Token: 0x04031CBB RID: 203963
			[FieldOffset(0)]
			public bool Show_;
		}

		// Token: 0x02009747 RID: 38727
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __HiddenShowUpParticles_FunctionParams
		{
			// Token: 0x04031CBC RID: 203964
			[FieldOffset(0)]
			public bool Show_;
		}

		// Token: 0x02009748 RID: 38728
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 304)]
		protected ref struct __ExecuteUbergraph_BP_UpdateInteract_FunctionParams
		{
			// Token: 0x04031CBD RID: 203965
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
