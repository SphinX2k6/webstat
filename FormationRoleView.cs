using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B59 RID: 7001
[NullableContext(2)]
[Nullable(0)]
public class FormationRoleView : FormationRoleSlot
{
	// Token: 0x0600CA87 RID: 51847 RVA: 0x0035E7EF File Offset: 0x0035C9EF
	public FormationRoleView(int position)
	{
		this.Position = position;
	}

	// Token: 0x0600CA88 RID: 51848 RVA: 0x0035E800 File Offset: 0x0035CA00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 44;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(43, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickChooseButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CA89 RID: 51849 RVA: 0x0035EE34 File Offset: 0x0035D034
	private void OnClickChooseButton()
	{
		if (this.DragLogicFirst)
		{
			return;
		}
		Action<int> onSelectRole = this.OnSelectRole;
		if (onSelectRole == null)
		{
			return;
		}
		onSelectRole(this.Position);
	}

	// Token: 0x0600CA8A RID: 51850 RVA: 0x0035EE55 File Offset: 0x0035D055
	[NullableContext(1)]
	public void BindOnSelectRole(Action<int> onSelectRole)
	{
		this.OnSelectRole = onSelectRole;
	}

	// Token: 0x0600CA8B RID: 51851 RVA: 0x0035EE60 File Offset: 0x0035D060
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefensePhantomChanged, new Action(this.HandleOnConfirmPhantom));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, int[]>>(EEventName.RefreshFormationDango, new Action<IReadOnlyDictionary<int, int[]>>(this.OnSelectDango));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnSkillBranchInGamePlayChanged));
	}

	// Token: 0x0600CA8C RID: 51852 RVA: 0x0035EEC4 File Offset: 0x0035D0C4
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefensePhantomChanged, new Action(this.HandleOnConfirmPhantom));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyDictionary<int, int[]>>(EEventName.RefreshFormationDango, new Action<IReadOnlyDictionary<int, int[]>>(this.OnSelectDango));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkillBranchInGamePlayChanged, new Action<int>(this.OnSkillBranchInGamePlayChanged));
	}

	// Token: 0x0600CA8D RID: 51853 RVA: 0x0035EF28 File Offset: 0x0035D128
	protected override UniTask OnBeforeStartAsync()
	{
		FormationRoleView.<OnBeforeStartAsync>d__38 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FormationRoleView.<OnBeforeStartAsync>d__38>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CA8E RID: 51854 RVA: 0x0035EF6C File Offset: 0x0035D16C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.PlayerInLevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.PlayerOutLevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.CircleInLevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.CircleOutLevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetItem(7).SetAlpha(0f);
		UUIDraggableComponent draggable = base.GetDraggable(37);
		draggable.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
		draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
		draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
		this.RoleItem = base.GetItem(5);
	}

	// Token: 0x0600CA8F RID: 51855 RVA: 0x0035F050 File Offset: 0x0035D250
	private void OnPointerUp(ULGUIPointerEventData _)
	{
		this.NeedTick = false;
		this.EndShowDragItem();
		this.StopMove(null);
	}

	// Token: 0x0600CA90 RID: 51856 RVA: 0x0035F07C File Offset: 0x0035D27C
	private void OnPointerDown(ULGUIPointerEventData eventData)
	{
		if (this.ConfigId != null)
		{
			int? playerInternal = this.PlayerInternal;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (playerInternal.GetValueOrDefault() == id.GetValueOrDefault() & playerInternal != null == (id != null))
			{
				if (this.IsDragDisabled)
				{
					return;
				}
				this.NeedTick = true;
				this.StartDragTime = 0f;
				Action<ULGUIPointerEventData, int, int, int> onPointDown = this.OnPointDown;
				if (onPointDown == null)
				{
					return;
				}
				onPointDown(eventData, this.ConfigId.GetValueOrDefault(), this.SkinId.GetValueOrDefault(), this.Position);
				return;
			}
		}
	}

	// Token: 0x0600CA91 RID: 51857 RVA: 0x0035F114 File Offset: 0x0035D314
	public override void GamePadPress()
	{
		if (this.ConfigId != null)
		{
			int? playerInternal = this.PlayerInternal;
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			if (playerInternal.GetValueOrDefault() == id.GetValueOrDefault() & playerInternal != null == (id != null))
			{
				if (this.IsDragDisabled)
				{
					return;
				}
				this.NeedTick = true;
				this.StartDragTime = 0f;
				Action<UUIItem, int, int, int> onGamePadDown = this.OnGamePadDown;
				if (onGamePadDown == null)
				{
					return;
				}
				onGamePadDown(base.GetRootItem(), this.ConfigId.GetValueOrDefault(), this.SkinId.GetValueOrDefault(), this.Position);
				return;
			}
		}
	}

	// Token: 0x0600CA92 RID: 51858 RVA: 0x0035F1B1 File Offset: 0x0035D3B1
	public override void GamePadRelease()
	{
		if (!this.DragLogicFirst)
		{
			Action<int> onSelectRole = this.OnSelectRole;
			if (onSelectRole != null)
			{
				onSelectRole(this.Position);
			}
			this.NeedTick = false;
			return;
		}
	}

	// Token: 0x0600CA93 RID: 51859 RVA: 0x0035F1DA File Offset: 0x0035D3DA
	public override void GamePadUp(bool isCancel = false)
	{
		if (this.ConfigId == null)
		{
			return;
		}
		this.NeedTick = false;
		this.EndShowDragItem();
		this.StopMove(new bool?(isCancel));
	}

	// Token: 0x0600CA94 RID: 51860 RVA: 0x0035F203 File Offset: 0x0035D403
	public override void MouseCancelDrag()
	{
		if (this.ConfigId == null)
		{
			return;
		}
		this.NeedTick = false;
		this.EndShowDragItem();
		this.StopMove(new bool?(true));
	}

	// Token: 0x0600CA95 RID: 51861 RVA: 0x0035F22C File Offset: 0x0035D42C
	private void OnPointerDrag(ULGUIPointerEventData eventData)
	{
		if (eventData == null || !this.StartDrag)
		{
			return;
		}
		Action<ULGUIPointerEventData> onDragMove = this.OnDragMove;
		if (onDragMove == null)
		{
			return;
		}
		onDragMove(eventData);
	}

	// Token: 0x0600CA96 RID: 51862 RVA: 0x0035F24C File Offset: 0x0035D44C
	public void OnTick(float delta)
	{
		if (!this.NeedTick)
		{
			this.DragLogicFirst = false;
			return;
		}
		this.StartDragTime += delta;
		if (this.StartDragTime > 750f)
		{
			this.StartMoveDragItem();
			return;
		}
		if (this.StartDragTime > 250f)
		{
			this.StartShowDragItem();
			return;
		}
		this.DragLogicFirst = false;
	}

	// Token: 0x0600CA97 RID: 51863 RVA: 0x0035F2A8 File Offset: 0x0035D4A8
	private void StartShowDragItem()
	{
		this.DragLogicFirst = true;
		if (this.IsPlayingCircleIn)
		{
			LevelSequencePlayer circleInLevelSequencePlayer = this.CircleInLevelSequencePlayer;
			if (circleInLevelSequencePlayer != null)
			{
				circleInLevelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer circleOutLevelSequencePlayer = this.CircleOutLevelSequencePlayer;
			if (circleOutLevelSequencePlayer != null)
			{
				circleOutLevelSequencePlayer.PlaySequencePurely("CircleOut", false, false, null, null, false);
			}
			this.IsPlayingCircleIn = false;
		}
		base.GetItem(40).SetUIActive(false);
		FormationRoleDragStateItem dragStateItem = this.DragStateItem;
		if (dragStateItem == null)
		{
			return;
		}
		dragStateItem.SetBarFill((this.StartDragTime - 250f) / 500f);
	}

	// Token: 0x0600CA98 RID: 51864 RVA: 0x0035F334 File Offset: 0x0035D534
	public override void EndShowDragItem()
	{
		if (this.IsPlayingCircleIn)
		{
			LevelSequencePlayer circleInLevelSequencePlayer = this.CircleInLevelSequencePlayer;
			if (circleInLevelSequencePlayer != null)
			{
				circleInLevelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer circleOutLevelSequencePlayer = this.CircleOutLevelSequencePlayer;
			if (circleOutLevelSequencePlayer != null)
			{
				circleOutLevelSequencePlayer.PlaySequencePurely("CircleOut", false, false, null, null, false);
			}
			this.IsPlayingCircleIn = false;
		}
		base.GetItem(40).SetUIActive(false);
		FormationRoleDragStateItem dragStateItem = this.DragStateItem;
		if (dragStateItem == null)
		{
			return;
		}
		dragStateItem.SetBarFill(0f);
	}

	// Token: 0x0600CA99 RID: 51865 RVA: 0x0035F3AC File Offset: 0x0035D5AC
	private void StartMoveDragItem()
	{
		if (this.StartDrag)
		{
			return;
		}
		this.StartDrag = true;
		FormationSkillBranchItem skillBranchToggleItem = this.SkillBranchToggleItem;
		if (skillBranchToggleItem != null)
		{
			skillBranchToggleItem.SetUiActive(false);
		}
		this.EndShowDragItem();
		Action onDragStart = this.OnDragStart;
		if (onDragStart != null)
		{
			onDragStart();
		}
		this.RoleItem.SetUIActive(false);
		base.GetItem(42).SetUIActive(false);
		base.GetItem(1).SetUIActive(true);
		base.GetItem(1).SetAlpha(1f);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600CA9A RID: 51866 RVA: 0x0035F438 File Offset: 0x0035D638
	private void StopMove(bool? isCancel = null)
	{
		if (this.ConfigId == null || !this.StartDrag)
		{
			return;
		}
		this.StartDrag = false;
		this.RoleItem.SetUIActive(true);
		base.GetItem(42).SetUIActive(true);
		base.GetItem(1).SetAlpha(0f);
		base.GetItem(3).SetUIActive(true);
		this.RefreshSkillBranch(this.ConfigId.GetValueOrDefault(), this.PlayerInternal ?? ModelBase<PlayerInfoModel>.Instance.GetId().Value);
		Action<bool?> onDragEnd = this.OnDragEnd;
		if (onDragEnd == null)
		{
			return;
		}
		onDragEnd(isCancel);
	}

	// Token: 0x0600CA9B RID: 51867 RVA: 0x0035F4E8 File Offset: 0x0035D6E8
	public override void ShowOtherItemUpState()
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? playerInternal = this.PlayerInternal;
		if (id.GetValueOrDefault() == playerInternal.GetValueOrDefault() & id != null == (playerInternal != null))
		{
			if (!this.IsPlayingCircleIn && !this.StartDrag)
			{
				LevelSequencePlayer circleInLevelSequencePlayer = this.CircleInLevelSequencePlayer;
				if (circleInLevelSequencePlayer != null)
				{
					circleInLevelSequencePlayer.PlaySequencePurely("CircleIn", false, false, null, null, false);
				}
				this.IsPlayingCircleIn = true;
			}
			base.GetItem(40).SetUIActive(true);
			return;
		}
		base.GetItem(39).SetUIActive(true);
	}

	// Token: 0x0600CA9C RID: 51868 RVA: 0x0035F584 File Offset: 0x0035D784
	public override void RefreshLockItemState(bool isDrag)
	{
		if (!isDrag)
		{
			base.GetItem(39).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		if (this.ConfigId.GetValueOrDefault() > 0)
		{
			int? num = id;
			int? playerInternal = this.PlayerInternal;
			if (num.GetValueOrDefault() == playerInternal.GetValueOrDefault() & num != null == (playerInternal != null))
			{
				return;
			}
		}
		base.GetItem(39).SetUIActive(true);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600CA9D RID: 51869 RVA: 0x0035F610 File Offset: 0x0035D810
	public override int GetPlayerId()
	{
		return this.PlayerInternal.GetValueOrDefault();
	}

	// Token: 0x0600CA9E RID: 51870 RVA: 0x0035F61D File Offset: 0x0035D81D
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		this.PhantomExtensionComponent = null;
		this.AbyssDangoExtensionComponent = null;
	}

	// Token: 0x0600CA9F RID: 51871 RVA: 0x0035F648 File Offset: 0x0035D848
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (this.PhantomExtensionComponent != null && configParams[0].Contains("FirstSelf"))
		{
			if (configParams.Length < 2)
			{
				return null;
			}
			UUIItem[] guideUiItemAndUiItemForShowEx = this.PhantomExtensionComponent.GetGuideUiItemAndUiItemForShowEx(configParams);
			if (guideUiItemAndUiItemForShowEx == null)
			{
				return null;
			}
			if (configParams[1] == "G")
			{
				guideUiItemAndUiItemForShowEx[1] = base.GetButton(0).RootUIComp;
			}
			return guideUiItemAndUiItemForShowEx;
		}
		else
		{
			if (this.AbyssDangoExtensionComponent != null && configParams[0].Contains("FirstDangoSlot"))
			{
				return this.AbyssDangoExtensionComponent.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			return null;
		}
	}

	// Token: 0x0600CAA0 RID: 51872 RVA: 0x0035F6D0 File Offset: 0x0035D8D0
	[NullableContext(1)]
	public void Refresh(int configId, int roleSkinId, int level, string name, int onlineIndex, int playerId, string thirdPartyOnlineId, bool canUseSpecialTrialRole = true)
	{
		if (configId != 0)
		{
			int? configId2 = this.ConfigId;
			if (!(configId2.GetValueOrDefault() == configId & configId2 != null))
			{
				base.GetItem(5).SetUIActive(true);
				LevelSequencePlayer playerOutLevelSequencePlayer = this.PlayerOutLevelSequencePlayer;
				if (playerOutLevelSequencePlayer != null)
				{
					playerOutLevelSequencePlayer.StopSequenceByKey("PlayerOut", false, false);
				}
			}
		}
		base.GetItem(42).SetUIActive(configId > 0);
		this.RefreshRoleInfo(configId, roleSkinId, level, name, playerId, canUseSpecialTrialRole);
		this.RefreshTowerCost(configId);
		this.RefreshWeeklyRogueTag();
		this.RefreshOnlineState(onlineIndex, playerId);
		this.RefreshThirdPartyItem(thirdPartyOnlineId);
		this.IsMatching = false;
		this.RefreshMatchView(false);
		this.RefreshPhantomExtension();
		this.RefreshDangoExtension();
		base.GetItem(15).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
	}

	// Token: 0x0600CAA1 RID: 51873 RVA: 0x0035F7A4 File Offset: 0x0035D9A4
	public void RefreshThirdPartyItem(string onlineId)
	{
		bool flag = ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId();
		bool flag2 = ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon || ModelBase<GameModeModel>.Instance.IsMulti;
		if (flag && flag2)
		{
			UUIItem item = base.GetItem(28);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			if (!string.IsNullOrEmpty(onlineId))
			{
				UUIText text = base.GetText(31);
				if (text != null)
				{
					text.SetText(onlineId, true);
				}
				UUIText text2 = base.GetText(31);
				if (text2 != null)
				{
					text2.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(30);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUITexture texture = base.GetTexture(29);
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
				string thirdPartyLogoTexturePath = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyLogoTexturePath(ELogoSize.Medium);
				base.SetTextureByPath(thirdPartyLogoTexturePath, base.GetTexture(29), null, null);
				string thirdPartyTextColor = ConfigBase<UiResourceConfig>.Instance.GetThirdPartyTextColor(EConsoleColorSet.Set1);
				UUIText text3 = base.GetText(31);
				if (text3 == null)
				{
					return;
				}
				text3.SetColor(FColor.FromHex(thirdPartyTextColor));
				return;
			}
			else
			{
				UUIText text4 = base.GetText(31);
				if (text4 != null)
				{
					text4.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(30);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUITexture texture2 = base.GetTexture(29);
				if (texture2 == null)
				{
					return;
				}
				texture2.SetUIActive(false);
				return;
			}
		}
		else
		{
			UUIItem item4 = base.GetItem(28);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIText text5 = base.GetText(31);
			if (text5 != null)
			{
				text5.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(30);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUITexture texture3 = base.GetTexture(29);
			if (texture3 == null)
			{
				return;
			}
			texture3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600CAA2 RID: 51874 RVA: 0x0035F924 File Offset: 0x0035DB24
	[NullableContext(1)]
	private void RefreshRoleInfo(int configId, int roleSkinId, int level, string name, int playerId, bool canUseSpecialTrialRole)
	{
		FormationRoleView.<>c__DisplayClass64_0 CS$<>8__locals1 = new FormationRoleView.<>c__DisplayClass64_0();
		this.ConfigId = new int?(configId);
		this.SkinId = new int?(roleSkinId);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(configId);
		RoleSkin? roleSkin = (roleSkinId != 0) ? ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId) : null;
		if (roleConfig == null)
		{
			return;
		}
		UUIText text = base.GetText(8);
		if (text != null)
		{
			if (string.IsNullOrEmpty(name))
			{
				text.SetUIActive(false);
			}
			else
			{
				text.SetUIActive(true);
				text.SetText(name, true);
			}
		}
		int elementId = roleConfig.Value.ElementId;
		if (this.MiniElementItem == null)
		{
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				this.MiniElementItem = new MiniElementItem(elementId, item, item.GetOwner());
			}
		}
		MiniElementItem miniElementItem = this.MiniElementItem;
		if (miniElementItem != null)
		{
			miniElementItem.RefreshMiniElement(elementId);
		}
		CS$<>8__locals1.roleItem = base.GetItem(7);
		CS$<>8__locals1.roleSpine = base.GetSpine(6);
		CS$<>8__locals1.roleItem.SetAlpha(0f);
		string atlasPath = (roleSkin != null) ? roleSkin.Value.FormationSpineAtlas : roleConfig.Value.FormationSpineAtlas;
		string skeletonPath = (roleSkin != null) ? roleSkin.Value.FormationSpineSkeletonData : roleConfig.Value.FormationSpineSkeletonData;
		FormationRoleView.<>c__DisplayClass64_0 CS$<>8__locals2 = CS$<>8__locals1;
		float[] param;
		if (roleSkin == null)
		{
			(param = new float[3])[2] = 1f;
		}
		else
		{
			param = roleSkin.Value.GetSpineParamArray();
		}
		CS$<>8__locals2.param = param;
		base.SetSpineAssetByPath(atlasPath, skeletonPath, CS$<>8__locals1.roleSpine).ContinueWith(delegate()
		{
			CS$<>8__locals1.roleItem.SetAlpha(1f);
			CS$<>8__locals1.roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			CS$<>8__locals1.roleItem.SetAnchorOffsetX(CS$<>8__locals1.param[0]);
			CS$<>8__locals1.roleItem.SetAnchorOffsetY(CS$<>8__locals1.param[1]);
			CS$<>8__locals1.roleItem.SetUIItemScale(new FVector(CS$<>8__locals1.param[2], CS$<>8__locals1.param[2], CS$<>8__locals1.param[2]));
		});
		UUIArtText artText = base.GetArtText(9);
		if (artText != null)
		{
			artText.SetText(level.ToString());
		}
		base.GetItem(25).SetUIActive(false);
		bool flag = !ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon && ModelBase<RoleModel>.Instance.GetRoleDataById(configId, true).IsTrialRole();
		bool flag2 = true;
		if (ModelBase<GameModeModel>.Instance.IsMulti || ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon)
		{
			flag2 = (playerId == ModelBase<CreatureModel>.Instance.GetPlayerId());
		}
		this.IsDead = false;
		if (flag2 && !flag && !ModelBase<TowerModel>.Instance.IsOpenFloorFormation() && !ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
		{
			this.IsDead = ModelBase<EditFormationModel>.Instance.IsRoleDead(configId);
			if (this.IsDead)
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(configId, true);
				RoleAttributeData roleAttributeData = (roleDataById != null) ? roleDataById.GetAttributeData() : null;
				int num = (roleAttributeData != null) ? roleAttributeData.GetAttrValueById(3) : 0;
				this.IsDead = (num <= 0);
			}
		}
		base.GetItem(24).SetUIActive(this.IsDead);
		this.RefreshTrialRoleExtension(configId);
		this.RefreshSpecialTrialRoleExtension(configId, canUseSpecialTrialRole);
		this.RefreshSkillBranch(configId, playerId);
	}

	// Token: 0x0600CAA3 RID: 51875 RVA: 0x0035FBF8 File Offset: 0x0035DDF8
	private void RefreshOnlineState(int onlineIndex, int playerId)
	{
		bool flag = onlineIndex > 0;
		base.GetItem(12).SetUIActive(flag);
		base.GetSprite(14).SetUIActive(false);
		if (flag)
		{
			bool flag2 = playerId == ModelBase<CreatureModel>.Instance.GetPlayerId();
			string inString = flag2 ? "SP_Online{0}PIcon_Self" : "SP_Online{0}PIcon";
			this.LevelSequencePlayer.StopSequenceByKey("LocationNotice", false, true);
			if (flag2)
			{
				int? playerInternal = this.PlayerInternal;
				if (!(playerInternal.GetValueOrDefault() == playerId & playerInternal != null))
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("LocationNotice", false, null, false);
				}
			}
			string resourceId = StringUtils.Format(inString, new string[]
			{
				onlineIndex.ToString()
			});
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(13), false, null, null);
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
			ENetPingState? enetPingState = (currentTeamListById != null) ? new ENetPingState?(currentTeamListById.PingState) : null;
			if (enetPingState != null)
			{
				this.RefreshPing(enetPingState.Value);
			}
		}
		this.OnlineIndex = new int?(onlineIndex);
		this.PlayerInternal = new int?(playerId);
	}

	// Token: 0x0600CAA4 RID: 51876 RVA: 0x0035FD2C File Offset: 0x0035DF2C
	public override void Reset()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		this.OnSelectRole = null;
		this.ResetRole();
	}

	// Token: 0x0600CAA5 RID: 51877 RVA: 0x0035FD53 File Offset: 0x0035DF53
	public int? GetPlayer()
	{
		return this.PlayerInternal;
	}

	// Token: 0x0600CAA6 RID: 51878 RVA: 0x0035FD5B File Offset: 0x0035DF5B
	public override int? GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600CAA7 RID: 51879 RVA: 0x0035FD63 File Offset: 0x0035DF63
	public int? GetOnlineIndex()
	{
		return this.OnlineIndex;
	}

	// Token: 0x0600CAA8 RID: 51880 RVA: 0x0035FD6C File Offset: 0x0035DF6C
	public void ResetRole()
	{
		if (this.ConfigId != null)
		{
			LevelSequencePlayer playerInLevelSequencePlayer = this.PlayerInLevelSequencePlayer;
			if (playerInLevelSequencePlayer != null)
			{
				playerInLevelSequencePlayer.StopSequenceByKey("PlayerIn", false, true);
			}
			LevelSequencePlayer playerOutLevelSequencePlayer = this.PlayerOutLevelSequencePlayer;
			if (playerOutLevelSequencePlayer != null)
			{
				playerOutLevelSequencePlayer.PlayLevelSequenceByName("PlayerOut", false, null, false);
			}
		}
		else
		{
			base.GetItem(5).SetUIActive(false);
		}
		this.PlayerInternal = null;
		this.ConfigId = null;
		this.OnlineIndex = null;
		this.IsMatching = false;
		this.RefreshMatchView(false);
		base.GetItem(12).SetUIActive(false);
		base.GetSprite(14).SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(true);
		base.GetItem(1).SetUIActive(true);
		base.GetItem(42).SetUIActive(false);
		FormationSkillBranchItem skillBranchToggleItem = this.SkillBranchToggleItem;
		if (skillBranchToggleItem != null)
		{
			skillBranchToggleItem.SetUiActive(false);
		}
		this.RefreshDangoExtension();
	}

	// Token: 0x0600CAA9 RID: 51881 RVA: 0x0035FE78 File Offset: 0x0035E078
	public void RefreshPing(ENetPingState ping)
	{
		string text = null;
		if (ping != ENetPingState.Unknown)
		{
			if (ping == ENetPingState.Poor)
			{
				text = "SP_SignalPoor";
			}
		}
		else
		{
			text = "SP_SignalUnknown";
		}
		UUISprite sprite = base.GetSprite(14);
		if (string.IsNullOrEmpty(text))
		{
			sprite.SetUIActive(false);
			return;
		}
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
		this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		sprite.SetUIActive(true);
	}

	// Token: 0x0600CAAA RID: 51882 RVA: 0x0035FEDD File Offset: 0x0035E0DD
	public void SetCanAddRole(bool canAddRole)
	{
		base.GetItem(3).SetUIActive(canAddRole);
		base.GetItem(4).SetUIActive(!canAddRole);
	}

	// Token: 0x0600CAAB RID: 51883 RVA: 0x0035FEFC File Offset: 0x0035E0FC
	public void RefreshPrepareState()
	{
		bool isMultiInstanceDungeon = ModelBase<EditBattleTeamModel>.Instance.IsMultiInstanceDungeon;
		UUIItem item = base.GetItem(15);
		UUIItem item2 = base.GetItem(17);
		UUIItem item3 = base.GetItem(24);
		item2.SetUIActive(false);
		item.SetUIActive(false);
		if (!isMultiInstanceDungeon)
		{
			return;
		}
		if (ModelBase<EditBattleTeamModel>.Instance.IsRoleConflict((this.PlayerInternal != null) ? this.PlayerInternal.Value : 0, (this.ConfigId != null) ? this.ConfigId.Value : 0) && !ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() && !ModelBase<DangoAbyssModel>.Instance.CheckInAbyssEditFormationState() && !ModelBase<MultiMotorModel>.Instance.CheckInMultiMotorEditFormationState())
		{
			item3.SetUIActive(false);
			item2.SetUIActive(true);
			return;
		}
		item3.SetUIActive(this.IsDead);
		MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
		if (matchTeamInfo == null)
		{
			return;
		}
		int hostId = matchTeamInfo.HostId;
		int valueOrDefault = this.PlayerInternal.GetValueOrDefault(hostId);
		EMatchPlayerUiState playerUiState = ModelBase<InstanceDungeonModel>.Instance.GetPlayerUiState(valueOrDefault);
		if (playerUiState != EMatchPlayerUiState.Ready)
		{
			if (playerUiState == EMatchPlayerUiState.Selecting)
			{
				item.SetUIActive(true);
				base.GetItem(16).SetUIActive(true);
				if (this.CurrentState.GetValueOrDefault() != EMatchPlayerUiState.Selecting)
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("Connecting", false, null, false);
				}
				this.CurrentState = new EMatchPlayerUiState?(EMatchPlayerUiState.Selecting);
				return;
			}
			this.CurrentState = new EMatchPlayerUiState?(EMatchPlayerUiState.Wait);
			return;
		}
		else
		{
			if (valueOrDefault == hostId)
			{
				return;
			}
			item.SetUIActive(true);
			base.GetItem(16).SetUIActive(false);
			if (this.CurrentState.GetValueOrDefault() != EMatchPlayerUiState.Ready)
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Match", false, null, false);
			}
			this.CurrentState = new EMatchPlayerUiState?(EMatchPlayerUiState.Ready);
			return;
		}
	}

	// Token: 0x0600CAAC RID: 51884 RVA: 0x003600AC File Offset: 0x0035E2AC
	public void SetMatchState(bool isMatching)
	{
		if (this.IsMatching == isMatching)
		{
			return;
		}
		this.IsMatching = isMatching;
		if (this.ConfigId != null)
		{
			if (isMatching)
			{
				LevelSequencePlayer playerInLevelSequencePlayer = this.PlayerInLevelSequencePlayer;
				if (playerInLevelSequencePlayer != null)
				{
					playerInLevelSequencePlayer.StopSequenceByKey("PlayerIn", false, true);
				}
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopSequenceByKey("LocationNotice", false, true);
				}
				LevelSequencePlayer playerOutLevelSequencePlayer = this.PlayerOutLevelSequencePlayer;
				if (playerOutLevelSequencePlayer != null)
				{
					playerOutLevelSequencePlayer.PlayLevelSequenceByName("PlayerOut", false, null, false);
				}
			}
			else
			{
				LevelSequencePlayer playerOutLevelSequencePlayer2 = this.PlayerOutLevelSequencePlayer;
				if (playerOutLevelSequencePlayer2 != null)
				{
					playerOutLevelSequencePlayer2.StopSequenceByKey("PlayerOut", false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.StopSequenceByKey("LocationNotice", false, true);
				}
				LevelSequencePlayer playerInLevelSequencePlayer2 = this.PlayerInLevelSequencePlayer;
				if (playerInLevelSequencePlayer2 == null || !playerInLevelSequencePlayer2.IsPlayingSequence("PlayerIn"))
				{
					LevelSequencePlayer playerInLevelSequencePlayer3 = this.PlayerInLevelSequencePlayer;
					if (playerInLevelSequencePlayer3 != null)
					{
						playerInLevelSequencePlayer3.PlayLevelSequenceByName("PlayerIn", false, null, false);
					}
				}
				else
				{
					LevelSequencePlayer playerInLevelSequencePlayer4 = this.PlayerInLevelSequencePlayer;
					if (playerInLevelSequencePlayer4 != null)
					{
						playerInLevelSequencePlayer4.ReplaySequenceByKey("PlayerIn");
					}
				}
			}
		}
		this.RefreshMatchView(isMatching);
	}

	// Token: 0x0600CAAD RID: 51885 RVA: 0x003601C4 File Offset: 0x0035E3C4
	private void RefreshMatchView(bool isMatching)
	{
		base.GetItem(2).SetUIActive(isMatching);
		base.GetItem(3).SetUIActive(!isMatching);
		base.GetButton(0).SetSelfInteractive(!isMatching);
		if (!isMatching)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Matching", false, true);
			}
			if (this.ConfigId != null)
			{
				LevelSequencePlayer playerInLevelSequencePlayer = this.PlayerInLevelSequencePlayer;
				if (playerInLevelSequencePlayer == null || !playerInLevelSequencePlayer.IsPlayingSequence("PlayerIn"))
				{
					LevelSequencePlayer playerInLevelSequencePlayer2 = this.PlayerInLevelSequencePlayer;
					if (playerInLevelSequencePlayer2 == null)
					{
						return;
					}
					playerInLevelSequencePlayer2.PlayLevelSequenceByName("PlayerIn", false, null, false);
					return;
				}
				else
				{
					LevelSequencePlayer playerInLevelSequencePlayer3 = this.PlayerInLevelSequencePlayer;
					if (playerInLevelSequencePlayer3 == null)
					{
						return;
					}
					playerInLevelSequencePlayer3.ReplaySequenceByKey("PlayerIn");
				}
			}
			return;
		}
		LevelSequencePlayer playerInLevelSequencePlayer4 = this.PlayerInLevelSequencePlayer;
		if (playerInLevelSequencePlayer4 != null)
		{
			playerInLevelSequencePlayer4.StopSequenceByKey("PlayerIn", false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Matching", false, null, false);
	}

	// Token: 0x0600CAAE RID: 51886 RVA: 0x003602B1 File Offset: 0x0035E4B1
	public void SetMatchTime(int time)
	{
		base.GetText(23).SetText(Singleton<TimeUtil>.Instance.GetTimeString((double)time), true);
	}

	// Token: 0x0600CAAF RID: 51887 RVA: 0x003602D0 File Offset: 0x0035E4D0
	public void RefreshWeeklyRogueTag()
	{
		if (!ModelBase<WeeklyRogueModel>.Instance.IsWeeklyRogueOpen())
		{
			return;
		}
		base.GetItem(32).SetUIActive(ModelBase<WeeklyRogueModel>.Instance.CheckIsRecommendRole(this.ConfigId.Value));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(33), "WeeklyRogueTag", Array.Empty<object>());
	}

	// Token: 0x0600CAB0 RID: 51888 RVA: 0x00360328 File Offset: 0x0035E528
	public void RefreshTowerCost(int roleId)
	{
		FormationRoleView.<>c__DisplayClass78_0 CS$<>8__locals1 = new FormationRoleView.<>c__DisplayClass78_0();
		CS$<>8__locals1.<>4__this = this;
		if (!ModelBase<TowerModel>.Instance.IsOpenFloorFormation())
		{
			base.GetItem(18).SetUIActive(false);
			return;
		}
		int roleRemainCost = ModelBase<TowerModel>.Instance.GetRoleRemainCost(roleId, ModelBase<TowerModel>.Instance.CurrentSelectDifficulties);
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.CurrentSelectFloor);
		int? num = (towerInfo != null) ? new int?(towerInfo.GetValueOrDefault().Cost) : null;
		FormationRoleView.<>c__DisplayClass78_0 CS$<>8__locals2 = CS$<>8__locals1;
		int num2 = roleRemainCost;
		int? num3 = num;
		CS$<>8__locals2.isNotEnough = (num2 < num3.GetValueOrDefault() & num3 != null);
		CS$<>8__locals1.isHaveChallenge = ModelBase<TowerModel>.Instance.GetFloorIncludeRole(roleId, ModelBase<TowerModel>.Instance.CurrentSelectFloor);
		bool flag = CS$<>8__locals1.isNotEnough && !CS$<>8__locals1.isHaveChallenge;
		base.GetItem(18).SetUIActive(true);
		if (this.CurrentCost == null)
		{
			this.CurrentCost = new TowerCostItem();
			this.CurrentCost.CreateThenShowByActorAsync(base.GetItem(21).GetOwner(), null, false).ContinueWith(delegate()
			{
				CS$<>8__locals1.<>4__this.CurrentCost.SetUiActive(!CS$<>8__locals1.isNotEnough && !CS$<>8__locals1.isHaveChallenge);
			});
		}
		if (this.ChangeToCost == null)
		{
			this.ChangeToCost = new TowerCostItem();
			this.ChangeToCost.CreateThenShowByActorAsync(base.GetItem(22).GetOwner(), null, false).ContinueWith(delegate()
			{
				CS$<>8__locals1.<>4__this.ChangeToCost.SetUiActive(!CS$<>8__locals1.isNotEnough | CS$<>8__locals1.isHaveChallenge);
			});
		}
		base.GetItem(19).SetUIActive(flag);
		base.GetItem(20).SetUIActive(!flag);
		this.CurrentCost.SetUiActive(!CS$<>8__locals1.isNotEnough && !CS$<>8__locals1.isHaveChallenge);
		this.ChangeToCost.SetUiActive(!CS$<>8__locals1.isNotEnough | CS$<>8__locals1.isHaveChallenge);
		if (!CS$<>8__locals1.isNotEnough && !CS$<>8__locals1.isHaveChallenge)
		{
			this.CurrentCost.Update(roleRemainCost);
			this.ChangeToCost.Update(roleRemainCost - num.Value);
			return;
		}
		if (CS$<>8__locals1.isHaveChallenge)
		{
			this.ChangeToCost.Update(roleRemainCost);
		}
	}

	// Token: 0x0600CAB1 RID: 51889 RVA: 0x0036052C File Offset: 0x0035E72C
	private UniTask InitDangoExtension()
	{
		FormationRoleView.<InitDangoExtension>d__79 <InitDangoExtension>d__;
		<InitDangoExtension>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDangoExtension>d__.<>4__this = this;
		<InitDangoExtension>d__.<>1__state = -1;
		<InitDangoExtension>d__.<>t__builder.Start<FormationRoleView.<InitDangoExtension>d__79>(ref <InitDangoExtension>d__);
		return <InitDangoExtension>d__.<>t__builder.Task;
	}

	// Token: 0x0600CAB2 RID: 51890 RVA: 0x00360570 File Offset: 0x0035E770
	private void RefreshDangoExtension()
	{
		if (this.AbyssDangoExtensionComponent == null)
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? playerInternal = this.PlayerInternal;
		int num = 0;
		int? num2 = (playerInternal.GetValueOrDefault() > num & playerInternal != null) ? new int?(this.PlayerInternal.Value) : id;
		this.AbyssDangoExtensionComponent.Refresh(this.Position, this.ConfigId.GetValueOrDefault(), num2.Value);
		if (ModelBase<DangoAbyssModel>.Instance.CheckIsInMatch())
		{
			RoleFormationLikeItem likeItem = this.LikeItem;
			if (likeItem != null)
			{
				likeItem.SetActive(true);
			}
			RoleFormationLikeItem likeItem2 = this.LikeItem;
			if (likeItem2 == null)
			{
				return;
			}
			likeItem2.Refresh(num2.Value);
		}
	}

	// Token: 0x0600CAB3 RID: 51891 RVA: 0x0036061C File Offset: 0x0035E81C
	private UniTask InitPhantomExtension()
	{
		FormationRoleView.<InitPhantomExtension>d__81 <InitPhantomExtension>d__;
		<InitPhantomExtension>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPhantomExtension>d__.<>4__this = this;
		<InitPhantomExtension>d__.<>1__state = -1;
		<InitPhantomExtension>d__.<>t__builder.Start<FormationRoleView.<InitPhantomExtension>d__81>(ref <InitPhantomExtension>d__);
		return <InitPhantomExtension>d__.<>t__builder.Task;
	}

	// Token: 0x0600CAB4 RID: 51892 RVA: 0x00360660 File Offset: 0x0035E860
	private void RefreshPhantomExtension()
	{
		if (this.PhantomExtensionComponent == null)
		{
			return;
		}
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? num = (this.PlayerInternal != null && this.PlayerInternal.Value <= 0) ? id : new int?(this.PlayerInternal.Value);
		int value = this.ConfigId.Value;
		this.PhantomExtensionComponent.PlayerId = num.Value;
		this.PhantomExtensionComponent.RoleCfgId = value;
		string text = ControllerBase<TowerDefenseController>.Instance.BuildTeamPhantomIconData(num.Value, value);
		this.PhantomExtensionComponent.SetIcon(text, ControllerBase<TowerDefenseController>.Instance.CheckIsSelf(num.Value));
		UiPanelFormationRolePhantomExtension phantomExtensionComponent = this.PhantomExtensionComponent;
		int? num2 = id;
		int? num3 = num;
		phantomExtensionComponent.SetRedDotActive((num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null)) && text == null);
	}

	// Token: 0x0600CAB5 RID: 51893 RVA: 0x00360745 File Offset: 0x0035E945
	private void HandleOnConfirmPhantom()
	{
		this.RefreshPhantomExtension();
	}

	// Token: 0x0600CAB6 RID: 51894 RVA: 0x00360750 File Offset: 0x0035E950
	[NullableContext(1)]
	private void OnSelectDango(IReadOnlyDictionary<int, int[]> data)
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		int? num = (this.PlayerInternal != null && this.PlayerInternal.Value <= 0) ? id : new int?(this.PlayerInternal.Value);
		int value = this.ConfigId.Value;
		int[] array;
		if (data.TryGetValue(num.Value, out array) && Array.IndexOf<int>(array, value) != -1)
		{
			this.RefreshDangoExtension();
		}
	}

	// Token: 0x0600CAB7 RID: 51895 RVA: 0x003607C4 File Offset: 0x0035E9C4
	private UniTask InitTrialRoleExtension()
	{
		FormationRoleView.<InitTrialRoleExtension>d__85 <InitTrialRoleExtension>d__;
		<InitTrialRoleExtension>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTrialRoleExtension>d__.<>4__this = this;
		<InitTrialRoleExtension>d__.<>1__state = -1;
		<InitTrialRoleExtension>d__.<>t__builder.Start<FormationRoleView.<InitTrialRoleExtension>d__85>(ref <InitTrialRoleExtension>d__);
		return <InitTrialRoleExtension>d__.<>t__builder.Task;
	}

	// Token: 0x0600CAB8 RID: 51896 RVA: 0x00360808 File Offset: 0x0035EA08
	private void RefreshTrialRoleExtension(int roleId)
	{
		if (!RoleUtils.IsTrialRole(roleId))
		{
			RoleTrialLabelItem trialLabelItem = this.TrialLabelItem;
			if (trialLabelItem == null)
			{
				return;
			}
			trialLabelItem.SetUiActive(false);
			return;
		}
		else if (RoleUtils.GetTrialRoleType(roleId) == ETrialRoleType.None)
		{
			RoleTrialLabelItem trialLabelItem2 = this.TrialLabelItem;
			if (trialLabelItem2 == null)
			{
				return;
			}
			trialLabelItem2.SetUiActive(false);
			return;
		}
		else
		{
			RoleTrialLabelItem trialLabelItem3 = this.TrialLabelItem;
			if (trialLabelItem3 != null)
			{
				trialLabelItem3.SetUiActive(true);
			}
			RoleTrialLabelItem trialLabelItem4 = this.TrialLabelItem;
			if (trialLabelItem4 == null)
			{
				return;
			}
			trialLabelItem4.Refresh(roleId);
			return;
		}
	}

	// Token: 0x0600CAB9 RID: 51897 RVA: 0x0036086C File Offset: 0x0035EA6C
	private void RefreshSpecialTrialRoleExtension(int roleId, bool canUseSpecialTrailRole)
	{
		UUIItem item = base.GetItem(36);
		if (!RoleUtils.IsSpecialTrialRole(roleId))
		{
			item.SetUIActive(false);
			return;
		}
		if (!canUseSpecialTrailRole)
		{
			item.SetUIActive(true);
			return;
		}
		item.SetUIActive(false);
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)roleId, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.ConfigId,
			OnlyMyRole = new bool?(true)
		});
		if (teamItem != null && teamItem.EntityHandle != null && teamItem.EntityHandle.Entity != null)
		{
			this.IsDead = ModelBase<EditFormationModel>.Instance.IsRoleDead(roleId);
		}
		else
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			RoleAttributeData roleAttributeData = (roleDataById != null) ? roleDataById.GetAttributeData() : null;
			int num = (roleAttributeData != null) ? roleAttributeData.GetAttrValueById(3) : 0;
			this.IsDead = (num <= 0);
		}
		base.GetItem(24).SetUIActive(this.IsDead);
	}

	// Token: 0x0600CABA RID: 51898 RVA: 0x0036093C File Offset: 0x0035EB3C
	private void OnSkillBranchInGamePlayChanged(int roleId)
	{
		if (this.ConfigId == null || roleId != this.ConfigId.Value)
		{
			return;
		}
		this.RefreshSkillBranch(this.ConfigId.GetValueOrDefault(), this.PlayerInternal ?? ModelBase<PlayerInfoModel>.Instance.GetId().Value);
	}

	// Token: 0x0600CABB RID: 51899 RVA: 0x003609A4 File Offset: 0x0035EBA4
	private void RefreshSkillBranch(int configId, int playerId)
	{
		if (this.SkillBranchToggleItem == null)
		{
			return;
		}
		bool flag = ModelBase<RoleModel>.Instance.IsRoleHasBranch(configId);
		this.SkillBranchToggleItem.SetUiActive(flag);
		if (!flag)
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EditBattleTeamView))
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<EditBattleTeamModel>.Instance.GetCurrentDungeonConfig != null) ? new int?(instanceDungeon.GetValueOrDefault().InstSubType) : null;
			if (num != null && ModelBase<RoleModel>.Instance.IsInHideSkillBranchInstSubTypeList(num.Value))
			{
				this.SkillBranchToggleItem.SetUiActive(false);
				return;
			}
		}
		ValueTuple<bool, int> skillBranchMultiInfo = this.GetSkillBranchMultiInfo(playerId);
		bool item = skillBranchMultiInfo.Item1;
		int item2 = skillBranchMultiInfo.Item2;
		bool flag2 = playerId == ModelBase<CreatureModel>.Instance.GetPlayerId();
		if (item && !flag2)
		{
			this.SkillBranchToggleItem.SetToggleInteractive(false);
			int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(configId, item2);
			this.SkillBranchToggleItem.SetActiveBranchIndex(roleBranchIndexById);
			this.SkillBranchToggleItem.RefreshIcon(new Func<int, string>(this.RefreshSkillBranchIconHandler));
			return;
		}
		this.SkillBranchToggleItem.SetToggleInteractive(true);
		int roleSkillBranchIndexInCurrentGamePlay = ModelBase<RoleModel>.Instance.GetRoleSkillBranchIndexInCurrentGamePlay(configId);
		this.SkillBranchToggleItem.SetActiveBranchIndex(roleSkillBranchIndexInCurrentGamePlay);
		this.SkillBranchToggleItem.RefreshIcon(new Func<int, string>(this.RefreshSkillBranchIconHandler));
	}

	// Token: 0x0600CABC RID: 51900 RVA: 0x00360AF4 File Offset: 0x0035ECF4
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"IsMulti",
		"MultiSkillBranchId"
	})]
	private ValueTuple<bool, int> GetSkillBranchMultiInfo(int playerId)
	{
		ValueTuple<bool, int> result = new ValueTuple<bool, int>(false, 0);
		if (ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo() != null)
		{
			result.Item1 = true;
			PrewarFormationData prewarFormationData = Array.Find<PrewarFormationData>(ModelBase<InstanceDungeonModel>.Instance.GetPrewarFormationDataList().ToArray<PrewarFormationData>(), (PrewarFormationData data) => data.GetPlayerId() == playerId && data.GetConfigId() == this.ConfigId.GetValueOrDefault());
			result.Item2 = ((prewarFormationData != null) ? prewarFormationData.GetMultiSkillBranchId() : 0);
		}
		else if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			result.Item1 = true;
			result.Item2 = ModelBase<EditFormationModel>.Instance.GetCurrentFormationSkillBranchId(this.Position);
		}
		return result;
	}

	// Token: 0x0600CABD RID: 51901 RVA: 0x00360B94 File Offset: 0x0035ED94
	private void SwitchSkillBranchHandler(int skillBranch)
	{
		InstanceDungeonModel instance = ModelBase<InstanceDungeonModel>.Instance;
		if (instance.GetMatchTeamInfo() != null)
		{
			int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
			if (instance.GetPrewarPlayerReadyState(playerId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_700039_Text", Array.Empty<object>());
				int activeBranchIndex = (ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(this.ConfigId.GetValueOrDefault(), skillBranch) == 0) ? 1 : 0;
				FormationSkillBranchItem skillBranchToggleItem = this.SkillBranchToggleItem;
				if (skillBranchToggleItem == null)
				{
					return;
				}
				skillBranchToggleItem.SetActiveBranchIndex(activeBranchIndex);
				return;
			}
		}
		int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.ConfigId.GetValueOrDefault(), skillBranch);
		if (ModelBase<RoleModel>.Instance.IsInGamePlayRoleEdit)
		{
			ControllerBase<RoleController>.Instance.ModifyRoleSkillBranchInCurrentGamePlay(this.ConfigId.GetValueOrDefault(), roleBranchIdByIndex, true);
			return;
		}
		ControllerBase<RoleController>.Instance.RequestRoleSkillBranchModify(this.ConfigId.GetValueOrDefault(), roleBranchIdByIndex);
	}

	// Token: 0x0600CABE RID: 51902 RVA: 0x00360C54 File Offset: 0x0035EE54
	[NullableContext(1)]
	private string RefreshSkillBranchIconHandler(int index)
	{
		int roleBranchIdByIndex = ModelBase<RoleModel>.Instance.GetRoleBranchIdByIndex(this.ConfigId.GetValueOrDefault(), index);
		SkillBranch? skillBranchConfigById = ConfigBase<RoleConfig>.Instance.GetSkillBranchConfigById(roleBranchIdByIndex);
		if (skillBranchConfigById != null)
		{
			return skillBranchConfigById.Value.Icon;
		}
		return string.Empty;
	}

	// Token: 0x040060DF RID: 24799
	private const int HEALTH_ID = 3;

	// Token: 0x040060E0 RID: 24800
	private Action<int> OnSelectRole;

	// Token: 0x040060E1 RID: 24801
	public Action<ULGUIPointerEventData, int, int, int> OnPointDown;

	// Token: 0x040060E2 RID: 24802
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIItem, int, int, int> OnGamePadDown;

	// Token: 0x040060E3 RID: 24803
	public Action OnDragStart;

	// Token: 0x040060E4 RID: 24804
	public Action<ULGUIPointerEventData> OnDragMove;

	// Token: 0x040060E5 RID: 24805
	public Action<bool?> OnDragEnd;

	// Token: 0x040060E6 RID: 24806
	private readonly int Position;

	// Token: 0x040060E7 RID: 24807
	private int? PlayerInternal;

	// Token: 0x040060E8 RID: 24808
	private int? ConfigId;

	// Token: 0x040060E9 RID: 24809
	private int? SkinId;

	// Token: 0x040060EA RID: 24810
	private int? OnlineIndex;

	// Token: 0x040060EB RID: 24811
	private MiniElementItem MiniElementItem;

	// Token: 0x040060EC RID: 24812
	private TowerCostItem CurrentCost;

	// Token: 0x040060ED RID: 24813
	private TowerCostItem ChangeToCost;

	// Token: 0x040060EE RID: 24814
	private UiPanelFormationRolePhantomExtension PhantomExtensionComponent;

	// Token: 0x040060EF RID: 24815
	private UiPanelFormationRoleDangoExtension AbyssDangoExtensionComponent;

	// Token: 0x040060F0 RID: 24816
	private RoleFormationLikeItem LikeItem;

	// Token: 0x040060F1 RID: 24817
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040060F2 RID: 24818
	private LevelSequencePlayer CircleInLevelSequencePlayer;

	// Token: 0x040060F3 RID: 24819
	private LevelSequencePlayer CircleOutLevelSequencePlayer;

	// Token: 0x040060F4 RID: 24820
	private LevelSequencePlayer PlayerInLevelSequencePlayer;

	// Token: 0x040060F5 RID: 24821
	private LevelSequencePlayer PlayerOutLevelSequencePlayer;

	// Token: 0x040060F6 RID: 24822
	private EMatchPlayerUiState? CurrentState;

	// Token: 0x040060F7 RID: 24823
	private bool IsMatching;

	// Token: 0x040060F8 RID: 24824
	public bool IsDragDisabled;

	// Token: 0x040060F9 RID: 24825
	private bool IsDead;

	// Token: 0x040060FA RID: 24826
	private RoleTrialLabelItem TrialLabelItem;

	// Token: 0x040060FB RID: 24827
	private FormationRoleDragStateItem DragStateItem;

	// Token: 0x040060FC RID: 24828
	private bool IsPlayingCircleIn;

	// Token: 0x040060FD RID: 24829
	private FormationSkillBranchItem SkillBranchToggleItem;

	// Token: 0x040060FE RID: 24830
	private UUIItem RoleItem;

	// Token: 0x040060FF RID: 24831
	private bool NeedTick;

	// Token: 0x04006100 RID: 24832
	private bool DragLogicFirst;

	// Token: 0x04006101 RID: 24833
	private bool StartDrag;

	// Token: 0x04006102 RID: 24834
	private float StartDragTime;

	// Token: 0x02007E3F RID: 32319
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B008 RID: 176136
		ChooseButton,
		// Token: 0x0402B009 RID: 176137
		NoRoleItem,
		// Token: 0x0402B00A RID: 176138
		MatchingItem,
		// Token: 0x0402B00B RID: 176139
		AddRoleIcon,
		// Token: 0x0402B00C RID: 176140
		ForbiddenItem,
		// Token: 0x0402B00D RID: 176141
		RoleItem,
		// Token: 0x0402B00E RID: 176142
		RoleIconSpine,
		// Token: 0x0402B00F RID: 176143
		RoleIconItem,
		// Token: 0x0402B010 RID: 176144
		RoleNameText,
		// Token: 0x0402B011 RID: 176145
		RoleLevelText,
		// Token: 0x0402B012 RID: 176146
		ElementItem,
		// Token: 0x0402B013 RID: 176147
		TrailRoleIcon,
		// Token: 0x0402B014 RID: 176148
		OnlineItem,
		// Token: 0x0402B015 RID: 176149
		OnlineIndexIcon,
		// Token: 0x0402B016 RID: 176150
		OnlineSignalIcon,
		// Token: 0x0402B017 RID: 176151
		PrepareItem,
		// Token: 0x0402B018 RID: 176152
		PrepareWaitItem,
		// Token: 0x0402B019 RID: 176153
		WarnItem,
		// Token: 0x0402B01A RID: 176154
		CostItem,
		// Token: 0x0402B01B RID: 176155
		CostNotEnoughItem,
		// Token: 0x0402B01C RID: 176156
		CostEnoughItem,
		// Token: 0x0402B01D RID: 176157
		CurrentCostUIItem,
		// Token: 0x0402B01E RID: 176158
		ChangeToCostUIItem,
		// Token: 0x0402B01F RID: 176159
		MatchTimeText,
		// Token: 0x0402B020 RID: 176160
		DeadItem,
		// Token: 0x0402B021 RID: 176161
		ExitSkillTagContent,
		// Token: 0x0402B022 RID: 176162
		ExitSkillTag1,
		// Token: 0x0402B023 RID: 176163
		ExitSkillTag2,
		// Token: 0x0402B024 RID: 176164
		ThirdPartyItem,
		// Token: 0x0402B025 RID: 176165
		ThirdPartyIcon,
		// Token: 0x0402B026 RID: 176166
		PcItem,
		// Token: 0x0402B027 RID: 176167
		ThirdPartyText,
		// Token: 0x0402B028 RID: 176168
		RightTagItem,
		// Token: 0x0402B029 RID: 176169
		RightTagText,
		// Token: 0x0402B02A RID: 176170
		LikeItem,
		// Token: 0x0402B02B RID: 176171
		TrialRoleItem,
		// Token: 0x0402B02C RID: 176172
		TrialRoleWarnItem,
		// Token: 0x0402B02D RID: 176173
		Drag,
		// Token: 0x0402B02E RID: 176174
		DragStateItem,
		// Token: 0x0402B02F RID: 176175
		LockItem,
		// Token: 0x0402B030 RID: 176176
		OtherOnItem,
		// Token: 0x0402B031 RID: 176177
		SkillBranchItem,
		// Token: 0x0402B032 RID: 176178
		PnlPreviewItem,
		// Token: 0x0402B033 RID: 176179
		PnlRoleItem
	}
}
