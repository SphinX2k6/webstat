using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FE RID: 24830
	public class SpecialEnergyBarPoint : SpecialEnergyBarBase
	{
		// Token: 0x0603EBB6 RID: 256950 RVA: 0x0100F7D8 File Offset: 0x0100D9D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EBB7 RID: 256951 RVA: 0x0100F864 File Offset: 0x0100DA64
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarPoint.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarPoint.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBB8 RID: 256952 RVA: 0x0100F8A8 File Offset: 0x0100DAA8
		[NullableContext(1)]
		protected UniTask InitPointItem(UUIItem pointItem)
		{
			SpecialEnergyBarPoint.<InitPointItem>d__7 <InitPointItem>d__;
			<InitPointItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPointItem>d__.<>4__this = this;
			<InitPointItem>d__.pointItem = pointItem;
			<InitPointItem>d__.<>1__state = -1;
			<InitPointItem>d__.<>t__builder.Start<SpecialEnergyBarPoint.<InitPointItem>d__7>(ref <InitPointItem>d__);
			return <InitPointItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EBB9 RID: 256953 RVA: 0x0100F8F4 File Offset: 0x0100DAF4
		protected override void OnStart()
		{
			if (this.Config == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(this.Config.EffectColor))
			{
				FColor fcolor = FColor.FromHex(this.Config.EffectColor);
				FLinearColor flinearColor = new FLinearColor(ref fcolor);
				this.PointItem.SetFullEffectColor(flinearColor, false);
			}
			base.GetItem(2).SetUIActive(!this.IsMorph);
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603EBBA RID: 256954 RVA: 0x0100F960 File Offset: 0x0100DB60
		protected void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			this.PointItem.UpdatePercent(curPercent, true, 0);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(this.GetKeyEnable(), isStart);
		}

		// Token: 0x0603EBBB RID: 256955 RVA: 0x0100F99E File Offset: 0x0100DB9E
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBBC RID: 256956 RVA: 0x0100F9A7 File Offset: 0x0100DBA7
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EBBD RID: 256957 RVA: 0x0100F9B0 File Offset: 0x0100DBB0
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarPointItem pointItem = this.PointItem;
			if (pointItem == null)
			{
				return;
			}
			pointItem.Tick(delta);
		}

		// Token: 0x040232E2 RID: 144098
		private const int POINT_NUM = 41;

		// Token: 0x040232E3 RID: 144099
		private const float POINT_WIDTH = 9f;

		// Token: 0x040232E4 RID: 144100
		[Nullable(2)]
		private SpecialEnergyBarPointItem PointItem;

		// Token: 0x040232E5 RID: 144101
		public bool IsMorph;

		// Token: 0x0200C284 RID: 49796
		private enum EChildType
		{
			// Token: 0x0403BF7C RID: 245628
			PointItem,
			// Token: 0x0403BF7D RID: 245629
			KeyContainerItem,
			// Token: 0x0403BF7E RID: 245630
			BottomDescItem
		}
	}
}
