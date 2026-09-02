using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060EF RID: 24815
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarZanni : SpecialEnergyBarBase
	{
		// Token: 0x0603EB12 RID: 256786 RVA: 0x0100CADC File Offset: 0x0100ACDC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EB13 RID: 256787 RVA: 0x0100CCD7 File Offset: 0x0100AED7
		protected override void OnInitData()
		{
			this.MorphConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(150701);
			this.AttributeId = (EAttributeType)this.MorphConfig.AttributeId;
			this.MaxAttributeId = (EAttributeType)this.MorphConfig.MaxAttributeId;
		}

		// Token: 0x0603EB14 RID: 256788 RVA: 0x0100CD15 File Offset: 0x0100AF15
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1ZanniMd10011.技能标识.认真状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChange));
		}

		// Token: 0x0603EB15 RID: 256789 RVA: 0x0100CD3E File Offset: 0x0100AF3E
		private void OnMorphTagChange(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarZanni.EState.Morph : SpecialEnergyBarZanni.EState.Normal, false);
		}

		// Token: 0x0603EB16 RID: 256790 RVA: 0x0100CD50 File Offset: 0x0100AF50
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarZanni.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarZanni.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB17 RID: 256791 RVA: 0x0100CD94 File Offset: 0x0100AF94
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarZanni.<InitBarItem>d__16 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarZanni.<InitBarItem>d__16>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB18 RID: 256792 RVA: 0x0100CDD8 File Offset: 0x0100AFD8
		protected override void OnStart()
		{
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			this.RefreshState(true);
			this.OnBarPercentChanged();
		}

		// Token: 0x0603EB19 RID: 256793 RVA: 0x0100CE2F File Offset: 0x0100B02F
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(11);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603EB1A RID: 256794 RVA: 0x0100CE40 File Offset: 0x0100B040
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount(curPercent);
			}
			bool flag = curPercent >= this.MorphConfig.ExtraFloatParams[1];
			if (this.InDrive == flag)
			{
				return;
			}
			this.InDrive = flag;
			base.PlayTweenAnim(flag ? 9 : 10);
		}

		// Token: 0x0603EB1B RID: 256795 RVA: 0x0100CEA4 File Offset: 0x0100B0A4
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1ZanniMd10011.技能标识.认真状态"]))
			{
				this.SetState(SpecialEnergyBarZanni.EState.Morph, isStart);
				return;
			}
			this.SetState(SpecialEnergyBarZanni.EState.Normal, isStart);
		}

		// Token: 0x0603EB1C RID: 256796 RVA: 0x0100CEDC File Offset: 0x0100B0DC
		private void SetState(SpecialEnergyBarZanni.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			this.CurState = state;
			SpecialEnergyBarZanni.EState curState = this.CurState;
			if (curState != SpecialEnergyBarZanni.EState.Normal)
			{
				if (curState != SpecialEnergyBarZanni.EState.Morph)
				{
					return;
				}
				if (!isStart)
				{
					base.PlayTweenAnim(7);
					return;
				}
				UUIItem item = base.GetItem(5);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(6);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(true);
				return;
			}
			else
			{
				if (!isStart)
				{
					base.PlayTweenAnim(8);
					return;
				}
				UUIItem item3 = base.GetItem(5);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(6);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603EB1D RID: 256797 RVA: 0x0100CF70 File Offset: 0x0100B170
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarZanniSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal != null)
			{
				barItemNormal.Tick(delta);
			}
			SpecialEnergyBarZanniSlot barItemMorph = this.BarItemMorph;
			if (barItemMorph != null)
			{
				barItemMorph.Tick(delta);
			}
			if (this.CurState == SpecialEnergyBarZanni.EState.Normal)
			{
				this.PlayWarnAnim(false);
				return;
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_63;
				}
			}
			this.RefreshBuff();
			IL_63:
			if (this.Buff != null)
			{
				this.PlayWarnAnim(this.Buff.GetRemainDuration() < this.MorphConfig.ExtraFloatParams[0]);
			}
		}

		// Token: 0x0603EB1E RID: 256798 RVA: 0x0100D00C File Offset: 0x0100B20C
		private void RefreshBuff()
		{
			SpecialEnergyBarInfo morphConfig = this.MorphConfig;
			bool flag;
			if (morphConfig == null)
			{
				flag = false;
			}
			else
			{
				long buffId = morphConfig.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.MorphConfig.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603EB1F RID: 256799 RVA: 0x0100D079 File Offset: 0x0100B279
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(11);
				return;
			}
			base.StopTweenAnim(11);
			UUIItem item = base.GetItem(6);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(1f);
		}

		// Token: 0x0402328D RID: 144013
		private const int MORPH_CONFIG_ID = 150701;

		// Token: 0x0402328E RID: 144014
		private SpecialEnergyBarInfo MorphConfig;

		// Token: 0x0402328F RID: 144015
		private SpecialEnergyBarZanniSlot BarItemNormal;

		// Token: 0x04023290 RID: 144016
		private SpecialEnergyBarZanniSlot BarItemMorph;

		// Token: 0x04023291 RID: 144017
		private SpecialEnergyBarZanni.EState CurState;

		// Token: 0x04023292 RID: 144018
		private IActiveBuff Buff;

		// Token: 0x04023293 RID: 144019
		private int BuffHandle;

		// Token: 0x04023294 RID: 144020
		private bool IsPlayWarnAnim;

		// Token: 0x04023295 RID: 144021
		private bool InDrive;

		// Token: 0x0200C269 RID: 49769
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BEF2 RID: 245490
			Normal,
			// Token: 0x0403BEF3 RID: 245491
			Morph
		}

		// Token: 0x0200C26A RID: 49770
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BEF5 RID: 245493
			SlotBarItemNormal,
			// Token: 0x0403BEF6 RID: 245494
			BarSprite,
			// Token: 0x0403BEF7 RID: 245495
			ActivateItem,
			// Token: 0x0403BEF8 RID: 245496
			SlotBarItemMorph,
			// Token: 0x0403BEF9 RID: 245497
			ArrowItem,
			// Token: 0x0403BEFA RID: 245498
			NormalItem,
			// Token: 0x0403BEFB RID: 245499
			MorphItem,
			// Token: 0x0403BEFC RID: 245500
			AniMorphIn,
			// Token: 0x0403BEFD RID: 245501
			AniMorphOut,
			// Token: 0x0403BEFE RID: 245502
			AnimDriveIn,
			// Token: 0x0403BEFF RID: 245503
			AnimDriveOut,
			// Token: 0x0403BF00 RID: 245504
			AnimWarning,
			// Token: 0x0403BF01 RID: 245505
			DarkLeftItem,
			// Token: 0x0403BF02 RID: 245506
			DarkRightItem
		}
	}
}
