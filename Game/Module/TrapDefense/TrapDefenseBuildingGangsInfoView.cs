using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E63 RID: 20067
	public class TrapDefenseBuildingGangsInfoView : UiViewBase
	{
		// Token: 0x06033DE4 RID: 212452 RVA: 0x00CF9E5E File Offset: 0x00CF805E
		[NullableContext(1)]
		public TrapDefenseBuildingGangsInfoView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033DE5 RID: 212453 RVA: 0x00CF9E68 File Offset: 0x00CF8068
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedMask));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033DE6 RID: 212454 RVA: 0x00CF9F50 File Offset: 0x00CF8150
		protected override void OnStart()
		{
			int key = (int)this.OpenParam;
			TrapDefenseBdData valueOrDefault = ModelBase<TrapDefenseModel>.Instance.RougeModeData.BdDataMap.GetValueOrDefault(key);
			if (valueOrDefault == null)
			{
				return;
			}
			base.SetTextureByPath(valueOrDefault.Config.Icon, base.GetTexture(1), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), valueOrDefault.Config.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), valueOrDefault.Config.Desc, Array.Empty<object>());
		}

		// Token: 0x06033DE7 RID: 212455 RVA: 0x00CF9FE7 File Offset: 0x00CF81E7
		private void OnClickedMask()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200AE18 RID: 44568
		internal class EMainDefine
		{
			// Token: 0x04036111 RID: 221457
			public const int BtnMask = 0;

			// Token: 0x04036112 RID: 221458
			public const int Icon = 1;

			// Token: 0x04036113 RID: 221459
			public const int Title = 2;

			// Token: 0x04036114 RID: 221460
			public const int Desc = 3;
		}
	}
}
