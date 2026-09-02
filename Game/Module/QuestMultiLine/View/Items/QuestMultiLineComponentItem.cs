using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuestMultiLine.View.Items
{
	// Token: 0x02005329 RID: 21289
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMultiLineComponentItem : UiPanelBase
	{
		// Token: 0x0603653C RID: 222524 RVA: 0x00DB16F0 File Offset: 0x00DAF8F0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnToggleClickComponent))
			};
		}

		// Token: 0x0603653D RID: 222525 RVA: 0x00DB17F4 File Offset: 0x00DAF9F4
		public UniTask RefreshComponent(QuestMultiLineComponentData componentData)
		{
			QuestMultiLineComponentItem.<RefreshComponent>d__10 <RefreshComponent>d__;
			<RefreshComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshComponent>d__.<>4__this = this;
			<RefreshComponent>d__.componentData = componentData;
			<RefreshComponent>d__.<>1__state = -1;
			<RefreshComponent>d__.<>t__builder.Start<QuestMultiLineComponentItem.<RefreshComponent>d__10>(ref <RefreshComponent>d__);
			return <RefreshComponent>d__.<>t__builder.Task;
		}

		// Token: 0x0603653E RID: 222526 RVA: 0x00DB1840 File Offset: 0x00DAFA40
		protected override UniTask OnBeforeStartAsync()
		{
			QuestMultiLineComponentItem.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuestMultiLineComponentItem.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603653F RID: 222527 RVA: 0x00DB1883 File Offset: 0x00DAFA83
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x06036540 RID: 222528 RVA: 0x00DB1896 File Offset: 0x00DAFA96
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			if (this.FightStateItem != null)
			{
				this.FightStateItem.DestroyAsync();
				this.FightStateItem = null;
			}
		}

		// Token: 0x06036541 RID: 222529 RVA: 0x00DB18CC File Offset: 0x00DAFACC
		public void RefreshSelected(bool isSelected)
		{
			base.GetItem(1).SetUIActive(isSelected);
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (extendToggle != null)
			{
				EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				extendToggle.SetToggleStateForce(state, false, false, false);
			}
			if (isSelected)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_missionmap_roleitem_click");
			}
		}

		// Token: 0x06036542 RID: 222530 RVA: 0x00DB1918 File Offset: 0x00DAFB18
		public void RefreshRoleState(int statusType)
		{
			if (statusType == 0)
			{
				base.GetSprite(2).SetUIActive(false);
				return;
			}
			base.GetSprite(2).SetUIActive(true);
			string statusIcon = QuestMultiLineConfig.GetComponentStatusConfigById(statusType).Value.StatusIcon;
			if (!string.IsNullOrEmpty(statusIcon))
			{
				base.GetSprite(2).SetUIActive(true);
				this.SetSpriteByPath(statusIcon, base.GetSprite(2), false, null, null);
				return;
			}
			base.GetSprite(2).SetUIActive(false);
		}

		// Token: 0x06036543 RID: 222531 RVA: 0x00DB1996 File Offset: 0x00DAFB96
		public void SetComponentFunction(Action<QuestMultiLineComponentData> componentFunction)
		{
			this.ComponentFunction = componentFunction;
		}

		// Token: 0x06036544 RID: 222532 RVA: 0x00DB199F File Offset: 0x00DAFB9F
		public void SetClickable(bool clickable)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(5);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetSelfInteractive(clickable);
		}

		// Token: 0x06036545 RID: 222533 RVA: 0x00DB19B4 File Offset: 0x00DAFBB4
		private UniTask RefreshFightState(QuestMultiLineComponentData componentData)
		{
			QuestMultiLineComponentItem.<RefreshFightState>d__18 <RefreshFightState>d__;
			<RefreshFightState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshFightState>d__.<>4__this = this;
			<RefreshFightState>d__.componentData = componentData;
			<RefreshFightState>d__.<>1__state = -1;
			<RefreshFightState>d__.<>t__builder.Start<QuestMultiLineComponentItem.<RefreshFightState>d__18>(ref <RefreshFightState>d__);
			return <RefreshFightState>d__.<>t__builder.Task;
		}

		// Token: 0x06036546 RID: 222534 RVA: 0x00DB1A00 File Offset: 0x00DAFC00
		private void RefreshHeadLoopEffect(QuestMultiLineComponentData componentData)
		{
			if (this.SequencePlayer == null)
			{
				return;
			}
			string text = componentData.HeadLoopEffect ?? string.Empty;
			if (text == this.HeadLoopEffectKey)
			{
				if (!string.IsNullOrEmpty(text) && !this.SequencePlayer.IsPlayingSequence(text))
				{
					this.SequencePlayer.PlayLevelSequenceByName(text, false, null, false);
				}
				return;
			}
			if (!string.IsNullOrEmpty(this.HeadLoopEffectKey))
			{
				this.SequencePlayer.StopSequenceByKey(this.HeadLoopEffectKey, false, false);
			}
			this.HeadLoopEffectKey = text;
			if (!string.IsNullOrEmpty(text))
			{
				this.SequencePlayer.PlayLevelSequenceByName(text, false, null, false);
			}
		}

		// Token: 0x06036547 RID: 222535 RVA: 0x00DB1AA8 File Offset: 0x00DAFCA8
		public void RefreshDialogueSide()
		{
			if (this.ComponentData != null)
			{
				this.RefreshDialogue(this.ComponentData);
			}
		}

		// Token: 0x06036548 RID: 222536 RVA: 0x00DB1AC0 File Offset: 0x00DAFCC0
		private void RefreshDialogue(QuestMultiLineComponentData componentData)
		{
			if (QuestMultiLineUtils.IsComponentFinish(componentData))
			{
				QuestMultiLineDialogueItem dialogLeftPanel = this.DialogLeftPanel;
				if (dialogLeftPanel != null)
				{
					dialogLeftPanel.SetDialogueActive(false);
				}
				QuestMultiLineDialogueItem dialogRightPanel = this.DialogRightPanel;
				if (dialogRightPanel == null)
				{
					return;
				}
				dialogRightPanel.SetDialogueActive(false);
				return;
			}
			else
			{
				bool flag = this.ShouldUseLeftDialogue();
				QuestMultiLineDialogueItem dialogLeftPanel2 = this.DialogLeftPanel;
				if (dialogLeftPanel2 != null)
				{
					dialogLeftPanel2.SetDialogueActive(flag);
				}
				QuestMultiLineDialogueItem dialogRightPanel2 = this.DialogRightPanel;
				if (dialogRightPanel2 != null)
				{
					dialogRightPanel2.SetDialogueActive(!flag);
				}
				QuestMultiLineDialogueItem questMultiLineDialogueItem = flag ? this.DialogLeftPanel : this.DialogRightPanel;
				if (questMultiLineDialogueItem == null)
				{
					return;
				}
				questMultiLineDialogueItem.RefreshDialogue(componentData);
				return;
			}
		}

		// Token: 0x06036549 RID: 222537 RVA: 0x00DB1B44 File Offset: 0x00DAFD44
		private bool ShouldUseLeftDialogue()
		{
			UUIItem item = base.GetItem(3);
			UUIItem item2 = base.GetItem(4);
			if (item == null || item2 == null)
			{
				return false;
			}
			ULGUIBPLibrary.GetUIWorldPosForceUpdate(item);
			ULGUIBPLibrary.GetUIWorldPosForceUpdate(item2);
			FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(item.GetOwner());
			UUIItem uuiitem = item;
			bool bIsScaledByDPI = true;
			FVector2D fvector2D = new FVector2D(1f, 0.5f);
			if (uuiitem.GetPositionInViewportWithPivot(bIsScaledByDPI, fvector2D).X <= viewportSize.X)
			{
				return false;
			}
			UUIItem uuiitem2 = item2;
			bool bIsScaledByDPI2 = true;
			fvector2D = new FVector2D(0f, 0.5f);
			return uuiitem2.GetPositionInViewportWithPivot(bIsScaledByDPI2, fvector2D).X >= 0f;
		}

		// Token: 0x0603654A RID: 222538 RVA: 0x00DB1BD3 File Offset: 0x00DAFDD3
		private void OnClickComponent()
		{
			if (QuestMultiLineUtils.IsComponentClickable(this.ComponentData))
			{
				Action<QuestMultiLineComponentData> componentFunction = this.ComponentFunction;
				if (componentFunction == null)
				{
					return;
				}
				componentFunction(this.ComponentData);
			}
		}

		// Token: 0x0603654B RID: 222539 RVA: 0x00DB1BF8 File Offset: 0x00DAFDF8
		private void OnToggleClickComponent(EToggleState state)
		{
			this.OnClickComponent();
		}

		// Token: 0x0603654C RID: 222540 RVA: 0x00DB1C00 File Offset: 0x00DAFE00
		public void SetVisibleForAnim(bool visible)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(visible);
		}

		// Token: 0x0603654D RID: 222541 RVA: 0x00DB1C14 File Offset: 0x00DAFE14
		public UniTask PlayAppearAsync()
		{
			QuestMultiLineComponentItem.<PlayAppearAsync>d__26 <PlayAppearAsync>d__;
			<PlayAppearAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAppearAsync>d__.<>4__this = this;
			<PlayAppearAsync>d__.<>1__state = -1;
			<PlayAppearAsync>d__.<>t__builder.Start<QuestMultiLineComponentItem.<PlayAppearAsync>d__26>(ref <PlayAppearAsync>d__);
			return <PlayAppearAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F3C6 RID: 127942
		private const float ROLE_ICON_DESIGN_SIZE = 160f;

		// Token: 0x0401F3C7 RID: 127943
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<QuestMultiLineComponentData> ComponentFunction;

		// Token: 0x0401F3C8 RID: 127944
		[Nullable(2)]
		private QuestMultiLineComponentData ComponentData;

		// Token: 0x0401F3C9 RID: 127945
		[Nullable(2)]
		private QuestMultiLineDialogueItem DialogLeftPanel;

		// Token: 0x0401F3CA RID: 127946
		[Nullable(2)]
		private QuestMultiLineDialogueItem DialogRightPanel;

		// Token: 0x0401F3CB RID: 127947
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401F3CC RID: 127948
		[Nullable(2)]
		private QuestMultiLineFightStateItem FightStateItem;

		// Token: 0x0401F3CD RID: 127949
		private string FightStatePrefabPath = string.Empty;

		// Token: 0x0401F3CE RID: 127950
		private string HeadLoopEffectKey = string.Empty;
	}
}
