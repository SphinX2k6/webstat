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
	// Token: 0x02006026 RID: 24614
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonHeadState : HeadStateViewBase
	{
		// Token: 0x0603E08D RID: 254093 RVA: 0x00FD535C File Offset: 0x00FD355C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E08E RID: 254094 RVA: 0x00FD5558 File Offset: 0x00FD3758
		protected override UniTask OnBeforeStartAsync()
		{
			CommonHeadState.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonHeadState.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E08F RID: 254095 RVA: 0x00FD559B File Offset: 0x00FD379B
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			this.RefreshHpAndShield(false);
			this.RefreshLevelText();
			this.RefreshHeadStateDetail();
			this.RefreshLevelTextVisible();
			this.RefreshBuffVisible();
			this.RefreshBuff();
			this.RefreshHpColor();
			this.RefreshWeaknessItem(true);
		}

		// Token: 0x0603E090 RID: 254096 RVA: 0x00FD55D6 File Offset: 0x00FD37D6
		protected override void OnStart()
		{
			this.InitAllTweenAnim();
			this.HpParentWidth = base.GetSprite(2).GetParentAsUIItem().GetWidth();
			this.BuffItemContainer.Init(base.GetItem(5), 6, true, false, false, null);
		}

		// Token: 0x0603E091 RID: 254097 RVA: 0x00FD560C File Offset: 0x00FD380C
		protected override void OnBeforeDestroy()
		{
			if (this.WeaknessItem != null)
			{
				this.WeaknessItem.Destroy(null);
				this.WeaknessItem = null;
			}
		}

		// Token: 0x0603E092 RID: 254098 RVA: 0x00FD562C File Offset: 0x00FD382C
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			UUIItem item = base.GetItem(7);
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

		// Token: 0x0603E093 RID: 254099 RVA: 0x00FD5676 File Offset: 0x00FD3876
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

		// Token: 0x0603E094 RID: 254100 RVA: 0x00FD569C File Offset: 0x00FD389C
		private void RefreshWeaknessItem(bool isStart = false)
		{
			base.GetUiNiagara(11).SetUIActive(false);
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

		// Token: 0x0603E095 RID: 254101 RVA: 0x00FD5701 File Offset: 0x00FD3901
		private void RefreshHpWeaknessPercent()
		{
			if (this.WeaknessItem != null && this.WeaknessItem.IsFullState(true))
			{
				base.GetSprite(10).SetFillAmount(this.CurrentBarPercent);
			}
		}

		// Token: 0x0603E096 RID: 254102 RVA: 0x00FD572C File Offset: 0x00FD392C
		private void RefreshHpWeaknessState(bool isStart = false)
		{
			if (this.WeaknessItem.IsInBreakAnim())
			{
				base.GetItem(9).SetUIActive(true);
				if (!isStart)
				{
					this.PlayTweenAnim(13);
					return;
				}
			}
			else if (this.WeaknessItem.IsFullState(true))
			{
				base.GetItem(9).SetUIActive(true);
				if (!isStart)
				{
					this.PlayTweenAnim(12);
					return;
				}
			}
			else
			{
				base.GetItem(9).SetUIActive(false);
			}
		}

		// Token: 0x0603E097 RID: 254103 RVA: 0x00FD5796 File Offset: 0x00FD3996
		private void OnWeaknessStateChanged()
		{
			this.RefreshHpWeaknessPercent();
			this.RefreshHpWeaknessState(false);
		}

		// Token: 0x0603E098 RID: 254104 RVA: 0x00FD57A5 File Offset: 0x00FD39A5
		protected override string GetResourceId()
		{
			return "UiItem_LittleMonsterState_Prefab";
		}

		// Token: 0x0603E099 RID: 254105 RVA: 0x00FD57AC File Offset: 0x00FD39AC
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
			if (weaknessItem == null)
			{
				return;
			}
			weaknessItem.Tick(delta);
		}

		// Token: 0x0603E09A RID: 254106 RVA: 0x00FD57EA File Offset: 0x00FD39EA
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

		// Token: 0x0603E09B RID: 254107 RVA: 0x00FD5824 File Offset: 0x00FD3A24
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

		// Token: 0x0603E09C RID: 254108 RVA: 0x00FD5868 File Offset: 0x00FD3A68
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

		// Token: 0x0603E09D RID: 254109 RVA: 0x00FD58A0 File Offset: 0x00FD3AA0
		private void RefreshHeadStateDetail()
		{
			bool flag = base.IsDetailVisible();
			base.GetItem(4).SetUIActive(flag);
			StateExtraItemBase extraItem = this.ExtraItem;
			if (extraItem != null)
			{
				extraItem.SetUiActive(flag);
			}
			this.WeaknessContainer.SetUIActive(flag);
		}

		// Token: 0x0603E09E RID: 254110 RVA: 0x00FD58E0 File Offset: 0x00FD3AE0
		private void RefreshLevelTextVisible()
		{
			bool uiactive = base.IsLevelTextVisible();
			base.GetText(3).SetUIActive(uiactive);
		}

		// Token: 0x0603E09F RID: 254111 RVA: 0x00FD5904 File Offset: 0x00FD3B04
		private void RefreshBuffVisible()
		{
			bool uiactive = base.IsBuffVisible();
			base.GetItem(5).SetUIActive(uiactive);
		}

		// Token: 0x0603E0A0 RID: 254112 RVA: 0x00FD5925 File Offset: 0x00FD3B25
		private void TickBuffItem(float delta)
		{
			if (!base.IsBuffVisible())
			{
				return;
			}
			this.BuffItemContainer.Tick(delta);
		}

		// Token: 0x0603E0A1 RID: 254113 RVA: 0x00FD593C File Offset: 0x00FD3B3C
		public void RefreshHpAndShield(bool bPlayBarAnimation = false)
		{
			ValueTuple<float, float> hpAndShieldPercent = base.GetHpAndShieldPercent();
			float item = hpAndShieldPercent.Item1;
			float item2 = hpAndShieldPercent.Item2;
			this.SetHpBarPercent(item);
			this.SetShieldBarPercent(item2);
			if (bPlayBarAnimation)
			{
				this.PlayBarAnimation(item);
			}
			else
			{
				this.StopBarLerpAnimation();
			}
			this.RefreshHpWeaknessPercent();
		}

		// Token: 0x0603E0A2 RID: 254114 RVA: 0x00FD5982 File Offset: 0x00FD3B82
		protected override void OnBeginBarAnimation(float hpPercent)
		{
			this.SetBarBufferPercent(hpPercent);
		}

		// Token: 0x0603E0A3 RID: 254115 RVA: 0x00FD598B File Offset: 0x00FD3B8B
		protected override void StopBarLerpAnimation()
		{
			base.StopBarLerpAnimation();
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x0603E0A4 RID: 254116 RVA: 0x00FD59A0 File Offset: 0x00FD3BA0
		protected override void OnLerpBarBufferPercent(float percent)
		{
			this.SetBarBufferPercent(percent);
		}

		// Token: 0x0603E0A5 RID: 254117 RVA: 0x00FD59A9 File Offset: 0x00FD3BA9
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(0).SetFillAmount(percent);
		}

		// Token: 0x0603E0A6 RID: 254118 RVA: 0x00FD59B8 File Offset: 0x00FD3BB8
		private void SetBarBufferPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(1);
			sprite.SetFillAmount(percent);
			if (!sprite.IsUIActiveSelf())
			{
				sprite.SetUIActive(true);
			}
			UUISprite sprite2 = base.GetSprite(2);
			sprite2.SetStretchLeft(this.HpParentWidth * this.CurrentBarPercent - 2f);
			sprite2.SetStretchRight(this.HpParentWidth * (1f - percent) - 2f);
		}

		// Token: 0x0603E0A7 RID: 254119 RVA: 0x00FD5A1C File Offset: 0x00FD3C1C
		private void SetShieldBarPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(6);
			if (percent > 0f)
			{
				sprite.SetFillAmount(percent);
				sprite.SetUIActive(true);
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x0603E0A8 RID: 254120 RVA: 0x00FD5A4F File Offset: 0x00FD3C4F
		protected override void OnShieldChanged(float shield)
		{
			this.RefreshHpAndShield(false);
		}

		// Token: 0x0603E0A9 RID: 254121 RVA: 0x00FD5A58 File Offset: 0x00FD3C58
		protected override void OnChangeTeam()
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0AA RID: 254122 RVA: 0x00FD5A60 File Offset: 0x00FD3C60
		protected override void OnLevelChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0AB RID: 254123 RVA: 0x00FD5A68 File Offset: 0x00FD3C68
		protected override void OnRoleLevelChange(int configId, int exp, int level)
		{
			this.RefreshLevelText();
		}

		// Token: 0x0603E0AC RID: 254124 RVA: 0x00FD5A70 File Offset: 0x00FD3C70
		protected override void OnHealthChanged()
		{
			this.RefreshHpAndShield(true);
		}

		// Token: 0x0603E0AD RID: 254125 RVA: 0x00FD5A7C File Offset: 0x00FD3C7C
		private void RefreshLevelText()
		{
			if (this.HeadStateData == null)
			{
				return;
			}
			int level = this.GetLevel();
			UUIText text = base.GetText(3);
			string threadColor = ConfigBase<BattleUiConfig>.Instance.GetThreadColor(level, this.HeadStateData.Camp);
			text.SetColor(FColor.FromHex(threadColor));
			Singleton<LguiUtil>.Instance.SetLocalText(text, "LevelShow", new <>z__ReadOnlySingleElementList<object>(level));
		}

		// Token: 0x0603E0AE RID: 254126 RVA: 0x00FD5ADF File Offset: 0x00FD3CDF
		protected override void RefreshOnCampChanged()
		{
			this.RefreshLevelText();
			this.RefreshHpColor();
		}

		// Token: 0x0603E0AF RID: 254127 RVA: 0x00FD5AED File Offset: 0x00FD3CED
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(12);
			this.InitTweenAnim(13);
		}

		// Token: 0x0603E0B0 RID: 254128 RVA: 0x00FD5B00 File Offset: 0x00FD3D00
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

		// Token: 0x0603E0B1 RID: 254129 RVA: 0x00FD5B80 File Offset: 0x00FD3D80
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

		// Token: 0x04022C83 RID: 142467
		private readonly BuffItemContainer BuffItemContainer = new BuffItemContainer();

		// Token: 0x04022C84 RID: 142468
		private float HpParentWidth;

		// Token: 0x04022C85 RID: 142469
		[Nullable(2)]
		private UUIItem WeaknessContainer;

		// Token: 0x04022C86 RID: 142470
		[Nullable(2)]
		private HeadStateWeaknessItem WeaknessItem;

		// Token: 0x04022C87 RID: 142471
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C0D9 RID: 49369
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B5F6 RID: 243190
			NormalHpBarSprite,
			// Token: 0x0403B5F7 RID: 243191
			BarBufferSprite,
			// Token: 0x0403B5F8 RID: 243192
			HpLight,
			// Token: 0x0403B5F9 RID: 243193
			LevelText,
			// Token: 0x0403B5FA RID: 243194
			DetailItem,
			// Token: 0x0403B5FB RID: 243195
			BuffHorizontalItem,
			// Token: 0x0403B5FC RID: 243196
			ShieldBarSprite,
			// Token: 0x0403B5FD RID: 243197
			ExtraItem,
			// Token: 0x0403B5FE RID: 243198
			WeaknessContainer,
			// Token: 0x0403B5FF RID: 243199
			HpWeaknessNode,
			// Token: 0x0403B600 RID: 243200
			HpWeaknessSprite1,
			// Token: 0x0403B601 RID: 243201
			HpWeaknessEffect,
			// Token: 0x0403B602 RID: 243202
			AniHpWeaknessFull,
			// Token: 0x0403B603 RID: 243203
			AniHpWeaknessBreak
		}
	}
}
