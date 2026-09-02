using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FCF RID: 20431
	public class SheriffArrestPopupView : UiViewBase
	{
		// Token: 0x06034B02 RID: 215810 RVA: 0x00D36377 File Offset: 0x00D34577
		[NullableContext(1)]
		public SheriffArrestPopupView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B03 RID: 215811 RVA: 0x00D36380 File Offset: 0x00D34580
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034B04 RID: 215812 RVA: 0x00D3640C File Offset: 0x00D3460C
		protected override void OnStart()
		{
			SheriffArrestPopupViewData sheriffArrestPopupViewData = this.OpenParam as SheriffArrestPopupViewData;
			if (sheriffArrestPopupViewData == null)
			{
				return;
			}
			int identity = ModelBase<SheriffModel>.Instance.GetCriminalInfo(sheriffArrestPopupViewData.CriminalId).Identity;
			SheriffCriminal? criminalConfigById = ConfigBase<SheriffConfig>.Instance.GetCriminalConfigById(sheriffArrestPopupViewData.CriminalId);
			int id = (criminalConfigById != null) ? criminalConfigById.GetValueOrDefault().DropId : 0;
			Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(id);
			int num = 0;
			if (dropPackagePreview != null)
			{
				using (Dictionary<int, int>.Enumerator enumerator = dropPackagePreview.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						num = keyValuePair.Value;
					}
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Sheriff_HudDesc_8", new <>z__ReadOnlySingleElementList<object>(num));
			SheriffIdentity? identityConfigById = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(identity);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), (identityConfigById != null) ? identityConfigById.GetValueOrDefault().Name : null, Array.Empty<object>());
			if (identityConfigById != null && !string.IsNullOrEmpty(identityConfigById.Value.IconConfirm))
			{
				base.SetTextureByPath(identityConfigById.Value.IconConfirm, base.GetTexture(2), null, null);
			}
		}

		// Token: 0x06034B05 RID: 215813 RVA: 0x00D36574 File Offset: 0x00D34774
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200AF9B RID: 44955
		private static class EComponents
		{
			// Token: 0x040367F1 RID: 223217
			public const int TxtName = 0;

			// Token: 0x040367F2 RID: 223218
			public const int TxtTips = 1;

			// Token: 0x040367F3 RID: 223219
			public const int ImgIcon = 2;
		}
	}
}
