using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3E RID: 20030
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMonsterDescPanel : UiPanelBase
	{
		// Token: 0x06033C51 RID: 212049 RVA: 0x00CF0E04 File Offset: 0x00CEF004
		public UniTask Init(UUIItem item)
		{
			TrapDefenseMonsterDescPanel.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseMonsterDescPanel.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033C52 RID: 212050 RVA: 0x00CF0E4F File Offset: 0x00CEF04F
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033C53 RID: 212051 RVA: 0x00CF0E54 File Offset: 0x00CEF054
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C54 RID: 212052 RVA: 0x00CF0FA8 File Offset: 0x00CEF1A8
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMonsterDescPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMonsterDescPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C55 RID: 212053 RVA: 0x00CF0FEB File Offset: 0x00CEF1EB
		protected override void OnStart()
		{
		}

		// Token: 0x06033C56 RID: 212054 RVA: 0x00CF0FED File Offset: 0x00CEF1ED
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033C57 RID: 212055 RVA: 0x00CF0FEF File Offset: 0x00CEF1EF
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033C58 RID: 212056 RVA: 0x00CF0FF4 File Offset: 0x00CEF1F4
		public void UpdateData(TrapDefenseMonsterData data)
		{
			this.ItemData = data;
			UUITexture texture = base.GetTexture(0);
			base.SetTextureByPath(data.IconPath, texture, null, null);
			UUITexture texture2 = base.GetTexture(1);
			base.SetTextureByPath(data.GetQualityPathDesc(), texture2, null, null);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(data.NameKey);
			}
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.ShowTextNew(data.GetRiskTypeNameKey());
			}
			UUIText text3 = base.GetText(4);
			if (text3 != null)
			{
				text3.ShowTextNew(data.GetBodyTypeNameKey());
			}
			this.UpdateAttrShow();
		}

		// Token: 0x06033C59 RID: 212057 RVA: 0x00CF1094 File Offset: 0x00CEF294
		public void UpdateAttrShow()
		{
			List<ITrapDefenseAttrItemData> attrDataShowList = this.ItemData.GetAttrDataShowList();
			List<ITrapDefenseAttrItemData> tagDataShowList = this.ItemData.GetTagDataShowList();
			UUILayoutBase layoutBase = base.GetLayoutBase(5);
			if (layoutBase != null)
			{
				layoutBase.RootUIComp.Get().SetUIActive(attrDataShowList.Count > 0);
			}
			if (attrDataShowList.Count > 0)
			{
				this.LayoutAttr.RefreshByData(attrDataShowList, null, false);
			}
			UUILayoutBase layoutBase2 = base.GetLayoutBase(7);
			if (layoutBase2 != null)
			{
				layoutBase2.RootUIComp.Get().SetUIActive(tagDataShowList.Count > 0);
			}
			if (tagDataShowList.Count > 0)
			{
				this.LayoutTag.RefreshByData(tagDataShowList, null, false);
			}
		}

		// Token: 0x06033C5A RID: 212058 RVA: 0x00CF1137 File Offset: 0x00CEF337
		public TrapDefenseAttrItem CreateItemAttr()
		{
			return new TrapDefenseAttrItem();
		}

		// Token: 0x06033C5B RID: 212059 RVA: 0x00CF113E File Offset: 0x00CEF33E
		public TrapDefenseTagAttrItem CreateItemTag()
		{
			return new TrapDefenseTagAttrItem();
		}

		// Token: 0x0401DF5F RID: 122719
		public TrapDefenseMonsterData ItemData;

		// Token: 0x0401DF60 RID: 122720
		public TrapDefenseMonsterViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelMonster;

		// Token: 0x0401DF61 RID: 122721
		public GenericLayout<TrapDefenseAttrItem, ITrapDefenseAttrItemData> LayoutAttr;

		// Token: 0x0401DF62 RID: 122722
		public GenericLayout<TrapDefenseTagAttrItem, ITrapDefenseAttrItemData> LayoutTag;

		// Token: 0x0200ADC6 RID: 44486
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F64 RID: 221028
			public const int TextureIcon = 0;

			// Token: 0x04035F65 RID: 221029
			public const int TextureQuality = 1;

			// Token: 0x04035F66 RID: 221030
			public const int TextName = 2;

			// Token: 0x04035F67 RID: 221031
			public const int TextRiskType = 3;

			// Token: 0x04035F68 RID: 221032
			public const int TextBodyType = 4;

			// Token: 0x04035F69 RID: 221033
			public const int LayoutAttr = 5;

			// Token: 0x04035F6A RID: 221034
			public const int ItemAttr = 6;

			// Token: 0x04035F6B RID: 221035
			public const int LayoutTag = 7;

			// Token: 0x04035F6C RID: 221036
			public const int ItemTag = 8;
		}
	}
}
