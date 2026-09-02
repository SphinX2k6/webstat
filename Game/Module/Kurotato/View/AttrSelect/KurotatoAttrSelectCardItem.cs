using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AC9 RID: 23241
	[NullableContext(1)]
	[Nullable(0)]
	internal class KurotatoAttrSelectCardItem : UiPanelBase
	{
		// Token: 0x0603AC35 RID: 240693 RVA: 0x00EE6164 File Offset: 0x00EE4364
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action<EToggleState>(this.OnTogglePreviewState));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AC36 RID: 240694 RVA: 0x00EE6318 File Offset: 0x00EE4518
		protected override void OnStart()
		{
			this.AttrScrollList = new GenericScrollViewNew<AttrListItem, string>(base.GetScrollViewWithScrollbar(8), () => new AttrListItem(), null, false, null);
			UUIExtendToggle extendToggle = base.GetExtendToggle(11);
			if (extendToggle != null)
			{
				extendToggle.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPreviewHoverEnter));
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnPointExitCallBack.Bind(new Action<EToggleState>(this.OnPreviewHoverExit));
		}

		// Token: 0x0603AC37 RID: 240695 RVA: 0x00EE6399 File Offset: 0x00EE4599
		protected override void OnBeforeDestroy()
		{
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(false, new List<IKurotatoAttrPreviewDelta>());
		}

		// Token: 0x0603AC38 RID: 240696 RVA: 0x00EE63B1 File Offset: 0x00EE45B1
		public void SetAttrPreviewCb(Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> cb)
		{
			this.AttrPreviewCb = cb;
		}

		// Token: 0x0603AC39 RID: 240697 RVA: 0x00EE63BA File Offset: 0x00EE45BA
		public void ClearAttrPreviewSelection()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(11);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603AC3A RID: 240698 RVA: 0x00EE63D4 File Offset: 0x00EE45D4
		public void Refresh(IKurotatoAttrSelectCardData data)
		{
			this.Data = data;
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoItem value = instance.GetItemConfigByItemId(data.ItemId).Value;
			KurotatoQuality value2 = instance.GetQualityByQuality(value.Quality).Value;
			base.SetTextureByPath(value2.AttrSelectQualityBg, base.GetTexture(0), null, null);
			base.GetTexture(1).SetColor(FColor.FromHex(value2.AttrSelectCircleLight));
			base.GetTexture(2).SetColor(FColor.FromHex(value2.AttrSelectCircle));
			base.GetSprite(3).SetColor(FColor.FromHex(value2.AttrSelectFrame));
			base.SetTextureByPath(value2.AttrSelectLineTexture, base.GetTexture(4), null, null);
			base.SetTextureByPath(value.Icon, base.GetTexture(5), null, null);
			base.GetText(6).ShowTextNew(value.Name);
			base.GetText(6).SetColor(FColor.FromHex(value2.AttrSelectCircleLight));
			List<IKurotatoAttrDisplay> itemAttrDisplayList = KurotatoUtil.GetItemAttrDisplayList(value.EffectIter().ToList<int>(), false, true, false);
			this.AttrScrollList.RefreshByData((from attr in itemAttrDisplayList
			select attr.Text).ToList<string>(), null, false);
			base.GetItem(7).SetUIActive(data.IsRecommend);
		}

		// Token: 0x0603AC3B RID: 240699 RVA: 0x00EE6548 File Offset: 0x00EE4748
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0 || configParams[0] != "UpgradeRecommend")
			{
				return null;
			}
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				item,
				item
			};
		}

		// Token: 0x0603AC3C RID: 240700 RVA: 0x00EE6588 File Offset: 0x00EE4788
		private void OnTogglePreviewState(EToggleState state)
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			if (state == EToggleState.ETT_Checked)
			{
				Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
				if (attrPreviewCb == null)
				{
					return;
				}
				attrPreviewCb(true, this.BuildPreviewDeltas());
				return;
			}
			else
			{
				Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb2 = this.AttrPreviewCb;
				if (attrPreviewCb2 == null)
				{
					return;
				}
				attrPreviewCb2(false, new List<IKurotatoAttrPreviewDelta>());
				return;
			}
		}

		// Token: 0x0603AC3D RID: 240701 RVA: 0x00EE65D4 File Offset: 0x00EE47D4
		private void OnPreviewHoverEnter(EToggleState state)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(true, this.BuildPreviewDeltas());
		}

		// Token: 0x0603AC3E RID: 240702 RVA: 0x00EE65FA File Offset: 0x00EE47FA
		private void OnPreviewHoverExit(EToggleState state)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(false, new List<IKurotatoAttrPreviewDelta>());
		}

		// Token: 0x0603AC3F RID: 240703 RVA: 0x00EE6620 File Offset: 0x00EE4820
		private IReadOnlyList<IKurotatoAttrPreviewDelta> BuildPreviewDeltas()
		{
			List<IKurotatoAttrPreviewDelta> list = new List<IKurotatoAttrPreviewDelta>();
			if (this.Data == null)
			{
				return list;
			}
			KurotatoItem? itemConfigByItemId = ConfigBase<KurotatoConfig>.Instance.GetItemConfigByItemId(this.Data.ItemId);
			if (itemConfigByItemId == null)
			{
				return list;
			}
			foreach (IKurotatoAttrDisplay kurotatoAttrDisplay in KurotatoUtil.GetItemAttrPreviewList(itemConfigByItemId.Value.EffectIter().ToList<int>()))
			{
				list.Add(new KurotatoAttrPreviewDelta
				{
					PropertyId = kurotatoAttrDisplay.PropertyId,
					ValueStr = kurotatoAttrDisplay.Text
				});
			}
			return list;
		}

		// Token: 0x0402138C RID: 136076
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<AttrListItem, string> AttrScrollList;

		// Token: 0x0402138D RID: 136077
		[Nullable(2)]
		private IKurotatoAttrSelectCardData Data;

		// Token: 0x0402138E RID: 136078
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> AttrPreviewCb;

		// Token: 0x0200BAE6 RID: 47846
		[NullableContext(0)]
		private class ECardItemComp
		{
			// Token: 0x04039B07 RID: 236295
			public const int TextureQuality = 0;

			// Token: 0x04039B08 RID: 236296
			public const int TextureCircleLight = 1;

			// Token: 0x04039B09 RID: 236297
			public const int TextureCircleQuality = 2;

			// Token: 0x04039B0A RID: 236298
			public const int SpriteQualityFrame = 3;

			// Token: 0x04039B0B RID: 236299
			public const int TextureQualityLine = 4;

			// Token: 0x04039B0C RID: 236300
			public const int TextureIcon = 5;

			// Token: 0x04039B0D RID: 236301
			public const int TextName = 6;

			// Token: 0x04039B0E RID: 236302
			public const int PanelRecommend = 7;

			// Token: 0x04039B0F RID: 236303
			public const int ScrollAttrList = 8;

			// Token: 0x04039B10 RID: 236304
			public const int Toggle = 11;
		}
	}
}
