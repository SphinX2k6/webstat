using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Motorcycle.Model
{
	// Token: 0x020056F8 RID: 22264
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorcycleUiModelUtil : Singleton<MotorcycleUiModelUtil>
	{
		// Token: 0x06038A76 RID: 232054 RVA: 0x00E58864 File Offset: 0x00E56A64
		public void CreateMotor(EUiModelUseWay useWay = EUiModelUseWay.MotorInMotorView)
		{
			Singleton<UiSceneManager>.Instance.InitMotorSkeletalHandle(useWay);
		}

		// Token: 0x06038A77 RID: 232055 RVA: 0x00E58871 File Offset: 0x00E56A71
		public void DestroyMotor()
		{
			Singleton<UiSceneManager>.Instance.DestroyMotorSkeletalHandle();
		}

		// Token: 0x06038A78 RID: 232056 RVA: 0x00E58880 File Offset: 0x00E56A80
		public void ClearMotorBuff()
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiModelBuffComponent uiModelBuffComponent = motorModel.CheckGetComponent<UiModelBuffComponent>();
			if (uiModelBuffComponent == null)
			{
				return;
			}
			uiModelBuffComponent.RemoveAllBuffId();
		}

		// Token: 0x06038A79 RID: 232057 RVA: 0x00E588A8 File Offset: 0x00E56AA8
		[NullableContext(2)]
		public UiModelBase GetMotorModel()
		{
			SkeletalObserverHandle motorSkeletalHandle = Singleton<UiSceneManager>.Instance.GetMotorSkeletalHandle();
			if (motorSkeletalHandle == null)
			{
				return null;
			}
			return motorSkeletalHandle.Model;
		}

		// Token: 0x06038A7A RID: 232058 RVA: 0x00E588C0 File Offset: 0x00E56AC0
		public void InitAutoRotateParam(float autoRotateDuration, ERotateAxis axis = ERotateAxis.Yaw, bool isPlus = true)
		{
			UiModelBase motorModel = this.GetMotorModel();
			UiModelRotateComponent uiModelRotateComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelRotateComponent>() : null;
			if (uiModelRotateComponent == null)
			{
				return;
			}
			uiModelRotateComponent.SetRotateParam(autoRotateDuration * 1000f, axis, isPlus);
		}

		// Token: 0x06038A7B RID: 232059 RVA: 0x00E588F4 File Offset: 0x00E56AF4
		public void SetAutoRotate(bool isAutoRotate)
		{
			UiModelBase motorModel = this.GetMotorModel();
			UiModelRotateComponent uiModelRotateComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelRotateComponent>() : null;
			if (uiModelRotateComponent == null)
			{
				return;
			}
			if (isAutoRotate)
			{
				uiModelRotateComponent.StartRotate();
				return;
			}
			uiModelRotateComponent.StopRotate();
		}

		// Token: 0x06038A7C RID: 232060 RVA: 0x00E58928 File Offset: 0x00E56B28
		private MotorcycleUiModelParam GetMotorEquipParam()
		{
			int equippedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
			List<int> equippedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerIdList();
			List<int> equippedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationIdList();
			return new MotorcycleUiModelParam
			{
				FrameId = equippedFrameId,
				StickerIds = equippedStickerIdList.ToArray(),
				DecorationIds = equippedDecorationIdList.ToArray()
			};
		}

		// Token: 0x06038A7D RID: 232061 RVA: 0x00E5897A File Offset: 0x00E56B7A
		public bool IsMotorCreated()
		{
			return this.GetMotorModel() != null;
		}

		// Token: 0x06038A7E RID: 232062 RVA: 0x00E58988 File Offset: 0x00E56B88
		public void ShowMotor(bool isShow)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			Singleton<UiModelUtil>.Instance.SetVisible(motorModel, isShow);
			UiMotorDecorationComponent uiMotorDecorationComponent = motorModel.CheckGetComponent<UiMotorDecorationComponent>();
			if (uiMotorDecorationComponent != null)
			{
				uiMotorDecorationComponent.ShowAllDecoration(isShow);
			}
			UiMotorSoarWingComponent uiMotorSoarWingComponent = motorModel.CheckGetComponent<UiMotorSoarWingComponent>();
			if (uiMotorSoarWingComponent == null)
			{
				return;
			}
			uiMotorSoarWingComponent.TrySetActive(isShow);
		}

		// Token: 0x06038A7F RID: 232063 RVA: 0x00E589D0 File Offset: 0x00E56BD0
		public void SetSoarWingEnabled(bool isEnabled)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiMotorSoarWingComponent uiMotorSoarWingComponent = motorModel.CheckGetComponent<UiMotorSoarWingComponent>();
			if (uiMotorSoarWingComponent == null)
			{
				return;
			}
			uiMotorSoarWingComponent.SetCanShowSoarWing(isEnabled);
		}

		// Token: 0x06038A80 RID: 232064 RVA: 0x00E589FC File Offset: 0x00E56BFC
		public void ShowSoarWing(bool isShow)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiMotorSoarWingComponent uiMotorSoarWingComponent = motorModel.CheckGetComponent<UiMotorSoarWingComponent>();
			if (uiMotorSoarWingComponent == null)
			{
				return;
			}
			uiMotorSoarWingComponent.TrySetActive(isShow);
		}

		// Token: 0x06038A81 RID: 232065 RVA: 0x00E58A28 File Offset: 0x00E56C28
		public void ShowMotorLoadingIcon(bool isShow)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiModelLoadingIconComponent uiModelLoadingIconComponent = motorModel.CheckGetComponent<UiModelLoadingIconComponent>();
			if (uiModelLoadingIconComponent == null)
			{
				return;
			}
			uiModelLoadingIconComponent.SetLoadingActive(isShow);
		}

		// Token: 0x06038A82 RID: 232066 RVA: 0x00E58A54 File Offset: 0x00E56C54
		public void LoadEquippedMotor([Nullable(new byte[]
		{
			2,
			1
		})] Action<UiModelBase> afterLoadCallBack = null)
		{
			MotorcycleUiModelParam motorEquipParam = this.GetMotorEquipParam();
			this.LoadMotorByParam(motorEquipParam, afterLoadCallBack);
		}

		// Token: 0x06038A83 RID: 232067 RVA: 0x00E58A70 File Offset: 0x00E56C70
		[NullableContext(2)]
		public void LoadEquippedMotorAndRole(int roleId, int roleSkinId, string animPath = null)
		{
			UiModelBase motorModel = this.GetMotorModel();
			UiMotorDataComponent uiMotorDataComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiMotorDataComponent>() : null;
			if (uiMotorDataComponent != null)
			{
				uiMotorDataComponent.SetRoleData(roleId, roleSkinId, animPath);
			}
			MotorcycleUiModelParam motorEquipParam = this.GetMotorEquipParam();
			this.LoadMotorByParam(motorEquipParam, null);
		}

		// Token: 0x06038A84 RID: 232068 RVA: 0x00E58AAC File Offset: 0x00E56CAC
		public void LoadMotorBySkinId(int skinId, [Nullable(new byte[]
		{
			2,
			1
		})] Action<UiModelBase> afterLoadCallBack = null)
		{
			MotorcycleDiySkinEquipRecord skinSuitRecord = ModelBase<MotorcycleDiyModel>.Instance.GetSkinSuitRecord(skinId);
			if (skinSuitRecord == null)
			{
				return;
			}
			MotorcycleUiModelParam param = new MotorcycleUiModelParam
			{
				FrameId = skinSuitRecord.FrameId,
				StickerIds = skinSuitRecord.StickerIds,
				DecorationIds = skinSuitRecord.DecorateIds
			};
			this.LoadMotorByParam(param, afterLoadCallBack);
		}

		// Token: 0x06038A85 RID: 232069 RVA: 0x00E58AFC File Offset: 0x00E56CFC
		private List<int> AutoFixStickerIds(int[] stickerIds)
		{
			List<int> list = new List<int>
			{
				0,
				0,
				0
			};
			foreach (int num in stickerIds)
			{
				if (num > 0)
				{
					MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
					if (motorStickerConfig != null)
					{
						int partId = motorStickerConfig.Value.PartId;
						int num2 = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART, partId);
						if (num2 != -1)
						{
							list[num2] = num;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06038A86 RID: 232070 RVA: 0x00E58B84 File Offset: 0x00E56D84
		private List<int> AutoFixDecorationIds(int[] decorateIds)
		{
			List<int> defaultDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetDefaultDecorationIdList();
			foreach (int num in decorateIds)
			{
				if (num > 0)
				{
					MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
					if (motorDecorationConfig != null)
					{
						int partId = motorDecorationConfig.Value.PartId;
						int num2 = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART, partId);
						if (num2 != -1)
						{
							defaultDecorationIdList[num2] = num;
						}
					}
				}
			}
			return defaultDecorationIdList;
		}

		// Token: 0x06038A87 RID: 232071 RVA: 0x00E58BFC File Offset: 0x00E56DFC
		public void LoadMotorByParam(MotorcycleUiModelParam param, [Nullable(new byte[]
		{
			2,
			1
		})] Action<UiModelBase> afterLoadCallBack = null)
		{
			MotorcycleUiModelUtil.<>c__DisplayClass17_0 CS$<>8__locals1 = new MotorcycleUiModelUtil.<>c__DisplayClass17_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.afterLoadCallBack = afterLoadCallBack;
			CS$<>8__locals1.model = this.GetMotorModel();
			if (CS$<>8__locals1.model == null)
			{
				return;
			}
			UiModelLoadComponent uiModelLoadComponent = CS$<>8__locals1.model.CheckGetComponent<UiModelLoadComponent>();
			UiModelActorComponent uiModelActorComponent = CS$<>8__locals1.model.CheckGetComponent<UiModelActorComponent>();
			CS$<>8__locals1.motorDataComponent = CS$<>8__locals1.model.CheckGetComponent<UiMotorDataComponent>();
			CS$<>8__locals1.motorSoarWingComponent = CS$<>8__locals1.model.CheckGetComponent<UiMotorSoarWingComponent>();
			CS$<>8__locals1.frameId = param.FrameId;
			CS$<>8__locals1.stickerIds = this.AutoFixStickerIds(param.StickerIds ?? Array.Empty<int>());
			List<int> list = this.AutoFixDecorationIds(param.DecorationIds ?? Array.Empty<int>());
			CS$<>8__locals1.loadSeq = CS$<>8__locals1.motorDataComponent.NextLoadSeq();
			int requestedFrameId = CS$<>8__locals1.motorDataComponent.GetRequestedFrameId();
			CS$<>8__locals1.motorDataComponent.SetRequestedFrameId(CS$<>8__locals1.frameId);
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(CS$<>8__locals1.frameId);
			if (motorFrameConfig == null)
			{
				return;
			}
			CS$<>8__locals1.frameBuffIds = motorFrameConfig.Value.GetModelBuffArray();
			CS$<>8__locals1.frameAnimPath = (motorFrameConfig.Value.ModelAnim ?? "");
			UiMotorSoarWingComponent motorSoarWingComponent = CS$<>8__locals1.motorSoarWingComponent;
			if (motorSoarWingComponent != null)
			{
				motorSoarWingComponent.SetSoarWingId(motorFrameConfig.Value.Wing);
			}
			if (requestedFrameId != CS$<>8__locals1.frameId || CS$<>8__locals1.motorDataComponent.GetFrameId() != CS$<>8__locals1.frameId)
			{
				this.ShowMotor(false);
				List<string> list2 = new List<string>();
				if (!StringUtils.IsBlank(CS$<>8__locals1.frameAnimPath))
				{
					list2.Add(CS$<>8__locals1.frameAnimPath);
				}
				foreach (int num in CS$<>8__locals1.stickerIds)
				{
					if (num > 0)
					{
						MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
						if (motorStickerConfig != null && !StringUtils.IsBlank(motorStickerConfig.Value.MaterialDA))
						{
							list2.Add(motorStickerConfig.Value.MaterialDA);
						}
					}
				}
				CS$<>8__locals1.totalLoadCount = 1;
				int[] motorcycle_DIY_DECORATION_PART = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART;
				for (int i = 0; i < motorcycle_DIY_DECORATION_PART.Length; i++)
				{
					if (i < list.Count && list[i] != 0)
					{
						int totalLoadCount = CS$<>8__locals1.totalLoadCount;
						CS$<>8__locals1.totalLoadCount = totalLoadCount + 1;
					}
				}
				uiModelActorComponent.SetTransformByTag("RoleCase");
				CS$<>8__locals1.finishCount = 0;
				uiModelLoadComponent.LoadModelByModelId(motorFrameConfig.Value.ModelId, true, delegate
				{
					if (base.<LoadMotorByParam>g__IsStale|0())
					{
						return;
					}
					CS$<>8__locals1.motorDataComponent.SetFrameId(CS$<>8__locals1.frameId);
					CS$<>8__locals1.motorDataComponent.SetStickerIdList(CS$<>8__locals1.stickerIds);
					base.<LoadMotorByParam>g__CheckAllLoadFinish|1();
				}, list2);
				this.LoadDecorations(list, new Action(CS$<>8__locals1.<LoadMotorByParam>g__CheckAllLoadFinish|1));
				return;
			}
			this.HandleSticker(CS$<>8__locals1.stickerIds);
			this.LoadDecorations(list, null);
			CS$<>8__locals1.motorSoarWingComponent.RefreshCurSoarWing();
			Action<UiModelBase> afterLoadCallBack2 = CS$<>8__locals1.afterLoadCallBack;
			if (afterLoadCallBack2 == null)
			{
				return;
			}
			afterLoadCallBack2(CS$<>8__locals1.model);
		}

		// Token: 0x06038A88 RID: 232072 RVA: 0x00E58EE4 File Offset: 0x00E570E4
		public void SetEmptySticker(int stickerPart)
		{
			if (stickerPart <= 0)
			{
				return;
			}
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiMotorStickerComponent uiMotorStickerComponent = motorModel.CheckGetComponent<UiMotorStickerComponent>();
			if (uiMotorStickerComponent == null)
			{
				return;
			}
			uiMotorStickerComponent.RemoveStickerMaterial(stickerPart);
		}

		// Token: 0x06038A89 RID: 232073 RVA: 0x00E58F14 File Offset: 0x00E57114
		public void AddMaterialByStickerId(int stickerId)
		{
			if (stickerId <= 0)
			{
				return;
			}
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiMotorStickerComponent uiMotorStickerComponent = motorModel.CheckGetComponent<UiMotorStickerComponent>();
			if (uiMotorStickerComponent == null)
			{
				return;
			}
			uiMotorStickerComponent.AddStickerMaterial(stickerId);
		}

		// Token: 0x06038A8A RID: 232074 RVA: 0x00E58F44 File Offset: 0x00E57144
		private void PlayFrameBuff(long[] frameBuffIds)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiModelBuffComponent uiModelBuffComponent = motorModel.CheckGetComponent<UiModelBuffComponent>();
			if (uiModelBuffComponent == null)
			{
				return;
			}
			uiModelBuffComponent.RemoveAllBuffId();
			foreach (long buffId in frameBuffIds)
			{
				uiModelBuffComponent.AddBuffByBuffId(buffId);
			}
		}

		// Token: 0x06038A8B RID: 232075 RVA: 0x00E58F8C File Offset: 0x00E5718C
		private void PlayFrameAnim(string frameAnimPath)
		{
			if (StringUtils.IsBlank(frameAnimPath))
			{
				return;
			}
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiModelLoadComponent uiModelLoadComponent = motorModel.CheckGetComponent<UiModelLoadComponent>();
			UiModelAnimationComponent uiModelAnimationComponent = motorModel.CheckGetComponent<UiModelAnimationComponent>();
			if (uiModelAnimationComponent == null || uiModelLoadComponent == null)
			{
				return;
			}
			UAnimationAsset uanimationAsset = uiModelLoadComponent.GetLoadedResource(frameAnimPath) as UAnimationAsset;
			if (uanimationAsset != null)
			{
				uiModelAnimationComponent.PlayAnimation(uanimationAsset, false);
			}
		}

		// Token: 0x06038A8C RID: 232076 RVA: 0x00E58FDC File Offset: 0x00E571DC
		private void HandleSticker(List<int> stickerIds)
		{
			int[] motorcycle_DIY_STICKER_PART = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART;
			for (int i = 0; i < motorcycle_DIY_STICKER_PART.Length; i++)
			{
				int num = (stickerIds.Count > i) ? stickerIds[i] : 0;
				if (num == 0)
				{
					this.SetEmptySticker(motorcycle_DIY_STICKER_PART[i]);
				}
				else
				{
					this.AddMaterialByStickerId(num);
				}
			}
		}

		// Token: 0x06038A8D RID: 232077 RVA: 0x00E59028 File Offset: 0x00E57228
		private void LoadDecorations(List<int> decorationIds, [Nullable(2)] Action oneLoadCallBack = null)
		{
			int[] motorcycle_DIY_DECORATION_PART = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART;
			for (int i = 0; i < motorcycle_DIY_DECORATION_PART.Length; i++)
			{
				int num = (decorationIds.Count > i) ? decorationIds[i] : 0;
				if (num == 0)
				{
					this.SetEmptyDecoration(motorcycle_DIY_DECORATION_PART[i]);
				}
				else
				{
					this.AddDecoration(num, oneLoadCallBack);
				}
			}
		}

		// Token: 0x06038A8E RID: 232078 RVA: 0x00E59074 File Offset: 0x00E57274
		public void SetEmptyDecoration(int decorationPart)
		{
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiMotorDataComponent uiMotorDataComponent = motorModel.CheckGetComponent<UiMotorDataComponent>();
			UiMotorDecorationComponent uiMotorDecorationComponent = motorModel.CheckGetComponent<UiMotorDecorationComponent>();
			if (uiMotorDataComponent != null)
			{
				uiMotorDataComponent.SetDecorationId(decorationPart, 0);
			}
			if (uiMotorDecorationComponent == null)
			{
				return;
			}
			uiMotorDecorationComponent.RemoveDecorationSkeletalObserver(decorationPart, null);
		}

		// Token: 0x06038A8F RID: 232079 RVA: 0x00E590B8 File Offset: 0x00E572B8
		[NullableContext(2)]
		public void AddDecoration(int decorationId, Action finishCallBack = null)
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(decorationId);
			if (motorDecorationConfig == null)
			{
				return;
			}
			int partId = motorDecorationConfig.Value.PartId;
			int modelId = motorDecorationConfig.Value.ModelId;
			UiModelBase motorModel = this.GetMotorModel();
			if (motorModel == null)
			{
				return;
			}
			UiModelActorComponent uiModelActorComponent = motorModel.CheckGetComponent<UiModelActorComponent>();
			UiMotorDataComponent motorDataComponent = motorModel.CheckGetComponent<UiMotorDataComponent>();
			if (uiModelActorComponent == null || motorDataComponent == null)
			{
				return;
			}
			UiMotorDecorationComponent uiMotorDecorationComponent = motorModel.CheckGetComponent<UiMotorDecorationComponent>();
			if (uiMotorDecorationComponent == null)
			{
				return;
			}
			if (motorDataComponent.IsSameDecorationId(partId, decorationId))
			{
				UiDecorationLoadComponent uiDecorationLoadComponent = uiMotorDecorationComponent.GetDecorationHandle(partId, 0).Model.CheckGetComponent<UiDecorationLoadComponent>();
				uiDecorationLoadComponent.SetAttachActorComponent(uiModelActorComponent);
				uiDecorationLoadComponent.AttachToTarget();
				Action finishCallBack2 = finishCallBack;
				if (finishCallBack2 == null)
				{
					return;
				}
				finishCallBack2();
				return;
			}
			else
			{
				SkeletalObserverHandle decorationHandle = uiMotorDecorationComponent.GetDecorationHandle(partId, 0);
				if (decorationHandle == null)
				{
					uiMotorDecorationComponent.AddDecorationMesh(partId, decorationId);
					decorationHandle = uiMotorDecorationComponent.GetDecorationHandle(partId, 0);
				}
				if (decorationHandle == null)
				{
					return;
				}
				UiModelBase model = decorationHandle.Model;
				if (model == null)
				{
					return;
				}
				UiDecorationLoadComponent uiDecorationLoadComponent2 = model.CheckGetComponent<UiDecorationLoadComponent>();
				if (uiDecorationLoadComponent2 == null)
				{
					return;
				}
				uiDecorationLoadComponent2.SetAttachActorComponent(uiModelActorComponent);
				uiDecorationLoadComponent2.LoadModelByModelId(modelId, 0, true, delegate
				{
					motorDataComponent.SetDecorationId(partId, decorationId);
					Action finishCallBack3 = finishCallBack;
					if (finishCallBack3 == null)
					{
						return;
					}
					finishCallBack3();
				}, null, false);
				if (!uiMotorDecorationComponent.IsMotorModelLoaded())
				{
					Singleton<UiModelUtil>.Instance.SetVisible(model, false);
				}
				return;
			}
		}

		// Token: 0x06038A90 RID: 232080 RVA: 0x00E59234 File Offset: 0x00E57434
		[NullableContext(2)]
		public void RefreshRoleInMotor(int roleId, int skinId, string animPath = null)
		{
			SkeletalObserverHandle motorSkeletalHandle = Singleton<UiSceneManager>.Instance.GetMotorSkeletalHandle();
			if (motorSkeletalHandle == null)
			{
				return;
			}
			UiModelBase model = motorSkeletalHandle.Model;
			if (model == null)
			{
				return;
			}
			UiMotorRoleComponent uiMotorRoleComponent = model.CheckGetComponent<UiMotorRoleComponent>();
			UiMotorDataComponent uiMotorDataComponent = model.CheckGetComponent<UiMotorDataComponent>();
			if (uiMotorRoleComponent == null || uiMotorDataComponent == null)
			{
				return;
			}
			uiMotorDataComponent.SetRoleData(roleId, skinId, animPath);
			uiMotorRoleComponent.Refresh();
		}
	}
}
