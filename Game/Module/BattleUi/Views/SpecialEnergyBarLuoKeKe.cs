using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CE RID: 24782
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarLuoKeKe : SpecialEnergyBarBase
	{
		// Token: 0x0603E97B RID: 256379 RVA: 0x01004000 File Offset: 0x01002200
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E97C RID: 256380 RVA: 0x01004154 File Offset: 0x01002354
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLuoKeKe.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLuoKeKe.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E97D RID: 256381 RVA: 0x01004198 File Offset: 0x01002398
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarLuoKeKe.<InitBarItem>d__14 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLuoKeKe.<InitBarItem>d__14>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E97E RID: 256382 RVA: 0x010041DC File Offset: 0x010023DC
		private void UpdateIsGhost()
		{
			this.IsInGhost = false;
			foreach (int tagId in SpecialEnergyBarLuoKeKe.GhostTags)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				if (tagComponent != null && tagComponent.HasTag(tagId))
				{
					this.IsInGhost = true;
					return;
				}
			}
		}

		// Token: 0x0603E97F RID: 256383 RVA: 0x01004228 File Offset: 0x01002428
		protected override void AddEvents()
		{
			base.AddEvents();
			foreach (int tagId in SpecialEnergyBarLuoKeKe.GhostTags)
			{
				base.ListenForTagAddOrRemoveChanged(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnGhostTagChange));
			}
		}

		// Token: 0x0603E980 RID: 256384 RVA: 0x01004266 File Offset: 0x01002466
		private void OnGhostTagChange(int tagId, bool bTagExists)
		{
			if (bTagExists)
			{
				this.IsInGhost = true;
			}
			else
			{
				this.UpdateIsGhost();
			}
			this.RefreshGhostEffectItem(false);
		}

		// Token: 0x0603E981 RID: 256385 RVA: 0x01004284 File Offset: 0x01002484
		protected override void OnStart()
		{
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			this.UpdateIsGhost();
			for (int i = 0; i < 3; i++)
			{
				this.GhostItemList.Add(base.GetItem(1 + i));
				this.GhostEffectItemList.Add(base.GetItem(4 + i));
				this.GhostEffectItemList[i].SetUIActive(false);
			}
			this.RefreshGhostEffectItem(true);
		}

		// Token: 0x0603E982 RID: 256386 RVA: 0x010042F2 File Offset: 0x010024F2
		protected override void OnBarPercentChanged()
		{
			this.RefreshGhostEffectItem(false);
		}

		// Token: 0x0603E983 RID: 256387 RVA: 0x010042FC File Offset: 0x010024FC
		private void RefreshGhostEffectItem(bool isStart = false)
		{
			int num = (int)Math.Floor((double)(this.PercentMachine.GetCurPercent() * 3f));
			int num2 = this.IsInGhost ? num : 0;
			if (this.LastVisibleGhostCount != num2)
			{
				if (num2 > this.LastVisibleGhostCount)
				{
					for (int i = 0; i < 3; i++)
					{
						bool flag = i < num2;
						this.GhostItemList[i].SetUIActive(flag);
						if (isStart && flag)
						{
							this.GhostItemList[i].SetAlpha(1f);
						}
					}
					if (!isStart)
					{
						base.StopTweenAnim(8);
						base.PlayTweenAnim(7);
					}
				}
				else if (!isStart)
				{
					base.StopTweenAnim(7);
					base.PlayTweenAnim(8);
				}
				if (this.IsInGhost)
				{
					for (int j = 0; j < 3; j++)
					{
						this.BarItem.SetFullEffectVisible(j, false);
					}
				}
				else
				{
					for (int k = 0; k < 3; k++)
					{
						bool visible = k < num;
						this.BarItem.SetFullEffectVisible(k, visible);
					}
				}
				this.LastVisibleGhostCount = num2;
			}
			if (this.LastGhostCount != num)
			{
				if (num < this.LastGhostCount)
				{
					for (int l = num; l < this.LastGhostCount; l++)
					{
						this.GhostEffectItemList[l].SetUIActive(true);
						this.EffectFinishTime = Singleton<Time>.Instance.Now + 1000.0;
						this.IsAnyEffectPlaying = true;
					}
				}
				this.LastGhostCount = num;
			}
		}

		// Token: 0x0603E984 RID: 256388 RVA: 0x01004460 File Offset: 0x01002660
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (!this.IsAnyEffectPlaying)
			{
				return;
			}
			if (this.EffectFinishTime <= Singleton<Time>.Instance.Now)
			{
				foreach (UUIItem uuiitem in this.GhostEffectItemList)
				{
					uuiitem.SetUIActive(false);
				}
				this.IsAnyEffectPlaying = false;
			}
		}

		// Token: 0x0402318F RID: 143759
		private const int NUM = 3;

		// Token: 0x04023190 RID: 143760
		private const double EFFECT_TIME = 1000.0;

		// Token: 0x04023191 RID: 143761
		[StaticVariableRuleIgnore]
		private static readonly int[] GhostTags = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.R2T1LuokekeMd10011.状态标识.灵感1层"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1LuokekeMd10011.状态标识.灵感2层"],
			GameplayTagDefine.EGameplayTagId["角色.R2T1LuokekeMd10011.状态标识.灵感3层"]
		};

		// Token: 0x04023192 RID: 143762
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023193 RID: 143763
		private readonly List<UUIItem> GhostItemList = new List<UUIItem>();

		// Token: 0x04023194 RID: 143764
		private readonly List<UUIItem> GhostEffectItemList = new List<UUIItem>();

		// Token: 0x04023195 RID: 143765
		private bool IsAnyEffectPlaying;

		// Token: 0x04023196 RID: 143766
		private double EffectFinishTime;

		// Token: 0x04023197 RID: 143767
		private bool IsInGhost;

		// Token: 0x04023198 RID: 143768
		private int LastGhostCount;

		// Token: 0x04023199 RID: 143769
		private int LastVisibleGhostCount;

		// Token: 0x0200C213 RID: 49683
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BCDF RID: 244959
			SlotBarItem,
			// Token: 0x0403BCE0 RID: 244960
			GhostItem1,
			// Token: 0x0403BCE1 RID: 244961
			GhostItem2,
			// Token: 0x0403BCE2 RID: 244962
			GhostItem3,
			// Token: 0x0403BCE3 RID: 244963
			GhostEffectItem1,
			// Token: 0x0403BCE4 RID: 244964
			GhostEffectItem2,
			// Token: 0x0403BCE5 RID: 244965
			GhostEffectItem3,
			// Token: 0x0403BCE6 RID: 244966
			AniGhostIn,
			// Token: 0x0403BCE7 RID: 244967
			AniGhostOut
		}
	}
}
