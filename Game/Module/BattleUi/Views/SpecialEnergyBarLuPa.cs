using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D3 RID: 24787
	public class SpecialEnergyBarLuPa : SpecialEnergyBarBase
	{
		// Token: 0x0603E9A2 RID: 256418 RVA: 0x01004D28 File Offset: 0x01002F28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E9A3 RID: 256419 RVA: 0x01004E79 File Offset: 0x01003079
		protected override void OnInitData()
		{
			base.OnInitData();
			base.ListenForTagCountChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LupaMd10011.状态标识.能量转换层数"], new BaseTagComponent.TTagChangedCallback(this.OnTagCountChanged));
		}

		// Token: 0x0603E9A4 RID: 256420 RVA: 0x01004EA4 File Offset: 0x010030A4
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLuPa.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLuPa.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9A5 RID: 256421 RVA: 0x01004EE8 File Offset: 0x010030E8
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarLuPa.<InitBarItem>d__6 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLuPa.<InitBarItem>d__6>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9A6 RID: 256422 RVA: 0x01004F2B File Offset: 0x0100312B
		private void OnTagCountChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshTagCount(count, false);
		}

		// Token: 0x0603E9A7 RID: 256423 RVA: 0x01004F38 File Offset: 0x01003138
		protected override void OnStart()
		{
			base.InitTweenAnim(3);
			base.InitTweenAnim(4);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			BaseTagComponent tagComponent = this.TagComponent;
			int tagCount = (tagComponent != null) ? tagComponent.GetTagCount(GameplayTagDefine.EGameplayTagId["角色.R2T1LupaMd10011.状态标识.能量转换层数"]) : 0;
			this.RefreshTagCount(tagCount, true);
		}

		// Token: 0x0603E9A8 RID: 256424 RVA: 0x01004F8C File Offset: 0x0100318C
		private void RefreshTagCount(int tagCount, bool isStart = false)
		{
			if (tagCount == this.TagCount && !isStart)
			{
				return;
			}
			int tagCount2 = this.TagCount;
			this.TagCount = tagCount;
			this.BarItem.SetTagCount(this.TagCount);
			this.SetBottomLineState(this.TagCount >= 2);
			if (isStart)
			{
				if (this.TagCount >= 2)
				{
					base.PlayTweenAnim(3);
					base.PlayTweenAnim(7);
					return;
				}
				if (this.TagCount == 1)
				{
					base.PlayTweenAnim(3);
				}
				return;
			}
			else
			{
				if (tagCount2 > this.TagCount)
				{
					for (int i = this.TagCount; i < tagCount2; i++)
					{
						if (i == 0)
						{
							base.StopTweenAnim(3);
							base.PlayTweenAnim(4);
						}
						else if (i == 1)
						{
							base.StopTweenAnim(7);
							base.PlayTweenAnim(8);
						}
					}
					return;
				}
				for (int j = tagCount2; j < this.TagCount; j++)
				{
					if (j == 0)
					{
						base.StopTweenAnim(4);
						base.PlayTweenAnim(3);
					}
					else if (j == 1)
					{
						base.StopTweenAnim(8);
						base.PlayTweenAnim(7);
					}
				}
				return;
			}
		}

		// Token: 0x0603E9A9 RID: 256425 RVA: 0x01005079 File Offset: 0x01003279
		private void SetBottomLineState(bool isLight)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!isLight);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(isLight);
		}

		// Token: 0x0603E9AA RID: 256426 RVA: 0x010050A3 File Offset: 0x010032A3
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarLuPaSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x040231A7 RID: 143783
		private int TagCount;

		// Token: 0x040231A8 RID: 143784
		[Nullable(2)]
		private SpecialEnergyBarLuPaSlot BarItem;

		// Token: 0x0200C21E RID: 49694
		private enum EChildType
		{
			// Token: 0x0403BD15 RID: 245013
			SlotItem,
			// Token: 0x0403BD16 RID: 245014
			StateItemA,
			// Token: 0x0403BD17 RID: 245015
			StateItemB,
			// Token: 0x0403BD18 RID: 245016
			AniLeftIn,
			// Token: 0x0403BD19 RID: 245017
			AniLeftOut,
			// Token: 0x0403BD1A RID: 245018
			EffectRight,
			// Token: 0x0403BD1B RID: 245019
			EffectLeft,
			// Token: 0x0403BD1C RID: 245020
			AniRightIn,
			// Token: 0x0403BD1D RID: 245021
			AniRightOut
		}
	}
}
