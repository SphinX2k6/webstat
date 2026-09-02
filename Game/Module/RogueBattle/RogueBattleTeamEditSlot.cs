using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005229 RID: 21033
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleTeamEditSlot : FormationRoleSlot
	{
		// Token: 0x06035E2B RID: 220715 RVA: 0x00D900A5 File Offset: 0x00D8E2A5
		public RogueBattleTeamEditSlot(int index)
		{
			this.Index = index;
		}

		// Token: 0x06035E2C RID: 220716 RVA: 0x00D900B4 File Offset: 0x00D8E2B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSelf))
			};
		}

		// Token: 0x06035E2D RID: 220717 RVA: 0x00D90256 File Offset: 0x00D8E456
		private void OnBtnSelf()
		{
			Action<int> onClickCallBack = this.OnClickCallBack;
			if (onClickCallBack == null)
			{
				return;
			}
			onClickCallBack(this.Index);
		}

		// Token: 0x06035E2E RID: 220718 RVA: 0x00D90270 File Offset: 0x00D8E470
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleTeamEditSlot.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleTeamEditSlot.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035E2F RID: 220719 RVA: 0x00D902B4 File Offset: 0x00D8E4B4
		protected override void OnStart()
		{
			UUIDraggableComponent draggable = base.GetDraggable(17);
			draggable.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
			this.RoleItem = base.GetItem(1);
		}

		// Token: 0x06035E30 RID: 220720 RVA: 0x00D90331 File Offset: 0x00D8E531
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResNewRoleFlagChange, new Action(this.RefreshRedDot));
			Singleton<EventSystem>.Instance.Add(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		}

		// Token: 0x06035E31 RID: 220721 RVA: 0x00D9036B File Offset: 0x00D8E56B
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResNewRoleFlagChange, new Action(this.RefreshRedDot));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnInputAnyKey, new Action<bool, FKey>(this.OnInputAnyKey));
		}

		// Token: 0x06035E32 RID: 220722 RVA: 0x00D903A8 File Offset: 0x00D8E5A8
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			if (ControllerBase<FormationDragController>.Instance.DraggingIndex != this.Index + 1)
			{
				return;
			}
			ControllerBase<FormationDragController>.Instance.DraggingIndex = 0;
			this.NeedTick = false;
			this.EndShowDragItem();
			this.StopMove(null);
		}

		// Token: 0x06035E33 RID: 220723 RVA: 0x00D903F4 File Offset: 0x00D8E5F4
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			if (this.ConfigId == 0)
			{
				return;
			}
			if (ControllerBase<FormationDragController>.Instance.DraggingIndex != 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "RogueBattleTeamEditSlot-CanDragStart-false", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<FormationDragController>.Instance.DraggingIndex = this.Index + 1;
			this.NeedTick = true;
			this.StartDragTime = 0f;
			Action<ULGUIPointerEventData, int, int, int> onPointDown = this.OnPointDown;
			if (onPointDown == null)
			{
				return;
			}
			onPointDown(eventData, this.ConfigId, this.SkinId.GetValueOrDefault(), this.Index + 1);
		}

		// Token: 0x06035E34 RID: 220724 RVA: 0x00D90480 File Offset: 0x00D8E680
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

		// Token: 0x06035E35 RID: 220725 RVA: 0x00D9049F File Offset: 0x00D8E69F
		public void OnTick(float delta)
		{
			if (!this.NeedTick)
			{
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
			}
		}

		// Token: 0x06035E36 RID: 220726 RVA: 0x00D904DF File Offset: 0x00D8E6DF
		public override void Reset()
		{
		}

		// Token: 0x06035E37 RID: 220727 RVA: 0x00D904E1 File Offset: 0x00D8E6E1
		public override int? GetConfigId()
		{
			return new int?(this.ConfigId);
		}

		// Token: 0x06035E38 RID: 220728 RVA: 0x00D904F0 File Offset: 0x00D8E6F0
		private void StartShowDragItem()
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
			if (!this.HaveCustomShield)
			{
				ControllerBase<FormationDragController>.Instance.SetCustomShield(false);
				this.HaveCustomShield = true;
			}
			base.GetItem(20).SetUIActive(false);
			FormationRoleDragStateItem dragStateItem = this.DragStateItem;
			if (dragStateItem == null)
			{
				return;
			}
			dragStateItem.SetBarFill((this.StartDragTime - 250f) / 500f);
		}

		// Token: 0x06035E39 RID: 220729 RVA: 0x00D9058C File Offset: 0x00D8E78C
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
			if (this.HaveCustomShield)
			{
				ControllerBase<FormationDragController>.Instance.SetCustomShield(true);
				this.HaveCustomShield = false;
			}
			base.GetItem(20).SetUIActive(false);
			FormationRoleDragStateItem dragStateItem = this.DragStateItem;
			if (dragStateItem == null)
			{
				return;
			}
			dragStateItem.SetBarFill(0f);
		}

		// Token: 0x06035E3A RID: 220730 RVA: 0x00D9061C File Offset: 0x00D8E81C
		public override void GamePadUp(bool isCancel = false)
		{
			if (this.ConfigId == 0)
			{
				return;
			}
			if (ControllerBase<FormationDragController>.Instance.DraggingIndex != this.Index + 1)
			{
				return;
			}
			ControllerBase<FormationDragController>.Instance.DraggingIndex = 0;
			this.NeedTick = false;
			this.EndShowDragItem();
			this.StopMove(new bool?(isCancel));
		}

		// Token: 0x06035E3B RID: 220731 RVA: 0x00D9066C File Offset: 0x00D8E86C
		public override void GamePadPress()
		{
			if (this.ConfigId == 0)
			{
				return;
			}
			if (ControllerBase<FormationDragController>.Instance.DraggingIndex != 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Formation, ELogAuthor.LJQ, "FormationRoleView-CanDragStart-false", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<FormationDragController>.Instance.DraggingIndex = this.Index + 1;
			this.NeedTick = true;
			this.StartDragTime = 0f;
			Action<UUIItem, int, int, int> onGamePadDown = this.OnGamePadDown;
			if (onGamePadDown == null)
			{
				return;
			}
			onGamePadDown(this.RootItem, this.ConfigId, this.SkinId.GetValueOrDefault(), this.Index + 1);
		}

		// Token: 0x06035E3C RID: 220732 RVA: 0x00D906FD File Offset: 0x00D8E8FD
		public override void GamePadRelease()
		{
			if (!this.StartDrag)
			{
				if (this.OnClickCallBack != null)
				{
					this.OnClickCallBack(this.Index + 1);
				}
				this.GamePadUp(false);
				return;
			}
		}

		// Token: 0x06035E3D RID: 220733 RVA: 0x00D9072C File Offset: 0x00D8E92C
		public override void MouseCancelDrag()
		{
			if (this.ConfigId == 0)
			{
				return;
			}
			if (ControllerBase<FormationDragController>.Instance.DraggingIndex != this.Index + 1)
			{
				return;
			}
			ControllerBase<FormationDragController>.Instance.DraggingIndex = 0;
			this.NeedTick = false;
			this.EndShowDragItem();
			this.StopMove(new bool?(true));
		}

		// Token: 0x06035E3E RID: 220734 RVA: 0x00D9077B File Offset: 0x00D8E97B
		private void StartMoveDragItem()
		{
			if (this.StartDrag)
			{
				return;
			}
			this.StartDrag = true;
			this.EndShowDragItem();
			Action onDragStart = this.OnDragStart;
			if (onDragStart != null)
			{
				onDragStart();
			}
			this.RoleItem.SetUIActive(false);
		}

		// Token: 0x06035E3F RID: 220735 RVA: 0x00D907B0 File Offset: 0x00D8E9B0
		private void StopMove(bool? isCancel = null)
		{
			if (this.ConfigId == 0 || !this.StartDrag)
			{
				return;
			}
			this.StartDrag = false;
			this.RoleItem.SetUIActive(true);
			Action<bool?> onDragEnd = this.OnDragEnd;
			if (onDragEnd == null)
			{
				return;
			}
			onDragEnd(isCancel);
		}

		// Token: 0x06035E40 RID: 220736 RVA: 0x00D907E8 File Offset: 0x00D8E9E8
		public override void ShowOtherItemUpState()
		{
			if (!this.IsPlayingCircleIn && !this.StartDrag)
			{
				LevelSequencePlayer circleInLevelSequencePlayer = this.CircleInLevelSequencePlayer;
				if (circleInLevelSequencePlayer != null)
				{
					circleInLevelSequencePlayer.PlaySequencePurely("CircleIn", false, false, null, null, false);
				}
				this.IsPlayingCircleIn = true;
				base.GetItem(20).SetUIActive(true);
			}
		}

		// Token: 0x06035E41 RID: 220737 RVA: 0x00D90840 File Offset: 0x00D8EA40
		public override void RefreshLockItemState(bool isDrag)
		{
			if (!isDrag)
			{
				base.GetItem(19).SetUIActive(false);
				base.GetItem(21).SetUIActive(true);
				return;
			}
			if (this.ConfigId <= 0)
			{
				base.GetItem(19).SetUIActive(true);
				base.GetItem(21).SetUIActive(false);
			}
		}

		// Token: 0x06035E42 RID: 220738 RVA: 0x00D90892 File Offset: 0x00D8EA92
		[NullableContext(1)]
		private void OnInputAnyKey(bool bPress, FKey key)
		{
			if (this.StartDrag && bPress && !Singleton<Info>.Instance.IsInGamepad())
			{
				this.MouseCancelDrag();
			}
		}

		// Token: 0x06035E43 RID: 220739 RVA: 0x00D908B0 File Offset: 0x00D8EAB0
		public override int GetPlayerId()
		{
			return ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		}

		// Token: 0x06035E44 RID: 220740 RVA: 0x00D908D0 File Offset: 0x00D8EAD0
		public void UpdateRoleInfo(int configId, int formationIndex)
		{
			RogueBattleTeamEditSlot.<>c__DisplayClass46_0 CS$<>8__locals1 = new RogueBattleTeamEditSlot.<>c__DisplayClass46_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.formationData = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(formationIndex);
			this.RefreshRedDot();
			base.GetText(6).SetText((this.Index + 1).ToString(), true);
			if (configId == 0)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				this.SetAnimState(configId);
				this.ConfigId = configId;
				return;
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(configId, true);
			CS$<>8__locals1.roleConfig = roleDataById.GetRoleConfig();
			int incIdByRoleId = ModelBase<RogueBattleModel>.Instance.GetIncIdByRoleId(configId);
			RogueResRole roleInfoById = ModelBase<RogueBattleModel>.Instance.GetRoleInfoById(incIdByRoleId);
			int roleSkinId = roleDataById.GetRoleSkinId();
			this.SkinId = new int?(roleSkinId);
			RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId);
			CS$<>8__locals1.roleSpine = base.GetSpine(2);
			CS$<>8__locals1.roleItem = (UUIItem)CS$<>8__locals1.roleSpine.GetOwner().GetComponentByClass(UUIItem.StaticClass());
			CS$<>8__locals1.roleItem.SetAlpha(0f);
			string atlasPath = (roleSkinConfig != null) ? roleSkinConfig.Value.FormationSpineAtlas : CS$<>8__locals1.roleConfig.FormationSpineAtlas;
			string skeletonPath = (roleSkinConfig != null) ? roleSkinConfig.Value.FormationSpineSkeletonData : CS$<>8__locals1.roleConfig.FormationSpineSkeletonData;
			RogueBattleTeamEditSlot.<>c__DisplayClass46_0 CS$<>8__locals2 = CS$<>8__locals1;
			float[] param;
			if (roleSkinConfig == null)
			{
				(param = new float[3])[2] = 1f;
			}
			else
			{
				param = roleSkinConfig.Value.SpineParam();
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
			RogueBattleTokenElement elementItem = this.ElementItem;
			if (elementItem != null)
			{
				elementItem.Refresh(CS$<>8__locals1.roleConfig.ElementId, false, 0);
			}
			base.GetText(3).SetText(roleDataById.GetName(null), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RogueRes_FightFormation_RoleLevel", new <>z__ReadOnlySingleElementList<object>(ModelBase<MapRogueModel>.Instance.GetRogueRoleLevel()));
			base.GetText(9).SetText(roleInfoById.Level.ToString(), true);
			UiAsyncTask task = new UiAsyncTask("RogueBattleTeamEditSlot.UpdateRoleInfo", delegate()
			{
				RogueBattleTeamEditSlot.<>c__DisplayClass46_0.<<UpdateRoleInfo>b__1>d <<UpdateRoleInfo>b__1>d;
				<<UpdateRoleInfo>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<UpdateRoleInfo>b__1>d.<>4__this = CS$<>8__locals1;
				<<UpdateRoleInfo>b__1>d.<>1__state = -1;
				<<UpdateRoleInfo>b__1>d.<>t__builder.Start<RogueBattleTeamEditSlot.<>c__DisplayClass46_0.<<UpdateRoleInfo>b__1>d>(ref <<UpdateRoleInfo>b__1>d);
				return <<UpdateRoleInfo>b__1>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
			this.SetAnimState(configId);
			this.ConfigId = configId;
		}

		// Token: 0x06035E45 RID: 220741 RVA: 0x00D90B40 File Offset: 0x00D8ED40
		private void RefreshRedDot()
		{
			bool flag = this.Index == 0;
			bool rogueResNewRoleFlag = ModelBase<RogueBattleModel>.Instance.GetRogueResNewRoleFlag();
			base.GetItem(10).SetUIActive(flag && rogueResNewRoleFlag);
		}

		// Token: 0x06035E46 RID: 220742 RVA: 0x00D90B74 File Offset: 0x00D8ED74
		private void SetAnimState(int configId)
		{
			if (this.ConfigId == configId)
			{
				return;
			}
			if (configId == 0)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopSequenceByKey("PlayerIn", false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null && levelSequencePlayer2.IsPlayingSequence("PlayerOut"))
				{
					this.LevelSequencePlayer.ReplaySequenceByKey("PlayerOut");
					return;
				}
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 == null)
				{
					return;
				}
				levelSequencePlayer3.PlayLevelSequenceByName("PlayerOut", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 != null)
				{
					levelSequencePlayer4.StopSequenceByKey("PlayerOut", false, false);
				}
				LevelSequencePlayer levelSequencePlayer5 = this.LevelSequencePlayer;
				if (levelSequencePlayer5 != null && levelSequencePlayer5.IsPlayingSequence("PlayerIn"))
				{
					this.LevelSequencePlayer.ReplaySequenceByKey("PlayerIn");
					return;
				}
				LevelSequencePlayer levelSequencePlayer6 = this.LevelSequencePlayer;
				if (levelSequencePlayer6 == null)
				{
					return;
				}
				levelSequencePlayer6.PlayLevelSequenceByName("PlayerIn", false, null, false);
				return;
			}
		}

		// Token: 0x0401EF6B RID: 126827
		public Action<ULGUIPointerEventData, int, int, int> OnPointDown;

		// Token: 0x0401EF6C RID: 126828
		public Action OnDragStart;

		// Token: 0x0401EF6D RID: 126829
		public Action<ULGUIPointerEventData> OnDragMove;

		// Token: 0x0401EF6E RID: 126830
		public Action<bool?> OnDragEnd;

		// Token: 0x0401EF6F RID: 126831
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<UUIItem, int, int, int> OnGamePadDown;

		// Token: 0x0401EF70 RID: 126832
		private int? SkinId;

		// Token: 0x0401EF71 RID: 126833
		private FormationRoleDragStateItem DragStateItem;

		// Token: 0x0401EF72 RID: 126834
		private UUIItem RoleItem;

		// Token: 0x0401EF73 RID: 126835
		private bool NeedTick;

		// Token: 0x0401EF74 RID: 126836
		private bool StartDrag;

		// Token: 0x0401EF75 RID: 126837
		private float StartDragTime;

		// Token: 0x0401EF76 RID: 126838
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EF77 RID: 126839
		private LevelSequencePlayer CircleInLevelSequencePlayer;

		// Token: 0x0401EF78 RID: 126840
		private LevelSequencePlayer CircleOutLevelSequencePlayer;

		// Token: 0x0401EF79 RID: 126841
		public int ConfigId;

		// Token: 0x0401EF7A RID: 126842
		public int Index;

		// Token: 0x0401EF7B RID: 126843
		public RogueBattleTokenElement ElementItem;

		// Token: 0x0401EF7C RID: 126844
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<RogueBattleTeamEditFetterIconItem, IRogueBattleRoleBondUpdateInfo> FetterLayout;

		// Token: 0x0401EF7D RID: 126845
		public Action<int> OnClickCallBack;

		// Token: 0x0401EF7E RID: 126846
		private bool HaveCustomShield;

		// Token: 0x0401EF7F RID: 126847
		private bool IsPlayingCircleIn;

		// Token: 0x0200B1C0 RID: 45504
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040371E1 RID: 225761
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<IRogueBattleRoleBondUpdateInfo> <0>__SortRogueBattleRoleBondUpdateInfo;
		}
	}
}
