using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060ED RID: 24813
	public class SpecialEnergyBarYouNuo : SpecialEnergyBarBase
	{
		// Token: 0x0603EAF7 RID: 256759 RVA: 0x0100C238 File Offset: 0x0100A438
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
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
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EAF8 RID: 256760 RVA: 0x0100C3D0 File Offset: 0x0100A5D0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarYouNuo.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarYouNuo.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAF9 RID: 256761 RVA: 0x0100C414 File Offset: 0x0100A614
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarYouNuo.<InitBarItem>d__15 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarYouNuo.<InitBarItem>d__15>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAFA RID: 256762 RVA: 0x0100C458 File Offset: 0x0100A658
		protected override void OnStart()
		{
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			BaseTagComponent tagComponent = this.TagComponent;
			this.IsQuarterMoon = (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarYouNuo.QuarterMoonTag));
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.IsNewMoon = (tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarYouNuo.NewMoonTag));
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.IsNormalSkillEnable = (tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarYouNuo.NormalSkillEnableTag));
			this.RefreshBarPercent(true);
			this.BarItem.SetKeyItemEnable(0, this.IsNormalSkillEnable, true);
		}

		// Token: 0x0603EAFB RID: 256763 RVA: 0x0100C4F4 File Offset: 0x0100A6F4
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarYouNuo.QuarterMoonTag, new BaseTagComponent.TTagSwitchedCallback(this.OnQuarterMoonTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarYouNuo.NewMoonTag, new BaseTagComponent.TTagSwitchedCallback(this.OnNewMoonTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarYouNuo.NormalSkillEnableTag, new BaseTagComponent.TTagSwitchedCallback(this.OnNormalSkillEnableTagChange));
		}

		// Token: 0x0603EAFC RID: 256764 RVA: 0x0100C54C File Offset: 0x0100A74C
		private void OnQuarterMoonTagChange(int tagId, bool tagExist)
		{
			this.IsQuarterMoon = tagExist;
			this.RefreshState(false);
		}

		// Token: 0x0603EAFD RID: 256765 RVA: 0x0100C55C File Offset: 0x0100A75C
		private void OnNewMoonTagChange(int tagId, bool tagExist)
		{
			this.IsNewMoon = tagExist;
			this.RefreshState(false);
		}

		// Token: 0x0603EAFE RID: 256766 RVA: 0x0100C56C File Offset: 0x0100A76C
		private void OnNormalSkillEnableTagChange(int tagId, bool tagExist)
		{
			this.IsNormalSkillEnable = tagExist;
			this.BarItem.SetKeyItemEnable(0, this.IsNormalSkillEnable, true);
		}

		// Token: 0x0603EAFF RID: 256767 RVA: 0x0100C588 File Offset: 0x0100A788
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB00 RID: 256768 RVA: 0x0100C591 File Offset: 0x0100A791
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB01 RID: 256769 RVA: 0x0100C59C File Offset: 0x0100A79C
		private void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.IsFull = (curPercent >= 1f);
			this.RefreshNewMoonEffectPercent(curPercent);
			this.RefreshState(isStart);
		}

		// Token: 0x0603EB02 RID: 256770 RVA: 0x0100C5D4 File Offset: 0x0100A7D4
		private void RefreshNewMoonEffectPercent(float percent)
		{
			if (this.State != SpecialEnergyBarYouNuo.EState.NewMoon)
			{
				return;
			}
			base.GetUiNiagara(9).SetNiagaraVarFloat("Dissolve", Math.Min(percent * 2f, 1f));
			base.GetUiNiagara(10).SetNiagaraVarFloat("Dissolve", Math.Max(percent * 2f - 1f, 0f));
		}

		// Token: 0x0603EB03 RID: 256771 RVA: 0x0100C638 File Offset: 0x0100A838
		private void RefreshState(bool isStart = false)
		{
			SpecialEnergyBarYouNuo.EState estate = SpecialEnergyBarYouNuo.EState.Normal;
			if (this.IsQuarterMoon)
			{
				estate = SpecialEnergyBarYouNuo.EState.QuarterMoon;
			}
			else if (this.IsNewMoon)
			{
				estate = SpecialEnergyBarYouNuo.EState.NewMoon;
			}
			else if (this.IsFull)
			{
				estate = SpecialEnergyBarYouNuo.EState.Full;
			}
			if (this.State == estate && !isStart)
			{
				return;
			}
			this.State = estate;
			if (this.CurAnim >= 0)
			{
				base.StopTweenAnim(this.CurAnim);
				this.CurAnim = -1;
			}
			float fullEffectPercent = 1.1f;
			int keyItemType = 0;
			int barColor = 0;
			switch (this.State)
			{
			case SpecialEnergyBarYouNuo.EState.Normal:
				this.CurAnim = 8;
				break;
			case SpecialEnergyBarYouNuo.EState.Full:
				this.CurAnim = 5;
				break;
			case SpecialEnergyBarYouNuo.EState.QuarterMoon:
				keyItemType = 1;
				barColor = 1;
				this.CurAnim = 6;
				break;
			case SpecialEnergyBarYouNuo.EState.NewMoon:
				keyItemType = 2;
				barColor = 2;
				this.CurAnim = 7;
				fullEffectPercent = 0f;
				this.RefreshNewMoonEffectPercent(this.PercentMachine.GetCurPercent());
				break;
			}
			if (this.CurAnim >= 0)
			{
				base.PlayTweenAnim(this.CurAnim);
			}
			if (this.BarItem != null)
			{
				this.BarItem.SetKeyItemType(keyItemType);
				this.BarItem.SetFullEffectPercent(fullEffectPercent);
				this.BarItem.SetBarColor(barColor);
			}
		}

		// Token: 0x0603EB04 RID: 256772 RVA: 0x0100C746 File Offset: 0x0100A946
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarYouNuoSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x0402327D RID: 143997
		private const float EFFECT_BASE_PERCENT = 0.4390244f;

		// Token: 0x0402327E RID: 143998
		[StaticVariableRuleIgnore]
		private static readonly int QuarterMoonTag = GameplayTagDefine.EGameplayTagId["角色.R2T1YounuoMd10011.状态标识.环刃模式"];

		// Token: 0x0402327F RID: 143999
		[StaticVariableRuleIgnore]
		private static readonly int NewMoonTag = GameplayTagDefine.EGameplayTagId["角色.R2T1YounuoMd10011.状态标识.月弓模式"];

		// Token: 0x04023280 RID: 144000
		[StaticVariableRuleIgnore]
		private static readonly int NormalSkillEnableTag = GameplayTagDefine.EGameplayTagId["角色.R2T1YounuoMd10011.状态标识.E2可使用"];

		// Token: 0x04023281 RID: 144001
		[Nullable(2)]
		private SpecialEnergyBarYouNuoSlot BarItem;

		// Token: 0x04023282 RID: 144002
		private bool IsFull;

		// Token: 0x04023283 RID: 144003
		private bool IsQuarterMoon;

		// Token: 0x04023284 RID: 144004
		private bool IsNewMoon;

		// Token: 0x04023285 RID: 144005
		private bool IsNormalSkillEnable;

		// Token: 0x04023286 RID: 144006
		private SpecialEnergyBarYouNuo.EState State;

		// Token: 0x04023287 RID: 144007
		private int CurAnim = -1;

		// Token: 0x0200C264 RID: 49764
		private enum EChildType
		{
			// Token: 0x0403BED4 RID: 245460
			SlotBarItem,
			// Token: 0x0403BED5 RID: 245461
			NormalItem,
			// Token: 0x0403BED6 RID: 245462
			FullItem,
			// Token: 0x0403BED7 RID: 245463
			QuarterMoonItem,
			// Token: 0x0403BED8 RID: 245464
			NewMoonItem,
			// Token: 0x0403BED9 RID: 245465
			AniFull,
			// Token: 0x0403BEDA RID: 245466
			AniQuarterMoon,
			// Token: 0x0403BEDB RID: 245467
			AniNewMoon,
			// Token: 0x0403BEDC RID: 245468
			AniNormal,
			// Token: 0x0403BEDD RID: 245469
			NewMoonBarEffectL,
			// Token: 0x0403BEDE RID: 245470
			NewMoonBarEffectR
		}

		// Token: 0x0200C265 RID: 49765
		private enum EState
		{
			// Token: 0x0403BEE0 RID: 245472
			Normal,
			// Token: 0x0403BEE1 RID: 245473
			Full,
			// Token: 0x0403BEE2 RID: 245474
			QuarterMoon,
			// Token: 0x0403BEE3 RID: 245475
			NewMoon
		}
	}
}
