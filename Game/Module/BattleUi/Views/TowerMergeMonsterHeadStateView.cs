using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF4 RID: 24564
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerMergeMonsterHeadStateView : BattleChildView
	{
		// Token: 0x0603DDB9 RID: 253369 RVA: 0x00FC5510 File Offset: 0x00FC3710
		protected unsafe override void OnRegisterComponent()
		{
			int num = 35;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.HitEffectDuration = (float)ConfigCommonParamById.GetIntConfig("HitEffectDuration").Value;
		}

		// Token: 0x0603DDBA RID: 253370 RVA: 0x00FC59F0 File Offset: 0x00FC3BF0
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.InitAllTweenAnim();
			this.HitLargePercent = (float)ConfigCommonParamById.GetIntConfig("HitLargeBufferPercent").Value / 10000f;
			this.VisibleMachine = new VisibleAnimMachine();
			this.VisibleMachine.InitCallback(new Action<bool>(this.OnRealVisibleChanged), new Action<bool>(this.OnPlayVisibleAnim), new Action<bool>(this.OnStopVisibleAnim));
			this.VisibleMachine.InitVisible(false);
			this.HideInvisibleNode();
			FColor color = FColor.FromHex("ED601BFF");
			base.GetText(1).SetColor(color);
			UUIItem item = base.GetItem(13);
			item.SetAnchorOffsetY(-15f);
			item.SetUIActive(false);
		}

		// Token: 0x0603DDBB RID: 253371 RVA: 0x00FC5AB0 File Offset: 0x00FC3CB0
		private void HideInvisibleNode()
		{
			base.GetSprite(10).SetUIActive(false);
			base.GetItem(11).SetUIActive(false);
			UUIItem item = base.GetItem(32);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			base.GetItem(34).SetUIActive(false);
			base.GetItem(35).SetUIActive(false);
		}

		// Token: 0x0603DDBC RID: 253372 RVA: 0x00FC5B09 File Offset: 0x00FC3D09
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.VisibleMachine.Reset();
			this.VisibleMachine = null;
			if (this.HitEffectCountdown >= 0f)
			{
				this.PlayHitEffect(0f);
			}
		}

		// Token: 0x0603DDBD RID: 253373 RVA: 0x00FC5B47 File Offset: 0x00FC3D47
		protected override void OnBeforeShow()
		{
			this.RefreshInner();
			this.VisibleMachine.SetVisible(true, 667f);
			this.PlayHitEffect(0f);
		}

		// Token: 0x0603DDBE RID: 253374 RVA: 0x00FC5B6B File Offset: 0x00FC3D6B
		public void Refresh(TowerMergeHeadStateInfo info)
		{
			this.Info = info;
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (info == null)
			{
				this.StopBarLerpAnimation();
				return;
			}
			this.RefreshInner();
		}

		// Token: 0x0603DDBF RID: 253375 RVA: 0x00FC5B8D File Offset: 0x00FC3D8D
		private void RefreshInner()
		{
			this.RefreshBossLevel();
			this.RefreshBossName();
			this.RefreshHp(false);
		}

		// Token: 0x0603DDC0 RID: 253376 RVA: 0x00FC5BA4 File Offset: 0x00FC3DA4
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.HpParentWidth = base.GetItem(8).GetParentAsUIItem().GetWidth();
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialParameterCollection>("/LGUI/MPC_UIShader.MPC_UIShader", delegate([Nullable(2)] UMaterialParameterCollection collection, string _)
			{
				this.GlobalShaderCollection = collection;
			}, 103, "js_undefined");
		}

		// Token: 0x0603DDC1 RID: 253377 RVA: 0x00FC5BF2 File Offset: 0x00FC3DF2
		public void OnHealthChanged()
		{
			this.RefreshHp(true);
		}

		// Token: 0x0603DDC2 RID: 253378 RVA: 0x00FC5BFB File Offset: 0x00FC3DFB
		public void OnLanguageChange()
		{
			this.RefreshBossName();
		}

		// Token: 0x0603DDC3 RID: 253379 RVA: 0x00FC5C04 File Offset: 0x00FC3E04
		public void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (this.IsPlayingHpBarAnim)
			{
				float num = this.HpStateMachine.UpdatePercent(delta);
				if (num < 0f)
				{
					this.StopBarLerpAnimation();
				}
				else if (num <= 1f)
				{
					this.SetBarBufferPercent(num);
				}
			}
			if (this.HitEffectCountdown > this.HitEffectDuration)
			{
				this.PlayHitEffect(0f);
				this.HitEffectCountdown = -1f;
			}
			if (this.HitEffectCountdown >= 0f)
			{
				this.HitEffectCountdown += delta;
			}
		}

		// Token: 0x0603DDC4 RID: 253380 RVA: 0x00FC5C90 File Offset: 0x00FC3E90
		private void RefreshHp(bool bPlayBarAnimation = false)
		{
			if (this.Info.TotalHpMax <= 0f)
			{
				return;
			}
			float num = this.Info.TotalHp / this.Info.TotalHpMax;
			this.SetHpBarPercent(num);
			if (bPlayBarAnimation)
			{
				this.PlayBarAnimation(num);
			}
			else
			{
				this.StopBarLerpAnimation();
			}
			this.CurrentBarPercent = num;
		}

		// Token: 0x0603DDC5 RID: 253381 RVA: 0x00FC5CE8 File Offset: 0x00FC3EE8
		private void PlayBarAnimation(float hpPercent)
		{
			if (hpPercent < this.CurrentBarPercent)
			{
				bool flag = this.HpStateMachine.IsOriginState();
				this.HpStateMachine.GetHit(hpPercent, this.CurrentBarPercent);
				if (flag && !this.HpStateMachine.IsOriginState())
				{
					this.SetBarBufferPercent(this.CurrentBarPercent);
				}
				this.IsPlayingHpBarAnim = true;
				if (this.CurrentBarPercent - hpPercent < this.HitLargePercent)
				{
					this.PlayTweenAnim(25);
					return;
				}
				this.PlayTweenAnim(26);
				this.HitEffectCountdown = 0f;
				this.PlayHitEffect(1f);
			}
		}

		// Token: 0x0603DDC6 RID: 253382 RVA: 0x00FC5D74 File Offset: 0x00FC3F74
		private void PlayHitEffect(float param)
		{
			if (this.GlobalShaderCollection != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.GlobalShaderCollection, TowerMergeMonsterHeadStateView.RgbSplitProgress, param);
			}
		}

		// Token: 0x0603DDC7 RID: 253383 RVA: 0x00FC5D99 File Offset: 0x00FC3F99
		private void StopBarLerpAnimation()
		{
			base.GetItem(8).SetUIActive(false);
			this.HpStateMachine.Reset();
			this.IsPlayingHpBarAnim = false;
		}

		// Token: 0x0603DDC8 RID: 253384 RVA: 0x00FC5DBA File Offset: 0x00FC3FBA
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(7).SetFillAmount(percent);
		}

		// Token: 0x0603DDC9 RID: 253385 RVA: 0x00FC5DCC File Offset: 0x00FC3FCC
		private void SetBarBufferPercent(float percent)
		{
			float num = this.HpParentWidth * this.CurrentBarPercent;
			float num2 = this.HpParentWidth * percent;
			float num3 = num2 - num;
			float num4 = num2 - (this.HpParentWidth + num3) / 2f;
			UUIItem item = base.GetItem(8);
			item.SetAnchorOffsetX(num4);
			item.SetWidth(num3);
			item.SetUIActive(true);
			base.GetSprite(9).SetAnchorOffsetX(-num4);
		}

		// Token: 0x0603DDCA RID: 253386 RVA: 0x00FC5E2D File Offset: 0x00FC402D
		private void RefreshBossLevel()
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603DDCB RID: 253387 RVA: 0x00FC5E44 File Offset: 0x00FC4044
		private void RefreshBossName()
		{
			UUIText text = base.GetText(1);
			if (this.Info == null)
			{
				text.SetUIActive(false);
				return;
			}
			text.SetUIActive(true);
			NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(this.Info.MainMonsterInfoId);
			string text2 = (waveConfigById != null) ? waveConfigById.GetValueOrDefault().Name : null;
			if (!string.IsNullOrEmpty(text2))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, text2, Array.Empty<object>());
				return;
			}
			text.SetText(string.Empty, true);
		}

		// Token: 0x0603DDCC RID: 253388 RVA: 0x00FC5EC8 File Offset: 0x00FC40C8
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(25);
			this.InitTweenAnim(26);
		}

		// Token: 0x0603DDCD RID: 253389 RVA: 0x00FC5EDC File Offset: 0x00FC40DC
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

		// Token: 0x0603DDCE RID: 253390 RVA: 0x00FC5F5C File Offset: 0x00FC415C
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

		// Token: 0x0603DDCF RID: 253391 RVA: 0x00FC5FB8 File Offset: 0x00FC41B8
		public void HideWithAnim()
		{
			this.VisibleMachine.SetVisible(false, 167f);
		}

		// Token: 0x0603DDD0 RID: 253392 RVA: 0x00FC5FCB File Offset: 0x00FC41CB
		private void OnRealVisibleChanged(bool visible)
		{
			if (!visible)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603DDD1 RID: 253393 RVA: 0x00FC5FD8 File Offset: 0x00FC41D8
		private void OnPlayVisibleAnim(bool visible)
		{
			this.LevelSequencePlayer.PlaySequencePurely(visible ? "ShowView" : "CloseView", false, false, null, null, false);
		}

		// Token: 0x0603DDD2 RID: 253394 RVA: 0x00FC600C File Offset: 0x00FC420C
		private void OnStopVisibleAnim(bool visible)
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x0603DDD3 RID: 253395 RVA: 0x00FC601B File Offset: 0x00FC421B
		[NullableContext(1)]
		public string GetResourceId()
		{
			return "UiItem_BossState_Prefab";
		}

		// Token: 0x04022B17 RID: 142103
		[StaticVariableRuleIgnore]
		private static readonly FName RgbSplitProgress = new FName("RGBSplit_Progress");

		// Token: 0x04022B18 RID: 142104
		private const float SHOW_VIEW_ANIM_TIME = 667f;

		// Token: 0x04022B19 RID: 142105
		private const float CLOSE_VIEW_ANIM_TIME = 167f;

		// Token: 0x04022B1A RID: 142106
		public TowerMergeHeadStateInfo Info;

		// Token: 0x04022B1B RID: 142107
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022B1C RID: 142108
		private VisibleAnimMachine VisibleMachine;

		// Token: 0x04022B1D RID: 142109
		private float HitLargePercent;

		// Token: 0x04022B1E RID: 142110
		private float CurrentBarPercent = 1f;

		// Token: 0x04022B1F RID: 142111
		[Nullable(1)]
		private readonly HpBufferStateMachine HpStateMachine = new HpBufferStateMachine();

		// Token: 0x04022B20 RID: 142112
		private UMaterialParameterCollection GlobalShaderCollection;

		// Token: 0x04022B21 RID: 142113
		private float HitEffectCountdown = -1f;

		// Token: 0x04022B22 RID: 142114
		private float HitEffectDuration;

		// Token: 0x04022B23 RID: 142115
		private float HpParentWidth;

		// Token: 0x04022B24 RID: 142116
		private bool IsPlayingHpBarAnim;

		// Token: 0x04022B25 RID: 142117
		[Nullable(1)]
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C080 RID: 49280
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B425 RID: 242725
			BossLevelText,
			// Token: 0x0403B426 RID: 242726
			BossNameText,
			// Token: 0x0403B427 RID: 242727
			RageItem,
			// Token: 0x0403B428 RID: 242728
			ToughBg,
			// Token: 0x0403B429 RID: 242729
			RageBar,
			// Token: 0x0403B42A RID: 242730
			HpShieldBarItem,
			// Token: 0x0403B42B RID: 242731
			HpBarItem,
			// Token: 0x0403B42C RID: 242732
			NormalHpBarSprite,
			// Token: 0x0403B42D RID: 242733
			BarBufferCanvas,
			// Token: 0x0403B42E RID: 242734
			BarBufferSprite,
			// Token: 0x0403B42F RID: 242735
			ShieldBarSprite,
			// Token: 0x0403B430 RID: 242736
			ToughItem,
			// Token: 0x0403B431 RID: 242737
			MaxHardnessEffect,
			// Token: 0x0403B432 RID: 242738
			BuffHorizontalItem,
			// Token: 0x0403B433 RID: 242739
			HpLight,
			// Token: 0x0403B434 RID: 242740
			HardnessNormal,
			// Token: 0x0403B435 RID: 242741
			HardnessBreak,
			// Token: 0x0403B436 RID: 242742
			FallDownItem,
			// Token: 0x0403B437 RID: 242743
			FallDownBar,
			// Token: 0x0403B438 RID: 242744
			FallDownBarSign,
			// Token: 0x0403B439 RID: 242745
			RageReduceLittle,
			// Token: 0x0403B43A RID: 242746
			HpFlicker,
			// Token: 0x0403B43B RID: 242747
			RageReduceLargeCanvas,
			// Token: 0x0403B43C RID: 242748
			RageReduceLarge,
			// Token: 0x0403B43D RID: 242749
			RageEmpty,
			// Token: 0x0403B43E RID: 242750
			AnimSmallHit,
			// Token: 0x0403B43F RID: 242751
			AnimBigHit,
			// Token: 0x0403B440 RID: 242752
			AnimToughStart,
			// Token: 0x0403B441 RID: 242753
			AnimToughHit,
			// Token: 0x0403B442 RID: 242754
			AnimToughFlick,
			// Token: 0x0403B443 RID: 242755
			AnimToughClose,
			// Token: 0x0403B444 RID: 242756
			AnimBreak,
			// Token: 0x0403B445 RID: 242757
			MoraleLevelItem,
			// Token: 0x0403B446 RID: 242758
			BloodModeIcon,
			// Token: 0x0403B447 RID: 242759
			WeaknessContainer,
			// Token: 0x0403B448 RID: 242760
			HpWeaknessNode,
			// Token: 0x0403B449 RID: 242761
			HpWeaknessSprite1,
			// Token: 0x0403B44A RID: 242762
			HpWeaknessSprite2,
			// Token: 0x0403B44B RID: 242763
			HpWeaknessSprite3,
			// Token: 0x0403B44C RID: 242764
			HpWeaknessEffect,
			// Token: 0x0403B44D RID: 242765
			AniHpWeaknessFull,
			// Token: 0x0403B44E RID: 242766
			AniHpWeaknessBreak
		}
	}
}
