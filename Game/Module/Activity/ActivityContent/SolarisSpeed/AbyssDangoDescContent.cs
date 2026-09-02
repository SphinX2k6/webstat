using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200638C RID: 25484
	[NullableContext(1)]
	[Nullable(0)]
	internal class AbyssDangoDescContent : UiPanelBase
	{
		// Token: 0x0603FFF3 RID: 262131 RVA: 0x01066EF0 File Offset: 0x010650F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FFF4 RID: 262132 RVA: 0x01066F7A File Offset: 0x0106517A
		protected override void OnStart()
		{
			this.Scroll = new GenericScrollViewNew<AbyssDangoDescItem, IAbyssDescData>(base.GetScrollViewWithScrollbar(1), new Func<AbyssDangoDescItem>(this.InitScrollItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x0603FFF5 RID: 262133 RVA: 0x01066FAD File Offset: 0x010651AD
		private AbyssDangoDescItem InitScrollItem()
		{
			return new AbyssDangoDescItem();
		}

		// Token: 0x0603FFF6 RID: 262134 RVA: 0x01066FB4 File Offset: 0x010651B4
		private void RefreshDescLayout(List<IAbyssDescData> data)
		{
			AbyssDangoDescContent.<>c__DisplayClass5_0 CS$<>8__locals1 = new AbyssDangoDescContent.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("AbyssDangoDescContent.Refresh", delegate()
			{
				AbyssDangoDescContent.<>c__DisplayClass5_0.<<RefreshDescLayout>b__0>d <<RefreshDescLayout>b__0>d;
				<<RefreshDescLayout>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshDescLayout>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshDescLayout>b__0>d.<>1__state = -1;
				<<RefreshDescLayout>b__0>d.<>t__builder.Start<AbyssDangoDescContent.<>c__DisplayClass5_0.<<RefreshDescLayout>b__0>d>(ref <<RefreshDescLayout>b__0>d);
				return <<RefreshDescLayout>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x0603FFF7 RID: 262135 RVA: 0x01066FF8 File Offset: 0x010651F8
		public void Refresh(IAbyssRolePanelData data)
		{
			List<IAbyssDescData> mainDescData = data.MainDescData;
			if (mainDescData.Count > 0)
			{
				int mainHonorRank = ModelBase<DangoAbyssModel>.Instance.GetMainHonorRank(mainDescData, true);
				IAbyssDescData abyssDescData = mainDescData[0];
				AbyssSettle? abyssSettleById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssSettleById(abyssDescData.Id);
				int count = abyssSettleById.Value.Title().Count;
				int num = (mainHonorRank >= count - 1) ? (count - 1) : mainHonorRank;
				int key = abyssSettleById.Value.Title().Keys.ToArray<int>()[num];
				string text;
				string textStringId;
				if (abyssSettleById.Value.Title().TryGetValue(key, out text))
				{
					textStringId = (text ?? "");
				}
				else
				{
					textStringId = "";
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, Array.Empty<object>());
			}
			this.RefreshDescLayout(data.SubDescData);
		}

		// Token: 0x04023EFB RID: 147195
		protected GenericScrollViewNew<AbyssDangoDescItem, IAbyssDescData> Scroll;

		// Token: 0x0200C3E2 RID: 50146
		[NullableContext(0)]
		private enum EComponentDefine
		{
			// Token: 0x0403C567 RID: 247143
			Title,
			// Token: 0x0403C568 RID: 247144
			DescScroll,
			// Token: 0x0403C569 RID: 247145
			DescItem
		}
	}
}
