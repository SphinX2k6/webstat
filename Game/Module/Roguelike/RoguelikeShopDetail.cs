using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A3 RID: 20899
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeShopDetail : UiPanelBase
	{
		// Token: 0x06035BF0 RID: 220144 RVA: 0x00D83628 File Offset: 0x00D81828
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, this.OnBtnConfirm);
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BF1 RID: 220145 RVA: 0x00D83816 File Offset: 0x00D81A16
		protected override void OnStart()
		{
			this.GenericLayout = new GenericLayout<CommonElementItem, int>(base.GetHorizontalLayout(11), this.CreateElement, null, false, true);
		}

		// Token: 0x06035BF2 RID: 220146 RVA: 0x00D83834 File Offset: 0x00D81A34
		public void Refresh(RogueGainEntry data)
		{
			RoguelikeShopDetail.<>c__DisplayClass7_0 CS$<>8__locals1 = new RoguelikeShopDetail.<>c__DisplayClass7_0();
			CS$<>8__locals1.data = data;
			CS$<>8__locals1.<>4__this = this;
			AsyncTask task = new AsyncTask("RoguelikeShopDetail.Refresh", delegate()
			{
				RoguelikeShopDetail.<>c__DisplayClass7_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RoguelikeShopDetail.<>c__DisplayClass7_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run().Forget<bool>();
		}

		// Token: 0x0401ED7D RID: 126333
		private readonly List<RoguelikeShopAttrItem> AttrItemList = new List<RoguelikeShopAttrItem>();

		// Token: 0x0401ED7E RID: 126334
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonElementItem, int> GenericLayout;

		// Token: 0x0401ED7F RID: 126335
		private readonly Func<CommonElementItem> CreateElement = () => new CommonElementItem();

		// Token: 0x0401ED80 RID: 126336
		private readonly Action OnBtnConfirm = delegate()
		{
			ControllerBase<RoguelikeController>.Instance.RogueChooseDataResultRequest(EPerkType.Shop);
		};

		// Token: 0x0200B176 RID: 45430
		[NullableContext(0)]
		private static class ERoguelikeShopDefine
		{
			// Token: 0x04037084 RID: 225412
			public const int TxtName = 0;

			// Token: 0x04037085 RID: 225413
			public const int TxtHave = 1;

			// Token: 0x04037086 RID: 225414
			public const int TxtType = 2;

			// Token: 0x04037087 RID: 225415
			public const int TxtDesc = 3;

			// Token: 0x04037088 RID: 225416
			public const int PanelAttr = 4;

			// Token: 0x04037089 RID: 225417
			public const int AttrItem = 5;

			// Token: 0x0403708A RID: 225418
			public const int PanelCost = 6;

			// Token: 0x0403708B RID: 225419
			public const int BtnConfirm = 7;

			// Token: 0x0403708C RID: 225420
			public const int TextureCurrencyIcon = 8;

			// Token: 0x0403708D RID: 225421
			public const int TxtCurrencyCurPrice = 9;

			// Token: 0x0403708E RID: 225422
			public const int TxtCurrencyOriginPrice = 10;

			// Token: 0x0403708F RID: 225423
			public const int ElementLayout = 11;
		}
	}
}
