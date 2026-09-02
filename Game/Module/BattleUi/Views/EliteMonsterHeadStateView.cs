using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006029 RID: 24617
	[NullableContext(1)]
	[Nullable(0)]
	public class EliteMonsterHeadStateView : HeadStateViewBase
	{
		// Token: 0x0603E0D4 RID: 254164 RVA: 0x00FD62F0 File Offset: 0x00FD44F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 32;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.ScaleToleration = 0.003f;
		}

		// Token: 0x0603E0D5 RID: 254165 RVA: 0x00FD675C File Offset: 0x00FD495C
		protected override UniTask OnBeforeStartAsync()
		{
			EliteMonsterHeadStateView.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EliteMonsterHeadStateView.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E0D6 RID: 254166 RVA: 0x00FD67A0 File Offset: 0x00FD49A0
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			this.ToughItemVisible = base.GetItem(8).bIsUIActive;
			this.RageVisible = base.GetItem(5).bIsUIActive;
			this.FallDownBarVisible = base.GetSprite(12).bIsUIActive;
			this.ToughVisibleMachine.InitVisible(this.ToughItemVisible);
			base.GetItem(8).SetAlpha(1f);
			this.HpFlickerVisible = headStateData.HasTag(GameplayTagDefine.EGameplayTagId["怪物.common.状态标识.瘫痪易伤"]);
			base.GetSprite(15).SetUIActive(this.HpFlickerVisible);
			this.IsShowFallDownBar = headStateData.HasFallDownTag;
			this.RefreshNeedCorrectionOutside();
			this.RefreshHpAndShield(false);
			this.RefreshLevelText();
			base.RefreshHeadStateRotation();
			this.RefreshHeadStateDetail();
			this.RefreshLevelTextVisible();
			this.RefreshBuffVisible();
			this.RefreshFallDownBarVisible();
			this.RefreshRageVisible();
			this.RefreshToughItemVisible();
			this.RefreshRage();
			this.StopRageEmptyAnimation();
			this.RefreshBuff();
			this.RefreshHpColor();
			this.RefreshWeaknessItem(true);
		}

		// Token: 0x0603E0D7 RID: 254167 RVA: 0x00FD68A4 File Offset: 0x00FD4AA4
		protected override void OnStart()
		{
			this.InitAllTweenAnim();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.HitLargePercent = (float)ConfigCommonParamById.GetIntConfig("HitLargeBufferPercent").Value / 10000f;
			this.RageMachine.SetUpdateCallback(new RageBufferStateMachine.OnUpdateLittleReduce(this.PlayRageLittleReduceAnimation), new RageBufferStateMachine.OnUpdateLargeReduce(this.PlayRageLargeReduceAnimation), new Action(this.PlayRageEmptyAnimation));
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
			this.RageWidth = base.GetSprite(14).GetParentAsUIItem().GetWidth();
			this.ToughVisibleMachine = new VisibleAnimMachine();
			this.ToughVisibleMachine.InitCallback(new Action<bool>(this.OnToughRealVisibleChanged), new Action<bool>(this.OnPlayToughVisibleAnim), new Action<bool>(this.OnStopToughVisibleAnim));
			this.BuffItemContainer.Init(base.GetItem(9), 6, true, false, false, null);
		}

		// Token: 0x0603E0D8 RID: 254168 RVA: 0x00FD6998 File Offset: 0x00FD4B98
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.StopRageLittleReduceAnimation();
			this.StopRageEmptyAnimation();
			this.RageMachine.Reset();
			this.ToughVisibleMachine.Deactivate();
			this.ToughVisibleMachine = null;
			if (this.WeaknessItem != null)
			{
				this.WeaknessItem.Destroy(null);
				this.WeaknessItem = null;
			}
		}

		// Token: 0x0603E0D9 RID: 254169 RVA: 0x00FD69FC File Offset: 0x00FD4BFC
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			UUIItem item = base.GetItem(25);
			if (this.ExtraItem != null)
			{
				this.ExtraItem.GetRootItem().SetUIParent(item, false);
				if (item != null)
				{
					item.SetUIActive(true);
					return;
				}
			}
			else if (item != null)
			{
				item.SetUIActive(false);
			}
		}

		// Token: 0x0603E0DA RID: 254170 RVA: 0x00FD6A47 File Offset: 0x00FD4C47
		protected override void OnFallDownVisibleChange()
		{
			if (this.HeadStateData.HasFallDownTag)
			{
				this.RageMachine.GetHit(0f, this.CurRage);
				this.RefreshFallDownBar();
				this.SetFallDownBar(true);
				return;
			}
			this.SetFallDownBar(false);
		}

		// Token: 0x0603E0DB RID: 254171 RVA: 0x00FD6A81 File Offset: 0x00FD4C81
		protected override void ResetBattleHeadState()
		{
			this.BuffItemContainer.ClearAll();
			HeadStateWeaknessItem weaknessItem = this.WeaknessItem;
			if (weaknessItem != null)
			{
				weaknessItem.Refresh(null);
			}
			base.ResetBattleHeadState();
		}

		// Token: 0x0603E0DC RID: 254172 RVA: 0x00FD6AA8 File Offset: 0x00FD4CA8
		private void RefreshWeaknessItem(bool isStart = false)
		{
			base.GetUiNiagara(29).SetUIActive(false);
			if (this.WeaknessItem == null)
			{
				return;
			}
			HeadStateWeaknessItem weaknessItem = this.WeaknessItem;
			HeadStateData headStateData = this.HeadStateData;
			weaknessItem.Refresh((headStateData != null) ? headStateData.GetEntity() : null);
			this.RefreshHpWeaknessPercent();
			this.RefreshHpWeaknessState(isStart);
			this.WeaknessItem.SetStateChangeCallback(new Action(this.OnWeaknessStateChanged));
		}

		// Token: 0x0603E0DD RID: 254173 RVA: 0x00FD6B0D File Offset: 0x00FD4D0D
		private void RefreshHpWeaknessPercent()
		{
			if (this.WeaknessItem != null && this.WeaknessItem.IsFullState(true))
			{
				base.GetSprite(28).SetFillAmount(this.CurrentBarPercent);
			}
		}

		// Token: 0x0603E0DE RID: 254174 RVA: 0x00FD6B38 File Offset: 0x00FD4D38
		private void RefreshHpWeaknessState(bool isStart = false)
		{
			if (this.WeaknessItem.IsInBreakAnim())
			{
				base.GetItem(27).SetUIActive(true);
				if (!isStart)
				{
					this.PlayTweenAnim(31);
					return;
				}
			}
			else if (this.WeaknessItem.IsFullState(true))
			{
				base.GetItem(27).SetUIActive(true);
				if (!isStart)
				{
					this.PlayTweenAnim(30);
					return;
				}
			}
			else
			{
				base.GetItem(27).SetUIActive(false);
			}
		}

		// Token: 0x0603E0DF RID: 254175 RVA: 0x00FD6BA2 File Offset: 0x00FD4DA2
		private void OnWeaknessStateChanged()
		{
			this.RefreshHpWeaknessPercent();
			this.RefreshHpWeaknessState(false);
		}

		// Token: 0x0603E0E0 RID: 254176 RVA: 0x00FD6BB1 File Offset: 0x00FD4DB1
		protected override string GetResourceId()
		{
			return "UiItem_EliteMonsterState_Prefab";
		}

		// Token: 0x0603E0E1 RID: 254177 RVA: 0x00FD6BB8 File Offset: 0x00FD4DB8
		public override void OnRefresh(float distance, float scale, float delta)
		{
			base.OnRefresh(distance, scale, delta);
			if (!this.IsActivated)
			{
				return;
			}
			this.RefreshHeadStateDetail();
			this.RefreshLevelTextVisible();
			this.RefreshBuffVisible();
			this.TickBuffItem(delta);
			HeadStateWeaknessItem weaknessItem = this.WeaknessItem;
			if (weaknessItem != null)
			{
				weaknessItem.Tick(delta);
			}
			this.RageMachine.Update(delta);
			this.RefreshFallDownBar();
		}

		// Token: 0x0603E0E2 RID: 254178 RVA: 0x00FD6C14 File Offset: 0x00FD4E14
		protected override void OnAddOrRemoveBuff(int entityId, in GameplayCue cueConfig, bool isAdd, int handleId)
		{
			if (this.HeadStateData.GetEntityId() != entityId)
			{
				return;
			}
			if (isAdd)
			{
				this.BuffItemContainer.AddBuffByCue(cueConfig, handleId, true);
				return;
			}
			this.BuffItemContainer.RemoveBuffByCue(cueConfig, handleId, true);
		}

		// Token: 0x0603E0E3 RID: 254179 RVA: 0x00FD6C4C File Offset: 0x00FD4E4C
		private void RefreshBuff()
		{
			if (this.HeadStateData == null)
			{
				this.BuffItemContainer.ClearAll();
				return;
			}
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(this.HeadStateData.GetEntityId());
			this.BuffItemContainer.RefreshBuff(handle);
		}

		// Token: 0x0603E0E4 RID: 254180 RVA: 0x00FD6C90 File Offset: 0x00FD4E90
		private void RefreshHeadStateDetail()
		{
			bool flag = base.IsDetailVisible();
			base.GetItem(7).SetUIActive(flag);
			StateExtraItemBase extraItem = this.ExtraItem;
			if (extraItem != null)
			{
				extraItem.SetUiActive(flag);
			}
			this.WeaknessContainer.SetUIActive(flag);
		}

		// Token: 0x0603E0E5 RID: 254181 RVA: 0x00FD6CD0 File Offset: 0x00FD4ED0
		private void RefreshLevelTextVisible()
		{
			bool uiactive = base.IsLevelTextVisible();
			base.GetText(4).SetUIActive(uiactive);
		}

		// Token: 0x0603E0E6 RID: 254182 RVA: 0x00FD6CF4 File Offset: 0x00FD4EF4
		private void RefreshBuffVisible()
		{
			bool uiactive = base.IsBuffVisible();
			base.GetItem(9).SetUIActive(uiactive);
		}

		// Token: 0x0603E0E7 RID: 254183 RVA: 0x00FD6D16 File Offset: 0x00FD4F16
		private void TickBuffItem(float delta)
		{
			if (!base.IsBuffVisible())
			{
				return;
			}
			this.BuffItemContainer.Tick(delta);
		}

		// Token: 0x0603E0E8 RID: 254184 RVA: 0x00FD6D2D File Offset: 0x00FD4F2D
		protected override void OnEliteStateChange()
		{
			this.RefreshRageVisible();
			this.RefreshToughItemVisible();
		}

		// Token: 0x0603E0E9 RID: 254185 RVA: 0x00FD6D3C File Offset: 0x00FD4F3C
		private void RefreshNeedCorrectionOutside()
		{
			CharacterActorComponent characterActorComponent = this.HeadStateData.ActorComponent as CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.HalfHeight > this.HeadStateData.CommonParam.OutMonsterHalfHeight)
			{
				this.NeedCorrectionOutside = true;
			}
		}

		// Token: 0x0603E0EA RID: 254186 RVA: 0x00FD6D7C File Offset: 0x00FD4F7C
		public void RefreshHpAndShield(bool bPlayBarAnimation = false)
		{
			ValueTuple<float, float> hpAndShieldPercent = base.GetHpAndShieldPercent();
			float item = hpAndShieldPercent.Item1;
			float item2 = hpAndShieldPercent.Item2;
			this.SetHpBarPercent(item);
			this.SetShieldBarPercent(item2);
			if (bPlayBarAnimation)
			{
				if (item < this.CurrentBarPercent)
				{
					if (this.CurrentBarPercent - item < this.HitLargePercent)
					{
						this.PlayTweenAnim(19);
					}
					else
					{
						this.PlayTweenAnim(20);
					}
				}
				this.PlayBarAnimation(item);
			}
			else
			{
				this.StopBarLerpAnimation();
			}
			this.RefreshHpWeaknessPercent();
		}

		// Token: 0x0603E0EB RID: 254187 RVA: 0x00FD6DED File Offset: 0x00FD4FED
		protected override void OnBeginBarAnimation(float hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E0EC RID: 254188 RVA: 0x00FD6DF6 File Offset: 0x00FD4FF6
		protected override void StopBarLerpAnimation()
		{
			base.StopBarLerpAnimation();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E0ED RID: 254189 RVA: 0x00FD6E0B File Offset: 0x00FD500B
		protected override void OnLerpBarBufferPercent(float percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E0EE RID: 254190 RVA: 0x00FD6E14 File Offset: 0x00FD5014
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(0).SetFillAmount(percent);
			if (this.HpFlickerVisible)
			{
				base.GetSprite(15).SetFillAmount(percent);
			}
		}

		// Token: 0x0603E0EF RID: 254191 RVA: 0x00FD6E3C File Offset: 0x00FD503C
		private void SetBarBufferPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetFillAmount(percent);
			sprite.SetUIActive(true);
			UUISprite sprite2 = base.GetSprite(2);
			sprite2.SetStretchLeft(this.HpParentWidth * this.CurrentBarPercent - 2f);
			sprite2.SetStretchRight(this.HpParentWidth * (1f - percent) - 2f);
		}

		// Token: 0x0603E0F0 RID: 254192 RVA: 0x00FD6E98 File Offset: 0x00FD5098
		private void SetShieldBarPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(3);
			if (percent > 0f)
			{
				sprite.SetFillAmount(percent);
				sprite.SetUIActive(true);
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x0603E0F1 RID: 254193 RVA: 0x00FD6ECB File Offset: 0x00FD50CB
		protected override void OnShieldChanged(float shield)
		{
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E0F2 RID: 254194 RVA: 0x00FD6ED4 File Offset: 0x00FD50D4
		protected override void OnHardnessHideChanged(bool bTagExists)
		{
			this.RefreshRageVisible();
			this.RefreshToughItemVisible();
		}

		// Token: 0x0603E0F3 RID: 254195 RVA: 0x00FD6EE2 File Offset: 0x00FD50E2
		protected override void OnHardnessAttributeChanged()
		{
			base.OnHardnessAttributeChanged();
			this.RefreshRage();
		}

		// Token: 0x0603E0F4 RID: 254196 RVA: 0x00FD6EF0 File Offset: 0x00FD50F0
		protected override void OnHardnessChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (attributeId != this.HardnessAttributeId && attributeId != this.MaxHardnessAttributeId)
			{
				return;
			}
			this.RefreshRage();
		}

		// Token: 0x0603E0F5 RID: 254197 RVA: 0x00FD6F0C File Offset: 0x00FD510C
		protected override void VulnerabilityActivated(bool bTagExists)
		{
			this.HpFlickerVisible = bTagExists;
			UUISprite sprite = base.GetSprite(15);
			sprite.SetUIActive(bTagExists);
			if (this.HpFlickerVisible)
			{
				float item = base.GetHpAndShieldPercent().Item1;
				sprite.SetFillAmount(item);
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlaySequencePurely("Flicker", false, false, null, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.StopSequenceByKey("Flicker", false, false);
				return;
			}
		}

		// Token: 0x0603E0F6 RID: 254198 RVA: 0x00FD6F85 File Offset: 0x00FD5185
		protected override void OnLevelChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0F7 RID: 254199 RVA: 0x00FD6F8D File Offset: 0x00FD518D
		protected override void OnRoleLevelChange(int configId, int exp, int level)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0F8 RID: 254200 RVA: 0x00FD6F95 File Offset: 0x00FD5195
		protected override void OnChangeTeam()
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0F9 RID: 254201 RVA: 0x00FD6F9D File Offset: 0x00FD519D
		protected override void OnHealthChanged()
		{
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E0FA RID: 254202 RVA: 0x00FD6FA8 File Offset: 0x00FD51A8
		private void RefreshLevelText()
		{
			if (this.HeadStateData == null)
			{
				return;
			}
			int level = this.GetLevel();
			UUIText text = base.GetText(4);
			string threadColor = ConfigBase<BattleUiConfig>.Instance.GetThreadColor(level, this.HeadStateData.Camp);
			text.SetColor(FColor.FromHex(threadColor));
			Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelShow", new <>z__ReadOnlySingleElementList<object>(level));
		}

		// Token: 0x0603E0FB RID: 254203 RVA: 0x00FD700B File Offset: 0x00FD520B
		protected override void RefreshOnCampChanged()
		{
			this.RefreshLevelText();
			this.RefreshHpColor();
		}

		// Token: 0x0603E0FC RID: 254204 RVA: 0x00FD701C File Offset: 0x00FD521C
		private void RefreshToughItemVisible()
		{
			bool flag = this.IsShowFallDownBar || this.IsShowRage;
			if (this.ToughItemVisible == flag)
			{
				return;
			}
			this.ToughItemVisible = flag;
			this.ToughVisibleMachine.SetVisible(flag, 250f);
			if (flag)
			{
				base.GetItem(8).SetAlpha(1f);
			}
		}

		// Token: 0x0603E0FD RID: 254205 RVA: 0x00FD7071 File Offset: 0x00FD5271
		private void OnToughRealVisibleChanged(bool visible)
		{
			base.GetItem(8).SetUIActive(visible);
		}

		// Token: 0x0603E0FE RID: 254206 RVA: 0x00FD7080 File Offset: 0x00FD5280
		private void OnPlayToughVisibleAnim(bool visible)
		{
			if (visible)
			{
				this.PlayTweenAnim(21);
				return;
			}
			this.PlayTweenAnim(24);
		}

		// Token: 0x0603E0FF RID: 254207 RVA: 0x00FD7096 File Offset: 0x00FD5296
		private void OnStopToughVisibleAnim(bool visible)
		{
			if (visible)
			{
				this.StopTweenAnim(21);
				return;
			}
			this.StopTweenAnim(24);
		}

		// Token: 0x0603E100 RID: 254208 RVA: 0x00FD70AC File Offset: 0x00FD52AC
		private void RefreshRage()
		{
			if (this.HardnessAttributeId != EAttributeType.Rage)
			{
				return;
			}
			float attributeCurrentValueById = this.HeadStateData.GetAttributeCurrentValueById(this.MaxHardnessAttributeId);
			float attributeCurrentValueById2 = this.HeadStateData.GetAttributeCurrentValueById(this.HardnessAttributeId);
			float num = attributeCurrentValueById2 / attributeCurrentValueById;
			base.GetSprite(10).SetFillAmount(num);
			this.RageMachine.GetHit(num, this.CurRage);
			this.CurRage = attributeCurrentValueById2 / attributeCurrentValueById;
			this.SetRageEffect(num);
		}

		// Token: 0x0603E101 RID: 254209 RVA: 0x00FD7120 File Offset: 0x00FD5320
		private void SetRageEffect(float percent)
		{
			if (percent < 1f)
			{
				this.IsMaxHardnessEffectVisible = false;
				return;
			}
			if (this.IsMaxHardnessEffectVisible)
			{
				return;
			}
			if (!this.IsShowRage)
			{
				this.RefreshRageEffectNextVisible = true;
				return;
			}
			this.RefreshRageEffectNextVisible = false;
			this.IsMaxHardnessEffectVisible = true;
			base.GetUiNiagara(6).ActivateSystem(true);
			this.StopRageEmptyAnimation();
		}

		// Token: 0x0603E102 RID: 254210 RVA: 0x00FD7178 File Offset: 0x00FD5378
		private void RefreshRageVisible()
		{
			this.RefreshIsShowRage();
			if (this.RageVisible == this.IsShowRage)
			{
				return;
			}
			this.RageVisible = this.IsShowRage;
			base.GetItem(5).SetUIActive(this.RageVisible);
			if (this.RageVisible && this.RefreshRageEffectNextVisible)
			{
				this.RefreshRage();
			}
		}

		// Token: 0x0603E103 RID: 254211 RVA: 0x00FD71D0 File Offset: 0x00FD53D0
		private void RefreshIsShowRage()
		{
			if (this.IsShowFallDownBar)
			{
				this.IsShowRage = false;
				return;
			}
			if (this.HardnessAttributeId != EAttributeType.Rage)
			{
				this.IsShowRage = false;
				return;
			}
			if (this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["功能.功能制作.白条隐藏"]))
			{
				this.IsShowRage = false;
				return;
			}
			if (this.HeadStateData.GetAttributeCurrentValueById(this.MaxHardnessAttributeId) <= 0f)
			{
				this.IsShowRage = false;
				return;
			}
			this.IsShowRage = true;
		}

		// Token: 0x0603E104 RID: 254212 RVA: 0x00FD7250 File Offset: 0x00FD5450
		private void PlayRageLittleReduceAnimation(float curPercent, float targetPercent, bool isNewHit)
		{
			if (curPercent <= targetPercent)
			{
				this.StopRageLittleReduceAnimation();
				return;
			}
			UUISprite sprite = base.GetSprite(14);
			sprite.SetUIActive(true);
			sprite.SetStretchRight(this.RageWidth * (1f - curPercent));
			sprite.SetStretchLeft(this.RageWidth * targetPercent);
			if (isNewHit)
			{
				this.PlayTweenAnim(22);
			}
		}

		// Token: 0x0603E105 RID: 254213 RVA: 0x00FD72A3 File Offset: 0x00FD54A3
		private void StopRageLittleReduceAnimation()
		{
			base.GetSprite(14).SetUIActive(false);
		}

		// Token: 0x0603E106 RID: 254214 RVA: 0x00FD72B3 File Offset: 0x00FD54B3
		private void PlayRageLargeReduceAnimation(float curPercent, float targetPercent)
		{
			this.PlayTweenAnim(20);
		}

		// Token: 0x0603E107 RID: 254215 RVA: 0x00FD72C0 File Offset: 0x00FD54C0
		private void PlayRageEmptyAnimation()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(18);
			if (!uiNiagara.bIsUIActive)
			{
				uiNiagara.SetUIActive(true);
			}
			uiNiagara.ActivateSystem(true);
		}

		// Token: 0x0603E108 RID: 254216 RVA: 0x00FD72EC File Offset: 0x00FD54EC
		private void StopRageEmptyAnimation()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(18);
			if (uiNiagara.bIsUIActive)
			{
				uiNiagara.SetUIActive(false);
			}
		}

		// Token: 0x0603E109 RID: 254217 RVA: 0x00FD7311 File Offset: 0x00FD5511
		private void SetFallDownBar(bool state)
		{
			this.IsShowFallDownBar = state;
			this.RefreshFallDownBarVisible();
			this.RefreshRageVisible();
			this.RefreshToughItemVisible();
		}

		// Token: 0x0603E10A RID: 254218 RVA: 0x00FD732C File Offset: 0x00FD552C
		private void RefreshFallDownBarVisible()
		{
			if (this.IsShowFallDownBar == this.FallDownBarVisible)
			{
				return;
			}
			this.FallDownBarVisible = this.IsShowFallDownBar;
			base.GetSprite(12).SetUIActive(this.FallDownBarVisible);
			if (this.FallDownBarVisible)
			{
				this.PlayTweenAnim(23);
				return;
			}
			this.StopTweenAnim(23);
		}

		// Token: 0x0603E10B RID: 254219 RVA: 0x00FD7380 File Offset: 0x00FD5580
		private void RefreshFallDownBar()
		{
			if (!this.IsShowFallDownBar)
			{
				return;
			}
			float attributeCurrentValueById = this.HeadStateData.GetAttributeCurrentValueById(EAttributeType.ParalysisTime);
			float attributeCurrentValueById2 = this.HeadStateData.GetAttributeCurrentValueById(EAttributeType.ParalysisTimeMax);
			float num = 1f - attributeCurrentValueById / attributeCurrentValueById2;
			if (num >= 0f && num <= 1f)
			{
				UUIItem sprite = base.GetSprite(12);
				if (this.FallDownBarWidth == 0f)
				{
					this.FallDownBarWidth = base.GetItem(11).GetWidth();
				}
				sprite.SetStretchRight(this.FallDownBarWidth * num);
				float num2 = 1f;
				if (num > 0.8f)
				{
					num2 = (1f - num) * 5f;
				}
				if (this.TailCount != num2)
				{
					this.TailCount = num2;
					base.GetUiNiagara(13).SetNiagaraVarFloat("Count", num2);
				}
			}
		}

		// Token: 0x0603E10C RID: 254220 RVA: 0x00FD7448 File Offset: 0x00FD5648
		private void RefreshHpColor()
		{
			string hpColor = base.GetHpColor();
			if (string.IsNullOrEmpty(hpColor))
			{
				return;
			}
			FColor color = FColor.FromHex(hpColor);
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetColor(color);
		}

		// Token: 0x0603E10D RID: 254221 RVA: 0x00FD7480 File Offset: 0x00FD5680
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(19);
			this.InitTweenAnim(20);
			this.InitTweenAnim(21);
			this.InitTweenAnim(22);
			this.InitTweenAnim(23);
			this.InitTweenAnim(24);
			this.InitTweenAnim(30);
			this.InitTweenAnim(31);
		}

		// Token: 0x0603E10E RID: 254222 RVA: 0x00FD74D0 File Offset: 0x00FD56D0
		private void InitTweenAnim(int componentType)
		{
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>(tarray.Count);
			foreach (UActorComponent uactorComponent in tarray)
			{
				list.Add((ULGUIPlayTweenComponent)uactorComponent);
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603E10F RID: 254223 RVA: 0x00FD7550 File Offset: 0x00FD5750
		private void PlayTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603E110 RID: 254224 RVA: 0x00FD75AC File Offset: 0x00FD57AC
		private void StopTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Stop();
				}
			}
		}

		// Token: 0x04022C8C RID: 142476
		private const float SCALE_TOLERATION = 0.003f;

		// Token: 0x04022C8D RID: 142477
		private const float FALL_DOWN_DISAPPEAR_PERCENT = 0.8f;

		// Token: 0x04022C8E RID: 142478
		private const float FALL_DOWN_DISAPPEAR_TAIL_COUNT_FACTOR = 5f;

		// Token: 0x04022C8F RID: 142479
		private const float TOUGH_ANIM_TIME = 250f;

		// Token: 0x04022C90 RID: 142480
		private const EAttributeType fallDownAttributeId = EAttributeType.ParalysisTime;

		// Token: 0x04022C91 RID: 142481
		private const EAttributeType fallDownMaxAttributeId = EAttributeType.ParalysisTimeMax;

		// Token: 0x04022C92 RID: 142482
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022C93 RID: 142483
		[Nullable(2)]
		private VisibleAnimMachine ToughVisibleMachine;

		// Token: 0x04022C94 RID: 142484
		private float HitLargePercent;

		// Token: 0x04022C95 RID: 142485
		private bool IsMaxHardnessEffectVisible;

		// Token: 0x04022C96 RID: 142486
		private readonly BuffItemContainer BuffItemContainer = new BuffItemContainer();

		// Token: 0x04022C97 RID: 142487
		private readonly RageBufferStateMachine RageMachine = new RageBufferStateMachine();

		// Token: 0x04022C98 RID: 142488
		private float CurRage = 1f;

		// Token: 0x04022C99 RID: 142489
		private float HpParentWidth;

		// Token: 0x04022C9A RID: 142490
		private float RageWidth = 1f;

		// Token: 0x04022C9B RID: 142491
		private bool ToughItemVisible = true;

		// Token: 0x04022C9C RID: 142492
		private bool IsShowFallDownBar;

		// Token: 0x04022C9D RID: 142493
		private bool FallDownBarVisible;

		// Token: 0x04022C9E RID: 142494
		private bool IsShowRage = true;

		// Token: 0x04022C9F RID: 142495
		private bool RageVisible = true;

		// Token: 0x04022CA0 RID: 142496
		private bool RefreshRageEffectNextVisible;

		// Token: 0x04022CA1 RID: 142497
		private bool HpFlickerVisible;

		// Token: 0x04022CA2 RID: 142498
		private float FallDownBarWidth;

		// Token: 0x04022CA3 RID: 142499
		private float TailCount;

		// Token: 0x04022CA4 RID: 142500
		[Nullable(2)]
		private UUIItem WeaknessContainer;

		// Token: 0x04022CA5 RID: 142501
		[Nullable(2)]
		private HeadStateWeaknessItem WeaknessItem;

		// Token: 0x04022CA6 RID: 142502
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C0DD RID: 49373
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B615 RID: 243221
			NormalHpBarSprite,
			// Token: 0x0403B616 RID: 243222
			BarBufferSprite,
			// Token: 0x0403B617 RID: 243223
			HpLight,
			// Token: 0x0403B618 RID: 243224
			ShieldBarSprite,
			// Token: 0x0403B619 RID: 243225
			LevelText,
			// Token: 0x0403B61A RID: 243226
			RageItem,
			// Token: 0x0403B61B RID: 243227
			MaxHardnessEffect,
			// Token: 0x0403B61C RID: 243228
			DetailItem,
			// Token: 0x0403B61D RID: 243229
			ToughItem,
			// Token: 0x0403B61E RID: 243230
			BuffHorizontalItem,
			// Token: 0x0403B61F RID: 243231
			RageBar,
			// Token: 0x0403B620 RID: 243232
			FallDownItem,
			// Token: 0x0403B621 RID: 243233
			FallDownBar,
			// Token: 0x0403B622 RID: 243234
			FallDownBarSign,
			// Token: 0x0403B623 RID: 243235
			RageReduceLittle,
			// Token: 0x0403B624 RID: 243236
			HpFlicker,
			// Token: 0x0403B625 RID: 243237
			RageReduceLargeCanvas,
			// Token: 0x0403B626 RID: 243238
			RageReduceLarge,
			// Token: 0x0403B627 RID: 243239
			RageEmpty,
			// Token: 0x0403B628 RID: 243240
			AnimSmallHit,
			// Token: 0x0403B629 RID: 243241
			AnimBigHit,
			// Token: 0x0403B62A RID: 243242
			AnimToughStart,
			// Token: 0x0403B62B RID: 243243
			AnimToughHit,
			// Token: 0x0403B62C RID: 243244
			AnimToughFlick,
			// Token: 0x0403B62D RID: 243245
			AnimToughClose,
			// Token: 0x0403B62E RID: 243246
			MoraleLevelItem,
			// Token: 0x0403B62F RID: 243247
			WeaknessContainer,
			// Token: 0x0403B630 RID: 243248
			HpWeaknessNode,
			// Token: 0x0403B631 RID: 243249
			HpWeaknessSprite1,
			// Token: 0x0403B632 RID: 243250
			HpWeaknessEffect,
			// Token: 0x0403B633 RID: 243251
			AniHpWeaknessFull,
			// Token: 0x0403B634 RID: 243252
			AniHpWeaknessBreak
		}
	}
}
