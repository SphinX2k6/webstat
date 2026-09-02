using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E6 RID: 24806
	public class SpecialEnergyBarWind : SpecialEnergyBarBase
	{
		// Token: 0x0603EAA2 RID: 256674 RVA: 0x0100A334 File Offset: 0x01008534
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

		// Token: 0x0603EAA3 RID: 256675 RVA: 0x0100A424 File Offset: 0x01008624
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarWind.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarWind.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAA4 RID: 256676 RVA: 0x0100A468 File Offset: 0x01008668
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarWind.<InitBarItem>d__7 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarWind.<InitBarItem>d__7>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAA5 RID: 256677 RVA: 0x0100A4AC File Offset: 0x010086AC
		protected override void OnStart()
		{
			base.InitTweenAnim(4);
			base.InitTweenAnim(5);
			this.RefreshBarPercent(true);
			BaseTagComponent tagComponent = this.TagComponent;
			bool isInCd = tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1WindNanzhuMd10011.标记用.技能CD中"]);
			this.RefreshCdState(isInCd, true);
		}

		// Token: 0x0603EAA6 RID: 256678 RVA: 0x0100A4F8 File Offset: 0x010086F8
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1WindNanzhuMd10011.标记用.技能CD中"], new BaseTagComponent.TTagSwitchedCallback(this.OnCdTagChange));
		}

		// Token: 0x0603EAA7 RID: 256679 RVA: 0x0100A521 File Offset: 0x01008721
		private void OnCdTagChange(int tagId, bool tagExist)
		{
			this.RefreshCdState(tagExist, false);
		}

		// Token: 0x0603EAA8 RID: 256680 RVA: 0x0100A52B File Offset: 0x0100872B
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EAA9 RID: 256681 RVA: 0x0100A534 File Offset: 0x01008734
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EAAA RID: 256682 RVA: 0x0100A540 File Offset: 0x01008740
		private void RefreshBarPercent(bool isStart = false)
		{
			bool keyEnable = this.GetKeyEnable();
			this.RefreshDrawState(keyEnable, isStart);
		}

		// Token: 0x0603EAAB RID: 256683 RVA: 0x0100A55C File Offset: 0x0100875C
		private void RefreshDrawState(bool isDrawing, bool isStart = false)
		{
			if (this.IsDrawing == isDrawing && !isStart)
			{
				return;
			}
			this.IsDrawing = isDrawing;
			if (isDrawing)
			{
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(2);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
			}
			else
			{
				UUIItem item3 = base.GetItem(1);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(2);
				if (item4 != null)
				{
					item4.SetUIActive(false);
				}
			}
			if (!isStart)
			{
				if (isDrawing)
				{
					base.PlayTweenAnim(4);
					base.StopTweenAnim(5);
					return;
				}
				base.StopTweenAnim(4);
				base.PlayTweenAnim(5);
			}
		}

		// Token: 0x0603EAAC RID: 256684 RVA: 0x0100A5F1 File Offset: 0x010087F1
		private void RefreshCdState(bool isInCd, bool isStart = false)
		{
			if (this.IsInCd == isInCd && !isStart)
			{
				return;
			}
			this.IsInCd = isInCd;
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!isInCd);
		}

		// Token: 0x0603EAAD RID: 256685 RVA: 0x0100A61C File Offset: 0x0100881C
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x0402324C RID: 143948
		private const float EFFECT_BASE_PERCENT = 0.4390244f;

		// Token: 0x0402324D RID: 143949
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x0402324E RID: 143950
		private bool IsDrawing;

		// Token: 0x0402324F RID: 143951
		private bool IsInCd;

		// Token: 0x0200C253 RID: 49747
		private enum EChildType
		{
			// Token: 0x0403BE63 RID: 245347
			SlotBarItem,
			// Token: 0x0403BE64 RID: 245348
			StateItem1,
			// Token: 0x0403BE65 RID: 245349
			StateItem2,
			// Token: 0x0403BE66 RID: 245350
			CdNiagaraItem,
			// Token: 0x0403BE67 RID: 245351
			AniIn,
			// Token: 0x0403BE68 RID: 245352
			AniOut
		}
	}
}
