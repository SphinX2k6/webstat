using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AE RID: 24750
	public class SpecialEnergyBarBuLanTe : SpecialEnergyBarBase
	{
		// Token: 0x0603E7E3 RID: 255971 RVA: 0x00FF9750 File Offset: 0x00FF7950
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E7E4 RID: 255972 RVA: 0x00FF9908 File Offset: 0x00FF7B08
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarBuLanTe.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarBuLanTe.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7E5 RID: 255973 RVA: 0x00FF994C File Offset: 0x00FF7B4C
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarBuLanTe.<InitBarItem>d__10 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarBuLanTe.<InitBarItem>d__10>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7E6 RID: 255974 RVA: 0x00FF9990 File Offset: 0x00FF7B90
		private UniTask InitStarItems(int index)
		{
			SpecialEnergyBarBuLanTe.<InitStarItems>d__11 <InitStarItems>d__;
			<InitStarItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitStarItems>d__.<>4__this = this;
			<InitStarItems>d__.index = index;
			<InitStarItems>d__.<>1__state = -1;
			<InitStarItems>d__.<>t__builder.Start<SpecialEnergyBarBuLanTe.<InitStarItems>d__11>(ref <InitStarItems>d__);
			return <InitStarItems>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7E7 RID: 255975 RVA: 0x00FF99DC File Offset: 0x00FF7BDC
		protected override void OnStart()
		{
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.PlayTweenAnim(11);
			this.IconHandle.Init(new UUITexture[]
			{
				base.GetTexture(2)
			}, null);
			this.RefreshFullEffect(true);
			this.RefreshBottomBar(true);
			this.RefreshStarEffectItem(true);
		}

		// Token: 0x0603E7E8 RID: 255976 RVA: 0x00FF9A4F File Offset: 0x00FF7C4F
		protected override void OnBarPercentChanged()
		{
			this.RefreshFullEffect(false);
			this.RefreshBottomBar(false);
			this.RefreshStarEffectItem(false);
		}

		// Token: 0x0603E7E9 RID: 255977 RVA: 0x00FF9A68 File Offset: 0x00FF7C68
		private void RefreshFullEffect(bool isStart = false)
		{
			bool flag = this.PercentMachine.GetCurPercent() >= this.Config.DisableKeyOnPercent;
			if (this.IsFull == flag && !isStart)
			{
				return;
			}
			this.IsFull = flag;
			if (this.IsFull)
			{
				base.StopTweenAnim(7);
				base.PlayTweenAnim(6);
				return;
			}
			if (!isStart)
			{
				base.StopTweenAnim(6);
				base.PlayTweenAnim(7);
				return;
			}
			base.StopTweenAnim(6);
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			UUITexture texture2 = base.GetTexture(2);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetAlpha(1f);
		}

		// Token: 0x0603E7EA RID: 255978 RVA: 0x00FF9B00 File Offset: 0x00FF7D00
		private void RefreshBottomBar(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount(curPercent);
			}
			bool flag = curPercent <= 0f;
			if (this.IsEmpty == flag && !isStart)
			{
				return;
			}
			this.IsEmpty = flag;
			SpecialEnergyBaIconHandle iconHandle = this.IconHandle;
			string icon;
			if (!flag)
			{
				SpecialEnergyBarInfo config = this.Config;
				icon = ((config != null) ? config.EnableIconPath : null);
			}
			else
			{
				SpecialEnergyBarInfo config2 = this.Config;
				icon = ((config2 != null) ? config2.IconPath : null);
			}
			iconHandle.SetIcon(icon);
			foreach (SpecialEnergyBarBuLanTeStarItem specialEnergyBarBuLanTeStarItem in this.StarItemList)
			{
				specialEnergyBarBuLanTeStarItem.SetIsEmpty(flag);
			}
		}

		// Token: 0x0603E7EB RID: 255979 RVA: 0x00FF9BC4 File Offset: 0x00FF7DC4
		private void RefreshStarEffectItem(bool isStart = false)
		{
			int num = Math.Min((int)MathF.Floor(this.PercentMachine.GetCurPercent() * 4f), 3);
			for (int i = this.StarCount; i < num; i++)
			{
				base.PlayTweenAnim(8 + i);
			}
			for (int j = num; j < 3; j++)
			{
				this.StarItemList[j].SetStarEnable(false);
			}
			this.StarCount = num;
		}

		// Token: 0x0603E7EC RID: 255980 RVA: 0x00FF9C2E File Offset: 0x00FF7E2E
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

		// Token: 0x0603E7ED RID: 255981 RVA: 0x00FF9C48 File Offset: 0x00FF7E48
		protected override void OnBeforeDestroy()
		{
			this.IconHandle.OnBeforeDestroy();
			base.OnBeforeDestroy();
		}

		// Token: 0x04023077 RID: 143479
		private const int NUM = 3;

		// Token: 0x04023078 RID: 143480
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023079 RID: 143481
		[Nullable(1)]
		private readonly SpecialEnergyBaIconHandle IconHandle = new SpecialEnergyBaIconHandle();

		// Token: 0x0402307A RID: 143482
		[Nullable(1)]
		private readonly List<SpecialEnergyBarBuLanTeStarItem> StarItemList = new List<SpecialEnergyBarBuLanTeStarItem>();

		// Token: 0x0402307B RID: 143483
		private bool IsEmpty;

		// Token: 0x0402307C RID: 143484
		private bool IsFull;

		// Token: 0x0402307D RID: 143485
		private int StarCount;

		// Token: 0x0200C1CD RID: 49613
		private enum EChildType
		{
			// Token: 0x0403BACA RID: 244426
			SlotBarItem,
			// Token: 0x0403BACB RID: 244427
			BarSprite,
			// Token: 0x0403BACC RID: 244428
			BarBgTexture,
			// Token: 0x0403BACD RID: 244429
			StarItem1,
			// Token: 0x0403BACE RID: 244430
			StarItem2,
			// Token: 0x0403BACF RID: 244431
			StarItem3,
			// Token: 0x0403BAD0 RID: 244432
			AniFull,
			// Token: 0x0403BAD1 RID: 244433
			AniUse,
			// Token: 0x0403BAD2 RID: 244434
			AniStar1,
			// Token: 0x0403BAD3 RID: 244435
			AniStar2,
			// Token: 0x0403BAD4 RID: 244436
			AniStar3,
			// Token: 0x0403BAD5 RID: 244437
			AniDefault
		}
	}
}
