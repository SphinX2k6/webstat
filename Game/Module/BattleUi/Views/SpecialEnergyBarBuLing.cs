using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B0 RID: 24752
	public class SpecialEnergyBarBuLing : SpecialEnergyBarBase
	{
		// Token: 0x0603E7F3 RID: 255987 RVA: 0x00FF9D4C File Offset: 0x00FF7F4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
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

		// Token: 0x0603E7F4 RID: 255988 RVA: 0x00FF9F28 File Offset: 0x00FF8128
		protected override void OnInitData()
		{
			base.OnInitData();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarBuLing.TagLeft, new BaseTagComponent.TTagSwitchedCallback(this.OnTagLeftChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarBuLing.TagRight, new BaseTagComponent.TTagSwitchedCallback(this.OnTagRightChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarBuLing.TagAll, new BaseTagComponent.TTagSwitchedCallback(this.OnTagAllChanged));
		}

		// Token: 0x0603E7F5 RID: 255989 RVA: 0x00FF9F80 File Offset: 0x00FF8180
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarBuLing.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarBuLing.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7F6 RID: 255990 RVA: 0x00FF9FC4 File Offset: 0x00FF81C4
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarBuLing.<InitBarItem>d__14 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarBuLing.<InitBarItem>d__14>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7F7 RID: 255991 RVA: 0x00FFA007 File Offset: 0x00FF8207
		private void OnTagLeftChanged(int tagId, bool tagExist)
		{
			this.HasTagLeft = tagExist;
			this.RefreshState(false);
		}

		// Token: 0x0603E7F8 RID: 255992 RVA: 0x00FFA017 File Offset: 0x00FF8217
		private void OnTagRightChanged(int tagId, bool tagExist)
		{
			this.HasTagRight = tagExist;
			this.RefreshState(false);
		}

		// Token: 0x0603E7F9 RID: 255993 RVA: 0x00FFA027 File Offset: 0x00FF8227
		private void OnTagAllChanged(int tagId, bool tagExist)
		{
			this.HasTagAll = tagExist;
			this.RefreshState(false);
		}

		// Token: 0x0603E7FA RID: 255994 RVA: 0x00FFA038 File Offset: 0x00FF8238
		protected override void OnStart()
		{
			base.InitTweenAnim(7);
			base.InitTweenAnim(9);
			base.InitTweenAnim(8);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			BaseTagComponent tagComponent = this.TagComponent;
			this.HasTagLeft = (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarBuLing.TagLeft));
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.HasTagRight = (tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarBuLing.TagRight));
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.HasTagAll = (tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarBuLing.TagAll));
			this.RefreshState(true);
		}

		// Token: 0x0603E7FB RID: 255995 RVA: 0x00FFA0D4 File Offset: 0x00FF82D4
		private void RefreshState(bool isStart = false)
		{
			this.BarItem.SetState(this.HasTagLeft || this.HasTagAll, this.HasTagRight || this.HasTagAll);
			int num = 0;
			if (this.HasTagAll)
			{
				num = 3;
			}
			else if (this.HasTagLeft)
			{
				num = 1;
			}
			else if (this.HasTagRight)
			{
				num = 2;
			}
			if (num == this.State && !isStart)
			{
				return;
			}
			int state = this.State;
			this.State = num;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(this.State == 0);
			}
			UUIItem item2 = base.GetItem(3);
			if (item2 != null)
			{
				item2.SetUIActive(this.State == 1);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(this.State == 2);
			}
			UUIItem item4 = base.GetItem(4);
			if (item4 != null)
			{
				item4.SetUIActive(this.State == 3);
			}
			UUIItem item5 = base.GetItem(5);
			if (item5 != null)
			{
				item5.SetUIActive(this.HasTagLeft || this.HasTagAll);
			}
			UUIItem item6 = base.GetItem(6);
			if (item6 != null)
			{
				item6.SetUIActive(this.HasTagRight || this.HasTagAll);
			}
			if (!isStart)
			{
				if (this.State == 0)
				{
					if (state == 3)
					{
						this.PlayTweenAnimOnly(10);
						return;
					}
					if (state == 1)
					{
						this.PlayTweenAnimOnly(11);
						return;
					}
					if (state == 2)
					{
						this.PlayTweenAnimOnly(12);
						return;
					}
				}
				else
				{
					if (this.State == 3)
					{
						this.PlayTweenAnimOnly(9);
						return;
					}
					if (this.State == 1)
					{
						if (state == 0)
						{
							this.PlayTweenAnimOnly(7);
							return;
						}
					}
					else if (this.State == 2 && state == 0)
					{
						this.PlayTweenAnimOnly(8);
					}
				}
			}
		}

		// Token: 0x0603E7FC RID: 255996 RVA: 0x00FFA26A File Offset: 0x00FF846A
		protected void PlayTweenAnimOnly(int componentType)
		{
			if (this.LastAni >= 0)
			{
				base.StopTweenAnim(this.LastAni);
			}
			this.LastAni = componentType;
			base.PlayTweenAnim(componentType);
		}

		// Token: 0x0603E7FD RID: 255997 RVA: 0x00FFA28F File Offset: 0x00FF848F
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarBuLingSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x0402307E RID: 143486
		[StaticVariableRuleIgnore]
		private static readonly int TagLeft = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.阴阳鱼.阳侧"];

		// Token: 0x0402307F RID: 143487
		[StaticVariableRuleIgnore]
		private static readonly int TagRight = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.阴阳鱼.阴侧"];

		// Token: 0x04023080 RID: 143488
		[StaticVariableRuleIgnore]
		private static readonly int TagAll = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.阴阳鱼.嵌合中"];

		// Token: 0x04023081 RID: 143489
		private const float EFFECT_BASE_PERCENT = 0.41463414f;

		// Token: 0x04023082 RID: 143490
		private bool HasTagLeft;

		// Token: 0x04023083 RID: 143491
		private bool HasTagRight;

		// Token: 0x04023084 RID: 143492
		private bool HasTagAll;

		// Token: 0x04023085 RID: 143493
		private int State;

		// Token: 0x04023086 RID: 143494
		private int LastAni = -1;

		// Token: 0x04023087 RID: 143495
		[Nullable(2)]
		private SpecialEnergyBarBuLingSlot BarItem;

		// Token: 0x0200C1D2 RID: 49618
		private enum EChildType
		{
			// Token: 0x0403BAE8 RID: 244456
			SlotItem,
			// Token: 0x0403BAE9 RID: 244457
			StateNoneItem,
			// Token: 0x0403BAEA RID: 244458
			StateRightItem,
			// Token: 0x0403BAEB RID: 244459
			StateLeftItem,
			// Token: 0x0403BAEC RID: 244460
			StateAllItem,
			// Token: 0x0403BAED RID: 244461
			LeftBottomItem,
			// Token: 0x0403BAEE RID: 244462
			RightBottomItem,
			// Token: 0x0403BAEF RID: 244463
			AniLeftIn,
			// Token: 0x0403BAF0 RID: 244464
			AniRightIn,
			// Token: 0x0403BAF1 RID: 244465
			AniAllIn,
			// Token: 0x0403BAF2 RID: 244466
			AniAllOut,
			// Token: 0x0403BAF3 RID: 244467
			AniLeftOut,
			// Token: 0x0403BAF4 RID: 244468
			AniRightOut
		}
	}
}
