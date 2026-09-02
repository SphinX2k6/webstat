using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060BF RID: 24767
	public class SpecialEnergyBarJingRan : SpecialEnergyBarBase
	{
		// Token: 0x0603E8B8 RID: 256184 RVA: 0x00FFE898 File Offset: 0x00FFCA98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 23;
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
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUINiagara));
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E8B9 RID: 256185 RVA: 0x00FFEBC5 File Offset: 0x00FFCDC5
		protected override void OnInitData()
		{
			this.YangConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(SpecialEnergyBarJingRan.YANG_CONFIG_ID);
			this.YinConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(SpecialEnergyBarJingRan.YIN_CONFIG_ID);
		}

		// Token: 0x0603E8BA RID: 256186 RVA: 0x00FFEBFC File Offset: 0x00FFCDFC
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarJingRan.StateYinTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnStateTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarJingRan.StateYangTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnStateTagChange));
			base.ListenForAttributeChanged(SpecialEnergyBarJingRan.FishEnergyAttrId, new Action<EAttributeType, float, float>(this.OnFishEnergyChanged));
			base.ListenForAttributeChanged(SpecialEnergyBarJingRan.FishEnergyMaxAttrId, new Action<EAttributeType, float, float>(this.OnFishEnergyChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarJingRan.StateStrengthTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnStrengthTagChange));
		}

		// Token: 0x0603E8BB RID: 256187 RVA: 0x00FFEC84 File Offset: 0x00FFCE84
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarJingRan.<OnBeforeStartAsync>d__33 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarJingRan.<OnBeforeStartAsync>d__33>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8BC RID: 256188 RVA: 0x00FFECC8 File Offset: 0x00FFCEC8
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarJingRan.<InitBarItem>d__34 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarJingRan.<InitBarItem>d__34>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8BD RID: 256189 RVA: 0x00FFED0C File Offset: 0x00FFCF0C
		[NullableContext(1)]
		protected UniTask InitFishItem(int index, UUIItem slotItem)
		{
			SpecialEnergyBarJingRan.<InitFishItem>d__35 <InitFishItem>d__;
			<InitFishItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitFishItem>d__.<>4__this = this;
			<InitFishItem>d__.index = index;
			<InitFishItem>d__.slotItem = slotItem;
			<InitFishItem>d__.<>1__state = -1;
			<InitFishItem>d__.<>t__builder.Start<SpecialEnergyBarJingRan.<InitFishItem>d__35>(ref <InitFishItem>d__);
			return <InitFishItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8BE RID: 256190 RVA: 0x00FFED60 File Offset: 0x00FFCF60
		protected override void OnStart()
		{
			base.InitTweenAnim(22);
			this.RefreshState();
			this.OnBarPercentChanged();
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(18);
			if (item2 != null)
			{
				item2.SetUIActive(true);
			}
			this.UpdateBarBgStyle();
			this.RefreshFireState(true);
			BaseTagComponent tagComponent = this.TagComponent;
			bool tagExist = tagComponent != null && tagComponent.HasTag(SpecialEnergyBarJingRan.StateStrengthTagId);
			this.OnStrengthTagChange(SpecialEnergyBarJingRan.StateStrengthTagId, tagExist);
		}

		// Token: 0x0603E8BF RID: 256191 RVA: 0x00FFEDDC File Offset: 0x00FFCFDC
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.IsWaitingSlotAnim || this.IsStateDirty)
			{
				this.RefreshState();
			}
			SpecialEnergyBarJingRanSlot barItemA = this.BarItemA;
			if (barItemA != null)
			{
				barItemA.Tick(delta);
			}
			SpecialEnergyBarJingRanSlot barItemB = this.BarItemB;
			if (barItemB != null)
			{
				barItemB.Tick(delta);
			}
			this.TryRotFishPanel(delta);
			if (!this.IsInStrengthState)
			{
				this.PlayWarnAnim(false);
				return;
			}
			this.RefreshBuff();
			if (this.Buff != null)
			{
				this.PlayWarnAnim(this.Buff.GetRemainDuration() < this.Config.ExtraFloatParams[2]);
				return;
			}
			this.PlayWarnAnim(false);
		}

		// Token: 0x0603E8C0 RID: 256192 RVA: 0x00FFEE7B File Offset: 0x00FFD07B
		private void OnStateTagChange(int tagId, bool tagExist)
		{
			this.IsStateDirty = true;
			SpecialEnergyBarJingRanSlot barItemA = this.BarItemA;
			if (barItemA != null)
			{
				barItemA.MarkStateChange();
			}
			SpecialEnergyBarJingRanSlot barItemB = this.BarItemB;
			if (barItemB == null)
			{
				return;
			}
			barItemB.MarkStateChange();
		}

		// Token: 0x0603E8C1 RID: 256193 RVA: 0x00FFEEA5 File Offset: 0x00FFD0A5
		private void OnStrengthTagChange(int tagId, bool tagExist)
		{
			this.IsInStrengthState = tagExist;
			SpecialEnergyBarJingRanSlot barItemA = this.BarItemA;
			if (barItemA != null)
			{
				barItemA.SetStrengthState(tagExist);
			}
			SpecialEnergyBarJingRanSlot barItemB = this.BarItemB;
			if (barItemB == null)
			{
				return;
			}
			barItemB.SetStrengthState(tagExist);
		}

		// Token: 0x0603E8C2 RID: 256194 RVA: 0x00FFEED1 File Offset: 0x00FFD0D1
		private void OnFishEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.UpdateFishEnergy();
		}

		// Token: 0x0603E8C3 RID: 256195 RVA: 0x00FFEED9 File Offset: 0x00FFD0D9
		protected override void OnAttributeChanged()
		{
			this.UpdateBarBgStyle();
		}

		// Token: 0x0603E8C4 RID: 256196 RVA: 0x00FFEEE1 File Offset: 0x00FFD0E1
		protected override void OnMaxAttributeChanged()
		{
			this.UpdateBarBgStyle();
		}

		// Token: 0x0603E8C5 RID: 256197 RVA: 0x00FFEEEC File Offset: 0x00FFD0EC
		private void UpdateBarBgStyle()
		{
			bool flag = this.AttributeComponent.GetCurrentValue(this.AttributeId) > 0f;
			if (flag == this.IsLightState)
			{
				return;
			}
			this.IsLightState = flag;
			UUIItem item = base.GetItem(19);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(17);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			this.RefreshFireState(false);
		}

		// Token: 0x0603E8C6 RID: 256198 RVA: 0x00FFEF54 File Offset: 0x00FFD154
		private bool IsCurItemPlayingAnim()
		{
			SpecialEnergyBarJingRan.EState curState = this.CurState;
			if (curState == SpecialEnergyBarJingRan.EState.Yin)
			{
				SpecialEnergyBarJingRanSlot barItemB = this.BarItemB;
				return barItemB != null && barItemB.IsPlayingConsumeAnim();
			}
			if (curState == SpecialEnergyBarJingRan.EState.Yang)
			{
				SpecialEnergyBarJingRanSlot barItemA = this.BarItemA;
				return barItemA != null && barItemA.IsPlayingConsumeAnim();
			}
			return false;
		}

		// Token: 0x0603E8C7 RID: 256199 RVA: 0x00FFEF94 File Offset: 0x00FFD194
		private void RefreshState()
		{
			if (this.IsCurItemPlayingAnim())
			{
				this.IsWaitingSlotAnim = true;
				return;
			}
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarJingRan.StateYangTagId))
			{
				this.SetState(SpecialEnergyBarJingRan.EState.Yang);
			}
			else
			{
				this.SetState(SpecialEnergyBarJingRan.EState.Yin);
			}
			this.IsStateDirty = false;
			this.IsWaitingSlotAnim = false;
		}

		// Token: 0x0603E8C8 RID: 256200 RVA: 0x00FFEFE8 File Offset: 0x00FFD1E8
		private void SetState(SpecialEnergyBarJingRan.EState state)
		{
			if (state == this.CurState)
			{
				return;
			}
			this.CurState = state;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yang);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yin);
			}
			UUIItem item3 = base.GetItem(12);
			if (item3 != null)
			{
				item3.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yang);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 != null)
			{
				item4.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yin);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(13);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yang);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(7);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(state == SpecialEnergyBarJingRan.EState.Yin);
			}
			this.UpdateFishEnergy();
		}

		// Token: 0x0603E8C9 RID: 256201 RVA: 0x00FFF094 File Offset: 0x00FFD294
		private void UpdateFishEnergy()
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(SpecialEnergyBarJingRan.FishEnergyAttrId) : 0f;
			BaseAttributeComponent attributeComponent2 = this.AttributeComponent;
			float num2 = (attributeComponent2 != null) ? attributeComponent2.GetCurrentValue(SpecialEnergyBarJingRan.FishEnergyMaxAttrId) : 0f;
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num2, 0.0, null))
			{
				return;
			}
			float num3 = num2 / (float)SpecialEnergyBarJingRan.MAX_FISH_NUM / 2f;
			float num4 = num2 / (float)SpecialEnergyBarJingRan.MAX_FISH_NUM;
			float num5 = num / num4;
			float curFishNum = this.CurFishNum;
			this.CurFishNum = num5;
			bool isZeroEnergy = Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, 0.0, null) || Singleton<MathUtils>.Instance.IsNearlyEqual((double)num2, 0.0, null);
			bool flag = num2 > 0f && Singleton<MathUtils>.Instance.IsNearlyEqual((double)num2, (double)num, null);
			bool isNewFish = Math.Floor((double)num5) > Math.Floor((double)curFishNum);
			this.PlayFillFishAnim(isNewFish, isZeroEnergy, flag);
			for (int i = 0; i < SpecialEnergyBarJingRan.MAX_FISH_NUM; i++)
			{
				SpecialEnergyBarJingRan.EFishState fishState = SpecialEnergyBarJingRan.EFishState.Empty;
				if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num2, 0.0, null))
				{
					fishState = SpecialEnergyBarJingRan.EFishState.Empty;
				}
				else if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, (double)((float)(i * 2 + 1) * num3), null))
				{
					fishState = SpecialEnergyBarJingRan.EFishState.Half;
				}
				else if (num >= (float)((i + 1) * 2) * num3)
				{
					fishState = SpecialEnergyBarJingRan.EFishState.Full;
				}
				this.SetFishState(i, fishState);
			}
			this.UpdateTargetRot(num5, curFishNum);
			SpecialEnergyBarJingRanSlot barItemA = this.BarItemA;
			if (barItemA != null)
			{
				barItemA.SetKeyEnable(flag);
			}
			SpecialEnergyBarJingRanSlot barItemB = this.BarItemB;
			if (barItemB != null)
			{
				barItemB.SetKeyEnable(flag);
			}
			this.RefreshFireState(false);
		}

		// Token: 0x0603E8CA RID: 256202 RVA: 0x00FFF268 File Offset: 0x00FFD468
		private void RefreshFireState(bool isStart = false)
		{
			bool isLightState = this.IsLightState;
			if (isLightState == this.IsFireState && !isStart)
			{
				return;
			}
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(isLightState);
			}
			UUIItem item2 = base.GetItem(20);
			if (item2 != null)
			{
				item2.SetUIActive(isLightState);
			}
			this.IsFireState = isLightState;
		}

		// Token: 0x0603E8CB RID: 256203 RVA: 0x00FFF2B8 File Offset: 0x00FFD4B8
		private void PlayFillFishAnim(bool isNewFish, bool isZeroEnergy, bool isFullEnergy)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(8);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(this.CurState == SpecialEnergyBarJingRan.EState.Yin && isNewFish);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(9);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(this.CurState == SpecialEnergyBarJingRan.EState.Yin && !isZeroEnergy && isFullEnergy);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(15);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetUIActive(this.CurState == SpecialEnergyBarJingRan.EState.Yang && isNewFish);
			}
			UUINiagara uiNiagara4 = base.GetUiNiagara(14);
			if (uiNiagara4 == null)
			{
				return;
			}
			uiNiagara4.SetUIActive(this.CurState == SpecialEnergyBarJingRan.EState.Yang && !isZeroEnergy && isFullEnergy);
		}

		// Token: 0x0603E8CC RID: 256204 RVA: 0x00FFF348 File Offset: 0x00FFD548
		private void UpdateTargetRot(float newFishNum, float oldFishNum)
		{
			if (newFishNum > oldFishNum)
			{
				this.RemainingRotDegree += (float)((Math.Floor((double)newFishNum) - Math.Floor((double)oldFishNum)) * 360.0 / (double)SpecialEnergyBarJingRan.MAX_FISH_NUM);
				return;
			}
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)newFishNum, 0.0, null))
			{
				this.RemainingRotDegree = 0f;
				this.TmpRotation.Yaw = 0f;
				base.GetItem(10).SetUIRelativeRotation(this.TmpRotation);
			}
		}

		// Token: 0x0603E8CD RID: 256205 RVA: 0x00FFF3D6 File Offset: 0x00FFD5D6
		private void SetFishState(int fishIndex, SpecialEnergyBarJingRan.EFishState fishState)
		{
			if (fishIndex < 0 || fishIndex >= SpecialEnergyBarJingRan.MAX_FISH_NUM)
			{
				return;
			}
			this.FishPanelList[fishIndex].SetFishState(this.CurState, fishState);
		}

		// Token: 0x0603E8CE RID: 256206 RVA: 0x00FFF400 File Offset: 0x00FFD600
		private void TryRotFishPanel(float delta)
		{
			if (this.RemainingRotDegree <= 0f)
			{
				return;
			}
			float num = delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond * (float)SpecialEnergyBarJingRan.FISH_ROT_SPEED;
			if (num > this.RemainingRotDegree)
			{
				num = this.RemainingRotDegree;
			}
			this.TmpRotation.Yaw = (this.TmpRotation.Yaw - num) % 360f;
			this.RemainingRotDegree -= num;
			base.GetItem(10).SetUIRelativeRotation(this.TmpRotation);
		}

		// Token: 0x0603E8CF RID: 256207 RVA: 0x00FFF480 File Offset: 0x00FFD680
		private void RefreshBuff()
		{
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					return;
				}
			}
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
			if (flag && this.Config.BuffId != 0L)
			{
				CharacterBuffComponent buffComponent2 = this.BuffComponent;
				this.Buff = ((buffComponent2 != null) ? buffComponent2.GetBuffById(this.Config.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603E8D0 RID: 256208 RVA: 0x00FFF520 File Offset: 0x00FFD720
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(22);
				return;
			}
			base.StopTweenAnim(22);
			base.GetItem(0).SetAlpha(1f);
			base.GetItem(2).SetAlpha(1f);
			base.GetItem(1).SetAlpha(1f);
			base.GetItem(3).SetAlpha(1f);
		}

		// Token: 0x0603E8D1 RID: 256209 RVA: 0x00FFF596 File Offset: 0x00FFD796
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(22);
			base.ClearAllTweenAnim();
		}

		// Token: 0x040230F5 RID: 143605
		[StaticVariableRuleIgnore]
		private static readonly int YANG_CONFIG_ID = 121201;

		// Token: 0x040230F6 RID: 143606
		private static readonly int YIN_CONFIG_ID = 121202;

		// Token: 0x040230F7 RID: 143607
		private static readonly int StateYinTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1JingranMd1001.形态标识.阴"];

		// Token: 0x040230F8 RID: 143608
		private static readonly int StateYangTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1JingranMd1001.形态标识.阳"];

		// Token: 0x040230F9 RID: 143609
		private static readonly int StateStrengthTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1JingranMd10011.标识.大招状态"];

		// Token: 0x040230FA RID: 143610
		private static readonly EAttributeType FishEnergyAttrId = EAttributeType.SpecialEnergy1;

		// Token: 0x040230FB RID: 143611
		private static readonly EAttributeType FishEnergyMaxAttrId = EAttributeType.SpecialEnergy1Max;

		// Token: 0x040230FC RID: 143612
		private static readonly int MAX_FISH_NUM = 3;

		// Token: 0x040230FD RID: 143613
		private static readonly int FISH_ROT_SPEED = 360;

		// Token: 0x040230FE RID: 143614
		[Nullable(2)]
		private SpecialEnergyBarInfo YangConfig;

		// Token: 0x040230FF RID: 143615
		[Nullable(2)]
		private SpecialEnergyBarInfo YinConfig;

		// Token: 0x04023100 RID: 143616
		private SpecialEnergyBarJingRan.EState CurState = SpecialEnergyBarJingRan.EState.Max;

		// Token: 0x04023101 RID: 143617
		[Nullable(2)]
		private SpecialEnergyBarJingRanSlot BarItemA;

		// Token: 0x04023102 RID: 143618
		[Nullable(2)]
		private SpecialEnergyBarJingRanSlot BarItemB;

		// Token: 0x04023103 RID: 143619
		[Nullable(1)]
		private List<SpecialEnergyBarJingRan.SpecialEnergyBarJingRanFishPanel> FishPanelList = new List<SpecialEnergyBarJingRan.SpecialEnergyBarJingRanFishPanel>(SpecialEnergyBarJingRan.MAX_FISH_NUM);

		// Token: 0x04023104 RID: 143620
		private FRotator TmpRotation;

		// Token: 0x04023105 RID: 143621
		private float CurFishNum;

		// Token: 0x04023106 RID: 143622
		private float RemainingRotDegree;

		// Token: 0x04023107 RID: 143623
		private bool IsLightState;

		// Token: 0x04023108 RID: 143624
		private bool IsFireState;

		// Token: 0x04023109 RID: 143625
		private bool IsWaitingSlotAnim;

		// Token: 0x0402310A RID: 143626
		private bool IsStateDirty;

		// Token: 0x0402310B RID: 143627
		[Nullable(2)]
		private IActiveBuff Buff;

		// Token: 0x0402310C RID: 143628
		private int BuffHandle;

		// Token: 0x0402310D RID: 143629
		private bool IsPlayWarnAnim;

		// Token: 0x0402310E RID: 143630
		private bool IsInStrengthState;

		// Token: 0x0200C1EE RID: 49646
		private enum EChildType
		{
			// Token: 0x0403BBBD RID: 244669
			PnlStateA,
			// Token: 0x0403BBBE RID: 244670
			BarSlotA,
			// Token: 0x0403BBBF RID: 244671
			PnlStateB,
			// Token: 0x0403BBC0 RID: 244672
			BarSlotB,
			// Token: 0x0403BBC1 RID: 244673
			PnlFish1,
			// Token: 0x0403BBC2 RID: 244674
			PnlFish2,
			// Token: 0x0403BBC3 RID: 244675
			PnlFish3,
			// Token: 0x0403BBC4 RID: 244676
			AniNsLoop,
			// Token: 0x0403BBC5 RID: 244677
			AniNsSingle,
			// Token: 0x0403BBC6 RID: 244678
			AniNsFull,
			// Token: 0x0403BBC7 RID: 244679
			PnlRot,
			// Token: 0x0403BBC8 RID: 244680
			FishBgYin,
			// Token: 0x0403BBC9 RID: 244681
			FishBgYang,
			// Token: 0x0403BBCA RID: 244682
			AniNsLoopYang,
			// Token: 0x0403BBCB RID: 244683
			AniNsFullYang,
			// Token: 0x0403BBCC RID: 244684
			AniNsSingleYang,
			// Token: 0x0403BBCD RID: 244685
			PnlDarkYang,
			// Token: 0x0403BBCE RID: 244686
			PnlLightYang,
			// Token: 0x0403BBCF RID: 244687
			PnlDarkYin,
			// Token: 0x0403BBD0 RID: 244688
			PnlLightYin,
			// Token: 0x0403BBD1 RID: 244689
			AniNsFireYang,
			// Token: 0x0403BBD2 RID: 244690
			AniNsFireYin,
			// Token: 0x0403BBD3 RID: 244691
			AnimWarning
		}

		// Token: 0x0200C1EF RID: 49647
		public enum EState
		{
			// Token: 0x0403BBD5 RID: 244693
			Yin,
			// Token: 0x0403BBD6 RID: 244694
			Yang,
			// Token: 0x0403BBD7 RID: 244695
			Max
		}

		// Token: 0x0200C1F0 RID: 49648
		public enum EFishState
		{
			// Token: 0x0403BBD9 RID: 244697
			Empty,
			// Token: 0x0403BBDA RID: 244698
			Half,
			// Token: 0x0403BBDB RID: 244699
			Full
		}

		// Token: 0x0200C1F1 RID: 49649
		private class SpecialEnergyBarJingRanFishPanel : UiPanelBase
		{
			// Token: 0x0604E5AD RID: 320941 RVA: 0x015B7A78 File Offset: 0x015B5C78
			protected unsafe override void OnRegisterComponent()
			{
				int num = 6;
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
				this.ComponentRegisterInfos = list;
			}

			// Token: 0x0604E5AE RID: 320942 RVA: 0x015B7B68 File Offset: 0x015B5D68
			public void SetFishState(SpecialEnergyBarJingRan.EState roleState, SpecialEnergyBarJingRan.EFishState fishState)
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(roleState == SpecialEnergyBarJingRan.EState.Yang);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(roleState == SpecialEnergyBarJingRan.EState.Yin);
				}
				UUIItem item3 = base.GetItem(2);
				if (item3 != null)
				{
					item3.SetUIActive(fishState != SpecialEnergyBarJingRan.EFishState.Empty && roleState == SpecialEnergyBarJingRan.EState.Yin);
				}
				UUIItem item4 = base.GetItem(5);
				if (item4 != null)
				{
					item4.SetUIActive(fishState != SpecialEnergyBarJingRan.EFishState.Empty && roleState == SpecialEnergyBarJingRan.EState.Yang);
				}
				UUIItem item5 = base.GetItem(3);
				if (item5 != null)
				{
					item5.SetUIActive(fishState == SpecialEnergyBarJingRan.EFishState.Full && roleState == SpecialEnergyBarJingRan.EState.Yin);
				}
				UUIItem item6 = base.GetItem(4);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(fishState == SpecialEnergyBarJingRan.EFishState.Full && roleState == SpecialEnergyBarJingRan.EState.Yang);
			}

			// Token: 0x0200CF62 RID: 53090
			private enum EFishChildType
			{
				// Token: 0x0403FE0B RID: 261643
				EmptyYellow,
				// Token: 0x0403FE0C RID: 261644
				EmptyBlue,
				// Token: 0x0403FE0D RID: 261645
				FishHalfYin,
				// Token: 0x0403FE0E RID: 261646
				FishFullYin,
				// Token: 0x0403FE0F RID: 261647
				FishFullYang,
				// Token: 0x0403FE10 RID: 261648
				FishHalfYang
			}
		}
	}
}
