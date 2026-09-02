using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060BB RID: 24763
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarJiaBeiLiNa : SpecialEnergyBarBase
	{
		// Token: 0x0603E896 RID: 256150 RVA: 0x00FFDE0C File Offset: 0x00FFC00C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E897 RID: 256151 RVA: 0x00FFE007 File Offset: 0x00FFC207
		protected override void OnInitData()
		{
			this.MorphConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(120801);
			this.SubConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(120802);
		}

		// Token: 0x0603E898 RID: 256152 RVA: 0x00FFE03D File Offset: 0x00FFC23D
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarJiaBeiLiNa.MorphTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnMorphTagChange));
			base.ListenForTagAddOrRemoveChanged(this.SubConfig.KeyEnableTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChange));
		}

		// Token: 0x0603E899 RID: 256153 RVA: 0x00FFE079 File Offset: 0x00FFC279
		private void OnMorphTagChange(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarJiaBeiLiNa.EState.Morph : SpecialEnergyBarJiaBeiLiNa.EState.Normal, false);
		}

		// Token: 0x0603E89A RID: 256154 RVA: 0x00FFE089 File Offset: 0x00FFC289
		private void OnSubTagChange(int tagId, bool tagExist)
		{
			this.ShowSubBar = tagExist;
		}

		// Token: 0x0603E89B RID: 256155 RVA: 0x00FFE094 File Offset: 0x00FFC294
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarJiaBeiLiNa.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarJiaBeiLiNa.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E89C RID: 256156 RVA: 0x00FFE0D8 File Offset: 0x00FFC2D8
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarJiaBeiLiNa.<InitBarItem>d__22 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarJiaBeiLiNa.<InitBarItem>d__22>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E89D RID: 256157 RVA: 0x00FFE11C File Offset: 0x00FFC31C
		protected override void OnStart()
		{
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.PlayTweenAnim(8);
			for (int i = 0; i < this.FullStateList.Length; i++)
			{
				if (this.FullStateList[i])
				{
					base.PlayTweenAnim((i == 0) ? 9 : 10);
				}
			}
			this.RefreshState(true);
			this.OnBarPercentChanged();
			this.RefreshSubBarPercent(true);
		}

		// Token: 0x0603E89E RID: 256158 RVA: 0x00FFE197 File Offset: 0x00FFC397
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			UUINiagara uiNiagara = base.GetUiNiagara(13);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(false);
		}

		// Token: 0x0603E89F RID: 256159 RVA: 0x00FFE1B4 File Offset: 0x00FFC3B4
		private void RefreshSubBarPercent(bool isStart = false)
		{
			float num = 0f;
			if (this.ShowSubBar)
			{
				if (this.Buff != null)
				{
					CharacterBuffComponent buffComponent = this.BuffComponent;
					if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
					{
						goto IL_36;
					}
				}
				this.RefreshBuff();
				IL_36:
				if (this.Buff != null)
				{
					num = this.Buff.GetRemainDuration() / this.Buff.Duration;
				}
			}
			if (num == this.SubBarPercent && !isStart)
			{
				return;
			}
			this.SubBarPercent = num;
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetFillAmount(num);
			}
			UUISprite sprite2 = base.GetSprite(2);
			if (sprite2 != null)
			{
				sprite2.SetFillAmount(num);
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetAnchorOffsetX(320f * (num - 0.5f));
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 == null)
			{
				return;
			}
			item2.SetAnchorOffsetX(289f * (num - 0.5f));
		}

		// Token: 0x0603E8A0 RID: 256160 RVA: 0x00FFE290 File Offset: 0x00FFC490
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarJiaBeiLiNa.MorphTagId))
			{
				this.SetState(SpecialEnergyBarJiaBeiLiNa.EState.Morph, isStart);
			}
			else
			{
				this.SetState(SpecialEnergyBarJiaBeiLiNa.EState.Normal, isStart);
			}
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.ShowSubBar = (tagComponent2 != null && tagComponent2.HasTag(this.SubConfig.KeyEnableTagId));
		}

		// Token: 0x0603E8A1 RID: 256161 RVA: 0x00FFE2EC File Offset: 0x00FFC4EC
		private void SetState(SpecialEnergyBarJiaBeiLiNa.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			this.CurState = state;
			SpecialEnergyBarJiaBeiLiNa.EState curState = this.CurState;
			if (curState != SpecialEnergyBarJiaBeiLiNa.EState.Normal)
			{
				if (curState != SpecialEnergyBarJiaBeiLiNa.EState.Morph)
				{
					return;
				}
				if (!isStart)
				{
					base.StopTweenAnim(12);
				}
				base.PlayTweenAnim(11);
			}
			else if (!isStart)
			{
				base.StopTweenAnim(11);
				base.PlayTweenAnim(12);
				return;
			}
		}

		// Token: 0x0603E8A2 RID: 256162 RVA: 0x00FFE344 File Offset: 0x00FFC544
		private void OnPercentCallback(int index, float percent)
		{
			bool flag = percent >= 1f;
			if (this.FullStateList[index] != flag)
			{
				this.FullStateList[index] = flag;
				if (flag)
				{
					base.PlayTweenAnim((index == 0) ? 9 : 10);
				}
			}
		}

		// Token: 0x0603E8A3 RID: 256163 RVA: 0x00FFE383 File Offset: 0x00FFC583
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarJiaBeiLiNaSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal != null)
			{
				barItemNormal.Tick(delta);
			}
			SpecialEnergyBarJiaBeiLiNaMorphSlot barItemMorph = this.BarItemMorph;
			if (barItemMorph != null)
			{
				barItemMorph.Tick(delta);
			}
			this.RefreshSubBarPercent(false);
		}

		// Token: 0x0603E8A4 RID: 256164 RVA: 0x00FFE3B8 File Offset: 0x00FFC5B8
		private void RefreshBuff()
		{
			SpecialEnergyBarInfo subConfig = this.SubConfig;
			bool flag;
			if (subConfig == null)
			{
				flag = false;
			}
			else
			{
				long buffId = subConfig.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				ActiveBuffInternal buff;
				if ((buff = ((buffComponent != null) ? buffComponent.GetBuffById(1208003423L) : null)) == null)
				{
					CharacterBuffComponent buffComponent2 = this.BuffComponent;
					buff = ((buffComponent2 != null) ? buffComponent2.GetBuffById(this.SubConfig.BuffId) : null);
				}
				this.Buff = buff;
				IActiveBuff buff2 = this.Buff;
				this.BuffHandle = ((buff2 != null) ? buff2.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x040230E3 RID: 143587
		private const int MORPH_CONFIG_ID = 120801;

		// Token: 0x040230E4 RID: 143588
		private const int SUB_CONFIG_ID = 120802;

		// Token: 0x040230E5 RID: 143589
		[StaticVariableRuleIgnore]
		private static readonly int MorphTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1CalbrenaMd10011.状态标识.强化状态"];

		// Token: 0x040230E6 RID: 143590
		private const int EXTRA_SUB_BUFF_ID = 1208003423;

		// Token: 0x040230E7 RID: 143591
		private SpecialEnergyBarInfo MorphConfig;

		// Token: 0x040230E8 RID: 143592
		private SpecialEnergyBarInfo SubConfig;

		// Token: 0x040230E9 RID: 143593
		private SpecialEnergyBarJiaBeiLiNaSlot BarItemNormal;

		// Token: 0x040230EA RID: 143594
		private SpecialEnergyBarJiaBeiLiNaMorphSlot BarItemMorph;

		// Token: 0x040230EB RID: 143595
		private SpecialEnergyBarJiaBeiLiNa.EState CurState;

		// Token: 0x040230EC RID: 143596
		private IActiveBuff Buff;

		// Token: 0x040230ED RID: 143597
		private int BuffHandle;

		// Token: 0x040230EE RID: 143598
		private bool ShowSubBar;

		// Token: 0x040230EF RID: 143599
		private float SubBarPercent = -1f;

		// Token: 0x040230F0 RID: 143600
		[Nullable(1)]
		private readonly bool[] FullStateList = new bool[2];

		// Token: 0x0200C1EA RID: 49642
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BBA3 RID: 244643
			MorphItem,
			// Token: 0x0403BBA4 RID: 244644
			SlotBarItemMorph,
			// Token: 0x0403BBA5 RID: 244645
			MorphExtraBarSprite,
			// Token: 0x0403BBA6 RID: 244646
			MorphExtraBarLightItem,
			// Token: 0x0403BBA7 RID: 244647
			NormalItem,
			// Token: 0x0403BBA8 RID: 244648
			SlotBarItemNormal,
			// Token: 0x0403BBA9 RID: 244649
			ExtraBarSprite,
			// Token: 0x0403BBAA RID: 244650
			ExtraBarLightItem,
			// Token: 0x0403BBAB RID: 244651
			AniDefault,
			// Token: 0x0403BBAC RID: 244652
			AniRed,
			// Token: 0x0403BBAD RID: 244653
			AniBlue,
			// Token: 0x0403BBAE RID: 244654
			AniMorphIn,
			// Token: 0x0403BBAF RID: 244655
			AniMorphOut,
			// Token: 0x0403BBB0 RID: 244656
			MorphEffect
		}

		// Token: 0x0200C1EB RID: 49643
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BBB2 RID: 244658
			Normal,
			// Token: 0x0403BBB3 RID: 244659
			Morph
		}
	}
}
