using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C2 RID: 24770
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarKanTeLeiLa : SpecialEnergyBarBase
	{
		// Token: 0x0603E8ED RID: 256237 RVA: 0x00FFFCBC File Offset: 0x00FFDEBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 25;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E8EE RID: 256238 RVA: 0x01000030 File Offset: 0x00FFE230
		protected override void OnInitData()
		{
			this.NormalConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(160701);
			this.PinkConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(160702);
			this.ColorfulConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(160703);
		}

		// Token: 0x0603E8EF RID: 256239 RVA: 0x0100008C File Offset: 0x00FFE28C
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1KanteleilaMd10011.状态标识.强化状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnDrownTagChange));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1KanteleilaMd10011.状态标识.普通状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnFinisherTagChange));
		}

		// Token: 0x0603E8F0 RID: 256240 RVA: 0x010000E1 File Offset: 0x00FFE2E1
		private void OnDrownTagChange(int tagId, bool tagExist)
		{
			this.NeedRefreshState = true;
		}

		// Token: 0x0603E8F1 RID: 256241 RVA: 0x010000EA File Offset: 0x00FFE2EA
		private void OnFinisherTagChange(int tagId, bool tagExist)
		{
			this.NeedRefreshState = true;
		}

		// Token: 0x0603E8F2 RID: 256242 RVA: 0x010000F4 File Offset: 0x00FFE2F4
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKanTeLeiLa.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKanTeLeiLa.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8F3 RID: 256243 RVA: 0x01000138 File Offset: 0x00FFE338
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarKanTeLeiLa.<InitBarItem>d__27 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarKanTeLeiLa.<InitBarItem>d__27>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E8F4 RID: 256244 RVA: 0x0100017C File Offset: 0x00FFE37C
		protected override void OnStart()
		{
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			base.InitTweenAnim(17);
			base.InitTweenAnim(18);
			base.InitTweenAnim(19);
			base.InitTweenAnim(20);
			base.InitTweenAnim(21);
			base.InitTweenAnim(22);
			base.InitTweenAnim(24);
			this.PointItemsA.Add(base.GetItem(0));
			this.PointItemsA.Add(base.GetItem(1));
			this.PointItemsA.Add(base.GetItem(2));
			this.PointItemsB.Add(base.GetItem(3));
			this.PointItemsB.Add(base.GetItem(4));
			this.PointItemsB.Add(base.GetItem(5));
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			this.RefreshState(true);
			this.RefreshPointItems(true);
		}

		// Token: 0x0603E8F5 RID: 256245 RVA: 0x01000272 File Offset: 0x00FFE472
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(18);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E8F6 RID: 256246 RVA: 0x01000282 File Offset: 0x00FFE482
		protected override void OnAttributeChanged()
		{
			this.RefreshPointItems(false);
		}

		// Token: 0x0603E8F7 RID: 256247 RVA: 0x0100028B File Offset: 0x00FFE48B
		protected override void OnMaxAttributeChanged()
		{
		}

		// Token: 0x0603E8F8 RID: 256248 RVA: 0x01000290 File Offset: 0x00FFE490
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			bool flag = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1KanteleilaMd10011.状态标识.普通状态"]);
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1KanteleilaMd10011.状态标识.强化状态"]))
			{
				if (flag)
				{
					this.SetState(SpecialEnergyBarKanTeLeiLa.EState.Pink, isStart);
				}
				else
				{
					this.SetState(SpecialEnergyBarKanTeLeiLa.EState.Colorful, isStart);
				}
			}
			else
			{
				this.SetState(SpecialEnergyBarKanTeLeiLa.EState.Normal, isStart);
			}
			if (this.IsInCd != flag || isStart)
			{
				this.IsInCd = flag;
				this.RefreshNormalEffect(isStart);
			}
		}

		// Token: 0x0603E8F9 RID: 256249 RVA: 0x01000320 File Offset: 0x00FFE520
		private void RefreshNormalEffect(bool isStart = false)
		{
			bool flag = !this.IsInCd;
			if (!isStart && this.CurState == SpecialEnergyBarKanTeLeiLa.EState.Normal)
			{
				if (flag)
				{
					base.PlayTweenAnim(24);
				}
				return;
			}
			UUIItem item = base.GetItem(23);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(23);
			if (item2 == null)
			{
				return;
			}
			item2.SetAlpha(flag > false);
		}

		// Token: 0x0603E8FA RID: 256250 RVA: 0x0100037C File Offset: 0x00FFE57C
		private void SetState(SpecialEnergyBarKanTeLeiLa.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			SpecialEnergyBarKanTeLeiLa.EState curState = this.CurState;
			this.CurState = state;
			switch (this.CurState)
			{
			case SpecialEnergyBarKanTeLeiLa.EState.Normal:
				if (!isStart)
				{
					base.StopTweenAnim(13);
					base.PlayTweenAnim(14);
					if (curState == SpecialEnergyBarKanTeLeiLa.EState.Colorful)
					{
						base.StopTweenAnim(15);
						base.PlayTweenAnim(16);
					}
				}
				else
				{
					UUIItem item = base.GetItem(6);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					UUIItem item2 = base.GetItem(7);
					if (item2 != null)
					{
						item2.SetUIActive(false);
					}
				}
				break;
			case SpecialEnergyBarKanTeLeiLa.EState.Pink:
			{
				UUIItem item3 = base.GetItem(9);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				UUIItem item4 = base.GetItem(8);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				UUIItem item5 = base.GetItem(8);
				if (item5 != null)
				{
					item5.SetAlpha(1f);
				}
				if (!isStart)
				{
					if (curState == SpecialEnergyBarKanTeLeiLa.EState.Normal)
					{
						base.StopTweenAnim(14);
						base.PlayTweenAnim(13);
						UUIItem item6 = base.GetItem(9);
						if (item6 != null)
						{
							item6.SetUIActive(false);
						}
						UUIItem item7 = base.GetItem(8);
						if (item7 != null)
						{
							item7.SetUIActive(true);
						}
					}
					else
					{
						base.StopTweenAnim(15);
						base.PlayTweenAnim(16);
					}
				}
				else
				{
					UUIItem item8 = base.GetItem(6);
					if (item8 != null)
					{
						item8.SetUIActive(false);
					}
					UUIItem item9 = base.GetItem(7);
					if (item9 != null)
					{
						item9.SetUIActive(true);
					}
				}
				break;
			}
			case SpecialEnergyBarKanTeLeiLa.EState.Colorful:
				if (!isStart)
				{
					if (curState == SpecialEnergyBarKanTeLeiLa.EState.Normal)
					{
						base.StopTweenAnim(14);
						base.PlayTweenAnim(13);
						UUIItem item10 = base.GetItem(9);
						if (item10 != null)
						{
							item10.SetUIActive(true);
						}
						UUIItem item11 = base.GetItem(8);
						if (item11 != null)
						{
							item11.SetUIActive(false);
						}
					}
					base.StopTweenAnim(16);
					base.PlayTweenAnim(15);
				}
				else
				{
					UUIItem item12 = base.GetItem(6);
					if (item12 != null)
					{
						item12.SetUIActive(false);
					}
					UUIItem item13 = base.GetItem(7);
					if (item13 != null)
					{
						item13.SetUIActive(true);
					}
					UUIItem item14 = base.GetItem(9);
					if (item14 != null)
					{
						item14.SetUIActive(true);
					}
					UUIItem item15 = base.GetItem(8);
					if (item15 != null)
					{
						item15.SetUIActive(false);
					}
				}
				break;
			}
			if (!isStart && (curState == SpecialEnergyBarKanTeLeiLa.EState.Colorful || this.CurState == SpecialEnergyBarKanTeLeiLa.EState.Colorful))
			{
				this.RefreshPointItems(true);
				if (this.CurState == SpecialEnergyBarKanTeLeiLa.EState.Colorful)
				{
					base.PlayTweenAnim(19);
				}
			}
		}

		// Token: 0x0603E8FB RID: 256251 RVA: 0x010005AC File Offset: 0x00FFE7AC
		private void RefreshPointItems(bool bForce = false)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(this.AttributeId);
			if (!bForce && this.LastPointCount == currentValue)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				bool flag = currentValue > (float)i;
				bool flag2 = this.CurState == SpecialEnergyBarKanTeLeiLa.EState.Colorful && currentValue == 3f;
				this.PointItemsA[i].SetUIActive(flag && !flag2);
				this.PointItemsB[i].SetUIActive(flag && flag2);
				if (flag && this.LastPointCount <= (float)i)
				{
					base.PlayTweenAnim(20 + i);
				}
			}
			if (currentValue < this.LastPointCount)
			{
				base.PlayTweenAnim(17);
			}
			this.LastPointCount = currentValue;
		}

		// Token: 0x0603E8FC RID: 256252 RVA: 0x01000660 File Offset: 0x00FFE860
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarKanTeLeiLaSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal != null)
			{
				barItemNormal.Tick(delta);
			}
			SpecialEnergyBarKanTeLeiLaSlot barItemPink = this.BarItemPink;
			if (barItemPink != null)
			{
				barItemPink.Tick(delta);
			}
			SpecialEnergyBarKanTeLeiLaSlot barItemColorful = this.BarItemColorful;
			if (barItemColorful != null)
			{
				barItemColorful.Tick(delta);
			}
			if (this.NeedRefreshState)
			{
				this.RefreshState(false);
				this.NeedRefreshState = false;
			}
			if (this.CurState == SpecialEnergyBarKanTeLeiLa.EState.Normal)
			{
				this.PlayWarnAnim(false);
				return;
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_8B;
				}
			}
			this.RefreshBuff();
			IL_8B:
			if (this.Buff != null)
			{
				this.PlayWarnAnim(this.Buff.GetRemainDuration() < this.Config.ExtraFloatParams[0]);
			}
		}

		// Token: 0x0603E8FD RID: 256253 RVA: 0x01000724 File Offset: 0x00FFE924
		private void RefreshBuff()
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

		// Token: 0x0603E8FE RID: 256254 RVA: 0x01000791 File Offset: 0x00FFE991
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(18);
				return;
			}
			base.StopTweenAnim(18);
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(1f);
		}

		// Token: 0x0402311D RID: 143645
		private const int NORMAL_CONFIG_ID = 160701;

		// Token: 0x0402311E RID: 143646
		private const int PINK_CONFIG_ID = 160702;

		// Token: 0x0402311F RID: 143647
		private const int COLORFUL_CONFIG_ID = 160703;

		// Token: 0x04023120 RID: 143648
		private const int POINT_NUM = 3;

		// Token: 0x04023121 RID: 143649
		private SpecialEnergyBarInfo NormalConfig;

		// Token: 0x04023122 RID: 143650
		private SpecialEnergyBarInfo PinkConfig;

		// Token: 0x04023123 RID: 143651
		private SpecialEnergyBarInfo ColorfulConfig;

		// Token: 0x04023124 RID: 143652
		private SpecialEnergyBarKanTeLeiLaSlot BarItemNormal;

		// Token: 0x04023125 RID: 143653
		private SpecialEnergyBarKanTeLeiLaSlot BarItemPink;

		// Token: 0x04023126 RID: 143654
		private SpecialEnergyBarKanTeLeiLaSlot BarItemColorful;

		// Token: 0x04023127 RID: 143655
		[Nullable(1)]
		private readonly List<UUIItem> PointItemsA = new List<UUIItem>();

		// Token: 0x04023128 RID: 143656
		[Nullable(1)]
		private readonly List<UUIItem> PointItemsB = new List<UUIItem>();

		// Token: 0x04023129 RID: 143657
		private float LastPointCount;

		// Token: 0x0402312A RID: 143658
		private SpecialEnergyBarKanTeLeiLa.EState CurState;

		// Token: 0x0402312B RID: 143659
		private IActiveBuff Buff;

		// Token: 0x0402312C RID: 143660
		private int BuffHandle;

		// Token: 0x0402312D RID: 143661
		private bool IsPlayWarnAnim;

		// Token: 0x0402312E RID: 143662
		private bool IsInCd;

		// Token: 0x0402312F RID: 143663
		private bool NeedRefreshState;

		// Token: 0x0200C1F7 RID: 49655
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BBF4 RID: 244724
			PointA1Item,
			// Token: 0x0403BBF5 RID: 244725
			PointA2Item,
			// Token: 0x0403BBF6 RID: 244726
			PointA3Item,
			// Token: 0x0403BBF7 RID: 244727
			PointB1Item,
			// Token: 0x0403BBF8 RID: 244728
			PointB2Item,
			// Token: 0x0403BBF9 RID: 244729
			PointB3Item,
			// Token: 0x0403BBFA RID: 244730
			NormalItem,
			// Token: 0x0403BBFB RID: 244731
			DrownItem,
			// Token: 0x0403BBFC RID: 244732
			PinkItem,
			// Token: 0x0403BBFD RID: 244733
			ColorfulItem,
			// Token: 0x0403BBFE RID: 244734
			SlotBarItemNormal,
			// Token: 0x0403BBFF RID: 244735
			SlotBarItemPink,
			// Token: 0x0403BC00 RID: 244736
			SlotBarItemColorful,
			// Token: 0x0403BC01 RID: 244737
			AnimDrownIn,
			// Token: 0x0403BC02 RID: 244738
			AnimDrownOut,
			// Token: 0x0403BC03 RID: 244739
			AnimColorfulIn,
			// Token: 0x0403BC04 RID: 244740
			AnimColorfulOut,
			// Token: 0x0403BC05 RID: 244741
			AnimBurst,
			// Token: 0x0403BC06 RID: 244742
			AnimWarning,
			// Token: 0x0403BC07 RID: 244743
			AnimCoreIn,
			// Token: 0x0403BC08 RID: 244744
			AnimPoint1,
			// Token: 0x0403BC09 RID: 244745
			AnimPoint2,
			// Token: 0x0403BC0A RID: 244746
			AnimPoint3,
			// Token: 0x0403BC0B RID: 244747
			ExtraItem,
			// Token: 0x0403BC0C RID: 244748
			AnimPreColorful
		}

		// Token: 0x0200C1F8 RID: 49656
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BC0E RID: 244750
			Normal,
			// Token: 0x0403BC0F RID: 244751
			Pink,
			// Token: 0x0403BC10 RID: 244752
			Colorful
		}
	}
}
