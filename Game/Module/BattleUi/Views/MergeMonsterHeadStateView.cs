using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF3 RID: 24563
	[NullableContext(2)]
	[Nullable(0)]
	public class MergeMonsterHeadStateView : BattleChildView
	{
		// Token: 0x0603DD99 RID: 253337 RVA: 0x00FC4964 File Offset: 0x00FC2B64
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

		// Token: 0x0603DD9A RID: 253338 RVA: 0x00FC4E44 File Offset: 0x00FC3044
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
			this.BuffItemContainer.Init(item, 12, false);
		}

		// Token: 0x0603DD9B RID: 253339 RVA: 0x00FC4F10 File Offset: 0x00FC3110
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

		// Token: 0x0603DD9C RID: 253340 RVA: 0x00FC4F6C File Offset: 0x00FC316C
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.VisibleMachine.Reset();
			this.VisibleMachine = null;
			this.BuffItemContainer.ClearAll();
			if (this.HitEffectCountdown >= 0f)
			{
				this.PlayHitEffect(0f);
			}
		}

		// Token: 0x0603DD9D RID: 253341 RVA: 0x00FC4FC0 File Offset: 0x00FC31C0
		protected override void OnBeforeShow()
		{
			this.RefreshInner();
			this.VisibleMachine.SetVisible(true, 667f);
		}

		// Token: 0x0603DD9E RID: 253342 RVA: 0x00FC4FD9 File Offset: 0x00FC31D9
		public void Refresh(MergeHeadStateInfo info)
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

		// Token: 0x0603DD9F RID: 253343 RVA: 0x00FC4FFB File Offset: 0x00FC31FB
		private void RefreshInner()
		{
			this.RefreshBossLevel();
			this.RefreshBossName();
			this.RefreshHp(false);
			this.RefreshBuff();
			this.RefreshExtraItem();
		}

		// Token: 0x0603DDA0 RID: 253344 RVA: 0x00FC501C File Offset: 0x00FC321C
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.HpParentWidth = base.GetItem(8).GetParentAsUIItem().GetWidth();
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialParameterCollection>("/LGUI/MPC_UIShader.MPC_UIShader", delegate([Nullable(2)] UMaterialParameterCollection collection, string _)
			{
				this.GlobalShaderCollection = collection;
			}, 103, "js_undefined");
		}

		// Token: 0x0603DDA1 RID: 253345 RVA: 0x00FC506A File Offset: 0x00FC326A
		public void OnHealthChanged()
		{
			this.RefreshHp(true);
		}

		// Token: 0x0603DDA2 RID: 253346 RVA: 0x00FC5073 File Offset: 0x00FC3273
		public void OnLanguageChange()
		{
			this.RefreshBossName();
		}

		// Token: 0x0603DDA3 RID: 253347 RVA: 0x00FC507C File Offset: 0x00FC327C
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
			this.BuffItemContainer.Tick(delta);
		}

		// Token: 0x0603DDA4 RID: 253348 RVA: 0x00FC5114 File Offset: 0x00FC3314
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

		// Token: 0x0603DDA5 RID: 253349 RVA: 0x00FC516C File Offset: 0x00FC336C
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

		// Token: 0x0603DDA6 RID: 253350 RVA: 0x00FC51F8 File Offset: 0x00FC33F8
		private void PlayHitEffect(float param)
		{
			if (this.GlobalShaderCollection != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.GlobalShaderCollection, MergeMonsterHeadStateView.RgbSplitProgress, param);
			}
		}

		// Token: 0x0603DDA7 RID: 253351 RVA: 0x00FC521D File Offset: 0x00FC341D
		private void StopBarLerpAnimation()
		{
			base.GetItem(8).SetUIActive(false);
			this.HpStateMachine.Reset();
			this.IsPlayingHpBarAnim = false;
		}

		// Token: 0x0603DDA8 RID: 253352 RVA: 0x00FC523E File Offset: 0x00FC343E
		private void SetHpBarPercent(float percent)
		{
			base.GetSprite(7).SetFillAmount(percent);
		}

		// Token: 0x0603DDA9 RID: 253353 RVA: 0x00FC5250 File Offset: 0x00FC3450
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

		// Token: 0x0603DDAA RID: 253354 RVA: 0x00FC52B1 File Offset: 0x00FC34B1
		private void RefreshBossLevel()
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603DDAB RID: 253355 RVA: 0x00FC52C8 File Offset: 0x00FC34C8
		private void RefreshBossName()
		{
			string monsterGroupName = this.Info.MonsterGroupName;
			base.GetText(1).SetText((!string.IsNullOrEmpty(monsterGroupName)) ? Singleton<PublicUtil>.Instance.GetConfigTextByKey(monsterGroupName) : string.Empty, true);
		}

		// Token: 0x0603DDAC RID: 253356 RVA: 0x00FC5308 File Offset: 0x00FC3508
		private void RefreshBuff()
		{
			IMonsterMergedHpBarSettings monsterMergedHpBarSettings = this.Info.MonsterMergedHpBarSettings;
			List<long> list = (monsterMergedHpBarSettings != null) ? monsterMergedHpBarSettings.DisplayBuffIds : null;
			if (list == null)
			{
				this.BuffItemContainer.ClearAll();
				return;
			}
			this.BuffItemContainer.RefreshBuff(list);
		}

		// Token: 0x0603DDAD RID: 253357 RVA: 0x00FC5348 File Offset: 0x00FC3548
		private void RefreshExtraItem()
		{
			UUIItem item = base.GetItem(32);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x0603DDAE RID: 253358 RVA: 0x00FC535D File Offset: 0x00FC355D
		private void InitAllTweenAnim()
		{
			this.InitTweenAnim(25);
			this.InitTweenAnim(26);
		}

		// Token: 0x0603DDAF RID: 253359 RVA: 0x00FC5370 File Offset: 0x00FC3570
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

		// Token: 0x0603DDB0 RID: 253360 RVA: 0x00FC53F0 File Offset: 0x00FC35F0
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

		// Token: 0x0603DDB1 RID: 253361 RVA: 0x00FC544C File Offset: 0x00FC364C
		public void HideWithAnim()
		{
			this.VisibleMachine.SetVisible(false, 167f);
		}

		// Token: 0x0603DDB2 RID: 253362 RVA: 0x00FC545F File Offset: 0x00FC365F
		private void OnRealVisibleChanged(bool visible)
		{
			if (!visible)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603DDB3 RID: 253363 RVA: 0x00FC546C File Offset: 0x00FC366C
		private void OnPlayVisibleAnim(bool visible)
		{
			this.LevelSequencePlayer.PlaySequencePurely(visible ? "ShowView" : "CloseView", false, false, null, null, false);
		}

		// Token: 0x0603DDB4 RID: 253364 RVA: 0x00FC54A0 File Offset: 0x00FC36A0
		private void OnStopVisibleAnim(bool visible)
		{
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x0603DDB5 RID: 253365 RVA: 0x00FC54AF File Offset: 0x00FC36AF
		[NullableContext(1)]
		public string GetResourceId()
		{
			return "UiItem_BossState_Prefab";
		}

		// Token: 0x04022B06 RID: 142086
		[StaticVariableRuleIgnore]
		private static readonly FName RgbSplitProgress = new FName("RGBSplit_Progress");

		// Token: 0x04022B07 RID: 142087
		private const float SHOW_VIEW_ANIM_TIME = 667f;

		// Token: 0x04022B08 RID: 142088
		private const float CLOSE_VIEW_ANIM_TIME = 167f;

		// Token: 0x04022B09 RID: 142089
		private const int MAX_BUFF_ITEM_COUNT = 12;

		// Token: 0x04022B0A RID: 142090
		public MergeHeadStateInfo Info;

		// Token: 0x04022B0B RID: 142091
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022B0C RID: 142092
		private VisibleAnimMachine VisibleMachine;

		// Token: 0x04022B0D RID: 142093
		private float HitLargePercent;

		// Token: 0x04022B0E RID: 142094
		private float CurrentBarPercent = 1f;

		// Token: 0x04022B0F RID: 142095
		[Nullable(1)]
		private readonly HpBufferStateMachine HpStateMachine = new HpBufferStateMachine();

		// Token: 0x04022B10 RID: 142096
		private UMaterialParameterCollection GlobalShaderCollection;

		// Token: 0x04022B11 RID: 142097
		private float HitEffectCountdown = -1f;

		// Token: 0x04022B12 RID: 142098
		private float HitEffectDuration;

		// Token: 0x04022B13 RID: 142099
		private float HpParentWidth;

		// Token: 0x04022B14 RID: 142100
		private bool IsPlayingHpBarAnim;

		// Token: 0x04022B15 RID: 142101
		[Nullable(1)]
		private readonly BuffItemSimpleContainer BuffItemContainer = new BuffItemSimpleContainer();

		// Token: 0x04022B16 RID: 142102
		[Nullable(1)]
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C07F RID: 49279
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B3FA RID: 242682
			BossLevelText,
			// Token: 0x0403B3FB RID: 242683
			BossNameText,
			// Token: 0x0403B3FC RID: 242684
			RageItem,
			// Token: 0x0403B3FD RID: 242685
			ToughBg,
			// Token: 0x0403B3FE RID: 242686
			RageBar,
			// Token: 0x0403B3FF RID: 242687
			HpShieldBarItem,
			// Token: 0x0403B400 RID: 242688
			HpBarItem,
			// Token: 0x0403B401 RID: 242689
			NormalHpBarSprite,
			// Token: 0x0403B402 RID: 242690
			BarBufferCanvas,
			// Token: 0x0403B403 RID: 242691
			BarBufferSprite,
			// Token: 0x0403B404 RID: 242692
			ShieldBarSprite,
			// Token: 0x0403B405 RID: 242693
			ToughItem,
			// Token: 0x0403B406 RID: 242694
			MaxHardnessEffect,
			// Token: 0x0403B407 RID: 242695
			BuffHorizontalItem,
			// Token: 0x0403B408 RID: 242696
			HpLight,
			// Token: 0x0403B409 RID: 242697
			HardnessNormal,
			// Token: 0x0403B40A RID: 242698
			HardnessBreak,
			// Token: 0x0403B40B RID: 242699
			FallDownItem,
			// Token: 0x0403B40C RID: 242700
			FallDownBar,
			// Token: 0x0403B40D RID: 242701
			FallDownBarSign,
			// Token: 0x0403B40E RID: 242702
			RageReduceLittle,
			// Token: 0x0403B40F RID: 242703
			HpFlicker,
			// Token: 0x0403B410 RID: 242704
			RageReduceLargeCanvas,
			// Token: 0x0403B411 RID: 242705
			RageReduceLarge,
			// Token: 0x0403B412 RID: 242706
			RageEmpty,
			// Token: 0x0403B413 RID: 242707
			AnimSmallHit,
			// Token: 0x0403B414 RID: 242708
			AnimBigHit,
			// Token: 0x0403B415 RID: 242709
			AnimToughStart,
			// Token: 0x0403B416 RID: 242710
			AnimToughHit,
			// Token: 0x0403B417 RID: 242711
			AnimToughFlick,
			// Token: 0x0403B418 RID: 242712
			AnimToughClose,
			// Token: 0x0403B419 RID: 242713
			AnimBreak,
			// Token: 0x0403B41A RID: 242714
			MoraleLevelItem,
			// Token: 0x0403B41B RID: 242715
			BloodModeIcon,
			// Token: 0x0403B41C RID: 242716
			WeaknessContainer,
			// Token: 0x0403B41D RID: 242717
			HpWeaknessNode,
			// Token: 0x0403B41E RID: 242718
			HpWeaknessSprite1,
			// Token: 0x0403B41F RID: 242719
			HpWeaknessSprite2,
			// Token: 0x0403B420 RID: 242720
			HpWeaknessSprite3,
			// Token: 0x0403B421 RID: 242721
			HpWeaknessEffect,
			// Token: 0x0403B422 RID: 242722
			AniHpWeaknessFull,
			// Token: 0x0403B423 RID: 242723
			AniHpWeaknessBreak
		}
	}
}
