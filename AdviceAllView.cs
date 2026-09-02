using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Advice;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200177A RID: 6010
[NullableContext(2)]
[Nullable(0)]
public class AdviceAllView : UiViewBase
{
	// Token: 0x0600A93D RID: 43325 RVA: 0x002D1B32 File Offset: 0x002CFD32
	[NullableContext(1)]
	public AdviceAllView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A93E RID: 43326 RVA: 0x002D1B48 File Offset: 0x002CFD48
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickChangeBtn)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickChangeBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickSwitchButton)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickCreateButton))
		};
	}

	// Token: 0x0600A93F RID: 43327 RVA: 0x002D1D34 File Offset: 0x002CFF34
	protected override void OnStart()
	{
		this.AdviceSelectItem = new AdivceSelectItem(base.GetItem(6));
		this.AdviceSelectMotionItem = new AdviceSelectMotionItem(base.GetItem(7));
		this.AdviceSelectMotionItem.SetClickChangeRoleCall(new Action(this.OnClickChangeRole));
		this.AdviceAllViewShowContent = new AdviceAllViewShowContent(base.GetItem(8));
		this.Timer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimer), 1000f, 1f, null, null, true);
		this.ListCurrentEntityBattleTag();
	}

	// Token: 0x0600A940 RID: 43328 RVA: 0x002D1DBD File Offset: 0x002CFFBD
	protected override void OnBeforeShow()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView == null)
		{
			return;
		}
		CommonPopViewBase popItem = childPopView.PopItem;
		if (popItem == null)
		{
			return;
		}
		popItem.SetHelpButtonActive(false);
	}

	// Token: 0x0600A941 RID: 43329 RVA: 0x002D1DDC File Offset: 0x002CFFDC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceSelectItem, new Action(this.OnClickAdviceSelectItem));
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
		Singleton<EventSystem>.Instance.Add(EEventName.OnDeleteAdviceSuccess, new Action(this.OnDeleteAdvice));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectAdviceWord, new Action(this.RefreshConfirmBtn));
		Singleton<EventSystem>.Instance.Add(EEventName.OnChangeAdviceWord, new Action(this.RefreshConfirmBtn));
	}

	// Token: 0x0600A942 RID: 43330 RVA: 0x002D1E78 File Offset: 0x002D0078
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceSelectItem, new Action(this.OnClickAdviceSelectItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickAdviceMotion, new Action(this.OnClickMotion));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnDeleteAdviceSuccess, new Action(this.OnDeleteAdvice));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectAdviceWord, new Action(this.RefreshConfirmBtn));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeAdviceWord, new Action(this.RefreshConfirmBtn));
	}

	// Token: 0x0600A943 RID: 43331 RVA: 0x002D1F14 File Offset: 0x002D0114
	private void ListCurrentEntityBattleTag()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity != null && getCurrentEntity.Valid)
		{
			WorldEntity entity = getCurrentEntity.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				this.IsPlayerEnterFight = baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
				this.RemoveEnterFightTask();
				if (this.IsPlayerEnterFight)
				{
					base.CloseMe(null);
					return;
				}
				this.ListenPlayerEnterFight(getCurrentEntity);
			}
		}
	}

	// Token: 0x0600A944 RID: 43332 RVA: 0x002D1F85 File Offset: 0x002D0185
	private void RemoveEnterFightTask()
	{
		if (this.EnterFightTask != null)
		{
			((ITagTask)this.EnterFightTask).EndTask();
			this.EnterFightTask = null;
		}
	}

	// Token: 0x0600A945 RID: 43333 RVA: 0x002D1FA8 File Offset: 0x002D01A8
	[NullableContext(1)]
	private void ListenPlayerEnterFight(EntityHandle playerEntity)
	{
		WorldEntity entity = playerEntity.Entity;
		BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
		if (baseTagComponent != null)
		{
			this.EnterFightTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]), new BaseTagComponent.TTagSwitchedCallback(this.OnPlayerEnterFight), null);
		}
	}

	// Token: 0x0600A946 RID: 43334 RVA: 0x002D1FF8 File Offset: 0x002D01F8
	private void OnPlayerEnterFight(int tagId, bool tagExists)
	{
		this.IsPlayerEnterFight = tagExists;
		if (tagExists)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x0600A947 RID: 43335 RVA: 0x002D200B File Offset: 0x002D020B
	private void OnClickSwitchButton()
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceView();
	}

	// Token: 0x0600A948 RID: 43336 RVA: 0x002D2018 File Offset: 0x002D0218
	private void OnClickCreateButton()
	{
		if (ModelBase<AdviceModel>.Instance.GetIfCanCreateAdvice(ModelBase<AdviceModel>.Instance.CurrentLineModel))
		{
			global::Vector vector = global::Vector.Create();
			Rotator rotator = Rotator.Create();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (((baseCharacter != null) ? baseCharacter.CharacterActorComponent : null) != null)
			{
				vector.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
				global::Vector vector2 = vector;
				double z = vector2.Z;
				UCapsuleComponent capsuleComponent = baseCharacter.CharacterActorComponent.Actor.CapsuleComponent;
				vector2.Z = z - (double)((capsuleComponent != null) ? capsuleComponent.GetScaledCapsuleHalfHeight() : 0f);
				rotator.DeepCopy(baseCharacter.CharacterActorComponent.ActorRotationProxy);
				AActor currentCameraActor = ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor;
				if (currentCameraActor != null)
				{
					rotator.Yaw = currentCameraActor.D_GetTransform().Rotator().Yaw + 90f;
				}
				ControllerBase<AdviceController>.Instance.RequestCreateAdvice(vector, rotator, ModelBase<AdviceModel>.Instance.GetCreateAdviceContent(), delegate
				{
					base.CloseMe(null);
				});
				return;
			}
		}
		else
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("AdviceNeedFull", Array.Empty<object>());
		}
	}

	// Token: 0x0600A949 RID: 43337 RVA: 0x002D211B File Offset: 0x002D031B
	private void OnEnsureRole(int roleId)
	{
		this.RoleSelectionSelectedEvent(roleId);
	}

	// Token: 0x0600A94A RID: 43338 RVA: 0x002D2124 File Offset: 0x002D0324
	private void OnClickChangeRole()
	{
		int preSelectRoleId = ModelBase<AdviceModel>.Instance.PreSelectRoleId;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(preSelectRoleId);
		if (roleInstanceById == null)
		{
			return;
		}
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		TeamRoleSelectViewData data = new TeamRoleSelectViewData(EFilterSortGroupId.Role, roleInstanceById.GetRoleId(), roleList.Cast<RoleDataBase>().ToList<RoleDataBase>(), new Action<int>(this.OnEnsureRole), null, null, null);
		ControllerBase<RoleController>.Instance.OpenTeamRoleSelectView(data);
	}

	// Token: 0x0600A94B RID: 43339 RVA: 0x002D219C File Offset: 0x002D039C
	private void OnClickAdviceSelectItem()
	{
		EAdviceSelectItemEnum preSelectAdviceItemId = (EAdviceSelectItemEnum)ModelBase<AdviceModel>.Instance.PreSelectAdviceItemId;
		if (preSelectAdviceItemId == EAdviceSelectItemEnum.SelectWord1)
		{
			this.OnClickSelectWordBtn(0);
		}
		else if (preSelectAdviceItemId == EAdviceSelectItemEnum.Conjunction)
		{
			this.OnClickChangeConjunctionBtn();
		}
		else if (preSelectAdviceItemId == EAdviceSelectItemEnum.SelectWord2)
		{
			this.OnClickSelectWordBtn(1);
		}
		else if (preSelectAdviceItemId == EAdviceSelectItemEnum.AddExpression)
		{
			this.OnClickCurrentEmojiBtn();
		}
		else if (preSelectAdviceItemId == EAdviceSelectItemEnum.ChangeWordBtn)
		{
			this.OnClickChangeWordBtn();
		}
		else if (preSelectAdviceItemId == EAdviceSelectItemEnum.AddOrDecreaseBtn)
		{
			this.ChangeLineMode();
		}
		this.RefreshConfirmBtn();
	}

	// Token: 0x0600A94C RID: 43340 RVA: 0x002D2201 File Offset: 0x002D0401
	private void OnClickSelectWordBtn(int wordIndex)
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceWordSelectView(wordIndex);
	}

	// Token: 0x0600A94D RID: 43341 RVA: 0x002D220E File Offset: 0x002D040E
	private void OnClickChangeWordBtn()
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceSentenceSelectView();
	}

	// Token: 0x0600A94E RID: 43342 RVA: 0x002D221A File Offset: 0x002D041A
	private void OnClickChangeConjunctionBtn()
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceConjunctionSelectView();
	}

	// Token: 0x0600A94F RID: 43343 RVA: 0x002D2228 File Offset: 0x002D0428
	private void ChangeLineMode()
	{
		if (ModelBase<AdviceModel>.Instance.CurrentLineModel == ELineMode.SingleLine)
		{
			ModelBase<AdviceModel>.Instance.CurrentLineModel = ELineMode.MutiLine;
		}
		else
		{
			ModelBase<AdviceModel>.Instance.CurrentLineModel = ELineMode.SingleLine;
			ModelBase<AdviceModel>.Instance.OnChangeSentence(1);
			ModelBase<AdviceModel>.Instance.CurrentConjunctionId = 0;
		}
		this.RefreshView();
	}

	// Token: 0x0600A950 RID: 43344 RVA: 0x002D2275 File Offset: 0x002D0475
	private void OnClickCurrentEmojiBtn()
	{
		ControllerBase<AdviceController>.Instance.OpenAdviceExpressionView();
	}

	// Token: 0x0600A951 RID: 43345 RVA: 0x002D2281 File Offset: 0x002D0481
	protected override void OnAfterShow()
	{
		this.CurrentViewState = new int?(0);
		ModelBase<AdviceModel>.Instance.CurrentLineModel = ELineMode.SingleLine;
		this.RefreshView();
		this.ShowAdviceModel();
		this.RefreshTitle();
	}

	// Token: 0x0600A952 RID: 43346 RVA: 0x002D22AC File Offset: 0x002D04AC
	private void RefreshTitle()
	{
		IUiPopFrameInterface childPopView = this.ChildPopView;
		if (childPopView == null)
		{
			return;
		}
		childPopView.SetTitleByTextIdAndArg("AdviceName", Array.Empty<object>());
	}

	// Token: 0x0600A953 RID: 43347 RVA: 0x002D22C8 File Offset: 0x002D04C8
	private void OnTimer(float deltaTime)
	{
		this.CurrentRunningTime += 1000;
		if (this.CurrentRunningTime >= 5000)
		{
			int? currentViewState = this.CurrentViewState;
			int num = 0;
			if (!(currentViewState.GetValueOrDefault() == num & currentViewState != null))
			{
				this.OnClickMotion();
			}
		}
	}

	// Token: 0x0600A954 RID: 43348 RVA: 0x002D2318 File Offset: 0x002D0518
	private void ShowAdviceModel()
	{
		this.TryEnableEntity();
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (((getCurrentEntity != null) ? getCurrentEntity.Entity : null) != null)
		{
			this.EntityDisableHandle = getCurrentEntity.Entity.Disable("[AdviceCreate DisableCharacter]");
		}
		this.AdviceCreateActor = ModelBase<AdviceModel>.Instance.GetAdviceCreateActor();
	}

	// Token: 0x0600A955 RID: 43349 RVA: 0x002D236A File Offset: 0x002D056A
	private void TryEnableEntity()
	{
		if (this.EntityDisableHandle > 0)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity != null)
			{
				WorldEntity entity = getCurrentEntity.Entity;
				if (entity != null)
				{
					entity.Enable(this.EntityDisableHandle, "AdviceAllView.TryEnableEntity");
				}
			}
			this.EntityDisableHandle = 0;
		}
	}

	// Token: 0x0600A956 RID: 43350 RVA: 0x002D23A8 File Offset: 0x002D05A8
	private void OnClickMotion()
	{
		this.CurrentRunningTime = 0;
		if (ModelBase<AdviceModel>.Instance.PreSelectMotionId == ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId())
		{
			AdviceCreateActor adviceCreateActor = this.AdviceCreateActor;
			if (adviceCreateActor == null)
			{
				return;
			}
			adviceCreateActor.HideAnimation();
			return;
		}
		else
		{
			AdviceCreateActor adviceCreateActor2 = this.AdviceCreateActor;
			if (adviceCreateActor2 == null)
			{
				return;
			}
			adviceCreateActor2.PlayAnimation(ModelBase<AdviceModel>.Instance.PreSelectMotionId);
			return;
		}
	}

	// Token: 0x0600A957 RID: 43351 RVA: 0x002D23FD File Offset: 0x002D05FD
	private void OnDeleteAdvice()
	{
		this.RefreshView();
		this.RefreshSwitchBtnRedPoint();
		this.RefreshConfirmBtn();
	}

	// Token: 0x0600A958 RID: 43352 RVA: 0x002D2414 File Offset: 0x002D0614
	private void RoleSelectionSelectedEvent(int roleId)
	{
		ModelBase<AdviceModel>.Instance.PreSelectRoleId = roleId;
		ModelBase<AdviceModel>.Instance.PreSelectMotionId = ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId();
		ModelBase<AdviceModel>.Instance.CurrentSelectMotionId = ConfigBase<AdviceConfig>.Instance.GetAdviceMotionDefaultConfigId();
		AdviceSelectMotionItem adviceSelectMotionItem = this.AdviceSelectMotionItem;
		if (adviceSelectMotionItem != null)
		{
			adviceSelectMotionItem.RefreshView(ModelBase<AdviceModel>.Instance.GetMotionSelectData());
		}
		this.OnClickMotion();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeAdviceRole);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickAdviceMotion);
	}

	// Token: 0x0600A959 RID: 43353 RVA: 0x002D2498 File Offset: 0x002D0698
	private void OnClickChangeBtn()
	{
		int? currentViewState = this.CurrentViewState;
		int num = 0;
		if (currentViewState.GetValueOrDefault() == num & currentViewState != null)
		{
			this.CurrentViewState = new int?(1);
		}
		else
		{
			this.CurrentViewState = new int?(0);
		}
		currentViewState = this.CurrentViewState;
		num = 0;
		if (currentViewState.GetValueOrDefault() == num & currentViewState != null)
		{
			AdviceCreateActor adviceCreateActor = this.AdviceCreateActor;
			if (adviceCreateActor != null)
			{
				adviceCreateActor.HideAnimation();
			}
		}
		else
		{
			this.OnClickMotion();
		}
		this.RefreshView();
	}

	// Token: 0x0600A95A RID: 43354 RVA: 0x002D2518 File Offset: 0x002D0718
	private void RefreshView()
	{
		this.RefreshContentView();
		this.RefreshStateText();
		this.RefreshSwitchBtnRedPoint();
		this.RefreshConfirmBtn();
		AdviceAllViewShowContent adviceAllViewShowContent = this.AdviceAllViewShowContent;
		if (adviceAllViewShowContent == null)
		{
			return;
		}
		adviceAllViewShowContent.RefreshView();
	}

	// Token: 0x0600A95B RID: 43355 RVA: 0x002D2544 File Offset: 0x002D0744
	private void RefreshStateText()
	{
		if (this.CurrentViewState.GetValueOrDefault() == 1)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "Motion", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "TextAndExpression", Array.Empty<object>());
	}

	// Token: 0x0600A95C RID: 43356 RVA: 0x002D2598 File Offset: 0x002D0798
	private void RefreshContentView()
	{
		bool flag = false;
		if (!ModelBase<AdviceModel>.Instance.GetCreateConditionState())
		{
			if (ModelBase<AdviceModel>.Instance.CheckIfMaxAdvice())
			{
				flag = false;
			}
			else
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(9);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(12);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				UUIButtonComponent button = base.GetButton(4);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				AdviceAllViewShowContent adviceAllViewShowContent = this.AdviceAllViewShowContent;
				if (adviceAllViewShowContent != null)
				{
					adviceAllViewShowContent.SetActive(false);
				}
				this.RefreshCreateLimitText();
				flag = true;
			}
		}
		if (!flag)
		{
			UUIItem item4 = base.GetItem(12);
			if (item4 != null)
			{
				item4.SetUIActive(true);
			}
			UUIItem item5 = base.GetItem(0);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(9);
			if (item6 != null)
			{
				item6.SetUIActive(true);
			}
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(true);
			}
			AdviceAllViewShowContent adviceAllViewShowContent2 = this.AdviceAllViewShowContent;
			if (adviceAllViewShowContent2 != null)
			{
				adviceAllViewShowContent2.SetActive(true);
			}
			if (this.CurrentViewState.GetValueOrDefault() == 1)
			{
				AdivceSelectItem adviceSelectItem = this.AdviceSelectItem;
				if (adviceSelectItem != null)
				{
					adviceSelectItem.SetActive(false);
				}
				AdviceSelectMotionItem adviceSelectMotionItem = this.AdviceSelectMotionItem;
				if (adviceSelectMotionItem != null)
				{
					adviceSelectMotionItem.SetActive(true);
				}
				UUIItem item7 = base.GetItem(13);
				if (item7 != null)
				{
					item7.SetUIActive(true);
				}
				AdviceSelectMotionItem adviceSelectMotionItem2 = this.AdviceSelectMotionItem;
				if (adviceSelectMotionItem2 == null)
				{
					return;
				}
				adviceSelectMotionItem2.RefreshView(ModelBase<AdviceModel>.Instance.GetMotionSelectData());
				return;
			}
			else
			{
				UUIItem item8 = base.GetItem(13);
				if (item8 != null)
				{
					item8.SetUIActive(false);
				}
				AdviceSelectMotionItem adviceSelectMotionItem3 = this.AdviceSelectMotionItem;
				if (adviceSelectMotionItem3 != null)
				{
					adviceSelectMotionItem3.SetActive(false);
				}
				AdivceSelectItem adviceSelectItem2 = this.AdviceSelectItem;
				if (adviceSelectItem2 != null)
				{
					adviceSelectItem2.SetActive(true);
				}
				AdivceSelectItem adviceSelectItem3 = this.AdviceSelectItem;
				if (adviceSelectItem3 == null)
				{
					return;
				}
				adviceSelectItem3.RefreshView(ModelBase<AdviceModel>.Instance.GetAdviceSelectData(ModelBase<AdviceModel>.Instance.CurrentLineModel));
			}
		}
	}

	// Token: 0x0600A95D RID: 43357 RVA: 0x002D276B File Offset: 0x002D096B
	private void RefreshCreateLimitText()
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(14), ModelBase<AdviceModel>.Instance.GetCreateConditionFailText(), Array.Empty<object>());
	}

	// Token: 0x0600A95E RID: 43358 RVA: 0x002D2790 File Offset: 0x002D0990
	private void RefreshSwitchBtnRedPoint()
	{
		AdviceData[] adviceArray = ModelBase<AdviceModel>.Instance.GetAdviceArray();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("AdviceCreateLimit").GetValueOrDefault();
		UUIItem item = base.GetItem(10);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(adviceArray != null && adviceArray.Length >= valueOrDefault);
	}

	// Token: 0x0600A95F RID: 43359 RVA: 0x002D27DC File Offset: 0x002D09DC
	private void RefreshConfirmBtn()
	{
		AdviceData[] adviceArray = ModelBase<AdviceModel>.Instance.GetAdviceArray();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("AdviceCreateLimit").GetValueOrDefault();
		object obj = adviceArray != null && adviceArray.Length >= valueOrDefault;
		bool ifCanCreateAdvice = ModelBase<AdviceModel>.Instance.GetIfCanCreateAdvice(ModelBase<AdviceModel>.Instance.CurrentLineModel);
		object obj2 = obj;
		if (obj2 != null || !ifCanCreateAdvice)
		{
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				button.SetSelfInteractive(false);
			}
		}
		else
		{
			UUIButtonComponent button2 = base.GetButton(4);
			if (button2 != null)
			{
				button2.SetSelfInteractive(true);
			}
		}
		if (obj2 != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "Advice_Max", Array.Empty<object>());
			return;
		}
		if (!ifCanCreateAdvice)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "AdviceNotFull", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(11), "Advice_Publish", Array.Empty<object>());
	}

	// Token: 0x0600A960 RID: 43360 RVA: 0x002D28B4 File Offset: 0x002D0AB4
	protected override void OnBeforeDestroy()
	{
		AdviceCreateActor adviceCreateActor = this.AdviceCreateActor;
		if (adviceCreateActor != null)
		{
			adviceCreateActor.Destroy();
		}
		this.TryEnableEntity();
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
		}
	}

	// Token: 0x04004FC8 RID: 20424
	private const int CHECKTIMEER = 1000;

	// Token: 0x04004FC9 RID: 20425
	private const int ANIMATIONGAP = 5000;

	// Token: 0x04004FCA RID: 20426
	private int EntityDisableHandle;

	// Token: 0x04004FCB RID: 20427
	private int? CurrentViewState = new int?(0);

	// Token: 0x04004FCC RID: 20428
	private AdivceSelectItem AdviceSelectItem;

	// Token: 0x04004FCD RID: 20429
	private AdviceSelectMotionItem AdviceSelectMotionItem;

	// Token: 0x04004FCE RID: 20430
	private AdviceAllViewShowContent AdviceAllViewShowContent;

	// Token: 0x04004FCF RID: 20431
	private AdviceCreateActor AdviceCreateActor;

	// Token: 0x04004FD0 RID: 20432
	private TimerHandle Timer;

	// Token: 0x04004FD1 RID: 20433
	private int CurrentRunningTime;

	// Token: 0x04004FD2 RID: 20434
	private object EnterFightTask;

	// Token: 0x04004FD3 RID: 20435
	private bool IsPlayerEnterFight;

	// Token: 0x02007ADC RID: 31452
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A129 RID: 172329
		public const int CanNotCreateTips = 0;

		// Token: 0x0402A12A RID: 172330
		public const int LeftBtn = 1;

		// Token: 0x0402A12B RID: 172331
		public const int RightBtn = 2;

		// Token: 0x0402A12C RID: 172332
		public const int BtnText = 3;

		// Token: 0x0402A12D RID: 172333
		public const int CreateBtn = 4;

		// Token: 0x0402A12E RID: 172334
		public const int SwitchBtn = 5;

		// Token: 0x0402A12F RID: 172335
		public const int SelectItem = 6;

		// Token: 0x0402A130 RID: 172336
		public const int MotionItem = 7;

		// Token: 0x0402A131 RID: 172337
		public const int WordItem = 8;

		// Token: 0x0402A132 RID: 172338
		public const int ContentItem = 9;

		// Token: 0x0402A133 RID: 172339
		public const int SwitchBtnRedPoint = 10;

		// Token: 0x0402A134 RID: 172340
		public const int ConfirmBtnText = 11;

		// Token: 0x0402A135 RID: 172341
		public const int SwitchContainer = 12;

		// Token: 0x0402A136 RID: 172342
		public const int RoleContainer = 13;

		// Token: 0x0402A137 RID: 172343
		public const int CreateLimitText = 14;

		// Token: 0x0402A138 RID: 172344
		public const int CreateLimitTipsText = 15;
	}

	// Token: 0x02007ADD RID: 31453
	[NullableContext(0)]
	private static class EViewState
	{
		// Token: 0x0402A139 RID: 172345
		public const int Normal = 0;

		// Token: 0x0402A13A RID: 172346
		public const int Motion = 1;
	}
}
