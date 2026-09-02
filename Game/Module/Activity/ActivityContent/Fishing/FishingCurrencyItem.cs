using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680C RID: 26636
	public class FishingCurrencyItem : UiPanelBase
	{
		// Token: 0x0604264A RID: 271946 RVA: 0x01104BCC File Offset: 0x01102DCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITextureTransitionComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604264B RID: 271947 RVA: 0x01104D5C File Offset: 0x01102F5C
		protected override UniTask OnBeforeStartAsync()
		{
			FishingCurrencyItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingCurrencyItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604264C RID: 271948 RVA: 0x01104DA0 File Offset: 0x01102FA0
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingShipDataRefresh, new Action(this.FishingShipDataRefresh));
			UUITexture texture = base.GetTexture(0);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUISprite sprite = base.GetSprite(7);
			sprite.SetUIActive(true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_FightHp");
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x0604264D RID: 271949 RVA: 0x01104E54 File Offset: 0x01103054
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingShipDataRefresh, new Action(this.FishingShipDataRefresh));
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			shipData.RemoveAttributeListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.FishingShipAttributeRefresh));
			shipData.RemoveAttributeListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.FishingShipAttributeRefresh));
		}

		// Token: 0x0604264E RID: 271950 RVA: 0x01104EAC File Offset: 0x011030AC
		protected override void OnBeforeShow()
		{
			this.RefreshItem();
		}

		// Token: 0x0604264F RID: 271951 RVA: 0x01104EB4 File Offset: 0x011030B4
		public void RefreshItem()
		{
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			float currentHp = shipData.GetCurrentHp();
			float maxHp = shipData.GetMaxHp();
			base.GetText(1).SetText(currentHp.ToString() + "/" + maxHp.ToString(), true);
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("FishingLowFixTips").GetValueOrDefault();
			UiPanelBase lowPowerTips = this.LowPowerTips;
			if (lowPowerTips == null)
			{
				return;
			}
			lowPowerTips.SetUiActive(currentHp < (float)valueOrDefault);
		}

		// Token: 0x06042650 RID: 271952 RVA: 0x01104F25 File Offset: 0x01103125
		private void OnClickButton()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(186);
		}

		// Token: 0x06042651 RID: 271953 RVA: 0x01104F36 File Offset: 0x01103136
		private void FishingShipAttributeRefresh(EAttributeType attrId, float oldValue, float newValue)
		{
			this.RefreshItem();
		}

		// Token: 0x06042652 RID: 271954 RVA: 0x01104F3E File Offset: 0x0110313E
		private void FishingShipDataRefresh()
		{
			this.RefreshItem();
			FishingShipData shipData = ModelBase<FishingModel>.Instance.GetShipData();
			shipData.AddAttributeListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.FishingShipAttributeRefresh));
			shipData.AddAttributeListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.FishingShipAttributeRefresh));
		}

		// Token: 0x04024F9A RID: 151450
		[Nullable(2)]
		private UiPanelBase LowPowerTips;

		// Token: 0x0200C83E RID: 51262
		private class EComponentDefine
		{
			// Token: 0x0403D9DA RID: 252378
			public const int Texture = 0;

			// Token: 0x0403D9DB RID: 252379
			public const int CountText = 1;

			// Token: 0x0403D9DC RID: 252380
			public const int Button = 2;

			// Token: 0x0403D9DD RID: 252381
			public const int TextureButton = 3;

			// Token: 0x0403D9DE RID: 252382
			public const int TextureTransition = 4;

			// Token: 0x0403D9DF RID: 252383
			public const int SliderItem = 5;

			// Token: 0x0403D9E0 RID: 252384
			public const int SliderSprite = 6;

			// Token: 0x0403D9E1 RID: 252385
			public const int SpriteIcon = 7;

			// Token: 0x0403D9E2 RID: 252386
			public const int MaxItem = 8;
		}
	}
}
