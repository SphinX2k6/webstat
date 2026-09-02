using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006762 RID: 26466
	internal class LineCrossClawItem : UiPanelBase
	{
		// Token: 0x06041F9E RID: 270238 RVA: 0x010ED8F4 File Offset: 0x010EBAF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041F9F RID: 270239 RVA: 0x010ED9E4 File Offset: 0x010EBBE4
		public void Refresh(bool ifHidden, ELineCrossGroupState state)
		{
			string resourceId;
			string resourceId2;
			switch (state)
			{
			case ELineCrossGroupState.Normal:
				this.RefreshNormal();
				resourceId = "T_CrosslineCraw1";
				resourceId2 = "T_CrosslineCraw";
				break;
			case ELineCrossGroupState.Passed:
				this.RefreshClear();
				resourceId = "T_CrosslineCraw1";
				resourceId2 = "T_CrosslineCraw";
				break;
			case ELineCrossGroupState.Lock:
				this.RefreshLock();
				resourceId = "T_CrosslineCrawLine";
				resourceId2 = "T_CrosslineCraw";
				break;
			default:
				this.RefreshNormal();
				resourceId = "T_CrosslineCraw1";
				resourceId2 = "T_CrosslineCraw";
				break;
			}
			if (ifHidden)
			{
				resourceId = "T_CrosslineCrawLineMystery";
				resourceId2 = "T_CrosslineCrawLineMystery";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
			base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
			base.SetTextureByPath(resourcePath2, base.GetTexture(3), null, null);
		}

		// Token: 0x06041FA0 RID: 270240 RVA: 0x010EDAB8 File Offset: 0x010EBCB8
		private void RefreshNormal()
		{
			base.GetTexture(0).SetColor(FColor.FromHex("764372"));
			base.GetTexture(1).SetColor(FColor.FromHex("444dba"));
			base.GetTexture(2).SetColor(FColor.FromHex("c594ff"));
			base.GetTexture(3).SetColor(FColor.FromHex("c594ff"));
			base.GetSprite(4).SetColor(FColor.FromHex("582e8c"));
			base.GetSprite(5).SetColor(FColor.FromHex("582e8c"));
			base.GetSprite(4).SetUIActive(true);
			base.GetSprite(5).SetUIActive(true);
		}

		// Token: 0x06041FA1 RID: 270241 RVA: 0x010EDB64 File Offset: 0x010EBD64
		private void RefreshClear()
		{
			base.GetTexture(0).SetColor(FColor.FromHex("764372"));
			base.GetTexture(1).SetColor(FColor.FromHex("6dac75"));
			base.GetTexture(2).SetColor(FColor.FromHex("b2ffbf"));
			base.GetTexture(3).SetColor(FColor.FromHex("b2ffbf"));
			base.GetSprite(4).SetColor(FColor.FromHex("45945b"));
			base.GetSprite(5).SetColor(FColor.FromHex("45945b"));
			base.GetSprite(4).SetUIActive(true);
			base.GetSprite(5).SetUIActive(true);
		}

		// Token: 0x06041FA2 RID: 270242 RVA: 0x010EDC10 File Offset: 0x010EBE10
		private void RefreshLock()
		{
			base.GetTexture(0).SetColor(FColor.FromHex("4e4e4e"));
			base.GetTexture(1).SetColor(FColor.FromHex("5d6161"));
			base.GetTexture(2).SetColor(FColor.FromHex("c65959"));
			base.GetTexture(3).SetColor(FColor.FromHex("c65959"));
			base.GetSprite(4).SetUIActive(false);
			base.GetSprite(5).SetUIActive(false);
		}

		// Token: 0x0200C781 RID: 51073
		private class EComponent
		{
			// Token: 0x0403D6B7 RID: 251575
			public const int TextureDesc1 = 0;

			// Token: 0x0403D6B8 RID: 251576
			public const int TextureDesc2 = 1;

			// Token: 0x0403D6B9 RID: 251577
			public const int ClawTexture1 = 2;

			// Token: 0x0403D6BA RID: 251578
			public const int ClawTexture2 = 3;

			// Token: 0x0403D6BB RID: 251579
			public const int SpriteDesc3 = 4;

			// Token: 0x0403D6BC RID: 251580
			public const int SpriteDesc4 = 5;
		}
	}
}
