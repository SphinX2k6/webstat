using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritState;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.NewWorld.Character.Role.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.View
{
	// Token: 0x02006AA2 RID: 27298
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritHintView : UiPanelBase
	{
		// Token: 0x06043820 RID: 276512 RVA: 0x011666D0 File Offset: 0x011648D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06043821 RID: 276513 RVA: 0x011667C0 File Offset: 0x011649C0
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnEndSequenceEvent));
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(true);
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

		// Token: 0x06043822 RID: 276514 RVA: 0x01166874 File Offset: 0x01164A74
		protected override void OnBeforeDestroy()
		{
			this.RemoveEvents();
		}

		// Token: 0x06043823 RID: 276515 RVA: 0x0116687C File Offset: 0x01164A7C
		private void AddEvents()
		{
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged));
			}
			if (!Singleton<EventSystem>.Instance.Has<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged)))
			{
				Singleton<EventSystem>.Instance.Add<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged));
			}
		}

		// Token: 0x06043824 RID: 276516 RVA: 0x011668FC File Offset: 0x01164AFC
		private void RemoveEvents()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnSunSpiritOccupiedByPlayerChanged, new Action(this.OnSunSpiritOccupiedByPlayerChanged));
			}
			if (Singleton<EventSystem>.Instance.Has<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged)))
			{
				Singleton<EventSystem>.Instance.Remove<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(EEventName.OnSunSpiritLauncherWatchSelectedChanged, new Action<SceneItemSunSpiritLauncherComponent, SceneItemSunSpiritLauncherComponent>(this.OnSunSpiritLauncherWatchSelectedChanged));
			}
		}

		// Token: 0x06043825 RID: 276517 RVA: 0x0116697B File Offset: 0x01164B7B
		public void Tick(float delta)
		{
			this.RemainKeepVisibleTime -= (double)delta;
			this.CheckAndUpdateVisible();
			this.UpdateLocation(delta);
		}

		// Token: 0x06043826 RID: 276518 RVA: 0x0116699C File Offset: 0x01164B9C
		[NullableContext(2)]
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

		// Token: 0x06043827 RID: 276519 RVA: 0x011669E4 File Offset: 0x01164BE4
		private void CheckAndUpdateVisible()
		{
			if (this.RemainKeepVisibleTime <= 0.0)
			{
				this.RemainKeepVisibleTime = 0.0;
			}
			if (this.RemainKeepVisibleTime > 0.0 || this.GetWatchSelectedLauncherComp() != null)
			{
				UUIItem rootItem = this.RootItem;
				if (rootItem == null || !rootItem.IsUIActiveSelf())
				{
					this.ShowHintView();
					this.UpdateHint();
					return;
				}
			}
			else
			{
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 != null && rootItem2.IsUIActiveSelf())
				{
					this.HideHintView();
				}
			}
		}

		// Token: 0x06043828 RID: 276520 RVA: 0x01166A68 File Offset: 0x01164C68
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

		// Token: 0x06043829 RID: 276521 RVA: 0x01166ABC File Offset: 0x01164CBC
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

		// Token: 0x0604382A RID: 276522 RVA: 0x01166B10 File Offset: 0x01164D10
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

		// Token: 0x0604382B RID: 276523 RVA: 0x01166B6B File Offset: 0x01164D6B
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

		// Token: 0x0604382C RID: 276524 RVA: 0x01166B98 File Offset: 0x01164D98
		private void OnSunSpiritOccupiedByPlayerChanged()
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			float? num = (instance != null) ? new float?(instance.GetSunSpiritConfig().CharacterHintUiShowDurationWhenUpdate) : null;
			double? num2 = (num != null) ? new double?((double)num.GetValueOrDefault()) : null;
			if (num2 != null)
			{
				this.SetVisibleForDuration(num2.Value * 1000.0);
			}
			this.UpdateHint();
		}

		// Token: 0x0604382D RID: 276525 RVA: 0x01166C11 File Offset: 0x01164E11
		[NullableContext(2)]
		private void OnSunSpiritLauncherWatchSelectedChanged(SceneItemSunSpiritLauncherComponent oldSunSpiritLauncher, SceneItemSunSpiritLauncherComponent newSunSpiritLauncher)
		{
			this.CheckAndUpdateVisible();
		}

		// Token: 0x0604382E RID: 276526 RVA: 0x01166C19 File Offset: 0x01164E19
		private void SetVisibleForDuration(double duration)
		{
			if (duration <= 0.0)
			{
				return;
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null || !rootItem.IsUIActiveSelf())
			{
				this.ShowHintView();
			}
			this.RemainKeepVisibleTime = duration;
		}

		// Token: 0x0604382F RID: 276527 RVA: 0x01166C4C File Offset: 0x01164E4C
		private void UpdateHint()
		{
			SunSpiritModel instance = ModelBase<SunSpiritModel>.Instance;
			int num;
			if (instance == null)
			{
				num = 0;
			}
			else
			{
				CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
				int playerId = (instance2 != null) ? instance2.GetPlayerId() : 0;
				AreaModel instance3 = ModelBase<AreaModel>.Instance;
				num = instance.GetSunSpiritNumByPlayerIdAndAreaId(playerId, (instance3 != null) ? instance3.GetCurrentAreaId(null) : 0, true, delegate(SunSpiritData sunSpiritData)
				{
					SunSpiritOccupiedByPlayerState sunSpiritOccupiedByPlayerState = sunSpiritData.GetSunSpiritState() as SunSpiritOccupiedByPlayerState;
					return sunSpiritOccupiedByPlayerState != null && !sunSpiritOccupiedByPlayerState.IsFinished;
				});
			}
			int num2 = num;
			this.UpdateTxtNum(num2);
			this.UpdateLocation(0f);
		}

		// Token: 0x06043830 RID: 276528 RVA: 0x01166CC8 File Offset: 0x01164EC8
		private void UpdateTxtNum(int num)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x06043831 RID: 276529 RVA: 0x01166CE4 File Offset: 0x01164EE4
		private void UpdateLocation(float delta)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			FVectorDouble? fvectorDouble = (baseCharacter != null) ? new FVectorDouble?(baseCharacter.D_K2_GetActorLocation()) : null;
			if (fvectorDouble == null)
			{
				return;
			}
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
			FVectorDouble value = fvectorDouble.Value;
			if (!UGameplayStatics.D_ProjectWorldToScreen(player, value, ref fvector2D, false))
			{
				return;
			}
			this.TargetAnchorOffset.FromUeVector2D(fvector2D);
			this.TargetAnchorOffset.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset);
			this.TargetAnchorOffset.Y *= -1.0;
			this.TargetAnchorOffset.AdditionEqual(sunSpiritConfig.CharacterHintUiAnchorOffset);
			if (this.RootItem == null)
			{
				return;
			}
			if (Math.Abs(this.TargetAnchorOffset.X - this.CurrentAnchorOffset.X) > 500.0 || Math.Abs(this.TargetAnchorOffset.Y - this.CurrentAnchorOffset.Y) > 500.0)
			{
				this.CurrentAnchorOffset.X = this.TargetAnchorOffset.X;
				this.CurrentAnchorOffset.Y = this.TargetAnchorOffset.Y;
				UUIItem rootItem = this.RootItem;
				if (rootItem == null)
				{
					return;
				}
				rootItem.SetAnchorOffset(this.CurrentAnchorOffset.ToUeVector2D(false));
				return;
			}
			else
			{
				this.CurrentSpeed.X = this.GetSpeed((double)delta, this.TargetAnchorOffset.X, this.CurrentAnchorOffset.X, this.CurrentSpeed.X);
				this.CurrentSpeed.Y = this.GetSpeed((double)delta, this.TargetAnchorOffset.Y, this.CurrentAnchorOffset.Y, this.CurrentSpeed.Y);
				double num = this.CurrentSpeed.X * (double)delta;
				double num2 = this.CurrentSpeed.Y * (double)delta;
				if (Math.Abs(num) < 0.5 && Math.Abs(num2) < 0.5)
				{
					return;
				}
				this.CurrentAnchorOffset.X += num;
				this.CurrentAnchorOffset.Y += num2;
				UUIItem rootItem2 = this.RootItem;
				if (rootItem2 == null)
				{
					return;
				}
				rootItem2.SetAnchorOffset(this.CurrentAnchorOffset.ToUeVector2D(false));
				return;
			}
		}

		// Token: 0x06043832 RID: 276530 RVA: 0x01166F54 File Offset: 0x01165154
		private double GetSpeed(double delta, double target, double cur, double lastSpeed)
		{
			double num = target - cur;
			bool flag = false;
			if (num < 0.0)
			{
				num = -num;
				flag = true;
			}
			if (num < 1.0)
			{
				return 0.0;
			}
			double num2;
			if (delta >= 200.0)
			{
				num2 = num / delta;
			}
			else
			{
				num2 = num / 200.0;
			}
			if (flag)
			{
				num2 = -num2;
			}
			return Singleton<MathUtils>.Instance.Lerp(lastSpeed, num2, 0.5);
		}

		// Token: 0x04025B67 RID: 154471
		public const int MAX_DELTA_TIME = 200;

		// Token: 0x04025B68 RID: 154472
		public const float MIN_DELTA_OFFSET = 0.5f;

		// Token: 0x04025B69 RID: 154473
		public const int MAX_POS_OFFSET = 500;

		// Token: 0x04025B6A RID: 154474
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04025B6B RID: 154475
		private double RemainKeepVisibleTime;

		// Token: 0x04025B6C RID: 154476
		private readonly Vector2D TargetAnchorOffset = Vector2D.Create();

		// Token: 0x04025B6D RID: 154477
		private readonly Vector2D CurrentAnchorOffset = Vector2D.Create();

		// Token: 0x04025B6E RID: 154478
		private readonly Vector2D CurrentSpeed = Vector2D.Create();

		// Token: 0x0200C9E6 RID: 51686
		[NullableContext(0)]
		public enum EChildType
		{
			// Token: 0x0403E0A8 RID: 254120
			NormalTxtNum,
			// Token: 0x0403E0A9 RID: 254121
			DefaultBg,
			// Token: 0x0403E0AA RID: 254122
			NotEnoughBgOverlay,
			// Token: 0x0403E0AB RID: 254123
			NotEnoughTxtNum,
			// Token: 0x0403E0AC RID: 254124
			EnoughBgOverlay,
			// Token: 0x0403E0AD RID: 254125
			EnoughTxtNum
		}
	}
}
