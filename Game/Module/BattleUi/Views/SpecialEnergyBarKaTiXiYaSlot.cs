using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C6 RID: 24774
	[NullableContext(1)]
	[Nullable(0)]
	internal class SpecialEnergyBarKaTiXiYaSlot : SpecialEnergyBarBase
	{
		// Token: 0x0603E918 RID: 256280 RVA: 0x0100129C File Offset: 0x00FFF49C
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
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
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E919 RID: 256281 RVA: 0x01001610 File Offset: 0x00FFF810
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKaTiXiYaSlot.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKaTiXiYaSlot.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E91A RID: 256282 RVA: 0x01001654 File Offset: 0x00FFF854
		protected unsafe override void OnStart()
		{
			base.OnStart();
			List<List<UUIItem>> energyItemList = this.EnergyItemList;
			int num = 3;
			List<UUIItem> list = new List<UUIItem>(num);
			CollectionsMarshal.SetCount<UUIItem>(list, num);
			Span<UUIItem> span = CollectionsMarshal.AsSpan<UUIItem>(list);
			int num2 = 0;
			*span[num2] = base.GetItem(0);
			num2++;
			*span[num2] = base.GetItem(1);
			num2++;
			*span[num2] = base.GetItem(2);
			energyItemList.Add(list);
			List<List<UUIItem>> energyItemList2 = this.EnergyItemList;
			num2 = 3;
			List<UUIItem> list2 = new List<UUIItem>(num2);
			CollectionsMarshal.SetCount<UUIItem>(list2, num2);
			span = CollectionsMarshal.AsSpan<UUIItem>(list2);
			num = 0;
			*span[num] = base.GetUiNiagara(3);
			num++;
			*span[num] = base.GetUiNiagara(4);
			num++;
			*span[num] = base.GetUiNiagara(5);
			energyItemList2.Add(list2);
			List<List<UUIItem>> energyItemList3 = this.EnergyItemList;
			num = 3;
			List<UUIItem> list3 = new List<UUIItem>(num);
			CollectionsMarshal.SetCount<UUIItem>(list3, num);
			span = CollectionsMarshal.AsSpan<UUIItem>(list3);
			num2 = 0;
			*span[num2] = base.GetItem(12);
			num2++;
			*span[num2] = base.GetItem(13);
			num2++;
			*span[num2] = base.GetItem(14);
			energyItemList3.Add(list3);
			List<List<UUIItem>> swordItemList = this.SwordItemList;
			num2 = 3;
			List<UUIItem> list4 = new List<UUIItem>(num2);
			CollectionsMarshal.SetCount<UUIItem>(list4, num2);
			span = CollectionsMarshal.AsSpan<UUIItem>(list4);
			num = 0;
			*span[num] = base.GetItem(6);
			num++;
			*span[num] = base.GetItem(7);
			num++;
			*span[num] = base.GetItem(8);
			swordItemList.Add(list4);
			List<List<UUIItem>> swordItemList2 = this.SwordItemList;
			num = 3;
			List<UUIItem> list5 = new List<UUIItem>(num);
			CollectionsMarshal.SetCount<UUIItem>(list5, num);
			span = CollectionsMarshal.AsSpan<UUIItem>(list5);
			num2 = 0;
			*span[num2] = base.GetItem(9);
			num2++;
			*span[num2] = base.GetItem(10);
			num2++;
			*span[num2] = base.GetItem(11);
			swordItemList2.Add(list5);
			this.CollectEffectList.Add(base.GetUiNiagara(15));
			this.CollectEffectList.Add(base.GetUiNiagara(16));
			this.CollectEffectList.Add(base.GetUiNiagara(17));
			this.CollectEffectList.Add(base.GetUiNiagara(18));
			this.CollectEffectList.Add(base.GetUiNiagara(20));
			this.CollectEffectList.Add(base.GetUiNiagara(22));
			this.CollectEffectList.Add(base.GetUiNiagara(15));
			this.CollectEffectList.Add(base.GetUiNiagara(16));
			this.CollectEffectList.Add(base.GetUiNiagara(17));
			this.RefreshState(true);
			this.ListenTags();
		}

		// Token: 0x0603E91B RID: 256283 RVA: 0x010018EC File Offset: 0x00FFFAEC
		private void ListenTags()
		{
			foreach (int tagId in SpecialEnergyBarKaTiXiYaSlot.NormalTagIds)
			{
				base.ListenForTagAddOrRemoveChanged(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnNormalTagChange));
			}
			foreach (int tagId2 in SpecialEnergyBarKaTiXiYaSlot.CollectTagIds)
			{
				base.ListenForTagAddOrRemoveChanged(tagId2, new BaseTagComponent.TTagSwitchedCallback(this.OnCollectTagChange));
			}
		}

		// Token: 0x0603E91C RID: 256284 RVA: 0x01001950 File Offset: 0x00FFFB50
		private void OnNormalTagChange(int tagId, bool tagExist)
		{
			int num = Array.IndexOf<int>(SpecialEnergyBarKaTiXiYaSlot.NormalTagIds, tagId);
			if (num < 0 || this.NormalTagStateList[num] == tagExist)
			{
				return;
			}
			this.NormalTagStateList[num] = tagExist;
			this.RefreshState(false);
			if (tagExist)
			{
				this.PlayCollectEffect(3 + num, 1000);
				return;
			}
			this.PlayCollectEffect(6 + num, 500);
		}

		// Token: 0x0603E91D RID: 256285 RVA: 0x010019B4 File Offset: 0x00FFFBB4
		private void OnCollectTagChange(int tagId, bool tagExist)
		{
			int num = Array.IndexOf<int>(SpecialEnergyBarKaTiXiYaSlot.CollectTagIds, tagId);
			if (num < 0 || this.CollectTagStateList[num] == tagExist)
			{
				return;
			}
			this.CollectTagStateList[num] = tagExist;
			this.RefreshState(false);
			if (tagExist)
			{
				this.PlayCollectEffect(num, 800);
			}
		}

		// Token: 0x0603E91E RID: 256286 RVA: 0x01001A04 File Offset: 0x00FFFC04
		private void RefreshState(bool isStart = false)
		{
			if (this.TagComponent == null)
			{
				return;
			}
			if (isStart)
			{
				foreach (int tagId in SpecialEnergyBarKaTiXiYaSlot.NormalTagIds)
				{
					this.NormalTagStateList.Add(this.TagComponent.HasTag(tagId));
				}
				foreach (int tagId2 in SpecialEnergyBarKaTiXiYaSlot.CollectTagIds)
				{
					this.CollectTagStateList.Add(this.TagComponent.HasTag(tagId2));
				}
			}
			bool enable = false;
			bool uiactive = true;
			for (int j = 0; j < 3; j++)
			{
				bool flag = this.NormalTagStateList[j];
				bool flag2 = this.CollectTagStateList[j];
				int num = 0;
				if (flag2)
				{
					num = 2;
				}
				else if (flag)
				{
					num = 1;
					enable = true;
				}
				else
				{
					uiactive = false;
				}
				for (int k = 0; k < 3; k++)
				{
					this.EnergyItemList[k][j].SetUIActive(k == num);
				}
				this.SwordItemList[0][j].SetUIActive(num == 0);
				this.SwordItemList[1][j].SetUIActive(num != 0);
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.RefreshKeyEnable(enable, isStart);
			}
			UUIItem item = base.GetItem(24);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603E91F RID: 256287 RVA: 0x01001B5C File Offset: 0x00FFFD5C
		private void PlayCollectEffect(int index, int duration)
		{
			UUIItem uuiitem = this.CollectEffectList[index];
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(true);
				this.CollectEffectEndTime[index] = Singleton<Time>.Instance.Now + (double)duration;
				this.IsAnyEffectPlaying = true;
			}
		}

		// Token: 0x0603E920 RID: 256288 RVA: 0x01001BA0 File Offset: 0x00FFFDA0
		protected override void RefreshVisible()
		{
		}

		// Token: 0x0603E921 RID: 256289 RVA: 0x01001BA4 File Offset: 0x00FFFDA4
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.IsAnyEffectPlaying)
			{
				this.IsAnyEffectPlaying = false;
				for (int i = 0; i < this.CollectEffectEndTime.Count; i++)
				{
					double num = this.CollectEffectEndTime[i];
					if (num > 0.0 && num < Singleton<Time>.Instance.Now)
					{
						this.CollectEffectList[i].SetUIActive(false);
						this.CollectEffectEndTime[i] = 0.0;
					}
					else
					{
						this.IsAnyEffectPlaying = true;
					}
				}
			}
		}

		// Token: 0x0603E922 RID: 256290 RVA: 0x01001C34 File Offset: 0x00FFFE34
		public unsafe SpecialEnergyBarKaTiXiYaSlot()
		{
			int num = 9;
			List<double> list = new List<double>(num);
			CollectionsMarshal.SetCount<double>(list, num);
			Span<double> span = CollectionsMarshal.AsSpan<double>(list);
			int num2 = 0;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			num2++;
			*span[num2] = 0.0;
			this.CollectEffectEndTime = list;
			base..ctor();
		}

		// Token: 0x04023141 RID: 143681
		[StaticVariableRuleIgnore]
		private static readonly int[] NormalTagIds = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.幻影剑_水驻场"],
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.幻影剑_风驻场"],
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.幻影剑_重力驻场"]
		};

		// Token: 0x04023142 RID: 143682
		[StaticVariableRuleIgnore]
		private static readonly int[] CollectTagIds = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.拥有幻影剑_水"],
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.拥有幻影剑_风"],
			GameplayTagDefine.EGameplayTagId["角色.Katixiya.状态.拥有幻影剑_重力"]
		};

		// Token: 0x04023143 RID: 143683
		private const int SLOT_NUM = 3;

		// Token: 0x04023144 RID: 143684
		private const int COLLECT_EFFECT_DURATION = 800;

		// Token: 0x04023145 RID: 143685
		private const int COLLECT_IN_EFFECT_DURATION = 1000;

		// Token: 0x04023146 RID: 143686
		private const int COLLECT_OUT_EFFECT_DURATION = 500;

		// Token: 0x04023147 RID: 143687
		private readonly List<bool> NormalTagStateList = new List<bool>();

		// Token: 0x04023148 RID: 143688
		private readonly List<bool> CollectTagStateList = new List<bool>();

		// Token: 0x04023149 RID: 143689
		private readonly List<List<UUIItem>> EnergyItemList = new List<List<UUIItem>>();

		// Token: 0x0402314A RID: 143690
		private readonly List<List<UUIItem>> SwordItemList = new List<List<UUIItem>>();

		// Token: 0x0402314B RID: 143691
		private readonly List<UUIItem> CollectEffectList = new List<UUIItem>();

		// Token: 0x0402314C RID: 143692
		private readonly List<double> CollectEffectEndTime;

		// Token: 0x0402314D RID: 143693
		private bool IsAnyEffectPlaying;

		// Token: 0x0402314E RID: 143694
		[Nullable(2)]
		public UUIItem UiKeyItem;

		// Token: 0x0200C1FF RID: 49663
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BC3B RID: 244795
			EmptyItem11,
			// Token: 0x0403BC3C RID: 244796
			EmptyItem12,
			// Token: 0x0403BC3D RID: 244797
			EmptyItem13,
			// Token: 0x0403BC3E RID: 244798
			FullEffect21,
			// Token: 0x0403BC3F RID: 244799
			FullEffect22,
			// Token: 0x0403BC40 RID: 244800
			FullEffect23,
			// Token: 0x0403BC41 RID: 244801
			SwordIcon11,
			// Token: 0x0403BC42 RID: 244802
			SwordIcon12,
			// Token: 0x0403BC43 RID: 244803
			SwordIcon13,
			// Token: 0x0403BC44 RID: 244804
			SwordIcon21,
			// Token: 0x0403BC45 RID: 244805
			SwordIcon22,
			// Token: 0x0403BC46 RID: 244806
			SwordIcon23,
			// Token: 0x0403BC47 RID: 244807
			FullEffect31,
			// Token: 0x0403BC48 RID: 244808
			FullEffect32,
			// Token: 0x0403BC49 RID: 244809
			FullEffect33,
			// Token: 0x0403BC4A RID: 244810
			CollectEffect1,
			// Token: 0x0403BC4B RID: 244811
			CollectEffect2,
			// Token: 0x0403BC4C RID: 244812
			CollectEffect3,
			// Token: 0x0403BC4D RID: 244813
			CollectInEffect1,
			// Token: 0x0403BC4E RID: 244814
			CollectOutEffect1,
			// Token: 0x0403BC4F RID: 244815
			CollectInEffect2,
			// Token: 0x0403BC50 RID: 244816
			CollectOutEffect2,
			// Token: 0x0403BC51 RID: 244817
			CollectInEffect3,
			// Token: 0x0403BC52 RID: 244818
			CollectOutEffect3,
			// Token: 0x0403BC53 RID: 244819
			CollectAllItem
		}
	}
}
