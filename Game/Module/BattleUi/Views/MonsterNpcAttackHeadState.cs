using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006031 RID: 24625
	[NullableContext(1)]
	[Nullable(0)]
	public class MonsterNpcAttackHeadState : HeadStateViewBase
	{
		// Token: 0x0603E1BE RID: 254398 RVA: 0x00FDA16C File Offset: 0x00FD836C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 27;
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
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUINiagara));
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
			this.ComponentRegisterInfos = list;
			this.ScaleToleration = 0.003f;
		}

		// Token: 0x0603E1BF RID: 254399 RVA: 0x00FDA52C File Offset: 0x00FD872C
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			this.RefreshNeedCorrectionOutside();
			this.RefreshHpAndShield(false);
			this.RefreshLevelText();
			base.RefreshHeadStateRotation();
			this.RefreshHeadStateDetail();
			this.RefreshLevelTextVisible();
			this.RefreshBuffVisible();
			this.RefreshBuff();
			this.RefreshHpColor();
			this.RefreshSpecialEnergy4(false);
			this.RefreshSlowChargeState(null);
			this.RefreshFastChargeState(null);
			this.RefreshAttackReadyState(null);
			this.RefreshAttackBeginState(null);
			this.RefreshAttackEndState(null);
			this.RefreshAttackBrokenState(null);
		}

		// Token: 0x0603E1C0 RID: 254400 RVA: 0x00FDA5D8 File Offset: 0x00FD87D8
		protected override void OnStart()
		{
			this.InitAllTweenAnim();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.HitLargePercent = (float)ConfigCommonParamById.GetIntConfig("HitLargeBufferPercent").Value / 10000f;
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(16);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(18);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(false);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(17);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetUIActive(false);
			}
			UUINiagara uiNiagara4 = base.GetUiNiagara(19);
			if (uiNiagara4 != null)
			{
				uiNiagara4.SetUIActive(false);
			}
			this.BuffItemContainer.Init(base.GetItem(8), 6, true, false, false, null);
		}

		// Token: 0x0603E1C1 RID: 254401 RVA: 0x00FDA6AD File Offset: 0x00FD88AD
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603E1C2 RID: 254402 RVA: 0x00FDA6C1 File Offset: 0x00FD88C1
		protected override void ResetBattleHeadState()
		{
			this.BuffItemContainer.ClearAll();
			base.ResetBattleHeadState();
		}

		// Token: 0x0603E1C3 RID: 254403 RVA: 0x00FDA6D4 File Offset: 0x00FD88D4
		protected override string GetResourceId()
		{
			return "UiItem_EnergyBarAogusita";
		}

		// Token: 0x0603E1C4 RID: 254404 RVA: 0x00FDA6DB File Offset: 0x00FD88DB
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
			this.LerpAttackPercent(delta);
		}

		// Token: 0x0603E1C5 RID: 254405 RVA: 0x00FDA70F File Offset: 0x00FD890F
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

		// Token: 0x0603E1C6 RID: 254406 RVA: 0x00FDA748 File Offset: 0x00FD8948
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

		// Token: 0x0603E1C7 RID: 254407 RVA: 0x00FDA78C File Offset: 0x00FD898C
		private void RefreshHeadStateDetail()
		{
			bool uiactive = base.IsDetailVisible();
			base.GetItem(5).SetUIActive(uiactive);
		}

		// Token: 0x0603E1C8 RID: 254408 RVA: 0x00FDA7B0 File Offset: 0x00FD89B0
		private void RefreshLevelTextVisible()
		{
			bool uiactive = base.IsLevelTextVisible();
			base.GetText(4).SetUIActive(uiactive);
		}

		// Token: 0x0603E1C9 RID: 254409 RVA: 0x00FDA7D4 File Offset: 0x00FD89D4
		private void RefreshBuffVisible()
		{
			bool uiactive = base.IsBuffVisible();
			base.GetItem(8).SetUIActive(uiactive);
		}

		// Token: 0x0603E1CA RID: 254410 RVA: 0x00FDA7F5 File Offset: 0x00FD89F5
		private void TickBuffItem(float delta)
		{
			if (!base.IsBuffVisible())
			{
				return;
			}
			this.BuffItemContainer.Tick(delta);
		}

		// Token: 0x0603E1CB RID: 254411 RVA: 0x00FDA80C File Offset: 0x00FD8A0C
		private void LerpAttackPercent(float delta)
		{
			this.AttackMachine.UpdatePercent(delta);
			if (this.AttackMachine.HasUpdate())
			{
				this.RefreshEnergyBar(this.AttackMachine.CurrentPercent);
			}
		}

		// Token: 0x0603E1CC RID: 254412 RVA: 0x00FDA83C File Offset: 0x00FD8A3C
		private void RefreshNeedCorrectionOutside()
		{
			CharacterActorComponent characterActorComponent = this.HeadStateData.ActorComponent as CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.HalfHeight > this.HeadStateData.CommonParam.OutMonsterHalfHeight)
			{
				this.NeedCorrectionOutside = true;
			}
		}

		// Token: 0x0603E1CD RID: 254413 RVA: 0x00FDA87C File Offset: 0x00FD8A7C
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
					float num = this.CurrentBarPercent - item;
					float hitLargePercent = this.HitLargePercent;
				}
				this.PlayBarAnimation(item);
				return;
			}
			this.StopBarLerpAnimation();
		}

		// Token: 0x0603E1CE RID: 254414 RVA: 0x00FDA8D4 File Offset: 0x00FD8AD4
		protected override void OnBeginBarAnimation(float hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E1CF RID: 254415 RVA: 0x00FDA8DD File Offset: 0x00FD8ADD
		protected override void StopBarLerpAnimation()
		{
			base.StopBarLerpAnimation();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E1D0 RID: 254416 RVA: 0x00FDA8F2 File Offset: 0x00FD8AF2
		protected override void OnLerpBarBufferPercent(float percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E1D1 RID: 254417 RVA: 0x00FDA8FB File Offset: 0x00FD8AFB
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(0).SetFillAmount(percent);
		}

		// Token: 0x0603E1D2 RID: 254418 RVA: 0x00FDA90C File Offset: 0x00FD8B0C
		private void SetBarBufferPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetFillAmount(percent);
			sprite.SetUIActive(true);
			UUISprite sprite2 = base.GetSprite(2);
			sprite2.SetStretchLeft(this.HpParentWidth * this.CurrentBarPercent - 2f);
			sprite2.SetStretchRight(this.HpParentWidth * (1f - percent) - 2f);
		}

		// Token: 0x0603E1D3 RID: 254419 RVA: 0x00FDA968 File Offset: 0x00FD8B68
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

		// Token: 0x0603E1D4 RID: 254420 RVA: 0x00FDA99C File Offset: 0x00FD8B9C
		protected override void BindCallback()
		{
			base.BindCallback();
			if (this.HeadStateData == null)
			{
				return;
			}
			MonsterNpcAttackHeadStateData monsterNpcAttackHeadStateData = (MonsterNpcAttackHeadStateData)this.HeadStateData;
			monsterNpcAttackHeadStateData.BindOnSpecialEnergy4Changed(new Action<EAttributeType, float, float>(this.OnSpecialEnergy4Changed));
			monsterNpcAttackHeadStateData.BindOnSlowChargeStateChanged(new Action<int, bool>(this.OnSlowChargeStateChanged));
			monsterNpcAttackHeadStateData.BindOnFastChargeStateChanged(new Action<int, bool>(this.OnFastChargeStateChanged));
			monsterNpcAttackHeadStateData.BindOnAttackReadyStateChanged(new Action<int, bool>(this.OnAttackReadyStateChanged));
			monsterNpcAttackHeadStateData.BindOnAttackBeginStateChanged(new Action<int, bool>(this.OnAttackBeginStateChanged));
			monsterNpcAttackHeadStateData.BindOnAttackEndStateChanged(new Action<int, bool>(this.OnAttackEndStateChanged));
			monsterNpcAttackHeadStateData.BindOnAttackBrokenStateChanged(new Action<int, bool>(this.OnAttackBrokenStateChanged));
		}

		// Token: 0x0603E1D5 RID: 254421 RVA: 0x00FDAA40 File Offset: 0x00FD8C40
		protected override void OnShieldChanged(float shield)
		{
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E1D6 RID: 254422 RVA: 0x00FDAA49 File Offset: 0x00FD8C49
		protected override void OnLevelChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E1D7 RID: 254423 RVA: 0x00FDAA51 File Offset: 0x00FD8C51
		protected override void OnRoleLevelChange(int configId, int exp, int level)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E1D8 RID: 254424 RVA: 0x00FDAA59 File Offset: 0x00FD8C59
		protected override void OnChangeTeam()
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E1D9 RID: 254425 RVA: 0x00FDAA61 File Offset: 0x00FD8C61
		protected override void OnHealthChanged()
		{
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E1DA RID: 254426 RVA: 0x00FDAA6A File Offset: 0x00FD8C6A
		private void OnSpecialEnergy4Changed(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshSpecialEnergy4(true);
		}

		// Token: 0x0603E1DB RID: 254427 RVA: 0x00FDAA73 File Offset: 0x00FD8C73
		private void OnSlowChargeStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshSlowChargeState(new bool?(bTagExists));
		}

		// Token: 0x0603E1DC RID: 254428 RVA: 0x00FDAA81 File Offset: 0x00FD8C81
		private void OnFastChargeStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshFastChargeState(new bool?(bTagExists));
		}

		// Token: 0x0603E1DD RID: 254429 RVA: 0x00FDAA8F File Offset: 0x00FD8C8F
		private void OnAttackReadyStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshAttackReadyState(new bool?(bTagExists));
		}

		// Token: 0x0603E1DE RID: 254430 RVA: 0x00FDAA9D File Offset: 0x00FD8C9D
		private void OnAttackBeginStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshAttackBeginState(new bool?(bTagExists));
		}

		// Token: 0x0603E1DF RID: 254431 RVA: 0x00FDAAAB File Offset: 0x00FD8CAB
		private void OnAttackEndStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshAttackEndState(new bool?(bTagExists));
		}

		// Token: 0x0603E1E0 RID: 254432 RVA: 0x00FDAAB9 File Offset: 0x00FD8CB9
		private void OnAttackBrokenStateChanged(int tagId, bool bTagExists)
		{
			this.RefreshAttackBrokenState(new bool?(bTagExists));
		}

		// Token: 0x0603E1E1 RID: 254433 RVA: 0x00FDAAC8 File Offset: 0x00FD8CC8
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

		// Token: 0x0603E1E2 RID: 254434 RVA: 0x00FDAB2B File Offset: 0x00FD8D2B
		protected override void RefreshOnCampChanged()
		{
			this.RefreshLevelText();
			this.RefreshHpColor();
		}

		// Token: 0x0603E1E3 RID: 254435 RVA: 0x00FDAB3C File Offset: 0x00FD8D3C
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

		// Token: 0x0603E1E4 RID: 254436 RVA: 0x00FDAB74 File Offset: 0x00FD8D74
		private void RefreshEnergyBar(float percent)
		{
			if (percent > 0f)
			{
				UUIItem item = base.GetItem(21);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUISliderComponent slider = base.GetSlider(10);
				if (slider != null)
				{
					slider.SetValue(percent, true);
				}
				UUISliderComponent slider2 = base.GetSlider(12);
				if (slider2 != null)
				{
					slider2.SetValue(percent, true);
				}
				if (this.EnergyPercent >= 1f)
				{
					UUINiagara uiNiagara = base.GetUiNiagara(16);
					if (uiNiagara != null)
					{
						uiNiagara.SetUIActive(false);
					}
					UUINiagara uiNiagara2 = base.GetUiNiagara(18);
					if (uiNiagara2 != null)
					{
						uiNiagara2.SetUIActive(false);
					}
					UUINiagara uiNiagara3 = base.GetUiNiagara(17);
					if (uiNiagara3 != null)
					{
						uiNiagara3.SetUIActive(false);
					}
					UUINiagara uiNiagara4 = base.GetUiNiagara(19);
					if (uiNiagara4 == null)
					{
						return;
					}
					uiNiagara4.SetUIActive(false);
				}
				return;
			}
			UUIItem item2 = base.GetItem(21);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x0603E1E5 RID: 254437 RVA: 0x00FDAC38 File Offset: 0x00FD8E38
		private void RefreshSpecialEnergy4(bool lerp)
		{
			float attributeCurrentValueById = this.HeadStateData.GetAttributeCurrentValueById(EAttributeType.SpecialEnergy4);
			float attributeCurrentValueById2 = this.HeadStateData.GetAttributeCurrentValueById(EAttributeType.SpecialEnergy4Max);
			float num = (attributeCurrentValueById2 == 0f) ? 0f : (attributeCurrentValueById / attributeCurrentValueById2);
			if (num == this.EnergyPercent)
			{
				return;
			}
			this.EnergyPercent = num;
			this.AttackMachine.SetTargetPercent(num, lerp ? 200f : 0f);
		}

		// Token: 0x0603E1E6 RID: 254438 RVA: 0x00FDACA0 File Offset: 0x00FD8EA0
		private void RefreshSlowChargeState(bool? isInState = null)
		{
			if (isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.未出手状态_慢充"]))
			{
				if (!this.IsFullEnergy())
				{
					UUINiagara uiNiagara = base.GetUiNiagara(16);
					if (uiNiagara != null)
					{
						uiNiagara.SetUIActive(true);
					}
					UUINiagara uiNiagara2 = base.GetUiNiagara(18);
					if (uiNiagara2 == null)
					{
						return;
					}
					uiNiagara2.SetUIActive(true);
					return;
				}
			}
			else
			{
				UUINiagara uiNiagara3 = base.GetUiNiagara(16);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetUIActive(false);
				}
				UUINiagara uiNiagara4 = base.GetUiNiagara(18);
				if (uiNiagara4 == null)
				{
					return;
				}
				uiNiagara4.SetUIActive(false);
			}
		}

		// Token: 0x0603E1E7 RID: 254439 RVA: 0x00FDAD34 File Offset: 0x00FD8F34
		private void RefreshFastChargeState(bool? isInState = null)
		{
			if (isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.未出手状态_快充"]))
			{
				if (!this.IsFullEnergy())
				{
					UUINiagara uiNiagara = base.GetUiNiagara(17);
					if (uiNiagara != null)
					{
						uiNiagara.SetUIActive(true);
					}
					UUINiagara uiNiagara2 = base.GetUiNiagara(19);
					if (uiNiagara2 == null)
					{
						return;
					}
					uiNiagara2.SetUIActive(true);
					return;
				}
			}
			else
			{
				UUINiagara uiNiagara3 = base.GetUiNiagara(17);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetUIActive(false);
				}
				UUINiagara uiNiagara4 = base.GetUiNiagara(19);
				if (uiNiagara4 == null)
				{
					return;
				}
				uiNiagara4.SetUIActive(false);
			}
		}

		// Token: 0x0603E1E8 RID: 254440 RVA: 0x00FDADC8 File Offset: 0x00FD8FC8
		private void RefreshAttackReadyState(bool? isInState = null)
		{
			bool flag = isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.准备状态"]);
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				this.PlayTweenAnim(25);
				return;
			}
			this.StopTweenAnim(25);
			this.PlayTweenAnim(26);
		}

		// Token: 0x0603E1E9 RID: 254441 RVA: 0x00FDAE34 File Offset: 0x00FD9034
		private void RefreshAttackBeginState(bool? isInState = null)
		{
			if (isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态"]))
			{
				this.PlayTweenAnim(22);
				return;
			}
			this.StopTweenAnim(22);
		}

		// Token: 0x0603E1EA RID: 254442 RVA: 0x00FDAE84 File Offset: 0x00FD9084
		private void RefreshAttackEndState(bool? isInState = null)
		{
			if (isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态退出_弱"]))
			{
				this.PlayTweenAnim(23);
				return;
			}
			this.StopTweenAnim(23);
		}

		// Token: 0x0603E1EB RID: 254443 RVA: 0x00FDAED4 File Offset: 0x00FD90D4
		private void RefreshAttackBrokenState(bool? isInState = null)
		{
			if (isInState ?? this.HeadStateData.ContainsTagById(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态退出_强"]))
			{
				this.PlayTweenAnim(24);
				return;
			}
			this.StopTweenAnim(24);
		}

		// Token: 0x0603E1EC RID: 254444 RVA: 0x00FDAF22 File Offset: 0x00FD9122
		private bool IsFullEnergy()
		{
			return this.EnergyPercent >= 1f;
		}

		// Token: 0x0603E1ED RID: 254445 RVA: 0x00FDAF34 File Offset: 0x00FD9134
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(22);
			this.InitTweenAnim(23);
			this.InitTweenAnim(24);
			this.InitTweenAnim(25);
			this.InitTweenAnim(26);
		}

		// Token: 0x0603E1EE RID: 254446 RVA: 0x00FDAF60 File Offset: 0x00FD9160
		private void InitTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
			foreach (UActorComponent uactorComponent in base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass()))
			{
				list.Add((ULGUIPlayTweenComponent)uactorComponent);
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603E1EF RID: 254447 RVA: 0x00FDAFDC File Offset: 0x00FD91DC
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

		// Token: 0x0603E1F0 RID: 254448 RVA: 0x00FDB038 File Offset: 0x00FD9238
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

		// Token: 0x04022D1B RID: 142619
		private const float SCALE_TOLERATION = 0.003f;

		// Token: 0x04022D1C RID: 142620
		private const float LERP_ANIM_TIME = 200f;

		// Token: 0x04022D1D RID: 142621
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022D1E RID: 142622
		private readonly BuffItemContainer BuffItemContainer = new BuffItemContainer();

		// Token: 0x04022D1F RID: 142623
		private readonly MonsterNpcAttackMachine AttackMachine = new MonsterNpcAttackMachine();

		// Token: 0x04022D20 RID: 142624
		private float HitLargePercent;

		// Token: 0x04022D21 RID: 142625
		private float HpParentWidth;

		// Token: 0x04022D22 RID: 142626
		private float EnergyPercent;

		// Token: 0x04022D23 RID: 142627
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C0E6 RID: 49382
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B674 RID: 243316
			NormalHpBarSprite,
			// Token: 0x0403B675 RID: 243317
			BarBufferSprite,
			// Token: 0x0403B676 RID: 243318
			HpLight,
			// Token: 0x0403B677 RID: 243319
			ShieldBarSprite,
			// Token: 0x0403B678 RID: 243320
			LevelText,
			// Token: 0x0403B679 RID: 243321
			DetailItem,
			// Token: 0x0403B67A RID: 243322
			HpItem,
			// Token: 0x0403B67B RID: 243323
			HpBarItem,
			// Token: 0x0403B67C RID: 243324
			BuffHorizontalItem,
			// Token: 0x0403B67D RID: 243325
			EnergyItem,
			// Token: 0x0403B67E RID: 243326
			EnergySliderLeft,
			// Token: 0x0403B67F RID: 243327
			EnergyFullSpriteLeft,
			// Token: 0x0403B680 RID: 243328
			EnergySliderRight,
			// Token: 0x0403B681 RID: 243329
			EnergyFullSpriteRight,
			// Token: 0x0403B682 RID: 243330
			EnergyCenterPoint,
			// Token: 0x0403B683 RID: 243331
			BrokenItem,
			// Token: 0x0403B684 RID: 243332
			SlowChargeLeft,
			// Token: 0x0403B685 RID: 243333
			FastChargeLeft,
			// Token: 0x0403B686 RID: 243334
			SlowChargeRight,
			// Token: 0x0403B687 RID: 243335
			FastChargeRight,
			// Token: 0x0403B688 RID: 243336
			EnergyFullItem,
			// Token: 0x0403B689 RID: 243337
			EnergyBarItem,
			// Token: 0x0403B68A RID: 243338
			AnimWarningStart,
			// Token: 0x0403B68B RID: 243339
			AnimWarningClose,
			// Token: 0x0403B68C RID: 243340
			AnimWarningBreak,
			// Token: 0x0403B68D RID: 243341
			AnimWarningReady,
			// Token: 0x0403B68E RID: 243342
			AnimWarningReadyClose
		}
	}
}
