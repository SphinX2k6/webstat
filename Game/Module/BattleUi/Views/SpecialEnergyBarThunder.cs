using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E4 RID: 24804
	public class SpecialEnergyBarThunder : SpecialEnergyBarBase
	{
		// Token: 0x0603EA86 RID: 256646 RVA: 0x01009D38 File Offset: 0x01007F38
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EA87 RID: 256647 RVA: 0x01009E67 File Offset: 0x01008067
		protected override void OnInitData()
		{
			this.OverloadConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(130901);
		}

		// Token: 0x0603EA88 RID: 256648 RVA: 0x01009E83 File Offset: 0x01008083
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarThunder.OverloadTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnOverloadTagChanged));
		}

		// Token: 0x0603EA89 RID: 256649 RVA: 0x01009EA4 File Offset: 0x010080A4
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarThunder.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarThunder.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA8A RID: 256650 RVA: 0x01009EE8 File Offset: 0x010080E8
		private UniTask InitBarItem()
		{
			SpecialEnergyBarThunder.<InitBarItem>d__13 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarThunder.<InitBarItem>d__13>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA8B RID: 256651 RVA: 0x01009F2C File Offset: 0x0100812C
		private UniTask InitOverloadBarItem()
		{
			SpecialEnergyBarThunder.<InitOverloadBarItem>d__14 <InitOverloadBarItem>d__;
			<InitOverloadBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitOverloadBarItem>d__.<>4__this = this;
			<InitOverloadBarItem>d__.<>1__state = -1;
			<InitOverloadBarItem>d__.<>t__builder.Start<SpecialEnergyBarThunder.<InitOverloadBarItem>d__14>(ref <InitOverloadBarItem>d__);
			return <InitOverloadBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA8C RID: 256652 RVA: 0x01009F6F File Offset: 0x0100816F
		protected override void OnStart()
		{
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			this.RefreshState(true);
			this.RefreshFullState(true);
		}

		// Token: 0x0603EA8D RID: 256653 RVA: 0x01009F94 File Offset: 0x01008194
		protected override void OnBarPercentChanged()
		{
			this.RefreshFullState(false);
		}

		// Token: 0x0603EA8E RID: 256654 RVA: 0x01009F9D File Offset: 0x0100819D
		protected override void OnKeyEnableChanged()
		{
			this.RefreshFullState(false);
		}

		// Token: 0x0603EA8F RID: 256655 RVA: 0x01009FA6 File Offset: 0x010081A6
		private void OnOverloadTagChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarThunder.EState.Overload : SpecialEnergyBarThunder.EState.Normal, false);
		}

		// Token: 0x0603EA90 RID: 256656 RVA: 0x01009FB8 File Offset: 0x010081B8
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetState((tagComponent != null && tagComponent.HasTag(SpecialEnergyBarThunder.OverloadTagId)) ? SpecialEnergyBarThunder.EState.Overload : SpecialEnergyBarThunder.EState.Normal, isStart);
		}

		// Token: 0x0603EA91 RID: 256657 RVA: 0x01009FEC File Offset: 0x010081EC
		private void SetState(SpecialEnergyBarThunder.EState state, bool isStart = false)
		{
			if (this.CurState == state && !isStart)
			{
				return;
			}
			this.CurState = state;
			bool flag = this.CurState == SpecialEnergyBarThunder.EState.Overload;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUIItem item4 = base.GetItem(4);
			if (item4 != null)
			{
				item4.SetUIActive(flag);
			}
			if (!isStart)
			{
				if (flag)
				{
					base.StopTweenAnim(7);
					base.PlayTweenAnim(6);
				}
				else
				{
					base.StopTweenAnim(6);
					base.PlayTweenAnim(7);
				}
				SpecialEnergyBarThunderOverload overloadBarItem = this.OverloadBarItem;
				if (overloadBarItem != null)
				{
					overloadBarItem.OnChangeVisibleByTagChange(flag);
				}
			}
			this.RefreshFullState(true);
		}

		// Token: 0x0603EA92 RID: 256658 RVA: 0x0100A0A8 File Offset: 0x010082A8
		private void RefreshFullState(bool isStart = false)
		{
			if (this.CurState == SpecialEnergyBarThunder.EState.Overload)
			{
				if (this.IsFull || isStart)
				{
					this.IsFull = false;
					this.SetNormalBgUseChangeColor(false);
					base.StopTweenAnim(5);
				}
				return;
			}
			bool keyEnable = this.GetKeyEnable();
			if (this.IsFull == keyEnable && !isStart)
			{
				return;
			}
			this.IsFull = keyEnable;
			this.SetNormalBgUseChangeColor(keyEnable);
			if (keyEnable)
			{
				base.PlayTweenAnim(5);
				return;
			}
			base.StopTweenAnim(5);
		}

		// Token: 0x0603EA93 RID: 256659 RVA: 0x0100A114 File Offset: 0x01008314
		private void SetNormalBgUseChangeColor(bool useChangeColor)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				UUIItem uuiitem = texture;
				FColor? fcolor = new FColor?(texture.changeColor);
				uuiitem.SetChangeColor(useChangeColor, fcolor);
			}
		}

		// Token: 0x0603EA94 RID: 256660 RVA: 0x0100A141 File Offset: 0x01008341
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			SpecialEnergyBarThunderOverload overloadBarItem = this.OverloadBarItem;
			if (overloadBarItem == null)
			{
				return;
			}
			overloadBarItem.Tick(delta);
		}

		// Token: 0x04023244 RID: 143940
		private const int OVERLOAD_CONFIG_ID = 130901;

		// Token: 0x04023245 RID: 143941
		[StaticVariableRuleIgnore]
		private static readonly int OverloadTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1ThunderNanzhuMd10011.逻辑.E技能派生"];

		// Token: 0x04023246 RID: 143942
		[Nullable(2)]
		private SpecialEnergyBarInfo OverloadConfig;

		// Token: 0x04023247 RID: 143943
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023248 RID: 143944
		[Nullable(2)]
		private SpecialEnergyBarThunderOverload OverloadBarItem;

		// Token: 0x04023249 RID: 143945
		private bool IsFull;

		// Token: 0x0402324A RID: 143946
		private SpecialEnergyBarThunder.EState CurState;

		// Token: 0x0200C24C RID: 49740
		private enum EChildType
		{
			// Token: 0x0403BE40 RID: 245312
			StateItemA,
			// Token: 0x0403BE41 RID: 245313
			BgTexture,
			// Token: 0x0403BE42 RID: 245314
			SlotBarItem,
			// Token: 0x0403BE43 RID: 245315
			StateItemB,
			// Token: 0x0403BE44 RID: 245316
			OverloadSlotBarItem,
			// Token: 0x0403BE45 RID: 245317
			AniAmax,
			// Token: 0x0403BE46 RID: 245318
			AniAtoB,
			// Token: 0x0403BE47 RID: 245319
			AniBtoA
		}

		// Token: 0x0200C24D RID: 49741
		private enum EState
		{
			// Token: 0x0403BE49 RID: 245321
			Normal,
			// Token: 0x0403BE4A RID: 245322
			Overload
		}
	}
}
