using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060DD RID: 24797
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarQiuYuan : SpecialEnergyBarBase
	{
		// Token: 0x0603EA23 RID: 256547 RVA: 0x01007CF4 File Offset: 0x01005EF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EA24 RID: 256548 RVA: 0x01007ECD File Offset: 0x010060CD
		protected override void OnInitData()
		{
			base.OnInitData();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarQiuYuan.CountDownTag, new BaseTagComponent.TTagSwitchedCallback(this.OnCountDownTagChanged));
		}

		// Token: 0x0603EA25 RID: 256549 RVA: 0x01007EEC File Offset: 0x010060EC
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarQiuYuan.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarQiuYuan.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA26 RID: 256550 RVA: 0x01007F30 File Offset: 0x01006130
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarQiuYuan.<InitBarItem>d__12 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarQiuYuan.<InitBarItem>d__12>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA27 RID: 256551 RVA: 0x01007F74 File Offset: 0x01006174
		protected override void OnStart()
		{
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			this.BarTexture = base.GetTexture(1);
			this.RefreshBarPercent(true);
			this.SetCountDownState(this.TagComponent.HasTag(SpecialEnergyBarQiuYuan.CountDownTag), true);
			this.SetCountDownBarPercent(0f, true);
		}

		// Token: 0x0603EA28 RID: 256552 RVA: 0x01007FF4 File Offset: 0x010061F4
		private void OnCountDownTagChanged(int tagId, bool tagExist)
		{
			this.SetCountDownState(tagExist, false);
		}

		// Token: 0x0603EA29 RID: 256553 RVA: 0x01007FFE File Offset: 0x010061FE
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EA2A RID: 256554 RVA: 0x01008008 File Offset: 0x01006208
		protected void RefreshBarPercent(bool isStart = false)
		{
			int tagCount = (int)Math.Floor((double)(this.PercentMachine.GetCurPercent() * 3f));
			this.RefreshStateCount(tagCount, isStart);
		}

		// Token: 0x0603EA2B RID: 256555 RVA: 0x01008038 File Offset: 0x01006238
		private void RefreshStateCount(int tagCount, bool isStart = false)
		{
			if (tagCount == this.StateCount && !isStart)
			{
				return;
			}
			int stateCount = this.StateCount;
			this.StateCount = tagCount;
			if (stateCount > this.StateCount)
			{
				for (int i = this.StateCount; i < stateCount; i++)
				{
					base.StopTweenAnim(5 + i * 2);
					base.PlayTweenAnim(6 + i * 2);
				}
				return;
			}
			for (int j = stateCount; j < this.StateCount; j++)
			{
				base.StopTweenAnim(6 + j * 2);
				base.PlayTweenAnim(5 + j * 2);
			}
		}

		// Token: 0x0603EA2C RID: 256556 RVA: 0x010080B8 File Offset: 0x010062B8
		private void SetCountDownState(bool state, bool isStart = false)
		{
			if (this.CountDownState == state && !isStart)
			{
				return;
			}
			this.CountDownState = state;
		}

		// Token: 0x0603EA2D RID: 256557 RVA: 0x010080D0 File Offset: 0x010062D0
		private void SetCountDownBarPercent(float percent = 0f, bool isStart = false)
		{
			if (isStart)
			{
				this.BarPercent = percent;
				this.BarTexture.SetFillAmount(percent);
				return;
			}
			if (this.BarPercent == percent)
			{
				return;
			}
			this.BarTexture.SetFillAmount(percent);
			if (percent <= 0f && this.BarPercent > 0f)
			{
				base.StopTweenAnim(11);
				base.PlayTweenAnim(12);
			}
			else if (percent > 0f && this.BarPercent <= 0f)
			{
				base.StopTweenAnim(12);
				base.PlayTweenAnim(11);
			}
			this.BarPercent = percent;
		}

		// Token: 0x0603EA2E RID: 256558 RVA: 0x01008160 File Offset: 0x01006360
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (!this.CountDownState)
			{
				this.SetCountDownBarPercent(0f, false);
				return;
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_56;
				}
			}
			this.RefreshBuff();
			IL_56:
			if (this.Buff != null)
			{
				this.SetCountDownBarPercent(this.Buff.GetRemainDuration() / this.Buff.Duration, false);
			}
		}

		// Token: 0x0603EA2F RID: 256559 RVA: 0x010081EC File Offset: 0x010063EC
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

		// Token: 0x04023204 RID: 143876
		[StaticVariableRuleIgnore]
		private static readonly int CountDownTag = GameplayTagDefine.EGameplayTagId["角色.R2T1Qiuyuan01Md10011.特殊机制.心眼展开"];

		// Token: 0x04023205 RID: 143877
		private int StateCount;

		// Token: 0x04023206 RID: 143878
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023207 RID: 143879
		private UUITexture BarTexture;

		// Token: 0x04023208 RID: 143880
		private float BarPercent;

		// Token: 0x04023209 RID: 143881
		private IActiveBuff Buff;

		// Token: 0x0402320A RID: 143882
		private int BuffHandle;

		// Token: 0x0402320B RID: 143883
		private bool CountDownState;

		// Token: 0x0200C236 RID: 49718
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BDB7 RID: 245175
			SlotItem,
			// Token: 0x0403BDB8 RID: 245176
			BarTexture,
			// Token: 0x0403BDB9 RID: 245177
			StateItem1,
			// Token: 0x0403BDBA RID: 245178
			StateItem2,
			// Token: 0x0403BDBB RID: 245179
			StateItem3,
			// Token: 0x0403BDBC RID: 245180
			AniStateIn1,
			// Token: 0x0403BDBD RID: 245181
			AniStateOut1,
			// Token: 0x0403BDBE RID: 245182
			AniStateIn2,
			// Token: 0x0403BDBF RID: 245183
			AniStateOut2,
			// Token: 0x0403BDC0 RID: 245184
			AniStateIn3,
			// Token: 0x0403BDC1 RID: 245185
			AniStateOut3,
			// Token: 0x0403BDC2 RID: 245186
			AniBarIn,
			// Token: 0x0403BDC3 RID: 245187
			AniBarOut
		}
	}
}
