using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006092 RID: 24722
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleStateView : BattleVisibleChildView
	{
		// Token: 0x0603E61C RID: 255516 RVA: 0x00FEE978 File Offset: 0x00FECB78
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E61D RID: 255517 RVA: 0x00FEEAEC File Offset: 0x00FECCEC
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.Ignore);
			this.BufferAnimLengthInternal = ConfigCommonParamById.GetIntConfig("PlayerHPAttenuateBufferSpeed").Value;
			this.HpMask = (base.GetItem(8).GetOwner().GetComponentByClass(ULGUICanvas.StaticClass()) as ULGUICanvas);
			this.HpTextWidth = base.GetText(1).GetWidth();
			this.ShieldSequence = new LevelSequencePlayer(base.GetSprite(5));
			this.AddEvents();
		}

		// Token: 0x0603E61E RID: 255518 RVA: 0x00FEEB70 File Offset: 0x00FECD70
		protected override void OnBeforeDestroy()
		{
			this.Refresh(null);
			if (this.MotorcycleShieldItem != null)
			{
				this.MotorcycleShieldItem.ExistShieldChanged = null;
				this.MotorcycleShieldItem.Destroy(null);
				this.MotorcycleShieldItem = null;
			}
		}

		// Token: 0x0603E61F RID: 255519 RVA: 0x00FEEBA0 File Offset: 0x00FECDA0
		public override void Reset()
		{
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603E620 RID: 255520 RVA: 0x00FEEBB0 File Offset: 0x00FECDB0
		public void Refresh(BattleUiRoleData roleData)
		{
			if (roleData == null)
			{
				this.RoleData = null;
				this.EntityId = null;
				this.AttributeComponent = null;
				this.ShieldComponent = null;
				this.DeactivateRoleState();
				return;
			}
			this.RoleData = roleData;
			EntityHandle entityHandle = roleData.EntityHandle;
			this.EntityId = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			this.AttributeComponent = roleData.AttributeComponent;
			EntityHandle entityHandle2 = roleData.EntityHandle;
			CharacterShieldComponent shieldComponent;
			if (entityHandle2 == null)
			{
				shieldComponent = null;
			}
			else
			{
				WorldEntity entity = entityHandle2.Entity;
				shieldComponent = ((entity != null) ? entity.GetComponent<CharacterShieldComponent>() : null);
			}
			this.ShieldComponent = shieldComponent;
			this.RefreshRoleState();
		}

		// Token: 0x0603E621 RID: 255521 RVA: 0x00FEEC4A File Offset: 0x00FECE4A
		public bool IsValid()
		{
			BattleUiRoleData roleData = this.RoleData;
			return ((roleData != null) ? roleData.EntityHandle : null) != null;
		}

		// Token: 0x0603E622 RID: 255522 RVA: 0x00FEEC61 File Offset: 0x00FECE61
		public int? GetEntityId()
		{
			return this.EntityId;
		}

		// Token: 0x0603E623 RID: 255523 RVA: 0x00FEEC6C File Offset: 0x00FECE6C
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiHealthChanged, new Action<int>(this.OnHealthChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiShieldChanged, new Action<int>(this.OnShieldChanged));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiLevelChanged, new Action<int>(this.OnLevelChanged));
			Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
		}

		// Token: 0x0603E624 RID: 255524 RVA: 0x00FEED08 File Offset: 0x00FECF08
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiHealthChanged, new Action<int>(this.OnHealthChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiShieldChanged, new Action<int>(this.OnShieldChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiLevelChanged, new Action<int>(this.OnLevelChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnRefreshText));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
		}

		// Token: 0x0603E625 RID: 255525 RVA: 0x00FEEDA1 File Offset: 0x00FECFA1
		public void Tick(float delta)
		{
			this.LerpBarPercent(delta);
			MotorcycleShieldItem motorcycleShieldItem = this.MotorcycleShieldItem;
			if (motorcycleShieldItem == null)
			{
				return;
			}
			motorcycleShieldItem.Tick(delta);
		}

		// Token: 0x0603E626 RID: 255526 RVA: 0x00FEEDBB File Offset: 0x00FECFBB
		private void DeactivateRoleState()
		{
			if (TimerSystem.Instance.Has(this.DelayTimerId))
			{
				TimerSystem.Instance.Remove(this.DelayTimerId);
			}
			this.StopBarLerpAnimation();
			this.DelayTimerId = null;
			base.SetVisible(1, false);
		}

		// Token: 0x0603E627 RID: 255527 RVA: 0x00FEEDF8 File Offset: 0x00FECFF8
		private void LerpBarPercent(float delta)
		{
			if (this.AnimTime == -1f)
			{
				return;
			}
			if (this.AnimTime >= (float)this.BufferAnimLengthInternal)
			{
				this.StopBarLerpAnimation();
			}
			if (this.TargetBarPercent >= this.SourceBarPercent)
			{
				return;
			}
			float alpha = this.AnimTime / (float)this.BufferAnimLengthInternal;
			float barBufferPercent = Singleton<MathUtils>.Instance.Lerp(this.SourceBarPercent, this.TargetBarPercent, alpha);
			this.SetBarBufferPercent(barBufferPercent);
			this.AnimTime += delta;
		}

		// Token: 0x0603E628 RID: 255528 RVA: 0x00FEEE74 File Offset: 0x00FED074
		public void SetNiagaraActive(bool bActive)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			uiNiagara.SetUIActive(bActive);
			if (bActive)
			{
				uiNiagara.SetNiagaraVarFloat("Dissolve", this.CurrentBarPercent);
				uiNiagara.ActivateSystem(true);
				return;
			}
			uiNiagara.DeactivateSystem();
		}

		// Token: 0x0603E629 RID: 255529 RVA: 0x00FEEEB2 File Offset: 0x00FED0B2
		public void RefreshRoleState()
		{
			if (!this.IsValid())
			{
				return;
			}
			this.StopBarLerpAnimation();
			this.RefreshHpAndShield(false);
			this.RefreshLevel();
			this.RefreshMotorcycleShield();
			base.SetVisible(1, true);
		}

		// Token: 0x0603E62A RID: 255530 RVA: 0x00FEEEE0 File Offset: 0x00FED0E0
		private void OnShieldChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E62B RID: 255531 RVA: 0x00FEEF10 File Offset: 0x00FED110
		private void OnHealthChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshHpAndShield(true);
			this.SetNiagaraActive(true);
		}

		// Token: 0x0603E62C RID: 255532 RVA: 0x00FEEF48 File Offset: 0x00FED148
		private void OnLevelChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshLevel();
		}

		// Token: 0x0603E62D RID: 255533 RVA: 0x00FEEF77 File Offset: 0x00FED177
		[NullableContext(1)]
		private void OnRefreshText(string s, string s1)
		{
			this.RefreshLevel();
			this.RefreshHpAndShield(false);
		}

		// Token: 0x0603E62E RID: 255534 RVA: 0x00FEEF86 File Offset: 0x00FED186
		private void OnMotorcycleStateChanged(bool b)
		{
			this.RefreshMotorcycleShield();
		}

		// Token: 0x0603E62F RID: 255535 RVA: 0x00FEEF90 File Offset: 0x00FED190
		public void RefreshHpAndShield(bool bPlayBarAnimation = false)
		{
			if (!this.IsValid())
			{
				return;
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			float currentValue = attributeComponent.GetCurrentValue(EAttributeType.Life);
			float currentValue2 = attributeComponent.GetCurrentValue(EAttributeType.LifeMax);
			float shieldTotal = this.ShieldComponent.ShieldTotal;
			float num = currentValue / currentValue2;
			float shieldBarPercent = Math.Min(shieldTotal / currentValue2, 1f);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)currentValue));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)currentValue2));
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			this.UeMargin.Right = -(1f - num) * this.HpTextWidth;
			this.HpMask.SetRectClipOffset(this.UeMargin);
			base.GetText(1).SetText(newText, true);
			base.GetText(7).SetText(newText, true);
			this.SetHpBarPercent(num);
			this.SetShieldBarPercent(shieldBarPercent);
			if (bPlayBarAnimation)
			{
				this.PlayBarAnimation();
			}
			else
			{
				this.StopBarLerpAnimation();
			}
			this.CurrentBarPercent = num;
		}

		// Token: 0x0603E630 RID: 255536 RVA: 0x00FEF088 File Offset: 0x00FED288
		private void PlayBarAnimation()
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			float currentValue = attributeComponent.GetCurrentValue(EAttributeType.Life);
			float currentValue2 = attributeComponent.GetCurrentValue(EAttributeType.LifeMax);
			float num = currentValue / currentValue2;
			float currentBarPercent = this.CurrentBarPercent;
			if (num >= currentBarPercent)
			{
				return;
			}
			this.TargetBarPercent = num;
			this.SourceBarPercent = currentBarPercent;
			this.AnimTime = 0f;
		}

		// Token: 0x0603E631 RID: 255537 RVA: 0x00FEF0DC File Offset: 0x00FED2DC
		private void SetBarBufferPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(4);
			sprite.SetFillAmount(percent);
			sprite.SetUIActive(true);
		}

		// Token: 0x0603E632 RID: 255538 RVA: 0x00FEF0F2 File Offset: 0x00FED2F2
		private void StopBarLerpAnimation()
		{
			base.GetSprite(4).SetUIActive(false);
			this.TargetBarPercent = 0f;
			this.SourceBarPercent = 0f;
			this.AnimTime = -1f;
		}

		// Token: 0x0603E633 RID: 255539 RVA: 0x00FEF124 File Offset: 0x00FED324
		private void SetHpBarPercent(float percent)
		{
			this.RefreshHpSpriteVisible(percent);
			UUISprite sprite = base.GetSprite(3);
			UUISprite sprite2 = base.GetSprite(0);
			if (sprite.bIsUIActive)
			{
				sprite.SetFillAmount(percent);
			}
			if (sprite2.bIsUIActive)
			{
				sprite2.SetFillAmount(percent);
			}
		}

		// Token: 0x0603E634 RID: 255540 RVA: 0x00FEF168 File Offset: 0x00FED368
		private void RefreshHpSpriteVisible(float percent)
		{
			UUISprite sprite = base.GetSprite(3);
			UUISprite sprite2 = base.GetSprite(0);
			if (percent <= 0.2f)
			{
				sprite.SetUIActive(true);
				sprite2.SetUIActive(false);
				return;
			}
			sprite.SetUIActive(false);
			sprite2.SetUIActive(true);
		}

		// Token: 0x0603E635 RID: 255541 RVA: 0x00FEF1AC File Offset: 0x00FED3AC
		private void SetShieldBarPercent(float percent)
		{
			this.ShieldPercent = percent;
			UUISprite sprite = base.GetSprite(5);
			MotorcycleShieldItem motorcycleShieldItem = this.MotorcycleShieldItem;
			bool flag = (motorcycleShieldItem == null || !motorcycleShieldItem.ExistShield) && percent > 0f;
			sprite.SetUIActive(flag);
			if (this.ShieldLastState != flag)
			{
				this.ShieldLastState = flag;
				if (flag)
				{
					this.ShieldSequence.PlayLevelSequenceByName("Start", false, null, false);
				}
			}
			if (flag)
			{
				sprite.SetFillAmount(percent);
			}
		}

		// Token: 0x0603E636 RID: 255542 RVA: 0x00FEF228 File Offset: 0x00FED428
		private void RefreshLevel()
		{
			if (!this.IsValid())
			{
				return;
			}
			UUIText text = base.GetText(2);
			RoleInfo? roleConfig = this.RoleData.RoleConfig;
			if (((roleConfig != null) ? new int?(roleConfig.GetValueOrDefault().RoleType) : null).Value == 2)
			{
				text.SetText(string.Empty, true);
				return;
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				text.SetText(string.Empty, true);
				return;
			}
			int num = (int)attributeComponent.GetCurrentValue(EAttributeType.Lv);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "LevelShowNew", new <>z__ReadOnlySingleElementList<object>(num));
		}

		// Token: 0x0603E637 RID: 255543 RVA: 0x00FEF2D0 File Offset: 0x00FED4D0
		private void RefreshMotorcycleShield()
		{
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				if (this.MotorcycleShieldItem == null)
				{
					this.MotorcycleShieldItem = new MotorcycleShieldItem();
					this.MotorcycleShieldItem.ExistShieldChanged = new Action(this.ExistShieldChanged);
					this.MotorcycleShieldItem.CreateThenShowByResourceIdAsync("UiItem_MotorcycleShieldBar", base.GetRootItem(), false);
					return;
				}
			}
			else if (this.MotorcycleShieldItem != null)
			{
				this.MotorcycleShieldItem.ExistShieldChanged = null;
				this.MotorcycleShieldItem.Destroy(null);
				this.MotorcycleShieldItem = null;
				this.ExistShieldChanged();
			}
		}

		// Token: 0x0603E638 RID: 255544 RVA: 0x00FEF35E File Offset: 0x00FED55E
		private void ExistShieldChanged()
		{
			this.SetShieldBarPercent(this.ShieldPercent);
		}

		// Token: 0x04022F54 RID: 143188
		private const float LOW_HP_PERCENT = 0.2f;

		// Token: 0x04022F55 RID: 143189
		private BattleUiRoleData RoleData;

		// Token: 0x04022F56 RID: 143190
		private int? EntityId;

		// Token: 0x04022F57 RID: 143191
		private BaseAttributeComponent AttributeComponent;

		// Token: 0x04022F58 RID: 143192
		private CharacterShieldComponent ShieldComponent;

		// Token: 0x04022F59 RID: 143193
		private TimerHandle DelayTimerId;

		// Token: 0x04022F5A RID: 143194
		private float CurrentBarPercent = -1f;

		// Token: 0x04022F5B RID: 143195
		private float TargetBarPercent;

		// Token: 0x04022F5C RID: 143196
		private float SourceBarPercent;

		// Token: 0x04022F5D RID: 143197
		private float AnimTime = -1f;

		// Token: 0x04022F5E RID: 143198
		private int BufferAnimLengthInternal;

		// Token: 0x04022F5F RID: 143199
		private ULGUICanvas HpMask;

		// Token: 0x04022F60 RID: 143200
		private FMargin UeMargin;

		// Token: 0x04022F61 RID: 143201
		private float HpTextWidth;

		// Token: 0x04022F62 RID: 143202
		private LevelSequencePlayer ShieldSequence;

		// Token: 0x04022F63 RID: 143203
		private bool ShieldLastState;

		// Token: 0x04022F64 RID: 143204
		private float ShieldPercent;

		// Token: 0x04022F65 RID: 143205
		private MotorcycleShieldItem MotorcycleShieldItem;

		// Token: 0x0200C182 RID: 49538
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B968 RID: 244072
			RoleHpBar,
			// Token: 0x0403B969 RID: 244073
			RoleHpNumber,
			// Token: 0x0403B96A RID: 244074
			RoleLvNumber,
			// Token: 0x0403B96B RID: 244075
			HpLowBarSprite,
			// Token: 0x0403B96C RID: 244076
			HpBufferSprite,
			// Token: 0x0403B96D RID: 244077
			ShieldFrameSprite,
			// Token: 0x0403B96E RID: 244078
			Niagara,
			// Token: 0x0403B96F RID: 244079
			RoleHpNumber2,
			// Token: 0x0403B970 RID: 244080
			RoleHpMask,
			// Token: 0x0403B971 RID: 244081
			HpAdjustNode,
			// Token: 0x0403B972 RID: 244082
			HpLockSprite,
			// Token: 0x0403B973 RID: 244083
			HpAdditionNode
		}
	}
}
