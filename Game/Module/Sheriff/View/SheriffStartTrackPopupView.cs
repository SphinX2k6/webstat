using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FD7 RID: 20439
	public class SheriffStartTrackPopupView : UiViewBase
	{
		// Token: 0x06034B38 RID: 215864 RVA: 0x00D37AAE File Offset: 0x00D35CAE
		[NullableContext(1)]
		public SheriffStartTrackPopupView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034B39 RID: 215865 RVA: 0x00D37AB8 File Offset: 0x00D35CB8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034B3A RID: 215866 RVA: 0x00D37B00 File Offset: 0x00D35D00
		protected override void OnStart()
		{
			SheriffStartTrackPopupViewData sheriffStartTrackPopupViewData = this.OpenParam as SheriffStartTrackPopupViewData;
			if (sheriffStartTrackPopupViewData == null)
			{
				return;
			}
			SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(sheriffStartTrackPopupViewData.AnomalyId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), (anomalyConfigById != null) ? anomalyConfigById.GetValueOrDefault().Name : null, Array.Empty<object>());
		}

		// Token: 0x06034B3B RID: 215867 RVA: 0x00D37B5F File Offset: 0x00D35D5F
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200AFA3 RID: 44963
		private static class EComponents
		{
			// Token: 0x0403681B RID: 223259
			public const int TitleText = 0;
		}
	}
}
