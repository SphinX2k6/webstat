using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004753 RID: 18259
	[NullableContext(1)]
	[Nullable(0)]
	public class CharMaterialContainer : CharRenderBase
	{
		// Token: 0x0602F636 RID: 194102 RVA: 0x00B3E86B File Offset: 0x00B3CA6B
		public void MarkForceUpdateThisFrame()
		{
			this.ForceUpdateThisFrame = true;
		}

		// Token: 0x0602F637 RID: 194103 RVA: 0x00B3E874 File Offset: 0x00B3CA74
		public int GetMaxUpdateParamsPerFrame()
		{
			if (this.MaxUpdateParamsPerFrame < 0)
			{
				this.MaxUpdateParamsPerFrame = (Singleton<Info>.Instance.IsGameRunning() ? (GlobalData.IsEs3 ? 16 : 32) : 9999);
			}
			return this.MaxUpdateParamsPerFrame;
		}

		// Token: 0x0602F638 RID: 194104 RVA: 0x00B3E8AC File Offset: 0x00B3CAAC
		public unsafe override void Awake(CharRenderingComponent renderComponent)
		{
			base.Awake(renderComponent);
			AActor owner = this.RenderComponent.GetOwner();
			if (owner == null || !owner.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.MY, "Actor 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.OwnerActorName = owner.GetName();
			this.AllBodyInfoList = new Dictionary<string, CharBodyInfo>();
			TArray<UActorComponent> tarray = owner.K2_GetComponentsByClass(USkeletalMeshComponent.StaticClass());
			int num = tarray.Num();
			bool flag = false;
			bool flag2 = false;
			List<USkeletalMeshComponent> list = new List<USkeletalMeshComponent>();
			for (int i = 0; i < num; i++)
			{
				USkeletalMeshComponent uskeletalMeshComponent = tarray.Get(i) as USkeletalMeshComponent;
				if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderCharacter;
					ELogAuthor author = ELogAuthor.ZJF;
					string message = "材质容器初始化失败，组件不可用";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerActorName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					string name = uskeletalMeshComponent.GetName();
					if (uskeletalMeshComponent.SkeletalMesh == null || !uskeletalMeshComponent.SkeletalMesh.IsValid())
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.RenderCharacter;
						ELogAuthor author2 = ELogAuthor.ZJF;
						string message2 = "资产的SkeletalMeshComponent的SkeletalMesh为空";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.OwnerActorName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkeletalName", name);
						instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					else
					{
						if (RenderConfig.GetBodyTypeByName(name) == ECharacterBodyType.Body)
						{
							flag2 = true;
						}
						flag = (flag || this.AddSkeletalComponent(uskeletalMeshComponent, name, false));
					}
				}
			}
			if (!flag2 && list.Count > 0)
			{
				flag = (flag || this.AddSkeletalComponent(list[0], RenderConfig.MaterialControlBodyCaseArray[0], false));
				list.RemoveAt(0);
			}
			foreach (USkeletalMeshComponent uskeletalMeshComponent2 in list)
			{
				flag = (flag || this.AddSkeletalComponent(uskeletalMeshComponent2, uskeletalMeshComponent2.GetName(), false));
			}
			if (!flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.RenderCharacter;
				ELogAuthor author3 = ELogAuthor.MY;
				string message3 = "无Mesh类型材质控制器初始化";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			base.OnInitSuccess();
			string name2 = "Render_CharMaterialContainer_" + this.OwnerActorName;
			this.StatTick = Stat.CreateNoFlameGraph(name2, "", "");
		}

		// Token: 0x0602F639 RID: 194105 RVA: 0x00B3EB18 File Offset: 0x00B3CD18
		public unsafe bool AddSkeletalComponent(USkeletalMeshComponent skeletalComp, string skelName, bool useEmptyMaterial = false)
		{
			if (string.IsNullOrEmpty(skelName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "角色骨骼名称错误";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (skeletalComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "外部传入了空的SkeletalMeshComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			if (skeletalComp.GetOwner() == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.RenderCharacter;
				ELogAuthor author3 = ELogAuthor.ZJF;
				string message3 = "外部传入的SkeletalMeshComponent的Owner为空";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			if (skeletalComp.SkeletalMesh == null)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.RenderCharacter;
				ELogAuthor author4 = ELogAuthor.MY;
				string message4 = "外部传入的SkeletalMeshComponent的SkeletalMesh为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SkeletalName", skelName);
				instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			bool bHiddenInGame = skeletalComp.bHiddenInGame;
			if (bHiddenInGame)
			{
				skeletalComp.SetHiddenInGame(false, false);
			}
			CharBodyInfo charBodyInfo = new CharBodyInfo();
			charBodyInfo.Init(this.OwnerActorName, skelName, skeletalComp, this, useEmptyMaterial);
			this.AllBodyInfoList.Add(skelName, charBodyInfo);
			if (bHiddenInGame)
			{
				skeletalComp.SetHiddenInGame(true, false);
			}
			return true;
		}

		// Token: 0x0602F63A RID: 194106 RVA: 0x00B3EC63 File Offset: 0x00B3CE63
		public bool RemoveSkeletalComponent(string bodyName)
		{
			if (this.AllBodyInfoList.ContainsKey(bodyName))
			{
				this.AllBodyInfoList.Remove(bodyName);
				return true;
			}
			return false;
		}

		// Token: 0x0602F63B RID: 194107 RVA: 0x00B3EC84 File Offset: 0x00B3CE84
		public void ResetAllState()
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				charBodyInfo.ResetAllState();
			}
		}

		// Token: 0x0602F63C RID: 194108 RVA: 0x00B3ECDC File Offset: 0x00B3CEDC
		public void UseAlphaTestCommon()
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				charBodyInfo.UseAlphaTestCommon();
			}
		}

		// Token: 0x0602F63D RID: 194109 RVA: 0x00B3ED34 File Offset: 0x00B3CF34
		public void RevertAlphaTestCommon()
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				charBodyInfo.RevertAlphaTestCommon();
			}
		}

		// Token: 0x0602F63E RID: 194110 RVA: 0x00B3ED8C File Offset: 0x00B3CF8C
		public void SetColor(FName? propertyName, FLinearColor color, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(propertyName))
			{
				return;
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.SetColor(propertyName.Value, color, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F63F RID: 194111 RVA: 0x00B3EDE0 File Offset: 0x00B3CFE0
		public void RevertColor(FName propertyName, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(new FName?(propertyName)))
			{
				return;
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.RevertColor(propertyName, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F640 RID: 194112 RVA: 0x00B3EE30 File Offset: 0x00B3D030
		public void SetFloat(FName? propertyName, float value, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(propertyName))
			{
				return;
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.SetFloat(propertyName.Value, value, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F641 RID: 194113 RVA: 0x00B3EE84 File Offset: 0x00B3D084
		public void RevertFloat(FName propertyName, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(new FName?(propertyName)))
			{
				return;
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.RevertFloat(propertyName, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F642 RID: 194114 RVA: 0x00B3EED4 File Offset: 0x00B3D0D4
		[NullableContext(2)]
		public void SetTexture(FName propertyName, UTexture texture, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(new FName?(propertyName)))
			{
				return;
			}
			if (texture == null)
			{
				return;
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.SetTexture(propertyName, texture, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F643 RID: 194115 RVA: 0x00B3EF2C File Offset: 0x00B3D12C
		public void RevertTexture(FName propertyName, ECharacterBodySpecifiedType specifiedBodyType = ECharacterBodySpecifiedType.All, int sectionIndex = -1, ECharacterSlotSpecifiedType specifiedSlotType = ECharacterSlotSpecifiedType.All)
		{
			if (FNameUtil.IsEmpty(new FName?(propertyName)))
			{
				return;
			}
			if (sectionIndex >= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.ZJF, "SetColor: 不支持指定SectionIndex", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			foreach (string key in RenderConfig.GetBodyNamesByBodyType(specifiedBodyType))
			{
				CharBodyInfo charBodyInfo;
				if (this.AllBodyInfoList.TryGetValue(key, out charBodyInfo) && charBodyInfo != null)
				{
					charBodyInfo.RevertTexture(propertyName, specifiedSlotType);
				}
			}
		}

		// Token: 0x0602F644 RID: 194116 RVA: 0x00B3EFA0 File Offset: 0x00B3D1A0
		public void SetStarScarEnergy(float value)
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				charBodyInfo.SetStarScarEnergy(value);
			}
		}

		// Token: 0x0602F645 RID: 194117 RVA: 0x00B3EFF8 File Offset: 0x00B3D1F8
		public void SetNoWater(bool value)
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				charBodyInfo.SetNoWater(value);
			}
		}

		// Token: 0x0602F646 RID: 194118 RVA: 0x00B3F050 File Offset: 0x00B3D250
		public override void LateUpdate()
		{
			this.UpdateCounter++;
			AActor cachedOwner = base.GetRenderingComponent().GetCachedOwner();
			EMaterialShadingRate? meshShadingRate = null;
			ACharacter acharacter = cachedOwner as ACharacter;
			if (acharacter != null && acharacter != Global.BaseCharacter)
			{
				double num = acharacter.D_GetVelocity().SizeSquared();
				int[] motionVelocitySquared = CharRenderingComponent.MotionVelocitySquared;
				meshShadingRate = new EMaterialShadingRate?(EMaterialShadingRate.MSR_1x1);
				for (int i = motionVelocitySquared.Length - 1; i >= 0; i--)
				{
					if (num > (double)motionVelocitySquared[i])
					{
						meshShadingRate = new EMaterialShadingRate?(CharRenderingComponent.MotionMeshShadingRate[i]);
						break;
					}
				}
			}
			List<CharBodyInfo> list = new List<CharBodyInfo>();
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].LastUpdateCounter > charBodyInfo.LastUpdateCounter)
					{
						list.Insert(j, charBodyInfo);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(charBodyInfo);
				}
			}
			int num2 = this.ForceUpdateThisFrame ? 9999 : this.GetMaxUpdateParamsPerFrame();
			this.ForceUpdateThisFrame = false;
			int num3 = 0;
			foreach (CharBodyInfo charBodyInfo2 in list)
			{
				num3 += charBodyInfo2.Update(meshShadingRate);
				charBodyInfo2.LastUpdateCounter = this.UpdateCounter;
				if (num3 > num2)
				{
					break;
				}
			}
		}

		// Token: 0x0602F647 RID: 194119 RVA: 0x00B3F1F0 File Offset: 0x00B3D3F0
		public override void Destroy()
		{
			foreach (CharBodyInfo charBodyInfo in this.AllBodyInfoList.Values)
			{
				if (charBodyInfo.SkeletalComp != null && charBodyInfo.SkeletalComp.IsValid())
				{
					charBodyInfo.Update(null);
				}
			}
			this.AllBodyInfoList.Clear();
		}

		// Token: 0x0602F648 RID: 194120 RVA: 0x00B3F274 File Offset: 0x00B3D474
		public override int GetComponentId()
		{
			return 1;
		}

		// Token: 0x0602F649 RID: 194121 RVA: 0x00B3F277 File Offset: 0x00B3D477
		public override string GetStatName()
		{
			return "CharMaterialContainer";
		}

		// Token: 0x0602F64A RID: 194122 RVA: 0x00B3F280 File Offset: 0x00B3D480
		public void StateEnter(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			runtimeData.HasReverted = false;
			ECharacterControllerApplyType? materialModifyType = dataCache.MaterialModifyType;
			ECharacterControllerApplyType echaracterControllerApplyType = ECharacterControllerApplyType.ModifyProperty;
			if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
			{
				if (dataCache.UseRim)
				{
					this.StartRim(runtimeData);
				}
				if (dataCache.UseDissolve)
				{
					this.OnStartDissolve(runtimeData);
				}
				if (dataCache.UseOutline)
				{
					this.OnStartOutline(runtimeData);
				}
				if (dataCache.UseColor)
				{
					this.StartColor(runtimeData);
				}
				if (dataCache.UseTextureSample)
				{
					this.StartSampleTexture(runtimeData);
				}
				if (dataCache.UseMotionOffset)
				{
					this.OnStartMotionOffset(runtimeData);
				}
				if (dataCache.UseDitherEffect)
				{
					this.OnStartDither(runtimeData);
					return;
				}
			}
			else
			{
				materialModifyType = dataCache.MaterialModifyType;
				echaracterControllerApplyType = ECharacterControllerApplyType.ReplaceMaterial;
				if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
				{
					this.OnStartMaterialReplace(runtimeData);
				}
			}
		}

		// Token: 0x0602F64B RID: 194123 RVA: 0x00B3F348 File Offset: 0x00B3D548
		public void StateUpdate(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			ECharacterControllerApplyType? materialModifyType = dataCache.MaterialModifyType;
			ECharacterControllerApplyType echaracterControllerApplyType = ECharacterControllerApplyType.ModifyProperty;
			if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
			{
				if (dataCache.UseRim)
				{
					this.OnUpdateRim(runtimeData);
				}
				if (dataCache.UseDissolve)
				{
					this.OnUpdateDissolve(runtimeData);
				}
				if (dataCache.UseOutline)
				{
					this.OnUpdateOutline(runtimeData);
				}
				if (dataCache.UseColor)
				{
					this.OnUpdateColor(runtimeData);
				}
				if (dataCache.UseTextureSample)
				{
					this.OnUpdateSampleTexture(runtimeData);
				}
				if (dataCache.UseMotionOffset)
				{
					this.OnUpdateMotionOffset(runtimeData);
				}
				if (dataCache.UseDitherEffect)
				{
					this.OnUpdateDither(runtimeData);
				}
				if (dataCache.UseCustomMaterialEffect)
				{
					this.OnUpdateCustomMaterialEffect(runtimeData);
					return;
				}
			}
			else
			{
				materialModifyType = dataCache.MaterialModifyType;
				echaracterControllerApplyType = ECharacterControllerApplyType.ReplaceMaterial;
				if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
				{
					this.OnUpdateMaterialReplace(runtimeData);
				}
			}
		}

		// Token: 0x0602F64C RID: 194124 RVA: 0x00B3F418 File Offset: 0x00B3D618
		public unsafe void StateRevert(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			if (runtimeData.HasReverted)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "已经执行过Revert逻辑";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DataAsset", dataCache.DataName);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			runtimeData.HasReverted = true;
			ECharacterControllerApplyType? materialModifyType = dataCache.MaterialModifyType;
			ECharacterControllerApplyType echaracterControllerApplyType = ECharacterControllerApplyType.ModifyProperty;
			if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
			{
				if (dataCache.UseRim)
				{
					this.OnRevertRim(runtimeData);
				}
				if (dataCache.UseDissolve)
				{
					this.OnRevertDissolve(runtimeData);
				}
				if (dataCache.UseOutline)
				{
					this.OnRevertOutline(runtimeData);
				}
				if (dataCache.UseColor)
				{
					this.OnRevertColor(runtimeData);
				}
				if (dataCache.UseTextureSample)
				{
					this.OnRevertSampleTexture(runtimeData);
				}
				if (dataCache.UseMotionOffset)
				{
					this.OnRevertMotionOffset(runtimeData);
				}
				if (dataCache.UseDitherEffect)
				{
					this.OnRevertDither(runtimeData);
				}
				if (dataCache.UseCustomMaterialEffect)
				{
					this.OnRevertCustomMaterialEffect(runtimeData);
				}
			}
			else
			{
				materialModifyType = dataCache.MaterialModifyType;
				echaracterControllerApplyType = ECharacterControllerApplyType.ReplaceMaterial;
				if (materialModifyType.GetValueOrDefault() == echaracterControllerApplyType & materialModifyType != null)
				{
					this.OnRevertMaterialReplace(runtimeData);
				}
			}
			if (dataCache.HiddenAfterEffect)
			{
				foreach (string key in runtimeData.SpecifiedMaterialIndexMap.Keys)
				{
					CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
					if (valueOrDefault.SkeletalComp != null && valueOrDefault.SkeletalComp.IsValid())
					{
						valueOrDefault.SkeletalComp.SetHiddenInGame(true, false);
					}
				}
			}
		}

		// Token: 0x0602F64D RID: 194125 RVA: 0x00B3F5D8 File Offset: 0x00B3D7D8
		private void OnStartMaterialReplace(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			if (dataCache.ReplaceMaterialInterface == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "材质替换失败，不存在替换材质";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("替换材质名称", dataCache.DataName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			runtimeData.ReplaceMaterial = UKismetMaterialLibrary.CreateDynamicMaterialInstance(base.GetRenderingComponent(), dataCache.ReplaceMaterialInterface, default(FName), EMIDCreationFlags.None);
			if (runtimeData.ReplaceMaterial == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "材质替换失败，不存在替换材质:";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("替换材质名称", dataCache.DataName);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.TempReplaceMaterialBodies.Clear();
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				this.TempReplaceMaterialBodies.Add(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					if (dataCache.RevertMaterial)
					{
						charMaterialSlot.SetReplaceMaterial(runtimeData.ReplaceMaterial);
					}
					else
					{
						charMaterialSlot.SetDynamicMaterial(runtimeData.ReplaceMaterial);
					}
				}
			}
		}

		// Token: 0x0602F64E RID: 194126 RVA: 0x00B3F744 File Offset: 0x00B3D944
		private void OnUpdateMaterialReplace(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			if (!dataCache.UseParameterModify)
			{
				return;
			}
			UMaterialInstanceDynamic replaceMaterial = runtimeData.ReplaceMaterial;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			if (dataCache.FloatParameterNames != null)
			{
				for (int i = 0; i < dataCache.FloatParameterNames.Length; i++)
				{
					float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.FloatParameterValues[i], interpolateFactor);
					replaceMaterial.SetScalarParameterValue(dataCache.FloatParameterNames[i], floatFromGroup);
				}
			}
			if (dataCache.ColorParameterNames != null)
			{
				for (int j = 0; j < dataCache.ColorParameterNames.Length; j++)
				{
					FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.ColorParameterValues[j], interpolateFactor);
					replaceMaterial.SetVectorParameterValue(dataCache.ColorParameterNames[j], colorFromGroup);
				}
			}
		}

		// Token: 0x0602F64F RID: 194127 RVA: 0x00B3F7F4 File Offset: 0x00B3D9F4
		private void OnRevertMaterialReplace(CharMaterialControlRuntimeData runtimeData)
		{
			if (!runtimeData.DataCache.RevertMaterial)
			{
				return;
			}
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					valueOrDefault.MaterialSlotList[value[i]].RevertReplaceMaterial(runtimeData.ReplaceMaterial);
				}
			}
			runtimeData.ReplaceMaterial = null;
		}

		// Token: 0x0602F650 RID: 194128 RVA: 0x00B3F8A4 File Offset: 0x00B3DAA4
		private void StartRim(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseBattleCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseBattle(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F651 RID: 194129 RVA: 0x00B3F96C File Offset: 0x00B3DB6C
		private void OnUpdateRim(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.RimRange, interpolateFactor);
			FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.RimColor, interpolateFactor);
			float floatFromGroup2 = RenderUtil.GetFloatFromGroup(dataCache.RimIntensity, interpolateFactor);
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.UseRim, 1f);
					charMaterialSlot.SetFloat(RenderConfig.RimUseTex, (float)dataCache.RimUseTex);
					charMaterialSlot.SetColor(RenderConfig.RimChannel, dataCache.RimChannel.Value);
					charMaterialSlot.SetFloat(RenderConfig.RimRange, floatFromGroup);
					charMaterialSlot.SetColor(RenderConfig.RimColor, colorFromGroup);
					charMaterialSlot.SetFloat(RenderConfig.RimIntensity, floatFromGroup2);
				}
			}
		}

		// Token: 0x0602F652 RID: 194130 RVA: 0x00B3FA9C File Offset: 0x00B3DC9C
		private void OnRevertRim(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertBattleCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.UseRim);
					charMaterialSlot.RevertProperty(RenderConfig.RimUseTex);
					charMaterialSlot.RevertProperty(RenderConfig.RimChannel);
					charMaterialSlot.RevertProperty(RenderConfig.RimRange);
					charMaterialSlot.RevertProperty(RenderConfig.RimColor);
					charMaterialSlot.RevertProperty(RenderConfig.RimIntensity);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertBattle(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F653 RID: 194131 RVA: 0x00B3FBB4 File Offset: 0x00B3DDB4
		private void OnStartDissolve(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseBattleMaskCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseBattleMask(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F654 RID: 194132 RVA: 0x00B3FC7C File Offset: 0x00B3DE7C
		private void OnUpdateDissolve(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.DissolveProgress, interpolateFactor);
			float floatFromGroup2 = RenderUtil.GetFloatFromGroup(dataCache.DissolveSmooth, interpolateFactor);
			float floatFromGroup3 = RenderUtil.GetFloatFromGroup(dataCache.DissolveColorIntensity, interpolateFactor);
			FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.DissolveColor, interpolateFactor);
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.UseDissolve, 1f);
					charMaterialSlot.SetColor(RenderConfig.DissolveChannelSwitch, dataCache.DissolveChannel.Value);
					charMaterialSlot.SetFloat(RenderConfig.DissolveProgress, floatFromGroup);
					charMaterialSlot.SetFloat(RenderConfig.DissolveSmooth, floatFromGroup2);
					charMaterialSlot.SetFloat(RenderConfig.DissolveMulti, floatFromGroup3);
					charMaterialSlot.SetColor(RenderConfig.DissolveEmission, colorFromGroup);
				}
			}
		}

		// Token: 0x0602F655 RID: 194133 RVA: 0x00B3FDB4 File Offset: 0x00B3DFB4
		private void OnRevertDissolve(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertBattleMaskCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.UseDissolve);
					charMaterialSlot.RevertProperty(RenderConfig.DissolveChannelSwitch);
					charMaterialSlot.RevertProperty(RenderConfig.DissolveProgress);
					charMaterialSlot.RevertProperty(RenderConfig.DissolveSmooth);
					charMaterialSlot.RevertProperty(RenderConfig.DissolveMulti);
					charMaterialSlot.RevertProperty(RenderConfig.DissolveEmission);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertBattleMask(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F656 RID: 194134 RVA: 0x00B3FECC File Offset: 0x00B3E0CC
		private void OnStartOutline(CharMaterialControlRuntimeData runtimeData)
		{
			if (!runtimeData.DataCache.UseOuterOutlineEffect)
			{
				return;
			}
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseOutlineStencilTestCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseOutlineStencilTest(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F657 RID: 194135 RVA: 0x00B3FFA0 File Offset: 0x00B3E1A0
		private void OnUpdateOutline(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.OutlineWidth, interpolateFactor);
			FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.OutlineColor, interpolateFactor);
			float floatFromGroup2 = RenderUtil.GetFloatFromGroup(dataCache.OutlineIntensity, interpolateFactor);
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.OutlineUseTex, dataCache.OutlineUseTex);
					charMaterialSlot.SetFloat(RenderConfig.OutlineWidth, floatFromGroup);
					charMaterialSlot.SetColor(RenderConfig.OutlineColor, colorFromGroup);
					charMaterialSlot.SetFloat(RenderConfig.OutlineColorIntensity, floatFromGroup2);
				}
			}
		}

		// Token: 0x0602F658 RID: 194136 RVA: 0x00B400A8 File Offset: 0x00B3E2A8
		private void OnRevertOutline(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertOutlineStencilTestCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.OutlineUseTex);
					charMaterialSlot.RevertProperty(RenderConfig.OutlineWidth);
					charMaterialSlot.RevertProperty(RenderConfig.OutlineColor);
					charMaterialSlot.RevertProperty(RenderConfig.OutlineColorIntensity);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertOutlineStencilTest(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F659 RID: 194137 RVA: 0x00B401A4 File Offset: 0x00B3E3A4
		private void StartColor(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseBattleCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseBattle(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F65A RID: 194138 RVA: 0x00B4026C File Offset: 0x00B3E46C
		private void OnUpdateColor(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			if (!dataCache.UseColor)
			{
				return;
			}
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.BaseColor, interpolateFactor);
			FLinearColor colorFromGroup2 = RenderUtil.GetColorFromGroup(dataCache.EmissionColor, interpolateFactor);
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.EmissionIntensity, interpolateFactor);
			float floatFromGroup2 = RenderUtil.GetFloatFromGroup(dataCache.BaseColorIntensity, interpolateFactor);
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.BaseUseTex, dataCache.BaseUseTex);
					charMaterialSlot.SetColor(RenderConfig.BaseColor, colorFromGroup);
					charMaterialSlot.SetFloat(RenderConfig.BaseColorIntensity, floatFromGroup2);
					charMaterialSlot.SetFloat(RenderConfig.EmissionUseTex, dataCache.EmissionUseTex);
					charMaterialSlot.SetColor(RenderConfig.EmissionColor, colorFromGroup2);
					charMaterialSlot.SetFloat(RenderConfig.EmissionIntensity, floatFromGroup);
				}
			}
		}

		// Token: 0x0602F65B RID: 194139 RVA: 0x00B403A8 File Offset: 0x00B3E5A8
		private void OnRevertColor(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertBattleCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.BaseUseTex);
					charMaterialSlot.RevertProperty(RenderConfig.BaseColor);
					charMaterialSlot.RevertProperty(RenderConfig.BaseColorIntensity);
					charMaterialSlot.RevertProperty(RenderConfig.EmissionUseTex);
					charMaterialSlot.RevertProperty(RenderConfig.EmissionColor);
					charMaterialSlot.RevertProperty(RenderConfig.EmissionIntensity);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertBattle(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F65C RID: 194140 RVA: 0x00B404C0 File Offset: 0x00B3E6C0
		private void StartSampleTexture(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseBattleCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseBattle(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F65D RID: 194141 RVA: 0x00B40588 File Offset: 0x00B3E788
		private void OnUpdateSampleTexture(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.TextureScaleAndOffset, interpolateFactor);
			FLinearColor colorFromGroup2 = RenderUtil.GetColorFromGroup(dataCache.TextureSpeed, interpolateFactor);
			FLinearColor colorFromGroup3 = RenderUtil.GetColorFromGroup(dataCache.TextureColorTint, interpolateFactor);
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.Rotation, interpolateFactor);
			float floatFromGroup2 = RenderUtil.GetFloatFromGroup(dataCache.TextureMaskRange, interpolateFactor);
			UTexture2D maskTexture = dataCache.MaskTexture;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.UseTexture, 1f);
					charMaterialSlot.SetFloat(RenderConfig.TextureUseMask, dataCache.UseAlphaToMask);
					charMaterialSlot.SetFloat(RenderConfig.TextureMaskRange, floatFromGroup2);
					charMaterialSlot.SetColor(RenderConfig.TextureScaleAndOffset, colorFromGroup);
					charMaterialSlot.SetColor(RenderConfig.TextureSpeed, colorFromGroup2);
					charMaterialSlot.SetColor(RenderConfig.TextureColor, colorFromGroup3);
					charMaterialSlot.SetFloat(RenderConfig.TextureRotation, floatFromGroup);
					charMaterialSlot.SetFloat(RenderConfig.TextureUseScreenUv, dataCache.UseScreenUv);
					if (maskTexture != null)
					{
						charMaterialSlot.SetTexture(RenderConfig.NoiseTexture, maskTexture);
					}
					charMaterialSlot.SetColor(RenderConfig.TextureUvSwitch, dataCache.UvSelection.Value);
				}
			}
		}

		// Token: 0x0602F65E RID: 194142 RVA: 0x00B40734 File Offset: 0x00B3E934
		private void OnRevertSampleTexture(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertBattleCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.UseTexture);
					charMaterialSlot.RevertProperty(RenderConfig.TextureUseScreenUv);
					charMaterialSlot.RevertProperty(RenderConfig.TextureUseMask);
					charMaterialSlot.RevertProperty(RenderConfig.TextureMaskRange);
					charMaterialSlot.RevertProperty(RenderConfig.TextureUvSwitch);
					charMaterialSlot.RevertProperty(RenderConfig.TextureScaleAndOffset);
					charMaterialSlot.RevertProperty(RenderConfig.TextureSpeed);
					charMaterialSlot.RevertProperty(RenderConfig.TextureColor);
					charMaterialSlot.RevertProperty(RenderConfig.TextureRotation);
					charMaterialSlot.RevertProperty(RenderConfig.NoiseTexture);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertBattle(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F65F RID: 194143 RVA: 0x00B40888 File Offset: 0x00B3EA88
		private void OnStartMotionOffset(CharMaterialControlRuntimeData runtimeData)
		{
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (valueOrDefault.SkeletalComp != null && valueOrDefault.SkeletalComp.IsValid())
				{
					runtimeData.TargetSkeletalMesh = valueOrDefault.SkeletalComp;
					runtimeData.MotionStartLocation = new FVectorDouble?(runtimeData.TargetSkeletalMesh.D_GetSocketLocation(RenderConfig.RootName));
					if (runtimeData.MotionEndLocation == null)
					{
						runtimeData.MotionEndLocation = new List<double>
						{
							0.0,
							0.0,
							0.0
						};
						break;
					}
					break;
				}
			}
		}

		// Token: 0x0602F660 RID: 194144 RVA: 0x00B40970 File Offset: 0x00B3EB70
		private void OnUpdateMotionOffset(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			if (runtimeData.TargetSkeletalMesh == null)
			{
				return;
			}
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			double alpha = Math.Pow((double)interpolateFactor.Factor, (double)dataCache.MotionOffsetLength);
			FVectorDouble fvectorDouble = runtimeData.TargetSkeletalMesh.D_GetSocketLocation(RenderConfig.RootName);
			RenderUtil.LerpVector(runtimeData.MotionStartLocation.Value, fvectorDouble, alpha, runtimeData.MotionEndLocation.ToArray());
			double num = runtimeData.MotionEndLocation[0] - fvectorDouble.X;
			double num2 = runtimeData.MotionEndLocation[1] - fvectorDouble.Y;
			double num3 = runtimeData.MotionEndLocation[2] - fvectorDouble.Z;
			float num4 = (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
			FLinearColor value;
			if (num4 < 100f)
			{
				value = new FLinearColor((float)num, (float)num2, (float)num3, num4);
			}
			else
			{
				value = new FLinearColor(0f, 0f, 0f, 0f);
			}
			float value2 = (num4 < 100f) ? RenderUtil.GetFloatFromGroup(dataCache.MotionNoiseSpeed, interpolateFactor) : 0f;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value3 = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value3.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value3[i]];
					charMaterialSlot.SetFloat(RenderConfig.MotionRange, dataCache.MotionAffectVertexRange);
					charMaterialSlot.SetColor(RenderConfig.MotionOffset, value);
					charMaterialSlot.SetFloat(RenderConfig.MotionNoiseSpeed, value2);
				}
			}
		}

		// Token: 0x0602F661 RID: 194145 RVA: 0x00B40B3C File Offset: 0x00B3ED3C
		private void OnRevertMotionOffset(CharMaterialControlRuntimeData runtimeData)
		{
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.MotionRange);
					charMaterialSlot.RevertProperty(RenderConfig.MotionOffset);
					charMaterialSlot.RevertProperty(RenderConfig.MotionNoiseSpeed);
				}
			}
		}

		// Token: 0x0602F662 RID: 194146 RVA: 0x00B40BEC File Offset: 0x00B3EDEC
		private void OnStartDither(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.UseAlphaTestCommon();
				}
				else
				{
					for (int i = 0; i < value.Count; i++)
					{
						CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
						if (charMaterialSlot.SectionIndex != 99999)
						{
							valueOrDefault.UseAlphaTest(charMaterialSlot.SectionIndex);
						}
					}
				}
			}
		}

		// Token: 0x0602F663 RID: 194147 RVA: 0x00B40CB4 File Offset: 0x00B3EEB4
		private void OnUpdateDither(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.DitherValue, interpolateFactor);
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.SetFloat(RenderConfig.UseDitherEffect2, 1f);
					charMaterialSlot.SetFloat(RenderConfig.DitherValue2, floatFromGroup);
				}
			}
		}

		// Token: 0x0602F664 RID: 194148 RVA: 0x00B40D7C File Offset: 0x00B3EF7C
		private void OnRevertDither(CharMaterialControlRuntimeData runtimeData)
		{
			bool selectedAllParts = runtimeData.SelectedAllParts;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				if (selectedAllParts)
				{
					valueOrDefault.RevertAlphaTestCommon();
				}
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					charMaterialSlot.RevertProperty(RenderConfig.DitherValue2);
					charMaterialSlot.RevertProperty(RenderConfig.UseDitherEffect2);
					if (!selectedAllParts && charMaterialSlot.SectionIndex != 99999)
					{
						valueOrDefault.RevertAlphaTest(charMaterialSlot.SectionIndex);
					}
				}
			}
		}

		// Token: 0x0602F665 RID: 194149 RVA: 0x00B40E60 File Offset: 0x00B3F060
		private void OnUpdateCustomMaterialEffect(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			InterpolateFactor interpolateFactor = runtimeData.InterpolateFactor;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					if (dataCache.CustomTextureParameterNames != null)
					{
						for (int j = 0; j < dataCache.CustomTextureParameterNames.Length; j++)
						{
							UTexture2D textureFromGroup = RenderUtil.GetTextureFromGroup(dataCache.CustomTextureParameterValues[j], interpolateFactor);
							if (textureFromGroup != null)
							{
								charMaterialSlot.SetTexture(dataCache.CustomTextureParameterNames[j], textureFromGroup);
							}
						}
					}
					if (dataCache.CustomFloatParameterNames != null)
					{
						for (int k = 0; k < dataCache.CustomFloatParameterNames.Length; k++)
						{
							float floatFromGroup = RenderUtil.GetFloatFromGroup(dataCache.CustomFloatParameterValues[k], interpolateFactor);
							charMaterialSlot.SetFloat(dataCache.CustomFloatParameterNames[k], floatFromGroup);
						}
					}
					if (dataCache.CustomColorParameterNames != null)
					{
						for (int l = 0; l < dataCache.CustomColorParameterNames.Length; l++)
						{
							FLinearColor colorFromGroup = RenderUtil.GetColorFromGroup(dataCache.CustomColorParameterValues[l], interpolateFactor);
							charMaterialSlot.SetColor(dataCache.CustomColorParameterNames[l], colorFromGroup);
						}
					}
				}
			}
		}

		// Token: 0x0602F666 RID: 194150 RVA: 0x00B40FF4 File Offset: 0x00B3F1F4
		private void OnRevertCustomMaterialEffect(CharMaterialControlRuntimeData runtimeData)
		{
			CharMaterialControlDataCache dataCache = runtimeData.DataCache;
			foreach (KeyValuePair<string, List<int>> keyValuePair in runtimeData.SpecifiedMaterialIndexMap)
			{
				string key = keyValuePair.Key;
				List<int> value = keyValuePair.Value;
				CharBodyInfo valueOrDefault = this.AllBodyInfoList.GetValueOrDefault(key);
				for (int i = 0; i < value.Count; i++)
				{
					CharMaterialSlot charMaterialSlot = valueOrDefault.MaterialSlotList[value[i]];
					if (dataCache.CustomTextureParameterNames != null)
					{
						for (int j = 0; j < dataCache.CustomTextureParameterNames.Length; j++)
						{
							charMaterialSlot.RevertProperty(dataCache.CustomTextureParameterNames[j]);
						}
					}
					if (dataCache.CustomFloatParameterNames != null)
					{
						for (int k = 0; k < dataCache.CustomFloatParameterNames.Length; k++)
						{
							charMaterialSlot.RevertProperty(dataCache.CustomFloatParameterNames[k]);
						}
					}
					if (dataCache.CustomColorParameterNames != null)
					{
						for (int l = 0; l < dataCache.CustomColorParameterNames.Length; l++)
						{
							charMaterialSlot.RevertProperty(dataCache.CustomColorParameterNames[l]);
						}
					}
				}
			}
		}

		// Token: 0x0401AFBC RID: 110524
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, CharBodyInfo> AllBodyInfoList;

		// Token: 0x0401AFBD RID: 110525
		private string OwnerActorName = string.Empty;

		// Token: 0x0401AFBE RID: 110526
		private readonly List<string> TempReplaceMaterialBodies = new List<string>();

		// Token: 0x0401AFBF RID: 110527
		[Nullable(2)]
		private Stat StatTick;

		// Token: 0x0401AFC0 RID: 110528
		private int UpdateCounter;

		// Token: 0x0401AFC1 RID: 110529
		private bool ForceUpdateThisFrame;

		// Token: 0x0401AFC2 RID: 110530
		private int MaxUpdateParamsPerFrame = -1;
	}
}
