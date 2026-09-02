using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B3 RID: 24755
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarChun : SpecialEnergyBarBase
	{
		// Token: 0x0603E80B RID: 256011 RVA: 0x00FFA5E0 File Offset: 0x00FF87E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 24;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E80C RID: 256012 RVA: 0x00FFA930 File Offset: 0x00FF8B30
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarChun.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarChun.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E80D RID: 256013 RVA: 0x00FFA974 File Offset: 0x00FF8B74
		[NullableContext(1)]
		protected UniTask InitPointItem(UUIItem pointItem)
		{
			SpecialEnergyBarChun.<InitPointItem>d__15 <InitPointItem>d__;
			<InitPointItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointItem>d__.<>4__this = this;
			<InitPointItem>d__.pointItem = pointItem;
			<InitPointItem>d__.<>1__state = -1;
			<InitPointItem>d__.<>t__builder.Start<SpecialEnergyBarChun.<InitPointItem>d__15>(ref <InitPointItem>d__);
			return <InitPointItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E80E RID: 256014 RVA: 0x00FFA9BF File Offset: 0x00FF8BBF
		protected override void OnInitData()
		{
			base.OnInitData();
			this.IsEvilStage = this.TagComponent.HasTag(SpecialEnergyBarChun.TagEvil);
			this.IsStrengthStage = this.TagComponent.HasTag(SpecialEnergyBarChun.TagStrength);
			this.IsEnergyStage = this.GetKeyEnable();
		}

		// Token: 0x0603E80F RID: 256015 RVA: 0x00FFA9FF File Offset: 0x00FF8BFF
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarChun.TagEvil, new BaseTagComponent.TTagSwitchedCallback(this.OnTagEvilChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarChun.TagStrength, new BaseTagComponent.TTagSwitchedCallback(this.OnTagStrengthChange));
		}

		// Token: 0x0603E810 RID: 256016 RVA: 0x00FFAA35 File Offset: 0x00FF8C35
		protected override void OnStart()
		{
			base.OnStart();
			this.InitAllTweenAnim();
			this.UpdatePointItemEffect();
			this.UpdateEvilState(false);
			this.UpdateStrengthState(false);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E811 RID: 256017 RVA: 0x00FFAA60 File Offset: 0x00FF8C60
		private void InitAllTweenAnim()
		{
			this.TweenPlayer = new BattleUiTweenAnimPlayer();
			this.TweenPlayer.InitTweenAnim(17, base.GetItem(17), false);
			this.TweenPlayer.InitTweenAnim(18, base.GetItem(18), false);
			this.TweenPlayer.InitTweenAnim(19, base.GetItem(19), false);
			this.TweenPlayer.InitTweenAnim(20, base.GetItem(20), false);
			this.TweenPlayer.InitTweenAnim(21, base.GetItem(21), false);
			this.TweenPlayer.InitTweenAnim(22, base.GetItem(22), false);
			this.TweenPlayer.InitTweenAnim(23, base.GetItem(23), false);
		}

		// Token: 0x0603E812 RID: 256018 RVA: 0x00FFAB14 File Offset: 0x00FF8D14
		private void UpdatePointItemEffect()
		{
			if (!this.IsStrengthStage)
			{
				this.PointItem.ResetFullEffect();
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				this.PointItem.SetFullEffectColor(flinearColor, false);
				return;
			}
			UNiagaraSystem valueOrDefault = this.NiagaraList.GetValueOrDefault(0);
			if (valueOrDefault != null && this.PointItem != null)
			{
				this.PointItem.ReplaceFullEffect(valueOrDefault);
			}
		}

		// Token: 0x0603E813 RID: 256019 RVA: 0x00FFAB80 File Offset: 0x00FF8D80
		private void UpdateEvilState(bool playAnim = false)
		{
			if (!this.IsEvilStage)
			{
				base.GetItem(2).SetUIActive(true);
				base.GetItem(4).SetUIActive(this.IsEnergyStage);
				base.GetItem(5).SetUIActive(!this.IsEnergyStage);
				base.GetItem(6).SetUIActive(this.IsEnergyStage);
				base.GetItem(8).SetUIActive(false);
				if (!playAnim)
				{
					base.GetItem(3).SetAlpha(1f);
					base.GetItem(4).SetAlpha(1f);
					base.GetItem(9).SetAlpha(1f);
					base.GetItem(10).SetAlpha(1f);
					base.GetItem(7).SetUIActive(false);
					return;
				}
				BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
				if (tweenPlayer != null)
				{
					tweenPlayer.StopTweenAnim(18);
				}
				BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
				if (tweenPlayer2 == null)
				{
					return;
				}
				tweenPlayer2.PlayTweenAnim(17);
				return;
			}
			else
			{
				base.GetItem(8).SetUIActive(true);
				base.GetItem(10).SetUIActive(this.IsEnergyStage);
				base.GetItem(11).SetUIActive(!this.IsEnergyStage);
				base.GetItem(12).SetUIActive(this.IsEnergyStage);
				base.GetItem(2).SetUIActive(false);
				if (!playAnim)
				{
					base.GetItem(3).SetAlpha(1f);
					base.GetItem(4).SetAlpha(1f);
					base.GetItem(9).SetAlpha(1f);
					base.GetItem(10).SetAlpha(1f);
					base.GetItem(13).SetUIActive(false);
					return;
				}
				BattleUiTweenAnimPlayer tweenPlayer3 = this.TweenPlayer;
				if (tweenPlayer3 != null)
				{
					tweenPlayer3.StopTweenAnim(17);
				}
				BattleUiTweenAnimPlayer tweenPlayer4 = this.TweenPlayer;
				if (tweenPlayer4 == null)
				{
					return;
				}
				tweenPlayer4.PlayTweenAnim(18);
				return;
			}
		}

		// Token: 0x0603E814 RID: 256020 RVA: 0x00FFAD3C File Offset: 0x00FF8F3C
		private void UpdateStrengthState(bool playAnim = false)
		{
			if (!this.IsStrengthStage)
			{
				base.GetItem(3).SetUIActive(true);
				base.GetItem(9).SetUIActive(true);
				if (!playAnim)
				{
					base.GetItem(14).SetUIActive(false);
					return;
				}
				BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
				if (tweenPlayer != null)
				{
					tweenPlayer.StopTweenAnim(19);
				}
				BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
				if (tweenPlayer2 == null)
				{
					return;
				}
				tweenPlayer2.PlayTweenAnim(20);
				return;
			}
			else
			{
				if (!playAnim)
				{
					base.GetItem(3).SetUIActive(false);
					base.GetItem(9).SetUIActive(false);
					base.GetItem(14).SetUIActive(true);
					base.GetItem(15).SetUIActive(true);
					base.GetItem(16).SetUIActive(false);
					return;
				}
				BattleUiTweenAnimPlayer tweenPlayer3 = this.TweenPlayer;
				if (tweenPlayer3 != null)
				{
					tweenPlayer3.StopTweenAnim(20);
				}
				BattleUiTweenAnimPlayer tweenPlayer4 = this.TweenPlayer;
				if (tweenPlayer4 == null)
				{
					return;
				}
				tweenPlayer4.PlayTweenAnim(19);
				return;
			}
		}

		// Token: 0x0603E815 RID: 256021 RVA: 0x00FFAE14 File Offset: 0x00FF9014
		private void UpdateEnergyState()
		{
			if (this.IsEnergyStage)
			{
				base.GetItem(4).SetUIActive(true);
				base.GetItem(10).SetUIActive(true);
				BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
				if (tweenPlayer != null)
				{
					tweenPlayer.StopTweenAnim(23);
				}
				BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
				if (tweenPlayer2 == null)
				{
					return;
				}
				tweenPlayer2.PlayTweenAnim(22);
				return;
			}
			else
			{
				BattleUiTweenAnimPlayer tweenPlayer3 = this.TweenPlayer;
				if (tweenPlayer3 != null)
				{
					tweenPlayer3.StopTweenAnim(22);
				}
				BattleUiTweenAnimPlayer tweenPlayer4 = this.TweenPlayer;
				if (tweenPlayer4 == null)
				{
					return;
				}
				tweenPlayer4.PlayTweenAnim(23);
				return;
			}
		}

		// Token: 0x0603E816 RID: 256022 RVA: 0x00FFAE90 File Offset: 0x00FF9090
		protected void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.PointItem.UpdatePercent(curPercent, true, 0);
			bool flag = curPercent > 0f;
			if (flag != this.IsEnergyStage)
			{
				this.IsEnergyStage = flag;
				this.UpdateEnergyState();
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(flag, isStart);
		}

		// Token: 0x0603E817 RID: 256023 RVA: 0x00FFAEE8 File Offset: 0x00FF90E8
		protected void RefreshBuff()
		{
			SpecialEnergyBarInfo config = this.Config;
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				long buffId = config.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.Config.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603E818 RID: 256024 RVA: 0x00FFAF55 File Offset: 0x00FF9155
		private void OnTagEvilChange(int tagId, bool tagExist)
		{
			if (tagExist == this.IsEvilStage)
			{
				return;
			}
			this.IsEvilStage = tagExist;
			this.UpdateEvilState(true);
		}

		// Token: 0x0603E819 RID: 256025 RVA: 0x00FFAF6F File Offset: 0x00FF916F
		private void OnTagStrengthChange(int tagId, bool tagExist)
		{
			if (tagExist == this.IsStrengthStage)
			{
				return;
			}
			this.IsStrengthStage = tagExist;
			this.UpdatePointItemEffect();
			this.UpdateStrengthState(true);
		}

		// Token: 0x0603E81A RID: 256026 RVA: 0x00FFAF8F File Offset: 0x00FF918F
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E81B RID: 256027 RVA: 0x00FFAF98 File Offset: 0x00FF9198
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarPointItem pointItem = this.PointItem;
			if (pointItem != null)
			{
				pointItem.Tick(delta);
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_41;
				}
			}
			this.RefreshBuff();
			IL_41:
			bool flag = this.Buff != null && this.Buff.GetRemainDuration() < this.Config.ExtraFloatParams[0];
			if (this.IsPlayWarnAnim != flag)
			{
				this.IsPlayWarnAnim = flag;
				if (flag)
				{
					BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
					if (tweenPlayer == null)
					{
						return;
					}
					tweenPlayer.PlayTweenAnim(21);
					return;
				}
				else
				{
					BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
					if (tweenPlayer2 != null)
					{
						tweenPlayer2.StopTweenAnim(21);
					}
					UUIItem item = base.GetItem(2);
					if (item != null)
					{
						item.SetAlpha(1f);
					}
					UUIItem item2 = base.GetItem(8);
					if (item2 != null)
					{
						item2.SetAlpha(1f);
					}
					UUIItem item3 = base.GetItem(14);
					if (item3 == null)
					{
						return;
					}
					item3.SetAlpha(1f);
				}
			}
		}

		// Token: 0x0603E81C RID: 256028 RVA: 0x00FFB090 File Offset: 0x00FF9290
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			if (this.IsPlayWarnAnim)
			{
				this.IsPlayWarnAnim = false;
				BattleUiTweenAnimPlayer tweenPlayer = this.TweenPlayer;
				if (tweenPlayer != null)
				{
					tweenPlayer.StopTweenAnim(21);
				}
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetAlpha(1f);
				}
				UUIItem item2 = base.GetItem(8);
				if (item2 != null)
				{
					item2.SetAlpha(1f);
				}
				UUIItem item3 = base.GetItem(14);
				if (item3 != null)
				{
					item3.SetAlpha(1f);
				}
			}
			BattleUiTweenAnimPlayer tweenPlayer2 = this.TweenPlayer;
			if (tweenPlayer2 == null)
			{
				return;
			}
			tweenPlayer2.Clear(false);
		}

		// Token: 0x0402308B RID: 143499
		private const int POINT_NUM = 41;

		// Token: 0x0402308C RID: 143500
		private const float POINT_WIDTH = 9f;

		// Token: 0x0402308D RID: 143501
		[StaticVariableRuleIgnore]
		private static readonly int TagEvil = GameplayTagDefine.EGameplayTagId["角色.R2T1ChunMd10011.标记机制.魔人化启动"];

		// Token: 0x0402308E RID: 143502
		[StaticVariableRuleIgnore]
		private static readonly int TagStrength = GameplayTagDefine.EGameplayTagId["角色.R2T1ChunMd10011.标记机制.强化状态"];

		// Token: 0x0402308F RID: 143503
		private bool IsEvilStage;

		// Token: 0x04023090 RID: 143504
		private bool IsStrengthStage;

		// Token: 0x04023091 RID: 143505
		private bool IsEnergyStage;

		// Token: 0x04023092 RID: 143506
		private SpecialEnergyBarPointItem PointItem;

		// Token: 0x04023093 RID: 143507
		private BattleUiTweenAnimPlayer TweenPlayer;

		// Token: 0x04023094 RID: 143508
		private IActiveBuff Buff;

		// Token: 0x04023095 RID: 143509
		private int BuffHandle;

		// Token: 0x04023096 RID: 143510
		private bool IsPlayWarnAnim;

		// Token: 0x0200C1D5 RID: 49621
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BAFE RID: 244478
			PointItem,
			// Token: 0x0403BAFF RID: 244479
			KeyContainerItem,
			// Token: 0x0403BB00 RID: 244480
			ItemA,
			// Token: 0x0403BB01 RID: 244481
			ItemA1,
			// Token: 0x0403BB02 RID: 244482
			ItemA2,
			// Token: 0x0403BB03 RID: 244483
			ItemA3,
			// Token: 0x0403BB04 RID: 244484
			ItemA4,
			// Token: 0x0403BB05 RID: 244485
			ItemA5,
			// Token: 0x0403BB06 RID: 244486
			ItemB,
			// Token: 0x0403BB07 RID: 244487
			ItemB1,
			// Token: 0x0403BB08 RID: 244488
			ItemB2,
			// Token: 0x0403BB09 RID: 244489
			ItemB3,
			// Token: 0x0403BB0A RID: 244490
			ItemB4,
			// Token: 0x0403BB0B RID: 244491
			ItemB5,
			// Token: 0x0403BB0C RID: 244492
			ItemStar,
			// Token: 0x0403BB0D RID: 244493
			ItemStar1,
			// Token: 0x0403BB0E RID: 244494
			ItemStar2,
			// Token: 0x0403BB0F RID: 244495
			AniStageA,
			// Token: 0x0403BB10 RID: 244496
			AniStageB,
			// Token: 0x0403BB11 RID: 244497
			AniStrengthIn,
			// Token: 0x0403BB12 RID: 244498
			AniStrengthOut,
			// Token: 0x0403BB13 RID: 244499
			AniStrengthWarn,
			// Token: 0x0403BB14 RID: 244500
			AniEnergyIn,
			// Token: 0x0403BB15 RID: 244501
			AniEnergyOut
		}
	}
}
