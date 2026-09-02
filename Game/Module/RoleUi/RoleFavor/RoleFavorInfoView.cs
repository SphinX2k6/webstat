using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleFavor
{
	// Token: 0x02005076 RID: 20598
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleFavorInfoView : UiViewBase
	{
		// Token: 0x06035186 RID: 217478 RVA: 0x00D50D95 File Offset: 0x00D4EF95
		public RoleFavorInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035187 RID: 217479 RVA: 0x00D50DC8 File Offset: 0x00D4EFC8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose))
			};
		}

		// Token: 0x06035188 RID: 217480 RVA: 0x00D50F3C File Offset: 0x00D4F13C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleFavorInfoView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleFavorInfoView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035189 RID: 217481 RVA: 0x00D50F7F File Offset: 0x00D4F17F
		protected override void OnBeforeShow()
		{
			base.GetItem(13).SetUIActive(true);
			if (this.SelectedContentData != null && this.SelectedContentData.FavorContentType == EFavorContentType.PreciousItem)
			{
				Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
			}
			this.RefreshView();
		}

		// Token: 0x0603518A RID: 217482 RVA: 0x00D50FB5 File Offset: 0x00D4F1B5
		protected override void OnAfterHide()
		{
			if (this.SelectedContentData != null && this.SelectedContentData.FavorContentType == EFavorContentType.PreciousItem)
			{
				Singleton<UiSceneManager>.Instance.ShowRoleSystemRoleActor();
			}
		}

		// Token: 0x0603518B RID: 217483 RVA: 0x00D50FD8 File Offset: 0x00D4F1D8
		protected override void OnBeforeDestroy()
		{
			if (this.RoleFavorDescComponent != null)
			{
				this.RoleFavorDescComponent.Destroy(null);
				this.RoleFavorDescComponent = null;
			}
			if (this.RoleFavorBaseInfoComponent != null)
			{
				this.RoleFavorBaseInfoComponent.Destroy(null);
				this.RoleFavorBaseInfoComponent = null;
			}
			if (this.RoleFavorPowerInfoComponent != null)
			{
				this.RoleFavorPowerInfoComponent.Destroy(null);
				this.RoleFavorPowerInfoComponent = null;
			}
			if (this.RoleFavorPreciousItemComponent != null)
			{
				this.RoleFavorPreciousItemComponent.Destroy(null);
				this.RoleFavorPreciousItemComponent = null;
			}
			if (this.RoleFavorLockComponent != null)
			{
				this.RoleFavorLockComponent.Destroy(null);
				this.RoleFavorLockComponent = null;
			}
			this.ClearVerticalLayout();
			this.ClassifyDataList.Clear();
			this.SelectedContentData = null;
			Singleton<AudioController>.Instance.StopEvent(this.FavorInfoAudioResult, true, null);
		}

		// Token: 0x0603518C RID: 217484 RVA: 0x00D5109E File Offset: 0x00D4F29E
		private void RefreshView()
		{
			this.UpdateClassifyTitle();
			this.HideAllItem();
			if (this.SelectedContentData != null)
			{
				this.ShowItemByData(this.SelectedContentData);
				return;
			}
			this.ShowDefaultItem();
		}

		// Token: 0x0603518D RID: 217485 RVA: 0x00D510C8 File Offset: 0x00D4F2C8
		private List<RoleFavorActionClassifyData> GetActionDataList()
		{
			List<RoleFavorActionClassifyData> list = new List<RoleFavorActionClassifyData>();
			int roleId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetRoleId();
			IReadOnlyList<Motion> roleMotionByType = ConfigBase<MotionConfig>.Instance.GetRoleMotionByType(roleId, 1);
			IReadOnlyList<Motion> roleMotionByType2 = ConfigBase<MotionConfig>.Instance.GetRoleMotionByType(roleId, 2);
			if (roleMotionByType != null && roleMotionByType.Count > 0)
			{
				RoleFavorActionClassifyData item = ClassifyDataFactory.CreateClassifyData("FavorIdleAction", EFavorTabType.Action, roleId, EFavorActionType.IdleAction);
				list.Add(item);
			}
			if (roleMotionByType2 != null && roleMotionByType2.Count > 0)
			{
				RoleFavorActionClassifyData item2 = ClassifyDataFactory.CreateClassifyData("FavorFightAction", EFavorTabType.Action, roleId, EFavorActionType.FightAction);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x0603518E RID: 217486 RVA: 0x00D51154 File Offset: 0x00D4F354
		private List<RoleFavorExperienceClassifyData> GetExperienceDataList()
		{
			List<RoleFavorExperienceClassifyData> list = new List<RoleFavorExperienceClassifyData>();
			int roleId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetRoleId();
			RoleFavorExperienceClassifyData item = ClassifyDataFactory.CreateClassifyData("FavorRoleInfo", EFavorTabType.Experience, roleId, EFavorExperienceType.File);
			RoleFavorExperienceClassifyData item2 = ClassifyDataFactory.CreateClassifyData("FavorRoleStory", EFavorTabType.Experience, roleId, EFavorExperienceType.Story);
			list.Add(item);
			list.Add(item2);
			return list;
		}

		// Token: 0x0603518F RID: 217487 RVA: 0x00D511A8 File Offset: 0x00D4F3A8
		private List<RoleFavorPreciousItemClassifyData> GetPreciousItemDataList()
		{
			List<RoleFavorPreciousItemClassifyData> list = new List<RoleFavorPreciousItemClassifyData>();
			int roleId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetRoleId();
			RoleFavorPreciousItemClassifyData item = ClassifyDataFactory.CreateClassifyData("FavorPreciousItem", EFavorTabType.PreciousItem, roleId);
			list.Add(item);
			return list;
		}

		// Token: 0x06035190 RID: 217488 RVA: 0x00D511E4 File Offset: 0x00D4F3E4
		private List<RoleFavorVoiceClassifyData> GetVoiceDataList()
		{
			List<RoleFavorVoiceClassifyData> list = new List<RoleFavorVoiceClassifyData>();
			int roleId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetRoleId();
			IReadOnlyList<FavorWord> favorWordConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorWordConfig(roleId, 1);
			IReadOnlyList<FavorWord> favorWordConfig2 = ConfigBase<RoleFavorConfig>.Instance.GetFavorWordConfig(roleId, 2);
			if (favorWordConfig != null && favorWordConfig.Count > 0)
			{
				RoleFavorVoiceClassifyData item = ClassifyDataFactory.CreateClassifyData("FavorNatureVoice", EFavorTabType.Voice, roleId, EFavorVoiceType.FavorNatureVoice);
				list.Add(item);
			}
			if (favorWordConfig2 != null && favorWordConfig2.Count > 0)
			{
				RoleFavorVoiceClassifyData item2 = ClassifyDataFactory.CreateClassifyData("FavorFightVoice", EFavorTabType.Voice, roleId, EFavorVoiceType.FavorFightVoice);
				list.Add(item2);
			}
			return list;
		}

		// Token: 0x06035191 RID: 217489 RVA: 0x00D51270 File Offset: 0x00D4F470
		protected EFavorItemStatus GetItemState(RoleFavorContentDataBase contentItemData)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
			RoleFavorData favorData = roleInstanceById.GetFavorData();
			EFavorItemStatus result;
			if (contentItemData.FavorContentType == EFavorContentType.Action)
			{
				result = (EFavorItemStatus)ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), contentItemData.ConfigId);
			}
			else
			{
				result = favorData.GetFavorItemState(contentItemData.ConfigId, contentItemData.FavorContentType);
			}
			return result;
		}

		// Token: 0x06035192 RID: 217490 RVA: 0x00D512D0 File Offset: 0x00D4F4D0
		private void UpdateClassifyTitle()
		{
			string textTableId = null;
			UUIText text = base.GetText(3);
			switch (this.SelectedContentData.FavorContentType)
			{
			case EFavorContentType.Voice:
				textTableId = "FavorVoice";
				break;
			case EFavorContentType.ExperienceFile:
			case EFavorContentType.ExperienceStory:
				textTableId = "FavorExperience";
				break;
			case EFavorContentType.Action:
				textTableId = "FavorAction";
				break;
			case EFavorContentType.PreciousItem:
				textTableId = "FavorPreciousItem";
				break;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(text, textTableId, Array.Empty<object>());
		}

		// Token: 0x06035193 RID: 217491 RVA: 0x00D51340 File Offset: 0x00D4F540
		private void UpdateCvPanel(bool isShow)
		{
			if (isShow)
			{
				string curLanguageCvName = RoleFavorUtil.GetCurLanguageCvName(this.RoleId);
				UUIText text = base.GetText(11);
				UUIItem item = base.GetItem(12);
				if (curLanguageCvName == "")
				{
					if (item != null)
					{
						item.SetUIActive(false);
						return;
					}
				}
				else
				{
					if (item != null)
					{
						item.SetUIActive(true);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, curLanguageCvName, Array.Empty<object>());
				}
				return;
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06035194 RID: 217492 RVA: 0x00D513B8 File Offset: 0x00D4F5B8
		protected void ShowDefaultItem()
		{
			int roleId = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId).GetRoleId();
			FavorRoleInfo? favorRoleInfoConfig = ConfigBase<RoleFavorConfig>.Instance.GetFavorRoleInfoConfig(roleId);
			EFavorExperienceSubType favorExperienceSubType = EFavorExperienceSubType.RoleBaseInfo;
			RoleFavorRoleInfoContentData contentItemData = new RoleFavorRoleInfoContentData(this.RoleId, favorExperienceSubType, favorRoleInfoConfig.Value);
			this.ShowItemByData(contentItemData);
		}

		// Token: 0x06035195 RID: 217493 RVA: 0x00D51404 File Offset: 0x00D4F604
		protected void ShowItemByData(RoleFavorContentDataBase contentItemData)
		{
			this.HideAllItem();
			EFavorItemStatus itemState = this.GetItemState(contentItemData);
			if (contentItemData.FavorContentType != EFavorContentType.ExperienceFile && itemState != EFavorItemStatus.ItemUnLocked)
			{
				this.HandleLockItemData();
				return;
			}
			IContentHandler contentHandler;
			if (this.GetContentHandlersMap().TryGetValue(contentItemData.FavorContentType, out contentHandler))
			{
				contentHandler.ShowItem(contentItemData);
			}
		}

		// Token: 0x06035196 RID: 217494 RVA: 0x00D51450 File Offset: 0x00D4F650
		protected void HandleLockItemData()
		{
			int configId = this.SelectedContentData.ConfigId;
			EFavorContentType favorContentType = this.SelectedContentData.FavorContentType;
			FavorItemType? favorItemType = null;
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
			RoleFavorData favorData = roleInstanceById.GetFavorData();
			if (favorContentType == EFavorContentType.Action)
			{
				if (this.LastSelectedRoleFavorContentItem != null)
				{
					this.ClearRoleMontage(this.LastSelectedRoleFavorContentItem);
				}
				EFavorItemStatus roleMotionState = (EFavorItemStatus)ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), configId);
				if (roleMotionState == EFavorItemStatus.ItemCanUnLock)
				{
					ControllerBase<MotionController>.Instance.RequestUnlockMotion(roleInstanceById.GetRoleId(), configId);
					return;
				}
				if (roleMotionState == EFavorItemStatus.ItemLocked)
				{
					this.ShowLockItem();
				}
				return;
			}
			else
			{
				switch (favorContentType)
				{
				case EFavorContentType.Voice:
					favorItemType = new FavorItemType?(FavorItemType.Word);
					if (this.LastSelectedRoleFavorContentItem != null)
					{
						this.ClearAudio(this.LastSelectedRoleFavorContentItem);
					}
					break;
				case EFavorContentType.ExperienceStory:
					favorItemType = new FavorItemType?(FavorItemType.Story);
					break;
				case EFavorContentType.PreciousItem:
					favorItemType = new FavorItemType?(FavorItemType.Goods);
					break;
				}
				EFavorItemStatus favorItemState = favorData.GetFavorItemState(this.SelectedContentData.ConfigId, favorContentType);
				if (favorItemState == EFavorItemStatus.ItemCanUnLock)
				{
					ControllerBase<RoleController>.Instance.SendRoleFavorUnLockRequest(favorItemType.Value, roleInstanceById.GetRoleId(), configId);
					return;
				}
				if (favorItemState == EFavorItemStatus.ItemLocked)
				{
					this.ShowLockItem();
				}
				return;
			}
		}

		// Token: 0x06035197 RID: 217495 RVA: 0x00D5156C File Offset: 0x00D4F76C
		private void ShowActionItem(RoleFavorActionContentData contentData)
		{
			this.UpdateCvPanel(false);
			this.RoleFavorDescComponent.SetData(contentData, true);
		}

		// Token: 0x06035198 RID: 217496 RVA: 0x00D51584 File Offset: 0x00D4F784
		private void ShowRoleInfoItem(RoleFavorRoleInfoContentData contentData)
		{
			this.UpdateCvPanel(true);
			EFavorExperienceSubType favorExperienceSubType = contentData.FavorExperienceSubType;
			if (favorExperienceSubType == EFavorExperienceSubType.RoleBaseInfo)
			{
				this.RoleFavorBaseInfoComponent.SetData(contentData, true);
				return;
			}
			if (favorExperienceSubType == EFavorExperienceSubType.RolePowerFile)
			{
				this.RoleFavorPowerInfoComponent.SetData(contentData, true);
			}
		}

		// Token: 0x06035199 RID: 217497 RVA: 0x00D515C2 File Offset: 0x00D4F7C2
		private void ShowRoleStoryItem(RoleFavorStoryContentData contentData)
		{
			this.RoleFavorDescComponent.SetData(contentData, true);
		}

		// Token: 0x0603519A RID: 217498 RVA: 0x00D515D1 File Offset: 0x00D4F7D1
		private void ShowPreciousItem(RoleFavorPreciousItemContentData contentData)
		{
			this.UpdateCvPanel(false);
			this.RoleFavorDescComponent.SetData(contentData, true);
			this.RoleFavorPreciousItemComponent.SetData(contentData, true);
			this.RoleFavorPreciousItemComponent.SetLockState(false);
		}

		// Token: 0x0603519B RID: 217499 RVA: 0x00D51600 File Offset: 0x00D4F800
		private void ShowVoiceItem(RoleFavorVoiceContentData contentData)
		{
			this.UpdateCvPanel(true);
			this.RoleFavorDescComponent.SetData(contentData, true);
		}

		// Token: 0x0603519C RID: 217500 RVA: 0x00D51618 File Offset: 0x00D4F818
		protected void ShowLockItem()
		{
			this.HideAllItem();
			this.RoleFavorLockComponent.SetData(this.SelectedContentData, true);
			RoleFavorContentDataBase selectedContentData = this.SelectedContentData;
			if (selectedContentData != null && selectedContentData.FavorContentType == EFavorContentType.PreciousItem)
			{
				RoleFavorPreciousItemContentData contentData = this.SelectedContentData as RoleFavorPreciousItemContentData;
				this.RoleFavorPreciousItemComponent.SetData(contentData, true);
				this.RoleFavorPreciousItemComponent.SetLockState(true);
			}
		}

		// Token: 0x0603519D RID: 217501 RVA: 0x00D51679 File Offset: 0x00D4F879
		private void HideAllItem()
		{
			this.RoleFavorLockComponent.SetComponentActive(false);
			this.RoleFavorDescComponent.SetComponentActive(false);
			this.RoleFavorBaseInfoComponent.SetComponentActive(false);
			this.RoleFavorPowerInfoComponent.SetComponentActive(false);
			this.RoleFavorPreciousItemComponent.SetComponentActive(false);
		}

		// Token: 0x0603519E RID: 217502 RVA: 0x00D516B8 File Offset: 0x00D4F8B8
		private void ResetAllRoleFavorContentItemToggle()
		{
			int count = this.RoleFavorContentItemList.Count;
			for (int i = 0; i < count; i++)
			{
				RoleFavorContentItem roleFavorContentItem = this.RoleFavorContentItemList[i];
				RoleFavorContentDataBase contentData = roleFavorContentItem.ContentData;
				int num = (contentData != null) ? contentData.InstanceId : -1;
				if (this.SelectedContentData.InstanceId == num)
				{
					roleFavorContentItem.SetToggleState(EToggleState.ETT_Checked);
					roleFavorContentItem.SetButtonActive(true);
					this.CurSelectedRoleFavorContentItem = roleFavorContentItem;
				}
				else
				{
					roleFavorContentItem.SetToggleState(EToggleState.ETT_UnChecked);
					roleFavorContentItem.SetButtonActive(false);
				}
			}
		}

		// Token: 0x0603519F RID: 217503 RVA: 0x00D51730 File Offset: 0x00D4F930
		protected void ClearVerticalLayout()
		{
			if (this.ClassifyVerticalLayout != null)
			{
				this.ClassifyVerticalLayout.ClearChildren();
			}
		}

		// Token: 0x060351A0 RID: 217504 RVA: 0x00D51748 File Offset: 0x00D4F948
		private void PlayVoice(RoleFavorVoiceContentData contentData, RoleFavorContentItem roleFavorContentItem)
		{
			if (roleFavorContentItem.GetCurVoiceState() == EFavorPlayerStatus.Play)
			{
				this.ClearAudio(roleFavorContentItem);
				return;
			}
			if (this.LastSelectedRoleFavorContentItem != null && this.LastSelectedRoleFavorContentItem.GetCurVoiceState() == EFavorPlayerStatus.Play)
			{
				this.ClearAudio(this.LastSelectedRoleFavorContentItem);
			}
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.MASTERVOLUMEFUNCTION, true, true);
			int? currentValue2 = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.VOICEVOLUMEFUNCTION, true, true);
			if (currentValue != null)
			{
				int? num = currentValue;
				int num2 = 0;
				if (!(num.GetValueOrDefault() == num2 & num != null) && currentValue2 != null)
				{
					num = currentValue2;
					num2 = 0;
					if (!(num.GetValueOrDefault() == num2 & num != null))
					{
						FavorWord configData = contentData.ConfigData;
						TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
						ControllerBase<RoleController>.Instance.SetRoleMorphType(roleSystemRoleActor, (EUiModelMorphType)configData.Morph);
						this.PlayVoiceByConfig(roleFavorContentItem, configData);
						return;
					}
				}
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("FavorVolume", Array.Empty<object>());
		}

		// Token: 0x060351A1 RID: 217505 RVA: 0x00D5182C File Offset: 0x00D4FA2C
		private void PlayVoiceByConfig(RoleFavorContentItem roleFavorContentItem, FavorWord config)
		{
			RoleFavorInfoView.<>c__DisplayClass44_0 CS$<>8__locals1 = new RoleFavorInfoView.<>c__DisplayClass44_0();
			CS$<>8__locals1.roleFavorContentItem = roleFavorContentItem;
			this.VoicePath = config.Voice;
			if (this.VoicePath == "")
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Role;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "配置的语音路径为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.VoicePath", this.VoicePath);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			CS$<>8__locals1.voicePath = this.VoicePath;
			CS$<>8__locals1.audioResult = this.FavorInfoAudioResult;
			CS$<>8__locals1.playFlag = this.PlayFlag;
			Singleton<AudioController>.Instance.LoadAndAddCallback(this.VoicePath, new Action(CS$<>8__locals1.<PlayVoiceByConfig>g__loadedCallback|0), this.FavorInfoAudioResult);
		}

		// Token: 0x060351A2 RID: 217506 RVA: 0x00D518D8 File Offset: 0x00D4FAD8
		private void PlayRoleMontage(RoleFavorActionContentData contentData, RoleFavorContentItem roleFavorContentItem)
		{
			Motion configData = contentData.ConfigData;
			if (roleFavorContentItem.GetCurVoiceState() == EFavorPlayerStatus.Play)
			{
				this.ClearRoleMontage(roleFavorContentItem);
				return;
			}
			if (this.LastSelectedRoleFavorContentItem != null && this.LastSelectedRoleFavorContentItem.GetCurVoiceState() == EFavorPlayerStatus.Play)
			{
				this.ClearRoleMontage(this.LastSelectedRoleFavorContentItem);
			}
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			ControllerBase<RoleController>.Instance.SetRoleMorphType(roleSystemRoleActor, (EUiModelMorphType)configData.Morph);
			this.PlayRoleMontageByConfig(roleFavorContentItem, configData);
		}

		// Token: 0x060351A3 RID: 217507 RVA: 0x00D51944 File Offset: 0x00D4FB44
		private void PlayRoleMontageByConfig(RoleFavorContentItem roleFavorContentItem, Motion config)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(config.AniMontage, delegate([Nullable(2)] UAnimMontage montageObject, string _)
			{
				if (montageObject == null || !montageObject.IsValid())
				{
					return;
				}
				TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
				if (roleSystemRoleActor == null)
				{
					return;
				}
				UiModelBase model = roleSystemRoleActor.Model;
				Singleton<UiModelUtil>.Instance.SetVisible(model, true);
				UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
				USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
				if (uskeletalMeshComponent == null)
				{
					return;
				}
				roleFavorContentItem.StartPlay();
				ABP_PerformanceRole_C animInstanceFromSkeletalMesh = uiModelActorComponent.GetAnimInstanceFromSkeletalMesh(uskeletalMeshComponent);
				if (animInstanceFromSkeletalMesh == null || !animInstanceFromSkeletalMesh.IsValid())
				{
					return;
				}
				animInstanceFromSkeletalMesh.TryForceEnterLoop();
				animInstanceFromSkeletalMesh.Montage_Play(montageObject, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
				animInstanceFromSkeletalMesh.OnMontageEnded.Add(roleFavorContentItem.OnMontageCompleted);
			}, 100, this.MemoryTag);
		}

		// Token: 0x060351A4 RID: 217508 RVA: 0x00D51984 File Offset: 0x00D4FB84
		protected void ClearAudio(RoleFavorContentItem roleFavorContentItem)
		{
			Singleton<AudioController>.Instance.StopEvent(this.FavorInfoAudioResult, true, null);
			roleFavorContentItem.EndPlay();
		}

		// Token: 0x060351A5 RID: 217509 RVA: 0x00D519B4 File Offset: 0x00D4FBB4
		protected void ClearRoleMontage(RoleFavorContentItem roleFavorContentItem)
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			if (roleSystemRoleActor == null)
			{
				return;
			}
			UiModelBase model = roleSystemRoleActor.Model;
			Singleton<UiModelUtil>.Instance.SetVisible(model, true);
			UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
			USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
			if (uskeletalMeshComponent == null)
			{
				return;
			}
			UAnimInstance linkedAnimGraphInstanceByTag = uskeletalMeshComponent.GetAnimInstance().GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
			linkedAnimGraphInstanceByTag.StopSlotAnimation(0.25f, default(FName));
			if (roleFavorContentItem.OnMontageCompleted != null)
			{
				linkedAnimGraphInstanceByTag.OnMontageEnded.Remove(roleFavorContentItem.OnMontageCompleted);
			}
			roleFavorContentItem.EndPlay();
		}

		// Token: 0x060351A6 RID: 217510 RVA: 0x00D51A48 File Offset: 0x00D4FC48
		private void InitClassifyItemDataList()
		{
			switch (this.FavorTabType)
			{
			case EFavorTabType.Voice:
				this.ClassifyDataList = this.ConvertClassifyDataList<RoleFavorVoiceClassifyData>(this.GetVoiceDataList());
				return;
			case EFavorTabType.Experience:
				this.ClassifyDataList = this.ConvertClassifyDataList<RoleFavorExperienceClassifyData>(this.GetExperienceDataList());
				return;
			case EFavorTabType.Action:
				this.ClassifyDataList = this.ConvertClassifyDataList<RoleFavorActionClassifyData>(this.GetActionDataList());
				return;
			case EFavorTabType.PreciousItem:
				this.ClassifyDataList = this.ConvertClassifyDataList<RoleFavorPreciousItemClassifyData>(this.GetPreciousItemDataList());
				return;
			default:
				return;
			}
		}

		// Token: 0x060351A7 RID: 217511 RVA: 0x00D51AC0 File Offset: 0x00D4FCC0
		private List<RoleFavorClassifyDataBase> ConvertClassifyDataList<[Nullable(0)] T>(List<T> source) where T : RoleFavorClassifyDataBase
		{
			List<RoleFavorClassifyDataBase> list = new List<RoleFavorClassifyDataBase>(source.Count);
			for (int i = 0; i < source.Count; i++)
			{
				list.Add(source[i]);
			}
			return list;
		}

		// Token: 0x060351A8 RID: 217512 RVA: 0x00D51B00 File Offset: 0x00D4FD00
		private void InitRoleFavorContentItemList()
		{
			foreach (RoleFavorClassifyItem roleFavorClassifyItem in this.ClassifyVerticalLayout.GetLayoutItemList())
			{
				foreach (RoleFavorContentItem roleFavorContentItem in roleFavorClassifyItem.GetContentItemList())
				{
					roleFavorContentItem.BindToggleFunction(new TRoleFavorContentItemToggleFunction(this.ContentItemToggleFunction));
					roleFavorContentItem.BindButtonFunction(new TRoleFavorContentItemButtonFunction(this.ContentItemButtonFunction));
					this.RoleFavorContentItemList.Add(roleFavorContentItem);
				}
			}
		}

		// Token: 0x060351A9 RID: 217513 RVA: 0x00D51BB4 File Offset: 0x00D4FDB4
		private void ContentItemToggleFunction(bool isSelect, RoleFavorContentDataBase contentItemData, RoleFavorContentItem roleFavorContentItem)
		{
			if (isSelect)
			{
				this.HideAllItem();
				this.SelectedContentData = contentItemData;
				this.LastSelectedRoleFavorContentItem = this.CurSelectedRoleFavorContentItem;
				this.ResetAllRoleFavorContentItemToggle();
				this.OnContentItemToggleClick(roleFavorContentItem, this.SelectedContentData);
			}
		}

		// Token: 0x060351AA RID: 217514 RVA: 0x00D51BE8 File Offset: 0x00D4FDE8
		protected void OnContentItemToggleClick(RoleFavorContentItem roleFavorContentItem, RoleFavorContentDataBase contentItemData)
		{
			EFavorItemStatus itemState = this.GetItemState(contentItemData);
			if (contentItemData.FavorContentType != EFavorContentType.ExperienceFile && itemState != EFavorItemStatus.ItemUnLocked)
			{
				this.HandleLockItemData();
				return;
			}
			IContentHandler contentHandler;
			if (this.GetContentHandlersMap().TryGetValue(contentItemData.FavorContentType, out contentHandler))
			{
				contentHandler.ShowItem(contentItemData);
				if (new Action<RoleFavorContentDataBase, RoleFavorContentItem>(contentHandler.PlayContent) != null)
				{
					contentHandler.PlayContent(contentItemData, roleFavorContentItem);
				}
			}
		}

		// Token: 0x060351AB RID: 217515 RVA: 0x00D51C44 File Offset: 0x00D4FE44
		private void ContentItemButtonFunction(RoleFavorContentDataBase contentItemData, RoleFavorContentItem roleFavorContentItem)
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RoleId);
			RoleFavorData favorData = roleInstanceById.GetFavorData();
			EFavorItemStatus efavorItemStatus;
			if (contentItemData.FavorContentType == EFavorContentType.Action)
			{
				efavorItemStatus = (EFavorItemStatus)ModelBase<MotionModel>.Instance.GetRoleMotionState(roleInstanceById.GetRoleId(), contentItemData.ConfigId);
			}
			else
			{
				efavorItemStatus = favorData.GetFavorItemState(contentItemData.ConfigId, contentItemData.FavorContentType);
			}
			if (contentItemData.FavorContentType != EFavorContentType.ExperienceFile && efavorItemStatus != EFavorItemStatus.ItemUnLocked)
			{
				return;
			}
			IContentHandler contentHandler;
			if (this.GetContentHandlersMap().TryGetValue(contentItemData.FavorContentType, out contentHandler) && new Action<RoleFavorContentDataBase, RoleFavorContentItem>(contentHandler.PlayContent) != null)
			{
				contentHandler.PlayContent(contentItemData, roleFavorContentItem);
			}
		}

		// Token: 0x060351AC RID: 217516 RVA: 0x00D51CDA File Offset: 0x00D4FEDA
		private RoleFavorClassifyItem CreateClassifyItem()
		{
			return new RoleFavorClassifyItem();
		}

		// Token: 0x060351AD RID: 217517 RVA: 0x00D51CE1 File Offset: 0x00D4FEE1
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.UnLockRoleFavorItem, new Action<int, int>(this.RoleFavorUnlock));
			Singleton<EventSystem>.Instance.Add<UiCameraAnimationDefine.IFinishData>(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnCameraFinish));
		}

		// Token: 0x060351AE RID: 217518 RVA: 0x00D51D1B File Offset: 0x00D4FF1B
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UnLockRoleFavorItem, new Action<int, int>(this.RoleFavorUnlock));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCameraAnimationFinish, new Action<UiCameraAnimationDefine.IFinishData>(this.OnCameraFinish));
		}

		// Token: 0x060351AF RID: 217519 RVA: 0x00D51D58 File Offset: 0x00D4FF58
		private void RoleFavorUnlock(int roleId, int unlockId)
		{
			if (roleId != this.RoleId)
			{
				return;
			}
			foreach (RoleFavorContentItem roleFavorContentItem in this.RoleFavorContentItemList)
			{
				if (roleFavorContentItem.ContentData.ConfigId == unlockId)
				{
					roleFavorContentItem.RefreshContentItem();
					this.ContentItemToggleFunction(true, roleFavorContentItem.ContentData, roleFavorContentItem);
				}
			}
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("30001", Array.Empty<object>());
		}

		// Token: 0x060351B0 RID: 217520 RVA: 0x00D51DE4 File Offset: 0x00D4FFE4
		private void OnCameraFinish(UiCameraAnimationDefine.IFinishData finishData)
		{
			if (finishData.ToHandleData.ViewName != EUiViewName.RoleFavorInfoView)
			{
				return;
			}
			base.GetItem(13).SetUIActive(false);
		}

		// Token: 0x060351B1 RID: 217521 RVA: 0x00D51E14 File Offset: 0x00D50014
		private void OnClickClose()
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			if (roleSystemRoleActor != null)
			{
				ControllerBase<RoleController>.Instance.SetRoleMorphType(roleSystemRoleActor, EUiModelMorphType.默认形态);
			}
			base.CloseMe(null);
		}

		// Token: 0x060351B2 RID: 217522 RVA: 0x00D51E42 File Offset: 0x00D50042
		protected override void OnHandleLoadScene()
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			object obj;
			if (roleSystemRoleActor == null)
			{
				obj = null;
			}
			else
			{
				UiModelBase model = roleSystemRoleActor.Model;
				obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 == null)
			{
				return;
			}
			obj2.SetTransformByTag("RoleCase");
		}

		// Token: 0x060351B3 RID: 217523 RVA: 0x00D51E78 File Offset: 0x00D50078
		private Dictionary<EFavorContentType, IContentHandler> GetContentHandlersMap()
		{
			if (this.ContentHandlersMap == null)
			{
				this.ContentHandlersMap = new Dictionary<EFavorContentType, IContentHandler>
				{
					{
						EFavorContentType.Action,
						ContentHandlerFactory.CreateContentHandler<RoleFavorActionContentData>(new Action<RoleFavorActionContentData>(this.ShowActionItem), new Action<RoleFavorActionContentData, RoleFavorContentItem>(this.PlayRoleMontage))
					},
					{
						EFavorContentType.ExperienceFile,
						ContentHandlerFactory.CreateContentHandler<RoleFavorRoleInfoContentData>(new Action<RoleFavorRoleInfoContentData>(this.ShowRoleInfoItem), null)
					},
					{
						EFavorContentType.ExperienceStory,
						ContentHandlerFactory.CreateContentHandler<RoleFavorStoryContentData>(new Action<RoleFavorStoryContentData>(this.ShowRoleStoryItem), null)
					},
					{
						EFavorContentType.PreciousItem,
						ContentHandlerFactory.CreateContentHandler<RoleFavorPreciousItemContentData>(new Action<RoleFavorPreciousItemContentData>(this.ShowPreciousItem), null)
					},
					{
						EFavorContentType.Voice,
						ContentHandlerFactory.CreateContentHandler<RoleFavorVoiceContentData>(new Action<RoleFavorVoiceContentData>(this.ShowVoiceItem), new Action<RoleFavorVoiceContentData, RoleFavorContentItem>(this.PlayVoice))
					}
				};
			}
			return this.ContentHandlersMap;
		}

		// Token: 0x0401E92A RID: 125226
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoleFavorClassifyItem, RoleFavorClassifyDataBase> ClassifyVerticalLayout;

		// Token: 0x0401E92B RID: 125227
		private List<RoleFavorClassifyDataBase> ClassifyDataList = new List<RoleFavorClassifyDataBase>();

		// Token: 0x0401E92C RID: 125228
		private readonly List<RoleFavorContentItem> RoleFavorContentItemList = new List<RoleFavorContentItem>();

		// Token: 0x0401E92D RID: 125229
		[Nullable(2)]
		private RoleFavorContentDataBase SelectedContentData;

		// Token: 0x0401E92E RID: 125230
		[Nullable(2)]
		private RoleFavorContentItem CurSelectedRoleFavorContentItem;

		// Token: 0x0401E92F RID: 125231
		[Nullable(2)]
		private RoleFavorContentItem LastSelectedRoleFavorContentItem;

		// Token: 0x0401E930 RID: 125232
		[Nullable(2)]
		private string VoicePath;

		// Token: 0x0401E931 RID: 125233
		private readonly int PlayFlag = 1;

		// Token: 0x0401E932 RID: 125234
		[Nullable(2)]
		private RoleFavorDescComponent RoleFavorDescComponent;

		// Token: 0x0401E933 RID: 125235
		[Nullable(2)]
		private RoleFavorBaseInfoComponent RoleFavorBaseInfoComponent;

		// Token: 0x0401E934 RID: 125236
		[Nullable(2)]
		private RoleFavorPowerInfoComponent RoleFavorPowerInfoComponent;

		// Token: 0x0401E935 RID: 125237
		[Nullable(2)]
		private RoleFavorPreciousItemComponent RoleFavorPreciousItemComponent;

		// Token: 0x0401E936 RID: 125238
		[Nullable(2)]
		private RoleFavorLockComponent RoleFavorLockComponent;

		// Token: 0x0401E937 RID: 125239
		private readonly PlayResult FavorInfoAudioResult = new PlayResult();

		// Token: 0x0401E938 RID: 125240
		private int RoleId;

		// Token: 0x0401E939 RID: 125241
		private EFavorTabType FavorTabType;

		// Token: 0x0401E93A RID: 125242
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EFavorContentType, IContentHandler> ContentHandlersMap;

		// Token: 0x0200B02C RID: 45100
		[NullableContext(0)]
		private enum ERoleFavorInfoViewDefine
		{
			// Token: 0x04036A73 RID: 223859
			CloseButton,
			// Token: 0x04036A74 RID: 223860
			ClassifyVerticalLayout,
			// Token: 0x04036A75 RID: 223861
			ClassifyIcon,
			// Token: 0x04036A76 RID: 223862
			ClassifyText,
			// Token: 0x04036A77 RID: 223863
			NameText,
			// Token: 0x04036A78 RID: 223864
			LockItem,
			// Token: 0x04036A79 RID: 223865
			DescItem,
			// Token: 0x04036A7A RID: 223866
			BaseInfoItem,
			// Token: 0x04036A7B RID: 223867
			PowerInfoItem,
			// Token: 0x04036A7C RID: 223868
			PreciousItem,
			// Token: 0x04036A7D RID: 223869
			DragItem,
			// Token: 0x04036A7E RID: 223870
			CVNameText,
			// Token: 0x04036A7F RID: 223871
			CVPanel,
			// Token: 0x04036A80 RID: 223872
			MaskPanel
		}
	}
}
