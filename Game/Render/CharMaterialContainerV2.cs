using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200474B RID: 18251
	[NullableContext(1)]
	[Nullable(0)]
	public class CharMaterialContainerV2 : CharRenderBase
	{
		// Token: 0x0602F5BE RID: 193982 RVA: 0x00B3C01C File Offset: 0x00B3A21C
		public override void Start()
		{
			AActor cachedOwner = base.GetRenderingComponent().GetCachedOwner();
			ECharacterRenderingType? renderType = base.GetRenderingComponent().RenderType;
			if (cachedOwner == null)
			{
				return;
			}
			this.ControllerComponent = (cachedOwner.GetComponentByClass(UKuroMaterialControllerComponent.StaticClass()) as UKuroMaterialControllerComponent);
			ECharacterRenderingType? echaracterRenderingType;
			ECharacterRenderingType echaracterRenderingType2;
			if (this.ControllerComponent == null)
			{
				AActor aactor = cachedOwner;
				TSubclassOf<UActorComponent> @class = UKuroMaterialControllerComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				this.ControllerComponent = (aactor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as UKuroMaterialControllerComponent);
				echaracterRenderingType = renderType;
				echaracterRenderingType2 = ECharacterRenderingType.Sequence;
				if (!(echaracterRenderingType.GetValueOrDefault() == echaracterRenderingType2 & echaracterRenderingType != null))
				{
					echaracterRenderingType = renderType;
					echaracterRenderingType2 = ECharacterRenderingType.Default;
					if (!(echaracterRenderingType.GetValueOrDefault() == echaracterRenderingType2 & echaracterRenderingType != null))
					{
						this.ControllerComponent.SetInitTakeOver(true);
						goto IL_C1;
					}
				}
				this.ControllerComponent.SetInitTakeOver(false);
				IL_C1:
				this.ControllerComponent.InitFromOwner();
			}
			echaracterRenderingType = renderType;
			echaracterRenderingType2 = ECharacterRenderingType.LocalPlayer;
			if (echaracterRenderingType.GetValueOrDefault() == echaracterRenderingType2 & echaracterRenderingType != null)
			{
				this.ControllerComponent.SetToonCustomStencilValue(1);
			}
			this.IdentifyName = cachedOwner.GetClass().GetName();
			USkeletalMeshComponent registeredSkeletalMeshComponent = this.ControllerComponent.GetRegisteredSkeletalMeshComponent(new FName("CharacterMesh0"));
			USkeletalMesh uskeletalMesh = (registeredSkeletalMeshComponent != null) ? registeredSkeletalMeshComponent.SkeletalMesh : null;
			if (uskeletalMesh != null)
			{
				this.IdentifyName = this.IdentifyName + "_" + uskeletalMesh.GetName();
			}
			this.BodyEffect = (base.GetRenderingComponent().GetComponent(9) as CharBodyEffect);
			this.StatTick = Stat.CreateNoFlameGraph("CharMaterialContainerV2_Tick_" + this.IdentifyName, "", "");
			this.StatUpdateEffectOnly = Stat.CreateNoFlameGraph("CharMaterialContainerV2_UpdateEffectOnly_" + this.IdentifyName, "", "");
			base.OnInitSuccess();
		}

		// Token: 0x0602F5BF RID: 193983 RVA: 0x00B3C1DC File Offset: 0x00B3A3DC
		public override void Update()
		{
			LogicalTimeDilationOut logicalTimeDilationOut = new LogicalTimeDilationOut
			{
				LogicalTimeDilation = 1f
			};
			float timeDilation = this.RenderComponent.GetTimeDilation(logicalTimeDilationOut);
			this.ControllerComponent.ManualTick(base.GetDeltaTime() * timeDilation, false, false, logicalTimeDilationOut.LogicalTimeDilation);
			this.ControllerComponent.UpdateEffects();
			this.ControllerComponent.SetUpdateForce(false);
			TArray<int> tarray = this.ControllerComponent.RemoveDeadEffects();
			if (this.OnEffectFinishCallbackSet != null)
			{
				for (int i = 0; i < tarray.Num(); i++)
				{
					foreach (Action<int> action in this.OnEffectFinishCallbackSet)
					{
						action(tarray.Get(i));
					}
				}
			}
			if (this.BodyEffect != null)
			{
				float bodyOpacity = this.ControllerComponent.GetBodyOpacity();
				this.BodyEffect.SetOpacity(bodyOpacity, ECharBodyEffectOpacityType.Effect);
			}
		}

		// Token: 0x0602F5C0 RID: 193984 RVA: 0x00B3C2CC File Offset: 0x00B3A4CC
		public void UpdateEffectsOnly()
		{
			this.ControllerComponent.MarkForceUpdateAllOnce();
			this.ControllerComponent.UpdateEffects();
		}

		// Token: 0x0602F5C1 RID: 193985 RVA: 0x00B3C2E4 File Offset: 0x00B3A4E4
		public void ForceUpdateOnce()
		{
			UKuroMaterialControllerComponent controllerComponent = this.ControllerComponent;
			if (controllerComponent != null)
			{
				controllerComponent.MarkForceUpdateAllOnce();
			}
			UKuroMaterialControllerComponent controllerComponent2 = this.ControllerComponent;
			if (controllerComponent2 == null)
			{
				return;
			}
			controllerComponent2.SetUpdateForce(true);
		}

		// Token: 0x0602F5C2 RID: 193986 RVA: 0x00B3C308 File Offset: 0x00B3A508
		public void AddSkeletalComponent(USkeletalMeshComponent skeletalComp, string skelName, bool useEmptyMaterial = false)
		{
			this.ControllerComponent.AddSkeletalMeshComponent(skeletalComp, new FName(skelName), useEmptyMaterial);
		}

		// Token: 0x0602F5C3 RID: 193987 RVA: 0x00B3C31D File Offset: 0x00B3A51D
		[return: Nullable(2)]
		public USkeletalMeshComponent GetSkeletalComponent(string skelName)
		{
			return this.ControllerComponent.GetRegisteredSkeletalMeshComponent(new FName(skelName));
		}

		// Token: 0x0602F5C4 RID: 193988 RVA: 0x00B3C330 File Offset: 0x00B3A530
		public FName GetSkeletalMeshComponentBodyName(USkeletalMeshComponent skeletalComp)
		{
			return this.ControllerComponent.GetSkeletalMeshComponentBodyName(skeletalComp);
		}

		// Token: 0x0602F5C5 RID: 193989 RVA: 0x00B3C33E File Offset: 0x00B3A53E
		public void RemoveSkeletalComponent(string bodyName)
		{
			this.ControllerComponent.RemoveSkeletalMeshComponent(new FName(bodyName));
		}

		// Token: 0x0602F5C6 RID: 193990 RVA: 0x00B3C351 File Offset: 0x00B3A551
		public int AddEffect(UKuroMaterialControllerDataAsset dataAsset, bool needLoop, bool paused, [Nullable(2)] USkeletalMeshComponent animObject = null, bool hiddenAfterEffect = false)
		{
			return this.ControllerComponent.AddEffect_Ex(dataAsset, needLoop, paused, animObject, hiddenAfterEffect, -1);
		}

		// Token: 0x0602F5C7 RID: 193991 RVA: 0x00B3C366 File Offset: 0x00B3A566
		public void SetEffectLoop(int handle, bool needLoop)
		{
			this.ControllerComponent.SetHandleLoop(handle, needLoop, true, -1);
		}

		// Token: 0x0602F5C8 RID: 193992 RVA: 0x00B3C377 File Offset: 0x00B3A577
		public void SetEffectPause(int handle, bool paused)
		{
			this.ControllerComponent.SetHandlePause(handle, paused);
		}

		// Token: 0x0602F5C9 RID: 193993 RVA: 0x00B3C386 File Offset: 0x00B3A586
		public void SetEffectProgress(int handle, float progress)
		{
			this.ControllerComponent.SeekHandleFactor(handle, progress);
		}

		// Token: 0x0602F5CA RID: 193994 RVA: 0x00B3C398 File Offset: 0x00B3A598
		public void RemoveEffect(int handle)
		{
			this.ControllerComponent.RemoveEffect(handle, -1);
			if (this.OnEffectFinishCallbackSet != null)
			{
				foreach (Action<int> action in this.OnEffectFinishCallbackSet)
				{
					action(handle);
				}
			}
		}

		// Token: 0x0602F5CB RID: 193995 RVA: 0x00B3C400 File Offset: 0x00B3A600
		public void RemoveAllUnloopedEffects()
		{
			TArray<int> tarray = this.ControllerComponent.RemoveAllUnloopedEffects();
			if (this.OnEffectFinishCallbackSet != null)
			{
				for (int i = 0; i < tarray.Num(); i++)
				{
					foreach (Action<int> action in this.OnEffectFinishCallbackSet)
					{
						action(tarray.Get(i));
					}
				}
			}
		}

		// Token: 0x0602F5CC RID: 193996 RVA: 0x00B3C47C File Offset: 0x00B3A67C
		public override void OnResetRenderState()
		{
			this.ControllerComponent.RemoveAllEffects(-1);
			this.ControllerComponent.UpdateEffects();
		}

		// Token: 0x0602F5CD RID: 193997 RVA: 0x00B3C495 File Offset: 0x00B3A695
		public void SetFloatUpdateParamPermanent(FName name, float value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.AddFloatUpdateParamPermanent(name, value, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5CE RID: 193998 RVA: 0x00B3C4B0 File Offset: 0x00B3A6B0
		public void AddFloatUpdateParamPermanentByIndex(FName name, float value, FName bodyName, int materialIndex)
		{
			this.ControllerComponent.AddFloatUpdateParamPermanentByIndex(name, value, bodyName, materialIndex);
		}

		// Token: 0x0602F5CF RID: 193999 RVA: 0x00B3C4C2 File Offset: 0x00B3A6C2
		public void SetColorUpdateParamPermanent(FName name, FLinearColor value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.AddColorUpdateParamPermanent(name, value, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D0 RID: 194000 RVA: 0x00B3C4DD File Offset: 0x00B3A6DD
		public void SetTextureUpdateParamPermanent(FName name, UTexture value, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.AddTextureUpdateParamPermanent(name, value, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D1 RID: 194001 RVA: 0x00B3C4F8 File Offset: 0x00B3A6F8
		public void RemoveFloatUpdateParamPermanent(FName name, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.RemoveFloatUpdateParamPermanent(name, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D2 RID: 194002 RVA: 0x00B3C511 File Offset: 0x00B3A711
		public void RemoveColorUpdateParamPermanent(FName name, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.RemoveColorUpdateParamPermanent(name, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D3 RID: 194003 RVA: 0x00B3C52A File Offset: 0x00B3A72A
		public void RemoveTextureUpdateParamPermanent(FName name, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.RemoveTextureUpdateParamPermanent(name, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D4 RID: 194004 RVA: 0x00B3C543 File Offset: 0x00B3A743
		public void SetExternalMaterialReplace(UMaterialInterface material, EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.SetExternalMaterialReplace(material, bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D5 RID: 194005 RVA: 0x00B3C55C File Offset: 0x00B3A75C
		public void SetExternalMaterialReplaceByIndex(UMaterialInterface material, FName bodyName, int materialIndex)
		{
			this.ControllerComponent.SetExternalMaterialReplaceByIndex(material, bodyName, materialIndex);
		}

		// Token: 0x0602F5D6 RID: 194006 RVA: 0x00B3C56C File Offset: 0x00B3A76C
		public void RemoveExternalMaterialReplace(EKuroCharBodySpecifiedType bodyType, EKuroCharSlotSpecifiedType slotType, EKuroCharMeshPart? meshPart = null)
		{
			this.ControllerComponent.RemoveExternalMaterialReplace(bodyType, slotType, meshPart.GetValueOrDefault(EKuroCharMeshPart.ECharacterMeshPart_Max));
		}

		// Token: 0x0602F5D7 RID: 194007 RVA: 0x00B3C584 File Offset: 0x00B3A784
		public void RemoveExternalMaterialReplaceByIndex(FName bodyName, int materialIndex)
		{
			this.ControllerComponent.RemoveExternalMaterialReplaceByIndex(bodyName, materialIndex);
		}

		// Token: 0x0602F5D8 RID: 194008 RVA: 0x00B3C593 File Offset: 0x00B3A793
		public void AddAlphaTestCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.AddExternalAlphaTestRefCount(bodyType);
		}

		// Token: 0x0602F5D9 RID: 194009 RVA: 0x00B3C5A1 File Offset: 0x00B3A7A1
		public void AddOutlineStencilTestCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.AddExternalOutlineStencilTestRefCount(bodyType);
		}

		// Token: 0x0602F5DA RID: 194010 RVA: 0x00B3C5AF File Offset: 0x00B3A7AF
		public void AddBattleCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.AddExternalBattleRefCount(bodyType);
		}

		// Token: 0x0602F5DB RID: 194011 RVA: 0x00B3C5BD File Offset: 0x00B3A7BD
		public void AddBattleMaskCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.AddExternalBattleMaskRefCount(bodyType);
		}

		// Token: 0x0602F5DC RID: 194012 RVA: 0x00B3C5CB File Offset: 0x00B3A7CB
		public void RemoveAlphaTestCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.RemoveExternalAlphaTestRefCount(bodyType);
		}

		// Token: 0x0602F5DD RID: 194013 RVA: 0x00B3C5D9 File Offset: 0x00B3A7D9
		public void RemoveOutlineStencilTestCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.RemoveExternalOutlineStencilTestRefCount(bodyType);
		}

		// Token: 0x0602F5DE RID: 194014 RVA: 0x00B3C5E7 File Offset: 0x00B3A7E7
		public void RemoveBattleCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.RemoveExternalBattleRefCount(bodyType);
		}

		// Token: 0x0602F5DF RID: 194015 RVA: 0x00B3C5F5 File Offset: 0x00B3A7F5
		public void RemoveBattleMaskCount(EKuroCharBodySpecifiedType bodyType)
		{
			this.ControllerComponent.RemoveExternalBattleMaskRefCount(bodyType);
		}

		// Token: 0x0602F5E0 RID: 194016 RVA: 0x00B3C603 File Offset: 0x00B3A803
		public void SetNoWater(bool value)
		{
			this.ControllerComponent.SetAllBodyNoWater(value);
		}

		// Token: 0x0602F5E1 RID: 194017 RVA: 0x00B3C611 File Offset: 0x00B3A811
		public void AddEffectFinishCallback(Action<int> callback)
		{
			if (this.OnEffectFinishCallbackSet == null)
			{
				this.OnEffectFinishCallbackSet = new HashSet<Action<int>>();
			}
			if (this.OnEffectFinishCallbackSet.Contains(callback))
			{
				return;
			}
			this.OnEffectFinishCallbackSet.Add(callback);
		}

		// Token: 0x0602F5E2 RID: 194018 RVA: 0x00B3C642 File Offset: 0x00B3A842
		public void RemoveEffectFinishCallback(Action<int> callback)
		{
			if (this.OnEffectFinishCallbackSet == null)
			{
				return;
			}
			this.OnEffectFinishCallbackSet.Remove(callback);
		}

		// Token: 0x0602F5E3 RID: 194019 RVA: 0x00B3C65A File Offset: 0x00B3A85A
		public bool GetAnyUnloopEffect()
		{
			return this.ControllerComponent.GetAnyUnloopEffect();
		}

		// Token: 0x0602F5E4 RID: 194020 RVA: 0x00B3C668 File Offset: 0x00B3A868
		public void EnableTickGetHeadPosInAllMeshes(bool enable)
		{
			TArray<FName> allRegisteredBodyNames = this.ControllerComponent.GetAllRegisteredBodyNames();
			int num = allRegisteredBodyNames.Num();
			for (int i = 0; i < num; i++)
			{
				FName bodyName = allRegisteredBodyNames.Get(i);
				USkeletalMeshComponent registeredSkeletalMeshComponent = this.ControllerComponent.GetRegisteredSkeletalMeshComponent(bodyName);
				string text = (registeredSkeletalMeshComponent != null) ? registeredSkeletalMeshComponent.GetAttachSocketName().ToString() : null;
				if (text != null && (text.Contains("Head") || text.Contains("Hair") || text.Contains("Neck")))
				{
					if (enable)
					{
						UKuroMaterialControllerComponent controllerComponent = this.ControllerComponent;
						if (controllerComponent != null)
						{
							controllerComponent.AddFloatUpdateParamPermanentCustom(RenderConfig.DitherUseInRayTracing, 0f, bodyName, EKuroCharSlotSpecifiedType.All, "");
						}
					}
					else
					{
						UKuroMaterialControllerComponent controllerComponent2 = this.ControllerComponent;
						if (controllerComponent2 != null)
						{
							controllerComponent2.RemoveFloatUpdateParamPermanentCustom(RenderConfig.DitherUseInRayTracing, bodyName, EKuroCharSlotSpecifiedType.All, "");
						}
					}
				}
				else if (enable)
				{
					if (registeredSkeletalMeshComponent != null)
					{
						registeredSkeletalMeshComponent.EnableTickGetHeadBonePos(enable);
					}
					UKuroMaterialControllerComponent controllerComponent3 = this.ControllerComponent;
					if (controllerComponent3 != null)
					{
						controllerComponent3.AddFloatUpdateParamPermanentCustom(RenderConfig.UseHeadMaskHideEffect, 1f, bodyName, EKuroCharSlotSpecifiedType.All, "");
					}
					UKuroMaterialControllerComponent controllerComponent4 = this.ControllerComponent;
					if (controllerComponent4 != null)
					{
						controllerComponent4.AddFloatUpdateParamPermanentCustom(RenderConfig.DitherUseInRayTracing, 0f, bodyName, EKuroCharSlotSpecifiedType.All, "");
					}
					foreach (string customPartName in this.MeshPartHeadNamesArray)
					{
						UKuroMaterialControllerComponent controllerComponent5 = this.ControllerComponent;
						if (controllerComponent5 != null)
						{
							controllerComponent5.AddFloatUpdateParamPermanentCustom(RenderConfig.UseHeadMaskHideEffect, 0f, bodyName, EKuroCharSlotSpecifiedType.All, customPartName);
						}
					}
				}
				else
				{
					UKuroMaterialControllerComponent controllerComponent6 = this.ControllerComponent;
					if (controllerComponent6 != null)
					{
						controllerComponent6.RemoveFloatUpdateParamPermanentCustom(RenderConfig.UseHeadMaskHideEffect, bodyName, EKuroCharSlotSpecifiedType.All, "");
					}
					UKuroMaterialControllerComponent controllerComponent7 = this.ControllerComponent;
					if (controllerComponent7 != null)
					{
						controllerComponent7.RemoveFloatUpdateParamPermanentCustom(RenderConfig.DitherUseInRayTracing, bodyName, EKuroCharSlotSpecifiedType.All, "");
					}
				}
			}
		}

		// Token: 0x0602F5E5 RID: 194021 RVA: 0x00B3C822 File Offset: 0x00B3AA22
		public override void Destroy()
		{
		}

		// Token: 0x0602F5E6 RID: 194022 RVA: 0x00B3C824 File Offset: 0x00B3AA24
		public override string GetStatName()
		{
			return "CharMaterialContainerV2";
		}

		// Token: 0x0602F5E7 RID: 194023 RVA: 0x00B3C82B File Offset: 0x00B3AA2B
		public override int GetComponentId()
		{
			return 13;
		}

		// Token: 0x0401AF7E RID: 110462
		[Nullable(2)]
		private UKuroMaterialControllerComponent ControllerComponent;

		// Token: 0x0401AF7F RID: 110463
		[Nullable(2)]
		private Stat StatTick;

		// Token: 0x0401AF80 RID: 110464
		[Nullable(2)]
		private Stat StatUpdateEffectOnly;

		// Token: 0x0401AF81 RID: 110465
		public string IdentifyName = string.Empty;

		// Token: 0x0401AF82 RID: 110466
		[Nullable(2)]
		private CharBodyEffect BodyEffect;

		// Token: 0x0401AF83 RID: 110467
		public string[] MeshPartHeadNamesArray = new string[]
		{
			"Bangs",
			"Hair",
			"Head",
			"Face",
			"Eye"
		};

		// Token: 0x0401AF84 RID: 110468
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private HashSet<Action<int>> OnEffectFinishCallbackSet;
	}
}
