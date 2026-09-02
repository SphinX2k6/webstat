using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E4B RID: 20043
	public class TrapDefenseShopCheckBuffItem : UiPanelBase
	{
		// Token: 0x06033CD4 RID: 212180 RVA: 0x00CF33A4 File Offset: 0x00CF15A4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnSelfClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033CD5 RID: 212181 RVA: 0x00CF3534 File Offset: 0x00CF1734
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseShopCheckBuffItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseShopCheckBuffItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033CD6 RID: 212182 RVA: 0x00CF3578 File Offset: 0x00CF1778
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			base.GetTexture(0).SetUIActive(false);
			base.GetSprite(7).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), ETrapDefenseTextKey.ShopBuffViewEntry.ToString(), Array.Empty<object>());
		}

		// Token: 0x06033CD7 RID: 212183 RVA: 0x00CF35D4 File Offset: 0x00CF17D4
		private void OnBtnSelfClicked()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewBdSum(null, null, null);
		}

		// Token: 0x0200ADE1 RID: 44513
		private class EComponentDefine
		{
			// Token: 0x04035FDE RID: 221150
			public const int TextureIcon = 0;

			// Token: 0x04035FDF RID: 221151
			public const int TextNum = 1;

			// Token: 0x04035FE0 RID: 221152
			public const int BtnAdd = 2;

			// Token: 0x04035FE1 RID: 221153
			public const int BtnSelf = 3;

			// Token: 0x04035FE2 RID: 221154
			public const int TextureIconTrans = 4;

			// Token: 0x04035FE3 RID: 221155
			public const int Item = 5;

			// Token: 0x04035FE4 RID: 221156
			public const int SpriteFill = 6;

			// Token: 0x04035FE5 RID: 221157
			public const int SpriteIcon = 7;

			// Token: 0x04035FE6 RID: 221158
			public const int SpriteMax = 8;
		}
	}
}
