using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F9 RID: 24825
	public class SpecialEnergyBarMorphCountDown : SpecialEnergyBarBase
	{
		// Token: 0x0603EB97 RID: 256919 RVA: 0x0100F0B4 File Offset: 0x0100D2B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EB98 RID: 256920 RVA: 0x0100F180 File Offset: 0x0100D380
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarMorphCountDown.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarMorphCountDown.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB99 RID: 256921 RVA: 0x0100F1C4 File Offset: 0x0100D3C4
		[NullableContext(1)]
		protected UniTask InitPointLeftItem(UUIItem pointItem)
		{
			SpecialEnergyBarMorphCountDown.<InitPointLeftItem>d__12 <InitPointLeftItem>d__;
			<InitPointLeftItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointLeftItem>d__.<>4__this = this;
			<InitPointLeftItem>d__.pointItem = pointItem;
			<InitPointLeftItem>d__.<>1__state = -1;
			<InitPointLeftItem>d__.<>t__builder.Start<SpecialEnergyBarMorphCountDown.<InitPointLeftItem>d__12>(ref <InitPointLeftItem>d__);
			return <InitPointLeftItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB9A RID: 256922 RVA: 0x0100F210 File Offset: 0x0100D410
		[NullableContext(1)]
		protected UniTask InitPointRightItem(UUIItem pointItem)
		{
			SpecialEnergyBarMorphCountDown.<InitPointRightItem>d__13 <InitPointRightItem>d__;
			<InitPointRightItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointRightItem>d__.<>4__this = this;
			<InitPointRightItem>d__.pointItem = pointItem;
			<InitPointRightItem>d__.<>1__state = -1;
			<InitPointRightItem>d__.<>t__builder.Start<SpecialEnergyBarMorphCountDown.<InitPointRightItem>d__13>(ref <InitPointRightItem>d__);
			return <InitPointRightItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB9B RID: 256923 RVA: 0x0100F25C File Offset: 0x0100D45C
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			float effectBasePercent = (float)this.PointNum / 41f;
			ValueTuple<float, float> effectBasePercents = this.GetEffectBasePercents(effectBasePercent);
			float item = effectBasePercents.Item1;
			float item2 = effectBasePercents.Item2;
			ValueTuple<int, int> effectPointNums = this.GetEffectPointNums(this.PointNum);
			int item3 = effectPointNums.Item1;
			int item4 = effectPointNums.Item2;
			this.PointLeftItem.SetEffectBasePercents(item, new float?(item2), item3, new int?(item4));
			this.PointRightItem.SetEffectBasePercents(item, new float?(item2), item3, new int?(item4));
			if (!string.IsNullOrEmpty(this.Config.EffectColor))
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				this.PointLeftItem.SetFullEffectColor(flinearColor, true);
				this.PointRightItem.SetFullEffectColor(flinearColor, true);
			}
			if (!string.IsNullOrEmpty(this.Config.IconPath))
			{
				UUITexture[] iconTextureList = new UUITexture[]
				{
					base.GetTexture(2)
				};
				this.IconHandle.Init(iconTextureList, base.GetItem(4));
				this.IconHandle.SetIcon(this.Config.IconPath);
			}
			if (this.StartEffectFinishTime == 0.0)
			{
				base.GetUiNiagara(3).SetUIActive(false);
			}
			this.RefreshBarPercent();
		}

		// Token: 0x0603EB9C RID: 256924 RVA: 0x0100F39D File Offset: 0x0100D59D
		protected virtual ValueTuple<float, float> GetEffectBasePercents(float effectBasePercent)
		{
			return new ValueTuple<float, float>(effectBasePercent, effectBasePercent);
		}

		// Token: 0x0603EB9D RID: 256925 RVA: 0x0100F3A6 File Offset: 0x0100D5A6
		protected virtual ValueTuple<int, int> GetEffectPointNums(int pointNum)
		{
			return new ValueTuple<int, int>(pointNum, pointNum);
		}

		// Token: 0x0603EB9E RID: 256926 RVA: 0x0100F3AF File Offset: 0x0100D5AF
		protected virtual int GetUseEffectPointOffsetNum(int pointNum)
		{
			return 0;
		}

		// Token: 0x0603EB9F RID: 256927 RVA: 0x0100F3B2 File Offset: 0x0100D5B2
		public override void OnChangeVisibleByTagChange(bool visible)
		{
			if (visible)
			{
				base.GetUiNiagara(3).SetUIActive(true);
				this.StartEffectFinishTime = 500.0 + Singleton<Time>.Instance.Now;
			}
		}

		// Token: 0x0603EBA0 RID: 256928 RVA: 0x0100F3DE File Offset: 0x0100D5DE
		protected override void OnBeforeShow()
		{
			if ((byte)this.Config.PrefabType == 9)
			{
				base.GetUiNiagara(3).SetUIActive(true);
				this.StartEffectFinishTime = 500.0 + Singleton<Time>.Instance.Now;
			}
		}

		// Token: 0x0603EBA1 RID: 256929 RVA: 0x0100F418 File Offset: 0x0100D618
		protected void RefreshBarPercent()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			int useEffectPointOffsetNum = this.GetUseEffectPointOffsetNum(this.PointNum);
			this.PointLeftItem.UpdatePercent(curPercent, true, useEffectPointOffsetNum);
			this.PointRightItem.UpdatePercent(curPercent, true, useEffectPointOffsetNum);
			bool isPlay = this.Config.ExtraFloatParams.Count > 0 && curPercent < this.Config.ExtraFloatParams[0];
			this.IconHandle.PlayEndAnim(isPlay);
		}

		// Token: 0x0603EBA2 RID: 256930 RVA: 0x0100F491 File Offset: 0x0100D691
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent();
		}

		// Token: 0x0603EBA3 RID: 256931 RVA: 0x0100F49C File Offset: 0x0100D69C
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarPointItem pointLeftItem = this.PointLeftItem;
			if (pointLeftItem != null)
			{
				pointLeftItem.Tick(delta);
			}
			SpecialEnergyBarPointItem pointRightItem = this.PointRightItem;
			if (pointRightItem != null)
			{
				pointRightItem.Tick(delta);
			}
			if (this.StartEffectFinishTime > 0.0 && this.StartEffectFinishTime <= Singleton<Time>.Instance.Now)
			{
				base.GetUiNiagara(3).SetUIActive(false);
				this.StartEffectFinishTime = 0.0;
			}
		}

		// Token: 0x0603EBA4 RID: 256932 RVA: 0x0100F513 File Offset: 0x0100D713
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.IconHandle.OnBeforeDestroy();
		}

		// Token: 0x040232D0 RID: 144080
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly int[] PointNumList = new int[]
		{
			19,
			20
		};

		// Token: 0x040232D1 RID: 144081
		private const int TOTAL_NUM = 41;

		// Token: 0x040232D2 RID: 144082
		private const float POINT_WIDTH = 9f;

		// Token: 0x040232D3 RID: 144083
		private const double EFFECT_DURATION = 500.0;

		// Token: 0x040232D4 RID: 144084
		[Nullable(2)]
		private SpecialEnergyBarPointItem PointLeftItem;

		// Token: 0x040232D5 RID: 144085
		[Nullable(2)]
		private SpecialEnergyBarPointItem PointRightItem;

		// Token: 0x040232D6 RID: 144086
		[Nullable(1)]
		private readonly SpecialEnergyBaIconHandle IconHandle = new SpecialEnergyBaIconHandle();

		// Token: 0x040232D7 RID: 144087
		private double StartEffectFinishTime;

		// Token: 0x040232D8 RID: 144088
		private int PointNum;

		// Token: 0x0200C27F RID: 49791
		private enum EChildType
		{
			// Token: 0x0403BF66 RID: 245606
			PointLeftItem,
			// Token: 0x0403BF67 RID: 245607
			PointRightItem,
			// Token: 0x0403BF68 RID: 245608
			IconTexture,
			// Token: 0x0403BF69 RID: 245609
			StartEffect,
			// Token: 0x0403BF6A RID: 245610
			AnimItem
		}
	}
}
