using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B7 RID: 24759
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarFeibi : SpecialEnergyBarBase
	{
		// Token: 0x0603E855 RID: 256085 RVA: 0x00FFC360 File Offset: 0x00FFA560
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
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
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E856 RID: 256086 RVA: 0x00FFC59F File Offset: 0x00FFA79F
		protected override void OnInitData()
		{
			this.YellowConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(150602);
			this.BlueConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(150603);
		}

		// Token: 0x0603E857 RID: 256087 RVA: 0x00FFC5D8 File Offset: 0x00FFA7D8
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1FeibiMd10011.逻辑.延奏标识1"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1FeibiMd10011.逻辑.延奏标识2"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange));
		}

		// Token: 0x0603E858 RID: 256088 RVA: 0x00FFC62D File Offset: 0x00FFA82D
		private void OnTagChange(int tagId, bool tagExist)
		{
			this.RefreshState(false);
		}

		// Token: 0x0603E859 RID: 256089 RVA: 0x00FFC638 File Offset: 0x00FFA838
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarFeibi.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarFeibi.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E85A RID: 256090 RVA: 0x00FFC67C File Offset: 0x00FFA87C
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarFeibi.<InitBarItem>d__14 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarFeibi.<InitBarItem>d__14>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E85B RID: 256091 RVA: 0x00FFC6BF File Offset: 0x00FFA8BF
		protected override void OnStart()
		{
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			this.RefreshState(true);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603E85C RID: 256092 RVA: 0x00FFC6DF File Offset: 0x00FFA8DF
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603E85D RID: 256093 RVA: 0x00FFC6E8 File Offset: 0x00FFA8E8
		private void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			switch (this.CurState)
			{
			case SpecialEnergyBarFeibi.EState.Normal:
			{
				UUITexture texture = base.GetTexture(11);
				if (texture != null)
				{
					texture.SetFillAmount(curPercent);
				}
				this.RefreshKeyEnable(isStart);
				return;
			}
			case SpecialEnergyBarFeibi.EState.Yellow:
			{
				UUITexture texture2 = base.GetTexture(5);
				if (texture2 == null)
				{
					return;
				}
				texture2.SetFillAmount(curPercent);
				return;
			}
			case SpecialEnergyBarFeibi.EState.Blue:
			{
				UUITexture texture3 = base.GetTexture(4);
				if (texture3 == null)
				{
					return;
				}
				texture3.SetFillAmount(curPercent);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603E85E RID: 256094 RVA: 0x00FFC75C File Offset: 0x00FFA95C
		protected override void OnKeyEnableChanged()
		{
			this.RefreshKeyEnable(false);
		}

		// Token: 0x0603E85F RID: 256095 RVA: 0x00FFC768 File Offset: 0x00FFA968
		private void RefreshKeyEnable(bool isStart = false)
		{
			bool keyEnable = this.GetKeyEnable();
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603E860 RID: 256096 RVA: 0x00FFC790 File Offset: 0x00FFA990
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1FeibiMd10011.逻辑.延奏标识1"]))
			{
				this.SetState(SpecialEnergyBarFeibi.EState.Yellow, isStart);
			}
			else
			{
				BaseTagComponent tagComponent2 = this.TagComponent;
				if (tagComponent2 != null && tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1FeibiMd10011.逻辑.延奏标识2"]))
				{
					this.SetState(SpecialEnergyBarFeibi.EState.Blue, isStart);
				}
				else
				{
					this.SetState(SpecialEnergyBarFeibi.EState.Normal, isStart);
				}
			}
			if (!isStart)
			{
				this.RefreshBarPercent(false);
			}
		}

		// Token: 0x0603E861 RID: 256097 RVA: 0x00FFC80C File Offset: 0x00FFAA0C
		private void SetState(SpecialEnergyBarFeibi.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			this.CurState = state;
			switch (this.CurState)
			{
			case SpecialEnergyBarFeibi.EState.Normal:
			{
				UUIItem item = base.GetItem(10);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				UUIItem item2 = base.GetItem(1);
				if (item2 != null)
				{
					item2.SetUIActive(false);
				}
				UUIItem item3 = base.GetItem(0);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				UUIItem item4 = base.GetItem(12);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				if (!isStart)
				{
					base.StopTweenAnim(13);
					base.PlayTweenAnim(14);
					return;
				}
				break;
			}
			case SpecialEnergyBarFeibi.EState.Yellow:
			{
				UUIItem item5 = base.GetItem(10);
				if (item5 != null)
				{
					item5.SetUIActive(false);
				}
				UUIItem item6 = base.GetItem(1);
				if (item6 != null)
				{
					item6.SetUIActive(true);
				}
				UUIItem item7 = base.GetItem(0);
				if (item7 != null)
				{
					item7.SetUIActive(false);
				}
				UUIItem item8 = base.GetItem(12);
				if (item8 != null)
				{
					item8.SetUIActive(false);
				}
				if (!isStart)
				{
					base.StopTweenAnim(14);
					base.PlayTweenAnim(13);
					return;
				}
				break;
			}
			case SpecialEnergyBarFeibi.EState.Blue:
			{
				UUIItem item9 = base.GetItem(10);
				if (item9 != null)
				{
					item9.SetUIActive(false);
				}
				UUIItem item10 = base.GetItem(1);
				if (item10 != null)
				{
					item10.SetUIActive(false);
				}
				UUIItem item11 = base.GetItem(0);
				if (item11 != null)
				{
					item11.SetUIActive(true);
				}
				UUIItem item12 = base.GetItem(12);
				if (item12 != null)
				{
					item12.SetUIActive(false);
				}
				if (!isStart)
				{
					base.StopTweenAnim(14);
					base.PlayTweenAnim(13);
				}
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x0603E862 RID: 256098 RVA: 0x00FFC96F File Offset: 0x00FFAB6F
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarFeibiSlot barItemYellow = this.BarItemYellow;
			if (barItemYellow != null)
			{
				barItemYellow.Tick(delta);
			}
			SpecialEnergyBarFeibiSlot barItemBlue = this.BarItemBlue;
			if (barItemBlue == null)
			{
				return;
			}
			barItemBlue.Tick(delta);
		}

		// Token: 0x040230BA RID: 143546
		private const int YELLOW_CONFIG_ID = 150602;

		// Token: 0x040230BB RID: 143547
		private const int BLUE_CONFIG_ID = 150603;

		// Token: 0x040230BC RID: 143548
		private SpecialEnergyBarInfo YellowConfig;

		// Token: 0x040230BD RID: 143549
		private SpecialEnergyBarInfo BlueConfig;

		// Token: 0x040230BE RID: 143550
		private SpecialEnergyBarFeibiSlot BarItemYellow;

		// Token: 0x040230BF RID: 143551
		private SpecialEnergyBarFeibiSlot BarItemBlue;

		// Token: 0x040230C0 RID: 143552
		private SpecialEnergyBarFeibi.EState CurState;

		// Token: 0x0200C1E1 RID: 49633
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BB5C RID: 244572
			BlueItem,
			// Token: 0x0403BB5D RID: 244573
			YellowItem,
			// Token: 0x0403BB5E RID: 244574
			SlotBarItemBlue,
			// Token: 0x0403BB5F RID: 244575
			SlotBarItemYellow,
			// Token: 0x0403BB60 RID: 244576
			BarTextureBlue,
			// Token: 0x0403BB61 RID: 244577
			BarTextureYellow,
			// Token: 0x0403BB62 RID: 244578
			CoreBlue,
			// Token: 0x0403BB63 RID: 244579
			CoreYellow,
			// Token: 0x0403BB64 RID: 244580
			BgBlueItem,
			// Token: 0x0403BB65 RID: 244581
			BgYellowItem,
			// Token: 0x0403BB66 RID: 244582
			NormalItem,
			// Token: 0x0403BB67 RID: 244583
			BarTextureNormal,
			// Token: 0x0403BB68 RID: 244584
			KeyItem,
			// Token: 0x0403BB69 RID: 244585
			AnimAwakeIn,
			// Token: 0x0403BB6A RID: 244586
			AnimAwakeOut,
			// Token: 0x0403BB6B RID: 244587
			AnimBurst
		}

		// Token: 0x0200C1E2 RID: 49634
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BB6D RID: 244589
			Normal,
			// Token: 0x0403BB6E RID: 244590
			Yellow,
			// Token: 0x0403BB6F RID: 244591
			Blue
		}
	}
}
