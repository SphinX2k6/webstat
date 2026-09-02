using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.View
{
	// Token: 0x02006AA5 RID: 27301
	[NullableContext(2)]
	[Nullable(0)]
	public class SunSpiritLauncherHintView : UiPanelBase
	{
		// Token: 0x06043835 RID: 276533 RVA: 0x01167004 File Offset: 0x01165204
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
		}

		// Token: 0x06043836 RID: 276534 RVA: 0x011670A0 File Offset: 0x011652A0
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIText text3 = base.GetText(5);
			if (text3 != null)
			{
				text3.SetUIActive(false);
			}
			base.SetUiActive(false);
			this.AddEvents();
		}

		// Token: 0x06043837 RID: 276535 RVA: 0x01167154 File Offset: 0x01165354
		protected override void OnBeforeDestroy()
		{
			this.ClearTargetLauncherComp();
			Singleton<EventSystem>.Instance.RemoveAllTargetUseKey(this);
			this.RemoveEvents();
		}

		// Token: 0x06043838 RID: 276536 RVA: 0x01167170 File Offset: 0x01165370
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged)))
			{
				Singleton<EventSystem>.Instance.Add<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged));
			}
			this.ChangeTargetLauncherComp(this.GetWatchSelectedLauncherComp());
		}

		// Token: 0x06043839 RID: 276537 RVA: 0x011671C2 File Offset: 0x011653C2
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged));
			}
		}

		// Token: 0x0604383A RID: 276538 RVA: 0x011671FD File Offset: 0x011653FD
		public void Tick(double delta)
		{
			this.CheckAndUpdateVisible();
			this.UpdateLocation(delta);
		}

		// Token: 0x0604383B RID: 276539 RVA: 0x0116720C File Offset: 0x0116540C
		private void OnSunSpiritLauncherWatchSelectedChanged(SceneItemSunSpiritLauncherComponent oldSunSpiritLauncher, SceneItemSunSpiritLauncherComponent newSunSpiritLauncher)
		{
			this.ChangeTargetLauncherComp(this.GetWatchSelectedLauncherComp());
		}

		// Token: 0x0604383C RID: 276540 RVA: 0x0116721C File Offset: 0x0116541C
		private void ShowHintView()
		{
			base.SetUiActive(true);
			if (this.SequencePlayer == null)
			{
				this.OnEndSequenceEvent("Start");
				return;
			}
			if (this.SequencePlayer.IsSequenceFinish("Start"))
			{
				this.SequencePlayer.PlaySequence("Start", false, null);
			}
		}

		// Token: 0x0604383D RID: 276541 RVA: 0x01167270 File Offset: 0x01165470
		private void HideHintView()
		{
			if (this.SequencePlayer == null)
			{
				this.OnEndSequenceEvent("Close");
				return;
			}
			if (this.SequencePlayer.IsSequenceFinish("Close"))
			{
				this.ToggleLoopSequence(false);
				this.SequencePlayer.PlaySequence("Close", false, null);
			}
		}

		// Token: 0x0604383E RID: 276542 RVA: 0x011672C4 File Offset: 0x011654C4
		private void ToggleLoopSequence(bool bEnable)
		{
			if (this.SequencePlayer == null)
			{
				return;
			}
			if (this.SequencePlayer.IsSequenceFinish("Loop"))
			{
				if (bEnable)
				{
					this.SequencePlayer.PlaySequence("Loop", false, null);
					return;
				}
			}
			else if (!bEnable)
			{
				this.SequencePlayer.StopSequenceByKey("Loop", false, false);
			}
		}

		// Token: 0x0604383F RID: 276543 RVA: 0x0116731F File Offset: 0x0116551F
		[NullableContext(1)]
		private void OnEndSequenceEvent(string seqName)
		{
			if (seqName == "Start")
			{
				this.ToggleLoopSequence(true);
				return;
			}
			if (seqName == "Close")
			{
				base.SetUiActive(false);
			}
		}

		// Token: 0x06043840 RID: 276544 RVA: 0x0116734A File Offset: 0x0116554A
		private void OnSunSpiritOccupiedByGearChanged()
		{
			this.UpdateHint();
		}

		// Token: 0x06043841 RID: 276545 RVA: 0x01167352 File Offset: 0x01165552
		private void OnSunSpiritOccupiedByPlayerChanged()
		{
			this.UpdateHint();
		}

		// Token: 0x06043842 RID: 276546 RVA: 0x0116735C File Offset: 0x0116555C
		private SceneItemSunSpiritLauncherComponent GetWatchSelectedLauncherComp()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity == null || !entity.Valid)
			{
				return null;
			}
			if (entity == null)
			{
				return null;
			}
			RoleSceneInteractComponent component = entity.GetComponent<RoleSceneInteractComponent>();
			if (component == null)
			{
				return null;
			}
			return component.GetSunSpiritLauncherUiTarget();
		}

		// Token: 0x06043843 RID: 276547 RVA: 0x011673A4 File Offset: 0x011655A4
		private void ChangeTargetLauncherComp(SceneItemSunSpiritLauncherComponent newSunSpiritLauncher)
		{
			if (newSunSpiritLauncher == this.TargetLauncherComp)
			{
				return;
			}
			this.ClearTargetLauncherComp();
			if (newSunSpiritLauncher != null)
			{
				this.SetupTargetLauncherComp(newSunSpiritLauncher);
			}
			this.CheckAndUpdateVisible();
			this.UpdateHint();
		}

		// Token: 0x06043844 RID: 276548 RVA: 0x011673CC File Offset: 0x011655CC
		private void ClearTargetLauncherComp()
		{
			if (this.TargetGearComp != null && Singleton<EventSystem>.Instance.HasWithTarget(this.TargetGearComp.Entity, EEventName.OnSunSpiritOccupiedByGearChanged, new Action(this.OnSunSpiritOccupiedByGearChanged)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTargetUseKey(this, this.TargetGearComp.Entity, EEventName.OnSunSpiritOccupiedByGearChanged, new Action(this.OnSunSpiritOccupiedByGearChanged));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged));
			}
			this.TargetLauncherComp = null;
			this.TargetGearComp = null;
		}

		// Token: 0x06043845 RID: 276549 RVA: 0x01167478 File Offset: 0x01165678
		[NullableContext(1)]
		private void SetupTargetLauncherComp(SceneItemSunSpiritLauncherComponent newSunSpiritLauncher)
		{
			if (newSunSpiritLauncher == null || newSunSpiritLauncher.GetTargetGear() == null)
			{
				return;
			}
			this.TargetLauncherComp = newSunSpiritLauncher;
			this.TargetGearComp = newSunSpiritLauncher.GetTargetGear();
			if (!Singleton<EventSystem>.Instance.HasWithTarget(this.TargetGearComp.Entity, EEventName.OnSunSpiritOccupiedByGearChanged, new Action(this.OnSunSpiritOccupiedByGearChanged)))
			{
				Singleton<EventSystem>.Instance.AddWithTargetUseHoldKey(this, this.TargetGearComp.Entity, EEventName.OnSunSpiritOccupiedByGearChanged, new Action(this.OnSunSpiritOccupiedByGearChanged));
			}
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged));
			}
		}

		// Token: 0x06043846 RID: 276550 RVA: 0x01167530 File Offset: 0x01165730
		private void CheckAndUpdateVisible()
		{
			if (this.TargetLauncherComp != null)
			{
				if (this.RootItem != null && !this.RootItem.IsUIActiveSelf())
				{
					this.ShowHintView();
					this.UpdateHint();
					return;
				}
			}
			else
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem != null && rootItem.IsUIActiveSelf())
				{
					this.HideHintView();
				}
			}
		}

		// Token: 0x06043847 RID: 276551 RVA: 0x01167584 File Offset: 0x01165784
		private void SwitchToEnough()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(true);
		}

		// Token: 0x06043848 RID: 276552 RVA: 0x011675DC File Offset: 0x011657DC
		private void SwitchToNotEnough()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(true);
		}

		// Token: 0x06043849 RID: 276553 RVA: 0x01167634 File Offset: 0x01165834
		private void UpdateHint()
		{
			if (this.TargetLauncherComp != null)
			{
				int numOfNeededSunSpirit = this.TargetLauncherComp.GetNumOfNeededSunSpirit();
				int numOfSunSpiritRelatedToLauncher = this.TargetLauncherComp.GetNumOfSunSpiritRelatedToLauncher(true, true, true, true);
				if (numOfNeededSunSpirit > numOfSunSpiritRelatedToLauncher)
				{
					this.SwitchToNotEnough();
				}
				else
				{
					this.SwitchToEnough();
				}
				this.UpdateTxtNum(numOfNeededSunSpirit);
				this.UpdateLocation(0.0);
			}
		}

		// Token: 0x0604384A RID: 276554 RVA: 0x0116768D File Offset: 0x0116588D
		private void UpdateTxtNum(int num)
		{
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(num.ToString(), true);
			}
			UUIText text2 = base.GetText(3);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(num.ToString(), true);
		}

		// Token: 0x0604384B RID: 276555 RVA: 0x011676C4 File Offset: 0x011658C4
		private void UpdateLocation(double delta)
		{
			SceneItemSunSpiritLauncherComponent targetLauncherComp = this.TargetLauncherComp;
			if (targetLauncherComp == null || !targetLauncherComp.GetHintViewLocation(this.TmpVector))
			{
				return;
			}
			Vector tmpVector = this.TmpVector;
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			if (instance == null)
			{
				return;
			}
			SunSpiritModel instance2 = ModelBase<SunSpiritModel>.Instance;
			SunSpiritConfig sunSpiritConfig = (instance2 != null) ? instance2.GetSunSpiritConfig() : null;
			if (sunSpiritConfig == null)
			{
				return;
			}
			FVector2D fvector2D = default(FVector2D);
			APlayerController player = characterController;
			FVectorDouble fvectorDouble = tmpVector.ToUeVector(false);
			if (!UGameplayStatics.D_ProjectWorldToScreen(player, fvectorDouble, ref fvector2D, false))
			{
				return;
			}
			this.TargetAnchorOffset.FromUeVector2D(fvector2D);
			this.TargetAnchorOffset.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset);
			this.TargetAnchorOffset.Y *= -1.0;
			this.TargetAnchorOffset.AdditionEqual(sunSpiritConfig.LauncherHintUiAnchorOffset);
			if (this.RootItem == null)
			{
				return;
			}
			this.CurrentAnchorOffset.FromUeVector2D(this.RootItem.GetAnchorOffset());
			double num = this.TargetAnchorOffset.X - this.CurrentAnchorOffset.X;
			double num2 = this.TargetAnchorOffset.Y - this.CurrentAnchorOffset.Y;
			if (Math.Abs(num) < 0.5 && Math.Abs(num2) < 0.5)
			{
				return;
			}
			if (delta != 0.0 && !sunSpiritConfig.LauncherHintUiPosLerpSpeed.IsNearlyZero(9.999999747378752E-05) && Math.Abs(num) <= 500.0 && Math.Abs(num2) <= 500.0)
			{
				double num3 = sunSpiritConfig.LauncherHintUiPosLerpSpeed.X * 1000.0;
				double num4 = sunSpiritConfig.LauncherHintUiPosLerpSpeed.Y * 1000.0;
				double num5 = (delta > 200.0) ? 200.0 : delta;
				double alpha = Singleton<MathUtils>.Instance.Clamp(Math.Abs(num3 * num5 / num), 0.0, 1.0);
				double alpha2 = Singleton<MathUtils>.Instance.Clamp(Math.Abs(num4 * num5 / num2), 0.0, 1.0);
				this.CurrentAnchorOffset.X = Singleton<MathUtils>.Instance.Lerp(this.CurrentAnchorOffset.X, this.TargetAnchorOffset.X, alpha);
				this.CurrentAnchorOffset.Y = Singleton<MathUtils>.Instance.Lerp(this.CurrentAnchorOffset.Y, this.TargetAnchorOffset.Y, alpha2);
			}
			else
			{
				this.CurrentAnchorOffset.DeepCopy(this.TargetAnchorOffset);
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(this.CurrentAnchorOffset.ToUeVector2D(false));
		}

		// Token: 0x04025B79 RID: 154489
		private SceneItemSunSpiritLauncherComponent TargetLauncherComp;

		// Token: 0x04025B7A RID: 154490
		private SceneItemSunSpiritGearComponent TargetGearComp;

		// Token: 0x04025B7B RID: 154491
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04025B7C RID: 154492
		[Nullable(1)]
		private readonly Vector2D TargetAnchorOffset = Vector2D.Create();

		// Token: 0x04025B7D RID: 154493
		[Nullable(1)]
		private readonly Vector2D CurrentAnchorOffset = Vector2D.Create();

		// Token: 0x04025B7E RID: 154494
		[Nullable(1)]
		private readonly Vector TmpVector = Vector.Create();
	}
}
