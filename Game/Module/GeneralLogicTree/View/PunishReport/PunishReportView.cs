using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.View.PunishReport
{
	// Token: 0x02005CCF RID: 23759
	public class PunishReportView : UiViewBase
	{
		// Token: 0x0603BE95 RID: 245397 RVA: 0x00F2EF74 File Offset: 0x00F2D174
		[NullableContext(1)]
		public PunishReportView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE96 RID: 245398 RVA: 0x00F2EF80 File Offset: 0x00F2D180
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BE97 RID: 245399 RVA: 0x00F2F02C File Offset: 0x00F2D22C
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd), false);
			IPunishReport punishReport = this.OpenParam as IPunishReport;
			if (punishReport == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(punishReport.MainText))
			{
				string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(punishReport.MainText);
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.SetText(configTextByKey, true);
				}
			}
			if (!string.IsNullOrEmpty(punishReport.SubText))
			{
				string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(punishReport.SubText);
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.SetText(configTextByKey2, true);
				}
			}
			if (!(punishReport.ShowType != EPunishReportShowType.Storm))
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_TipsIconXuZhiCiBao1");
				base.SetTextureByPath(resourcePath, base.GetTexture(2), null, null);
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_TipsIconXuZhiCiBao2");
				base.SetTextureByPath(resourcePath2, base.GetTexture(3), null, null);
			}
		}

		// Token: 0x0603BE98 RID: 245400 RVA: 0x00F2F140 File Offset: 0x00F2D340
		[NullableContext(1)]
		private void OnStartSequenceEnd(string _)
		{
			this.UiViewSequence.RemoveSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd));
			base.CloseMe(null);
		}

		// Token: 0x0200BD50 RID: 48464
		private enum EViewComponent
		{
			// Token: 0x0403A549 RID: 238921
			TitleText,
			// Token: 0x0403A54A RID: 238922
			DescribeText,
			// Token: 0x0403A54B RID: 238923
			Texture1,
			// Token: 0x0403A54C RID: 238924
			Texture2
		}
	}
}
