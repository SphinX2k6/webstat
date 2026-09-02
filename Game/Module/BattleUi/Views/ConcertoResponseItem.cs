using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006000 RID: 24576
	[NullableContext(2)]
	[Nullable(0)]
	public class ConcertoResponseItem : BattleVisibleChildView
	{
		// Token: 0x0603DE39 RID: 253497 RVA: 0x00FC8D7C File Offset: 0x00FC6F7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE3A RID: 253498 RVA: 0x00FC8DE5 File Offset: 0x00FC6FE5
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.Ignore);
			this.AddEvents();
		}

		// Token: 0x0603DE3B RID: 253499 RVA: 0x00FC8DFC File Offset: 0x00FC6FFC
		protected override void OnBeforeDestroy()
		{
			this.Refresh(null);
		}

		// Token: 0x0603DE3C RID: 253500 RVA: 0x00FC8E05 File Offset: 0x00FC7005
		public override void Reset()
		{
			this.RemoveEvents();
			if (this.ExtraEffectComponent != null)
			{
				this.ExtraEffectComponent.Stop();
				this.ExtraEffectComponent.Destroy(null);
				this.ExtraEffectComponent = null;
			}
			base.Reset();
		}

		// Token: 0x0603DE3D RID: 253501 RVA: 0x00FC8E3C File Offset: 0x00FC703C
		public void Refresh(BattleUiRoleData roleData)
		{
			if (roleData == null || (roleData.RoleConfig != null && roleData.RoleConfig.GetValueOrDefault().RoleType == 2))
			{
				this.RoleData = null;
				this.EntityId = null;
				this.GameplayTagComponent = null;
				this.ElementType = null;
				this.ElementConfig = null;
				base.SetVisible(1, false);
				return;
			}
			this.RoleData = roleData;
			EntityHandle entityHandle = roleData.EntityHandle;
			this.EntityId = ((entityHandle != null) ? new int?(entityHandle.Id) : null);
			this.GameplayTagComponent = this.RoleData.GameplayTagComponent;
			this.ElementConfig = this.RoleData.ElementConfig;
			if (this.HandleId != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
				this.HandleId = 0;
			}
			this.SetElementStyle(this.RoleData.ElementType.Value);
			this.UpdateElementBar();
			this.RefreshVisible();
		}

		// Token: 0x0603DE3E RID: 253502 RVA: 0x00FC8F3A File Offset: 0x00FC713A
		public int? GetEntityId()
		{
			return this.EntityId;
		}

		// Token: 0x0603DE3F RID: 253503 RVA: 0x00FC8F44 File Offset: 0x00FC7144
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.BattleUiElementEnergyChanged, new Action<int>(this.OnElementEnergyChanged));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.BattleUiElementHideTagChanged, new Action<int, int, bool>(this.OnHideTagChanged));
			Singleton<EventSystem>.Instance.Add<ESkillButtonExtraEffect, float>(EEventName.BattleUiConcertoExtraEffectRefresh, new Action<ESkillButtonExtraEffect, float>(this.OnExtraEffectRefresh));
		}

		// Token: 0x0603DE40 RID: 253504 RVA: 0x00FC8FA8 File Offset: 0x00FC71A8
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiElementEnergyChanged, new Action<int>(this.OnElementEnergyChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiElementHideTagChanged, new Action<int, int, bool>(this.OnHideTagChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiConcertoExtraEffectRefresh, new Action<ESkillButtonExtraEffect, float>(this.OnExtraEffectRefresh));
		}

		// Token: 0x0603DE41 RID: 253505 RVA: 0x00FC900C File Offset: 0x00FC720C
		private void OnElementEnergyChanged(int entityId)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.UpdateElementBar();
		}

		// Token: 0x0603DE42 RID: 253506 RVA: 0x00FC903C File Offset: 0x00FC723C
		private void OnHideTagChanged(int entityId, int tagId, bool tagExist)
		{
			int? entityId2 = this.EntityId;
			if (!(entityId == entityId2.GetValueOrDefault() & entityId2 != null))
			{
				return;
			}
			this.RefreshVisible();
		}

		// Token: 0x0603DE43 RID: 253507 RVA: 0x00FC906C File Offset: 0x00FC726C
		public void RefreshVisible()
		{
			if (this.RoleData == null)
			{
				return;
			}
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10036))
			{
				base.SetVisible(1, false);
				return;
			}
			foreach (int tagId in BattleUiRoleData.HideElementTagList)
			{
				if (this.GameplayTagComponent.HasTag(tagId))
				{
					base.SetVisible(1, false);
					return;
				}
			}
			base.SetVisible(1, true);
		}

		// Token: 0x0603DE44 RID: 253508 RVA: 0x00FC90D3 File Offset: 0x00FC72D3
		private void OnExtraEffectRefresh(ESkillButtonExtraEffect effectType, float duration)
		{
			this.RefreshExtraEffect(effectType, duration);
		}

		// Token: 0x0603DE45 RID: 253509 RVA: 0x00FC90E0 File Offset: 0x00FC72E0
		public void RefreshExtraEffect(ESkillButtonExtraEffect effectType, float duration)
		{
			if (effectType == ESkillButtonExtraEffect.None)
			{
				if (this.ExtraEffectComponent != null)
				{
					this.ExtraEffectComponent.SetComponentActive(false);
				}
				return;
			}
			if (this.ExtraEffectComponent != null)
			{
				if (this.ExtraEffectComponent.GetEffectType() == this.EffectType)
				{
					this.ExtraEffectComponent.SetComponentActive(true);
					this.ExtraEffectComponent.Refresh(duration);
					return;
				}
				this.ExtraEffectComponent.Destroy(null);
				this.ExtraEffectComponent = null;
			}
			this.EffectType = effectType;
			if (effectType == ESkillButtonExtraEffect.Rhythm)
			{
				this.ExtraEffectComponent = new BattleSkillExtraEffectRhythmItem();
				this.ExtraEffectComponent.Init(this.RootItem);
				this.ExtraEffectComponent.SetComponentActive(true);
				this.ExtraEffectComponent.Refresh(duration);
			}
			BattleSkillExtraEffectItem extraEffectComponent = this.ExtraEffectComponent;
			if (extraEffectComponent == null)
			{
				return;
			}
			extraEffectComponent.SetEffectType(effectType);
		}

		// Token: 0x0603DE46 RID: 253510 RVA: 0x00FC919C File Offset: 0x00FC739C
		private void SetElementStyle(EElementType elementType)
		{
			EElementType? elementType2 = this.ElementType;
			if (elementType2.GetValueOrDefault() == elementType & elementType2 != null)
			{
				return;
			}
			string icon = this.ElementConfig.Value.Icon5;
			UUITexture texture = base.GetTexture(1);
			UUIItem sprite = base.GetSprite(0);
			base.SetElementIcon(icon, texture, (int)elementType, null);
			texture.SetColor(this.RoleData.ElementColor.Value);
			sprite.SetColor(this.RoleData.ElementColor.Value);
			this.ElementType = new EElementType?(elementType);
		}

		// Token: 0x0603DE47 RID: 253511 RVA: 0x00FC9235 File Offset: 0x00FC7435
		private void UpdateElementBar()
		{
			base.GetSprite(0).SetFillAmount(this.GetElementPercent());
		}

		// Token: 0x0603DE48 RID: 253512 RVA: 0x00FC9249 File Offset: 0x00FC7449
		public float GetElementPercent()
		{
			if (this.RoleData == null)
			{
				return 0f;
			}
			return this.RoleData.GetElementAttributePercent();
		}

		// Token: 0x04022B62 RID: 142178
		private BattleUiRoleData RoleData;

		// Token: 0x04022B63 RID: 142179
		private int? EntityId;

		// Token: 0x04022B64 RID: 142180
		private BaseTagComponent GameplayTagComponent;

		// Token: 0x04022B65 RID: 142181
		private ElementInfo? ElementConfig;

		// Token: 0x04022B66 RID: 142182
		private EElementType? ElementType;

		// Token: 0x04022B67 RID: 142183
		private int HandleId;

		// Token: 0x04022B68 RID: 142184
		private BattleSkillExtraEffectItem ExtraEffectComponent;

		// Token: 0x04022B69 RID: 142185
		private ESkillButtonExtraEffect EffectType;

		// Token: 0x0200C08A RID: 49290
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B486 RID: 242822
			ResponseBarSprite,
			// Token: 0x0403B487 RID: 242823
			ElementTexture
		}
	}
}
