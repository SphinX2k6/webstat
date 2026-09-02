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
	// Token: 0x020060D9 RID: 24793
	public class SpecialEnergyBarQianXiao : SpecialEnergyBarBase
	{
		// Token: 0x0603E9DB RID: 256475 RVA: 0x01006254 File Offset: 0x01004454
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
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
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E9DC RID: 256476 RVA: 0x010065C8 File Offset: 0x010047C8
		protected override void OnInitData()
		{
			this.AttributeId = EAttributeType.SpecialEnergy2;
			this.MaxAttributeId = EAttributeType.SpecialEnergy2Max;
			SpecialEnergyBarInfo config = this.Config;
			float? num = (config != null) ? config.ExtraFloatParams.GetValueOrNull(0) : null;
			if (num != null)
			{
				this.WarningAnimPercent = num.Value;
			}
		}

		// Token: 0x0603E9DD RID: 256477 RVA: 0x0100661C File Offset: 0x0100481C
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarQianXiao.StayInAirTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnStayInAirTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarQianXiao.SpecialTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarQianXiao.SpecialEnableTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSpecialEnableTagChange));
		}

		// Token: 0x0603E9DE RID: 256478 RVA: 0x01006674 File Offset: 0x01004874
		private void OnStayInAirTagChange(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarQianXiao.EState.StayInAir : SpecialEnergyBarQianXiao.EState.Normal, false);
		}

		// Token: 0x0603E9DF RID: 256479 RVA: 0x01006684 File Offset: 0x01004884
		private void OnSpecialTagChange(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarQianXiao.EState.Special : SpecialEnergyBarQianXiao.EState.Normal, false);
		}

		// Token: 0x0603E9E0 RID: 256480 RVA: 0x01006694 File Offset: 0x01004894
		private void OnSpecialEnableTagChange(int tagId, bool tagExist)
		{
			this.SetSpecialStateEnable(tagExist);
		}

		// Token: 0x0603E9E1 RID: 256481 RVA: 0x010066A0 File Offset: 0x010048A0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarQianXiao.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarQianXiao.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9E2 RID: 256482 RVA: 0x010066E4 File Offset: 0x010048E4
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarQianXiao.<InitBarItem>d__19 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarQianXiao.<InitBarItem>d__19>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9E3 RID: 256483 RVA: 0x01006728 File Offset: 0x01004928
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
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.RefreshState(true);
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E9E4 RID: 256484 RVA: 0x01006796 File Offset: 0x01004996
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(19);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E9E5 RID: 256485 RVA: 0x010067A8 File Offset: 0x010049A8
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			switch (this.CurState)
			{
			case SpecialEnergyBarQianXiao.EState.Normal:
			{
				UUITexture texture = base.GetTexture(4);
				if (texture == null)
				{
					return;
				}
				texture.SetFillAmount(curPercent);
				return;
			}
			case SpecialEnergyBarQianXiao.EState.StayInAir:
			{
				UUITexture texture2 = base.GetTexture(6);
				if (texture2 != null)
				{
					texture2.SetFillAmount(curPercent);
				}
				UUITexture texture3 = base.GetTexture(23);
				if (texture3 != null)
				{
					texture3.SetFillAmount(curPercent);
				}
				UUITexture texture4 = base.GetTexture(24);
				if (texture4 == null)
				{
					return;
				}
				texture4.SetFillAmount(curPercent);
				return;
			}
			case SpecialEnergyBarQianXiao.EState.Special:
			{
				UUITexture texture5 = base.GetTexture(8);
				if (texture5 != null)
				{
					texture5.SetFillAmount(curPercent);
				}
				UUITexture texture6 = base.GetTexture(9);
				if (texture6 == null)
				{
					return;
				}
				texture6.SetFillAmount(curPercent);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603E9E6 RID: 256486 RVA: 0x0100684F File Offset: 0x01004A4F
		protected override void OnBeforeHide()
		{
			SpecialEnergyBarQianXiaoSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.StopCoolDownState();
		}

		// Token: 0x0603E9E7 RID: 256487 RVA: 0x01006864 File Offset: 0x01004A64
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarQianXiao.SpecialTagId))
			{
				this.SetState(SpecialEnergyBarQianXiao.EState.Special, isStart);
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarQianXiao.StayInAirTagId))
				{
					this.SetState(SpecialEnergyBarQianXiao.EState.StayInAir, isStart);
				}
				else
				{
					this.SetState(SpecialEnergyBarQianXiao.EState.Normal, isStart);
				}
			}
			if (isStart)
			{
				BaseTagComponent tagComponent3 = this.TagComponent;
				if (tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarQianXiao.SpecialEnableTagId))
				{
					this.SetSpecialStateEnable(true);
				}
			}
		}

		// Token: 0x0603E9E8 RID: 256488 RVA: 0x010068E4 File Offset: 0x01004AE4
		private void SetState(SpecialEnergyBarQianXiao.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			int curState = (int)this.CurState;
			this.CurState = state;
			if (curState == 2 && state != SpecialEnergyBarQianXiao.EState.Special)
			{
				base.StopTweenAnim(20);
				base.PlayTweenAnim(18);
				SpecialEnergyBarQianXiaoSlot barItem = this.BarItem;
				if (barItem != null)
				{
					barItem.SetState(SpecialEnergyBarQianXiaoSlot.ESlotState.CoolDown);
				}
				this.SetSpecialStateEnable(false);
			}
			switch (this.CurState)
			{
			case SpecialEnergyBarQianXiao.EState.Normal:
			{
				UUIItem item = base.GetItem(3);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(7);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				base.PlayTweenAnim(16);
				break;
			}
			case SpecialEnergyBarQianXiao.EState.StayInAir:
			{
				UUIItem item4 = base.GetItem(3);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
				UUIItem item5 = base.GetItem(5);
				if (item5 != null)
				{
					item5.SetUIActive(true);
				}
				UUIItem item6 = base.GetItem(7);
				if (item6 != null)
				{
					item6.SetUIActive(false);
				}
				base.PlayTweenAnim(15);
				break;
			}
			case SpecialEnergyBarQianXiao.EState.Special:
			{
				UUIItem item7 = base.GetItem(3);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
				UUIItem item8 = base.GetItem(5);
				if (item8 != null)
				{
					item8.SetUIActive(false);
				}
				UUIItem item9 = base.GetItem(7);
				if (item9 != null)
				{
					item9.SetUIActive(true);
				}
				base.PlayTweenAnim(17);
				base.PlayTweenAnim(20);
				SpecialEnergyBarQianXiaoSlot barItem2 = this.BarItem;
				if (barItem2 != null)
				{
					barItem2.SetState(SpecialEnergyBarQianXiaoSlot.ESlotState.Special);
				}
				break;
			}
			}
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E9E9 RID: 256489 RVA: 0x01006A44 File Offset: 0x01004C44
		private void SetSpecialStateEnable(bool enable)
		{
			if (this.IsSpecialStateEnable == enable)
			{
				return;
			}
			if (enable)
			{
				SpecialEnergyBarQianXiaoSlot barItem = this.BarItem;
				if (barItem == null || !barItem.IsInSlotState(SpecialEnergyBarQianXiaoSlot.ESlotState.CoolDown))
				{
					this.IsSpecialStateEnable = true;
					SpecialEnergyBarQianXiaoSlot barItem2 = this.BarItem;
					if (barItem2 != null)
					{
						barItem2.SetFullEffectEnable(true);
					}
					base.PlayTweenAnim(13);
					return;
				}
			}
			if (!enable && this.CurState != SpecialEnergyBarQianXiao.EState.Special)
			{
				this.IsSpecialStateEnable = false;
				SpecialEnergyBarQianXiaoSlot barItem3 = this.BarItem;
				if (barItem3 != null)
				{
					barItem3.SetFullEffectEnable(false);
				}
				base.PlayTweenAnim(14);
			}
		}

		// Token: 0x0603E9EA RID: 256490 RVA: 0x01006AC8 File Offset: 0x01004CC8
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarQianXiaoSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (this.CurState == SpecialEnergyBarQianXiao.EState.StayInAir && this.PercentMachine.GetCurPercent() < this.WarningAnimPercent)
			{
				this.PlayWarnAnim(true);
				return;
			}
			this.PlayWarnAnim(false);
		}

		// Token: 0x0603E9EB RID: 256491 RVA: 0x01006B1C File Offset: 0x01004D1C
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(19);
				return;
			}
			base.StopTweenAnim(19);
			UUITexture texture = base.GetTexture(6);
			if (texture != null)
			{
				texture.SetColor(this.BarDefaultColor);
			}
			UUITexture texture2 = base.GetTexture(24);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetAlpha(1f);
		}

		// Token: 0x0603E9EC RID: 256492 RVA: 0x01006B80 File Offset: 0x01004D80
		private UniTask<bool> LoadCurve([Nullable(1)] string path)
		{
			SpecialEnergyBarQianXiao.<LoadCurve>d__29 <LoadCurve>d__;
			<LoadCurve>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<LoadCurve>d__.<>4__this = this;
			<LoadCurve>d__.path = path;
			<LoadCurve>d__.<>1__state = -1;
			<LoadCurve>d__.<>t__builder.Start<SpecialEnergyBarQianXiao.<LoadCurve>d__29>(ref <LoadCurve>d__);
			return <LoadCurve>d__.<>t__builder.Task;
		}

		// Token: 0x040231CC RID: 143820
		[StaticVariableRuleIgnore]
		private static readonly int StayInAirTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1QianxiaMd10011.状态标识.特殊闪避可用"];

		// Token: 0x040231CD RID: 143821
		[StaticVariableRuleIgnore]
		private static readonly int SpecialTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1QianxiaMd10011.状态标识.电锯状态"];

		// Token: 0x040231CE RID: 143822
		[StaticVariableRuleIgnore]
		private static readonly int SpecialEnableTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1QianxiaMd10011.状态标识.剪刀E可用"];

		// Token: 0x040231CF RID: 143823
		[Nullable(1)]
		private const string CURVE_PATH = "/Game/Aki/UI/UIResources/UiFight/Curve/EnergyBar/Qianxiao/GearRollbackCurve.GearRollbackCurve";

		// Token: 0x040231D0 RID: 143824
		private readonly FColor BarDefaultColor = new FColor(byte.MaxValue, 133, 246, byte.MaxValue);

		// Token: 0x040231D1 RID: 143825
		[Nullable(2)]
		private SpecialEnergyBarQianXiaoSlot BarItem;

		// Token: 0x040231D2 RID: 143826
		private SpecialEnergyBarQianXiao.EState CurState;

		// Token: 0x040231D3 RID: 143827
		private bool IsSpecialStateEnable;

		// Token: 0x040231D4 RID: 143828
		private bool IsPlayWarnAnim;

		// Token: 0x040231D5 RID: 143829
		private float WarningAnimPercent = 0.5f;

		// Token: 0x0200C22A RID: 49706
		private enum EState
		{
			// Token: 0x0403BD63 RID: 245091
			Normal,
			// Token: 0x0403BD64 RID: 245092
			StayInAir,
			// Token: 0x0403BD65 RID: 245093
			Special
		}

		// Token: 0x0200C22B RID: 49707
		private enum EChildType
		{
			// Token: 0x0403BD67 RID: 245095
			EnergyBar,
			// Token: 0x0403BD68 RID: 245096
			SlotBarItem,
			// Token: 0x0403BD69 RID: 245097
			SlotBarPoint,
			// Token: 0x0403BD6A RID: 245098
			BarItemNormal,
			// Token: 0x0403BD6B RID: 245099
			BarTextureNormal,
			// Token: 0x0403BD6C RID: 245100
			BarItemAir,
			// Token: 0x0403BD6D RID: 245101
			BarTextureAir,
			// Token: 0x0403BD6E RID: 245102
			BarItemSpecial,
			// Token: 0x0403BD6F RID: 245103
			BarTextureSpecialLeft,
			// Token: 0x0403BD70 RID: 245104
			BarTextureSpecialRight,
			// Token: 0x0403BD71 RID: 245105
			GearActiveTexture,
			// Token: 0x0403BD72 RID: 245106
			GearItem,
			// Token: 0x0403BD73 RID: 245107
			BarPointItem,
			// Token: 0x0403BD74 RID: 245108
			AniGearActive,
			// Token: 0x0403BD75 RID: 245109
			AniGear,
			// Token: 0x0403BD76 RID: 245110
			AniAirState,
			// Token: 0x0403BD77 RID: 245111
			AniNormalState,
			// Token: 0x0403BD78 RID: 245112
			AniSpecialState,
			// Token: 0x0403BD79 RID: 245113
			AniRestore,
			// Token: 0x0403BD7A RID: 245114
			AniWarning,
			// Token: 0x0403BD7B RID: 245115
			AniStart,
			// Token: 0x0403BD7C RID: 245116
			GlowItem,
			// Token: 0x0403BD7D RID: 245117
			GlowSlider,
			// Token: 0x0403BD7E RID: 245118
			GlowBarTexture,
			// Token: 0x0403BD7F RID: 245119
			GlowBar2Texture
		}
	}
}
