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
	// Token: 0x020060C4 RID: 24772
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarKaTiXiYa : SpecialEnergyBarBase
	{
		// Token: 0x0603E902 RID: 256258 RVA: 0x01000868 File Offset: 0x00FFEA68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E903 RID: 256259 RVA: 0x01000AEB File Offset: 0x00FFECEB
		protected override void OnInitData()
		{
			this.BigConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(140901);
			this.AttributeId = (EAttributeType)this.BigConfig.AttributeId;
			this.MaxAttributeId = (EAttributeType)this.BigConfig.MaxAttributeId;
		}

		// Token: 0x0603E904 RID: 256260 RVA: 0x01000B2C File Offset: 0x00FFED2C
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.凭依时间"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltraTagChange));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.Katixiya.解放状态.状态.大形态标记"], new BaseTagComponent.TTagSwitchedCallback(this.OnAdultTagChange));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.Katixiya.技能.大招变身"], new BaseTagComponent.TTagSwitchedCallback(this.OnUltarSkillTagChange));
		}

		// Token: 0x0603E905 RID: 256261 RVA: 0x01000BA2 File Offset: 0x00FFEDA2
		private void OnUltraTagChange(int tagId, bool tagExist)
		{
			this.SetUltraState(tagExist, false);
		}

		// Token: 0x0603E906 RID: 256262 RVA: 0x01000BAC File Offset: 0x00FFEDAC
		private void OnAdultTagChange(int tagId, bool tagExist)
		{
			this.SetAdultState(tagExist, false);
		}

		// Token: 0x0603E907 RID: 256263 RVA: 0x01000BB6 File Offset: 0x00FFEDB6
		private void OnUltarSkillTagChange(int tagId, bool tagExist)
		{
			this.SetUltraSkillState(tagExist, false);
		}

		// Token: 0x0603E908 RID: 256264 RVA: 0x01000BC0 File Offset: 0x00FFEDC0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKaTiXiYa.<OnBeforeStartAsync>d__24 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKaTiXiYa.<OnBeforeStartAsync>d__24>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E909 RID: 256265 RVA: 0x01000C04 File Offset: 0x00FFEE04
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarKaTiXiYa.<InitBarItem>d__25 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarKaTiXiYa.<InitBarItem>d__25>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E90A RID: 256266 RVA: 0x01000C48 File Offset: 0x00FFEE48
		protected override void OnStart()
		{
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetAlpha(1f);
			}
			UUIItem item3 = base.GetItem(17);
			if (item3 != null)
			{
				item3.SetAlpha(1f);
			}
			UUIItem item4 = base.GetItem(2);
			if (item4 != null)
			{
				item4.SetAlpha(1f);
			}
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetUltraState(tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.凭依时间"]), true);
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.SetAdultState(tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.Katixiya.解放状态.状态.大形态标记"]), true);
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.SetUltraSkillState(tagComponent3 != null && tagComponent3.HasTag(GameplayTagDefine.EGameplayTagId["角色.Katixiya.技能.大招变身"]), true);
			this.RefreshState(true);
		}

		// Token: 0x0603E90B RID: 256267 RVA: 0x01000D7F File Offset: 0x00FFEF7F
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(15);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E90C RID: 256268 RVA: 0x01000D8F File Offset: 0x00FFEF8F
		private void SetUltraState(bool isUltra, bool isStart = false)
		{
			if (isUltra == this.IsUltra && !isStart)
			{
				return;
			}
			this.IsUltra = isUltra;
			if (!isStart)
			{
				this.RefreshState(false);
			}
		}

		// Token: 0x0603E90D RID: 256269 RVA: 0x01000DAF File Offset: 0x00FFEFAF
		private void SetAdultState(bool isAdult, bool isStart = false)
		{
			if (isAdult == this.IsAdult && !isStart)
			{
				return;
			}
			this.IsAdult = isAdult;
			if (!isStart)
			{
				this.RefreshState(false);
			}
		}

		// Token: 0x0603E90E RID: 256270 RVA: 0x01000DCF File Offset: 0x00FFEFCF
		private void SetUltraSkillState(bool isUltraSkill, bool isStart = false)
		{
			if (isUltraSkill == this.IsUltraSkill && !isStart)
			{
				return;
			}
			this.IsUltraSkill = isUltraSkill;
			if (!isStart)
			{
				this.RefreshState(false);
			}
		}

		// Token: 0x0603E90F RID: 256271 RVA: 0x01000DF0 File Offset: 0x00FFEFF0
		private void RefreshState(bool isStart = false)
		{
			SpecialEnergyBarKaTiXiYa.EState estate = SpecialEnergyBarKaTiXiYa.EState.Small;
			if (this.IsAdult || (this.IsUltraSkill && this.IsUltra))
			{
				estate = SpecialEnergyBarKaTiXiYa.EState.Big;
			}
			else if (this.IsUltra)
			{
				estate = SpecialEnergyBarKaTiXiYa.EState.UltraSmall;
			}
			if (this.State == estate && !isStart)
			{
				return;
			}
			this.State = estate;
			if (isStart)
			{
				switch (this.State)
				{
				case SpecialEnergyBarKaTiXiYa.EState.Small:
					base.PlayTweenAnim(12);
					break;
				case SpecialEnergyBarKaTiXiYa.EState.Big:
					base.PlayTweenAnim(13);
					break;
				case SpecialEnergyBarKaTiXiYa.EState.UltraSmall:
					base.PlayTweenAnim(14);
					break;
				}
				this.LastState = this.State;
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(this.State != SpecialEnergyBarKaTiXiYa.EState.Big);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.State != SpecialEnergyBarKaTiXiYa.EState.Big);
		}

		// Token: 0x0603E910 RID: 256272 RVA: 0x01000EBC File Offset: 0x00FFF0BC
		private void PlayChangeStateAnim()
		{
			if (this.LastState == this.State || (float)Singleton<Time>.Instance.WorldTime < this.NextAnimTime)
			{
				return;
			}
			switch (this.State)
			{
			case SpecialEnergyBarKaTiXiYa.EState.Small:
				if (this.LastState == SpecialEnergyBarKaTiXiYa.EState.Big)
				{
					base.PlayTweenAnim(8);
				}
				else
				{
					base.PlayTweenAnim(11);
				}
				break;
			case SpecialEnergyBarKaTiXiYa.EState.Big:
				if (this.LastState == SpecialEnergyBarKaTiXiYa.EState.Small)
				{
					base.PlayTweenAnim(7);
				}
				else
				{
					base.PlayTweenAnim(10);
				}
				break;
			case SpecialEnergyBarKaTiXiYa.EState.UltraSmall:
				if (this.LastState == SpecialEnergyBarKaTiXiYa.EState.Small)
				{
					base.PlayTweenAnim(14);
				}
				else
				{
					base.PlayTweenAnim(9);
				}
				break;
			}
			this.LastState = this.State;
			this.NextAnimTime = (float)Singleton<Time>.Instance.WorldTime + 500f;
		}

		// Token: 0x0603E911 RID: 256273 RVA: 0x01000F7C File Offset: 0x00FFF17C
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarKaTiXiYaSlot barItemSmall = this.BarItemSmall;
			if (barItemSmall != null)
			{
				barItemSmall.Tick(delta);
			}
			SpecialEnergyBarKaTiXiYaAdultSlot barItemBig = this.BarItemBig;
			if (barItemBig != null)
			{
				barItemBig.Tick(delta);
			}
			this.PlayChangeStateAnim();
			if (!this.IsUltra)
			{
				this.PlayWarnAnim(false);
				using (List<SpecialEnergyBarKaTiXiYaStar>.Enumerator enumerator = this.StarList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SpecialEnergyBarKaTiXiYaStar specialEnergyBarKaTiXiYaStar = enumerator.Current;
						specialEnergyBarKaTiXiYaStar.SetStarNum(0);
					}
					goto IL_16F;
				}
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_9F;
				}
			}
			this.RefreshBuff();
			IL_9F:
			if (this.Buff != null)
			{
				float remainDuration = this.Buff.GetRemainDuration();
				float num = MathF.Ceiling(remainDuration / this.Buff.Duration * 6f);
				this.PlayWarnAnim(this.IsAdult && remainDuration < this.BigConfig.ExtraFloatParams[0] && num <= 1f);
				using (List<SpecialEnergyBarKaTiXiYaStar>.Enumerator enumerator = this.StarList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						SpecialEnergyBarKaTiXiYaStar specialEnergyBarKaTiXiYaStar2 = enumerator.Current;
						specialEnergyBarKaTiXiYaStar2.SetStarNum((int)num);
					}
					goto IL_16F;
				}
			}
			this.PlayWarnAnim(false);
			foreach (SpecialEnergyBarKaTiXiYaStar specialEnergyBarKaTiXiYaStar3 in this.StarList)
			{
				specialEnergyBarKaTiXiYaStar3.SetStarNum(0);
			}
			IL_16F:
			foreach (SpecialEnergyBarKaTiXiYaStar specialEnergyBarKaTiXiYaStar4 in this.StarList)
			{
				specialEnergyBarKaTiXiYaStar4.Tick(delta);
			}
		}

		// Token: 0x0603E912 RID: 256274 RVA: 0x01001160 File Offset: 0x00FFF360
		private void RefreshBuff()
		{
			SpecialEnergyBarInfo bigConfig = this.BigConfig;
			bool flag;
			if (bigConfig == null)
			{
				flag = false;
			}
			else
			{
				long buffId = bigConfig.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.BigConfig.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603E913 RID: 256275 RVA: 0x010011D0 File Offset: 0x00FFF3D0
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(15);
				return;
			}
			base.StopTweenAnim(15);
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetAlpha(1f);
		}

		// Token: 0x0603E914 RID: 256276 RVA: 0x01001230 File Offset: 0x00FFF430
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.PlayBurstAnim(curPercent >= 1f);
		}

		// Token: 0x0603E915 RID: 256277 RVA: 0x0100125A File Offset: 0x00FFF45A
		private void PlayBurstAnim(bool bPlay)
		{
			if (this.IsPlayBurstAnim == bPlay)
			{
				return;
			}
			this.IsPlayBurstAnim = bPlay;
			if (bPlay && this.State == SpecialEnergyBarKaTiXiYa.EState.Big)
			{
				base.PlayTweenAnim(16);
			}
		}

		// Token: 0x04023131 RID: 143665
		private const int ULTRA_CONFIG_ID = 140901;

		// Token: 0x04023132 RID: 143666
		private const int ANIM_DURATION = 500;

		// Token: 0x04023133 RID: 143667
		private SpecialEnergyBarInfo BigConfig;

		// Token: 0x04023134 RID: 143668
		private SpecialEnergyBarKaTiXiYaSlot BarItemSmall;

		// Token: 0x04023135 RID: 143669
		private SpecialEnergyBarKaTiXiYaAdultSlot BarItemBig;

		// Token: 0x04023136 RID: 143670
		[Nullable(1)]
		private readonly List<SpecialEnergyBarKaTiXiYaStar> StarList = new List<SpecialEnergyBarKaTiXiYaStar>();

		// Token: 0x04023137 RID: 143671
		private bool IsUltra;

		// Token: 0x04023138 RID: 143672
		private bool IsAdult;

		// Token: 0x04023139 RID: 143673
		private bool IsUltraSkill;

		// Token: 0x0402313A RID: 143674
		private SpecialEnergyBarKaTiXiYa.EState State;

		// Token: 0x0402313B RID: 143675
		private SpecialEnergyBarKaTiXiYa.EState LastState;

		// Token: 0x0402313C RID: 143676
		private float NextAnimTime;

		// Token: 0x0402313D RID: 143677
		private IActiveBuff Buff;

		// Token: 0x0402313E RID: 143678
		private int BuffHandle;

		// Token: 0x0402313F RID: 143679
		private bool IsPlayWarnAnim;

		// Token: 0x04023140 RID: 143680
		private bool IsPlayBurstAnim;

		// Token: 0x0200C1FB RID: 49659
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BC1A RID: 244762
			SmallItem,
			// Token: 0x0403BC1B RID: 244763
			BigItem,
			// Token: 0x0403BC1C RID: 244764
			StarItem,
			// Token: 0x0403BC1D RID: 244765
			SlotBarItemBig,
			// Token: 0x0403BC1E RID: 244766
			StarLeftItem,
			// Token: 0x0403BC1F RID: 244767
			StarRightItem,
			// Token: 0x0403BC20 RID: 244768
			KeyItem,
			// Token: 0x0403BC21 RID: 244769
			AniSmallToBig,
			// Token: 0x0403BC22 RID: 244770
			AniBigToSmall,
			// Token: 0x0403BC23 RID: 244771
			AniChangeUltraSmall,
			// Token: 0x0403BC24 RID: 244772
			AniChangeUltraBig,
			// Token: 0x0403BC25 RID: 244773
			AniUltraSmallOut,
			// Token: 0x0403BC26 RID: 244774
			AniSmall,
			// Token: 0x0403BC27 RID: 244775
			AniBig,
			// Token: 0x0403BC28 RID: 244776
			AniUltraSmall,
			// Token: 0x0403BC29 RID: 244777
			AniWarning,
			// Token: 0x0403BC2A RID: 244778
			AniBurst,
			// Token: 0x0403BC2B RID: 244779
			BigWarnItem
		}

		// Token: 0x0200C1FC RID: 49660
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BC2D RID: 244781
			Small,
			// Token: 0x0403BC2E RID: 244782
			Big,
			// Token: 0x0403BC2F RID: 244783
			UltraSmall
		}
	}
}
