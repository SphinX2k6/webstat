using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006045 RID: 24645
	public class JoystickStatic : Joystick, IBattleUiCenterPanelOtherMovePanel
	{
		// Token: 0x0603E2A6 RID: 254630 RVA: 0x00FDF464 File Offset: 0x00FDD664
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(8, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(9, typeof(UUIItem)));
		}

		// Token: 0x0603E2A7 RID: 254631 RVA: 0x00FDF4A4 File Offset: 0x00FDD6A4
		protected override void OnAfterShow()
		{
			this.TagIdVisible = ModelBase<BattleUiModel>.Instance.GetTagIdJoystickStaticVisible();
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				if (this.TagIdVisible != null)
				{
					BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
					if (gameplayTagComponent == null)
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "Initialize gamePlayTag 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
						return;
					}
					if (gameplayTagComponent.HasAnyTag(this.TagIdVisible))
					{
						UUIItem rootItem = this.RootItem;
						if (rootItem != null)
						{
							rootItem.SetUIActive(false);
						}
						curRoleData.MorphShowSpecialEnergyBar = true;
						return;
					}
					curRoleData.MorphShowSpecialEnergyBar = false;
					foreach (int tagId in this.TagIdVisible)
					{
						gameplayTagComponent.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagAddOrRemove), null);
					}
					return;
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "Initialize roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0603E2A8 RID: 254632 RVA: 0x00FDF584 File Offset: 0x00FDD784
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.AnimHoverItem = new List<ULGUIPlayTweenComponent>();
			UUIItem item = base.GetItem(8);
			TArray<UActorComponent> tarray;
			if (item == null)
			{
				tarray = null;
			}
			else
			{
				AActor owner = item.GetOwner();
				tarray = ((owner != null) ? owner.K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()) : null);
			}
			TArray<UActorComponent> tarray2 = tarray;
			int num = tarray2.Num();
			for (int i = 0; i < num; i++)
			{
				this.AnimHoverItem.Add((ULGUIPlayTweenComponent)tarray2.Get(i));
			}
			this.AnimNormalItem = new List<ULGUIPlayTweenComponent>();
			UUIItem item2 = base.GetItem(9);
			TArray<UActorComponent> tarray3;
			if (item2 == null)
			{
				tarray3 = null;
			}
			else
			{
				AActor owner2 = item2.GetOwner();
				tarray3 = ((owner2 != null) ? owner2.K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()) : null);
			}
			tarray2 = tarray3;
			num = tarray2.Num();
			for (int j = 0; j < num; j++)
			{
				this.AnimNormalItem.Add((ULGUIPlayTweenComponent)tarray2.Get(j));
			}
			this.TargetVector.Set(0.0, 200.0, 0.0);
			this.SetHandleOffset(this.TargetVector);
			base.SetInputAxis(this.TargetVector, true);
			this.SetUiOnDrag(false);
			this.IsDynamicJoystick = false;
		}

		// Token: 0x0603E2A9 RID: 254633 RVA: 0x00FDF6A4 File Offset: 0x00FDD8A4
		protected override void OnHideBattleChildView()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				curRoleData.MorphShowSpecialEnergyBar = true;
				if (this.TagIdVisible != null)
				{
					BaseTagComponent gameplayTagComponent = curRoleData.GameplayTagComponent;
					if (gameplayTagComponent != null)
					{
						foreach (int tagId in this.TagIdVisible)
						{
							gameplayTagComponent.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagAddOrRemove));
						}
						return;
					}
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnHideBattleChildView gamePlayTag 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnHideBattleChildView roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0603E2AA RID: 254634 RVA: 0x00FDF744 File Offset: 0x00FDD944
		private void OnTagAddOrRemove(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData != null)
				{
					curRoleData.MorphShowSpecialEnergyBar = true;
				}
				else
				{
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnTagAddOrRemove roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiEnergyBarVisible, true);
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetUIActive(false);
			}
		}

		// Token: 0x0603E2AB RID: 254635 RVA: 0x00FDF7A9 File Offset: 0x00FDD9A9
		public override void OnDynamicChanged(bool isDynamic)
		{
		}

		// Token: 0x0603E2AC RID: 254636 RVA: 0x00FDF7AC File Offset: 0x00FDD9AC
		protected override void OnWalk()
		{
			if (this.CurrentJoystickType == EJoystickType.Walk)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "控制角色行走", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.SetUiOnDrag(true);
			this.CurrentJoystickType = EJoystickType.Walk;
		}

		// Token: 0x0603E2AD RID: 254637 RVA: 0x00FDF7FC File Offset: 0x00FDD9FC
		protected override void OnRun()
		{
			if (this.CurrentJoystickType == EJoystickType.Run)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
			{
				Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "控制角色奔跑", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.SetUiOnDrag(true);
			this.CurrentJoystickType = EJoystickType.Run;
		}

		// Token: 0x0603E2AE RID: 254638 RVA: 0x00FDF84C File Offset: 0x00FDDA4C
		protected override void OnStand()
		{
			if (this.CurrentJoystickType != EJoystickType.Stand)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "松开摇杆时控制角色站立", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				if (this.CurrentJoystickType != EJoystickType.StandInTouch)
				{
					this.SetUiOnDrag(false);
				}
				this.CurrentJoystickType = EJoystickType.Stand;
			}
		}

		// Token: 0x0603E2AF RID: 254639 RVA: 0x00FDF8A0 File Offset: 0x00FDDAA0
		protected override void OnStandInTouch()
		{
			if (this.CurrentJoystickType != EJoystickType.StandInTouch)
			{
				if (ModelBase<BattleUiModel>.Instance.IsOpenJoystickLog)
				{
					Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.XXJ, "按下摇杆时控制角色站立", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				if (this.CurrentJoystickType != EJoystickType.Stand)
				{
					this.SetUiOnDrag(false);
				}
				this.CurrentJoystickType = EJoystickType.StandInTouch;
			}
		}

		// Token: 0x0603E2B0 RID: 254640 RVA: 0x00FDF8F4 File Offset: 0x00FDDAF4
		protected void SetUiOnDrag(bool onDrag)
		{
			if (onDrag)
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.AnimNormalItem)
				{
					ulguiplayTweenComponent.Stop();
				}
				using (List<ULGUIPlayTweenComponent>.Enumerator enumerator = this.AnimHoverItem.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ULGUIPlayTweenComponent ulguiplayTweenComponent2 = enumerator.Current;
						ulguiplayTweenComponent2.Play();
					}
					return;
				}
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent3 in this.AnimHoverItem)
			{
				ulguiplayTweenComponent3.Stop();
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent4 in this.AnimNormalItem)
			{
				ulguiplayTweenComponent4.Play();
			}
		}

		// Token: 0x0603E2B1 RID: 254641 RVA: 0x00FDFA04 File Offset: 0x00FDDC04
		[NullableContext(1)]
		protected override void SetHandleOffset(Vector targetVector)
		{
			FRotator? rotatorMoveArrow = base.GetRotatorMoveArrow(targetVector);
			if (rotatorMoveArrow == null)
			{
				return;
			}
			UUIItem walkBgItem = this.WalkBgItem;
			FRotator value = rotatorMoveArrow.Value;
			walkBgItem.SetUIRelativeRotation(value);
		}

		// Token: 0x0603E2B2 RID: 254642 RVA: 0x00FDFA38 File Offset: 0x00FDDC38
		public override void SetVisible(EBattleUiVisibleReason visibleReason, bool bVisible)
		{
			this.JoystickVisible = bVisible;
		}

		// Token: 0x0603E2B3 RID: 254643 RVA: 0x00FDFA41 File Offset: 0x00FDDC41
		protected override void UpdateJoystickVisible()
		{
		}

		// Token: 0x04022DA8 RID: 142760
		private const float INIT_TARGET_VECTOR_Y = 200f;

		// Token: 0x04022DA9 RID: 142761
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> AnimHoverItem;

		// Token: 0x04022DAA RID: 142762
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> AnimNormalItem;

		// Token: 0x04022DAB RID: 142763
		[Nullable(2)]
		private int[] TagIdVisible;

		// Token: 0x0200C105 RID: 49413
		private enum EChildType
		{
			// Token: 0x0403B70D RID: 243469
			AnimOnHover = 8,
			// Token: 0x0403B70E RID: 243470
			AnimNormal
		}
	}
}
